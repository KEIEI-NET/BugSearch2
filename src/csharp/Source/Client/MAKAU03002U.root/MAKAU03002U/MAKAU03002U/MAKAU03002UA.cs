//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������(�ꗗ�E�ӁE����)�����t�H�[���N���X
// �v���O�����T�v   : ���������(�ꗗ�E�ӁE����)�����t�H�[���N���X
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
// �Ǘ��ԍ�  11800082-00   �쐬�S�� : ���O
// �� �� ��  2023/01/10    �C�����e : �d�q����A�g�i�������j��CSV�o�͏��ԑΉ�
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO; 
using System.Windows.Forms;
using System.Data;
using System.Threading;
using Microsoft.Win32;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Text;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Application.Remoting.ParamData;
using System.Reflection;
namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���������(�ꗗ�E�ӁE����)�����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���������(�ꗗ�E���v�E����)�����t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
    /// <br>Update Note : 2022/04/21 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br>  
    /// <br>Update Note : 2023/01/10 ���O</br>
    /// <br>�Ǘ��ԍ�    : 11800082-00 �d�q����A�g�i�������j��CSV�o�͏��ԑΉ�</br>
    /// </remarks>
    public class MAKAU03002UA : System.Windows.Forms.Form, IDemandEbooksChildMain
    {
        # region Private Members (Component)
        private System.Windows.Forms.Panel panel1;
        private Infragistics.Win.UltraWinTabControl.UltraTabControl Main_TabControl;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinDock.UltraDockManager Main_DockManager;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private System.Windows.Forms.Panel ExtraInfo_Panel;
        private System.Windows.Forms.Panel ExtraData_Panel;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private System.Windows.Forms.Panel PrintExtra_Panel;
        private System.Windows.Forms.Panel DataView_Panel;
        private System.Windows.Forms.Panel Total_Panel;
        private System.Windows.Forms.Panel panel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private System.Windows.Forms.Panel panel7;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit6;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private Infragistics.Win.UltraWinGrid.UltraGrid DEMANDLISTVIEW;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl SectionList_ExplorerBarContainerControl;
        private Infragistics.Win.UltraWinTree.UltraTree Section_Tree;
        private Infragistics.Win.UltraWinDock.WindowDockingArea windowDockingArea1;
        private Infragistics.Win.UltraWinDock.DockableWindow dockableWindow1;
        private System.Windows.Forms.Timer Initial_Timer;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToGridColumn_CheckEditor;
        private Broadleaf.Library.Windows.Forms.TNedit TotalSales_tNedit;
        private Infragistics.Win.Misc.UltraButton Select_Button;
        private Infragistics.Win.Misc.UltraButton UnSelect_Button;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03002UAUnpinnedTabAreaLeft;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03002UAUnpinnedTabAreaRight;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03002UAUnpinnedTabAreaTop;
        private Infragistics.Win.UltraWinDock.UnpinnedTabArea _MAKAU03002UAUnpinnedTabAreaBottom;
        private Infragistics.Win.UltraWinDock.AutoHideControl _MAKAU03002UAAutoHideControl;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl5;
        private Broadleaf.Library.Windows.Forms.TComboEditor PrintOder_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Broadleaf.Library.Windows.Forms.TDateEdit AddUpDate_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode_Ed;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Broadleaf.Library.Windows.Forms.TComboEditor ChargeEmployee_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Broadleaf.Library.Windows.Forms.TComboEditor OutPutPriceCond_tComboEditor;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Extra_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinTree.UltraTree History_Tree;
        private System.Windows.Forms.ToolTip History_ToolTip;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Panel panel2;
        private Broadleaf.Library.Windows.Forms.TNedit TotalDmd_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
        private System.Windows.Forms.Panel panel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Broadleaf.Library.Windows.Forms.TNedit TotalDeposit_tNedit;
        private System.Windows.Forms.Panel panel4;
        private Broadleaf.Library.Windows.Forms.TNedit TotalLastDmd_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel19;
        private System.Windows.Forms.Panel panel5;
        private Broadleaf.Library.Windows.Forms.TNedit TotalTax_tNedit;
        private System.Windows.Forms.Panel panel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel22;
        private Broadleaf.Library.Windows.Forms.TNedit RpSlipCount_tNedit;
        private Infragistics.Win.Misc.UltraLabel BillTableOutPut_Label;
        private Infragistics.Win.Misc.UltraLabel ConsTaxTiTle_Label;
        private System.Windows.Forms.MenuItem menuItem2;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager Button_UToolTipManager;
        private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton EmployeeCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton EmployeeCdSt_GuideBtn;
        private TEdit tEdit_EmployeeCode_Ed;
        private TEdit tEdit_EmployeeCode_St;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraButton ub_SalesAreaCodeStGuid;
        private Infragistics.Win.Misc.UltraButton ub_SalesAreaCodeEdGuid;
        private TNedit tNedit_SalesAreaCode_St;
        private TNedit tNedit_SalesAreaCode_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TDateEdit IssueDay_tDateEdit;
        private UiMemInput uiMemInput1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl6;
        private TNedit tEdit_SectionCode_Ed;
        private TNedit tEdit_SectionCode_St;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor endRangeNameUltraTextEditor;
        private Infragistics.Win.Misc.UltraLabel endRangeUltraLabel;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor startRangeNameUltraTextEditor;
        private Infragistics.Win.Misc.UltraLabel startRangeUltraLabel;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl7;
        private TComboEditor tComboEditor_PrintTarget;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TComboEditor tComboEditor_OutputTarget;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private TComboEditor tComboEditor_Pattern;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_Pattern;
        private TComboEditor Pattern_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel tLebal_Example;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Panel panel9;
        private TComboEditor tComboEditor_TaxPrintDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel20;
        private Panel panel_LineMaSqOfChDiv;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private TComboEditor lineMaSqOfChDiv_tComboEditor;
        private Panel panel_PrintBlLiDiv;
        private Infragistics.Win.Misc.UltraLabel Label_PrintBlLiDiv;
        private TComboEditor PrintBlLiDiv_tComboEditor;
        private Panel panel_NewPage;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private TComboEditor NewPageDiv_tComboEditor;
        private Panel panel_AccRecDivCd;
        private Infragistics.Win.Misc.UltraLabel ultraLabel23;
        private TComboEditor AccRecDivCd_tComboEditor;
        private Panel panel_BalanceDepositDtl_;
        private Infragistics.Win.Misc.UltraLabel ultraLabel24;
        private TComboEditor BalanceDepositDtl_tComboEditor;
        private Panel panel_CollectRate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private TComboEditor CollectRatePrtDiv_tComboEditor;
        private System.ComponentModel.IContainer components;
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// ���������(�ꗗ�E���v�E����)�����t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �R���X�g���N�^�������̊T�v���L�q</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public MAKAU03002UA()
        {
            try
            {
                InitializeComponent();

                mDemandEBooksPrintAcs = new DemandEBooksPrintAcs();
                mPdfHistoryControl = new PdfHistoryControl();

                this._extraInfo_DemandTotal = new ExtrInfo_EBooksDemandTotal();
                this._prevExtraInfo_DemandTotal = new ExtrInfo_EBooksDemandTotal();
                this._sectionCodeList = new Hashtable();

                // �o�͍ςݗ����Ǘ��N���X
                this._printHistoryList = new Hashtable();
                this._printHistoryKeyList = new ArrayList();
                PdfHistoryControl.PdfHistoryListChanged += new PdfHistoryListChangedEvent(this.DisplaySettingPdfList);

                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // ���O�C���S����
                this._loginEmployee = LoginInfoAcquisition.Employee.Clone();

                // �A�N�Z�X�N���X �C���X�^���X����
                this._employeeAcs = new EmployeeAcs();

                this._userGuideAcs = new UserGuideAcs();

                //���t�擾���i
                this._dateGetAcs = DateGetAcs.GetInstance();

                List<Control> ctrlList = new List<Control>();
                ctrlList.Add(this.PrintOder_tComboEditor);              // �o�͏�
                ctrlList.Add(this.OutPutPriceCond_tComboEditor);        // �o�͋��z�敪

                ctrlList.Add(this.NewPageDiv_tComboEditor);         // ����
                ctrlList.Add(this.ChargeEmployee_tComboEditor);     // �S��
                ctrlList.Add(this.tEdit_EmployeeCode_St);           // �]�ƈ��R�[�h�J�n
                ctrlList.Add(this.tEdit_EmployeeCode_Ed);           // �]�ƈ��R�[�h�I��
                ctrlList.Add(this.tNedit_SalesAreaCode_St);         // �n��R�[�h�J�n
                ctrlList.Add(this.tNedit_SalesAreaCode_Ed);         // �n��R�[�h�I��
                ctrlList.Add(this.tNedit_CustomerCode_St);          // ���Ӑ�R�[�h�J�n
                ctrlList.Add(this.tNedit_CustomerCode_Ed);          // ���Ӑ�R�[�h�I��
                ctrlList.Add(this.AccRecDivCd_tComboEditor);        // ���|�敪
                ctrlList.Add(this.CollectRatePrtDiv_tComboEditor);  // �������
                ctrlList.Add(this.BalanceDepositDtl_tComboEditor);  // �c����������
                ctrlList.Add(this.IssueDay_tDateEdit);  // ���s��
                ctrlList.Add(this.tComboEditor_OutputTarget);        // �d�q����o�͐ݒ�
                ctrlList.Add(this.tComboEditor_PrintTarget);     // ����A����v���r���[�ݒ�
                ctrlList.Add(this.tComboEditor_TaxPrintDiv); // �ŕʓ���󎚋敪

                // ����������p�^�[���}�X�^�A�N�Z�X�N���X�C���X�^���X��
                this.DmdPrtPtnAcsObj = new DmdPrtPtnAcs();
                ctrlList.Add(this.tComboEditor_Pattern);
                ctrlList.Add(this.Pattern_tComboEditor);

                uiMemInput1.TargetControls = ctrlList;

                this.StatusBarInfoPrinted += new PrintStatusBar(PrintStatusBarOfDefault);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance143 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance144 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance145 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance146 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance147 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance148 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance149 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance150 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup5 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�S�đI�����܂�", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�S�Ă̑I�����������܂�", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup6 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup7 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup8 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinDock.DockAreaPane dockAreaPane1 = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.DockedLeft, new System.Guid("920e15ec-1184-42a2-9b25-5dbbe53ad37a"));
            Infragistics.Win.UltraWinDock.DockableControlPane dockableControlPane1 = new Infragistics.Win.UltraWinDock.DockableControlPane(new System.Guid("8c0ea4bb-1e17-45f9-8bf8-706ad246d773"), new System.Guid("00000000-0000-0000-0000-000000000000"), -1, new System.Guid("920e15ec-1184-42a2-9b25-5dbbe53ad37a"), -1);
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tComboEditor_TaxPrintDiv = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.panel_LineMaSqOfChDiv = new System.Windows.Forms.Panel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.lineMaSqOfChDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_PrintBlLiDiv = new System.Windows.Forms.Panel();
            this.Label_PrintBlLiDiv = new Infragistics.Win.Misc.UltraLabel();
            this.PrintBlLiDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_NewPage = new System.Windows.Forms.Panel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.NewPageDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AddUpDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.panel_AccRecDivCd = new System.Windows.Forms.Panel();
            this.ultraLabel23 = new Infragistics.Win.Misc.UltraLabel();
            this.AccRecDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PrintTarget = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_OutputTarget = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ub_SalesAreaCodeStGuid = new Infragistics.Win.Misc.UltraButton();
            this.ub_SalesAreaCodeEdGuid = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_SalesAreaCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesAreaCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tNedit_CustomerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.EmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ChargeEmployee_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraExplorerBarContainerControl5 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.panel_BalanceDepositDtl_ = new System.Windows.Forms.Panel();
            this.ultraLabel24 = new Infragistics.Win.Misc.UltraLabel();
            this.BalanceDepositDtl_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.panel_CollectRate = new System.Windows.Forms.Panel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.CollectRatePrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.IssueDay_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.BillTableOutPut_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OutPutPriceCond_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraExplorerBarContainerControl7 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_Pattern = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel_Pattern = new Infragistics.Win.Misc.UltraLabel();
            this.Pattern_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.tLebal_Example = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl6 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tEdit_SectionCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_SectionCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.endRangeNameUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.endRangeUltraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.startRangeNameUltraTextEditor = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.startRangeUltraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionList_ExplorerBarContainerControl = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.Section_Tree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.History_Tree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ExtraInfo_Panel = new System.Windows.Forms.Panel();
            this.Extra_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.ExtraData_Panel = new System.Windows.Forms.Panel();
            this.DataView_Panel = new System.Windows.Forms.Panel();
            this.DEMANDLISTVIEW = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraGrid1 = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Total_Panel = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ultraLabel22 = new Infragistics.Win.Misc.UltraLabel();
            this.RpSlipCount_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TotalLastDmd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.TotalDeposit_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.TotalSales_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ConsTaxTiTle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TotalTax_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotalDmd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.PrintExtra_Panel = new System.Windows.Forms.Panel();
            this.AutoFillToGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.Select_Button = new Infragistics.Win.Misc.UltraButton();
            this.UnSelect_Button = new Infragistics.Win.Misc.UltraButton();
            this.Main_ExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Main_TabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Main_DockManager = new Infragistics.Win.UltraWinDock.UltraDockManager(this.components);
            this._MAKAU03002UAUnpinnedTabAreaLeft = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03002UAUnpinnedTabAreaRight = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03002UAUnpinnedTabAreaTop = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03002UAUnpinnedTabAreaBottom = new Infragistics.Win.UltraWinDock.UnpinnedTabArea();
            this._MAKAU03002UAAutoHideControl = new Infragistics.Win.UltraWinDock.AutoHideControl();
            this.dockableWindow1 = new Infragistics.Win.UltraWinDock.DockableWindow();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tNedit6 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.windowDockingArea1 = new Infragistics.Win.UltraWinDock.WindowDockingArea();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.History_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Button_UToolTipManager = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.uiMemInput1 = new Broadleaf.Library.Windows.Forms.UiMemInput(this.components);
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).BeginInit();
            this.panel_LineMaSqOfChDiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineMaSqOfChDiv_tComboEditor)).BeginInit();
            this.panel_PrintBlLiDiv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBlLiDiv_tComboEditor)).BeginInit();
            this.panel_NewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageDiv_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            this.panel_AccRecDivCd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccRecDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OutputTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChargeEmployee_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl5.SuspendLayout();
            this.panel_BalanceDepositDtl_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceDepositDtl_tComboEditor)).BeginInit();
            this.panel_CollectRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectRatePrtDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutPriceCond_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_Pattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pattern_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRangeNameUltraTextEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRangeNameUltraTextEditor)).BeginInit();
            this.SectionList_ExplorerBarContainerControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Section_Tree)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.History_Tree)).BeginInit();
            this.ultraTabPageControl1.SuspendLayout();
            this.ExtraInfo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Extra_ultraExplorerBar)).BeginInit();
            this.Extra_ultraExplorerBar.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.ExtraData_Panel.SuspendLayout();
            this.DataView_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DEMANDLISTVIEW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.Total_Panel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RpSlipCount_tNedit)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalLastDmd_tNedit)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDeposit_tNedit)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSales_tNedit)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalTax_tNedit)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDmd_tNedit)).BeginInit();
            this.PrintExtra_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ExplorerBar)).BeginInit();
            this.Main_ExplorerBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_TabControl)).BeginInit();
            this.Main_TabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).BeginInit();
            this.dockableWindow1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit6)).BeginInit();
            this.windowDockingArea1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel9);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel_LineMaSqOfChDiv);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel_PrintBlLiDiv);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.panel_NewPage);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.AddUpDate_tDateEdit);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(644, 155);
            this.ultraExplorerBarContainerControl2.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tComboEditor_TaxPrintDiv);
            this.panel9.Controls.Add(this.ultraLabel20);
            this.panel9.Location = new System.Drawing.Point(6, 122);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(535, 30);
            this.panel9.TabIndex = 214;
            this.panel9.Visible = false;
            // 
            // tComboEditor_TaxPrintDiv
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ActiveAppearance = appearance49;
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_TaxPrintDiv.Appearance = appearance51;
            this.tComboEditor_TaxPrintDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_TaxPrintDiv.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_TaxPrintDiv.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_TaxPrintDiv.ItemAppearance = appearance50;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "�󎚂���";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "�󎚂��Ȃ�";
            this.tComboEditor_TaxPrintDiv.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.tComboEditor_TaxPrintDiv.Location = new System.Drawing.Point(193, 3);
            this.tComboEditor_TaxPrintDiv.Name = "tComboEditor_TaxPrintDiv";
            this.tComboEditor_TaxPrintDiv.Size = new System.Drawing.Size(176, 24);
            this.tComboEditor_TaxPrintDiv.TabIndex = 1;
            // 
            // ultraLabel20
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance48;
            this.ultraLabel20.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel20.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel20.Location = new System.Drawing.Point(43, 4);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(141, 23);
            this.ultraLabel20.TabIndex = 210;
            this.ultraLabel20.Text = "�ŕʓ����";
            // 
            // panel_LineMaSqOfChDiv
            // 
            this.panel_LineMaSqOfChDiv.Controls.Add(this.ultraLabel15);
            this.panel_LineMaSqOfChDiv.Controls.Add(this.lineMaSqOfChDiv_tComboEditor);
            this.panel_LineMaSqOfChDiv.Location = new System.Drawing.Point(6, 91);
            this.panel_LineMaSqOfChDiv.Name = "panel_LineMaSqOfChDiv";
            this.panel_LineMaSqOfChDiv.Size = new System.Drawing.Size(535, 30);
            this.panel_LineMaSqOfChDiv.TabIndex = 213;
            this.panel_LineMaSqOfChDiv.Visible = false;
            // 
            // ultraLabel15
            // 
            appearance134.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance134;
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel15.Location = new System.Drawing.Point(43, 4);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel15.TabIndex = 208;
            this.ultraLabel15.Text = "�r����";
            // 
            // lineMaSqOfChDiv_tComboEditor
            // 
            appearance135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.lineMaSqOfChDiv_tComboEditor.ActiveAppearance = appearance135;
            appearance136.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.lineMaSqOfChDiv_tComboEditor.Appearance = appearance136;
            this.lineMaSqOfChDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.lineMaSqOfChDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.lineMaSqOfChDiv_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance137.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.lineMaSqOfChDiv_tComboEditor.ItemAppearance = appearance137;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "�󎚂���";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "�󎚂��Ȃ�";
            this.lineMaSqOfChDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.lineMaSqOfChDiv_tComboEditor.Location = new System.Drawing.Point(193, 4);
            this.lineMaSqOfChDiv_tComboEditor.Name = "lineMaSqOfChDiv_tComboEditor";
            this.lineMaSqOfChDiv_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.lineMaSqOfChDiv_tComboEditor.TabIndex = 1;
            // 
            // panel_PrintBlLiDiv
            // 
            this.panel_PrintBlLiDiv.Controls.Add(this.Label_PrintBlLiDiv);
            this.panel_PrintBlLiDiv.Controls.Add(this.PrintBlLiDiv_tComboEditor);
            this.panel_PrintBlLiDiv.Location = new System.Drawing.Point(6, 61);
            this.panel_PrintBlLiDiv.Name = "panel_PrintBlLiDiv";
            this.panel_PrintBlLiDiv.Size = new System.Drawing.Size(535, 30);
            this.panel_PrintBlLiDiv.TabIndex = 212;
            this.panel_PrintBlLiDiv.Visible = false;
            // 
            // Label_PrintBlLiDiv
            // 
            appearance130.TextVAlignAsString = "Middle";
            this.Label_PrintBlLiDiv.Appearance = appearance130;
            this.Label_PrintBlLiDiv.BackColorInternal = System.Drawing.Color.Transparent;
            this.Label_PrintBlLiDiv.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label_PrintBlLiDiv.Location = new System.Drawing.Point(43, 3);
            this.Label_PrintBlLiDiv.Name = "Label_PrintBlLiDiv";
            this.Label_PrintBlLiDiv.Size = new System.Drawing.Size(100, 23);
            this.Label_PrintBlLiDiv.TabIndex = 208;
            this.Label_PrintBlLiDiv.Text = "�󔒍s��";
            // 
            // PrintBlLiDiv_tComboEditor
            // 
            appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintBlLiDiv_tComboEditor.ActiveAppearance = appearance131;
            appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintBlLiDiv_tComboEditor.Appearance = appearance132;
            this.PrintBlLiDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintBlLiDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrintBlLiDiv_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintBlLiDiv_tComboEditor.ItemAppearance = appearance133;
            valueListItem5.DataValue = 0;
            valueListItem5.DisplayText = "�󎚂���";
            valueListItem6.DataValue = 1;
            valueListItem6.DisplayText = "�󎚂��Ȃ�";
            this.PrintBlLiDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6});
            this.PrintBlLiDiv_tComboEditor.Location = new System.Drawing.Point(193, 3);
            this.PrintBlLiDiv_tComboEditor.Name = "PrintBlLiDiv_tComboEditor";
            this.PrintBlLiDiv_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.PrintBlLiDiv_tComboEditor.TabIndex = 1;
            // 
            // panel_NewPage
            // 
            this.panel_NewPage.Controls.Add(this.ultraLabel13);
            this.panel_NewPage.Controls.Add(this.NewPageDiv_tComboEditor);
            this.panel_NewPage.Location = new System.Drawing.Point(6, 32);
            this.panel_NewPage.Name = "panel_NewPage";
            this.panel_NewPage.Size = new System.Drawing.Size(535, 30);
            this.panel_NewPage.TabIndex = 210;
            this.panel_NewPage.Visible = false;
            // 
            // ultraLabel13
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance38;
            this.ultraLabel13.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel13.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel13.Location = new System.Drawing.Point(43, 3);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel13.TabIndex = 208;
            this.ultraLabel13.Text = "���@�@��";
            // 
            // NewPageDiv_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageDiv_tComboEditor.ActiveAppearance = appearance17;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NewPageDiv_tComboEditor.Appearance = appearance34;
            this.NewPageDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.NewPageDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.NewPageDiv_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageDiv_tComboEditor.ItemAppearance = appearance18;
            valueListItem7.DataValue = 0;
            valueListItem7.DisplayText = "���_";
            valueListItem8.DataValue = 1;
            valueListItem8.DisplayText = "���v";
            valueListItem9.DataValue = 2;
            valueListItem9.DisplayText = "���Ȃ�";
            this.NewPageDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem7,
            valueListItem8,
            valueListItem9});
            this.NewPageDiv_tComboEditor.Location = new System.Drawing.Point(193, 3);
            this.NewPageDiv_tComboEditor.Name = "NewPageDiv_tComboEditor";
            this.NewPageDiv_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.NewPageDiv_tComboEditor.TabIndex = 1;
            // 
            // AddUpDate_tDateEdit
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AddUpDate_tDateEdit.ActiveEditAppearance = appearance22;
            this.AddUpDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.AddUpDate_tDateEdit.CalendarDisp = true;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance23.TextHAlignAsString = "Left";
            appearance23.TextVAlignAsString = "Middle";
            this.AddUpDate_tDateEdit.EditAppearance = appearance23;
            this.AddUpDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.AddUpDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AddUpDate_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance32.TextHAlignAsString = "Left";
            appearance32.TextVAlignAsString = "Middle";
            this.AddUpDate_tDateEdit.LabelAppearance = appearance32;
            this.AddUpDate_tDateEdit.Location = new System.Drawing.Point(199, 6);
            this.AddUpDate_tDateEdit.Name = "AddUpDate_tDateEdit";
            this.AddUpDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.AddUpDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.AddUpDate_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.AddUpDate_tDateEdit.TabIndex = 0;
            this.AddUpDate_tDateEdit.TabStop = true;
            // 
            // ultraLabel3
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance11;
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel3.Location = new System.Drawing.Point(50, 6);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(100, 23);
            this.ultraLabel3.TabIndex = 208;
            this.ultraLabel3.Text = "���@�@��";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 239);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(644, 37);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance122;
            appearance123.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.Appearance = appearance123;
            this.PrintOder_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrintOder_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance124;
            valueListItem10.DataValue = 0;
            valueListItem10.DisplayText = "���Ӑ揇";
            valueListItem11.DataValue = 1;
            valueListItem11.DisplayText = "�S���ҏ�";
            valueListItem12.DataValue = 2;
            valueListItem12.DisplayText = "�n�揇";
            this.PrintOder_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem10,
            valueListItem11,
            valueListItem12});
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(199, 6);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(184, 24);
            this.PrintOder_tComboEditor.TabIndex = 0;
            this.PrintOder_tComboEditor.SelectionChangeCommitted += new System.EventHandler(this.PrintOder_tComboEditor_SelectionChangeCommitted);
            // 
            // ultraLabel5
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance35;
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel5.Location = new System.Drawing.Point(50, 6);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 209;
            this.ultraLabel5.Text = "�o�͏�";
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.panel_AccRecDivCd);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_PrintTarget);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel1);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_OutputTarget);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ub_SalesAreaCodeStGuid);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ub_SalesAreaCodeEdGuid);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tNedit_SalesAreaCode_St);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tNedit_SalesAreaCode_Ed);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tEdit_EmployeeCode_Ed);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tEdit_EmployeeCode_St);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tNedit_CustomerCode_Ed);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.EmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tNedit_CustomerCode_St);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.EmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ChargeEmployee_tComboEditor);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 314);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(644, 184);
            this.ultraExplorerBarContainerControl4.TabIndex = 2;
            // 
            // panel_AccRecDivCd
            // 
            this.panel_AccRecDivCd.Controls.Add(this.ultraLabel23);
            this.panel_AccRecDivCd.Controls.Add(this.AccRecDivCd_tComboEditor);
            this.panel_AccRecDivCd.Location = new System.Drawing.Point(6, 150);
            this.panel_AccRecDivCd.Name = "panel_AccRecDivCd";
            this.panel_AccRecDivCd.Size = new System.Drawing.Size(535, 30);
            this.panel_AccRecDivCd.TabIndex = 256;
            // 
            // ultraLabel23
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel23.Appearance = appearance12;
            this.ultraLabel23.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel23.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel23.Location = new System.Drawing.Point(43, 3);
            this.ultraLabel23.Name = "ultraLabel23";
            this.ultraLabel23.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel23.TabIndex = 251;
            this.ultraLabel23.Text = "���|�敪";
            // 
            // AccRecDivCd_tComboEditor
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AccRecDivCd_tComboEditor.ActiveAppearance = appearance1;
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AccRecDivCd_tComboEditor.Appearance = appearance104;
            this.AccRecDivCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AccRecDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AccRecDivCd_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AccRecDivCd_tComboEditor.ItemAppearance = appearance2;
            valueListItem13.DataValue = 1;
            valueListItem13.DisplayText = "���|";
            valueListItem14.DataValue = 0;
            valueListItem14.DisplayText = "���|�Ȃ�";
            valueListItem15.DataValue = -1;
            valueListItem15.DisplayText = "�S��";
            this.AccRecDivCd_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem13,
            valueListItem14,
            valueListItem15});
            this.AccRecDivCd_tComboEditor.Location = new System.Drawing.Point(193, 3);
            this.AccRecDivCd_tComboEditor.Name = "AccRecDivCd_tComboEditor";
            this.AccRecDivCd_tComboEditor.Size = new System.Drawing.Size(184, 24);
            this.AccRecDivCd_tComboEditor.TabIndex = 0;
            // 
            // ultraLabel12
            // 
            appearance107.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance107;
            this.ultraLabel12.Font = new System.Drawing.Font("�l�r �S�V�b�N", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel12.Location = new System.Drawing.Point(477, 124);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(184, 23);
            this.ultraLabel12.TabIndex = 263;
            this.ultraLabel12.Text = "��[���]/[����v���r���[]�̐ݒ�";
            // 
            // ultraLabel4
            // 
            appearance111.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance111;
            this.ultraLabel4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel4.Location = new System.Drawing.Point(478, 94);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(161, 23);
            this.ultraLabel4.TabIndex = 262;
            this.ultraLabel4.Text = "��[�d�q���듯��]�̐ݒ�";
            // 
            // tComboEditor_PrintTarget
            // 
            appearance114.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintTarget.ActiveAppearance = appearance114;
            appearance115.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance115.TextVAlignAsString = "Middle";
            this.tComboEditor_PrintTarget.Appearance = appearance115;
            this.tComboEditor_PrintTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PrintTarget.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_PrintTarget.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintTarget.ItemAppearance = appearance26;
            valueListItem16.DataValue = 0;
            valueListItem16.DisplayText = "�S�ďo��";
            valueListItem17.DataValue = 1;
            valueListItem17.DisplayText = "�d�q����o�͐ݒ肠��̐�����";
            valueListItem18.DataValue = 2;
            valueListItem18.DisplayText = "�d�q����o�͐ݒ�Ȃ��̐�����";
            this.tComboEditor_PrintTarget.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem16,
            valueListItem17,
            valueListItem18});
            this.tComboEditor_PrintTarget.Location = new System.Drawing.Point(199, 123);
            this.tComboEditor_PrintTarget.Name = "tComboEditor_PrintTarget";
            this.tComboEditor_PrintTarget.Size = new System.Drawing.Size(272, 24);
            this.tComboEditor_PrintTarget.TabIndex = 260;
            // 
            // ultraLabel1
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance37;
            this.ultraLabel1.Location = new System.Drawing.Point(49, 124);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(141, 23);
            this.ultraLabel1.TabIndex = 261;
            this.ultraLabel1.Text = "����Ώ�";
            // 
            // tComboEditor_OutputTarget
            // 
            appearance142.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OutputTarget.ActiveAppearance = appearance142;
            appearance143.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance143.TextVAlignAsString = "Middle";
            this.tComboEditor_OutputTarget.Appearance = appearance143;
            this.tComboEditor_OutputTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_OutputTarget.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_OutputTarget.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance144.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_OutputTarget.ItemAppearance = appearance144;
            valueListItem19.DataValue = 0;
            valueListItem19.DisplayText = "�S�ďo��";
            valueListItem20.DataValue = 1;
            valueListItem20.DisplayText = "�d�q����o�͐ݒ�ɏ]��";
            this.tComboEditor_OutputTarget.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem19,
            valueListItem20});
            this.tComboEditor_OutputTarget.Location = new System.Drawing.Point(199, 93);
            this.tComboEditor_OutputTarget.Name = "tComboEditor_OutputTarget";
            this.tComboEditor_OutputTarget.Size = new System.Drawing.Size(272, 24);
            this.tComboEditor_OutputTarget.TabIndex = 258;
            // 
            // ultraLabel6
            // 
            appearance145.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance145;
            this.ultraLabel6.Location = new System.Drawing.Point(49, 94);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(141, 23);
            this.ultraLabel6.TabIndex = 259;
            this.ultraLabel6.Text = "�d�q����o�͑Ώ�";
            // 
            // ultraLabel2
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance27;
            this.ultraLabel2.Location = new System.Drawing.Point(50, 34);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel2.TabIndex = 257;
            this.ultraLabel2.Text = "�n��";
            // 
            // ub_SalesAreaCodeStGuid
            // 
            appearance28.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_SalesAreaCodeStGuid.Appearance = appearance28;
            this.ub_SalesAreaCodeStGuid.Location = new System.Drawing.Point(249, 33);
            this.ub_SalesAreaCodeStGuid.Name = "ub_SalesAreaCodeStGuid";
            this.ub_SalesAreaCodeStGuid.Size = new System.Drawing.Size(25, 25);
            this.ub_SalesAreaCodeStGuid.TabIndex = 6;
            this.ub_SalesAreaCodeStGuid.Tag = "3";
            this.ub_SalesAreaCodeStGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_SalesAreaCodeStGuid.Click += new System.EventHandler(this.ub_SalesAreaCodeStGuid_Click);
            // 
            // ub_SalesAreaCodeEdGuid
            // 
            appearance29.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_SalesAreaCodeEdGuid.Appearance = appearance29;
            this.ub_SalesAreaCodeEdGuid.Location = new System.Drawing.Point(406, 33);
            this.ub_SalesAreaCodeEdGuid.Name = "ub_SalesAreaCodeEdGuid";
            this.ub_SalesAreaCodeEdGuid.Size = new System.Drawing.Size(25, 25);
            this.ub_SalesAreaCodeEdGuid.TabIndex = 8;
            this.ub_SalesAreaCodeEdGuid.Tag = "4";
            this.ub_SalesAreaCodeEdGuid.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_SalesAreaCodeEdGuid.Click += new System.EventHandler(this.ub_SalesAreaCodeEdGuid_Click);
            // 
            // tNedit_SalesAreaCode_St
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SalesAreaCode_St.ActiveAppearance = appearance74;
            appearance75.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_St.Appearance = appearance75;
            this.tNedit_SalesAreaCode_St.AutoSelect = true;
            this.tNedit_SalesAreaCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_St.DataText = "";
            this.tNedit_SalesAreaCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_St.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SalesAreaCode_St.Location = new System.Drawing.Point(199, 34);
            this.tNedit_SalesAreaCode_St.MaxLength = 4;
            this.tNedit_SalesAreaCode_St.Name = "tNedit_SalesAreaCode_St";
            this.tNedit_SalesAreaCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_SalesAreaCode_St.TabIndex = 5;
            // 
            // tNedit_SalesAreaCode_Ed
            // 
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SalesAreaCode_Ed.ActiveAppearance = appearance76;
            appearance84.TextHAlignAsString = "Right";
            this.tNedit_SalesAreaCode_Ed.Appearance = appearance84;
            this.tNedit_SalesAreaCode_Ed.AutoSelect = true;
            this.tNedit_SalesAreaCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesAreaCode_Ed.DataText = "";
            this.tNedit_SalesAreaCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesAreaCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesAreaCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SalesAreaCode_Ed.Location = new System.Drawing.Point(356, 34);
            this.tNedit_SalesAreaCode_Ed.MaxLength = 4;
            this.tNedit_SalesAreaCode_Ed.Name = "tNedit_SalesAreaCode_Ed";
            this.tNedit_SalesAreaCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_SalesAreaCode_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_SalesAreaCode_Ed.TabIndex = 7;
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance146.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance146;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(446, 63);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 12;
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // tEdit_EmployeeCode_Ed
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_Ed.ActiveAppearance = appearance31;
            this.tEdit_EmployeeCode_Ed.AutoSelect = true;
            this.tEdit_EmployeeCode_Ed.DataText = "";
            this.tEdit_EmployeeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_EmployeeCode_Ed.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_EmployeeCode_Ed.Location = new System.Drawing.Point(356, 4);
            this.tEdit_EmployeeCode_Ed.MaxLength = 9;
            this.tEdit_EmployeeCode_Ed.Name = "tEdit_EmployeeCode_Ed";
            this.tEdit_EmployeeCode_Ed.Size = new System.Drawing.Size(44, 24);
            this.tEdit_EmployeeCode_Ed.TabIndex = 3;
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance39.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance39;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(289, 63);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 10;
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // tEdit_EmployeeCode_St
            // 
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_St.ActiveAppearance = appearance93;
            this.tEdit_EmployeeCode_St.AutoSelect = true;
            this.tEdit_EmployeeCode_St.DataText = "";
            this.tEdit_EmployeeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.tEdit_EmployeeCode_St.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_EmployeeCode_St.Location = new System.Drawing.Point(199, 4);
            this.tEdit_EmployeeCode_St.MaxLength = 9;
            this.tEdit_EmployeeCode_St.Name = "tEdit_EmployeeCode_St";
            this.tEdit_EmployeeCode_St.Size = new System.Drawing.Size(44, 24);
            this.tEdit_EmployeeCode_St.TabIndex = 1;
            // 
            // ultraLabel14
            // 
            appearance125.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance125;
            this.ultraLabel14.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel14.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel14.Location = new System.Drawing.Point(50, 63);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel14.TabIndex = 251;
            this.ultraLabel14.Text = "���Ӑ�";
            // 
            // tNedit_CustomerCode_Ed
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode_Ed.ActiveAppearance = appearance13;
            appearance14.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.Appearance = appearance14;
            this.tNedit_CustomerCode_Ed.AutoSelect = true;
            this.tNedit_CustomerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_Ed.DataText = "";
            this.tNedit_CustomerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_Ed.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustomerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_Ed.Location = new System.Drawing.Point(356, 63);
            this.tNedit_CustomerCode_Ed.MaxLength = 8;
            this.tNedit_CustomerCode_Ed.Name = "tNedit_CustomerCode_Ed";
            this.tNedit_CustomerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_Ed.Size = new System.Drawing.Size(84, 24);
            this.tNedit_CustomerCode_Ed.TabIndex = 11;
            // 
            // EmployeeCdEd_GuideBtn
            // 
            appearance94.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.EmployeeCdEd_GuideBtn.Appearance = appearance94;
            this.EmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.EmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(406, 3);
            this.EmployeeCdEd_GuideBtn.Name = "EmployeeCdEd_GuideBtn";
            this.EmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.EmployeeCdEd_GuideBtn.TabIndex = 4;
            this.EmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.EmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.EmployeeCdEd_GuideBtn_Click);
            // 
            // tNedit_CustomerCode_St
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode_St.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.Appearance = appearance16;
            this.tNedit_CustomerCode_St.AutoSelect = true;
            this.tNedit_CustomerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_St.DataText = "";
            this.tNedit_CustomerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_St.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tNedit_CustomerCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_St.Location = new System.Drawing.Point(199, 63);
            this.tNedit_CustomerCode_St.MaxLength = 8;
            this.tNedit_CustomerCode_St.Name = "tNedit_CustomerCode_St";
            this.tNedit_CustomerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_St.Size = new System.Drawing.Size(84, 24);
            this.tNedit_CustomerCode_St.TabIndex = 9;
            // 
            // EmployeeCdSt_GuideBtn
            // 
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.EmployeeCdSt_GuideBtn.Appearance = appearance30;
            this.EmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.EmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(249, 3);
            this.EmployeeCdSt_GuideBtn.Name = "EmployeeCdSt_GuideBtn";
            this.EmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.EmployeeCdSt_GuideBtn.TabIndex = 2;
            this.EmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.EmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.EmployeeCdSt_GuideBtn_Click);
            // 
            // ultraLabel7
            // 
            appearance21.TextHAlignAsString = "Center";
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance21;
            this.ultraLabel7.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel7.Location = new System.Drawing.Point(320, 64);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(30, 24);
            this.ultraLabel7.TabIndex = 244;
            this.ultraLabel7.Text = "�`";
            // 
            // ultraLabel8
            // 
            appearance33.TextHAlignAsString = "Center";
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance33;
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel8.Location = new System.Drawing.Point(320, 35);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel8.TabIndex = 239;
            this.ultraLabel8.Text = "�`";
            // 
            // ultraLabel10
            // 
            appearance95.TextHAlignAsString = "Center";
            appearance95.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance95;
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel10.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel10.Location = new System.Drawing.Point(320, 5);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(30, 23);
            this.ultraLabel10.TabIndex = 239;
            this.ultraLabel10.Text = "�`";
            // 
            // ChargeEmployee_tComboEditor
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ChargeEmployee_tComboEditor.ActiveAppearance = appearance20;
            appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ChargeEmployee_tComboEditor.Appearance = appearance113;
            this.ChargeEmployee_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.ChargeEmployee_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ChargeEmployee_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ChargeEmployee_tComboEditor.ItemAppearance = appearance24;
            valueListItem21.DataValue = 0;
            valueListItem21.DisplayText = "���Ӑ�S��";
            valueListItem22.DataValue = 1;
            valueListItem22.DisplayText = "�W���S��";
            this.ChargeEmployee_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem21,
            valueListItem22});
            this.ChargeEmployee_tComboEditor.Location = new System.Drawing.Point(50, 4);
            this.ChargeEmployee_tComboEditor.Name = "ChargeEmployee_tComboEditor";
            this.ChargeEmployee_tComboEditor.Size = new System.Drawing.Size(140, 24);
            this.ChargeEmployee_tComboEditor.TabIndex = 0;
            // 
            // ultraExplorerBarContainerControl5
            // 
            this.ultraExplorerBarContainerControl5.Controls.Add(this.panel_BalanceDepositDtl_);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.panel_CollectRate);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.IssueDay_tDateEdit);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.BillTableOutPut_Label);
            this.ultraExplorerBarContainerControl5.Controls.Add(this.OutPutPriceCond_tComboEditor);
            this.ultraExplorerBarContainerControl5.Location = new System.Drawing.Point(18, 536);
            this.ultraExplorerBarContainerControl5.Name = "ultraExplorerBarContainerControl5";
            this.ultraExplorerBarContainerControl5.Size = new System.Drawing.Size(644, 126);
            this.ultraExplorerBarContainerControl5.TabIndex = 3;
            // 
            // panel_BalanceDepositDtl_
            // 
            this.panel_BalanceDepositDtl_.Controls.Add(this.ultraLabel24);
            this.panel_BalanceDepositDtl_.Controls.Add(this.BalanceDepositDtl_tComboEditor);
            this.panel_BalanceDepositDtl_.Location = new System.Drawing.Point(6, 93);
            this.panel_BalanceDepositDtl_.Name = "panel_BalanceDepositDtl_";
            this.panel_BalanceDepositDtl_.Size = new System.Drawing.Size(535, 30);
            this.panel_BalanceDepositDtl_.TabIndex = 252;
            this.panel_BalanceDepositDtl_.Visible = false;
            // 
            // ultraLabel24
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel24.Appearance = appearance25;
            this.ultraLabel24.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel24.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel24.Location = new System.Drawing.Point(44, 3);
            this.ultraLabel24.Name = "ultraLabel24";
            this.ultraLabel24.Size = new System.Drawing.Size(108, 23);
            this.ultraLabel24.TabIndex = 250;
            this.ultraLabel24.Text = "�c����������";
            // 
            // BalanceDepositDtl_tComboEditor
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BalanceDepositDtl_tComboEditor.ActiveAppearance = appearance36;
            appearance108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BalanceDepositDtl_tComboEditor.Appearance = appearance108;
            this.BalanceDepositDtl_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.BalanceDepositDtl_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BalanceDepositDtl_tComboEditor.ItemAppearance = appearance112;
            valueListItem23.DataValue = 0;
            valueListItem23.DisplayText = "�󎚂���";
            valueListItem24.DataValue = 1;
            valueListItem24.DisplayText = "�󎚂��Ȃ�";
            this.BalanceDepositDtl_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem23,
            valueListItem24});
            this.BalanceDepositDtl_tComboEditor.Location = new System.Drawing.Point(193, 3);
            this.BalanceDepositDtl_tComboEditor.Name = "BalanceDepositDtl_tComboEditor";
            this.BalanceDepositDtl_tComboEditor.Size = new System.Drawing.Size(272, 24);
            this.BalanceDepositDtl_tComboEditor.TabIndex = 3;
            // 
            // panel_CollectRate
            // 
            this.panel_CollectRate.Controls.Add(this.ultraLabel25);
            this.panel_CollectRate.Controls.Add(this.CollectRatePrtDiv_tComboEditor);
            this.panel_CollectRate.Location = new System.Drawing.Point(6, 59);
            this.panel_CollectRate.Name = "panel_CollectRate";
            this.panel_CollectRate.Size = new System.Drawing.Size(535, 30);
            this.panel_CollectRate.TabIndex = 251;
            this.panel_CollectRate.Visible = false;
            // 
            // ultraLabel25
            // 
            appearance118.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance118;
            this.ultraLabel25.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel25.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel25.Location = new System.Drawing.Point(44, 5);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(110, 23);
            this.ultraLabel25.TabIndex = 249;
            this.ultraLabel25.Text = "�������";
            // 
            // CollectRatePrtDiv_tComboEditor
            // 
            appearance119.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CollectRatePrtDiv_tComboEditor.ActiveAppearance = appearance119;
            appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CollectRatePrtDiv_tComboEditor.Appearance = appearance120;
            this.CollectRatePrtDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CollectRatePrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CollectRatePrtDiv_tComboEditor.ItemAppearance = appearance121;
            valueListItem25.DataValue = 0;
            valueListItem25.DisplayText = "�O��c�v�Z";
            valueListItem26.DataValue = 1;
            valueListItem26.DisplayText = "������v�Z";
            valueListItem27.DataValue = 2;
            valueListItem27.DisplayText = "�󎚂Ȃ�";
            this.CollectRatePrtDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem25,
            valueListItem26,
            valueListItem27});
            this.CollectRatePrtDiv_tComboEditor.Location = new System.Drawing.Point(193, 4);
            this.CollectRatePrtDiv_tComboEditor.Name = "CollectRatePrtDiv_tComboEditor";
            this.CollectRatePrtDiv_tComboEditor.Size = new System.Drawing.Size(272, 24);
            this.CollectRatePrtDiv_tComboEditor.TabIndex = 0;
            // 
            // ultraLabel11
            // 
            appearance147.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance147;
            this.ultraLabel11.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel11.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel11.Location = new System.Drawing.Point(49, 4);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(108, 23);
            this.ultraLabel11.TabIndex = 250;
            this.ultraLabel11.Text = "���s��";
            // 
            // IssueDay_tDateEdit
            // 
            appearance148.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.IssueDay_tDateEdit.ActiveEditAppearance = appearance148;
            this.IssueDay_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.IssueDay_tDateEdit.CalendarDisp = true;
            appearance149.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance149.TextHAlignAsString = "Left";
            appearance149.TextVAlignAsString = "Middle";
            this.IssueDay_tDateEdit.EditAppearance = appearance149;
            this.IssueDay_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.IssueDay_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.IssueDay_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance150.TextHAlignAsString = "Left";
            appearance150.TextVAlignAsString = "Middle";
            this.IssueDay_tDateEdit.LabelAppearance = appearance150;
            this.IssueDay_tDateEdit.Location = new System.Drawing.Point(199, 4);
            this.IssueDay_tDateEdit.Name = "IssueDay_tDateEdit";
            this.IssueDay_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.IssueDay_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.IssueDay_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.IssueDay_tDateEdit.TabIndex = 0;
            this.IssueDay_tDateEdit.TabStop = true;
            this.IssueDay_tDateEdit.ValueChanged += new System.EventHandler(this.AddUpDate_tDateEdit_ValueChanged);
            // 
            // BillTableOutPut_Label
            // 
            appearance98.TextVAlignAsString = "Middle";
            this.BillTableOutPut_Label.Appearance = appearance98;
            this.BillTableOutPut_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.BillTableOutPut_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillTableOutPut_Label.Location = new System.Drawing.Point(50, 34);
            this.BillTableOutPut_Label.Name = "BillTableOutPut_Label";
            this.BillTableOutPut_Label.Size = new System.Drawing.Size(110, 23);
            this.BillTableOutPut_Label.TabIndex = 249;
            this.BillTableOutPut_Label.Text = "�o�͋��z�敪";
            // 
            // OutPutPriceCond_tComboEditor
            // 
            appearance99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OutPutPriceCond_tComboEditor.ActiveAppearance = appearance99;
            appearance106.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OutPutPriceCond_tComboEditor.Appearance = appearance106;
            this.OutPutPriceCond_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.OutPutPriceCond_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.OutPutPriceCond_tComboEditor.ItemAppearance = appearance110;
            this.OutPutPriceCond_tComboEditor.Location = new System.Drawing.Point(199, 34);
            this.OutPutPriceCond_tComboEditor.Name = "OutPutPriceCond_tComboEditor";
            this.OutPutPriceCond_tComboEditor.Size = new System.Drawing.Size(272, 24);
            this.OutPutPriceCond_tComboEditor.TabIndex = 2;
            // 
            // ultraExplorerBarContainerControl7
            // 
            this.ultraExplorerBarContainerControl7.Controls.Add(this.tComboEditor_Pattern);
            this.ultraExplorerBarContainerControl7.Controls.Add(this.ultraLabel_Pattern);
            this.ultraExplorerBarContainerControl7.Controls.Add(this.Pattern_tComboEditor);
            this.ultraExplorerBarContainerControl7.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl7.Controls.Add(this.tLebal_Example);
            this.ultraExplorerBarContainerControl7.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraExplorerBarContainerControl7.Name = "ultraExplorerBarContainerControl7";
            this.ultraExplorerBarContainerControl7.Size = new System.Drawing.Size(661, 78);
            this.ultraExplorerBarContainerControl7.TabIndex = 4;
            this.ultraExplorerBarContainerControl7.Visible = false;
            // 
            // tComboEditor_Pattern
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_Pattern.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.TextVAlignAsString = "Middle";
            this.tComboEditor_Pattern.Appearance = appearance7;
            this.tComboEditor_Pattern.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_Pattern.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.tComboEditor_Pattern.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_Pattern.ItemAppearance = appearance8;
            valueListItem28.DataValue = 1;
            valueListItem28.DisplayText = "�p�^�[��1";
            valueListItem29.DataValue = 2;
            valueListItem29.DisplayText = "�p�^�[��2";
            valueListItem30.DataValue = 3;
            valueListItem30.DisplayText = "�p�^�[��3";
            this.tComboEditor_Pattern.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem28,
            valueListItem29,
            valueListItem30});
            this.tComboEditor_Pattern.Location = new System.Drawing.Point(199, 33);
            this.tComboEditor_Pattern.Name = "tComboEditor_Pattern";
            this.tComboEditor_Pattern.Size = new System.Drawing.Size(272, 24);
            this.tComboEditor_Pattern.TabIndex = 38;
            this.tComboEditor_Pattern.ValueChanged += new System.EventHandler(this.tComboEditor_Pattern_ValueChanged);
            // 
            // ultraLabel_Pattern
            // 
            appearance116.TextVAlignAsString = "Middle";
            this.ultraLabel_Pattern.Appearance = appearance116;
            this.ultraLabel_Pattern.Location = new System.Drawing.Point(49, 34);
            this.ultraLabel_Pattern.Name = "ultraLabel_Pattern";
            this.ultraLabel_Pattern.Size = new System.Drawing.Size(150, 23);
            this.ultraLabel_Pattern.TabIndex = 39;
            this.ultraLabel_Pattern.Text = "�t�@�C�����p�^�[��";
            // 
            // Pattern_tComboEditor
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Pattern_tComboEditor.ActiveAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance4.TextVAlignAsString = "Middle";
            this.Pattern_tComboEditor.Appearance = appearance4;
            this.Pattern_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Pattern_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Pattern_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Pattern_tComboEditor.ItemAppearance = appearance5;
            this.Pattern_tComboEditor.Location = new System.Drawing.Point(199, 4);
            this.Pattern_tComboEditor.Name = "Pattern_tComboEditor";
            this.Pattern_tComboEditor.Size = new System.Drawing.Size(272, 24);
            this.Pattern_tComboEditor.TabIndex = 37;
            // 
            // ultraLabel9
            // 
            appearance96.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance96;
            this.ultraLabel9.Location = new System.Drawing.Point(49, 5);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel9.TabIndex = 36;
            this.ultraLabel9.Text = "�������^�C�v";
            // 
            // tLebal_Example
            // 
            appearance97.TextVAlignAsString = "Middle";
            this.tLebal_Example.Appearance = appearance97;
            this.tLebal_Example.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tLebal_Example.Location = new System.Drawing.Point(199, 56);
            this.tLebal_Example.Name = "tLebal_Example";
            this.tLebal_Example.Size = new System.Drawing.Size(500, 23);
            this.tLebal_Example.TabIndex = 40;
            this.tLebal_Example.Text = "(��)������(20210120_01_00001001)_20210101_12010100.pdf";
            // 
            // ultraExplorerBarContainerControl6
            // 
            this.ultraExplorerBarContainerControl6.Controls.Add(this.tEdit_SectionCode_Ed);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.tEdit_SectionCode_St);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.endRangeNameUltraTextEditor);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.endRangeUltraLabel);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.startRangeNameUltraTextEditor);
            this.ultraExplorerBarContainerControl6.Controls.Add(this.startRangeUltraLabel);
            this.ultraExplorerBarContainerControl6.Location = new System.Drawing.Point(28, 48);
            this.ultraExplorerBarContainerControl6.Name = "ultraExplorerBarContainerControl6";
            this.ultraExplorerBarContainerControl6.Size = new System.Drawing.Size(228, 50);
            this.ultraExplorerBarContainerControl6.TabIndex = 3;
            // 
            // tEdit_SectionCode_Ed
            // 
            this.tEdit_SectionCode_Ed.ActiveAppearance = appearance9;
            this.tEdit_SectionCode_Ed.AutoSelect = true;
            this.tEdit_SectionCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SectionCode_Ed.DataText = "01";
            this.tEdit_SectionCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCode_Ed.Location = new System.Drawing.Point(59, 26);
            this.tEdit_SectionCode_Ed.MaxLength = 12;
            this.tEdit_SectionCode_Ed.Name = "tEdit_SectionCode_Ed";
            this.tEdit_SectionCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tEdit_SectionCode_Ed.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode_Ed.TabIndex = 9;
            this.tEdit_SectionCode_Ed.Text = "01";
            this.tEdit_SectionCode_Ed.Leave += new System.EventHandler(this.tEdit_SectionCode_Ed_Leave);
            // 
            // tEdit_SectionCode_St
            // 
            this.tEdit_SectionCode_St.ActiveAppearance = appearance10;
            this.tEdit_SectionCode_St.AutoSelect = true;
            this.tEdit_SectionCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tEdit_SectionCode_St.DataText = "01";
            this.tEdit_SectionCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tEdit_SectionCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_SectionCode_St.Location = new System.Drawing.Point(59, 0);
            this.tEdit_SectionCode_St.MaxLength = 12;
            this.tEdit_SectionCode_St.Name = "tEdit_SectionCode_St";
            this.tEdit_SectionCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tEdit_SectionCode_St.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCode_St.TabIndex = 7;
            this.tEdit_SectionCode_St.Text = "01";
            this.tEdit_SectionCode_St.Leave += new System.EventHandler(this.tEdit_SectionCode_St_Leave);
            // 
            // endRangeNameUltraTextEditor
            // 
            this.endRangeNameUltraTextEditor.Enabled = false;
            this.endRangeNameUltraTextEditor.Location = new System.Drawing.Point(93, 26);
            this.endRangeNameUltraTextEditor.Name = "endRangeNameUltraTextEditor";
            this.endRangeNameUltraTextEditor.Size = new System.Drawing.Size(104, 24);
            this.endRangeNameUltraTextEditor.TabIndex = 11;
            // 
            // endRangeUltraLabel
            // 
            appearance109.BackColor = System.Drawing.Color.Transparent;
            this.endRangeUltraLabel.Appearance = appearance109;
            this.endRangeUltraLabel.Location = new System.Drawing.Point(13, 30);
            this.endRangeUltraLabel.Name = "endRangeUltraLabel";
            this.endRangeUltraLabel.Size = new System.Drawing.Size(40, 20);
            this.endRangeUltraLabel.TabIndex = 10;
            this.endRangeUltraLabel.Text = "�I��";
            // 
            // startRangeNameUltraTextEditor
            // 
            this.startRangeNameUltraTextEditor.Enabled = false;
            this.startRangeNameUltraTextEditor.Location = new System.Drawing.Point(93, 0);
            this.startRangeNameUltraTextEditor.Name = "startRangeNameUltraTextEditor";
            this.startRangeNameUltraTextEditor.Size = new System.Drawing.Size(104, 24);
            this.startRangeNameUltraTextEditor.TabIndex = 8;
            // 
            // startRangeUltraLabel
            // 
            appearance105.BackColor = System.Drawing.Color.Transparent;
            this.startRangeUltraLabel.Appearance = appearance105;
            this.startRangeUltraLabel.Location = new System.Drawing.Point(13, 4);
            this.startRangeUltraLabel.Name = "startRangeUltraLabel";
            this.startRangeUltraLabel.Size = new System.Drawing.Size(40, 20);
            this.startRangeUltraLabel.TabIndex = 6;
            this.startRangeUltraLabel.Text = "�J�n";
            // 
            // SectionList_ExplorerBarContainerControl
            // 
            this.SectionList_ExplorerBarContainerControl.Controls.Add(this.Section_Tree);
            this.SectionList_ExplorerBarContainerControl.Location = new System.Drawing.Point(28, 156);
            this.SectionList_ExplorerBarContainerControl.Name = "SectionList_ExplorerBarContainerControl";
            this.SectionList_ExplorerBarContainerControl.Size = new System.Drawing.Size(228, 234);
            this.SectionList_ExplorerBarContainerControl.TabIndex = 1;
            // 
            // Section_Tree
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.Section_Tree.Appearance = appearance40;
            this.Section_Tree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Section_Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Section_Tree.Location = new System.Drawing.Point(0, 0);
            this.Section_Tree.Name = "Section_Tree";
            this.Section_Tree.Size = new System.Drawing.Size(228, 234);
            this.Section_Tree.TabIndex = 0;
            this.Section_Tree.AfterCheck += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.Section_Tree_AfterCheck);
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.History_Tree);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(28, 448);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(228, 120);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // History_Tree
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(223)))), ((int)(((byte)(247)))));
            this.History_Tree.Appearance = appearance41;
            this.History_Tree.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.History_Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.History_Tree.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.History_Tree.Location = new System.Drawing.Point(0, 0);
            this.History_Tree.Name = "History_Tree";
            this.History_Tree.Size = new System.Drawing.Size(228, 120);
            this.History_Tree.TabIndex = 0;
            this.History_Tree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.History_Tree_MouseMove);
            this.History_Tree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.History_Tree_MouseClick);
            this.History_Tree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.History_Tree_MouseDoubleClick);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.ExtraInfo_Panel);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(25, 2);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(697, 666);
            // 
            // ExtraInfo_Panel
            // 
            this.ExtraInfo_Panel.AutoScroll = true;
            this.ExtraInfo_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ExtraInfo_Panel.Controls.Add(this.Extra_ultraExplorerBar);
            this.ExtraInfo_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraInfo_Panel.Location = new System.Drawing.Point(0, 0);
            this.ExtraInfo_Panel.Name = "ExtraInfo_Panel";
            this.ExtraInfo_Panel.Size = new System.Drawing.Size(697, 666);
            this.ExtraInfo_Panel.TabIndex = 0;
            // 
            // Extra_ultraExplorerBar
            // 
            this.Extra_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Extra_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance42.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance42.FontData.Name = "�l�r �S�V�b�N";
            appearance42.FontData.SizeInPoints = 11.25F;
            this.Extra_ultraExplorerBar.Appearance = appearance42;
            this.Extra_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl5);
            this.Extra_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl7);
            this.Extra_ultraExplorerBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.Extra_ultraExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Extra_ultraExplorerBar.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup1.Key = "ReportSelectGroup";
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance43;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 157;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "�@�o�͏���";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "ReportSortGroup";
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance44;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 39;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "�@�\�[�g��";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup3.Key = "PrintConditionGroup";
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance45;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 186;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "�@���o����";
            ultraExplorerBarGroup4.Container = this.ultraExplorerBarContainerControl5;
            ultraExplorerBarGroup4.Key = "BillPrtStGroup";
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup4.Settings.AppearancesSmall.Appearance = appearance46;
            ultraExplorerBarGroup4.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup4.Settings.ContainerHeight = 128;
            ultraExplorerBarGroup4.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup4.Text = "�@��������ݒ�";
            ultraExplorerBarGroup5.Container = this.ultraExplorerBarContainerControl7;
            ultraExplorerBarGroup5.Key = "BillOutStGroup";
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup5.Settings.AppearancesSmall.Appearance = appearance19;
            ultraExplorerBarGroup5.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup5.Settings.ContainerHeight = 80;
            ultraExplorerBarGroup5.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup5.Text = "�@�����o�͐ݒ�";
            this.Extra_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3,
            ultraExplorerBarGroup4,
            ultraExplorerBarGroup5});
            this.Extra_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Extra_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance47.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance47.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance47.Cursor = System.Windows.Forms.Cursors.Default;
            this.Extra_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance47;
            appearance138.Cursor = System.Windows.Forms.Cursors.Default;
            this.Extra_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance138;
            this.Extra_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Extra_ultraExplorerBar.GroupSpacing = 4;
            this.Extra_ultraExplorerBar.Location = new System.Drawing.Point(0, 0);
            this.Extra_ultraExplorerBar.Margins.Bottom = 10;
            this.Extra_ultraExplorerBar.Margins.Top = 10;
            this.Extra_ultraExplorerBar.Name = "Extra_ultraExplorerBar";
            this.Extra_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Extra_ultraExplorerBar.Size = new System.Drawing.Size(697, 666);
            this.Extra_ultraExplorerBar.TabIndex = 234;
            this.Extra_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Extra_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
            this.Extra_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Extra_ultraExplorerBar_GroupExpanding);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.ExtraData_Panel);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(697, 666);
            // 
            // ExtraData_Panel
            // 
            this.ExtraData_Panel.BackColor = System.Drawing.Color.Transparent;
            this.ExtraData_Panel.Controls.Add(this.DataView_Panel);
            this.ExtraData_Panel.Controls.Add(this.PrintExtra_Panel);
            this.ExtraData_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraData_Panel.Location = new System.Drawing.Point(0, 0);
            this.ExtraData_Panel.Name = "ExtraData_Panel";
            this.ExtraData_Panel.Size = new System.Drawing.Size(697, 666);
            this.ExtraData_Panel.TabIndex = 0;
            // 
            // DataView_Panel
            // 
            this.DataView_Panel.Controls.Add(this.DEMANDLISTVIEW);
            this.DataView_Panel.Controls.Add(this.ultraGrid1);
            this.DataView_Panel.Controls.Add(this.Total_Panel);
            this.DataView_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataView_Panel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DataView_Panel.Location = new System.Drawing.Point(0, 32);
            this.DataView_Panel.Name = "DataView_Panel";
            this.DataView_Panel.Size = new System.Drawing.Size(697, 634);
            this.DataView_Panel.TabIndex = 3;
            // 
            // DEMANDLISTVIEW
            // 
            appearance139.BackColor = System.Drawing.Color.White;
            appearance139.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance139.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.DEMANDLISTVIEW.DisplayLayout.Appearance = appearance139;
            this.DEMANDLISTVIEW.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            appearance140.BackColor = System.Drawing.Color.Transparent;
            this.DEMANDLISTVIEW.DisplayLayout.Override.ActiveCardCaptionAppearance = appearance140;
            this.DEMANDLISTVIEW.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.DEMANDLISTVIEW.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.DEMANDLISTVIEW.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.DEMANDLISTVIEW.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance141.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance141.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance141.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance141.ForeColor = System.Drawing.Color.White;
            appearance141.TextHAlignAsString = "Left";
            appearance141.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.DEMANDLISTVIEW.DisplayLayout.Override.HeaderAppearance = appearance141;
            this.DEMANDLISTVIEW.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance52.BackColor = System.Drawing.Color.Lavender;
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowAlternateAppearance = appearance52;
            appearance53.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowAppearance = appearance53;
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance54.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance54.ForeColor = System.Drawing.Color.White;
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowSelectorAppearance = appearance54;
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement;
            this.DEMANDLISTVIEW.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance55.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance55.ForeColor = System.Drawing.Color.Black;
            this.DEMANDLISTVIEW.DisplayLayout.Override.SelectedRowAppearance = appearance55;
            this.DEMANDLISTVIEW.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.DEMANDLISTVIEW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DEMANDLISTVIEW.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DEMANDLISTVIEW.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.DEMANDLISTVIEW.Location = new System.Drawing.Point(0, 0);
            this.DEMANDLISTVIEW.Name = "DEMANDLISTVIEW";
            this.DEMANDLISTVIEW.Size = new System.Drawing.Size(697, 586);
            this.DEMANDLISTVIEW.TabIndex = 0;
            this.DEMANDLISTVIEW.Click += new System.EventHandler(this.DEMANDLISTVIEW_Click);
            this.DEMANDLISTVIEW.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.DEMANDLISTVIEW_InitializeLayout);
            this.DEMANDLISTVIEW.BeforeRowFilterDropDown += new Infragistics.Win.UltraWinGrid.BeforeRowFilterDropDownEventHandler(this.DEMANDLISTVIEW_BeforeRowFilterDropDown);
            this.DEMANDLISTVIEW.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.DEMANDLISTVIEW_AfterRowFilterChanged);
            this.DEMANDLISTVIEW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DEMANDLISTVIEW_KeyDown);
            // 
            // ultraGrid1
            // 
            appearance56.BackColor = System.Drawing.Color.White;
            appearance56.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultraGrid1.DisplayLayout.Appearance = appearance56;
            this.ultraGrid1.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            appearance57.BackColor = System.Drawing.Color.Transparent;
            this.ultraGrid1.DisplayLayout.Override.ActiveCardCaptionAppearance = appearance57;
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance58.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance58.ForeColor = System.Drawing.Color.White;
            appearance58.TextHAlignAsString = "Left";
            appearance58.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance58;
            appearance59.BackColor = System.Drawing.Color.Lavender;
            this.ultraGrid1.DisplayLayout.Override.RowAlternateAppearance = appearance59;
            appearance60.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(68)))), ((int)(((byte)(208)))));
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance60;
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance61.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.ForeColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Override.RowSelectorAppearance = appearance61;
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance62.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance62.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid1.DisplayLayout.Override.SelectedRowAppearance = appearance62;
            this.ultraGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGrid1.Location = new System.Drawing.Point(0, 0);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(697, 586);
            this.ultraGrid1.TabIndex = 0;
            // 
            // Total_Panel
            // 
            this.Total_Panel.BackColor = System.Drawing.Color.AliceBlue;
            this.Total_Panel.Controls.Add(this.panel7);
            this.Total_Panel.Controls.Add(this.panel8);
            this.Total_Panel.Controls.Add(this.panel4);
            this.Total_Panel.Controls.Add(this.panel3);
            this.Total_Panel.Controls.Add(this.panel6);
            this.Total_Panel.Controls.Add(this.panel5);
            this.Total_Panel.Controls.Add(this.panel2);
            this.Total_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Total_Panel.Location = new System.Drawing.Point(0, 586);
            this.Total_Panel.Name = "Total_Panel";
            this.Total_Panel.Size = new System.Drawing.Size(697, 48);
            this.Total_Panel.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.ultraLabel16);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(0, 48);
            this.panel7.TabIndex = 107;
            // 
            // ultraLabel16
            // 
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance63.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance63.ForeColor = System.Drawing.Color.White;
            appearance63.TextHAlignAsString = "Center";
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance63;
            this.ultraLabel16.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel16.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(0, 48);
            this.ultraLabel16.TabIndex = 11;
            this.ultraLabel16.Text = "���v";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.ultraLabel22);
            this.panel8.Controls.Add(this.RpSlipCount_tNedit);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(-71, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(128, 48);
            this.panel8.TabIndex = 106;
            this.panel8.Visible = false;
            // 
            // ultraLabel22
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance64.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance64.ForeColor = System.Drawing.Color.White;
            appearance64.TextHAlignAsString = "Center";
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel22.Appearance = appearance64;
            this.ultraLabel22.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel22.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel22.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel22.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel22.Name = "ultraLabel22";
            this.ultraLabel22.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel22.TabIndex = 2;
            this.ultraLabel22.Text = "�`�[����";
            this.ultraLabel22.Visible = false;
            // 
            // RpSlipCount_tNedit
            // 
            this.RpSlipCount_tNedit.ActiveAppearance = appearance65;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance66.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance66.FontData.BoldAsString = "True";
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextHAlignAsString = "Right";
            this.RpSlipCount_tNedit.Appearance = appearance66;
            this.RpSlipCount_tNedit.AutoSelect = true;
            this.RpSlipCount_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.RpSlipCount_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.RpSlipCount_tNedit.DataText = "";
            this.RpSlipCount_tNedit.Enabled = false;
            this.RpSlipCount_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RpSlipCount_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.RpSlipCount_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RpSlipCount_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RpSlipCount_tNedit.Location = new System.Drawing.Point(0, 24);
            this.RpSlipCount_tNedit.MaxLength = 14;
            this.RpSlipCount_tNedit.Name = "RpSlipCount_tNedit";
            this.RpSlipCount_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.RpSlipCount_tNedit.Size = new System.Drawing.Size(128, 24);
            this.RpSlipCount_tNedit.TabIndex = 1;
            this.RpSlipCount_tNedit.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.TotalLastDmd_tNedit);
            this.panel4.Controls.Add(this.ultraLabel19);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(57, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 48);
            this.panel4.TabIndex = 105;
            // 
            // TotalLastDmd_tNedit
            // 
            this.TotalLastDmd_tNedit.ActiveAppearance = appearance67;
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance68.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance68.FontData.BoldAsString = "True";
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            appearance68.TextHAlignAsString = "Right";
            this.TotalLastDmd_tNedit.Appearance = appearance68;
            this.TotalLastDmd_tNedit.AutoSelect = true;
            this.TotalLastDmd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalLastDmd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalLastDmd_tNedit.DataText = "";
            this.TotalLastDmd_tNedit.Enabled = false;
            this.TotalLastDmd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalLastDmd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalLastDmd_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalLastDmd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalLastDmd_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalLastDmd_tNedit.MaxLength = 14;
            this.TotalLastDmd_tNedit.Name = "TotalLastDmd_tNedit";
            this.TotalLastDmd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalLastDmd_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalLastDmd_tNedit.TabIndex = 1;
            // 
            // ultraLabel19
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance69.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance69.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance69.ForeColor = System.Drawing.Color.White;
            appearance69.TextHAlignAsString = "Center";
            appearance69.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance69;
            this.ultraLabel19.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel19.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel19.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel19.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel19.TabIndex = 2;
            this.ultraLabel19.Text = "�O�񐿋��z";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ultraLabel18);
            this.panel3.Controls.Add(this.TotalDeposit_tNedit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(185, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 48);
            this.panel3.TabIndex = 104;
            // 
            // ultraLabel18
            // 
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance70.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance70.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance70.ForeColor = System.Drawing.Color.White;
            appearance70.TextHAlignAsString = "Center";
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance70;
            this.ultraLabel18.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel18.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel18.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel18.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel18.TabIndex = 2;
            this.ultraLabel18.Text = "�������";
            // 
            // TotalDeposit_tNedit
            // 
            this.TotalDeposit_tNedit.ActiveAppearance = appearance71;
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance72.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance72.FontData.BoldAsString = "True";
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Right";
            this.TotalDeposit_tNedit.Appearance = appearance72;
            this.TotalDeposit_tNedit.AutoSelect = true;
            this.TotalDeposit_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalDeposit_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalDeposit_tNedit.DataText = "";
            this.TotalDeposit_tNedit.Enabled = false;
            this.TotalDeposit_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalDeposit_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalDeposit_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalDeposit_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalDeposit_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalDeposit_tNedit.MaxLength = 14;
            this.TotalDeposit_tNedit.Name = "TotalDeposit_tNedit";
            this.TotalDeposit_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalDeposit_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalDeposit_tNedit.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ultraLabel21);
            this.panel6.Controls.Add(this.TotalSales_tNedit);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(313, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(128, 48);
            this.panel6.TabIndex = 103;
            // 
            // ultraLabel21
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance73.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance73.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance73.ForeColor = System.Drawing.Color.White;
            appearance73.TextHAlignAsString = "Center";
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance73;
            this.ultraLabel21.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel21.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel21.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel21.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel21.TabIndex = 2;
            this.ultraLabel21.Text = "���񔄏�";
            // 
            // TotalSales_tNedit
            // 
            this.TotalSales_tNedit.ActiveAppearance = appearance100;
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance101.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance101.FontData.BoldAsString = "True";
            appearance101.ForeColorDisabled = System.Drawing.Color.Black;
            appearance101.TextHAlignAsString = "Right";
            this.TotalSales_tNedit.Appearance = appearance101;
            this.TotalSales_tNedit.AutoSelect = true;
            this.TotalSales_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalSales_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalSales_tNedit.DataText = "";
            this.TotalSales_tNedit.Enabled = false;
            this.TotalSales_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalSales_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalSales_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalSales_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalSales_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalSales_tNedit.MaxLength = 14;
            this.TotalSales_tNedit.Name = "TotalSales_tNedit";
            this.TotalSales_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalSales_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalSales_tNedit.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ConsTaxTiTle_Label);
            this.panel5.Controls.Add(this.TotalTax_tNedit);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(441, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(128, 48);
            this.panel5.TabIndex = 102;
            // 
            // ConsTaxTiTle_Label
            // 
            appearance102.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance102.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance102.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance102.ForeColor = System.Drawing.Color.White;
            appearance102.TextHAlignAsString = "Center";
            appearance102.TextVAlignAsString = "Middle";
            this.ConsTaxTiTle_Label.Appearance = appearance102;
            this.ConsTaxTiTle_Label.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ConsTaxTiTle_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ConsTaxTiTle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ConsTaxTiTle_Label.Location = new System.Drawing.Point(0, 0);
            this.ConsTaxTiTle_Label.Name = "ConsTaxTiTle_Label";
            this.ConsTaxTiTle_Label.Size = new System.Drawing.Size(128, 24);
            this.ConsTaxTiTle_Label.TabIndex = 2;
            this.ConsTaxTiTle_Label.Text = "��������";
            // 
            // TotalTax_tNedit
            // 
            this.TotalTax_tNedit.ActiveAppearance = appearance77;
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance78.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance78.FontData.BoldAsString = "True";
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            appearance78.TextHAlignAsString = "Right";
            this.TotalTax_tNedit.Appearance = appearance78;
            this.TotalTax_tNedit.AutoSelect = true;
            this.TotalTax_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalTax_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalTax_tNedit.DataText = "";
            this.TotalTax_tNedit.Enabled = false;
            this.TotalTax_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalTax_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalTax_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalTax_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalTax_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalTax_tNedit.MaxLength = 14;
            this.TotalTax_tNedit.Name = "TotalTax_tNedit";
            this.TotalTax_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalTax_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalTax_tNedit.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TotalDmd_tNedit);
            this.panel2.Controls.Add(this.ultraLabel17);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(569, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(128, 48);
            this.panel2.TabIndex = 101;
            // 
            // TotalDmd_tNedit
            // 
            this.TotalDmd_tNedit.ActiveAppearance = appearance79;
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance80.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance80.FontData.BoldAsString = "True";
            appearance80.ForeColorDisabled = System.Drawing.Color.Black;
            appearance80.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance80.TextHAlignAsString = "Right";
            this.TotalDmd_tNedit.Appearance = appearance80;
            this.TotalDmd_tNedit.AutoSelect = true;
            this.TotalDmd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.TotalDmd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TotalDmd_tNedit.DataText = "";
            this.TotalDmd_tNedit.Enabled = false;
            this.TotalDmd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TotalDmd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 14, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.TotalDmd_tNedit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalDmd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TotalDmd_tNedit.Location = new System.Drawing.Point(0, 24);
            this.TotalDmd_tNedit.MaxLength = 14;
            this.TotalDmd_tNedit.Name = "TotalDmd_tNedit";
            this.TotalDmd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.TotalDmd_tNedit.Size = new System.Drawing.Size(128, 24);
            this.TotalDmd_tNedit.TabIndex = 1;
            // 
            // ultraLabel17
            // 
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance81.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance81.ForeColor = System.Drawing.Color.White;
            appearance81.TextHAlignAsString = "Center";
            appearance81.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance81;
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.AliceBlue;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraLabel17.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.RaisedSoft;
            this.ultraLabel17.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel17.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel17.TabIndex = 2;
            this.ultraLabel17.Text = "�������z";
            // 
            // PrintExtra_Panel
            // 
            this.PrintExtra_Panel.Controls.Add(this.AutoFillToGridColumn_CheckEditor);
            this.PrintExtra_Panel.Controls.Add(this.Select_Button);
            this.PrintExtra_Panel.Controls.Add(this.UnSelect_Button);
            this.PrintExtra_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PrintExtra_Panel.Location = new System.Drawing.Point(0, 0);
            this.PrintExtra_Panel.Name = "PrintExtra_Panel";
            this.PrintExtra_Panel.Size = new System.Drawing.Size(697, 32);
            this.PrintExtra_Panel.TabIndex = 2;
            // 
            // AutoFillToGridColumn_CheckEditor
            // 
            this.AutoFillToGridColumn_CheckEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance82.FontData.SizeInPoints = 9F;
            this.AutoFillToGridColumn_CheckEditor.Appearance = appearance82;
            this.AutoFillToGridColumn_CheckEditor.Checked = true;
            this.AutoFillToGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToGridColumn_CheckEditor.Location = new System.Drawing.Point(555, 8);
            this.AutoFillToGridColumn_CheckEditor.Name = "AutoFillToGridColumn_CheckEditor";
            this.AutoFillToGridColumn_CheckEditor.Size = new System.Drawing.Size(136, 20);
            this.AutoFillToGridColumn_CheckEditor.TabIndex = 4;
            this.AutoFillToGridColumn_CheckEditor.Text = "��T�C�Y�̎�������";
            this.AutoFillToGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToGridColumn_CheckEditor_CheckedChanged);
            // 
            // Select_Button
            // 
            this.Select_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.Select_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Select_Button.HotTrackAppearance = appearance83;
            this.Select_Button.Location = new System.Drawing.Point(108, 4);
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.Size = new System.Drawing.Size(100, 27);
            this.Select_Button.TabIndex = 3;
            this.Select_Button.Text = "�S�Ĉ�";
            ultraToolTipInfo1.ToolTipText = "�S�đI�����܂�";
            this.Button_UToolTipManager.SetUltraToolTip(this.Select_Button, ultraToolTipInfo1);
            this.Select_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Select_Button.Visible = false;
            this.Select_Button.Click += new System.EventHandler(this.Select_Button_Click);
            // 
            // UnSelect_Button
            // 
            this.UnSelect_Button.Cursor = System.Windows.Forms.Cursors.Default;
            this.UnSelect_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UnSelect_Button.HotTrackAppearance = appearance103;
            this.UnSelect_Button.Location = new System.Drawing.Point(4, 4);
            this.UnSelect_Button.Name = "UnSelect_Button";
            this.UnSelect_Button.Size = new System.Drawing.Size(100, 27);
            this.UnSelect_Button.TabIndex = 1;
            this.UnSelect_Button.Text = "�S�Ĕ��";
            ultraToolTipInfo2.ToolTipText = "�S�Ă̑I�����������܂�";
            this.Button_UToolTipManager.SetUltraToolTip(this.UnSelect_Button, ultraToolTipInfo2);
            this.UnSelect_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.UnSelect_Button.Visible = false;
            this.UnSelect_Button.Click += new System.EventHandler(this.Select_Button_Click);
            // 
            // Main_ExplorerBar
            // 
            appearance85.FontData.SizeInPoints = 9F;
            this.Main_ExplorerBar.Appearance = appearance85;
            this.Main_ExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ExplorerBar.Controls.Add(this.SectionList_ExplorerBarContainerControl);
            this.Main_ExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl6);
            ultraExplorerBarGroup6.Container = this.ultraExplorerBarContainerControl6;
            ultraExplorerBarGroup6.Key = "SectionRange";
            ultraExplorerBarGroup6.Settings.ContainerHeight = 50;
            ultraExplorerBarGroup6.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup6.Text = "�o�͋��_�͈̔͂��w�肵�܂�";
            ultraExplorerBarGroup7.Container = this.SectionList_ExplorerBarContainerControl;
            ultraExplorerBarGroup7.Key = "SectionList";
            ultraExplorerBarGroup7.Settings.ContainerHeight = 234;
            ultraExplorerBarGroup7.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup7.Text = "�o�͑Ώۋ��_��I�����܂�";
            ultraExplorerBarGroup7.Visible = false;
            ultraExplorerBarGroup8.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup8.Key = "HistoryList";
            ultraExplorerBarGroup8.Settings.ContainerHeight = 120;
            ultraExplorerBarGroup8.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            ultraExplorerBarGroup8.Text = "�ŋߏo�͂����ꗗ�\";
            this.Main_ExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup6,
            ultraExplorerBarGroup7,
            ultraExplorerBarGroup8});
            this.Main_ExplorerBar.Location = new System.Drawing.Point(0, 27);
            this.Main_ExplorerBar.Name = "Main_ExplorerBar";
            this.Main_ExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ExplorerBar.Size = new System.Drawing.Size(277, 643);
            this.Main_ExplorerBar.TabIndex = 0;
            this.Main_ExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.XPExplorerBar;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "���̒��[���폜(&D)";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "���̒��[�ȑO���폜(&B)";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Main_TabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(282, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 670);
            this.panel1.TabIndex = 91;
            // 
            // Main_TabControl
            // 
            appearance86.BackColor = System.Drawing.Color.White;
            appearance86.BackColor2 = System.Drawing.Color.LightPink;
            this.Main_TabControl.ActiveTabAppearance = appearance86;
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            appearance87.BackColor2 = System.Drawing.Color.White;
            appearance87.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            this.Main_TabControl.Appearance = appearance87;
            this.Main_TabControl.BackColorInternal = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            appearance88.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.Main_TabControl.ClientAreaAppearance = appearance88;
            this.Main_TabControl.Controls.Add(this.ultraTabSharedControlsPage1);
            this.Main_TabControl.Controls.Add(this.ultraTabPageControl1);
            this.Main_TabControl.Controls.Add(this.ultraTabPageControl2);
            this.Main_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Main_TabControl.Location = new System.Drawing.Point(0, 0);
            this.Main_TabControl.Name = "Main_TabControl";
            appearance89.FontData.BoldAsString = "True";
            this.Main_TabControl.SelectedTabAppearance = appearance89;
            this.Main_TabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.Main_TabControl.Size = new System.Drawing.Size(724, 670);
            this.Main_TabControl.TabIndex = 0;
            this.Main_TabControl.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.LeftBottom;
            ultraTab1.Key = "ExtractInfoTab";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "���o����";
            ultraTab2.Key = "ExtractDataTab";
            ultraTab2.TabPage = this.ultraTabPageControl2;
            ultraTab2.Text = "���o����";
            ultraTab2.Visible = false;
            this.Main_TabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.Main_TabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.Main_TabControl.ActiveTabChanged += new Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventHandler(this.Main_TabControl_ActiveTabChanged);
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(697, 666);
            // 
            // Main_DockManager
            // 
            this.Main_DockManager.AnimationSpeed = Infragistics.Win.UltraWinDock.AnimationSpeed.StandardSpeedPlus5;
            this.Main_DockManager.AutoHideDelay = 50;
            this.Main_DockManager.CaptionStyle = Infragistics.Win.UltraWinDock.CaptionStyle.Office2003;
            dockableControlPane1.Control = this.Main_ExplorerBar;
            dockableControlPane1.FlyoutSize = new System.Drawing.Size(240, -1);
            dockableControlPane1.Key = "ControlPane0";
            dockableControlPane1.OriginalControlBounds = new System.Drawing.Rectangle(230, -1, 260, 648);
            dockableControlPane1.Settings.AllowClose = Infragistics.Win.DefaultableBoolean.False;
            appearance90.FontData.SizeInPoints = 10F;
            dockableControlPane1.Settings.Appearance = appearance90;
            dockableControlPane1.Settings.DoubleClickAction = Infragistics.Win.UltraWinDock.PaneDoubleClickAction.ToggleDockedState;
            dockableControlPane1.Size = new System.Drawing.Size(100, 100);
            dockAreaPane1.Panes.AddRange(new Infragistics.Win.UltraWinDock.DockablePaneBase[] {
            dockableControlPane1});
            dockAreaPane1.Size = new System.Drawing.Size(277, 670);
            this.Main_DockManager.DockAreas.AddRange(new Infragistics.Win.UltraWinDock.DockAreaPane[] {
            dockAreaPane1});
            this.Main_DockManager.HostControl = this;
            this.Main_DockManager.ShowCloseButton = false;
            this.Main_DockManager.WindowStyle = Infragistics.Win.UltraWinDock.WindowStyle.Office2003;
            // 
            // _MAKAU03002UAUnpinnedTabAreaLeft
            // 
            this._MAKAU03002UAUnpinnedTabAreaLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this._MAKAU03002UAUnpinnedTabAreaLeft.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03002UAUnpinnedTabAreaLeft.Location = new System.Drawing.Point(0, 0);
            this._MAKAU03002UAUnpinnedTabAreaLeft.Name = "_MAKAU03002UAUnpinnedTabAreaLeft";
            this._MAKAU03002UAUnpinnedTabAreaLeft.Owner = this.Main_DockManager;
            this._MAKAU03002UAUnpinnedTabAreaLeft.Size = new System.Drawing.Size(0, 670);
            this._MAKAU03002UAUnpinnedTabAreaLeft.TabIndex = 92;
            // 
            // _MAKAU03002UAUnpinnedTabAreaRight
            // 
            this._MAKAU03002UAUnpinnedTabAreaRight.Dock = System.Windows.Forms.DockStyle.Right;
            this._MAKAU03002UAUnpinnedTabAreaRight.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03002UAUnpinnedTabAreaRight.Location = new System.Drawing.Point(1006, 0);
            this._MAKAU03002UAUnpinnedTabAreaRight.Name = "_MAKAU03002UAUnpinnedTabAreaRight";
            this._MAKAU03002UAUnpinnedTabAreaRight.Owner = this.Main_DockManager;
            this._MAKAU03002UAUnpinnedTabAreaRight.Size = new System.Drawing.Size(0, 670);
            this._MAKAU03002UAUnpinnedTabAreaRight.TabIndex = 93;
            // 
            // _MAKAU03002UAUnpinnedTabAreaTop
            // 
            this._MAKAU03002UAUnpinnedTabAreaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._MAKAU03002UAUnpinnedTabAreaTop.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03002UAUnpinnedTabAreaTop.Location = new System.Drawing.Point(0, 0);
            this._MAKAU03002UAUnpinnedTabAreaTop.Name = "_MAKAU03002UAUnpinnedTabAreaTop";
            this._MAKAU03002UAUnpinnedTabAreaTop.Owner = this.Main_DockManager;
            this._MAKAU03002UAUnpinnedTabAreaTop.Size = new System.Drawing.Size(1006, 0);
            this._MAKAU03002UAUnpinnedTabAreaTop.TabIndex = 94;
            // 
            // _MAKAU03002UAUnpinnedTabAreaBottom
            // 
            this._MAKAU03002UAUnpinnedTabAreaBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._MAKAU03002UAUnpinnedTabAreaBottom.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03002UAUnpinnedTabAreaBottom.Location = new System.Drawing.Point(0, 670);
            this._MAKAU03002UAUnpinnedTabAreaBottom.Name = "_MAKAU03002UAUnpinnedTabAreaBottom";
            this._MAKAU03002UAUnpinnedTabAreaBottom.Owner = this.Main_DockManager;
            this._MAKAU03002UAUnpinnedTabAreaBottom.Size = new System.Drawing.Size(1006, 0);
            this._MAKAU03002UAUnpinnedTabAreaBottom.TabIndex = 95;
            // 
            // _MAKAU03002UAAutoHideControl
            // 
            this._MAKAU03002UAAutoHideControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._MAKAU03002UAAutoHideControl.Location = new System.Drawing.Point(22, 0);
            this._MAKAU03002UAAutoHideControl.Name = "_MAKAU03002UAAutoHideControl";
            this._MAKAU03002UAAutoHideControl.Owner = this.Main_DockManager;
            this._MAKAU03002UAAutoHideControl.Size = new System.Drawing.Size(245, 605);
            this._MAKAU03002UAAutoHideControl.TabIndex = 96;
            // 
            // dockableWindow1
            // 
            this.dockableWindow1.Controls.Add(this.Main_ExplorerBar);
            this.dockableWindow1.Location = new System.Drawing.Point(0, 0);
            this.dockableWindow1.Name = "dockableWindow1";
            this.dockableWindow1.Owner = this.Main_DockManager;
            this.dockableWindow1.Size = new System.Drawing.Size(277, 670);
            this.dockableWindow1.TabIndex = 98;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tNedit6
            // 
            this.tNedit6.ActiveAppearance = appearance91;
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            appearance92.BackColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            appearance92.ImageHAlign = Infragistics.Win.HAlign.Right;
            this.tNedit6.Appearance = appearance92;
            this.tNedit6.AutoSelect = true;
            this.tNedit6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.tNedit6.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit6.DataText = "";
            this.tNedit6.Enabled = false;
            this.tNedit6.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit6.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit6.Location = new System.Drawing.Point(0, 24);
            this.tNedit6.MaxLength = 11;
            this.tNedit6.Name = "tNedit6";
            this.tNedit6.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit6.Size = new System.Drawing.Size(97, 21);
            this.tNedit6.TabIndex = 1;
            // 
            // windowDockingArea1
            // 
            this.windowDockingArea1.Controls.Add(this.dockableWindow1);
            this.windowDockingArea1.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowDockingArea1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.windowDockingArea1.Location = new System.Drawing.Point(0, 0);
            this.windowDockingArea1.Name = "windowDockingArea1";
            this.windowDockingArea1.Owner = this.Main_DockManager;
            this.windowDockingArea1.Size = new System.Drawing.Size(282, 670);
            this.windowDockingArea1.TabIndex = 97;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Button_UToolTipManager
            // 
            this.Button_UToolTipManager.ContainingControl = this;
            this.Button_UToolTipManager.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // uiMemInput1
            // 
            this.uiMemInput1.OwnerForm = this;
            this.uiMemInput1.CustomizeWrite += new Broadleaf.Library.Windows.Forms.CustomizeWriteEventHandler(this.uiMemInput1_CustomizeWrite);
            this.uiMemInput1.CustomizeRead += new Broadleaf.Library.Windows.Forms.CustomizeReadEventHandler(this.uiMemInput1_CustomizeRead);
            this.uiMemInput1.ReadOnLoad = false;
            // 
            // MAKAU03002UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1006, 670);
            this.Controls.Add(this._MAKAU03002UAAutoHideControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.windowDockingArea1);
            this.Controls.Add(this._MAKAU03002UAUnpinnedTabAreaTop);
            this.Controls.Add(this._MAKAU03002UAUnpinnedTabAreaBottom);
            this.Controls.Add(this._MAKAU03002UAUnpinnedTabAreaRight);
            this.Controls.Add(this._MAKAU03002UAUnpinnedTabAreaLeft);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MAKAU03002UA";
            this.Text = "������";
            this.Load += new System.EventHandler(this.MAKAU03002UA_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MAKAU03002UA_FormClosing);
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_TaxPrintDiv)).EndInit();
            this.panel_LineMaSqOfChDiv.ResumeLayout(false);
            this.panel_LineMaSqOfChDiv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineMaSqOfChDiv_tComboEditor)).EndInit();
            this.panel_PrintBlLiDiv.ResumeLayout(false);
            this.panel_PrintBlLiDiv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintBlLiDiv_tComboEditor)).EndInit();
            this.panel_NewPage.ResumeLayout(false);
            this.panel_NewPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageDiv_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            this.panel_AccRecDivCd.ResumeLayout(false);
            this.panel_AccRecDivCd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccRecDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_OutputTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesAreaCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChargeEmployee_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl5.ResumeLayout(false);
            this.ultraExplorerBarContainerControl5.PerformLayout();
            this.panel_BalanceDepositDtl_.ResumeLayout(false);
            this.panel_BalanceDepositDtl_.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceDepositDtl_tComboEditor)).EndInit();
            this.panel_CollectRate.ResumeLayout(false);
            this.panel_CollectRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CollectRatePrtDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutPriceCond_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl7.ResumeLayout(false);
            this.ultraExplorerBarContainerControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_Pattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pattern_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl6.ResumeLayout(false);
            this.ultraExplorerBarContainerControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endRangeNameUltraTextEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startRangeNameUltraTextEditor)).EndInit();
            this.SectionList_ExplorerBarContainerControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Section_Tree)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.History_Tree)).EndInit();
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ExtraInfo_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Extra_ultraExplorerBar)).EndInit();
            this.Extra_ultraExplorerBar.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ExtraData_Panel.ResumeLayout(false);
            this.DataView_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DEMANDLISTVIEW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.Total_Panel.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RpSlipCount_tNedit)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalLastDmd_tNedit)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDeposit_tNedit)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalSales_tNedit)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalTax_tNedit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalDmd_tNedit)).EndInit();
            this.PrintExtra_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ExplorerBar)).EndInit();
            this.Main_ExplorerBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_TabControl)).EndInit();
            this.Main_TabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_DockManager)).EndInit();
            this.dockableWindow1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tNedit6)).EndInit();
            this.windowDockingArea1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region private member


        // ����������p�^�[���}�X�^�A�N�Z�X
        private DmdPrtPtnAcs DmdPrtPtnAcsObj;

        private bool _eventDoFlag = false;
        private string _enterpriseCode = "";

        // �����ݒ苒�_
        private string _demandSectionCode = "";
        private ExtrInfo_EBooksDemandTotal _extraInfo_DemandTotal = null;
        private ExtrInfo_EBooksDemandTotal _prevExtraInfo_DemandTotal = null;

        private DemandEBooksPrintAcs mDemandEBooksPrintAcs = null;
        private PdfHistoryControl mPdfHistoryControl = null;

        private Hashtable _sectionCodeList = null;
        private Hashtable _printHistoryList = null;
        private ArrayList _printHistoryKeyList = null;

        private bool _nodeCheckEventDo = false;

        private Employee _loginEmployee = null;
        private string[] outputCdNames = new string[]{
                                                   "�S�ďo��",
                                                   "�O�ƃv���X���z���o��",
                                                   "�v���X���z�̂ݏo��",
                                                   "�O�̂ݏo��",
                                                   "�v���X���z�ƃ}�C�i�X���z���o��",
                                                   "�O�ƃ}�C�i�X���z���o��",
                                                   "�}�C�i�X���z�̂ݏo��"
                                                 };

        private bool _eventDateChange = false;
        private bool _isOptSection = false;
        private bool _isMainOfficeFunc = false;

        // �K�C�h�n�A�N�Z�X�N���X
        EmployeeAcs _employeeAcs;
        UserGuideAcs _userGuideAcs;

        //�}�E�X�|�C���^�̂���m�[�h��ۑ�����̈�
        private Infragistics.Win.UltraWinTree.UltraTreeNode _lastUltraTreeNode = null;

        // ���R���[����N���X
        private FreePrintController _freePrintController;

        // �G�N�X�v���[���o�[�g������ 
        private Form _topForm = null;
        private bool _explorerBarExpanding = false;

        // ���t�擾���i
        private DateGetAcs _dateGetAcs;

        // �e�t���[���ďo���[�h
        private int _callMode = 0;
        #region <�o��PDF/>

        /// <summary>�o��PDF���</summary>
        private PDFManager _outputPDF;
        /// <summary>
        /// �o��PDF�����擾���܂��B
        /// </summary>
        public PDFManager OutputPDF { get { return _outputPDF; } }

        /// <summary>
        /// PDF�̏o�̓p�X�i�\���p�j���X�g���擾���܂��B
        /// </summary>
        public List<string> PreviewPDFPathList
        {
            get
            {
                if (OutputPDF == null) return new List<string>();
                return OutputPDF.PreviewPDFPathList;
            }
        }

        /// <summary>
        /// �֘A����PDF�t�@�C����S�č폜���܂��B
        /// </summary>
        /// <param name="previewPDFPath">PDF�̏o�̓p�X�i�\���p�j</param>
        public void DeletePDFFiles(string previewPDFPath)
        {
            if (OutputPDF == null) return;
            OutputPDF.DeleteFiles(previewPDFPath);
        }

        #endregion  // <�o��PDF/>

        // �v���r���[�pPDF�p�X���X�g
        private List<string> _previewPdfPathList;
        // �������P�ʂ�PDF�p�X���X�g
        private List<string> _billPdfPathList;

        private SFCMN06002C _printInfo = null;
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�萔
        // ===================================================================================== //
        #region private constant
        private const int START_MODE_DEFAULT_LIST = 1;		// �����ꗗ�\
        private const int START_MODE_DEFAULT_DEMAND = 2;		// ������
        // ���l
        private const int EXSTATUS = -1;
        private const int INITIALSTATUS = 0;
        private const int INITIALINDEX = 0;
        private const int INITIALCOUNT = 0;
        private const int INITIALDATE = 0;
        private const int INITIALLOGICALDELCD = 0;
        private const int INITIALSECTION = 0;
        private const int INITIALOPTION = 0;
        private const int OPERATIONCODE = 3;
        private const int AREADIVCODE = 21;
        private const int FEBRUARYMAXDAY = 28;
        private const int NOTEXISTDAY = 32;
        private const int DTLBILLTYPE = 60;
        private const string TABCONTROL_EXTRAINFOSCREEN_KEY = "ExtractInfoTab";
        private const string TABCONTROL_EXTRADATASCREEN_KEY = "ExtractDataTab";
        private const string THIS_ASSEMBLYID = "MAKAU03002U";

        private const string EXPLORERBAR_SECTIONLIST = "SectionList";
        private const string EXPLORERBAR_HISTORYLIST = "HistoryList";
        private const string CT_XMLEBOOKSFILEFOLDERXMLINFO = "MAKAU03000U_EBooksLinkSetting.XML";
        private const string CT_EBOOKSFOLDER = "\\eBooks\\eBooks";
        private const string CT_CUSTOMERFOLDER = "\\eBooks\\Customer";
        private const string CT_TEMPFOLDER = "\\Temp\\eBooks";
        private const string CT_LOGFOLDER = "\\Log\\eBooks";
        private const string CT_LOGFILENM = "\\{0}_eBook_{1}.txt";
        private const string CT_FOLDERSPLIT = "\\";
        private const string CT_EBOOKSFLPATH = "\\nN2_{0}_{1}.csv";
        private const string CT_CUSTOMERFLPATH = "\\nN7_CustomerRF_Diff_{0}.csv";
        private const string CT_DATETIMEFOMART = "yyyyMMddHHmmss";
        private const string CT_YMDFOMART = "yyyyMMdd";
        private const string CT_LOGDATETIMEFOMART = "yyyy/MM/dd HH:mm:ss";
        private const string CT_LOGCOUNT = "{0}��";
        private const string CT_OPLOGMSG = "{0}���𓯊��@Log�F{1}";
        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
        private const string CT_TRUE = "true";
        private const string CT_FALSE = "false";
        // �o�͉\�������ݒ�t�@�C��
        private const string DMDPRTXMLFILENAME = "PMKAU02010U_DmdPrtPtnSetting.XML";
         //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<       
        // �ŗ��ݒ�t�@�C��
        private const string CTPRINTXMLFILENAME = "TaxRate_UserSetting.XML";
        // �ŕʓ���󎚌x�����b�Z�[�W
        private const string CTTAXPRINTMSG = "����ŗ��ʂ̓�����󎚂���ƁA�������x���Ȃ�\��������܂��B\n��낵���ł����H";

        /// <summary>PDF�����Ǘ��pKEY�i�����ꗗ�\�p�j</summary>
        private const string PDF_HISTORY_KEY = "5590a061-9176-4900-bfac-f433b8e164b9";
        /// <summary>PDF�����Ǘ��pKEY�i�������p�j</summary>
        private const string PDF_HISTORY_DETAIL_KEY = "563ef6ad-a619-41f4-8f27-12a21d1ccb93";
        /// <summary>
        /// PDF�����Ǘ��p�L�[���擾���܂��B
        /// </summary>
        /// <value>�����ꗗ�\�A�̎����A�������ɉ�����PDF�����Ǘ��p�L�[</value>
        private string PDFHistoryKey
        {
            get
            {
                string key = string.Empty;
                switch (_callMode)
                {
                    case START_MODE_DEFAULT_LIST:   // �����ꗗ�\
                        key = PDF_HISTORY_KEY;
                        break;
                    case START_MODE_DEFAULT_DEMAND:
                        key = PDF_HISTORY_DETAIL_KEY;
                        break;
                }
                return key;
            }
        }
        private const string DOCK_PANE0_KEY = "ControlPane0";

        #region ������
        private const string PROGRAMNAME_STR = "���������s(�d�q����A�g)";
        private const string SETPRINTPATMETHOD_STR = "SetPrintPattern";
        private const string SECTION_STR = "���_";
        private const string TOTALDAY_STR = "����{0}";
        private const string CUSTOMERAGENT_STR = "���Ӑ�S��{0}";
        private const string TOTALRAGENT_STR = "�W�v�S��{0}";
        private const string AREA_STR = "�n��{0}";
        private const string CUSTOMERT_STR = "���Ӑ�{0}";
        private const string PRINTDAY_STR = "���s��{0}";
        private const string NOINPUTLIST_STR = "�o�͉�𐿋��惊�X�g";
        private const string PDFFLODER_STR = "\\PDF";
        private const string PATTERN1_EMP = "(��)������(20210120_01_00001001)_20210101_12010100.pdf";
        private const string PATTERN2_EMP = "(��)00001001#01_20210120_120101.pdf";
        private const string PATTERN3_EMP = "(��)������_20210120_00001001_�Z�~����_2021010112010100.pdf";// ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή�
        private const string ASSID_SFANL07200U = "SFANL07200U";
        private const string MONEYFORMAT = "#,##0;-#,##0;";
        private const string MSG_SECTIONCHECKONE_STR = "�o�͑Ώۋ��_�͕K����̓`�F�b�N���Ă��������B";
        private const string MSG_FOLDERNOINPUT_STR = "�o�͐�t�H���_����͂��ĉ������B";
        private const string MSG_FOLDERNOTEXIST_STR = "�w�肳�ꂽ�t�H���_�����݂��܂���B";
        private const string MSG_BILLTYPENOINPUT_STR = "�������^�C�v����͂��ĉ������B";
        private const string MSG_PRINTSTART_STR = "����J�n";
        private const string MSG_PRINTEND_STR = "����I��";
        private const string MSG_OUTPUTSTART_STR = "���o�J�n";
        private const string MSG_OUTPUTEND_STR = "���o�I��";
        private const string MSG_INPUTERROR = "�̓��͂��s���ł��B";
        private const string MSG_NOINPUT = "����͂��ĉ������B";
        private const string MSG_RANGEERROR = "�͈͎̔w��Ɍ�肪����܂��B";
        private const string MSG_NODATA_STR = "�Y������f�[�^������܂���B";
        private const string MSG_BILLTITLE_STR = "���������s(�d�q����A�g)";
        private const string MSG_LISTTITLE_STR = "�����ꗗ�\(�d�q����A�g)";
        private const string MSG_OUTPUTTINGTITLE_STR = "���o��";
        private const string MSG_OUTPUTTING_STR = "���݁A�f�[�^���o���ł��D�D�D";
        private const string MSG_OUTPUTERR_STR = "���������s���ɃG���[������܂����ALOĢ�ق��m�F���Ă��������B";
        private const string MSG_EXE_STR = "explorer.exe";
        private const string MSG_FILECREATE_STR = "{0}�̃t�@�C�����쐬���܂����B";
        private const string MSG_FAIL_STR = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string MSG_SECTIONRANGEERR_STR = "�J�n���_�R�[�h���I�����_�R�[�h���傫�Ȓl�ł��B";
        private const string MSG_CUSDELETED_STR = "�I���������Ӑ�͊��ɍ폜����Ă��܂��B";
        private const string MSG_GETCUSFAIL_STR = "���Ӑ���̎擾�Ɏ��s���܂����B";
        private const string MSG_CUSCHK = "�ʍ��ڂ��܂ރ��C�A�E�g�͐�����������邱�Ƃ͂ł��܂���B\r\n����ł�������܂����H";
        private const string MSG_OUTPUTJYOKENCHANGE = "���o�����ɕύX������܂��B�Ē��o���s���ĉ������B";
        private const string MSG_NOSELECTDATA_STR = "�d�q����o�͑Ώۂ�I�����ĉ������B";
        #endregion
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region events
        /// <summary>PDF�I���Ƃ��̃C�x���g�n���h��</summary>
        public event SelectedPdfNodeEventHandler SelectedPdfNodeEvent;

        /// <summary>�X�e�[�^�X�o�[�\�������񂪏o�͂��ꂽ�Ƃ��̃C�x���g�n���h��</summary>
        public event PrintStatusBar StatusBarInfoPrinted;

        /// <summary>�X�e�[�^�X�o�[�X�V�����񂪏o�͂��ꂽ�Ƃ��̃C�x���g�n���h��</summary>
        public event ChangeStatusBar ChangeTab;

        /// <summary>
        /// �X�e�[�^�X�o�[�ɏ����o�͂��܂��B�i�f�t�H���g�j
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private static void PrintStatusBarOfDefault(object sender, PrintStatusBarEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
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
        static void Main()
        {
            System.Windows.Forms.Application.Run(new MAKAU03002UA());
        }
        #endregion

        // ===================================================================================== //
        // IDemandTbsMDIChildExtrViewPrintForm�@������
        // ===================================================================================== //
        #region IDemandEbooksChildMain
        /// <summary>
        /// Control.Show ���\�b�h�̃I�[�o�[���[�h
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̕\�����s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public void Show(object parameter)
        {
            try
            {
                // �ďo���[�h�ݒ�
                this._callMode = Broadleaf.Library.Text.TStrConv.StrToIntDef(parameter.ToString(), 0);

                // ��ʕ\��������
                SetPrintPattern();

                // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
                this.uiMemInput1.OptionCode = this._callMode.ToString();

                this.Show();
            }
            catch
            { 
            }
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <returns>true:OK, false:NG</returns>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public bool ScreenInputCheck()
        {
            string message;
            Control errControl = null;

            // ��ʓ��͏����`�F�b�N
            bool result = this.ScreenInputCheck(out message, ref errControl);
            if (!result)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                if (errControl != null) errControl.Focus();
            }
            return result;
        }
        /// <summary>
        /// �f�[�^���o����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��̓`�F�b�N���s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public int ExtractData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {

                // ��ʁ����o�����N���X
                this.SetExtraInfo_DemandTotalFromScreen(ref this._extraInfo_DemandTotal);

                // �O�񒊏o�����ݒ�
                this._prevExtraInfo_DemandTotal = this._extraInfo_DemandTotal.Clone();


                switch (_callMode)
                {
                    case START_MODE_DEFAULT_LIST:   // �����ꗗ�\
                        _extraInfo_DemandTotal.EBooksFlg = 0;
                        break;
                    case START_MODE_DEFAULT_DEMAND:
                        // ���������敪
                        _extraInfo_DemandTotal.EBooksFlg = 1;
                        break;
                }

                string msg;
                _printInfo = null;
                status = this.SearchDemandData(0, out msg, true);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_INFO, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                    default:
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">����p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ����������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public int Print(ref object parameter, bool syncFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                // �ŗ�����󎚃��b�Z�[�W�ǉ�
                if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0 && this._extraInfo_DemandTotal.SlipPrtKind == 0)
                {
                    DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, "MAKAU03002UA", CTTAXPRINTMSG, 0, MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        return -1;
                    }
                }

                // ���������̏ꍇ�Atemp�t�H���_������
                if (this._callMode != START_MODE_DEFAULT_LIST && syncFlg)
                {
                    if (!Directory.Exists(System.Environment.CurrentDirectory + CT_TEMPFOLDER))
                    {
                        Directory.CreateDirectory(System.Environment.CurrentDirectory + CT_TEMPFOLDER);
                    }
                    else
                    {
                        foreach (string strFile in Directory.GetFiles(System.Environment.CurrentDirectory + CT_TEMPFOLDER))
                        {
                            File.Delete(strFile);
                        }
                    }
                }

                SFCMN06001U printDialog = new SFCMN06001U();            // ���[�I���K�C�h
                SFCMN06002C printInfo = parameter as SFCMN06002C;       // ������p�����[�^
                _printInfo = printInfo;

                // ��ƃR�[�h
                printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                printInfo.kidopgid = THIS_ASSEMBLYID;             // �N���o�f�h�c
                printInfo.key = PDFHistoryKey;                  // PDF�����Ǘ��pKEY���

                // ��ʁ����o�����N���X
                this.SetExtraInfo_DemandTotalFromScreen(ref this._extraInfo_DemandTotal);

                // �A�N�e�B�u�ȃ^�u�́H
                // ���o�������
                if (this.Main_TabControl.ActiveTab.Key == TABCONTROL_EXTRAINFOSCREEN_KEY)
                {
                    printDialog.PrintMode = 1;  // ���o�����
                }
                // ���o�f�[�^�\�����
                else
                {
                    // �O�񒊏o�����Ɠ������H
                    if (!this._extraInfo_DemandTotal.Equals(this._prevExtraInfo_DemandTotal))
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_QUESTION, MSG_OUTPUTJYOKENCHANGE, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    printDialog.PrintMode = 0;  // ���ڈ��
                }
                printDialog.PrtPosSetButtonVisible = false;

                // �����ꗗ�\
                if (this._extraInfo_DemandTotal.SlipPrtKind == 0)
                {
                    // �����ꗗ�\(�ʏ�̃A�N�e�B�u���|�[�g���)
                    DialogResult dialogResult;

                    // ���ڈ��
                    if (printDialog.PrintMode == 0)
                    {
                        printInfo.PrintPaperSetCd = 1;

                        // ����pDataTable�쐬
                        this.mDemandEBooksPrintAcs.MakePrintDataTable();

                        // �ꗗ��ʂ��\������Ă���ꍇ�A�P���ȏ�o�͐ݒ肳��Ă��邩�H
                        if (this.Main_TabControl.Tabs[TABCONTROL_EXTRADATASCREEN_KEY].Visible)
                        {
                            if (this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint.Count == 0)
                            {
                                TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�o�͂���f�[�^��ݒ肵�ĉ�����", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                return 4;
                            }
                        }


                        // ���o�����̐ݒ�
                        printInfo.jyoken = this._extraInfo_DemandTotal;

                        // ����pDataView�ݒ�
                        printInfo.rdData = this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint;

                        printDialog.PrintInfo = printInfo;

                        // ���[�I���K�C�h
                        dialogResult = printDialog.ShowDialog();


                    }
                    // ���o����
                    else
                    {
                        printInfo.PrintPaperSetCd = 1;

                        // �������̓`�F�b�N���s��
                        string message;
                        Control errControl = null;
                        bool result = this.ScreenInputCheck(out message, ref errControl);
                        if (!result)
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                            if (errControl != null) errControl.Focus();
                            return 9;
                        }

                        printDialog.PrintInfo = printInfo;
                        // ���[�I���K�C�h
                        dialogResult = printDialog.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            // �ݒ���擾
                            printInfo = printDialog.PrintInfo;

                            // ���o����
                            string msg;
                            status = this.SearchDemandData(1, out msg, false);
                            switch (status)
                            {
                                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                    {
                                        break;
                                    }
                                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                    {
                                        TMessageBox(emErrorLevel.ERR_LEVEL_INFO, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                        return status;
                                    }
                                default:
                                    {
                                        TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                        return status;
                                    }
                            }

                            // ����pDataTable�쐬
                            this.mDemandEBooksPrintAcs.MakePrintDataTable();

                            // ��ʃ��t���b�V��
                            this.Refresh();

                            // ���o�����̐ݒ�
                            printInfo.jyoken = this._extraInfo_DemandTotal;
                            // ����pDataView�ݒ�
                            printInfo.rdData = this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint;

                            printDialog.PrintInfo = printInfo;

                            // �������
                            printDialog.PrtProc();

                        }
                    }

                    // �O�񒊏o�����ݒ�
                    if (dialogResult == DialogResult.OK)
                    {
                        this._prevExtraInfo_DemandTotal = this._extraInfo_DemandTotal.Clone();
                    }

                    parameter = (Object)printInfo;
                }  
                // ������
                else
                {
                    // �������̓`�F�b�N���s��
                    string message;
                    Control errControl = null;
                    bool checkRst = this.ScreenInputCheck(out message, ref errControl);
                    if (!checkRst)
                    {
                        TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        if (errControl != null) errControl.Focus();
                        return (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }

                    if (this._callMode != START_MODE_DEFAULT_LIST)
                    {
                        // �ʍ��ڃ`�F�b�N
                        string chkMsg = string.Empty;
                        bool CusChkResult = this.mDemandEBooksPrintAcs.CustomizeCheck(this.Pattern_tComboEditor.SelectedItem.DataValue.ToString(), out chkMsg);
                        // �ʍ��ڂ���ꍇ�A���\�b�h��\������
                        if (CusChkResult)
                        {
                            if (!string.IsNullOrEmpty(chkMsg))
                            {
                                DialogResult dResult = TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, chkMsg, INITIALSTATUS, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                return (int)ConstantManagement.DB_Status.ctDB_EOF;
                            }
                            else
                            {
                                DialogResult dResult = TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, MSG_CUSCHK, INITIALSTATUS, MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                                if (dResult == DialogResult.No)
                                {
                                    this.Pattern_tComboEditor.Focus();
                                    return (int)ConstantManagement.DB_Status.ctDB_EOF;
                                }
                            }
                        }
                    }

                    // �o�̓p�X
                    if (this._callMode != START_MODE_DEFAULT_LIST && syncFlg)
                    {
                        printInfo.outPutFilePathName = System.Environment.CurrentDirectory + CT_TEMPFOLDER;
                    }
                    // �o�͐�����ID
                    printInfo.prpid = this.Pattern_tComboEditor.SelectedItem.DataValue.ToString();
                    this._extraInfo_DemandTotal.PrtSetPaperId = printInfo.prpid;

                    //�t�@�C�����p�^�[��
                    this._extraInfo_DemandTotal.OutPutPattern = (int)this.tComboEditor_Pattern.SelectedItem.DataValue;

                    // ����J�n����
                    DateTime stDateTime = DateTime.Now;

                    // ���o����
                    if (printDialog.PrintMode == 1)
                    {
                        string msg;

                        // ���������敪
                        if (_printInfo != null)
                        {
                            if (_printInfo.printmode == 2)
                            {
                                _extraInfo_DemandTotal.EBooksFlg = 1;
                            }
                            else
                            {
                                _extraInfo_DemandTotal.EBooksFlg = 0;
                            }
                        }

                        status = this.SearchDemandData(1, out msg, false);
                        switch (status)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    break;
                                }
                            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                            case (int)ConstantManagement.DB_Status.ctDB_EOF:
                                {
                                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                    return status;
                                }
                            default:
                                {
                                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, msg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                                    return status;
                                }
                        }
                    }

                    // ����pDataTable�쐬
                    status = this.mDemandEBooksPrintAcs.MakePrintDataTable(printInfo.PcardPrtSuspendcnt, this._extraInfo_DemandTotal);

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                    {
                        string errmsg = MSG_NOSELECTDATA_STR;
                        TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, errmsg, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        return status;
                    }

                    // ��ʃ��t���b�V��
                    this.Refresh();

                    // ������
                    _billPdfPathList = new List<string>();
                    _previewPdfPathList = new List<string>();

                    string pgName = string.Empty;
                    switch (_callMode)
                    {
                        case START_MODE_DEFAULT_LIST:
                            pgName = MSG_LISTTITLE_STR;
                            break;
                        case START_MODE_DEFAULT_DEMAND:
                            pgName = MSG_BILLTITLE_STR;
                            break;
                        default:
                            break;
                    }

                    // 2:���,1:PDF
                    int operationCode = 2;
                    if (_printInfo != null)
                    {
                        operationCode = (_printInfo.printmode == 2) ? 1 : 2;
                    }
                    // 3:�d�q���듯��
                    if (this._callMode != START_MODE_DEFAULT_LIST && syncFlg)
                    {
                        operationCode = OPERATIONCODE;
                    }
                    OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                    operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, ASSID_SFANL07200U, pgName, string.Empty, operationCode, 0, MSG_PRINTSTART_STR, string.Empty);

                    // �I�𒆂̋��_�̕��A�J��Ԃ�
                    # region [FreePrintPaper�����_���Ɏ��s]
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

                    List<string> sectionCodeList = CreateSelectedSectionCodeList(_extraInfo_DemandTotal.ResultsAddUpSecList);
                    sectionCodeList.Sort();

                    // ���R���[����N���X
                    if (_freePrintController == null)
                    {
                        _freePrintController = new FreePrintController();
                    }
                    // �������_�C�A���O�\��
                    _freePrintController.ShowProgressDialog();
                    if (printInfo.printmode == 1 && printInfo.prevkbn == 0)
                    {
                        string preAddUpSecCode = string.Empty;
                        string nextAddUpSecCode = string.Empty;
                        List<string> AddUpSecCodeList = new List<string>();
                        for (int i = 0; i < this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint.Count; i++)
                        {
                            nextAddUpSecCode = (string)this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint[i].Row["AddUpSecCode"].ToString().Trim();
                            if (preAddUpSecCode != nextAddUpSecCode)
                            {
                                AddUpSecCodeList.Add(nextAddUpSecCode);
                                preAddUpSecCode = nextAddUpSecCode;
                            }
                        }
                        sectionCodeList = AddUpSecCodeList;
                    }

                    // ���O�t���O���n�l
                    _freePrintController._logCnt = 0;

                    List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList = new List<DenchoDXIndexCSVEntity>();

                    foreach (string sectionCode in sectionCodeList)
                    {
                        // foreach���̑O��v���r���[�\���ňꎞ�I�Ƀ_�C�A���O��\���ɂ��Ă����񕪂͍ēx�\������ׂ̏���
                        _freePrintController.RestartShowProgressDialog();

                        // �P���������̈���������s
                        int secStatus = FreePrintPaper(printInfo, sectionCode, ref denchoDXIndexCSVEntityList, syncFlg);

                        // STATUS�̊m��
                        if (secStatus == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                        {
                            // �G���[
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                        }
                        else if (secStatus == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                        {
                            // �L�����Z��
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        }
                        else if (secStatus == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ����
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                    }
                    # endregion

                    operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, ASSID_SFANL07200U, pgName, string.Empty, operationCode, 0, MSG_PRINTEND_STR, string.Empty);

                    // �C���f�b�N�X�t�@�C��
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && syncFlg)
                    {
                        DenchoDXIndexCSV denchoDXIndexCSV = new DenchoDXIndexCSV(denchoDXIndexCSVEntityList);
                        string pathCSV = System.Environment.CurrentDirectory + CT_TEMPFOLDER + string.Format(CT_EBOOKSFLPATH, LoginInfoAcquisition.EnterpriseCode, DateTime.Now.ToString(CT_DATETIMEFOMART));
                        denchoDXIndexCSV.MakeIndexCSV(pathCSV);
                    }

                    // ����E�_�C�A���O�I��
                    _freePrintController.Dispose();

                    // PDF�o�͏���(PDF�o�͂̏ꍇ�̂�)
                    # region [�v���r���[�pPDF�\��]
                    // �o��PDF����ݒ�
                    _outputPDF = new PDFManager(
                        _previewPdfPathList,  // �\���pPDF�t���p�X
                        _billPdfPathList     // �������P��PDF�t���p�X
                    );
                    if (OutputPDF.PreviewPDFPathList.Count > 1)
                    {
                        printInfo.pdftemppath = OutputPDF.PreviewPDFPathList[0];
                    }

                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && syncFlg)
                    {
                        // ���O�o��
                        OutEBooksLog(stDateTime, _billPdfPathList);
                    }
                    # endregion

                    // ��ʃ��t���b�V��
                    this.Refresh();

                    // LOĢ�ق��L��ꍇ
                    if (_freePrintController._logCnt != 0)
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        // �G���[�����̃��b�Z�[�W��\������
                        TMsgDisp.Show(form, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, MSG_OUTPUTERR_STR, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                        form.TopMost = false;
                    }

                    // �K�x�[�W�R���N�^�������I�ɌĂяo���B(���������)
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                // ����E�_�C�A���O�I��
                _freePrintController.Dispose();
                // ��ʃ��t���b�V��
                this.Refresh();
                // �K�x�[�W�R���N�^�������I�ɌĂяo���B(���������)
                GC.Collect();
                // �G���[���b�Z�[�W
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return status;

        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void OutEBooksLog(DateTime stDateTime, List<string> pathList)
        {
            System.IO.StreamWriter writer = null;
            try
            {
                // �[���ԍ��擾
                PosTerminalMgAcs posTerminalMgAcs = new PosTerminalMgAcs();
                int cashRegisterNo;
                posTerminalMgAcs.GetCashRegisterNo(out cashRegisterNo, LoginInfoAcquisition.EnterpriseCode);

                string path = System.Environment.CurrentDirectory + CT_LOGFOLDER;
                // �t�H���_�쐬
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                string logPath = System.Environment.CurrentDirectory + CT_LOGFOLDER + string.Format(CT_LOGFILENM, DateTime.Now.ToString(CT_YMDFOMART), cashRegisterNo.ToString());
                writer = new System.IO.StreamWriter(logPath, true, System.Text.Encoding.Default);

                // �o�͓���
                writer.Write(stDateTime.ToString(CT_LOGDATETIMEFOMART));
                writer.Write(Environment.NewLine);

                // ����
                writer.Write(string.Format(CT_LOGCOUNT, pathList.Count.ToString()));
                writer.Write(Environment.NewLine);

                // �t�@�C����
                foreach (string flNm in pathList)
                {
                    int index = flNm.LastIndexOf("\\");
                    writer.Write(flNm.Substring(index + 1));
                    writer.Write(Environment.NewLine);
                }

                OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                string opLogMsg = string.Format(CT_OPLOGMSG, pathList.Count.ToString(), logPath);
                operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, ASSID_SFANL07200U, MSG_BILLTITLE_STR, string.Empty, OPERATIONCODE, 0, opLogMsg, string.Empty);
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public int SyncMain()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �d�q����󂯓n���p�t�H���_�擾
                EBooksLinkSetInfo eBooksFileFolderXmlInfo = GetEBooksFileFolderXmlInfo();

                // �d�q����󂯓n��
                CopyEBooksDevDirectory(eBooksFileFolderXmlInfo);

                // ����惊�X�g�쐬
                DenchoDXCustomerExportAcs denchoDXCustomerExportAcs = new DenchoDXCustomerExportAcs();
                denchoDXCustomerExportAcs.MakeCustomerCSVDifference(LoginInfoAcquisition.EnterpriseCode, eBooksFileFolderXmlInfo.CustomFolder + string.Format(CT_CUSTOMERFLPATH, DateTime.Now.ToString(CT_DATETIMEFOMART)));
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return status;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
        /// <summary>
        /// ���o�����^�u�ɖ߂�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���o�����^�u�ɖ߂���s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/04/21</br>
        /// </remarks>
        public void ReturnToExtraCondition()
        {
            //�������̎�
            if (this._callMode != START_MODE_DEFAULT_LIST)
            {
                // ���o�����^�u�ɖ߂�
                Infragistics.Win.UltraWinTabControl.UltraTab tab =
                    this.Main_TabControl.Tabs[TABCONTROL_EXTRAINFOSCREEN_KEY];
                this.Main_TabControl.Focus();
                this.Main_TabControl.SelectedTab = tab;
            }

        }
        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
        /// <summary>
        /// �d�q����󂯓n���p�t�H���_�擾
        /// </summary>
        /// <remarks>
        /// <br>Note        : �d�q����󂯓n���p�t�H���_�擾�������s��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private EBooksLinkSetInfo GetEBooksFileFolderXmlInfo()
        {
            EBooksLinkSetInfo eBooksFileFolderXmlInfo = new EBooksLinkSetInfo();
            try
            {
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XMLEBOOKSFILEFOLDERXMLINFO)))
                {
                    // XML����`�F�b�N�敪���擾����
                    eBooksFileFolderXmlInfo = UserSettingController.DeserializeUserSetting<EBooksLinkSetInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CT_XMLEBOOKSFILEFOLDERXMLINFO));
                }
                else
                {
                    // �f�t�H���g�t�H���_
                    eBooksFileFolderXmlInfo.EBooksFolder = System.Environment.CurrentDirectory + CT_EBOOKSFOLDER;
                    eBooksFileFolderXmlInfo.CustomFolder = System.Environment.CurrentDirectory + CT_CUSTOMERFOLDER;
                }
            }
            catch
            {
                // �f�t�H���g�t�H���_
                eBooksFileFolderXmlInfo.EBooksFolder = System.Environment.CurrentDirectory + CT_EBOOKSFOLDER;
                eBooksFileFolderXmlInfo.CustomFolder = System.Environment.CurrentDirectory + CT_CUSTOMERFOLDER;
            }
            finally
            {
                // �t�H���_�쐬
                if (!Directory.Exists(eBooksFileFolderXmlInfo.EBooksFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(eBooksFileFolderXmlInfo.EBooksFolder);
                }
                if (!Directory.Exists(eBooksFileFolderXmlInfo.CustomFolder))
                {
                    DirectoryInfo di = Directory.CreateDirectory(eBooksFileFolderXmlInfo.CustomFolder);
                }
            }
            return eBooksFileFolderXmlInfo;
        }

        /// <summary>
        /// �d�q����󂯓n��
        /// </summary>
        /// <remarks>
        /// <br>Note         : �d�q����󂯓n���������s��</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        private void CopyEBooksDevDirectory(EBooksLinkSetInfo eBooksFileFolderXmlInfo)
        {
            //�t�@�C���R�s�[
            DirectoryInfo dir = new DirectoryInfo(System.Environment.CurrentDirectory + CT_TEMPFOLDER);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)
                {
                    continue;
                }
                else
                {
                    File.Copy(i.FullName, eBooksFileFolderXmlInfo.EBooksFolder + CT_FOLDERSPLIT + i.Name);
                }
            }
        }

        /// <summary>
        /// ���_�R�[�h���X�g�����i�S�Ўw��̓��X�g�ɓW�J���đΉ�����j
        /// </summary>
        /// <param name="sectionCodeArray">���_�R�[�h</param>
        /// <returns>���_�R�[�h���X�g</returns>
        /// <remarks>
        /// <br>Note         : �d�q����󂯓n���������s��</br>
        /// <br>Programmer   : ���O</br>
        /// <br>Date         : 2022/03/07</br>
        /// </remarks>
        private List<string> CreateSelectedSectionCodeList(string[] sectionCodeArray)
        {
            if (sectionCodeArray.Length == 0 ||
                 (sectionCodeArray.Length == 1 && (sectionCodeArray[0].Trim() == ALL_SECTION_CODE || sectionCodeArray[0].Trim() == string.Empty)))
            {
                // �S�Ўw��Ƃ݂Ȃ�

                // ���X�g������
                List<string> sectionList = new List<string>();
                foreach (object obj in this.mDemandEBooksPrintAcs.SectionTable.Values)
                {
                    if (obj is SecInfoSet)
                    {
                        if ((obj as SecInfoSet).SectionCode.Trim() != ALL_SECTION_CODE && (obj as SecInfoSet).SectionCode.Trim() != string.Empty)
                        {
                            sectionList.Add((obj as SecInfoSet).SectionCode.Trim());
                        }
                    }
                }
                return sectionList;
            }
            else if (sectionCodeArray.Length > 0)
            {
                // ���_�w��
                return new List<string>(sectionCodeArray);
            }

            return new List<string>();
        }

        /// <summary>
        /// ������ޕύX����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ������ޕύX���̏������s���܂��B
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public void ChangePrintType()
        {
            int outPutDiv = 0;
            int dmdDtlDiv = 0;
            outPutDiv = (int)this.OutPutPriceCond_tComboEditor.SelectedItem.DataValue;

            dmdDtlDiv = 1;//�������󁨐�����
            int issueType = -1;
            this.mDemandEBooksPrintAcs.SelectViewData(outPutDiv, dmdDtlDiv, issueType);

            // ���v���z�v�Z
            this.CalculationTotalViewRow();
        }
        #endregion


        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private methods
        /// <summary>
        /// ������񒊏o�O���b�h��ݒ肵�܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��������\������O���b�h��ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SettingGrid()
        {
            // �O���b�h�̃J��������ݒ肵�܂��B
            SettingGridColumn(DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns);
        }

        /// <summary>
        /// ������񒊏o�O���b�h�J�������ݒ菈��
        /// </summary>
        /// <param name="Columns">�O���b�h�̃J�����R���N�V����</param>
        /// <remarks>
        /// <br>Note        : �����O���b�h�ɕ\������J��������ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SettingGridColumn(Infragistics.Win.UltraWinGrid.ColumnsCollection Columns)
        {
            try
            {
                string _moneyFormat = MONEYFORMAT;

                // ��U�A�S�Ă̗���\���ɂ���B
                foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
                {
                    column.Hidden = true;
                }

                //--------------------------------------------------------------------------------
                //  �\������J�������
                //--------------------------------------------------------------------------------
                // ����t���O
                switch (this._callMode)
                {
                    case START_MODE_DEFAULT_LIST:       // �����ꗗ�\
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintFlag].Hidden = true;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintFlag].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        break;
                    case START_MODE_DEFAULT_DEMAND:

                        Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintFlag].Hidden = false;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintFlag].Header.Caption = "�d��.DX�o��";
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintFlag].Width = 50;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintFlag].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
                        break;
                }

                // ���R�[�h��
                Columns[DemandEBooksPrintAcs.CT_CsDmd_RecordName].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_RecordName].Header.Caption = "���R�[�h��";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_RecordName].Width = 50;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_RecordName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                // �v�㋒�_
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AddUpSecCode].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AddUpSecCode].Header.Caption = "�������_";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AddUpSecCode].Width = 30;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AddUpSecCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                // ���ы��_
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ResultsSectCd].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ResultsSectCd].Header.Caption = "���ы��_";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ResultsSectCd].Width = 30;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ResultsSectCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                // ������
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ClaimCodeDisp].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ClaimCodeDisp].Header.Caption = "������";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ClaimCodeDisp].Width = 50;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ClaimCodeDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                // ���Ӑ�
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerCodeDisp].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerCodeDisp].Header.Caption = "���Ӑ�";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerCodeDisp].Width = 50;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerCodeDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                // ���Ӑ於��
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerSnmDisp].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerSnmDisp].Header.Caption = "���Ӑ於";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerSnmDisp].Width = 100;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerSnmDisp].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

                // �W����
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CollectMoneyName].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CollectMoneyName].Header.Caption = "�W����";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CollectMoneyName].Width = 20;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CollectMoneyName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // �W����
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CollectMoneyDay].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CollectMoneyDay].Header.Caption = "�W����";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CollectMoneyDay].Width = 20;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_CollectMoneyDay].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // �O�񐿋����z
                Columns[DemandEBooksPrintAcs.CT_CsDmd_DemandBalance].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_DemandBalance].Header.Caption = "�O�񐿋����z";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_DemandBalance].Width = 77;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_DemandBalance].Format = _moneyFormat;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_DemandBalance].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // �������
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Header.Caption = "�������";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Width = 77;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Format = _moneyFormat;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_ThisTimeDmdNrml].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                if (mDemandEBooksPrintAcs.AllDefSetData != null)
                {
                    if (mDemandEBooksPrintAcs.AllDefSetData.TotalAmountDispWayCd == 0)
                    {
                        // ���z�\�����@ = �Ŕ���
                        // ���񔄏�z
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Hidden = false;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Header.Caption = "���񔄏�";
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Width = 77;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Format = _moneyFormat;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        // ��������
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Header.Caption = "��������";
                    }
                    else
                    {
                        // ���z�\�����@ = �ō���
                        // ���񔄏�z
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Hidden = false;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Header.Caption = "���񔄏�";
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Width = 77;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Format = _moneyFormat;
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                        // ��������
                        Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Header.Caption = "(����������)";
                    }
                }
                else
                {
                    // ���񔄏�z
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Hidden = false;
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Header.Caption = "���񔄏�";
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Width = 77;
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Format = _moneyFormat;
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                    // ��������
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Header.Caption = "��������";
                }

                // ��������
                Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].Width = 77;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_PrintTtlConsTaxDmd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // �������z
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AfCalDemandPrice].Hidden = false;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AfCalDemandPrice].Header.Caption = "�������z";
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AfCalDemandPrice].Width = 77;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AfCalDemandPrice].Format = _moneyFormat;
                Columns[DemandEBooksPrintAcs.CT_CsDmd_AfCalDemandPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // �S���Җ���
                if (TStrConv.StrToIntDef(this.ChargeEmployee_tComboEditor.SelectedItem.DataValue.ToString(), 0) == 1)
                {
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_BillCollecterNm].Hidden = false;
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_BillCollecterNm].Header.Caption = "�W���S��";
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_BillCollecterNm].Width = 100;
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_BillCollecterNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                else
                {
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerAgentNm].Hidden = false;
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerAgentNm].Header.Caption = "���Ӑ�S��";
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerAgentNm].Width = 100;
                    Columns[DemandEBooksPrintAcs.CT_CsDmd_CustomerAgentNm].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ����������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            this.InitialExtraInfoSetting();
            this.SetScreenFromExtraInfo_DemandTotal(this._extraInfo_DemandTotal);

            // ���z�\�����@
            if (mDemandEBooksPrintAcs.AllDefSetData != null && mDemandEBooksPrintAcs.AllDefSetData.TotalAmountDispWayCd == 0)
            {
                // �Ŕ���
                this.ConsTaxTiTle_Label.Text = "��������";
            }
            else
            {
                // �ō���
                this.ConsTaxTiTle_Label.Text = "(����������)";
            }

            // �K�C�h�{�^���C���[�W�ݒ�
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            EmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            EmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            EmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            EmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            ub_SalesAreaCodeStGuid.ImageList = IconResourceManagement.ImageList16;
            ub_SalesAreaCodeStGuid.Appearance.Image = Size16_Index.STAR1;
            ub_SalesAreaCodeEdGuid.ImageList = IconResourceManagement.ImageList16;
            ub_SalesAreaCodeEdGuid.Appearance.Image = Size16_Index.STAR1;

            #region < �\������ >
            Point point = new Point();
            this.IssueDay_tDateEdit.SetDateTime(System.DateTime.Now);

            switch (this._callMode)
            {
                case START_MODE_DEFAULT_LIST:       // �����ꗗ�\
                    {
                        //����Ώ�
                        this.ultraLabel1.Text = "�o�͑Ώ�";

                        // ���y�[�W
                        this.panel_NewPage.Visible = true;

                        //�󔒍s��
                        this.panel_PrintBlLiDiv.Visible = true;

                        //�r����
                        this.panel_LineMaSqOfChDiv.Visible = true;

                        // �ŕʓ���󎚋敪
                        this.panel9.Visible = true;

                        //������� 
                        point.X = 6;
                        point.Y = 0;
                        this.panel_CollectRate.Location = point;
                        this.panel_CollectRate.Visible = true;

                        //�c��������
                        point.X = 6;
                        point.Y = 60;
                        this.panel_BalanceDepositDtl_.Location = point;
                        this.panel_BalanceDepositDtl_.Visible = true;

                        //�o�͋敪
                        this.ultraLabel6.Visible =false;
                        this.tComboEditor_OutputTarget.Visible = false;
                        this.ultraLabel4.Visible = false;
                        this.ultraLabel12.Visible = false;

                        // ���|�敪
                        point.X = 6;
                        point.Y = 90;
                        this.panel_AccRecDivCd.Location = point;
                        this.panel_AccRecDivCd.Visible = true;

                        // ���s��
                        this.ultraLabel11.Visible = false;
                        this.IssueDay_tDateEdit.Visible = false;

                        // �G�N�X�v���[���[�o�[��������
                        this.Extra_ultraExplorerBar.Groups[0].Settings.ContainerHeight = 154;
                        this.Extra_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 150;
                        this.Extra_ultraExplorerBar.Groups[3].Settings.ContainerHeight = 92;
                        this.Extra_ultraExplorerBar.Groups[4].Visible = false;

                        break;
                    }
                case START_MODE_DEFAULT_DEMAND:		// ������
                    {
                        // ���|�敪
                        this.panel_AccRecDivCd.Visible = false;

                        // �G�N�X�v���[���[�o�[��������
                        this.Extra_ultraExplorerBar.Groups[0].Settings.ContainerHeight = 38;
                        this.Extra_ultraExplorerBar.Groups[2].Settings.ContainerHeight = 154;
                        this.Extra_ultraExplorerBar.Groups[3].Settings.ContainerHeight = 63;

                        break;
                    }
            }
            #endregion
        }

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
            // �����f�[�^�Ǎ�
            int status = this.mDemandEBooksPrintAcs.InitialDataRead(LoginInfoAcquisition.EnterpriseCode, out message);

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
        /// ���_���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���_����ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SettingSectonListForm()
        {
            this.Section_Tree.ShowLines = false;
            foreach (string secCode in this.mDemandEBooksPrintAcs.SecCodeList)
            {
                SecInfoSet secInfoSet = (SecInfoSet)this.mDemandEBooksPrintAcs.SectionTable[secCode];

                this.Section_Tree.Nodes.Add(secCode, secInfoSet.SectionGuideNm);
                this.Section_Tree.Nodes[secCode].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
                this.Section_Tree.Nodes[secCode].CheckedState = System.Windows.Forms.CheckState.Unchecked;
            }
        }

        /// <summary>
        /// �o�c�e�o�͗������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : �o�c�e�o�͗�����ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SettingRecentPdfList()
        {

            // �o�͊Ǘ�����p���[��KEY�ݒ�(���̏��A�����ꗗ�̂�)
            this._printHistoryKeyList.Add(PDFHistoryKey);

            // �o�͊Ǘ������N���X������
            string[] keys = (string[])this._printHistoryKeyList.ToArray(typeof(string));
            this.mPdfHistoryControl.InitializeHistoryTable(keys);

            // �o�͊Ǘ����������\��
            this.DisplaySettingPdfList();
        }

        /// <summary>
        /// �o�c�e�o�͗�������ʕ\������
        /// </summary>
        /// <remarks>
        /// <br>Note        : �o�c�e�o�͗�������ʕ\�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void DisplaySettingPdfList()
        {
            Infragistics.Win.UltraWinTree.UltraTreeNode topNode;
            PrintInfoItem infoItem;

            this.History_Tree.Nodes.Clear();
            this._printHistoryList.Clear();

            foreach (string wkKey in this._printHistoryKeyList)
            {
                // �t�B���^�����ݒ�
                this.mPdfHistoryControl.HistoryDataView.RowFilter =
                    String.Format(
                    "{0} = '{1}' AND {2} = '{3}'",
                    PdfHistoryControl.ctCOL_PrintKey,
                    wkKey,
                    PdfHistoryControl.ctCOL_LoginWorkerCode,
                    (this._loginEmployee != null) ? this._loginEmployee.EmployeeCode : "");

                // �\�[�g���ݒ�
                this.mPdfHistoryControl.HistoryDataView.Sort =
                    String.Format("{0} DESC, {1} ASC", PdfHistoryControl.ctCOL_PrintOutDateTime, PdfHistoryControl.ctCOL_PdfFileName);

                foreach (DataRowView rowView in this.mPdfHistoryControl.HistoryDataView)
                {
                    // �o�͗����e�[�u���ɒǉ�
                    infoItem = new PrintInfoItem(rowView.Row);
                    this._printHistoryList.Add(infoItem.Id, infoItem);

                    // �e�m�[�h�擾
                    topNode = this.History_Tree.GetNodeByKey(infoItem.PrintKey);
                    if (topNode == null)
                    {
                        topNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(infoItem.PrintKey, infoItem.PrintName);
                        this.History_Tree.Nodes.Add(topNode);
                    }

                    // �q�m�[�h��ǉ�����
                    Infragistics.Win.UltraWinTree.UltraTreeNode childNode = new Infragistics.Win.UltraWinTree.UltraTreeNode(
                        infoItem.Id.ToString(),
                        String.Format("{0} {1}",
                        TDateTime.DateTimeToString("GGYYMMDD", infoItem.PrintOutDateTime),
                        TDateTime.DateTimeToString("HHMM", infoItem.PrintOutDateTime)));
                    childNode.LeftImages.Add(IconResourceManagement.ImageList16.Images[(int)Size16_Index.LIST4]);
                    childNode.Tag = infoItem.PdfFileName;

                    topNode.Nodes.Add(childNode);
                }
            }

            this.History_Tree.ExpandAll();
        }
        /// <summary>
        /// ���o���������l�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���o�����ɏ����l��ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void InitialExtraInfoSetting()
        {
            // ��ƃR�[�h
            this._extraInfo_DemandTotal.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_OP
            this._extraInfo_DemandTotal.IsOptSection = this._isOptSection;

            // �{�Ћ@�\�L��
            this._extraInfo_DemandTotal.IsMainOfficeFunc = this._isMainOfficeFunc;

            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            totalDayCalculator.InitializeHisDmdC();
            totalDayCalculator.GetHisTotalDayDmdC(this._loginEmployee.BelongSectionCode, out prevTotalDay);
            if (prevTotalDay != DateTime.MinValue)
            {
                // �O�������ݒ�
                this._extraInfo_DemandTotal.AddUpDate = prevTotalDay;
            }
            else
            {
                // ���ݓ�����ݒ�
                this._extraInfo_DemandTotal.AddUpDate = DateTime.Now;
            }

            switch (this._callMode)
            {
                case START_MODE_DEFAULT_LIST:		// �����ꗗ�\
                    {
                        this._extraInfo_DemandTotal.SlipPrtKind = 0;
                        break;
                    }
                case START_MODE_DEFAULT_DEMAND:		// ���א�����
                    {
                        this._extraInfo_DemandTotal.SlipPrtKind = 60;
                        break;
                    }
            }

            // �o�͏�
            this._extraInfo_DemandTotal.SortOrder = 0;

            // ���Ӑ�R�[�h(�J�n)
            this._extraInfo_DemandTotal.CustomerCodeSt = 0;

            // ���Ӑ�R�[�h(�I��)
            this._extraInfo_DemandTotal.CustomerCodeEd = 0;

            // �ڋq�S���҃R�[�h(�J�n)
            this._extraInfo_DemandTotal.CustomerAgentCdSt = string.Empty;

            // �ڋq�S���҃R�[�h(�I��)
            this._extraInfo_DemandTotal.CustomerAgentCdEd = string.Empty;

            // �W���S���҃R�[�h(�J�n)
            this._extraInfo_DemandTotal.BillCollecterCdSt = string.Empty;

            // �W���S���҃R�[�h(�I��)
            this._extraInfo_DemandTotal.BillCollecterCdEd = string.Empty;

            // �n��(�J�n)
            this._extraInfo_DemandTotal.SalesAreaCodeSt = 0;

            // �n��(�I��)
            this._extraInfo_DemandTotal.SalesAreaCodeEd = 0;

            // �ďo���[�h�ɂ��o�͋��z�敪��ݒ�
            switch (this._callMode)
            {
                case START_MODE_DEFAULT_LIST:	        // �����ꗗ�\
                    this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandEBooksPrintAcs.BillPrtStData.BillTableOutCd;
                    break;
                case START_MODE_DEFAULT_DEMAND:        // ������
                    this._extraInfo_DemandTotal.OutPutPriceCond = this.mDemandEBooksPrintAcs.BillPrtStData.TotalBillOutputDiv;
                    break;
                default:
                    break;
            }

            // �����
            this._extraInfo_DemandTotal.CollectRatePrtDiv = 0;
            // �c����������
            this._extraInfo_DemandTotal.BalanceDepositDtl = 1;
            // ���s��
            this._extraInfo_DemandTotal.IssueDay = DateTime.Now;
            // ���|�敪
            this._extraInfo_DemandTotal.AccRecDivCd = 1;
        }

        /// <summary>
        /// ���o�����ݒ肩���ʕ\������(���o���������)
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���o�����ݒ聨��ʂ֕\�����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SetScreenFromExtraInfo_DemandTotal(ExtrInfo_EBooksDemandTotal extraInfo)
        {
            this._eventDoFlag = false;
            try
            {
                // ����
                this.AddUpDate_tDateEdit.SetDateTime(extraInfo.AddUpDate);

                // �o�͏�
                this.PrintOder_tComboEditor.Value = extraInfo.SortOrder;

                // ����
                this.NewPageDiv_tComboEditor.Value = extraInfo.NewPageDiv;

                // �ŕʓ���󎚋敪
                this.tComboEditor_TaxPrintDiv.Value = 1;

                // �r���󎚋敪
                this.lineMaSqOfChDiv_tComboEditor.Value = 0;

                // �󔒍s��
                this.PrintBlLiDiv_tComboEditor.Value = 1;

                // ���Ӑ�R�[�h(�J�n)
                this.tNedit_CustomerCode_St.SetInt(extraInfo.CustomerCodeSt);
                // ���Ӑ�R�[�h(�I��)
                this.tNedit_CustomerCode_Ed.SetInt(extraInfo.CustomerCodeEd);

                // �S���ҋ敪
                this.ChargeEmployee_tComboEditor.Value = extraInfo.CustomerAgentDivCd;
                if (extraInfo.CustomerAgentDivCd == 0)
                {
                    // �ڋq�S���҃R�[�h(�J�n)
                    this.tEdit_EmployeeCode_St.DataText = extraInfo.CustomerAgentCdSt;
                    // �ڋq�S���҃R�[�h(�I��)
                    this.tEdit_EmployeeCode_Ed.DataText = extraInfo.CustomerAgentCdEd;
                }
                else
                {
                    // �W���S���҃R�[�h(�J�n)
                    this.tEdit_EmployeeCode_St.DataText = extraInfo.BillCollecterCdSt;
                    // �W���S���҃R�[�h(�I��)
                    this.tEdit_EmployeeCode_Ed.DataText = extraInfo.BillCollecterCdEd;
                }

                // �o�͋��z�敪
                this.OutPutPriceCond_tComboEditor.SelectedIndex = this._extraInfo_DemandTotal.OutPutPriceCond;

                // �������
                this.CollectRatePrtDiv_tComboEditor.Value = extraInfo.CollectRatePrtDiv;

                // �c����������
                this.BalanceDepositDtl_tComboEditor.Value = extraInfo.BalanceDepositDtl;

                // ���s��
                this.IssueDay_tDateEdit.SetDateTime(extraInfo.IssueDay);

                // ���|�敪
                this.AccRecDivCd_tComboEditor.Value = extraInfo.AccRecDivCd;

            }
            finally
            {
                this._eventDoFlag = true;

                uiMemInput1.ReadMemInput();
            }
        }

        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʁ����o�����֐ݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SetExtraInfo_DemandTotalFromScreen(ref ExtrInfo_EBooksDemandTotal extraInfo)
        {
            // ��ƃR�[�h
            this._extraInfo_DemandTotal.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_OP
            this._extraInfo_DemandTotal.IsOptSection = this._isOptSection;

            // �{�Ћ@�\�L��
            this._extraInfo_DemandTotal.IsMainOfficeFunc = this._isMainOfficeFunc;

            // �{�Ћ@�\����
            if (this.Main_ExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible)
            {
                ArrayList secList = new ArrayList();

                // ���_�̑I������ݒ�
                this._sectionCodeList.Clear();
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_Tree.Nodes)
                {
                    if (utn.CheckedState == CheckState.Checked)
                    {
                        this._sectionCodeList.Add(utn.Key, utn.Key);
                    }
                }

                if (this._sectionCodeList.Count == 0)
                {
                    _sectionCodeList.Add(ALL_SECTION_CODE, ALL_SECTION_CODE);
                }

                // ���_���ݒ�
                if (this._sectionCodeList.ContainsKey(DemandEBooksPrintAcs.CT_AllSectionCode))
                {
                    // �S��?
                    extraInfo.IsSelectAllSection = false;
                    extraInfo.IsOutputAllSecRec = true;

                    // ���_���̃J����ON
                    this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns[DemandEBooksPrintAcs.CT_CsDmd_AddUpSecName].Hidden = false;

                    extraInfo.ResultsAddUpSecList = new string[1];
                    extraInfo.ResultsAddUpSecList[0] = string.Empty;
                }
                else
                {
                    // �I�����_
                    foreach (DictionaryEntry entry in this._sectionCodeList)
                    {
                        secList.Add(entry.Value.ToString());
                    }
                    extraInfo.ResultsAddUpSecList = (string[])secList.ToArray(typeof(string));

                    extraInfo.IsSelectAllSection = false;
                    extraInfo.IsOutputAllSecRec = false;

                    // ���_���̃J����OFF
                    this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns[DemandEBooksPrintAcs.CT_CsDmd_AddUpSecName].Hidden = true;
                }
            }
            // �{�Ћ@�\�Ȃ��@or ���_�I�v�V�����Ȃ�
            else
            {
                extraInfo.ResultsAddUpSecList = new string[0];

                extraInfo.IsSelectAllSection = false;
                extraInfo.IsOutputAllSecRec = false;
                // ���_���̃J����OFF
                this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns[DemandEBooksPrintAcs.CT_CsDmd_AddUpSecName].Hidden = true;
            }

            // ����
            extraInfo.AddUpDate = this.AddUpDate_tDateEdit.GetDateTime();

            switch (this._callMode)
            {
                case START_MODE_DEFAULT_LIST:		// �����ꗗ�\
                    {
                        // ���s�^�C�v
                        extraInfo.SlipPrtKind = 0;
                        // ����
                        extraInfo.NewPageDiv = Convert.ToInt32(this.NewPageDiv_tComboEditor.SelectedItem.DataValue);
                        // �������
                        extraInfo.CollectRatePrtDiv = Convert.ToInt32(this.CollectRatePrtDiv_tComboEditor.SelectedItem.DataValue);
                        // �c����������
                        extraInfo.BalanceDepositDtl = Convert.ToInt32(this.BalanceDepositDtl_tComboEditor.SelectedItem.DataValue);
                        // �󔒍s��
                        extraInfo.PrintBlLiDiv = Convert.ToInt32(this.PrintBlLiDiv_tComboEditor.SelectedItem.DataValue);
                        // �r���󎚋敪
                        extraInfo.LineMaSqOfChDiv = Convert.ToInt32(this.lineMaSqOfChDiv_tComboEditor.SelectedItem.DataValue);
                        // �ŕʓ���󎚋敪
                        extraInfo.TaxPrintDiv = Convert.ToInt32(this.tComboEditor_TaxPrintDiv.SelectedItem.DataValue);

                        // �ŕʓ���󎚂���
                        if (Convert.ToInt32(this.tComboEditor_TaxPrintDiv.SelectedItem.DataValue) == 0)
                        {
                            TaxRatePrintInfo taxInfo = null;
                            string errMsg = string.Empty;

                            int status = Deserialize(out taxInfo, out errMsg);
                            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                            {
                                // �ŗ�1
                                extraInfo.TaxRate1 = Convert.ToDouble(taxInfo.TaxRate1);
                                // �ŗ�2
                                extraInfo.TaxRate2 = Convert.ToDouble(taxInfo.TaxRate2);
                            }
                        }

                        // ���|�敪
                        extraInfo.AccRecDivCd = (int)this.AccRecDivCd_tComboEditor.Value;

                        // ����Ώ�
                        extraInfo.PrintOutMode = (int)this.tComboEditor_PrintTarget.SelectedItem.DataValue;
                        break;
                    }
                case START_MODE_DEFAULT_DEMAND:		// ������
                    {
                        // ���s�^�C�v
                        extraInfo.SlipPrtKind = DTLBILLTYPE;

                        // ����Ώ�
                        extraInfo.PrintOutMode = (int)this.tComboEditor_PrintTarget.SelectedItem.DataValue;
                        break;
                    }
            }

            // �n��(�J�n)
            extraInfo.SalesAreaCodeSt = this.tNedit_SalesAreaCode_St.GetInt();
            // �n��(�I��)
            extraInfo.SalesAreaCodeEd = this.tNedit_SalesAreaCode_Ed.GetInt();

            // ���s��
            extraInfo.IssueDay = this.IssueDay_tDateEdit.GetDateTime();

            // �o�͏�
            extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);

            // ���Ӑ�R�[�h(�J�n)
            extraInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
            // ���Ӑ�R�[�h(�I��)
            extraInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
            // �S���ҋ敪
            extraInfo.CustomerAgentDivCd = TStrConv.StrToIntDef(this.ChargeEmployee_tComboEditor.SelectedItem.DataValue.ToString(), 0);

            if (this.ChargeEmployee_tComboEditor.SelectedIndex == 0)
            {
                // �ڋq�S���҃R�[�h(�J�n)
                if (this.tEdit_EmployeeCode_St.Text.Trim() == string.Empty)
                {
                    extraInfo.CustomerAgentCdSt = string.Empty;
                }
                else
                {
                    extraInfo.CustomerAgentCdSt = this.tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                }
                // �ڋq�S���҃R�[�h(�I��)
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == string.Empty)
                {
                    extraInfo.CustomerAgentCdEd = string.Empty;
                }
                else
                {
                    extraInfo.CustomerAgentCdEd = this.tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                }
            }
            else
            {
                // �W���S���҃R�[�h(�J�n)
                if (this.tEdit_EmployeeCode_St.Text.Trim() == string.Empty)
                {
                    extraInfo.BillCollecterCdSt = string.Empty;
                }
                else
                {
                    extraInfo.BillCollecterCdSt = this.tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                }
                // �W���S���҃R�[�h(�I��)
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == string.Empty)
                {
                    extraInfo.BillCollecterCdEd = string.Empty;
                }
                else
                {
                    extraInfo.BillCollecterCdEd = this.tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                }
            }

            // �o�͋��z�敪
            extraInfo.OutPutPriceCond = (int)this.OutPutPriceCond_tComboEditor.SelectedItem.DataValue;

            // �d�q����o�͑Ώ�
            extraInfo.EBooksOutMode = (int)this.tComboEditor_OutputTarget.SelectedItem.DataValue;
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private bool ScreenInputCheck(out string message, ref Control errControl)
        {
            bool status = true;
            try
            {
                message = string.Empty;
                bool result = false;
                errControl = null;
                DateGetAcs.CheckDateResult cdrResult;

                const string ct_InputError = "�̓��͂��s���ł�";
                const string ct_NoInput = "����͂��ĉ�����";
                const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";

                // ���_�͈�
                _currentResultCode = ResultCode.Normal;
                if (CheckSectionTreeNode(
                    this.tEdit_SectionCode_St.Text,
                    this.tEdit_SectionCode_Ed.Text
                ).Equals((int)ResultCode.StartSectionCodeHasError))
                {
                    _currentResultCode = ResultCode.StartSectionCodeHasError;
                    message = SECTION_STR + ct_RangeError;
                    errControl = this.tEdit_SectionCode_St;
                    return false;
                }

                // ����
                if (CallCheckDate(out cdrResult, ref AddUpDate_tDateEdit) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                            {
                                message = string.Format(TOTALDAY_STR, ct_InputError);
                                errControl = this.AddUpDate_tDateEdit;
                            }
                            break;
                        case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                            {
                                message = string.Format(TOTALDAY_STR, ct_NoInput);
                                errControl = this.AddUpDate_tDateEdit;
                            }
                            break;
                    }
                    status = false;
                }

                // XML�̐ŗ����
                if (tComboEditor_TaxPrintDiv.SelectedIndex == 0 && this._extraInfo_DemandTotal.SlipPrtKind == 0)
                {
                    string errMsg = string.Empty;
                    TaxRatePrintInfo taxRatePrintInfo = null;
                    Deserialize(out taxRatePrintInfo, out errMsg);
                    if (errMsg != string.Empty)
                    {
                        message = errMsg;
                        errControl = tComboEditor_TaxPrintDiv;
                        status = false;
                        return status;
                    }
                }

                // �S���҃R�[�h
                else if (
                  (this.tEdit_EmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                  (this.tEdit_EmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                  (this.tEdit_EmployeeCode_St.DataText.TrimEnd().PadLeft(4, '0').CompareTo(this.tEdit_EmployeeCode_Ed.DataText.TrimEnd().PadLeft(4, '0')) > 0))
                {
                    if (this.ChargeEmployee_tComboEditor.SelectedIndex == 0)
                    {
                        message = string.Format(CUSTOMERAGENT_STR, ct_RangeError);
                    }
                    else
                    {
                        message = string.Format(TOTALRAGENT_STR, ct_RangeError);
                    }
                    errControl = this.tEdit_EmployeeCode_St;
                    status = false;
                }
                // �n��
                else if ((tNedit_SalesAreaCode_St.DataText.Trim() != string.Empty)
                    && (tNedit_SalesAreaCode_Ed.DataText.Trim() != string.Empty)
                    && (this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt()))
                {
                    message = string.Format(AREA_STR, ct_RangeError);
                    errControl = this.tNedit_SalesAreaCode_St;
                    status = false;
                }

                // ���Ӑ�R�[�h
                else if ((tNedit_CustomerCode_St.DataText.Trim() != string.Empty)
                    && (tNedit_CustomerCode_Ed.DataText.Trim() != string.Empty)
                    && (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
                {
                    message = string.Format(CUSTOMERT_STR, ct_RangeError);
                    errControl = this.tNedit_CustomerCode_St;
                    status = false;
                }

                // ���s��
                else if (CallCheckDate(out cdrResult, ref IssueDay_tDateEdit) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                            {
                                message = string.Format(PRINTDAY_STR, ct_InputError);
                                errControl = this.IssueDay_tDateEdit;
                            }
                            break;
                        case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                            {
                                message = string.Format(PRINTDAY_STR, ct_NoInput);
                                errControl = this.IssueDay_tDateEdit;
                            }
                            break;
                    }
                    status = false;
                }

                // ���_�`�F�b�N
                if (this.Main_ExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible)
                {
                    bool blnCheck = false;

                    foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_Tree.Nodes)
                    {
                        if (utn.CheckedState == CheckState.Checked)
                        {
                            blnCheck = true;
                            break;
                        }
                    }

                    if (!blnCheck)
                    {
                        message = MSG_SECTIONCHECKONE_STR;
                        errControl = this.Section_Tree;
                        return result;
                    }
                }

                // �������^�C�v
                //---UPD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                //if (this.Pattern_tComboEditor.SelectedItem.DataValue.ToString().Equals(string.Empty))
                if (this.Pattern_tComboEditor.Items.Count == 0 && this._callMode != START_MODE_DEFAULT_LIST)
                //---UPD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                {
                    message = MSG_BILLTYPENOINPUT_STR;
                    errControl = this.Pattern_tComboEditor;
                    return result;
                }
            }
            catch(Exception ex)
            {
                message = ex.ToString();
                return false;
            }

            return status;
        }

        /// <summary>
        /// �������z���擾
        /// </summary>
        /// <param name="displayMode">���o���ʕ\�����[�h[0:���ʕ\��,1:���ʔ�\��]</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note        : �������z���̌������̒��o���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchDemandData(int displayMode, out string msg, bool syncFlg)
        {
            string errDspMsg = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = string.Empty;

            // ���o���ʃ^�u���\���ɂ���
            Infragistics.Win.UltraWinTabControl.UltraTab tab =
                this.Main_TabControl.Tabs[TABCONTROL_EXTRADATASCREEN_KEY];
            if (tab != null) { tab.Visible = false; }

            // ���o���_�C�A���O�쐬
            SFCMN00299CA pd = new SFCMN00299CA();
            pd.Title = MSG_OUTPUTTINGTITLE_STR;
            pd.Message = MSG_OUTPUTTING_STR;
            pd.DispCancelButton = false;

            pd.Show(this._topForm);

            try
            {
                string pgName = string.Empty;
                switch (_callMode)
                {
                    case START_MODE_DEFAULT_LIST:
                        pgName = MSG_LISTTITLE_STR;
                        break;
                    case START_MODE_DEFAULT_DEMAND:
                        pgName = MSG_BILLTITLE_STR;
                        break;
                    default:
                        break;
                }

                // 2:���,1:PDF
                int operationCode = 2;
                if (_printInfo != null)
                {
                    operationCode = (_printInfo.printmode == 2) ? 1 : 2;
                }
                // 3:�d�q���듯��
                if (syncFlg)
                {
                    operationCode = OPERATIONCODE;
                }
                OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
                operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, ASSID_SFANL07200U, pgName, string.Empty, operationCode, 0, MSG_OUTPUTSTART_STR, string.Empty);

                // �f�[�^���o����
                status = this.mDemandEBooksPrintAcs.SearchDemandList(this._extraInfo_DemandTotal, out msg, out errDspMsg);

                operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, ASSID_SFANL07200U, pgName, string.Empty, operationCode, 0, MSG_OUTPUTEND_STR, string.Empty);

                // ��������ݒ�̒��[�ʏo�͏����Ńt�B���^��������
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    this.ChangePrintType();

                    // �t�B���^�����������ʁA�Y�������Ȃ��̏ꍇ�X�e�[�^�X��ύX����
                    if (this.mDemandEBooksPrintAcs.CustDmdPrcDataView.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            if (tab != null)
                            {
                                tab.Visible = true;

                                if (displayMode == 0)
                                {
                                    this.Main_TabControl.Focus();
                                    this.Main_TabControl.SelectedTab = tab;
                                    this.UnSelect_Button.Focus();
                                }
                                this.DEMANDLISTVIEW.Refresh();
                                this.ColumnPerformAutoResize();
                                this.CalculationTotalViewRow();
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            msg = MSG_NODATA_STR;
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                pd.Close();
                if (String.IsNullOrEmpty(errDspMsg) == false)
                {
                    MessageBox.Show(errDspMsg, NOINPUTLIST_STR, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return status;
        }

        /// <summary>
        /// ����o�͋敪�R���{�����ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note        : ����o�͋敪�R���{�{�b�N�X�̏����ݒ���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void InitialSettingOutCombo(TComboEditor control)
        {
            control.Items.Clear();
            for (int i = 0; i < outputCdNames.Length; i++)
            {
                control.Items.Add(i, outputCdNames[i]);
            }
            control.MaxDropDownItems = control.Items.Count;
        }

        /// <summary>
        /// ���t���̓`�F�b�N����
        /// </summary>
        /// <param name="control">�`�F�b�N�ΏۃR���g���[��</param>
        /// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
        /// <remarks>
        /// <br>Note        : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private bool InputDateEditCheack(TDateEdit control)
        {
            // ���t�𐔒l�^�Ŏ擾
            int date = control.GetLongDate();
            int yy = date / 10000;
            int mm = date / 100 % 100;
            int dd = date % 100;

            // ���t�����̓`�F�b�N
            if (date == 0) return false;

            // �V�X�e���T�|�[�g�`�F�b�N
            if (yy < 1900) return false;

            // �N�E���E���ʓ��̓`�F�b�N
            switch (control.DateFormat)
            {
                // �N�E���E���\����
                case emDateFormat.dfG2Y2M2D:
                case emDateFormat.df4Y2M2D:
                case emDateFormat.df2Y2M2D:
                    if (yy == 0 || mm == 0 || dd == 0) return false;
                    break;
                // �N�E��    �\����
                case emDateFormat.dfG2Y2M:
                case emDateFormat.df4Y2M:
                case emDateFormat.df2Y2M:
                    if (yy == 0 || mm == 0) return false;
                    break;
                // �N        �\����
                case emDateFormat.dfG2Y:
                case emDateFormat.df4Y:
                case emDateFormat.df2Y:
                    if (yy == 0) return false;
                    break;
                // ���E���@�@�\����
                case emDateFormat.df2M2D:
                    if (mm == 0 || dd == 0) return false;
                    break;
                // ��        �\����
                case emDateFormat.df2M:
                    if (mm == 0) return false;
                    break;
                // ��        �\����
                case emDateFormat.df2D:
                    if (dd == 0) return false;
                    break;
            }

            // �P�����t�Ó����`�F�b�N
            if (TDateTime.IsAvailableDate(control.GetDateTime()) == false) return false;

            return true;
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdResult">����</param>
        /// <param name="targetDateEdit">���t</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : ���t�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private bool CallCheckDate(out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit)
        {
            cdResult = _dateGetAcs.CheckDate(ref targetDateEdit, false);
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// �J�����񕝒���
        /// </summary>
        /// <remarks>
        /// <br>Note        : �J�����̗񕝂𒲐����܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void ColumnPerformAutoResize()
        {
            if (AutoFillToGridColumn_CheckEditor.Checked == false)
            {
                for (int i = 0; i < this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns.Count; i++)
                {
                    this.DEMANDLISTVIEW.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
                }
            }
        }

        /// <summary>
        /// �\���s���v�v�Z����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �\������Ă���Row�̍��v���v�Z���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void CalculationTotalViewRow()
        {
            try
            {
                Int32 rpSlipCnt = 0;
                Int64 totalLastDmd = 0;
                Int64 totalDeposit = 0;
                Int64 totalSales = 0;
                Int64 totalTax = 0;
                Int64 totalDmd = 0;

                Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                    this.DEMANDLISTVIEW.Rows.GetFilteredInNonGroupByRows();
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
                {
                    if (((Boolean)_row.Cells[DemandEBooksPrintAcs.CT_CsDmd_DataType].Value))
                    {
                        totalLastDmd += (Int64)_row.Cells[DemandEBooksPrintAcs.CT_CsDmd_DemandBalance].Value;

                        totalDeposit += (Int64)_row.Cells[DemandEBooksPrintAcs.CT_CsDmd_ThisTimeDmdNrml].Value;
                        totalSales += (Int64)_row.Cells[DemandEBooksPrintAcs.CT_CsDmd_OfsThisTimeSales].Value;
                        totalTax += (Int64)_row.Cells[DemandEBooksPrintAcs.CT_CsDmd_OfsThisSalesTax].Value;
                        totalDmd += (Int64)_row.Cells[DemandEBooksPrintAcs.CT_CsDmd_AfCalDemandPrice].Value;
                    }
                }

                this.RpSlipCount_tNedit.SetInt(rpSlipCnt);
                this.TotalLastDmd_tNedit.SetValue(totalLastDmd);
                this.TotalDeposit_tNedit.SetValue(totalDeposit);

                // ���z�\�����@
                if (mDemandEBooksPrintAcs.AllDefSetData != null && mDemandEBooksPrintAcs.AllDefSetData.TotalAmountDispWayCd == 0)
                {
                    // �Ŕ���
                    this.TotalSales_tNedit.SetValue(totalSales);
                    this.TotalTax_tNedit.SetValue(totalTax);
                }
                else
                {
                    // �ō���
                    Int64 totalSalesInConsTax = totalSales + totalTax;
                    this.TotalSales_tNedit.SetValue(totalSalesInConsTax);
                    this.TotalTax_tNedit.Text = "(" + totalTax.ToString("#,##0") + ")";
                }

                this.TotalDmd_tNedit.SetValue(totalDmd);
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �m�[�h�A�C�e���擾
        /// </summary>
        /// <param name="nodeKey">�m�[�h</param>
        /// <remarks>
        /// <br>Note        : �m�[�hKEY���Item���擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private PrintInfoItem NodeKeyToItem(string nodeKey)
        {
            PrintInfoItem item = new PrintInfoItem();

            try
            {
                if (nodeKey.Length > 0 && nodeKey != null)
                {
                    // �m�[�h�ɖ��߂�KEY�iGuid)��Guid�^�ɕϊ�����
                    GuidConverter gc = new GuidConverter();
                    Guid wId = (Guid)gc.ConvertFromString(nodeKey);

                    if (this._printHistoryList.ContainsKey(wId))
                    {
                        item = (PrintInfoItem)this._printHistoryList[wId];
                    }
                    else
                    {
                        item = null;
                    }
                }
                else
                {
                    item = null;
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return item;
        }

        /// <summary>
        /// �ŏ�ʃt�H�[���擾
        /// </summary>
        /// <remarks>
        /// <br>Note		: �ŏ�ʃt�H�[���擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void GetTopForm()
        {
            // �ŏ�ʂ̐e�R���g���[�����擾����
            Control parent = this.Parent;

            while (parent != null)
            {
                if (parent.Parent == null) break;

                parent = parent.Parent;
            }

            if (parent != null)
            {
                if (parent is Form)
                {
                    this._topForm = (Form)parent;
                    this._topForm.SizeChanged += new EventHandler(TopForm_SizeChanged);
                }
            }
        }

        /// <summary>
        /// �g�b�v�t�H�[���T�C�Y�ύX�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopForm_SizeChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// �G�N�X�v���[���[�o�[�W�J��Ԓ���
        /// </summary>
        private void AdjustExplorerBarExpand()
        {
            if (this._topForm == null) return;
        }

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
            DialogResult result = TMsgDisp.Show(form, iLevel, THIS_ASSEMBLYID, iMsg, iSt, iButton, iDefButton);
            return result;
        }
        #endregion

        #region ���@�o�͑Ώۋ��_�͈̔͂̏����ݒ�

        /// <summary>
        /// �o�͑Ώۋ��_�͈̔͂��w�肷��R���g���[���̏����ݒ���s���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note        : �������n�t���[���Ή�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void InitSectionRange()
        {
            #region <Guard Phrase/>

            if (this.Section_Tree.Nodes.Count.Equals(0)) return;

            #endregion  // <Guard Phrase/>

            SortedList<string, string> sortedSectionList = new SortedList<string, string>();
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode sectionNode in this.Section_Tree.Nodes)
            {
                if (sectionNode.CheckedState.Equals(CheckState.Checked))
                {
                    sortedSectionList.Add(sectionNode.Key, sectionNode.Text);
                }
            }
            if (sortedSectionList.Count.Equals(0))
            {
                // �J�n���_�R�[�h�̏����l
                this.tEdit_SectionCode_St.Text = string.Empty;
                this.startRangeNameUltraTextEditor.Text = DEFAULT_START_SECTION_NAME;

                // �I�����_�R�[�h�̏����l
                this.tEdit_SectionCode_Ed.Text = string.Empty;
                this.endRangeNameUltraTextEditor.Text = DEFAULT_END_SECTION_NAME;
            }
            else
            {
                // �J�n���_�R�[�h�̏����l
                this.tEdit_SectionCode_St.Text = sortedSectionList.Keys[0].Trim();
                this.startRangeNameUltraTextEditor.Text = GetSectionName(sortedSectionList.Keys[0]);
                // �S�Зp�̕␳
                if (sortedSectionList.Keys[0].Trim().Equals(ALL_SECTION_CODE))
                {
                    this.tEdit_SectionCode_St.Text = string.Empty;
                    this.startRangeNameUltraTextEditor.Text = DEFAULT_START_SECTION_NAME;
                }

                // �I�����_�R�[�h�̏����l
                this.tEdit_SectionCode_Ed.Text = sortedSectionList.Keys[sortedSectionList.Count - 1].Trim();
                this.endRangeNameUltraTextEditor.Text = GetSectionName(sortedSectionList.Keys[sortedSectionList.Count - 1]);
                // �S�Зp�̕␳
                if (sortedSectionList.Keys[sortedSectionList.Count - 1].Trim().Equals(ALL_SECTION_CODE))
                {
                    this.tEdit_SectionCode_Ed.Text = string.Empty;
                    this.endRangeNameUltraTextEditor.Text = DEFAULT_END_SECTION_NAME;
                }
            }
        }

        /// <summary>
        /// ���_���̂��擾���܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : �������n�t���[���Ή�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            try
            {
                SecInfoSet secInfoSet = (SecInfoSet)this.mDemandEBooksPrintAcs.SectionTable[sectionCode.PadRight(6)];
                return secInfoSet.SectionGuideNm;
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion  // ���@�o�͑Ώۋ��_�͈̔͂̏����ݒ�

        #region ���o�͑Ώۋ��_�͈̔͂����_�c���[�ɓW�J

        // �S�Ћ��_�R�[�h
        private const string ALL_SECTION_CODE = "00";
        private const string ALL_SECTION_NAME = "�S��";
        private const string SECTION_CODE_FORMAT = "00";

        // ���_�R�[�h�͈̔�
        private const string DEFAULT_START_SECTION_NAME = "�ŏ�����";
        private const string DEFAULT_END_SECTION_NAME = "�Ō�܂�";
        private const int MIN_SECTION_CODE = 1;
        private const int MAX_SECTION_CODE = 99;

        /// <summary>
        /// �J�n���_�R�[�h�̃e�L�X�g�{�b�N�X��Leave�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tEdit_SectionCode_St_Leave(object sender, EventArgs e)
        {
            try
            {
                SetSectionRangeUI(this.tEdit_SectionCode_St, this.startRangeNameUltraTextEditor, DEFAULT_START_SECTION_NAME);

                if (_currentResultCode.Equals(ResultCode.StartSectionCodeHasError))
                {
                    this.tEdit_SectionCode_St.Focus();
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �I�����_�R�[�h�̃e�L�X�g�{�b�N�X��Leave�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tEdit_SectionCode_Ed_Leave(object sender, EventArgs e)
        {
            try
            {
                SetSectionRangeUI(this.tEdit_SectionCode_Ed, this.endRangeNameUltraTextEditor, DEFAULT_END_SECTION_NAME);

                // �t�H�[�J�X�J��
                if (_currentResultCode.Equals(ResultCode.StartSectionCodeHasError))
                {
                    _currentResultCode = ResultCode.Normal;
                    this.tEdit_SectionCode_St.Focus();
                }
                else
                {
                    this.AddUpDate_tDateEdit.Focus();
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ���_�͈̔͂��w�肷��UI��ݒ肵�܂��B
        /// </summary>
        /// <param name="sectionCodeUI">���_�R�[�hUI</param>
        /// <param name="sectionNameUI">���_����UI</param>
        /// <param name="defaultText">UI�ɉ������e�L�X�g</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���쌠���ɉ������{�^������̑Ή�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void SetSectionRangeUI(
            Broadleaf.Library.Windows.Forms.TNedit sectionCodeUI,
            Infragistics.Win.UltraWinEditors.UltraTextEditor sectionNameUI,
            string defaultText
        )
        {
            try
            {
                // �ŏ�����^�Ō�܂�
                if (string.IsNullOrEmpty(sectionCodeUI.Text.Trim()))
                {
                    sectionNameUI.Text = defaultText;
                    return;
                }

                // �S��
                if (int.Parse(sectionCodeUI.Text.Trim()).Equals(0))
                {
                    // �J�n
                    this.tEdit_SectionCode_St.Text = int.Parse(ALL_SECTION_CODE).ToString(SECTION_CODE_FORMAT);
                    this.startRangeNameUltraTextEditor.Text = ALL_SECTION_NAME;

                    // �I��
                    this.tEdit_SectionCode_Ed.Text = int.Parse(ALL_SECTION_CODE).ToString(SECTION_CODE_FORMAT);
                    this.endRangeNameUltraTextEditor.Text = ALL_SECTION_NAME;

                    return;
                }

                // �C��
                string sectionCode = int.Parse(sectionCodeUI.Text.Trim()).ToString(SECTION_CODE_FORMAT);
                sectionCodeUI.Text = sectionCode;
                sectionNameUI.Text = GetSectionName(sectionCode);
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ���_��I������c���[�̃m�[�h�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns><c>sectionCode.PadRight(6)</c></returns>
        private static string GetSectionTreeNodeKey(string sectionCode)
        {
            int sectionCodeNumber = int.Parse(sectionCode);
            if (sectionCodeNumber.Equals(0))
            {
                return sectionCode.Trim();
            }
            return sectionCode.PadRight(6);
        }

        /// <summary>
        /// ���ʃR�[�h�񋓑�
        /// </summary>
        private enum ResultCode : int
        {
            /// <summary>����</summary>
            Normal,
            /// <summary>�G���[</summary>
            Error,
            /// <summary>�J�n���_�R�[�h�ɃG���[</summary>
            StartSectionCodeHasError
        }

        /// <summary>���݂̌��ʃR�[�h</summary>
        private ResultCode _currentResultCode;

        /// <summary>
        /// ���_�c���[�̃m�[�h���`�F�b�N��Ԃɂ��܂��B
        /// </summary>
        /// <param name="startSectionCode">�J�n���_�R�[�h</param>
        /// <param name="endSectionCode">�I�����_�R�[�h</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �������n�t���[���Ή�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        /// <returns>���ʃR�[�h�i<c>0</c>:����j</returns>
        private int CheckSectionTreeNode(
            string startSectionCode,
            string endSectionCode
        )
        {
            #region �J�n���_�R�[�h�l

            int startCode = MIN_SECTION_CODE;
            if (!string.IsNullOrEmpty(startSectionCode))
            {
                startCode = int.Parse(startSectionCode);
                if (startCode < 0) startCode = MIN_SECTION_CODE;
            }
            else
            {
                if ((startSectionCode == null) || (startSectionCode.Trim() == ""))
                {
                    startCode = 0;
                }
            }

            #endregion  // �J�n���_�R�[�h�l

            #region �I�����_�R�[�h�l

            int endCode = MAX_SECTION_CODE;
            if (!string.IsNullOrEmpty(endSectionCode))
            {
                endCode = int.Parse(endSectionCode);
                if (endCode > MAX_SECTION_CODE) endCode = MAX_SECTION_CODE;
            }
            else
            {
                if ((endSectionCode == null) || (endSectionCode.Trim() == ""))
                {
                    endCode = 99;
                }
            }

            #endregion  // �I�����_�R�[�h�l

            // �J�n���_�R�[�h���I�����_�R�[�h���傫�Ȓl
            if (startCode > endCode)
            {
                const string MSG = MSG_SECTIONRANGEERR_STR;  // LITERAL:
                StatusBarInfoPrinted(this, new PrintStatusBarEventArgs(MSG));
                return (int)ResultCode.StartSectionCodeHasError;
            }
            else
            {
                StatusBarInfoPrinted(this, new PrintStatusBarEventArgs());
            }

            #region �����I�ɑS���_�𖢑I���ɂ���

            for (int i = 0; i < this.Section_Tree.Nodes.Count; i++)
            {
                // �����I�ɖ��I���ɂ���
                if (this.Section_Tree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                {
                    this.Section_Tree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                }
            }

            #endregion  // �����I�ɑS���_�𖢑I���ɂ���

            if (((string.IsNullOrEmpty(startSectionCode)) || (int.Parse(startSectionCode) == 0)) &&
                ((string.IsNullOrEmpty(endSectionCode)) || (int.Parse(endSectionCode) == 0)))
            {
                // �S�БI��
                this.Section_Tree.Nodes[GetSectionTreeNodeKey(ALL_SECTION_CODE)].CheckedState = CheckState.Checked;
            }
            else
            {
                if ((string.IsNullOrEmpty(startSectionCode)) || (int.Parse(startSectionCode) == 0))
                {
                    startCode = MIN_SECTION_CODE;
                }
                else
                {
                    startCode = int.Parse(startSectionCode);
                }
                if ((string.IsNullOrEmpty(endSectionCode)) || (int.Parse(endSectionCode) == 0))
                {
                    endCode = MAX_SECTION_CODE;
                }
                else
                {
                    endCode = int.Parse(endSectionCode);
                }

                for (int i = 0; i < this.Section_Tree.Nodes.Count; i++)
                {
                    // �����I�ɖ��I���ɂ���
                    if (this.Section_Tree.Nodes[i].CheckedState.Equals(System.Windows.Forms.CheckState.Checked))
                    {
                        this.Section_Tree.Nodes[i].CheckedState = System.Windows.Forms.CheckState.Unchecked;
                    }

                    // �J�n���_�R�[�h�l�ƏI�����_�R�[�h�l�͈͓̔��Ȃ�A�I������i�S�Ўw��̏ꍇ�A�S�Ђ�I������j
                    int sectionCode = int.Parse(this.Section_Tree.Nodes[i].Key.Trim());
                    if ((startCode <= sectionCode) && (sectionCode <= endCode))
                    {
                        if (!sectionCode.Equals(int.Parse(ALL_SECTION_CODE)))
                        {
                            string key = GetSectionTreeNodeKey(sectionCode.ToString(SECTION_CODE_FORMAT));
                            if (!string.IsNullOrEmpty(GetSectionName(key)))
                            {
                                this.Section_Tree.Nodes[key].CheckedState = System.Windows.Forms.CheckState.Checked;
                            }
                        }
                        else
                        {
                            this.Section_Tree.Nodes[ALL_SECTION_CODE].CheckedState = System.Windows.Forms.CheckState.Checked;
                        }
                    }
                }
            }

            return (int)ResultCode.Normal;
        }

        #endregion  // ���o�͑Ώۋ��_�͈̔͂����_�c���[�ɓW�J

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
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MAKAU03002UA_Load(object sender, System.EventArgs e)
        {
            try
            {
                // �ŏ�ʃt�H�[���擾
                this.GetTopForm();

                // �����l�ݒ�
                this.tComboEditor_Pattern.SelectedIndex = 0;
                this.tLebal_Example.Text = PATTERN1_EMP;
                this.tComboEditor_OutputTarget.SelectedIndex = 0; ;
                this.tComboEditor_PrintTarget.SelectedIndex = 0;

                // �ďo���[�h�ɂ���\�����ڂ�ݒ�
                this.Main_ExplorerBar.Groups[EXPLORERBAR_HISTORYLIST].Visible = true;

                Initial_Timer.Enabled = true;
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        #region �� MAKAU03002UA_FormClosing Event
        /// <summary>
        /// MAKAU03002UA_FormClosing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[������鎞�ɔ�������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void MAKAU03002UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �t�h���͕ۑ��R���|�[�l���g����̂��ߒǉ�
        }
        #endregion

        /// <summary>
        /// �����^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            try
            {
                Initial_Timer.Enabled = false;

                // �A�C�R���ݒ�
                this.Select_Button.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.PRINTOUT];
                this.UnSelect_Button.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.NOTPRINTOUT];

                // �����ݒ�f�[�^�Ǎ�
                int status = this.InitalDataRead();
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }

                // ���_�I�v�V�����L���`�F�b�N
                if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0)
                {
                    this._isOptSection = true;
                }
                else
                {
                    this._isOptSection = false;
                    this._demandSectionCode = DemandEBooksPrintAcs.CT_AllSectionCode;
                }

                mDemandEBooksPrintAcs.SectionOption = this._isOptSection;
                mDemandEBooksPrintAcs.OwnSectionCd = this._loginEmployee.BelongSectionCode;

                // ���_���ݒ�
                if (this._isOptSection)
                {
                    // �����ݒ苒�_�擾
                    string billsettingSecCode;
                    mDemandEBooksPrintAcs.GetOwnSeCtrlCode(_loginEmployee.BelongSectionCode, SecInfoAcs.CtrlFuncCode.BillSettingSecCd, out billsettingSecCode);
                    this._demandSectionCode = billsettingSecCode;
                    //// �{�Ћ@�\�L��
                    this._isMainOfficeFunc = true;

                    if (this._isMainOfficeFunc)
                    {
                        this.Main_ExplorerBar.Groups[EXPLORERBAR_SECTIONLIST].Visible = true;
                        this.SettingSectonListForm();

                        // �����ݒ苒�_�Ƀf�t�H���g�`�F�b�N�H
                        if (this.mDemandEBooksPrintAcs.SectionTable.ContainsKey(this._demandSectionCode))
                        {
                            this.Section_Tree.Nodes[this._demandSectionCode].CheckedState = System.Windows.Forms.CheckState.Checked;
                        }
                    }
                }

                // ���_�͈͎w���������
                InitSectionRange();

                // �h�b�N�}�l�[�W���[�����ݒ�
                if (this._isOptSection)
                {
                    this.Main_DockManager.ControlPanes[DOCK_PANE0_KEY].Text = "���_�ݒ�E���[����";
                }
                else
                {
                    this.Main_DockManager.ControlPanes[DOCK_PANE0_KEY].Text = "���[����";
                }

                // PDF�������ݒ�
                this.SettingRecentPdfList();

                // �o�͋敪�R���|�{�b�N�X�ݒ�
                this.InitialSettingOutCombo(this.OutPutPriceCond_tComboEditor);

                // ��ʏ������ݒ�
                this.InitialScreenSetting();

                // �O���b�h�̃f�[�^�\�[�X���A����������A�N�Z�X�N���X�̃f�[�^�r���[�ɐݒ肷��B
                DEMANDLISTVIEW.DataSource = mDemandEBooksPrintAcs.CustDmdPrcDataView;

                // �t�H�[�J�X�����ݒ�
                this.AddUpDate_tDateEdit.Focus();
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �t�@�C�����p�^�[���ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : �t�@�C�����p�^�[���ύX�C�x���g���������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2022/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br>  
        /// </remarks>
        private void tComboEditor_Pattern_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (tComboEditor_Pattern.SelectedIndex == 0)
                {
                    tLebal_Example.Text = PATTERN1_EMP;
                }
                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                else if (tComboEditor_Pattern.SelectedIndex == 2)
                {
                    tLebal_Example.Text = PATTERN3_EMP;
                }
                //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                else
                {
                    tLebal_Example.Text = PATTERN2_EMP;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �����ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �����̒l���ύX���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void AddUpDate_tDateEdit_ValueChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (!this._eventDoFlag) return;
                if (this._eventDateChange) return;

                this._eventDateChange = true;

                try
                {
                    int dd = this.AddUpDate_tDateEdit.GetDateDay();

                    // �o�͒��[�N���L�����`�F�b�N
                    if ((dd <= 0) || (dd >= 32) || (!InputDateEditCheack(this.AddUpDate_tDateEdit)))
                    {
                        this.AddUpDate_tDateEdit.Clear();
                        return;
                    }

                    int yy = this.AddUpDate_tDateEdit.GetDateYear();
                    int mm = this.AddUpDate_tDateEdit.GetDateMonth();

                    // 28���ȍ~�͒����𖖓��Ƃ���
                    if (dd >= 28)
                    {
                        dd = TDateTime.GetLastDate(yy, mm);
                    }
                    else
                    {
                    }

                    int date = yy * 10000 + mm * 100 + dd;
                    this.AddUpDate_tDateEdit.SetLongDate(date);

                }
                finally
                {
                    this._eventDateChange = false;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �o�͏��R���{�I��ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �o�͏��R���{�I��ύX�C�x���g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void PrintOder_tComboEditor_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            try
            {
                int printOder = Convert.ToInt32(PrintOder_tComboEditor.SelectedItem.DataValue);
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ���_�I���`�F�b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : checkedState�v���p�e�B���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Section_Tree_AfterCheck(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            try
            {
                if (this._nodeCheckEventDo) return;

                // �C�x���g���t���OON
                this._nodeCheckEventDo = true;

                try
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode utnAll =
                      this.Section_Tree.GetNodeByKey(DemandEBooksPrintAcs.CT_AllSectionCode);

                    // �h�S�Ёh�w�肳�ꂽ
                    if (e.TreeNode.Key.ToString().Equals(DemandEBooksPrintAcs.CT_AllSectionCode))
                    {
                        // �I��
                        if (utnAll.CheckedState == CheckState.Checked)
                        {
                            // ���̑��̍��ڂ̃`�F�b�N���͂���
                            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode utn in this.Section_Tree.Nodes)
                            {
                                if (utn.Key.Equals(DemandEBooksPrintAcs.CT_AllSectionCode) == false)
                                {
                                    utn.CheckedState = CheckState.Unchecked;
                                }
                            }
                        }
                    }
                    // ���̑����_
                    else
                    {
                        if (utnAll.CheckedState == CheckState.Checked)
                        {
                            utnAll.CheckedState = CheckState.Unchecked;

                        }
                    }
                }
                finally
                {
                    e.TreeNode.Selected = true;
                    this._nodeCheckEventDo = false;
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �^�u�R���g���[���A�N�e�B�u�^�u�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : Active��Tab���ύX���ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Main_TabControl_ActiveTabChanged(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e)
        {
            try
            {
                switch (e.Tab.Key)
                {
                    case TABCONTROL_EXTRAINFOSCREEN_KEY:
                        {
                            if (!this.Main_DockManager.ControlPanes[0].Pinned)
                                this.Main_DockManager.ControlPanes[0].Pin();
                            break;
                        }
                    case TABCONTROL_EXTRADATASCREEN_KEY:
                        {
                            if (this.Main_DockManager.ControlPanes[0].Pinned)
                                this.Main_DockManager.ControlPanes[0].Unpin();

                            if (!this.Main_DockManager.ControlPanes[0].Pinned && this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null)
                                this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);

                            break;
                        }
                }
                ChangeTab(this, e);
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ��T�C�Y�`�F�b�N�{�b�N�X�`�F�b�N�`�F���W�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : ��T�C�Y�`�F�b�N�{�b�N�X�̃`�F�b�N��Ԃ̕ύX�C�x���g�������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void AutoFillToGridColumn_CheckEditor_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (this.AutoFillToGridColumn_CheckEditor.Checked)
                {
                    // �񕝂��I�[�g�ɐݒ�
                    this.DEMANDLISTVIEW.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
                }
                else
                {
                    this.DEMANDLISTVIEW.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
                }

                this.DEMANDLISTVIEW.Refresh();
                this.ColumnPerformAutoResize();
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �O���b�h���C�A�E�g������ �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �f�[�^�\�[�X����R���g���[���Ƀf�[�^�����[�h�����Ƃ��ȂǁA
        ///                   �\�����C�A�E�g�������������Ƃ��ɔ������܂��B </br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void DEMANDLISTVIEW_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            try
            {
                // �O���b�h�ݒ�
                this.SettingGrid();
                // �X�N���[���q���g�̕\���t�B�[���h
                e.Layout.Bands[0].ScrollTipField = DemandEBooksPrintAcs.CT_CsDmd_AddUpSecCode;
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �O���b�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �ꗗ�O���b�h���N���b�N���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void DEMANDLISTVIEW_Click(object sender, System.EventArgs e)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

                // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
                Point point = System.Windows.Forms.Cursor.Position;
                point = targetGrid.PointToClient(point);

                // UIElement���擾����B
                Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
                if (objUIElement == null)
                    return;

                // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
                Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                  (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                if (objHeader != null) return;

                // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
                Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                  (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

                if (objRow != null)
                {
                    // �}�E�X�|�C���^�[������L���Z����ɂ��邩�H
                    Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                      (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
                    if (objCell != null)
                    {
                        // ����t���O��
                        if (objCell.Column.Key == DemandEBooksPrintAcs.CT_CsDmd_PrintFlag)
                        {
                            int uniqueID = (int)objRow.Cells[DemandEBooksPrintAcs.CT_CsDmd_UniqueID].Value;
                            this.mDemandEBooksPrintAcs.SelectedPrintRow(uniqueID);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �O���b�h���ł̃L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�O���b�h�L�[�_�E���C�x���g�������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void DEMANDLISTVIEW_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                switch (e.KeyData)
                {
                    // �X�y�[�X�L�[
                    case Keys.Space:
                        Infragistics.Win.UltraWinGrid.UltraGridRow _row = this.DEMANDLISTVIEW.ActiveRow;

                        if (_row != null)
                        {
                            int uniqueID = (int)_row.Cells[DemandEBooksPrintAcs.CT_CsDmd_UniqueID].Value;
                            this.mDemandEBooksPrintAcs.SelectedPrintRow(uniqueID);
                            e.Handled = true;

                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// �O���b�h�s�t�B���^�[�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̍s�������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void DEMANDLISTVIEW_AfterRowFilterChanged(object sender, Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e)
        {
            // ���v���z�v�Z
            this.CalculationTotalViewRow();
        }

        /// <summary>
        /// �I���E�����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �I���E�����{�^�����N���b�N���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Select_Button_Click(object sender, System.EventArgs e)
        {
            try
            {
                bool selected = false;

                if (sender == UnSelect_Button)
                {
                    selected = false;
                }
                else if (sender == Select_Button)
                {
                    selected = true; ;
                }

                // �t�B���^�[���O�s���擾      
                Infragistics.Win.UltraWinGrid.UltraGridRow[] _rows =
                    this.DEMANDLISTVIEW.Rows.GetFilteredInNonGroupByRows();

                // �\���s�͑��݂��邩�H
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow _row in _rows)
                {
                    int uniqueID = (int)_row.Cells[DemandEBooksPrintAcs.CT_CsDmd_UniqueID].Value;
                    this.mDemandEBooksPrintAcs.SelectedPrintRow(uniqueID, selected);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �s�t�B���^�[�h���b�v�_�E���O�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �s�t�B���^�[�h���b�v�_�E���������O�ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void DEMANDLISTVIEW_BeforeRowFilterDropDown(object sender, Infragistics.Win.UltraWinGrid.BeforeRowFilterDropDownEventArgs e)
        {
            try
            {
                switch (e.Column.Key)
                {
                    case DemandEBooksPrintAcs.CT_CsDmd_PrintFlag:
                        {

                            // �t�B���^�[�h���b�v�_�E������A�uTrue�v�uFalse�v���u�������v�u������Ȃ��v�ɕύX���܂�
                            for (int i = e.ValueList.ValueListItems.Count - 1; i >= 0; i--)
                            {
                                if (e.ValueList.ValueListItems[i].DisplayText.Equals("True"))
                                    e.ValueList.ValueListItems[i].DisplayText = "�������";

                                if (e.ValueList.ValueListItems[i].DisplayText.Equals("False"))
                                    e.ValueList.ValueListItems[i].DisplayText = "������Ȃ�";
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �G�N�X�v���[���[�o�[�O���[�v�k���O�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : UltraExplorerBarGroup���k�������O�ɂɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if (this._explorerBarExpanding) return;

            this._explorerBarExpanding = true;

            try
            {
                e.Cancel = true;
            }
            finally
            {
                this._explorerBarExpanding = false;
            }
        }

        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void Extra_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// �o�͗����c���[MouseMove�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �o�͗����c���[��Ń}�E�X�ړ����ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void History_Tree_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (this.History_Tree != null)
                {
                    Infragistics.Win.UltraWinTree.UltraTree ut = (Infragistics.Win.UltraWinTree.UltraTree)sender;
                    //�}�E�X�|�C���^�̂���A�C�e�����擾
                    Infragistics.Win.UltraWinTree.UltraTreeNode Utn = ut.GetNodeFromPoint(e.X, e.Y);
                    //�|�C���g����Ă���A�C�e�����ς������
                    if (Utn != _lastUltraTreeNode)
                    {
                        // ToolTip��Active�ȏꍇ�AActive����
                        if (History_ToolTip.Active)
                            History_ToolTip.Active = false;
                        if (Utn != null)
                        {
                            // �|�C���g����Ă���m�[�h�̏����R���N�V��������擾
                            PrintInfoItem Itm = new PrintInfoItem();
                            Itm = NodeKeyToItem(Utn.Key);
                            if (Itm != null)
                            {
                                //ToolTip�̃e�L�X�g��ݒ肷��
                                History_ToolTip.SetToolTip(ut, Itm.PrintDetailName + "  ���s�ҁF" + Itm.LoginWorkerName);
                                //ToolTip���ĂуA�N�e�B�u�ɂ���
                                History_ToolTip.Active = true;
                            }
                        }
                        // �|�C���g����Ă���m�[�h���L������
                        _lastUltraTreeNode = Utn;
                    }
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �o�͗����R���e�L�X�g���j���[�A�C�e���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �R���e�L�X�g���j���[�A�C�e�����N���b�N���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this._lastUltraTreeNode != null)
                {
                    PrintInfoItem itm = new PrintInfoItem();
                    itm = NodeKeyToItem(this._lastUltraTreeNode.Key);

                    if (itm != null)
                    {

                        string message = "";
                        if (!mPdfHistoryControl.DeletePrintHistoryList(itm.PrintKey, itm.PdfFileName, out message))
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                            "�����̍폜�Ɏ��s���܂����B\r\n" + message,
                                            -1,
                              MessageBoxButtons.OK,
                              MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �o�͗����R���e�L�X�g���j���[�A�C�e���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �R���e�L�X�g���j���[�A�C�e�����N���b�N���ꂽ�ۂɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this._lastUltraTreeNode != null)
                {
                    PrintInfoItem itm = new PrintInfoItem();
                    itm = NodeKeyToItem(this._lastUltraTreeNode.Key);

                    if (itm != null)
                    {
                        PdfHistoryControlFuncParam param = new PdfHistoryControlFuncParam();
                        param.Keys = new string[] { itm.PrintKey };
                        param.LoginEmployeeCode = this._loginEmployee.EmployeeCode;
                        param.StartDate = DateTime.MinValue;
                        param.EndDate = itm.PrintOutDateTime;

                        string message = string.Empty;
                        if (!this.mPdfHistoryControl.DeletePrintHistoryList(param, out message))
                        {
                            TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "�����̍폜�Ɏ��s���܂����B\r\n" + message,
                                -1,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �o�͗����c���[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �o�͗����c���[�̃m�[�h���N���b�N���ꂽ���ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void History_Tree_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // �E�N���b�N���Ƀm�[�h��I�����ăR���e�L�X�g���j���[��\������
                if (e.Button == MouseButtons.Right)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode wkNode = this.History_Tree.GetNodeFromPoint(e.Location);

                    // �m�[�h���擾�H
                    if (wkNode != null)
                    {
                        wkNode.Selected = true;
                        this.History_Tree.ActiveNode = wkNode;

                        // ���[��ʃm�[�h(�e�O���[�v�m�[�h)�̏ꍇ�̓R���e�L�X�g���j���[��\�����Ȃ�
                        if (wkNode.Level > 0)
                        {
                            // �R���e�L�X�g���j���[�\��
                            this.contextMenu1.Show(this.History_Tree, e.Location);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �o�͗����c���[�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �o�͗����c���[�̃m�[�h���_�u���N���b�N���ꂽ���ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void History_Tree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                PrintInfoItem Itm = new PrintInfoItem();

                // ���_�u���N���b�N�̂ݑΉ�
                if (e.Button != MouseButtons.Left) return;

                // �m�[�h���P�ȏ�A�I�����Ă��邩�H
                if (this.History_Tree.SelectedNodes.Count > 0)
                {
                    // �_�u���N���b�N�ʒu�Ƀm�[�h�����邩�H
                    if (this.History_Tree.GetNodeFromPoint(e.Location) == null) return;

                    // �I�����ꂽ�m�[�h�̏����R���N�V��������擾����
                    Itm = NodeKeyToItem(this.History_Tree.SelectedNodes[0].Key);
                    if (Itm != null)
                    {
                        // �f���Q�[�g�o�^����Ă��邩�H
                        if (SelectedPdfNodeEvent != null)
                        {
                            // �f���Q�[�g����Ă���C�x���g���N������
                            SelectedPdfNodeEvent(Itm.PrintKey, Itm.PrintName, Itm.PdfFileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }
        #endregion

        /// <summary>
        /// ���Ӑ�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note �@�@   : ���Ӑ�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
                int beCustCd = this.tNedit_CustomerCode_St.GetInt();

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
                customerSearchForm.ShowDialog(this);

                if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
                {
                    // �K�C�h�ďo�O�ƈႤ�A�N���A����Ă��Ȃ��ꍇ
                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch(Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ���Ӑ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note �@�@   : ���Ӑ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
                int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();

                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
                customerSearchForm.ShowDialog(this);

                if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
                {
                    // �K�C�h�ďo�O�ƈႤ�A�N���A����Ă��Ȃ��ꍇ
                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note �@�@   : ���Ӑ�I���������C�x���g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            try
            {
                if (customerSearchRet == null) return;

                CustomerInfo customerInfo;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �擾�������Ӑ�R�[�h(�J�n)����ʂɕ\������
                    this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(
                        form,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                        status,
                        MessageBoxButtons.OK);
                    form.TopMost = false;

                    return;
                }
                else
                {
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(
                        form,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "���Ӑ���̎擾�Ɏ��s���܂����B",
                        status,
                        MessageBoxButtons.OK);
                    form.TopMost = false;

                    return;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note �@�@   : ���Ӑ�I���������C�x���g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            try
            {
                if (customerSearchRet == null) return;

                CustomerInfo customerInfo;
                CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �擾�������Ӑ�R�[�h(�I��)����ʂɕ\������
                    this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(
                        form,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                        status,
                        MessageBoxButtons.OK);
                    form.TopMost = false;

                    return;
                }
                else
                {
                    Form form = new Form();
                    form.TopMost = true;
                    TMsgDisp.Show(
                        form,
                        emErrorLevel.ERR_LEVEL_STOPDISP,
                        this.Name,
                        "���Ӑ���̎擾�Ɏ��s���܂����B",
                        status,
                        MessageBoxButtons.OK);
                    form.TopMost = false;

                    return;
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �]�ƈ��R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note �@�@   : �]�ƈ��R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void EmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int status = -1;

                // �K�C�h�N��
                Employee employee = new Employee();
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �]�ƈ��R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note �@�@   : �]�ƈ��R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void EmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int status = -1;

                // �K�C�h�N��
                Employee employee = new Employee();
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(ub_SalesAreaCodeStGuid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@   : �n��i�J�n�j�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void ub_SalesAreaCodeStGuid_Click(object sender, EventArgs e)
        {
            try
            {
                int status = -1;

                // �K�C�h�N��
                UserGdBd userGdBd = new UserGdBd();
                UserGdHd userGdHd = new UserGdHd();
                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tNedit_SalesAreaCode_St.SetInt(userGdBd.GuideCode);

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(ub_SalesAreaCodeEdGuid)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@   : �n��i�I���j�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void ub_SalesAreaCodeEdGuid_Click(object sender, EventArgs e)
        {
            try
            {
                int status = -1;

                // �K�C�h�N��
                UserGdBd userGdBd = new UserGdBd();
                UserGdHd userGdHd = new UserGdHd();
                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tNedit_SalesAreaCode_Ed.SetInt(userGdBd.GuideCode);

                    // ���̃R���g���[���փt�H�[�J�X���ړ�
                    this.SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ���R���[�ďo����
        /// </summary>
        /// <remarks>
        /// <br>Note �@�@  : ���R���[���Ăяo���󎚏������s���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int FreePrintPaper(SFCMN06002C printInfo, string sectionCode, ref List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList, bool syncFlg)
        {
            PreviewPDFPathList.Clear();

            int status = 0;

            // ������p�����[�^
            if (printInfo == null)
            {
                printInfo = new SFCMN06002C();
            }

            // ��ƃR�[�h
            printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���o�����̐ݒ�
            printInfo.jyoken = this._extraInfo_DemandTotal;
            // ���o�����̋��_���P���_�݂̂ɏ���������
            (printInfo.jyoken as ExtrInfo_EBooksDemandTotal).ResultsAddUpSecList = CreateResultsAddUpSecList(sectionCode);

            if (printInfo.printmode == 1 && printInfo.prevkbn == 0)
            {
                for (int i = 0; i < this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint.Count; i++)
                {
                    string nexAddUpSecCode = (string)this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint[i].Row["AddUpSecCode"].ToString().Trim();
                    if (nexAddUpSecCode == sectionCode)
                    {
                        DataTable table = new DataTable();
                        DataView custView = table.DefaultView;
                        table = this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint.Table.Clone();
                        table.ImportRow(this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint[i].Row);
                        custView = new DataView(table);
                        printInfo.rdData = custView;

                        // ���o
                        status = _freePrintController.Extract(ref printInfo);

                        // ���
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            List<string> pdfPathList; // PdfPathList
                            Dictionary<string, Document> docDic; // DocumentByTypeDic

                            // ������s
                            status = _freePrintController.Print(out pdfPathList, out docDic, ref denchoDXIndexCSVEntityList, syncFlg);
                            # region [����㏈��]
                            // �������P�ʂ�PDF�p�X���X�g�ɒǉ�
                            if (pdfPathList != null && pdfPathList.Count > 0)
                            {
                                _billPdfPathList.AddRange(pdfPathList);
                            }

                            if (docDic != null)
                            {
                                // ���񏈗�����PDF�o�͂��āA�t�@�C���������X�g�ɒǉ�
                                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL &&
                                     (printInfo.printmode == 2 || printInfo.printmode == 3) && !syncFlg)
                                {
                                    _previewPdfPathList.AddRange(PMKAU01001PA.PrintPDF(ref printInfo, docDic, null));
                                }
                            }
                            # endregion
                        }
                        _freePrintController.Dispose2();

                    }

                }

            }
            else
            {
                // ����pDataView�ݒ�
                printInfo.rdData = this.mDemandEBooksPrintAcs.CustDmdPrcDataViewPrint;

                // ���o
                status = _freePrintController.Extract(ref printInfo);

                // ���
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    List<string> pdfPathList; // PdfPathList
                    Dictionary<string, Document> docDic; // DocumentByTypeDic

                    // ������s
                    status = _freePrintController.Print(out pdfPathList, out docDic, ref denchoDXIndexCSVEntityList, syncFlg);

                    # region [����㏈��]
                    // �������P�ʂ�PDF�p�X���X�g�ɒǉ�
                    if (pdfPathList != null && pdfPathList.Count > 0)
                    {
                        _billPdfPathList.AddRange(pdfPathList);
                    }

                    if (docDic != null)
                    {
                        // ���񏈗�����PDF�o�͂��āA�t�@�C���������X�g�ɒǉ�
                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL &&
                             (printInfo.printmode == 2 || printInfo.printmode == 3) && !syncFlg)
                        {
                            _previewPdfPathList.AddRange(PMKAU01001PA.PrintPDF(ref printInfo, docDic, null));
                        }
                    }
                    # endregion
                }
                _freePrintController.Dispose2();
            }

            // ������̉��
            if (printInfo != null && printInfo.rdData != null && printInfo.rdData is DataSet)
            {
                (printInfo.rdData as DataSet).Dispose();
            }
            printInfo = null;

            return status;
        }

        /// <summary>
        /// ���_�R�[�h���X�g�����i�P���_�R�[�h�����_�R�[�h�z��ɃZ�b�g�j
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private string[] CreateResultsAddUpSecList(string sectionCode)
        {
            return new string[] { sectionCode };
        }

        /// <summary>
        /// ����p�^�[���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note        : ����p�^�[����Pattern_tComboEditor�ɐݒ肵�܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2022/04/21 ���O</br>
        /// <br>�Ǘ��ԍ�    : 11870080-00 �d�q����2���Ή�</br>  
        /// </remarks>
        private void SetPrintPattern()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            Pattern_tComboEditor.Items.Clear();

            // �p�^�[���擾
            ArrayList dmdPrtPtnList = null;
            status = this.DmdPrtPtnAcsObj.SearchAllPrintKindGroup(out dmdPrtPtnList, LoginInfoAcquisition.EnterpriseCode, DTLBILLTYPE);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        Pattern_tComboEditor.Clear();
                        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                        Dictionary<string, DmdPrtPtnSetInfo> dmdPrtPtnSetInfoDic = null;
                        DmdPrtDeserialize(out dmdPrtPtnSetInfoDic);
                        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                        // �ǂݍ��񂾃C���X�^���X�̂��ꂼ����f�[�^�Z�b�g�ɓW�J
                        foreach (DmdPrtPtn dmdPrtPtn in dmdPrtPtnList)
                        {
                            //---UPD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
                            //if (dmdPrtPtn.LogicalDeleteCode == INITIALLOGICALDELCD)
                            //�o�͉\������XML�����݂��Ȃ��ꍇ�A�S�Ă̐������^�C�v��\������B
                            if (dmdPrtPtnSetInfoDic.Count == 0)
                            {
                                if (dmdPrtPtn.LogicalDeleteCode == INITIALLOGICALDELCD)
                                {
                                    Pattern_tComboEditor.Items.Add(dmdPrtPtn.SlipPrtSetPaperId, dmdPrtPtn.SlipComment);
                                    Pattern_tComboEditor.SelectedIndex = INITIALINDEX;
                                }
                            }
                            else if (dmdPrtPtn.LogicalDeleteCode == INITIALLOGICALDELCD && dmdPrtPtnSetInfoDic.ContainsKey(dmdPrtPtn.SlipPrtSetPaperId))
                            //---UPD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
                            {
                                Pattern_tComboEditor.Items.Add(dmdPrtPtn.SlipPrtSetPaperId, dmdPrtPtn.SlipComment);
                                Pattern_tComboEditor.SelectedIndex = INITIALINDEX;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // �S���ǂݍ��݊����̏ꍇ�́A�������Ȃ�
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                    {
                        Form form = new Form();
                        form.TopMost = true;
                        TMsgDisp.Show(
                            form,                               // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                            THIS_ASSEMBLYID,                    // �A�Z���u���h�c�܂��̓N���X�h�c
                            PROGRAMNAME_STR,                      // �v���O��������
                            SETPRINTPATMETHOD_STR,              // ��������
                            TMsgDisp.OPE_GET,                   // �I�y���[�V����
                            MSG_FAIL_STR,                       // �\�����郁�b�Z�[�W
                            status,                             // �X�e�[�^�X�l
                            this.DmdPrtPtnAcsObj,               // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,               // �\������{�^��
                            MessageBoxDefaultButton.Button1);   // �����\���{�^��
                        form.TopMost = false;

                        break;
                    }
            }
        }

        /// <summary>
        /// �����ꗗ�\�ŋN�����Ă��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�����ꗗ�\�ŋN�����Ă��܂��B<br/>
        /// <c>false</c>:�����ꗗ�\�ŋN�����Ă��܂���B
        /// </returns>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        private bool IsDemandListMode()
        {
            return this._callMode.Equals(START_MODE_DEFAULT_LIST);
        }

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note �@�@   : ���L�[�ł̃t�H�[�J�X�ړ��C�x���g���������܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            try
            {
                _currentResultCode = ResultCode.Normal;

                // ���_��I�����鏈��
                if ((e.PrevCtrl == this.tEdit_SectionCode_St) || (e.PrevCtrl == this.tEdit_SectionCode_Ed))
                {
                    int resultCode = CheckSectionTreeNode(this.tEdit_SectionCode_St.Text.Trim(), this.tEdit_SectionCode_Ed.Text.Trim());

                    if (resultCode.Equals((int)ResultCode.StartSectionCodeHasError))
                    {
                        if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                        {
                            _currentResultCode = ResultCode.StartSectionCodeHasError;
                            this.tEdit_SectionCode_St.Focus();
                            return;
                        }
                        else if (e.PrevCtrl == this.tEdit_SectionCode_St)
                        {
                            // �J�n���_�̓��͂̒i�K�ł͓��̓G���[�𖳎�
                            StatusBarInfoPrinted(this, new PrintStatusBarEventArgs());
                        }
                    }

                    _currentResultCode = ResultCode.Normal;
                    if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
                    {
                        this.AddUpDate_tDateEdit.Focus();
                    }
                    return;
                }

                if (!e.ShiftKey)
                {
                    // SHIFT�L�[������
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
                        {
                            // �S����(�J�n)���S����(�I��)
                            e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                        }
                        else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                        {
                            // �S����(�I��)���n��(�J�n)
                            e.NextCtrl = this.tNedit_SalesAreaCode_St;
                        }
                        else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                        {
                            // �n��(�J�n)���n��(�I��)
                            e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                        }
                        else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                        {
                            // �n��(�I��)�����Ӑ�(�J�n)
                            e.NextCtrl = this.tNedit_CustomerCode_St;
                        }
                        else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                        {
                            // ���Ӑ�(�J�n)�����Ӑ�(�I��)
                            e.NextCtrl = this.tNedit_CustomerCode_Ed;
                        }
                        else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                        {
                            switch (this._callMode)
                            {
                                case START_MODE_DEFAULT_LIST:           // �����ꗗ�\
                                    {
                                        // ���Ӑ�(�I��)�����|�敪
                                        e.NextCtrl = this.AccRecDivCd_tComboEditor;
                                        break;
                                    }
                                case START_MODE_DEFAULT_DEMAND:          // ������
                                    {
                                        // ���Ӑ�(�I��)���d�q����o�͐ݒ�
                                        e.NextCtrl = this.tComboEditor_OutputTarget;
                                        break;
                                    }
                            }
                        }
                        else if (e.PrevCtrl == this.AccRecDivCd_tComboEditor)
                        {
                            // ���|�敪���o�͑Ώ�
                            e.NextCtrl = this.tComboEditor_PrintTarget;
                        }
                        else if (e.PrevCtrl == this.tComboEditor_PrintTarget)
                        {
                            switch (this._callMode)
                            {
                                case START_MODE_DEFAULT_LIST:           // �����ꗗ�\
                                    {
                                        // �o�͑Ώہ��������
                                        e.NextCtrl = this.CollectRatePrtDiv_tComboEditor;
                                        break;
                                    }
                                case START_MODE_DEFAULT_DEMAND:          // ������
                                    {
                                        // �o�͑Ώہ����s��
                                        e.NextCtrl = this.IssueDay_tDateEdit;
                                        break;
                                    }
                            }
                        }
                        else if (e.PrevCtrl == this.CollectRatePrtDiv_tComboEditor)
                        {
                            // ������󎚁��o�͋��z�敪
                            e.NextCtrl = this.OutPutPriceCond_tComboEditor;
                        }
                        else if (e.PrevCtrl == this.OutPutPriceCond_tComboEditor)
                        {
                            switch (this._callMode)
                            {
                                case START_MODE_DEFAULT_LIST:           // �����ꗗ�\
                                    {
                                        // �o�͋��z�敪���c������
                                        e.NextCtrl = this.BalanceDepositDtl_tComboEditor;
                                        break;
                                    }
                                case START_MODE_DEFAULT_DEMAND:          // ������
                                    {
                                        // �o�͋��z�敪������^�C�v
                                        e.NextCtrl = this.Pattern_tComboEditor;
                                        break;
                                    }
                            }
                        }
                        else if (e.PrevCtrl == this.tComboEditor_OutputTarget)
                        {
                            // �d�q����o�͐ݒ聨����ݒ�
                            e.NextCtrl = this.tComboEditor_PrintTarget;
                        }
                    }
                }
                else
                {
                    // SHIFT�L�[����
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (e.PrevCtrl == this.CollectRatePrtDiv_tComboEditor)
                        {
                            // ������󎚁��d�q����o�͐ݒ�
                            e.NextCtrl = this.tComboEditor_PrintTarget;
                        }
                        if (e.PrevCtrl == this.IssueDay_tDateEdit)
                        {
                            // ���s��������ݒ�
                            e.NextCtrl = this.tComboEditor_PrintTarget;
                        }
                        if (e.PrevCtrl == this.BalanceDepositDtl_tComboEditor)
                        {
                            // �c���������o�͋��z�敪
                            e.NextCtrl = this.OutPutPriceCond_tComboEditor;
                        }
                        if (e.PrevCtrl == this.OutPutPriceCond_tComboEditor)
                        {
                            switch (this._callMode)
                            {
                                case START_MODE_DEFAULT_LIST:           // �����ꗗ�\
                                    {
                                        // �o�͋��z�敪���������
                                        e.NextCtrl = this.CollectRatePrtDiv_tComboEditor;
                                        break;
                                    }
                                case START_MODE_DEFAULT_DEMAND:          // ������
                                    {
                                        // �o�͋��z�敪�����s��
                                        e.NextCtrl = this.IssueDay_tDateEdit;
                                        break;
                                    }
                            }
                        }
                        else if (e.PrevCtrl == this.tComboEditor_PrintTarget)
                        {
                            switch (this._callMode)
                            {
                                case START_MODE_DEFAULT_LIST:           // �����ꗗ�\
                                    {
                                        // �o�͑Ώہ����|�敪
                                        e.NextCtrl = this.AccRecDivCd_tComboEditor;
                                        break;
                                    }
                                case START_MODE_DEFAULT_DEMAND:          // ������
                                    {
                                        // ����ݒ聨�d�q����o�͐ݒ�
                                        e.NextCtrl = this.tComboEditor_OutputTarget;
                                        break;
                                    }
                            }
                        }
                        else if (e.PrevCtrl == this.tComboEditor_OutputTarget)
                        {
                            // �d�q����o�͐ݒ聨���Ӑ�(�I��)
                            e.NextCtrl = this.tNedit_CustomerCode_Ed;
                        }
                        else if (e.PrevCtrl == this.AccRecDivCd_tComboEditor)
                        {
                            // ���|�敪�����Ӑ�(�I��)
                            e.NextCtrl = this.tNedit_CustomerCode_Ed;
                        }
                        else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                        {
                            // ���Ӑ�(�I��)�����Ӑ�(�J�n)
                            e.NextCtrl = this.tNedit_CustomerCode_St;
                        }
                        else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                        {
                            // ���Ӑ�(�J�n)���n��(�I��)
                            e.NextCtrl = this.tNedit_SalesAreaCode_Ed;
                        }
                        else if (e.PrevCtrl == this.tNedit_SalesAreaCode_Ed)
                        {
                            // �n��(�I��)���n��(�J�n)
                            e.NextCtrl = this.tNedit_SalesAreaCode_St;
                        }
                        else if (e.PrevCtrl == this.tNedit_SalesAreaCode_St)
                        {
                            // �n��(�J�n)���S����(�I��)
                            e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                        }
                        else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                        {
                            // �S����(�I��)���S����(�J�n)
                            e.NextCtrl = this.tEdit_EmployeeCode_St;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.StackTrace, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
        }

        # region [����p�ŗ����XML]
        /// <summary>
        /// ����p�ŗ����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����p�ŗ������擾����B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public class TaxRatePrintInfo
        {
            /// <summary>����p�ŗ��ݒ���ŗ��P</summary>
            private string _taxRate1;

            /// <summary>����p�ŗ��ݒ���ŗ��Q</summary>
            private string _taxRate2;

            /// <summary>����p�ŗ��ݒ���ŗ��P</summary>
            public string TaxRate1
            {
                get { return _taxRate1; }
                set { _taxRate1 = value; }
            }

            /// <summary>����p�ŗ��ݒ���ŗ��Q</summary>
            public string TaxRate2
            {
                get { return _taxRate2; }
                set { _taxRate2 = value; }
            }
        }

        # region
        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        /// <returns>�f�V���A���C�Y����</returns>
        /// <remarks>
        /// <br>Note       : �f�V���A���C�Y����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static int Deserialize(out TaxRatePrintInfo taxRatePrintInfo, out string errmsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;

            errmsg = string.Empty;
            taxRatePrintInfo = null;

            // ����p�ŗ����XML�t�@�C�����݂̔��f
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTPRINTXMLFILENAME)))
            {
                try
                {
                    taxRatePrintInfo = UserSettingController.DeserializeUserSetting<TaxRatePrintInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, CTPRINTXMLFILENAME));
                    // �ŗ��ݒ���ŗ��P
                    double dTaxRate1 = -1;
                    Boolean bTaxRate1 = double.TryParse(taxRatePrintInfo.TaxRate1, out dTaxRate1);
                    // �ŗ��ݒ���ŗ��Q
                    double dTaxRate2 = -1;
                    Boolean bTaxRate2 = double.TryParse(taxRatePrintInfo.TaxRate2, out dTaxRate2);

                    // �ŗ����ݒ�̏ꍇ�A
                    if ((taxRatePrintInfo.TaxRate1 == string.Empty) || (taxRatePrintInfo.TaxRate2 == string.Empty) ||
                        // �����ŗ��l�̏ꍇ
                        (taxRatePrintInfo.TaxRate1 == taxRatePrintInfo.TaxRate2) ||
                        // �����ȊO�̏ꍇ�A
                        (!bTaxRate1) || (!bTaxRate2) ||
                        // �ŗ��l��0�ȉ��̏ꍇ
                        (dTaxRate1 <= 0) || (dTaxRate2 <= 0) ||
                        // �ŗ��l��10�ȏ�̏ꍇ
                        (dTaxRate1 >= 10) || (dTaxRate2 >= 10))
                    {
                        errmsg = "�ŗ��ݒ��񂪐������ݒ肳��Ă��܂���B";
                        return status;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    errmsg = "�ŗ��ݒ��񂪐������ݒ肳��Ă��܂���B";
                    return status;
                }
            }
            else
            {
                errmsg = "�ŗ��ݒ���t�@�C��(" + CTPRINTXMLFILENAME + ")�����݂��܂���B";
                return status;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        # endregion
        # endregion
        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
        # region [�o�͉\������]
        /// <summary>
        /// �o�͉\������
        /// </summary>
        public class DmdPrtPtnSetInfo
        {
            /// <summary>���[ID </summary>
            private string _outputFormFileName;
            /// <summary>���[���� </summary>
            private string _displayName;

            /// <summary>
            /// ���[ID
            /// </summary>
            public string OutputFormFileName
            {
                get { return _outputFormFileName; }
                set { _outputFormFileName = value; }
            }

            /// <summary>
            /// ���[����
            /// </summary>
            public string DisplayName
            {
                get { return _displayName; }
                set { _displayName = value; }
            }

        }

        /// <summary>
        /// �o�͉\�������f�V���A���C�Y����
        /// </summary>
        /// <param name="dmdPrtPtnSetInfoDic">�o�͉\������</param>
        /// <returns>�f�V���A���C�Y����</returns>
        /// <remarks>
        /// <br>Note       : �o�͉\�������f�V���A���C�Y����</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2022/04/21</br>
        /// </remarks>
        public static void DmdPrtDeserialize(out Dictionary<string, DmdPrtPtnSetInfo> dmdPrtPtnSetInfoDic)
        {

            dmdPrtPtnSetInfoDic = new Dictionary<string, DmdPrtPtnSetInfo>();

            // �o�͉\������XML�t�@�C�����݂̔��f
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, DMDPRTXMLFILENAME)))
            {
                try
                {
                    DmdPrtPtnSetInfo[] constructions = UserSettingController.DeserializeUserSetting<DmdPrtPtnSetInfo[]>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, DMDPRTXMLFILENAME));
                    // �f�V���A���C�Y����
                    if (constructions != null)
                    {
                        for (int i = 0; i < constructions.Length; i++)
                        {
                            DmdPrtPtnSetInfo dmdPrtPtnSetInfo = (DmdPrtPtnSetInfo)constructions[i];
                            if (!dmdPrtPtnSetInfoDic.ContainsKey(dmdPrtPtnSetInfo.OutputFormFileName))
                                dmdPrtPtnSetInfoDic.Add(dmdPrtPtnSetInfo.OutputFormFileName, dmdPrtPtnSetInfo);
                        }
                    }

                }
                catch
                {

                }
            }
        }
        # endregion

        /// <summary>
        /// UI�ۑ��R���|�[�l���g�����݃C�x���g
        /// </summary>
        /// <param name="targetControls">�R���|�[�l���g</param>
        /// <param name="customizeData">�f�[�^</param>
        /// <remarks>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/04/21</br>
        /// <br>��T�C�Y�̎��������`�F�b�N�{�b�N�X�̏�Ԃ�ۑ�����B</br>
        /// </remarks>
        private void uiMemInput1_CustomizeWrite(Control[] targetControls, out string[] customizeData)
        {
            customizeData = new string[1];
            //�������̎�
            if (this._callMode != START_MODE_DEFAULT_LIST)
            {
                if (this.AutoFillToGridColumn_CheckEditor.Checked)
                {
                    customizeData[0] = CT_TRUE;
                }
                else
                {
                    customizeData[0] = CT_FALSE;
                }
            }
            else
            {
                //�������ȊO�̎��f�t�H���g�l�F�`�F�b�N�I��
                customizeData[0] = CT_TRUE;
            }
        }

        /// <summary>
        /// UI�ۑ��R���|�[�l���g�Ǎ��݃C�x���g
        /// </summary>
        /// <param name="targetControls">�R���|�[�l���g</param>
        /// <param name="customizeData">�f�[�^</param>
        /// <remarks>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/04/21</br>
        /// <br>��T�C�Y�̎��������`�F�b�N�{�b�N�X�̏�Ԃ𕜌�����B</br>
        /// </remarks>
        private void uiMemInput1_CustomizeRead(Control[] targetControls, string[] customizeData)
        {
            //�������̎�
            if (this._callMode != START_MODE_DEFAULT_LIST && customizeData.Length > 0)
            {
                if (customizeData[0] == CT_TRUE)
                {
                    this.AutoFillToGridColumn_CheckEditor.Checked = true;
                }
                else
                {
                    this.AutoFillToGridColumn_CheckEditor.Checked = false;
                }
            }
        }

    }
    //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
    #region ���X�e�[�^�X�o�[�֏o��

    /// <summary>
    /// �X�e�[�^�X�o�[�ɏo�͂���C�x���g�p�����[�^�N���X
    /// </summary>
    public sealed class PrintStatusBarEventArgs : EventArgs
    {
        #region <���b�Z�[�W/>

        /// <summary>���b�Z�[�W</summary>
        private string _message;
        /// <summary>
        /// ���b�Z�[�W�̃A�N�Z�T
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion  // <���b�Z�[�W/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="message">���b�Z�[�W</param>
        public PrintStatusBarEventArgs(string message)
        {
            _message = message;
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PrintStatusBarEventArgs() : this(string.Empty) { }

        #endregion  // <Constructor/>
    }

    /// <summary>
    /// �X�e�[�^�X�o�[�ɏo�͂���C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void PrintStatusBar(object sender, PrintStatusBarEventArgs e);

    /// <summary>
    /// �^�u�ύX�X�e�[�^�X�o�[�ɏo�͂���C�x���g�n���h��
    /// </summary>
    /// <param name="sender">�C�x���g�\�[�X</param>
    /// <param name="e">�C�x���g�p�����[�^</param>
    public delegate void ChangeStatusBar(object sender, Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e);

    #endregion  // ���X�e�[�^�X�o�[�֏o��
    /// <summary>
    /// PDF�̊Ǘ��҃N���X
    /// </summary>
    public sealed class PDFManager
    {
        #region <PDF�̏o�̓p�X�i�\���p�j/>

        /// <summary>PDF�̏o�̓t���p�X�̃��X�g�i�\���p�j</summary>
        private readonly List<string> _previewPDFPathList;
        /// <summary>
        /// PDF�̏o�̓t���p�X�̃��X�g�i�\���p�j���擾���܂��B
        /// </summary>
        public List<string> PreviewPDFPathList { get { return _previewPDFPathList; } }

        #endregion  // <PDF�̏o�̓p�X�i�\���p�j/>

        #region <PDF�̏o�̓p�X�i�������P�ʁj/>

        /// <summary>PDF�̏o�̓t���p�X�̃��X�g�i�������P�ʁj</summary>
        private readonly List<string> _pdfPathList;
        /// <summary>
        /// PDF�̏o�̓t���p�X�̃��X�g�i�������P�ʁj���擾���܂��B
        /// </summary>
        private List<string> PDFPathList { get { return _pdfPathList; } }

        #endregion  // <PDF�̏o�̓p�X�i�������P�ʁj/>

        #region <�\���pPDF�p�X�i�L�[�j�Ɛ������p�X�i�l�F���X�g�j�̃}�b�v/>

        /// <summary>�\���pPDF�p�X�i�L�[�j�Ɛ������p�X�i�l�F���X�g�j�̃}�b�v</summary>
        private readonly IDictionary<string, IList<string>> _pdfPathListMap;
        /// <summary>
        /// �\���pPDF�p�X�i�L�[�j�Ɛ������p�X�i�l�F���X�g�j�̃}�b�v���擾���܂��B
        /// </summary>
        private IDictionary<string, IList<string>> PDFPathListMap { get { return _pdfPathListMap; } }

        /// <summary>
        /// ��static���@�\���pPDF�p�X�i�L�[�j�Ɛ������p�X�i�l�F���X�g�j�̃}�b�v
        /// </summary>
        private static IDictionary<string, IList<string>> stc_pdfPathListMap;

        #endregion  // <�\���pPDF�p�X�i�L�[�j�Ɛ������p�X�i�l�F���X�g�j�̃}�b�v/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="previewPDFPathList">PDF�̏o�̓p�X�i�\���p�j</param>
        /// <param name="pdfPathList">PDF�̏o�̓p�X�i�������P�ʁj</param>
        public PDFManager(
            List<string> previewPDFPathList,
            List<string> pdfPathList
        )
        {
            // PDF�̏o�̓p�X�i�������P�ʁj
            if (pdfPathList != null)
            {
                _pdfPathList = pdfPathList;
            }
            else
            {
                _pdfPathList = new List<string>();
            }

            // PDF�̏o�̓p�X�i�\���p�j
            if (previewPDFPathList != null)
            {
                _previewPDFPathList = previewPDFPathList;
            }
            else
            {
                _previewPDFPathList = new List<string>();
            }

            // �\���pPDF�p�X�i�L�[�j�Ɛ������p�X�i�l�F���X�g�j�̃}�b�v��������
            _pdfPathListMap = CreatePDFListMap(previewPDFPathList, pdfPathList);

            // static�t�B�[���h�ɑޔ��iPG�I�����ɑS�č폜����ׁj
            if (stc_pdfPathListMap == null)
            {
                stc_pdfPathListMap = new Dictionary<string, IList<string>>();
            }
            AddTargetInfo(ref stc_pdfPathListMap, previewPDFPathList, pdfPathList);
        }

        /// <summary>
        /// �\���pPDF�p�X�i�L�[�j�Ɛ������p�X�i�l�F���X�g�j�̃}�b�v�𐶐����܂��B
        /// </summary>
        /// <param name="previewPDFPathList">PDF�̏o�̓p�X�i�\���p�j�̃��X�g</param>
        /// <param name="pdfPathList">PDF�̏o�̓p�X�i�������P�ʁj�̃��X�g</param>
        /// <returns>�\���pPDF�p�X�i�L�[�j�Ɛ������p�X�i�l�F���X�g�j�̃}�b�v</returns>
        private static IDictionary<string, IList<string>> CreatePDFListMap(
            List<string> previewPDFPathList,
            List<string> pdfPathList
        )
        {
            IDictionary<string, IList<string>> pdfPathListMap = new Dictionary<string, IList<string>>();
            {
                if (previewPDFPathList != null && previewPDFPathList.Count > 0)
                {
                    foreach (string previewPDFPath in previewPDFPathList)
                    {
                        if (!pdfPathListMap.ContainsKey(previewPDFPath))
                        {
                            pdfPathListMap.Add(previewPDFPath, pdfPathList);
                        }
                    }
                }
            }
            return pdfPathListMap;
        }

        /// <summary>
        /// PDF�Ώےǉ�
        /// </summary>
        /// <param name="previewPDFPathList"></param>
        /// <param name="pdfPathList"></param>
        private static void AddTargetInfo(ref IDictionary<string, IList<string>> pdfPathListDic, List<string> previewPDFPathList, List<string> pdfPathList)
        {
            if (pdfPathList == null)
            {
                // ���̃��\�b�h�̈����̃��X�g
                pdfPathList = new List<string>();
            }

            // �f�B�N�V���i���ɒǉ�
            if (previewPDFPathList != null && previewPDFPathList.Count > 0)
            {
                foreach (string previewPDFPath in previewPDFPathList)
                {
                    if (!pdfPathListDic.ContainsKey(previewPDFPath))
                    {
                        pdfPathListDic.Add(previewPDFPath, pdfPathList);
                    }
                    else
                    {
                        (pdfPathListDic[previewPDFPath] as List<string>).AddRange(pdfPathList);
                    }
                }
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �֘A����PDF�t�@�C����S�č폜���܂��B
        /// </summary>
        /// <remarks>�w�肳�ꂽ�\���pPDF�t�@�C���Ɗ֘A���鐿�����P�ʂ�PDF�t�@�C�����폜���܂��B</remarks>
        /// <param name="previewPDFPath">PDF�̏o�̓p�X�i�\���p�j</param>
        public void DeleteFiles(string previewPDFPath)
        {
            if (!stc_pdfPathListMap.ContainsKey(previewPDFPath)) return;

            // �\���pPDF�t�@�C�����폜
            try
            {
                if (File.Exists(previewPDFPath))
                {
                    File.Delete(previewPDFPath);
                }
            }
            catch
            {
            }

            // �֘A���鐿�����P�ʂ�PDF�t�@�C�����폜
            IList<string> deletingPDFFileList = stc_pdfPathListMap[previewPDFPath];
            foreach (string deletingPDFPath in deletingPDFFileList)
            {
                try
                {
                    if (File.Exists(deletingPDFPath))
                    {
                        File.Delete(deletingPDFPath);
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// �֘A����PDF�t�@�C����S�č폜���܂��B
        /// </summary>
        /// <remarks>�w�肳�ꂽ�\���pPDF�t�@�C���Ɗ֘A���鐿�����P�ʂ�PDF�t�@�C�����폜���܂��B</remarks>
        public void DeleteFiles()
        {
            foreach (string previewPDFPath in PDFPathListMap.Keys)
            {
                DeleteFiles(previewPDFPath);
            }
        }

        /// <summary>
        /// �����̕\���pPDF�����݂��邩���肵�܂��B
        /// </summary>
        /// <value><c>true</c> :���݂��܂��B<br/><c>false</c>:���݂��܂���B</value>
        public bool ExistsOtherPDFPreview
        {
            get { return PreviewPDFPathList.Count > 1; }
        }
    }

    #region ���_�c���[�R���g���[���̃w���p

    /// <summary>
    /// ���_�c���[�R���g���[���̃w���p�N���X
    /// </summary>
    internal static class SectionTreeHelper
    {
        /// <summary>
        /// �G�N�X�|�[�g�t�@�C���̃t���p�X���擾���܂��B
        /// </summary>
        private static string ExportPathName
        {
            get
            {
                return @".\UISettings\MAKAU03002U_SectionSetting.xml";
            }
        }

        /// <summary>
        /// �`�F�b�N����Ă��鋒�_�R�[�h���G�N�X�|�[�g���܂��B
        /// </summary>
        /// <param name="sectionTree">���_�c���[�R���g���[��</param>
        /// <param name="enabled">�L���t���O</param>
        public static void ExportCheckedSectionCode(
            Infragistics.Win.UltraWinTree.UltraTree sectionTree,
            bool enabled
        )
        {
            #region Guard Phrase

            if (sectionTree == null) return;
            if (!enabled) return;

            #endregion // Guard Phrase

            List<string> sectionPairList = new List<string>();

            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode sectionNode in sectionTree.Nodes)
            {
                if (sectionNode.CheckedState.Equals(CheckState.Checked))
                {
                    sectionPairList.Add(sectionNode.Key);
                }
            }

            System.IO.FileStream outputFile = null;
            try
            {
                outputFile = new System.IO.FileStream(ExportPathName, System.IO.FileMode.Create);
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
                serializer.Serialize(outputFile, sectionPairList);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (outputFile != null) outputFile.Close();
            }
        }

        /// <summary>
        /// �`�F�b�N����Ă������_�R�[�h���C���|�[�g���܂��B
        /// </summary>
        /// <param name="sectionTree">���_�c���[�R���g���[��</param>
        /// <param name="enabed">�L���t���O</param>
        /// <returns>
        /// <c>true</c> :�C���|�[�g���܂����B<br/>
        /// <c>false</c>:�C���|�[�g���܂���ł����B
        /// </returns>
        public static bool ImportCheckedSectionCode(
            Infragistics.Win.UltraWinTree.UltraTree sectionTree,
            bool enabed
        )
        {
            #region Guard Phrase

            if (sectionTree == null) return false;
            if (!System.IO.File.Exists(ExportPathName)) return false;
            if (!enabed) return false;

            #endregion // Guard Phrase

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));

            bool checkedTree = false;
            System.IO.FileStream inputFile = null;
            try
            {
                inputFile = new System.IO.FileStream(ExportPathName, System.IO.FileMode.Open);
                List<string> checkedSectionCodeList = (List<string>)serializer.Deserialize(inputFile);
                if (checkedSectionCodeList == null) return false;

                foreach (string sectionCode in checkedSectionCodeList)
                {
                    if (sectionTree.Nodes.Exists(sectionCode))
                    {
                        sectionTree.Nodes[sectionCode].CheckedState = CheckState.Checked;
                        checkedTree = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            finally
            {
                if (inputFile != null) inputFile.Close();
            }
            return checkedTree;
        }
    }

    #endregion // ���_�c���[�R���g���[���̃w���p

    # region�@���������O�o�̓f�[�^�̃N���X�̃N���X
    internal class RequestLogData
    {
        # region �� private field ��
        /// <summary>LOĢ�ٓ��Ӑ�CD</summary>
        private int customerCode;
        /// <summary>�O�񐿋�������</summary>
        private DateTime addupDate;
        /// <summary>������z</summary>
        private long thisTimeSalesPrice;
        /// <summary>���׍��v���z</summary>
        private long totalPrice;
        /// <summary>���z</summary>
        private long differentPrice;
        /// <summary>��������z</summary>
        private long thisTimeDemandPrice;
        /// <summary>���׍��v���z�i����</summary>
        private long totalDemandPrice;
        /// <summary>�������z</summary>
        private long differentDemandPrice;

        # endregion �� private field ��

        # region �� public propaty ��

        /// public propaty name  :  CustomerCode
        /// <summary>LOĢ�ٓ��Ӑ�CD�v���p�e�B</summary>
        public int CustomerCode
        {
            get { return customerCode; }
            set { customerCode = value; }
        }

        /// public propaty name  :  AddupDate
        /// <summary>�O�񐿋��������v���p�e�B</summary>
        public DateTime AddupDate
        {
            get { return addupDate; }
            set { addupDate = value; }
        }

        /// public propaty name  :  ThisTimeSalesPrice
        /// <summary>������z�v���p�e�B</summary>
        public long ThisTimeSalesPrice
        {
            get { return thisTimeSalesPrice; }
            set { thisTimeSalesPrice = value; }
        }

        /// public propaty name  :  TotalPrice
        /// <summary>���׍��v���z�v���p�e�B</summary>
        public long TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        /// public propaty name  :  DifferentPrice
        /// <summary>���z�v���p�e�B</summary>
        public long DifferentPrice
        {
            get { return differentPrice; }
            set { differentPrice = value; }
        }

        /// public propaty name  :  ThisTimeDemandPrice
        /// <summary>��������z�v���p�e�B</summary>
        public long ThisTimeDemandPrice
        {
            get { return thisTimeDemandPrice; }
            set { thisTimeDemandPrice = value; }
        }

        /// public propaty name  :  TotalDemandPrice
        /// <summary>���׍��v���z�i�����j�v���p�e�B</summary>
        public long TotalDemandPrice
        {
            get { return totalDemandPrice; }
            set { totalDemandPrice = value; }
        }

        /// public propaty name  :  DifferentDemandPrice
        /// <summary>�������z�v���p�e�B</summary>
        public long DifferentDemandPrice
        {
            get { return differentDemandPrice; }
            set { differentDemandPrice = value; }
        }

        # endregion �� public propaty ��

        # region �� Constructor ��
        /// <summary>
        /// �������o�̓f�[�^�̃N���X
        /// </summary>
        /// <returns>RequestInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        public RequestLogData()
        {
        }
        # endregion �� Constructor ��
    }
    # endregion

    /// <summary>
    /// ���R���[�������N���X
    /// </summary>
    /// <remarks>���R���[�̒��o�E����N���X���Ăяo���Đ��䂷��N���X�ł��B�������_�C�A���O�����䂵�܂��B</remarks>
    internal class FreePrintController : IDisposable
    {
        # region [enum]
        /// <summary>
        /// �������[�h�񋓌^
        /// </summary>
        private enum ProcMode : int
        {
            /// <summary>�Ȃ�</summary>
            None = 0,
            /// <summary>���o</summary>
            Extract = 1,
            /// <summary>���</summary>
            Print = 2,
        }
        # endregion

        # region [private const]
        private const string ct_Message_Extract = "���݁A����������ł��B";
        private const string ct_Message_BeforePrint = "���݁A����������ł��B";
        private const string ct_Message_Print = "���݁A����������ł��B";
        private const string ct_Message_Cancel = "���f���܂��B";
        # endregion

        # region [private �t�B�[���h]
        // ���o�����I�u�W�F�N�g
        private object _extractObj;
        // ��������I�u�W�F�N�g
        private object _printObj;

        // ������
        private SFCMN06002C _printInfo;

        // ����_�C�A���O
        private SFCMN00299CA _progressDialog;
        private bool _progressDialogDisposed;

        // ���ݏ������[�h(0:�Ȃ�/1:���o/2:���)
        private ProcMode _mode;
        private bool _cancel;
        internal int _logCnt;
        # endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public FreePrintController()
        {
            this.Clear();
        }
        /// <summary>
        /// ����������
        /// </summary>
        public void Clear()
        {
            _cancel = false;
            _mode = ProcMode.None;
            _progressDialog = null;
        }
        # endregion

        # region [�������_�C�A���O]
        /// <summary>
        /// �������_�C�A���O�\��
        /// </summary>
        public void ShowProgressDialog()
        {
            _progressDialogDisposed = false;

            if (_progressDialog == null)
            {
                _progressDialog = new SFCMN00299CA();
                _progressDialog.Title = "�������";
                _progressDialog.DispCancelButton = true;
                _progressDialog.CancelButtonClick += new EventHandler(ProgressDialog_CancelButtonClick);
            }
            _progressDialog.Message = ct_Message_Extract;
            _progressDialog.Show();
        }
        /// <summary>
        /// �������_�C�A���O�L�����Z��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressDialog_CancelButtonClick(object sender, EventArgs e)
        {
            // �L�����Z�������Ăяo��
            this.Cancel();
        }
        /// <summary>
        /// �������_�C�A���O�I��
        /// </summary>
        public void HideProgressDialog()
        {
            if (_progressDialog != null)
            {
                if (!_progressDialogDisposed)
                {
                    _progressDialog.Dispose();
                    _progressDialog = null;
                    _progressDialogDisposed = true;
                }
            }
        }
        /// <summary>
        /// �ĊJ�p�E�����_�C�A���O�\���i����v���r���[�Ń_�C�A���O���B������ɍĕ\������ׂ̏����j
        /// </summary>
        public void RestartShowProgressDialog()
        {
            if (_progressDialogDisposed)
            {
                // ����ς݂Ȃ�΁AShowProgressDialog���Ď��s����
                this.ShowProgressDialog();
            }
            else
            {
                // ������Ȃ�\�����s���Ȃ̂ŉ������Ȃ�
            }
        }
        # endregion

        # region [���o�E���]
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="printInfo"></param>
        /// <returns></returns>
        public int Extract(ref SFCMN06002C printInfo)
        {
            // mode=���o
            _mode = ProcMode.Extract;

            // ���o���̈�����I�u�W�F�N�g��ޔ�(����)
            _printInfo = printInfo;

            try
            {
                _progressDialog.Message = ct_Message_Extract;

                // ���o
                _extractObj = new PMKAU01000EA(printInfo);
                int status = (_extractObj as PMKAU01000EA).ExtrPrintData();

                if (_cancel)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
                return status;
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public int Print(out List<string> pdfPathList, out Dictionary<string, Document> documentByTypeDic, ref List<DenchoDXIndexCSVEntity> denchoDXIndexCSVEntityList, bool syncFlg)
        {
            // mode=���
            _mode = ProcMode.Print;

            // ������
            pdfPathList = null;
            documentByTypeDic = null;

            try
            {
                _progressDialog.Message = ct_Message_BeforePrint;

                _printObj = new PMKAU01001PA();
                (_printObj as PMKAU01001PA).Printinfo = _printInfo;
                (_printObj as PMKAU01001PA).MessageChange += new EventHandler(FreePrintController_MessageChange);

                int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                DataSet ds = (DataSet)_printInfo.rdData;
                DataTable dt = ds.Tables[0];
                // ���������O��񃊃X�g
                List<RequestLogData> requestLogDataList = new List<RequestLogData>();
                // ���O�t���O���n�l
                int logCnt = 0;

                // �������Ɉ�������ď���
                DataTable dtNew = dt.Clone();
                dtNew.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // ���Ӑ�̍��񔄏���z
                    Int64 thisTimeSalesPrice = 0;
                    // ���׍��v���z�i�������܂܂Ȃ��j
                    Int64 totalPrice = 0;
                    // ���z
                    Int64 differencePrice = 0;

                    // ���Ӑ�̍�������z
                    Int64 thisTimeDmdNrml = 0;
                    // ���׍��v���z�i�����̂݁j
                    Int64 demandTotalPrice = 0;

                    // ���O�t���O���n�l
                    //_logCnt = 0; // DEL 2012/03/05 xupz for redmine#28258

                    // ���R���[�������w�b�_�i�w�b�_�j
                    EBooksFrePBillHeadWork frePBillHeadWork = new EBooksFrePBillHeadWork();

                    if ((EBooksFrePBillHeadWork)dt.Rows[i]["FrePBillHead"] != null)
                    {
                        frePBillHeadWork = (EBooksFrePBillHeadWork)dt.Rows[i]["FrePBillHead"];
                    }

                    // ���R���[���������ׁi����j
                    List<EBooksFrePBillDetailWork> frePBillSalesDetailWorkList = new List<EBooksFrePBillDetailWork>();

                    if ((List<EBooksFrePBillDetailWork>)dt.Rows[i]["FrePBillSalesList"] != null)
                    {
                        frePBillSalesDetailWorkList = (List<EBooksFrePBillDetailWork>)dt.Rows[i]["FrePBillSalesList"];
                    }

                    // ���R���[���������ׁi�����j
                    List<EBooksFrePBillDetailWork> frePBillDemandDetailWorkList = new List<EBooksFrePBillDetailWork>();

                    if ((List<EBooksFrePBillDetailWork>)dt.Rows[i]["FrePBillDepositList"] != null)
                    {
                        frePBillDemandDetailWorkList = (List<EBooksFrePBillDetailWork>)dt.Rows[i]["FrePBillDepositList"];
                    }

                    // ���Ӑ�̍��񔄏���z(���񔄏���z-����ԕi���z-����l�������z)
                    thisTimeSalesPrice = frePBillHeadWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;

                    // ���׍��v���z�i�������܂܂Ȃ��j
                    foreach (EBooksFrePBillDetailWork frePBillDetailWork in frePBillSalesDetailWorkList)
                    {
                        totalPrice += frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF;
                    }

                    // ���Ӑ�̍�������z�i��������z�i�ʏ�j�j
                    thisTimeDmdNrml = frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;

                    // ���׍��v���z�i�����̂݁j
                    if (frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim() == "00" &&
                        frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0)
                    {
                        if (frePBillDemandDetailWorkList.Count != 0)
                        {
                            // �萔���E�l�����Z�̃L�[
                            List<string> keyList = new List<string>();
                            foreach (EBooksFrePBillDetailWork frePBillDemandWork in frePBillDemandDetailWorkList)
                            {
                                demandTotalPrice += frePBillDemandWork.DEPSITDTLRF_DEPOSITRF;
                                string depKey = string.Format("{0}{1}", frePBillDemandWork.DEPSITMAINRF_ACPTANODRSTATUSRF, frePBillDemandWork.DEPSITMAINRF_DEPOSITSLIPNORF);
                                if (!keyList.Contains(depKey))
                                {
                                    demandTotalPrice += frePBillDemandWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
                                    demandTotalPrice += frePBillDemandWork.DEPSITMAINRF_FEEDEPOSITRF;
                                    // �L�[�X�V
                                    keyList.Add(depKey);
                                }
                            }
                        }
                    }
                    else
                    {
                        // �W�v���R�[�h�ȊO��0
                        demandTotalPrice = 0;
                    }

                    if (thisTimeSalesPrice == totalPrice && thisTimeDmdNrml == demandTotalPrice)
                    {
                        dtNew.ImportRow(dt.Rows[i]);
                    }
                    // ���Ӑ�̍��񔄏���z�ƁA���׍��v�i�������܂܂Ȃ��j���r���āA�k�n�f�o�͂���B
                    // �����Ӑ�̍�������z�Ɩ��׍��v�i�����̂݁j���r���āA�Ⴂ���������ꍇ�ALOG�o�͂���B
                    else
                    {
                        // LOG���L��
                        logCnt++;

                        RequestLogData requestLogData = new RequestLogData();

                        // ���Ӑ�CD
                        int customerCode = frePBillHeadWork.CADD_CUSTOMERCODERF;
                        requestLogData.CustomerCode = customerCode;
                        if (customerCode == 0)
                        {
                            requestLogData.CustomerCode = frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF;
                        }

                        //�O�񐿋�������
                        requestLogData.AddupDate = (_printInfo.jyoken as ExtrInfo_EBooksDemandTotal).AddUpDate;

                        //���񔄏���z
                        requestLogData.ThisTimeSalesPrice = thisTimeSalesPrice;

                        //���׍��v���z
                        requestLogData.TotalPrice = totalPrice;

                        //���z
                        differencePrice = totalPrice - thisTimeSalesPrice;
                        requestLogData.DifferentPrice = differencePrice;

                        //��������z
                        requestLogData.ThisTimeDemandPrice = thisTimeDmdNrml;

                        //���׍��v���z�i�����j
                        requestLogData.TotalDemandPrice = demandTotalPrice;

                        // �������z
                        differencePrice = demandTotalPrice - thisTimeDmdNrml;
                        requestLogData.DifferentDemandPrice = differencePrice;

                        requestLogDataList.Add(requestLogData);
                    }
                }

                //���Ӑ�̍��񔄏���z�ƁA���׍��v�i�������܂܂Ȃ��j���r���āA�Ⴂ���������ꍇ�͐������̈��������������
                ds.Tables.RemoveAt(0);
                ds.Tables.Add(dtNew);
                _printInfo.rdData = ds;

                // LOG���L��
                if (logCnt > 0)
                {
                    LogWrite(requestLogDataList);
                    _logCnt++;
                }

                //������s
                if (_printInfo.rdData != null && dtNew.Rows.Count > 0)
                {
                    status = (_printObj as PMKAU01001PA).StartPrint();
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                // ���ʊi�[
                pdfPathList = (_printObj as PMKAU01001PA).PdfPathList;
                documentByTypeDic = (_printObj as PMKAU01001PA).DocumentByTypeDic;

                if (_cancel)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
                Thread.Sleep(10); // 0.01sec (PDF�̃t�@�C�������m���ɕς��悤)                

                // �C���f�b�N�X�t�@�C���쐬�p���쐬
                if (syncFlg)
                {
                    DataSet rstds = (DataSet)_printInfo.rdData;
                    DataTable rstdt = rstds.Tables[0];
                    EBooksFrePBillHeadWork rstFrePBillHeadWork = new EBooksFrePBillHeadWork();
                    for (int i = 0; i < rstdt.Rows.Count; i++)
                    {
                        //---DEL 2023/01/10 ���O �d�q����A�g�i�������j��CSV�o�͏��Ԃ̏C��--->>>>>
                        //// ���R���[�������w�b�_�i�w�b�_�j
                        //if ((EBooksFrePBillHeadWork)dt.Rows[i]["FrePBillHead"] != null)
                        //{
                        //    rstFrePBillHeadWork = (EBooksFrePBillHeadWork)dt.Rows[i]["FrePBillHead"];
                        //}
                        //---DEL 2023/01/10 ���O �d�q����A�g�i�������j��CSV�o�͏��Ԃ̏C��---<<<<<
                        //---ADD 2023/01/10 ���O �d�q����A�g�i�������j��CSV�o�͏��Ԃ̏C��--->>>>>
                        // ���R���[�������w�b�_�i�w�b�_�j
                        if ((EBooksFrePBillHeadWork)rstdt.Rows[i]["FrePBillHead"] != null)
                        {
                            rstFrePBillHeadWork = (EBooksFrePBillHeadWork)rstdt.Rows[i]["FrePBillHead"];
                        }
                        //---ADD 2023/01/10 ���O �d�q����A�g�i�������j��CSV�o�͏��Ԃ̏C��---<<<<<
                        // �C���f�b�N�X�t�@�C���쐬�p�G���e�B�e�B
                        DenchoDXIndexCSVEntity denchoDXIndexCSVEntity = new DenchoDXIndexCSVEntity();

                        //�V�X�e���敪	mcd
                        denchoDXIndexCSVEntity.Mcd = DenchoDXIndexCSVEntity.EMcdType.PMNS;
                        //�����R�[�h(����)	
                        denchoDXIndexCSVEntity.Blcustomercd = LoginInfoAcquisition.EnterpriseCode;
                        //�t�@�C����	 
                        int idx = pdfPathList[i].LastIndexOf("\\");
                        denchoDXIndexCSVEntity.Filename = pdfPathList[i].Substring(idx + 1);
                        //���ޕ���	
                        denchoDXIndexCSVEntity.Doctype = DenchoDXIndexCSVEntity.EDocType.Invoice;
                        //�����R�[�h	
                        denchoDXIndexCSVEntity.Customercd = rstFrePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF.ToString("00000000");
                        //����於��	
                        denchoDXIndexCSVEntity.Customername = rstFrePBillHeadWork.CUSTDMDPRCRF_CLAIMNAMERF + rstFrePBillHeadWork.CUSTDMDPRCRF_CLAIMNAME2RF;
                        //���ޔԍ�	
                        denchoDXIndexCSVEntity.Docnumber = rstFrePBillHeadWork.CUSTDMDPRCRF_BILLNORF.ToString();
                        //����N����	
                        DateTime outPutDateTime = (_printObj as PMKAU01001PA).OutPutDateTime;
                        denchoDXIndexCSVEntity.Transactiondate = outPutDateTime;
                        //�������	
                        denchoDXIndexCSVEntity.Transactiontime = outPutDateTime;
                        //������z���v(�ō���)	
                        denchoDXIndexCSVEntity.Price_tax_included = rstFrePBillHeadWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF;
                        //������z���v(�Ŕ���)	
                        denchoDXIndexCSVEntity.Price_tax_excluded = rstFrePBillHeadWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF - rstFrePBillHeadWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF;
                        //����ŋ��z���v	
                        denchoDXIndexCSVEntity.Total_tax = rstFrePBillHeadWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF;
                        //�ŗ�(1)	
                        denchoDXIndexCSVEntity.Taxrate1 = rstFrePBillHeadWork.TitleTaxRate1;
                        //�ŗ�(2)
                        denchoDXIndexCSVEntity.Taxrate2 = rstFrePBillHeadWork.TitleTaxRate2;
                        // �ŗ�(1)�Ώۋ��z���v(�Ŕ���)
                        denchoDXIndexCSVEntity.Price_taxrate1_excluded = (decimal)rstFrePBillHeadWork.TotalThisTimeSalesTaxExRate1;
                        // �ŗ�(2)�Ώۋ��z���v(�Ŕ���)
                        denchoDXIndexCSVEntity.Price_taxrate2_excluded = (decimal)rstFrePBillHeadWork.TotalThisTimeSalesTaxExRate2;
                        // �ŗ�(1)�Ώۋ��z���v(�ō���)
                        denchoDXIndexCSVEntity.Price_taxrate1_included = (decimal)(rstFrePBillHeadWork.TotalThisTimeSalesTaxExRate1 + rstFrePBillHeadWork.TotalThisTimeTaxRate1);
                        // �ŗ�(2)�Ώۋ��z���v(�ō���)
                        denchoDXIndexCSVEntity.Price_taxrate2_included = (decimal)(rstFrePBillHeadWork.TotalThisTimeSalesTaxExRate2 + rstFrePBillHeadWork.TotalThisTimeTaxRate2);
                        // �Ŋz(1)
                        denchoDXIndexCSVEntity.Tax1 = (decimal)rstFrePBillHeadWork.TotalThisTimeTaxRate1;
                        // �Ŋz(2)
                        denchoDXIndexCSVEntity.Tax2 = (decimal)rstFrePBillHeadWork.TotalThisTimeTaxRate2;
                        //���s�Җ���
                        denchoDXIndexCSVEntity.Companyname = rstFrePBillHeadWork.COMPANYNMRF_COMPANYNAME1RF;
                        //���s���_�R�[�h
                        denchoDXIndexCSVEntity.Sectioncd = Convert.ToUInt64(rstFrePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF);
                        //���s���_����
                        denchoDXIndexCSVEntity.Sectionname = rstFrePBillHeadWork.SECHED_SECTIONGUIDENMRF;
                        //�ʉݒP��
                        denchoDXIndexCSVEntity.Currencyunit = DenchoDXIndexCSVEntity.ECurrencyUnitType.JPY;

                        denchoDXIndexCSVEntityList.Add(denchoDXIndexCSVEntity);
                    }
                }

                return status;
            }
            catch
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }

        /// <summary>
        /// ���O�o�͏���
        /// </summary>
        /// <param name="requestinfoList">�������G���[��񃊃X�g</param>
        private void LogWrite(List<RequestLogData> requestLogDataList)
        {
            try
            {
                FileStream _fs;										// �t�@�C���X�g���[��
                StreamWriter _sw;                                     // �X�g���[��writer

                //�t�@�C���̃p�X���擾����(regedit�\����)
                string registData;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey broadleaf = software.OpenSubKey("BroadLeaf", true);
                RegistryKey product = broadleaf.OpenSubKey("Product", true);
                RegistryKey partsMan = product.OpenSubKey("Partsman", true);
                registData = partsMan.GetValue("InstallDirectory").ToString();

                DateTime edt = DateTime.Now;

                //�t�H�[������̂��̔��f
                string folderPath = registData + "\\LOG\\";
                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                    DirectoryInfo dis = di.CreateSubdirectory("MAKAU03002U\\");
                }
                else
                {

                    if (!Directory.Exists(folderPath + "MAKAU03002U\\"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folderPath + "MAKAU03002U\\");
                    }
                }

                //�t�@�C�����쐬����
                _fs = new FileStream(registData + "\\LOG\\" + "MAKAU03002U\\" + "MAKAU03002U_" + edt.ToString("yyyyMMdd") + ".Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));

                //�t�@�C���Ƀ��O���������Ƃ�����̂��̔��f
                FileInfo fi = new FileInfo(@_fs.Name);
                if (fi.Length == 0)
                {
                    _sw.WriteLine("\"LOĢ�ٓ��Ӑ�CD\"," + "\"�O�񐿋�������\"," + "\"������z\"," + "\"���׍��v���z\"," + "\"���㍷�z\"," + "\"��������z\"," + "\"���׍��v���z�i�����j\"," + "\"�������z\"");
                }

                //�t�@�C���Ƀ��O�������܂�
                foreach (RequestLogData item in requestLogDataList)
                {
                    _sw.WriteLine("\"" + item.CustomerCode + "\",\"" + TDateTime.DateTimeToString("YYYY/MM/DD", item.AddupDate) + "\",\"" + item.ThisTimeSalesPrice + "\",\"" + item.TotalPrice + "\",\"" + item.DifferentPrice + "\",\"" + item.ThisTimeDemandPrice + "\",\"" + item.TotalDemandPrice + "\",\"" + item.DifferentDemandPrice + "\"");
                }

                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ��������Ń��b�Z�[�W�ύX���鏈���i��������ˈ�������j
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FreePrintController_MessageChange(object sender, EventArgs e)
        {
            if (_printInfo.prevkbn == 0)
            {
                //----------------------------------------
                // �v���r���[�Ȃ�
                //----------------------------------------
                // ���b�Z�[�W�ύX
                _progressDialog.Message = ct_Message_Print;
            }
            else
            {
                //----------------------------------------
                // �v���r���[����
                //----------------------------------------
                // �_�C�A���O���̂��I���ˍĊJ����ɂ�RestartShowProgressDialog�̌Ăяo�����K�v�I
                this.HideProgressDialog();
            }
        }
        /// <summary>
        /// �L�����Z������
        /// </summary>
        public void Cancel()
        {
            _cancel = true;

            switch (_mode)
            {
                default:
                case ProcMode.None:
                    break;
                case ProcMode.Extract:
                    {
                        // ���o�L�����Z��
                        if (_extractObj != null)
                        {
                            (_extractObj as PMKAU01000EA).Cancel();
                        }
                    }
                    break;
                case ProcMode.Print:
                    {
                        // ����L�����Z��
                        if (_printObj != null)
                        {
                            (_printObj as PMKAU01001PA).Cancel();
                        }
                    }
                    break;
            }

            // �L�����Z�����b�Z�[�W�\��
            if (_progressDialog != null)
            {
                _progressDialog.Message = ct_Message_Cancel;
            }
        }
        # endregion

        # region [Dispose]
        /// <summary>
        /// �������
        /// </summary>
        public void Dispose()
        {
            // ����I�u�W�F�N�g���
            if (_printObj != null)
            {
                (_printObj as PMKAU01001PA).Dispose();
            }

            // �K�x�[�W�R���N�V���������҂���null�ɂ��Ă���
            _extractObj = null;
            _printObj = null;
            // ���C���o�f�ɂ��ʓrDataTable�̉�����s���̂ŁA�ێ����Ȃ��悤null�ɂ���B
            _printInfo = null;

            // �_�C�A���O���
            this.HideProgressDialog();

            // ������
            this.Clear();
        }

        /// <summary>
        /// �������
        /// </summary>
        public void Dispose2()
        {
            // ����I�u�W�F�N�g���
            if (_printObj != null)
            {
                (_printObj as PMKAU01001PA).Dispose();
            }

            // �K�x�[�W�R���N�V���������҂���null�ɂ��Ă���
            _extractObj = null;
            _printObj = null;
            // ���C���o�f�ɂ��ʓrDataTable�̉�����s���̂ŁA�ێ����Ȃ��悤null�ɂ���B
            _printInfo = null;

        }

        # endregion
    }

    # region
    /// <summary>
    /// �d�q����󂯓n���p�t�H���_�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�q����󂯓n���p�t�H���_�ݒ�N���X</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2022/03/07</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class EBooksLinkSetInfo
    {
        // �d�q����󂯓n���t�H���_
        private string _eBooksFolder;

        // ����惊�X�g�󂯓n���t�H���_
        private string _customFolder;

        /// <summary>
        /// �d�q����󂯓n���p�t�H���_�ݒ�N���X
        /// </summary>
        public EBooksLinkSetInfo()
        {

        }

        /// <summary>�d�q����󂯓n���t�H���_</summary>
        public string EBooksFolder
        {
            get { return this._eBooksFolder; }
            set { this._eBooksFolder = value; }
        }

        /// <summary>����惊�X�g�󂯓n���t�H���_</summary>
        public string CustomFolder
        {
            get { return this._customFolder; }
            set { this._customFolder = value; }
        }
    }
    # endregion
}

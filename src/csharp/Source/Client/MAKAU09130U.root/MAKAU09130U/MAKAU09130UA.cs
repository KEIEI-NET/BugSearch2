//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d������яC��
// �v���O�����T�v   : �d������т̓o�^�E�C���E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024 ���X�� ��
// �� �� ��  2009/01/14  �C�����e : Partman�p�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/29  �C�����e : MANTIS�y13353�z�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���� ���T
// �� �� ��  2012/09/18  �C�����e : �d���摍���Ή��ɔ����Ή�
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Reflection;

using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
// --- ADD 2012/09/18 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/09/18 ----------<<<<<

namespace  Broadleaf.Windows.Forms
{
	/// **********************************************************************
	/// public class name:	MAKAU09130UA
	///						MAKAU09130U.DLL                                    
	/// <summary>
	///						�d������яC�����
	/// </summary>
	/// ----------------------------------------------------------------------
	/// <remarks> 
	/// <br>note         :	�d����̔��|�E�x���̎��яC�����s���܂��B</br>
	/// <br>note         :	�� �}�X�^�����e���C��SFCMN09000UE�𗬗p���܂����B</br>
    /// <br>Programmer   : 30154 �����@���m</br>
    /// <br>Date         : 2007.04.18</br>
    /// <br></br>
    /// <br>note         :	����.NS�p�ɕύX</br>
    /// <br>Programmer   : 22018 ��� ���b</br>
    /// <br>Date         : 2007.09.27</br>
    /// <br></br>
    /// <br>Note         : PM.NS�p�ɕύX</br>
    /// <br>Programmer   : 21024 ���X�� ��</br>
    /// <br>Date         : 2009.01.14</br>
    /// </remarks>
	/// **********************************************************************
	public class MAKAU09130UA : System.Windows.Forms.Form
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel ViewButtonPanel;
		private Infragistics.Win.Misc.UltraButton Details_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton New_Button;
		private Infragistics.Win.Misc.UltraButton Modify_Button;
		private Infragistics.Win.Misc.UltraButton Close_Button;
		private System.Windows.Forms.Panel Customer_Panel;
		private Infragistics.Win.Misc.UltraLabel SupplierName2_Label;
		private Infragistics.Win.Misc.UltraButton Supplier_Guide_Button;
		private Infragistics.Win.Misc.UltraLabel SupplierSnm_Label;
		private Infragistics.Win.Misc.UltraLabel CustomerInfo_Label;
		private Broadleaf.Library.Windows.Forms.TNedit SupplierCode_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Infragistics.Win.Misc.UltraLabel TotalDay_Tittle_Label;
        private Infragistics.Win.Misc.UltraLabel TotalDay_Label;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl ultraTabControl1;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.Panel Five_Grid_Panel;
		private Infragistics.Win.UltraWinGrid.UltraGrid Acc_Grid;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.Misc.UltraLabel Line2_Label;
		private Infragistics.Win.UltraWinGrid.UltraGrid Dmd_Grid;
        private System.Windows.Forms.Panel claim_panel;
		private Broadleaf.Library.Windows.Forms.TLine tLine28;
		private Broadleaf.Library.Windows.Forms.TLine tLine30;
        private Broadleaf.Library.Windows.Forms.TLine tLine31;
        private Infragistics.Win.Misc.UltraLabel TtlBlDmd_Label;
        private Infragistics.Win.Misc.UltraLabel TtlDepoDmd_Label;
        private Infragistics.Win.Misc.UltraLabel TtlConsTaxDmd_Label;
        private Infragistics.Win.Misc.UltraLabel TtlSalesDmd_Label;
        private Infragistics.Win.Misc.UltraLabel TtlLMBlDmd_Label;
        private Infragistics.Win.Misc.UltraLabel Ttl2TmDmd_Label;
        private Infragistics.Win.Misc.UltraLabel Ttl3TmDmd_Label;
		private Broadleaf.Library.Windows.Forms.TLine tLine33;
		private Broadleaf.Library.Windows.Forms.TLine tLine34;
		private Broadleaf.Library.Windows.Forms.TLine tLine35;
		private Broadleaf.Library.Windows.Forms.TLine tLine36;
		private Broadleaf.Library.Windows.Forms.TLine tLine37;
		private Broadleaf.Library.Windows.Forms.TLine tLine38;
		private Broadleaf.Library.Windows.Forms.TLine tLine39;
        private Broadleaf.Library.Windows.Forms.TLine tLine40;
		private Infragistics.Win.Misc.UltraLabel BlDmdTitle_Label;
		private Infragistics.Win.Misc.UltraLabel DepositTotalTitle_Label;
		private Infragistics.Win.Misc.UltraLabel ConsTaxTitle_Label;
		private Infragistics.Win.Misc.UltraLabel SalesTotalTitle_Label;
		private Infragistics.Win.Misc.UltraLabel TtlLMTitle_Label;
		private Infragistics.Win.Misc.UltraLabel Ttl2TmTitle_Label;
		private Infragistics.Win.Misc.UltraLabel Ttl3TmTitle_Label;
		private Broadleaf.Library.Windows.Forms.TLine tLine42;
        private System.Windows.Forms.Splitter splitter1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar First_StatusBar;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar Second_StatusBar;
		private System.Windows.Forms.Timer Close_Timer;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToFirstGridColumn_CheckEditor;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor AutoFillToSecondGridColumn_CheckEditor;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager1;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU09130UA_Toolbars_Dock_Area_Top;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU09130UA_Toolbars_Dock_Area_Bottom;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU09130UA_Toolbars_Dock_Area_Left;
		private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _MAKAU09130UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.Misc.UltraLabel cust_Label;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel PayeeName2_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel PayeeSnm_Label;
        private TNedit PayeeCode_tNedit;
        private Infragistics.Win.Misc.UltraLabel TtlBalanceAdjust_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel SupplierName_Label;
        private Infragistics.Win.Misc.UltraLabel PayeeName_Label;
        private UiSetControl uiSetControl1;
        private TComboEditor SecCode_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel SecInfo_Tittle_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private TComboEditor TargetDiv_tComboEditor;
        private TNedit tNedit_SectionCode;
        private Infragistics.Win.Misc.UltraButton uButton_SectionGuide;
        private Infragistics.Win.Misc.UltraLabel SectionName_Label;
		private System.ComponentModel.IContainer components;

		# endregion

        // ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		# region Constructor

        /// <summary>
		/// 
		/// </summary>
		public MAKAU09130UA()
		{
			InitializeComponent();
		
			//�@��ƃR�[�h���擾����
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			
			// �ϐ�������
			this._targetData = TargetData.First;

            this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();

            this._controlScreenSkin = new ControlScreenSkin();  // 2009.01.14 Add

            // --- ADD 2012/09/18 ---------->>>>>
            #region ���I�v�V�������
            this.CacheOptionInfo();
            #endregion
            // --- ADD 2012/09/18 ----------<<<<<
        }
		# endregion 

		// ===================================================================================== //
		// �j��
		// ===================================================================================== //
		# region Dispose
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel2 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel3 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel4 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel5 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.UltraWinStatusBar.UltraStatusPanel ultraStatusPanel6 = new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�d���挟���K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Main_UltraToolbar");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("New_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool3 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Delete_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool4 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool5 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Close_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool6 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("New_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool7 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Delete_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool8 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Modify_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool9 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Details_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonTool1");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool10 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("AddUpDateBase_ControlContainerTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAKAU09130UA));
            this.AutoFillToFirstGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.AutoFillToSecondGridColumn_CheckEditor = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.Five_Grid_Panel = new System.Windows.Forms.Panel();
            this.Acc_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.First_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.Dmd_Grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.Second_StatusBar = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Close_Button = new Infragistics.Win.Misc.UltraButton();
            this.New_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Modify_Button = new Infragistics.Win.Misc.UltraButton();
            this.Details_Button = new Infragistics.Win.Misc.UltraButton();
            this.ViewButtonPanel = new System.Windows.Forms.Panel();
            this.Customer_Panel = new System.Windows.Forms.Panel();
            this.SectionName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.uButton_SectionGuide = new Infragistics.Win.Misc.UltraButton();
            this.SecCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SecInfo_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.TargetDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PayeeName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierName_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayeeName2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.PayeeSnm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PayeeCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.TotalDay_Tittle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TotalDay_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierName2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Supplier_Guide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SupplierSnm_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CustomerInfo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.cust_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Line2_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraTabControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.claim_panel = new System.Windows.Forms.Panel();
            this.TtlBalanceAdjust_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.TtlBlDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BlDmdTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlDepoDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlConsTaxDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlSalesDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlLMBlDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ttl2TmDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ttl3TmDmd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DepositTotalTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ConsTaxTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SalesTotalTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TtlLMTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ttl2TmTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Ttl3TmTitle_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tLine33 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine34 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine35 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine36 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine38 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine39 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine28 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine30 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine31 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine37 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine40 = new Broadleaf.Library.Windows.Forms.TLine();
            this.tLine42 = new Broadleaf.Library.Windows.Forms.TLine();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Close_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this._MAKAU09130UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsManager1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._MAKAU09130UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU09130UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraTabPageControl1.SuspendLayout();
            this.Five_Grid_Panel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.Acc_Grid ) ).BeginInit();
            this.First_StatusBar.SuspendLayout();
            this.ultraTabPageControl4.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.Dmd_Grid ) ).BeginInit();
            this.Second_StatusBar.SuspendLayout();
            this.ViewButtonPanel.SuspendLayout();
            this.Customer_Panel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SectionCode ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SecCode_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TargetDiv_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.PayeeCode_tNedit ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SupplierCode_tNedit ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraTabControl1 ) ).BeginInit();
            this.ultraTabControl1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.Bind_DataSet ) ).BeginInit();
            this.claim_panel.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine33 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine34 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine35 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine36 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine38 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine39 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine28 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine30 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine31 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine37 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine40 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine42 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraToolbarsManager1 ) ).BeginInit();
            this.SuspendLayout();
            // 
            // AutoFillToFirstGridColumn_CheckEditor
            // 
            appearance1.FontData.SizeInPoints = 9F;
            this.AutoFillToFirstGridColumn_CheckEditor.Appearance = appearance1;
            this.AutoFillToFirstGridColumn_CheckEditor.Checked = true;
            this.AutoFillToFirstGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToFirstGridColumn_CheckEditor.Location = new System.Drawing.Point(3, 4);
            this.AutoFillToFirstGridColumn_CheckEditor.Name = "AutoFillToFirstGridColumn_CheckEditor";
            this.AutoFillToFirstGridColumn_CheckEditor.Size = new System.Drawing.Size(138, 20);
            this.AutoFillToFirstGridColumn_CheckEditor.TabIndex = 10;
            this.AutoFillToFirstGridColumn_CheckEditor.Text = "��T�C�Y�̎�������";
            this.AutoFillToFirstGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToFirstGridColumn_CheckedChanged);
            // 
            // AutoFillToSecondGridColumn_CheckEditor
            // 
            appearance2.FontData.SizeInPoints = 9F;
            this.AutoFillToSecondGridColumn_CheckEditor.Appearance = appearance2;
            this.AutoFillToSecondGridColumn_CheckEditor.Checked = true;
            this.AutoFillToSecondGridColumn_CheckEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoFillToSecondGridColumn_CheckEditor.Location = new System.Drawing.Point(3, 4);
            this.AutoFillToSecondGridColumn_CheckEditor.Name = "AutoFillToSecondGridColumn_CheckEditor";
            this.AutoFillToSecondGridColumn_CheckEditor.Size = new System.Drawing.Size(138, 20);
            this.AutoFillToSecondGridColumn_CheckEditor.TabIndex = 10;
            this.AutoFillToSecondGridColumn_CheckEditor.Text = "��T�C�Y�̎�������";
            this.AutoFillToSecondGridColumn_CheckEditor.CheckedChanged += new System.EventHandler(this.AutoFillToSecondGridColumn_CheckedChanged);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.Five_Grid_Panel);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 32);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(928, 393);
            // 
            // Five_Grid_Panel
            // 
            this.Five_Grid_Panel.Controls.Add(this.Acc_Grid);
            this.Five_Grid_Panel.Controls.Add(this.First_StatusBar);
            this.Five_Grid_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Five_Grid_Panel.Location = new System.Drawing.Point(0, 0);
            this.Five_Grid_Panel.Name = "Five_Grid_Panel";
            this.Five_Grid_Panel.Size = new System.Drawing.Size(928, 393);
            this.Five_Grid_Panel.TabIndex = 11;
            // 
            // Acc_Grid
            // 
            this.Acc_Grid.Cursor = System.Windows.Forms.Cursors.Hand;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Acc_Grid.DisplayLayout.Appearance = appearance3;
            this.Acc_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.Acc_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Acc_Grid.DisplayLayout.InterBandSpacing = 10;
            this.Acc_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Acc_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Acc_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Acc_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Acc_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.Acc_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.Acc_Grid.DisplayLayout.Override.CardAreaAppearance = appearance4;
            this.Acc_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance5.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.TextHAlignAsString = "Left";
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Acc_Grid.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.Acc_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance6.BackColor = System.Drawing.Color.Lavender;
            this.Acc_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance6;
            appearance7.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 1 ) ) ) ), ( (int)( ( (byte)( 68 ) ) ) ), ( (int)( ( (byte)( 208 ) ) ) ));
            this.Acc_Grid.DisplayLayout.Override.RowAppearance = appearance7;
            this.Acc_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Acc_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance8.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance8.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.ForeColor = System.Drawing.Color.White;
            this.Acc_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance8;
            this.Acc_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Acc_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Acc_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance9.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance9.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.Acc_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance9;
            this.Acc_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Acc_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Acc_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Acc_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
            this.Acc_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Acc_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Acc_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Acc_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Acc_Grid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Acc_Grid.Location = new System.Drawing.Point(0, 0);
            this.Acc_Grid.Name = "Acc_Grid";
            this.Acc_Grid.Size = new System.Drawing.Size(928, 366);
            this.Acc_Grid.TabIndex = 6;
            this.Acc_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.Acc_Grid_AfterSelectChange);
            this.Acc_Grid.Enter += new System.EventHandler(this.Acc_Grid_Enter);
            this.Acc_Grid.AfterRowActivate += new System.EventHandler(this.Acc_Grid_AfterRowActivate);
            this.Acc_Grid.DoubleClick += new System.EventHandler(this.Acc_Grid_DoubleClick);
            this.Acc_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Acc_Grid_KeyDown);
            this.Acc_Grid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.Acc_Grid_AfterSortChange);
            this.Acc_Grid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.Acc_Grid_BeforeRowDeactivate);
            // 
            // First_StatusBar
            // 
            appearance10.FontData.SizeInPoints = 9F;
            this.First_StatusBar.Appearance = appearance10;
            this.First_StatusBar.Controls.Add(this.AutoFillToFirstGridColumn_CheckEditor);
            this.First_StatusBar.InterPanelSpacing = 5;
            this.First_StatusBar.Location = new System.Drawing.Point(0, 366);
            this.First_StatusBar.Name = "First_StatusBar";
            ultraStatusPanel1.Control = this.AutoFillToFirstGridColumn_CheckEditor;
            ultraStatusPanel1.Key = "AutoFillToFiveGridColumn_StatusPanel";
            ultraStatusPanel1.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel1.Width = 140;
            ultraStatusPanel2.Key = "Line1_StatusPanel";
            ultraStatusPanel2.Width = 1;
            appearance11.TextHAlignAsString = "Right";
            ultraStatusPanel3.Appearance = appearance11;
            ultraStatusPanel3.Key = "SearchCount_StatusPanel";
            ultraStatusPanel3.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel3.Text = "��";
            ultraStatusPanel3.Width = 0;
            this.First_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel1,
            ultraStatusPanel2,
            ultraStatusPanel3});
            this.First_StatusBar.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.None;
            this.First_StatusBar.Size = new System.Drawing.Size(928, 27);
            this.First_StatusBar.TabIndex = 14;
            this.First_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.Dmd_Grid);
            this.ultraTabPageControl4.Controls.Add(this.Second_StatusBar);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(928, 393);
            // 
            // Dmd_Grid
            // 
            this.Dmd_Grid.Cursor = System.Windows.Forms.Cursors.Default;
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.Dmd_Grid.DisplayLayout.Appearance = appearance12;
            this.Dmd_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.Dmd_Grid.DisplayLayout.GroupByBox.Hidden = true;
            this.Dmd_Grid.DisplayLayout.InterBandSpacing = 10;
            this.Dmd_Grid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Dmd_Grid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Synchronized;
            this.Dmd_Grid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Dmd_Grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.Dmd_Grid.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.Dmd_Grid.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.Color.Transparent;
            this.Dmd_Grid.DisplayLayout.Override.CardAreaAppearance = appearance13;
            this.Dmd_Grid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            appearance14.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance14.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.ForeColor = System.Drawing.Color.White;
            appearance14.TextHAlignAsString = "Left";
            appearance14.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Dmd_Grid.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.Dmd_Grid.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle;
            appearance15.BackColor = System.Drawing.Color.Lavender;
            this.Dmd_Grid.DisplayLayout.Override.RowAlternateAppearance = appearance15;
            appearance16.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 1 ) ) ) ), ( (int)( ( (byte)( 68 ) ) ) ), ( (int)( ( (byte)( 208 ) ) ) ));
            this.Dmd_Grid.DisplayLayout.Override.RowAppearance = appearance16;
            this.Dmd_Grid.DisplayLayout.Override.RowFilterAction = Infragistics.Win.UltraWinGrid.RowFilterAction.HideFilteredOutRows;
            this.Dmd_Grid.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand;
            appearance17.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 89 ) ) ) ), ( (int)( ( (byte)( 135 ) ) ) ), ( (int)( ( (byte)( 214 ) ) ) ));
            appearance17.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 7 ) ) ) ), ( (int)( ( (byte)( 59 ) ) ) ), ( (int)( ( (byte)( 150 ) ) ) ));
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.ForeColor = System.Drawing.Color.White;
            this.Dmd_Grid.DisplayLayout.Override.RowSelectorAppearance = appearance17;
            this.Dmd_Grid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            this.Dmd_Grid.DisplayLayout.Override.RowSelectorWidth = 12;
            this.Dmd_Grid.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed;
            appearance18.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 251 ) ) ) ), ( (int)( ( (byte)( 230 ) ) ) ), ( (int)( ( (byte)( 148 ) ) ) ));
            appearance18.BackColor2 = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 238 ) ) ) ), ( (int)( ( (byte)( 149 ) ) ) ), ( (int)( ( (byte)( 21 ) ) ) ));
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.ForeColor = System.Drawing.Color.Black;
            this.Dmd_Grid.DisplayLayout.Override.SelectedRowAppearance = appearance18;
            this.Dmd_Grid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Dmd_Grid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Dmd_Grid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;
            this.Dmd_Grid.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 168 ) ) ) ), ( (int)( ( (byte)( 167 ) ) ) ), ( (int)( ( (byte)( 191 ) ) ) ));
            this.Dmd_Grid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Dmd_Grid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Dmd_Grid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Dmd_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dmd_Grid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Dmd_Grid.Location = new System.Drawing.Point(0, 0);
            this.Dmd_Grid.Name = "Dmd_Grid";
            this.Dmd_Grid.Size = new System.Drawing.Size(928, 366);
            this.Dmd_Grid.TabIndex = 14;
            this.Dmd_Grid.AfterSelectChange += new Infragistics.Win.UltraWinGrid.AfterSelectChangeEventHandler(this.Acc_Grid_AfterSelectChange);
            this.Dmd_Grid.Enter += new System.EventHandler(this.Dmd_Grid_Enter);
            this.Dmd_Grid.AfterRowActivate += new System.EventHandler(this.Acc_Grid_AfterRowActivate);
            this.Dmd_Grid.DoubleClick += new System.EventHandler(this.Acc_Grid_DoubleClick);
            this.Dmd_Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Acc_Grid_KeyDown);
            this.Dmd_Grid.AfterSortChange += new Infragistics.Win.UltraWinGrid.BandEventHandler(this.Acc_Grid_AfterSortChange);
            this.Dmd_Grid.BeforeRowDeactivate += new System.ComponentModel.CancelEventHandler(this.Acc_Grid_BeforeRowDeactivate);
            // 
            // Second_StatusBar
            // 
            appearance19.FontData.SizeInPoints = 9F;
            this.Second_StatusBar.Appearance = appearance19;
            this.Second_StatusBar.Controls.Add(this.AutoFillToSecondGridColumn_CheckEditor);
            this.Second_StatusBar.InterPanelSpacing = 5;
            this.Second_StatusBar.Location = new System.Drawing.Point(0, 366);
            this.Second_StatusBar.Name = "Second_StatusBar";
            ultraStatusPanel4.Control = this.AutoFillToSecondGridColumn_CheckEditor;
            ultraStatusPanel4.Key = "AutoFillToFiveGridColumn_StatusPanel";
            ultraStatusPanel4.Style = Infragistics.Win.UltraWinStatusBar.PanelStyle.ControlContainer;
            ultraStatusPanel4.Width = 140;
            ultraStatusPanel5.Key = "Line1_StatusPanel";
            ultraStatusPanel5.Width = 1;
            appearance20.TextHAlignAsString = "Right";
            ultraStatusPanel6.Appearance = appearance20;
            ultraStatusPanel6.Key = "SearchCount_StatusPanel";
            ultraStatusPanel6.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Spring;
            ultraStatusPanel6.Text = "��";
            ultraStatusPanel6.Width = 0;
            this.Second_StatusBar.Panels.AddRange(new Infragistics.Win.UltraWinStatusBar.UltraStatusPanel[] {
            ultraStatusPanel4,
            ultraStatusPanel5,
            ultraStatusPanel6});
            this.Second_StatusBar.ResizeStyle = Infragistics.Win.UltraWinStatusBar.ResizeStyle.None;
            this.Second_StatusBar.Size = new System.Drawing.Size(928, 27);
            this.Second_StatusBar.TabIndex = 13;
            this.Second_StatusBar.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Close_Button
            // 
            this.Close_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Close_Button.Location = new System.Drawing.Point(3, 3);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(90, 27);
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Text = "����(&C)";
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // New_Button
            // 
            this.New_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.New_Button.Location = new System.Drawing.Point(188, 3);
            this.New_Button.Name = "New_Button";
            this.New_Button.Size = new System.Drawing.Size(75, 27);
            this.New_Button.TabIndex = 3;
            this.New_Button.TabStop = false;
            this.New_Button.Text = "�V�K(&N)";
            this.New_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.New_Button.Click += new System.EventHandler(this.New_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Delete_Button.Location = new System.Drawing.Point(170, 0);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(75, 27);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.TabStop = false;
            this.Delete_Button.Text = "�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // Modify_Button
            // 
            this.Modify_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Modify_Button.Location = new System.Drawing.Point(263, 3);
            this.Modify_Button.Name = "Modify_Button";
            this.Modify_Button.Size = new System.Drawing.Size(75, 27);
            this.Modify_Button.TabIndex = 5;
            this.Modify_Button.TabStop = false;
            this.Modify_Button.Text = "�C��(&E)";
            this.Modify_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Modify_Button.Click += new System.EventHandler(this.Modify_Button_Click);
            // 
            // Details_Button
            // 
            this.Details_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Details_Button.Location = new System.Drawing.Point(107, 3);
            this.Details_Button.Name = "Details_Button";
            this.Details_Button.Size = new System.Drawing.Size(75, 27);
            this.Details_Button.TabIndex = 9;
            this.Details_Button.Text = "�ڍ�(&T)";
            this.Details_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Details_Button.Click += new System.EventHandler(this.Details_Button_Click);
            // 
            // ViewButtonPanel
            // 
            this.ViewButtonPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.ViewButtonPanel.Controls.Add(this.Details_Button);
            this.ViewButtonPanel.Controls.Add(this.Delete_Button);
            this.ViewButtonPanel.Controls.Add(this.New_Button);
            this.ViewButtonPanel.Controls.Add(this.Modify_Button);
            this.ViewButtonPanel.Controls.Add(this.Close_Button);
            this.ViewButtonPanel.Location = new System.Drawing.Point(292, 8);
            this.ViewButtonPanel.Name = "ViewButtonPanel";
            this.ViewButtonPanel.Size = new System.Drawing.Size(488, 40);
            this.ViewButtonPanel.TabIndex = 2;
            this.ViewButtonPanel.Visible = false;
            // 
            // Customer_Panel
            // 
            this.Customer_Panel.Controls.Add(this.SectionName_Label);
            this.Customer_Panel.Controls.Add(this.tNedit_SectionCode);
            this.Customer_Panel.Controls.Add(this.uButton_SectionGuide);
            this.Customer_Panel.Controls.Add(this.SecCode_tComboEditor);
            this.Customer_Panel.Controls.Add(this.SecInfo_Tittle_Label);
            this.Customer_Panel.Controls.Add(this.ultraLabel4);
            this.Customer_Panel.Controls.Add(this.TargetDiv_tComboEditor);
            this.Customer_Panel.Controls.Add(this.PayeeName_Label);
            this.Customer_Panel.Controls.Add(this.SupplierName_Label);
            this.Customer_Panel.Controls.Add(this.PayeeName2_Label);
            this.Customer_Panel.Controls.Add(this.ultraLabel2);
            this.Customer_Panel.Controls.Add(this.PayeeSnm_Label);
            this.Customer_Panel.Controls.Add(this.PayeeCode_tNedit);
            this.Customer_Panel.Controls.Add(this.ultraLabel6);
            this.Customer_Panel.Controls.Add(this.TotalDay_Tittle_Label);
            this.Customer_Panel.Controls.Add(this.TotalDay_Label);
            this.Customer_Panel.Controls.Add(this.SupplierCode_tNedit);
            this.Customer_Panel.Controls.Add(this.SupplierName2_Label);
            this.Customer_Panel.Controls.Add(this.Supplier_Guide_Button);
            this.Customer_Panel.Controls.Add(this.SupplierSnm_Label);
            this.Customer_Panel.Controls.Add(this.CustomerInfo_Label);
            this.Customer_Panel.Controls.Add(this.cust_Label);
            this.Customer_Panel.Controls.Add(this.Line2_Label);
            this.Customer_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Customer_Panel.Location = new System.Drawing.Point(0, 29);
            this.Customer_Panel.Name = "Customer_Panel";
            this.Customer_Panel.Size = new System.Drawing.Size(930, 145);
            this.Customer_Panel.TabIndex = 370;
            // 
            // SectionName_Label
            // 
            appearance34.BackColor = System.Drawing.Color.Gainsboro;
            appearance34.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextVAlignAsString = "Middle";
            this.SectionName_Label.Appearance = appearance34;
            this.SectionName_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.SectionName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SectionName_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SectionName_Label.Location = new System.Drawing.Point(130, 56);
            this.SectionName_Label.Name = "SectionName_Label";
            this.SectionName_Label.Size = new System.Drawing.Size(323, 24);
            this.SectionName_Label.TabIndex = 1383;
            // 
            // tNedit_SectionCode
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.TextHAlignAsString = "Right";
            appearance48.TextVAlignAsString = "Middle";
            this.tNedit_SectionCode.ActiveAppearance = appearance48;
            appearance75.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColor = System.Drawing.Color.Black;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            appearance75.TextHAlignAsString = "Right";
            appearance75.TextVAlignAsString = "Middle";
            this.tNedit_SectionCode.Appearance = appearance75;
            this.tNedit_SectionCode.AutoSelect = true;
            this.tNedit_SectionCode.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tNedit_SectionCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SectionCode.DataText = "";
            this.tNedit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_SectionCode.Location = new System.Drawing.Point(98, 56);
            this.tNedit_SectionCode.MaxLength = 2;
            this.tNedit_SectionCode.Name = "tNedit_SectionCode";
            this.tNedit_SectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SectionCode.Size = new System.Drawing.Size(28, 24);
            this.tNedit_SectionCode.TabIndex = 1380;
            this.tNedit_SectionCode.ValueChanged += new System.EventHandler(this.tNedit_SectionCode_ValueChanged);
            this.tNedit_SectionCode.Leave += new System.EventHandler(this.tNedit_SectionCode_Leave);
            // 
            // uButton_SectionGuide
            // 
            this.uButton_SectionGuide.Location = new System.Drawing.Point(455, 56);
            this.uButton_SectionGuide.Name = "uButton_SectionGuide";
            this.uButton_SectionGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_SectionGuide.TabIndex = 1381;
            this.uButton_SectionGuide.Click += new System.EventHandler(this.uButton_SectionGuide_Click);
            // 
            // SecCode_tComboEditor
            // 
            this.SecCode_tComboEditor.ActiveAppearance = appearance63;
            appearance64.ForeColor = System.Drawing.Color.Black;
            appearance64.ForeColorDisabled = System.Drawing.Color.Black;
            this.SecCode_tComboEditor.Appearance = appearance64;
            this.SecCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SecCode_tComboEditor.Location = new System.Drawing.Point(280, 28);
            this.SecCode_tComboEditor.Name = "SecCode_tComboEditor";
            this.SecCode_tComboEditor.Size = new System.Drawing.Size(244, 24);
            this.SecCode_tComboEditor.TabIndex = 382;
            this.SecCode_tComboEditor.Visible = false;
            // 
            // SecInfo_Tittle_Label
            // 
            appearance65.BackColor = System.Drawing.Color.Transparent;
            appearance65.TextVAlignAsString = "Middle";
            this.SecInfo_Tittle_Label.Appearance = appearance65;
            this.SecInfo_Tittle_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SecInfo_Tittle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SecInfo_Tittle_Label.Location = new System.Drawing.Point(8, 56);
            this.SecInfo_Tittle_Label.Name = "SecInfo_Tittle_Label";
            this.SecInfo_Tittle_Label.Size = new System.Drawing.Size(84, 24);
            this.SecInfo_Tittle_Label.TabIndex = 383;
            this.SecInfo_Tittle_Label.Text = "���_";
            // 
            // ultraLabel4
            // 
            appearance37.BackColor = System.Drawing.Color.Transparent;
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance37;
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ultraLabel4.Location = new System.Drawing.Point(8, 30);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(84, 24);
            this.ultraLabel4.TabIndex = 381;
            this.ultraLabel4.Text = "�w��敪";
            // 
            // TargetDiv_tComboEditor
            // 
            this.TargetDiv_tComboEditor.ActiveAppearance = appearance38;
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            this.TargetDiv_tComboEditor.Appearance = appearance39;
            this.TargetDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            valueListItem1.DisplayText = "�x����";
            valueListItem2.DataValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            valueListItem2.DisplayText = "�d����";
            this.TargetDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.TargetDiv_tComboEditor.Location = new System.Drawing.Point(98, 30);
            this.TargetDiv_tComboEditor.Name = "TargetDiv_tComboEditor";
            this.TargetDiv_tComboEditor.Size = new System.Drawing.Size(104, 24);
            this.TargetDiv_tComboEditor.TabIndex = 380;
            this.TargetDiv_tComboEditor.ValueChanged += new System.EventHandler(this.TargetDiv_tComboEditor_ValueChanged);
            // 
            // PayeeName_Label
            // 
            appearance40.BackColor = System.Drawing.SystemColors.Control;
            appearance40.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.PayeeName_Label.Appearance = appearance40;
            this.PayeeName_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.PayeeName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.PayeeName_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.PayeeName_Label.Location = new System.Drawing.Point(714, 61);
            this.PayeeName_Label.Name = "PayeeName_Label";
            this.PayeeName_Label.Size = new System.Drawing.Size(21, 24);
            this.PayeeName_Label.TabIndex = 377;
            this.PayeeName_Label.Visible = false;
            // 
            // SupplierName_Label
            // 
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextVAlignAsString = "Middle";
            this.SupplierName_Label.Appearance = appearance22;
            this.SupplierName_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.SupplierName_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SupplierName_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SupplierName_Label.Location = new System.Drawing.Point(714, 28);
            this.SupplierName_Label.Name = "SupplierName_Label";
            this.SupplierName_Label.Size = new System.Drawing.Size(22, 24);
            this.SupplierName_Label.TabIndex = 376;
            this.SupplierName_Label.Visible = false;
            // 
            // PayeeName2_Label
            // 
            appearance23.BackColor = System.Drawing.SystemColors.Control;
            appearance23.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.PayeeName2_Label.Appearance = appearance23;
            this.PayeeName2_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.PayeeName2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.PayeeName2_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.PayeeName2_Label.Location = new System.Drawing.Point(742, 61);
            this.PayeeName2_Label.Name = "PayeeName2_Label";
            this.PayeeName2_Label.Size = new System.Drawing.Size(21, 24);
            this.PayeeName2_Label.TabIndex = 375;
            this.PayeeName2_Label.Visible = false;
            // 
            // ultraLabel2
            // 
            appearance24.BackColor = System.Drawing.Color.Transparent;
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance24;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ultraLabel2.Location = new System.Drawing.Point(188, 114);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(64, 24);
            this.ultraLabel2.TabIndex = 374;
            this.ultraLabel2.Text = "�x����";
            this.ultraLabel2.Visible = false;
            // 
            // PayeeSnm_Label
            // 
            appearance25.BackColor = System.Drawing.Color.Gainsboro;
            appearance25.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.PayeeSnm_Label.Appearance = appearance25;
            this.PayeeSnm_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.PayeeSnm_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.PayeeSnm_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.PayeeSnm_Label.Location = new System.Drawing.Point(368, 114);
            this.PayeeSnm_Label.Name = "PayeeSnm_Label";
            this.PayeeSnm_Label.Size = new System.Drawing.Size(472, 24);
            this.PayeeSnm_Label.TabIndex = 373;
            this.PayeeSnm_Label.Visible = false;
            // 
            // PayeeCode_tNedit
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Right";
            this.PayeeCode_tNedit.ActiveAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Right";
            this.PayeeCode_tNedit.Appearance = appearance27;
            this.PayeeCode_tNedit.AutoSelect = true;
            this.PayeeCode_tNedit.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.PayeeCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PayeeCode_tNedit.DataText = "";
            this.PayeeCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PayeeCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PayeeCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PayeeCode_tNedit.Location = new System.Drawing.Point(260, 114);
            this.PayeeCode_tNedit.MaxLength = 9;
            this.PayeeCode_tNedit.Name = "PayeeCode_tNedit";
            this.PayeeCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PayeeCode_tNedit.ReadOnly = true;
            this.PayeeCode_tNedit.Size = new System.Drawing.Size(84, 24);
            this.PayeeCode_tNedit.TabIndex = 372;
            this.PayeeCode_tNedit.Visible = false;
            // 
            // ultraLabel6
            // 
            appearance28.TextHAlignAsString = "Center";
            appearance28.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance28;
            this.ultraLabel6.Location = new System.Drawing.Point(131, 110);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(28, 24);
            this.ultraLabel6.TabIndex = 5;
            this.ultraLabel6.Text = "��";
            // 
            // TotalDay_Tittle_Label
            // 
            appearance29.TextHAlignAsString = "Left";
            appearance29.TextVAlignAsString = "Middle";
            this.TotalDay_Tittle_Label.Appearance = appearance29;
            this.TotalDay_Tittle_Label.Location = new System.Drawing.Point(8, 108);
            this.TotalDay_Tittle_Label.Name = "TotalDay_Tittle_Label";
            this.TotalDay_Tittle_Label.Size = new System.Drawing.Size(63, 24);
            this.TotalDay_Tittle_Label.TabIndex = 363;
            this.TotalDay_Tittle_Label.Text = "����";
            // 
            // TotalDay_Label
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 224 ) ) ) ), ( (int)( ( (byte)( 224 ) ) ) ), ( (int)( ( (byte)( 224 ) ) ) ));
            appearance30.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance30.TextHAlignAsString = "Right";
            appearance30.TextVAlignAsString = "Middle";
            this.TotalDay_Label.Appearance = appearance30;
            this.TotalDay_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.TotalDay_Label.Location = new System.Drawing.Point(98, 108);
            this.TotalDay_Label.Name = "TotalDay_Label";
            this.TotalDay_Label.Size = new System.Drawing.Size(32, 24);
            this.TotalDay_Label.TabIndex = 4;
            // 
            // SupplierCode_tNedit
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            appearance31.TextHAlignAsString = "Right";
            this.SupplierCode_tNedit.ActiveAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Right";
            this.SupplierCode_tNedit.Appearance = appearance32;
            this.SupplierCode_tNedit.AutoSelect = true;
            this.SupplierCode_tNedit.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.SupplierCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierCode_tNedit.DataText = "";
            this.SupplierCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SupplierCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.SupplierCode_tNedit.Location = new System.Drawing.Point(98, 82);
            this.SupplierCode_tNedit.MaxLength = 6;
            this.SupplierCode_tNedit.Name = "SupplierCode_tNedit";
            this.SupplierCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.SupplierCode_tNedit.Size = new System.Drawing.Size(60, 24);
            this.SupplierCode_tNedit.TabIndex = 1;
            this.SupplierCode_tNedit.ValueChanged += new System.EventHandler(this.SupplierCode_tNedit_ValueChanged);
            this.SupplierCode_tNedit.Leave += new System.EventHandler(this.SupplierCode_tNedit_Leave);
            this.SupplierCode_tNedit.Enter += new System.EventHandler(this.SupplierCode_tNedit_Enter);
            // 
            // SupplierName2_Label
            // 
            appearance33.BackColor = System.Drawing.SystemColors.Control;
            appearance33.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            appearance33.TextVAlignAsString = "Middle";
            this.SupplierName2_Label.Appearance = appearance33;
            this.SupplierName2_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.SupplierName2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SupplierName2_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SupplierName2_Label.Location = new System.Drawing.Point(742, 28);
            this.SupplierName2_Label.Name = "SupplierName2_Label";
            this.SupplierName2_Label.Size = new System.Drawing.Size(23, 24);
            this.SupplierName2_Label.TabIndex = 6;
            this.SupplierName2_Label.Visible = false;
            // 
            // Supplier_Guide_Button
            // 
            this.Supplier_Guide_Button.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.Supplier_Guide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Supplier_Guide_Button.Location = new System.Drawing.Point(487, 82);
            this.Supplier_Guide_Button.Name = "Supplier_Guide_Button";
            this.Supplier_Guide_Button.Size = new System.Drawing.Size(24, 24);
            this.Supplier_Guide_Button.TabIndex = 2;
            this.Supplier_Guide_Button.Text = "?";
            ultraToolTipInfo1.ToolTipText = "�d���挟���K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.Supplier_Guide_Button, ultraToolTipInfo1);
            this.Supplier_Guide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Supplier_Guide_Button.Click += new System.EventHandler(this.Customer_Guide_Button_Click);
            // 
            // SupplierSnm_Label
            // 
            appearance68.BackColor = System.Drawing.Color.Gainsboro;
            appearance68.BorderColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 127 ) ) ) ), ( (int)( ( (byte)( 157 ) ) ) ), ( (int)( ( (byte)( 185 ) ) ) ));
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            appearance68.TextVAlignAsString = "Middle";
            this.SupplierSnm_Label.Appearance = appearance68;
            this.SupplierSnm_Label.BackColorInternal = System.Drawing.Color.GhostWhite;
            this.SupplierSnm_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.SupplierSnm_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SupplierSnm_Label.Location = new System.Drawing.Point(162, 82);
            this.SupplierSnm_Label.Name = "SupplierSnm_Label";
            this.SupplierSnm_Label.Size = new System.Drawing.Size(323, 24);
            this.SupplierSnm_Label.TabIndex = 3;
            // 
            // CustomerInfo_Label
            // 
            appearance35.BackColor = System.Drawing.Color.Transparent;
            appearance35.TextVAlignAsString = "Middle";
            this.CustomerInfo_Label.Appearance = appearance35;
            this.CustomerInfo_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.CustomerInfo_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.CustomerInfo_Label.Location = new System.Drawing.Point(8, 82);
            this.CustomerInfo_Label.Name = "CustomerInfo_Label";
            this.CustomerInfo_Label.Size = new System.Drawing.Size(63, 24);
            this.CustomerInfo_Label.TabIndex = 357;
            this.CustomerInfo_Label.Text = "�d����";
            // 
            // cust_Label
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance36.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance36.BorderColor = System.Drawing.Color.Black;
            appearance36.TextHAlignAsString = "Center";
            appearance36.TextVAlignAsString = "Middle";
            this.cust_Label.Appearance = appearance36;
            this.cust_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 198 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.cust_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cust_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.cust_Label.Location = new System.Drawing.Point(0, 0);
            this.cust_Label.Name = "cust_Label";
            this.cust_Label.Size = new System.Drawing.Size(244, 24);
            this.cust_Label.TabIndex = 371;
            this.cust_Label.Text = "�d������";
            // 
            // Line2_Label
            // 
            this.Line2_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Line2_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.Line2_Label.Location = new System.Drawing.Point(0, 171);
            this.Line2_Label.Name = "Line2_Label";
            this.Line2_Label.Size = new System.Drawing.Size(986, 3);
            this.Line2_Label.TabIndex = 359;
            // 
            // ultraTabControl1
            // 
            appearance41.BackColor = System.Drawing.Color.LightPink;
            appearance41.BackColor2 = System.Drawing.Color.White;
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance41.ForeColor = System.Drawing.Color.Black;
            this.ultraTabControl1.ActiveTabAppearance = appearance41;
            this.ultraTabControl1.Controls.Add(this.ultraTabSharedControlsPage2);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl4);
            this.ultraTabControl1.Controls.Add(this.ultraTabPageControl1);
            this.ultraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraTabControl1.ImageSize = new System.Drawing.Size(24, 24);
            this.ultraTabControl1.InterTabSpacing = new Infragistics.Win.DefaultableInteger(1);
            this.ultraTabControl1.Location = new System.Drawing.Point(0, 174);
            this.ultraTabControl1.Name = "ultraTabControl1";
            this.ultraTabControl1.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.ultraTabControl1.Size = new System.Drawing.Size(930, 426);
            this.ultraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
            this.ultraTabControl1.TabIndex = 30;
            this.ultraTabControl1.TabPadding = new System.Drawing.Size(3, 3);
            appearance42.BackColor = System.Drawing.Color.White;
            appearance42.BackColor2 = System.Drawing.Color.LightPink;
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab1.ActiveAppearance = appearance42;
            appearance43.BackColor = System.Drawing.Color.White;
            appearance43.BackColor2 = System.Drawing.Color.Lavender;
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab1.Appearance = appearance43;
            ultraTab1.Key = "campanyTab";
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "���|�ݒ�";
            appearance44.BackColor = System.Drawing.Color.White;
            appearance44.BackColor2 = System.Drawing.Color.LightPink;
            appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab2.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.White;
            appearance45.BackColor2 = System.Drawing.Color.Lavender;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ultraTab2.Appearance = appearance45;
            ultraTab2.Key = "customerTab";
            ultraTab2.TabPage = this.ultraTabPageControl4;
            ultraTab2.Text = "�x���ݒ�";
            this.ultraTabControl1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.ultraTabControl1.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
            this.ultraTabControl1.Click += new System.EventHandler(this.ultraTabControl1_Click);
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(928, 393);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // claim_panel
            // 
            this.claim_panel.Controls.Add(this.TtlBalanceAdjust_Label);
            this.claim_panel.Controls.Add(this.ultraLabel1);
            this.claim_panel.Controls.Add(this.TtlBlDmd_Label);
            this.claim_panel.Controls.Add(this.BlDmdTitle_Label);
            this.claim_panel.Controls.Add(this.TtlDepoDmd_Label);
            this.claim_panel.Controls.Add(this.TtlConsTaxDmd_Label);
            this.claim_panel.Controls.Add(this.TtlSalesDmd_Label);
            this.claim_panel.Controls.Add(this.TtlLMBlDmd_Label);
            this.claim_panel.Controls.Add(this.Ttl2TmDmd_Label);
            this.claim_panel.Controls.Add(this.Ttl3TmDmd_Label);
            this.claim_panel.Controls.Add(this.DepositTotalTitle_Label);
            this.claim_panel.Controls.Add(this.ConsTaxTitle_Label);
            this.claim_panel.Controls.Add(this.SalesTotalTitle_Label);
            this.claim_panel.Controls.Add(this.TtlLMTitle_Label);
            this.claim_panel.Controls.Add(this.Ttl2TmTitle_Label);
            this.claim_panel.Controls.Add(this.Ttl3TmTitle_Label);
            this.claim_panel.Controls.Add(this.tLine33);
            this.claim_panel.Controls.Add(this.tLine34);
            this.claim_panel.Controls.Add(this.tLine35);
            this.claim_panel.Controls.Add(this.tLine36);
            this.claim_panel.Controls.Add(this.tLine38);
            this.claim_panel.Controls.Add(this.tLine39);
            this.claim_panel.Controls.Add(this.tLine28);
            this.claim_panel.Controls.Add(this.tLine30);
            this.claim_panel.Controls.Add(this.tLine31);
            this.claim_panel.Controls.Add(this.tLine37);
            this.claim_panel.Controls.Add(this.tLine40);
            this.claim_panel.Controls.Add(this.tLine42);
            this.claim_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.claim_panel.Location = new System.Drawing.Point(0, 600);
            this.claim_panel.Name = "claim_panel";
            this.claim_panel.Size = new System.Drawing.Size(930, 70);
            this.claim_panel.TabIndex = 389;
            this.claim_panel.Visible = false;
            // 
            // TtlBalanceAdjust_Label
            // 
            appearance46.TextHAlignAsString = "Right";
            appearance46.TextVAlignAsString = "Middle";
            this.TtlBalanceAdjust_Label.Appearance = appearance46;
            this.TtlBalanceAdjust_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlBalanceAdjust_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlBalanceAdjust_Label.Location = new System.Drawing.Point(570, 29);
            this.TtlBalanceAdjust_Label.Name = "TtlBalanceAdjust_Label";
            this.TtlBalanceAdjust_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlBalanceAdjust_Label.TabIndex = 183;
            // 
            // ultraLabel1
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance66.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance66.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance66.TextHAlignAsString = "Center";
            appearance66.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance66;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ultraLabel1.Location = new System.Drawing.Point(570, 5);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(93, 23);
            this.ultraLabel1.TabIndex = 182;
            this.ultraLabel1.Text = "�c������";
            // 
            // TtlBlDmd_Label
            // 
            appearance67.TextHAlignAsString = "Right";
            appearance67.TextVAlignAsString = "Middle";
            this.TtlBlDmd_Label.Appearance = appearance67;
            this.TtlBlDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlBlDmd_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlBlDmd_Label.Location = new System.Drawing.Point(664, 29);
            this.TtlBlDmd_Label.Name = "TtlBlDmd_Label";
            this.TtlBlDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlBlDmd_Label.TabIndex = 167;
            this.TtlBlDmd_Label.Text = "012345678901";
            // 
            // BlDmdTitle_Label
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance49.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance49.TextHAlignAsString = "Center";
            appearance49.TextVAlignAsString = "Middle";
            this.BlDmdTitle_Label.Appearance = appearance49;
            this.BlDmdTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.BlDmdTitle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.BlDmdTitle_Label.Location = new System.Drawing.Point(664, 5);
            this.BlDmdTitle_Label.Name = "BlDmdTitle_Label";
            this.BlDmdTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.BlDmdTitle_Label.TabIndex = 142;
            this.BlDmdTitle_Label.Text = "���|�c��";
            // 
            // TtlDepoDmd_Label
            // 
            appearance50.TextHAlignAsString = "Right";
            appearance50.TextVAlignAsString = "Middle";
            this.TtlDepoDmd_Label.Appearance = appearance50;
            this.TtlDepoDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlDepoDmd_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlDepoDmd_Label.Location = new System.Drawing.Point(475, 29);
            this.TtlDepoDmd_Label.Name = "TtlDepoDmd_Label";
            this.TtlDepoDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlDepoDmd_Label.TabIndex = 165;
            this.TtlDepoDmd_Label.Text = "-123456789012";
            // 
            // TtlConsTaxDmd_Label
            // 
            appearance51.TextHAlignAsString = "Right";
            appearance51.TextVAlignAsString = "Middle";
            this.TtlConsTaxDmd_Label.Appearance = appearance51;
            this.TtlConsTaxDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlConsTaxDmd_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlConsTaxDmd_Label.Location = new System.Drawing.Point(381, 29);
            this.TtlConsTaxDmd_Label.Name = "TtlConsTaxDmd_Label";
            this.TtlConsTaxDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlConsTaxDmd_Label.TabIndex = 163;
            // 
            // TtlSalesDmd_Label
            // 
            appearance52.TextHAlignAsString = "Right";
            appearance52.TextVAlignAsString = "Middle";
            this.TtlSalesDmd_Label.Appearance = appearance52;
            this.TtlSalesDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlSalesDmd_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlSalesDmd_Label.Location = new System.Drawing.Point(286, 29);
            this.TtlSalesDmd_Label.Name = "TtlSalesDmd_Label";
            this.TtlSalesDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlSalesDmd_Label.TabIndex = 161;
            // 
            // TtlLMBlDmd_Label
            // 
            appearance53.TextHAlignAsString = "Right";
            appearance53.TextVAlignAsString = "Middle";
            this.TtlLMBlDmd_Label.Appearance = appearance53;
            this.TtlLMBlDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.TtlLMBlDmd_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlLMBlDmd_Label.Location = new System.Drawing.Point(191, 29);
            this.TtlLMBlDmd_Label.Name = "TtlLMBlDmd_Label";
            this.TtlLMBlDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlLMBlDmd_Label.TabIndex = 159;
            // 
            // Ttl2TmDmd_Label
            // 
            appearance54.TextHAlignAsString = "Right";
            appearance54.TextVAlignAsString = "Middle";
            this.Ttl2TmDmd_Label.Appearance = appearance54;
            this.Ttl2TmDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.Ttl2TmDmd_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Ttl2TmDmd_Label.Location = new System.Drawing.Point(97, 29);
            this.Ttl2TmDmd_Label.Name = "Ttl2TmDmd_Label";
            this.Ttl2TmDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.Ttl2TmDmd_Label.TabIndex = 157;
            // 
            // Ttl3TmDmd_Label
            // 
            appearance55.TextHAlignAsString = "Right";
            appearance55.TextVAlignAsString = "Middle";
            this.Ttl3TmDmd_Label.Appearance = appearance55;
            this.Ttl3TmDmd_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 250 ) ) ) ), ( (int)( ( (byte)( 240 ) ) ) ), ( (int)( ( (byte)( 210 ) ) ) ));
            this.Ttl3TmDmd_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Ttl3TmDmd_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.Ttl3TmDmd_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Ttl3TmDmd_Label.Location = new System.Drawing.Point(3, 29);
            this.Ttl3TmDmd_Label.Name = "Ttl3TmDmd_Label";
            this.Ttl3TmDmd_Label.Size = new System.Drawing.Size(93, 23);
            this.Ttl3TmDmd_Label.TabIndex = 155;
            // 
            // DepositTotalTitle_Label
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance56.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance56.TextHAlignAsString = "Center";
            appearance56.TextVAlignAsString = "Middle";
            this.DepositTotalTitle_Label.Appearance = appearance56;
            this.DepositTotalTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.DepositTotalTitle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.DepositTotalTitle_Label.Location = new System.Drawing.Point(475, 5);
            this.DepositTotalTitle_Label.Name = "DepositTotalTitle_Label";
            this.DepositTotalTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.DepositTotalTitle_Label.TabIndex = 141;
            this.DepositTotalTitle_Label.Text = "����x��";
            // 
            // ConsTaxTitle_Label
            // 
            appearance57.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance57.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance57.TextHAlignAsString = "Center";
            appearance57.TextVAlignAsString = "Middle";
            this.ConsTaxTitle_Label.Appearance = appearance57;
            this.ConsTaxTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.ConsTaxTitle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ConsTaxTitle_Label.Location = new System.Drawing.Point(381, 5);
            this.ConsTaxTitle_Label.Name = "ConsTaxTitle_Label";
            this.ConsTaxTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.ConsTaxTitle_Label.TabIndex = 140;
            this.ConsTaxTitle_Label.Text = "�����";
            // 
            // SalesTotalTitle_Label
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance58.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance58.TextHAlignAsString = "Center";
            appearance58.TextVAlignAsString = "Middle";
            this.SalesTotalTitle_Label.Appearance = appearance58;
            this.SalesTotalTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.SalesTotalTitle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.SalesTotalTitle_Label.Location = new System.Drawing.Point(286, 5);
            this.SalesTotalTitle_Label.Name = "SalesTotalTitle_Label";
            this.SalesTotalTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.SalesTotalTitle_Label.TabIndex = 139;
            this.SalesTotalTitle_Label.Text = "����d��";
            // 
            // TtlLMTitle_Label
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance59.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance59.TextHAlignAsString = "Center";
            appearance59.TextVAlignAsString = "Middle";
            this.TtlLMTitle_Label.Appearance = appearance59;
            this.TtlLMTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.TtlLMTitle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.TtlLMTitle_Label.Location = new System.Drawing.Point(191, 5);
            this.TtlLMTitle_Label.Name = "TtlLMTitle_Label";
            this.TtlLMTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.TtlLMTitle_Label.TabIndex = 138;
            this.TtlLMTitle_Label.Text = "�O��c��";
            // 
            // Ttl2TmTitle_Label
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance60.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance60.TextHAlignAsString = "Center";
            appearance60.TextVAlignAsString = "Middle";
            this.Ttl2TmTitle_Label.Appearance = appearance60;
            this.Ttl2TmTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.Ttl2TmTitle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Ttl2TmTitle_Label.Location = new System.Drawing.Point(97, 5);
            this.Ttl2TmTitle_Label.Name = "Ttl2TmTitle_Label";
            this.Ttl2TmTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.Ttl2TmTitle_Label.TabIndex = 137;
            this.Ttl2TmTitle_Label.Text = "�O�X��c��";
            // 
            // Ttl3TmTitle_Label
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            appearance61.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.BorderColor = System.Drawing.Color.White;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.Ttl3TmTitle_Label.Appearance = appearance61;
            this.Ttl3TmTitle_Label.BackColorInternal = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 222 ) ) ) ), ( (int)( ( (byte)( 239 ) ) ) ), ( (int)( ( (byte)( 255 ) ) ) ));
            this.Ttl3TmTitle_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Ttl3TmTitle_Label.Location = new System.Drawing.Point(3, 5);
            this.Ttl3TmTitle_Label.Name = "Ttl3TmTitle_Label";
            this.Ttl3TmTitle_Label.Size = new System.Drawing.Size(93, 23);
            this.Ttl3TmTitle_Label.TabIndex = 136;
            this.Ttl3TmTitle_Label.Text = "�O�X�X��c��";
            // 
            // tLine33
            // 
            this.tLine33.BackColor = System.Drawing.Color.Transparent;
            this.tLine33.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine33.ForeColor = System.Drawing.Color.Black;
            this.tLine33.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine33.Location = new System.Drawing.Point(757, 4);
            this.tLine33.Name = "tLine33";
            this.tLine33.Size = new System.Drawing.Size(4, 49);
            this.tLine33.TabIndex = 153;
            this.tLine33.Text = "tLine14";
            // 
            // tLine34
            // 
            this.tLine34.BackColor = System.Drawing.Color.Transparent;
            this.tLine34.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine34.ForeColor = System.Drawing.Color.Black;
            this.tLine34.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine34.Location = new System.Drawing.Point(663, 4);
            this.tLine34.Name = "tLine34";
            this.tLine34.Size = new System.Drawing.Size(1, 49);
            this.tLine34.TabIndex = 152;
            this.tLine34.Text = "tLine13";
            // 
            // tLine35
            // 
            this.tLine35.BackColor = System.Drawing.Color.Transparent;
            this.tLine35.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine35.ForeColor = System.Drawing.Color.Black;
            this.tLine35.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine35.Location = new System.Drawing.Point(568, 4);
            this.tLine35.Name = "tLine35";
            this.tLine35.Size = new System.Drawing.Size(4, 49);
            this.tLine35.TabIndex = 151;
            this.tLine35.Text = "tLine12";
            // 
            // tLine36
            // 
            this.tLine36.BackColor = System.Drawing.Color.Transparent;
            this.tLine36.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine36.ForeColor = System.Drawing.Color.Black;
            this.tLine36.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine36.Location = new System.Drawing.Point(474, 4);
            this.tLine36.Name = "tLine36";
            this.tLine36.Size = new System.Drawing.Size(1, 49);
            this.tLine36.TabIndex = 150;
            this.tLine36.Text = "tLine11";
            // 
            // tLine38
            // 
            this.tLine38.BackColor = System.Drawing.Color.Transparent;
            this.tLine38.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine38.ForeColor = System.Drawing.Color.Black;
            this.tLine38.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine38.Location = new System.Drawing.Point(284, 4);
            this.tLine38.Name = "tLine38";
            this.tLine38.Size = new System.Drawing.Size(1, 49);
            this.tLine38.TabIndex = 148;
            this.tLine38.Text = "tLine9";
            // 
            // tLine39
            // 
            this.tLine39.BackColor = System.Drawing.Color.Transparent;
            this.tLine39.ForeColor = System.Drawing.Color.Black;
            this.tLine39.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine39.Location = new System.Drawing.Point(190, 4);
            this.tLine39.Name = "tLine39";
            this.tLine39.Size = new System.Drawing.Size(1, 49);
            this.tLine39.TabIndex = 147;
            this.tLine39.Text = "tLine8";
            // 
            // tLine28
            // 
            this.tLine28.BackColor = System.Drawing.Color.Transparent;
            this.tLine28.ForeColor = System.Drawing.Color.Black;
            this.tLine28.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine28.Location = new System.Drawing.Point(96, 4);
            this.tLine28.Name = "tLine28";
            this.tLine28.Size = new System.Drawing.Size(1, 49);
            this.tLine28.TabIndex = 173;
            this.tLine28.Text = "tLine1";
            // 
            // tLine30
            // 
            this.tLine30.BackColor = System.Drawing.Color.Transparent;
            this.tLine30.ForeColor = System.Drawing.Color.Black;
            this.tLine30.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine30.Location = new System.Drawing.Point(2, 4);
            this.tLine30.Name = "tLine30";
            this.tLine30.Size = new System.Drawing.Size(1, 49);
            this.tLine30.TabIndex = 171;
            this.tLine30.Text = "tLine20";
            // 
            // tLine31
            // 
            this.tLine31.BackColor = System.Drawing.Color.Transparent;
            this.tLine31.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine31.Location = new System.Drawing.Point(2, 4);
            this.tLine31.Name = "tLine31";
            this.tLine31.Size = new System.Drawing.Size(755, 4);
            this.tLine31.TabIndex = 170;
            this.tLine31.Text = "tLine19";
            // 
            // tLine37
            // 
            this.tLine37.BackColor = System.Drawing.Color.Transparent;
            this.tLine37.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine37.ForeColor = System.Drawing.Color.Black;
            this.tLine37.LineType = Broadleaf.Library.Windows.Forms.emLineType.ltVertical;
            this.tLine37.Location = new System.Drawing.Point(379, 5);
            this.tLine37.Name = "tLine37";
            this.tLine37.Size = new System.Drawing.Size(1, 49);
            this.tLine37.TabIndex = 149;
            this.tLine37.Text = "tLine10";
            // 
            // tLine40
            // 
            this.tLine40.BackColor = System.Drawing.Color.Transparent;
            this.tLine40.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine40.Location = new System.Drawing.Point(2, 52);
            this.tLine40.Name = "tLine40";
            this.tLine40.Size = new System.Drawing.Size(755, 4);
            this.tLine40.TabIndex = 146;
            this.tLine40.Text = "tLine7";
            // 
            // tLine42
            // 
            this.tLine42.BackColor = System.Drawing.Color.Transparent;
            this.tLine42.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.tLine42.Location = new System.Drawing.Point(3, 28);
            this.tLine42.Name = "tLine42";
            this.tLine42.Size = new System.Drawing.Size(755, 4);
            this.tLine42.TabIndex = 135;
            this.tLine42.Text = "tLine4";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 597);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(930, 3);
            this.splitter1.TabIndex = 390;
            this.splitter1.TabStop = false;
            // 
            // Close_Timer
            // 
            this.Close_Timer.Tick += new System.EventHandler(this.Close_Timer_Tick);
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
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // _MAKAU09130UA_Toolbars_Dock_Area_Right
            // 
            this._MAKAU09130UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU09130UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.GhostWhite;
            this._MAKAU09130UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._MAKAU09130UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU09130UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(930, 29);
            this._MAKAU09130UA_Toolbars_Dock_Area_Right.Name = "_MAKAU09130UA_Toolbars_Dock_Area_Right";
            this._MAKAU09130UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 641);
            this._MAKAU09130UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // ultraToolbarsManager1
            // 
            appearance62.BackColor = System.Drawing.Color.GhostWhite;
            this.ultraToolbarsManager1.Appearance = appearance62;
            this.ultraToolbarsManager1.DesignerFlags = 1;
            this.ultraToolbarsManager1.DockWithinContainer = this;
            this.ultraToolbarsManager1.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.ultraToolbarsManager1.LockToolbars = true;
            this.ultraToolbarsManager1.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.ultraToolbarsManager1.ShowFullMenusDelay = 500;
            this.ultraToolbarsManager1.ShowQuickCustomizeButton = false;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(2, 194);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(659, 50);
            ultraToolbar1.IsMainMenuBar = true;
            controlContainerTool1.ControlName = "Close_Button";
            controlContainerTool1.InstanceProps.Width = 92;
            controlContainerTool2.ControlName = "New_Button";
            controlContainerTool2.InstanceProps.Width = 77;
            controlContainerTool3.ControlName = "Delete_Button";
            controlContainerTool4.ControlName = "Modify_Button";
            controlContainerTool4.InstanceProps.Width = 77;
            labelTool1.InstanceProps.Width = 25;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool1,
            controlContainerTool2,
            controlContainerTool3,
            controlContainerTool4,
            labelTool1});
            ultraToolbar1.Text = "�W��";
            this.ultraToolbarsManager1.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            controlContainerTool5.ControlName = "Close_Button";
            controlContainerTool5.SharedProps.Caption = "Close_ControlContainerTool";
            controlContainerTool5.SharedProps.Width = 92;
            controlContainerTool6.ControlName = "New_Button";
            controlContainerTool6.SharedProps.Caption = "New_ControlContainerTool";
            controlContainerTool6.SharedProps.Width = 77;
            controlContainerTool7.ControlName = "Delete_Button";
            controlContainerTool7.SharedProps.Caption = "Delete_ControlContainerTool";
            controlContainerTool7.SharedProps.Visible = false;
            controlContainerTool8.ControlName = "Modify_Button";
            controlContainerTool8.SharedProps.Caption = "Modify_ControlContainerTool";
            controlContainerTool8.SharedProps.Width = 77;
            labelTool2.SharedProps.Spring = true;
            controlContainerTool9.ControlName = "Details_Button";
            controlContainerTool9.SharedProps.Caption = "Details_ControlContainerTool";
            controlContainerTool9.SharedProps.Width = 77;
            buttonTool1.SharedProps.Caption = "ButtonTool1";
            controlContainerTool10.SharedProps.Caption = "AddUpDateBase_ControlContainerTool";
            controlContainerTool10.SharedProps.Width = 169;
            labelTool3.SharedProps.Caption = "�v����t�����l";
            labelTool3.SharedProps.CustomizerCaption = "LabelTool";
            this.ultraToolbarsManager1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            controlContainerTool5,
            controlContainerTool6,
            controlContainerTool7,
            controlContainerTool8,
            labelTool2,
            controlContainerTool9,
            buttonTool1,
            controlContainerTool10,
            labelTool3});
            this.ultraToolbarsManager1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ultraToolbarsManager1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _MAKAU09130UA_Toolbars_Dock_Area_Left
            // 
            this._MAKAU09130UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU09130UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.GhostWhite;
            this._MAKAU09130UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._MAKAU09130UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU09130UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 29);
            this._MAKAU09130UA_Toolbars_Dock_Area_Left.Name = "_MAKAU09130UA_Toolbars_Dock_Area_Left";
            this._MAKAU09130UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 641);
            this._MAKAU09130UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _MAKAU09130UA_Toolbars_Dock_Area_Top
            // 
            this._MAKAU09130UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU09130UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.GhostWhite;
            this._MAKAU09130UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._MAKAU09130UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU09130UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._MAKAU09130UA_Toolbars_Dock_Area_Top.Name = "_MAKAU09130UA_Toolbars_Dock_Area_Top";
            this._MAKAU09130UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(930, 29);
            this._MAKAU09130UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // _MAKAU09130UA_Toolbars_Dock_Area_Bottom
            // 
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.GhostWhite;
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 670);
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom.Name = "_MAKAU09130UA_Toolbars_Dock_Area_Bottom";
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(930, 0);
            this._MAKAU09130UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.ultraToolbarsManager1;
            // 
            // MAKAU09130UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(930, 670);
            this.Controls.Add(this.ViewButtonPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ultraTabControl1);
            this.Controls.Add(this.claim_panel);
            this.Controls.Add(this.Customer_Panel);
            this.Controls.Add(this._MAKAU09130UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._MAKAU09130UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._MAKAU09130UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._MAKAU09130UA_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.Name = "MAKAU09130UA";
            this.Text = "�d������яC��";
            this.Load += new System.EventHandler(this.MAKAU09130UA_Load);
            this.Shown += new System.EventHandler(this.MAKAU09130UA_Shown);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.Five_Grid_Panel.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.Acc_Grid ) ).EndInit();
            this.First_StatusBar.ResumeLayout(false);
            this.ultraTabPageControl4.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.Dmd_Grid ) ).EndInit();
            this.Second_StatusBar.ResumeLayout(false);
            this.ViewButtonPanel.ResumeLayout(false);
            this.Customer_Panel.ResumeLayout(false);
            this.Customer_Panel.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_SectionCode ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SecCode_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.TargetDiv_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.PayeeCode_tNedit ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SupplierCode_tNedit ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraTabControl1 ) ).EndInit();
            this.ultraTabControl1.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.Bind_DataSet ) ).EndInit();
            this.claim_panel.ResumeLayout(false);
            ( (System.ComponentModel.ISupportInitialize)( this.tLine33 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine34 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine35 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine36 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine38 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine39 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine28 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine30 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine31 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine37 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine40 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tLine42 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.ultraToolbarsManager1 ) ).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�����o�[
		// ===================================================================================== //
		#region Private Members
		private bool        _underExtractionFlg                 = false;
		private bool        _detailFlg                          = false;

		private string[]    _tableNameList                      = new string[2];
		private string[]    _gridTitleList                      = new string[2];
		private int[]       _dataIndexList                      = new int[2];
		private bool[]      _canLogicalDeleteDataExtractionList = new bool[2];
		private bool[]      _defaultAutoFillToGridColumnList    = new bool[2];
		private Image[]     _gridIconList                       = new Image[2];
		private Hashtable[] _appearanceTable                    = new Hashtable[2];

		private bool        _changeFlg;
		//�@��ƃR�[�h
		private string      _enterpriseCode = "";

        private string  _employeeSectionCode = "";
        private int         _sectionIndex   = -1;

        private CustomerInfoAcs _customerInfoAcs;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
        private SupplierAcs _supplierAcs;
        private SecInfoSetAcs _secInfoSetAcs;

        private bool _isValidSupplierSelected = false;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END

        private ProgramItemMAKAU09130U        _programItemObj;
		private TargetData                    _targetData;
		private IMasterMaintenanceAccDmdType  _arrayTypeObj;

		private const int    FIRST_INDEX    = 0;
		private const int    SECOND_INDEX   = 1;
		private const int    CUSTOMER_INDEX = 2;
		// �S�Ћ��_�R�[�h
		private const string ALLSECCODE     = "000000";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA ADD START
        // �w��敪�v���_�E���I�����ڒl�ݒ�
        private const int TARGET_DIV_PAYEE = 0;     // �x����
        private const int TARGET_DIV_SUPPLIER = 1;  // �d����

        // �����p�v���C�x�[�g�ϐ�
        private int _targetSupplierCode;            // �d����R�[�h�i��ʁj
        private int _targetPayeeCode;               // �x����R�[�h
        private string _targetSectionCode;          // ���_�R�[�h�i��ʁj
        private string _targetPaymentSectionCode;   // �x�����_�R�[�h

        private ControlScreenSkin _controlScreenSkin;   // 2009.01.14 Add


        // �Ǘ��c�Ə��R�[�h
        //private string _mngSectionCode;

        //private int _targetClaimCode;
        //private int _targetCustomerCode;
        
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.25 TOKUNAGA ADD END

        // --- ADD 2012/09/18 ---------->>>>>
        // �d���摍���̃I�v�V�����R�[�h���p�ېݒ�p�t���O
        // true �� �d���摍���g�p����B false �� �d���摍���g�p���Ȃ��B
        private bool _sumSuppEnable = false;
        // --- ADD 2012/09/18 ----------<<<<<
		
		#endregion

		# region enum TargetData
		/// <summary>����Ώۃf�[�^�̗񋓌^�ł��B</summary>
		private enum TargetData: int
		{
			/// <summary>�P�K�w��</summary>
			First = 0,
			/// <summary>�Q�K�w��</summary>
			Second = 1,
		}
		# endregion


		# region Internal Methods
		/// <summary>
		/// �O���b�h��^�C�g�����X�g�擾����
		/// </summary>
		/// <param name="dataList">�f�[�^���ڃ��X�g</param>
		/// <param name="colList1">TAB1�O���b�h��^�C�g�����X�g</param>
		/// <param name="colList2">TAB2�O���b�h��^�C�g�����X�g</param>
		/// <remarks>
		/// <br>Note       : �ꗗ�\���p�O���b�h�ɕ\������Ă����̃^�C�g��(Key)��
		///					 ArrayList�Ɋi�[���ĕԂ��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void GetColKeyList(out ArrayList dataList, out ArrayList colList1,out ArrayList colList2)
		{
			dataList = new ArrayList();
			colList1 = new ArrayList();
			colList2 = new ArrayList();

			dataList.Add(this._gridTitleList[FIRST_INDEX]);
			dataList.Add(this._gridTitleList[SECOND_INDEX]);

			for (int i = 0; i < this.Acc_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				if (this.Acc_Grid.DisplayLayout.Bands[0].Columns[i].Hidden == false)
				{
					colList1.Add(this.Acc_Grid.DisplayLayout.Bands[0].Columns[i].Key.ToString());
				}
			}

			for (int i = 0; i < this.Dmd_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
			{
				if (this.Dmd_Grid.DisplayLayout.Bands[0].Columns[i].Hidden == false)
				{
					colList2.Add(this.Dmd_Grid.DisplayLayout.Bands[0].Columns[i].Key.ToString());
				}
			}
		}

		/// <summary>
		/// �O���b�h�e�L�X�g��������
		/// </summary>
		/// <param name="columnKey">�O���b�h�̌����Ώۗ񖼏�</param>
		/// <param name="searchString">����������</param>
		/// <param name="targetName">�����ΏۃO���b�h����</param>
		/// <remarks>
		/// <br>Note       : ������columnKey�ƈ�v���錟���Ώۗ���������A
		///					 ����������(searchString)�Ɉ�v����s�����݂���
		///					 �ꍇ�͂��̍s���A�N�e�B�u�ɂ��܂��B
		///					 ������columnKey�ƈ�v����񂪑��݂��Ȃ��ꍇ�́A
		///					 �S�Ă̗�������ΏۂƂ��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void GridTextSearch(string columnKey, string searchString, string targetName)
		{
			this.Cursor = Cursors.WaitCursor;
			bool checkFlg = false;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid;

			if (this._gridTitleList[FIRST_INDEX] == targetName)
			{
				targetGrid = this.Acc_Grid;
			}
			else
			{
				targetGrid = this.Dmd_Grid;
			}

			// ���ɃA�N�e�B�u�s�����݂���ꍇ�͂��̍s����A�����łȂ��ꍇ��
			// �ŏ��̍s���A�N�e�B�u�ɐݒ肵�A�������J�n����
			Infragistics.Win.UltraWinGrid.UltraGridRow oRow = targetGrid.ActiveRow;
			if (oRow == null)
			{
				oRow = targetGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);
			}

			// Row�I�u�W�F�N�g��GetSibling ���\�b�h���g�p���Ċe�s���J��Ԃ�
			// �`�F�b�N���A�Y���s������������
			while (oRow != null)
			{
				oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

				if (this.MatchText(oRow, columnKey, searchString, targetGrid))
				{
					targetGrid.ActiveRow = oRow;
					targetGrid.ActiveRow.Selected = true;
					targetGrid.Refresh();

					checkFlg = true;
					break;
				}
			}

			if (!checkFlg)
			{
				oRow = targetGrid.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First);

				// ���g���C
				while (oRow != null)
				{
					if (this.MatchText(oRow, columnKey, searchString, targetGrid))
					{
						targetGrid.ActiveRow = oRow;
						targetGrid.ActiveRow.Selected = true;
						targetGrid.Refresh();

						checkFlg = true;
						break;
					}

					oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);
				}
			}

			this.Cursor = Cursors.Default;

			if (!checkFlg)
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_INFO,
					this.Name,
					"���������Ɉ�v����f�[�^�͌�����܂���B",
					0,
					MessageBoxButtons.OK);
		}

		/// <summary>
		/// ��ʏI������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��I�������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		internal void ViewFormClose()
		{
			Close_Button_Click(this, null);
		}
		# endregion

		// ===================================================================================== //
		// �������\�b�h
		// ===================================================================================== //
		# region Private Methods

        /// <summary>��ʏ�������</summary>
		/// <remarks>
		/// <br>Note       : ��ʋN�����̏����������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void InitialDisplay()
		{
			// �{�^����Tag��ݒ肷��iTag�̓{�^���N���b�N�����̗L�������������܂��j
			this.Close_Button.Tag   = true;
			this.New_Button.Tag     = true;
			this.Delete_Button.Tag  = true;
			this.Modify_Button.Tag  = true;
			this.Delete_Button.Tag  = true;
			this.Details_Button.Tag = true;

			// �A�C�R����\������
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Close_Button.ImageList   = imageList16;
			this.New_Button.ImageList     = imageList16;
			this.Delete_Button.ImageList  = imageList16;
			this.Modify_Button.ImageList  = imageList16;
			this.Details_Button.ImageList = imageList16;

			this.Close_Button.Appearance.Image   = Size16_Index.CLOSE;
			this.New_Button.Appearance.Image     = Size16_Index.NEW;
			this.Delete_Button.Appearance.Image  = Size16_Index.DELETE;
			this.Modify_Button.Appearance.Image  = Size16_Index.MODIFY;
			this.Details_Button.Appearance.Image = Size16_Index.DETAILS;

			// �e�}�X�^�����e�i���X�I�u�W�F�N�g���ݒ�l���擾����
			this._canLogicalDeleteDataExtractionList = this._arrayTypeObj.GetCanLogicalDeleteDataExtractionList();
			this._gridTitleList                      = this._arrayTypeObj.GetGridTitleList();
			this._gridIconList                       = this._arrayTypeObj.GetGridIconList();
			this._defaultAutoFillToGridColumnList    = this._arrayTypeObj.GetDefaultAutoFillToGridColumnList();

			this.New_Button.Visible    = this._arrayTypeObj.CanNew;
			this.Delete_Button.Visible = this._arrayTypeObj.CanDelete;
			this.ultraToolbarsManager1.Tools["New_ControlContainerTool"].SharedProps.Visible    = this._arrayTypeObj.CanNew;
			this.ultraToolbarsManager1.Tools["Delete_ControlContainerTool"].SharedProps.Visible = this._arrayTypeObj.CanDelete;

			// ���_�I�v�V�������������ɂ͋��_���̉�ʂ͕\�����Ȃ�
            if (this._arrayTypeObj.Opt_SectionInfo == true)
            {
                //this.SecCode_tComboEditor.Enabled = true;
                this.tNedit_SectionCode.Enabled = true;
                this.uButton_SectionGuide.Enabled = true;
                //this.Section_Panel.Visible = true;    // 2009.01.14 Del
                // �{�Ћ@�\�ȊO�͏C���s��
                //if (this._arrayTypeObj.GetMainOfficeFuncMode == false)
                //{
                //    this.SecCode_tComboEditor.Enabled = false;
                //    this.tNedit_SectionCode.Enabled = false;
                //    this.uButton_SectionGuide.Enabled = false;
                //}
            }
            else
            {
                //this.Section_Panel.Visible = false;   // 2009.01.14 Del
            }

			// �C�x���g�Ƀ��\�b�h��o�^����
			this._arrayTypeObj.UnDisplaying += new MasterMaintenanceAccDmdTypeUnDisplayingEventHandler(this.MasterMaintenance_UnDisplaying);
			((Form)this._arrayTypeObj).VisibleChanged +=new EventHandler(this.SFCMN09000UE_VisibleChanged);

			// �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾����			
			DataSet bindDataSet = new DataSet();
			this._arrayTypeObj.GetBindDataSet(ref bindDataSet, ref this._tableNameList);
			this.Bind_DataSet = bindDataSet;
        }

		/// <summary>�f�[�^�r���[�p�O���b�h�����ݒ菈��</summary>
		/// <remarks>
		/// <br>Note       : �O���b�h�̏����ݒ���s���܂��B
		///					 �i�\����\���A�\�����ʒu�A�t�H�[�}�b�g�A�t�H���g�F�A�t�B���^�j</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void GridInitialSetting()
		{
            // TAB1�̃O���b�h�̐ݒ�
            GridSetting(FIRST_INDEX, Acc_Grid, TargetData.First);
            this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]].Columns[SuplAccPayAcs.COL_STCKTTLACCPAYBALANCE_TITLE].Caption = "���|�c��";

            // TAB2�̃O���b�h�̐ݒ�
            GridSetting(SECOND_INDEX, Dmd_Grid, TargetData.Second);
            this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]].Columns[SuplAccPayAcs.COL_AFCALDEMANDPRICE_TITLE].Caption = "�x���c��";
        }

        /// <summary>�f�[�^�r���[�p�O���b�h�ݒ菈��</summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̐ݒ���s���܂�(�\����\���A�\�����ʒu�A�t�H�[�}�b�g�A�t�H���g�F�A�t�B���^)</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
        private void GridSetting(int tabIndex, Infragistics.Win.UltraWinGrid.UltraGrid tagetGrid, TargetData targetIndex)
        {
            try
            {

                for (int i = 0; i < this.Bind_DataSet.Tables[this._tableNameList[tabIndex]].Columns.Count; i++)
                {
                    GridColAppearance appearance = (GridColAppearance)this._appearanceTable[tabIndex][this.Bind_DataSet.Tables[this._tableNameList[tabIndex]].Columns[i].ColumnName];

                    // �O���b�h��̕\����\���ݒ菈��
                    this.GridColHidden(i, appearance.GridColDispType, targetIndex);

                    // �l�̕\�����ʒu��ݒ肷��
                    switch (appearance.CellTextAlign)
                    {
                        case ContentAlignment.TopLeft:
                        case ContentAlignment.MiddleLeft:
                        case ContentAlignment.BottomLeft:
                            {
                                tagetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                                break;
                            }
                        case ContentAlignment.TopCenter:
                        case ContentAlignment.MiddleCenter:
                        case ContentAlignment.BottomCenter:
                            {
                                tagetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                                break;
                            }
                        case ContentAlignment.TopRight:
                        case ContentAlignment.MiddleRight:
                        case ContentAlignment.BottomRight:
                            {
                                tagetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                                break;
                            }
                    }

                    // �l�̃t�H�[�}�b�g��ݒ肷��
                    if ((appearance.Format != "") && (appearance.Format != null))
                    {
                        tagetGrid.DisplayLayout.Bands[0].Columns[i].Format = appearance.Format;
                    }

                    // ��̃t�H���g�F��ݒ肷��
                    tagetGrid.DisplayLayout.Bands[0].Columns[i].CellAppearance.ForeColor = appearance.ColFontColor;

                    // �O���b�h�̃t�B���^�����O����
                    AddGridFiltering(targetIndex);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

            
            
        /// <summary>�O���b�h��̕\����\���ݒ菈��</summary>
		/// <param name="colDispType">�O���b�h��̕\���^�C�v</param>
		/// <param name="index">�O���b�h��̃C���f�b�N�X</param>
		/// <param name="targetData">����ΏۃO���b�h����</param>
		/// <remarks>
		/// <br>Note       : �O���b�h��̕\����\���ݒ���s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void GridColHidden(int index, MGridColDispType colDispType, TargetData targetData)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = null;

			switch (targetData)
			{
				case (TargetData.First):
				{
					targetGrid = this.Acc_Grid;
					break;
				}
				case (TargetData.Second):
				{
					targetGrid = this.Dmd_Grid;
					break;
				}
			}

			switch (colDispType)
			{
				case MGridColDispType.None:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					break;
				}
				case MGridColDispType.Both:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					break;
				}
				case MGridColDispType.ListOnly:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					break;
				}
				case MGridColDispType.DetailsOnly:
				{
					if (this._detailFlg == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataBoth:
				{
					if (targetCheckEditor.Checked == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataListOnly:
				{
					if (targetCheckEditor.Checked == true)
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				case MGridColDispType.DeletionDataDetailsOnly:
				{
					if (targetCheckEditor.Checked == true)
					{
						if (this._detailFlg == true)
						{
							targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = false;
						}
						else
						{
							targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
						}
					}
					else
					{
						targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					}
					break;
				}
				default:
				{
					targetGrid.DisplayLayout.Bands[0].Columns[index].Hidden = true;
					break;
				}
			}
		}

		/// <summary>�O���b�h�̃t�B���^�����O����</summary>
		/// <remarks>
		/// <br>Note       : �O���b�h��̃t�B���^�����O���s���܂��B
		///					 �����N�����ɁA�폜�f�[�^���t�B���^�����O���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AddGridFiltering(TargetData targetData)
		{
			int index = -1;
			string tableName = "";
			Hashtable appearanceTable;
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Infragistics.Win.UltraWinEditors.UltraCheckEditor targetCheckEditor = null;
			
			switch (targetData)
			{
				case TargetData.First:
				{
					tableName = this._tableNameList[FIRST_INDEX];
					targetGrid = this.Acc_Grid;
					appearanceTable = this._appearanceTable[FIRST_INDEX];

					break;
				}
				case TargetData.Second:
				{
					tableName = this._tableNameList[SECOND_INDEX];
					targetGrid = this.Dmd_Grid;
					appearanceTable = this._appearanceTable[SECOND_INDEX];

					break;
				}
				default:
				{
					return;
				}
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
			{
                GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];

				if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataListOnly) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataDetailsOnly))
				{
					index = i;
					break;
				}
			}	

			if (index >= 0)
			{
				// �s�t�B���^���o���h�Ɋ�Â��Ă���ꍇ�A�o���h�̗�t�B���^���O���B
				Infragistics.Win.UltraWinGrid.ColumnFiltersCollection columnFilters = targetGrid.DisplayLayout.Bands[0].ColumnFilters;
				columnFilters.ClearAllFilters();

				if (targetCheckEditor.Checked == false)
				{
					// �󔒂�Null�ȊO���t�B���^�ɐݒ肷��
					columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, "");
					columnFilters[index].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.Equals, null);
					columnFilters[index].LogicalOperator = Infragistics.Win.UltraWinGrid.FilterLogicalOperator.Or;
				}
			}
		}

		/// <summary>�e�L�X�g��v�`�F�b�N����</summary>
		/// <param name="userString">����������</param>
		/// <param name="cellValue">�����ΏۃZ���l</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃Z���l�ƈ�������v���邩�ǂ������`�F�b�N���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool Match(string userString, string cellValue)
		{
			// ������𗼕��Ƃ��啶���ɕϊ�����
			userString = userString.ToUpper();
			cellValue = cellValue.ToUpper();

			// �Z���l�������[�U�[���������񂪑傫���ꍇ�́A�s��v�Ȃ̂�
			// False��߂�
			if (userString.Length > cellValue.Length)
			{
				return false;
			}
			else if (userString.Length == cellValue.Length)
			{
				// ��������v����ꍇ�A���������v����
				if (userString == cellValue)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				for ( int i = 0; i <= (cellValue.Length - userString.Length); i++ )
				{
					if (userString == cellValue.Substring(i, userString.Length))
					{
						return true;
					}
				}

				return false;
			}
		}

		/// <summary>�e�L�X�g��v�s���݃`�F�b�N����</summary>
		/// <param name="oRow">�����ΏۃO���b�h�s</param>
		/// <param name="columnKey">�����ΏۃO���b�h��</param>
		/// <param name="searchString">����������</param>
		/// <param name="targetGrid">�����ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �����̍s�ɑ΂��āA�����Ώۗ�̃Z���̒l�ƈ�v����
		///					 ���ǂ������`�F�b�N���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool MatchText(Infragistics.Win.UltraWinGrid.UltraGridRow oRow, string columnKey, string searchString, Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
		{
			if (oRow == null)
			{
				return false;
			}

			// �I������Ă�������������̂��S�Ă̗����������̂����m�F����
			bool bSearchAllColumns = true;
			if (targetGrid.DisplayLayout.Bands[0].Columns.Exists(columnKey))
			{
				bSearchAllColumns = false;
			}

			// �S�Ă̗����������ꍇ�A�s�̑S�ẴZ��������������
			// ���̏ꍇBands.Columns�R���N�V�������g�p���A��������}��
			if (bSearchAllColumns)
			{
				foreach(Infragistics.Win.UltraWinGrid.UltraGridColumn oCol in targetGrid.DisplayLayout.Bands[0].Columns)
				{
					if (!oCol.IsVisibleInLayout) continue;

					if ((oRow.Cells[oCol.Key].Value != null) && (oRow.IsFilteredOut == false))
					{
						if (this.Match(searchString, oRow.Cells[oCol.Key].Value.ToString()))
						{
							return true;
						}
					}
				}
			}
			else
			{
				Infragistics.Win.UltraWinGrid.UltraGridColumn oCol = targetGrid.DisplayLayout.Bands[0].Columns[columnKey];
				if ((oRow.Cells[oCol.Key].Value != null ) && (oRow.IsFilteredOut == false))
				{
					if (this.Match(searchString, oRow.Cells[oCol.Key].Value.ToString()))
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>�X�e�[�^�X�o�[�����\������</summary>
		/// <remarks>
		/// <br>Note       : �X�e�[�^�X�o�[�ɃO���b�h�̍s����\�����܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void StatusBarCountIndication()
		{
			this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text  = this.Acc_Grid.Rows.FilteredInRowCount.ToString()  + "��";
			this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = this.Dmd_Grid.Rows.FilteredInRowCount.ToString() + "��";
		}

		/// <summary>�O���b�h�A�N�e�B�u�s�ݒ菈��</summary>
		/// <param name="targetGrid">����Ώ�Grid</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃A�N�e�B�u�s���������A�I����Ԃɂ��܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void SetActiveRow(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid)
		{
			if (targetGrid.ActiveRow != null)
			{
				bool setFlg = false;
				Infragistics.Win.UltraWinGrid.UltraGridRow nextRow = targetGrid.ActiveRow;
				while (nextRow != null)
				{
					if (nextRow.IsFilteredOut)
					{
						int index = nextRow.Index;

						// �I���s���t�B���^�����O����Ă���ꍇNext�s��I��
						nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

						// �C���f�b�N�X�������ꍇ�́A�������݂��Ȃ��Ɣ��f����break
						if ((nextRow != null) && (index == nextRow.Index))
						{
							break;
						}
					}
					else
					{
						targetGrid.ActiveRow = nextRow;
						targetGrid.ActiveRow.Selected = true;
						setFlg = true;
						break;
					}
				}

				if (setFlg == false)
				{
					// �Y������s�����݂��Ȃ��ꍇ�́A�ŏ�����ēxNext����
					nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First);
					while (nextRow != null)
					{
						if (nextRow.IsFilteredOut)
						{
							int index = nextRow.Index;

							// �I���s���t�B���^�����O����Ă���ꍇNext�s��I��
							nextRow = targetGrid.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next);

							// �C���f�b�N�X�������ꍇ�́A�������݂��Ȃ��Ɣ��f����break;
							if ((nextRow != null) && (index == nextRow.Index))
							{
								break;
							}
						}
						else
						{
							targetGrid.ActiveRow = nextRow;
							targetGrid.ActiveRow.Selected = true;
							break;
						}
					}
				}
			}
			else if (targetGrid.Rows.Count > 0)
			{
				if (targetGrid.Rows[0] != null)
				{
					targetGrid.ActiveRow = targetGrid.Rows[0];
					targetGrid.ActiveRow.Selected = true;
				}
			}
		}

		/// <summary>��ʔ�\���C�x���g�p���\�b�h</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="me">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : �}�X�^�����e�i���X�̉�ʔ�\���C�x���g�p���\�b�h�ł��B
		///					 �c���[�`�F�b�N�{�b�N�X�̃`�F�b�N���������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MasterMaintenance_UnDisplaying(object sender, MasterMaintenanceUnDisplayingEventArgs me)
		{
			// ������DialogResult��OK�܂���Yes�̏ꍇ�́A�m�[�h�̃`�F�b�N�{�b�N�X�Ƀ`�F�b�N��t����
			if ((me.DialogResult == DialogResult.OK) || (me.DialogResult == DialogResult.Yes))
			{
				this.StatusBarCountIndication();
			}
			else
			{
				switch(this._targetData)
				{
					case (TargetData.First):
					{
						CurrencyManager cm = (CurrencyManager)BindingContext[this.Acc_Grid.DataSource];
						this._dataIndexList[FIRST_INDEX] = cm.Position;	
						break;
					}
					case (TargetData.Second):
					{
						CurrencyManager cm = (CurrencyManager)BindingContext[this.Dmd_Grid.DataSource];
						this._dataIndexList[SECOND_INDEX] = cm.Position;	
						break;
					}
				}
			}
			switch(this._targetData)
			{
				case (TargetData.First):
				{
					// �O���b�h�A�N�e�B�u�s�ݒ菈��
					this.SetActiveRow(this.Acc_Grid);

					break;
				}
				case (TargetData.Second):
				{
					// �O���b�h�A�N�e�B�u�s�ݒ菈��
					this.SetActiveRow(this.Dmd_Grid);
					break;
				}
			}
		}

		/// <summary>��ʕ\���ύX�㔭���C�x���g�p���\�b�h</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^�N���X</param>
		/// <remarks>
		/// <br>Note       : �q��ʂ�Visible���ύX�ɂȂ�����ɔ������܂��B
		///					 �{�^���̗L�������`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void SFCMN09000UE_VisibleChanged(object sender, EventArgs e)
		{
			this.Details_Button.Visible = false;
			if (((Form)this._arrayTypeObj).Visible == true)
			{
				this.Close_Button.Enabled   = false;
				this.New_Button.Enabled     = false;
				this.Modify_Button.Enabled  = false;
				this.Details_Button.Enabled = false;
			}
			else
			{
				this.Close_Button.Enabled   = true;
				this.New_Button.Enabled     = true;
				this.Modify_Button.Enabled  = true;
				this.Details_Button.Enabled = true;

				this.ButtonEnabledControl(this._targetData);
			}
		}

		/// <summary>�{�^���L���������䏈��</summary>
		/// <param name="targetData">����ΏۃO���b�h</param>
		/// <remarks>
		/// <br>Note       : �{�^���̗L������������s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ButtonEnabledControl(TargetData targetData)
		{
			bool[] newEnabled    = this._arrayTypeObj.GetNewButtonEnabledList();
			bool[] modifyEnabled = this._arrayTypeObj.GetModifyButtonEnabledList();

			switch(targetData)
			{
				case (TargetData.First):
				{
					this.New_Button.Enabled = newEnabled[0];
					this.Modify_Button.Enabled = modifyEnabled[0];

					break;
				}
				case (TargetData.Second):
				{
					this.New_Button.Enabled = newEnabled[1];
					this.Modify_Button.Enabled = modifyEnabled[1];
					break;
				}
			}

			this.New_Button.Tag    = this.New_Button.Enabled;
			this.Modify_Button.Tag = this.Modify_Button.Enabled;
		}

		/// <summary>�폜�f�[�^�`�F�b�N����</summary>
		/// <returns>true:�폜�\ false:�폜�s��</returns>
		/// <remarks>
		/// <br>Note       : �폜�f�[�^�̍폜�ς݃`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private bool DeleteDataCheck(TargetData targetData)
		{
			bool ret = true;
			int index = -1;

			string tableName = "";
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;
			Hashtable appearanceTable;

			switch (targetData)
			{
				case (TargetData.First):
				{
					tableName = this._tableNameList[FIRST_INDEX];
					targetGrid = this.Acc_Grid;
					appearanceTable = this._appearanceTable[FIRST_INDEX];
					break;
				}
				case (TargetData.Second):
				{
					tableName = this._tableNameList[SECOND_INDEX];
					targetGrid = this.Dmd_Grid;
					appearanceTable = this._appearanceTable[SECOND_INDEX];
					break;
				}
				default:
				{
					return ret;
				}
			}

			for (int i = 0; i < this.Bind_DataSet.Tables[tableName].Columns.Count; i++)
			{
                GridColAppearance appearance = (GridColAppearance)appearanceTable[this.Bind_DataSet.Tables[tableName].Columns[i].ColumnName];

				if ((appearance.GridColDispType == MGridColDispType.DeletionDataBoth) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataListOnly) ||
					(appearance.GridColDispType == MGridColDispType.DeletionDataDetailsOnly))
				{
					index = i;
					break;
				}
			}	

			if (index >= 0)
			{
				if (targetGrid.ActiveRow.Cells[index].Text.Trim() != "") ret = false;
			}

			return ret;
		}

		/// <summary>��ʏ����ݒ菈��</summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
			// ���_�����R���{�ɐݒ�
            //this.SecCode_tComboEditor.Clear();
            ArrayList retSecInfSetList = new ArrayList();
            this._arrayTypeObj.SecInf_Search(out retSecInfSetList);

            //this.SecCode_tComboEditor.Items.Add(ALLSECCODE, "�S��");

            //foreach(SecInfoSet secInfSet in retSecInfSetList)
            //{
            //    this.SecCode_tComboEditor.Items.Add(secInfSet.SectionCode,secInfSet.SectionGuideNm);
			
            //    if ( this._arrayTypeObj.GetCompanySectionCode == secInfSet.SectionCode )
            //        this._sectionIndex = this.SecCode_tComboEditor.Items.Count -1;
			
            //}
			// �N�����͎����_�������l�Ƃ���
            //this.SecCode_tComboEditor.SelectedIndex = this._sectionIndex;
            this.tNedit_SectionCode.Text = this._employeeSectionCode;
            // 2008.11.21 modify start [8120]
            //tNedit_SectionCode_Leave(null, null);
            ResearchFromSectionCode(false);
            // 2008.11.21 modify end [8120]
            

            this.TargetDiv_tComboEditor.SelectedIndex = TARGET_DIV_PAYEE;

		}

		/// <summary>��ʃN���A����</summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ScreenClear()
		{
			// �d������i�R�[�h�E���́E����)
			this.SupplierCode_tNedit.Clear();
			this.SupplierName_Label.Text = "";
			this.SupplierName2_Label.Text = "";
            this.SupplierSnm_Label.Text = "";
            this.TotalDay_Label.Text = "";

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA ADD START
            // �x������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.25 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.PayeeCode_tNedit.Clear();
            this.PayeeName_Label.Text = "";
            this.PayeeName2_Label.Text = "";
            this.PayeeSnm_Label.Text = "";
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

			// ���|�E�x����List
			// ���_�I�v�V�����������ꍇ�A�{�Ћ@�\�ł͂Ȃ��ꍇ�́A�����_����ɐݒ�
            if ((this._arrayTypeObj.Opt_SectionInfo == true) && (this._arrayTypeObj.GetMainOfficeFuncMode == true))
            {
                //this.SecCode_tComboEditor.SelectedIndex = -1;
                this.tNedit_SectionCode.Text = this._employeeSectionCode; ;// this._arrayTypeObj.SectionCodeData; 
                // 2008.11.21 modify start [8120]
                //tNedit_SectionCode_Leave(null, null);
                ResearchFromSectionCode(false);
                // 2008.11.21 modify end [8120]
            }
            else
            {
                //this.SecCode_tComboEditor.SelectedIndex = this._sectionIndex;
                this.tNedit_SectionCode.Text = this._employeeSectionCode;
                // 2008.11.21 modify start [8120]
                //tNedit_SectionCode_Leave(null, null);
                ResearchFromSectionCode(false);
                // 2008.11.21 modify end [8120]
            }

            this._dataIndexList[FIRST_INDEX]  = 0;
            this._dataIndexList[SECOND_INDEX] = 0;
            this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
            
            this.Bind_DataSet.Tables[FIRST_INDEX].Clear();
			this.Bind_DataSet.Tables[SECOND_INDEX].Clear();

			// �ڍ׉�ʊӏ��N���A
			claim_panel_Clear();

			this._changeFlg = false;
		}

        /// <summary>�Ӊ�ʂ̃N���A����</summary>
		/// <remarks>
		/// <br>Note       : �Ӊ�ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void claim_panel_Clear()
		{
			// �ڍ׉�ʏ��N���A(�Ӎ���)
			
			this.Ttl3TmDmd_Label.Text           = "";     // 3��ȑO�c��
			this.Ttl2TmDmd_Label.Text           = "";     // 2��ȑO�c��
			this.TtlLMBlDmd_Label.Text          = "";     // �O��c��
			this.TtlSalesDmd_Label.Text         = "";     // ����d��
            this.TtlConsTaxDmd_Label.Text       = "";     // �����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this.TtlPayDmd_Label.Text     = "";     // ����x��
            //this.TtlPayTaxDmd_Label.Text  = "";     // �x�������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this.TtlBalanceAdjust_Label.Text    = "";     // �c�������z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this.TtlDepoDmd_Label.Text          = "";     // ����x��
			this.TtlBlDmd_Label.Text            = "";     // �c��
		}

		/// <summary>�d����N���X��ʓW�J����</summary>
        /// <param name="customerRet">�d����I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �d����I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>-----------------------</br>
        /// <br>Note       : ���Ӑ�I�u�W�F�N�g�ł͂Ȃ��d����I�u�W�F�N�g(Supplier)�Ɏd�l���ύX���ꂽ�B</br>
        /// <br>Modifier   : ���i �r��</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
		private void CustomerToScreen(Supplier supplierInfo)
        //private void CustomerToScreen(CustomerSearchRet customerRet)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA MODIFY START
            this.SupplierCode_tNedit.SetInt(supplierInfo.SupplierCd);
            this.SupplierName_Label.Text = supplierInfo.SupplierNm1;
            this.SupplierName2_Label.Text = supplierInfo.SupplierNm2;
            this.SupplierSnm_Label.Text = supplierInfo.SupplierSnm;
            this.TotalDay_Label.Text = supplierInfo.PaymentTotalDay.ToString();
            //this.CustomerCode_tNedit.SetInt(customerRet.CustomerCode);
            //this.CustomerName_Label.Text = customerRet.Name;
            //this.CustomerName2_Label.Text = customerRet.Name2;
            //this.CustomerSnm_Label.Text = customerRet.Snm;
            //this.TotalDay_Label.Text = customerRet.TotalDay.ToString();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.25 TOKUNAGA MODIFY END
        }
	
		/// <summary>�ӏ��W�J����</summary>
		/// <param name="sender">�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note			:   �w�肳�ꂽ�s�̏����ӂɓW�J���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void claim_panelInfoSet(object sender)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			if (  targetGrid.ActiveRow == null ) return;

			int rowIndex = targetGrid.ActiveRow.Index;

			string[] textList = null;
			this._arrayTypeObj.ReadTabelData_claim_panelSet(out textList);
            if (textList == null)
            {
                return;
            }

			// ��ʏ��ɔ��f
			Ttl3TmDmd_Label.Text     = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[0]].Value, true);    // �R��ȑO�c��
			Ttl2TmDmd_Label.Text     = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[1]].Value, true);    // �Q��ȑO�c��
			TtlLMBlDmd_Label.Text    = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[2]].Value, true);    // �O��c��
			TtlSalesDmd_Label.Text   = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[3]].Value, true);    // ����d��
            TtlConsTaxDmd_Label.Text = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[4]].Value, true);    // �����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //TtlPayDmd_Label.Text     = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[5]].Value, true);    // ����x��
            //TtlPayTaxDmd_Label.Text  = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[6]].Value, true);    // �x�������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            TtlBalanceAdjust_Label.Text = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_BALANCEADJUST_TITLE].Value + (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_TAXADJUST_TITLE].Value, true); // �c�������z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //Int64 totalDepoDmd = (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEPAYNRML_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEFEEPAYNRML_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEDISPAYNRML_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMERBTDMDNRML_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEDMDDEPO_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEFEEDMDDEPO_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEDISDMDDEPO_TITLE].Value +
            //                     (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMERBTDMDDEPO_TITLE].Value;
            Int64 totalDepoDmd = ( Int64 ) targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEPAYNRML_TITLE].Value +
                                 ( Int64 ) targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEFEEPAYNRML_TITLE].Value +
                                 ( Int64 ) targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_THISTIMEDISPAYNRML_TITLE].Value ;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            TtlDepoDmd_Label.Text    = this._arrayTypeObj.Claim_panelDataFormat(totalDepoDmd, true);                                            // ����x��

            // 2008.11.17 modify start [5045]
            //TtlBlDmd_Label.Text = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[8]].Value, true);    // ���|�c��
            TtlBlDmd_Label.Text = this._arrayTypeObj.Claim_panelDataFormat((Int64)targetGrid.ActiveRow.Cells[textList[8]].Value, true);// + (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_BALANCEADJUST_TITLE].Value + (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_TAXADJUST_TITLE].Value, true);    // ���|�c��;// + (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_BALANCEADJUST_TITLE].Value + (Int64)targetGrid.ActiveRow.Cells[SuplAccPayAcs.COL_TAXADJUST_TITLE].Value, true);    // ���|�c��
            // 2008.11.17 modify end [5045]

		}
		# endregion

        // --- ADD 2012/09/18 ---------->>>>>
        #region ���I�v�V������񐧌䏈��

        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���d�������@�\�i�ʁj�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._sumSuppEnable = true;
            }
            else
            {
                this._sumSuppEnable = false;
            }
            #endregion
        }
        #endregion ���I�v�V������񐧌䏈��
        // --- ADD 2012/09/18 ----------<<<<<

		// ===================================================================================== //
		// �R���g���[���C�x���g
		// ===================================================================================== //
		#region Control Events

        /// <summary>Form.Load �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void MAKAU09130UA_Load(object sender, System.EventArgs e)
		{
            // �����_�R�[�h
            this._employeeSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;


			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList16 = IconResourceManagement.ImageList16;
			this.Supplier_Guide_Button.ImageList = imageList16;
			this.Supplier_Guide_Button.Appearance.Image = Size16_Index.STAR1;

            this.uButton_SectionGuide.ImageList = imageList16;
            this.uButton_SectionGuide.Appearance.Image = Size16_Index.STAR1;

            this._programItemObj = new ProgramItemMAKAU09130U(" ", 
                                                              "MAKAU09130U.DLL",
                                                              "Broadleaf.Windows.Forms.MAKAU09130UB",
                                                              "�d������яC��",
                                                              ProgramPatternMAKAU09130U.Multi);
			
			string AssemblyID = this._programItemObj.AssemblyID;
			string ClassID    = this._programItemObj.ClassID;

			Assembly assmbly = Assembly.LoadFrom(AssemblyID);
			System.Type type = assmbly.GetType(ClassID);

			this._programItemObj.ClassType  = type;
			this._programItemObj.Object     = Activator.CreateInstance(type);
			this._programItemObj.CustomForm = (Form)this._programItemObj.Object;

			this._arrayTypeObj = (IMasterMaintenanceAccDmdType)this._programItemObj.CustomForm;
            // --- ADD 2012/09/18 ---------->>>>>
            // �d���摍���I�v�V��������ݒ肷��
            MAKAU09130UB bForm = (MAKAU09130UB)this._arrayTypeObj;
            bForm.Opt_sumSuppEnable = this._sumSuppEnable;
            // --- ADD 2012/09/18 ----------<<<<<

            // ���_���擾
            ScreenInitialSetting();
            
            this.InitialDisplay();
            
            // �f�[�^�̒��o���������s����
			int totalCount = 0;
			// �d������̎擾
			int status = this._arrayTypeObj.CustomerData_Search(ref totalCount, 0);

			switch (status)
			{
				case 0:
				{
					break;
				}
				case 9:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP,
						          this.Name,
						          "�ǂݍ��݂Ɏ��s���܂����B",
						          status,
						          MessageBoxButtons.OK);
					return;
				}
			}

			this.Acc_Grid.DataSource = this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]];
			this.Dmd_Grid.DataSource = this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]];

			this._arrayTypeObj.GetAppearanceTable(out this._appearanceTable);
			this.GridInitialSetting();

			this._arrayTypeObj.GetDisPlayDisplayLayoutTable(ref Acc_Grid ,this._tableNameList[FIRST_INDEX]);
			this._arrayTypeObj.GetDisPlayDisplayLayoutTable(ref Dmd_Grid ,this._tableNameList[SECOND_INDEX]);

			this.AutoFillToFirstGridColumn_CheckEditor.Checked  = false;
			this.AutoFillToFirstGridColumn_CheckEditor.Checked  = this._defaultAutoFillToGridColumnList[FIRST_INDEX];

			this.AutoFillToSecondGridColumn_CheckEditor.Checked = false;
			this.AutoFillToSecondGridColumn_CheckEditor.Checked = this._defaultAutoFillToGridColumnList[SECOND_INDEX];

			this.ActiveControl = this.SupplierCode_tNedit;

			if (this.Acc_Grid.Rows.Count > 0)
			{
				this.Acc_Grid.ActiveRow = this.Acc_Grid.Rows[0];
				this.Acc_Grid.ActiveRow.Selected = true;
			}

			if (this.Dmd_Grid.Rows.Count > 0)
			{
				this.Dmd_Grid.ActiveRow = this.Dmd_Grid.Rows[0];
				this.Dmd_Grid.ActiveRow.Selected = true;
			}	

			this._targetData = TargetData.First;
            // �ڍ׏��̖��̐؂�ւ��̈גǉ�
            ultraTabControl1_Click(sender, null);

			ScreenClear();

            // ���b�Z�[�W�o��
            this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
            this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";

            // 2009.01.14 Add >>>
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // 2009.01.14 Add <<<
  		}

		/// <summary>Acc_Grid_AfterRowActivate �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : �s���A�N�e�B�u�ɂȂ�����ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_AfterRowActivate(object sender, System.EventArgs e)
		{
			// �w�肳�ꂽ�s���̊ӂ��쐬���܂��B	
			claim_panelInfoSet(sender);
		}

        /// <summary>�_�u���N���b�N���ꂽ���ɔ������� �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �_�u���N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_DoubleClick(object sender, System.EventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			
			// �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
			Point point = System.Windows.Forms.Cursor.Position;
			point = targetGrid.PointToClient(point);
			Infragistics.Win.UIElement objElement = null;
			Infragistics.Win.UltraWinGrid.RowCellAreaUIElement objRowCellAreaUIElement = null;
			objElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);

			objRowCellAreaUIElement = (Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)objElement.GetAncestor(
				(typeof(Infragistics.Win.UltraWinGrid.RowCellAreaUIElement)));

			// �w�b�_���̏ꍇ�͈ȉ��̏������L�����Z������
			if(objRowCellAreaUIElement == null)
			{
				return;
			}
			// �C����ʂ��N������
			Modify_Button_Click(Modify_Button, e);
		}

        /// <summary>���� �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �Z������A�N�e�B�u�ɂȂ�O�ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_BeforeRowDeactivate(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;
			foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cl in targetGrid.ActiveRow.Cells)
			{
				cl.Appearance  = null;
			}
		}

		/// <summary>Control.ChangeFocus �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X�ړ����ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
			if (e.PrevCtrl == null) return;
			if (e.NextCtrl == null) return;

            // ���̎擾 ============================================ //
            switch (e.Key)
            {
                case Keys.Return:
                case Keys.Tab:
                case Keys.Down:
                    {
                        switch (e.PrevCtrl.Name)
                        {
                            case "tNedit_SectionCode":
                                {
                                    if (String.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
                                    {
                                        // 2009.01.14 >>>
                                        //this.tEdit_SectionName.Clear();
                                        this.SectionName_Label.Text = string.Empty;
                                        // 2009.01.14 <<<
                                        e.NextCtrl = this.uButton_SectionGuide;
                                    }
                                    else
                                    {
                                        ResearchFromSectionCode(false);
                                        e.NextCtrl = this.SupplierCode_tNedit;
                                    }
                                    break;
                                }
                            case "uButton_SectionGuide":
                                {
                                    e.NextCtrl = this.SupplierCode_tNedit;
                                    break;
                                }
                            case "SupplierCode_tNedit":
                                {
                                    if (String.IsNullOrEmpty(this.SupplierCode_tNedit.Text.Trim()))
                                    {
                                        e.NextCtrl = this.Supplier_Guide_Button;
                                    }
                                    else
                                    {
                                        if (ultraTabControl1.ActiveTab.Key == "campanyTab")
                                        {
                                            if (this.Acc_Grid.Rows.Count > 0) e.NextCtrl = this.Acc_Grid;
                                            else e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
                                        }
                                        else
                                        {
                                            if (this.Dmd_Grid.Rows.Count > 0) e.NextCtrl = this.Dmd_Grid;
                                            else e.NextCtrl = this.AutoFillToSecondGridColumn_CheckEditor;
                                        }
                                    }
                                    break;
                                }
                            case "Supplier_Guide_Button":
                                {
                                    if (ultraTabControl1.ActiveTab.Key == "campanyTab")
                                    {
                                        if (this.Acc_Grid.Rows.Count > 0) e.NextCtrl = this.Acc_Grid;
                                        else e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
                                    }
                                    else
                                    {
                                        if (this.Dmd_Grid.Rows.Count > 0) e.NextCtrl = this.Dmd_Grid;
                                        else e.NextCtrl = this.AutoFillToSecondGridColumn_CheckEditor;
                                    }
                                    break;
                                }
                            case "TargetDiv_tComboEditor":
                                {
                                    if (this.tNedit_SectionCode.Enabled)
                                    {
                                        e.NextCtrl = this.tNedit_SectionCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.SupplierCode_tNedit;
                                    }
                                    break;
                                }
                            case "AutoFillToFirstGridColumn_CheckEditor":
                                {
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                    break;
                                }
                            case "AutoFillToSecondGridColumn_CheckEditor":
                                {
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                    break;
                                }
                            case "Acc_Grid":
                                {
                                    e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
                                    break;
                                }
                            case "Dmd_Grid":
                                {
                                    e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                    // 2008.11.17 add start [7895]
                case Keys.Up:
                    {
                        switch (e.PrevCtrl.Name)
                        {
                            // ���_�R�[�h
                            case "tNedit_SectionCode":
                                {
                                    // �w��敪��
                                    if (!String.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
                                    {
                                        ResearchFromSectionCode(true);
                                    }
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                    break;
                                }
                            default: break;
                        }
                        break;
                    }
                    // 2008.11.17 add end [7895]
                default: break;
            }

            //if (e.PrevCtrl == this.SupplierCode_tNedit)
            //{
            //    if (e.Key == Keys.Return)
            //    {
            //        if (this.SupplierCode_tNedit.GetValue() != 0)
            //        {
            //            switch (ultraTabControl1.ActiveTab.Key)
            //            {
            //                case "campanyTab":
            //                    {
            //                        if (this.Acc_Grid.Rows.Count > 0)
            //                        {
            //                            e.NextCtrl = this.Acc_Grid;
            //                        }
            //                        else
            //                        {
            //                            e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
            //                        }
            //                    }
            //                    break;
            //                case "customerTab":
            //                    {
            //                        if (this.Dmd_Grid.Rows.Count > 0)
            //                        {
            //                            e.NextCtrl = this.Dmd_Grid;
            //                        }
            //                        else
            //                        {
            //                            e.NextCtrl = this.AutoFillToFirstGridColumn_CheckEditor;
            //                        }
            //                        break;
            //                    }
            //                default:
            //                    {
            //                        return;
            //                    }
            //            }
            //        }
            //        else if (this.SupplierCode_tNedit.GetValue() == 0)
            //        {
            //            e.NextCtrl = this.Supplier_Guide_Button;
            //        }
            //    }
            //}

            //if ((e.PrevCtrl == this.Acc_Grid) || (e.PrevCtrl == this.Dmd_Grid))
            //{
            //    if (e.Key == Keys.Return)
            //    {
            //        switch (ultraTabControl1.ActiveTab.Key)
            //        {
            //            case "campanyTab":
            //                {
            //                    if (this.Acc_Grid.Rows.Count > 0)
            //                    {
            //                        KeyEventArgs k = new KeyEventArgs(e.Key);
            //                        this.Acc_Grid_KeyDown(sender, k);
            //                        //e.NextCtrl = this.Acc_Grid;
            //                    }
            //                    else
            //                    {
            //                        e.NextCtrl = this.TargetDiv_tComboEditor;
            //                    }
            //                    break;

            //                }
            //            case "customerTab":
            //                {
            //                    if (this.Dmd_Grid.Rows.Count > 0)
            //                    {
            //                        KeyEventArgs k = new KeyEventArgs(e.Key);
            //                        this.Acc_Grid_KeyDown(sender, k);
            //                        //e.NextCtrl = this.Dmd_Grid;
            //                    }
            //                    else
            //                    {
            //                        e.NextCtrl = this.TargetDiv_tComboEditor;
            //                    }
            //                    break;
            //                }
            //            default:
            //                {
            //                    return;
            //                }
            //        }
            //    }

            //}		

            // 2009.01.14 Add >>>
            if (( e.PrevCtrl == this.Acc_Grid ) || ( e.PrevCtrl == this.Dmd_Grid ))
            {
                if (e.Key == Keys.Return)
                {
                    switch (ultraTabControl1.ActiveTab.Key)
                    {
                        case "campanyTab":
                            {
                                if (this.Acc_Grid.Rows.Count > 0)
                                {
                                    KeyEventArgs k = new KeyEventArgs(e.Key);
                                    this.Acc_Grid_KeyDown(sender, k);
                                    //e.NextCtrl = this.Acc_Grid;
                                }
                                else
                                {
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                }
                                break;

                            }
                        case "customerTab":
                            {
                                if (this.Dmd_Grid.Rows.Count > 0)
                                {
                                    KeyEventArgs k = new KeyEventArgs(e.Key);
                                    this.Acc_Grid_KeyDown(sender, k);
                                    //e.NextCtrl = this.Dmd_Grid;
                                }
                                else
                                {
                                    e.NextCtrl = this.TargetDiv_tComboEditor;
                                }
                                break;
                            }
                        default:
                            {
                                return;
                            }
                    }
                }

            }	
            // 2009.01.14 Add <<<
		}

		/// <summary>SecCode_tComboEditor_ValueChanged�C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �I���f�[�^���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void SecCode_tComboEditor_ValueChanged(object sender, System.EventArgs e)
		{
			// �I���ڋq�̔��|�E�x���̑O�����擾����
			if ( this.SecCode_tComboEditor.SelectedIndex == -1 ) return;
			// �\�����_��ύX���ꂽ��w�肳�ꂽ���_�̔��|�E�x������\������
			// ���ݑI������Ă��鋒�_�̏����擾����
			string secCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
			
			Form customForm = (Form)this._arrayTypeObj;
			if ((this._arrayTypeObj.SectionCodeData != secCode ) && (customForm.Visible == true))
			{
				customForm.Hide();
			}
			
			// �ӏ��̉�ʏ��̃N���A
			claim_panel_Clear();

			if ( this.SupplierCode_tNedit.GetInt() != 0 )
			{
				this._dataIndexList[FIRST_INDEX]  = 0;	
				this._dataIndexList[SECOND_INDEX] = 0;	
				this._arrayTypeObj.SetDataIndexList(this._dataIndexList);

				this.Bind_DataSet.Tables[FIRST_INDEX].Clear();
				this.Bind_DataSet.Tables[SECOND_INDEX].Clear();
				
				int suppliercode  = this.SupplierCode_tNedit.GetInt() ;
                int payeecode     = this.PayeeCode_tNedit.GetInt();

                // �I���ڋq�̔��|�E�x���̑O�����擾����
                // �I���ڋq�̔��|�E�����̑O�����擾����
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                // �w��敪�̒l��n���悤�ɕύX
                //this._arrayTypeObj.DmdRec_Data_Search(claimcode, customercode, secCode);
                //this._arrayTypeObj.AccRec_Data_Search(claimcode, customercode, secCode);

                //this._arrayTypeObj.DmdRec_Data_Search(claimcode, customercode, secCode, this.TargetDiv_tComboEditor.SelectedIndex);
                //this._arrayTypeObj.AccRec_Data_Search(claimcode, customercode, secCode, this.TargetDiv_tComboEditor.SelectedIndex);
                this._arrayTypeObj.DmdRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                //MessageBox.Show("�x��:" + this._targetPayeeCode.ToString() + "/�d��:" + this._targetSupplierCode.ToString() + "/��ʂ̋��_:" + this._targetSectionCode + "/�敪:" + this.TargetDiv_tComboEditor.SelectedIndex.ToString());
                this._arrayTypeObj.AccRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                //this._arrayTypeObj.DmdRec_Data_Search(payeecode, suppliercode, secCode, this.TargetDiv_tComboEditor.SelectedIndex);
                //this._arrayTypeObj.AccRec_Data_Search(payeecode, suppliercode, secCode, this.TargetDiv_tComboEditor.SelectedIndex);
                //this._arrayTypeObj.DmdRec_Data_Search(_targetClaimCode, _targetCustomerCode, _targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                //this._arrayTypeObj.AccRec_Data_Search(_targetClaimCode, _targetCustomerCode, _targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

                //this._arrayTypeObj.DmdRec_Data_Search(claimcode,customercode, secCode);
                //this._arrayTypeObj.AccRec_Data_Search(claimcode,customercode, secCode);

				// �X�e�[�^�X�o�[�����\������
				this.StatusBarCountIndication();

				if (this.Acc_Grid.Rows.Count > 0)
				{
					this.Acc_Grid.ActiveRow = this.Acc_Grid.Rows[0];
					this.Acc_Grid.ActiveRow.Selected = true;
				}

				if (this.Dmd_Grid.Rows.Count > 0)
				{
					this.Dmd_Grid.ActiveRow = this.Dmd_Grid.Rows[0];
					this.Dmd_Grid.ActiveRow.Selected = true;
				}	

				this._arrayTypeObj.SectionCodeData = secCode;
				// �L����TAB�̏��ŕ\������
				ultraTabControl1_Click(sender, null);
			}
		}

		/// <summary>�C���{�^���C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �C���{�^�����I�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Modify_Button_Click(object sender, System.EventArgs e)
		{
			if ((this.ultraToolbarsManager1.Tools["Modify_ControlContainerTool"].SharedProps.Visible == false) ||
				((bool)this.Modify_Button.Tag == false))
			{
				return;
			}

            // ���_���ݒ�̎��͐V�K�s�� 
            if (String.IsNullOrEmpty(this.tNedit_SectionCode.Text))//this.SecCode_tComboEditor.SelectedIndex == -1)
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
                this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
                return;
            }
            // �d���斢�ݒ�̎��͐V�K�s�� 
            //if (this.SupplierCode_tNedit.GetInt() == 0 || String.IsNullOrEmpty(this.SupplierSnm_Label.Text))  // DEL 2009/06/29
            if (this.SupplierCode_tNedit.GetInt() == 0) // ADD 2009/06/29
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
                this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
                return;
            }
	
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = null;

			switch (this._targetData)
			{
				case (TargetData.First):
				{
					targetGrid = Acc_Grid;
					break;
				}
				case (TargetData.Second):
				{
					targetGrid = Dmd_Grid;
					break;
				}
				default:
				{
					return;
				}
			}

            // ���_�R�[�h��ҏW�t�H�[���I�u�W�F�N�g�ɕۑ�
			//this._arrayTypeObj.SectionCodeData = this.SecCode_tComboEditor.SelectedItem.DataValue.ToString();
            this._arrayTypeObj.SectionCodeData = _targetSectionCode;

			if (targetGrid.ActiveRow == null)
			{
				return;
			}

			if (targetGrid.ActiveRow.IsFilteredOut == true)
			{
				return;
			}

			CurrencyManager cm1 = (CurrencyManager)BindingContext[this.Acc_Grid.DataSource];
			CurrencyManager cm2 = (CurrencyManager)BindingContext[this.Dmd_Grid.DataSource];

			this._dataIndexList[FIRST_INDEX]  = cm1.Position;
			this._dataIndexList[SECOND_INDEX] = cm2.Position;	

			this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
			this._arrayTypeObj.CanClose = false;

			if (this._targetData == TargetData.First)
			{
				this._arrayTypeObj.TargetTableName = this._tableNameList[FIRST_INDEX];
			}
			else if (this._targetData == TargetData.Second)
			{
				this._arrayTypeObj.TargetTableName = this._tableNameList[SECOND_INDEX];
			}

			Form customForm = (Form)this._arrayTypeObj;
			customForm.StartPosition = FormStartPosition.CenterScreen;
            ( (MAKAU09130UB)customForm ).InvokerForm = this;// 2009.01.14 Add
			if (customForm.Visible == true)
			{
				customForm.Hide();
			}

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            MAKAU09130UB bForm = (MAKAU09130UB)customForm;

            // �w��敪���Z�b�g
            bForm.TargetDivType = this.TargetDiv_tComboEditor.SelectedIndex;

            // �Ǘ��c�Ə��R�[�h���Z�b�g
            //bForm.CondPaymentSectionCode = _mngSectionCode;

            // �����ϐ���n��
            bForm.CondPayeeCode = this._targetPayeeCode;
            bForm.CondPaymentSectionCode = this._targetPaymentSectionCode;
            bForm.CondSectionCode = this._targetSectionCode;
            bForm.CondSupplierCode = this._targetSupplierCode;

            bForm.TargetCustomerCode = this._targetSupplierCode;
            bForm.TargetPayeeCode = this._targetPayeeCode;
            //bForm.SectionCodeData = this._targetSectionCode;

            // --- ADD 2012/09/18 ---------->>>>>
            if (this._sumSuppEnable)
            {
                // �d���摍���I�v�V��������ݒ肷��
                bForm.Opt_sumSuppEnable = this._sumSuppEnable;
            }
            // --- ADD 2012/09/18 ----------<<<<<

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
            this._controlScreenSkin.SettingScreenSkin(customForm);  // 2009.01.14 Add
			customForm.Show(this);
		}

		/// <summary>�ڍ׃{�^���C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �ڍ׃{�^�����I�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Details_Button_Click(object sender, System.EventArgs e)
		{
			//  �ڍ׏���\������
            if (this.claim_panel.Visible == false)
            {
                this.claim_panel.Visible = true;
            }
            else
            {
                this.claim_panel.Visible = false;
            }
		}

        /// <summary>�V�K�{�^���C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �V�K�{�^�����I�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void New_Button_Click(object sender, System.EventArgs e)
		{
			if ((this.ultraToolbarsManager1.Tools["New_ControlContainerTool"].SharedProps.Visible == false) ||
				((bool)this.New_Button.Tag == false))
			{
				return;
			}

            // ���_���ݒ�̎��͐V�K�s�� 
            if (String.IsNullOrEmpty(this.tNedit_SectionCode.Text))//this.SecCode_tComboEditor.SelectedIndex == -1)
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
                this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
                return;
            }
            // �d���斢�ݒ�̎��͐V�K�s�� 
            //if (this.SupplierCode_tNedit.GetInt() == 0 || String.IsNullOrEmpty(this.SupplierSnm_Label.Text))  // DEL 2009/06/29
            if (this.SupplierCode_tNedit.GetInt() == 0) // ADD 2009/06/29
            {
                this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
                this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "���_�E�d�����ݒ肵�ĉ������B";
                return;
            }
            
            if (this._targetData == TargetData.First)
			{
				this._arrayTypeObj.TargetTableName = this._tableNameList[FIRST_INDEX];
				this._dataIndexList[FIRST_INDEX] = -1;
			}
			else if (this._targetData == TargetData.Second)
			{
				this._arrayTypeObj.TargetTableName = this._tableNameList[SECOND_INDEX];
				this._dataIndexList[SECOND_INDEX] = -1;
			}

			this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
			this._arrayTypeObj.CanClose = false;

			//this._arrayTypeObj.SectionCodeData = this.SecCode_tComboEditor.SelectedItem.DataValue.ToString();
            this._arrayTypeObj.SectionCodeData = _targetSectionCode;
			
			Form customForm = (Form)this._arrayTypeObj;
			customForm.StartPosition = FormStartPosition.CenterScreen;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START

            // �����ϐ���n��
            MAKAU09130UB bForm = (MAKAU09130UB)customForm;
            bForm.CondPayeeCode = this._targetPayeeCode;
            bForm.CondPaymentSectionCode = this._targetPaymentSectionCode;
            bForm.CondSectionCode = this._targetSectionCode;
            bForm.CondSupplierCode = this._targetSupplierCode;

            // �d��������擾������
            bForm.GetSettledSupplierData();
            bForm.TargetDivType = this.TargetDiv_tComboEditor.SelectedIndex;

            bForm.InvokerForm = this;       // 2009.01.14 Add

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            //bForm.TargetCustomerCode = this._targetSupplierCode;
            //bForm.TargetPayeeCode = this._targetPayeeCode;
            //bForm.SectionCodeData = this._targetSectionCode;

			// ���Ƀt�H�[�����\������Ă���ꍇ�́A��U�I��������
			if (customForm.Visible == true)
			{
				customForm.Hide();
			}

            // --- ADD 2012/09/18 ---------->>>>>
            if (this._sumSuppEnable)
            {
                // �d���摍���I�v�V��������ݒ肷��
                bForm.Opt_sumSuppEnable = this._sumSuppEnable;
            }
            // --- ADD 2012/09/18 ----------<<<<<

            this._controlScreenSkin.SettingScreenSkin(customForm);      // 2009.01.14 Add
			customForm.Show(this);
		}

        /// <summary>�^�u�I���C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �^�u���I�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void ultraTabControl1_Click(object sender, System.EventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
			switch (ultraTabControl1.ActiveTab.Key)

			{
				case "campanyTab" :
				{
					ActiveControl = this.Acc_Grid;
					this._targetData = TargetData.First;
					targetGrid = this.Acc_Grid;
                    this.BlDmdTitle_Label.Text = "���|�c��";
					break;
				}
				case "customerTab":
				{
					ActiveControl = this.Dmd_Grid;
					this._targetData = TargetData.Second;
					targetGrid = this.Dmd_Grid;
                    this.BlDmdTitle_Label.Text = "�x���c��";
                    break;
				}
				default:
				{
					return;
				}
			}
			claim_panelInfoSet(targetGrid);
		}

        /// <summary>����{�^���C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^�����I�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Close_Button_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        /// <summary>Leave  �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �A�N�e�B�u�R���g���[���łȂ��Ȃ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>-----------------------</br>
        /// <br>Note       : �f�[�^�x�[�X�\������у��C�u�����d�l�ύX�̂��ߏC��</br>
        /// <br>Modifier   : ���i �r��</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
		private void SupplierCode_tNedit_Leave(object sender, System.EventArgs e)
		{
			// �d������擾
			if (this._changeFlg == false ) return;
			int supplierCode = 0;
            string secCode;

            // ���͂��ꂽ�l���擾
			supplierCode = this.SupplierCode_tNedit.GetInt();
            //if (!this.SecCode_tComboEditor.IsItemInList())
            if (String.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
            {
                TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                this.Name,
                "�d�����I������O�ɁA���_��I�����Ă��������B",
                0,
                MessageBoxButtons.OK);

                // ���ڂ��N���A
                ScreenClear();
                this.SupplierSnm_Label.Text = "";

                return;
            }

            //secCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
            secCode = this.tNedit_SectionCode.Text.Trim().PadLeft(2, '0');
			
            // �ҏW�t�H�[�����I�u�W�F�N�g�Ƃ��č쐬�i�ҏW�t�H�[�����Ɋe��p�����[�^��ۑ����Ă��邽�߁j
			Form customForm = (Form)this._arrayTypeObj;
			if ((this._arrayTypeObj.TargetCustomerCode != supplierCode) && (customForm.Visible == true))
			{
				customForm.Hide();
			}

            // ���͂���Ă��Ȃ���΃X�N���[�����N���A���ďI��
			if( supplierCode == 0 ) 
			{
				ScreenClear();

                // �s�v
                //CustomerSearchRet customerRet = new CustomerSearchRet();
				//this._arrayTypeObj.ReadCustomerData(out customerRet ,supplierCode);

				this._arrayTypeObj.TargetCustomerCode = 0;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                this._arrayTypeObj.TargetPayeeCode = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			}
			else
			{
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA MODIFY START
                // ���Ӑ��񂩂�d�������擾���Ă����������A���ڎd���������擾����悤�ɕύX
                // ���f�[�^�x�[�X�\���ύX�̂��߁�

                // �d�����ύX����Ƌ��_���N���A�����d�l���N���A���Ȃ��悤�ɕύX
				//ScreenClear();
                //this.CustomerSnm_Label.Text = "";

                // �e��֐��߂�l�󂯎M
                int status;                 // �߂�l
                int payeeCode;              // �x����R�[�h
                string paymentSectionCode;  // �x�����_�R�[�h

                // �d����R�[�h��ʂ𔻒肷�邽�߁A���́i�܂��͑I���j���ꂽ�d����R�[�h����d��������擾����
                Supplier supplierInfo;

                // �d����A�N�Z�X�N���X���g�p���Ďd��������擾
                status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, supplierCode);

                // �擾�ł����Ƃ��̂ݎd����̏����擾����
                if (supplierInfo.SupplierCd > 0)//!= null)
                {
                    if (supplierInfo.LogicalDeleteCode == 0)
                    {
                        payeeCode = supplierInfo.PayeeCode;                         // �x����R�[�h
                        paymentSectionCode = supplierInfo.PaymentSectionCode.Trim();       // �x�����_�R�[�h
                        // --- ADD 2012/09/18 ---------->>>>>
                        if (this._sumSuppEnable)
                        {
                            // �x��������d������ŏ㏑������
                            payeeCode = supplierCode;

                            // �x�����_�R�[�h����ʂŎw�肵�����_�R�[�h�ŏ㏑������
                            paymentSectionCode = secCode;
                        }
                        // --- ADD 2012/09/18 ----------<<<<<

                        // ���͎d����R�[�h�̐������`�F�b�N
                        if (this.TargetDiv_tComboEditor.SelectedIndex == TARGET_DIV_PAYEE)
                        {
                            // �w��敪��[�x����]

                            // �e�d����R�[�h�̂ݓ��͉�
                            // �e�d��������F[�d����R�[�h�Ǝx����R�[�h����v]����[��ʏ�̋��_�R�[�h�Ǝx�����_����v]
                            // --- DEL 2012/09/18 ---------->>>>>
                            //if ((supplierCode != payeeCode) || (paymentSectionCode != secCode))
                            // --- DEL 2012/09/18 ----------<<<<<
                            // --- ADD 2012/09/18 ---------->>>>>
                            if (!this._sumSuppEnable && ((supplierCode != payeeCode) || (paymentSectionCode != secCode)))
                            // --- ADD 2012/09/18 ----------<<<<<
                            {
                                TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�w��敪���u�x����v�̎��́A�e�d����R�[�h�̂ݓ��͉\�ł��B",
                                0,
                                MessageBoxButtons.OK);

                                // ���ڂ��N���A
                                ScreenClear();
                                this.SupplierSnm_Label.Text = "";
                                this.SupplierCode_tNedit.Focus();

                                return;
                            }
                        }
                        else
                        {
                            // �w��敪��[�d����]
                            // 2009.01.14 Del >>>
                            //// �q�d����R�[�h�̂ݓ��͉�
                            //// �q�d��������F[�d����R�[�h�Ǝx����R�[�h���قȂ�]�܂���[��ʏ�̋��_�R�[�h�Ǝx�����_���قȂ�]
                            //if ((supplierCode == payeeCode) && (paymentSectionCode == secCode))
                            //{
                            //    TMsgDisp.Show(
                            //    this,
                            //    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            //    this.Name,
                            //    "�w��敪���u�d����v�̎��́A�q�d����R�[�h�̂ݓ��͉\�ł��B",
                            //    0,
                            //    MessageBoxButtons.OK);

                            //    // ���ڂ��N���A
                            //    ScreenClear();
                            //    this.SupplierSnm_Label.Text = "";
                            //    this.SupplierCode_tNedit.Focus();

                            //    return;
                            //}
                            // 2009.01.14 Del <<<
                        }

                        // ��ʏ�Ƀf�[�^��z�u
                        // �d������
                        this.SupplierCode_tNedit.SetInt(supplierCode);
                        this.SupplierName_Label.Text = supplierInfo.SupplierNm1;
                        this.SupplierName2_Label.Text = supplierInfo.SupplierNm2;
                        this.SupplierSnm_Label.Text = supplierInfo.SupplierSnm;

                        // �x������i��\���t�B�[���h�j
                        this.PayeeCode_tNedit.SetInt(payeeCode);
                        this.PayeeName_Label.Text = supplierInfo.PayeeName;
                        this.PayeeName2_Label.Text = supplierInfo.PayeeName2;
                        this.PayeeSnm_Label.Text = supplierInfo.PayeeSnm;
                        // --- ADD 2012/09/18 ---------->>>>>
                        if (this._sumSuppEnable)
                        {
                            // �x��������d������ŏ㏑������i��\���t�B�[���h�j
                            this.PayeeCode_tNedit.SetInt(supplierCode);
                            this.PayeeName_Label.Text = supplierInfo.SupplierNm1;
                            this.PayeeName2_Label.Text = supplierInfo.SupplierNm2;
                            this.PayeeSnm_Label.Text = supplierInfo.SupplierSnm;
                        }
                        // --- ADD 2012/09/18 ----------<<<<<

                        // ���ߓ�
                        this.TotalDay_Label.Text = supplierInfo.PaymentTotalDay.ToString();

                        // �����p�̃v���C�x�[�g�ϐ��ɒl��ۑ�
                        this._targetSupplierCode = supplierCode;
                        this._targetPayeeCode = payeeCode;
                        this._targetSectionCode = secCode;
                        this._targetPaymentSectionCode = paymentSectionCode;

                        // �o�b�N�G���h �I�u�W�F�N�g�ɕۑ�
                        //MAKAU09130UB bForm = (MAKAU09130UB)this._arrayTypeObj;
                        //bForm.CondPayeeCode = payeeCode;
                        //bForm.CondSupplierCode = supplierCode;
                        //bForm.CondSectionCode = secCode;
                        this._arrayTypeObj.TargetPayeeCode = payeeCode;
                        this._arrayTypeObj.TargetCustomerCode = supplierCode;
                        this._arrayTypeObj.SectionCodeData = secCode;

                        // ���擾����

                        // �I���ڋq�̔��|�E�x���̑O�����擾����
                        // �I���ڋq�̔��|�E�����̑O�����擾����
                        status = this._arrayTypeObj.DmdRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                        status = this._arrayTypeObj.AccRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);

                        // �X�e�[�^�X�o�[�����\������
                        this.StatusBarCountIndication();

                        if (this.Acc_Grid.Rows.Count > 0)
                        {
                            this.Acc_Grid.ActiveRow = this.Acc_Grid.Rows[0];
                            this.Acc_Grid.ActiveRow.Selected = true;
                        }

                        if (this.Dmd_Grid.Rows.Count > 0)
                        {
                            this.Dmd_Grid.ActiveRow = this.Dmd_Grid.Rows[0];
                            this.Dmd_Grid.ActiveRow.Selected = true;
                        }

                        this._arrayTypeObj.SectionCodeData = secCode;
                        // �L����TAB�̏��ŕ\������
                        ultraTabControl1_Click(sender, null);

                        // �����ΏۂƂ��ēo�^
                    }
                    else
                    {
                        TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                            "�w�肳�ꂽ�d����͍폜����Ă��܂��B", 0, MessageBoxButtons.OK);

                        // ���ڂ��N���A
                        ScreenClear();
                        this.SupplierSnm_Label.Text = "";
                        this.SupplierCode_tNedit.Focus();

                        return;
                    }
                    
                #region �s�v
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA DEL START
                //CustomerInfo customerInfo;
                //int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, supplierCode, out customerInfo);

                //if (customerInfo != null)
                //{
                    // ���͂��ꂽ���Ӑ�R�[�h�ɕR�Â�������R�[�h���瓾�Ӑ�����擾
                    //CustomerInfo customerInfo2;
                    //status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerInfo.ClaimCode, out customerInfo2);

                    // �Ǘ��c�Ə��R�[�h��ۑ�
                    //_condPaymentSectionCode = customerInfo2.CondPaymentSectionCode;
                //}
        
                //CustomerSearchRet customerRet = new CustomerSearchRet();
                //this._arrayTypeObj.ReadCustomerData(out customerRet, supplierCode);
                //if (customerRet != null)
                //{
                    //this.SupplierCode_tNedit.SetInt(supplierCode);
                    //this.SupplierName_Label.Text = customerRet.Name;
                    //this.SupplierName2_Label.Text = customerRet.Name2;
                    //this.SupplierSnm_Label.Text = customerRet.Snm;
                    //this.TotalDay_Label.Text = customerRet.TotalDay.ToString();
                    //this._arrayTypeObj.TargetCustomerCode = supplierCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    //CustomerInfo customerInfo;

                    //Supplier supplierInfo;
                    //CustSuppli custSuppli;

                    // �d����}�X�^�ǂݍ���
                    //int 
                    //status = this._supplierAcs.Search(out aList, this._enterpriseCode, this._condPaymentSectionCode);
                    //status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerRet.CustomerCode);
                    //status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, out custSuppli, this._enterpriseCode, customerRet.CustomerCode);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA DEL START
                    // ���Ӑ�Ǝd�����̊֘A�����Ȃ��Ȃ������߃`�F�b�N�̕K�v�Ȃ�
                    //if (status != 0)
                    //{
                        //status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerRet.CustomerCode, true, out customerInfo, out custSuppli);
                    //}
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA DEL END

                    //if (status != 0)
                    //{
                        // ���Ӑ惌�R�[�h�͂��邪�A�d�����񂪖���
                        //ScreenClear();
                        //this._arrayTypeObj.ReadCustomerData(out customerRet, supplierCode);
                        //this._arrayTypeObj.TargetCustomerCode = 0;
                        //this._arrayTypeObj.TargetPayeeCode = 0;
                    //}
                    //else
                    //{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
                        //if (this.TargetDiv_tComboEditor.SelectedIndex == TARGET_DIV_PAYEE)
                        //{
                            //if (this._targetData == TargetData.First)
                            //{
                                // �u������v���u���|�v�̏ꍇ
                                // ���Ӑ�R�[�h = ��ʓ��Ӑ�R�[�h
                                // ������R�[�h = ��ʓ��Ӑ�R�[�h
                                // �v�㋒�_�R�[�h = ��ʋ��_�R�[�h
                                //_targetClaimCode = supplierCode;
                                //_targetSupplierCode = supplierCode;
                                //_targetSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                                //this._arrayTypeObj.TargetClaimCode = supplierCode;
                                //this._arrayTypeObj.TargetCustomerCode = supplierCode;
                                //this._arrayTypeObj.SectionCodeData = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                                //((MAKAU09110UB)this._arrayTypeObj).CondPaymentSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                        //    }
                        //    else
                        //    {
                        //        // �u������v���u�x���v�̏ꍇ
                        //        // ���Ӑ�R�[�h = ��ʓ��Ӑ�R�[�h
                        //        // ������R�[�h = ��ʓ��Ӑ�R�[�h
                        //        // �v�㋒�_�R�[�h = ��ʋ��_�R�[�h
                        //        // ���ы��_�R�[�h = ��ʋ��_�R�[�h
                        //        _targetClaimCode = supplierCode;
                        //        _targetSupplierCode = supplierCode;
                        //        _targetSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                        //        _condPaymentSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                        //        //this._arrayTypeObj.TargetCustomerCode = supplierCode;
                        //        //this._arrayTypeObj.TargetClaimCode = supplierCode;
                        //        //this._arrayTypeObj.SectionCodeData = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                        //        //((MAKAU09110UB)this._arrayTypeObj).CondPaymentSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                        //    }
                        //}
                        //else
                        //{
                        //    if (this._targetData == TargetData.First)
                        //    {
                        //        // �u���Ӑ�v���u���|�v�̏ꍇ
                        //        // ���Ӑ�R�[�h = ��ʓ��Ӑ�R�[�h
                        //        // ������R�[�h = ���Ӑ�ɑ΂��鐿����R�[�h
                        //        // �v�㋒�_�R�[�h = ������R�[�h�̊Ǘ��c�Ə��R�[�h
                        //        _targetClaimCode = customerInfo.ClaimCode;
                        //        _targetSupplierCode = supplierCode;
                        //        _targetSectionCode = customerInfo2.CondPaymentSectionCode;
                        //        //this._arrayTypeObj.TargetCustomerCode = supplierCode;
                        //        //this._arrayTypeObj.TargetClaimCode = customerInfo.ClaimCode;
                        //        //((MAKAU09110UB)this._arrayTypeObj).CondPaymentSectionCode = customerInfo2.CondPaymentSectionCode;
                        //        //this._arrayTypeObj.SectionCodeData = (string)this.SecCode_tComboEditor.SelectedItem.DataValue; 
                        //    }
                        //    else
                        //    {
                        //        // �u���Ӑ�v���u�x���v�̏ꍇ
                        //        // ���Ӑ�R�[�h = ��ʓ��Ӑ�R�[�h
                        //        // ������R�[�h = ���Ӑ�ɑ΂��鐿����R�[�h
                        //        // �v�㋒�_�R�[�h = ������R�[�h�̊Ǘ��c�Ə��R�[�h
                        //        // ���ы��_�R�[�h = ��ʋ��_�R�[�h
                        //        _targetClaimCode = customerInfo.ClaimCode;
                        //        _targetSupplierCode = supplierCode;
                        //        _targetSectionCode = customerInfo2.CondPaymentSectionCode;
                        //        _condPaymentSectionCode = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                        //        //this._arrayTypeObj.TargetCustomerCode = supplierCode;
                        //        //this._arrayTypeObj.TargetClaimCode = customerInfo.ClaimCode;
                        //        //((MAKAU09110UB)this._arrayTypeObj).CondPaymentSectionCode = customerInfo2.CondPaymentSectionCode;
                        //        //this._arrayTypeObj.SectionCodeData = (string)this.SecCode_tComboEditor.SelectedItem.DataValue;
                        //    }
                        //    ((MAKAU09130UB)this._arrayTypeObj).CondPayeeCode = _targetClaimCode;
                        //    ((MAKAU09130UB)this._arrayTypeObj).CondSupplierCode = _targetSupplierCode;
                        //    ((MAKAU09130UB)this._arrayTypeObj).CondSectionCode = _targetSectionCode;
                        //}
                        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
                        //// �x����R�[�h�Z�b�g
                        //this.PayeeCode_tNedit.SetInt(custSuppli.PayeeCode);
                        // �x���於�̎擾�ׁ̈A�ǂݍ���
                        //status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, custSuppli.PayeeCode);
                        //if (status != 0)
                        //{
                        //    this._customerInfoAcs.ReadDBData(this._enterpriseCode, custSuppli.PayeeCode, out customerInfo);
                        //}

                        //this.PayeeName_Label.Text = customerInfo.Name;
                        //this.PayeeName2_Label.Text = customerInfo.Name2;
                        //this.PayeeSnm_Label.Text = customerInfo.CustomerSnm;


                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    //    if (customerRet.CustomerCode != 0)
                    //    {

                    //    }
                    //}
                    #endregion // �s�v
                }
                else
                {
                    // �s�v
                    //CustomerSearchRet customerRet = new CustomerSearchRet();
                    //this._arrayTypeObj.ReadCustomerData(out customerRet, supplierCode);

                    // �d�����񂪑��݂��Ȃ���΁A�f�[�^�͕\�����Ȃ�
                    this._arrayTypeObj.TargetCustomerCode = 0;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    this._arrayTypeObj.TargetPayeeCode = 0;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                    // 2008.09.29 Add Start
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name,
                        "�o�^����Ă��Ȃ��d����R�[�h�ł��B", 0, MessageBoxButtons.OK);

                    this.SupplierCode_tNedit.Clear();
                    this.SupplierSnm_Label.Text = "";
                    this.TotalDay_Label.Text = string.Empty;

                    this.SupplierCode_tNedit.Focus();
                    return;
                    // 2008.09.29 Add End
                }
			}
            
            // �X�e�[�^�X�o�[�����\������
            this.StatusBarCountIndication();
            // �L����TAB�̏��ŕ\������
            ultraTabControl1_Click(sender, e);
		}

        /// <summary>Enter �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �A�N�e�B�u�R���g���[���ɂȂ������ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void SupplierCode_tNedit_Enter(object sender, System.EventArgs e)
		{
			this._changeFlg = false;
		}

		/// <summary>ValueChanged �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �R���g���[���̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void SupplierCode_tNedit_ValueChanged(object sender, System.EventArgs e)
		{
			this._changeFlg = true;
		}

		/// <summary>�K�C�h�{�^�� �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �K�C�h�{�^�����I�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// <br>-----------------------</br>
        /// <br>Note       : �f�[�^�x�[�X�\������у��C�u�����d�l�ύX�̂��ߏC��</br>
        /// <br>Modifier   : ���i �r��</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
		private void Customer_Guide_Button_Click(object sender, System.EventArgs e)
		{
			// �d����K�C�h
            Infragistics.Win.Misc.UltraButton _pushBtn = (Infragistics.Win.Misc.UltraButton)sender;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.25 TOKUNAGA MODIFY START
            Supplier supplierInfo;
            int status = this._supplierAcs.ExecuteGuid(out supplierInfo, this._enterpriseCode, string.Empty);

            // 2009.01.14 >>>
            //// �d����R�[�h��z�u����Leave�C�x���g���R�[���i�C�x���g���Ő������`�F�b�N�Ȃǂ��s���j
            //this.SupplierCode_tNedit.SetInt(supplierInfo.SupplierCd);

            //this.SupplierCode_tNedit_Leave(sender, e);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �d����R�[�h��z�u����Leave�C�x���g���R�[���i�C�x���g���Ő������`�F�b�N�Ȃǂ��s���j
                this.SupplierCode_tNedit.SetInt(supplierInfo.SupplierCd);

                this.SupplierCode_tNedit_Leave(sender, e);
            }
            // 2009.01.14 <<<

            //SFTOK01370UA supplierGuide = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //supplierGuide.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            //supplierGuide.ShowDialog(this);

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.25 TOKUNAGA MODIFY END
        }

        #region �폜(�d����I���������C�x���g)

        ///// <summary>�d����I���������C�x���g</summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">�d����ԗ������߂�l�N���X</param>
        //private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustSuppli custSuppli;

        //    int status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, out custSuppli, this._enterpriseCode, customerSearchRet.CustomerCode);
        //    if (status != 0) {
        //        status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
        //    }

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //    }
        //    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
        //    {
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
        //            this.Name,
        //            "�I�������d����͊��ɍ폜����Ă��܂��B",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //    else
        //    {
        //        TMsgDisp.Show(this,
        //                      emErrorLevel.ERR_LEVEL_STOPDISP,
        //                      this.Name,
        //                      "�d������̎擾�Ɏ��s���܂����B",
        //                      status,
        //                      MessageBoxButtons.OK);

        //        return;
        //    }

        //    this.SupplierCode_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
        //    this.SupplierName_Label.Text = customerInfo.Name;
        //    this.SupplierName2_Label.Text = customerInfo.Name2;
        //    this.SupplierSnm_Label.Text = customerInfo.CustomerSnm;
        //    this.TotalDay_Label.Text = customerInfo.TotalDay.ToString();

        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //    this.PayeeCode_tNedit.Text = custSuppli.PayeeCode.ToString().Trim();

        //    status = this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, this._enterpriseCode, customerSearchRet.CustomerCode);
        //    if ( status != 0 ) {
        //        status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
        //    }
        //    this.PayeeName_Label.Text = customerInfo.Name;
        //    this.PayeeName2_Label.Text = customerInfo.Name2;
        //    this.PayeeSnm_Label.Text = customerInfo.CustomerSnm;
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        //}

        #endregion �폜

        #region �O���b�h�n�C�x���g

        /// <summary>�\�[�g�`�F���W�C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�̃\�[�g�A�N�V�����̊�����ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_AfterSortChange(object sender, Infragistics.Win.UltraWinGrid.BandEventArgs e)
		{
			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			// �I���s��擪�ɔz�u����
			if (targetGrid.Rows.Count > 0)
			{
				targetGrid.ActiveRow = targetGrid.Rows[0];
				targetGrid.ActiveRow.Selected = true;
				targetGrid.Refresh();
			}
		}

        /// <summary>AfterSelectChange �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �P�ȏ�̍s�A�Z���A�܂��͗�I�u�W�F�N�g���I���܂��͑I���������ꂽ��ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_AfterSelectChange(object sender, Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs e)
		{
			// �{���ΏۃO���b�h���قȂ�A�s�|�W�V�������ύX���ꂽ�ꍇ�́A�q��ʂ������I�ɔ�\���Ƃ���
			string targetTableName = "";
			Form customForm = (Form)this._arrayTypeObj;

			Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

			if (this._targetData == TargetData.First)
			{
				targetTableName = this._tableNameList[FIRST_INDEX];
			}
			if (this._targetData == TargetData.Second)
			{
				targetTableName = this._tableNameList[SECOND_INDEX];
			}

			if ((this._arrayTypeObj.TargetTableName != targetTableName) && (customForm.Visible == true))
			{
				customForm.Hide();
			}

			CurrencyManager cm = (CurrencyManager)BindingContext[targetGrid.DataSource];

			if (this._targetData == TargetData.First)
			{
				this._dataIndexList[FIRST_INDEX] = cm.Position;	
			}
			if (this._targetData == TargetData.Second)
			{
				this._dataIndexList[SECOND_INDEX] = cm.Position;	
			}

			this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
		}

		/// <summary>KeyDown�C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �L�[�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case (Keys.Return):
				{
					Modify_Button_Click(Modify_Button, e);

					break;
				}
				case (Keys.Tab):
				{
					switch (this._targetData)
					{
						case (TargetData.First):
						{
							this.ActiveControl = this.Dmd_Grid;
							break;
						}
						case (TargetData.Second):
						{
							this.ActiveControl = this.Acc_Grid;
							break;
						}
						default:
						{
							return;
						}
					}

					break;
				}
			}
		}

        /// <summary>Enter �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �O���b�h���I�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Acc_Grid_Enter(object sender, System.EventArgs e)
		{
			this._targetData = TargetData.First;	
			this.ButtonEnabledControl(this._targetData);
			this.SFCMN09000UE_VisibleChanged(this, new EventArgs());
		}

        /// <summary>Enter �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �O���b�h���I�����ꂽ���ɔ������܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Dmd_Grid_Enter(object sender, System.EventArgs e)
		{
			this._targetData = TargetData.Second;	
			this.ButtonEnabledControl(this._targetData);
			this.SFCMN09000UE_VisibleChanged(this, new EventArgs());
		}

        /// <summary>CheckedChanged	�C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ��̃T�C�Y��������������`�F�b�N�G�f�B�^�R���g���[����Checked
		///	                 �v���p�e�B���ύX�����Ƃ��ɔ������܂��B
		///	                 �O���b�h���AutoResize���\�b�h�����s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AutoFillToSecondGridColumn_CheckedChanged(object sender, System.EventArgs e)
		{
			bool result =  this.AutoFillToSecondGridColumn_CheckEditor.Checked;
            if (result == false)
                this.Dmd_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            else
                this.Dmd_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            if (this.AutoFillToSecondGridColumn_CheckEditor.Checked == false)
			{
				for (int i = 0; i < this.Dmd_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					this.Dmd_Grid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
				}
			}
		}

        /// <summary>CheckedChanged	�C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ��̃T�C�Y��������������`�F�b�N�G�f�B�^�R���g���[����Checked
		///	                 �v���p�e�B���ύX�����Ƃ��ɔ������܂��B
		///	               �@�O���b�h���AutoResize���\�b�h�����s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void AutoFillToFirstGridColumn_CheckedChanged(object sender, System.EventArgs e)
		{
			bool result =  this.AutoFillToFirstGridColumn_CheckEditor.Checked;
            if (result == false)
                this.Acc_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            else
                this.Acc_Grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            if (this.AutoFillToFirstGridColumn_CheckEditor.Checked == false)
			{
				for (int i = 0; i < this.Acc_Grid.DisplayLayout.Bands[0].Columns.Count; i++)
				{
					this.Acc_Grid.DisplayLayout.Bands[0].Columns[i].PerformAutoResize();
				}
			}
        }

        #endregion // �O���b�h�n�C�x���g

        /// <summary>�^�C�}�[�C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �I���������Ɏ��s���܂��B</br>
        /// <br>Programmer : 30154 �����@���m</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		private void Close_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Close_Timer.Enabled = false;

			if (this._underExtractionFlg == false)
			{	
				Form customForm = (Form)this._arrayTypeObj;
				customForm.Close();
				this.Close();
			}
			else
			{
				this.Close_Timer.Enabled = true;
			}
		}

        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            SecInfoSet sectionInfo;
            int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out sectionInfo);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_SectionCode.Text = sectionInfo.SectionCode.TrimEnd();
                // 2009.01.14 >>>
                //this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                this.SectionName_Label.Text = sectionInfo.SectionGuideNm.TrimEnd();
                // 2009.01.14 <<<
            }
            else
            {
                // 2009.01.14 >>>
                //this.tNedit_SectionCode.Clear();
                //this.tEdit_SectionName.Clear();
                // 2009.01.14 <<<
            }
        }

        /// <summary>
        /// ���_�R�[�hLeave����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tNedit_SectionCode_Leave(object sender, EventArgs e)
        {
            // 2008.11.17 del start [7895]
            //// ���_�R�[�h���͒l���擾
            //int sectionCd = this.tNedit_SectionCode.GetInt();
            //string sectionCode = this.tNedit_SectionCode.Text.Trim().PadLeft(2, '0');
            ////this.tNedit_SectionCode.Text = sectionCode;

            //// ���_�R�[�h�����͂���Ă���ꍇ�̂ݕϊ�
            //if (sectionCd == 0)
            //{
            //    // �x�����o���H
            //    // 2008.11.17 del start [7887]
            //    //TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
            //    //          "���_�R�[�h�͕K�{���͂ł��B", -1, MessageBoxButtons.OK);
            //    // 2008.11.17 del end [7887]
            //    this.tNedit_SectionCode.Clear();
            //    this.tEdit_SectionName.Clear();
            //    this.tNedit_SectionCode.Focus();
            //    return;
            //}
            //else // if (!String.IsNullOrEmpty(sectionCode))
            //{
            //    SecInfoSet sectionInfo;
            //    int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();

            //        if (!String.IsNullOrEmpty(this.SupplierCode_tNedit.Text.Trim()))
            //        {
            //            this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "";
            //            this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "";
            //        }
            //    }
            //    else
            //    {
            //        // �x�����o���H
            //        TMsgDisp.Show(
            //                  this,
            //                  emErrorLevel.ERR_LEVEL_INFO,
            //                  this.Name,
            //                  "���͂��ꂽ���_�͑��݂��܂���B",
            //                  -1,
            //                  MessageBoxButtons.OK);
            //        this.tNedit_SectionCode.Clear();
            //        this.tEdit_SectionName.Clear();
            //        this.tNedit_SectionCode.Focus();
            //        return;
            //    }
            //}

            //// ��ʏ�����
            ////this._dataIndexList[FIRST_INDEX] = 0;
            ////this._dataIndexList[SECOND_INDEX] = 0;
            ////this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
            ////if (this.Bind_DataSet.Tables.Count > 0)
            ////{
            ////    this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]].Clear();
            ////    this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]].Clear();
            ////}

            //// 0�l�߂̋��_�R�[�h���Z�b�g
            //this.tNedit_SectionCode.Text = sectionCode;

            //// �I���ڋq�̔��|�E�x���̑O�����擾����
            //Form customForm = (Form)this._arrayTypeObj;
            //if ((this._arrayTypeObj.SectionCodeData != sectionCode) && (customForm.Visible == true))
            //{
            //    customForm.Hide();
            //}

            //// �ӏ��̉�ʏ��̃N���A
            //claim_panel_Clear();

            //if (this.SupplierCode_tNedit.GetInt() != 0)
            //{
            //    this._dataIndexList[FIRST_INDEX] = 0;
            //    this._dataIndexList[SECOND_INDEX] = 0;
            //    this._arrayTypeObj.SetDataIndexList(this._dataIndexList);

            //    this.Bind_DataSet.Tables[FIRST_INDEX].Clear();
            //    this.Bind_DataSet.Tables[SECOND_INDEX].Clear();

            //    int suppliercode = this.SupplierCode_tNedit.GetInt();
            //    int payeecode = this.PayeeCode_tNedit.GetInt();

            //    Supplier supplierInfo;
            //    // �d����A�N�Z�X�N���X���g�p���Ďd��������擾
            //    int status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, suppliercode);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        string paymentSectionCode = supplierInfo.PaymentSectionCode;       // �x�����_�R�[�h

            //        this._targetSectionCode = sectionCode;
            //        this._targetSupplierCode = suppliercode;
            //        this._targetPayeeCode = payeecode;
            //        this._targetPaymentSectionCode = paymentSectionCode;

            //        // �I���ڋq�̔��|�E�x���̑O�����擾����
            //        // �I���ڋq�̔��|�E�����̑O�����擾����
            //        status = this._arrayTypeObj.DmdRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
            //        status = this._arrayTypeObj.AccRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);

            //        // �X�e�[�^�X�o�[�����\������
            //        this.StatusBarCountIndication();

            //        if (this.Acc_Grid.Rows.Count > 0)
            //        {
            //            this.Acc_Grid.ActiveRow = this.Acc_Grid.Rows[0];
            //            this.Acc_Grid.ActiveRow.Selected = true;
            //        }

            //        if (this.Dmd_Grid.Rows.Count > 0)
            //        {
            //            this.Dmd_Grid.ActiveRow = this.Dmd_Grid.Rows[0];
            //            this.Dmd_Grid.ActiveRow.Selected = true;
            //        }

            //        this._arrayTypeObj.SectionCodeData = sectionCode;
            //        // �L����TAB�̏��ŕ\������
            //        ultraTabControl1_Click(sender, null);


            //        // 2008.11.17 add start [7895]
            //        // �d����R�[�h��
            //        this.SupplierCode_tNedit.Focus();
            //        // 2008.11.17 add end [7895]

            //    }
            //}
            // 2008.11.17 del end [7895]
        }

        // 2008.11.17 add start [7895]
        /// <summary>
        /// ���_�R�[�h���灪�L�[�ȊO�Ńt�H�[�J�X���ڑ������ۂɍČ�������
        /// </summary>
        private void ResearchFromSectionCode(bool moveUpward)
        {
            // ���_�R�[�h���͒l���擾
            int sectionCd = this.tNedit_SectionCode.GetInt();
            string sectionCode = this.tNedit_SectionCode.Text.Trim().PadLeft(2, '0');
            //this.tNedit_SectionCode.Text = sectionCode;

            // ���_�R�[�h�����͂���Ă���ꍇ�̂ݕϊ�
            //if (sectionCd == 0)
            if (String.IsNullOrEmpty(this.tNedit_SectionCode.Text.Trim()))
            {
                // �x�����o���H
                // 2008.11.17 del start [7887]
                //TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                //          "���_�R�[�h�͕K�{���͂ł��B", -1, MessageBoxButtons.OK);
                // 2008.11.17 del end [7887]
                this.tNedit_SectionCode.Clear();
                // 2009.01.14 >>>
                //this.tEdit_SectionName.Clear();
                this.SectionName_Label.Text = string.Empty;
                // 2009.01.14 <<<
                this.tNedit_SectionCode.Focus();
                return;
            }
            //else if (this.tNedit_SectionCode.Text.Trim().Equals("0") || this.tNedit_SectionCode.Text.Trim().Equals("00"))
            //{
            //    // �e���肪����̂őS�Ћ��ʂ͑I��s��
            //    // 00 �̏ꍇ�́u�S�Ћ��ʁv
            //    this.tNedit_SectionCode.Text = "00";
            //    this.tEdit_SectionName.Text = "�S�Ћ���";
            //}
            else // if (!String.IsNullOrEmpty(sectionCode))
            {
                SecInfoSet sectionInfo;
                int status = this._secInfoSetAcs.Read(out sectionInfo, this._enterpriseCode, sectionCode);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (sectionInfo.LogicalDeleteCode == 0))
                {
                    // 2009.01.14 >>>
                    //this.tEdit_SectionName.Text = sectionInfo.SectionGuideNm.TrimEnd();
                    this.SectionName_Label.Text = sectionInfo.SectionGuideNm.TrimEnd();
                    // 2009.01.14 <<<

                    if (!String.IsNullOrEmpty(this.SupplierCode_tNedit.Text.Trim()))
                    {
                        this.First_StatusBar.Panels["SearchCount_StatusPanel"].Text = "";
                        this.Second_StatusBar.Panels["SearchCount_StatusPanel"].Text = "";
                    }
                }
                else
                {
                    // �x�����o���H
                    TMsgDisp.Show(
                              this,
                              emErrorLevel.ERR_LEVEL_INFO,
                              this.Name,
                              "���͂��ꂽ���_�͑��݂��܂���B",
                              -1,
                              MessageBoxButtons.OK);
                    this.tNedit_SectionCode.Clear();
                    // 2009.01.14 >>>
                    //this.tEdit_SectionName.Clear();
                    this.SectionName_Label.Text = string.Empty;
                    // 2009.01.14 <<<
                    this.tNedit_SectionCode.Focus();
                    return;
                }
            }

            // ��ʏ�����
            //this._dataIndexList[FIRST_INDEX] = 0;
            //this._dataIndexList[SECOND_INDEX] = 0;
            //this._arrayTypeObj.SetDataIndexList(this._dataIndexList);
            //if (this.Bind_DataSet.Tables.Count > 0)
            //{
            //    this.Bind_DataSet.Tables[this._tableNameList[FIRST_INDEX]].Clear();
            //    this.Bind_DataSet.Tables[this._tableNameList[SECOND_INDEX]].Clear();
            //}

            // 0�l�߂̋��_�R�[�h���Z�b�g
            this.tNedit_SectionCode.Text = sectionCode;

            // �I���ڋq�̔��|�E�x���̑O�����擾����
            Form customForm = (Form)this._arrayTypeObj;
            if ((this._arrayTypeObj.SectionCodeData != sectionCode) && (customForm.Visible == true))
            {
                customForm.Hide();
            }

            // �ӏ��̉�ʏ��̃N���A
            claim_panel_Clear();

            if (this.SupplierCode_tNedit.GetInt() != 0)
            {
                this._dataIndexList[FIRST_INDEX] = 0;
                this._dataIndexList[SECOND_INDEX] = 0;
                this._arrayTypeObj.SetDataIndexList(this._dataIndexList);

                this.Bind_DataSet.Tables[FIRST_INDEX].Clear();
                this.Bind_DataSet.Tables[SECOND_INDEX].Clear();

                int suppliercode = this.SupplierCode_tNedit.GetInt();
                int payeecode = this.PayeeCode_tNedit.GetInt();

                Supplier supplierInfo;
                // �d����A�N�Z�X�N���X���g�p���Ďd��������擾
                int status = this._supplierAcs.Read(out supplierInfo, this._enterpriseCode, suppliercode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    string paymentSectionCode = supplierInfo.PaymentSectionCode;       // �x�����_�R�[�h

                    // --- ADD 2012/09/18 ---------->>>>>
                    if (this._sumSuppEnable)
                    {
                        // �x�����_�R�[�h����ʂŎw�肵�����_�R�[�h�ŏ㏑������
                        paymentSectionCode = sectionCode;
                    }
                    // --- ADD 2012/09/18 ----------<<<<<

                    this._targetSectionCode = sectionCode;
                    this._targetSupplierCode = suppliercode;
                    this._targetPayeeCode = payeecode;
                    this._targetPaymentSectionCode = paymentSectionCode;

                    // �I���ڋq�̔��|�E�x���̑O�����擾����
                    // �I���ڋq�̔��|�E�����̑O�����擾����
                    status = this._arrayTypeObj.DmdRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);
                    status = this._arrayTypeObj.AccRec_Data_Search(this._targetPayeeCode, this._targetSupplierCode, this._targetSectionCode, this.TargetDiv_tComboEditor.SelectedIndex);

                    // �X�e�[�^�X�o�[�����\������
                    this.StatusBarCountIndication();

                    if (this.Acc_Grid.Rows.Count > 0)
                    {
                        this.Acc_Grid.ActiveRow = this.Acc_Grid.Rows[0];
                        this.Acc_Grid.ActiveRow.Selected = true;
                    }

                    if (this.Dmd_Grid.Rows.Count > 0)
                    {
                        this.Dmd_Grid.ActiveRow = this.Dmd_Grid.Rows[0];
                        this.Dmd_Grid.ActiveRow.Selected = true;
                    }

                    this._arrayTypeObj.SectionCodeData = sectionCode;
                    // �L����TAB�̏��ŕ\������
                    ultraTabControl1_Click(null, null);

                    if (moveUpward)
                    {
                        // �w��敪��
                        this.TargetDiv_tComboEditor.Focus();
                    }
                    else
                    {
                        // �d����R�[�h��
                        this.SupplierCode_tNedit.Focus();
                    }
                }
            }
        }
        // 2008.11.17 add end [7895]

        private void TargetDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.SupplierCode_tNedit.Text.Trim().Length > 0)
            {
                // �d����R�[�h���N���A���邩����
                if (TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�w��敪���ύX�����ƁA���ݓ��͂���Ă���d���悪�N���A����܂��B",
                        0,
                        MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    // ���΂̑I�������Z�b�g
                    if (this.TargetDiv_tComboEditor.SelectedIndex == TARGET_DIV_PAYEE)
                    {
                        this.TargetDiv_tComboEditor.SelectedIndex = TARGET_DIV_SUPPLIER;
                    }
                    else
                    {
                        this.TargetDiv_tComboEditor.SelectedIndex = TARGET_DIV_PAYEE;
                    }
                }
                else
                {
                    // ���ڂ��N���A
                    this.SupplierCode_tNedit.Clear();
                    SupplierCode_tNedit_Leave(null, null);
                }
            }
        }

        private void tNedit_SectionCode_ValueChanged(object sender, EventArgs e)
        {
 
        }

        private void MAKAU09130UA_Shown(object sender, EventArgs e)
        {
            SupplierCode_tNedit.Focus();
        }
	}
    # endregion
}

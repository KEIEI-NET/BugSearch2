using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller.Util; // ADD 2008/12/18 [9352]

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�E�`���[�g��������t�H�[���N���X
    /// </summary>
    /// <br>UpdateNote  : 2008/12/18 30462 �s�V�m���@�o�O�C��</br>
    /// <br>              2009/01/30       �Ɠc�M�u�@�s��Ή�[9828][9841]</br>
    /// <br>              2009/02/23       ���r���@�s��Ή�[11812]</br>
    /// <br>              2009/02/24       ���r���@�s��Ή�[11809]</br>
    /// <br>              2009/03/05       �Ɠc�M�u�@�s��Ή�[12187]</br>
    public class DCTOK02090UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer,
        //IPrintConditionInpTypeChart, // DEL 2009/02/23
        IPrintConditionInpTypeCondition /* �Ȃ��Ă������悤��������폜��*/

	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel DCTOK02090UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private ToolTip toolTip1;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
		private Infragistics.Win.Misc.UltraButton SalesEmployeeCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton SalesEmployeeCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraLabel ultraLbK_SalesEmp;
		private Infragistics.Win.Misc.UltraLabel ultraLabel_T2;
		private TNedit tNedit_CustomerCode_Ed;
		private Infragistics.Win.Misc.UltraLabel ultraLbK_Customer;
		private TNedit tNedit_CustomerCode_St;
		private Infragistics.Win.Misc.UltraLabel ultraLabel_T1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private TComboEditor tComboEditor_PrintType;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_TotalWay;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_MoneyUnit;
		private TDateEdit ItdedDateEdRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private TDateEdit ItdedDateStRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraLabel ultraLabel13;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraLabel ultraLabel28;
		private Infragistics.Win.Misc.UltraLabel ultraLabel29;
		private Infragistics.Win.Misc.UltraLabel ultraLabel30;
		private Infragistics.Win.Misc.UltraLabel ultraLabel31;
		private Infragistics.Win.Misc.UltraLabel ultraLabel32;
		private Infragistics.Win.Misc.UltraLabel ultraLabel33;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private Infragistics.Win.Misc.UltraLabel ultraLabel16;
		private Infragistics.Win.Misc.UltraLabel ultraLabel27;
		private Infragistics.Win.Misc.UltraButton BusinessTypeCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton BusinessTypeCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraLabel ultraLbK_Business;
		private Infragistics.Win.Misc.UltraLabel ultraLabel_T4;
		private Infragistics.Win.Misc.UltraButton AreaCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton AreaCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraLabel ultraLbK_Area;
		private Infragistics.Win.Misc.UltraLabel ultraLabel_T3;
		private TNedit TmTotalCostLow_Nedit;
		private TNedit TmTotalCostHigh_Nedit;
		private TNedit TyGrsMarginLow_Nedit;
		private TNedit TyGrsMarginHigh_Nedit;
		private TNedit TmGrsMarginLow_Nedit;
		private TNedit TmGrsMarginHigh_Nedit;
		private TNedit TyTotalCostLow_Nedit;
		private TNedit TyTotalCostHigh_Nedit;
		private TNedit tNedit_AreaCd_St;
		private TNedit tNedit_AreaCd_Ed;
		private TNedit tNedit_SalesEmployeeCd_Ed;
		private TNedit tNedit_SalesEmployeeCd_St;
		private TNedit tNedit_BusinessTypeCode_Ed;
		private TNedit tNedit_BusinessTypeCode_St;
		private UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl2;
        private TComboEditor tComboEditor_IssueType;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TNedit tNedit_BLGoodsCode_Ed;
        private TNedit tNedit_BLGoodsCode_St;
        private Infragistics.Win.Misc.UltraButton ub_Ed_BLGoodsCodeGuide;
        private Infragistics.Win.Misc.UltraButton ub_St_BLGoodsCodeGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLbK_BLGoodsCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_T5;
        private TNedit tNedit_BLGloupCode_Ed;
        private TNedit tNedit_BLGloupCode_St;
        private Infragistics.Win.Misc.UltraButton ub_Ed_DetailGoodsGuide;
        private Infragistics.Win.Misc.UltraButton ub_St_DetailGoodsGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLbK_BLGloupCode;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_T6;
        private TNedit tNedit_GoodsLGroup_Ed;
        private TNedit tNedit_GoodsLGroup_St;
        private Infragistics.Win.Misc.UltraButton ub_Ed_GoodsLGroupGuide;
        private Infragistics.Win.Misc.UltraButton ub_St_GoodsLGroupGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLbK_GoodsLGroup;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_T7;
        private TNedit tNedit_GoodsMGroup_Ed;
        private TNedit tNedit_GoodsMGroup_St;
        private Infragistics.Win.Misc.UltraButton ub_Ed_MediumGoodsGuide;
        private Infragistics.Win.Misc.UltraButton ub_St_MediumGoodsGuide;
        private Infragistics.Win.Misc.UltraLabel ultraLbK_GoodsMGroup;
        private Infragistics.Win.Misc.UltraLabel ultraLabel_T8;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkBox_NewPage2;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkBox_NewPage;
		private System.ComponentModel.IContainer components;
		#endregion
		
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region constructer

		/// <summary>
		/// �O�N�Δ�\UI�N���X
		/// </summary>
		public DCTOK02090UA()
		{
			InitializeComponent();

			this._enterpriseCode   = LoginInfoAcquisition.EnterpriseCode;

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginWorker    = LoginInfoAcquisition.Employee.Clone();
				this._ownSectionCode = this._loginWorker.BelongSectionCode;
			}

            // �C���X�^���X����
            this._employeeAcs = new EmployeeAcs();

			//���Џ��̎擾
			this._companyInfAcs = new CompanyInfAcs();

			_companyInf = new CompanyInf();
			int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);

			//���t�`�F�b�N���i�̃C���X�^���X�𐶐�
			this._dateGetAcs = DateGetAcs.GetInstance();

		}
		#endregion

		// ===================================================================================== //
		// �j��
		// ===================================================================================== //
		#region Dispose
		/// <summary>
		/// �j��
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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.checkBox_NewPage2 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.checkBox_NewPage = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.TyGrsMarginLow_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TyGrsMarginHigh_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TmGrsMarginLow_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TmGrsMarginHigh_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TyTotalCostLow_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TyTotalCostHigh_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TmTotalCostHigh_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.TmTotalCostLow_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_PrintType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_TotalWay = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraOptionSet_MoneyUnit = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ItdedDateEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ItdedDateStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_IssueType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tNedit_GoodsMGroup_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_GoodsMGroup_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_Ed_MediumGoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_St_MediumGoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_GoodsMGroup = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T8 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsLGroup_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_GoodsLGroup_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_Ed_GoodsLGroupGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_St_GoodsLGroupGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_GoodsLGroup = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T7 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGloupCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_BLGloupCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_Ed_DetailGoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_St_DetailGoodsGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_BLGloupCode = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T6 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BLGoodsCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_BLGoodsCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ub_Ed_BLGoodsCodeGuide = new Infragistics.Win.Misc.UltraButton();
            this.ub_St_BLGoodsCodeGuide = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_BLGoodsCode = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T5 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_BusinessTypeCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_BusinessTypeCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesEmployeeCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SalesEmployeeCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AreaCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AreaCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BusinessTypeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.BusinessTypeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_Business = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T4 = new Infragistics.Win.Misc.UltraLabel();
            this.AreaCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.AreaCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_Area = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T3 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesEmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLbK_SalesEmp = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel_T2 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLbK_Customer = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel_T1 = new Infragistics.Win.Misc.UltraLabel();
            this.DCTOK02090UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TyGrsMarginLow_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyGrsMarginHigh_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmGrsMarginLow_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmGrsMarginHigh_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyTotalCostLow_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyTotalCostHigh_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmTotalCostHigh_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmTotalCostLow_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_TotalWay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_MoneyUnit)).BeginInit();
            this.ultraExplorerBarContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_IssueType)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsLGroup_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsLGroup_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesEmployeeCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesEmployeeCd_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_AreaCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_AreaCd_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).BeginInit();
            this.DCTOK02090UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.checkBox_NewPage2);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.checkBox_NewPage);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TyGrsMarginLow_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TyGrsMarginHigh_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TmGrsMarginLow_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TmGrsMarginHigh_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TyTotalCostLow_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TyTotalCostHigh_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TmTotalCostHigh_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.TmTotalCostLow_Nedit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel28);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel29);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel30);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel31);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel32);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel33);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel16);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel27);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel13);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_PrintType);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_TotalWay);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_MoneyUnit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ItdedDateEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ItdedDateStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(695, 226);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // checkBox_NewPage2
            // 
            this.checkBox_NewPage2.Location = new System.Drawing.Point(313, 91);
            this.checkBox_NewPage2.Name = "checkBox_NewPage2";
            this.checkBox_NewPage2.Size = new System.Drawing.Size(176, 18);
            this.checkBox_NewPage2.TabIndex = 7;
            this.checkBox_NewPage2.Text = "�S���Җ��ŉ���";
            this.checkBox_NewPage2.CheckedChanged += new System.EventHandler(this.checkBox_NewPage2_CheckedChanged);
            // 
            // checkBox_NewPage
            // 
            this.checkBox_NewPage.Location = new System.Drawing.Point(166, 91);
            this.checkBox_NewPage.Name = "checkBox_NewPage";
            this.checkBox_NewPage.Size = new System.Drawing.Size(141, 18);
            this.checkBox_NewPage.TabIndex = 6;
            this.checkBox_NewPage.Text = "���_���ŉ���";
            // 
            // TyGrsMarginLow_Nedit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.TextHAlignAsString = "Right";
            this.TyGrsMarginLow_Nedit.ActiveAppearance = appearance1;
            appearance2.TextHAlignAsString = "Right";
            this.TyGrsMarginLow_Nedit.Appearance = appearance2;
            this.TyGrsMarginLow_Nedit.AutoSelect = true;
            this.TyGrsMarginLow_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TyGrsMarginLow_Nedit.DataText = "";
            this.TyGrsMarginLow_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TyGrsMarginLow_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TyGrsMarginLow_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TyGrsMarginLow_Nedit.Location = new System.Drawing.Point(313, 198);
            this.TyGrsMarginLow_Nedit.MaxLength = 7;
            this.TyGrsMarginLow_Nedit.Name = "TyGrsMarginLow_Nedit";
            this.TyGrsMarginLow_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TyGrsMarginLow_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TyGrsMarginLow_Nedit.TabIndex = 15;
            // 
            // TyGrsMarginHigh_Nedit
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance3.TextHAlignAsString = "Right";
            this.TyGrsMarginHigh_Nedit.ActiveAppearance = appearance3;
            appearance4.TextHAlignAsString = "Right";
            this.TyGrsMarginHigh_Nedit.Appearance = appearance4;
            this.TyGrsMarginHigh_Nedit.AutoSelect = true;
            this.TyGrsMarginHigh_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TyGrsMarginHigh_Nedit.DataText = "";
            this.TyGrsMarginHigh_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TyGrsMarginHigh_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TyGrsMarginHigh_Nedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TyGrsMarginHigh_Nedit.Location = new System.Drawing.Point(166, 198);
            this.TyGrsMarginHigh_Nedit.MaxLength = 7;
            this.TyGrsMarginHigh_Nedit.Name = "TyGrsMarginHigh_Nedit";
            this.TyGrsMarginHigh_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TyGrsMarginHigh_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TyGrsMarginHigh_Nedit.TabIndex = 14;
            // 
            // TmGrsMarginLow_Nedit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance5.TextHAlignAsString = "Right";
            this.TmGrsMarginLow_Nedit.ActiveAppearance = appearance5;
            appearance6.TextHAlignAsString = "Right";
            this.TmGrsMarginLow_Nedit.Appearance = appearance6;
            this.TmGrsMarginLow_Nedit.AutoSelect = true;
            this.TmGrsMarginLow_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TmGrsMarginLow_Nedit.DataText = "";
            this.TmGrsMarginLow_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TmGrsMarginLow_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TmGrsMarginLow_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TmGrsMarginLow_Nedit.Location = new System.Drawing.Point(313, 171);
            this.TmGrsMarginLow_Nedit.MaxLength = 7;
            this.TmGrsMarginLow_Nedit.Name = "TmGrsMarginLow_Nedit";
            this.TmGrsMarginLow_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TmGrsMarginLow_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TmGrsMarginLow_Nedit.TabIndex = 13;
            // 
            // TmGrsMarginHigh_Nedit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance7.TextHAlignAsString = "Right";
            this.TmGrsMarginHigh_Nedit.ActiveAppearance = appearance7;
            appearance8.TextHAlignAsString = "Right";
            this.TmGrsMarginHigh_Nedit.Appearance = appearance8;
            this.TmGrsMarginHigh_Nedit.AutoSelect = true;
            this.TmGrsMarginHigh_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TmGrsMarginHigh_Nedit.DataText = "";
            this.TmGrsMarginHigh_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TmGrsMarginHigh_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TmGrsMarginHigh_Nedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TmGrsMarginHigh_Nedit.Location = new System.Drawing.Point(166, 171);
            this.TmGrsMarginHigh_Nedit.MaxLength = 7;
            this.TmGrsMarginHigh_Nedit.Name = "TmGrsMarginHigh_Nedit";
            this.TmGrsMarginHigh_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TmGrsMarginHigh_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TmGrsMarginHigh_Nedit.TabIndex = 12;
            // 
            // TyTotalCostLow_Nedit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.TextHAlignAsString = "Right";
            this.TyTotalCostLow_Nedit.ActiveAppearance = appearance9;
            appearance10.TextHAlignAsString = "Right";
            this.TyTotalCostLow_Nedit.Appearance = appearance10;
            this.TyTotalCostLow_Nedit.AutoSelect = true;
            this.TyTotalCostLow_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TyTotalCostLow_Nedit.DataText = "";
            this.TyTotalCostLow_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TyTotalCostLow_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TyTotalCostLow_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TyTotalCostLow_Nedit.Location = new System.Drawing.Point(313, 144);
            this.TyTotalCostLow_Nedit.MaxLength = 7;
            this.TyTotalCostLow_Nedit.Name = "TyTotalCostLow_Nedit";
            this.TyTotalCostLow_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TyTotalCostLow_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TyTotalCostLow_Nedit.TabIndex = 11;
            // 
            // TyTotalCostHigh_Nedit
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.TextHAlignAsString = "Right";
            this.TyTotalCostHigh_Nedit.ActiveAppearance = appearance11;
            appearance12.TextHAlignAsString = "Right";
            this.TyTotalCostHigh_Nedit.Appearance = appearance12;
            this.TyTotalCostHigh_Nedit.AutoSelect = true;
            this.TyTotalCostHigh_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TyTotalCostHigh_Nedit.DataText = "";
            this.TyTotalCostHigh_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TyTotalCostHigh_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TyTotalCostHigh_Nedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TyTotalCostHigh_Nedit.Location = new System.Drawing.Point(166, 144);
            this.TyTotalCostHigh_Nedit.MaxLength = 7;
            this.TyTotalCostHigh_Nedit.Name = "TyTotalCostHigh_Nedit";
            this.TyTotalCostHigh_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TyTotalCostHigh_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TyTotalCostHigh_Nedit.TabIndex = 10;
            // 
            // TmTotalCostHigh_Nedit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.TmTotalCostHigh_Nedit.ActiveAppearance = appearance13;
            appearance14.TextHAlignAsString = "Right";
            this.TmTotalCostHigh_Nedit.Appearance = appearance14;
            this.TmTotalCostHigh_Nedit.AutoSelect = true;
            this.TmTotalCostHigh_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TmTotalCostHigh_Nedit.DataText = "";
            this.TmTotalCostHigh_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TmTotalCostHigh_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TmTotalCostHigh_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TmTotalCostHigh_Nedit.Location = new System.Drawing.Point(166, 117);
            this.TmTotalCostHigh_Nedit.MaxLength = 7;
            this.TmTotalCostHigh_Nedit.Name = "TmTotalCostHigh_Nedit";
            this.TmTotalCostHigh_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TmTotalCostHigh_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TmTotalCostHigh_Nedit.TabIndex = 8;
            // 
            // TmTotalCostLow_Nedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Right";
            this.TmTotalCostLow_Nedit.ActiveAppearance = appearance15;
            appearance16.TextHAlignAsString = "Right";
            this.TmTotalCostLow_Nedit.Appearance = appearance16;
            this.TmTotalCostLow_Nedit.AutoSelect = true;
            this.TmTotalCostLow_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.TmTotalCostLow_Nedit.DataText = "";
            this.TmTotalCostLow_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TmTotalCostLow_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 7, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, false, true, true));
            this.TmTotalCostLow_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TmTotalCostLow_Nedit.Location = new System.Drawing.Point(313, 117);
            this.TmTotalCostLow_Nedit.MaxLength = 7;
            this.TmTotalCostLow_Nedit.Name = "TmTotalCostLow_Nedit";
            this.TmTotalCostLow_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.TmTotalCostLow_Nedit.Size = new System.Drawing.Size(66, 24);
            this.TmTotalCostLow_Nedit.TabIndex = 9;
            // 
            // ultraLabel28
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance17;
            this.ultraLabel28.Location = new System.Drawing.Point(387, 199);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel28.TabIndex = 63;
            this.ultraLabel28.Text = "���ȉ�";
            // 
            // ultraLabel29
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance18;
            this.ultraLabel29.Location = new System.Drawing.Point(240, 198);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel29.TabIndex = 61;
            this.ultraLabel29.Text = "���ȏ�";
            // 
            // ultraLabel30
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel30.Appearance = appearance19;
            this.ultraLabel30.Location = new System.Drawing.Point(14, 198);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel30.TabIndex = 59;
            this.ultraLabel30.Text = "���N�e��";
            // 
            // ultraLabel31
            // 
            appearance20.TextVAlignAsString = "Middle";
            this.ultraLabel31.Appearance = appearance20;
            this.ultraLabel31.Location = new System.Drawing.Point(387, 172);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel31.TabIndex = 58;
            this.ultraLabel31.Text = "���ȉ�";
            // 
            // ultraLabel32
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance21;
            this.ultraLabel32.Location = new System.Drawing.Point(240, 171);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel32.TabIndex = 56;
            this.ultraLabel32.Text = "���ȏ�";
            // 
            // ultraLabel33
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.ultraLabel33.Appearance = appearance22;
            this.ultraLabel33.Location = new System.Drawing.Point(14, 171);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel33.TabIndex = 54;
            this.ultraLabel33.Text = "�����e��";
            // 
            // ultraLabel14
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance23;
            this.ultraLabel14.Location = new System.Drawing.Point(387, 145);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel14.TabIndex = 53;
            this.ultraLabel14.Text = "���ȉ�";
            // 
            // ultraLabel16
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance24;
            this.ultraLabel16.Location = new System.Drawing.Point(240, 144);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel16.TabIndex = 51;
            this.ultraLabel16.Text = "���ȏ�";
            // 
            // ultraLabel27
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance25;
            this.ultraLabel27.Location = new System.Drawing.Point(14, 144);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel27.TabIndex = 49;
            this.ultraLabel27.Text = "���N������";
            // 
            // ultraLabel13
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance26;
            this.ultraLabel13.Location = new System.Drawing.Point(387, 118);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel13.TabIndex = 48;
            this.ultraLabel13.Text = "���ȉ�";
            // 
            // ultraLabel12
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance27;
            this.ultraLabel12.Location = new System.Drawing.Point(240, 117);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(60, 23);
            this.ultraLabel12.TabIndex = 46;
            this.ultraLabel12.Text = "���ȏ�";
            // 
            // ultraLabel9
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance28;
            this.ultraLabel9.Location = new System.Drawing.Point(14, 117);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel9.TabIndex = 44;
            this.ultraLabel9.Text = "����������";
            // 
            // ultraLabel7
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance29;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 88);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(76, 23);
            this.ultraLabel7.TabIndex = 42;
            this.ultraLabel7.Text = "����";
            // 
            // tComboEditor_PrintType
            // 
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintType.ActiveAppearance = appearance33;
            this.tComboEditor_PrintType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PrintType.ItemAppearance = appearance35;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "����";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "�e��";
            valueListItem3.DataValue = 2;
            valueListItem3.DisplayText = "���さ�e��";
            this.tComboEditor_PrintType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.tComboEditor_PrintType.LimitToList = true;
            this.tComboEditor_PrintType.Location = new System.Drawing.Point(512, 61);
            this.tComboEditor_PrintType.Name = "tComboEditor_PrintType";
            this.tComboEditor_PrintType.Size = new System.Drawing.Size(112, 24);
            this.tComboEditor_PrintType.TabIndex = 5;
            this.tComboEditor_PrintType.Text = "���さ�e��";
            // 
            // ultraLabel15
            // 
            appearance84.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance84;
            this.ultraLabel15.Location = new System.Drawing.Point(386, 62);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel15.TabIndex = 37;
            this.ultraLabel15.Text = "����^�C�v";
            // 
            // ultraOptionSet_TotalWay
            // 
            this.ultraOptionSet_TotalWay.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_TotalWay.CheckedIndex = 1;
            valueListItem4.DataValue = true;
            valueListItem4.DisplayText = "�S��";
            valueListItem5.DataValue = false;
            valueListItem5.DisplayText = "���_��";
            this.ultraOptionSet_TotalWay.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem4,
            valueListItem5});
            this.ultraOptionSet_TotalWay.Location = new System.Drawing.Point(165, 5);
            this.ultraOptionSet_TotalWay.Name = "ultraOptionSet_TotalWay";
            this.ultraOptionSet_TotalWay.Size = new System.Drawing.Size(150, 23);
            this.ultraOptionSet_TotalWay.TabIndex = 1;
            this.ultraOptionSet_TotalWay.Text = "���_��";
            this.ultraOptionSet_TotalWay.ValueChanged += new System.EventHandler(this.ultraOptionSet_TotalWay_ValueChanged);
            // 
            // ultraLabel2
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance34;
            this.ultraLabel2.Location = new System.Drawing.Point(15, 4);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(76, 23);
            this.ultraLabel2.TabIndex = 33;
            this.ultraLabel2.Text = "�W�v���@";
            // 
            // ultraOptionSet_MoneyUnit
            // 
            this.ultraOptionSet_MoneyUnit.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_MoneyUnit.CheckedIndex = 0;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "�~";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "��~";
            this.ultraOptionSet_MoneyUnit.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7});
            this.ultraOptionSet_MoneyUnit.Location = new System.Drawing.Point(167, 62);
            this.ultraOptionSet_MoneyUnit.Name = "ultraOptionSet_MoneyUnit";
            this.ultraOptionSet_MoneyUnit.Size = new System.Drawing.Size(112, 23);
            this.ultraOptionSet_MoneyUnit.TabIndex = 4;
            this.ultraOptionSet_MoneyUnit.Text = "�~";
            // 
            // ItdedDateEdRF_tDateEdit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ItdedDateEdRF_tDateEdit.ActiveEditAppearance = appearance36;
            this.ItdedDateEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ItdedDateEdRF_tDateEdit.CalendarDisp = true;
            this.ItdedDateEdRF_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance37.TextHAlignAsString = "Left";
            appearance37.TextVAlignAsString = "Middle";
            this.ItdedDateEdRF_tDateEdit.EditAppearance = appearance37;
            this.ItdedDateEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ItdedDateEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance38.TextHAlignAsString = "Left";
            appearance38.TextVAlignAsString = "Middle";
            this.ItdedDateEdRF_tDateEdit.LabelAppearance = appearance38;
            this.ItdedDateEdRF_tDateEdit.Location = new System.Drawing.Point(341, 32);
            this.ItdedDateEdRF_tDateEdit.Name = "ItdedDateEdRF_tDateEdit";
            this.ItdedDateEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ItdedDateEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ItdedDateEdRF_tDateEdit.Size = new System.Drawing.Size(127, 24);
            this.ItdedDateEdRF_tDateEdit.TabIndex = 3;
            this.ItdedDateEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance39;
            this.ultraLabel10.Location = new System.Drawing.Point(308, 32);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "�`";
            // 
            // ItdedDateStRF_tDateEdit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ItdedDateStRF_tDateEdit.ActiveEditAppearance = appearance40;
            this.ItdedDateStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ItdedDateStRF_tDateEdit.CalendarDisp = true;
            this.ItdedDateStRF_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.df4Y2M;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance41.TextHAlignAsString = "Left";
            appearance41.TextVAlignAsString = "Middle";
            this.ItdedDateStRF_tDateEdit.EditAppearance = appearance41;
            this.ItdedDateStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ItdedDateStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance42.TextHAlignAsString = "Left";
            appearance42.TextVAlignAsString = "Middle";
            this.ItdedDateStRF_tDateEdit.LabelAppearance = appearance42;
            this.ItdedDateStRF_tDateEdit.Location = new System.Drawing.Point(167, 32);
            this.ItdedDateStRF_tDateEdit.Name = "ItdedDateStRF_tDateEdit";
            this.ItdedDateStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ItdedDateStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ItdedDateStRF_tDateEdit.Size = new System.Drawing.Size(127, 24);
            this.ItdedDateStRF_tDateEdit.TabIndex = 2;
            this.ItdedDateStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel8
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance43;
            this.ultraLabel8.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel8.TabIndex = 22;
            this.ultraLabel8.Text = "�Ώ۔N��";
            // 
            // ultraLabel4
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance44;
            this.ultraLabel4.Location = new System.Drawing.Point(15, 61);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel4.TabIndex = 21;
            this.ultraLabel4.Text = "���z�P��";
            // 
            // ultraExplorerBarContainerControl2
            // 
            this.ultraExplorerBarContainerControl2.Controls.Add(this.tComboEditor_IssueType);
            this.ultraExplorerBarContainerControl2.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl2.Location = new System.Drawing.Point(18, 309);
            this.ultraExplorerBarContainerControl2.Name = "ultraExplorerBarContainerControl2";
            this.ultraExplorerBarContainerControl2.Size = new System.Drawing.Size(695, 40);
            this.ultraExplorerBarContainerControl2.TabIndex = 1;
            // 
            // tComboEditor_IssueType
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_IssueType.ActiveAppearance = appearance30;
            this.tComboEditor_IssueType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_IssueType.ItemAppearance = appearance31;
            this.tComboEditor_IssueType.LimitToList = true;
            this.tComboEditor_IssueType.Location = new System.Drawing.Point(166, 7);
            this.tComboEditor_IssueType.Name = "tComboEditor_IssueType";
            this.tComboEditor_IssueType.Size = new System.Drawing.Size(199, 24);
            this.tComboEditor_IssueType.TabIndex = 16;
            this.tComboEditor_IssueType.UseAppStyling = false;
            this.tComboEditor_IssueType.ValueChanged += new System.EventHandler(this.tComboEditor_IssueType_ValueChanged);
            // 
            // ultraLabel3
            // 
            appearance32.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance32;
            this.ultraLabel3.Location = new System.Drawing.Point(14, 8);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 39;
            this.ultraLabel3.Text = "���s�^�C�v";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_GoodsMGroup_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_GoodsMGroup_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_Ed_MediumGoodsGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_St_MediumGoodsGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_GoodsMGroup);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T8);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_GoodsLGroup_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_GoodsLGroup_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_Ed_GoodsLGroupGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_St_GoodsLGroupGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_GoodsLGroup);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T7);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BLGloupCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BLGloupCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_Ed_DetailGoodsGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_St_DetailGoodsGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_BLGloupCode);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T6);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BLGoodsCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BLGoodsCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_Ed_BLGoodsCodeGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ub_St_BLGoodsCodeGuide);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_BLGoodsCode);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T5);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BusinessTypeCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_BusinessTypeCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesEmployeeCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SalesEmployeeCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_AreaCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_AreaCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.BusinessTypeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.BusinessTypeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_Business);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T4);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AreaCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.AreaCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_Area);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T3);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_SalesEmp);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLbK_Customer);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel_T1);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 386);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(695, 214);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // tNedit_GoodsMGroup_Ed
            // 
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance85.TextHAlignAsString = "Left";
            this.tNedit_GoodsMGroup_Ed.ActiveAppearance = appearance85;
            appearance86.TextHAlignAsString = "Right";
            this.tNedit_GoodsMGroup_Ed.Appearance = appearance86;
            this.tNedit_GoodsMGroup_Ed.AutoSelect = true;
            this.tNedit_GoodsMGroup_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMGroup_Ed.DataText = "";
            this.tNedit_GoodsMGroup_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMGroup_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMGroup_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMGroup_Ed.Location = new System.Drawing.Point(320, 189);
            this.tNedit_GoodsMGroup_Ed.MaxLength = 4;
            this.tNedit_GoodsMGroup_Ed.Name = "tNedit_GoodsMGroup_Ed";
            this.tNedit_GoodsMGroup_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsMGroup_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMGroup_Ed.TabIndex = 27;
            // 
            // tNedit_GoodsMGroup_St
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance87.TextHAlignAsString = "Left";
            this.tNedit_GoodsMGroup_St.ActiveAppearance = appearance87;
            appearance88.TextHAlignAsString = "Right";
            this.tNedit_GoodsMGroup_St.Appearance = appearance88;
            this.tNedit_GoodsMGroup_St.AutoSelect = true;
            this.tNedit_GoodsMGroup_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMGroup_St.DataText = "";
            this.tNedit_GoodsMGroup_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMGroup_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMGroup_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMGroup_St.Location = new System.Drawing.Point(166, 189);
            this.tNedit_GoodsMGroup_St.MaxLength = 4;
            this.tNedit_GoodsMGroup_St.Name = "tNedit_GoodsMGroup_St";
            this.tNedit_GoodsMGroup_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsMGroup_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMGroup_St.TabIndex = 25;
            // 
            // ub_Ed_MediumGoodsGuide
            // 
            appearance89.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_Ed_MediumGoodsGuide.Appearance = appearance89;
            this.ub_Ed_MediumGoodsGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_Ed_MediumGoodsGuide.Location = new System.Drawing.Point(367, 189);
            this.ub_Ed_MediumGoodsGuide.Name = "ub_Ed_MediumGoodsGuide";
            this.ub_Ed_MediumGoodsGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_Ed_MediumGoodsGuide.TabIndex = 28;
            this.ub_Ed_MediumGoodsGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_Ed_MediumGoodsGuide, "���i�����ރK�C�h");
            this.ub_Ed_MediumGoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_Ed_MediumGoodsGuide.Click += new System.EventHandler(this.ub_Ed_MediumGoodsGuide_Click);
            // 
            // ub_St_MediumGoodsGuide
            // 
            appearance90.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_St_MediumGoodsGuide.Appearance = appearance90;
            this.ub_St_MediumGoodsGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_St_MediumGoodsGuide.Location = new System.Drawing.Point(213, 189);
            this.ub_St_MediumGoodsGuide.Name = "ub_St_MediumGoodsGuide";
            this.ub_St_MediumGoodsGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_St_MediumGoodsGuide.TabIndex = 26;
            this.ub_St_MediumGoodsGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_St_MediumGoodsGuide, "���i�����ރK�C�h");
            this.ub_St_MediumGoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_St_MediumGoodsGuide.Click += new System.EventHandler(this.ub_St_MediumGoodsGuide_Click);
            // 
            // ultraLbK_GoodsMGroup
            // 
            appearance91.TextVAlignAsString = "Middle";
            this.ultraLbK_GoodsMGroup.Appearance = appearance91;
            this.ultraLbK_GoodsMGroup.Location = new System.Drawing.Point(288, 190);
            this.ultraLbK_GoodsMGroup.Name = "ultraLbK_GoodsMGroup";
            this.ultraLbK_GoodsMGroup.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_GoodsMGroup.TabIndex = 115;
            this.ultraLbK_GoodsMGroup.Text = "�`";
            // 
            // ultraLabel_T8
            // 
            appearance92.TextVAlignAsString = "Middle";
            this.ultraLabel_T8.Appearance = appearance92;
            this.ultraLabel_T8.Location = new System.Drawing.Point(16, 189);
            this.ultraLabel_T8.Name = "ultraLabel_T8";
            this.ultraLabel_T8.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T8.TabIndex = 114;
            this.ultraLabel_T8.Text = "���i������";
            // 
            // tNedit_GoodsLGroup_Ed
            // 
            appearance109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance109.TextHAlignAsString = "Left";
            this.tNedit_GoodsLGroup_Ed.ActiveAppearance = appearance109;
            appearance110.TextHAlignAsString = "Right";
            this.tNedit_GoodsLGroup_Ed.Appearance = appearance110;
            this.tNedit_GoodsLGroup_Ed.AutoSelect = true;
            this.tNedit_GoodsLGroup_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsLGroup_Ed.DataText = "";
            this.tNedit_GoodsLGroup_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsLGroup_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsLGroup_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsLGroup_Ed.Location = new System.Drawing.Point(320, 164);
            this.tNedit_GoodsLGroup_Ed.MaxLength = 4;
            this.tNedit_GoodsLGroup_Ed.Name = "tNedit_GoodsLGroup_Ed";
            this.tNedit_GoodsLGroup_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsLGroup_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsLGroup_Ed.TabIndex = 23;
            // 
            // tNedit_GoodsLGroup_St
            // 
            appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance111.TextHAlignAsString = "Left";
            this.tNedit_GoodsLGroup_St.ActiveAppearance = appearance111;
            appearance112.TextHAlignAsString = "Right";
            this.tNedit_GoodsLGroup_St.Appearance = appearance112;
            this.tNedit_GoodsLGroup_St.AutoSelect = true;
            this.tNedit_GoodsLGroup_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsLGroup_St.DataText = "";
            this.tNedit_GoodsLGroup_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsLGroup_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsLGroup_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsLGroup_St.Location = new System.Drawing.Point(166, 164);
            this.tNedit_GoodsLGroup_St.MaxLength = 4;
            this.tNedit_GoodsLGroup_St.Name = "tNedit_GoodsLGroup_St";
            this.tNedit_GoodsLGroup_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_GoodsLGroup_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsLGroup_St.TabIndex = 21;
            // 
            // ub_Ed_GoodsLGroupGuide
            // 
            appearance113.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_Ed_GoodsLGroupGuide.Appearance = appearance113;
            this.ub_Ed_GoodsLGroupGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_Ed_GoodsLGroupGuide.Location = new System.Drawing.Point(367, 164);
            this.ub_Ed_GoodsLGroupGuide.Name = "ub_Ed_GoodsLGroupGuide";
            this.ub_Ed_GoodsLGroupGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_Ed_GoodsLGroupGuide.TabIndex = 24;
            this.ub_Ed_GoodsLGroupGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_Ed_GoodsLGroupGuide, "���i�啪�ރK�C�h");
            this.ub_Ed_GoodsLGroupGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_Ed_GoodsLGroupGuide.Click += new System.EventHandler(this.ub_Ed_GoodsLGroupGuide_Click);
            // 
            // ub_St_GoodsLGroupGuide
            // 
            appearance114.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_St_GoodsLGroupGuide.Appearance = appearance114;
            this.ub_St_GoodsLGroupGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_St_GoodsLGroupGuide.Location = new System.Drawing.Point(213, 164);
            this.ub_St_GoodsLGroupGuide.Name = "ub_St_GoodsLGroupGuide";
            this.ub_St_GoodsLGroupGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_St_GoodsLGroupGuide.TabIndex = 22;
            this.ub_St_GoodsLGroupGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_St_GoodsLGroupGuide, "���i�啪�ރK�C�h");
            this.ub_St_GoodsLGroupGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_St_GoodsLGroupGuide.Click += new System.EventHandler(this.ub_St_GoodsLGroupGuide_Click);
            // 
            // ultraLbK_GoodsLGroup
            // 
            appearance115.TextVAlignAsString = "Middle";
            this.ultraLbK_GoodsLGroup.Appearance = appearance115;
            this.ultraLbK_GoodsLGroup.Location = new System.Drawing.Point(288, 165);
            this.ultraLbK_GoodsLGroup.Name = "ultraLbK_GoodsLGroup";
            this.ultraLbK_GoodsLGroup.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_GoodsLGroup.TabIndex = 109;
            this.ultraLbK_GoodsLGroup.Text = "�`";
            // 
            // ultraLabel_T7
            // 
            appearance116.TextVAlignAsString = "Middle";
            this.ultraLabel_T7.Appearance = appearance116;
            this.ultraLabel_T7.Location = new System.Drawing.Point(16, 164);
            this.ultraLabel_T7.Name = "ultraLabel_T7";
            this.ultraLabel_T7.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T7.TabIndex = 108;
            this.ultraLabel_T7.Text = "���i�啪��";
            // 
            // tNedit_BLGloupCode_Ed
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance45.TextHAlignAsString = "Left";
            this.tNedit_BLGloupCode_Ed.ActiveAppearance = appearance45;
            appearance46.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode_Ed.Appearance = appearance46;
            this.tNedit_BLGloupCode_Ed.AutoSelect = true;
            this.tNedit_BLGloupCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGloupCode_Ed.DataText = "";
            this.tNedit_BLGloupCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGloupCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGloupCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGloupCode_Ed.Location = new System.Drawing.Point(320, 139);
            this.tNedit_BLGloupCode_Ed.MaxLength = 5;
            this.tNedit_BLGloupCode_Ed.Name = "tNedit_BLGloupCode_Ed";
            this.tNedit_BLGloupCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGloupCode_Ed.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGloupCode_Ed.TabIndex = 31;
            // 
            // tNedit_BLGloupCode_St
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance47.TextHAlignAsString = "Left";
            this.tNedit_BLGloupCode_St.ActiveAppearance = appearance47;
            appearance48.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode_St.Appearance = appearance48;
            this.tNedit_BLGloupCode_St.AutoSelect = true;
            this.tNedit_BLGloupCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGloupCode_St.DataText = "";
            this.tNedit_BLGloupCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGloupCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGloupCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGloupCode_St.Location = new System.Drawing.Point(166, 139);
            this.tNedit_BLGloupCode_St.MaxLength = 5;
            this.tNedit_BLGloupCode_St.Name = "tNedit_BLGloupCode_St";
            this.tNedit_BLGloupCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGloupCode_St.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGloupCode_St.TabIndex = 29;
            // 
            // ub_Ed_DetailGoodsGuide
            // 
            appearance57.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_Ed_DetailGoodsGuide.Appearance = appearance57;
            this.ub_Ed_DetailGoodsGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_Ed_DetailGoodsGuide.Location = new System.Drawing.Point(375, 139);
            this.ub_Ed_DetailGoodsGuide.Name = "ub_Ed_DetailGoodsGuide";
            this.ub_Ed_DetailGoodsGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_Ed_DetailGoodsGuide.TabIndex = 32;
            this.ub_Ed_DetailGoodsGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_Ed_DetailGoodsGuide, "�O���[�v�R�[�h�K�C�h");
            this.ub_Ed_DetailGoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_Ed_DetailGoodsGuide.Click += new System.EventHandler(this.ub_Ed_DetailGoodsGuide_Click);
            // 
            // ub_St_DetailGoodsGuide
            // 
            appearance58.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_St_DetailGoodsGuide.Appearance = appearance58;
            this.ub_St_DetailGoodsGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_St_DetailGoodsGuide.Location = new System.Drawing.Point(221, 139);
            this.ub_St_DetailGoodsGuide.Name = "ub_St_DetailGoodsGuide";
            this.ub_St_DetailGoodsGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_St_DetailGoodsGuide.TabIndex = 30;
            this.ub_St_DetailGoodsGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_St_DetailGoodsGuide, "�O���[�v�R�[�h�K�C�h");
            this.ub_St_DetailGoodsGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_St_DetailGoodsGuide.Click += new System.EventHandler(this.ub_St_DetailGoodsGuide_Click);
            // 
            // ultraLbK_BLGloupCode
            // 
            appearance59.TextVAlignAsString = "Middle";
            this.ultraLbK_BLGloupCode.Appearance = appearance59;
            this.ultraLbK_BLGloupCode.Location = new System.Drawing.Point(288, 140);
            this.ultraLbK_BLGloupCode.Name = "ultraLbK_BLGloupCode";
            this.ultraLbK_BLGloupCode.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_BLGloupCode.TabIndex = 103;
            this.ultraLbK_BLGloupCode.Text = "�`";
            // 
            // ultraLabel_T6
            // 
            appearance60.TextVAlignAsString = "Middle";
            this.ultraLabel_T6.Appearance = appearance60;
            this.ultraLabel_T6.Location = new System.Drawing.Point(16, 139);
            this.ultraLabel_T6.Name = "ultraLabel_T6";
            this.ultraLabel_T6.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T6.TabIndex = 102;
            this.ultraLabel_T6.Text = "�O���[�v�R�[�h";
            // 
            // tNedit_BLGoodsCode_Ed
            // 
            appearance95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance95.TextHAlignAsString = "Left";
            this.tNedit_BLGoodsCode_Ed.ActiveAppearance = appearance95;
            appearance96.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode_Ed.Appearance = appearance96;
            this.tNedit_BLGoodsCode_Ed.AutoSelect = true;
            this.tNedit_BLGoodsCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode_Ed.DataText = "";
            this.tNedit_BLGoodsCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGoodsCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGoodsCode_Ed.Location = new System.Drawing.Point(320, 114);
            this.tNedit_BLGoodsCode_Ed.MaxLength = 5;
            this.tNedit_BLGoodsCode_Ed.Name = "tNedit_BLGoodsCode_Ed";
            this.tNedit_BLGoodsCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGoodsCode_Ed.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGoodsCode_Ed.TabIndex = 19;
            // 
            // tNedit_BLGoodsCode_St
            // 
            this.tNedit_BLGoodsCode_St.AcceptsTab = true;
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance93.TextHAlignAsString = "Left";
            this.tNedit_BLGoodsCode_St.ActiveAppearance = appearance93;
            appearance94.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode_St.Appearance = appearance94;
            this.tNedit_BLGoodsCode_St.AutoSelect = true;
            this.tNedit_BLGoodsCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode_St.DataText = "";
            this.tNedit_BLGoodsCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGoodsCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGoodsCode_St.Location = new System.Drawing.Point(166, 114);
            this.tNedit_BLGoodsCode_St.MaxLength = 5;
            this.tNedit_BLGoodsCode_St.Name = "tNedit_BLGoodsCode_St";
            this.tNedit_BLGoodsCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BLGoodsCode_St.Size = new System.Drawing.Size(51, 24);
            this.tNedit_BLGoodsCode_St.TabIndex = 17;
            // 
            // ub_Ed_BLGoodsCodeGuide
            // 
            appearance97.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_Ed_BLGoodsCodeGuide.Appearance = appearance97;
            this.ub_Ed_BLGoodsCodeGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_Ed_BLGoodsCodeGuide.Location = new System.Drawing.Point(375, 114);
            this.ub_Ed_BLGoodsCodeGuide.Name = "ub_Ed_BLGoodsCodeGuide";
            this.ub_Ed_BLGoodsCodeGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_Ed_BLGoodsCodeGuide.TabIndex = 20;
            this.ub_Ed_BLGoodsCodeGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_Ed_BLGoodsCodeGuide, "�a�k�R�[�h�K�C�h");
            this.ub_Ed_BLGoodsCodeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_Ed_BLGoodsCodeGuide.Click += new System.EventHandler(this.ub_Ed_BLGoodsCodeGuide_Click);
            // 
            // ub_St_BLGoodsCodeGuide
            // 
            appearance98.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.ub_St_BLGoodsCodeGuide.Appearance = appearance98;
            this.ub_St_BLGoodsCodeGuide.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ub_St_BLGoodsCodeGuide.Location = new System.Drawing.Point(221, 114);
            this.ub_St_BLGoodsCodeGuide.Name = "ub_St_BLGoodsCodeGuide";
            this.ub_St_BLGoodsCodeGuide.Size = new System.Drawing.Size(25, 25);
            this.ub_St_BLGoodsCodeGuide.TabIndex = 18;
            this.ub_St_BLGoodsCodeGuide.TabStop = false;
            this.toolTip1.SetToolTip(this.ub_St_BLGoodsCodeGuide, "�a�k�R�[�h�K�C�h");
            this.ub_St_BLGoodsCodeGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.ub_St_BLGoodsCodeGuide.Click += new System.EventHandler(this.ub_St_BLGoodsCodeGuide_Click);
            // 
            // ultraLbK_BLGoodsCode
            // 
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLbK_BLGoodsCode.Appearance = appearance99;
            this.ultraLbK_BLGoodsCode.Location = new System.Drawing.Point(288, 115);
            this.ultraLbK_BLGoodsCode.Name = "ultraLbK_BLGoodsCode";
            this.ultraLbK_BLGoodsCode.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_BLGoodsCode.TabIndex = 97;
            this.ultraLbK_BLGoodsCode.Text = "�`";
            // 
            // ultraLabel_T5
            // 
            appearance100.TextVAlignAsString = "Middle";
            this.ultraLabel_T5.Appearance = appearance100;
            this.ultraLabel_T5.Location = new System.Drawing.Point(16, 114);
            this.ultraLabel_T5.Name = "ultraLabel_T5";
            this.ultraLabel_T5.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T5.TabIndex = 96;
            this.ultraLabel_T5.Text = "�a�k�R�[�h";
            // 
            // tNedit_BusinessTypeCode_Ed
            // 
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance101.TextHAlignAsString = "Left";
            this.tNedit_BusinessTypeCode_Ed.ActiveAppearance = appearance101;
            appearance102.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_Ed.Appearance = appearance102;
            this.tNedit_BusinessTypeCode_Ed.AutoSelect = true;
            this.tNedit_BusinessTypeCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BusinessTypeCode_Ed.DataText = "";
            this.tNedit_BusinessTypeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BusinessTypeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BusinessTypeCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BusinessTypeCode_Ed.Location = new System.Drawing.Point(320, 88);
            this.tNedit_BusinessTypeCode_Ed.MaxLength = 4;
            this.tNedit_BusinessTypeCode_Ed.Name = "tNedit_BusinessTypeCode_Ed";
            this.tNedit_BusinessTypeCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BusinessTypeCode_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_BusinessTypeCode_Ed.TabIndex = 15;
            // 
            // tNedit_BusinessTypeCode_St
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance103.TextHAlignAsString = "Left";
            this.tNedit_BusinessTypeCode_St.ActiveAppearance = appearance103;
            appearance104.TextHAlignAsString = "Right";
            this.tNedit_BusinessTypeCode_St.Appearance = appearance104;
            this.tNedit_BusinessTypeCode_St.AutoSelect = true;
            this.tNedit_BusinessTypeCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BusinessTypeCode_St.DataText = "";
            this.tNedit_BusinessTypeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BusinessTypeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BusinessTypeCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BusinessTypeCode_St.Location = new System.Drawing.Point(166, 88);
            this.tNedit_BusinessTypeCode_St.MaxLength = 4;
            this.tNedit_BusinessTypeCode_St.Name = "tNedit_BusinessTypeCode_St";
            this.tNedit_BusinessTypeCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_BusinessTypeCode_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_BusinessTypeCode_St.TabIndex = 13;
            // 
            // tNedit_SalesEmployeeCd_Ed
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.TextHAlignAsString = "Left";
            this.tNedit_SalesEmployeeCd_Ed.ActiveAppearance = appearance49;
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_SalesEmployeeCd_Ed.Appearance = appearance50;
            this.tNedit_SalesEmployeeCd_Ed.AutoSelect = true;
            this.tNedit_SalesEmployeeCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesEmployeeCd_Ed.DataText = "";
            this.tNedit_SalesEmployeeCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesEmployeeCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesEmployeeCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesEmployeeCd_Ed.Location = new System.Drawing.Point(320, 32);
            this.tNedit_SalesEmployeeCd_Ed.MaxLength = 4;
            this.tNedit_SalesEmployeeCd_Ed.Name = "tNedit_SalesEmployeeCd_Ed";
            this.tNedit_SalesEmployeeCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SalesEmployeeCd_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_SalesEmployeeCd_Ed.TabIndex = 7;
            // 
            // tNedit_SalesEmployeeCd_St
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance51.TextHAlignAsString = "Left";
            this.tNedit_SalesEmployeeCd_St.ActiveAppearance = appearance51;
            appearance52.TextHAlignAsString = "Right";
            this.tNedit_SalesEmployeeCd_St.Appearance = appearance52;
            this.tNedit_SalesEmployeeCd_St.AutoSelect = true;
            this.tNedit_SalesEmployeeCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SalesEmployeeCd_St.DataText = "";
            this.tNedit_SalesEmployeeCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SalesEmployeeCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SalesEmployeeCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SalesEmployeeCd_St.Location = new System.Drawing.Point(166, 32);
            this.tNedit_SalesEmployeeCd_St.MaxLength = 4;
            this.tNedit_SalesEmployeeCd_St.Name = "tNedit_SalesEmployeeCd_St";
            this.tNedit_SalesEmployeeCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SalesEmployeeCd_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_SalesEmployeeCd_St.TabIndex = 5;
            // 
            // tNedit_AreaCd_Ed
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance53.TextHAlignAsString = "Left";
            this.tNedit_AreaCd_Ed.ActiveAppearance = appearance53;
            appearance54.TextHAlignAsString = "Right";
            this.tNedit_AreaCd_Ed.Appearance = appearance54;
            this.tNedit_AreaCd_Ed.AutoSelect = true;
            this.tNedit_AreaCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AreaCd_Ed.DataText = "";
            this.tNedit_AreaCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AreaCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AreaCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_AreaCd_Ed.Location = new System.Drawing.Point(320, 60);
            this.tNedit_AreaCd_Ed.MaxLength = 4;
            this.tNedit_AreaCd_Ed.Name = "tNedit_AreaCd_Ed";
            this.tNedit_AreaCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AreaCd_Ed.Size = new System.Drawing.Size(43, 24);
            this.tNedit_AreaCd_Ed.TabIndex = 11;
            // 
            // tNedit_AreaCd_St
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance55.TextHAlignAsString = "Left";
            this.tNedit_AreaCd_St.ActiveAppearance = appearance55;
            appearance56.TextHAlignAsString = "Right";
            this.tNedit_AreaCd_St.Appearance = appearance56;
            this.tNedit_AreaCd_St.AutoSelect = true;
            this.tNedit_AreaCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AreaCd_St.DataText = "";
            this.tNedit_AreaCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AreaCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AreaCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_AreaCd_St.Location = new System.Drawing.Point(166, 60);
            this.tNedit_AreaCd_St.MaxLength = 4;
            this.tNedit_AreaCd_St.Name = "tNedit_AreaCd_St";
            this.tNedit_AreaCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AreaCd_St.Size = new System.Drawing.Size(43, 24);
            this.tNedit_AreaCd_St.TabIndex = 9;
            // 
            // BusinessTypeCdEd_GuideBtn
            // 
            appearance105.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.BusinessTypeCdEd_GuideBtn.Appearance = appearance105;
            this.BusinessTypeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BusinessTypeCdEd_GuideBtn.Location = new System.Drawing.Point(367, 88);
            this.BusinessTypeCdEd_GuideBtn.Name = "BusinessTypeCdEd_GuideBtn";
            this.BusinessTypeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.BusinessTypeCdEd_GuideBtn.TabIndex = 16;
            this.BusinessTypeCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.BusinessTypeCdEd_GuideBtn, "�Ǝ�K�C�h");
            this.BusinessTypeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BusinessTypeCdEd_GuideBtn.Click += new System.EventHandler(this.BusinessTypeCdEd_GuideBtn_Click);
            // 
            // BusinessTypeCdSt_GuideBtn
            // 
            appearance106.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.BusinessTypeCdSt_GuideBtn.Appearance = appearance106;
            this.BusinessTypeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.BusinessTypeCdSt_GuideBtn.Location = new System.Drawing.Point(213, 88);
            this.BusinessTypeCdSt_GuideBtn.Name = "BusinessTypeCdSt_GuideBtn";
            this.BusinessTypeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.BusinessTypeCdSt_GuideBtn.TabIndex = 14;
            this.BusinessTypeCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.BusinessTypeCdSt_GuideBtn, "�Ǝ�K�C�h");
            this.BusinessTypeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BusinessTypeCdSt_GuideBtn.Click += new System.EventHandler(this.BusinessTypeCdSt_GuideBtn_Click);
            // 
            // ultraLbK_Business
            // 
            appearance107.TextVAlignAsString = "Middle";
            this.ultraLbK_Business.Appearance = appearance107;
            this.ultraLbK_Business.Location = new System.Drawing.Point(288, 89);
            this.ultraLbK_Business.Name = "ultraLbK_Business";
            this.ultraLbK_Business.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_Business.TabIndex = 74;
            this.ultraLbK_Business.Text = "�`";
            // 
            // ultraLabel_T4
            // 
            appearance108.TextVAlignAsString = "Middle";
            this.ultraLabel_T4.Appearance = appearance108;
            this.ultraLabel_T4.Location = new System.Drawing.Point(16, 88);
            this.ultraLabel_T4.Name = "ultraLabel_T4";
            this.ultraLabel_T4.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T4.TabIndex = 71;
            this.ultraLabel_T4.Text = "�Ǝ�";
            // 
            // AreaCdEd_GuideBtn
            // 
            appearance61.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.AreaCdEd_GuideBtn.Appearance = appearance61;
            this.AreaCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.AreaCdEd_GuideBtn.Location = new System.Drawing.Point(367, 60);
            this.AreaCdEd_GuideBtn.Name = "AreaCdEd_GuideBtn";
            this.AreaCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.AreaCdEd_GuideBtn.TabIndex = 12;
            this.AreaCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.AreaCdEd_GuideBtn, "�n��K�C�h");
            this.AreaCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.AreaCdEd_GuideBtn.Click += new System.EventHandler(this.AreaCdEd_GuideBtn_Click);
            // 
            // AreaCdSt_GuideBtn
            // 
            appearance62.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.AreaCdSt_GuideBtn.Appearance = appearance62;
            this.AreaCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.AreaCdSt_GuideBtn.Location = new System.Drawing.Point(213, 60);
            this.AreaCdSt_GuideBtn.Name = "AreaCdSt_GuideBtn";
            this.AreaCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.AreaCdSt_GuideBtn.TabIndex = 10;
            this.AreaCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.AreaCdSt_GuideBtn, "�n��K�C�h");
            this.AreaCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.AreaCdSt_GuideBtn.Click += new System.EventHandler(this.AreaCdSt_GuideBtn_Click);
            // 
            // ultraLbK_Area
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLbK_Area.Appearance = appearance63;
            this.ultraLbK_Area.Location = new System.Drawing.Point(288, 61);
            this.ultraLbK_Area.Name = "ultraLbK_Area";
            this.ultraLbK_Area.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_Area.TabIndex = 68;
            this.ultraLbK_Area.Text = "�`";
            // 
            // ultraLabel_T3
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel_T3.Appearance = appearance64;
            this.ultraLabel_T3.Location = new System.Drawing.Point(16, 60);
            this.ultraLabel_T3.Name = "ultraLabel_T3";
            this.ultraLabel_T3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T3.TabIndex = 66;
            this.ultraLabel_T3.Text = "�n��";
            // 
            // SalesEmployeeCdEd_GuideBtn
            // 
            appearance65.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdEd_GuideBtn.Appearance = appearance65;
            this.SalesEmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(367, 32);
            this.SalesEmployeeCdEd_GuideBtn.Name = "SalesEmployeeCdEd_GuideBtn";
            this.SalesEmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdEd_GuideBtn.TabIndex = 8;
            this.SalesEmployeeCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdEd_GuideBtn, "�S���҃K�C�h");
            this.SalesEmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // SalesEmployeeCdSt_GuideBtn
            // 
            appearance66.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdSt_GuideBtn.Appearance = appearance66;
            this.SalesEmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(213, 32);
            this.SalesEmployeeCdSt_GuideBtn.Name = "SalesEmployeeCdSt_GuideBtn";
            this.SalesEmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.SalesEmployeeCdSt_GuideBtn.TabIndex = 6;
            this.SalesEmployeeCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdSt_GuideBtn, "�S���҃K�C�h");
            this.SalesEmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance67.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance67;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(400, 3);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 4;
            this.CustomerCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "���Ӑ挟��");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance68.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance68;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(246, 3);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 2;
            this.CustomerCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "���Ӑ挟��");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // ultraLbK_SalesEmp
            // 
            appearance69.TextVAlignAsString = "Middle";
            this.ultraLbK_SalesEmp.Appearance = appearance69;
            this.ultraLbK_SalesEmp.Location = new System.Drawing.Point(288, 32);
            this.ultraLbK_SalesEmp.Name = "ultraLbK_SalesEmp";
            this.ultraLbK_SalesEmp.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_SalesEmp.TabIndex = 56;
            this.ultraLbK_SalesEmp.Text = "�`";
            // 
            // ultraLabel_T2
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel_T2.Appearance = appearance70;
            this.ultraLabel_T2.Location = new System.Drawing.Point(16, 32);
            this.ultraLabel_T2.Name = "ultraLabel_T2";
            this.ultraLabel_T2.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T2.TabIndex = 47;
            this.ultraLabel_T2.Text = "�S����";
            // 
            // tNedit_CustomerCode_Ed
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance71.TextHAlignAsString = "Left";
            this.tNedit_CustomerCode_Ed.ActiveAppearance = appearance71;
            appearance72.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.Appearance = appearance72;
            this.tNedit_CustomerCode_Ed.AutoSelect = true;
            this.tNedit_CustomerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_Ed.DataText = "";
            this.tNedit_CustomerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_Ed.Location = new System.Drawing.Point(320, 4);
            this.tNedit_CustomerCode_Ed.MaxLength = 8;
            this.tNedit_CustomerCode_Ed.Name = "tNedit_CustomerCode_Ed";
            this.tNedit_CustomerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode_Ed.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode_Ed.TabIndex = 3;
            // 
            // ultraLbK_Customer
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLbK_Customer.Appearance = appearance73;
            this.ultraLbK_Customer.Location = new System.Drawing.Point(288, 4);
            this.ultraLbK_Customer.Name = "ultraLbK_Customer";
            this.ultraLbK_Customer.Size = new System.Drawing.Size(20, 23);
            this.ultraLbK_Customer.TabIndex = 19;
            this.ultraLbK_Customer.Text = "�`";
            // 
            // tNedit_CustomerCode_St
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance74.TextHAlignAsString = "Left";
            this.tNedit_CustomerCode_St.ActiveAppearance = appearance74;
            appearance75.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.Appearance = appearance75;
            this.tNedit_CustomerCode_St.AutoSelect = true;
            this.tNedit_CustomerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_St.DataText = "";
            this.tNedit_CustomerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_St.Location = new System.Drawing.Point(166, 4);
            this.tNedit_CustomerCode_St.MaxLength = 8;
            this.tNedit_CustomerCode_St.Name = "tNedit_CustomerCode_St";
            this.tNedit_CustomerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_CustomerCode_St.Size = new System.Drawing.Size(74, 24);
            this.tNedit_CustomerCode_St.TabIndex = 1;
            // 
            // ultraLabel_T1
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel_T1.Appearance = appearance76;
            this.ultraLabel_T1.Location = new System.Drawing.Point(16, 4);
            this.ultraLabel_T1.Name = "ultraLabel_T1";
            this.ultraLabel_T1.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel_T1.TabIndex = 17;
            this.ultraLabel_T1.Text = "���Ӑ�";
            // 
            // DCTOK02090UA_Fill_Panel
            // 
            this.DCTOK02090UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.DCTOK02090UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DCTOK02090UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.DCTOK02090UA_Fill_Panel.Name = "DCTOK02090UA_Fill_Panel";
            this.DCTOK02090UA_Fill_Panel.Size = new System.Drawing.Size(733, 617);
            this.DCTOK02090UA_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Main_ultraExplorerBar);
            this.Centering_Panel.Controls.Add(this.ultraLabel1);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(733, 617);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Main_ultraExplorerBar
            // 
            this.Main_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Main_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance77.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance77.FontData.Name = "�l�r �S�V�b�N";
            appearance77.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance77;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl2);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance78;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 228;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "�@�o�͏���";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl2;
            ultraExplorerBarGroup2.Key = "IssueTypeGroup";
            appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance83;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 42;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "�@���s�^�C�v";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance79;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 216;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "�@���o����";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance80.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance80.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance80.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance80;
            appearance81.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance81;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(2, 3);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(731, 611);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance82.FontData.SizeInPoints = 20F;
            appearance82.TextHAlignAsString = "Center";
            appearance82.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance82;
            this.ultraLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(733, 617);
            this.ultraLabel1.TabIndex = 1;
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
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // DCTOK02090UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(733, 617);
            this.Controls.Add(this.DCTOK02090UA_Fill_Panel);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DCTOK02090UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SFUKK01390UA_Load);
            this.Activated += new System.EventHandler(this.SFUKK01390UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TyGrsMarginLow_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyGrsMarginHigh_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmGrsMarginLow_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmGrsMarginHigh_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyTotalCostLow_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TyTotalCostHigh_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmTotalCostHigh_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TmTotalCostLow_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PrintType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_TotalWay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_MoneyUnit)).EndInit();
            this.ultraExplorerBarContainerControl2.ResumeLayout(false);
            this.ultraExplorerBarContainerControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_IssueType)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsLGroup_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsLGroup_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BusinessTypeCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesEmployeeCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SalesEmployeeCd_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_AreaCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_AreaCd_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).EndInit();
            this.DCTOK02090UA_Fill_Panel.ResumeLayout(false);
            this.Centering_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).EndInit();
            this.Main_ultraExplorerBar.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region private member
		private string _enterpriseCode              = "";
     
		private bool _printButtonEnabled             = true;
		private bool _extraButtonEnabled             = false;
		private bool _pdfButtonEnabled               = true;
		private bool _printButtonVisibled            = true;
		private bool _extraButtonVisibled            = false;
		private bool _pdfButtonVisibled = true;
        private bool _visibledSelectAddUpCd = false;	// �v�㋒�_�I��\���擾

        private int  _selectedAddUpCd;

		private bool _chartButtonVisibled = true;	//true:�`���[�g�o�̓{�^���\���@false:��\��
		private bool _chartButtonEnabled = true;	//����
        
        private string _PrevYearCpDataTable;

		private Employee _loginWorker                = null;
		// �����_�R�[�h
		private string _ownSectionCode               = "";

        private ExtrInfo_DCTOK02093E _chartSaleconfListCndtn = null;

        // ���_�A�N�Z�X�N���X
        private static SecInfoAcs _secInfoAcs;

        //TODO �K�C�h�n�A�N�Z�X�N���X
        EmployeeAcs    _employeeAcs;
        UserGuideAcs _userGuideAcs = null;

        // BL�R�[�h
        GoodsAcs _goodsAcs;

        // ��ٰ�ߺ���
        BLGroupUAcs _bLGroupUAcs;

        // ���i������
        GoodsGroupUAcs _goodsGroupUAcs;

		//���Џ��A�N�Z�X�N���X
		CompanyInfAcs _companyInfAcs;
		CompanyInf _companyInf;

		//���t�擾���i
		DateGetAcs _dateGetAcs;

		private PrevYearComparison _prevYearComparison = null;  // �O�N�Δ�\�A�N�Z�X�N���X

        private Hashtable _selectedhSectinTable = new Hashtable();
        private bool _isOptSection;	// ���_�I�v�V�����L��
        private bool _isMainOfficeFunc;	// �{�Ћ@�\�L��

		
		// �G�N�X�v���[���o�[�g������ 
		private Form _topForm = null;


		// ���i�`���[�g���o�N���X�����o
		private List<IChartExtract> _iChartExtractList;

        private ExtrInfo_DCTOK02093E _saleConfListCndtnWork = new ExtrInfo_DCTOK02093E();		//�����N���X(�O������ێ��p)
		private ExtrInfo_DCTOK02093E _DCTOK02093E = new ExtrInfo_DCTOK02093E();		//�����N���X(�`���[�g���n���p)
        private DataSet _printBuffDataSet = null;

		// �N�����[�p�����[�^������ϐ�
		private int _listTypePara;

		// ���[����
		private string _printName = "";
		// ���[�L�[
		private string _printKey = "";
        
        // ���Ӑ�K�C�h����OK
        private bool _customerGuideOK;

        // --- ADD 2008/12/18 [9352] -------------------------------->>>>>
        /// <summary>���тȂ�������W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _ultraOptionSet_TotalWayDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>���Ń��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _ultraOptionSet_MoneyUnitDivRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// �W�v���@���W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>�W�v���@���W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper TotalWayDivRadioKeyPressHelper
        {
            get { return _ultraOptionSet_TotalWayDivRadioKeyPressHelper; }
        }

        /// <summary>
        /// ���z�P�ʃ��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���z�P�ʃ��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper MoneyUnitDivRadioKeyPressHelper
        {
            get { return _ultraOptionSet_MoneyUnitDivRadioKeyPressHelper; }
        }
        // --- ADD 2008/12/18 [9352] --------------------------------<<<<<
		#endregion
        
		// ===================================================================================== //
		// �v���C�x�[�g�萔
		// ===================================================================================== //
		#region private constant

		// �A�Z���u��ID
		private const string THIS_ASSEMBLYID = "DCTOK02090U";
		// �L�[���
        private const string PRINT_KEY00 = "bedb27bc-b923-476e-8e60-037a5fe9d65a";
        private const string PRINT_KEY01 = "bedb27bc-b923-476e-8e60-037a5fe9d65a";
        private const string PRINT_KEY02 = "8a95f2fe-08bc-43c5-9fcd-b86705b7f949";
        private const string PRINT_KEY03 = "0d64c5d9-0c55-4dba-888c-2961a2b0360d";
        private const string PRINT_KEY04 = "28b33c72-e681-4947-be69-a87998b8ff7b";
        private const string PRINT_KEY05 = "1cbd7a94-d31b-444c-a8b8-a02aee768277";
        private const string PRINT_KEY06 = "089f30d1-c1d4-4616-a83e-e04e336b68d6";

        private const string PRINT_NAME00 = "�O�N�Δ�\�i���Ӑ�ʁj";
        private const string PRINT_NAME01 = "�O�N�Δ�\�i�S���ҕʁj";
        private const string PRINT_NAME02 = "�O�N�Δ�\�i�󒍎ҕʁj";
        private const string PRINT_NAME03 = "�O�N�Δ�\�i�n��ʁj";
        private const string PRINT_NAME04 = "�O�N�Δ�\�i�Ǝ�ʁj";
        private const string PRINT_NAME05 = "�O�N�Δ�\�i��ٰ�ߺ��ޕʁj";
        private const string PRINT_NAME06 = "�O�N�Δ�\�i�a�k���ޕʁj";

        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

		// �G�N�X�v���[���[�o�[�̕\����Ԃ����肷�邽�߂̊�ƂȂ�g�b�v�t�H�[���̍���
		private const int CT_TOPFORM_BASE_HEIGHT = 768;
		#endregion
        
		// ===================================================================================== //
		// IPrintConditionInpType �����o
		// ===================================================================================== //
		#region IPrintConditionInpType �����o
		/// <summary>
		/// ����{�^���L�������v���p�e�B
		/// </summary>
		public bool CanPrint
		{
			get
			{
				return _printButtonEnabled;
			}
		}

		/// <summary>
		/// ���o�{�^���L�������v���p�e�B
		/// </summary>
		public bool CanExtract
		{
			get
			{
				return _extraButtonEnabled;
			}
		}

		/// <summary>
		/// PDF�{�^���L�������v���p�e�B
		/// </summary>
		public bool CanPdf
		{
			get
			{
				return _pdfButtonEnabled;
			}
		}
		
		/// <summary>
		/// ����{�^���\���v���p�e�B
		/// </summary>
		public bool VisibledPrintButton
		{
			get
			{
				return _printButtonVisibled;
			}
		}

		/// <summary>
		/// ���o�{�^���\���v���p�e�B
		/// </summary>
		public bool VisibledExtractButton
		{
			get
			{
				return _extraButtonVisibled;
			}
		}
		
		/// <summary>
		/// PDF�{�^���\���v���p�e�B
		/// </summary>
		public bool VisibledPdfButton
		{
			get
			{
				return _pdfButtonVisibled;
			}
		}

        // ===================================================================================== //
        // IPrintConditionInpTypeCondition �����o
        // ===================================================================================== //
        /// <summary>
        /// �`���[�g�p���o�����ݒ�
        /// </summary>
        public object ObjExtract
        {	//�t���[������n���Ă��钊�o����
            get
            {
                return _chartSaleconfListCndtn;
            }
        }
		
		/// <summary>
		/// �c�[���o�[�\������C�x���g
		/// </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;        
		
		
		/// <summary>
		/// Control.Show�̃I�[�o�[���[�h
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʕ\�����s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public void Show(object parameter)
		{
			// �N���p�����[�^�̎擾
            this._listTypePara = Convert.ToInt32( parameter );

			#region		�N�����[�h���̐ؑ�
            // ���s�^�C�v�̃N���A
            this.tComboEditor_IssueType.Items.Clear();
            switch (_listTypePara)
            {
                case 0: // ���Ӑ��
                    this._printName = PRINT_NAME00;
                    this._printKey = PRINT_KEY00;

                    // ���s�^�C�v�ݒ�
                    this.tComboEditor_IssueType.Items.Add(0, "���Ӑ��");
                    this.tComboEditor_IssueType.Items.Add(1, "���_��");
                    this.tComboEditor_IssueType.Items.Add(2, "���Ӑ�ʋ��_��");
                    this.tComboEditor_IssueType.Items.Add(3, "�Ǘ����_��");
                    this.tComboEditor_IssueType.Items.Add(4, "�������");
                    break;
                case 1: // �S���ҕ�
                    this._printName = PRINT_NAME01;
                    this._printKey = PRINT_KEY01;

                    // ���s�^�C�v�ݒ�
                    this.tComboEditor_IssueType.Items.Add(0, "�S���ҕ�");
                    this.tComboEditor_IssueType.Items.Add(1, "���Ӑ��");
                    this.tComboEditor_IssueType.Items.Add(2, "�S���ҕʋ��_��");
                    this.tComboEditor_IssueType.Items.Add(3, "�Ǘ����_��");
                    break;
                case 2: // �󒍎ҕ�
                    this._printName = PRINT_NAME02;
                    this._printKey = PRINT_KEY02;

                    // ���s�^�C�v�ݒ�
                    this.tComboEditor_IssueType.Items.Add(0, "�󒍎ҕ�");
                    this.tComboEditor_IssueType.Items.Add(1, "���Ӑ��");
                    this.tComboEditor_IssueType.Items.Add(2, "�󒍎ҕʋ��_��");
                    this.tComboEditor_IssueType.Items.Add(3, "�Ǘ����_��");
                    break;
                case 3: // �n���
                    this._printName = PRINT_NAME03;
                    this._printKey = PRINT_KEY03;

                    // ���s�^�C�v�ݒ�
                    this.tComboEditor_IssueType.Items.Add(0, "�n���");
                    this.tComboEditor_IssueType.Items.Add(1, "���Ӑ��");
                    this.tComboEditor_IssueType.Items.Add(2, "�n��ʋ��_��");
                    this.tComboEditor_IssueType.Items.Add(3, "�Ǘ����_��");
                    break;
                case 4: // �Ǝ��
                    this._printName = PRINT_NAME04;
                    this._printKey = PRINT_KEY04;

                    // ���s�^�C�v�ݒ�
                    this.tComboEditor_IssueType.Items.Add(0, "�Ǝ��");
                    this.tComboEditor_IssueType.Items.Add(1, "���Ӑ��");
                    this.tComboEditor_IssueType.Items.Add(2, "�Ǝ�ʋ��_��");
                    this.tComboEditor_IssueType.Items.Add(3, "�Ǘ����_��");
                    break;
                case 5: // �O���[�v�R�[�h��
                    this._printName = PRINT_NAME05;
                    this._printKey = PRINT_KEY05;

                    // ���s�^�C�v�ݒ�
                    this.tComboEditor_IssueType.Items.Add(0, "�O���[�v�R�[�h��");
                    this.tComboEditor_IssueType.Items.Add(1, "���i�����ޕ�");
                    this.tComboEditor_IssueType.Items.Add(2, "���i�啪�ޕ�");
                    break;
                case 6: // �a�k�R�[�h��
                    this._printName = PRINT_NAME06;
                    this._printKey = PRINT_KEY06;

                    // ���s�^�C�v�ݒ�
                    this.tComboEditor_IssueType.Items.Add(0, "�a�k�R�[�h��");
                    this.tComboEditor_IssueType.Items.Add(1, "�a�k�R�[�h�ʓ��Ӑ��");
                    this.tComboEditor_IssueType.Items.Add(2, "�a�k�R�[�h�ʒS���ҕ�");
                    break;
            }
            // ���s�^�C�v�̏����l
            this.tComboEditor_IssueType.Value = 0;

            this.ultraExplorerBarContainerControl1.Height = 123;
            // �\���R���g���[�����䏈��
            SetControl();
			#endregion

			this.Show();
        }
		
		/// <summary>
		/// �������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public int Print(ref object parameter)
		{
		            
			SFCMN06001U printDialog = new SFCMN06001U();            // ���[�I���K�C�h
			SFCMN06002C printInfo   = parameter as SFCMN06002C;     // ������p�����[�^
		
			// ��ƃR�[�h
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;     
			printInfo.kidopgid       = THIS_ASSEMBLYID;             // �N���o�f�h�c
			printInfo.key			 = this._printKey;              // PDF�����Ǘ��pKEY���

			// ��ʁ����o�����N���X
            ExtrInfo_DCTOK02093E _extrInfo_DCTOK02093E = new ExtrInfo_DCTOK02093E();
            this.SetExtraInfoFromScreen(ref _extrInfo_DCTOK02093E);
		            
			// ���o�����̐ݒ�
            printInfo.jyoken = _extrInfo_DCTOK02093E;
            
			// ������[�ݒ�		��U�N���X�͈�ŏo�͂��钠�[�𕪂���v���O�����̏ꍇ�K�v
			//�i��ʂ������Ă���parameter��printInfo�ɓn���BprintInfo�F����������j
            printInfo.PrintPaperSetCd = this._listTypePara;
                        
            this._saleConfListCndtnWork = _extrInfo_DCTOK02093E;

			printDialog.PrintInfo = printInfo;
		        
			// ���[�I���K�C�h
			DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }
		
			parameter = (Object)printInfo;
		
			return printInfo.status;
		}
		
		/// <summary>
		/// ����O�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����O�̃`�F�b�N�������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public bool PrintBeforeCheck()
		{
			string message;
			Control errControl = null;
		            
			// ��ʓ��͏����`�F�b�N
			bool result = this.ScreenInputCheack(out message, ref errControl);
			if (!result)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				if (errControl != null) errControl.Focus();
			}
			return result;
		}

		/// <summary>
		/// ���o����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���o�������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		public int Extract(ref object parameter)
		{
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            if (parameter.ToString().Equals("0"))   // �`���[�g�̏ꍇ�̂݁A�f�[�^�������s��
            {

                ExtrInfo_DCTOK02093E extraInfo = new ExtrInfo_DCTOK02093E();     // ���o�����N���X

                this.SetExtraInfoFromScreen(ref extraInfo);

                int i = _DCTOK02093E.ListType;

                //TODO �`���[�g�p�����ݒ�
                _chartSaleconfListCndtn = extraInfo;

                int h = extraInfo.ListType;

                int j = _DCTOK02093E.ListType;

                // �f�[�^���o
                status = this.SearchData(extraInfo);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
                {
                    this._printBuffDataSet = null;
                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    this._printBuffDataSet = null;
                    TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�f�[�^�̒��o�ŃG���[���������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
		}
		#endregion
		
		// ===================================================================================== //
		// IPrintConditionInpTypePdfCareer �����o
		// ===================================================================================== //
		#region IPrintConditionInpTypePdfCareer �����o
		/// <summary>���[KEY�v���p�e�B</summary>
		/// <remarks>���[�̏o�͗����擾�p��KEY�l���擾���܂��B</remarks>
		public string PrintKey
		{
			get
			{
				return this._printKey;
			}
		}

		/// <summary>���[���v���p�e�B</summary>
		/// <remarks>���[�����擾���܂��B</remarks>
		public string PrintName
		{
			get
			{
				return this._printName;
			}
		}
		#endregion

		// ===================================================================================== //
		// IPrintConditionInpTypeChart �����o
		// ===================================================================================== //
        #region IPrintConditionInpTypeChart �����o
        /// <summary>
        /// �`���[�g�{�^��Enabled����
        /// </summary>
        public bool CanChart
        {
            get { return this._chartButtonEnabled; }
        }

        /// <summary>
        /// �`���[�g�{�^���\������
        /// </summary>
        public bool VisibledChartButton
        {
            get { return this._chartButtonVisibled; }
        }

		/// <summary>
		/// �`���[�g�f�[�^�̒��o�`�F�b�N
		/// </summary>
		public bool CheckBefore()
        {
            // �`���[�g�f�[�^�̒��o�`�F�b�N���s���܂��B
            return true;
        }

        /// <summary>
        /// �`���[�g���o�N���X�����o�擾
        /// </summary>
        /// <param name="chartExtractMemberList"></param>
        /// <returns></returns>
        public int GetChartExtractMember(out List<IChartExtract> chartExtractMemberList)
        {
            try
			{
				int i = _DCTOK02093E.ListType;

				string message;
				Control errControl = null;

				// ��ʓ��͏����`�F�b�N
				bool result = this.ChartInputCheack(out message, ref errControl);
				if (result == false)
				{
					TMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION, message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
					if (errControl != null) errControl.Focus();

					chartExtractMemberList = null;

					return 9;
				}

                if (this._iChartExtractList == null)
                {
                    this._iChartExtractList = new List<IChartExtract>();

					//�`���[�g�N���X�ɓn��ӏ�
					//�����̃O���t��\������
					AgentOrderChart chartExtrac1 = new AgentOrderChart(0, this._listTypePara);
					this._iChartExtractList.Add(chartExtrac1);


					AgentOrderChart chartExtrac2 = new AgentOrderChart(1, this._listTypePara);
					this._iChartExtractList.Add(chartExtrac2);

                }

                chartExtractMemberList = this._iChartExtractList;
            }
            finally
            {
            }

            return 0;
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
          System.Windows.Forms.Application.Run(new DCTOK02090UA());
        }
        #endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private methods 
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        private void InitialScreenSetting()
        {
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);


            // ���t�͈�
                // ����
			this.ItdedDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M;
			this.ItdedDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M;
			this.ItdedDateStRF_tDateEdit.SetLongDate(this._companyInf.CompanyBiginDate);
            //this.ItdedDateEdRF_tDateEdit.SetLongDate(nowLongDate);                                                    //DEL 2009/03/05 �s��Ή�[12187]
            this.ItdedDateEdRF_tDateEdit.SetDateTime(this.ItdedDateStRF_tDateEdit.GetDateTime().AddMonths(11));         //ADD 2009/03/05 �s��Ή�[12187]

            			
			//����^�C�v
            this.tComboEditor_PrintType.SelectedIndex = 0;

            // �K�C�h�{�^���C���[�W�ݒ�
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			SalesEmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			SalesEmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			SalesEmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			SalesEmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			AreaCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			AreaCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			AreaCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			AreaCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			BusinessTypeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			BusinessTypeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			BusinessTypeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			BusinessTypeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            ub_St_BLGoodsCodeGuide.ImageList = IconResourceManagement.ImageList16;
            ub_St_BLGoodsCodeGuide.Appearance.Image = Size16_Index.STAR1;
            ub_Ed_BLGoodsCodeGuide.ImageList = IconResourceManagement.ImageList16;
            ub_Ed_BLGoodsCodeGuide.Appearance.Image = Size16_Index.STAR1;
            ub_St_DetailGoodsGuide.ImageList = IconResourceManagement.ImageList16;
            ub_St_DetailGoodsGuide.Appearance.Image = Size16_Index.STAR1;
            ub_Ed_DetailGoodsGuide.ImageList = IconResourceManagement.ImageList16;
            ub_Ed_DetailGoodsGuide.Appearance.Image = Size16_Index.STAR1;
            ub_St_GoodsLGroupGuide.ImageList = IconResourceManagement.ImageList16;
            ub_St_GoodsLGroupGuide.Appearance.Image = Size16_Index.STAR1;
            ub_Ed_GoodsLGroupGuide.ImageList = IconResourceManagement.ImageList16;
            ub_Ed_GoodsLGroupGuide.Appearance.Image = Size16_Index.STAR1;
            ub_St_MediumGoodsGuide.ImageList = IconResourceManagement.ImageList16;
            ub_St_MediumGoodsGuide.Appearance.Image = Size16_Index.STAR1;
            ub_Ed_MediumGoodsGuide.ImageList = IconResourceManagement.ImageList16;
            ub_Ed_MediumGoodsGuide.Appearance.Image = Size16_Index.STAR1;
            
		}

		/// <summary>
		/// ���t���̓`�F�b�N����
		/// </summary>
		/// <param name="control">�`�F�b�N�ΏۃR���g���[��</param>
		/// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
		/// <remarks>
		/// <br>Note: ���ʕ��i�ɂ����t�̓��̓`�F�b�N���s���܂��B</br>
		/// </remarks>
		private bool CheckDate(TDateEdit control)
		{
			Enum _checkD = this._dateGetAcs.CheckDate(ref control, false);

			string str_cD = _checkD.ToString();

			if (str_cD == "ErrorOfNoInput" || str_cD == "ErrorOfInvalid")
			{
				return false;
			}
			else
			{
				return true;
			}
		}
			
		/// <summary>
		/// ����N�x�`�F�b�N�����i���В��߁j
		/// </summary>
        /// <param name="startYearMonth"></param>
        /// <param name="endYearMonth"></param>
		/// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
		/// <remarks>
		/// <br>Note: ���ʕ��i�ɂ�铯��N�x�i���В��߁j�̃`�F�b�N���s���܂��B</br>
		/// </remarks>
		private bool CheckMonthsOnYear(DateTime startYearMonth, DateTime endYearMonth)
		{
			bool _checkMOY = this._dateGetAcs.CheckMonthsOnYear(startYearMonth, endYearMonth);

			return _checkMOY;

		}

		/// <summary>
		/// ���t�͈̓`�F�b�N����
		/// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="msg"></param>
		/// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
		/// <remarks>
		/// <br>Note: ���ʕ��i�ɂ����t�͈͂̃`�F�b�N���s���܂��B</br>
		/// </remarks>
        //private bool CheckPeriod(DateTime startDate, DateTime endDate) // DEL 2009/02/24
        private bool CheckPeriod(DateTime startDate, DateTime endDate, out string msg) // ADD 2009/02/24
		{
            msg = string.Empty; // ADD 2009/02/24
			Enum _checkP = this._dateGetAcs.CheckPeriod(DateGetAcs.YmdType.YearMonth, 12, DateGetAcs.YmdType.YearMonth, startDate, endDate);

			string str_cP = _checkP.ToString();

            // --- ADD 2009/02/24 -------------------------------->>>>>
            if (str_cP == "ErrorOfReverse")
            {
                msg = "�Ώ۔N���͈̔͂Ɍ�肪����܂�";
            }
            else if (str_cP == "ErrorOfRangeOver")
            {
                msg = "�Ώ۔N���͈̔͂�12�����ȓ��ɂ��ĉ�����";
            }
            // --- ADD 2009/02/24 --------------------------------<<<<<

			if (str_cP == "ErrorOfReverse" || str_cP == "ErrorOfRangeOver")
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        private bool ScreenInputCheack(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

		//�o�͏���
			// �Ώ۔N��(�J�n)
			if (!CheckDate(this.ItdedDateStRF_tDateEdit))
			{
				message = "�Ώ۔N���̎w��Ɍ�肪����܂�";
				errControl = this.ItdedDateStRF_tDateEdit;
				return result;
			}

			// �Ώ۔N��(�I��)
			if (!CheckDate(this.ItdedDateEdRF_tDateEdit))
			{
				message = "�Ώ۔N���̎w��Ɍ�肪����܂�";
				errControl = this.ItdedDateEdRF_tDateEdit;
				return result;
			}

			DateTime dt_st_SalesDate = DateTime.ParseExact(this.ItdedDateStRF_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);
			DateTime dt_ed_SalesDate = DateTime.ParseExact(this.ItdedDateEdRF_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);

            // --- DEL 2009/02/24 -------------------------------->>>>>
            //// �Ώ۔N�� ����N�x�`�F�b�N�����i���В��߁j
            //if (!CheckMonthsOnYear(dt_st_SalesDate, dt_ed_SalesDate))
            //{
            //    message = "�Ώ۔N���͈͓̔͂���N�x����12�����ɂ��ĉ�����";
            //    errControl = this.ItdedDateEdRF_tDateEdit;
            //    return result;
            //}
            // --- DEL 2009/02/24 --------------------------------<<<<<

			// �v����t�͈̓`�F�b�N
            //if (!CheckPeriod(dt_st_SalesDate, dt_ed_SalesDate)) // DEL 2009/02/24
            if (!CheckPeriod(dt_st_SalesDate, dt_ed_SalesDate, out message)) // ADD 2009/02/24
			{
                //message = "�Ώ۔N���͈̔͂Ɍ�肪����܂�"; // DEL 2009/02/24
				errControl = this.ItdedDateStRF_tDateEdit;
				return result;
			}

            // ADD 2008/12/18 �s��Ή�[9353] ---------->>>>>
            if (this.TmTotalCostHigh_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TmTotalCostLow_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TmTotalCostHigh_Nedit.GetInt() > this.TmTotalCostLow_Nedit.GetInt())
            {
                message = "����������͈̔͂Ɍ�肪����܂�";
                errControl = this.TmTotalCostHigh_Nedit;
                return result;
            }

            if (this.TyTotalCostHigh_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TyTotalCostLow_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TyTotalCostHigh_Nedit.GetInt() > this.TyTotalCostLow_Nedit.GetInt())
            {
                message = "���N������͈̔͂Ɍ�肪����܂�";
                errControl = this.TyTotalCostHigh_Nedit;
                return result;
            }

            if (this.TmGrsMarginHigh_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TmGrsMarginLow_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TmGrsMarginHigh_Nedit.GetInt() > this.TmGrsMarginLow_Nedit.GetInt())
            {
                message = "�����e���͈̔͂Ɍ�肪����܂�";
                errControl = this.TmGrsMarginHigh_Nedit;
                return result;
            }

            if (this.TyGrsMarginHigh_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TyGrsMarginLow_Nedit.Text.ToString().Equals(string.Empty) == false &&
                this.TyGrsMarginHigh_Nedit.GetInt() > this.TyGrsMarginLow_Nedit.GetInt())
            {
                message = "���N�e���͈̔͂Ɍ�肪����܂�";
                errControl = this.TyGrsMarginHigh_Nedit;
                return result;
            }
            // ADD 2008/12/18 �s��Ή�[9353] ----------<<<<<

		//���o����
            // ���Ӑ�R�[�h�͈̓`�F�b�N
            if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                (this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            {
                message = "���Ӑ�͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_CustomerCode_Ed;
                return result;
            }

			// �S���҃R�[�h�͈̓`�F�b�N
			if ((this.tNedit_SalesEmployeeCd_Ed.Text != "") &&
                (this.tNedit_SalesEmployeeCd_St.Text.Trim().PadLeft(4, '0').CompareTo(this.tNedit_SalesEmployeeCd_Ed.Text.Trim().PadLeft(4, '0')) > 0))
			{
				message = "�S���҂͈̔͂Ɍ�肪����܂�";
				errControl = this.tNedit_SalesEmployeeCd_St;
				return result;
			}

			// �n��R�[�h�͈̓`�F�b�N
			if ((this.tNedit_AreaCd_Ed.Text != "") &&
                (this.tNedit_AreaCd_St.Text.Trim().PadLeft(4, '0').CompareTo(this.tNedit_AreaCd_Ed.Text.Trim().PadLeft(4, '0')) > 0))
			{
				message = "�n��͈̔͂Ɍ�肪����܂�";
				errControl = this.tNedit_AreaCd_St;
				return result;
			}

			// �Ǝ�R�[�h�͈̓`�F�b�N
			if ((this.tNedit_BusinessTypeCode_Ed.Text != "") &&
				(this.tNedit_BusinessTypeCode_St.Text.CompareTo(this.tNedit_BusinessTypeCode_Ed.Text) > 0))
			{
				message = "�Ǝ�͈̔͂Ɍ�肪����܂�";
				errControl = this.tNedit_BusinessTypeCode_St;
				return result;
			}

            // BL�R�[�h�͈̓`�F�b�N
            if ((this.tNedit_BLGoodsCode_Ed.Text != "") &&
                (this.tNedit_BLGoodsCode_St.Text.CompareTo(this.tNedit_BLGoodsCode_Ed.Text) > 0))
            {
                message = "�a�k�R�[�h�͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_BLGoodsCode_St;
                return result;
            }

            // ���i�啪�ޔ͈̓`�F�b�N
            if ((this.tNedit_GoodsLGroup_Ed.Text != "") &&
                (this.tNedit_GoodsLGroup_St.Text.CompareTo(this.tNedit_GoodsLGroup_Ed.Text) > 0))
            {
                message = "���i�啪�ނ͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_GoodsLGroup_St;
                return result;
            }

            // ���i�����ޔ͈̓`�F�b�N
            if ((this.tNedit_GoodsMGroup_Ed.Text != "") &&
                (this.tNedit_GoodsMGroup_St.Text.CompareTo(this.tNedit_GoodsMGroup_Ed.Text) > 0))
            {
                message = "���i�����ނ͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_GoodsMGroup_St;
                return result;
            }

            // �O���[�v�R�[�h�͈̓`�F�b�N
            if ((this.tNedit_BLGloupCode_Ed.Text != "") &&
                (this.tNedit_BLGloupCode_St.Text.CompareTo(this.tNedit_BLGloupCode_Ed.Text) > 0))
            {
                message = "�O���[�v�R�[�h�͈̔͂Ɍ�肪����܂�";
                errControl = this.tNedit_BLGloupCode_St;
                return result;
            }
            return true;    
        }

		/// <summary>
		/// �`���[�g�p��ʓ��̓`�F�b�N����
		/// </summary>
		private bool ChartInputCheack(out string message, ref Control errControl)
		{
			message = "";
			bool result = false;
			errControl = null;
                        
            // ���_���e�`�F�b�N
            if ((this._selectedhSectinTable.Count > 1) || (this._selectedhSectinTable.ContainsKey("0")))
            {
                message = "�O���t�o�͂̏ꍇ�A���_�͑Ώۂ�1�ɂȂ�悤�i���Ă�������";
                return result;
            }
			return true;
		}

        /// <summary>
        /// �f�[�^���o
        /// </summary>
        /// <param name="extraInfo">���o�����N���X</param>
        /// <returns></returns>
        private int SearchData(ExtrInfo_DCTOK02093E extraInfo)
        {
            string message;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ���o�������ς���Ă���Ȃ烊���[�e�B���O
            if (this._printBuffDataSet == null || this._saleConfListCndtnWork == null || !this._saleConfListCndtnWork.Equals(extraInfo))
            {
                try
                {
                    status = this._prevYearComparison.Search(extraInfo, out message, 0);
                    if (status == 0)
                    {
                        this._printBuffDataSet = this._prevYearComparison._printDataSet;
                    }
                }
                catch (Exception ex)
                {
                    TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status,
                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    // �߂�l��ݒ�B�ُ�̏ꍇ�̓��b�Z�[�W��\��
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            this._saleConfListCndtnWork = extraInfo.Clone();

                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            break;
                        default:
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                            break;
                    }
                }
            }
            else
            {
                if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_PrevYearCpDataTable].Rows.Count == 0)
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                else
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;


        }

#if false
		private bool InputDateEditCheack(TDateEdit control)
		{
			int yy = control.GetDateYear();
			int mm = control.GetDateMonth();

			if ((DateTime.MinValue.Year > yy) || (yy > DateTime.MaxValue.Year))
			{
            return false;
        }

		if ((DateTime.MinValue.Month > mm) || (mm > DateTime.MaxValue.Month))
		{
            return false;
        }

        return true;
    }
#endif

#if false
		private bool InputDateEditCheack(TDateEdit control)
        {

			// ���t�𐔒l�^�Ŏ擾
			int date = control.GetLongDate();	//GetLongDate�F�N�����̌`�œ��t���擾����
			int yy   = date / 10000;  
			int mm   = date / 100 % 100;
			int dd   = date % 100;  

            // ���t�����̓`�F�b�N
            if (date == 0) return false;

            // �V�X�e���T�|�[�g�`�F�b�N
            if (yy < 1900) return false;
            	
            // �N�E���E���ʓ��̓`�F�b�N
            switch (control.DateFormat)
            {
			  // �N�E���E���\����
			case emDateFormat.dfG2Y2M2D:
			case emDateFormat.df4Y2M2D :
			case emDateFormat.df2Y2M2D :
			  if (yy == 0 || mm == 0 || dd == 0) return false;
			  break;
              // �N�E��    �\����
            case emDateFormat.dfG2Y2M  :
            case emDateFormat.df4Y2M   :
            case emDateFormat.df2Y2M   :
              if (yy == 0 || mm == 0) return false;
              break;
              // �N        �\����
            case emDateFormat.dfG2Y    :
            case emDateFormat.df4Y     :
            case emDateFormat.df2Y     :
              if (yy == 0) return false;
              break;
			  // ���E���@�@�\����
			case emDateFormat.df2M2D   :
			  if (mm == 0 || dd == 0) return false;
			  break;
               ��        �\����
            case emDateFormat.df2M     :
              if (mm == 0) return false;
              break;
			  // ��        �\����
			case emDateFormat.df2D     :
			  if (dd == 0) return false;
			  break;
            }
   
            07.11.30���N�����̑Ó����`�F�b�N�B�����̑Ó����`�F�b�N�̂�����������Ȃ��̂ŉ��R�����g�A�E�g  
            DateTime dt = TDateTime.LongDateToDateTime("YYYYMMDD",date);
            // �P�����t�Ó����`�F�b�N
            if (TDateTime.IsAvailableDate(dt) == false) return false;

			return true;           
        }
#endif

		/// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʁ����o�����֐ݒ肵�܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        public void SetExtraInfoFromScreen(ref ExtrInfo_DCTOK02093E extraInfo)
        {
            // ��ƃR�[�h
            extraInfo.EnterpriseCode = this._enterpriseCode;
            // �I�����_
            // ���_�I�v�V��������̂Ƃ�
			if (IsOptSection)
			{
				ArrayList secList = new ArrayList();
				ArrayList secNameList = new ArrayList();
				SortedList secInfoList = new SortedList();

				// �S�БI�����ǂ���
				if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
				{
					extraInfo.SecCodeList = null;	//�S��
				}
				else
				{
					foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
					{
						secInfoList.Add(secInfoSet.SectionCode.Trim(), secInfoSet.SectionGuideNm.Trim());
					}

					foreach (DictionaryEntry dicEntry in this._selectedhSectinTable)
					{
						if ((CheckState)dicEntry.Value == CheckState.Checked)
						{
							secList.Add(dicEntry.Key);
							secNameList.Add(secInfoList[dicEntry.Key]);
						}
					}
					extraInfo.SecCodeList = (string[])secList.ToArray(typeof(string));

				}
			}
			// ���_�I�v�V�����Ȃ��̎�
			else
			{
				extraInfo.SecCodeList = null;	//�S��

			}

			// �W�v���@
            if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
            {
                extraInfo.TotalWay = 0;
            }
            else
            {
                extraInfo.TotalWay = 1;
            }

			// �Ώ۔N��(�J�n)	yyyymmdd�`���Ŏ擾�����Ώ۔N����yyyymm�ɍ���Ē��o�����ɓn��
			string st_AddUpYearMonth = Convert.ToString(this.ItdedDateStRF_tDateEdit.GetLongDate());
			st_AddUpYearMonth = st_AddUpYearMonth.Remove(6, 2);						// 6 �����ڂ̌ォ�� 2 �������폜����
			extraInfo.St_AddUpYearMonth = Convert.ToInt32(st_AddUpYearMonth);
			
			// �Ώ۔N��(�I��)        
			string ed_AddUpYearMonth = Convert.ToString(this.ItdedDateEdRF_tDateEdit.GetLongDate());
			ed_AddUpYearMonth = ed_AddUpYearMonth.Remove(6, 2);// 6 �����ڂ̌ォ�� 2 �������폜����
			extraInfo.Ed_AddUpYearMonth = Convert.ToInt32(ed_AddUpYearMonth);

			// ���z�P��
			extraInfo.MoneyUnit = (int)this.ultraOptionSet_MoneyUnit.CheckedItem.DataValue;

			// ����^�C�v
			extraInfo.PrintType =(int)this.tComboEditor_PrintType.SelectedItem.DataValue;

			// ����
			if (this.checkBox_NewPage.Checked)
			{
				extraInfo.NewPage = true;
			}
			else
			{
				extraInfo.NewPage = false;
			}

            // ����2
            if (this.checkBox_NewPage2.Checked)
            {
                extraInfo.NewPage2 = true;
            }
            else
            {
                extraInfo.NewPage2 = false;
            }
            // ---ADD 2009/01/30 �s��Ή�[9841] ---------------------------->>>>>
            if (this.checkBox_NewPage.Visible == false)
            {
                extraInfo.NewPage = false;
            }
            if (this.checkBox_NewPage2.Visible == false)
            {
                extraInfo.NewPage2 = false;
            }
            // ---ADD 2009/01/30 �s��Ή�[9841] ----------------------------<<<<<

			// �o�͕��@�i���[�^�C�v�j
			extraInfo.ListType = this._listTypePara;

			//����������
            if (TmTotalCostHigh_Nedit.Value == null)
            {
                extraInfo.St_MonthSalesRatio = -99999;
                extraInfo.St_MonthSalesRatio_ck = false;
            }
            else
            {
                extraInfo.St_MonthSalesRatio = TmTotalCostHigh_Nedit.GetInt();
                extraInfo.St_MonthSalesRatio_ck = true;
            }
            if (TmTotalCostLow_Nedit.Value == null)
            {
                extraInfo.Ed_MonthSalesRatio = 99999;
                extraInfo.Ed_MonthSalesRatio_ck = false;
            }
            else
            {
                extraInfo.Ed_MonthSalesRatio = TmTotalCostLow_Nedit.GetInt();
                extraInfo.Ed_MonthSalesRatio_ck = true;
            }
			//���N������
            if (TyTotalCostHigh_Nedit.Value == null)
            {
                extraInfo.St_YearSalesRatio = -99999;
                extraInfo.St_YearSalesRatio_ck = false;
            }
            else
            {
                extraInfo.St_YearSalesRatio = TyTotalCostHigh_Nedit.GetInt();
                extraInfo.St_YearSalesRatio_ck = true;
            }
            if (TyTotalCostLow_Nedit.Value == null)
            {
                extraInfo.Ed_YearSalesRatio = 99999;
                extraInfo.Ed_YearSalesRatio_ck = false;
            }
            else
            {
                extraInfo.Ed_YearSalesRatio = TyTotalCostLow_Nedit.GetInt();
                extraInfo.Ed_YearSalesRatio_ck = true;
            }
			//�����e��
            if (TmGrsMarginHigh_Nedit.Value == null)
            {
                extraInfo.St_MonthGrossRatio = -99999;
                extraInfo.St_MonthGrossRatio_ck = false;
            }
            else
            {
                extraInfo.St_MonthGrossRatio = TmGrsMarginHigh_Nedit.GetInt();
                extraInfo.St_MonthGrossRatio_ck = true;
            }
            if (TmGrsMarginLow_Nedit.Value == null)
            {
                extraInfo.Ed_MonthGrossRatio = 99999;
                extraInfo.Ed_MonthGrossRatio_ck = false;
            }
            else
            {
                extraInfo.Ed_MonthGrossRatio = TmGrsMarginLow_Nedit.GetInt();
                extraInfo.Ed_MonthGrossRatio_ck = true;
            }
			//���N�e��
            if (TyGrsMarginHigh_Nedit.Value == null)
            {
                extraInfo.St_YearGrossRatio = -99999;
                extraInfo.St_YearGrossRatio_ck = false;
            }
            else
            {
                extraInfo.St_YearGrossRatio = TyGrsMarginHigh_Nedit.GetInt();
                extraInfo.St_YearGrossRatio_ck = true;
            }
            if (TyGrsMarginLow_Nedit.Value == null)
            {
                extraInfo.Ed_YearGrossRatio = 99999;
                extraInfo.Ed_YearGrossRatio_ck = false;
            }
            else
            {
                extraInfo.Ed_YearGrossRatio = TyGrsMarginLow_Nedit.GetInt();
                extraInfo.Ed_YearGrossRatio_ck = true;
            }

			// ���Ӑ�(�J�n)
            extraInfo.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt();
            // ���Ӑ�(�I��)
            extraInfo.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt();

			// �S���҃R�[�h(�J�n)
			extraInfo.St_EmployeeCode = this.tNedit_SalesEmployeeCd_St.Text;
			// �S���҃R�[�h(�I��)
			extraInfo.Ed_EmployeeCode = this.tNedit_SalesEmployeeCd_Ed.Text;

			// �n��R�[�h(�J�n)
			extraInfo.St_SalesAreaCode = this.tNedit_AreaCd_St.GetInt();
			// �n��R�[�h(�I��)
			extraInfo.Ed_SalesAreaCode = this.tNedit_AreaCd_Ed.GetInt();

			// �Ǝ�R�[�h(�J�n)
			extraInfo.St_BusinessTypeCode = this.tNedit_BusinessTypeCode_St.GetInt();
			// �Ǝ�R�[�h(�I��)
			extraInfo.Ed_BusinessTypeCode = this.tNedit_BusinessTypeCode_Ed.GetInt();

            // BL�R�[�h�i�J�n�j
            extraInfo.St_BLGoodsCode = this.tNedit_BLGoodsCode_St.GetInt();
            // BL�R�[�h�i�I���j
            extraInfo.Ed_BLGoodsCode = this.tNedit_BLGoodsCode_Ed.GetInt();

            // ���i�啪�ރR�[�h�i�J�n�j
            extraInfo.St_GoodsLGroup = this.tNedit_GoodsLGroup_St.GetInt();
            // ���i�啪�ރR�[�h�i�I���j
            extraInfo.Ed_GoodsLGroup = this.tNedit_GoodsLGroup_Ed.GetInt();

            // ���i�����ރR�[�h�i�J�n�j
            extraInfo.St_GoodsMGroup = this.tNedit_GoodsMGroup_St.GetInt();
            // ���i�����ރR�[�h�i�I���j
            extraInfo.Ed_GoodsMGroup = this.tNedit_GoodsMGroup_Ed.GetInt();

            // �O���[�v�R�[�h�i�J�n�j
            extraInfo.St_BLGroupCode = this.tNedit_BLGloupCode_St.GetInt();
            // �O���[�v�R�[�h�i�I���j
            extraInfo.Ed_BLGroupCode = this.tNedit_BLGloupCode_Ed.GetInt();
            
            // ���s�^�C�v
            extraInfo.IssueType = (int)this.tComboEditor_IssueType.SelectedItem.DataValue;
        }

        /// <summary>
        /// �N�����[�h���f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
            _PrevYearCpDataTable = Broadleaf.Application.UIData.DCTOK02094EA.CT_PrevYearCpDataTable;
        }

        /// <summary>
        /// �ŏ�ʃt�H�[���擾
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 30462 �s�V �m��</br>
        /// <br>Date		: 2008.11.25</br>
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
		    this.AdjustExplorerBarExpand();
	    }
    	
	    /// <summary>
	    /// �G�N�X�v���[���[�o�[�W�J��Ԓ���
	    /// </summary>
	    private void AdjustExplorerBarExpand()
	    {
		    if (this._topForm == null) return;

		    if (this._topForm.Height > CT_TOPFORM_BASE_HEIGHT)
		    {
			    // �g�b�v�t�H�[���̍�������l��荂���ꍇ
                //this._explorerBarExpanding = true;
			    try
			    {
                    //this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = true;
			    }
			    finally
			    {
                    //this._explorerBarExpanding = false;
			    }
		    }
		    else
		    {
			    // �g�b�v�t�H�[���̍�������l���Ⴂ�ꍇ
                //this._explorerBarExpanding = true;
			    try
			    {
                    //this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = false;
			    }
			    finally
			    {
                    //this._explorerBarExpanding = false;
			    }
		    }
	    }

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
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
          return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
        }
        #endregion

        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        /// </summary>
        /// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        public bool GetMainOfficeFunc()
        {
            bool isMainOfficeFunc = false;

            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // ���O�C���S�����_���̎擾
            SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

            if (secInfoSet != null)
            {
                // �{�Ћ@�\���H
                if (secInfoSet.MainOfficeFuncFlag == 1)
                {
                    isMainOfficeFunc = true;
                }
            }
            else
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }

            return isMainOfficeFunc;
        }
 
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
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>
        private void SFUKK01390UA_Load(object sender, System.EventArgs e)
        {

            this.SettingDataTable();

			this._prevYearComparison = new PrevYearComparison();

            // �ŏ�ʃt�H�[���擾
		    this.GetTopForm();

            // ���_�I�v�V�����L�����擾����
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // �{��/���_�����擾����
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

		    this.Initial_Timer.Enabled = true;

            // --- ADD 2008/12/18 [9352] -------------------------------->>>>>
            TotalWayDivRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_TotalWay);
            TotalWayDivRadioKeyPressHelper.StartSpaceKeyControl();

            MoneyUnitDivRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_MoneyUnit);
            MoneyUnitDivRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2008/12/18 [9352] --------------------------------<<<<<
        }

        /// <summary>
        /// ��ʃA�N�e�B�u�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �������C����ʂ��A�N�e�B�u�ɂȂ����Ƃ��̃C�x���g�����ł��B</br>
        /// <br>Programer  : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        private void SFUKK01390UA_Activated(object sender, System.EventArgs e)
        {
            ParentToolbarSettingEvent(this);
        }

		/// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
        }

        /// <summary>
        /// �����^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B</br>
        /// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date        : 2008.11.25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // ��ʏ����\��
            this.InitialScreenSetting();
        
            // �����t�H�[�J�X�ݒ�
            this.ItdedDateStRF_tDateEdit.Focus();

    	    // ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
		    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
	    }
		    	        
		
		/// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
		/// <br>Programmer	: 30462 �s�V �m��</br>
		/// <br>Date		: 2008.11.25</br>
		/// </remarks>
		private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == "CustomerConditionGroup") ||
				(e.Group.Key == "ExtraConditionCodeGroup") ||
                (e.Group.Key == "IssueTypeGroup"))
			{
				// �O���[�v�̏k�����L�����Z��
				e.Cancel = true;
			}
		}

		/// <summary>
		/// GroupExpanding Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
		/// <br>Programmer	: 30462 �s�V �m��</br>
		/// <br>Date		: 2008.11.25</br>
		/// </remarks>
		private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == "CustomerConditionGroup") ||
                (e.Group.Key == "ExtraConditionCodeGroup") ||
                (e.Group.Key == "IssueTypeGroup"))
			{
				// �O���[�v�̓W�J���L�����Z��
				e.Cancel = true;
			}
		}

        /// <summary>
        /// �W�v���@�̐؂�ւ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraOptionSet_TotalWay_ValueChanged(object sender, EventArgs e)
        {
            bool bl_ck = false;
            bool bl_Checked = false;
            switch (this._listTypePara)
            {
                case 0:
                    if ((int)this.tComboEditor_IssueType.Value == 1)
                    {
                        bl_ck = true;
                    }
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2)
                    {
                        bl_ck = true;
                    }       
                    break;
                case 5:
                    // �����Ȃ�
                    break;
                case 6:
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    break;
            }

            if (this.ultraOptionSet_TotalWay.CheckedItem != null)
            {
                if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue ||
                    bl_ck)
                {
                    if (this._listTypePara == 0 &&
                        (int)this.tComboEditor_IssueType.Value == 2)
                    {
                        this.checkBox_NewPage.Checked = true;
                        this.checkBox_NewPage.Enabled = true;
                    }
                    else
                    {
                        if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
                        {
                            bl_Checked = false;
                        }
                        this.checkBox_NewPage.Checked = bl_Checked;
                        this.checkBox_NewPage.Enabled = false;
                    }
                }
                else
                {
                    this.checkBox_NewPage.Checked = true;
                    this.checkBox_NewPage.Enabled = true;
                }
            }
        }

        /// <summary>
        /// ���s�^�C�v�؂�ւ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_IssueType_ValueChanged(object sender, EventArgs e)
        {
            bool bl_ck = false;
            bool bl_ck2 = false;
            bool bl_Checked = false;
            switch (this._listTypePara)
            {
                case 0:
                    if ((int)this.tComboEditor_IssueType.Value == 2)
                    {
                        this.checkBox_NewPage.Text = "���Ӑ斈�ŉ���";
                    }
                    else
                    {
                        this.checkBox_NewPage.Text = "���_���ŉ���";
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 1)
                    {
                        bl_ck = true;
                    }
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if ((int)this.tComboEditor_IssueType.Value == 0 ||
                        (int)this.tComboEditor_IssueType.Value == 3)
                    {
                        bl_ck2 = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2)
                    {
                        bl_ck = true;
                    }      
                    break;
                case 5:
                    // �����Ȃ�
                    break;
                case 6:
                    if ((int)this.tComboEditor_IssueType.Value == 0)
                    {
                        bl_ck2 = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    break;
            }

            if (bl_ck ||
               (bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
            {
                if (this._listTypePara == 0 &&
                    (int)this.tComboEditor_IssueType.Value == 2)
                {
                    this.checkBox_NewPage.Checked = true;
                    this.checkBox_NewPage.Enabled = true;
                }
                else
                {
                    if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
                    {
                        bl_Checked = false;
                    }
                    this.checkBox_NewPage.Checked = bl_Checked;
                    this.checkBox_NewPage.Enabled = false;
                }

            }
            else
            {
                this.checkBox_NewPage.Checked = true;
                this.checkBox_NewPage.Enabled = true;
            }

            if (bl_ck2)
            {
                this.checkBox_NewPage2.Checked = false;
                this.checkBox_NewPage2.Enabled = false;
            }
            else
            {
                this.checkBox_NewPage2.Checked = true;
                this.checkBox_NewPage2.Enabled = true;
            }
        }


        /// <summary>
        /// ���ŏ����Q�؂�ւ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_NewPage2_CheckedChanged(object sender, EventArgs e)
        {
            // ---ADD 2009/01/30 �s��Ή�[9828] ---------------------------->>>>>
            // �O�N�Δ�\(�S���ҕ�)�A�O�N�Δ�\(�󒍎ҕ�)
            // �O�N�Δ�\(�n���)�A�O�N�Δ�\(�Ǝ��)
            if ((this._listTypePara == 1) || (this._listTypePara == 2) ||
                (this._listTypePara == 3) || (this._listTypePara == 4))
            {
                // ���s�^�C�v���u�����ʋ��_�ʁv�̏ꍇ
                if ((int)this.tComboEditor_IssueType.Value == 2)
                {
                    this.checkBox_NewPage.Checked = false;
                    this.checkBox_NewPage.Enabled = false;
                    return;
                }
            }
            // ---ADD 2009/01/30 �s��Ή�[9828] ----------------------------<<<<<

            bool bl_ck = false;
            bool bl_Checked = false;
            switch (this._listTypePara)
            {
                case 0:
                    // ���łQ�s�g�p
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    break;
                case 5:
                    // ���łQ�s�g�p
                    break;
                case 6:
                    if ((int)this.tComboEditor_IssueType.Value == 1 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    if ((int)this.tComboEditor_IssueType.Value == 2 &&
                        this.checkBox_NewPage2.Checked)
                    {
                        bl_ck = true;
                        bl_Checked = true;
                    }
                    break;
            }

            if (bl_ck ||
               (bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
            {
                if ((bool)this.ultraOptionSet_TotalWay.CheckedItem.DataValue)
                {
                    bl_Checked = false;
                }
                this.checkBox_NewPage.Checked = bl_Checked;
                this.checkBox_NewPage.Enabled = false;
            }
            else
            {
                this.checkBox_NewPage.Checked = true;
                this.checkBox_NewPage.Enabled = true;
            }
        }
	    #endregion
        
	    #region IPrintConditionInpTypeChart �����o


	    #endregion

	    #region IPrintConditionInpTypeSelectedSection �����o

		/// <summary>
		/// �w�o�͑Ώۋ��_�x�̓��쏈��
		/// </summary>
		public void CheckedSection(string sectionCode, CheckState checkState)
	    {
            // ���_��I��������
            if (checkState == CheckState.Checked)
            {
                // �S�Ђ��I�����ꂽ��
                if (sectionCode == "0")
                {
                    // �I��I�����X�g���N���A
                    this._selectedhSectinTable.Clear();
                }

                // ���X�g�ɋ��_���ǉ�����Ă��Ȃ����A���_�̏�Ԃ�ǉ�
                if (this._selectedhSectinTable.ContainsKey(sectionCode) == false)
                {
                    this._selectedhSectinTable.Add(sectionCode, checkState);
                }
            }
            // ���_�̑I��������������
            else if (checkState == CheckState.Unchecked)
            {
                // �I�����_���X�g����폜
                if (this._selectedhSectinTable.ContainsKey(sectionCode))
                {
                    this._selectedhSectinTable.Remove(sectionCode);
                }
            }
        }

        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
		/// <param name="sectionCodeLst"></param>
        /// <remarks>
        /// <br>Note       : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
	    {
            if (sectionCodeLst.Length == 0)
            {
                return;
            }

            this._selectedhSectinTable.Clear();
            for (int ix = 0; ix < sectionCodeLst.Length; ix++)
            {
                // �I�����_��ǉ�
                this._selectedhSectinTable.Add(sectionCodeLst[ix], CheckState.Checked);
            }
        }

		/// <summary>
		/// InitVisibleCheckSection
		/// </summary>
		public bool InitVisibleCheckSection(bool isDefaultState)
	    {
		    return isDefaultState;
	    }

        /// <summary>
        /// �v�㋒�_�I��\���擾�v���p�e�B
        /// </summary>
        public bool VisibledSelectAddUpCd
        {
            get
            {
                return _visibledSelectAddUpCd;
            }
        }

        /// <summary>
        /// ���_�I�v�V�����擾�v���p�e�B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�I�v�V�����擾�v���p�e�B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary>
        /// �{�Ћ@�\�擾�v���p�e�B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�Ћ@�\�擾�v���p�e�B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary>
        /// �v�㋒�_�I������
        /// </summary>
		/// <param name="SelectAddUpCd"></param>
        /// <remarks>
        /// <br>Note       : �v�㋒�_�I������</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        public void SelectedAddUpCd(int SelectAddUpCd)
	    {
            // ���݂̃`�F�b�N����Ă���v�㋒�_����n���B
            this._selectedAddUpCd = SelectAddUpCd;
        }

        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note       : �I������Ă���v�㋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            this._selectedAddUpCd = addUpCd;
            return;
        }


        #endregion


        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �擾�������Ӑ�R�[�h(�J�n)����ʂɕ\������
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
                _customerGuideOK = true;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �擾�������Ӑ�R�[�h(�I��)����ʂɕ\������
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
                _customerGuideOK = true;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
        }


        #region ���K�C�h�N���C�x���g
        /// <summary>
        /// ���Ӑ�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
        {

            _customerGuideOK = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                this.tNedit_CustomerCode_Ed.Focus();
            }
        }
        

        /// <summary>
        /// ���Ӑ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                switch (this._listTypePara)
                {
                    case 0: // ���Ӑ��
                        this.ultraOptionSet_TotalWay.Focus();
                        break;
                    case 1: // �S���ҕ�
                    case 2: // �󒍎ҕ�
                    case 6: // �a�k�R�[�h��
                        this.tNedit_SalesEmployeeCd_St.Focus();
                        break;
                    case 3: // �n���
                        this.tNedit_AreaCd_St.Focus();
                        break;
                    case 4: // �Ǝ��
                        this.tNedit_BusinessTypeCode_St.Focus();
                        break;
                    case 5: // ��ٰ�ߺ��ޕ�
                        break;
                }
            }
        }

        /// <summary>
        /// �S���҃R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void SalesEmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SalesEmployeeCd_St.DataText = employee.EmployeeCode.TrimEnd();
                this.tNedit_SalesEmployeeCd_Ed.Focus();
            }
        }

        /// <summary>
		/// �S���҃R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void SalesEmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Employee employee = new Employee();
            status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SalesEmployeeCd_Ed.DataText = employee.EmployeeCode.TrimEnd();
                switch (this._listTypePara)
                {
                    case 0: // ���Ӑ��
                    case 3: // �n���
                    case 4: // �Ǝ��
                    case 5: // ��ٰ�ߺ��ޕ�
                        break;
                    case 1: // �S���ҕ�
                    case 2: // �󒍎ҕ�
                        this.ultraOptionSet_TotalWay.Focus();
                        break;
                    case 6: // �a�k�R�[�h��
                        this.tNedit_BLGoodsCode_St.Focus();
                        break;                   
                }
            }
        }

		/// <summary>
        /// �n��ʃR�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
		private void AreaCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            if (status == 0)
            {
				tNedit_AreaCd_St.SetInt(userGdBd.GuideCode);
                this.tNedit_AreaCd_Ed.Focus();
			}
		}

		/// <summary>
		/// �n��R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
		private void AreaCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 21);

            if (status == 0)
            {
				tNedit_AreaCd_Ed.SetInt(userGdBd.GuideCode);
                switch (this._listTypePara)
                {
                    case 0: // ���Ӑ��
                    case 1: // �S���ҕ�
                    case 2: // �󒍎ҕ�
                    case 4: // �Ǝ��
                    case 5: // ��ٰ�ߺ��ޕ�
                    case 6: // �a�k�R�[�h��
                        break;
                    case 3: // �n���
                        this.ultraOptionSet_TotalWay.Focus();
                        break;
                }
			}
		}


		/// <summary>
		/// �Ǝ�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
		private void BusinessTypeCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            if (status == 0)
            {
				tNedit_BusinessTypeCode_St.SetInt(userGdBd.GuideCode);
                this.tNedit_BusinessTypeCode_Ed.Focus();
			}
		}

		/// <summary>
		/// �Ǝ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
		private void BusinessTypeCdEd_GuideBtn_Click(object sender, EventArgs e)
		{
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 33);

            if (status == 0)
            {
				tNedit_BusinessTypeCode_Ed.SetInt(userGdBd.GuideCode);
                switch (this._listTypePara)
                {
                    case 0: // ���Ӑ��
                    case 1: // �S���ҕ�
                    case 2: // �󒍎ҕ�
                    case 3: // �n���
                    case 5: // ��ٰ�ߺ��ޕ�
                    case 6: // �a�k�R�[�h��
                        break;
                    case 4: // �Ǝ��
                        this.ultraOptionSet_TotalWay.Focus();
                        break;
                }
			}
		}

        /// <summary>
        /// BL�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._goodsAcs.ExecuteBLGoodsCd(out blGoodsCdUMnt);
            if (status != 0) return;

            tNedit_BLGoodsCode_St.SetInt(blGoodsCdUMnt.BLGoodsCode);
            this.tNedit_BLGoodsCode_Ed.Focus();
        }

        /// <summary>
        /// BL�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = this._goodsAcs.ExecuteBLGoodsCd(out blGoodsCdUMnt);
            if (status != 0) return;

            tNedit_BLGoodsCode_Ed.SetInt(blGoodsCdUMnt.BLGoodsCode);
            switch (this._listTypePara)
            {
                case 0: // ���Ӑ��
                case 1: // �S���ҕ�
                case 2: // �󒍎ҕ�
                case 3: // �n���
                case 4: // �Ǝ��
                case 5: // ��ٰ�ߺ��ޕ�
                    break;
                case 6: // �a�k�R�[�h��
                    this.ultraOptionSet_TotalWay.Focus();
                    break;
            }
        }
        
        /// <summary>
        /// �O���[�v�R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_DetailGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // �K�C�h�f�[�^�T�[�`���[�h(1:�����[�g)

            if (status != 0) return;

            tNedit_BLGloupCode_St.SetInt(bLGroupU.BLGroupCode);
            this.tNedit_BLGloupCode_Ed.Focus();
        }

        /// <summary>
        /// �O���[�v�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_DetailGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._bLGroupUAcs == null)
            {
                this._bLGroupUAcs = new BLGroupUAcs();
            }

            BLGroupU bLGroupU;

            int status = this._bLGroupUAcs.ExecuteGuid(this._enterpriseCode, out bLGroupU);  // �K�C�h�f�[�^�T�[�`���[�h(1:�����[�g)

            if (status != 0) return;

            tNedit_BLGloupCode_Ed.SetInt(bLGroupU.BLGroupCode);
            switch (this._listTypePara)
            {
                case 0: // ���Ӑ��
                case 1: // �S���ҕ�
                case 2: // �󒍎ҕ�
                case 3: // �n���
                case 4: // �Ǝ��
                case 6: // �a�k�R�[�h��
                    break;
                case 5: // ��ٰ�ߺ��ޕ�
                    this.ultraOptionSet_TotalWay.Focus();
                    break;
            }
        }

        /// <summary>
        /// ���i�啪��(�J�n)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                tNedit_GoodsLGroup_St.SetInt(userGdBd.GuideCode);
                this.tNedit_GoodsLGroup_Ed.Focus();
            }
        }

        /// <summary>
        /// ���i�啪��(�I��)�K�C�h�N���{�^���N���C�x���g       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_GoodsLGroupGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null) this._userGuideAcs = new UserGuideAcs();
            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 70);

            if (status == 0)
            {
                tNedit_GoodsLGroup_Ed.SetInt(userGdBd.GuideCode);
                this.tNedit_GoodsMGroup_St.Focus();
            }
        }

        /// <summary>
        /// ���i������(�J�n)�K�C�h�N���{�^���N���C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_St_MediumGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            GoodsGroupU goodsGroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);  // �K�C�h�f�[�^�T�[�`���[�h(1:�����[�g)

            if (status != 0) return;

            tNedit_GoodsMGroup_St.SetInt(goodsGroupU.GoodsMGroup);
            this.tNedit_GoodsMGroup_Ed.Focus();
        }

        /// <summary>
        /// ���i������(�I��)�K�C�h�N���{�^���N���C�x���g 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ub_Ed_MediumGoodsGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsGroupUAcs == null)
            {
                this._goodsGroupUAcs = new GoodsGroupUAcs();
            }

            GoodsGroupU goodsGroupU;

            int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU);  // �K�C�h�f�[�^�T�[�`���[�h(1:�����[�g)

            if (status != 0) return;

            tNedit_GoodsMGroup_Ed.SetInt(goodsGroupU.GoodsMGroup);
            this.tNedit_BLGloupCode_St.Focus();
        }

		#endregion

        #region �g�p�R���g���[���̐ݒ�
        private void SetControl()
        {
            switch (this._listTypePara)
            {
                case 0: // ���Ӑ��
                    CustomerInput_Ok();
                    SalesEmployeeInput_Forbidden();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = false;
                    break;
                case 1: // �S���ҕ�
                case 2: // �󒍎ҕ�
                    CustomerInput_Ok();
                    SalesEmployeeInput_Ok();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = true;

                    if (this._listTypePara == 1)
                    {
                        this.ultraLabel_T2.Text = "�S����";
                        this.checkBox_NewPage2.Text = "�S���Җ��ŉ���";
                    }
                    else
                    {
                        this.ultraLabel_T2.Text = "�󒍎�";
                        this.checkBox_NewPage2.Text = "�󒍎Җ��ŉ���";
                    }
                    break;
                case 3: // �n���
                    CustomerInput_Ok();
                    SalesEmployeeInput_Forbidden();
                    AreaInput_Ok();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = true;
                    this.checkBox_NewPage2.Text = "�n�斈�ŉ���";

                    AreaMove();
                    break;
                case 4: // �Ǝ��
                    CustomerInput_Ok();
                    SalesEmployeeInput_Forbidden();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Ok();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = true;
                    this.checkBox_NewPage2.Text = "�Ǝ했�ŉ���";

                    BusinessTypeMove();
                    break;
                case 5: // ��ٰ�ߺ��ޕ�
                    CustomerInput_Forbidden();
                    SalesEmployeeInput_Forbidden();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Forbidden();
                    BLGloupCodeInput_Ok();
                    this.checkBox_NewPage2.Visible = false;

                    BLGloupCodeMove();
                    break;
                case 6: // �a�k�R�[�h��
                    CustomerInput_Ok();
                    SalesEmployeeInput_Ok();
                    AreaInput_Forbidden();
                    BusinessTypeInput_Forbidden();
                    BLGoodsCodeInput_Ok();
                    BLGloupCode_Forbidden();
                    this.checkBox_NewPage2.Visible = true;
                    this.checkBox_NewPage2.Text = "�a�k�R�[�h���ŉ���";

                    BLGoodsCodeMove();
                    this.ultraLabel_T2.Text = "�S����";
                    break;
            }
        }
        #endregion

        #region		�R���g���[���̓��͉E�s��
        //���Ӑ�
		private void CustomerInput_Ok()			//���͉�
		{
			this.tNedit_CustomerCode_St.Visible = true;
			this.tNedit_CustomerCode_Ed.Visible = true;
			this.CustomerCdSt_GuideBtn.Visible = true;
			this.CustomerCdEd_GuideBtn.Visible = true;
			this.ultraLbK_Customer.Visible = true;
			this.ultraLabel_T1.Visible = true;
		}
		private void CustomerInput_Forbidden()	//���͕s��
		{
			this.tNedit_CustomerCode_St.Visible = false;
			this.tNedit_CustomerCode_Ed.Visible = false;
			this.CustomerCdSt_GuideBtn.Visible = false;
			this.CustomerCdEd_GuideBtn.Visible = false;
			this.ultraLbK_Customer.Visible = false;
			this.ultraLabel_T1.Visible = false;
		}

	    //�S����
		private void SalesEmployeeInput_Ok()
		{
			this.tNedit_SalesEmployeeCd_St.Visible = true;
			this.tNedit_SalesEmployeeCd_Ed.Visible = true;
			this.SalesEmployeeCdSt_GuideBtn.Visible = true;
			this.SalesEmployeeCdEd_GuideBtn.Visible = true;
			this.ultraLbK_SalesEmp.Visible = true;
			this.ultraLabel_T2.Visible = true;
		}
		private void SalesEmployeeInput_Forbidden()
		{
			this.tNedit_SalesEmployeeCd_St.Visible = false;
			this.tNedit_SalesEmployeeCd_Ed.Visible = false;
			this.SalesEmployeeCdSt_GuideBtn.Visible = false;
			this.SalesEmployeeCdEd_GuideBtn.Visible = false;
			this.ultraLbK_SalesEmp.Visible = false;
			this.ultraLabel_T2.Visible = false;
		}

	    //�n��
		private void AreaInput_Ok()
		{
			this.tNedit_AreaCd_St.Visible = true;
			this.tNedit_AreaCd_Ed.Visible = true;
			this.AreaCdSt_GuideBtn.Visible = true;
			this.AreaCdEd_GuideBtn.Visible = true;
			this.ultraLbK_Area.Visible = true;
			this.ultraLabel_T3.Visible = true;
		}
		private void AreaInput_Forbidden()
		{
			this.tNedit_AreaCd_St.Visible = false;
			this.tNedit_AreaCd_Ed.Visible = false;
			this.AreaCdSt_GuideBtn.Visible = false;
			this.AreaCdEd_GuideBtn.Visible = false;
			this.ultraLbK_Area.Visible = false;
			this.ultraLabel_T3.Visible = false;
		}

	    //�Ǝ�
		private void BusinessTypeInput_Ok()
		{
			this.tNedit_BusinessTypeCode_St.Visible = true;
			this.tNedit_BusinessTypeCode_Ed.Visible = true;
			this.BusinessTypeCdSt_GuideBtn.Visible = true;
			this.BusinessTypeCdEd_GuideBtn.Visible = true;
			this.ultraLbK_Business.Visible = true;
			this.ultraLabel_T4.Visible = true;
		}
		private void BusinessTypeInput_Forbidden()
		{
			this.tNedit_BusinessTypeCode_St.Visible = false;
			this.tNedit_BusinessTypeCode_Ed.Visible = false;
			this.BusinessTypeCdSt_GuideBtn.Visible = false;
			this.BusinessTypeCdEd_GuideBtn.Visible = false;
			this.ultraLbK_Business.Visible = false;
			this.ultraLabel_T4.Visible = false;
		}

        //�a�k�R�[�h
        private void BLGoodsCodeInput_Ok()
		{
            this.tNedit_BLGoodsCode_St.Visible = true;
            this.tNedit_BLGoodsCode_Ed.Visible = true;
            this.ub_St_BLGoodsCodeGuide.Visible = true;
            this.ub_Ed_BLGoodsCodeGuide.Visible = true;
            this.ultraLbK_BLGoodsCode.Visible = true;
            this.ultraLabel_T5.Visible = true;
        }
        private void BLGoodsCodeInput_Forbidden()
        {
            this.tNedit_BLGoodsCode_St.Visible = false;
            this.tNedit_BLGoodsCode_Ed.Visible = false;
            this.ub_St_BLGoodsCodeGuide.Visible = false;
            this.ub_Ed_BLGoodsCodeGuide.Visible = false;
            this.ultraLbK_BLGoodsCode.Visible = false;
            this.ultraLabel_T5.Visible = false;
        }

        // ��ٰ�ߺ���
        private void BLGloupCodeInput_Ok()
        {
            this.tNedit_BLGloupCode_St.Visible = true;
            this.tNedit_BLGloupCode_Ed.Visible = true;
            this.ub_St_DetailGoodsGuide.Visible = true;
            this.ub_Ed_DetailGoodsGuide.Visible = true;
            this.ultraLbK_BLGloupCode.Visible = true;
            this.ultraLabel_T6.Visible = true;

            this.tNedit_GoodsLGroup_St.Visible = true;
            this.tNedit_GoodsLGroup_Ed.Visible = true;
            this.ub_St_GoodsLGroupGuide.Visible = true;
            this.ub_Ed_GoodsLGroupGuide.Visible = true;
            this.ultraLbK_GoodsLGroup.Visible = true;
            this.ultraLabel_T7.Visible = true;

            this.tNedit_GoodsMGroup_St.Visible = true;
            this.tNedit_GoodsMGroup_Ed.Visible = true;
            this.ub_St_MediumGoodsGuide.Visible = true;
            this.ub_Ed_MediumGoodsGuide.Visible = true;
            this.ultraLbK_GoodsMGroup.Visible = true;
            this.ultraLabel_T8.Visible = true;
        }
        private void BLGloupCode_Forbidden()
        {
            this.tNedit_BLGloupCode_St.Visible = false;
            this.tNedit_BLGloupCode_Ed.Visible = false;
            this.ub_St_DetailGoodsGuide.Visible = false;
            this.ub_Ed_DetailGoodsGuide.Visible = false;
            this.ultraLbK_BLGloupCode.Visible = false;
            this.ultraLabel_T6.Visible = false;

            this.tNedit_GoodsLGroup_St.Visible = false;
            this.tNedit_GoodsLGroup_Ed.Visible = false;
            this.ub_St_GoodsLGroupGuide.Visible = false;
            this.ub_Ed_GoodsLGroupGuide.Visible = false;
            this.ultraLbK_GoodsLGroup.Visible = false;
            this.ultraLabel_T7.Visible = false;

            this.tNedit_GoodsMGroup_St.Visible = false;
            this.tNedit_GoodsMGroup_Ed.Visible = false;
            this.ub_St_MediumGoodsGuide.Visible = false;
            this.ub_Ed_MediumGoodsGuide.Visible = false;
            this.ultraLbK_GoodsMGroup.Visible = false;
            this.ultraLabel_T8.Visible = false;
        }

        #endregion

		#region �R���g���[���̈ʒu�ړ�

		//  �S���ҕʂ̎��F���Ӑ�̈ʒu��
		private void SalesEmployeeMove()
		{
			ultraLabel_T2.Top = ultraLabel_T1.Top;
			tNedit_SalesEmployeeCd_St.Top = tNedit_CustomerCode_St.Top;
			tNedit_SalesEmployeeCd_Ed.Top = tNedit_CustomerCode_Ed.Top;
			SalesEmployeeCdSt_GuideBtn.Top = CustomerCdSt_GuideBtn.Top;
			SalesEmployeeCdEd_GuideBtn.Top = CustomerCdEd_GuideBtn.Top;
			ultraLbK_SalesEmp.Top = ultraLbK_Customer.Top;
		}
		//	�n��ʂ̎��F�S���҂̈ʒu��
		private void AreaMove()
		{
			ultraLabel_T3.Top = ultraLabel_T2.Top;
			tNedit_AreaCd_St.Top = tNedit_SalesEmployeeCd_St.Top;
			tNedit_AreaCd_Ed.Top = tNedit_SalesEmployeeCd_Ed.Top;
			AreaCdSt_GuideBtn.Top = SalesEmployeeCdSt_GuideBtn.Top;
			AreaCdEd_GuideBtn.Top = SalesEmployeeCdEd_GuideBtn.Top;
			ultraLbK_Area.Top = ultraLbK_SalesEmp.Top;
		}
		//	�Ǝ�ʂ̎��F�S���҂̈ʒu��
		private void BusinessTypeMove()
		{
			ultraLabel_T4.Top = ultraLabel_T2.Top;
			tNedit_BusinessTypeCode_St.Top = tNedit_SalesEmployeeCd_St.Top;
			tNedit_BusinessTypeCode_Ed.Top = tNedit_SalesEmployeeCd_Ed.Top;
			BusinessTypeCdSt_GuideBtn.Top = SalesEmployeeCdSt_GuideBtn.Top;
			BusinessTypeCdEd_GuideBtn.Top = SalesEmployeeCdEd_GuideBtn.Top;
			ultraLbK_Business.Top = ultraLbK_SalesEmp.Top;
		}
        //	�a�k�R�[�h�ʂ̎��F�n��̈ʒu��
        private void BLGoodsCodeMove()
        {
            ultraLabel_T5.Top = ultraLabel_T3.Top;
            tNedit_BLGoodsCode_St.Top = tNedit_AreaCd_St.Top;
            tNedit_BLGoodsCode_Ed.Top = tNedit_AreaCd_Ed.Top;
            ub_St_BLGoodsCodeGuide.Top = AreaCdSt_GuideBtn.Top;
            ub_Ed_BLGoodsCodeGuide.Top = AreaCdEd_GuideBtn.Top;
            ultraLbK_BLGoodsCode.Top = ultraLbK_Area.Top;
        }
        //	�O���[�v�ʂ̎��F�啪�ށ����Ӑ�̈ʒu��
        //                  �����ށ��S���҂̈ʒu��
        //  �@�@�@�@�@�@�@�@��ٰ�ߺ��ށ��n��̈ʒu��
        private void BLGloupCodeMove()
        {
            ultraLabel_T7.Top = ultraLabel_T1.Top;
            tNedit_GoodsLGroup_St.Top = tNedit_CustomerCode_St.Top;
            tNedit_GoodsLGroup_Ed.Top = tNedit_CustomerCode_Ed.Top;
            ub_St_GoodsLGroupGuide.Top = CustomerCdSt_GuideBtn.Top;
            ub_Ed_GoodsLGroupGuide.Top = CustomerCdEd_GuideBtn.Top;
            ultraLbK_GoodsLGroup.Top = ultraLbK_Customer.Top;

            ultraLabel_T8.Top = ultraLabel_T2.Top;
            tNedit_GoodsMGroup_St.Top = tNedit_SalesEmployeeCd_St.Top;
            tNedit_GoodsMGroup_Ed.Top = tNedit_SalesEmployeeCd_Ed.Top;
            ub_St_MediumGoodsGuide.Top = SalesEmployeeCdSt_GuideBtn.Top;
            ub_Ed_MediumGoodsGuide.Top = SalesEmployeeCdEd_GuideBtn.Top;
            ultraLbK_GoodsMGroup.Top = ultraLbK_SalesEmp.Top;

            ultraLabel_T6.Top = ultraLabel_T3.Top;
            tNedit_BLGloupCode_St.Top = tNedit_AreaCd_St.Top;
            tNedit_BLGloupCode_Ed.Top = tNedit_AreaCd_Ed.Top;
            ub_St_DetailGoodsGuide.Top = AreaCdSt_GuideBtn.Top;
            ub_Ed_DetailGoodsGuide.Top = AreaCdEd_GuideBtn.Top;
            ultraLbK_BLGloupCode.Top = ultraLbK_Area.Top;
        }

		#endregion
	}
}

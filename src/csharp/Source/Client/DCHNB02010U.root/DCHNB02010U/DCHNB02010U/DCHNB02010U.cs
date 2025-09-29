//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �󒍑ݏo�m�F�\
// �v���O�����T�v   : �󒍊m�F�\�A�ݏo�m�F�\�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �n���@��
// �� �� ��  2008/01/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2008/07/24  �C�����e : PM.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2008/11/17  �C�����e : �e�����ڂ̓��͒l�������ꍇ�A���̓`�F�b�N�ŃG���[
//                                  �����_�̔���S�̐ݒ肪�Ȃ����00���_���擾����悤�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2008/11/18  �C�����e : 2008.11.17�̏C���Ɍ�肪���������ߏC��
//                                  �����_�̔���ݒ�}�X�^���擾���A�_���폜�`�F�b�N��ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/30  �C�����e : ��Q�Ή�10230�A10231�A12395�A12397
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/06  �C�����e : ��Q�Ή�13094
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/07  �C�����e : ��Q�Ή�13094(�ďC��)
//----------------------------------------------------------------------------//
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
using Broadleaf.Application.Controller.Util; // ADD 2009/03/30

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �󒍑ݏo�m�F�\�t�h�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �󒍑ݏo�m�F�\�t�h�N���X</br>
	/// <br>Programmer : 30191 �n���@��</br>
	/// <br>Date	   : 2008.01.23</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: PM.NS�Ή�</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2008.07.24</br>
    /// <br>Programmer	: 30452 ��� �r��</br>
    /// <br>Date		: 2008.11.17</br>
    /// <br>              �E�e�����ڂ̓��͒l�������ꍇ�A���̓`�F�b�N�ŃG���[</br>
    /// <br>              �E�����_�̔���S�̐ݒ肪�Ȃ����00���_���擾����悤�C��</br>
    /// <br>Programmer	: 30452 ��� �r��</br>
    /// <br>Date		: 2008.11.18</br>
    /// <br>              �E2008.11.17�̏C���Ɍ�肪���������ߏC��</br>
    /// <br>              �E�����_�̔���ݒ�}�X�^���擾���A�_���폜�`�F�b�N��ǉ�</br>
    /// <br>Update Note : 2009/03/30 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�10230�A10231�A12395�A12397</br>
    /// <br>Update Note : 2009/04/06 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�13094</br>
    /// <br>Update Note : 2009/04/07 30452 ��� �r��</br>
    /// <br>              �E��Q�Ή�13094(�ďC��)</br>
    /// <br></br>
	/// </remarks>  
    public class DCHNB02010UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel DCHNB02010UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
        private TComboEditor PrintOder_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
        private TDateEdit SalesDateEdRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TDateEdit SalesDateStRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TDateEdit InputDayEdRF_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private TDateEdit InputDayStRF_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private TNedit tNedit_CustomerCode_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TNedit tNedit_CustomerCode_St;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private TEdit tEdit_EmployeeCode_Ed;
        private TEdit tEdit_EmployeeCode_St;
		private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton SalesEmployeeCdSt_GuideBtn;
        private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
		private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
		private ToolTip toolTip1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel20;
		private Infragistics.Win.Misc.UltraLabel ultraLabel19;
		private Infragistics.Win.Misc.UltraLabel ultraLabel18;
		private TEdit GrossMarginMaxMark_tEdit;
		private TEdit GrossMarginUprMark_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private TNedit GrossMarginUpper2_Nedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel16;
		private TEdit GrossMarginBestMark_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.Misc.UltraLabel ultraLabel14;
		private TNedit GrossMarginBest2_Nedit;
		private TEdit GrossMarginLowMark_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private TNedit GrossMarginLow2_Nedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private TComboEditor tComboEditor_NewPageType;
        private TNedit GrsProfitCheckUpper_tNedit;
        private TNedit GrsProfitCheckBest_tNedit;
        private TNedit GrsProfitCheckLower_tNedit;
        private TComboEditor tComboEditor_PublicationType;
        private Infragistics.Win.Misc.UltraLabel ultraLabel34;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_PrintDailyFooter;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet ultraOptionSet_CostOut;
		private System.ComponentModel.IContainer components;
		#endregion
		
		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region constructer
		/// <summary>
		/// �󒍑ݏo�m�F�\�t�h�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �󒍑ݏo�m�F�\�t�h�N���X�̏���������уC���X�^���X�̐������s��</br>
		/// <br>Programmer : 30191 �n���@��</br>
		/// <br>Date	   : 2008.01.23</br>
		/// <br></br>
		/// </remarks>  
		public DCHNB02010UA()
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
            this._lGoodsGanreAcs = new LGoodsGanreAcs();
            this._mGoodsGanreAcs = new MGoodsGanreAcs();

			//���t�`�F�b�N���i�̃C���X�^���X�𐶐�
			this._dateGetAcs = DateGetAcs.GetInstance();
        }
		#endregion

		// ===================================================================================== //
		// �j��
		// ===================================================================================== //
		#region Dispose        
		/// <summary>
		/// Dispose
		/// </summary>
		protected override void Dispose(bool disposing)
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.ultraOptionSet_PrintDailyFooter = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraOptionSet_CostOut = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.tComboEditor_NewPageType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.InputDayEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDayStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesDateEdRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesDateStRF_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tComboEditor_PublicationType = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.GrsProfitCheckUpper_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrsProfitCheckBest_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrsProfitCheckLower_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel20 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel19 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginMaxMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GrossMarginUprMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginUpper2_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginBestMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginBest2_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.GrossMarginLowMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.GrossMarginLow2_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.SalesEmployeeCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.SalesEmployeeCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_EmployeeCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_EmployeeCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.DCHNB02010UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_CostOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPageType)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PublicationType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckUpper_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckBest_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckLower_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginMaxMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginUprMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginUpper2_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginBestMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginBest2_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginLowMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginLow2_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).BeginInit();
            this.DCHNB02010UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_PrintDailyFooter);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraOptionSet_CostOut);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel21);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.tComboEditor_NewPageType);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SalesDateEdRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.SalesDateStRF_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(695, 127);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // ultraOptionSet_PrintDailyFooter
            // 
            this.ultraOptionSet_PrintDailyFooter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_PrintDailyFooter.CheckedIndex = 0;
            valueListItem1.DataValue = "0";
            valueListItem1.DisplayText = "���Ȃ�";
            valueListItem2.DataValue = "1";
            valueListItem2.DisplayText = "����";
            this.ultraOptionSet_PrintDailyFooter.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.ultraOptionSet_PrintDailyFooter.Location = new System.Drawing.Point(465, 91);
            this.ultraOptionSet_PrintDailyFooter.Name = "ultraOptionSet_PrintDailyFooter";
            this.ultraOptionSet_PrintDailyFooter.Size = new System.Drawing.Size(130, 20);
            this.ultraOptionSet_PrintDailyFooter.TabIndex = 7;
            this.ultraOptionSet_PrintDailyFooter.Text = "���Ȃ�";
            // 
            // ultraOptionSet_CostOut
            // 
            this.ultraOptionSet_CostOut.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraOptionSet_CostOut.CheckedIndex = 0;
            valueListItem3.DataValue = "0";
            valueListItem3.DisplayText = "�Ȃ�";
            valueListItem4.DataValue = "1";
            valueListItem4.DisplayText = "����";
            this.ultraOptionSet_CostOut.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4});
            this.ultraOptionSet_CostOut.Location = new System.Drawing.Point(465, 67);
            this.ultraOptionSet_CostOut.Name = "ultraOptionSet_CostOut";
            this.ultraOptionSet_CostOut.Size = new System.Drawing.Size(112, 20);
            this.ultraOptionSet_CostOut.TabIndex = 6;
            this.ultraOptionSet_CostOut.Text = "�Ȃ�";
            // 
            // ultraLabel12
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance8;
            this.ultraLabel12.Location = new System.Drawing.Point(337, 88);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel12.TabIndex = 37;
            this.ultraLabel12.Text = "���v��";
            // 
            // ultraLabel4
            // 
            appearance67.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance67;
            this.ultraLabel4.Location = new System.Drawing.Point(337, 64);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel4.TabIndex = 36;
            this.ultraLabel4.Text = "�����E�e���o��";
            // 
            // ultraLabel21
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance23;
            this.ultraLabel21.Location = new System.Drawing.Point(15, 62);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel21.TabIndex = 35;
            this.ultraLabel21.Text = "����";
            // 
            // tComboEditor_NewPageType
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPageType.ActiveAppearance = appearance68;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_NewPageType.Appearance = appearance21;
            this.tComboEditor_NewPageType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_NewPageType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_NewPageType.ItemAppearance = appearance69;
            valueListItem5.DataValue = ((short)(0));
            valueListItem5.DisplayText = "���_";
            valueListItem6.DataValue = ((short)(1));
            valueListItem6.DisplayText = "���v";
            valueListItem7.DataValue = ((short)(2));
            valueListItem7.DisplayText = "���Ȃ�";
            this.tComboEditor_NewPageType.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem5,
            valueListItem6,
            valueListItem7});
            this.tComboEditor_NewPageType.LimitToList = true;
            this.tComboEditor_NewPageType.Location = new System.Drawing.Point(150, 63);
            this.tComboEditor_NewPageType.Name = "tComboEditor_NewPageType";
            this.tComboEditor_NewPageType.Size = new System.Drawing.Size(112, 24);
            this.tComboEditor_NewPageType.TabIndex = 5;
            // 
            // InputDayEdRF_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayEdRF_tDateEdit.ActiveEditAppearance = appearance1;
            this.InputDayEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayEdRF_tDateEdit.CalendarDisp = true;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.InputDayEdRF_tDateEdit.EditAppearance = appearance2;
            this.InputDayEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.InputDayEdRF_tDateEdit.LabelAppearance = appearance3;
            this.InputDayEdRF_tDateEdit.Location = new System.Drawing.Point(368, 33);
            this.InputDayEdRF_tDateEdit.Name = "InputDayEdRF_tDateEdit";
            this.InputDayEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayEdRF_tDateEdit.TabIndex = 4;
            this.InputDayEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel6
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance4;
            this.ultraLabel6.Location = new System.Drawing.Point(337, 33);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel6.TabIndex = 31;
            this.ultraLabel6.Text = "�`";
            // 
            // InputDayStRF_tDateEdit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayStRF_tDateEdit.ActiveEditAppearance = appearance5;
            this.InputDayStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayStRF_tDateEdit.CalendarDisp = true;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.InputDayStRF_tDateEdit.EditAppearance = appearance6;
            this.InputDayStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.InputDayStRF_tDateEdit.LabelAppearance = appearance7;
            this.InputDayStRF_tDateEdit.Location = new System.Drawing.Point(150, 33);
            this.InputDayStRF_tDateEdit.Name = "InputDayStRF_tDateEdit";
            this.InputDayStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayStRF_tDateEdit.TabIndex = 3;
            this.InputDayStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel7
            // 
            appearance66.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance66;
            this.ultraLabel7.Location = new System.Drawing.Point(15, 33);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(128, 23);
            this.ultraLabel7.TabIndex = 30;
            this.ultraLabel7.Text = "���͓�";
            // 
            // SalesDateEdRF_tDateEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesDateEdRF_tDateEdit.ActiveEditAppearance = appearance9;
            this.SalesDateEdRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.SalesDateEdRF_tDateEdit.CalendarDisp = true;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.SalesDateEdRF_tDateEdit.EditAppearance = appearance10;
            this.SalesDateEdRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.SalesDateEdRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.SalesDateEdRF_tDateEdit.LabelAppearance = appearance11;
            this.SalesDateEdRF_tDateEdit.Location = new System.Drawing.Point(368, 3);
            this.SalesDateEdRF_tDateEdit.Name = "SalesDateEdRF_tDateEdit";
            this.SalesDateEdRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.SalesDateEdRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.SalesDateEdRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.SalesDateEdRF_tDateEdit.TabIndex = 2;
            this.SalesDateEdRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance12;
            this.ultraLabel10.Location = new System.Drawing.Point(337, 3);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "�`";
            // 
            // SalesDateStRF_tDateEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SalesDateStRF_tDateEdit.ActiveEditAppearance = appearance13;
            this.SalesDateStRF_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.SalesDateStRF_tDateEdit.CalendarDisp = true;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.SalesDateStRF_tDateEdit.EditAppearance = appearance14;
            this.SalesDateStRF_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.SalesDateStRF_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.SalesDateStRF_tDateEdit.LabelAppearance = appearance15;
            this.SalesDateStRF_tDateEdit.Location = new System.Drawing.Point(150, 3);
            this.SalesDateStRF_tDateEdit.Name = "SalesDateStRF_tDateEdit";
            this.SalesDateStRF_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.SalesDateStRF_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.SalesDateStRF_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.SalesDateStRF_tDateEdit.TabIndex = 1;
            this.SalesDateStRF_tDateEdit.TabStop = true;
            // 
            // ultraLabel8
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance16;
            this.ultraLabel8.Location = new System.Drawing.Point(15, 3);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(128, 23);
            this.ultraLabel8.TabIndex = 22;
            this.ultraLabel8.Text = "���t";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 210);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(695, 31);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance17;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.Appearance = appearance22;
            this.PrintOder_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintOder_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance18;
            this.PrintOder_tComboEditor.LimitToList = true;
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(150, 4);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(372, 24);
            this.PrintOder_tComboEditor.TabIndex = 7;
            // 
            // ultraLabel5
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance19;
            this.ultraLabel5.Location = new System.Drawing.Point(16, 3);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 3;
            this.ultraLabel5.Text = "�o�͏�";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tComboEditor_PublicationType);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel34);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckUpper_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckBest_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrsProfitCheckLower_tNedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel20);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel19);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel18);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginMaxMark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginUprMark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel17);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginUpper2_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel16);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginBestMark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel14);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginBest2_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginLowMark_tEdit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.GrossMarginLow2_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SalesEmployeeCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_EmployeeCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_EmployeeCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel25);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel26);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_CustomerCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 278);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(695, 215);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // tComboEditor_PublicationType
            // 
            appearance84.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PublicationType.ActiveAppearance = appearance84;
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PublicationType.Appearance = appearance20;
            this.tComboEditor_PublicationType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tComboEditor_PublicationType.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tComboEditor_PublicationType.ItemAppearance = appearance85;
            this.tComboEditor_PublicationType.LimitToList = true;
            this.tComboEditor_PublicationType.Location = new System.Drawing.Point(150, 61);
            this.tComboEditor_PublicationType.Name = "tComboEditor_PublicationType";
            this.tComboEditor_PublicationType.Size = new System.Drawing.Size(131, 24);
            this.tComboEditor_PublicationType.TabIndex = 30;
            // 
            // ultraLabel34
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance70;
            this.ultraLabel34.Location = new System.Drawing.Point(15, 61);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(127, 23);
            this.ultraLabel34.TabIndex = 79;
            this.ultraLabel34.Text = "���s�^�C�v";
            // 
            // GrsProfitCheckUpper_tNedit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.TextHAlignAsString = "Right";
            this.GrsProfitCheckUpper_tNedit.ActiveAppearance = appearance40;
            appearance41.TextHAlignAsString = "Right";
            this.GrsProfitCheckUpper_tNedit.Appearance = appearance41;
            this.GrsProfitCheckUpper_tNedit.AutoSelect = true;
            this.GrsProfitCheckUpper_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrsProfitCheckUpper_tNedit.DataText = "";
            this.GrsProfitCheckUpper_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrsProfitCheckUpper_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GrsProfitCheckUpper_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrsProfitCheckUpper_tNedit.Location = new System.Drawing.Point(150, 177);
            this.GrsProfitCheckUpper_tNedit.MaxLength = 4;
            this.GrsProfitCheckUpper_tNedit.Name = "GrsProfitCheckUpper_tNedit";
            this.GrsProfitCheckUpper_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckUpper_tNedit.Size = new System.Drawing.Size(43, 24);
            this.GrsProfitCheckUpper_tNedit.TabIndex = 70;
            this.GrsProfitCheckUpper_tNedit.ValueChanged += new System.EventHandler(this.GrsProfitCheckUpper_tNedit_ValueChanged);
            this.GrsProfitCheckUpper_tNedit.Leave += new System.EventHandler(this.GrsProfitCheckUpper_tNedit_Leave);
            // 
            // GrsProfitCheckBest_tNedit
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance24.TextHAlignAsString = "Right";
            this.GrsProfitCheckBest_tNedit.ActiveAppearance = appearance24;
            appearance25.TextHAlignAsString = "Right";
            this.GrsProfitCheckBest_tNedit.Appearance = appearance25;
            this.GrsProfitCheckBest_tNedit.AutoSelect = true;
            this.GrsProfitCheckBest_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrsProfitCheckBest_tNedit.DataText = "";
            this.GrsProfitCheckBest_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrsProfitCheckBest_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GrsProfitCheckBest_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrsProfitCheckBest_tNedit.Location = new System.Drawing.Point(150, 148);
            this.GrsProfitCheckBest_tNedit.MaxLength = 4;
            this.GrsProfitCheckBest_tNedit.Name = "GrsProfitCheckBest_tNedit";
            this.GrsProfitCheckBest_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckBest_tNedit.Size = new System.Drawing.Size(43, 24);
            this.GrsProfitCheckBest_tNedit.TabIndex = 60;
            this.GrsProfitCheckBest_tNedit.ValueChanged += new System.EventHandler(this.GrsProfitCheckBest_tNedit_ValueChanged);
            this.GrsProfitCheckBest_tNedit.Leave += new System.EventHandler(this.GrsProfitCheckBest_tNedit_Leave);
            // 
            // GrsProfitCheckLower_tNedit
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance47.TextHAlignAsString = "Right";
            this.GrsProfitCheckLower_tNedit.ActiveAppearance = appearance47;
            appearance48.TextHAlignAsString = "Right";
            this.GrsProfitCheckLower_tNedit.Appearance = appearance48;
            this.GrsProfitCheckLower_tNedit.AutoSelect = true;
            this.GrsProfitCheckLower_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrsProfitCheckLower_tNedit.DataText = "";
            this.GrsProfitCheckLower_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrsProfitCheckLower_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.GrsProfitCheckLower_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrsProfitCheckLower_tNedit.Location = new System.Drawing.Point(150, 119);
            this.GrsProfitCheckLower_tNedit.MaxLength = 4;
            this.GrsProfitCheckLower_tNedit.Name = "GrsProfitCheckLower_tNedit";
            this.GrsProfitCheckLower_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 1, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrsProfitCheckLower_tNedit.Size = new System.Drawing.Size(43, 24);
            this.GrsProfitCheckLower_tNedit.TabIndex = 50;
            this.GrsProfitCheckLower_tNedit.ValueChanged += new System.EventHandler(this.GrsProfitCheckLower_tNedit_ValueChanged);
            this.GrsProfitCheckLower_tNedit.Leave += new System.EventHandler(this.GrsProfitCheckLower_tNedit_Leave);
            // 
            // ultraLabel20
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel20.Appearance = appearance26;
            this.ultraLabel20.Location = new System.Drawing.Point(373, 148);
            this.ultraLabel20.Name = "ultraLabel20";
            this.ultraLabel20.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel20.TabIndex = 78;
            this.ultraLabel20.Text = "��";
            // 
            // ultraLabel19
            // 
            appearance27.TextVAlignAsString = "Middle";
            this.ultraLabel19.Appearance = appearance27;
            this.ultraLabel19.Location = new System.Drawing.Point(217, 148);
            this.ultraLabel19.Name = "ultraLabel19";
            this.ultraLabel19.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel19.TabIndex = 77;
            this.ultraLabel19.Text = "��";
            // 
            // ultraLabel18
            // 
            appearance28.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance28;
            this.ultraLabel18.Location = new System.Drawing.Point(217, 119);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel18.TabIndex = 76;
            this.ultraLabel18.Text = "��";
            // 
            // GrossMarginMaxMark_tEdit
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMarginMaxMark_tEdit.ActiveAppearance = appearance29;
            this.GrossMarginMaxMark_tEdit.AutoSelect = true;
            this.GrossMarginMaxMark_tEdit.DataText = "";
            this.GrossMarginMaxMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginMaxMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMarginMaxMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMarginMaxMark_tEdit.Location = new System.Drawing.Point(413, 177);
            this.GrossMarginMaxMark_tEdit.MaxLength = 2;
            this.GrossMarginMaxMark_tEdit.Name = "GrossMarginMaxMark_tEdit";
            this.GrossMarginMaxMark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginMaxMark_tEdit.TabIndex = 71;
            // 
            // GrossMarginUprMark_tEdit
            // 
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMarginUprMark_tEdit.ActiveAppearance = appearance30;
            this.GrossMarginUprMark_tEdit.AutoSelect = true;
            this.GrossMarginUprMark_tEdit.DataText = "";
            this.GrossMarginUprMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginUprMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMarginUprMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMarginUprMark_tEdit.Location = new System.Drawing.Point(413, 148);
            this.GrossMarginUprMark_tEdit.MaxLength = 2;
            this.GrossMarginUprMark_tEdit.Name = "GrossMarginUprMark_tEdit";
            this.GrossMarginUprMark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginUprMark_tEdit.TabIndex = 62;
            // 
            // ultraLabel17
            // 
            appearance31.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance31;
            this.ultraLabel17.Location = new System.Drawing.Point(217, 177);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(65, 23);
            this.ultraLabel17.TabIndex = 74;
            this.ultraLabel17.Text = "���ȏ�";
            // 
            // GrossMarginUpper2_Nedit
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance32.TextHAlignAsString = "Left";
            this.GrossMarginUpper2_Nedit.ActiveAppearance = appearance32;
            appearance33.TextHAlignAsString = "Right";
            this.GrossMarginUpper2_Nedit.Appearance = appearance33;
            this.GrossMarginUpper2_Nedit.AutoSelect = true;
            this.GrossMarginUpper2_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMarginUpper2_Nedit.DataText = "";
            this.GrossMarginUpper2_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginUpper2_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMarginUpper2_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMarginUpper2_Nedit.Location = new System.Drawing.Point(306, 148);
            this.GrossMarginUpper2_Nedit.MaxLength = 4;
            this.GrossMarginUpper2_Nedit.Name = "GrossMarginUpper2_Nedit";
            this.GrossMarginUpper2_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMarginUpper2_Nedit.ReadOnly = true;
            this.GrossMarginUpper2_Nedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GrossMarginUpper2_Nedit.Size = new System.Drawing.Size(44, 24);
            this.GrossMarginUpper2_Nedit.TabIndex = 61;
            // 
            // ultraLabel16
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance34;
            this.ultraLabel16.Location = new System.Drawing.Point(260, 148);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel16.TabIndex = 70;
            this.ultraLabel16.Text = "�`";
            // 
            // GrossMarginBestMark_tEdit
            // 
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMarginBestMark_tEdit.ActiveAppearance = appearance35;
            this.GrossMarginBestMark_tEdit.AutoSelect = true;
            this.GrossMarginBestMark_tEdit.DataText = "";
            this.GrossMarginBestMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginBestMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMarginBestMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMarginBestMark_tEdit.Location = new System.Drawing.Point(413, 119);
            this.GrossMarginBestMark_tEdit.MaxLength = 2;
            this.GrossMarginBestMark_tEdit.Name = "GrossMarginBestMark_tEdit";
            this.GrossMarginBestMark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginBestMark_tEdit.TabIndex = 52;
            // 
            // ultraLabel15
            // 
            appearance36.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance36;
            this.ultraLabel15.Location = new System.Drawing.Point(373, 119);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel15.TabIndex = 67;
            this.ultraLabel15.Text = "��";
            // 
            // ultraLabel14
            // 
            appearance37.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance37;
            this.ultraLabel14.Location = new System.Drawing.Point(260, 119);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(24, 23);
            this.ultraLabel14.TabIndex = 65;
            this.ultraLabel14.Text = "�`";
            // 
            // GrossMarginBest2_Nedit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.TextHAlignAsString = "Left";
            this.GrossMarginBest2_Nedit.ActiveAppearance = appearance38;
            appearance39.TextHAlignAsString = "Right";
            this.GrossMarginBest2_Nedit.Appearance = appearance39;
            this.GrossMarginBest2_Nedit.AutoSelect = true;
            this.GrossMarginBest2_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMarginBest2_Nedit.DataText = "";
            this.GrossMarginBest2_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginBest2_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMarginBest2_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMarginBest2_Nedit.Location = new System.Drawing.Point(306, 119);
            this.GrossMarginBest2_Nedit.MaxLength = 4;
            this.GrossMarginBest2_Nedit.Name = "GrossMarginBest2_Nedit";
            this.GrossMarginBest2_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMarginBest2_Nedit.ReadOnly = true;
            this.GrossMarginBest2_Nedit.Size = new System.Drawing.Size(44, 24);
            this.GrossMarginBest2_Nedit.TabIndex = 51;
            // 
            // GrossMarginLowMark_tEdit
            // 
            appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GrossMarginLowMark_tEdit.ActiveAppearance = appearance72;
            this.GrossMarginLowMark_tEdit.AutoSelect = true;
            this.GrossMarginLowMark_tEdit.DataText = "";
            this.GrossMarginLowMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginLowMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GrossMarginLowMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.GrossMarginLowMark_tEdit.Location = new System.Drawing.Point(413, 90);
            this.GrossMarginLowMark_tEdit.MaxLength = 2;
            this.GrossMarginLowMark_tEdit.Name = "GrossMarginLowMark_tEdit";
            this.GrossMarginLowMark_tEdit.Size = new System.Drawing.Size(51, 24);
            this.GrossMarginLowMark_tEdit.TabIndex = 41;
            this.GrossMarginLowMark_tEdit.UseWaitCursor = true;
            // 
            // ultraLabel9
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance73;
            this.ultraLabel9.Location = new System.Drawing.Point(217, 90);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(65, 23);
            this.ultraLabel9.TabIndex = 62;
            this.ultraLabel9.Text = "������";
            // 
            // GrossMarginLow2_Nedit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.TextHAlignAsString = "Left";
            this.GrossMarginLow2_Nedit.ActiveAppearance = appearance42;
            appearance43.TextHAlignAsString = "Right";
            this.GrossMarginLow2_Nedit.Appearance = appearance43;
            this.GrossMarginLow2_Nedit.AutoSelect = true;
            this.GrossMarginLow2_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.GrossMarginLow2_Nedit.DataText = "";
            this.GrossMarginLow2_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GrossMarginLow2_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.GrossMarginLow2_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GrossMarginLow2_Nedit.Location = new System.Drawing.Point(150, 90);
            this.GrossMarginLow2_Nedit.MaxLength = 6;
            this.GrossMarginLow2_Nedit.Name = "GrossMarginLow2_Nedit";
            this.GrossMarginLow2_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.GrossMarginLow2_Nedit.ReadOnly = true;
            this.GrossMarginLow2_Nedit.Size = new System.Drawing.Size(43, 24);
            this.GrossMarginLow2_Nedit.TabIndex = 40;
            this.GrossMarginLow2_Nedit.TabStop = false;
            // 
            // ultraLabel2
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance44;
            this.ultraLabel2.Location = new System.Drawing.Point(16, 90);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(123, 23);
            this.ultraLabel2.TabIndex = 60;
            this.ultraLabel2.Text = "�e���`�F�b�N";
            // 
            // SalesEmployeeCdEd_GuideBtn
            // 
            appearance45.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdEd_GuideBtn.Appearance = appearance45;
            this.SalesEmployeeCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdEd_GuideBtn.Location = new System.Drawing.Point(398, 3);
            this.SalesEmployeeCdEd_GuideBtn.Name = "SalesEmployeeCdEd_GuideBtn";
            this.SalesEmployeeCdEd_GuideBtn.Size = new System.Drawing.Size(25, 26);
            this.SalesEmployeeCdEd_GuideBtn.TabIndex = 13;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdEd_GuideBtn, "�]�ƈ��K�C�h");
            this.SalesEmployeeCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // SalesEmployeeCdSt_GuideBtn
            // 
            appearance46.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.SalesEmployeeCdSt_GuideBtn.Appearance = appearance46;
            this.SalesEmployeeCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SalesEmployeeCdSt_GuideBtn.Location = new System.Drawing.Point(240, 3);
            this.SalesEmployeeCdSt_GuideBtn.Name = "SalesEmployeeCdSt_GuideBtn";
            this.SalesEmployeeCdSt_GuideBtn.Size = new System.Drawing.Size(25, 26);
            this.SalesEmployeeCdSt_GuideBtn.TabIndex = 11;
            this.toolTip1.SetToolTip(this.SalesEmployeeCdSt_GuideBtn, "�]�ƈ��K�C�h");
            this.SalesEmployeeCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SalesEmployeeCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance74.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance74;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(398, 32);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 23;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "���Ӑ挟��");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance75.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance75;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(240, 32);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 21;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "���Ӑ挟��");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // tEdit_EmployeeCode_Ed
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_Ed.ActiveAppearance = appearance49;
            this.tEdit_EmployeeCode_Ed.AutoSelect = true;
            this.tEdit_EmployeeCode_Ed.DataText = "";
            this.tEdit_EmployeeCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_EmployeeCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_EmployeeCode_Ed.Location = new System.Drawing.Point(308, 3);
            this.tEdit_EmployeeCode_Ed.MaxLength = 4;
            this.tEdit_EmployeeCode_Ed.Name = "tEdit_EmployeeCode_Ed";
            this.tEdit_EmployeeCode_Ed.Size = new System.Drawing.Size(59, 24);
            this.tEdit_EmployeeCode_Ed.TabIndex = 12;
            // 
            // tEdit_EmployeeCode_St
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_EmployeeCode_St.ActiveAppearance = appearance50;
            this.tEdit_EmployeeCode_St.AutoSelect = true;
            this.tEdit_EmployeeCode_St.DataText = "";
            this.tEdit_EmployeeCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_EmployeeCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_EmployeeCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_EmployeeCode_St.Location = new System.Drawing.Point(150, 3);
            this.tEdit_EmployeeCode_St.MaxLength = 4;
            this.tEdit_EmployeeCode_St.Name = "tEdit_EmployeeCode_St";
            this.tEdit_EmployeeCode_St.Size = new System.Drawing.Size(59, 24);
            this.tEdit_EmployeeCode_St.TabIndex = 10;
            // 
            // ultraLabel25
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance51;
            this.ultraLabel25.Location = new System.Drawing.Point(274, 3);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(20, 24);
            this.ultraLabel25.TabIndex = 56;
            this.ultraLabel25.Text = "�`";
            // 
            // ultraLabel26
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance52;
            this.ultraLabel26.Location = new System.Drawing.Point(15, 3);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(122, 24);
            this.ultraLabel26.TabIndex = 47;
            this.ultraLabel26.Text = "�S����";
            // 
            // tNedit_CustomerCode_Ed
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance53.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.ActiveAppearance = appearance53;
            appearance54.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_Ed.Appearance = appearance54;
            this.tNedit_CustomerCode_Ed.AutoSelect = true;
            this.tNedit_CustomerCode_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_Ed.DataText = "";
            this.tNedit_CustomerCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_Ed.Location = new System.Drawing.Point(308, 32);
            this.tNedit_CustomerCode_Ed.MaxLength = 9;
            this.tNedit_CustomerCode_Ed.Name = "tNedit_CustomerCode_Ed";
            this.tNedit_CustomerCode_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode_Ed.TabIndex = 22;
            // 
            // ultraLabel11
            // 
            appearance55.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance55;
            this.ultraLabel11.Location = new System.Drawing.Point(277, 32);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 19;
            this.ultraLabel11.Text = "�`";
            // 
            // tNedit_CustomerCode_St
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.ActiveAppearance = appearance56;
            appearance57.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode_St.Appearance = appearance57;
            this.tNedit_CustomerCode_St.AutoSelect = true;
            this.tNedit_CustomerCode_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode_St.DataText = "";
            this.tNedit_CustomerCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode_St.Location = new System.Drawing.Point(150, 32);
            this.tNedit_CustomerCode_St.MaxLength = 9;
            this.tNedit_CustomerCode_St.Name = "tNedit_CustomerCode_St";
            this.tNedit_CustomerCode_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode_St.TabIndex = 20;
            // 
            // ultraLabel3
            // 
            appearance58.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance58;
            this.ultraLabel3.Location = new System.Drawing.Point(15, 32);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 17;
            this.ultraLabel3.Text = "���Ӑ�";
            // 
            // DCHNB02010UA_Fill_Panel
            // 
            this.DCHNB02010UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.DCHNB02010UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DCHNB02010UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.DCHNB02010UA_Fill_Panel.Name = "DCHNB02010UA_Fill_Panel";
            this.DCHNB02010UA_Fill_Panel.Size = new System.Drawing.Size(733, 617);
            this.DCHNB02010UA_Fill_Panel.TabIndex = 0;
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
            appearance59.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance59.FontData.Name = "�l�r �S�V�b�N";
            appearance59.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance59;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance60;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 129;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "�@�o�͏���";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "PrintOderGroup";
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance61;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 33;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "�@�\�[�g��";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance62;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 217;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "�@���o����";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance63.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance63.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance63;
            appearance64.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance64;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(3, 3);
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
            appearance65.FontData.SizeInPoints = 20F;
            appearance65.TextHAlignAsString = "Center";
            appearance65.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance65;
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
            // DCHNB02010UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(733, 617);
            this.Controls.Add(this.DCHNB02010UA_Fill_Panel);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DCHNB02010UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DCHNB02010UA_Load);
            this.Activated += new System.EventHandler(this.DCHNB02010UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_PrintDailyFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraOptionSet_CostOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_NewPageType)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tComboEditor_PublicationType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckUpper_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckBest_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrsProfitCheckLower_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginMaxMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginUprMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginUpper2_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginBestMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginBest2_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginLowMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginLow2_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode_St)).EndInit();
            this.DCHNB02010UA_Fill_Panel.ResumeLayout(false);
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

		//private bool _baseOption                     = false;
        
		private bool _printButtonEnabled             = true;
		private bool _extraButtonEnabled             = false;
		private bool _pdfButtonEnabled               = true;
		private bool _printButtonVisibled            = true;
		private bool _extraButtonVisibled            = false;
		private bool _pdfButtonVisibled = true;
        private bool _visibledSelectAddUpCd = false;	// �v�㋒�_�I��\���擾

        private int  _selectedAddUpCd;

		private bool _chartButtonVisibled = false;
		private bool _chartButtonEnabled = false;

        private string _SalesConfDataTable;

		private Employee _loginWorker                = null;
		// �����_�R�[�h
		private string _ownSectionCode               = "";
		// �����ݒ苒�_�R�[�h
		//private string _balanceSectionCode           = "";

        private ExtrInfo_DCHNB02013E _chartSaleconfListCndtn = null;

        // ���_�A�N�Z�X�N���X
        private static SecInfoAcs _secInfoAcs;

        // �K�C�h�n�A�N�Z�X�N���X
        EmployeeAcs    _employeeAcs;
        LGoodsGanreAcs _lGoodsGanreAcs;
        MGoodsGanreAcs _mGoodsGanreAcs;

		private SaleConfAcs _saleConfListAcs = null;  // �󒍑ݏo�m�F�\�A�N�Z�X�N���X

		//����S�̐ݒ�}�X�^���o����
		private SalesTtlSt _salesTtlSt;
		//����S�̐ݒ�}�X�^�A�N�Z�X�N���X
		private SalesTtlStAcs _salesTtlStAcs;

        //���t�擾���i
		DateGetAcs _dateGetAcs;
		
		private Hashtable _selectedhSectinTable = new Hashtable();
        private bool _isOptSection;	// ���_�I�v�V�����L��
        private bool _isMainOfficeFunc;	// �{�Ћ@�\�L��

		// �G�N�X�v���[���o�[�g������ 
		private Form _topForm = null;
        // 2008.07.24 30413 ���� ���g�p�v���p�e�B�̍폜 >>>>>>START
        //private bool _explorerBarExpanding = false;
        // 2008.07.24 30413 ���� ���g�p�v���p�e�B�̍폜 <<<<<<END
        

		// ���i�`���[�g���o�N���X�����o
		private List<IChartExtract> _iChartExtractList;

        private ExtrInfo_DCHNB02013E _saleConfListCndtnWork = new ExtrInfo_DCHNB02013E();		//�����N���X(�O������ێ��p)
        private ExtrInfo_DCHNB02013E _chartSaleConfListCndtn = new ExtrInfo_DCHNB02013E();		//�����N���X(�`���[�g���n���p)
        private DataSet _printBuffDataSet = null;

		//�N�����[���[�h������ϐ�
		private int _selPrintMode;

		// ���[����
		private string _printName = "";
		// ���[�L�[
		private string _printKey = "";

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// <summary>�����E�e���o�̓��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _uos_CostOutRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _uos_PrindDailyFooterRadioKeyPressHelper = new OptionSetKeyPressEventHelper();

        /// <summary>
        /// �����E�e���o�̓��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>�����E�e���o�̓��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper Uos_CostOutRadioKeyPressHelper
        {
            get { return _uos_CostOutRadioKeyPressHelper; }
        }

        /// <summary>
        /// ���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper Uos_PrindDailyFooterRadioKeyPressHelper
        {
            get { return _uos_PrindDailyFooterRadioKeyPressHelper; }
        }
        // --- ADD 2009/03/30 --------------------------------<<<<<

		#endregion
        
		// ===================================================================================== //
		// �v���C�x�[�g�萔
		// ===================================================================================== //
		#region private constant
        private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";

		// �N���XID
		private const string CT_CLASSID								 = "DCHNB02010UA";
		// �v���O����ID
		private const string THIS_ASSEMBLYID                         = "DCHNB02010U";	
		// �L�[���
		private const string PRINT_KEY01							 = "e1dc02c5-b6c1-4764-b121-d152c2737fe3";
		private const string PRINT_KEY02							 = "c0b28f80-d5ec-4131-ae0d-cf12cfe7cc44";

		private const string PRINT_NAME_01							 = "�󒍊m�F�\";
        // 2008.07.24 30413 ���� �o�ׁ��ݏo�ɕύX >>>>>>START
        //private const string PRINT_NAME_02							 = "�o�׊m�F�\";
        private const string PRINT_NAME_02 = "�ݏo�m�F�\";
        // 2008.07.24 30413 ���� �o�ׁ��ݏo�ɕύX <<<<<<END
		
		//���t����
		private const string CTDATENAMEPATERN01 = "�󒍓�";
        // 2008.07.24 30413 ���� �o�ׁ��ݏo�ɕύX >>>>>>START
        //private const string CTDATENAMEPATERN02 = "�o�ד��t";
        private const string CTDATENAMEPATERN02 = "�ݏo��";
        // 2008.07.24 30413 ���� �o�ׁ��ݏo�ɕύX <<<<<<END

        // 2008.07.24 30413 ���� ���s�^�C�v�̒ǉ� >>>>>>START
        private const string PUBLICATION_TYPE0 = "��";
        private const string PUBLICATION_TYPE1 = "�󒍌v���";
        private const string PUBLICATION_TYPE2 = "�ݏo";
        private const string PUBLICATION_TYPE3 = "�ݏo�v���";
        // 2008.07.24 30413 ���� ���s�^�C�v�̒ǉ� <<<<<<END
        
            
		//�o�͏�
        // 2008.07.24 30413 ���� �\�[�g���̕ύX >>>>>>START
        //private const string CHANGEPAGEDIV1_01 = "�󒍓��{�`�[�ԍ��{�s�ԍ�";
        //private const string CHANGEPAGEDIV1_02 = "�o�ד��{�`�[�ԍ��{�s�ԍ�";
        private const string CHANGEPAGEDIV1_01 = "�󒍓��{�`�[�ԍ�";
        private const string CHANGEPAGEDIV1_02 = "�ݏo���{�`�[�ԍ�";
        // 2008.07.24 30413 ���� �\�[�g���̕ύX <<<<<<END
        private const string CHANGEPAGEDIV2 = "�`�[�ԍ�";
		private const string CHANGEPAGEDIV3 = "���Ӑ�{�`�[�ԍ�";
		private const string CHANGEPAGEDIV4 = "�S���ҁ{�`�[�ԍ�";

		
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
        {
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
		/// </remarks>
		public void Show(object parameter)
		{
			this._selPrintMode = 0;

			//�N�����[�h���擾���܂��i20�F�󒍕\�A40:�ݏo�\�j
			this._selPrintMode = Int32.Parse(parameter.ToString());

			switch (this._selPrintMode)
			{
				case 20:
					{
						this._printName = PRINT_NAME_01;
						this._printKey = PRINT_KEY01;
						this.ultraLabel8.Text = CTDATENAMEPATERN01;

						break;
					}
				case 40:
					{
						this._printName = PRINT_NAME_02;
						this._printKey = PRINT_KEY02;
						this.ultraLabel8.Text = CTDATENAMEPATERN02;

						break;
					}
			}

            this.Show();
			
        }
		
		/// <summary>
		/// �������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����������s���܂��B</br>
		/// </remarks>
		public int Print(ref object parameter)
		{
		            
			SFCMN06001U printDialog = new SFCMN06001U();            // ���[�I���K�C�h
			SFCMN06002C printInfo   = parameter as SFCMN06002C;     // ������p�����[�^
		
			// ��ƃR�[�h
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;     
			printInfo.kidopgid       = THIS_ASSEMBLYID;             // �N���o�f�h�c
			printInfo.key			 = this._printKey;              // PDF�����Ǘ��pKEY���

			//�N�����[�h�ʂɐݒ�R�[�h���Z�b�g
			switch (this._selPrintMode)
			{
				//�󒍊m�F�\
				case 20:
					{
						printInfo.PrintPaperSetCd = 20;
						break;
					}
				//�ݏo�m�F�\
				case 40:
					{
						printInfo.PrintPaperSetCd = 40;
						break;
					}

			}

			// ��ʁ����o�����N���X
            ExtrInfo_DCHNB02013E saleConfListCndtnWork = new ExtrInfo_DCHNB02013E();
			int status = this.SetExtraInfoFromScreen(ref saleConfListCndtnWork);
			if (status != 0)
			{
				return -1;
			}
			// ���o�����̐ݒ�
            printInfo.jyoken = saleConfListCndtnWork;

			// //������[�ݒ�
			//if(saleConfListCndtnWork.IsDetails == false)
			//{
			//    printInfo.PrintPaperSetCd = 1;
			//}
			//else
			//{
			//    printInfo.PrintPaperSetCd = 0;
			//}

#if false
            // ----------
            // ���o����ʃC���X�^���X�쐬
            Broadleaf.Windows.Forms.SFCMN00299CA pd = new Broadleaf.Windows.Forms.SFCMN00299CA();
            pd.Title = "���o��";
            pd.Message = "���݁A�f�[�^���o���ł��B";

            status = 0;

            try
            {
                pd.Show();
                status = this.SearchData(saleConfListCndtnWork);
            }
            finally
            {
                pd.Close();
                printInfo.status = status;
            }
            // ----------

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                this._printBuffDataSet = null;
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

                return status;
            }

            this._saleConfListCndtnWork = saleConfListCndtnWork;

			printInfo.rdData = this._printBuffDataSet;
#endif
			this._saleConfListCndtnWork = saleConfListCndtnWork;

			printDialog.PrintInfo = printInfo;
		        
			// ���[�I���K�C�h�i�o�͐ݒ�_�C�A���O�j
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
		/// <br>����O�̃`�F�b�N�������s���܂��B</br>
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
		///  ���o�������s���܂��B
		/// </remarks>
		public int Extract(ref object parameter)
		{
            //int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //return status;

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;

            ExtrInfo_DCHNB02013E extraInfo = new ExtrInfo_DCHNB02013E();     // ���o�����N���X

            this.SetExtraInfoFromScreen(ref extraInfo);

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
		/// Dispose
		/// </summary>
		public bool CheckBefore()
        {
            // TODO �`���[�g�f�[�^�̒��o�`�F�b�N���s���܂��B
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
                if (this._iChartExtractList == null)
                {
                    this._iChartExtractList = new List<IChartExtract>();
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
          System.Windows.Forms.Application.Run(new DCHNB02010UA());
        }
        #endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private methods 
        /// <summary>
        /// ������ʐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������ʐݒ���s���܂��B</br>
        /// </remarks>
        private void InitialScreenSetting()
        {
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);
            // ���t�͈�
            // �󒍓��E�ݏo��
            this.SalesDateStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            this.SalesDateEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
			//this.SalesDateStRF_tDateEdit.SetLongDate(nowLongDate);
			//this.SalesDateEdRF_tDateEdit.SetLongDate(nowLongDate);
            // 2008.07.24 30413 ���� �󒍁E�ݏo���ɃV�X�e�����t��ݒ� >>>>>>START
            this.SalesDateStRF_tDateEdit.SetLongDate(nowLongDate);
            this.SalesDateEdRF_tDateEdit.SetLongDate(nowLongDate);
            // 2008.07.24 30413 ���� �󒍁E�ݏo���ɃV�X�e�����t��ݒ� <<<<<<END

			// ���͓��t
			this.InputDayStRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
			this.InputDayEdRF_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            // 2008.07.24 30413 ���� ���͓��͖��ݒ�ɕύX >>>>>>START
            //this.InputDayStRF_tDateEdit.SetLongDate(nowLongDate);
            //this.InputDayEdRF_tDateEdit.SetLongDate(nowLongDate);
            // 2008.07.24 30413 ���� ���͓��͖��ݒ�ɕύX <<<<<<END

            // 2008.07.24 30413 ���� ���s�^�C�v�̏����l�ݒ� >>>>>>START
            // ���s�^�C�v
            this.tComboEditor_PublicationType.SelectedIndex = 0;
            // 2008.07.24 30413 ���� ���s�^�C�v�̏����l�ݒ� <<<<<<END

            // 2008.07.24 30413 ���� ���ł̏����l�ݒ� >>>>>>START
            // ����
            this.tComboEditor_NewPageType.Value = 0;
            // 2008.07.24 30413 ���� ���ł̏����l�ݒ� <<<<<<END
            

			this.PrintOder_tComboEditor.Value = 0;

            
            // �K�C�h�{�^���C���[�W�ݒ�
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
                     
            SalesEmployeeCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            SalesEmployeeCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
            SalesEmployeeCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
        }


        /// <summary>
        /// ���_�I���R���|�{�b�N�X�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�����R���|�{�b�N�X�ɐݒ肵�܂��B</br>
        /// </remarks>
        private void SettingSectionCombList()
        {
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
			Enum _checkD = this._dateGetAcs.CheckDate(ref control);

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
		/// ���t�͈̓`�F�b�N����
		/// </summary>
		/// <param name="startDate">�`�F�b�N�ΏۃR���g���[��</param>
		/// <param name="endDate">�`�F�b�N�ΏۃR���g���[��</param>
		/// <returns>true:�`�F�b�NOK,false:�`�F�b�NNG</returns>
		/// <remarks>
		/// <br>Note: ���ʕ��i�ɂ����t�͈͂̃`�F�b�N���s���܂��B</br>
		/// </remarks>
		private bool CheckPeriod(DateTime startDate, DateTime endDate, int s)
		{
			Enum _checkP = this._dateGetAcs.CheckPeriod(DateGetAcs.YmdType.YearMonth, 1, DateGetAcs.YmdType.YearMonthDay, startDate, endDate);

			string str_cP = _checkP.ToString();

			bool r = false;

			switch (s)
			{
				case 1:
					if (str_cP == "ErrorOfReverse" || str_cP == "ErrorOfRangeOver")
					{
						r = false;
					}
					else
					{
						r = true;
					}
					break;

				case 240:
					//�󒍁E�ݏo���t�͔͈͖���
					if (str_cP == "ErrorOfReverse" )
					{
						r = false;
					}
					else
					{
						r = true;
					}
					break;
			}

			return r;
		}

        /// <summary>
        /// ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// </remarks>
        private bool ScreenInputCheack(out string message, ref Control errControl)
        {
            message = "";
            bool result = false;
            errControl = null;

            // 2008.07.24 30413 ���� �󒍁E�ݏo���Ɠ��͓��̃`�F�b�N��ύX >>>>>>START
            DateGetAcs.CheckDateRangeResult cdrResult;

            // �󒍁E�ݏo���i�J�n�E�I���j�̃`�F�b�N
            // --- DEL 2009/04/06 -------------------------------->>>>>
            //if ((this.SalesDateStRF_tDateEdit.LongDate != 0) ||
            //    (this.SalesDateEdRF_tDateEdit.LongDate != 0))
            //{
            // --- DEL 2009/04/06 --------------------------------<<<<<
            if (CallCheckDateRange_SalesDays(out cdrResult, ref SalesDateStRF_tDateEdit, ref SalesDateEdRF_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            //message = "�J�n������͂��ĉ�����"; // DEL 2009/04/06
                            //errControl = this.SalesDateStRF_tDateEdit; // DEL 2009/04/06
                            result = true; // ADD 2009/04/06
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = "�J�n���̓��͂��s���ł�";
                            errControl = this.SalesDateStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            //message = "�I��������͂��ĉ�����"; // DEL 2009/04/06
                            //errControl = this.SalesDateEdRF_tDateEdit; // DEL 2009/04/06
                            result = true; // ADD 2009/04/06
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = "�I�����̓��͂��s���ł�";
                            errControl = this.SalesDateEdRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = "���t�͈͎̔w��Ɍ�肪����܂�";
                            errControl = this.SalesDateStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            //message = "���t�͂R�����͈̔͂œ��͂��ĉ�����"; // DEL 2009/04/06
                            //errControl = this.SalesDateStRF_tDateEdit; // DEL 2009/04/06
                            result = true; // ADD 2009/04/06
                        }
                        break;

                }
                //return result; // DEL 2009/04/07
            }
            // --- ADD 2009/04/07 -------------------------------->>>>>
            else
            {
                result = true;
            }

            if (!result)
            {
                // �󒍁E�ݏo���`�F�b�N�G���[
                return result;
            }
            else
            {
                // �󒍁E�ݏo���`�F�b�NOK
                result = false;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<
            // --- DEL 2009/04/06 -------------------------------->>>>>
            //}
            //// 2008.09.18 30413 ���� ������ɕK�{�`�F�b�N��ǉ� >>>>>>START
            //else
            //{
            //    // �J�n���ƏI�����̗���������
            //    message = "�J�n���ƏI��������͂��ĉ�����";
            //    errControl = this.SalesDateStRF_tDateEdit;
            //    return result;
            //}
            // --- DEL 2009/04/06 --------------------------------<<<<<
            // 2008.09.18 30413 ���� ������ɕK�{�`�F�b�N��ǉ� <<<<<<END

            // 2009.01.06 30413 ���� ���͓��`�F�b�N���C�� >>>>>>START
            // ���͓��i�J�n�E�I���j
            //if ((this.InputDayStRF_tDateEdit.LongDate != 0) ||
            //    (this.InputDayEdRF_tDateEdit.LongDate != 0))
            //{

            if (CallCheckDateRange_InputDays(out cdrResult, ref InputDayStRF_tDateEdit, ref InputDayEdRF_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            //message = "�J�n������͂��ĉ�����";
                            //errControl = this.InputDayStRF_tDateEdit;
                            result = true;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = "�J�n���̓��͂��s���ł�";
                            errControl = this.InputDayStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            //message = "�I��������͂��ĉ�����";
                            //errControl = this.InputDayEdRF_tDateEdit;
                            result = true;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = "�I�����̓��͂��s���ł�";
                            errControl = this.InputDayEdRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = "���t�͈͎̔w��Ɍ�肪����܂�";
                            errControl = this.InputDayStRF_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            //message = "���t�͂R�����͈̔͂œ��͂��ĉ�����";
                            //errControl = this.InputDayStRF_tDateEdit;
                            result = true;
                        }
                        break;
                }
                return result;
            }

        //}
            else
            {
                result = true;
            }

            if (!result)
            {
                // ���͓��`�F�b�N�G���[
                return result;
            }
            else
            {
                // ���͓��`�F�b�NOK
                result = false;
            }
            // 2009.01.06 30413 ���� ���͓��`�F�b�N���C�� <<<<<<END            
            // 2008.07.24 30413 ���� �󒍁E�ݏo���Ɠ��͓��̃`�F�b�N��ύX <<<<<<END

            // 2008.07.24 30413 ���� �����̓��͓��Ǝ󒍁E�ݏo���̃`�F�b�N���폜 >>>>>>START
            //// ���͓��t(�I��)
            //if (!CheckDate(this.InputDayEdRF_tDateEdit))
            //{
            //    message = "���͓��t�̎w��Ɍ�肪����܂�";
            //    errControl = this.InputDayEdRF_tDateEdit;
            //    return result;
            //}

            //DateTime _dtInputDaySt = DateTime.ParseExact(this.InputDayStRF_tDateEdit.GetLongDate().ToString(), "yyyyMMdd", null);
            //DateTime _dtInputDayEd = DateTime.ParseExact(this.InputDayEdRF_tDateEdit.GetLongDate().ToString(), "yyyyMMdd", null);

            //// ���͓��t�͈̓`�F�b�N
            //if (!CheckPeriod(_dtInputDaySt, _dtInputDayEd, 1))
            //{
            //    message = "���͓��t��1�����͈͓̔��œ��͂��Ă�������";
            //    errControl = this.InputDayStRF_tDateEdit;
            //    return result;
            //}

            //// �󒍓��i�o�ד��j�͉������͂���Ă�����`�F�b�N
            //if (this.SalesDateStRF_tDateEdit.GetLongDate() != 0 || this.SalesDateEdRF_tDateEdit.GetLongDate() != 0)
            //{
            //    // �󒍓��i�o�ד��j(�J�n)
            //    if (!CheckDate(this.SalesDateStRF_tDateEdit))
            //    {
            //        switch (this._selPrintMode)
            //        {
            //            case 20:
            //                {
            //                    message = "�󒍓��t�̎w��Ɍ�肪����܂�";
            //                    break;
            //                }
            //            case 40:
            //                {
            //                    message = "�o�ד��t�̎w��Ɍ�肪����܂�";
            //                    break;
            //                }
            //        }
            //        errControl = this.SalesDateStRF_tDateEdit;
            //        return result;

            //    }

            //    // �󒍓��i�o�ד��j(�I��)
            //    if (!CheckDate(this.SalesDateEdRF_tDateEdit))
            //    {
            //        switch (this._selPrintMode)
            //        {
            //            case 20:
            //                {
            //                    message = "�󒍓��t�̎w��Ɍ�肪����܂�";
            //                    break;
            //                }
            //            case 40:
            //                {
            //                    message = "�o�ד��t�̎w��Ɍ�肪����܂�";
            //                    break;
            //                }
            //        }
            //        errControl = this.SalesDateEdRF_tDateEdit;
            //        return result;
            //    }

            //    DateTime _dtSalesDateSt = DateTime.ParseExact(this.SalesDateStRF_tDateEdit.GetLongDate().ToString(), "yyyyMMdd", null);
            //    DateTime _dtSalesDateEd = DateTime.ParseExact(this.SalesDateEdRF_tDateEdit.GetLongDate().ToString(), "yyyyMMdd", null);

            //    // �󒍓��i�o�ד��j�͈̓`�F�b�N
            //    if (!CheckPeriod(_dtSalesDateSt, _dtSalesDateEd, 240))
            //    {
            //        switch (this._selPrintMode)
            //        {
            //            case 20:
            //                {
            //                    message = "�󒍓��t�͈̔͂Ɍ�肪����܂�";
            //                    break;
            //                }
            //            case 40:
            //                {
            //                    message = "�o�ד��t�͈̔͂Ɍ�肪����܂�";
            //                    break;
            //                }
            //        }
            //        errControl = this.SalesDateStRF_tDateEdit;
            //        return result;
            //    }
            //}
            //    // ���͓��t(�J�n)
            //    if (!CheckDate(this.InputDayStRF_tDateEdit))
            //    {
            //        message = "���͓��t�̎w��Ɍ�肪����܂�";
            //        errControl = this.InputDayStRF_tDateEdit;
            //        return result;
            //    }
            // 2008.07.24 30413 ���� �����̓��͓��Ǝ󒍁E�ݏo���̃`�F�b�N���폜 <<<<<<END

            // 2008.07.24 30413 ���� �S���҂̃`�F�b�N���ʂ�ύX >>>>>>START
            // �S���҃R�[�h�͈̓`�F�b�N
            if ((this.tEdit_EmployeeCode_Ed.Text != "") &&
                (this.tEdit_EmployeeCode_St.Text.CompareTo(this.tEdit_EmployeeCode_Ed.Text) > 0))
            {
                message = "�S���҂͈̔͂Ɍ�肪����܂�";
                errControl = this.tEdit_EmployeeCode_St;
                return result;
            }
            // 2008.07.24 30413 ���� �S���҂̃`�F�b�N���ʂ�ύX <<<<<<END

            // ���Ӑ�R�[�h�͈̓`�F�b�N
            if ((this.tNedit_CustomerCode_Ed.GetInt() != 0) &&
                (this.tNedit_CustomerCode_St.GetInt()) > (this.tNedit_CustomerCode_Ed.GetInt()))
            {
                // 2008.07.24 30413 ���� �G���[���b�Z�[�W��ύX >>>>>>START
                //message = "���Ӑ�R�[�h�͈̔͂Ɍ�肪����܂�";
                message = "���Ӑ�͈̔͂Ɍ�肪����܂�";
                // 2008.07.24 30413 ���� �G���[���b�Z�[�W��ύX <<<<<<END
                errControl = this.tNedit_CustomerCode_Ed;
                return result;
            }

            #region �e���͈̓`�F�b�N
            // �e���`�F�b�N�̓��͔͈� �󔒂��ƃG���[�\��
            if (this.GrsProfitCheckLower_tNedit.Text == "")
            {
                message = "�e��������͂��Ă�������";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            //if (this.GrsProfitCheckBest_tNedit.Text == "") // DEL 2008/11/18
            if ((this.GrsProfitCheckBest_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckBest_tNedit.Text) == 0.0)) // ADD 2008/11/18
            {
                message = "�e��������͂��Ă�������";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }

            //if (this.GrsProfitCheckUpper_tNedit.Text == "")  // DEL 2008/11/18
            if ((this.GrsProfitCheckUpper_tNedit.Text == "") || (double.Parse(this.GrsProfitCheckUpper_tNedit.Text) == 0.0)) // ADD 2008/11/18
            {
                message = "�e��������͂��Ă�������";
                errControl = this.GrsProfitCheckUpper_tNedit;
                return result;
            }


            // �K���l��艺�����傫���ƃG���[�\��
            //if ((double.Parse(this.GrsProfitCheckBest_tNedit.Text) != 0.0) &&
            //    (double.Parse(this.GrsProfitCheckLower_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckBest_tNedit.Text)) > 0.0)) // DEL 2008/11/17
            if ((double.Parse(this.GrsProfitCheckBest_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckLower_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckBest_tNedit.Text)) >= 0.0)) // ADD 2008/11/17
            {
                message = "�e���`�F�b�N�͈̔͂Ɍ�肪����܂�";
                errControl = this.GrsProfitCheckLower_tNedit;
                return result;
            }

            // ������K���l���傫���ƃG���[�\��
            //if ((double.Parse(this.GrsProfitCheckUpper_tNedit.Text) != 0.0) &&
            //    (double.Parse(this.GrsProfitCheckBest_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckUpper_tNedit.Text)) > 0.0)) // DEL 2008/11/17
            if ((double.Parse(this.GrsProfitCheckUpper_tNedit.Text) != 0.0) &&
                (double.Parse(this.GrsProfitCheckBest_tNedit.Text).CompareTo(double.Parse(this.GrsProfitCheckUpper_tNedit.Text)) >= 0.0)) // ADD 2008/11/17
            {
                message = "�e���`�F�b�N�͈̔͂Ɍ�肪����܂�";
                errControl = this.GrsProfitCheckBest_tNedit;
                return result;
            }

            #endregion

            // 2008.07.24 30413 ���� �S���҂̃`�F�b�N���ʂ�ύX >>>>>>START
            //// �S���҃R�[�h�͈̓`�F�b�N
            //if ((this.SalesEmployeeCdEd_tEdit.Text != "") &&
            //    (this.SalesEmployeeCdSt_tEdit.Text.CompareTo(this.SalesEmployeeCdEd_tEdit.Text) > 0))
            //{
            //    message = "�S���҃R�[�h�͈̔͂Ɍ�肪����܂�";
            //    errControl = this.SalesEmployeeCdSt_tEdit;
            //    return result;
            //}
            // 2008.07.24 30413 ���� �S���҂̃`�F�b�N���ʂ�ύX <<<<<<END

            return true;

        }

        /// <summary>
        /// ���t�͈̓`�F�b�N�Ăяo��(�󒍁E�ݏo��)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange_SalesDays(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            // --- DEL 2009/04/06 -------------------------------->>>>>
            //// 2008.08.01 30413 ���� �͈͂��R�P���ɕύX >>>>>>START
            ////cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, false, false);
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref startDate, ref endDate, false, false);
            //// 2008.08.01 30413 ���� �͈͂��R�P���ɕύX <<<<<<END
            // --- DEL 2009/04/06 --------------------------------<<<<<
            // --- ADD 2009/04/06 -------------------------------->>>>>
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, true);
            // --- ADD 2009/04/06 --------------------------------<<<<<

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���t�͈̓`�F�b�N�Ăяo��(���͓�)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange_InputDays(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            // 2009.01.06 30413 ���� ���t�`�F�b�N���C�� >>>>>>START
            // 2008.08.01 30413 ���� �͈̓`�F�b�N�����ɕύX >>>>>>START
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref startDate, ref endDate, false, false);
            //cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, false, false);
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref startDate, ref endDate, true);
            // 2008.08.01 30413 ���� �͈̓`�F�b�N�����ɕύX <<<<<<END
            // 2009.01.06 30413 ���� ���t�`�F�b�N���C�� <<<<<<END
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
		/// SearchData
		/// </summary>
		/// <param name="extraInfo"></param>
		/// <returns></returns>
        private int SearchData(ExtrInfo_DCHNB02013E extraInfo)
        {
            string message;
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ���o�������ς���Ă���Ȃ烊���[�e�B���O
            if (this._printBuffDataSet == null || this._saleConfListCndtnWork == null || !this._saleConfListCndtnWork.Equals(extraInfo))
            {
                try
				{	//�`�[/���׌`������֘A
					status = this._saleConfListAcs.Search(extraInfo, out message, 0);
					if (status == 0)
					{
						this._printBuffDataSet = this._saleConfListAcs._printDataSet;
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
                            //this._printBuffDataSet = new DataSet();
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
                if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count == 0)
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                else
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }

            return status;


        }
            
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <remarks>
        ///  ��ʁ����o�����֐ݒ肵�܂��B
        /// </remarks>
        public int SetExtraInfoFromScreen(ref ExtrInfo_DCHNB02013E extraInfo)
        {
			int status = 0;
			
			if (extraInfo == null)
            {
                extraInfo = new ExtrInfo_DCHNB02013E();
            }

            try
            {
                //�N�����[�h�p�����[�^
                extraInfo.AcptAnOdrStatus = this._selPrintMode;

                // ��ƃR�[�h
                extraInfo.EnterpriseCode = this._enterpriseCode;
                // �I�����_
                // ���_�I�v�V��������̂Ƃ�
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // �S�БI�����ǂ���
                    if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
                    {
                        extraInfo.ResultsAddUpSecList = new string[1];
                        extraInfo.ResultsAddUpSecList[0] = "0";
                    }
                    else
                    {
                        foreach (DictionaryEntry dicEntry in this._selectedhSectinTable)
                        {
                            if ((CheckState)dicEntry.Value == CheckState.Checked)
                            {
                                secList.Add(dicEntry.Key);
                            }
                        }
                        extraInfo.ResultsAddUpSecList = (string[])secList.ToArray(typeof(string));
                    }
                }
                // ���_�I�v�V�����Ȃ��̎�
                else
                {
                    extraInfo.ResultsAddUpSecList = new string[0];
                }

                // �󒍓�or�ݏo����(�J�n) �E(�I��)   
                switch (this._selPrintMode)
                {
                    case 20:	//�󒍓�
                        {
                            extraInfo.SalesDateSt = this.SalesDateStRF_tDateEdit.GetLongDate();
                            extraInfo.SalesDateEd = this.SalesDateEdRF_tDateEdit.GetLongDate();
                            break;
                        }
                    case 40:	//�ݏo��
                        {
                            extraInfo.ShipmentDaySt = this.SalesDateStRF_tDateEdit.GetLongDate();
                            extraInfo.ShipmentDayEd = this.SalesDateEdRF_tDateEdit.GetLongDate();
                            break;
                        }
                }

                // ���͓��t(�J�n)        
                extraInfo.SearchSlipDateSt = this.InputDayStRF_tDateEdit.GetLongDate();
                // ���͓��t(�I��)        
                extraInfo.SearchSlipDateEd = this.InputDayEdRF_tDateEdit.GetLongDate();

                // 2008.07.24 30413 ���� ���s�^�C�v�Ɖ��ł�ǉ� >>>>>>START
                // ���s�^�C�v
                extraInfo.PublicationType = Convert.ToInt32(this.tComboEditor_PublicationType.SelectedItem.DataValue);

                // ����
                extraInfo.NewPageType = Convert.ToInt32(this.tComboEditor_NewPageType.SelectedItem.DataValue);
                // 2008.07.24 30413 ���� ���s�^�C�v�Ɖ��ł�ǉ� <<<<<<END

                // --- ADD 2009/03/30 -------------------------------->>>>>
                // �����E�e���o��
                extraInfo.CostOut = Convert.ToInt32(this.ultraOptionSet_CostOut.CheckedItem.DataValue);

                // ���v��
                extraInfo.PrintDailyFooter = Convert.ToInt32(this.ultraOptionSet_PrintDailyFooter.CheckedItem.DataValue);
                // --- ADD 2009/03/30 --------------------------------<<<<<
                
                //�o�͏�
                extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);

                // ���Ӑ�(�J�n)
                extraInfo.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                // ���Ӑ�(�I��)
                extraInfo.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();

                //�e���`�F�b�N(����)
                extraInfo.GrsProfitCheckLower = Convert.ToDouble(this.GrsProfitCheckLower_tNedit.Text);
                //�e���`�F�b�N(�K��)
                extraInfo.GrsProfitCheckBest = Convert.ToDouble(this.GrsProfitCheckBest_tNedit.Text);
                //�e���`�F�b�N(���)
                extraInfo.GrsProfitCheckUpper = Convert.ToDouble(this.GrsProfitCheckUpper_tNedit.Text);

                //�e���`�F�b�N2
                extraInfo.GrossMarginLow2 = this.GrossMarginLow2_Nedit.GetInt();

                //�e���`�F�b�N3
                extraInfo.GrossMarginBest2 = this.GrossMarginBest2_Nedit.GetInt();

                //�e���`�F�b�N4
                extraInfo.GrossMarginUpper2 = this.GrossMarginUpper2_Nedit.GetInt();

                //�e���`�F�b�N�}�[�N1(����)
                extraInfo.GrossMargin1Mark = this.GrossMarginLowMark_tEdit.Text;
                //�e���`�F�b�N�}�[�N2(����)�`�i�K���j
                extraInfo.GrossMargin2Mark = this.GrossMarginBestMark_tEdit.Text;
                //�e���`�F�b�N�}�[�N3(�K��)�`�i����j
                extraInfo.GrossMargin3Mark = this.GrossMarginUprMark_tEdit.Text;
                //�e���`�F�b�N�}�[�N4(���)
                extraInfo.GrossMargin4Mark = this.GrossMarginMaxMark_tEdit.Text;

                // 2008.10.09 30413 ���� 0�l�ߑΉ� >>>>>>START
                //// �S���R�[�h(�J�n)
                //extraInfo.SalesEmployeeCdSt = this.tEdit_EmployeeCode_St.Text;
                //// �S���R�[�h(�I��)
                //extraInfo.SalesEmployeeCdEd = this.tEdit_EmployeeCode_Ed.Text;
                // �S���R�[�h(�J�n)
                if (this.tEdit_EmployeeCode_St.Text.Trim() == "")
                {
                    extraInfo.SalesEmployeeCdSt = "";
                }
                else
                {
                    extraInfo.SalesEmployeeCdSt = this.tEdit_EmployeeCode_St.Text.Trim().PadLeft(4, '0');
                }
                // �S���R�[�h(�I��)
                if (this.tEdit_EmployeeCode_Ed.Text.Trim() == "")
                {
                    extraInfo.SalesEmployeeCdEd = "";
                }
                else
                {
                    extraInfo.SalesEmployeeCdEd = this.tEdit_EmployeeCode_Ed.Text.Trim().PadLeft(4, '0');
                }
                // 2008.10.09 30413 ���� 0�l�ߑΉ� <<<<<<END
            }
            catch (Exception)
            {
                status = -1;
                TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "���o�����̎擾�Ɏ��s���܂����B", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
            _SalesConfDataTable = Broadleaf.Application.UIData.DCHNB02014EA.CT_OrderConfDataTable;
        }

		/// <summary>
        /// �ŏ�ʃt�H�[���擾
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
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
            // 2008.07.24 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
            //this.AdjustExplorerBarExpand();
            // 2008.07.24 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
        }

        // 2008.07.24 30413 ���� ���g�p���\�b�h�̍폜 >>>>>>START
        #region �G�N�X�v���[���[�o�[�W�J��Ԓ���
        ///// <summary>
        ///// �G�N�X�v���[���[�o�[�W�J��Ԓ���
        ///// </summary>
        //private void AdjustExplorerBarExpand()
        //{
        //    if (this._topForm == null) return;

        //    if (this._topForm.Height > CT_TOPFORM_BASE_HEIGHT)
        //    {
        //        // �g�b�v�t�H�[���̍�������l��荂���ꍇ
        //        this._explorerBarExpanding = true;
        //        try
        //        {
        //            //this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = true;
        //        }
        //        finally
        //        {
        //            this._explorerBarExpanding = false;
        //        }
        //    }
        //    else
        //    {
        //        // �g�b�v�t�H�[���̍�������l���Ⴂ�ꍇ
        //        this._explorerBarExpanding = true;
        //        try
        //        {
        //            //this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = false;
        //        }
        //        finally
        //        {
        //            this._explorerBarExpanding = false;
        //        }
        //    }
        //}
        #endregion
        // 2008.07.24 30413 ���� ���g�p���\�b�h�̍폜 <<<<<<END
            
	    /// <summary>
        /// �G���[���b�Z�[�W�\��
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="iMsg">�G���[���b�Z�[�W</param>
        /// <param name="iSt">�G���[�X�e�[�^�X</param>
        /// <param name="iButton">�\���{�^��</param>
        /// <param name="iDefButton">�����t�H�[�J�X�{�^��</param>
        /// <returns>DialogResult</returns>
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

        /// <summary>
        /// �I�����ڒl�����ݒ菈��(TDateEdit)
        /// </summary>
        /// <param name="startDate">�J�n���t����TDateEdit</param>
        /// <param name="endDate">�I�����t����TDateEdit</param>
        private void AutoSetEndValue(TDateEdit startDate, TDateEdit endDate)
        {
            if (endDate.LongDate == 0)
            {
                endDate.SetLongDate(startDate.LongDate);
            }
        }

        /// <summary>
        /// �I�����ڒl�����ݒ菈��(TEdit)
        /// </summary>
        /// <param name="startEdit">�J�n�����񍀖�TEdit</param>
        /// <param name="endEdit">�I�������񍀖�TEdit</param>
        private void AutoSetEndValue(TEdit startEdit, TEdit endEdit)
        {
            if (endEdit.Text == "")
            {
                endEdit.Text = startEdit.Text;
            }
        }

        /// <summary>
        /// �I�����ڒl�����ݒ菈��(TNedit)
        /// </summary>
        /// <param name="startNedit">�J�n���l����TEdit</param>
        /// <param name="endNedit">�I�����l����TEdit</param>
        private void AutoSetEndValue(TNedit startNedit, TNedit endNedit)
        {
            if ((endNedit.GetInt() == 0) &&
                (startNedit.GetInt() != 0))
            {
                endNedit.SetInt(startNedit.GetInt());
            }
        }

        /// <summary>
        /// �I�����ڒl�����ݒ菈��(TComboEditor)
        /// </summary>
		/// <param name="startComboEditor">�J�n���l����TEdit</param>
		/// <param name="endComboEditor">�I�����l����TEdit</param>
        private void AutoSetEndValue(TComboEditor startComboEditor, TComboEditor endComboEditor)
        {
            endComboEditor.SelectedIndex = startComboEditor.SelectedIndex;
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
        /// </remarks>
        private void DCHNB02010UA_Load(object sender, System.EventArgs e)
        {
            this.SettingDataTable();
            this._saleConfListAcs = new SaleConfAcs();

            // �ŏ�ʃt�H�[���擾
		    this.GetTopForm();

            // ���_�I�v�V�����L�����擾����
            this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // �{��/���_�����擾����
            this._isMainOfficeFunc = this.GetMainOfficeFunc();

			this.Initial_Timer.Enabled = true;

            // 2008.07.24 30413 ���� ���s�^�C�v�̒ǉ� >>>>>>START
            // �R���{�{�b�N�X�ɔ��s�^�C�v��ݒ�
            switch (this._selPrintMode)
            {
                case 20:
                    {	// �󒍊m�F�\
                        this.tComboEditor_PublicationType.Items.Add(ExtrInfo_DCHNB02013E.PublicationTypeState.AcceptAnOrder, PUBLICATION_TYPE0);        // ��
                        this.tComboEditor_PublicationType.Items.Add(ExtrInfo_DCHNB02013E.PublicationTypeState.AcceptAnOrderAddUp, PUBLICATION_TYPE1);   // �󒍌v���
                        break;
                    }
                case 40:
                    {	// �ݏo�m�F�\
                        this.tComboEditor_PublicationType.Items.Add(ExtrInfo_DCHNB02013E.PublicationTypeState.Loan, PUBLICATION_TYPE2);                 // �ݏo
                        this.tComboEditor_PublicationType.Items.Add(ExtrInfo_DCHNB02013E.PublicationTypeState.LoanAddUp, PUBLICATION_TYPE3);            // �ݏo�v���
                        break;
                    }
            }
            // 2008.07.24 30413 ���� ���s�^�C�v�̒ǉ� <<<<<<END
            
			//�R���{�{�b�N�X�Ƀ\�[�g����ݒ�
			switch (this._selPrintMode)
			{
				case 20:	
					{	//�󒍓��{�`�[�ԍ��{�s�ԍ�
						Infragistics.Win.ValueListItem listItem0_1 = new Infragistics.Win.ValueListItem();
						listItem0_1.DataValue = 0;
						listItem0_1.DisplayText = CHANGEPAGEDIV1_01;
						this.PrintOder_tComboEditor.Items.Add(listItem0_1);
						break;
					}
				case 40:	
					{	//�ݏo���{�`�[�ԍ��{�s�ԍ�
						Infragistics.Win.ValueListItem listItem0_2 = new Infragistics.Win.ValueListItem();
						listItem0_2.DataValue = 0;
						listItem0_2.DisplayText = CHANGEPAGEDIV1_02;
						this.PrintOder_tComboEditor.Items.Add(listItem0_2);
						break;
					}
			}
			//�`�[�ԍ�
			Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
			listItem1.DataValue = 1;
			listItem1.DisplayText = CHANGEPAGEDIV2;
			//���Ӑ�{�`�[�ԍ�
			Infragistics.Win.ValueListItem listItem2 = new Infragistics.Win.ValueListItem();
			listItem2.DataValue = 2;
			listItem2.DisplayText = CHANGEPAGEDIV3;
			//�S���ҁ{�`�[�ԍ�
			Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
			listItem3.DataValue = 3;
			listItem3.DisplayText = CHANGEPAGEDIV4;

			this.PrintOder_tComboEditor.Items.Add(listItem1);
			this.PrintOder_tComboEditor.Items.Add(listItem2);
			this.PrintOder_tComboEditor.Items.Add(listItem3);

			//TODO ����S�̐ݒ�}�X�^����e�����ƃ}�[�N���擾�A���͗��ɕ\��
			this._salesTtlStAcs = new SalesTtlStAcs();
			this._salesTtlSt = new SalesTtlSt();

            // 2008.07.24 30413 ���� ���_�R�[�h"0"�̃��R�[�h���擾 >>>>>>START
            //this._salesTtlStAcs.Read(out this._salesTtlSt, LoginInfoAcquisition.EnterpriseCode); //EnterpriseCode���}�X�^���ĂԂƂ���Key�ɂȂ��Ă���B
            int status = 0;
            ArrayList retList = null;

            status = this._salesTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (status == 0)
            {
                // --- DEL 2008/11/17 -------------------------------->>>>>
                //foreach (SalesTtlSt wkSalesTtlSt in retList)
                //{
                //    if (wkSalesTtlSt.SectionCode.Trim().Equals("00"))
                //    {
                //        this._salesTtlSt = wkSalesTtlSt.Clone();
                //    }
                //}
                // --- DEL 2008/11/17 --------------------------------<<<<<
                // --- ADD 2008/11/17 -------------------------------->>>>>
                bool hitOwnSection = false;

                foreach (SalesTtlSt wkSalesTtlSt in retList)
                {
                    if (wkSalesTtlSt.SectionCode.Trim().Equals(this._ownSectionCode.Trim())
                        && wkSalesTtlSt.LogicalDeleteCode == 0)
                    {
                        this._salesTtlSt = wkSalesTtlSt.Clone();
                        hitOwnSection = true;
                    }
                }

                // �����_�Ō�����Ȃ��ꍇ��00���_�̐ݒ���擾
                if (!hitOwnSection)
                {
                    foreach (SalesTtlSt wkSalesTtlSt in retList)
                    {
                        if (wkSalesTtlSt.SectionCode.Trim().Equals("00"))
                        {
                            this._salesTtlSt = wkSalesTtlSt.Clone();
                        }
                    }
                }
                // --- ADD 2008/11/17 --------------------------------<<<<<
            }
            // 2008.07.24 30413 ���� ���_�R�[�h"0"�̃��R�[�h���擾 <<<<<<END

            // 2008.09.18 30413 ���� �e�����̏����l��s�������Őݒ� >>>>>>START
            //�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�
            //this.GrsProfitCheckLower_tNedit.Text = this._salesTtlSt.GrsProfitCheckLower.ToString();
            //this.GrossMarginLow2_Nedit.Text = this._salesTtlSt.GrsProfitCheckLower.ToString();
            this.GrsProfitCheckLower_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckLower);

			//�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�
            //this.GrsProfitCheckBest_tNedit.Text = this._salesTtlSt.GrsProfitCheckBest.ToString();
            //this.GrossMarginUpper2_Nedit.Text = this._salesTtlSt.GrsProfitCheckBest.ToString();
            this.GrsProfitCheckBest_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckBest);

			//�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�
            //this.GrsProfitCheckUpper_tNedit.Text = this._salesTtlSt.GrsProfitCheckUpper.ToString();
            //this.GrossMarginUpper2_Nedit.Text = this._salesTtlSt.GrsProfitCheckUpper.ToString();
            this.GrsProfitCheckUpper_tNedit.SetValue(this._salesTtlSt.GrsProfitCheckUpper);
            // 2008.09.18 30413 ���� �e�����̏����l��s�������Őݒ� <<<<<<END
            
			//�e���`�F�b�N�̉����l�����̋L��
			this.GrossMarginLowMark_tEdit.Text = this._salesTtlSt.GrsProfitChkLowSign;
			//�e���`�F�b�N�̓K���l���牺���l�܂ł̋L��
			this.GrossMarginBestMark_tEdit.Text = this._salesTtlSt.GrsProfitChkBestSign;
			//�e���`�F�b�N�̏���l����K���l�܂ł̋L��
			this.GrossMarginUprMark_tEdit.Text = this._salesTtlSt.GrsProfitChkUprSign;
			//�e���`�F�b�N�̏���l�I�[�o�[�̋L��
			this.GrossMarginMaxMark_tEdit.Text = this._salesTtlSt.GrsProfitChkMaxSign;

            // --- ADD 2009/03/30 -------------------------------->>>>>
            Uos_CostOutRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_CostOut);
            Uos_CostOutRadioKeyPressHelper.StartSpaceKeyControl();

            Uos_PrindDailyFooterRadioKeyPressHelper.ControlList.Add(this.ultraOptionSet_PrintDailyFooter);
            Uos_PrindDailyFooterRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2009/03/30 --------------------------------<<<<<
        }

        /// <summary>
        /// ��ʃA�N�e�B�u�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note       : �������C����ʂ��A�N�e�B�u�ɂȂ����Ƃ��̃C�x���g�����ł��B</br>
        /// </remarks>
        private void DCHNB02010UA_Activated(object sender, System.EventArgs e)
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
            // 2008.09.24 30413 ���� ���͎x���̍폜 >>>>>>START
            //// ���͎x�� ============================================ //
            //// �����
            //if ((e.PrevCtrl == this.SalesDateStRF_tDateEdit) ||
            //    (e.PrevCtrl == this.SalesDateEdRF_tDateEdit))
            //{
            //    AutoSetEndValue(this.SalesDateStRF_tDateEdit, this.SalesDateEdRF_tDateEdit);
            //}

            //// ���ד�
            //if ((e.PrevCtrl == this.InputDayStRF_tDateEdit) ||
            //    (e.PrevCtrl == this.InputDayEdRF_tDateEdit))
            //{
            //    AutoSetEndValue(this.InputDayStRF_tDateEdit, this.InputDayEdRF_tDateEdit);
            //}

            //// ���Ӑ�R�[�h
            //if (e.PrevCtrl == this.tNedit_CustomerCode_St)
            //{
            //    AutoSetEndValue(this.tNedit_CustomerCode_St, this.tNedit_CustomerCode_Ed);
            //}

            //// �S���R�[�h
            //if (e.PrevCtrl == this.tEdit_EmployeeCode_St)
            //{
            //    AutoSetEndValue(this.tEdit_EmployeeCode_St, this.tEdit_EmployeeCode_Ed);
            //}
            // 2008.09.24 30413 ���� ���͎x���̍폜 <<<<<<END
            
            // 2008.09.18 30413 ���� �K�C�h�{�^���J�ڐ��� >>>>>>START
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
                        // �S����(�I��)�����Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        //// ���Ӑ�(�I��)���e���ݒ艺���l
                        //e.NextCtrl = this.GrossMarginLowMark_tEdit; // DEL 2009/03/30
                        // ���Ӑ�(�I��)�����s�^�C�v
                        e.NextCtrl = this.tComboEditor_PublicationType; // ADD 2009/03/30

                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    //if (e.PrevCtrl == this.GrossMarginLowMark_tEdit) // DEL 2009/03/30
                    if (e.PrevCtrl == this.tComboEditor_PublicationType) // ADD 2009/03/30
                    {
                        //// �e���ݒ艺���l�����Ӑ�(�I��)
                        // ���s�^�C�v�����Ӑ�(�I��)
                        e.NextCtrl = this.tNedit_CustomerCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_Ed)
                    {
                        // ���Ӑ�(�I��)�����Ӑ�(�J�n)
                        e.NextCtrl = this.tNedit_CustomerCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_CustomerCode_St)
                    {
                        // ���Ӑ�(�J�n)���S����(�I��)
                        e.NextCtrl = this.tEdit_EmployeeCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_EmployeeCode_Ed)
                    {
                        // �S����(�I��)���S����(�J�n)
                        e.NextCtrl = this.tEdit_EmployeeCode_St;
                    }                    
                }
            }
            // 2008.09.18 30413 ���� �K�C�h�{�^���J�ڐ��� <<<<<<END

        }



        
        /// <summary>
        /// �����^�C�}�[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g����</param>
        /// <remarks>
        /// <br>Note        : �����������s���܂��B</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, System.EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // ��ʏ����\��
            this.InitialScreenSetting();
        
            // �����t�H�[�J�X�ݒ�
            this.SalesDateStRF_tDateEdit.Focus();

    	    // ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
		    if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
	    }

    	        
		///// <summary>
		///// Control.GroupCollapsing�C�x���g
		///// </summary>
		///// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		///// <param name="e">�C�x���g����</param>
		///// <remarks>
		///// <br>Note        : �G�N�X�v���[���o�[�̃O���[�v��W�J�����ۂɔ������܂��B</br>
		///// </remarks>
		//private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		//{
		//    if (this._explorerBarExpanding) return;

		//    this._explorerBarExpanding = true;

		//    try
		//    {
		//        if (!e.Group.Key.Equals(EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY))
		//        {
		//            e.Cancel = true;
		//        }
		//    }
		//    finally
		//    {
		//        this._explorerBarExpanding = false;
		//    }
		//}

		/// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
		/// <br>Programmer	: �n�� ��</br>
		/// <br>Date		: 2008.01.07</br>
		/// </remarks>
		private void Main_ultraExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == "CustomerConditionGroup") ||
				(e.Group.Key == "PrintOderGroup") ||
				(e.Group.Key == "ExtraConditionCodeGroup"))
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
		/// <br>Programmer	: �n�� ��</br>
		/// <br>Date		: 2008.01.07</br>
		/// </remarks>
		private void Main_ultraExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
			if ((e.Group.Key == "CustomerConditionGroup") ||
				(e.Group.Key == "PrintOderGroup") ||
				(e.Group.Key == "ExtraConditionCodeGroup"))
			{
				// �O���[�v�̓W�J���L�����Z��
				e.Cancel = true;
			}
		}



	    #endregion

	    #region IPrintConditionInpTypeSelectedSection �����o

		/// <summary>
		/// CheckedSection Event
		/// </summary>
		/// <param name="sectionCode">�ΏۃI�u�W�F�N�g</param>
		/// <param name="checkState">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �o�͑Ώۋ��_���I�����ꂽ���ɔ�������B</br>
		/// <br>Programmer	: �n�� ��</br>
		/// <br>Date		: 2008.01.07</br>
		/// </remarks>
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
        ///  ���_�I�v�V�����擾�v���p�e�B
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
        ///  �{�Ћ@�\�擾�v���p�e�B
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
        ///  �v�㋒�_�I������
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
        ///  �I������Ă���v�㋒�_��ݒ肵�܂�
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
            // 2008.10.09 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode_St.GetInt();
            // 2008.10.09 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END

            // 2008.07.24 30413 ���� ���Ӑ�K�C�h�̃N���X��ύX >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.24 30413 ���� ���Ӑ�K�C�h�̃N���X��ύX <<<<<<END

            // 2008.10.09 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_St.GetInt())) && (this.tNedit_CustomerCode_St.Text != ""))
            {
                // �K�C�h�ďo�O�ƈႤ�A�N���A����Ă��Ȃ��ꍇ
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.09 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END
        }
        #endregion

        /// <summary>
        /// ���Ӑ�R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
        /// </summary>
        private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
        {
            // 2008.10.09 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
            // �t�H�[�J�X����p�A�K�C�h�ďo�O�̓��Ӑ�R�[�h
            int beCustCd = this.tNedit_CustomerCode_Ed.GetInt();
            // 2008.10.09 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END

            // 2008.07.24 30413 ���� ���Ӑ�K�C�h�̃N���X��ύX >>>>>>START
            //SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            //customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            //customerSearchForm.ShowDialog(this);
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
            customerSearchForm.ShowDialog(this);
            // 2008.07.24 30413 ���� ���Ӑ�K�C�h�̃N���X��ύX <<<<<<END

            // 2008.10.09 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX >>>>>>START
            if ((!beCustCd.Equals(this.tNedit_CustomerCode_Ed.GetInt())) && (this.tNedit_CustomerCode_Ed.Text != ""))
            {
                // �K�C�h�ďo�O�ƈႤ�A�N���A����Ă��Ȃ��ꍇ
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
            // 2008.10.09 30413 ���� �K�C�h�{�^���̃t�H�[�J�X�����ύX <<<<<<END
        }

        /// <summary>
        /// ��t�]�ƈ��R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
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
                this.tEdit_EmployeeCode_St.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.10.09 30413 ���� �t�H�[�J�X�����ǉ� >>>>>>START
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.09 30413 ���� �t�H�[�J�X�����ǉ� <<<<<<END
            }
        }

        /// <summary>
        /// ��t�]�ƈ��R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
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
                this.tEdit_EmployeeCode_Ed.DataText = employee.EmployeeCode.TrimEnd();

                // 2008.10.09 30413 ���� �t�H�[�J�X�����ǉ� >>>>>>START
                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
                // 2008.10.09 30413 ���� �t�H�[�J�X�����ǉ� <<<<<<END
            }
        }

		//�e�L�X�g�{�b�N�X�ւ̑e�����̓��͂�A��������
        private void GrsProfitCheckLower_tNedit_ValueChanged(object sender, EventArgs e)
		{
            this.GrossMarginLow2_Nedit.Text = this.GrsProfitCheckLower_tNedit.Text;
		}

		private void GrsProfitCheckBest_tNedit_ValueChanged(object sender, EventArgs e)
		{
            this.GrossMarginBest2_Nedit.Text = this.GrsProfitCheckBest_tNedit.Text;
		}

		private void GrsProfitCheckUpper_tNedit_ValueChanged(object sender, EventArgs e)
		{
            this.GrossMarginUpper2_Nedit.Text = this.GrsProfitCheckUpper_tNedit.Text;
		}

        /// <summary>
        /// Control.Leave �C�x���g(GrsProfitCheckLower_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̉����l����t�H�[�J�X���������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.09</br>
        /// </remarks>
        private void GrsProfitCheckLower_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // ��̏ꍇ�́A�����l��ݒ�
                tNedit.Text = "0.0";
            }
        }

        /// <summary>
        /// Control.Leave �C�x���g(GrsProfitCheckBest_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̓K���l����t�H�[�J�X���������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.09</br>
        /// </remarks>
        private void GrsProfitCheckBest_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // ��̏ꍇ�́A�����l��ݒ�
                tNedit.Text = "0.0";
            }
        }

        /// <summary>
        /// Control.Leave �C�x���g(GrsProfitCheckUpper_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note �@�@  : �e���`�F�b�N�̏���l����t�H�[�J�X���������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.09</br>
        /// </remarks>
        private void GrsProfitCheckUpper_tNedit_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = sender as TNedit;

            if (tNedit.Text == "")
            {
                // ��̏ꍇ�́A�����l��ݒ�
                tNedit.Text = "0.0";
            }
        }
       
    }
}

//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ���׊m�F�\
// �v���O�����T�v   : ���׊m�F�\�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����@��`
// �� �� ��  2007/10/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �n�� ��
// �C �� ��  2008/01/28  �C�����e : ���t���䕔�i�̑g��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �ēc �ύK
// �C �� ��  2008/06/25  �C�����e : �d�l�ύX�ɔ����ύX�B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/09/26  �C�����e : �o�O�C���B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/07  �C�����e : ��Q�Ή�13160(�o�ד��̔C�Ӊ�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/08  �C�����e : ��Q�Ή�9803�A11150�A11153�A12398
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/08  �C�����e : ��Q�Ή�9803�A11150�A11153�A12398�i�ďC���B���W�I�{�^���̑J�ڕ⏕��ǉ��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/06/26  �C�����e : �s��Ή�[13590]�@�`�[�敪�u���ׁv���u�d���v�ɕύX(�R���g���[����Item���C��)
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
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/15 �s��Ή�[9659]

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���[�E�`���[�g��������t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note	   : ���[�E�`���[�g��������t�H�[���N���X�ł��B</br>
	/// <br>Programmer : 980035 ����@��`</br>
	/// <br>Date	   : 2007.10.19</br>
	/// -----------------------------------------------------------------------------------------------------
	/// <br>UpdateNote	: �d�l�ύX�ɔ����ύX�B</br>
	///	<br>			�@���͓��t�̒ǉ��A��\�敪�ړ��i�o�͏��������o�����j�A�o�͏��̒ǉ��A�ԓ`�敪�ǉ�</br>
	/// <br>Programmer	: 30191 �n�� ��</br>
	/// <br>Date		: 2008.01.28</br>
	/// -----------------------------------------------------------------------------------------------------
	/// <br>UpdateNote	: ���ʏC���B</br>
	///	<br>			�@���t���䕔�i�̑g��</br>
	/// <br>Programmer	: 30191 �n�� ��</br>
	/// <br>Date		: 2008.02.19</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: �d�l�ύX�ɔ����ύX�B</br>
    /// <br>Programmer	: 30415 �ēc �ύK</br>
    /// <br>Date		: 2008/06/25</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: �o�O�C���B</br>
    /// <br>Programmer	: �Ɠc �M�u</br>
    /// <br>Date		: 2008/09/26</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: ��Q�Ή�13160(�o�ד��̔C�Ӊ�)</br>
    /// <br>Programmer	: ��� �r��</br>
    /// <br>Date		: 2009/04/07</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: ��Q�Ή�9803�A11150�A11153�A12398</br>
    /// <br>Programmer	: ��� �r��</br>
    /// <br>Date		: 2009/04/08</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: ��Q�Ή�9803�A11150�A11153�A12398�i�ďC���B���W�I�{�^���̑J�ڕ⏕��ǉ��j</br>
    /// <br>Programmer	: ��� �r��</br>
    /// <br>Date		: 2009/04/14</br>
    /// -----------------------------------------------------------------------------------------------------
    /// <br>UpdateNote	: �s��Ή�[13590]�@�`�[�敪�u���ׁv���u�d���v�ɕύX(�R���g���[����Item���C��)</br>
    /// <br>Programmer	: �Ɠc �M�u</br>
    /// <br>Date		: 2009/06/26</br>
    /// </remarks>
	public class DCKOU02301UA : System.Windows.Forms.Form,
		IPrintConditionInpType,
		IPrintConditionInpTypeSelectedSection,
		IPrintConditionInpTypePdfCareer
	{
		# region Private Members (Component)

		private System.Windows.Forms.Panel Centering_Panel;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Windows.Forms.Panel MAHNB02020UA_Fill_Panel;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar Main_ultraExplorerBar;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl1;
		private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl3;
		private TComboEditor PrintOder_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl ultraExplorerBarContainerControl4;
		private TDateEdit InputDayEd_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel10;
		private TDateEdit InputDaySt_tDateEdit;
        private Infragistics.Win.Misc.UltraLabel Date_Title_Label;
		private TNedit tNedit_SupplierCd_Ed;
		private Infragistics.Win.Misc.UltraLabel ultraLabel11;
		private TNedit tNedit_SupplierCd_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private TComboEditor SlipDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
		private Infragistics.Win.Misc.UltraLabel ultraLabel28;
		private TEdit tEdit_StockAgentCode_Ed;
		private TEdit tEdit_StockAgentCode_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
		private Infragistics.Win.Misc.UltraLabel ultraLabel9;
		private Infragistics.Win.Misc.UltraButton CustomerCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraButton StockAgentCdEd_GuideBtn;
        private Infragistics.Win.Misc.UltraButton StockAgentCdSt_GuideBtn;
		private Infragistics.Win.Misc.UltraButton CustomerCdEd_GuideBtn;
		private ToolTip toolTip1;
		private TDateEdit ArrivalGoodsDayEd_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel7;
		private TDateEdit ArrivalGoodsDaySt_tDateEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private TComboEditor DebitN_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private TComboEditor MakeShowDiv_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private TNedit SupplierSlipNoEd_Nedit;
		private TNedit SupplierSlipNoSt_Nedit;
		private UiSetControl uiSetControl1;
        private Infragistics.Win.UltraWinEditors.UltraOptionSet PrindDailyFooter_ultraOptionSet;
        private Infragistics.Win.Misc.UltraLabel ultraLabel37;
        private Infragistics.Win.Misc.UltraLabel ultraLabel21;
        private TComboEditor NewPageType_tComboEditor;
        private TEdit tEdit_PartySalesSlipNum_Ed;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TEdit tEdit_PartySalesSlipNum_St;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private System.ComponentModel.IContainer components;
		#endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region constructer
        /// <summary>
        /// ���׈ꗗ�\UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���׈ꗗ�\UI�N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// <br></br>
        /// </remarks>
        public DCKOU02301UA()
		{
			InitializeComponent();

			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._salesFormalList = new SortedList();
			this._salesSlipKindList = new SortedList();

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginWorker = LoginInfoAcquisition.Employee.Clone();
				this._ownSectionCode = this._loginWorker.BelongSectionCode;
			}

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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup2 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            this.ultraExplorerBarContainerControl4 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrindDailyFooter_ultraOptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel21 = new Infragistics.Win.Misc.UltraLabel();
            this.NewPageType_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ArrivalGoodsDayEd_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ArrivalGoodsDaySt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDayEd_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.InputDaySt_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.Date_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl3 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.PrintOder_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraExplorerBarContainerControl1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl();
            this.tEdit_PartySalesSlipNum_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_PartySalesSlipNum_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierSlipNoEd_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierSlipNoSt_Nedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MakeShowDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.DebitN_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.StockAgentCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.StockAgentCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdEd_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCdSt_GuideBtn = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_StockAgentCode_Ed = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_StockAgentCode_St = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.SlipDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_Ed = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_SupplierCd_St = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.MAHNB02020UA_Fill_Panel = new System.Windows.Forms.Panel();
            this.Centering_Panel = new System.Windows.Forms.Panel();
            this.Main_ultraExplorerBar = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.ultraExplorerBarContainerControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrindDailyFooter_ultraOptionSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageType_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).BeginInit();
            this.ultraExplorerBarContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNoEd_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNoSt_Nedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakeShowDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitN_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_St)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).BeginInit();
            this.MAHNB02020UA_Fill_Panel.SuspendLayout();
            this.Centering_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ultraExplorerBar)).BeginInit();
            this.Main_ultraExplorerBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraExplorerBarContainerControl4
            // 
            this.ultraExplorerBarContainerControl4.Controls.Add(this.PrindDailyFooter_ultraOptionSet);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel37);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel21);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.NewPageType_tComboEditor);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ArrivalGoodsDayEd_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel7);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ArrivalGoodsDaySt_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel15);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDayEd_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.ultraLabel10);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.InputDaySt_tDateEdit);
            this.ultraExplorerBarContainerControl4.Controls.Add(this.Date_Title_Label);
            this.ultraExplorerBarContainerControl4.Location = new System.Drawing.Point(18, 46);
            this.ultraExplorerBarContainerControl4.Name = "ultraExplorerBarContainerControl4";
            this.ultraExplorerBarContainerControl4.Size = new System.Drawing.Size(714, 104);
            this.ultraExplorerBarContainerControl4.TabIndex = 0;
            // 
            // PrindDailyFooter_ultraOptionSet
            // 
            this.PrindDailyFooter_ultraOptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.PrindDailyFooter_ultraOptionSet.CheckedIndex = 0;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "���Ȃ�";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "����";
            this.PrindDailyFooter_ultraOptionSet.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2});
            this.PrindDailyFooter_ultraOptionSet.Location = new System.Drawing.Point(443, 74);
            this.PrindDailyFooter_ultraOptionSet.Name = "PrindDailyFooter_ultraOptionSet";
            this.PrindDailyFooter_ultraOptionSet.Size = new System.Drawing.Size(130, 20);
            this.PrindDailyFooter_ultraOptionSet.TabIndex = 38;
            this.PrindDailyFooter_ultraOptionSet.Text = "���Ȃ�";
            // 
            // ultraLabel37
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel37.Appearance = appearance18;
            this.ultraLabel37.Location = new System.Drawing.Point(366, 71);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(80, 23);
            this.ultraLabel37.TabIndex = 39;
            this.ultraLabel37.Text = "���v��";
            // 
            // ultraLabel21
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.ultraLabel21.Appearance = appearance8;
            this.ultraLabel21.Location = new System.Drawing.Point(24, 69);
            this.ultraLabel21.Name = "ultraLabel21";
            this.ultraLabel21.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel21.TabIndex = 37;
            this.ultraLabel21.Text = "����";
            // 
            // NewPageType_tComboEditor
            // 
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageType_tComboEditor.ActiveAppearance = appearance68;
            this.NewPageType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.NewPageType_tComboEditor.ItemAppearance = appearance69;
            valueListItem3.DataValue = 0;
            valueListItem3.DisplayText = "���_";
            valueListItem4.DataValue = 1;
            valueListItem4.DisplayText = "�d����";
            valueListItem5.DataValue = 2;
            valueListItem5.DisplayText = "���Ȃ�";
            this.NewPageType_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem3,
            valueListItem4,
            valueListItem5});
            this.NewPageType_tComboEditor.LimitToList = true;
            this.NewPageType_tComboEditor.Location = new System.Drawing.Point(178, 70);
            this.NewPageType_tComboEditor.Name = "NewPageType_tComboEditor";
            this.NewPageType_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.NewPageType_tComboEditor.TabIndex = 36;
            // 
            // ArrivalGoodsDayEd_tDateEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ArrivalGoodsDayEd_tDateEdit.ActiveEditAppearance = appearance1;
            this.ArrivalGoodsDayEd_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ArrivalGoodsDayEd_tDateEdit.CalendarDisp = true;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ArrivalGoodsDayEd_tDateEdit.EditAppearance = appearance2;
            this.ArrivalGoodsDayEd_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ArrivalGoodsDayEd_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.ArrivalGoodsDayEd_tDateEdit.LabelAppearance = appearance3;
            this.ArrivalGoodsDayEd_tDateEdit.Location = new System.Drawing.Point(397, 9);
            this.ArrivalGoodsDayEd_tDateEdit.Name = "ArrivalGoodsDayEd_tDateEdit";
            this.ArrivalGoodsDayEd_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ArrivalGoodsDayEd_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ArrivalGoodsDayEd_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.ArrivalGoodsDayEd_tDateEdit.TabIndex = 1;
            this.ArrivalGoodsDayEd_tDateEdit.TabStop = true;
            // 
            // ultraLabel7
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance4;
            this.ultraLabel7.Location = new System.Drawing.Point(366, 9);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel7.TabIndex = 5;
            this.ultraLabel7.Text = "�`";
            // 
            // ArrivalGoodsDaySt_tDateEdit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ArrivalGoodsDaySt_tDateEdit.ActiveEditAppearance = appearance5;
            this.ArrivalGoodsDaySt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.ArrivalGoodsDaySt_tDateEdit.CalendarDisp = true;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.ArrivalGoodsDaySt_tDateEdit.EditAppearance = appearance6;
            this.ArrivalGoodsDaySt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.ArrivalGoodsDaySt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.ArrivalGoodsDaySt_tDateEdit.LabelAppearance = appearance7;
            this.ArrivalGoodsDaySt_tDateEdit.Location = new System.Drawing.Point(178, 9);
            this.ArrivalGoodsDaySt_tDateEdit.Name = "ArrivalGoodsDaySt_tDateEdit";
            this.ArrivalGoodsDaySt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.ArrivalGoodsDaySt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.ArrivalGoodsDaySt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.ArrivalGoodsDaySt_tDateEdit.TabIndex = 0;
            this.ArrivalGoodsDaySt_tDateEdit.TabStop = true;
            // 
            // ultraLabel15
            // 
            appearance33.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance33;
            this.ultraLabel15.Location = new System.Drawing.Point(24, 9);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel15.TabIndex = 0;
            this.ultraLabel15.Text = "���ד�";
            // 
            // InputDayEd_tDateEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDayEd_tDateEdit.ActiveEditAppearance = appearance9;
            this.InputDayEd_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDayEd_tDateEdit.CalendarDisp = true;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.InputDayEd_tDateEdit.EditAppearance = appearance10;
            this.InputDayEd_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDayEd_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.InputDayEd_tDateEdit.LabelAppearance = appearance11;
            this.InputDayEd_tDateEdit.Location = new System.Drawing.Point(397, 40);
            this.InputDayEd_tDateEdit.Name = "InputDayEd_tDateEdit";
            this.InputDayEd_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDayEd_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDayEd_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDayEd_tDateEdit.TabIndex = 3;
            this.InputDayEd_tDateEdit.TabStop = true;
            // 
            // ultraLabel10
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance12;
            this.ultraLabel10.Location = new System.Drawing.Point(366, 40);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel10.TabIndex = 25;
            this.ultraLabel10.Text = "�`";
            // 
            // InputDaySt_tDateEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InputDaySt_tDateEdit.ActiveEditAppearance = appearance13;
            this.InputDaySt_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.InputDaySt_tDateEdit.CalendarDisp = true;
            appearance14.TextHAlignAsString = "Left";
            appearance14.TextVAlignAsString = "Middle";
            this.InputDaySt_tDateEdit.EditAppearance = appearance14;
            this.InputDaySt_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.InputDaySt_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            appearance15.TextHAlignAsString = "Left";
            appearance15.TextVAlignAsString = "Middle";
            this.InputDaySt_tDateEdit.LabelAppearance = appearance15;
            this.InputDaySt_tDateEdit.Location = new System.Drawing.Point(178, 40);
            this.InputDaySt_tDateEdit.Name = "InputDaySt_tDateEdit";
            this.InputDaySt_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.InputDaySt_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.InputDaySt_tDateEdit.Size = new System.Drawing.Size(176, 24);
            this.InputDaySt_tDateEdit.TabIndex = 2;
            this.InputDaySt_tDateEdit.TabStop = true;
            // 
            // Date_Title_Label
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.Date_Title_Label.Appearance = appearance16;
            this.Date_Title_Label.Location = new System.Drawing.Point(24, 40);
            this.Date_Title_Label.Name = "Date_Title_Label";
            this.Date_Title_Label.Size = new System.Drawing.Size(140, 23);
            this.Date_Title_Label.TabIndex = 6;
            this.Date_Title_Label.Text = "���͓�";
            // 
            // ultraExplorerBarContainerControl3
            // 
            this.ultraExplorerBarContainerControl3.Controls.Add(this.PrintOder_tComboEditor);
            this.ultraExplorerBarContainerControl3.Controls.Add(this.ultraLabel5);
            this.ultraExplorerBarContainerControl3.Location = new System.Drawing.Point(18, 187);
            this.ultraExplorerBarContainerControl3.Name = "ultraExplorerBarContainerControl3";
            this.ultraExplorerBarContainerControl3.Size = new System.Drawing.Size(714, 38);
            this.ultraExplorerBarContainerControl3.TabIndex = 1;
            // 
            // PrintOder_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ActiveAppearance = appearance17;
            this.PrintOder_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintOder_tComboEditor.ItemAppearance = appearance36;
            valueListItem6.DataValue = 0;
            valueListItem6.DisplayText = "�d���恨���ד����d��SEQ�ԍ�";
            valueListItem7.DataValue = 1;
            valueListItem7.DisplayText = "���ד����d���恨�d��SEQ�ԍ�";
            valueListItem8.DataValue = 2;
            valueListItem8.DisplayText = "�S���ҁ��d���恨���ד����d��SEQ�ԍ�";
            valueListItem9.DataValue = 3;
            valueListItem9.DisplayText = "���ד����d��SEQ�ԍ�";
            valueListItem10.DataValue = 4;
            valueListItem10.DisplayText = "�d��SEQ�ԍ�";
            this.PrintOder_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10});
            this.PrintOder_tComboEditor.LimitToList = true;
            this.PrintOder_tComboEditor.Location = new System.Drawing.Point(178, 7);
            this.PrintOder_tComboEditor.Name = "PrintOder_tComboEditor";
            this.PrintOder_tComboEditor.Size = new System.Drawing.Size(372, 24);
            this.PrintOder_tComboEditor.TabIndex = 40;
            // 
            // ultraLabel5
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance19;
            this.ultraLabel5.Location = new System.Drawing.Point(24, 7);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel5.TabIndex = 0;
            this.ultraLabel5.Text = "�o�͏�";
            // 
            // ultraExplorerBarContainerControl1
            // 
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_PartySalesSlipNum_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel8);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_PartySalesSlipNum_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel2);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SupplierSlipNoEd_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SupplierSlipNoSt_Nedit);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.MakeShowDiv_tComboEditor);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel6);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.DebitN_tComboEditor);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel4);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.StockAgentCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.StockAgentCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdEd_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.CustomerCdSt_GuideBtn);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel9);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_StockAgentCode_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tEdit_StockAgentCode_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel25);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel27);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel28);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.SlipDiv_tComboEditor);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel12);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_Ed);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel11);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.tNedit_SupplierCd_St);
            this.ultraExplorerBarContainerControl1.Controls.Add(this.ultraLabel3);
            this.ultraExplorerBarContainerControl1.Location = new System.Drawing.Point(18, 262);
            this.ultraExplorerBarContainerControl1.Name = "ultraExplorerBarContainerControl1";
            this.ultraExplorerBarContainerControl1.Size = new System.Drawing.Size(714, 195);
            this.ultraExplorerBarContainerControl1.TabIndex = 2;
            // 
            // tEdit_PartySalesSlipNum_Ed
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PartySalesSlipNum_Ed.ActiveAppearance = appearance41;
            this.tEdit_PartySalesSlipNum_Ed.AutoSelect = true;
            this.tEdit_PartySalesSlipNum_Ed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_PartySalesSlipNum_Ed.DataText = "";
            this.tEdit_PartySalesSlipNum_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PartySalesSlipNum_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_PartySalesSlipNum_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_PartySalesSlipNum_Ed.Location = new System.Drawing.Point(390, 99);
            this.tEdit_PartySalesSlipNum_Ed.MaxLength = 9;
            this.tEdit_PartySalesSlipNum_Ed.Name = "tEdit_PartySalesSlipNum_Ed";
            this.tEdit_PartySalesSlipNum_Ed.Size = new System.Drawing.Size(159, 24);
            this.tEdit_PartySalesSlipNum_Ed.TabIndex = 155;
            // 
            // ultraLabel8
            // 
            appearance43.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance43;
            this.ultraLabel8.Location = new System.Drawing.Point(355, 101);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel8.TabIndex = 157;
            this.ultraLabel8.Text = "�`";
            // 
            // tEdit_PartySalesSlipNum_St
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_PartySalesSlipNum_St.ActiveAppearance = appearance32;
            this.tEdit_PartySalesSlipNum_St.AutoSelect = true;
            this.tEdit_PartySalesSlipNum_St.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_PartySalesSlipNum_St.DataText = "";
            this.tEdit_PartySalesSlipNum_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_PartySalesSlipNum_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_PartySalesSlipNum_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_PartySalesSlipNum_St.Location = new System.Drawing.Point(178, 100);
            this.tEdit_PartySalesSlipNum_St.MaxLength = 9;
            this.tEdit_PartySalesSlipNum_St.Name = "tEdit_PartySalesSlipNum_St";
            this.tEdit_PartySalesSlipNum_St.Size = new System.Drawing.Size(159, 24);
            this.tEdit_PartySalesSlipNum_St.TabIndex = 154;
            // 
            // ultraLabel2
            // 
            appearance59.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance59;
            this.ultraLabel2.Location = new System.Drawing.Point(24, 100);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(107, 23);
            this.ultraLabel2.TabIndex = 156;
            this.ultraLabel2.Text = "�`�[�ԍ�";
            // 
            // SupplierSlipNoEd_Nedit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.TextHAlignAsString = "Right";
            this.SupplierSlipNoEd_Nedit.ActiveAppearance = appearance20;
            appearance21.TextHAlignAsString = "Right";
            this.SupplierSlipNoEd_Nedit.Appearance = appearance21;
            this.SupplierSlipNoEd_Nedit.AutoSelect = true;
            this.SupplierSlipNoEd_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierSlipNoEd_Nedit.DataText = "";
            this.SupplierSlipNoEd_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierSlipNoEd_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SupplierSlipNoEd_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierSlipNoEd_Nedit.Location = new System.Drawing.Point(390, 70);
            this.SupplierSlipNoEd_Nedit.MaxLength = 9;
            this.SupplierSlipNoEd_Nedit.Name = "SupplierSlipNoEd_Nedit";
            this.SupplierSlipNoEd_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SupplierSlipNoEd_Nedit.Size = new System.Drawing.Size(82, 24);
            this.SupplierSlipNoEd_Nedit.TabIndex = 120;
            // 
            // SupplierSlipNoSt_Nedit
            // 
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance22.TextHAlignAsString = "Right";
            this.SupplierSlipNoSt_Nedit.ActiveAppearance = appearance22;
            appearance23.TextHAlignAsString = "Right";
            this.SupplierSlipNoSt_Nedit.Appearance = appearance23;
            this.SupplierSlipNoSt_Nedit.AutoSelect = true;
            this.SupplierSlipNoSt_Nedit.CalcSize = new System.Drawing.Size(172, 200);
            this.SupplierSlipNoSt_Nedit.DataText = "";
            this.SupplierSlipNoSt_Nedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierSlipNoSt_Nedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.SupplierSlipNoSt_Nedit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SupplierSlipNoSt_Nedit.Location = new System.Drawing.Point(178, 70);
            this.SupplierSlipNoSt_Nedit.MaxLength = 9;
            this.SupplierSlipNoSt_Nedit.Name = "SupplierSlipNoSt_Nedit";
            this.SupplierSlipNoSt_Nedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.SupplierSlipNoSt_Nedit.Size = new System.Drawing.Size(82, 24);
            this.SupplierSlipNoSt_Nedit.TabIndex = 110;
            // 
            // MakeShowDiv_tComboEditor
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakeShowDiv_tComboEditor.ActiveAppearance = appearance24;
            this.MakeShowDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakeShowDiv_tComboEditor.ItemAppearance = appearance25;
            valueListItem11.DataValue = 0;
            valueListItem11.DisplayText = "�S��";
            valueListItem12.DataValue = 1;
            valueListItem12.DisplayText = "���׌v��";
            this.MakeShowDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem11,
            valueListItem12});
            this.MakeShowDiv_tComboEditor.LimitToList = true;
            this.MakeShowDiv_tComboEditor.Location = new System.Drawing.Point(178, 160);
            this.MakeShowDiv_tComboEditor.Name = "MakeShowDiv_tComboEditor";
            this.MakeShowDiv_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.MakeShowDiv_tComboEditor.TabIndex = 150;
            // 
            // ultraLabel6
            // 
            appearance26.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance26;
            this.ultraLabel6.Location = new System.Drawing.Point(24, 160);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel6.TabIndex = 26;
            this.ultraLabel6.Text = "���s�^�C�v";
            // 
            // DebitN_tComboEditor
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DebitN_tComboEditor.ActiveAppearance = appearance27;
            this.DebitN_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DebitN_tComboEditor.ItemAppearance = appearance28;
            valueListItem13.DataValue = 0;
            valueListItem13.DisplayText = "���`";
            valueListItem14.DataValue = 1;
            valueListItem14.DisplayText = "�ԓ`";
            valueListItem15.DataValue = 2;
            valueListItem15.DisplayText = "����";
            valueListItem16.DataValue = 3;
            valueListItem16.DisplayText = "�S��";
            this.DebitN_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem13,
            valueListItem14,
            valueListItem15,
            valueListItem16});
            this.DebitN_tComboEditor.LimitToList = true;
            this.DebitN_tComboEditor.Location = new System.Drawing.Point(599, 160);
            this.DebitN_tComboEditor.Name = "DebitN_tComboEditor";
            this.DebitN_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.DebitN_tComboEditor.TabIndex = 140;
            this.DebitN_tComboEditor.Visible = false;
            // 
            // ultraLabel4
            // 
            appearance29.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance29;
            this.ultraLabel4.Location = new System.Drawing.Point(453, 160);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel4.TabIndex = 24;
            this.ultraLabel4.Text = "�ԓ`�敪";
            this.ultraLabel4.Visible = false;
            // 
            // StockAgentCdEd_GuideBtn
            // 
            appearance30.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.StockAgentCdEd_GuideBtn.Appearance = appearance30;
            this.StockAgentCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.StockAgentCdEd_GuideBtn.Location = new System.Drawing.Point(480, 40);
            this.StockAgentCdEd_GuideBtn.Name = "StockAgentCdEd_GuideBtn";
            this.StockAgentCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.StockAgentCdEd_GuideBtn.TabIndex = 85;
            this.StockAgentCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.StockAgentCdEd_GuideBtn, "�]�ƈ��K�C�h");
            this.StockAgentCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.StockAgentCdEd_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdEd_GuideBtn_Click);
            // 
            // StockAgentCdSt_GuideBtn
            // 
            appearance31.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.StockAgentCdSt_GuideBtn.Appearance = appearance31;
            this.StockAgentCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.StockAgentCdSt_GuideBtn.Location = new System.Drawing.Point(268, 40);
            this.StockAgentCdSt_GuideBtn.Name = "StockAgentCdSt_GuideBtn";
            this.StockAgentCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.StockAgentCdSt_GuideBtn.TabIndex = 75;
            this.StockAgentCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.StockAgentCdSt_GuideBtn, "�]�ƈ��K�C�h");
            this.StockAgentCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.StockAgentCdSt_GuideBtn.Click += new System.EventHandler(this.SalesEmployeeCdSt_GuideBtn_Click);
            // 
            // CustomerCdEd_GuideBtn
            // 
            appearance34.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdEd_GuideBtn.Appearance = appearance34;
            this.CustomerCdEd_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdEd_GuideBtn.Location = new System.Drawing.Point(480, 10);
            this.CustomerCdEd_GuideBtn.Name = "CustomerCdEd_GuideBtn";
            this.CustomerCdEd_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdEd_GuideBtn.TabIndex = 65;
            this.CustomerCdEd_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdEd_GuideBtn, "�d���挟��");
            this.CustomerCdEd_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdEd_GuideBtn.Click += new System.EventHandler(this.CustomerCdEd_GuideBtn_Click);
            // 
            // CustomerCdSt_GuideBtn
            // 
            appearance35.ImageHAlign = Infragistics.Win.HAlign.Center;
            this.CustomerCdSt_GuideBtn.Appearance = appearance35;
            this.CustomerCdSt_GuideBtn.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.CustomerCdSt_GuideBtn.Location = new System.Drawing.Point(268, 10);
            this.CustomerCdSt_GuideBtn.Name = "CustomerCdSt_GuideBtn";
            this.CustomerCdSt_GuideBtn.Size = new System.Drawing.Size(25, 25);
            this.CustomerCdSt_GuideBtn.TabIndex = 55;
            this.CustomerCdSt_GuideBtn.TabStop = false;
            this.toolTip1.SetToolTip(this.CustomerCdSt_GuideBtn, "�d���挟��");
            this.CustomerCdSt_GuideBtn.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerCdSt_GuideBtn.Click += new System.EventHandler(this.CustomerCdSt_GuideBtn_Click);
            // 
            // ultraLabel9
            // 
            appearance39.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance39;
            this.ultraLabel9.Location = new System.Drawing.Point(24, 40);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(138, 23);
            this.ultraLabel9.TabIndex = 12;
            this.ultraLabel9.Text = "�S����";
            // 
            // tEdit_StockAgentCode_Ed
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode_Ed.ActiveAppearance = appearance40;
            this.tEdit_StockAgentCode_Ed.AutoSelect = true;
            this.tEdit_StockAgentCode_Ed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_StockAgentCode_Ed.DataText = "";
            this.tEdit_StockAgentCode_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_StockAgentCode_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentCode_Ed.Location = new System.Drawing.Point(390, 40);
            this.tEdit_StockAgentCode_Ed.MaxLength = 9;
            this.tEdit_StockAgentCode_Ed.Name = "tEdit_StockAgentCode_Ed";
            this.tEdit_StockAgentCode_Ed.Size = new System.Drawing.Size(82, 24);
            this.tEdit_StockAgentCode_Ed.TabIndex = 80;
            // 
            // tEdit_StockAgentCode_St
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_StockAgentCode_St.ActiveAppearance = appearance37;
            this.tEdit_StockAgentCode_St.AutoSelect = true;
            this.tEdit_StockAgentCode_St.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tEdit_StockAgentCode_St.DataText = "";
            this.tEdit_StockAgentCode_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_StockAgentCode_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, false, true, true, true));
            this.tEdit_StockAgentCode_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_StockAgentCode_St.Location = new System.Drawing.Point(178, 40);
            this.tEdit_StockAgentCode_St.MaxLength = 9;
            this.tEdit_StockAgentCode_St.Name = "tEdit_StockAgentCode_St";
            this.tEdit_StockAgentCode_St.Size = new System.Drawing.Size(82, 24);
            this.tEdit_StockAgentCode_St.TabIndex = 70;
            // 
            // ultraLabel25
            // 
            appearance42.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance42;
            this.ultraLabel25.Location = new System.Drawing.Point(355, 41);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel25.TabIndex = 76;
            this.ultraLabel25.Text = "�`";
            // 
            // ultraLabel27
            // 
            appearance38.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance38;
            this.ultraLabel27.Location = new System.Drawing.Point(355, 71);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel27.TabIndex = 115;
            this.ultraLabel27.Text = "�`";
            // 
            // ultraLabel28
            // 
            appearance44.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance44;
            this.ultraLabel28.Location = new System.Drawing.Point(24, 70);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel28.TabIndex = 18;
            this.ultraLabel28.Text = "�d��SEQ�ԍ�";
            // 
            // SlipDiv_tComboEditor
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipDiv_tComboEditor.ActiveAppearance = appearance46;
            this.SlipDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipDiv_tComboEditor.ItemAppearance = appearance47;
            valueListItem17.DataValue = 2;
            valueListItem17.DisplayText = "�S��";
            valueListItem18.DataValue = 0;
            valueListItem18.DisplayText = "�d��";
            valueListItem19.DataValue = 1;
            valueListItem19.DisplayText = "�ԕi";
            this.SlipDiv_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem17,
            valueListItem18,
            valueListItem19});
            this.SlipDiv_tComboEditor.LimitToList = true;
            this.SlipDiv_tComboEditor.Location = new System.Drawing.Point(178, 130);
            this.SlipDiv_tComboEditor.Name = "SlipDiv_tComboEditor";
            this.SlipDiv_tComboEditor.Size = new System.Drawing.Size(112, 24);
            this.SlipDiv_tComboEditor.TabIndex = 130;
            // 
            // ultraLabel12
            // 
            appearance48.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance48;
            this.ultraLabel12.Location = new System.Drawing.Point(24, 130);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(140, 23);
            this.ultraLabel12.TabIndex = 22;
            this.ultraLabel12.Text = "�`�[�敪";
            // 
            // tNedit_SupplierCd_Ed
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance49.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_Ed.ActiveAppearance = appearance49;
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_Ed.Appearance = appearance50;
            this.tNedit_SupplierCd_Ed.AutoSelect = true;
            this.tNedit_SupplierCd_Ed.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_Ed.DataText = "";
            this.tNedit_SupplierCd_Ed.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_Ed.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_Ed.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_Ed.Location = new System.Drawing.Point(390, 10);
            this.tNedit_SupplierCd_Ed.MaxLength = 9;
            this.tNedit_SupplierCd_Ed.Name = "tNedit_SupplierCd_Ed";
            this.tNedit_SupplierCd_Ed.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SupplierCd_Ed.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd_Ed.TabIndex = 60;
            // 
            // ultraLabel11
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance51;
            this.ultraLabel11.Location = new System.Drawing.Point(355, 11);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(20, 23);
            this.ultraLabel11.TabIndex = 56;
            this.ultraLabel11.Text = "�`";
            // 
            // tNedit_SupplierCd_St
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.TextHAlignAsString = "Left";
            this.tNedit_SupplierCd_St.ActiveAppearance = appearance52;
            appearance53.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd_St.Appearance = appearance53;
            this.tNedit_SupplierCd_St.AutoSelect = true;
            this.tNedit_SupplierCd_St.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd_St.DataText = "";
            this.tNedit_SupplierCd_St.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd_St.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd_St.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd_St.Location = new System.Drawing.Point(178, 10);
            this.tNedit_SupplierCd_St.MaxLength = 9;
            this.tNedit_SupplierCd_St.Name = "tNedit_SupplierCd_St";
            this.tNedit_SupplierCd_St.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_SupplierCd_St.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd_St.TabIndex = 50;
            // 
            // ultraLabel3
            // 
            appearance54.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance54;
            this.ultraLabel3.Location = new System.Drawing.Point(24, 10);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(122, 23);
            this.ultraLabel3.TabIndex = 0;
            this.ultraLabel3.Text = "�d����";
            // 
            // MAHNB02020UA_Fill_Panel
            // 
            this.MAHNB02020UA_Fill_Panel.Controls.Add(this.Centering_Panel);
            this.MAHNB02020UA_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAHNB02020UA_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.MAHNB02020UA_Fill_Panel.Name = "MAHNB02020UA_Fill_Panel";
            this.MAHNB02020UA_Fill_Panel.Size = new System.Drawing.Size(750, 677);
            this.MAHNB02020UA_Fill_Panel.TabIndex = 0;
            // 
            // Centering_Panel
            // 
            this.Centering_Panel.Controls.Add(this.Main_ultraExplorerBar);
            this.Centering_Panel.Controls.Add(this.ultraLabel1);
            this.Centering_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Centering_Panel.Location = new System.Drawing.Point(0, 0);
            this.Centering_Panel.Name = "Centering_Panel";
            this.Centering_Panel.Size = new System.Drawing.Size(750, 677);
            this.Centering_Panel.TabIndex = 0;
            // 
            // Main_ultraExplorerBar
            // 
            this.Main_ultraExplorerBar.AcceptsFocus = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.AnimationSpeed = Infragistics.Win.UltraWinExplorerBar.AnimationSpeed.Fast;
            appearance55.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            appearance55.FontData.Name = "�l�r �S�V�b�N";
            appearance55.FontData.SizeInPoints = 11.25F;
            this.Main_ultraExplorerBar.Appearance = appearance55;
            this.Main_ultraExplorerBar.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl1);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl3);
            this.Main_ultraExplorerBar.Controls.Add(this.ultraExplorerBarContainerControl4);
            this.Main_ultraExplorerBar.Dock = System.Windows.Forms.DockStyle.Fill;
            ultraExplorerBarGroup1.Container = this.ultraExplorerBarContainerControl4;
            ultraExplorerBarGroup1.Key = "CustomerConditionGroup";
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup1.Settings.AppearancesSmall.Appearance = appearance56;
            ultraExplorerBarGroup1.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup1.Settings.ContainerHeight = 106;
            ultraExplorerBarGroup1.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup1.Text = "�@�o�͏���";
            ultraExplorerBarGroup2.Container = this.ultraExplorerBarContainerControl3;
            ultraExplorerBarGroup2.Key = "PrintOderGroup";
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup2.Settings.AppearancesSmall.Appearance = appearance57;
            ultraExplorerBarGroup2.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup2.Settings.ContainerHeight = 40;
            ultraExplorerBarGroup2.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup2.Text = "�@�\�[�g��";
            ultraExplorerBarGroup3.Container = this.ultraExplorerBarContainerControl1;
            ultraExplorerBarGroup3.Key = "ExtraConditionCodeGroup";
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            ultraExplorerBarGroup3.Settings.AppearancesSmall.Appearance = appearance58;
            ultraExplorerBarGroup3.Settings.BorderStyleItemArea = Infragistics.Win.UIElementBorderStyle.Solid;
            ultraExplorerBarGroup3.Settings.ContainerHeight = 197;
            ultraExplorerBarGroup3.Settings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            ultraExplorerBarGroup3.Text = "�@���o����";
            this.Main_ultraExplorerBar.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1,
            ultraExplorerBarGroup2,
            ultraExplorerBarGroup3});
            this.Main_ultraExplorerBar.GroupSettings.AllowDrag = Infragistics.Win.DefaultableBoolean.False;
            this.Main_ultraExplorerBar.GroupSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance45.BackColor2 = System.Drawing.Color.CornflowerBlue;
            appearance45.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance45.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderAppearance = appearance45;
            appearance60.Cursor = System.Windows.Forms.Cursors.Default;
            this.Main_ultraExplorerBar.GroupSettings.AppearancesSmall.HeaderHotTrackAppearance = appearance60;
            this.Main_ultraExplorerBar.GroupSettings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer;
            this.Main_ultraExplorerBar.GroupSpacing = 3;
            this.Main_ultraExplorerBar.Location = new System.Drawing.Point(0, 0);
            this.Main_ultraExplorerBar.Name = "Main_ultraExplorerBar";
            this.Main_ultraExplorerBar.Scrollbars = Infragistics.Win.UltraWinExplorerBar.ScrollbarStyle.Never;
            this.Main_ultraExplorerBar.ShowDefaultContextMenu = false;
            this.Main_ultraExplorerBar.Size = new System.Drawing.Size(750, 677);
            this.Main_ultraExplorerBar.TabIndex = 2;
            this.Main_ultraExplorerBar.ViewStyle = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarViewStyle.Office2003;
            this.Main_ultraExplorerBar.GroupCollapsing += new Infragistics.Win.UltraWinExplorerBar.GroupCollapsingEventHandler(this.Main_ultraExplorerBar_GroupCollapsing);
            this.Main_ultraExplorerBar.GroupExpanding += new Infragistics.Win.UltraWinExplorerBar.GroupExpandingEventHandler(this.Main_ultraExplorerBar_GroupExpanding);
            // 
            // ultraLabel1
            // 
            appearance61.FontData.SizeInPoints = 20F;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance61;
            this.ultraLabel1.Location = new System.Drawing.Point(0, 0);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(750, 560);
            this.ultraLabel1.TabIndex = 1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tKeyControl_ChangeFocus);
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
            // DCKOU02301UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(750, 677);
            this.Controls.Add(this.MAHNB02020UA_Fill_Panel);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DCKOU02301UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SFUKK01390UA_Load);
            this.Activated += new System.EventHandler(this.SFUKK01390UA_Activated);
            this.ultraExplorerBarContainerControl4.ResumeLayout(false);
            this.ultraExplorerBarContainerControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrindDailyFooter_ultraOptionSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewPageType_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl3.ResumeLayout(false);
            this.ultraExplorerBarContainerControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintOder_tComboEditor)).EndInit();
            this.ultraExplorerBarContainerControl1.ResumeLayout(false);
            this.ultraExplorerBarContainerControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_PartySalesSlipNum_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNoEd_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSlipNoSt_Nedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakeShowDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebitN_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_StockAgentCode_St)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_Ed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd_St)).EndInit();
            this.MAHNB02020UA_Fill_Panel.ResumeLayout(false);
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
		private string _enterpriseCode = "";

		private bool _printButtonEnabled = true;
		private bool _extraButtonEnabled = false;
		private bool _pdfButtonEnabled = true;
		private bool _printButtonVisibled = true;
		private bool _extraButtonVisibled = false;
		private bool _pdfButtonVisibled = true;
		private bool _visibledSelectAddUpCd = false;	// �v�㋒�_�I��\���擾

		private int _selectedAddUpCd;

		private string _SalesTableDataTable;

		private Employee _loginWorker = null;

		// �����_�R�[�h
		private string _ownSectionCode = "";

		private ExtrInfo_DCKOU02304E _chartExtrInfo_DCKOU02304E = null;

		// ���_�A�N�Z�X�N���X
		private static SecInfoAcs _secInfoAcs;

        // --- ADD 2008/07/01 -------------------------------->>>>>
        private static SupplierAcs _supplierAcs;
        private static EmployeeAcs _employeeAcs;
        // --- ADD 2008/07/01 --------------------------------<<<<< 

		//���t�擾���i
		DateGetAcs _dateGetAcs;

		// ����m�F�\�A�N�Z�X�N���X
		private DCKOU02306A _salesTableListAcs = null;

		private Hashtable _selectedhSectinTable = new Hashtable();
		// ���_�I�v�V�����L��
		private bool _isOptSection;
		// �{�Ћ@�\�L��
		private bool _isMainOfficeFunc;

		SortedList _salesFormalList;
		SortedList _salesSlipKindList;

		// �G�N�X�v���[���o�[�g������
		private Form _topForm = null;
		//private bool _explorerBarExpanding = false;  // DEL 2008/06/25

		private ExtrInfo_DCKOU02304E _extrInfo_DCKOU02304E = new ExtrInfo_DCKOU02304E();		//�����N���X(�O������ێ��p)
		private ExtrInfo_DCKOU02304E _chart_ExtrInfo_DCKOU02304E = new ExtrInfo_DCKOU02304E();		//�����N���X(�`���[�g���n���p)
		private DataSet _printBuffDataSet = null;

        // ADD 2009/01/15 �s��Ή�[9659]---------->>>>>
        /// <summary>�͈͎w��K�C�h�̃t�H�[�J�X����I�u�W�F�N�g�̃��X�g</summary>
        private readonly IList<GeneralRangeGuideUIController> _rangeGuideControllerList = new List<GeneralRangeGuideUIController>();
        /// <summary>
        /// �͈͎w��K�C�h�̃t�H�[�J�X����I�u�W�F�N�g�̃��X�g���擾���܂��B
        /// </summary>
        /// <value>�͈͎w��K�C�h�̃t�H�[�J�X����I�u�W�F�N�g�̃��X�g</value>
        private IList<GeneralRangeGuideUIController> RangeGuideControllerList
        {
            get { return _rangeGuideControllerList; }
        }
        // ADD 2009/01/15 �s��Ή�[9659]----------<<<<<

        // --- ADD 2009/04/14 -------------------------------->>>>>
        /// <summary>���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p</summary>
        private readonly OptionSetKeyPressEventHelper _printDailyFooterRadioKeyPressHelper = new OptionSetKeyPressEventHelper();
        /// <summary>
        /// ���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p���擾���܂��B
        /// </summary>
        /// <value>���v�󎚃��W�I�{�^����KeyPress�C�x���g�̃w���p</value>
        public OptionSetKeyPressEventHelper PrintDailyFooterRadioKeyPressHelper
        {
            get { return _printDailyFooterRadioKeyPressHelper; }
        }
        // --- ADD 2009/04/14 --------------------------------<<<<<

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g�萔
		// ===================================================================================== //
		#region private constant
		private const string EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY = "ExtraConditionCodeGroup";

		private const string THIS_ASSEMBLYID = "DCKOU02301U";
		private const string PDF_PRINT_KEY = "D086E2FA-69C3-4886-98FA-06DF7F43ACAE";
		//private const string PDF_PRINT_NAME = "���׈ꗗ�\";  // DEL 2008/06/25
        private const string PDF_PRINT_NAME = "���׊m�F�\";  // ADD 2008/06/25

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
				return _chartExtrInfo_DCKOU02304E;
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
		/// <br>Note	   : ��ʕ\�����s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public void Show(object parameter)
		{
			this.Show();
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ����������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public int Print(ref object parameter)
		{

			SFCMN06001U printDialog = new SFCMN06001U();			// ���[�I���K�C�h
			SFCMN06002C printInfo = parameter as SFCMN06002C;	  // ������p�����[�^

			// ��ƃR�[�h
			printInfo.enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			printInfo.kidopgid = THIS_ASSEMBLYID;			  // �N���o�f�h�c
			printInfo.key = PDF_PRINT_KEY;				 // PDF�����Ǘ��pKEY���

			// ��ʁ����o�����N���X
			ExtrInfo_DCKOU02304E extrInfo_DCKOU02304E = new ExtrInfo_DCKOU02304E();
			this.SetExtraInfoFromScreen(out extrInfo_DCKOU02304E);

			// ���o�����̐ݒ�
			printInfo.jyoken = extrInfo_DCKOU02304E;
			// �`���[�g�p�����ݒ�

			// �ꎞ�R�����g�A�E�g****************************START
			//// ������[�ݒ�
			//if (extrInfo_DCKOU02304E.IsDetails == false)
			//{
			//	  printInfo.PrintPaperSetCd = 1;
			//}
			//else
			//{
			//	  printInfo.PrintPaperSetCd = 0;
			//}
			//***********************************************END
			printInfo.PrintPaperSetCd = 0;

			// �f�[�^���o
			//int status = this.SearchData(extrInfo_DCKOU02304E);
			//if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			//{
			//	  this._printBuffDataSet = null;
			//	  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);

			//	  return status;
			//}

			printInfo.rdData = this._printBuffDataSet;
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
		/// <br>Note	   : ����O�̃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public bool PrintBeforeCheck()
		{
			string message;
			Control errControl = null;

			// ��ʂ͈͎̔w�荀�ڂ̓��͕⏕������ǉ�
			this.ScreenInputAssist();

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
		/// <br>Note	   : ���o�������s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public int Extract(ref object parameter)
		{
			//int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			//return status;

			//int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
			int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;

            //ShipmentListCndtn extraInfo = new ShipmentListCndtn();	   // ���o�����N���X

			//this.SetExtraInfoFromScreen(ref extraInfo);

			// �f�[�^���o
			//status = this.SearchData(extraInfo);
			//if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			//{
			//	  this._printBuffDataSet = null;
			//	  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//}
			//else if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
			//{
			//	  this._printBuffDataSet = null;
			//	  TMessageBox(emErrorLevel.ERR_LEVEL_INFO, "�f�[�^�̒��o�ŃG���[���������܂���", 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//}
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
				return PDF_PRINT_KEY;
			}
		}

		/// <summary>���[���v���p�e�B</summary>
		/// <remarks>���[�����擾���܂��B</remarks>
		public string PrintName
		{
			get
			{
				return PDF_PRINT_NAME;
			}
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
			System.Windows.Forms.Application.Run(new DCKOU02301UA());
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
		/// <br>Note	   : ������ʐݒ���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void InitialScreenSetting()
		{
            #region < ���t�͈� >
            int nowLongDate = TDateTime.DateTimeToLongDate(DateTime.Now);
			//���͓�
			this.InputDaySt_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
			this.InputDayEd_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			this.InputDaySt_tDateEdit.SetLongDate(nowLongDate);
			this.InputDayEd_tDateEdit.SetLongDate(nowLongDate);
               --- DEL 2008/06/25 --------------------------------<<<<< */

			//���ד�
			this.ArrivalGoodsDaySt_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
			this.ArrivalGoodsDayEd_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
            // --- ADD 2008/06/25 -------------------------------->>>>>
			this.ArrivalGoodsDaySt_tDateEdit.SetLongDate(nowLongDate);
			this.ArrivalGoodsDayEd_tDateEdit.SetLongDate(nowLongDate);
            // --- ADD 2008/06/25 --------------------------------<<<<< 

			#endregion

            // --- ADD 2009/04/08 -------------------------------->>>>>
            #region < ���� >
            this.NewPageType_tComboEditor.Value = 0; // ���_
            #endregion

            #region < ���v�� >
            this.PrindDailyFooter_ultraOptionSet.Value = 0; // ���Ȃ�
            #endregion
            // --- ADD 2009/04/08 --------------------------------<<<<<

			#region < �o�͏��ݒ� >
			this.PrintOder_tComboEditor.Value = 0;
			#endregion

			#region < �`�[�敪 >
			this.SlipDiv_tComboEditor.Value = 2;
			#endregion

			#region < �ԓ`�敪 >
			this.DebitN_tComboEditor.Value = 0;
			#endregion


			#region < ��\�敪 >
            /* --- DEL 2008/09/26 �u�S�āv���f�t�H���g�Ƃ���� -------------------------------------->>>>>
			//2008.01.28 A.Mabuchi START//////////////////////////////////////////////////////////////////
			//this.MakeShowDiv_ultraOptionSet.CheckedIndex = 0;
			this.MakeShowDiv_tComboEditor.Value = 1;
			//2008.01.28 A.Mabuchi END////////////////////////////////////////////////////////////////////
               --- DEL 2008/09/26 ------------------------------------------------------------------->>>>> */
            // --- ADD 2008/09/26 ------------------------------------------------------------------->>>>>
            this.MakeShowDiv_tComboEditor.Value = 0;    // �u�S�āv
            // --- ADD 2008/09/26 -------------------------------------------------------------------<<<<<
            #endregion

            #region < �����l�ݒ� >
            // �d����R�[�h�����l�ݒ�
			//this.CustomerCodeSt_Nedit.SetInt(0);
			//this.CustomerCodeEd_Nedit.SetInt(999999999);
			#endregion
            

			#region < �K�C�h�{�^���̃A�C�R���ݒ� >
            CustomerCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			CustomerCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			CustomerCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			CustomerCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			StockInputCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			StockInputCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			StockInputCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			StockInputCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
               --- DEL 2008/06/25 --------------------------------<<<<< */
			StockAgentCdSt_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			StockAgentCdSt_GuideBtn.Appearance.Image = Size16_Index.STAR1;
			StockAgentCdEd_GuideBtn.ImageList = IconResourceManagement.ImageList16;
			StockAgentCdEd_GuideBtn.Appearance.Image = Size16_Index.STAR1;
            #endregion

            // --- ADD 2008/09/26 ------------------------------->>>>>
            // ��\�� ����ʃ��[�h���Ɉ�u������ׁA�v���p�e�B�𒼐�False�ɂ��Ă���
                // �u�ԓ`�敪�v�^�C�g��
                // �u�ԓ`�敪�v�R���{�{�b�N�X
            // �K�{�F
            //this.ArrivalGoodsDaySt_tDateEdit.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);  // ���ד�From // DEL 2009/04/07
            //this.ArrivalGoodsDayEd_tDateEdit.EditAppearance.BackColor = Color.FromArgb(179, 219, 231);  // ���ד�To // DEL 2009/04/07
            this.NewPageType_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);         // ���� // ADD 2009/04/08
            this.PrintOder_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);           // �o�͏�
            this.SlipDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);             // �`�[�敪
            this.MakeShowDiv_tComboEditor.Appearance.BackColor = Color.FromArgb(179, 219, 231);         // ��\�敪
            // --- ADD 2008/09/26 -------------------------------<<<<<

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
		/// <remarks>
		/// <br>Note: ���ʕ��i�ɂ����t�͈͂̃`�F�b�N���s���܂��B</br>
		/// </remarks>
		private bool CheckPeriod(DateTime startDate, DateTime endDate, int i)
		{
			Enum _checkP = this._dateGetAcs.CheckPeriod(DateGetAcs.YmdType.YearMonth, 1, DateGetAcs.YmdType.YearMonthDay, startDate, endDate);

			string str_cP = _checkP.ToString();

			if (i == 1)
			{
				if (str_cP == "ErrorOfReverse" || str_cP == "ErrorOfRangeOver")
				{
					return false;
				}
				else
				{
					return true;
				}

			}
			else
			{	//���ד��t�͔͈͂�1�����𒴂��Ă��G���[�ɂ��Ȃ�
				if (str_cP == "ErrorOfReverse")
				{
					return false;
				}
				else
				{
					return true;
				}
			}

		}
		
		/// <summary>
		/// ��ʓ��̓`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private bool ScreenInputCheack(out string message, ref Control errControl)
		{
			message = "";
			bool result = false;
			errControl = null;

            #region
			//< ������t(�J�n) >
            //if (!InputDateEditCheack(this.SalesDateSt_tDateEdit))
			//{
			//	message = "������t�̎w��Ɍ�肪����܂�";
			//	errControl = this.SalesDateSt_tDateEdit;
			//	return result;
            //}
            
            //< ������t(�I��) >
            //if (!InputDateEditCheack(this.SalesDateEd_tDateEdit))
			//{
			//	message = "������t�̎w��Ɍ�肪����܂�";
			//	errControl = this.SalesDateEd_tDateEdit;
			//	return result;
			//}
            #endregion

            // DEL 2009/01/15 �s��Ή�[9658] ---------->>>>>
            #region �폜�R�[�h
            //// --- ADD 2008/06/25 -------------------------------->>>>>
            //int checkDateRange;

            //checkDateRange = (int)this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref this.ArrivalGoodsDaySt_tDateEdit, ref this.ArrivalGoodsDayEd_tDateEdit, false);

            //switch (checkDateRange)
            //{
            //    case (int)DateGetAcs.CheckDateRangeResult.OK:

            //        break;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:

            //        message = "���ד���3�����͈͓̔��œ��͂��Ă�������";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfReverse:

            //        message = "���ד��͈̔͂Ɍ�肪����܂�";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:

            //        message = "���ד��̎w��Ɍ�肪����܂�";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:

            //        message = "���ד��̎w��Ɍ�肪����܂�";
            //        errControl = this.ArrivalGoodsDayEd_tDateEdit;
            //        return result;

            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
            //    case (int)DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:

            //        // ���肦�Ȃ��B

            //        break;  
            //}
            //// --- ADD 2008/06/25 --------------------------------<<<<<
            #endregion
            // DEL 2009/01/15 �s��Ή�[9658] ----------<<<<<

            // --- DEL 2008/06/25 -------------------------------->>>>>
            #region �폜�R�[�h
            ////���ד��͉������͂���Ă����������`�F�b�N
            //if (ArrivalGoodsDaySt_tDateEdit.GetLongDate() != 0 || ArrivalGoodsDayEd_tDateEdit.GetLongDate() != 0)  // DEL 2008/06/25
            //{
            //    // ���ד�(�J�n)
            //    if (!CheckDate(this.ArrivalGoodsDaySt_tDateEdit))
            //    {
            //        message = "���ד��̎w��Ɍ�肪����܂�";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;
            //    }

            //    // ���ד�(�I��)
            //    if (!CheckDate(this.ArrivalGoodsDayEd_tDateEdit))
            //    {
            //        message = "���ד��̎w��Ɍ�肪����܂�";
            //        errControl = this.ArrivalGoodsDayEd_tDateEdit;
            //        return result;
            //    }

            //    DateTime dt_ShipmentDaySt = DateTime.ParseExact(this.ArrivalGoodsDaySt_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);
            //    DateTime dt_ShipmentDayEd = DateTime.ParseExact(this.ArrivalGoodsDayEd_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);

            //    // ���ד��͈̓`�F�b�N
            //    if (!CheckPeriod(dt_ShipmentDaySt, dt_ShipmentDayEd, 2))
            //    {
            //        message = "���ד��͈̔͂Ɍ�肪����܂�";
            //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
            //        return result;
            //    }
            //}
            #endregion
            // --- DEL 2008/06/25 --------------------------------<<<<<

            // ADD 2009/01/15 �s��Ή�[9658] ���d���m�F�\���ڐA ---------->>>>>
            // �G���[�������b�Z�[�W
            const string MSG_INPUT_ERROR        = "�̓��͂��s���ł�";
            //const string MSG_NO_INPUT           = "����͂��ĉ�����"; // DEL 2009/04/07
            const string MSG_RANGE_ERROR        = "�͈͎̔w��Ɍ�肪����܂�";
            //const string MSG_RANGE_OVER_ERROR   = "�͂R�����͈͓̔��œ��͂��ĉ�����"; // DEL 2009/04/07

            DateGetAcs.CheckDateRangeResult cdrResult;

            // ���ד��i�J�n�`�I���j
            //if (!CallCheckDateRange(
            //    out cdrResult,
            //    ref this.ArrivalGoodsDaySt_tDateEdit,
            //    ref this.ArrivalGoodsDayEd_tDateEdit,
            //    false,
            //    3
            //)) // DEL 2009/04/07
            if (!CallCheckDateRange(
                out cdrResult,
                ref this.ArrivalGoodsDaySt_tDateEdit,
                ref this.ArrivalGoodsDayEd_tDateEdit,
                true,
                0
            )) // ADD 2009/04/07
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    {
                    //        message = string.Format("�J�n���ד�{0}", MSG_NO_INPUT);
                    //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("�J�n���ד�{0}", MSG_INPUT_ERROR);
                            errControl = this.ArrivalGoodsDaySt_tDateEdit;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    {
                    //        message = string.Format("�I�����ד�{0}", MSG_NO_INPUT);
                    //        errControl = this.ArrivalGoodsDayEd_tDateEdit;
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("�I�����ד�{0}", MSG_INPUT_ERROR);
                            errControl = this.ArrivalGoodsDayEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("���ד�{0}", MSG_RANGE_ERROR);
                            errControl = this.ArrivalGoodsDaySt_tDateEdit;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        message = string.Format("���ד�{0}", MSG_RANGE_OVER_ERROR);
                    //        errControl = this.ArrivalGoodsDaySt_tDateEdit;
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                }
                result = false;
                return result;
            }
            // ADD 2009/01/15 �s��Ή�[9658] ���d���m�F�\���ڐA ----------<<<<<

            // DEL 2009/01/15 �s��Ή�[9658] ---------->>>>>
            #region �폜�R�[�h
            //// --- ADD 2008/06/25 -------------------------------->>>>>
            ////���͓��͉������͂���Ă����������`�F�b�N
            //if (InputDaySt_tDateEdit.GetLongDate() != 0 || InputDayEd_tDateEdit.GetLongDate() != 0)  
            //{
            //    checkDateRange = (int)this._dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref this.InputDaySt_tDateEdit, ref this.InputDayEd_tDateEdit, false);

            //    switch (checkDateRange)
            //    {
            //        case (int)DateGetAcs.CheckDateRangeResult.OK:
            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:

            //            // �͈̓`�F�b�N�̓G���[�ɂ��Ȃ�

            //            break;

            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfReverse:

            //            message = "���͓��͈̔͂Ɍ�肪����܂�";
            //            errControl = this.InputDaySt_tDateEdit;
            //            return result;

            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:

            //            message = "���͓��̎w��Ɍ�肪����܂�";
            //            errControl = this.InputDaySt_tDateEdit;
            //            return result;

            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:

            //            message = "���͓��̎w��Ɍ�肪����܂�";
            //            errControl = this.InputDayEd_tDateEdit;
            //            return result;

            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfNotOnYear:
            //        case (int)DateGetAcs.CheckDateRangeResult.ErrorOfNotOnMonth:

            //            // ���肦�Ȃ��B

            //            break;
            //    }
            //}
            //// --- ADD 2008/06/25 --------------------------------<<<<<
            #endregion
            // DEL 2009/01/15 �s��Ή�[9658] ----------<<<<<

            // --- DEL 2008/06/25 -------------------------------->>>>>
            #region �폜�R�[�h
            //// ���͓�(�J�n)
            //if (!CheckDate(this.InputDaySt_tDateEdit))
            //{
            //    message = "���͓��̎w��Ɍ�肪����܂�";
            //    errControl = this.InputDaySt_tDateEdit;
            //    return result;
            //}

            //// ���͓�(�I��)
            //if (!CheckDate(this.InputDayEd_tDateEdit))
            //{
            //    message = "���͓��̎w��Ɍ�肪����܂�";
            //    errControl = this.InputDayEd_tDateEdit;
            //    return result;
            //}

            //DateTime dt_InputDaySt = DateTime.ParseExact(this.InputDaySt_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);
            //DateTime dt_InputDayEd = DateTime.ParseExact(this.InputDayEd_tDateEdit.LongDate.ToString(), "yyyyMMdd", null);

            //// ���͓��͈̓`�F�b�N
            //if (!CheckPeriod(dt_InputDaySt, dt_InputDayEd, 1))
            //{
            //    message = "���͓���1�����͈͓̔��œ��͂��Ă�������";
            //    errControl = this.InputDaySt_tDateEdit;
            //    return result;
            //}
            #endregion
            // --- DEL 2008/06/25 --------------------------------<<<<<

            // ADD 2009/01/15 �s��Ή�[9657] ���d���m�F�\���ڐA ---------->>>>>
            // ���͓��i�J�n�`�I���j
            if (!CallCheckInputDateRange(
                out cdrResult,
                ref this.InputDaySt_tDateEdit,
                ref this.InputDayEd_tDateEdit,
                true,
                3
            ))
            {
                switch (cdrResult)
                {
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                    //    return true;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            message = string.Format("�J�n���͓�{0}", MSG_INPUT_ERROR);
                            errControl = this.InputDaySt_tDateEdit;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                    //    return true;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            message = string.Format("�I�����͓�{0}", MSG_INPUT_ERROR);
                            errControl = this.InputDayEd_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            message = string.Format("���͓�{0}", MSG_RANGE_ERROR);
                            errControl = this.InputDaySt_tDateEdit;
                        }
                        break;
                    // --- DEL 2009/04/07 -------------------------------->>>>>
                    //case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                    //    {
                    //        message = string.Format("���͓�{0}", MSG_RANGE_OVER_ERROR);
                    //        errControl = this.InputDaySt_tDateEdit;
                    //    }
                    //    break;
                    // --- DEL 2009/04/07 --------------------------------<<<<<
                }
                result = false;
                return result;
            }
            // ADD 2009/01/15 �s��Ή�[9657] ���d���m�F�\���ڐA ----------<<<<<

            #region < �d����R�[�h�͈̓`�F�b�N >
            if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") && (this.tNedit_SupplierCd_Ed.DataText.Trim() != ""))  // ADD 2008/06/25
            {
                if ((this.tNedit_SupplierCd_St.GetInt()) > (this.tNedit_SupplierCd_Ed.GetInt()))
			    {
				    message = "�d����͈̔͂Ɍ�肪����܂�";
				    errControl = this.tNedit_SupplierCd_St;
				    return result;
                }
            }

            #endregion

            // --- DEL 2008/06/25 -------------------------------->>>>>
            #region �폜�R�[�h
            //#region < ���͏]�ƈ��R�[�h�͈̓`�F�b�N >
            //if (this.StockInputCdSt_tEdit.DataText.CompareTo(this.StockInputCdEd_tEdit.DataText) > 0 )
            //{
            //    message = "���͎҂͈̔͂Ɍ�肪����܂�";
            //    errControl = this.StockInputCdSt_tEdit;
            //    return result;
            //}
            //#endregion
            #endregion
            // --- DEL 2008/06/25 --------------------------------<<<<<

            #region < �S���҃R�[�h�͈̓`�F�b�N >
            if ((this.tEdit_StockAgentCode_St.DataText.Trim() != "") && (this.tEdit_StockAgentCode_Ed.DataText.Trim() != ""))  // ADD 2008/06/25
            {
                //if (this.tEdit_StockAgentCode_St.DataText.CompareTo(this.tEdit_StockAgentCode_Ed.DataText) > 0)             // DEL 2008/06/25
                if (Int32.Parse(this.tEdit_StockAgentCode_St.DataText) > Int32.Parse(this.tEdit_StockAgentCode_Ed.DataText))  // ADD 2008/06/25
                {
                    message = "�S���҂͈̔͂Ɍ�肪����܂�";
                    errControl = this.tEdit_StockAgentCode_St;
                    return result;
                }
            }
            #endregion

            #region < �`�[�ԍ��͈̓`�F�b�N >
            //// �`�[�ԍ��͈̓`�F�b�N
            //if ((this.AcceptAnOrderNoSt_tNedit.GetInt()) > (this.AcceptAnOrderNoEd_tNedit.GetInt()))
            //{
            //    message = "�`�[�ԍ��͈̔͂Ɍ�肪����܂�";
            //    errControl = this.AcceptAnOrderNoSt_tNedit;
            //    return result;
            //}
            // �d���`�[�ԍ��͈̓`�F�b�N
            if ((this.SupplierSlipNoSt_Nedit.DataText.Trim() != "") && (this.SupplierSlipNoEd_Nedit.DataText.Trim() != ""))  // ADD 2008/06/25
            {
                if (this.SupplierSlipNoSt_Nedit.DataText.CompareTo(this.SupplierSlipNoEd_Nedit.DataText) > 0)
                {
                    //message = "�`�[�ԍ��͈̔͂Ɍ�肪����܂�"; // DEL 2009/04/08
                    message = "�d��SEQ�ԍ��͈̔͂Ɍ�肪����܂�"; // ADD 2009/04/08
                    errControl = this.SupplierSlipNoSt_Nedit;
                    return result;
                }
                if ((this.SupplierSlipNoSt_Nedit.GetInt()) > (this.SupplierSlipNoEd_Nedit.GetInt()))
                {
                    //message = "�`�[�ԍ��͈̔͂Ɍ�肪����܂�"; // DEL 2009/04/08
                    message = "�d��SEQ�ԍ��͈̔͂Ɍ�肪����܂�"; // ADD 2009/04/08
                    errControl = this.SupplierSlipNoSt_Nedit;
                    return result;
                }
            }

            #endregion

            return true;
		}

        // ADD 2009/01/15 �s��Ή�[9658] ---------->>>>>
        // HACK:2009/01/15
        /// <summary>
        /// ���ד��`�F�b�N�����Ăяo��
        /// </summary>
        /// <remarks>
        /// �d���m�F�\���ڐA
        /// </remarks>
        /// <param name="cdrResult"></param>
        /// <param name="startTDateEdit"></param>
        /// <param name="tde_Ed_OrderDataCreateDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit startTDateEdit,
            ref TDateEdit endTDateEdit,
            bool mode,
            int range
        )
        {
            cdrResult = DateGetAcs.GetInstance().CheckDateRange(
                DateGetAcs.YmdType.YearMonth,
                range,
                ref startTDateEdit,
                ref endTDateEdit,
                mode,
                false
            );
            if (startTDateEdit.Name.Equals("InputDaySt_tDateEdit"))
            {
                if (cdrResult.Equals(DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver))
                {
                    cdrResult = DateGetAcs.CheckDateRangeResult.OK;
                }
            }

            // --- ADD 2009/04/07 -------------------------------->>>>>
            // ���ד���C�ӂɂ��邽�߁A�����͂�OK�ɂ���
            if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput
                || cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput)
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<

            return cdrResult.Equals(DateGetAcs.CheckDateRangeResult.OK);
        }
        // ADD 2009/01/15 �s��Ή�[9658] ----------<<<<<

        // ADD 2008/01/15 �s��Ή�[9657] ---------->>>>>
        /// <summary>
        /// ���͓��t�`�F�b�N�����Ăяo��(�͈̓`�F�b�N�Ȃ��A������OK)
        /// </summary>
        /// <remarks>
        /// �d���m�F�\���ڐA
        /// </remarks>
        /// <param name="cdrResult">�`�F�b�N����</param>
        /// <param name="startTDateEdit">���͓��i�J�n�j</param>
        /// <param name="tde_Ed_AddUpADate">���͓��i�I���j</param>
        /// <param name="mode">���[�h</param>
        /// <param name="range">�͈�</param>
        /// <returns><c>true</c> :OK<br/><c>false</c>:NG</returns>
        private bool CallCheckInputDateRange(
            out DateGetAcs.CheckDateRangeResult cdrResult,
            ref TDateEdit startTDateEdit,
            ref TDateEdit endTDateEdit,
            bool mode,
            int range
        )
        {
            cdrResult = DateGetAcs.GetInstance().CheckDateRange(
                DateGetAcs.YmdType.YearMonth,
                0,
                ref startTDateEdit,
                ref endTDateEdit,
                true
            );

            // --- ADD 2009/04/07 -------------------------------->>>>>
            // ���͓���C�ӂɂ��邽�߁A�����͂�OK�ɂ���
            if (cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput
                || cdrResult == DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput)
            {
                cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            }
            // --- ADD 2009/04/07 --------------------------------<<<<<

            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        // ADD 2008/01/15 �s��Ή�[9657] ----------<<<<<

		/// <summary>
		/// ��ʓ��͕⏕����
		/// </summary>
		/// <remarks>
		/// <br>Note	   : ��ʂ͈͎̔w��̓��͕⏕���s���܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void ScreenInputAssist()
        {
            /* --- DEL 2008/09/26 �R�s�[���s��Ȃ��� --------------------------------------------->>>>>
            #region < ���͓��t >
            if (this.InputDaySt_tDateEdit.LongDate != 0 && this.InputDayEd_tDateEdit.LongDate == 0)
			{
				this.InputDayEd_tDateEdit.SetLongDate(this.InputDaySt_tDateEdit.LongDate);
            }
            #endregion
               --- DEL 2008/09/26 ----------------------------------------------------------------<<<<< */

            // DEL 2009/01/15 �s��Ή�[9658] ---------->>>>>
            //#region < ���ד��t >
            //if (this.ArrivalGoodsDaySt_tDateEdit.LongDate != 0 && this.ArrivalGoodsDayEd_tDateEdit.LongDate == 0)
            //{
            //    this.ArrivalGoodsDayEd_tDateEdit.SetLongDate(this.ArrivalGoodsDaySt_tDateEdit.LongDate);
            //}
            //#endregion
            // DEL 2009/01/15 �s��Ή�[9658] ----------<<<<<

            #region < �`�[�ԍ� >
            // �`�[�ԍ�
            //if (this.SalesSlipNumSt_tEdit.DataText != "" && this.SalesSlipNumEd_tEdit.DataText == "")
            //{
            //    this.SalesSlipNumEd_tEdit.DataText = this.SalesSlipNumSt_tEdit.DataText;
            //}
            #endregion

            #region < �d����R�[�h >
            //if (this.CustomerCodeSt_Nedit.DataText != "" && this.CustomerCodeEd_Nedit.DataText == "")
			//{
			//	this.CustomerCodeEd_Nedit.DataText = this.CustomerCodeSt_Nedit.DataText;
            //}
			//if (this.CustomerCodeSt_Nedit.GetInt() == 0)
			//{
			//    this.CustomerCodeSt_Nedit.SetInt(0);
			//}
			//if (this.CustomerCodeEd_Nedit.GetInt() == 0)
			//{
			//    this.CustomerCodeEd_Nedit.SetInt(999999999);
			//}
            #endregion

            #region < ���͏]�ƈ��R�[�h >
            //if (this.SalesInputCodeSt_tEdit.DataText != "" && this.SalesInputCodeEd_tEdit.DataText == "")
			//{
			//	this.SalesInputCodeEd_tEdit.DataText = this.SalesInputCodeSt_tEdit.DataText;
            //}
            #endregion

            #region < �S���҃R�[�h >
            //if (this.SalesEmployeeCdSt_tEdit.DataText != "" && this.SalesEmployeeCdEd_tEdit.DataText == "")
			//{
			//	this.SalesEmployeeCdEd_tEdit.DataText = this.SalesEmployeeCdSt_tEdit.DataText;
            //}
            #endregion
        }

		/// <summary>
		///
		/// </summary>
		/// <param name="extraInfo"></param>
		/// <returns></returns>
		private int SearchData(ExtrInfo_DCKOU02304E extraInfo)
		{
			string message;
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ���o�������ς���Ă���Ȃ烊���[�e�B���O
			if (this._printBuffDataSet == null || this._extrInfo_DCKOU02304E == null || !this._extrInfo_DCKOU02304E.Equals(extraInfo))
			{
				try
				{
					status = this._salesTableListAcs.Search(extraInfo, out message, 0);
					if (status == 0)
					{
						this._printBuffDataSet = this._salesTableListAcs._printDataSet;
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
							this._extrInfo_DCKOU02304E = extraInfo.Clone();

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
				if (this._printBuffDataSet == null || this._printBuffDataSet.Tables[_SalesTableDataTable].Rows.Count == 0)
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
		/// <br>Note	   : ��ʁ����o�����֐ݒ肵�܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private void SetExtraInfoFromScreen(out ExtrInfo_DCKOU02304E extraInfo)
		{
			extraInfo = new ExtrInfo_DCKOU02304E();

            #region < ��ƃR�[�h >
            extraInfo.EnterpriseCode = this._enterpriseCode;
            #endregion

            #region < �I�����_ >
            // ���_�I�v�V��������̂Ƃ�
			if (IsOptSection)
			{
				ArrayList secList = new ArrayList();
				// �S�БI�����ǂ���
				if ((this._selectedhSectinTable.Count == 1) && (this._selectedhSectinTable.ContainsKey("0")))
				{
					
					//A�N���XSearchParaSet()�Łg�S�Ђ̏ꍇ�h��if���ɓ��邽�߂̏���
					extraInfo.SectionCodes = new string[1];
					extraInfo.SectionCodes[0] = "0";
				
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
					extraInfo.SectionCodes = (string[])secList.ToArray(typeof(string));
                }
			}
			// ���_�I�v�V�����Ȃ��̎�
			else
			{
				extraInfo.SectionCodes = new string[0];
				extraInfo.SectionCodes[0] = "0";
			}
            #endregion

            #region < ���ד��t >
            // ���ד��t(�J�n)
			extraInfo.ArrivalGoodsDaySt = this.ArrivalGoodsDaySt_tDateEdit.GetLongDate();
			// ���ד��t(�I��)
			extraInfo.ArrivalGoodsDayEd = this.ArrivalGoodsDayEd_tDateEdit.GetLongDate();
            #endregion

			#region < ���͓��t >
			// ���͓��t(�J�n)
			extraInfo.InputDaySt = this.InputDaySt_tDateEdit.GetLongDate();
			// ���͓��t(�I��)
			extraInfo.InputDayEd = this.InputDayEd_tDateEdit.GetLongDate();

			#endregion

            // --- ADD 2009/04/08 -------------------------------->>>>>
            #region < ���� >
            extraInfo.NewPageDiv = Convert.ToInt32(this.NewPageType_tComboEditor.SelectedItem.DataValue);
            #endregion

            #region < ���v�� >
            extraInfo.PrintDailyFooter = Convert.ToInt32(this.PrindDailyFooter_ultraOptionSet.CheckedItem.DataValue);
            #endregion

            // --- ADD 2009/04/08 --------------------------------<<<<<

			#region < �o�͏� >
            extraInfo.SortOrder = Convert.ToInt32(this.PrintOder_tComboEditor.SelectedItem.DataValue);
            #endregion

            #region < �d���� >
            /* --- DEL 2008/06/25 -------------------------------->>>>>
            // �d����(�J�n)
			extraInfo.CustomerCodeSt = this.CustomerCodeSt_Nedit.GetInt();
			// �d����(�I��)
			extraInfo.CustomerCodeEd = this.CustomerCodeEd_Nedit.GetInt();
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            // �d����(�J�n)
            extraInfo.SupplierCdSt = this.tNedit_SupplierCd_St.GetInt();
            // �d����(�I��)
            extraInfo.SupplierCdEd = this.tNedit_SupplierCd_Ed.GetInt();
            // --- ADD 2008/06/25 --------------------------------<<<<< 
            #endregion

			#region < ���͎ҥ�S���� >
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			// ���͏]�ƈ��R�[�h(�J�n)
			extraInfo.StockInputCodeSt = this.StockInputCdSt_tEdit.Text;
			// ���͏]�ƈ��R�[�h(�I��)
			extraInfo.StockInputCodeEd = this.StockInputCdEd_tEdit.Text;
               --- DEL 2008/06/25 --------------------------------<<<<< */
            /* --- DEL 2008/09/26 �S���҂���t�H�[�J�X�ړ�����PDF�{�^���������A�S���҂��[���l�߂���Ȃ��� --->>>>>
			// �S���҃R�[�h(�J�n)
			extraInfo.StockAgentCodeSt = this.tEdit_StockAgentCode_St.Text;
            // �S���҃R�[�h(�I��)
            extraInfo.StockAgentCodeEd = this.tEdit_StockAgentCode_Ed.Text;
               --- DEL 2008/09/26 ---------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/09/26 --------------------------------------------------------------------------->>>>>
            if (string.IsNullOrEmpty(this.tEdit_StockAgentCode_St.Text))
            {
                extraInfo.StockAgentCodeSt = this.tEdit_StockAgentCode_St.Text;
            }
            else
            {
                extraInfo.StockAgentCodeSt = this.tEdit_StockAgentCode_St.Text.PadLeft(4, '0');
            }
            if (string.IsNullOrEmpty(this.tEdit_StockAgentCode_Ed.Text))
            {
                extraInfo.StockAgentCodeEd = this.tEdit_StockAgentCode_Ed.Text;
            }
            else
            {
                extraInfo.StockAgentCodeEd = this.tEdit_StockAgentCode_Ed.Text.PadLeft(4,'0');
            }
            // --- ADD 2008/09/26 ---------------------------------------------------------------------------<<<<<

			#endregion
			
			#region < �`�[�ԍ� >
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2007.05.31 T-Kidate START
			//// �`�[�ԍ�(�J�n)
			//extraInfo.AcceptAnOrderNoSt = this.AcceptAnOrderNoSt_tNedit.GetInt();
			//// �`�[�ԍ�(�I��)
			//extraInfo.AcceptAnOrderNoEd = this.AcceptAnOrderNoEd_tNedit.GetInt();
			// �d���`�[�ԍ�(�J�n)
            extraInfo.SupplierSlipNoSt = this.SupplierSlipNoSt_Nedit.GetInt();
            // �d���`�[�ԍ�(�I��)
            extraInfo.SupplierSlipNoEd = this.SupplierSlipNoEd_Nedit.GetInt();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2007.05.31 T-Kidate END
			#endregion

            // --- ADD 2009/04/08 -------------------------------->>>>>
            #region < �����`�[�ԍ� >
            extraInfo.PartySalesSlipNumSt = this.tEdit_PartySalesSlipNum_St.DataText;
            extraInfo.PartySalesSlipNumEd = this.tEdit_PartySalesSlipNum_Ed.DataText;
            #endregion
            // --- ADD 2009/04/08 --------------------------------<<<<<
			
			#region < �`�[�敪 >
            // �`�[�敪
			extraInfo.SlipDiv = Convert.ToInt32(this.SlipDiv_tComboEditor.SelectedItem.DataValue);
            extraInfo.SlipDivName = this.SlipDiv_tComboEditor.SelectedItem.DisplayText;
            #endregion

            /* --- DEL 2008/09/26 �ԓ`�敪�폜�̈� -------------------------------------------------------->>>>>
			#region < �ԓ`�敪 >
			// �ԓ`�敪
			extraInfo.DebitNoteDiv = Convert.ToInt32(this.DebitN_tComboEditor.SelectedItem.DataValue);
			extraInfo.DebitNoteDivName = this.DebitN_tComboEditor.SelectedItem.DisplayText;
			#endregion
               --- DEL 2008/09/26 -------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/09/26 ------------------------------------------------------------------------->>>>>
            extraInfo.DebitNoteDiv = 3;                     // �u�S�āv�Œ�
            extraInfo.DebitNoteDivName = string.Empty;
            // --- ADD 2008/09/26 -------------------------------------------------------------------------<<<<<

            #region < ��\�敪 >
            extraInfo.MakeShowDiv = Convert.ToInt32(this.MakeShowDiv_tComboEditor.SelectedItem.DataValue);
			extraInfo.MakeShowDivName = MakeShowDiv_tComboEditor.SelectedItem.DisplayText;
			#endregion

		}

		/// <summary>
		/// �N�����[�h���f�[�^�e�[�u���ݒ�
		/// </summary>
		private void SettingDataTable()
		{
			_SalesTableDataTable = Broadleaf.Application.UIData.DCKOU02305EA.ct_Tbl_ArrivalDtl;
		}

		/// <summary>
		/// �ŏ�ʃt�H�[���擾
		/// </summary>
		/// <remarks>
		/// <br>Note		: </br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date	    : 2007.10.19</br>
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
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			if (this._topForm == null) return;

			if (this._topForm.Height > CT_TOPFORM_BASE_HEIGHT)
			{
				// �g�b�v�t�H�[���̍�������l��荂���ꍇ
				this._explorerBarExpanding = true;
				try
				{
					//this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = true;
				}
				finally
				{
					this._explorerBarExpanding = false;
				}
			}
			else
			{
				// �g�b�v�t�H�[���̍�������l���Ⴂ�ꍇ
				this._explorerBarExpanding = true;
				try
				{
					//this.Main_ultraExplorerBar.Groups[EXPLORERBAR_EXTRACONDITIONCODEGROUP_KEY].Expanded = false;
				}
				finally
				{
					this._explorerBarExpanding = false;
				}
			}
               --- DEL 2008/06/25 --------------------------------<<<<< */
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
		/// <br>Note	   : �G���[���b�Z�[�W��\�����܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, this.Name, iMsg, iSt, iButton, iDefButton);
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

		#endregion

        #region internal methods
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
		/// <br>Note		: ��ʂ����[�h���ꂽ�ہA��������C�x���g�ł��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date	    : 2007.10.19</br>
        /// </remarks>
		private void SFUKK01390UA_Load(object sender, System.EventArgs e)
		{
			this.SettingDataTable();
			this._salesTableListAcs = new DCKOU02306A();

			// �ŏ�ʃt�H�[���擾
			this.GetTopForm();

			// ���_�I�v�V�����L�����擾����
			this._isOptSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

			// �{��/���_�����擾����
			this._isMainOfficeFunc = this.GetMainOfficeFunc();

            // ADD 2009/01/15 �s��Ή�[9659]---------->>>>>
            // �d����F�J�n
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_St,
                this.CustomerCdSt_GuideBtn,
                this.tNedit_SupplierCd_Ed
            ));
            // �d����F�I��
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tNedit_SupplierCd_Ed,
                this.CustomerCdEd_GuideBtn,
                this.tEdit_StockAgentCode_St
            ));

            // �S���ҁF�J�n
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_StockAgentCode_St,
                this.StockAgentCdSt_GuideBtn,
                this.tEdit_StockAgentCode_Ed
            ));
            // �S���ҁF�I��
            RangeGuideControllerList.Add(new GeneralRangeGuideUIController(
                this.tEdit_StockAgentCode_Ed,
                this.StockAgentCdEd_GuideBtn,
                this.SupplierSlipNoSt_Nedit
            ));

            foreach (GeneralRangeGuideUIController rangeGuideController in RangeGuideControllerList)
            {
                rangeGuideController.StartControl();
            }
            // ADD 2009/01/15 �s��Ή�[9659]----------<<<<<

            // --- ADD 2009/04/14 -------------------------------->>>>>
            PrintDailyFooterRadioKeyPressHelper.ControlList.Add(this.PrindDailyFooter_ultraOptionSet);
            PrintDailyFooterRadioKeyPressHelper.StartSpaceKeyControl();
            // --- ADD 2009/04/14 --------------------------------<<<<<

			this.Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// ��ʃA�N�e�B�u�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note	   : �������C����ʂ��A�N�e�B�u�ɂȂ����Ƃ��̃C�x���g�����ł��B</br>
		/// <br>Programer  : 18012�@Y.Sasaki</br>
		/// <br>Date	   : 2005.09.12</br>
		/// </remarks>
		private void SFUKK01390UA_Activated(object sender, System.EventArgs e)
		{
			ParentToolbarSettingEvent(this);
		}

		/// <summary>
		/// tArrowKey �� tRetKey �C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note	   : �R���g���[���ŃL�[��������ăt�H�[�J�X�ړ������Ƃ��̃C�x���g�����ł��B</br>
		/// <br>Programer  : 30005�@�،��@��</br>
		/// <br>Date	   : 2007.04.03</br>
		/// </remarks>
		private void tKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			// ���͎x�� ============================================ //
            /* --- DEL 2008/09/26 �I���ւ̃R�s�[���s��Ȃ��� --------------------------------------->>>>>
			// ���͓�
			if ((e.PrevCtrl == this.InputDaySt_tDateEdit) ||
				(e.PrevCtrl == this.InputDayEd_tDateEdit))
			{
				AutoSetEndValue(this.InputDaySt_tDateEdit, this.InputDayEd_tDateEdit);
			}
               --- DEL 2008/09/26 ------------------------------------------------------------------<<<<< */
            // ����`�[�ԍ�
            //if ((e.PrevCtrl == this.SalesSlipNumSt_tEdit) ||
            //    (e.PrevCtrl == this.SalesSlipNumEd_tEdit))
            //{
            //    AutoSetEndValue(this.SalesSlipNumSt_tEdit, this.SalesSlipNumEd_tEdit);
            //}

			// �d����R�[�h
			//if ((e.PrevCtrl == this.CustomerCodeSt_Nedit) ||
			//	(e.PrevCtrl == this.CustomerCodeEd_Nedit))
			//{
			//	AutoSetEndValue(this.CustomerCodeSt_Nedit, this.CustomerCodeEd_Nedit);
			//}
            
			//2008.02.01 A.Mabuchi START-----------------------------------------------------------------
			//if ((e.PrevCtrl == this.CustomerCodeSt_Nedit) && (this.CustomerCodeSt_Nedit.GetInt() == 0))
			//{
			//    this.CustomerCodeSt_Nedit.SetInt(0);
			//}
			//if ((e.PrevCtrl == this.CustomerCodeEd_Nedit) && (this.CustomerCodeEd_Nedit.GetInt() == 0))
			//{
			//    this.CustomerCodeEd_Nedit.SetInt(999999999);
			//}
			//2008.02.01 A.Mabuchi START-----------------------------------------------------------------

            // ���͏]�ƈ��R�[�h
			//if ((e.PrevCtrl == this.SalesInputCodeSt_tEdit) ||
			//	(e.PrevCtrl == this.SalesInputCodeEd_tEdit))
			//{
			//	AutoSetEndValue(this.SalesInputCodeSt_tEdit, this.SalesInputCodeEd_tEdit);
			//}

			// �S���҃R�[�h
			//if ((e.PrevCtrl == this.SalesEmployeeCdSt_tEdit) ||
			//	(e.PrevCtrl == this.SalesEmployeeCdEd_tEdit))
			//{
			//	AutoSetEndValue(this.SalesEmployeeCdSt_tEdit, this.SalesEmployeeCdEd_tEdit);
			//}

            // --- ADD 2008/09/26 ------------------------------------------------------------------>>>>>
            if (e.ShiftKey)
            {
                return;
            }
            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
            {
                // �d����From
                if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                {
                    // �f�[�^������΃K�C�h���΂�
                    if ((this.tNedit_SupplierCd_St.Text != "0") && (string.IsNullOrEmpty(this.tNedit_SupplierCd_St.Text) == false))
                    {
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    return;
                }
                // �d����To
                if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                {
                    // �f�[�^������΃K�C�h���΂�
                    if ((this.tNedit_SupplierCd_Ed.Text != "0") && (string.IsNullOrEmpty(this.tNedit_SupplierCd_Ed.Text) == false))
                    {
                        e.NextCtrl = this.tEdit_StockAgentCode_St;
                    }
                    return;
                }
                // �S����From
                if (e.PrevCtrl == this.tEdit_StockAgentCode_St)
                {
                    // �f�[�^������΃K�C�h���΂�
                    if ((this.tEdit_StockAgentCode_St.Text != "0") && (string.IsNullOrEmpty(this.tEdit_StockAgentCode_St.Text) == false))
                    {
                        e.NextCtrl = this.tEdit_StockAgentCode_Ed;
                    }
                    return;
                }
                // �S����To
                if (e.PrevCtrl == this.tEdit_StockAgentCode_Ed)
                {
                    // �f�[�^������΃K�C�h���΂�
                    if ((this.tEdit_StockAgentCode_Ed.Text != "0") && (string.IsNullOrEmpty(this.tEdit_StockAgentCode_Ed.Text) == false))
                    {
                        e.NextCtrl = this.SupplierSlipNoSt_Nedit;
                    }
                    return;
                }
            }
            // --- ADD 2008/09/26 ------------------------------------------------------------------<<<<<
		}

		/// <summary>
		/// �����^�C�}�[�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g����</param>
		/// <remarks>
		/// <br>Note		: �����������s���܂��B</br>
        /// <br>Programmer  : 980035 ����@��`</br>
        /// <br>Date	    : 2007.10.19</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;

			// ��ʏ����\��
			this.InitialScreenSetting();

			// �����t�H�[�J�X�ݒ�
			//this.InputDaySt_tDateEdit.Focus();  // DEL 2008/06/25
            this.ArrivalGoodsDaySt_tDateEdit.Focus();  // ADD 2008/06/25

			// ���C���t���[���Ƀc�[���o�[�ݒ�ʒm
			if (ParentToolbarSettingEvent != null) this.ParentToolbarSettingEvent(this);
		}

		///// <summary>
		///// Control.GroupCollapsing�C�x���g
		///// </summary>
		///// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		///// <param name="e">�C�x���g����</param>
		///// <remarks>
		///// <br>Note		: �G�N�X�v���[���o�[�̃O���[�v��W�J�����ۂɔ������܂��B</br>
		///// <br>Programmer  : 980035 ����@��`</br>
		///// <br>Date	    : 2007.10.19</br>
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
		/// <br>Date		: 2008.01.31</br>
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
		/// <br>Date		: 2008.01.31</br>
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

        // ---DEL 2009/06/26 �s��Ή�[13590]�@�R���p�C���G���[�ƂȂ�A���g�p�ׁ̈A�폜 ------------------------->>>>>
        ///// <summary>
        ///// �d����I���������C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">�d����ԗ������߂�l�N���X</param>
        //private void CustomerSearchForm_StCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // �擾�����d����R�[�h(�J�n)����ʂɕ\������
        //        this.tNedit_SupplierCd_St.SetInt(customerInfo.CustomerCode);
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
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_STOPDISP,
        //            this.Name,
        //            "�d������̎擾�Ɏ��s���܂����B",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //}

        ///// <summary>
        ///// �d����I���������C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="customerSearchRet">�d����ԗ������߂�l�N���X</param>
        //private void CustomerSearchForm_EdCustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        //{
        //    if (customerSearchRet == null) return;

        //    CustomerInfo customerInfo;
        //    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

        //    int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);

        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // �擾�����d����R�[�h(�I��)����ʂɕ\������
        //        this.tNedit_SupplierCd_Ed.SetInt(customerInfo.CustomerCode);
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
        //        TMsgDisp.Show(
        //            this,
        //            emErrorLevel.ERR_LEVEL_STOPDISP,
        //            this.Name,
        //            "�d������̎擾�Ɏ��s���܂����B",
        //            status,
        //            MessageBoxButtons.OK);

        //        return;
        //    }
        //}
        // ---DEL 2009/06/26 �s��Ή�[13590]�@�R���p�C���G���[�ƂȂ�A���g�p�ׁ̈A�폜 -------------------------<<<<<

		#region ���K�C�h�N���C�x���g
		/// <summary>
		/// �d����R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
		private void CustomerCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
            /* --- DEL 2008/06/25 -------------------------------->>>>>
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_StCustomerSelect);
            customerSearchForm.ShowDialog(this);
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // �C���X�^���X����
                    _supplierAcs = new SupplierAcs();
                }

                // �K�C�h�N��
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tNedit_SupplierCd_St.DataText = supplier.SupplierCd.ToString();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2009/01/15 �s��Ή�[9659]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/06/25 --------------------------------<<<<< 
		}

		/// <summary>
		/// �d����R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
		private void CustomerCdEd_GuideBtn_Click(object sender, EventArgs e)
		{
            /* --- DEL 2008/06/25 -------------------------------->>>>>
			SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);
			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_EdCustomerSelect);
			customerSearchForm.ShowDialog(this);
               --- DEL 2008/06/25 --------------------------------<<<<< */

            // --- ADD 2008/06/25 -------------------------------->>>>>
            int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_supplierAcs == null)
                {
                    // �C���X�^���X����
                    _supplierAcs = new SupplierAcs();
                }

                // �K�C�h�N��
                Supplier supplier;
                status = _supplierAcs.ExecuteGuid(out supplier, LoginInfoAcquisition.EnterpriseCode, this._ownSectionCode);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tNedit_SupplierCd_Ed.DataText = supplier.SupplierCd.ToString();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2009/01/15 �s��Ή�[9659]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            // --- ADD 2008/06/25 --------------------------------<<<<< 
		}

        /* --- DEL 2008/06/25 -------------------------------->>>>>
		/// <summary>
        /// ���͏]�ƈ��R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
		private void SalesInputCodeSt_GuideBtn_Click(object sender, EventArgs e)
		{
			int status = -1;
			// �C���X�^���X����
			EmployeeAcs _employeeAcs = new EmployeeAcs();

			// �K�C�h�N��
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// ���ڂɓW�J
			if (status == 0)
			{
				this.StockInputCdSt_tEdit.DataText = employee.EmployeeCode.TrimEnd();
			}
		}

		/// <summary>
        /// ���͏]�ƈ��R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
		private void SalesInputCodeEd_GuideBtn_Click(object sender, EventArgs e)
		{
			int status = -1;
			// �C���X�^���X����
			EmployeeAcs _employeeAcs = new EmployeeAcs();

			// �K�C�h�N��
			Employee employee = new Employee();
			status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

			// ���ڂɓW�J
			if (status == 0)
			{
				this.StockInputCdEd_tEdit.DataText = employee.EmployeeCode.TrimEnd();
			}

		}
           --- DEL 2008/06/25 --------------------------------<<<<< */
        
        /// <summary>
		/// �S���҃R�[�h(�J�n)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
		private void SalesEmployeeCdSt_GuideBtn_Click(object sender, EventArgs e)
		{
			int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_employeeAcs == null)
                {
                    // �C���X�^���X����
                    _employeeAcs = new EmployeeAcs();
                }

                // �K�C�h�N��
                Employee employee;
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tEdit_StockAgentCode_St.DataText = employee.EmployeeCode.TrimEnd();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2009/01/15 �s��Ή�[9659]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}

		/// <summary>
		/// �S���҃R�[�h(�I��)�K�C�h�N���{�^���N���C�x���g
		/// </summary>
		private void SalesEmployeeCdEd_GuideBtn_Click(object sender, EventArgs e)
		{
			int status = -1;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_employeeAcs == null)
                {
                    // �C���X�^���X����
                    _employeeAcs = new EmployeeAcs();
                }

                // �K�C�h�N��
                Employee employee;
                status = _employeeAcs.ExecuteGuid(LoginInfoAcquisition.EnterpriseCode, true, out employee);

                // ���ڂɓW�J
                if (status == 0)
                {
                    this.tEdit_StockAgentCode_Ed.DataText = employee.EmployeeCode.TrimEnd();
                }
                else
                {
                    ((Control)sender).Tag = GeneralGuideUIController.CAN_FOCUS; // ADD 2009/01/15 �s��Ή�[9659]
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}
		#endregion

		#endregion

        // ===================================================================================== //
        // IPrintConditionInpTypeSelectedSection �����o
        // ===================================================================================== //
		#region IPrintConditionInpTypeSelectedSection �����o

        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="checkState">�R���g���[�����</param>
        /// <remarks>
        /// <br>Note	   : ���_��I���������s�Ȃ��܂��B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
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
		/// <br>Note	   : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
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
        /// ���_�\���擾����
        /// </summary>
        /// <param name="isDefaultState"></param>
        /// <remarks>
        /// <br>Note	   : �I������Ă��鋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
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
		/// <br>Note	   : ���_�I�v�V�����擾�v���p�e�B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
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
		/// <br>Note	   : �{�Ћ@�\�擾�v���p�e�B</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
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
		/// <br>Note	   : �v�㋒�_�I������</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
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
		/// <br>Note	   : �I������Ă���v�㋒�_��ݒ肵�܂�</br>
        /// <br>Programmer : 980035 ����@��`</br>
        /// <br>Date	   : 2007.10.19</br>
        /// </remarks>
		public void InitSelectAddUpCd(int addUpCd)
		{
			this._selectedAddUpCd = addUpCd;
			return;
		}

		#endregion



	}
}

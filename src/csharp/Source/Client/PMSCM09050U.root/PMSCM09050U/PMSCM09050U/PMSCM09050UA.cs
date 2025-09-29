//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : SCM���ꉿ�i�ݒ�}�X�^
// �v���O�����T�v   : SCM���ꉿ�i�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434 �H��
// �� �� ��  2009/08/26  �C�����e : �`�P�b�g[14168]�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/12  �C�����e : ���ꉿ�i�i���R�[�h�Q�A���ꉿ�i�i���R�[�h�R�̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.RCDS.Web.Services;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// SCM���ꉿ�i�ݒ�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: SCM���ꉿ�i�ݒ���s���܂��B
	///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>   
	/// <br></br>
    /// </remarks>
	public class PMSCM09050UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel MarketPriceSalesRate_uLabel;
		private Broadleaf.Library.Windows.Forms.TNedit tNedit_MarketPriceSalesRate;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel MarketPriceKindCd2_uLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor MarketPriceKindCd2_tComboEditor;
		private Infragistics.Win.Misc.UltraLabel MarketPriceAreaCd_uLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor MarketPriceAreaCd_tComEditor;
		private Infragistics.Win.Misc.UltraLabel MarketPriceQualityCd_uLabel;
		private Infragistics.Win.Misc.UltraLabel Section_uLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraLabel MarketPriceAnswerDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel AddPaymntAmbit_uLabel;
        private Infragistics.Win.Misc.UltraLabel MarketPriceKindCd1_uLabel;
        private TComboEditor MarketPriceKindCd1_tComboEditor;
        private TComboEditor MarketPriceAnswerDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        private TEdit tEdit_SectionCodeAllowZero;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private TComboEditor MarketPriceKindCd3_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel MarketPriceKindCd3_uLabel;
        private TNedit tNedit_AddPaymnt10;
        private TNedit tNedit_AddPaymntAmbit10;
        private TNedit tNedit_AddPaymnt9;
        private TNedit tNedit_AddPaymntAmbit9;
        private TNedit tNedit_AddPaymnt8;
        private TNedit tNedit_AddPaymntAmbit8;
        private TNedit tNedit_AddPaymnt7;
        private TNedit tNedit_AddPaymntAmbit7;
        private TNedit tNedit_AddPaymnt6;
        private TNedit tNedit_AddPaymntAmbit6;
        private TNedit tNedit_AddPaymnt5;
        private TNedit tNedit_AddPaymntAmbit5;
        private TNedit tNedit_AddPaymnt4;
        private TNedit tNedit_AddPaymntAmbit4;
        private TNedit tNedit_AddPaymnt3;
        private TNedit tNedit_AddPaymntAmbit3;
        private TNedit tNedit_AddPaymnt2;
        private TNedit tNedit_AddPaymntAmbit2;
        private TNedit tNedit_AddPaymnt1;
        private TNedit tNedit_AddPaymntAmbit1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel14;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraLabel ultraLabel34;
        private Infragistics.Win.Misc.UltraLabel ultraLabel30;
        private Infragistics.Win.Misc.UltraLabel ultraLabel33;
        private Infragistics.Win.Misc.UltraLabel ultraLabel32;
        private Infragistics.Win.Misc.UltraLabel ultraLabel27;
        private Infragistics.Win.Misc.UltraLabel ultraLabel29;
        private Infragistics.Win.Misc.UltraLabel ultraLabel31;
        private Infragistics.Win.Misc.UltraLabel ultraLabel26;
        private Infragistics.Win.Misc.UltraLabel ultraLabel28;
        private Infragistics.Win.Misc.UltraLabel ultraLabel35;
        private Infragistics.Win.Misc.UltraLabel ultraLabel25;
        private Infragistics.Win.Misc.UltraLabel ultraLabel44;
        private Infragistics.Win.Misc.UltraLabel ultraLabel42;
        private Infragistics.Win.Misc.UltraLabel ultraLabel38;
        private Infragistics.Win.Misc.UltraLabel ultraLabel41;
        private Infragistics.Win.Misc.UltraLabel ultraLabel36;
        private Infragistics.Win.Misc.UltraLabel ultraLabel43;
        private Infragistics.Win.Misc.UltraLabel ultraLabel40;
        private Infragistics.Win.Misc.UltraLabel ultraLabel37;
        private Infragistics.Win.Misc.UltraLabel ultraLabel39;
        private Infragistics.Win.Misc.UltraLabel FractionProcCd_uLabel;
        private TComboEditor FractionProcCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel AddPaymnt_uLabel;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel16;
        private TComboEditor MarketPriceQualityCd3_tComEditor;
        private TComboEditor MarketPriceQualityCd2_tComEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TComboEditor MarketPriceQualityCd_tComEditor;
		#endregion

		#region -- Constructor --
		/// <summary>
        /// SCM���ꉿ�i�ݒ�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note		: SCM���ꉿ�i�ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br></br>
		/// </remarks>
        public PMSCM09050UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._scmMrktPriStAcs = new SCMMrktPriStAcs();
            this._totalCount = 0;
            this._scmMrktPriStTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ���_�ݒ�A�N�Z�X�N���X
            this._secInfoAcs = new SecInfoAcs();

            // ������擾
            GetSobaInfo();
        }
		#endregion

		private System.ComponentModel.IContainer components;

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region -- Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h --
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM09050UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceSalesRate_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_MarketPriceSalesRate = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd2_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd2_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MarketPriceAreaCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceAreaCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MarketPriceQualityCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceQualityCd_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.MarketPriceAnswerDiv_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.AddPaymntAmbit_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd1_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceAnswerDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MarketPriceKindCd1_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd3_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceKindCd3_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tNedit_AddPaymntAmbit1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit4 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit5 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit6 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit7 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit8 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit9 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymntAmbit10 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt4 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt5 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt6 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt7 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt8 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt9 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_AddPaymnt10 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel25 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel26 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel27 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel28 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel29 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel30 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel31 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel32 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel33 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel34 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel35 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel36 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel37 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel38 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel39 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel41 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel42 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel43 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel44 = new Infragistics.Win.Misc.UltraLabel();
            this.FractionProcCd_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.FractionProcCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AddPaymnt_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.MarketPriceQualityCd2_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MarketPriceQualityCd3_tComEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_MarketPriceSalesRate ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd2_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceAreaCd_tComEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd_tComEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SectionName_tEdit ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.Bind_DataSet ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceAnswerDiv_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd1_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_SectionCodeAllowZero ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd3_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit3 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit4 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit5 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit6 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit7 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit8 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit9 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit10 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt1 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt2 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt3 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt4 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt5 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt6 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt7 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt8 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt9 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt10 ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.FractionProcCd_tComboEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd2_tComEditor ) ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd3_tComEditor ) ).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(573, 667);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 35;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(445, 667);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 32;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 711);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(713, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(559, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // MarketPriceSalesRate_uLabel
            // 
            appearance137.TextVAlignAsString = "Middle";
            this.MarketPriceSalesRate_uLabel.Appearance = appearance137;
            this.MarketPriceSalesRate_uLabel.Location = new System.Drawing.Point(16, 279);
            this.MarketPriceSalesRate_uLabel.Name = "MarketPriceSalesRate_uLabel";
            this.MarketPriceSalesRate_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceSalesRate_uLabel.TabIndex = 171;
            this.MarketPriceSalesRate_uLabel.Text = "���ꉿ�i������";
            // 
            // tNedit_MarketPriceSalesRate
            // 
            appearance138.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance138.ForeColor = System.Drawing.Color.Black;
            appearance138.TextHAlignAsString = "Right";
            this.tNedit_MarketPriceSalesRate.ActiveAppearance = appearance138;
            appearance139.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance139.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance139.ForeColor = System.Drawing.Color.Black;
            appearance139.ForeColorDisabled = System.Drawing.Color.Black;
            appearance139.TextHAlignAsString = "Right";
            appearance139.TextVAlignAsString = "Middle";
            this.tNedit_MarketPriceSalesRate.Appearance = appearance139;
            this.tNedit_MarketPriceSalesRate.AutoSelect = true;
            this.tNedit_MarketPriceSalesRate.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tNedit_MarketPriceSalesRate.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_MarketPriceSalesRate.DataText = "";
            this.tNedit_MarketPriceSalesRate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_MarketPriceSalesRate.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.tNedit_MarketPriceSalesRate.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_MarketPriceSalesRate.Location = new System.Drawing.Point(221, 279);
            this.tNedit_MarketPriceSalesRate.MaxLength = 6;
            this.tNedit_MarketPriceSalesRate.Name = "tNedit_MarketPriceSalesRate";
            this.tNedit_MarketPriceSalesRate.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 2, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_MarketPriceSalesRate.Size = new System.Drawing.Size(82, 24);
            this.tNedit_MarketPriceSalesRate.TabIndex = 11;
            this.tNedit_MarketPriceSalesRate.Leave += new System.EventHandler(this.tNedit_MarketPriceSalesRate_Leave);
            // 
            // ultraLabel1
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance13;
            this.ultraLabel1.Location = new System.Drawing.Point(327, 279);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(24, 24);
            this.ultraLabel1.TabIndex = 173;
            this.ultraLabel1.Text = "��";
            // 
            // MarketPriceKindCd2_uLabel
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd2_uLabel.Appearance = appearance12;
            this.MarketPriceKindCd2_uLabel.Location = new System.Drawing.Point(187, 201);
            this.MarketPriceKindCd2_uLabel.Name = "MarketPriceKindCd2_uLabel";
            this.MarketPriceKindCd2_uLabel.Size = new System.Drawing.Size(28, 24);
            this.MarketPriceKindCd2_uLabel.TabIndex = 177;
            this.MarketPriceKindCd2_uLabel.Text = "2";
            // 
            // MarketPriceKindCd2_tComboEditor
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd2_tComboEditor.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceKindCd2_tComboEditor.Appearance = appearance15;
            this.MarketPriceKindCd2_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceKindCd2_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceKindCd2_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance16.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceKindCd2_tComboEditor.ItemAppearance = appearance16;
            this.MarketPriceKindCd2_tComboEditor.Location = new System.Drawing.Point(221, 201);
            this.MarketPriceKindCd2_tComboEditor.Name = "MarketPriceKindCd2_tComboEditor";
            this.MarketPriceKindCd2_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceKindCd2_tComboEditor.TabIndex = 7;
            this.MarketPriceKindCd2_tComboEditor.ValueChanged += new System.EventHandler(this.MarketPriceKindCd2_tComboEditor_ValueChanged);
            // 
            // MarketPriceAreaCd_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.MarketPriceAreaCd_uLabel.Appearance = appearance22;
            this.MarketPriceAreaCd_uLabel.Location = new System.Drawing.Point(16, 120);
            this.MarketPriceAreaCd_uLabel.Name = "MarketPriceAreaCd_uLabel";
            this.MarketPriceAreaCd_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceAreaCd_uLabel.TabIndex = 179;
            this.MarketPriceAreaCd_uLabel.Text = "���ꉿ�i�n��";
            // 
            // MarketPriceAreaCd_tComEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.MarketPriceAreaCd_tComEditor.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceAreaCd_tComEditor.Appearance = appearance24;
            this.MarketPriceAreaCd_tComEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceAreaCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceAreaCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceAreaCd_tComEditor.ItemAppearance = appearance25;
            this.MarketPriceAreaCd_tComEditor.Location = new System.Drawing.Point(221, 120);
            this.MarketPriceAreaCd_tComEditor.Name = "MarketPriceAreaCd_tComEditor";
            this.MarketPriceAreaCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceAreaCd_tComEditor.TabIndex = 4;
            // 
            // MarketPriceQualityCd_uLabel
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.MarketPriceQualityCd_uLabel.Appearance = appearance30;
            this.MarketPriceQualityCd_uLabel.Location = new System.Drawing.Point(451, 150);
            this.MarketPriceQualityCd_uLabel.Name = "MarketPriceQualityCd_uLabel";
            this.MarketPriceQualityCd_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceQualityCd_uLabel.TabIndex = 183;
            this.MarketPriceQualityCd_uLabel.Text = "�i��";
            // 
            // MarketPriceQualityCd_tComEditor
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance55.ForeColor = System.Drawing.Color.Black;
            appearance55.TextVAlignAsString = "Middle";
            this.MarketPriceQualityCd_tComEditor.ActiveAppearance = appearance55;
            appearance56.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance56.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance56.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceQualityCd_tComEditor.Appearance = appearance56;
            this.MarketPriceQualityCd_tComEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceQualityCd_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceQualityCd_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance62.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceQualityCd_tComEditor.ItemAppearance = appearance62;
            this.MarketPriceQualityCd_tComEditor.Location = new System.Drawing.Point(451, 174);
            this.MarketPriceQualityCd_tComEditor.Name = "MarketPriceQualityCd_tComEditor";
            this.MarketPriceQualityCd_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceQualityCd_tComEditor.TabIndex = 6;
            // 
            // Section_uLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance4;
            this.Section_uLabel.Location = new System.Drawing.Point(16, 42);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(165, 24);
            this.Section_uLabel.TabIndex = 184;
            this.Section_uLabel.Text = "���_";
            // 
            // SectionName_tEdit
            // 
            appearance2.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.SectionName_tEdit.ActiveAppearance = appearance2;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Left";
            this.SectionName_tEdit.Appearance = appearance3;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionName_tEdit.Location = new System.Drawing.Point(255, 42);
            this.SectionName_tEdit.MaxLength = 10;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(159, 24);
            this.SectionName_tEdit.TabIndex = 1;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // SectionGuide_Button
            // 
            this.SectionGuide_Button.Location = new System.Drawing.Point(456, 42);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.SectionGuide_Button.TabIndex = 2;
            ultraToolTipInfo1.ToolTipText = "���_�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // MarketPriceAnswerDiv_uLabel
            // 
            appearance68.TextVAlignAsString = "Middle";
            this.MarketPriceAnswerDiv_uLabel.Appearance = appearance68;
            this.MarketPriceAnswerDiv_uLabel.Location = new System.Drawing.Point(16, 81);
            this.MarketPriceAnswerDiv_uLabel.Name = "MarketPriceAnswerDiv_uLabel";
            this.MarketPriceAnswerDiv_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceAnswerDiv_uLabel.TabIndex = 253;
            this.MarketPriceAnswerDiv_uLabel.Text = "���ꉿ�i�񓚋敪";
            // 
            // AddPaymntAmbit_uLabel
            // 
            appearance51.TextVAlignAsString = "Middle";
            this.AddPaymntAmbit_uLabel.Appearance = appearance51;
            this.AddPaymntAmbit_uLabel.Location = new System.Drawing.Point(16, 339);
            this.AddPaymntAmbit_uLabel.Name = "AddPaymntAmbit_uLabel";
            this.AddPaymntAmbit_uLabel.Size = new System.Drawing.Size(199, 24);
            this.AddPaymntAmbit_uLabel.TabIndex = 259;
            this.AddPaymntAmbit_uLabel.Text = "�����e�[�u��";
            // 
            // MarketPriceKindCd1_uLabel
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd1_uLabel.Appearance = appearance73;
            this.MarketPriceKindCd1_uLabel.Location = new System.Drawing.Point(16, 150);
            this.MarketPriceKindCd1_uLabel.Name = "MarketPriceKindCd1_uLabel";
            this.MarketPriceKindCd1_uLabel.Size = new System.Drawing.Size(165, 24);
            this.MarketPriceKindCd1_uLabel.TabIndex = 258;
            this.MarketPriceKindCd1_uLabel.Text = "���ꉿ�i���";
            // 
            // MarketPriceAnswerDiv_tComboEditor
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.MarketPriceAnswerDiv_tComboEditor.ActiveAppearance = appearance58;
            appearance59.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceAnswerDiv_tComboEditor.Appearance = appearance59;
            this.MarketPriceAnswerDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceAnswerDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceAnswerDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance60.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceAnswerDiv_tComboEditor.ItemAppearance = appearance60;
            this.MarketPriceAnswerDiv_tComboEditor.Location = new System.Drawing.Point(221, 81);
            this.MarketPriceAnswerDiv_tComboEditor.Name = "MarketPriceAnswerDiv_tComboEditor";
            this.MarketPriceAnswerDiv_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceAnswerDiv_tComboEditor.TabIndex = 3;
            this.MarketPriceAnswerDiv_tComboEditor.ValueChanged += new System.EventHandler(this.MarketPriceAnswerDiv_tComboEditor_ValueChanged);
            // 
            // MarketPriceKindCd1_tComboEditor
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd1_tComboEditor.ActiveAppearance = appearance43;
            appearance44.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance44.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceKindCd1_tComboEditor.Appearance = appearance44;
            this.MarketPriceKindCd1_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceKindCd1_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceKindCd1_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance45.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceKindCd1_tComboEditor.ItemAppearance = appearance45;
            this.MarketPriceKindCd1_tComboEditor.Location = new System.Drawing.Point(221, 174);
            this.MarketPriceKindCd1_tComboEditor.Name = "MarketPriceKindCd1_tComboEditor";
            this.MarketPriceKindCd1_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceKindCd1_tComboEditor.TabIndex = 5;
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(16, 72);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(675, 3);
            this.DivideLine_Label.TabIndex = 261;
            // 
            // ultraLabel6
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance34;
            this.ultraLabel6.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.ultraLabel6.Location = new System.Drawing.Point(487, 42);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(223, 24);
            this.ultraLabel6.TabIndex = 262;
            this.ultraLabel6.Text = "���[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(445, 667);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 34;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(316, 667);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 31;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance7.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance7;
            appearance11.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Right";
            this.tEdit_SectionCodeAllowZero.Appearance = appearance11;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, false, false, true, true, true));
            this.tEdit_SectionCodeAllowZero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(221, 42);
            this.tEdit_SectionCodeAllowZero.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 0;
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(316, 667);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 33;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel5.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel5.Location = new System.Drawing.Point(16, 111);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(675, 3);
            this.ultraLabel5.TabIndex = 261;
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel2.Location = new System.Drawing.Point(16, 270);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(675, 3);
            this.ultraLabel2.TabIndex = 261;
            // 
            // MarketPriceKindCd3_uLabel
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd3_uLabel.Appearance = appearance18;
            this.MarketPriceKindCd3_uLabel.Location = new System.Drawing.Point(187, 228);
            this.MarketPriceKindCd3_uLabel.Name = "MarketPriceKindCd3_uLabel";
            this.MarketPriceKindCd3_uLabel.Size = new System.Drawing.Size(28, 24);
            this.MarketPriceKindCd3_uLabel.TabIndex = 177;
            this.MarketPriceKindCd3_uLabel.Text = "3";
            // 
            // MarketPriceKindCd3_tComboEditor
            // 
            appearance140.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance140.ForeColor = System.Drawing.Color.Black;
            appearance140.TextVAlignAsString = "Middle";
            this.MarketPriceKindCd3_tComboEditor.ActiveAppearance = appearance140;
            appearance141.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance141.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance141.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceKindCd3_tComboEditor.Appearance = appearance141;
            this.MarketPriceKindCd3_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceKindCd3_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceKindCd3_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance142.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceKindCd3_tComboEditor.ItemAppearance = appearance142;
            this.MarketPriceKindCd3_tComboEditor.Location = new System.Drawing.Point(221, 228);
            this.MarketPriceKindCd3_tComboEditor.Name = "MarketPriceKindCd3_tComboEditor";
            this.MarketPriceKindCd3_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceKindCd3_tComboEditor.TabIndex = 9;
            this.MarketPriceKindCd3_tComboEditor.ValueChanged += new System.EventHandler(this.MarketPriceKindCd3_tComboEditor_ValueChanged);
            // 
            // tNedit_AddPaymntAmbit1
            // 
            appearance95.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance95.ForeColor = System.Drawing.Color.Black;
            appearance95.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit1.ActiveAppearance = appearance95;
            appearance96.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance96.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance96.ForeColor = System.Drawing.Color.Black;
            appearance96.ForeColorDisabled = System.Drawing.Color.Black;
            appearance96.TextHAlignAsString = "Right";
            appearance96.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit1.Appearance = appearance96;
            this.tNedit_AddPaymntAmbit1.AutoSelect = true;
            this.tNedit_AddPaymntAmbit1.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tNedit_AddPaymntAmbit1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit1.DataText = "";
            this.tNedit_AddPaymntAmbit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit1.Location = new System.Drawing.Point(47, 368);
            this.tNedit_AddPaymntAmbit1.MaxLength = 10;
            this.tNedit_AddPaymntAmbit1.Name = "tNedit_AddPaymntAmbit1";
            this.tNedit_AddPaymntAmbit1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit1.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit1.TabIndex = 13;
            // 
            // tNedit_AddPaymntAmbit2
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance91.ForeColor = System.Drawing.Color.Black;
            appearance91.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit2.ActiveAppearance = appearance91;
            appearance92.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance92.ForeColor = System.Drawing.Color.Black;
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            appearance92.TextHAlignAsString = "Right";
            appearance92.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit2.Appearance = appearance92;
            this.tNedit_AddPaymntAmbit2.AutoSelect = true;
            this.tNedit_AddPaymntAmbit2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit2.DataText = "";
            this.tNedit_AddPaymntAmbit2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit2.Location = new System.Drawing.Point(47, 395);
            this.tNedit_AddPaymntAmbit2.MaxLength = 10;
            this.tNedit_AddPaymntAmbit2.Name = "tNedit_AddPaymntAmbit2";
            this.tNedit_AddPaymntAmbit2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit2.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit2.TabIndex = 15;
            // 
            // tNedit_AddPaymntAmbit3
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance87.ForeColor = System.Drawing.Color.Black;
            appearance87.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit3.ActiveAppearance = appearance87;
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColor = System.Drawing.Color.Black;
            appearance88.ForeColorDisabled = System.Drawing.Color.Black;
            appearance88.TextHAlignAsString = "Right";
            appearance88.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit3.Appearance = appearance88;
            this.tNedit_AddPaymntAmbit3.AutoSelect = true;
            this.tNedit_AddPaymntAmbit3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit3.DataText = "";
            this.tNedit_AddPaymntAmbit3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit3.Location = new System.Drawing.Point(47, 422);
            this.tNedit_AddPaymntAmbit3.MaxLength = 10;
            this.tNedit_AddPaymntAmbit3.Name = "tNedit_AddPaymntAmbit3";
            this.tNedit_AddPaymntAmbit3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit3.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit3.TabIndex = 17;
            // 
            // tNedit_AddPaymntAmbit4
            // 
            appearance83.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance83.ForeColor = System.Drawing.Color.Black;
            appearance83.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit4.ActiveAppearance = appearance83;
            appearance84.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance84.ForeColor = System.Drawing.Color.Black;
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            appearance84.TextHAlignAsString = "Right";
            appearance84.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit4.Appearance = appearance84;
            this.tNedit_AddPaymntAmbit4.AutoSelect = true;
            this.tNedit_AddPaymntAmbit4.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit4.DataText = "";
            this.tNedit_AddPaymntAmbit4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit4.Location = new System.Drawing.Point(47, 449);
            this.tNedit_AddPaymntAmbit4.MaxLength = 10;
            this.tNedit_AddPaymntAmbit4.Name = "tNedit_AddPaymntAmbit4";
            this.tNedit_AddPaymntAmbit4.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit4.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit4.TabIndex = 19;
            // 
            // tNedit_AddPaymntAmbit5
            // 
            appearance79.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance79.ForeColor = System.Drawing.Color.Black;
            appearance79.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit5.ActiveAppearance = appearance79;
            appearance80.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance80.ForeColor = System.Drawing.Color.Black;
            appearance80.ForeColorDisabled = System.Drawing.Color.Black;
            appearance80.TextHAlignAsString = "Right";
            appearance80.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit5.Appearance = appearance80;
            this.tNedit_AddPaymntAmbit5.AutoSelect = true;
            this.tNedit_AddPaymntAmbit5.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit5.DataText = "";
            this.tNedit_AddPaymntAmbit5.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit5.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit5.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit5.Location = new System.Drawing.Point(47, 476);
            this.tNedit_AddPaymntAmbit5.MaxLength = 10;
            this.tNedit_AddPaymntAmbit5.Name = "tNedit_AddPaymntAmbit5";
            this.tNedit_AddPaymntAmbit5.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit5.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit5.TabIndex = 21;
            // 
            // tNedit_AddPaymntAmbit6
            // 
            appearance75.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance75.ForeColor = System.Drawing.Color.Black;
            appearance75.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit6.ActiveAppearance = appearance75;
            appearance76.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance76.ForeColor = System.Drawing.Color.Black;
            appearance76.ForeColorDisabled = System.Drawing.Color.Black;
            appearance76.TextHAlignAsString = "Right";
            appearance76.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit6.Appearance = appearance76;
            this.tNedit_AddPaymntAmbit6.AutoSelect = true;
            this.tNedit_AddPaymntAmbit6.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit6.DataText = "";
            this.tNedit_AddPaymntAmbit6.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit6.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit6.Location = new System.Drawing.Point(47, 503);
            this.tNedit_AddPaymntAmbit6.MaxLength = 10;
            this.tNedit_AddPaymntAmbit6.Name = "tNedit_AddPaymntAmbit6";
            this.tNedit_AddPaymntAmbit6.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit6.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit6.TabIndex = 23;
            // 
            // tNedit_AddPaymntAmbit7
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance71.ForeColor = System.Drawing.Color.Black;
            appearance71.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit7.ActiveAppearance = appearance71;
            appearance72.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance72.ForeColor = System.Drawing.Color.Black;
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Right";
            appearance72.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit7.Appearance = appearance72;
            this.tNedit_AddPaymntAmbit7.AutoSelect = true;
            this.tNedit_AddPaymntAmbit7.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit7.DataText = "";
            this.tNedit_AddPaymntAmbit7.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit7.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit7.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit7.Location = new System.Drawing.Point(47, 530);
            this.tNedit_AddPaymntAmbit7.MaxLength = 10;
            this.tNedit_AddPaymntAmbit7.Name = "tNedit_AddPaymntAmbit7";
            this.tNedit_AddPaymntAmbit7.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit7.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit7.TabIndex = 25;
            // 
            // tNedit_AddPaymntAmbit8
            // 
            appearance66.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit8.ActiveAppearance = appearance66;
            appearance67.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance67.ForeColor = System.Drawing.Color.Black;
            appearance67.ForeColorDisabled = System.Drawing.Color.Black;
            appearance67.TextHAlignAsString = "Right";
            appearance67.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit8.Appearance = appearance67;
            this.tNedit_AddPaymntAmbit8.AutoSelect = true;
            this.tNedit_AddPaymntAmbit8.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit8.DataText = "";
            this.tNedit_AddPaymntAmbit8.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit8.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit8.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit8.Location = new System.Drawing.Point(47, 557);
            this.tNedit_AddPaymntAmbit8.MaxLength = 10;
            this.tNedit_AddPaymntAmbit8.Name = "tNedit_AddPaymntAmbit8";
            this.tNedit_AddPaymntAmbit8.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit8.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit8.TabIndex = 27;
            // 
            // tNedit_AddPaymntAmbit9
            // 
            appearance57.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance57.ForeColor = System.Drawing.Color.Black;
            appearance57.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit9.ActiveAppearance = appearance57;
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextHAlignAsString = "Right";
            appearance61.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit9.Appearance = appearance61;
            this.tNedit_AddPaymntAmbit9.AutoSelect = true;
            this.tNedit_AddPaymntAmbit9.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit9.DataText = "";
            this.tNedit_AddPaymntAmbit9.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit9.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit9.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit9.Location = new System.Drawing.Point(47, 584);
            this.tNedit_AddPaymntAmbit9.MaxLength = 10;
            this.tNedit_AddPaymntAmbit9.Name = "tNedit_AddPaymntAmbit9";
            this.tNedit_AddPaymntAmbit9.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit9.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit9.TabIndex = 29;
            // 
            // tNedit_AddPaymntAmbit10
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.TextHAlignAsString = "Right";
            this.tNedit_AddPaymntAmbit10.ActiveAppearance = appearance53;
            appearance54.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance54.ForeColor = System.Drawing.Color.Black;
            appearance54.ForeColorDisabled = System.Drawing.Color.Black;
            appearance54.TextHAlignAsString = "Right";
            appearance54.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymntAmbit10.Appearance = appearance54;
            this.tNedit_AddPaymntAmbit10.AutoSelect = true;
            this.tNedit_AddPaymntAmbit10.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymntAmbit10.DataText = "";
            this.tNedit_AddPaymntAmbit10.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymntAmbit10.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymntAmbit10.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymntAmbit10.Location = new System.Drawing.Point(47, 611);
            this.tNedit_AddPaymntAmbit10.MaxLength = 10;
            this.tNedit_AddPaymntAmbit10.Name = "tNedit_AddPaymntAmbit10";
            this.tNedit_AddPaymntAmbit10.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymntAmbit10.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymntAmbit10.TabIndex = 31;
            // 
            // tNedit_AddPaymnt1
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt1.ActiveAppearance = appearance49;
            appearance50.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance50.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance50.ForeColor = System.Drawing.Color.Black;
            appearance50.ForeColorDisabled = System.Drawing.Color.Black;
            appearance50.TextHAlignAsString = "Right";
            appearance50.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt1.Appearance = appearance50;
            this.tNedit_AddPaymnt1.AutoSelect = true;
            this.tNedit_AddPaymnt1.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.tNedit_AddPaymnt1.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt1.DataText = "";
            this.tNedit_AddPaymnt1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt1.Location = new System.Drawing.Point(236, 368);
            this.tNedit_AddPaymnt1.MaxLength = 10;
            this.tNedit_AddPaymnt1.Name = "tNedit_AddPaymnt1";
            this.tNedit_AddPaymnt1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt1.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt1.TabIndex = 14;
            // 
            // tNedit_AddPaymnt2
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt2.ActiveAppearance = appearance17;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Right";
            appearance26.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt2.Appearance = appearance26;
            this.tNedit_AddPaymnt2.AutoSelect = true;
            this.tNedit_AddPaymnt2.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt2.DataText = "";
            this.tNedit_AddPaymnt2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt2.Location = new System.Drawing.Point(236, 395);
            this.tNedit_AddPaymnt2.MaxLength = 10;
            this.tNedit_AddPaymnt2.Name = "tNedit_AddPaymnt2";
            this.tNedit_AddPaymnt2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt2.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt2.TabIndex = 16;
            // 
            // tNedit_AddPaymnt3
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt3.ActiveAppearance = appearance40;
            appearance41.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextHAlignAsString = "Right";
            appearance41.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt3.Appearance = appearance41;
            this.tNedit_AddPaymnt3.AutoSelect = true;
            this.tNedit_AddPaymnt3.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt3.DataText = "";
            this.tNedit_AddPaymnt3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt3.Location = new System.Drawing.Point(236, 422);
            this.tNedit_AddPaymnt3.MaxLength = 10;
            this.tNedit_AddPaymnt3.Name = "tNedit_AddPaymnt3";
            this.tNedit_AddPaymnt3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt3.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt3.TabIndex = 18;
            // 
            // tNedit_AddPaymnt4
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt4.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextHAlignAsString = "Right";
            appearance28.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt4.Appearance = appearance28;
            this.tNedit_AddPaymnt4.AutoSelect = true;
            this.tNedit_AddPaymnt4.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt4.DataText = "";
            this.tNedit_AddPaymnt4.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt4.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt4.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt4.Location = new System.Drawing.Point(236, 449);
            this.tNedit_AddPaymnt4.MaxLength = 10;
            this.tNedit_AddPaymnt4.Name = "tNedit_AddPaymnt4";
            this.tNedit_AddPaymnt4.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt4.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt4.TabIndex = 20;
            // 
            // tNedit_AddPaymnt5
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt5.ActiveAppearance = appearance42;
            appearance46.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            appearance46.TextHAlignAsString = "Right";
            appearance46.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt5.Appearance = appearance46;
            this.tNedit_AddPaymnt5.AutoSelect = true;
            this.tNedit_AddPaymnt5.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt5.DataText = "";
            this.tNedit_AddPaymnt5.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt5.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt5.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt5.Location = new System.Drawing.Point(236, 476);
            this.tNedit_AddPaymnt5.MaxLength = 10;
            this.tNedit_AddPaymnt5.Name = "tNedit_AddPaymnt5";
            this.tNedit_AddPaymnt5.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt5.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt5.TabIndex = 22;
            // 
            // tNedit_AddPaymnt6
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt6.ActiveAppearance = appearance29;
            appearance35.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance35.ForeColor = System.Drawing.Color.Black;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Right";
            appearance35.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt6.Appearance = appearance35;
            this.tNedit_AddPaymnt6.AutoSelect = true;
            this.tNedit_AddPaymnt6.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt6.DataText = "";
            this.tNedit_AddPaymnt6.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt6.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt6.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt6.Location = new System.Drawing.Point(236, 503);
            this.tNedit_AddPaymnt6.MaxLength = 10;
            this.tNedit_AddPaymnt6.Name = "tNedit_AddPaymnt6";
            this.tNedit_AddPaymnt6.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt6.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt6.TabIndex = 24;
            // 
            // tNedit_AddPaymnt7
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt7.ActiveAppearance = appearance47;
            appearance48.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            appearance48.TextHAlignAsString = "Right";
            appearance48.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt7.Appearance = appearance48;
            this.tNedit_AddPaymnt7.AutoSelect = true;
            this.tNedit_AddPaymnt7.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt7.DataText = "";
            this.tNedit_AddPaymnt7.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt7.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt7.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt7.Location = new System.Drawing.Point(236, 530);
            this.tNedit_AddPaymnt7.MaxLength = 10;
            this.tNedit_AddPaymnt7.Name = "tNedit_AddPaymnt7";
            this.tNedit_AddPaymnt7.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt7.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt7.TabIndex = 26;
            // 
            // tNedit_AddPaymnt8
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt8.ActiveAppearance = appearance38;
            appearance39.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextHAlignAsString = "Right";
            appearance39.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt8.Appearance = appearance39;
            this.tNedit_AddPaymnt8.AutoSelect = true;
            this.tNedit_AddPaymnt8.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt8.DataText = "";
            this.tNedit_AddPaymnt8.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt8.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt8.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt8.Location = new System.Drawing.Point(236, 557);
            this.tNedit_AddPaymnt8.MaxLength = 10;
            this.tNedit_AddPaymnt8.Name = "tNedit_AddPaymnt8";
            this.tNedit_AddPaymnt8.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt8.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt8.TabIndex = 28;
            // 
            // tNedit_AddPaymnt9
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt9.ActiveAppearance = appearance36;
            appearance37.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextHAlignAsString = "Right";
            appearance37.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt9.Appearance = appearance37;
            this.tNedit_AddPaymnt9.AutoSelect = true;
            this.tNedit_AddPaymnt9.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt9.DataText = "";
            this.tNedit_AddPaymnt9.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt9.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt9.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt9.Location = new System.Drawing.Point(236, 584);
            this.tNedit_AddPaymnt9.MaxLength = 10;
            this.tNedit_AddPaymnt9.Name = "tNedit_AddPaymnt9";
            this.tNedit_AddPaymnt9.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt9.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt9.TabIndex = 30;
            // 
            // tNedit_AddPaymnt10
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            this.tNedit_AddPaymnt10.ActiveAppearance = appearance8;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.tNedit_AddPaymnt10.Appearance = appearance9;
            this.tNedit_AddPaymnt10.AutoSelect = true;
            this.tNedit_AddPaymnt10.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_AddPaymnt10.DataText = "";
            this.tNedit_AddPaymnt10.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_AddPaymnt10.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_AddPaymnt10.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_AddPaymnt10.Location = new System.Drawing.Point(236, 611);
            this.tNedit_AddPaymnt10.MaxLength = 10;
            this.tNedit_AddPaymnt10.Name = "tNedit_AddPaymnt10";
            this.tNedit_AddPaymnt10.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.tNedit_AddPaymnt10.Size = new System.Drawing.Size(97, 24);
            this.tNedit_AddPaymnt10.TabIndex = 32;
            // 
            // ultraLabel3
            // 
            appearance101.TextHAlignAsString = "Right";
            appearance101.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance101;
            this.ultraLabel3.Location = new System.Drawing.Point(16, 369);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel3.TabIndex = 263;
            this.ultraLabel3.Text = "1";
            // 
            // ultraLabel4
            // 
            appearance105.TextHAlignAsString = "Right";
            appearance105.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance105;
            this.ultraLabel4.Location = new System.Drawing.Point(16, 396);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel4.TabIndex = 263;
            this.ultraLabel4.Text = "2";
            // 
            // ultraLabel7
            // 
            appearance104.TextHAlignAsString = "Right";
            appearance104.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance104;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 423);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel7.TabIndex = 263;
            this.ultraLabel7.Text = "3";
            // 
            // ultraLabel8
            // 
            appearance103.TextHAlignAsString = "Right";
            appearance103.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance103;
            this.ultraLabel8.Location = new System.Drawing.Point(16, 450);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel8.TabIndex = 263;
            this.ultraLabel8.Text = "4";
            // 
            // ultraLabel9
            // 
            appearance102.TextHAlignAsString = "Right";
            appearance102.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance102;
            this.ultraLabel9.Location = new System.Drawing.Point(16, 477);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel9.TabIndex = 263;
            this.ultraLabel9.Text = "5";
            // 
            // ultraLabel10
            // 
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance5;
            this.ultraLabel10.Location = new System.Drawing.Point(16, 504);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel10.TabIndex = 263;
            this.ultraLabel10.Text = "6";
            // 
            // ultraLabel11
            // 
            appearance6.TextHAlignAsString = "Right";
            appearance6.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance6;
            this.ultraLabel11.Location = new System.Drawing.Point(16, 531);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel11.TabIndex = 263;
            this.ultraLabel11.Text = "7";
            // 
            // ultraLabel12
            // 
            appearance99.TextHAlignAsString = "Right";
            appearance99.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance99;
            this.ultraLabel12.Location = new System.Drawing.Point(16, 558);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel12.TabIndex = 263;
            this.ultraLabel12.Text = "8";
            // 
            // ultraLabel13
            // 
            appearance100.TextHAlignAsString = "Right";
            appearance100.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance100;
            this.ultraLabel13.Location = new System.Drawing.Point(16, 585);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel13.TabIndex = 263;
            this.ultraLabel13.Text = "9";
            // 
            // ultraLabel14
            // 
            appearance90.TextHAlignAsString = "Right";
            appearance90.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance90;
            this.ultraLabel14.Location = new System.Drawing.Point(16, 612);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(25, 23);
            this.ultraLabel14.TabIndex = 263;
            this.ultraLabel14.Text = "10";
            // 
            // ultraLabel25
            // 
            appearance125.TextVAlignAsString = "Middle";
            this.ultraLabel25.Appearance = appearance125;
            this.ultraLabel25.Location = new System.Drawing.Point(168, 368);
            this.ultraLabel25.Name = "ultraLabel25";
            this.ultraLabel25.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel25.TabIndex = 259;
            this.ultraLabel25.Text = "�~�܂�";
            // 
            // ultraLabel26
            // 
            appearance123.TextVAlignAsString = "Middle";
            this.ultraLabel26.Appearance = appearance123;
            this.ultraLabel26.Location = new System.Drawing.Point(168, 395);
            this.ultraLabel26.Name = "ultraLabel26";
            this.ultraLabel26.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel26.TabIndex = 259;
            this.ultraLabel26.Text = "�~�܂�";
            // 
            // ultraLabel27
            // 
            appearance121.TextVAlignAsString = "Middle";
            this.ultraLabel27.Appearance = appearance121;
            this.ultraLabel27.Location = new System.Drawing.Point(168, 422);
            this.ultraLabel27.Name = "ultraLabel27";
            this.ultraLabel27.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel27.TabIndex = 259;
            this.ultraLabel27.Text = "�~�܂�";
            // 
            // ultraLabel28
            // 
            appearance124.TextVAlignAsString = "Middle";
            this.ultraLabel28.Appearance = appearance124;
            this.ultraLabel28.Location = new System.Drawing.Point(168, 449);
            this.ultraLabel28.Name = "ultraLabel28";
            this.ultraLabel28.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel28.TabIndex = 259;
            this.ultraLabel28.Text = "�~�܂�";
            // 
            // ultraLabel29
            // 
            appearance122.TextVAlignAsString = "Middle";
            this.ultraLabel29.Appearance = appearance122;
            this.ultraLabel29.Location = new System.Drawing.Point(168, 476);
            this.ultraLabel29.Name = "ultraLabel29";
            this.ultraLabel29.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel29.TabIndex = 259;
            this.ultraLabel29.Text = "�~�܂�";
            // 
            // ultraLabel30
            // 
            appearance120.TextVAlignAsString = "Middle";
            this.ultraLabel30.Appearance = appearance120;
            this.ultraLabel30.Location = new System.Drawing.Point(168, 503);
            this.ultraLabel30.Name = "ultraLabel30";
            this.ultraLabel30.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel30.TabIndex = 259;
            this.ultraLabel30.Text = "�~�܂�";
            // 
            // ultraLabel31
            // 
            appearance111.TextVAlignAsString = "Middle";
            this.ultraLabel31.Appearance = appearance111;
            this.ultraLabel31.Location = new System.Drawing.Point(168, 557);
            this.ultraLabel31.Name = "ultraLabel31";
            this.ultraLabel31.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel31.TabIndex = 259;
            this.ultraLabel31.Text = "�~�܂�";
            // 
            // ultraLabel32
            // 
            appearance112.TextVAlignAsString = "Middle";
            this.ultraLabel32.Appearance = appearance112;
            this.ultraLabel32.Location = new System.Drawing.Point(168, 584);
            this.ultraLabel32.Name = "ultraLabel32";
            this.ultraLabel32.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel32.TabIndex = 259;
            this.ultraLabel32.Text = "�~�܂�";
            // 
            // ultraLabel33
            // 
            appearance113.TextVAlignAsString = "Middle";
            this.ultraLabel33.Appearance = appearance113;
            this.ultraLabel33.Location = new System.Drawing.Point(168, 530);
            this.ultraLabel33.Name = "ultraLabel33";
            this.ultraLabel33.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel33.TabIndex = 259;
            this.ultraLabel33.Text = "�~�܂�";
            // 
            // ultraLabel34
            // 
            appearance110.TextVAlignAsString = "Middle";
            this.ultraLabel34.Appearance = appearance110;
            this.ultraLabel34.Location = new System.Drawing.Point(168, 611);
            this.ultraLabel34.Name = "ultraLabel34";
            this.ultraLabel34.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel34.TabIndex = 259;
            this.ultraLabel34.Text = "�~�܂�";
            // 
            // ultraLabel35
            // 
            appearance136.TextVAlignAsString = "Middle";
            this.ultraLabel35.Appearance = appearance136;
            this.ultraLabel35.Location = new System.Drawing.Point(357, 368);
            this.ultraLabel35.Name = "ultraLabel35";
            this.ultraLabel35.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel35.TabIndex = 259;
            this.ultraLabel35.Text = "�~";
            // 
            // ultraLabel36
            // 
            appearance133.TextVAlignAsString = "Middle";
            this.ultraLabel36.Appearance = appearance133;
            this.ultraLabel36.Location = new System.Drawing.Point(357, 395);
            this.ultraLabel36.Name = "ultraLabel36";
            this.ultraLabel36.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel36.TabIndex = 259;
            this.ultraLabel36.Text = "�~";
            // 
            // ultraLabel37
            // 
            appearance135.TextVAlignAsString = "Middle";
            this.ultraLabel37.Appearance = appearance135;
            this.ultraLabel37.Location = new System.Drawing.Point(357, 422);
            this.ultraLabel37.Name = "ultraLabel37";
            this.ultraLabel37.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel37.TabIndex = 259;
            this.ultraLabel37.Text = "�~";
            // 
            // ultraLabel38
            // 
            appearance132.TextVAlignAsString = "Middle";
            this.ultraLabel38.Appearance = appearance132;
            this.ultraLabel38.Location = new System.Drawing.Point(357, 449);
            this.ultraLabel38.Name = "ultraLabel38";
            this.ultraLabel38.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel38.TabIndex = 259;
            this.ultraLabel38.Text = "�~";
            // 
            // ultraLabel39
            // 
            appearance129.TextVAlignAsString = "Middle";
            this.ultraLabel39.Appearance = appearance129;
            this.ultraLabel39.Location = new System.Drawing.Point(357, 476);
            this.ultraLabel39.Name = "ultraLabel39";
            this.ultraLabel39.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel39.TabIndex = 259;
            this.ultraLabel39.Text = "�~";
            // 
            // ultraLabel40
            // 
            appearance134.TextVAlignAsString = "Middle";
            this.ultraLabel40.Appearance = appearance134;
            this.ultraLabel40.Location = new System.Drawing.Point(357, 530);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel40.TabIndex = 259;
            this.ultraLabel40.Text = "�~";
            // 
            // ultraLabel41
            // 
            appearance130.TextVAlignAsString = "Middle";
            this.ultraLabel41.Appearance = appearance130;
            this.ultraLabel41.Location = new System.Drawing.Point(357, 503);
            this.ultraLabel41.Name = "ultraLabel41";
            this.ultraLabel41.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel41.TabIndex = 259;
            this.ultraLabel41.Text = "�~";
            // 
            // ultraLabel42
            // 
            appearance131.TextVAlignAsString = "Middle";
            this.ultraLabel42.Appearance = appearance131;
            this.ultraLabel42.Location = new System.Drawing.Point(357, 557);
            this.ultraLabel42.Name = "ultraLabel42";
            this.ultraLabel42.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel42.TabIndex = 259;
            this.ultraLabel42.Text = "�~";
            // 
            // ultraLabel43
            // 
            appearance128.TextVAlignAsString = "Middle";
            this.ultraLabel43.Appearance = appearance128;
            this.ultraLabel43.Location = new System.Drawing.Point(357, 584);
            this.ultraLabel43.Name = "ultraLabel43";
            this.ultraLabel43.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel43.TabIndex = 259;
            this.ultraLabel43.Text = "�~";
            // 
            // ultraLabel44
            // 
            appearance114.TextVAlignAsString = "Middle";
            this.ultraLabel44.Appearance = appearance114;
            this.ultraLabel44.Location = new System.Drawing.Point(357, 611);
            this.ultraLabel44.Name = "ultraLabel44";
            this.ultraLabel44.Size = new System.Drawing.Size(62, 24);
            this.ultraLabel44.TabIndex = 259;
            this.ultraLabel44.Text = "�~";
            // 
            // FractionProcCd_uLabel
            // 
            appearance52.TextVAlignAsString = "Middle";
            this.FractionProcCd_uLabel.Appearance = appearance52;
            this.FractionProcCd_uLabel.Location = new System.Drawing.Point(16, 309);
            this.FractionProcCd_uLabel.Name = "FractionProcCd_uLabel";
            this.FractionProcCd_uLabel.Size = new System.Drawing.Size(165, 24);
            this.FractionProcCd_uLabel.TabIndex = 171;
            this.FractionProcCd_uLabel.Text = "�[�������P��";
            // 
            // FractionProcCd_tComboEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.FractionProcCd_tComboEditor.ActiveAppearance = appearance19;
            appearance20.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.FractionProcCd_tComboEditor.Appearance = appearance20;
            this.FractionProcCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.FractionProcCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FractionProcCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance21.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.FractionProcCd_tComboEditor.ItemAppearance = appearance21;
            this.FractionProcCd_tComboEditor.Location = new System.Drawing.Point(221, 309);
            this.FractionProcCd_tComboEditor.Name = "FractionProcCd_tComboEditor";
            this.FractionProcCd_tComboEditor.Size = new System.Drawing.Size(224, 24);
            this.FractionProcCd_tComboEditor.TabIndex = 12;
            // 
            // AddPaymnt_uLabel
            // 
            appearance127.TextVAlignAsString = "Middle";
            this.AddPaymnt_uLabel.Appearance = appearance127;
            this.AddPaymnt_uLabel.Location = new System.Drawing.Point(236, 339);
            this.AddPaymnt_uLabel.Name = "AddPaymnt_uLabel";
            this.AddPaymnt_uLabel.Size = new System.Drawing.Size(199, 24);
            this.AddPaymnt_uLabel.TabIndex = 259;
            this.AddPaymnt_uLabel.Text = "���Z�z";
            // 
            // ultraLabel15
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance10;
            this.ultraLabel15.Location = new System.Drawing.Point(16, 641);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(403, 24);
            this.ultraLabel15.TabIndex = 171;
            this.ultraLabel15.Text = "�� �ݒ�l�𒴂����ꍇ�A���Z�z��0�~�ɂȂ�܂�";
            // 
            // MarketPriceQualityCd2_tComEditor
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance64.ForeColor = System.Drawing.Color.Black;
            appearance64.TextVAlignAsString = "Middle";
            this.MarketPriceQualityCd2_tComEditor.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceQualityCd2_tComEditor.Appearance = appearance65;
            this.MarketPriceQualityCd2_tComEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceQualityCd2_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceQualityCd2_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance69.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceQualityCd2_tComEditor.ItemAppearance = appearance69;
            this.MarketPriceQualityCd2_tComEditor.Location = new System.Drawing.Point(451, 201);
            this.MarketPriceQualityCd2_tComEditor.Name = "MarketPriceQualityCd2_tComEditor";
            this.MarketPriceQualityCd2_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceQualityCd2_tComEditor.TabIndex = 8;
            // 
            // MarketPriceQualityCd3_tComEditor
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.MarketPriceQualityCd3_tComEditor.ActiveAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.MarketPriceQualityCd3_tComEditor.Appearance = appearance32;
            this.MarketPriceQualityCd3_tComEditor.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 179 ) ) ) ), ( (int)( ( (byte)( 219 ) ) ) ), ( (int)( ( (byte)( 231 ) ) ) ));
            this.MarketPriceQualityCd3_tComEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MarketPriceQualityCd3_tComEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance33.BackColor = System.Drawing.Color.FromArgb(( (int)( ( (byte)( 247 ) ) ) ), ( (int)( ( (byte)( 227 ) ) ) ), ( (int)( ( (byte)( 156 ) ) ) ));
            this.MarketPriceQualityCd3_tComEditor.ItemAppearance = appearance33;
            this.MarketPriceQualityCd3_tComEditor.Location = new System.Drawing.Point(451, 228);
            this.MarketPriceQualityCd3_tComEditor.Name = "MarketPriceQualityCd3_tComEditor";
            this.MarketPriceQualityCd3_tComEditor.Size = new System.Drawing.Size(224, 24);
            this.MarketPriceQualityCd3_tComEditor.TabIndex = 10;
            // 
            // ultraLabel16
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance63;
            this.ultraLabel16.Location = new System.Drawing.Point(221, 150);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(165, 24);
            this.ultraLabel16.TabIndex = 266;
            this.ultraLabel16.Text = "���";
            // 
            // ultraLabel17
            // 
            appearance70.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance70;
            this.ultraLabel17.Location = new System.Drawing.Point(187, 174);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(28, 24);
            this.ultraLabel17.TabIndex = 267;
            this.ultraLabel17.Text = "1";
            // 
            // PMSCM09050UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(713, 734);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.ultraLabel16);
            this.Controls.Add(this.MarketPriceQualityCd3_tComEditor);
            this.Controls.Add(this.MarketPriceQualityCd2_tComEditor);
            this.Controls.Add(this.ultraLabel14);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.ultraLabel11);
            this.Controls.Add(this.ultraLabel4);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.SectionGuide_Button);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.MarketPriceKindCd1_tComboEditor);
            this.Controls.Add(this.MarketPriceAnswerDiv_tComboEditor);
            this.Controls.Add(this.ultraLabel34);
            this.Controls.Add(this.ultraLabel30);
            this.Controls.Add(this.ultraLabel33);
            this.Controls.Add(this.ultraLabel32);
            this.Controls.Add(this.ultraLabel27);
            this.Controls.Add(this.ultraLabel29);
            this.Controls.Add(this.ultraLabel31);
            this.Controls.Add(this.ultraLabel26);
            this.Controls.Add(this.ultraLabel28);
            this.Controls.Add(this.ultraLabel44);
            this.Controls.Add(this.ultraLabel42);
            this.Controls.Add(this.ultraLabel38);
            this.Controls.Add(this.ultraLabel41);
            this.Controls.Add(this.ultraLabel36);
            this.Controls.Add(this.ultraLabel43);
            this.Controls.Add(this.ultraLabel40);
            this.Controls.Add(this.ultraLabel37);
            this.Controls.Add(this.ultraLabel39);
            this.Controls.Add(this.ultraLabel35);
            this.Controls.Add(this.ultraLabel25);
            this.Controls.Add(this.AddPaymnt_uLabel);
            this.Controls.Add(this.AddPaymntAmbit_uLabel);
            this.Controls.Add(this.MarketPriceKindCd1_uLabel);
            this.Controls.Add(this.MarketPriceAnswerDiv_uLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.SectionName_tEdit);
            this.Controls.Add(this.Section_uLabel);
            this.Controls.Add(this.MarketPriceQualityCd_tComEditor);
            this.Controls.Add(this.MarketPriceQualityCd_uLabel);
            this.Controls.Add(this.MarketPriceAreaCd_tComEditor);
            this.Controls.Add(this.MarketPriceAreaCd_uLabel);
            this.Controls.Add(this.FractionProcCd_tComboEditor);
            this.Controls.Add(this.MarketPriceKindCd3_tComboEditor);
            this.Controls.Add(this.MarketPriceKindCd2_tComboEditor);
            this.Controls.Add(this.MarketPriceKindCd3_uLabel);
            this.Controls.Add(this.MarketPriceKindCd2_uLabel);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.tNedit_AddPaymnt10);
            this.Controls.Add(this.tNedit_AddPaymntAmbit10);
            this.Controls.Add(this.tNedit_AddPaymnt9);
            this.Controls.Add(this.tNedit_AddPaymntAmbit9);
            this.Controls.Add(this.tNedit_AddPaymnt8);
            this.Controls.Add(this.tNedit_AddPaymntAmbit8);
            this.Controls.Add(this.tNedit_AddPaymnt7);
            this.Controls.Add(this.tNedit_AddPaymntAmbit7);
            this.Controls.Add(this.tNedit_AddPaymnt6);
            this.Controls.Add(this.tNedit_AddPaymntAmbit6);
            this.Controls.Add(this.tNedit_AddPaymnt5);
            this.Controls.Add(this.tNedit_AddPaymntAmbit5);
            this.Controls.Add(this.tNedit_AddPaymnt4);
            this.Controls.Add(this.tNedit_AddPaymntAmbit4);
            this.Controls.Add(this.tNedit_AddPaymnt3);
            this.Controls.Add(this.tNedit_AddPaymntAmbit3);
            this.Controls.Add(this.tNedit_AddPaymnt2);
            this.Controls.Add(this.tNedit_AddPaymntAmbit2);
            this.Controls.Add(this.tNedit_AddPaymnt1);
            this.Controls.Add(this.tNedit_AddPaymntAmbit1);
            this.Controls.Add(this.tNedit_MarketPriceSalesRate);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.FractionProcCd_uLabel);
            this.Controls.Add(this.MarketPriceSalesRate_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 128 ) ));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ( (System.Drawing.Icon)( resources.GetObject("$this.Icon") ) );
            this.Name = "PMSCM09050UA";
            this.Text = "SCM���ꉿ�i�ݒ�";
            this.Load += new System.EventHandler(this.PMSCM09050UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMSCM09050UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMSCM09050UA_Closing);
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_MarketPriceSalesRate ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd2_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceAreaCd_tComEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd_tComEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.SectionName_tEdit ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.Bind_DataSet ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceAnswerDiv_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd1_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tEdit_SectionCodeAllowZero ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceKindCd3_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit3 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit4 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit5 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit6 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit7 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit8 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit9 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymntAmbit10 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt1 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt2 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt3 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt4 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt5 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt6 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt7 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt8 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt9 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.tNedit_AddPaymnt10 ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.FractionProcCd_tComboEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd2_tComEditor ) ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)( this.MarketPriceQualityCd3_tComEditor ) ).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region -- Events --
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region -- Private Members --
		private SCMMrktPriStAcs _scmMrktPriStAcs;
        private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _scmMrktPriStTable;

        private SecInfoAcs _secInfoAcs;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
		// �ۑ���r�pClone
		private SCMMrktPriSt _scmMrktPriStClone;

		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;

        // �V�K���[�h���烂�[�h�ύX�Ή�
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;

        // ������
        GetAreaListResType _getAreaListResType;         // ���ꉿ�i�n��
        GetQualityListResType _getQualityListResType;   // ���ꉿ�i�i��
        GetKindListResType _getKindListResType;         // ���ꉿ�i���

        private const string PROGRAM_ID = "PMSCM09050U";    // �v���O����ID

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";
        
		// Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";

        private const string VIEW_SECTION_CODE_TITLE = "���_�R�[�h";
        private const string VIEW_SECTION_NAME_TITLE = "���_����";

        private const string VIEW_MARKET_PRICE_AREA_CD = "���ꉿ�i�n��";
        // 2010/04/12 >>>
        //private const string VIEW_MARKET_PRICE_QUALITY_CD = "���ꉿ�i�i��";
        private const string VIEW_MARKET_PRICE_QUALITY_CD = "���ꉿ�i�i���P";
        private const string VIEW_MARKET_PRICE_QUALITY_CD2 = "���ꉿ�i�i���Q";
        private const string VIEW_MARKET_PRICE_QUALITY_CD3 = "���ꉿ�i�i���R";
        // 2010/04/12 <<<
        private const string VIEW_MARKET_PRICE_KIND_CD1 = "���ꉿ�i��ʂP";
        private const string VIEW_MARKET_PRICE_KIND_CD2 = "���ꉿ�i��ʂQ";
        private const string VIEW_MARKET_PRICE_KIND_CD3 = "���ꉿ�i��ʂR";
        private const string VIEW_MARKET_PRICE_ANSWER_DIV = "���ꉿ�i�񓚋敪";
        private const string VIEW_MARKET_PRICE_SALES_RATE = "���ꉿ�i������";
        private const string VIEW_FRACTION_PROC_CD = "�[�������P��";
        
        private const string VIEW_ADD_PAYMNT_AMBIT1 = "�����e�[�u���P";
        private const string VIEW_ADD_PAYMNT_AMBIT2 = "�����e�[�u���Q";
        private const string VIEW_ADD_PAYMNT_AMBIT3 = "�����e�[�u���R";
        private const string VIEW_ADD_PAYMNT_AMBIT4 = "�����e�[�u���S";
        private const string VIEW_ADD_PAYMNT_AMBIT5 = "�����e�[�u���T";
        private const string VIEW_ADD_PAYMNT_AMBIT6 = "�����e�[�u���U";
        private const string VIEW_ADD_PAYMNT_AMBIT7 = "�����e�[�u���V";
        private const string VIEW_ADD_PAYMNT_AMBIT8 = "�����e�[�u���W";
        private const string VIEW_ADD_PAYMNT_AMBIT9 = "�����e�[�u���X";
        private const string VIEW_ADD_PAYMNT_AMBIT10 = "�����e�[�u���P�O";

        private const string VIEW_ADD_PAYMNT_1 = "���Z�z�P";
        private const string VIEW_ADD_PAYMNT_2 = "���Z�z�Q";
        private const string VIEW_ADD_PAYMNT_3 = "���Z�z�R";
        private const string VIEW_ADD_PAYMNT_4 = "���Z�z�S";
        private const string VIEW_ADD_PAYMNT_5 = "���Z�z�T";
        private const string VIEW_ADD_PAYMNT_6 = "���Z�z�U";
        private const string VIEW_ADD_PAYMNT_7 = "���Z�z�V";
        private const string VIEW_ADD_PAYMNT_8 = "���Z�z�W";
        private const string VIEW_ADD_PAYMNT_9 = "���Z�z�X";
        private const string VIEW_ADD_PAYMNT_10 = "���Z�z�P�O";

        private const string VIEW_GUID_KEY_TITLE = "Guid";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";	   
		private const string DELETE_MODE = "�폜���[�h";

        // �S�Ћ���
        private const string ALL_SECTIONCODE = "00";
        
        // �ő���z
        private const int MAX_PAYMNT = 99999999;

		#endregion

		#region -- Main --
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMSCM09050UA());
		}
		# endregion

		#region -- Properties --
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{ 
				return this._canPrint; 
			}
		}

		/// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
		/// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{ 
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>��ʏI���ݒ�v���p�e�B</summary>
		/// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		/// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
		public bool CanClose
		{
			get
			{
				return this._canClose;
			}
			set
			{ 
				this._canClose = value; 
			}
		}

		/// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
		/// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>�폜�\�ݒ�v���p�e�B</summary>
		/// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
		/// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
		public int DataIndex
		{
			get
			{ 
				return this._dataIndex;
			}
			set
			{
				this._dataIndex = value;
			}
		}

		/// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
		/// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{ 
				return this._defaultAutoFillToColumn;
			}
		}

		/// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
		/// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}

        /// <summary>
        /// ��ƃR�[�h���擾���܂��B
        /// </summary>
        private static string EnterpriseCode
        {
            get { return LoginInfoAcquisition.EnterpriseCode; }
        }
		#endregion

		#region -- Public Methods --
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br></br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = VIEW_TABLE;
		}
		
		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
		///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br></br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList retList = null;

            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._scmMrktPriStTable.Clear();

            // �S����
            status = this._scmMrktPriStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

			switch(status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    int index = 0;

                    foreach (SCMMrktPriSt scmMrktPriSt in retList)
					{
                        // SCM���ꉿ�i�ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        SCMMrktPriStToDataSet(scmMrktPriSt.Clone(), index);
						++index;
					}
					break;
				}

				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}

				default:
				{
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                        PROGRAM_ID,							    // �A�Z���u��ID
                        this.Text,              �@�@            // �v���O��������
						"Search",                               // ��������
						TMsgDisp.OPE_GET,                       // �I�y���[�V����
						"�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._scmMrktPriStAcs,					    // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��

					break;
				}
			}
			return status;
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br></br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
            // �����Ȃ�
            return 9;
        }

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B</br>
		/// <br></br>
		/// </remarks>
		public int Delete()
		{
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMMrktPriSt scmMrktPriSt = (SCMMrktPriSt)this._scmMrktPriStTable[guid];

            // �S�Ћ��ʃf�[�^�͍폜�s��
            if (scmMrktPriSt.SectionCode.Trim() == ALL_SECTIONCODE)
            {
                TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                        PROGRAM_ID,							    // �A�Z���u��ID
                        "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
                        0,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                return (0);
            }
            
            int status;

            // SCM���ꉿ�i�ݒ���̘_���폜����
            status = this._scmMrktPriStAcs.LogicalDelete(ref scmMrktPriSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._scmMrktPriStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // SCM���ꉿ�i�ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            SCMMrktPriStToDataSet(scmMrktPriSt.Clone(), this.DataIndex);

            return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note        : ������������s���܂��B(������)</br>
		/// <br></br>
		/// </remarks>
		public int Print()
		{
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br></br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���_�R�[�h
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_����
			appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));

            // ���ꉿ�i�񓚋敪
            appearanceTable.Add(VIEW_MARKET_PRICE_ANSWER_DIV, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���ꉿ�i�n��
            appearanceTable.Add(VIEW_MARKET_PRICE_AREA_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Del >>>
            //// ���ꉿ�i�i��
            //appearanceTable.Add(VIEW_MARKET_PRICE_QUALITY_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Del <<<
            // ���ꉿ�i��ʂP
            appearanceTable.Add(VIEW_MARKET_PRICE_KIND_CD1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add >>>
            // ���ꉿ�i�i���P
            appearanceTable.Add(VIEW_MARKET_PRICE_QUALITY_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add <<<
            // ���ꉿ�i��ʂQ
            appearanceTable.Add(VIEW_MARKET_PRICE_KIND_CD2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add >>>
            // ���ꉿ�i�i���Q
            appearanceTable.Add(VIEW_MARKET_PRICE_QUALITY_CD2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add <<<
            // ���ꉿ�i��ʂR
            appearanceTable.Add(VIEW_MARKET_PRICE_KIND_CD3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add >>>
            // ���ꉿ�i�i���R
            appearanceTable.Add(VIEW_MARKET_PRICE_QUALITY_CD3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // 2010/04/12 Add <<<
            // ���ꉿ�i������
            appearanceTable.Add(VIEW_MARKET_PRICE_SALES_RATE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �[�������P��
            appearanceTable.Add(VIEW_FRACTION_PROC_CD, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            
            // �����e�[�u���P
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���Q
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���R
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���S
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���T
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���U
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���V
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���W
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT8, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���X
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT9, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // �����e�[�u���P�O
            appearanceTable.Add(VIEW_ADD_PAYMNT_AMBIT10, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));

            // ���Z�z�P
            appearanceTable.Add(VIEW_ADD_PAYMNT_1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�Q
            appearanceTable.Add(VIEW_ADD_PAYMNT_2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�R
            appearanceTable.Add(VIEW_ADD_PAYMNT_3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�S
            appearanceTable.Add(VIEW_ADD_PAYMNT_4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�T
            appearanceTable.Add(VIEW_ADD_PAYMNT_5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�U
            appearanceTable.Add(VIEW_ADD_PAYMNT_6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�V
            appearanceTable.Add(VIEW_ADD_PAYMNT_7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�W
            appearanceTable.Add(VIEW_ADD_PAYMNT_8, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�X
            appearanceTable.Add(VIEW_ADD_PAYMNT_9, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            // ���Z�z�P�O
            appearanceTable.Add(VIEW_ADD_PAYMNT_10, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
            
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			
			return appearanceTable;
		}
		# endregion

		#region -- Private Methods --
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SCMMrktPriSt scmMrktPriSt = new SCMMrktPriSt();
                //�N���[���쐬
                this._scmMrktPriStClone = scmMrktPriSt.Clone();
                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToSCMMrktPriSt(ref this._scmMrktPriStClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCodeAllowZero.Focus();
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SCMMrktPriSt scmMrktPriSt = (SCMMrktPriSt)this._scmMrktPriStTable[guid];

                // SCM���ꉿ�i�ݒ�N���X��ʓW�J����
                SCMMrktPriStToScreen(scmMrktPriSt);

                if (scmMrktPriSt.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.MarketPriceAnswerDiv_tComboEditor.Focus();

                    // �N���[���쐬
                    this._scmMrktPriStClone = scmMrktPriSt.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToSCMMrktPriSt(ref this._scmMrktPriStClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;
                        this.SectionName_tEdit.Enabled = false;
                        this.MarketPriceAnswerDiv_tComboEditor.Enabled = true;

                        // ���ꉿ�i�񓚋敪�ɂ����͋�����
                        MarketPriceAnswerDivPermissionControl();
                        
                        if (mode == INSERT_MODE)
                        {
                            // �V�K���[�h
                            this.tEdit_SectionCodeAllowZero.Enabled = true;
                            this.SectionGuide_Button.Enabled = true;
                        }
                        else
                        {
                            // �X�V���[�h
                            this.tEdit_SectionCodeAllowZero.Enabled = false;
                            this.SectionGuide_Button.Enabled = false;
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.tEdit_SectionCodeAllowZero.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        this.MarketPriceAnswerDiv_tComboEditor.Enabled = false;
                        this.MarketPriceAreaCd_tComEditor.Enabled = false;
                        this.MarketPriceQualityCd_tComEditor.Enabled = false;
                        this.MarketPriceKindCd1_tComboEditor.Enabled = false;
                        this.MarketPriceKindCd2_tComboEditor.Enabled = false;
                        this.MarketPriceKindCd3_tComboEditor.Enabled = false;
                        // 2010/04/12 Add >>>
                        this.MarketPriceQualityCd2_tComEditor.Enabled = false;
                        this.MarketPriceQualityCd3_tComEditor.Enabled = false;
                        // 2010/04/12 Add <<<
                        this.tNedit_MarketPriceSalesRate.Enabled = false;
                        
                        break;
                    }
            }
        }

        /// <summary>
        /// ���ꉿ�i�񓚋敪���䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i�񓚋敪�ɂ����͋��𐧌䂵�܂��B</br>
        /// <br></br>
        /// </remarks>
        private void MarketPriceAnswerDivPermissionControl()
        {
            if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 0)
            {
                // ���Ȃ�
                MarketPriceAreaCd_tComEditor.Enabled = false;
                MarketPriceQualityCd_tComEditor.Enabled = false;
                MarketPriceKindCd1_tComboEditor.Enabled = false;
                MarketPriceKindCd2_tComboEditor.Enabled = false;
                MarketPriceKindCd3_tComboEditor.Enabled = false;
                // 2010/04/12 Add >>>
                MarketPriceQualityCd2_tComEditor.Enabled = false;
                MarketPriceQualityCd3_tComEditor.Enabled = false;
                // 2010/04/12 Add <<<
                tNedit_MarketPriceSalesRate.Enabled = false;
                FractionProcCd_tComboEditor.Enabled = false;

                tNedit_AddPaymntAmbit1.Enabled = false;
                tNedit_AddPaymntAmbit2.Enabled = false;
                tNedit_AddPaymntAmbit3.Enabled = false;
                tNedit_AddPaymntAmbit4.Enabled = false;
                tNedit_AddPaymntAmbit5.Enabled = false;
                tNedit_AddPaymntAmbit6.Enabled = false;
                tNedit_AddPaymntAmbit7.Enabled = false;
                tNedit_AddPaymntAmbit8.Enabled = false;
                tNedit_AddPaymntAmbit9.Enabled = false;
                tNedit_AddPaymntAmbit10.Enabled = false;

                tNedit_AddPaymnt1.Enabled = false;
                tNedit_AddPaymnt2.Enabled = false;
                tNedit_AddPaymnt3.Enabled = false;
                tNedit_AddPaymnt4.Enabled = false;
                tNedit_AddPaymnt5.Enabled = false;
                tNedit_AddPaymnt6.Enabled = false;
                tNedit_AddPaymnt7.Enabled = false;
                tNedit_AddPaymnt8.Enabled = false;
                tNedit_AddPaymnt9.Enabled = false;
                tNedit_AddPaymnt10.Enabled = false;
            }
            else if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 1)
            {
                // ����i�������j
                MarketPriceAreaCd_tComEditor.Enabled = true;
                MarketPriceQualityCd_tComEditor.Enabled = true;
                MarketPriceKindCd1_tComboEditor.Enabled = true;
                MarketPriceKindCd2_tComboEditor.Enabled = true;
                MarketPriceKindCd3_tComboEditor.Enabled = true;
                // 2010/04/12 Add >>>
                MarketPriceQualityCd2_tComEditor.Enabled = true;
                MarketPriceQualityCd3_tComEditor.Enabled = true;
                // 2010/04/12 Add <<<
                tNedit_MarketPriceSalesRate.Enabled = true;
                FractionProcCd_tComboEditor.Enabled = true;

                tNedit_AddPaymntAmbit1.Enabled = false;
                tNedit_AddPaymntAmbit2.Enabled = false;
                tNedit_AddPaymntAmbit3.Enabled = false;
                tNedit_AddPaymntAmbit4.Enabled = false;
                tNedit_AddPaymntAmbit5.Enabled = false;
                tNedit_AddPaymntAmbit6.Enabled = false;
                tNedit_AddPaymntAmbit7.Enabled = false;
                tNedit_AddPaymntAmbit8.Enabled = false;
                tNedit_AddPaymntAmbit9.Enabled = false;
                tNedit_AddPaymntAmbit10.Enabled = false;

                tNedit_AddPaymnt1.Enabled = false;
                tNedit_AddPaymnt2.Enabled = false;
                tNedit_AddPaymnt3.Enabled = false;
                tNedit_AddPaymnt4.Enabled = false;
                tNedit_AddPaymnt5.Enabled = false;
                tNedit_AddPaymnt6.Enabled = false;
                tNedit_AddPaymnt7.Enabled = false;
                tNedit_AddPaymnt8.Enabled = false;
                tNedit_AddPaymnt9.Enabled = false;
                tNedit_AddPaymnt10.Enabled = false;
            }
            else if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 2)
            {
                // ����i���Z�e�[�u���j
                MarketPriceAreaCd_tComEditor.Enabled = true;
                MarketPriceQualityCd_tComEditor.Enabled = true;
                MarketPriceKindCd1_tComboEditor.Enabled = true;
                MarketPriceKindCd2_tComboEditor.Enabled = true;
                MarketPriceKindCd3_tComboEditor.Enabled = true;
                // 2010/04/12 Add >>>
                MarketPriceQualityCd2_tComEditor.Enabled = true;
                MarketPriceQualityCd3_tComEditor.Enabled = true;
                // 2010/04/12 Add <<<
                tNedit_MarketPriceSalesRate.Enabled = false;
                FractionProcCd_tComboEditor.Enabled = true;

                tNedit_AddPaymntAmbit1.Enabled = true;
                tNedit_AddPaymntAmbit2.Enabled = true;
                tNedit_AddPaymntAmbit3.Enabled = true;
                tNedit_AddPaymntAmbit4.Enabled = true;
                tNedit_AddPaymntAmbit5.Enabled = true;
                tNedit_AddPaymntAmbit6.Enabled = true;
                tNedit_AddPaymntAmbit7.Enabled = true;
                tNedit_AddPaymntAmbit8.Enabled = true;
                tNedit_AddPaymntAmbit9.Enabled = true;
                tNedit_AddPaymntAmbit10.Enabled = true;

                tNedit_AddPaymnt1.Enabled = true;
                tNedit_AddPaymnt2.Enabled = true;
                tNedit_AddPaymnt3.Enabled = true;
                tNedit_AddPaymnt4.Enabled = true;
                tNedit_AddPaymnt5.Enabled = true;
                tNedit_AddPaymnt6.Enabled = true;
                tNedit_AddPaymnt7.Enabled = true;
                tNedit_AddPaymnt8.Enabled = true;
                tNedit_AddPaymnt9.Enabled = true;
                tNedit_AddPaymnt10.Enabled = true;
            }

            // 2010/04/12 Add >>>
            if (MarketPriceKindCd2_tComboEditor.SelectedIndex == 0)
            {
                MarketPriceQualityCd2_tComEditor.Value = null;
                MarketPriceQualityCd2_tComEditor.Enabled = false;
            }

            if (MarketPriceKindCd3_tComboEditor.SelectedIndex == 0)
            {
                MarketPriceQualityCd3_tComEditor.Value = null;
                MarketPriceQualityCd3_tComEditor.Enabled = false;
            }
            // 2010/04/12 Add <<<
        }

		/// <summary>
		/// SCM���ꉿ�i�ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
        /// <param name="scmMrktPriSt">SCM���ꉿ�i�ݒ�I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
        /// <br>Note       : SCM���ꉿ�i�ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br></br>
		/// </remarks>
		private void SCMMrktPriStToDataSet(SCMMrktPriSt scmMrktPriSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}

            if (scmMrktPriSt.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = scmMrktPriSt.UpdateDateTimeJpInFormal;
            }

			// ���_�R�[�h
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmMrktPriSt.SectionCode;
            // ���_����
            string sectionName = GetSectionName(scmMrktPriSt.SectionCode);
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            // ���ꉿ�i�񓚋敪
            switch (scmMrktPriSt.MarketPriceAnswerDiv)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_ANSWER_DIV] = "���Ȃ�";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_ANSWER_DIV] = "����(������)";
                    break;
                case 2:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_ANSWER_DIV] = "����(���Z�e�[�u��)";
                    break;
            }

            // ���ꉿ�i�n��
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_AREA_CD] = GetMarketPriceAreaName(scmMrktPriSt.MarketPriceAreaCd);

            // 2010/04/12 Del >>>
            //// ���ꉿ�i�i��
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_QUALITY_CD] = GetMarketPriceQualityName(scmMrktPriSt.MarketPriceQualityCd);
            // 2010/04/12 Del <<<

            // ���ꉿ�i��ʂP
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_KIND_CD1] = GetMarketPriceKindName(scmMrktPriSt.MarketPriceKindCd1);

            // 2010/04/12 Add >>>
            // ���ꉿ�i�i���P
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_QUALITY_CD] = GetMarketPriceQualityName(scmMrktPriSt.MarketPriceQualityCd);
            // 2010/04/12 Add <<<

            // ���ꉿ�i��ʂQ
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_KIND_CD2] = GetMarketPriceKindName(scmMrktPriSt.MarketPriceKindCd2);

            // 2010/04/12 Add >>>
            // ���ꉿ�i�i���Q
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_QUALITY_CD2] = GetMarketPriceQualityName(scmMrktPriSt.MarketPriceQualityCd2);
            // 2010/04/12 Add <<<

            // ���ꉿ�i��ʂR
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_KIND_CD3] = GetMarketPriceKindName(scmMrktPriSt.MarketPriceKindCd3);

            // 2010/04/12 Add >>>
            // ���ꉿ�i�i���R
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_QUALITY_CD3] = GetMarketPriceQualityName(scmMrktPriSt.MarketPriceQualityCd3);
            // 2010/04/12 Add <<<

            // ���ꉿ�i������
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_MARKET_PRICE_SALES_RATE] = scmMrktPriSt.MarketPriceSalesRate;

            // �[�������P��
            switch (scmMrktPriSt.FractionProcCd)
            {
                case 0:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRACTION_PROC_CD] = "�P�O�~�P��(�l�̌ܓ�)";
                    break;
                case 1:
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_FRACTION_PROC_CD] = "�P�O�O�~�P��(�l�̌ܓ�)";
                    break;
            }

            // �����e�[�u���P
            if (scmMrktPriSt.AddPaymntAmbit1 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT1] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT1] = scmMrktPriSt.AddPaymntAmbit1.ToString("#,##0");
            }
            // �����e�[�u���Q
            if (scmMrktPriSt.AddPaymntAmbit2 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT2] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT2] = scmMrktPriSt.AddPaymntAmbit2.ToString("#,##0");
            }
            // �����e�[�u���R
            if (scmMrktPriSt.AddPaymntAmbit3 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT3] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT3] = scmMrktPriSt.AddPaymntAmbit3.ToString("#,##0");
            }
            // �����e�[�u���S
            if (scmMrktPriSt.AddPaymntAmbit4 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT4] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT4] = scmMrktPriSt.AddPaymntAmbit4.ToString("#,##0");
            }
            // �����e�[�u���T
            if (scmMrktPriSt.AddPaymntAmbit5 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT5] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT5] = scmMrktPriSt.AddPaymntAmbit5.ToString("#,##0");
            }
            // �����e�[�u���U
            if (scmMrktPriSt.AddPaymntAmbit6 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT6] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT6] = scmMrktPriSt.AddPaymntAmbit6.ToString("#,##0");
            }
            // �����e�[�u���V
            if (scmMrktPriSt.AddPaymntAmbit7 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT7] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT7] = scmMrktPriSt.AddPaymntAmbit7.ToString("#,##0");
            }
            // �����e�[�u���W
            if (scmMrktPriSt.AddPaymntAmbit8 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT8] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT8] = scmMrktPriSt.AddPaymntAmbit8.ToString("#,##0");
            }
            // �����e�[�u���X
            if (scmMrktPriSt.AddPaymntAmbit9 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT9] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT9] = scmMrktPriSt.AddPaymntAmbit9.ToString("#,##0");
            }
            // �����e�[�u���P�O
            if (scmMrktPriSt.AddPaymntAmbit10 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT10] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_AMBIT10] = scmMrktPriSt.AddPaymntAmbit10.ToString("#,##0");
            }

            // ���Z�z�P
            if (scmMrktPriSt.AddPaymnt1 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_1] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_1] = scmMrktPriSt.AddPaymnt1.ToString("#,##0");
            }
            // ���Z�z�Q
            if (scmMrktPriSt.AddPaymnt2 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_2] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_2] = scmMrktPriSt.AddPaymnt2.ToString("#,##0");
            }
            // ���Z�z�R
            if (scmMrktPriSt.AddPaymnt3 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_3] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_3] = scmMrktPriSt.AddPaymnt3.ToString("#,##0");
            }
            // ���Z�z�S
            if (scmMrktPriSt.AddPaymnt4 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_4] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_4] = scmMrktPriSt.AddPaymnt4.ToString("#,##0");
            }
            // ���Z�z�T
            if (scmMrktPriSt.AddPaymnt5 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_5] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_5] = scmMrktPriSt.AddPaymnt5.ToString("#,##0");
            }
            // ���Z�z�U
            if (scmMrktPriSt.AddPaymnt6 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_6] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_6] = scmMrktPriSt.AddPaymnt6.ToString("#,##0");
            }
            // ���Z�z�V
            if (scmMrktPriSt.AddPaymnt7 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_7] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_7] = scmMrktPriSt.AddPaymnt7.ToString("#,##0");
            }
            // ���Z�z�W
            if (scmMrktPriSt.AddPaymnt8 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_8] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_8] = scmMrktPriSt.AddPaymnt8.ToString("#,##0");
            }
            // ���Z�z�X
            if (scmMrktPriSt.AddPaymnt9 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_9] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_9] = scmMrktPriSt.AddPaymnt9.ToString("#,##0");
            }
            // ���Z�z�P�O
            if (scmMrktPriSt.AddPaymnt10 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_10] = string.Empty;
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_ADD_PAYMNT_10] = scmMrktPriSt.AddPaymnt10.ToString("#,##0");
            }

            // Guid
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = scmMrktPriSt.FileHeaderGuid;
			
			if (this._scmMrktPriStTable.ContainsKey(scmMrktPriSt.FileHeaderGuid) == true)
			{
				this._scmMrktPriStTable.Remove(scmMrktPriSt.FileHeaderGuid);
			}
			this._scmMrktPriStTable.Add(scmMrktPriSt.FileHeaderGuid, scmMrktPriSt);
		}

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br></br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable scmMrktPriStTable = new DataTable(VIEW_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B

            scmMrktPriStTable.Columns.Add(DELETE_DATE, typeof(string));			                // �폜��
            
            scmMrktPriStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));             // ���_�R�[�h
			scmMrktPriStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));             // ���_����

            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_ANSWER_DIV, typeof(string));        // ���ꉿ�i�񓚋敪
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_AREA_CD, typeof(string));           // ���ꉿ�i�n��
            // 2010/04/12 Del >>>
            //scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_QUALITY_CD, typeof(string));        // ���ꉿ�i�i��
            // 2010/04/12 Del <<<
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_KIND_CD1, typeof(string));          // ���ꉿ�i��ʂP
            // 2010/04/12 Add >>>
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_QUALITY_CD, typeof(string));        // ���ꉿ�i�i���P
            // 2010/04/12 Add <<<
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_KIND_CD2, typeof(string));          // ���ꉿ�i��ʂQ
            // 2010/04/12 Add >>>
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_QUALITY_CD2, typeof(string));       // ���ꉿ�i�i���Q
            // 2010/04/12 Add <<<
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_KIND_CD3, typeof(string));          // ���ꉿ�i��ʂR
            // 2010/04/12 Add >>>
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_QUALITY_CD3, typeof(string));       // ���ꉿ�i�i���R
            // 2010/04/12 Add <<<
            scmMrktPriStTable.Columns.Add(VIEW_MARKET_PRICE_SALES_RATE, typeof(string));        // ���ꉿ�i������
            scmMrktPriStTable.Columns.Add(VIEW_FRACTION_PROC_CD, typeof(string));               // �[�������P��

            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT1, typeof(string));              // �����e�[�u���P
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT2, typeof(string));              // �����e�[�u���Q
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT3, typeof(string));              // �����e�[�u���R
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT4, typeof(string));              // �����e�[�u���S
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT5, typeof(string));              // �����e�[�u���T
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT6, typeof(string));              // �����e�[�u���U
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT7, typeof(string));              // �����e�[�u���V
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT8, typeof(string));              // �����e�[�u���W
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT9, typeof(string));              // �����e�[�u���X
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_AMBIT10, typeof(string));             // �����e�[�u���P�O

            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_1, typeof(string));                   // ���Z�z�P
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_2, typeof(string));                   // ���Z�z�Q
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_3, typeof(string));                   // ���Z�z�R
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_4, typeof(string));                   // ���Z�z�S
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_5, typeof(string));                   // ���Z�z�T
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_6, typeof(string));                   // ���Z�z�U
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_7, typeof(string));                   // ���Z�z�V
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_8, typeof(string));                   // ���Z�z�W
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_9, typeof(string));                   // ���Z�z�X
            scmMrktPriStTable.Columns.Add(VIEW_ADD_PAYMNT_10, typeof(string));                  // ���Z�z�P�O

            scmMrktPriStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                   // Guid

			this.Bind_DataSet.Tables.Add(scmMrktPriStTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br></br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            // ���ꉿ�i�񓚋敪
            MarketPriceAnswerDiv_tComboEditor.Items.Clear();
            MarketPriceAnswerDiv_tComboEditor.Items.Add(0, "���Ȃ�");
            MarketPriceAnswerDiv_tComboEditor.Items.Add(1, "����(������)");
            MarketPriceAnswerDiv_tComboEditor.Items.Add(2, "����(���Z�e�[�u��)");
            MarketPriceAnswerDiv_tComboEditor.MaxDropDownItems = MarketPriceAnswerDiv_tComboEditor.Items.Count;

            // ���ꉿ�i�n��
            SetMarketPriceAreaCd_tComEditor();
            
            // ���ꉿ�i�i��
            SetMarketPriceQualityCd_tComEditor();
            
            // ���ꉿ�i��ʂP
            SetMarketPriceKindCd1_tComboEditor();
            
            // ���ꉿ�i��ʂQ
            SetMarketPriceKindCd2_tComboEditor();
            
            // ���ꉿ�i��ʂR
            SetMarketPriceKindCd3_tComboEditor();
            
            // �[�������P��
            FractionProcCd_tComboEditor.Items.Clear();
            FractionProcCd_tComboEditor.Items.Add(0, "�P�O�~�P��(�l�̌ܓ�)");
            FractionProcCd_tComboEditor.Items.Add(1, "�P�O�O�~�P��(�l�̌ܓ�)");
            FractionProcCd_tComboEditor.MaxDropDownItems = FractionProcCd_tComboEditor.Items.Count;
            
        }

        /// <summary>
        /// ������擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void GetSobaInfo()
        {
            // ���ꉿ�i�n��̏��擾
            AreaService areaService = new AreaService();
            GetAreaListReqType getAreaListReqType = new GetAreaListReqType();
            {
                getAreaListReqType.UC = EnterpriseCode;
            }
            this._getAreaListResType = areaService.GetAreaList(getAreaListReqType);
            if (this._getAreaListResType == null)
            {
                this._getAreaListResType = new GetAreaListResType();
            }

            // ���ꉿ�i�i���̏��擾
            QualityService qualityService = new QualityService();
            GetQualityListReqType getQualityListReqType = new GetQualityListReqType();
            {
                getQualityListReqType.UC = EnterpriseCode;
            }
            this._getQualityListResType = qualityService.GetQualityList(getQualityListReqType);
            if (this._getQualityListResType == null)
            {
                this._getQualityListResType = new GetQualityListResType();
            }

            // ���ꉿ�i��ʂ̏��擾
            KindService kindService = new KindService();
            GetKindListReqType getKindListReqType = new GetKindListReqType();
            {
                getKindListReqType.UC = EnterpriseCode;
            }
            this._getKindListResType = kindService.GetKindList(getKindListReqType);
            if (this._getKindListResType == null)
            {
                this._getKindListResType = new GetKindListResType();
            }
        }

        /// <summary>
        /// ���ꉿ�i�n�於�̎擾����
        /// </summary>
        /// <param name="marketPriceAreaCd">���ꉿ�i�n��R�[�h</param>
        /// <returns>���ꉿ�i�n�於��</returns>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i�n�於�̂̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetMarketPriceAreaName(int marketPriceAreaCd)
        {
            string name = string.Empty;

            foreach (AreaType areaListType in this._getAreaListResType.AreaList)
            {
                if (marketPriceAreaCd == areaListType.AreaCode)
                {
                    name = areaListType.AreaName;
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// ���ꉿ�i�i�����̎擾����
        /// </summary>
        /// <param name="marketPriceQualityCd">���ꉿ�i�i���R�[�h</param>
        /// <returns>���ꉿ�i�i������</returns>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i�i�����̂̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetMarketPriceQualityName(int marketPriceQualityCd)
        {
            string name = string.Empty;

            foreach (QualityType qualityListType in this._getQualityListResType.QualityList)
            {
                if (marketPriceQualityCd == qualityListType.QualityCode)
                {
                    name = qualityListType.QualityName;
                    break;
                }
            }

            return name;
        }

        /// <summary>
        /// ���ꉿ�i��ʖ��̎擾����
        /// </summary>
        /// <param name="marketPriceQualityCd">���ꉿ�i��ʃR�[�h</param>
        /// <returns>���ꉿ�i��ʖ���</returns>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i��ʖ��̂̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetMarketPriceKindName(int marketPriceKindCd)
        {
            string name = string.Empty;

            if (marketPriceKindCd == -1)
            {
                name = "�Ȃ�";
            }
            else
            {
                foreach (KindType kindListType in this._getKindListResType.KindList)
                {
                    if (marketPriceKindCd == kindListType.KindCode)
                    {
                        name = kindListType.KindName;
                        break;
                    }
                }
            }

            return name;
        }

        /// <summary>
        /// ���ꉿ�i�n��R���{�G�f�B�^�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i�n��R���{�G�f�B�^�̐ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceAreaCd_tComEditor()
        {
            MarketPriceAreaCd_tComEditor.Items.Clear();

            foreach (AreaType areaListType in this._getAreaListResType.AreaList)
            {
                MarketPriceAreaCd_tComEditor.Items.Add(areaListType.AreaCode, areaListType.AreaName);
            }

            MarketPriceAreaCd_tComEditor.MaxDropDownItems = MarketPriceAreaCd_tComEditor.Items.Count;
        }

        /// <summary>
        /// ���ꉿ�i�i���R���{�G�f�B�^�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i�i���R���{�G�f�B�^�̐ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceQualityCd_tComEditor()
        {
            MarketPriceQualityCd_tComEditor.Items.Clear();
            // 2010/04/12 Add >>>
            MarketPriceQualityCd2_tComEditor.Items.Clear();
            MarketPriceQualityCd3_tComEditor.Items.Clear();
            // 2010/04/12 Add <<<

            foreach (QualityType qualityListType in this._getQualityListResType.QualityList)
            {
                MarketPriceQualityCd_tComEditor.Items.Add(qualityListType.QualityCode, qualityListType.QualityName);
                // 2010/04/12 >>>
                MarketPriceQualityCd2_tComEditor.Items.Add(qualityListType.QualityCode, qualityListType.QualityName);
                MarketPriceQualityCd3_tComEditor.Items.Add(qualityListType.QualityCode, qualityListType.QualityName);
                // 2010/04/12 <<<
            }


            MarketPriceQualityCd_tComEditor.MaxDropDownItems = MarketPriceQualityCd_tComEditor.Items.Count;
            // 2010/04/12 Add >>>
            MarketPriceQualityCd2_tComEditor.MaxDropDownItems = MarketPriceQualityCd2_tComEditor.Items.Count;
            MarketPriceQualityCd3_tComEditor.MaxDropDownItems = MarketPriceQualityCd3_tComEditor.Items.Count;
            // 2010/04/12 Add <<<
        }
       
        /// <summary>
        /// ���ꉿ�i��ʂP�R���{�G�f�B�^�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i��ʂP�R���{�G�f�B�^�̐ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceKindCd1_tComboEditor()
        {
            MarketPriceKindCd1_tComboEditor.Items.Clear();

            foreach (KindType kindListType in this._getKindListResType.KindList)
            {
                MarketPriceKindCd1_tComboEditor.Items.Add(kindListType.KindCode, kindListType.KindName);
            }
            
            MarketPriceKindCd1_tComboEditor.MaxDropDownItems = MarketPriceKindCd1_tComboEditor.Items.Count;
        }

        /// <summary>
        /// ���ꉿ�i��ʃR���{�G�f�B�^�Q�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i��ʂQ�R���{�G�f�B�^�̐ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceKindCd2_tComboEditor()
        {
            MarketPriceKindCd2_tComboEditor.Items.Clear();
            MarketPriceKindCd2_tComboEditor.Items.Add(-1, "�Ȃ�");

            foreach (KindType kindListType in this._getKindListResType.KindList)
            {
                MarketPriceKindCd2_tComboEditor.Items.Add(kindListType.KindCode, kindListType.KindName);
            }

            MarketPriceKindCd2_tComboEditor.MaxDropDownItems = MarketPriceKindCd2_tComboEditor.Items.Count;
        }

        /// <summary>
        /// ���ꉿ�i��ʂR�R���{�G�f�B�^�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ꉿ�i��ʂR�R���{�G�f�B�^�̐ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetMarketPriceKindCd3_tComboEditor()
        {
            MarketPriceKindCd3_tComboEditor.Items.Clear();
            MarketPriceKindCd3_tComboEditor.Items.Add(-1, "�Ȃ�");

            foreach (KindType kindListType in this._getKindListResType.KindList)
            {
                MarketPriceKindCd3_tComboEditor.Items.Add(kindListType.KindCode, kindListType.KindName);
            }

            MarketPriceKindCd3_tComboEditor.MaxDropDownItems = MarketPriceKindCd3_tComboEditor.Items.Count;
        }

       	/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note        : ��ʂ��N���A���܂��B</br>
		/// <br></br>
		/// </remarks>
		private void ScreenClear()
		{
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.SectionName_tEdit.DataText = "";

            this.MarketPriceAnswerDiv_tComboEditor.SelectedIndex = 0;   // ���ꉿ�i�񓚋敪
            this.MarketPriceAreaCd_tComEditor.SelectedIndex = 0;        // ���ꉿ�i�n��
            this.MarketPriceQualityCd_tComEditor.SelectedIndex = 0;     // ���ꉿ�i�i��
            // 2010/04/12 Add >>>
            this.MarketPriceQualityCd2_tComEditor.SelectedIndex = -1;    // ���ꉿ�i�i���Q
            this.MarketPriceQualityCd3_tComEditor.SelectedIndex = -1;    // ���ꉿ�i�i���R
            // 2010/04/12 Add <<<
            this.MarketPriceKindCd1_tComboEditor.SelectedIndex = 0;     // ���ꉿ�i��ʂP
            this.MarketPriceKindCd2_tComboEditor.SelectedIndex = 0;     // ���ꉿ�i��ʂQ
            this.MarketPriceKindCd3_tComboEditor.SelectedIndex = 0;     // ���ꉿ�i��ʂR
            this.tNedit_MarketPriceSalesRate.DataText = "";             // ���ꉿ�i������
            this.FractionProcCd_tComboEditor.SelectedIndex = 0;         // �[�������P��

            this.tNedit_AddPaymntAmbit1.Clear();                        // �����e�[�u���P
            this.tNedit_AddPaymntAmbit2.Clear();                        // �����e�[�u���Q
            this.tNedit_AddPaymntAmbit3.Clear();                        // �����e�[�u���R
            this.tNedit_AddPaymntAmbit4.Clear();                        // �����e�[�u���S
            this.tNedit_AddPaymntAmbit5.Clear();                        // �����e�[�u���T
            this.tNedit_AddPaymntAmbit6.Clear();                        // �����e�[�u���U
            this.tNedit_AddPaymntAmbit7.Clear();                        // �����e�[�u���V
            this.tNedit_AddPaymntAmbit8.Clear();                        // �����e�[�u���W
            this.tNedit_AddPaymntAmbit9.Clear();                        // �����e�[�u���X
            this.tNedit_AddPaymntAmbit10.Clear();                       // �����e�[�u���P�O

            this.tNedit_AddPaymnt1.Clear();                             // ���Z�z�P
            this.tNedit_AddPaymnt2.Clear();                             // ���Z�z�Q
            this.tNedit_AddPaymnt3.Clear();                             // ���Z�z�R
            this.tNedit_AddPaymnt4.Clear();                             // ���Z�z�S
            this.tNedit_AddPaymnt5.Clear();                             // ���Z�z�T
            this.tNedit_AddPaymnt6.Clear();                             // ���Z�z�U
            this.tNedit_AddPaymnt7.Clear();                             // ���Z�z�V
            this.tNedit_AddPaymnt8.Clear();                             // ���Z�z�W
            this.tNedit_AddPaymnt9.Clear();                             // ���Z�z�X
            this.tNedit_AddPaymnt10.Clear();                            // ���Z�z�P�O
        }

		/// <summary>
        /// SCM���ꉿ�i�ݒ�N���X��ʓW�J����
		/// </summary>
        /// <param name="scmMrktPriSt">SCM���ꉿ�i�ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : SCM���ꉿ�i�ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br></br>
		/// </remarks>
		private void SCMMrktPriStToScreen(SCMMrktPriSt scmMrktPriSt)
		{
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.DataText = scmMrktPriSt.SectionCode;
            // ���_����
            string sectionName = string.Empty;
            if (scmMrktPriSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            {
                sectionName = "�S�Ћ���";
            }
            else
            {
                sectionName = this.GetSectionName(scmMrktPriSt.SectionCode);
            }
            this.SectionName_tEdit.DataText = sectionName;

            // ���ꉿ�i�񓚋敪
            this.MarketPriceAnswerDiv_tComboEditor.SelectedIndex = scmMrktPriSt.MarketPriceAnswerDiv;

            // ���ꉿ�i�n��
            this.MarketPriceAreaCd_tComEditor.Value = scmMrktPriSt.MarketPriceAreaCd;

            // ���ꉿ�i�i��
            this.MarketPriceQualityCd_tComEditor.Value = scmMrktPriSt.MarketPriceQualityCd;

            // 2010/04/12 Add >>>
            // ���ꉿ�i�i���Q
            this.MarketPriceQualityCd2_tComEditor.Value = scmMrktPriSt.MarketPriceQualityCd2;

            // ���ꉿ�i�i���R
            this.MarketPriceQualityCd3_tComEditor.Value = scmMrktPriSt.MarketPriceQualityCd3;
            // 2010/04/12 Add <<<

            // ���ꉿ�i��ʂP
            this.MarketPriceKindCd1_tComboEditor.Value = scmMrktPriSt.MarketPriceKindCd1;

            // ���ꉿ�i��ʂQ
            this.MarketPriceKindCd2_tComboEditor.Value = scmMrktPriSt.MarketPriceKindCd2;

            // ���ꉿ�i��ʂR
            this.MarketPriceKindCd3_tComboEditor.Value = scmMrktPriSt.MarketPriceKindCd3;

            // ���ꉿ�i������
			this.tNedit_MarketPriceSalesRate.DataText = scmMrktPriSt.MarketPriceSalesRate.ToString();

            // �[�������P��
            this.FractionProcCd_tComboEditor.Value = scmMrktPriSt.FractionProcCd;

            // 

            // �����e�[�u���P
            this.tNedit_AddPaymntAmbit1.SetInt(scmMrktPriSt.AddPaymntAmbit1);
            // �����e�[�u���Q
            this.tNedit_AddPaymntAmbit2.SetInt(scmMrktPriSt.AddPaymntAmbit2);
            // �����e�[�u���R
            this.tNedit_AddPaymntAmbit3.SetInt(scmMrktPriSt.AddPaymntAmbit3);
            // �����e�[�u���S
            this.tNedit_AddPaymntAmbit4.SetInt(scmMrktPriSt.AddPaymntAmbit4);
            // �����e�[�u���T
            this.tNedit_AddPaymntAmbit5.SetInt(scmMrktPriSt.AddPaymntAmbit5);
            // �����e�[�u���U
            this.tNedit_AddPaymntAmbit6.SetInt(scmMrktPriSt.AddPaymntAmbit6);
            // �����e�[�u���V
            this.tNedit_AddPaymntAmbit7.SetInt(scmMrktPriSt.AddPaymntAmbit7);
            // �����e�[�u���W
            this.tNedit_AddPaymntAmbit8.SetInt(scmMrktPriSt.AddPaymntAmbit8);
            // �����e�[�u���X
            this.tNedit_AddPaymntAmbit9.SetInt(scmMrktPriSt.AddPaymntAmbit9);
            // �����e�[�u���P�O
            this.tNedit_AddPaymntAmbit10.SetInt(scmMrktPriSt.AddPaymntAmbit10);

            // ���Z�z�P
            this.tNedit_AddPaymnt1.SetInt(scmMrktPriSt.AddPaymnt1);
            // ���Z�z�Q
            this.tNedit_AddPaymnt2.SetInt(scmMrktPriSt.AddPaymnt2);
            // ���Z�z�R
            this.tNedit_AddPaymnt3.SetInt(scmMrktPriSt.AddPaymnt3);
            // ���Z�z�S
            this.tNedit_AddPaymnt4.SetInt(scmMrktPriSt.AddPaymnt4);
            // ���Z�z�T
            this.tNedit_AddPaymnt5.SetInt(scmMrktPriSt.AddPaymnt5);
            // ���Z�z�U
            this.tNedit_AddPaymnt6.SetInt(scmMrktPriSt.AddPaymnt6);
            // ���Z�z�V
            this.tNedit_AddPaymnt7.SetInt(scmMrktPriSt.AddPaymnt7);
            // ���Z�z�W
            this.tNedit_AddPaymnt8.SetInt(scmMrktPriSt.AddPaymnt8);
            // ���Z�z�X
            this.tNedit_AddPaymnt9.SetInt(scmMrktPriSt.AddPaymnt9);
            // ���Z�z�P�O
            this.tNedit_AddPaymnt10.SetInt(scmMrktPriSt.AddPaymnt10);

        }

		/// <summary>
        /// ��ʏ��SCM���ꉿ�i�ݒ�N���X�i�[����
		/// </summary>
        /// <param name="scmMrktPriSt">SCM���ꉿ�i�ݒ�I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : ��ʏ�񂩂�SCM���ꉿ�i�ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br></br>
		/// </remarks>
		private void ScreenToSCMMrktPriSt(ref SCMMrktPriSt scmMrktPriSt)
		{
			if (scmMrktPriSt == null)
			{
				// �V�K�̏ꍇ
                scmMrktPriSt = new SCMMrktPriSt();
			}

            //��ƃR�[�h
            scmMrktPriSt.EnterpriseCode = this._enterpriseCode; 
            // ���_�R�[�h
            scmMrktPriSt.SectionCode = this.tEdit_SectionCodeAllowZero.DataText;

            // ���ꉿ�i�񓚋敪
            scmMrktPriSt.MarketPriceAnswerDiv = (int)this.MarketPriceAnswerDiv_tComboEditor.Value;

            // ���ꉿ�i�n��
            if (this.MarketPriceAreaCd_tComEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceAreaCd = (int)this.MarketPriceAreaCd_tComEditor.Value;
            }

            // ���ꉿ�i�i��
            if (this.MarketPriceQualityCd_tComEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceQualityCd = (int)this.MarketPriceQualityCd_tComEditor.Value;
            }

            // 2010/04/12 Add >>>
            // ���ꉿ�i�i���Q
            if (this.MarketPriceQualityCd2_tComEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceQualityCd2 = (int)this.MarketPriceQualityCd2_tComEditor.Value;
            }
            else
            {
                scmMrktPriSt.MarketPriceQualityCd2 = -1;
            }

            // ���ꉿ�i�i���R
            if (this.MarketPriceQualityCd3_tComEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceQualityCd3 = (int)this.MarketPriceQualityCd3_tComEditor.Value;
            }
            else
            {
                scmMrktPriSt.MarketPriceQualityCd3 = -1;
            }
            // 2010/04/12 Add <<<

            // ���ꉿ�i��ʂP
            if (this.MarketPriceKindCd1_tComboEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceKindCd1 = (int)this.MarketPriceKindCd1_tComboEditor.Value;
            }

            // ���ꉿ�i��ʂQ
            if (this.MarketPriceKindCd2_tComboEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceKindCd2 = (int)this.MarketPriceKindCd2_tComboEditor.Value;
            }

            // ���ꉿ�i��ʂR
            if (this.MarketPriceKindCd3_tComboEditor.Value != null)
            {
                scmMrktPriSt.MarketPriceKindCd3 = (int)this.MarketPriceKindCd3_tComboEditor.Value;
            }

            // ���ꉿ�i������
            scmMrktPriSt.MarketPriceSalesRate =  this.tNedit_MarketPriceSalesRate.GetValue();

            // �[�������P��
            scmMrktPriSt.FractionProcCd = (int)this.FractionProcCd_tComboEditor.Value;

            // ���Z�z�͈�
            scmMrktPriSt.AddPaymntAmbit1 = this.tNedit_AddPaymntAmbit1.GetInt();
            scmMrktPriSt.AddPaymntAmbit2 = this.tNedit_AddPaymntAmbit2.GetInt();
            scmMrktPriSt.AddPaymntAmbit3 = this.tNedit_AddPaymntAmbit3.GetInt();
            scmMrktPriSt.AddPaymntAmbit4 = this.tNedit_AddPaymntAmbit4.GetInt();
            scmMrktPriSt.AddPaymntAmbit5 = this.tNedit_AddPaymntAmbit5.GetInt();
            scmMrktPriSt.AddPaymntAmbit6 = this.tNedit_AddPaymntAmbit6.GetInt();
            scmMrktPriSt.AddPaymntAmbit7 = this.tNedit_AddPaymntAmbit7.GetInt();
            scmMrktPriSt.AddPaymntAmbit8 = this.tNedit_AddPaymntAmbit8.GetInt();
            scmMrktPriSt.AddPaymntAmbit9 = this.tNedit_AddPaymntAmbit9.GetInt();
            scmMrktPriSt.AddPaymntAmbit10 = this.tNedit_AddPaymntAmbit10.GetInt();

            // ���Z�z
            scmMrktPriSt.AddPaymnt1 = this.tNedit_AddPaymnt1.GetInt();
            scmMrktPriSt.AddPaymnt2 = this.tNedit_AddPaymnt2.GetInt();
            scmMrktPriSt.AddPaymnt3 = this.tNedit_AddPaymnt3.GetInt();
            scmMrktPriSt.AddPaymnt4 = this.tNedit_AddPaymnt4.GetInt();
            scmMrktPriSt.AddPaymnt5 = this.tNedit_AddPaymnt5.GetInt();
            scmMrktPriSt.AddPaymnt6 = this.tNedit_AddPaymnt6.GetInt();
            scmMrktPriSt.AddPaymnt7 = this.tNedit_AddPaymnt7.GetInt();
            scmMrktPriSt.AddPaymnt8 = this.tNedit_AddPaymnt8.GetInt();
            scmMrktPriSt.AddPaymnt9 = this.tNedit_AddPaymnt9.GetInt();
            scmMrktPriSt.AddPaymnt10 = this.tNedit_AddPaymnt10.GetInt();
		}

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ��r�p�N���[���N���A
            this._scmMrktPriStClone = null;

            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
		{
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
		}

		/// <summary>
		///	SCM���ꉿ�i�ݒ��ʓ��̓`�F�b�N����
		/// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : SCM���ꉿ�i�ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
		/// <br></br>
		/// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
		{
            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                message = this.Section_uLabel.Text + "��ݒ肵�ĉ������B";
                control = this.tEdit_SectionCodeAllowZero;
                return false;
            }

            // ���ꉿ�i�񓚋敪
            if (this.MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 1)
            {
                // ����(������)
                if (this.tNedit_MarketPriceSalesRate.DataText == "")
                {
                    message = this.MarketPriceSalesRate_uLabel.Text + "��ݒ肵�ĉ������B";
                    control = this.tNedit_MarketPriceSalesRate;
                    return false;
                }
            }
            else if (this.MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 2)
            {
                int maxPaymnt = 0;
                // ����(�����z)
                // �����e�[�u���P
                if (tNedit_AddPaymntAmbit1.GetInt() == 0)
                {
                    message = "�����e�[�u���P��ݒ肵�ĉ������B";
                    control = this.tNedit_AddPaymntAmbit1;
                    return false;
                }
                else if (tNedit_AddPaymnt1.GetInt() == 0)
                {
                    message = "���Z�z�P��ݒ肵�ĉ������B";
                    control = this.tNedit_AddPaymntAmbit1;
                    return false;
                }

                if (!InputDataSeqCheck(ref control))
                {
                    message = "�����e�[�u���P���珇�ɐݒ肵�ĉ������B";
                    return false;
                }

                // �����e�[�u���Q
                maxPaymnt = tNedit_AddPaymntAmbit1.GetInt();
                if (tNedit_AddPaymntAmbit2.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt2.GetInt() == 0)
                    {
                        message = "���Z�z�Q��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt2;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit2.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���Q�́A�����e�[�u���P���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit2;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt2.GetInt() != 0)
                    {
                        message = "�����e�[�u���Q��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt2;
                        return false;
                    }
                }

                // �����e�[�u���R
                maxPaymnt = tNedit_AddPaymntAmbit2.GetInt();
                if (tNedit_AddPaymntAmbit3.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt3.GetInt() == 0)
                    {
                        message = "���Z�z�R��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt3;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit3.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���R�́A�����e�[�u���Q���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit3;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt3.GetInt() != 0)
                    {
                        message = "�����e�[�u���R��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt3;
                        return false;
                    }
                }

                // �����e�[�u���S
                maxPaymnt = tNedit_AddPaymntAmbit3.GetInt();
                if (tNedit_AddPaymntAmbit4.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt4.GetInt() == 0)
                    {
                        message = "���Z�z�S��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt4;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit4.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���S�́A�����e�[�u���R���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit4;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt4.GetInt() != 0)
                    {
                        message = "�����e�[�u���S��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt4;
                        return false;
                    }
                }

                // �����e�[�u���T
                maxPaymnt = tNedit_AddPaymntAmbit4.GetInt();
                if (tNedit_AddPaymntAmbit5.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt5.GetInt() == 0)
                    {
                        message = "���Z�z�T��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt5;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit5.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���T�́A�����e�[�u���S���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit5;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt5.GetInt() != 0)
                    {
                        message = "�����e�[�u���T��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt5;
                        return false;
                    }
                }

                // �����e�[�u���U
                maxPaymnt = tNedit_AddPaymntAmbit5.GetInt();
                if (tNedit_AddPaymntAmbit6.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt6.GetInt() == 0)
                    {
                        message = "���Z�z�U��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt6;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit6.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���U�́A�����e�[�u���T���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit6;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt6.GetInt() != 0)
                    {
                        message = "�����e�[�u���U��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt6;
                        return false;
                    }
                }

                // �����e�[�u���V
                maxPaymnt = tNedit_AddPaymntAmbit6.GetInt();
                if (tNedit_AddPaymntAmbit7.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt7.GetInt() == 0)
                    {
                        message = "���Z�z�V��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt7;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit7.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���V�́A�����e�[�u���U���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit7;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt7.GetInt() != 0)
                    {
                        message = "�����e�[�u���V��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt7;
                        return false;
                    }
                }

                // �����e�[�u���W
                maxPaymnt = tNedit_AddPaymntAmbit7.GetInt();
                if (tNedit_AddPaymntAmbit8.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt8.GetInt() == 0)
                    {
                        message = "���Z�z�W��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt8;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit8.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���W�́A�����e�[�u���V���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit8;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt8.GetInt() != 0)
                    {
                        message = "�����e�[�u���W��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt8;
                        return false;
                    }
                }

                // �����e�[�u���X
                maxPaymnt = tNedit_AddPaymntAmbit8.GetInt();
                if (tNedit_AddPaymntAmbit9.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt9.GetInt() == 0)
                    {
                        message = "���Z�z�X��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt9;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit9.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���X�́A�����e�[�u���W���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit9;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt9.GetInt() != 0)
                    {
                        message = "�����e�[�u���X��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt9;
                        return false;
                    }
                }

                // �����e�[�u���P�O
                maxPaymnt = tNedit_AddPaymntAmbit9.GetInt();
                if (tNedit_AddPaymntAmbit10.GetInt() != 0)
                {
                    if (tNedit_AddPaymnt10.GetInt() == 0)
                    {
                        message = "���Z�z�P�O��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt10;
                        return false;
                    }
                    else if (tNedit_AddPaymntAmbit10.GetInt() <= maxPaymnt)
                    {
                        message = "�����e�[�u���P�O�́A�����e�[�u���X���傫�����z��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymntAmbit10;
                        return false;
                    }
                }
                else
                {
                    if (tNedit_AddPaymnt10.GetInt() != 0)
                    {
                        message = "�����e�[�u���P�O��ݒ肵�ĉ������B";
                        control = this.tNedit_AddPaymnt10;
                        return false;
                    }
                }
            }

            return true;
		}

        /// <summary>
        ///	�����e�[�u�����͏��`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : �����e�[�u���̓��͏��`�F�b�N�����܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool InputDataSeqCheck(ref Control control)
        {
            bool input = true;

            // �����e�[�u���Q
            if ((tNedit_AddPaymntAmbit2.GetInt() == 0) && (tNedit_AddPaymnt2.GetInt() == 0))
            {
                input = false;
            }

            // �����e�[�u���R
            if ((tNedit_AddPaymntAmbit3.GetInt() == 0) && (tNedit_AddPaymnt3.GetInt() == 0))
            {
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit3;
                    return false;
                }
            }

            // �����e�[�u���S
            if ((tNedit_AddPaymntAmbit4.GetInt() == 0) && (tNedit_AddPaymnt4.GetInt() == 0))
            {
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit4;
                    return false;
                }
            }

            // �����e�[�u���T
            if ((tNedit_AddPaymntAmbit5.GetInt() == 0) && (tNedit_AddPaymnt5.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit5;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit5;
                    return false;
                }
            }

            // �����e�[�u���U
            if ((tNedit_AddPaymntAmbit6.GetInt() == 0) && (tNedit_AddPaymnt6.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit6;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit6;
                    return false;
                }
            }

            // �����e�[�u���V
            if ((tNedit_AddPaymntAmbit7.GetInt() == 0) && (tNedit_AddPaymnt7.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit7;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit7;
                    return false;
                }
            }

            // �����e�[�u���W
            if ((tNedit_AddPaymntAmbit8.GetInt() == 0) && (tNedit_AddPaymnt8.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit8;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit8;
                    return false;
                }
            }

            // �����e�[�u���X
            if ((tNedit_AddPaymntAmbit9.GetInt() == 0) && (tNedit_AddPaymnt9.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit9;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit9;
                    return false;
                }
            }

            // �����e�[�u���P�O
            if ((tNedit_AddPaymntAmbit10.GetInt() == 0) && (tNedit_AddPaymnt10.GetInt() == 0))
            {
                //if (input)
                //{
                //    control = this.tNedit_AddPaymntAmbit10;
                //    return false;
                //}
                input = false;
            }
            else
            {
                if (!input)
                {
                    control = this.tNedit_AddPaymntAmbit10;
                    return false;
                }
            }




            //// �����e�[�u���Q
            //if ((tNedit_AddPaymntAmbit2.GetInt() == 0) && (tNedit_AddPaymnt2.GetInt() == 0))
            //{
            //    input = false;
            //}

            //// �����e�[�u���R
            //if ((tNedit_AddPaymntAmbit3.GetInt() == 0) && (tNedit_AddPaymnt3.GetInt() == 0))
            //{
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit3;
            //        return false;
            //    }
            //}

            //// �����e�[�u���S
            //if ((tNedit_AddPaymntAmbit4.GetInt() == 0) && (tNedit_AddPaymnt4.GetInt() == 0))
            //{
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit4;
            //        return false;
            //    }
            //}

            //// �����e�[�u���T
            //if ((tNedit_AddPaymntAmbit5.GetInt() == 0) && (tNedit_AddPaymnt5.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit5;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit5;
            //        return false;
            //    }
            //}

            //// �����e�[�u���U
            //if ((tNedit_AddPaymntAmbit6.GetInt() == 0) && (tNedit_AddPaymnt6.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit6;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit6;
            //        return false;
            //    }
            //}

            //// �����e�[�u���V
            //if ((tNedit_AddPaymntAmbit7.GetInt() == 0) && (tNedit_AddPaymnt7.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit7;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit7;
            //        return false;
            //    }
            //}

            //// �����e�[�u���W
            //if ((tNedit_AddPaymntAmbit8.GetInt() == 0) && (tNedit_AddPaymnt8.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit8;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit8;
            //        return false;
            //    }
            //}

            //// �����e�[�u���X
            //if ((tNedit_AddPaymntAmbit9.GetInt() == 0) && (tNedit_AddPaymnt9.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit9;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit9;
            //        return false;
            //    }
            //}

            //// �����e�[�u���P�O
            //if ((tNedit_AddPaymntAmbit10.GetInt() == 0) && (tNedit_AddPaymnt10.GetInt() == 0))
            //{
            //    if (input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit10;
            //        return false;
            //    }
            //    input = false;
            //}
            //else
            //{
            //    if (!input)
            //    {
            //        control = this.tNedit_AddPaymntAmbit10;
            //        return false;
            //    }
            //}

            return true;
        }

		/// <summary>
        ///�@�ۑ�����(SaveProc())
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
		/// <br></br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;
            
			//��ʃf�[�^���̓`�F�b�N����
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this, 								// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                    PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                    message, 							// �\�����郁�b�Z�[�W
                    0, 									// �X�e�[�^�X�l
                    MessageBoxButtons.OK);				// �\������{�^��
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }
	
			SCMMrktPriSt scmMrktPriSt = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                scmMrktPriSt = ((SCMMrktPriSt)this._scmMrktPriStTable[guid]).Clone();
			}

            // ��ʏ����擾
			ScreenToSCMMrktPriSt(ref scmMrktPriSt);
            // �o�^�E�X�V����
			int status = this._scmMrktPriStAcs.Write(ref scmMrktPriSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                {
                    RepeatTransaction(status, ref control);
                    control.Focus();
                    return false;
                }
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    // �r������
                    ExclusiveTransaction(status, true);					
					
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return false;
				}
				default:
				{
					TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                        PROGRAM_ID,							    // �A�Z���u��ID
						this.Text,  �@�@                        // �v���O��������
                        "SaveProc",                             // ��������
						TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
						"�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._scmMrktPriStAcs,				    	// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,			  		// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
                    CloseForm(DialogResult.Cancel);
					return false;
				}
			}

            // SCM���ꉿ�i�ݒ���N���X�̃f�[�^�Z�b�g�W�J����
			SCMMrktPriStToDataSet(scmMrktPriSt, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			this.DialogResult = DialogResult.OK;
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
			result = true;
			return result;
		}


        /// <summary>
        ///�@���������b�Z�[�W�\��
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �Y���R�[�h���g�p����Ă���ꍇ�Ƀ��b�Z�[�W��\�����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�͊��Ɏg�p����Ă��܂�" ,// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
                tEdit_SectionCodeAllowZero.Focus();

                control = tEdit_SectionCodeAllowZero;
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(190, 24);
            this.tNedit_MarketPriceSalesRate.Size = new System.Drawing.Size(100, 24);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // �S�Ћ��ʃ`�F�b�N
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "�S�Ћ���";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            string msg = "���͂��ꂽ�R�[�h��SCM���ꉿ�i�ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero.Text.TrimEnd().PadLeft(2, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                if (sectionCd.Equals(dsSecCd.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��SCM���ꉿ�i�ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���_�R�[�h�A���̂̃N���A
                        tEdit_SectionCodeAllowZero.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == ALL_SECTIONCODE)
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h��SCM���ꉿ�i�ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PROGRAM_ID,                             // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���_�R�[�h�A���̂̃N���A
                                tEdit_SectionCodeAllowZero.Clear();
                                SectionName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        # endregion

        # region -- Control Events --
       	/// <summary>
        ///	Form.Load �C�x���g(PMSCM09050UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09050UA_Load(object sender, System.EventArgs e)
		{
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
            
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
            
			// ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
        ///	Form.Closing �C�x���g(PMSCM09050UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
		///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09050UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;
			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			//�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}		
		}

		/// <summary>
        ///	Form.VisibleChanged �C�x���g(PMSCM09050UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
		///					  ���Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void PMSCM09050UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				// ���C���t���[���A�N�e�B�u��
				this.Owner.Activate();
				return;
			}

			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			
            // ��ʃN���A
			ScreenClear();

            Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
            // �o�^�E�X�V����
			if (!SaveProc())
			{
				return;
			}
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br></br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SCMMrktPriSt compareSCMMrktPriSt = new SCMMrktPriSt();

                compareSCMMrktPriSt = this._scmMrktPriStClone.Clone();
                ScreenToSCMMrktPriSt(ref compareSCMMrktPriSt);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._scmMrktPriStClone.Equals(compareSCMMrktPriSt))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // �G���[���x��
                        PROGRAM_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        null, 					                              // �\�����郁�b�Z�[�W
                        0, 					                                  // �X�e�[�^�X�l
                        MessageBoxButtons.YesNoCancel);	                      // �\������{�^��

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                if (!SaveProc())
                                {
                                    return;
                                }
                                return;
                            }
                        case DialogResult.No:
                            {
                                // ��ʔ�\���C�x���g
                                if (UnDisplaying != null)
                                {
                                    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
                                    UnDisplaying(this, me);
                                }
                                break;
                            }
                        default:
                            {
                                // �V�K���[�h���烂�[�h�ύX�Ή�
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                return;
                            }
                    }
                }
            }
            
            this.DialogResult = DialogResult.Cancel;
			this._indexBuf = -2;

			// CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
			// �t�H�[�����\��������B
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}

		/// <summary>
		/// Timer.Tick �C�x���g(timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br></br>
		/// </remarks>
		private void Timer_Tick(object sender, System.EventArgs e)
		{
			Timer.Enabled = false;

            // ��ʕ\������
			ScreenReconstruction();
		}

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    this.MarketPriceAnswerDiv_tComboEditor.Focus();

                    // �V�K���[�h���烂�[�h�ύX�Ή�
                    if (this.DataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            if (result != DialogResult.OK)
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMMrktPriSt scmMrktPriSt = (SCMMrktPriSt)this._scmMrktPriStTable[guid];

            // ���S�폜����
            int status = this._scmMrktPriStAcs.Delete(scmMrktPriSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._scmMrktPriStTable.Remove(scmMrktPriSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // ���S�폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._scmMrktPriStAcs, 				    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SCMMrktPriSt scmMrktPriSt = ((SCMMrktPriSt)this._scmMrktPriStTable[guid]).Clone();

            // ��������
            status = this._scmMrktPriStAcs.Revival(ref scmMrktPriSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // SCM���ꉿ�i�ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        SCMMrktPriStToDataSet(scmMrktPriSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._scmMrktPriStAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // �V�K���[�h���烂�[�h�ύX�Ή�
            _modeFlg = false;

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;

                // ���_���̎擾
                this.SectionName_tEdit.DataText = GetSectionName(sectionCode);

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // �t�H�[�J�X�ݒ�
                            e.NextCtrl = this.MarketPriceAnswerDiv_tComboEditor;
                        }
                    }
                }

                // �V�K���[�h���烂�[�h�ύX�Ή�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // �ŐV���{�^���͍X�V�`�F�b�N����O��
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero;
                    }
                }
            }
            else if (e.PrevCtrl == Renewal_Button)
            {
                // �ŐV���{�^������̑J�ڎ��A�X�V�`�F�b�N��ǉ�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "tEdit_SectionCodeAllowZero")
                {
                    ;
                }
                else if (this._dataIndex < 0)
                {
                    if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero;
                    }
                }
            }
            else if (e.PrevCtrl == MarketPriceAnswerDiv_tComboEditor)
            {
                if ((e.ShiftKey) && (e.Key == Keys.Tab))
                {
                    // SHIFT+TAB����
                    if (!tEdit_SectionCodeAllowZero.Enabled)
                    {
                        e.NextCtrl = Cancel_Button;
                    }
                    else
                    {
                        if (SectionName_tEdit.DataText != "")
                        {
                            e.NextCtrl = tEdit_SectionCodeAllowZero;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// �ŐV���{�^���N���b�N
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            this._secInfoAcs.ResetSectionInfo();

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
        }

        /// <summary>
        /// MarketPriceAnswerDiv_tComboEditor_ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void MarketPriceAnswerDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // ���ꉿ�i�񓚋敪�ɂ����͋�����
            MarketPriceAnswerDivPermissionControl();

            // �N���A����
            if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 0)
            {
                // ���Ȃ�
                MarketPriceAreaCd_tComEditor.SelectedIndex = 0;
                MarketPriceQualityCd_tComEditor.SelectedIndex = 0;
                // 2010/04/12 Add >>>
                MarketPriceQualityCd2_tComEditor.SelectedIndex = -1;
                MarketPriceQualityCd3_tComEditor.SelectedIndex = -1;
                // 2010/04/12 Add <<<
                MarketPriceKindCd1_tComboEditor.SelectedIndex = 0;
                MarketPriceKindCd2_tComboEditor.SelectedIndex = 0;
                MarketPriceKindCd3_tComboEditor.SelectedIndex = 0;
                tNedit_MarketPriceSalesRate.Clear();
                FractionProcCd_tComboEditor.SelectedIndex = 0;

                tNedit_AddPaymntAmbit1.Clear();
                tNedit_AddPaymntAmbit2.Clear();
                tNedit_AddPaymntAmbit3.Clear();
                tNedit_AddPaymntAmbit4.Clear();
                tNedit_AddPaymntAmbit5.Clear();
                tNedit_AddPaymntAmbit6.Clear();
                tNedit_AddPaymntAmbit7.Clear();
                tNedit_AddPaymntAmbit8.Clear();
                tNedit_AddPaymntAmbit9.Clear();
                tNedit_AddPaymntAmbit10.Clear();

                tNedit_AddPaymnt1.Clear();
                tNedit_AddPaymnt2.Clear();
                tNedit_AddPaymnt3.Clear();
                tNedit_AddPaymnt4.Clear();
                tNedit_AddPaymnt5.Clear();
                tNedit_AddPaymnt6.Clear();
                tNedit_AddPaymnt7.Clear();
                tNedit_AddPaymnt8.Clear();
                tNedit_AddPaymnt9.Clear();
                tNedit_AddPaymnt10.Clear();
            }
            else if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 1)
            {
                // ����i�������j
                tNedit_AddPaymntAmbit1.Clear();
                tNedit_AddPaymntAmbit2.Clear();
                tNedit_AddPaymntAmbit3.Clear();
                tNedit_AddPaymntAmbit4.Clear();
                tNedit_AddPaymntAmbit5.Clear();
                tNedit_AddPaymntAmbit6.Clear();
                tNedit_AddPaymntAmbit7.Clear();
                tNedit_AddPaymntAmbit8.Clear();
                tNedit_AddPaymntAmbit9.Clear();
                tNedit_AddPaymntAmbit10.Clear();

                tNedit_AddPaymnt1.Clear();
                tNedit_AddPaymnt2.Clear();
                tNedit_AddPaymnt3.Clear();
                tNedit_AddPaymnt4.Clear();
                tNedit_AddPaymnt5.Clear();
                tNedit_AddPaymnt6.Clear();
                tNedit_AddPaymnt7.Clear();
                tNedit_AddPaymnt8.Clear();
                tNedit_AddPaymnt9.Clear();
                tNedit_AddPaymnt10.Clear();
            }
            else if (MarketPriceAnswerDiv_tComboEditor.SelectedIndex == 2)
            {
                // ����i���Z�e�[�u���j
                tNedit_MarketPriceSalesRate.Clear();
                FractionProcCd_tComboEditor.SelectedIndex = 0;
            }
        }

        // ADD 2009/08/26 �`�P�b�g[14168]�Ή��F���ꉿ�i��������100%�ȏ� ---------->>>>>
        /// <summary>
        /// ���ꉿ�i�������e�L�X�g��Leave�C�x���g�n���h��
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tNedit_MarketPriceSalesRate_Leave(object sender, EventArgs e)
        {
            double marketPriceSalesRate = 0.0;
            if (!string.IsNullOrEmpty(this.tNedit_MarketPriceSalesRate.Text.Trim()))
            {
                marketPriceSalesRate = double.Parse(this.tNedit_MarketPriceSalesRate.Text.Trim());
            }
            if (marketPriceSalesRate < 100.0)
            {
                TMsgDisp.Show(
                    this,                                           // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,			        // �G���[���x��
                    PROGRAM_ID,							            // �A�Z���u��ID
                    this.Text,              �@�@                    // �v���O��������
                    "tNedit_MarketPriceSalesRate_Leave",            // ��������
                    TMsgDisp.OPE_GET,                               // �I�y���[�V����
                    "���ꉿ�i�������� 100%�ȏ� ��ݒ肵�ĉ������B", // �\�����郁�b�Z�[�W
                    0,							                    // �X�e�[�^�X�l
                    this,			                                // �G���[�����������I�u�W�F�N�g
                    MessageBoxButtons.OK,			                // �\������{�^��
                    MessageBoxDefaultButton.Button1                 // �����\���{�^��
                );
                this.tNedit_MarketPriceSalesRate.Focus();
            }
        }

        // ADD 2009/08/26 �`�P�b�g[14168]�Ή��F���ꉿ�i��������100%�ȏ� ----------<<<<<

        // 2010/04/12 Add >>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarketPriceKindCd2_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if ((int)MarketPriceKindCd2_tComboEditor.Value == -1)
            {
                MarketPriceQualityCd2_tComEditor.Value = null;
                MarketPriceQualityCd2_tComEditor.Enabled = false;
            }
            else
            {
                MarketPriceQualityCd2_tComEditor.Enabled = true;
                if (MarketPriceQualityCd2_tComEditor.Value == null)
                {
                    this.MarketPriceQualityCd2_tComEditor.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarketPriceKindCd3_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if ((int)MarketPriceKindCd3_tComboEditor.Value == -1)
            {
                MarketPriceQualityCd3_tComEditor.Value = null;
                MarketPriceQualityCd3_tComEditor.Enabled = false;
            }
            else
            {
                MarketPriceQualityCd3_tComEditor.Enabled = true;
                if (MarketPriceQualityCd3_tComEditor.Value == null)
                {
                    this.MarketPriceQualityCd3_tComEditor.SelectedIndex = 0;
                }
            }
        }
        // 2010/04/12 Add <<<

		#endregion
	}
}

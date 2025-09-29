# region ��using
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Agent;   // 2008.09.04 �ǉ�
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using Infragistics.Win.UltraWinTabControl;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller.Facade;          // ADD 2008/10/10 �s��Ή�[6442] 
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �]�ƈ������̓t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �]�ƈ����ݒ���s���܂��B
	///					 IMasterMaintenanceMultiType���������Ă��܂��B</br>
	/// <br>Programmer	: 980076 �Ȓ��@����Y</br>
	/// <br>Date		: 2004.03.19</br>
	/// <br>Update Note	: 2005.11.15  23006 ���� ���q</br>
	/// <br>			  �E�Q�ƌ^�R���{�{�b�N�X�u�폜�ρv�\���Ή�</br>
	/// <br>Update Note	: 2005.11.16 23002 ���@�k��</br>
	/// <br>			  �E�Q�Ƃ���Ă���]�ƈ��̍폜�h�~</br>
	/// <br>Update Note	: 2005.11.17 22011 �����@���l</br>
	/// <br>			  �E�Q�Ƃ���Ă���]�ƈ��̍폜�h�~�̑Ή����R�����g�A�E�g</br>
	/// <br>Update Note	: 2006.06.20 23001 �H�R�@����</br>
	/// <br>              1.���o���[�g�����ނ�DD�̕ύX�Ή�</br>
	/// <br>Update Note	: 2006.06.29 22033 �O��  �M�j</br>
	/// <br>              �E���_OP�̔�����C��</br>
	/// <br>Update Note	: 2006.09.05 22033 �O��  �M�j</br>
	/// <br>              �E�t���[���O���b�h�̗񏇂��C��</br>
	/// <br>              �E�\�[�X����������</br>
    /// <br>Update Note	: 2006.12.11 20031 �É�@���S��</br>
    /// <br>              �ESF����Mobile�p�ɍ��ڕύX�i�폜�̂݁j</br>
    /// <br>Update Note	: 2007.04.02 20031 �É�@���S��</br>
    /// <br>              �E�u���o���@�ݒ�v�{�^����L�����疳���ɕύX(�g�юd�l)</br>
    /// <br>Update Note : 2007.05.22 20008 �ɓ��@�L</br>
    /// <br>              �E�擾���ڂɁu�������x���P�v�u�������x���Q�v��ǉ�</br>
    /// <br>Update Note	: 2007.07.17 20031 �É�@���S��</br>
    /// <br>              �E�u�������_�v�̔w�i�F��F�ɕύX</br>
    /// <br>Update Note : 2007.08.14 980035 ���� ��`</br>
    /// <br>              1.�]�ƈ��ڍ׃}�X�^�̒ǉ�</br>
    /// <br>Update Note : 2008.06.04 30414 �E�@�K�j</br>
    /// <br>              �E�u�����ہv�u���������ύX���v�u���������_�v�u����������v�u�������ہv�폜</br>
    /// <br>Update Note : 2008.09.04 30434 �H���@�b�D</br>
    /// <br>              �E�u�E��v�R���{�A�u�ٗp�`�ԁv�R���{�̍��ڐݒ�̕ύX</br>
    /// <br>UpdateNote : 2008/10/06 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2008/10/09 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2008/10/10 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2008/11/04 30462 �s�V �m���@�o�O�C��</br>
    /// <br>UpdateNote   : 2008/11/10 30009 �a�J ���@UOE���̋敪�ǉ�</br>
    /// <br>UpdateNote   : 2008/11/12 30009 �a�J ���@�p�X���[�h�`�F�b�N�����̃o�O�C��</br>
    /// <br>UpdateNote   : 2008/11/14 30009 �a�J ���@�o�O�C��[7905]</br>
    /// <br>UpdateNote   : 2009/02/13 30414 �E �K�j�@�o�O�C��[11419]</br>
    /// <br>UpdateNote   : 2009.03.02 20056 ���n ���@���[�����ڒǉ�</br>
    /// <br>UpdateNote   : 2009.03.17 30414 �E �K�j�@��ʐ���ǉ�(���[�U�[�Ǘ��҃t���O)[11347]</br>
    /// <br>Update Note : 2010/02/18 30517 �Ė� �x��</br>
    /// <br>              �Efelica�Ή��E�f���p��felica�I�v�V�����`�F�b�N�i_optFeliCaAcs�j�ɂ�true���Z�b�g���Ă��܂�</br>
	/// <br>Update Note : 2012.05.29 30182 ���J�@����</br>
	/// <br>              �E�u����`�[���͋N�������v�u���Ӑ�d�q�����N�������v���ڒǉ�</br>
    /// <br>Update Note: 2013/05/21 huangt </br>
    /// <br>�Ǘ��ԍ�   : 10902175-00 6��18���z�M���i��Q�ȊO�j</br>
    /// <br>           : Redmine#35765 �]�ƈ��}�X�^ �N�������̃G���[�`�F�b�N�̒ǉ�</br>
	/// </remarks>
	public class SFTOK09380UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region ��Private Members (Component)

		private Infragistics.Win.Misc.UltraLabel Sex_Title_Label;
		private Infragistics.Win.Misc.UltraLabel Birthday_Title_Label;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TComboEditor Sex_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TEdit tEdit_EmployeeCode;
		private Infragistics.Win.Misc.UltraLabel EmployeeCode_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit Name_tEdit;
		private Infragistics.Win.Misc.UltraLabel Name_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit Kana_tEdit;
		private Infragistics.Win.Misc.UltraLabel Kana_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit ShortName_tEdit;
		private Infragistics.Win.Misc.UltraLabel ShortName_Title_Label;
		private Infragistics.Win.Misc.UltraLabel RetirementDtTm_Title_Label;
		private Infragistics.Win.Misc.UltraLabel EnterCompanyDtTm_Title_Label;
		private Infragistics.Win.Misc.UltraLabel PortableTelNo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTelNo_Title_Label;
        private Infragistics.Win.Misc.UltraLabel BelongSelectionCode_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit LoginPassword_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit LoginId_tEdit;
		private Infragistics.Win.Misc.UltraLabel LoginPassword_Title_Label;
		private Infragistics.Win.Misc.UltraLabel LoginId_Title_Label;
		private Infragistics.Win.Misc.UltraLabel LoginPasswordAgain_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit LoginPasswordAgain_tEdit;
		private Infragistics.Win.UltraWinTabControl.UltraTabControl MainTabControl;
		private Infragistics.Win.Misc.UltraLabel Guid_Label;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 EnterCompanyDate_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 RetirementDate_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelNo_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PortableTelNo_tEdit;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl GeneralTabPageControl;
		private Infragistics.Win.UltraWinTabControl.UltraTabPageControl SecurityTabPageControl;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TDateEdit2 Birthday_tDateEdit;
		private Broadleaf.Library.Windows.Forms.TImeControl tImeControl1;
		private Infragistics.Win.Misc.UltraLabel UserAdminFlag_uLabel;
		private Infragistics.Win.Misc.UltraLabel UserAdminName_uLabel;
        private Infragistics.Win.Misc.UltraLabel JobType_ultraLabel;
        private TComboEditor JobType_tComboEditor;
        private TComboEditor EmploymentForm_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel EmploymentForm_ultraLabel;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl DetailsTabPageControl;
        private Infragistics.Win.Misc.UltraLabel ultraLabel4;
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private TEdit tEdit_SectionName;
        private TEdit tEdit_SectionCode;
        private TNedit EmployAnalysCode6_tNedit;
        private TNedit EmployAnalysCode5_tNedit;
        private TNedit EmployAnalysCode4_tNedit;
        private TNedit EmployAnalysCode3_tNedit;
        private TNedit EmployAnalysCode2_tNedit;
        private TNedit EmployAnalysCode1_tNedit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private TNedit tNedit_SubSectionCode;
        private Infragistics.Win.Misc.UltraButton BelongSubSectionGuide_ultraButton;
        private TEdit BelongSubSectionName_tEdit;
        private Infragistics.Win.Misc.UltraLabel BelongSubSectionTitle_Label;
        private Infragistics.Win.Misc.UltraLabel UOESnmDivTitle_Label;
        private TEdit UOESnmDiv_tEdit;
        private TEdit MailAddress2_tEdit;
        private TEdit MailAddress1_tEdit;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel FeliCaInfo_Title_uLabel;
        private Infragistics.Win.Misc.UltraLabel FeliCaInfo_uLabel;
        private Infragistics.Win.Misc.UltraButton FeliCaMngGuide_uButton;
        private Infragistics.Win.Misc.UltraButton FeliCaMngDelete_uButton;
		private TNedit CustLedgerBootCnt_tNedit;
		private TNedit SalSlipInpBootCnt_tNedit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel12;
		private Infragistics.Win.Misc.UltraLabel ultraLabel13;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private System.ComponentModel.IContainer components;
		# endregion

		# region ��Constructor
		/// <summary>
		/// �]�ƈ������̓t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �]�ƈ������̓t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public SFTOK09380UA()
		{
			InitializeComponent();

            // 2010/02/18 Add felica�I�v�V�����`�F�b�N >>>
            //this._optFeliCaAcs = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FelicaAccessService) > 0);
            this._optFeliCaAcs = true;
            // 2010/02/18 Add <<<

            // �f�[�^�Z�b�g����\�z����
			DataSetColumnConstruction();

			// �v���p�e�B�����l�ݒ�
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// �f�t�H���g:true�Œ�
			this._defaultAutoFillToColumn = false;
            // 2007.04.02  S.Koga  amend -----------------------------------------------------------------------
			//this._canSpecificationSearch = true;
            this._canSpecificationSearch = false;
            // -------------------------------------------------------------------------------------------------
            // 2007.08.14 �ǉ� >>>>>>>>>>
            this._canSpecificationSearch = false;
            // 2007.08.14 �ǉ� <<<<<<<<<<

			//�@��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// �ϐ�������
			this._dataIndex = -1;
			this._secInfoAcs = new SecInfoAcs(1);
			this._employeeAcs = new EmployeeAcs();
            //this._userGuideAcs = new UserGuideAcs();    // DEL 2008/11/04 �s��Ή�[7289]
			this._prevEmployee = null;
			this._nextData = false;
			this._totalCount = 0;
			this._employeeTable = new Hashtable();

            this.AuthorityLevel1Table = new Hashtable();
            this.AuthorityLevel2Table = new Hashtable();

            this._employeeDtl = new EmployeeDtl();      // 2007.08.14 �ǉ�
            this._companyInfAcs = new CompanyInfAcs();  // 2008.01.16 �ǉ�

            this._subSectionAcs = new SubSectionAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            
            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
			this._indexBuf = -2;

			// ���_OP�̔���
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- >>>>>
            // ���j���[�ȈՋN���I�v�V�����̔���
            this._opMenuSimpleStart = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_MenuSimpleStart) > 0);
            // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- <<<<<

            // 2007.09.04 �폜����ђǉ� >>>>>>>>>>
            //// �������x���P�̐ݒ�
            //this.AuthorityLevel1Table.Clear();
            //this.AuthorityLevel1Table.Add("100", "�{��");
            //this.AuthorityLevel1Table.Add("80", "�X��");
            //this.AuthorityLevel1Table.Add("70", "�X���̔���(���Ј�)");
            //this.AuthorityLevel1Table.Add("60", "�X���̔���(�A���o�C�g)");
            //this.AuthorityLevel1Table.Add("40", "�o�b�N���[�h�S����");
            //this.AuthorityLevel1Table.Add("20", "����(���Ј�)");
            //this.AuthorityLevel1Table.Add("10", "����(�A���o�C�g)");
            //this.AuthorityLevel1Table.Add("0", "");

            //// �������x���Q�̐ݒ�
            //this.AuthorityLevel2Table.Clear();
            //this.AuthorityLevel2Table.Add("50", "���Ј�");
            //this.AuthorityLevel2Table.Add("10", "�A���o�C�g");
            //this.AuthorityLevel2Table.Add("0", "");

            using (AuthorityLevelLcDBAgent authorityLevelDB = new AuthorityLevelLcDBAgent())
            {
                // �������x���P�̐ݒ�
                this.AuthorityLevel1Table.Clear();
                foreach (AuthorityLevelMasterDataSet.AuthorityLevelMasterRow jobTypeRow in authorityLevelDB.JobTypeTbl)
                {
                    this.AuthorityLevel1Table.Add(jobTypeRow.AuthorityLevelCd.ToString(), jobTypeRow.AuthorityLevelNm);
                }
                if (!this.AuthorityLevel1Table.ContainsKey(NULL_JOBTYPE_CODE.ToString()))
                {
                    this.AuthorityLevel1Table.Add(NULL_JOBTYPE_CODE.ToString(), NULL_JOBTYPE_NAME);
                }

                // �������x���Q�̐ݒ�
                this.AuthorityLevel2Table.Clear();
                foreach (AuthorityLevelMasterDataSet.AuthorityLevelMasterRow employmentFormRow in authorityLevelDB.EmploymentFormTbl)
                {
                    this.AuthorityLevel2Table.Add(employmentFormRow.AuthorityLevelCd.ToString(), employmentFormRow.AuthorityLevelNm);
                }
                if (!this.AuthorityLevel2Table.ContainsKey(NULL_EMPLOYMENTFORM_CODE.ToString()))
                {
                    this.AuthorityLevel2Table.Add(NULL_EMPLOYMENTFORM_CODE.ToString(), NULL_EMPLOYMENTFORM_NAME);
                }
            }
            // 2007.09.04 �폜����ђǉ� <<<<<<<<<<

            // ADD 2008/10/10 �s��Ή�[6442] ---------->>>>>
            // �N�����̋敪���X�g
            _yearOnlyList = new List<emDateFormat>();
            _yearOnlyList.AddRange(new emDateFormat[] { emDateFormat.df2Y, emDateFormat.df4Y, emDateFormat.dfG2Y });
            // �N�������̋敪���X�g
            _monthOnlyList = new List<emDateFormat>();
            _monthOnlyList.AddRange(new emDateFormat[] { emDateFormat.df2M, emDateFormat.df2Y2M, emDateFormat.df4Y2M, emDateFormat.dfG2Y2M });
            // ADD 2008/10/10 �s��Ή�[6442] ----------<<<<<
		}
		# endregion

		# region ��Dispose
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

		#region ��Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance141 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance142 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("����K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
			Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
			Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance128 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance140 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance107 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance108 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance109 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance110 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance111 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance112 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance113 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance114 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance115 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance116 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance117 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance118 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
			Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
			Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
			Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFTOK09380UA));
			this.GeneralTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.CustLedgerBootCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.SalSlipInpBootCnt_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
			this.MailAddress2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.MailAddress1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
			this.UOESnmDiv_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.UOESnmDivTitle_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EmployAnalysCode6_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode5_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode4_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode3_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode2_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.EmployAnalysCode1_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
			this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
			this.tNedit_SubSectionCode = new Broadleaf.Library.Windows.Forms.TNedit();
			this.BelongSubSectionGuide_ultraButton = new Infragistics.Win.Misc.UltraButton();
			this.BelongSubSectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.BelongSubSectionTitle_Label = new Infragistics.Win.Misc.UltraLabel();
			this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
			this.tEdit_SectionName = new Broadleaf.Library.Windows.Forms.TEdit();
			this.tEdit_SectionCode = new Broadleaf.Library.Windows.Forms.TEdit();
			this.EmploymentForm_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.EmploymentForm_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
			this.JobType_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
			this.JobType_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.Birthday_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
			this.PortableTelNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.CompanyTelNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
			this.BelongSelectionCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.RetirementDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
			this.RetirementDtTm_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EnterCompanyDtTm_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EnterCompanyDate_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit2();
			this.Sex_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
			this.Kana_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.ShortName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.Name_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.tEdit_EmployeeCode = new Broadleaf.Library.Windows.Forms.TEdit();
			this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Kana_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.ShortName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Birthday_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Sex_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Name_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.EmployeeCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.PortableTelNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.CompanyTelNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.SecurityTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.FeliCaMngDelete_uButton = new Infragistics.Win.Misc.UltraButton();
			this.FeliCaMngGuide_uButton = new Infragistics.Win.Misc.UltraButton();
			this.FeliCaInfo_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.FeliCaInfo_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.UserAdminName_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.UserAdminFlag_uLabel = new Infragistics.Win.Misc.UltraLabel();
			this.LoginPasswordAgain_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.LoginPasswordAgain_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.LoginPassword_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.LoginId_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
			this.LoginPassword_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.LoginId_Title_Label = new Infragistics.Win.Misc.UltraLabel();
			this.DetailsTabPageControl = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
			this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
			this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
			this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
			this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
			this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
			this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
			this.Bind_DataSet = new System.Data.DataSet();
			this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
			this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
			this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
			this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
			this.MainTabControl = new Infragistics.Win.UltraWinTabControl.UltraTabControl();
			this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
			this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
			this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
			this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
			this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
			this.GeneralTabPageControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CustLedgerBootCnt_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SalSlipInpBootCnt_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MailAddress2_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MailAddress1_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.UOESnmDiv_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode6_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode5_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode4_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode3_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode2_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode1_tNedit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BelongSubSectionName_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EmploymentForm_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.JobType_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PortableTelNo_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Sex_tComboEditor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Kana_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ShortName_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Name_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).BeginInit();
			this.SecurityTabPageControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LoginPasswordAgain_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LoginPassword_tEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LoginId_tEdit)).BeginInit();
			this.DetailsTabPageControl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MainTabControl)).BeginInit();
			this.MainTabControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// GeneralTabPageControl
			// 
			this.GeneralTabPageControl.Controls.Add(this.CustLedgerBootCnt_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.SalSlipInpBootCnt_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel12);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel13);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel3);
			this.GeneralTabPageControl.Controls.Add(this.MailAddress2_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.MailAddress1_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel1);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel2);
			this.GeneralTabPageControl.Controls.Add(this.UOESnmDiv_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.UOESnmDivTitle_Label);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode6_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode5_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode4_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode3_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode2_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.EmployAnalysCode1_tNedit);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel9);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel10);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel11);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel8);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel7);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel6);
			this.GeneralTabPageControl.Controls.Add(this.tNedit_SubSectionCode);
			this.GeneralTabPageControl.Controls.Add(this.BelongSubSectionGuide_ultraButton);
			this.GeneralTabPageControl.Controls.Add(this.BelongSubSectionName_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.BelongSubSectionTitle_Label);
			this.GeneralTabPageControl.Controls.Add(this.SectionGuide_Button);
			this.GeneralTabPageControl.Controls.Add(this.tEdit_SectionName);
			this.GeneralTabPageControl.Controls.Add(this.tEdit_SectionCode);
			this.GeneralTabPageControl.Controls.Add(this.EmploymentForm_tComboEditor);
			this.GeneralTabPageControl.Controls.Add(this.EmploymentForm_ultraLabel);
			this.GeneralTabPageControl.Controls.Add(this.JobType_ultraLabel);
			this.GeneralTabPageControl.Controls.Add(this.JobType_tComboEditor);
			this.GeneralTabPageControl.Controls.Add(this.Birthday_tDateEdit);
			this.GeneralTabPageControl.Controls.Add(this.PortableTelNo_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.CompanyTelNo_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel17);
			this.GeneralTabPageControl.Controls.Add(this.ultraLabel15);
			this.GeneralTabPageControl.Controls.Add(this.BelongSelectionCode_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.RetirementDate_tDateEdit);
			this.GeneralTabPageControl.Controls.Add(this.RetirementDtTm_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.EnterCompanyDtTm_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.EnterCompanyDate_tDateEdit);
			this.GeneralTabPageControl.Controls.Add(this.Sex_tComboEditor);
			this.GeneralTabPageControl.Controls.Add(this.Kana_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.ShortName_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.Name_tEdit);
			this.GeneralTabPageControl.Controls.Add(this.tEdit_EmployeeCode);
			this.GeneralTabPageControl.Controls.Add(this.Guid_Label);
			this.GeneralTabPageControl.Controls.Add(this.Kana_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.ShortName_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.Birthday_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.Sex_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.Name_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.EmployeeCode_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.PortableTelNo_Title_Label);
			this.GeneralTabPageControl.Controls.Add(this.CompanyTelNo_Title_Label);
			this.GeneralTabPageControl.Location = new System.Drawing.Point(1, 21);
			this.GeneralTabPageControl.Name = "GeneralTabPageControl";
			this.GeneralTabPageControl.Size = new System.Drawing.Size(778, 553);
			// 
			// CustLedgerBootCnt_tNedit
			// 
			appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CustLedgerBootCnt_tNedit.ActiveAppearance = appearance62;
			appearance63.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance63.ForeColorDisabled = System.Drawing.Color.Black;
			appearance63.TextHAlignAsString = "Right";
			this.CustLedgerBootCnt_tNedit.Appearance = appearance63;
			this.CustLedgerBootCnt_tNedit.AutoSelect = true;
			this.CustLedgerBootCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.CustLedgerBootCnt_tNedit.DataText = "";
			this.CustLedgerBootCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.CustLedgerBootCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.CustLedgerBootCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.CustLedgerBootCnt_tNedit.Location = new System.Drawing.Point(491, 515);
			this.CustLedgerBootCnt_tNedit.MaxLength = 1;
			this.CustLedgerBootCnt_tNedit.Name = "CustLedgerBootCnt_tNedit";
			this.CustLedgerBootCnt_tNedit.NullText = "0";
			this.CustLedgerBootCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.CustLedgerBootCnt_tNedit.Size = new System.Drawing.Size(51, 24);
			this.CustLedgerBootCnt_tNedit.TabIndex = 149;
			// 
			// SalSlipInpBootCnt_tNedit
			// 
			appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.SalSlipInpBootCnt_tNedit.ActiveAppearance = appearance68;
			appearance69.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance69.ForeColorDisabled = System.Drawing.Color.Black;
			appearance69.TextHAlignAsString = "Right";
			this.SalSlipInpBootCnt_tNedit.Appearance = appearance69;
			this.SalSlipInpBootCnt_tNedit.AutoSelect = true;
			this.SalSlipInpBootCnt_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.SalSlipInpBootCnt_tNedit.DataText = "";
			this.SalSlipInpBootCnt_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.SalSlipInpBootCnt_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.SalSlipInpBootCnt_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.SalSlipInpBootCnt_tNedit.Location = new System.Drawing.Point(206, 515);
			this.SalSlipInpBootCnt_tNedit.MaxLength = 1;
			this.SalSlipInpBootCnt_tNedit.Name = "SalSlipInpBootCnt_tNedit";
			this.SalSlipInpBootCnt_tNedit.NullText = "0";
			this.SalSlipInpBootCnt_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.SalSlipInpBootCnt_tNedit.Size = new System.Drawing.Size(51, 24);
			this.SalSlipInpBootCnt_tNedit.TabIndex = 148;
			// 
			// ultraLabel12
			// 
			appearance97.TextVAlignAsString = "Middle";
			this.ultraLabel12.Appearance = appearance97;
			this.ultraLabel12.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel12.Location = new System.Drawing.Point(305, 519);
			this.ultraLabel12.Name = "ultraLabel12";
			this.ultraLabel12.Size = new System.Drawing.Size(180, 17);
			this.ultraLabel12.TabIndex = 151;
			this.ultraLabel12.Text = "���Ӑ�d�q�����N������";
			// 
			// ultraLabel13
			// 
			appearance100.TextVAlignAsString = "Middle";
			this.ultraLabel13.Appearance = appearance100;
			this.ultraLabel13.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel13.Location = new System.Drawing.Point(20, 519);
			this.ultraLabel13.Name = "ultraLabel13";
			this.ultraLabel13.Size = new System.Drawing.Size(180, 17);
			this.ultraLabel13.TabIndex = 150;
			this.ultraLabel13.Text = "����`�[���͋N������";
			// 
			// ultraLabel3
			// 
			this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel3.Location = new System.Drawing.Point(20, 503);
			this.ultraLabel3.Name = "ultraLabel3";
			this.ultraLabel3.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel3.TabIndex = 147;
			// 
			// MailAddress2_tEdit
			// 
			appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.MailAddress2_tEdit.ActiveAppearance = appearance2;
			appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance3.ForeColorDisabled = System.Drawing.Color.Black;
			this.MailAddress2_tEdit.Appearance = appearance3;
			this.MailAddress2_tEdit.AutoSelect = true;
			this.MailAddress2_tEdit.DataText = "";
			this.MailAddress2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.MailAddress2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.MailAddress2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.MailAddress2_tEdit.Location = new System.Drawing.Point(145, 220);
			this.MailAddress2_tEdit.MaxLength = 64;
			this.MailAddress2_tEdit.Name = "MailAddress2_tEdit";
			this.MailAddress2_tEdit.Size = new System.Drawing.Size(252, 24);
			this.MailAddress2_tEdit.TabIndex = 7;
			// 
			// MailAddress1_tEdit
			// 
			appearance85.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.MailAddress1_tEdit.ActiveAppearance = appearance85;
			appearance86.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance86.ForeColorDisabled = System.Drawing.Color.Black;
			this.MailAddress1_tEdit.Appearance = appearance86;
			this.MailAddress1_tEdit.AutoSelect = true;
			this.MailAddress1_tEdit.DataText = "";
			this.MailAddress1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.MailAddress1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 64, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.MailAddress1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.MailAddress1_tEdit.Location = new System.Drawing.Point(145, 190);
			this.MailAddress1_tEdit.MaxLength = 64;
			this.MailAddress1_tEdit.Name = "MailAddress1_tEdit";
			this.MailAddress1_tEdit.Size = new System.Drawing.Size(252, 24);
			this.MailAddress1_tEdit.TabIndex = 6;
			// 
			// ultraLabel1
			// 
			appearance141.TextVAlignAsString = "Middle";
			this.ultraLabel1.Appearance = appearance141;
			this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel1.Location = new System.Drawing.Point(20, 220);
			this.ultraLabel1.Name = "ultraLabel1";
			this.ultraLabel1.Size = new System.Drawing.Size(120, 24);
			this.ultraLabel1.TabIndex = 146;
			this.ultraLabel1.Text = "�@�@�@�@�^�g��";
			// 
			// ultraLabel2
			// 
			appearance142.TextVAlignAsString = "Middle";
			this.ultraLabel2.Appearance = appearance142;
			this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel2.Location = new System.Drawing.Point(20, 190);
			this.ultraLabel2.Name = "ultraLabel2";
			this.ultraLabel2.Size = new System.Drawing.Size(120, 24);
			this.ultraLabel2.TabIndex = 145;
			this.ultraLabel2.Text = "���[���@�^���";
			// 
			// UOESnmDiv_tEdit
			// 
			appearance83.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.UOESnmDiv_tEdit.ActiveAppearance = appearance83;
			appearance84.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance84.ForeColorDisabled = System.Drawing.Color.Black;
			this.UOESnmDiv_tEdit.Appearance = appearance84;
			this.UOESnmDiv_tEdit.AutoSelect = true;
			this.UOESnmDiv_tEdit.DataText = "";
			this.UOESnmDiv_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.UOESnmDiv_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
			this.UOESnmDiv_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.UOESnmDiv_tEdit.Location = new System.Drawing.Point(145, 317);
			this.UOESnmDiv_tEdit.MaxLength = 1;
			this.UOESnmDiv_tEdit.Name = "UOESnmDiv_tEdit";
			this.UOESnmDiv_tEdit.Size = new System.Drawing.Size(20, 24);
			this.UOESnmDiv_tEdit.TabIndex = 12;
			// 
			// UOESnmDivTitle_Label
			// 
			appearance104.TextVAlignAsString = "Middle";
			this.UOESnmDivTitle_Label.Appearance = appearance104;
			this.UOESnmDivTitle_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.UOESnmDivTitle_Label.Location = new System.Drawing.Point(20, 317);
			this.UOESnmDivTitle_Label.Name = "UOESnmDivTitle_Label";
			this.UOESnmDivTitle_Label.Size = new System.Drawing.Size(120, 24);
			this.UOESnmDivTitle_Label.TabIndex = 142;
			this.UOESnmDivTitle_Label.Text = "UOE���̋敪";
			// 
			// EmployAnalysCode6_tNedit
			// 
			appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode6_tNedit.ActiveAppearance = appearance12;
			appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance13.ForeColorDisabled = System.Drawing.Color.Black;
			appearance13.TextHAlignAsString = "Right";
			this.EmployAnalysCode6_tNedit.Appearance = appearance13;
			this.EmployAnalysCode6_tNedit.AutoSelect = true;
			this.EmployAnalysCode6_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode6_tNedit.DataText = "";
			this.EmployAnalysCode6_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode6_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode6_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode6_tNedit.Location = new System.Drawing.Point(491, 470);
			this.EmployAnalysCode6_tNedit.MaxLength = 3;
			this.EmployAnalysCode6_tNedit.Name = "EmployAnalysCode6_tNedit";
			this.EmployAnalysCode6_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode6_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode6_tNedit.TabIndex = 24;
			// 
			// EmployAnalysCode5_tNedit
			// 
			appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode5_tNedit.ActiveAppearance = appearance64;
			appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance65.ForeColorDisabled = System.Drawing.Color.Black;
			appearance65.TextHAlignAsString = "Right";
			this.EmployAnalysCode5_tNedit.Appearance = appearance65;
			this.EmployAnalysCode5_tNedit.AutoSelect = true;
			this.EmployAnalysCode5_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode5_tNedit.DataText = "";
			this.EmployAnalysCode5_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode5_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode5_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode5_tNedit.Location = new System.Drawing.Point(491, 440);
			this.EmployAnalysCode5_tNedit.MaxLength = 3;
			this.EmployAnalysCode5_tNedit.Name = "EmployAnalysCode5_tNedit";
			this.EmployAnalysCode5_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode5_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode5_tNedit.TabIndex = 23;
			// 
			// EmployAnalysCode4_tNedit
			// 
			appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode4_tNedit.ActiveAppearance = appearance66;
			appearance67.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance67.ForeColorDisabled = System.Drawing.Color.Black;
			appearance67.TextHAlignAsString = "Right";
			this.EmployAnalysCode4_tNedit.Appearance = appearance67;
			this.EmployAnalysCode4_tNedit.AutoSelect = true;
			this.EmployAnalysCode4_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode4_tNedit.DataText = "";
			this.EmployAnalysCode4_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode4_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode4_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode4_tNedit.Location = new System.Drawing.Point(491, 410);
			this.EmployAnalysCode4_tNedit.MaxLength = 3;
			this.EmployAnalysCode4_tNedit.Name = "EmployAnalysCode4_tNedit";
			this.EmployAnalysCode4_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode4_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode4_tNedit.TabIndex = 22;
			// 
			// EmployAnalysCode3_tNedit
			// 
			appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode3_tNedit.ActiveAppearance = appearance14;
			appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance15.ForeColorDisabled = System.Drawing.Color.Black;
			appearance15.TextHAlignAsString = "Right";
			this.EmployAnalysCode3_tNedit.Appearance = appearance15;
			this.EmployAnalysCode3_tNedit.AutoSelect = true;
			this.EmployAnalysCode3_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode3_tNedit.DataText = "";
			this.EmployAnalysCode3_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode3_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode3_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode3_tNedit.Location = new System.Drawing.Point(206, 470);
			this.EmployAnalysCode3_tNedit.MaxLength = 3;
			this.EmployAnalysCode3_tNedit.Name = "EmployAnalysCode3_tNedit";
			this.EmployAnalysCode3_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode3_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode3_tNedit.TabIndex = 21;
			// 
			// EmployAnalysCode2_tNedit
			// 
			appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode2_tNedit.ActiveAppearance = appearance70;
			appearance71.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance71.ForeColorDisabled = System.Drawing.Color.Black;
			appearance71.TextHAlignAsString = "Right";
			this.EmployAnalysCode2_tNedit.Appearance = appearance71;
			this.EmployAnalysCode2_tNedit.AutoSelect = true;
			this.EmployAnalysCode2_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode2_tNedit.DataText = "";
			this.EmployAnalysCode2_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode2_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode2_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode2_tNedit.Location = new System.Drawing.Point(206, 440);
			this.EmployAnalysCode2_tNedit.MaxLength = 3;
			this.EmployAnalysCode2_tNedit.Name = "EmployAnalysCode2_tNedit";
			this.EmployAnalysCode2_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode2_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode2_tNedit.TabIndex = 20;
			// 
			// EmployAnalysCode1_tNedit
			// 
			appearance72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmployAnalysCode1_tNedit.ActiveAppearance = appearance72;
			appearance73.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance73.ForeColorDisabled = System.Drawing.Color.Black;
			appearance73.TextHAlignAsString = "Right";
			this.EmployAnalysCode1_tNedit.Appearance = appearance73;
			this.EmployAnalysCode1_tNedit.AutoSelect = true;
			this.EmployAnalysCode1_tNedit.CalcSize = new System.Drawing.Size(172, 200);
			this.EmployAnalysCode1_tNedit.DataText = "";
			this.EmployAnalysCode1_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EmployAnalysCode1_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.EmployAnalysCode1_tNedit.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.EmployAnalysCode1_tNedit.Location = new System.Drawing.Point(206, 410);
			this.EmployAnalysCode1_tNedit.MaxLength = 3;
			this.EmployAnalysCode1_tNedit.Name = "EmployAnalysCode1_tNedit";
			this.EmployAnalysCode1_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.EmployAnalysCode1_tNedit.Size = new System.Drawing.Size(51, 24);
			this.EmployAnalysCode1_tNedit.TabIndex = 19;
			// 
			// ultraLabel9
			// 
			appearance16.TextVAlignAsString = "Middle";
			this.ultraLabel9.Appearance = appearance16;
			this.ultraLabel9.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel9.Location = new System.Drawing.Point(305, 470);
			this.ultraLabel9.Name = "ultraLabel9";
			this.ultraLabel9.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel9.TabIndex = 141;
			this.ultraLabel9.Text = "�]�ƈ����̓R�[�h�U";
			// 
			// ultraLabel10
			// 
			appearance98.TextVAlignAsString = "Middle";
			this.ultraLabel10.Appearance = appearance98;
			this.ultraLabel10.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel10.Location = new System.Drawing.Point(305, 440);
			this.ultraLabel10.Name = "ultraLabel10";
			this.ultraLabel10.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel10.TabIndex = 139;
			this.ultraLabel10.Text = "�]�ƈ����̓R�[�h�T";
			// 
			// ultraLabel11
			// 
			appearance99.TextVAlignAsString = "Middle";
			this.ultraLabel11.Appearance = appearance99;
			this.ultraLabel11.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel11.Location = new System.Drawing.Point(305, 410);
			this.ultraLabel11.Name = "ultraLabel11";
			this.ultraLabel11.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel11.TabIndex = 137;
			this.ultraLabel11.Text = "�]�ƈ����̓R�[�h�S";
			// 
			// ultraLabel8
			// 
			appearance17.TextVAlignAsString = "Middle";
			this.ultraLabel8.Appearance = appearance17;
			this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel8.Location = new System.Drawing.Point(20, 470);
			this.ultraLabel8.Name = "ultraLabel8";
			this.ultraLabel8.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel8.TabIndex = 135;
			this.ultraLabel8.Text = "�]�ƈ����̓R�[�h�R";
			// 
			// ultraLabel7
			// 
			appearance101.TextVAlignAsString = "Middle";
			this.ultraLabel7.Appearance = appearance101;
			this.ultraLabel7.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel7.Location = new System.Drawing.Point(20, 440);
			this.ultraLabel7.Name = "ultraLabel7";
			this.ultraLabel7.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel7.TabIndex = 133;
			this.ultraLabel7.Text = "�]�ƈ����̓R�[�h�Q";
			// 
			// ultraLabel6
			// 
			appearance102.TextVAlignAsString = "Middle";
			this.ultraLabel6.Appearance = appearance102;
			this.ultraLabel6.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel6.Location = new System.Drawing.Point(20, 410);
			this.ultraLabel6.Name = "ultraLabel6";
			this.ultraLabel6.Size = new System.Drawing.Size(145, 17);
			this.ultraLabel6.TabIndex = 131;
			this.ultraLabel6.Text = "�]�ƈ����̓R�[�h�P";
			// 
			// tNedit_SubSectionCode
			// 
			appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tNedit_SubSectionCode.ActiveAppearance = appearance76;
			appearance77.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance77.ForeColorDisabled = System.Drawing.Color.Black;
			appearance77.TextHAlignAsString = "Right";
			this.tNedit_SubSectionCode.Appearance = appearance77;
			this.tNedit_SubSectionCode.AutoSelect = true;
			this.tNedit_SubSectionCode.CalcSize = new System.Drawing.Size(172, 200);
			this.tNedit_SubSectionCode.DataText = "";
			this.tNedit_SubSectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tNedit_SubSectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
			this.tNedit_SubSectionCode.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.tNedit_SubSectionCode.Location = new System.Drawing.Point(145, 287);
			this.tNedit_SubSectionCode.MaxLength = 2;
			this.tNedit_SubSectionCode.Name = "tNedit_SubSectionCode";
			this.tNedit_SubSectionCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
			this.tNedit_SubSectionCode.Size = new System.Drawing.Size(35, 24);
			this.tNedit_SubSectionCode.TabIndex = 10;
			// 
			// BelongSubSectionGuide_ultraButton
			// 
			this.BelongSubSectionGuide_ultraButton.BackColorInternal = System.Drawing.Color.Transparent;
			this.BelongSubSectionGuide_ultraButton.Location = new System.Drawing.Point(528, 287);
			this.BelongSubSectionGuide_ultraButton.Margin = new System.Windows.Forms.Padding(4);
			this.BelongSubSectionGuide_ultraButton.Name = "BelongSubSectionGuide_ultraButton";
			this.BelongSubSectionGuide_ultraButton.Size = new System.Drawing.Size(24, 24);
			this.BelongSubSectionGuide_ultraButton.TabIndex = 11;
			ultraToolTipInfo1.ToolTipText = "����K�C�h";
			this.ultraToolTipManager1.SetUltraToolTip(this.BelongSubSectionGuide_ultraButton, ultraToolTipInfo1);
			this.BelongSubSectionGuide_ultraButton.Click += new System.EventHandler(this.BelongSubSectionGuide_ultraButton_Click);
			// 
			// BelongSubSectionName_tEdit
			// 
			this.BelongSubSectionName_tEdit.ActiveAppearance = appearance58;
			appearance59.ForeColorDisabled = System.Drawing.Color.Black;
			this.BelongSubSectionName_tEdit.Appearance = appearance59;
			this.BelongSubSectionName_tEdit.AutoSelect = true;
			this.BelongSubSectionName_tEdit.DataText = "";
			this.BelongSubSectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.BelongSubSectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
			this.BelongSubSectionName_tEdit.Location = new System.Drawing.Point(185, 287);
			this.BelongSubSectionName_tEdit.MaxLength = 20;
			this.BelongSubSectionName_tEdit.Name = "BelongSubSectionName_tEdit";
			this.BelongSubSectionName_tEdit.ReadOnly = true;
			this.BelongSubSectionName_tEdit.Size = new System.Drawing.Size(337, 24);
			this.BelongSubSectionName_tEdit.TabIndex = 129;
			// 
			// BelongSubSectionTitle_Label
			// 
			appearance1.TextVAlignAsString = "Middle";
			this.BelongSubSectionTitle_Label.Appearance = appearance1;
			this.BelongSubSectionTitle_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.BelongSubSectionTitle_Label.Location = new System.Drawing.Point(20, 287);
			this.BelongSubSectionTitle_Label.Name = "BelongSubSectionTitle_Label";
			this.BelongSubSectionTitle_Label.Size = new System.Drawing.Size(120, 24);
			this.BelongSubSectionTitle_Label.TabIndex = 127;
			this.BelongSubSectionTitle_Label.Text = "��������";
			// 
			// SectionGuide_Button
			// 
			this.SectionGuide_Button.BackColorInternal = System.Drawing.Color.Transparent;
			this.SectionGuide_Button.Location = new System.Drawing.Point(370, 256);
			this.SectionGuide_Button.Margin = new System.Windows.Forms.Padding(4);
			this.SectionGuide_Button.Name = "SectionGuide_Button";
			this.SectionGuide_Button.Size = new System.Drawing.Size(24, 24);
			this.SectionGuide_Button.TabIndex = 9;
			ultraToolTipInfo2.ToolTipText = "���_�K�C�h";
			this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo2);
			this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
			// 
			// tEdit_SectionName
			// 
			this.tEdit_SectionName.ActiveAppearance = appearance18;
			appearance21.ForeColorDisabled = System.Drawing.Color.Black;
			this.tEdit_SectionName.Appearance = appearance21;
			this.tEdit_SectionName.AutoSelect = true;
			this.tEdit_SectionName.DataText = "";
			this.tEdit_SectionName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tEdit_SectionName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
			this.tEdit_SectionName.Location = new System.Drawing.Point(185, 256);
			this.tEdit_SectionName.MaxLength = 10;
			this.tEdit_SectionName.Name = "tEdit_SectionName";
			this.tEdit_SectionName.ReadOnly = true;
			this.tEdit_SectionName.Size = new System.Drawing.Size(179, 24);
			this.tEdit_SectionName.TabIndex = 126;
			// 
			// tEdit_SectionCode
			// 
			appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tEdit_SectionCode.ActiveAppearance = appearance22;
			this.tEdit_SectionCode.AllowDrop = true;
			appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance23.ForeColorDisabled = System.Drawing.Color.Black;
			this.tEdit_SectionCode.Appearance = appearance23;
			this.tEdit_SectionCode.AutoSelect = true;
			this.tEdit_SectionCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.tEdit_SectionCode.DataText = "";
			this.tEdit_SectionCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tEdit_SectionCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, false, true));
			this.tEdit_SectionCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tEdit_SectionCode.Location = new System.Drawing.Point(145, 256);
			this.tEdit_SectionCode.MaxLength = 9;
			this.tEdit_SectionCode.Name = "tEdit_SectionCode";
			this.tEdit_SectionCode.Size = new System.Drawing.Size(35, 24);
			this.tEdit_SectionCode.TabIndex = 8;
			// 
			// EmploymentForm_tComboEditor
			// 
			appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmploymentForm_tComboEditor.ActiveAppearance = appearance24;
			appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance28.ForeColorDisabled = System.Drawing.Color.Black;
			this.EmploymentForm_tComboEditor.Appearance = appearance28;
			this.EmploymentForm_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.EmploymentForm_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.EmploymentForm_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
			appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.EmploymentForm_tComboEditor.ItemAppearance = appearance29;
			this.EmploymentForm_tComboEditor.Location = new System.Drawing.Point(536, 361);
			this.EmploymentForm_tComboEditor.Name = "EmploymentForm_tComboEditor";
			this.EmploymentForm_tComboEditor.Size = new System.Drawing.Size(202, 24);
			this.EmploymentForm_tComboEditor.TabIndex = 18;
			// 
			// EmploymentForm_ultraLabel
			// 
			appearance30.TextVAlignAsString = "Middle";
			this.EmploymentForm_ultraLabel.Appearance = appearance30;
			this.EmploymentForm_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
			this.EmploymentForm_ultraLabel.Location = new System.Drawing.Point(410, 361);
			this.EmploymentForm_ultraLabel.Name = "EmploymentForm_ultraLabel";
			this.EmploymentForm_ultraLabel.Size = new System.Drawing.Size(120, 24);
			this.EmploymentForm_ultraLabel.TabIndex = 124;
			this.EmploymentForm_ultraLabel.Text = "���[���i�����j";
			// 
			// JobType_ultraLabel
			// 
			appearance31.TextVAlignAsString = "Middle";
			this.JobType_ultraLabel.Appearance = appearance31;
			this.JobType_ultraLabel.BackColorInternal = System.Drawing.Color.Transparent;
			this.JobType_ultraLabel.Location = new System.Drawing.Point(20, 361);
			this.JobType_ultraLabel.Name = "JobType_ultraLabel";
			this.JobType_ultraLabel.Size = new System.Drawing.Size(120, 24);
			this.JobType_ultraLabel.TabIndex = 123;
			this.JobType_ultraLabel.Text = "���[���i�Ɩ��j";
			// 
			// JobType_tComboEditor
			// 
			appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.JobType_tComboEditor.ActiveAppearance = appearance44;
			appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance45.ForeColorDisabled = System.Drawing.Color.Black;
			this.JobType_tComboEditor.Appearance = appearance45;
			this.JobType_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.JobType_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.JobType_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
			appearance79.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.JobType_tComboEditor.ItemAppearance = appearance79;
			this.JobType_tComboEditor.Location = new System.Drawing.Point(145, 361);
			this.JobType_tComboEditor.Name = "JobType_tComboEditor";
			this.JobType_tComboEditor.Size = new System.Drawing.Size(202, 24);
			this.JobType_tComboEditor.TabIndex = 17;
			// 
			// Birthday_tDateEdit
			// 
			appearance80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance80.TextHAlignAsString = "Right";
			appearance80.TextVAlignAsString = "Middle";
			this.Birthday_tDateEdit.ActiveEditAppearance = appearance80;
			this.Birthday_tDateEdit.BackColor = System.Drawing.Color.Transparent;
			this.Birthday_tDateEdit.CalendarDisp = true;
			this.Birthday_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
			appearance81.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance81.ForeColorDisabled = System.Drawing.Color.Black;
			appearance81.TextHAlignAsString = "Right";
			appearance81.TextVAlignAsString = "Middle";
			this.Birthday_tDateEdit.EditAppearance = appearance81;
			this.Birthday_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.Birthday_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			appearance82.ForeColorDisabled = System.Drawing.Color.Black;
			appearance82.TextHAlignAsString = "Left";
			appearance82.TextVAlignAsString = "Middle";
			this.Birthday_tDateEdit.LabelAppearance = appearance82;
			this.Birthday_tDateEdit.Location = new System.Drawing.Point(536, 160);
			this.Birthday_tDateEdit.Name = "Birthday_tDateEdit";
			this.Birthday_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.Birthday_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
			this.Birthday_tDateEdit.Size = new System.Drawing.Size(202, 24);
			this.Birthday_tDateEdit.TabIndex = 14;
			this.Birthday_tDateEdit.TabStop = true;
			// 
			// PortableTelNo_tEdit
			// 
			appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.PortableTelNo_tEdit.ActiveAppearance = appearance4;
			appearance5.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance5.ForeColorDisabled = System.Drawing.Color.Black;
			this.PortableTelNo_tEdit.Appearance = appearance5;
			this.PortableTelNo_tEdit.AutoSelect = true;
			this.PortableTelNo_tEdit.DataText = "";
			this.PortableTelNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.PortableTelNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
			this.PortableTelNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.PortableTelNo_tEdit.Location = new System.Drawing.Point(145, 160);
			this.PortableTelNo_tEdit.MaxLength = 16;
			this.PortableTelNo_tEdit.Name = "PortableTelNo_tEdit";
			this.PortableTelNo_tEdit.Size = new System.Drawing.Size(136, 24);
			this.PortableTelNo_tEdit.TabIndex = 5;
			// 
			// CompanyTelNo_tEdit
			// 
			appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.CompanyTelNo_tEdit.ActiveAppearance = appearance6;
			appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance7.ForeColorDisabled = System.Drawing.Color.Black;
			this.CompanyTelNo_tEdit.Appearance = appearance7;
			this.CompanyTelNo_tEdit.AutoSelect = true;
			this.CompanyTelNo_tEdit.DataText = "";
			this.CompanyTelNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.CompanyTelNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
			this.CompanyTelNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.CompanyTelNo_tEdit.Location = new System.Drawing.Point(145, 130);
			this.CompanyTelNo_tEdit.MaxLength = 16;
			this.CompanyTelNo_tEdit.Name = "CompanyTelNo_tEdit";
			this.CompanyTelNo_tEdit.Size = new System.Drawing.Size(136, 24);
			this.CompanyTelNo_tEdit.TabIndex = 4;
			// 
			// ultraLabel17
			// 
			this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel17.Location = new System.Drawing.Point(20, 396);
			this.ultraLabel17.Name = "ultraLabel17";
			this.ultraLabel17.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel17.TabIndex = 121;
			// 
			// ultraLabel15
			// 
			this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel15.Location = new System.Drawing.Point(20, 349);
			this.ultraLabel15.Name = "ultraLabel15";
			this.ultraLabel15.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel15.TabIndex = 119;
			// 
			// BelongSelectionCode_Title_Label
			// 
			appearance87.TextVAlignAsString = "Middle";
			this.BelongSelectionCode_Title_Label.Appearance = appearance87;
			this.BelongSelectionCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.BelongSelectionCode_Title_Label.Location = new System.Drawing.Point(20, 256);
			this.BelongSelectionCode_Title_Label.Name = "BelongSelectionCode_Title_Label";
			this.BelongSelectionCode_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.BelongSelectionCode_Title_Label.TabIndex = 116;
			this.BelongSelectionCode_Title_Label.Text = "�������_";
			// 
			// RetirementDate_tDateEdit
			// 
			appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance88.TextHAlignAsString = "Right";
			appearance88.TextVAlignAsString = "Middle";
			this.RetirementDate_tDateEdit.ActiveEditAppearance = appearance88;
			this.RetirementDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
			this.RetirementDate_tDateEdit.CalendarDisp = true;
			this.RetirementDate_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
			appearance89.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance89.ForeColorDisabled = System.Drawing.Color.Black;
			appearance89.TextHAlignAsString = "Right";
			appearance89.TextVAlignAsString = "Middle";
			this.RetirementDate_tDateEdit.EditAppearance = appearance89;
			this.RetirementDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.RetirementDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.RetirementDate_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance90.ForeColorDisabled = System.Drawing.Color.Black;
			appearance90.TextHAlignAsString = "Left";
			appearance90.TextVAlignAsString = "Middle";
			this.RetirementDate_tDateEdit.LabelAppearance = appearance90;
			this.RetirementDate_tDateEdit.Location = new System.Drawing.Point(536, 220);
			this.RetirementDate_tDateEdit.Name = "RetirementDate_tDateEdit";
			this.RetirementDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.RetirementDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
			this.RetirementDate_tDateEdit.Size = new System.Drawing.Size(202, 24);
			this.RetirementDate_tDateEdit.TabIndex = 16;
			this.RetirementDate_tDateEdit.TabStop = true;
			// 
			// RetirementDtTm_Title_Label
			// 
			this.RetirementDtTm_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.RetirementDtTm_Title_Label.Location = new System.Drawing.Point(411, 220);
			this.RetirementDtTm_Title_Label.Name = "RetirementDtTm_Title_Label";
			this.RetirementDtTm_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.RetirementDtTm_Title_Label.TabIndex = 86;
			this.RetirementDtTm_Title_Label.Text = "�ސE��";
			// 
			// EnterCompanyDtTm_Title_Label
			// 
			appearance91.TextVAlignAsString = "Middle";
			this.EnterCompanyDtTm_Title_Label.Appearance = appearance91;
			this.EnterCompanyDtTm_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.EnterCompanyDtTm_Title_Label.Location = new System.Drawing.Point(411, 190);
			this.EnterCompanyDtTm_Title_Label.Name = "EnterCompanyDtTm_Title_Label";
			this.EnterCompanyDtTm_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.EnterCompanyDtTm_Title_Label.TabIndex = 85;
			this.EnterCompanyDtTm_Title_Label.Text = "���Г�";
			// 
			// EnterCompanyDate_tDateEdit
			// 
			appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			appearance92.TextHAlignAsString = "Right";
			appearance92.TextVAlignAsString = "Middle";
			this.EnterCompanyDate_tDateEdit.ActiveEditAppearance = appearance92;
			this.EnterCompanyDate_tDateEdit.BackColor = System.Drawing.Color.Transparent;
			this.EnterCompanyDate_tDateEdit.CalendarDisp = true;
			this.EnterCompanyDate_tDateEdit.DateFormat = Broadleaf.Library.Windows.Forms.emDateFormat.dfG2Y2M2D;
			appearance93.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance93.ForeColorDisabled = System.Drawing.Color.Black;
			appearance93.TextHAlignAsString = "Right";
			appearance93.TextVAlignAsString = "Middle";
			this.EnterCompanyDate_tDateEdit.EditAppearance = appearance93;
			this.EnterCompanyDate_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
			this.EnterCompanyDate_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.EnterCompanyDate_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			appearance94.ForeColorDisabled = System.Drawing.Color.Black;
			appearance94.TextHAlignAsString = "Left";
			appearance94.TextVAlignAsString = "Middle";
			this.EnterCompanyDate_tDateEdit.LabelAppearance = appearance94;
			this.EnterCompanyDate_tDateEdit.Location = new System.Drawing.Point(536, 190);
			this.EnterCompanyDate_tDateEdit.Name = "EnterCompanyDate_tDateEdit";
			this.EnterCompanyDate_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
			this.EnterCompanyDate_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, true, true);
			this.EnterCompanyDate_tDateEdit.Size = new System.Drawing.Size(202, 24);
			this.EnterCompanyDate_tDateEdit.TabIndex = 15;
			this.EnterCompanyDate_tDateEdit.TabStop = true;
			// 
			// Sex_tComboEditor
			// 
			appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Sex_tComboEditor.ActiveAppearance = appearance103;
			appearance125.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance125.ForeColorDisabled = System.Drawing.Color.Black;
			this.Sex_tComboEditor.Appearance = appearance125;
			this.Sex_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
			this.Sex_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
			appearance126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Sex_tComboEditor.ItemAppearance = appearance126;
			this.Sex_tComboEditor.Location = new System.Drawing.Point(536, 130);
			this.Sex_tComboEditor.Name = "Sex_tComboEditor";
			this.Sex_tComboEditor.Size = new System.Drawing.Size(100, 24);
			this.Sex_tComboEditor.TabIndex = 13;
			// 
			// Kana_tEdit
			// 
			appearance127.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Kana_tEdit.ActiveAppearance = appearance127;
			appearance128.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance128.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance128.ForeColorDisabled = System.Drawing.Color.Black;
			this.Kana_tEdit.Appearance = appearance128;
			this.Kana_tEdit.AutoSelect = true;
			this.Kana_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.Kana_tEdit.DataText = "";
			this.Kana_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.Kana_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
			this.Kana_tEdit.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
			this.Kana_tEdit.Location = new System.Drawing.Point(145, 70);
			this.Kana_tEdit.MaxLength = 30;
			this.Kana_tEdit.Name = "Kana_tEdit";
			this.Kana_tEdit.Size = new System.Drawing.Size(252, 24);
			this.Kana_tEdit.TabIndex = 2;
			this.Kana_tEdit.ValueChanged += new System.EventHandler(this.Kana_tEdit_ValueChanged);
			// 
			// ShortName_tEdit
			// 
			appearance129.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.ShortName_tEdit.ActiveAppearance = appearance129;
			appearance130.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance130.ForeColorDisabled = System.Drawing.Color.Black;
			this.ShortName_tEdit.Appearance = appearance130;
			this.ShortName_tEdit.AutoSelect = true;
			this.ShortName_tEdit.DataText = "";
			this.ShortName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.ShortName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.ShortName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.ShortName_tEdit.Location = new System.Drawing.Point(145, 100);
			this.ShortName_tEdit.MaxLength = 5;
			this.ShortName_tEdit.Name = "ShortName_tEdit";
			this.ShortName_tEdit.Size = new System.Drawing.Size(97, 24);
			this.ShortName_tEdit.TabIndex = 3;
			// 
			// Name_tEdit
			// 
			appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.Name_tEdit.ActiveAppearance = appearance131;
			appearance132.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance132.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance132.ForeColorDisabled = System.Drawing.Color.Black;
			this.Name_tEdit.Appearance = appearance132;
			this.Name_tEdit.AutoSelect = true;
			this.Name_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.Name_tEdit.DataText = "";
			this.Name_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.Name_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
			this.Name_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			this.Name_tEdit.Location = new System.Drawing.Point(145, 40);
			this.Name_tEdit.MaxLength = 30;
			this.Name_tEdit.Name = "Name_tEdit";
			this.Name_tEdit.Size = new System.Drawing.Size(484, 24);
			this.Name_tEdit.TabIndex = 1;
			this.Name_tEdit.ValueChanged += new System.EventHandler(this.Name_tEdit_ValueChanged);
			// 
			// tEdit_EmployeeCode
			// 
			appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.tEdit_EmployeeCode.ActiveAppearance = appearance133;
			appearance134.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance134.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance134.ForeColorDisabled = System.Drawing.Color.Black;
			this.tEdit_EmployeeCode.Appearance = appearance134;
			this.tEdit_EmployeeCode.AutoSelect = true;
			this.tEdit_EmployeeCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.tEdit_EmployeeCode.DataText = "1234";
			this.tEdit_EmployeeCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.tEdit_EmployeeCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, false, true));
			this.tEdit_EmployeeCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.tEdit_EmployeeCode.Location = new System.Drawing.Point(145, 10);
			this.tEdit_EmployeeCode.MaxLength = 9;
			this.tEdit_EmployeeCode.Name = "tEdit_EmployeeCode";
			this.tEdit_EmployeeCode.Size = new System.Drawing.Size(43, 24);
			this.tEdit_EmployeeCode.TabIndex = 0;
			this.tEdit_EmployeeCode.Text = "1234";
			// 
			// Guid_Label
			// 
			this.Guid_Label.Location = new System.Drawing.Point(280, 10);
			this.Guid_Label.Name = "Guid_Label";
			this.Guid_Label.Size = new System.Drawing.Size(240, 25);
			this.Guid_Label.TabIndex = 45;
			this.Guid_Label.Visible = false;
			// 
			// Kana_Title_Label
			// 
			appearance135.TextVAlignAsString = "Middle";
			this.Kana_Title_Label.Appearance = appearance135;
			this.Kana_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.Kana_Title_Label.Location = new System.Drawing.Point(20, 70);
			this.Kana_Title_Label.Name = "Kana_Title_Label";
			this.Kana_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.Kana_Title_Label.TabIndex = 31;
			this.Kana_Title_Label.Text = "�S���Җ�(��)";
			// 
			// ShortName_Title_Label
			// 
			appearance136.TextVAlignAsString = "Middle";
			this.ShortName_Title_Label.Appearance = appearance136;
			this.ShortName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.ShortName_Title_Label.Location = new System.Drawing.Point(20, 100);
			this.ShortName_Title_Label.Name = "ShortName_Title_Label";
			this.ShortName_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.ShortName_Title_Label.TabIndex = 60;
			this.ShortName_Title_Label.Text = "�S���җ���";
			// 
			// Birthday_Title_Label
			// 
			appearance137.TextVAlignAsString = "Middle";
			this.Birthday_Title_Label.Appearance = appearance137;
			this.Birthday_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.Birthday_Title_Label.Location = new System.Drawing.Point(411, 160);
			this.Birthday_Title_Label.Name = "Birthday_Title_Label";
			this.Birthday_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.Birthday_Title_Label.TabIndex = 14;
			this.Birthday_Title_Label.Text = "���N����";
			// 
			// Sex_Title_Label
			// 
			appearance138.TextVAlignAsString = "Middle";
			this.Sex_Title_Label.Appearance = appearance138;
			this.Sex_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.Sex_Title_Label.Location = new System.Drawing.Point(411, 130);
			this.Sex_Title_Label.Name = "Sex_Title_Label";
			this.Sex_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.Sex_Title_Label.TabIndex = 12;
			this.Sex_Title_Label.Text = "����";
			// 
			// Name_Title_Label
			// 
			appearance139.TextVAlignAsString = "Middle";
			this.Name_Title_Label.Appearance = appearance139;
			this.Name_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.Name_Title_Label.Location = new System.Drawing.Point(20, 40);
			this.Name_Title_Label.Name = "Name_Title_Label";
			this.Name_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.Name_Title_Label.TabIndex = 5;
			this.Name_Title_Label.Text = "�S���Җ�";
			// 
			// EmployeeCode_Title_Label
			// 
			appearance140.TextVAlignAsString = "Middle";
			this.EmployeeCode_Title_Label.Appearance = appearance140;
			this.EmployeeCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.EmployeeCode_Title_Label.Location = new System.Drawing.Point(20, 10);
			this.EmployeeCode_Title_Label.Name = "EmployeeCode_Title_Label";
			this.EmployeeCode_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.EmployeeCode_Title_Label.TabIndex = 3;
			this.EmployeeCode_Title_Label.Text = "�S���҃R�[�h";
			// 
			// PortableTelNo_Title_Label
			// 
			appearance8.TextVAlignAsString = "Middle";
			this.PortableTelNo_Title_Label.Appearance = appearance8;
			this.PortableTelNo_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.PortableTelNo_Title_Label.Location = new System.Drawing.Point(20, 160);
			this.PortableTelNo_Title_Label.Name = "PortableTelNo_Title_Label";
			this.PortableTelNo_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.PortableTelNo_Title_Label.TabIndex = 67;
			this.PortableTelNo_Title_Label.Text = "�@�@�@�@�^�g��";
			// 
			// CompanyTelNo_Title_Label
			// 
			appearance9.TextVAlignAsString = "Middle";
			this.CompanyTelNo_Title_Label.Appearance = appearance9;
			this.CompanyTelNo_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.CompanyTelNo_Title_Label.Location = new System.Drawing.Point(20, 130);
			this.CompanyTelNo_Title_Label.Name = "CompanyTelNo_Title_Label";
			this.CompanyTelNo_Title_Label.Size = new System.Drawing.Size(120, 24);
			this.CompanyTelNo_Title_Label.TabIndex = 61;
			this.CompanyTelNo_Title_Label.Text = "�d�b�ԍ��^���";
			// 
			// SecurityTabPageControl
			// 
			this.SecurityTabPageControl.Controls.Add(this.FeliCaMngDelete_uButton);
			this.SecurityTabPageControl.Controls.Add(this.FeliCaMngGuide_uButton);
			this.SecurityTabPageControl.Controls.Add(this.FeliCaInfo_uLabel);
			this.SecurityTabPageControl.Controls.Add(this.FeliCaInfo_Title_uLabel);
			this.SecurityTabPageControl.Controls.Add(this.UserAdminName_uLabel);
			this.SecurityTabPageControl.Controls.Add(this.UserAdminFlag_uLabel);
			this.SecurityTabPageControl.Controls.Add(this.LoginPasswordAgain_tEdit);
			this.SecurityTabPageControl.Controls.Add(this.LoginPasswordAgain_Title_Label);
			this.SecurityTabPageControl.Controls.Add(this.LoginPassword_tEdit);
			this.SecurityTabPageControl.Controls.Add(this.LoginId_tEdit);
			this.SecurityTabPageControl.Controls.Add(this.LoginPassword_Title_Label);
			this.SecurityTabPageControl.Controls.Add(this.LoginId_Title_Label);
			this.SecurityTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
			this.SecurityTabPageControl.Name = "SecurityTabPageControl";
			this.SecurityTabPageControl.Size = new System.Drawing.Size(778, 553);
			// 
			// FeliCaMngDelete_uButton
			// 
			this.FeliCaMngDelete_uButton.Location = new System.Drawing.Point(433, 95);
			this.FeliCaMngDelete_uButton.Name = "FeliCaMngDelete_uButton";
			this.FeliCaMngDelete_uButton.Size = new System.Drawing.Size(83, 25);
			this.FeliCaMngDelete_uButton.TabIndex = 97;
			this.FeliCaMngDelete_uButton.Text = "�N���A";
			this.FeliCaMngDelete_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.FeliCaMngDelete_uButton.Click += new System.EventHandler(this.FeliCaMngDelete_uButton_Click);
			// 
			// FeliCaMngGuide_uButton
			// 
			this.FeliCaMngGuide_uButton.Location = new System.Drawing.Point(402, 95);
			this.FeliCaMngGuide_uButton.Name = "FeliCaMngGuide_uButton";
			this.FeliCaMngGuide_uButton.Size = new System.Drawing.Size(25, 25);
			this.FeliCaMngGuide_uButton.TabIndex = 96;
			this.FeliCaMngGuide_uButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.FeliCaMngGuide_uButton.Click += new System.EventHandler(this.FeliCaMngGuide_uButton_Click);
			// 
			// FeliCaInfo_uLabel
			// 
			appearance105.BackColor = System.Drawing.SystemColors.Control;
			appearance105.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			appearance105.TextVAlignAsString = "Middle";
			this.FeliCaInfo_uLabel.Appearance = appearance105;
			this.FeliCaInfo_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
			this.FeliCaInfo_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
			this.FeliCaInfo_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FeliCaInfo_uLabel.Location = new System.Drawing.Point(188, 96);
			this.FeliCaInfo_uLabel.Name = "FeliCaInfo_uLabel";
			this.FeliCaInfo_uLabel.Size = new System.Drawing.Size(208, 23);
			this.FeliCaInfo_uLabel.TabIndex = 95;
			// 
			// FeliCaInfo_Title_uLabel
			// 
			appearance106.TextVAlignAsString = "Middle";
			this.FeliCaInfo_Title_uLabel.Appearance = appearance106;
			this.FeliCaInfo_Title_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
			this.FeliCaInfo_Title_uLabel.Location = new System.Drawing.Point(15, 96);
			this.FeliCaInfo_Title_uLabel.Name = "FeliCaInfo_Title_uLabel";
			this.FeliCaInfo_Title_uLabel.Size = new System.Drawing.Size(169, 24);
			this.FeliCaInfo_Title_uLabel.TabIndex = 94;
			this.FeliCaInfo_Title_uLabel.Text = "�t�F���J�J�[�hID";
			// 
			// UserAdminName_uLabel
			// 
			appearance11.BackColor = System.Drawing.SystemColors.Control;
			appearance11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
			appearance11.TextVAlignAsString = "Middle";
			this.UserAdminName_uLabel.Appearance = appearance11;
			this.UserAdminName_uLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
			this.UserAdminName_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Solid;
			this.UserAdminName_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.UserAdminName_uLabel.Location = new System.Drawing.Point(188, 127);
			this.UserAdminName_uLabel.Name = "UserAdminName_uLabel";
			this.UserAdminName_uLabel.Size = new System.Drawing.Size(208, 23);
			this.UserAdminName_uLabel.TabIndex = 93;
			// 
			// UserAdminFlag_uLabel
			// 
			appearance10.TextVAlignAsString = "Middle";
			this.UserAdminFlag_uLabel.Appearance = appearance10;
			this.UserAdminFlag_uLabel.BackColorInternal = System.Drawing.Color.Transparent;
			this.UserAdminFlag_uLabel.Location = new System.Drawing.Point(15, 127);
			this.UserAdminFlag_uLabel.Name = "UserAdminFlag_uLabel";
			this.UserAdminFlag_uLabel.Size = new System.Drawing.Size(169, 24);
			this.UserAdminFlag_uLabel.TabIndex = 92;
			this.UserAdminFlag_uLabel.Text = "���[�U�[�Ǘ��҃t���O";
			// 
			// LoginPasswordAgain_tEdit
			// 
			appearance107.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.LoginPasswordAgain_tEdit.ActiveAppearance = appearance107;
			appearance108.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance108.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance108.ForeColorDisabled = System.Drawing.Color.Black;
			this.LoginPasswordAgain_tEdit.Appearance = appearance108;
			this.LoginPasswordAgain_tEdit.AutoSelect = true;
			this.LoginPasswordAgain_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.LoginPasswordAgain_tEdit.DataText = "";
			this.LoginPasswordAgain_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.LoginPasswordAgain_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.LoginPasswordAgain_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.LoginPasswordAgain_tEdit.Location = new System.Drawing.Point(188, 65);
			this.LoginPasswordAgain_tEdit.MaxLength = 24;
			this.LoginPasswordAgain_tEdit.Name = "LoginPasswordAgain_tEdit";
			this.LoginPasswordAgain_tEdit.PasswordChar = '*';
			this.LoginPasswordAgain_tEdit.Size = new System.Drawing.Size(206, 24);
			this.LoginPasswordAgain_tEdit.TabIndex = 2;
			// 
			// LoginPasswordAgain_Title_Label
			// 
			appearance109.TextVAlignAsString = "Middle";
			this.LoginPasswordAgain_Title_Label.Appearance = appearance109;
			this.LoginPasswordAgain_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.LoginPasswordAgain_Title_Label.Location = new System.Drawing.Point(15, 65);
			this.LoginPasswordAgain_Title_Label.Name = "LoginPasswordAgain_Title_Label";
			this.LoginPasswordAgain_Title_Label.Size = new System.Drawing.Size(145, 24);
			this.LoginPasswordAgain_Title_Label.TabIndex = 91;
			this.LoginPasswordAgain_Title_Label.Text = "�p�X���[�h�m�F";
			// 
			// LoginPassword_tEdit
			// 
			appearance110.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.LoginPassword_tEdit.ActiveAppearance = appearance110;
			appearance111.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance111.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance111.ForeColorDisabled = System.Drawing.Color.Black;
			this.LoginPassword_tEdit.Appearance = appearance111;
			this.LoginPassword_tEdit.AutoSelect = true;
			this.LoginPassword_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.LoginPassword_tEdit.DataText = "";
			this.LoginPassword_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.LoginPassword_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.LoginPassword_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.LoginPassword_tEdit.Location = new System.Drawing.Point(188, 40);
			this.LoginPassword_tEdit.MaxLength = 24;
			this.LoginPassword_tEdit.Name = "LoginPassword_tEdit";
			this.LoginPassword_tEdit.PasswordChar = '*';
			this.LoginPassword_tEdit.Size = new System.Drawing.Size(206, 24);
			this.LoginPassword_tEdit.TabIndex = 1;
			this.LoginPassword_tEdit.Leave += new System.EventHandler(this.LoginPassword_tEdit_Leave);
			// 
			// LoginId_tEdit
			// 
			appearance112.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
			this.LoginId_tEdit.ActiveAppearance = appearance112;
			appearance113.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			appearance113.BackColorDisabled = System.Drawing.SystemColors.Control;
			appearance113.ForeColorDisabled = System.Drawing.Color.Black;
			this.LoginId_tEdit.Appearance = appearance113;
			this.LoginId_tEdit.AutoSelect = true;
			this.LoginId_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
			this.LoginId_tEdit.DataText = "";
			this.LoginId_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
			this.LoginId_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
			this.LoginId_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.LoginId_tEdit.Location = new System.Drawing.Point(188, 10);
			this.LoginId_tEdit.MaxLength = 24;
			this.LoginId_tEdit.Name = "LoginId_tEdit";
			this.LoginId_tEdit.Size = new System.Drawing.Size(206, 24);
			this.LoginId_tEdit.TabIndex = 0;
			// 
			// LoginPassword_Title_Label
			// 
			appearance114.TextVAlignAsString = "Middle";
			this.LoginPassword_Title_Label.Appearance = appearance114;
			this.LoginPassword_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.LoginPassword_Title_Label.Location = new System.Drawing.Point(15, 40);
			this.LoginPassword_Title_Label.Name = "LoginPassword_Title_Label";
			this.LoginPassword_Title_Label.Size = new System.Drawing.Size(150, 24);
			this.LoginPassword_Title_Label.TabIndex = 87;
			this.LoginPassword_Title_Label.Text = "���O�C���p�X���[�h";
			// 
			// LoginId_Title_Label
			// 
			appearance115.TextVAlignAsString = "Middle";
			this.LoginId_Title_Label.Appearance = appearance115;
			this.LoginId_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
			this.LoginId_Title_Label.Location = new System.Drawing.Point(15, 10);
			this.LoginId_Title_Label.Name = "LoginId_Title_Label";
			this.LoginId_Title_Label.Size = new System.Drawing.Size(160, 24);
			this.LoginId_Title_Label.TabIndex = 85;
			this.LoginId_Title_Label.Text = "���O�C��ID";
			// 
			// DetailsTabPageControl
			// 
			this.DetailsTabPageControl.Controls.Add(this.ultraLabel5);
			this.DetailsTabPageControl.Controls.Add(this.ultraLabel4);
			this.DetailsTabPageControl.Location = new System.Drawing.Point(-10000, -10000);
			this.DetailsTabPageControl.Name = "DetailsTabPageControl";
			this.DetailsTabPageControl.Size = new System.Drawing.Size(778, 427);
			// 
			// ultraLabel5
			// 
			this.ultraLabel5.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel5.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel5.Location = new System.Drawing.Point(17, 171);
			this.ultraLabel5.Name = "ultraLabel5";
			this.ultraLabel5.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel5.TabIndex = 41;
			// 
			// ultraLabel4
			// 
			this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
			this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
			this.ultraLabel4.Location = new System.Drawing.Point(17, 44);
			this.ultraLabel4.Name = "ultraLabel4";
			this.ultraLabel4.Size = new System.Drawing.Size(745, 3);
			this.ultraLabel4.TabIndex = 40;
			// 
			// Ok_Button
			// 
			this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
			this.Ok_Button.Location = new System.Drawing.Point(534, 589);
			this.Ok_Button.Name = "Ok_Button";
			this.Ok_Button.Size = new System.Drawing.Size(125, 34);
			this.Ok_Button.TabIndex = 18;
			this.Ok_Button.Text = "�ۑ�(&S)";
			this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
			// 
			// tRetKeyControl1
			// 
			this.tRetKeyControl1.OwnerForm = this;
			this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
			this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
			// 
			// ultraStatusBar1
			// 
			this.ultraStatusBar1.Location = new System.Drawing.Point(0, 630);
			this.ultraStatusBar1.Name = "ultraStatusBar1";
			this.ultraStatusBar1.Size = new System.Drawing.Size(792, 23);
			this.ultraStatusBar1.TabIndex = 46;
			this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
			// 
			// tArrowKeyControl1
			// 
			this.tArrowKeyControl1.OwnerForm = this;
			this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
			// 
			// Bind_DataSet
			// 
			this.Bind_DataSet.DataSetName = "NewDataSet";
			this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
			// 
			// Mode_Label
			// 
			appearance116.ForeColor = System.Drawing.Color.White;
			appearance116.TextHAlignAsString = "Center";
			appearance116.TextVAlignAsString = "Middle";
			this.Mode_Label.Appearance = appearance116;
			this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
			this.Mode_Label.Location = new System.Drawing.Point(685, 1);
			this.Mode_Label.Name = "Mode_Label";
			this.Mode_Label.Size = new System.Drawing.Size(100, 23);
			this.Mode_Label.TabIndex = 58;
			this.Mode_Label.Text = "�X�V���[�h";
			// 
			// Delete_Button
			// 
			this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
			this.Delete_Button.Location = new System.Drawing.Point(411, 589);
			this.Delete_Button.Name = "Delete_Button";
			this.Delete_Button.Size = new System.Drawing.Size(125, 34);
			this.Delete_Button.TabIndex = 17;
			this.Delete_Button.Text = "���S�폜(&D)";
			this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
			// 
			// Revive_Button
			// 
			this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
			this.Revive_Button.Location = new System.Drawing.Point(535, 589);
			this.Revive_Button.Name = "Revive_Button";
			this.Revive_Button.Size = new System.Drawing.Size(125, 34);
			this.Revive_Button.TabIndex = 18;
			this.Revive_Button.Text = "����(&R)";
			this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
			// 
			// Cancel_Button
			// 
			this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
			this.Cancel_Button.Location = new System.Drawing.Point(660, 589);
			this.Cancel_Button.Name = "Cancel_Button";
			this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
			this.Cancel_Button.TabIndex = 19;
			this.Cancel_Button.Text = "����(&X)";
			this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
			// 
			// MainTabControl
			// 
			appearance117.BackColor = System.Drawing.Color.White;
			appearance117.BackColor2 = System.Drawing.Color.LightPink;
			appearance117.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.MainTabControl.ActiveTabAppearance = appearance117;
			appearance118.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance118.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
			appearance118.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			this.MainTabControl.Appearance = appearance118;
			this.MainTabControl.BackColorInternal = System.Drawing.Color.WhiteSmoke;
			this.MainTabControl.Controls.Add(this.ultraTabSharedControlsPage1);
			this.MainTabControl.Controls.Add(this.GeneralTabPageControl);
			this.MainTabControl.Controls.Add(this.SecurityTabPageControl);
			this.MainTabControl.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.MainTabControl.InterTabSpacing = new Infragistics.Win.DefaultableInteger(2);
			this.MainTabControl.Location = new System.Drawing.Point(5, 5);
			this.MainTabControl.Name = "MainTabControl";
			this.MainTabControl.SharedControlsPage = this.ultraTabSharedControlsPage1;
			this.MainTabControl.Size = new System.Drawing.Size(780, 575);
			this.MainTabControl.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.VisualStudio2005;
			appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			this.MainTabControl.TabHeaderAreaAppearance = appearance60;
			this.MainTabControl.TabIndex = 0;
			this.MainTabControl.TabLayoutStyle = Infragistics.Win.UltraWinTabs.TabLayoutStyle.SingleRowFixed;
			appearance119.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance119.BackColor2 = System.Drawing.Color.LightPink;
			ultraTab1.ActiveAppearance = appearance119;
			appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			appearance120.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraTab1.ClientAreaAppearance = appearance120;
			ultraTab1.FixedWidth = 60;
			ultraTab1.Key = "GeneralTab";
			ultraTab1.TabPage = this.GeneralTabPageControl;
			ultraTab1.Text = "�S��";
			appearance123.BackColor = System.Drawing.Color.WhiteSmoke;
			appearance123.BackColor2 = System.Drawing.Color.LightPink;
			ultraTab3.ActiveAppearance = appearance123;
			appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
			appearance124.BackGradientStyle = Infragistics.Win.GradientStyle.None;
			ultraTab3.ClientAreaAppearance = appearance124;
			ultraTab3.FixedWidth = 120;
			ultraTab3.Key = "SecurityTab";
			ultraTab3.TabPage = this.SecurityTabPageControl;
			ultraTab3.Text = "�Z�L�����e�B";
			this.MainTabControl.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab3});
			this.MainTabControl.TabsPerRow = 2;
			this.MainTabControl.TabStop = false;
			this.MainTabControl.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
			this.MainTabControl.ViewStyle = Infragistics.Win.UltraWinTabControl.ViewStyle.Office2003;
			this.MainTabControl.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(this.MainTabControl_SelectedTabChanged);
			// 
			// ultraTabSharedControlsPage1
			// 
			this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
			this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
			this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(778, 553);
			// 
			// Initial_Timer
			// 
			this.Initial_Timer.Interval = 1;
			this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
			// 
			// tImeControl1
			// 
			this.tImeControl1.InControl = this.Name_tEdit;
			this.tImeControl1.OutControl = this.Kana_tEdit;
			this.tImeControl1.OwnerForm = this;
			this.tImeControl1.PutLength = 30;
			// 
			// uiSetControl1
			// 
			this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
			this.uiSetControl1.OwnerForm = this;
			// 
			// ultraToolTipManager1
			// 
			this.ultraToolTipManager1.ContainingControl = this;
			this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
			// 
			// SFTOK09380UA
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(792, 653);
			this.Controls.Add(this.ultraStatusBar1);
			this.Controls.Add(this.Mode_Label);
			this.Controls.Add(this.MainTabControl);
			this.Controls.Add(this.Cancel_Button);
			this.Controls.Add(this.Revive_Button);
			this.Controls.Add(this.Delete_Button);
			this.Controls.Add(this.Ok_Button);
			this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SFTOK09380UA";
			this.Text = "�]�ƈ��ݒ�";
			this.Load += new System.EventHandler(this.SFTOK09380UA_Load);
			this.VisibleChanged += new System.EventHandler(this.SFTOK09380UA_VisibleChanged);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.SFTOK09380UA_Closing);
			this.GeneralTabPageControl.ResumeLayout(false);
			this.GeneralTabPageControl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CustLedgerBootCnt_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SalSlipInpBootCnt_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MailAddress2_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MailAddress1_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.UOESnmDiv_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode6_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode5_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode4_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode3_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode2_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmployAnalysCode1_tNedit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tNedit_SubSectionCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BelongSubSectionName_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionName)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCode)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EmploymentForm_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.JobType_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PortableTelNo_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Sex_tComboEditor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Kana_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ShortName_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Name_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tEdit_EmployeeCode)).EndInit();
			this.SecurityTabPageControl.ResumeLayout(false);
			this.SecurityTabPageControl.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LoginPasswordAgain_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LoginPassword_tEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LoginId_tEdit)).EndInit();
			this.DetailsTabPageControl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MainTabControl)).EndInit();
			this.MainTabControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		# region ��IMasterMaintenanceArrayType�����o�[

		# region ��Events
		/// <summary>��ʔ�\���C�x���g</summary>
		/// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ��Properties
		/// <summary>����\�ݒ�v���p�e�B</summary>
		/// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
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
		# endregion

		# region ��Public Methods
		/// <summary>
		/// �o�C���h�f�[�^�Z�b�g�擾����
		/// </summary>
		/// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
		/// <param name="tableName">�e�[�u������</param>
		/// <remarks>
		/// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = EMPLOYEE_TABLE;
		}

		/// <summary>
		/// �f�[�^��������
		/// </summary>
		/// <param name="totalCount">�S�Y������</param>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �擪����w�茏�����̃f�[�^���������A���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList employees = null;
            ArrayList employeesDtl = null;  // 2007.08.14 �ǉ�

			if (readCount == 0)
			{
				// ���o�Ώی�����0�̏ꍇ�͑S�����o�����s����
                // 2007.08.14 �C�� >>>>>>>>>>
                //status = this._employeeAcs.SearchAll(
				//			out employees,
			    //			this._enterpriseCode);
                status = this._employeeAcs.SearchAll(
                            out employees,
                            out employeesDtl,
                            this._enterpriseCode);
                // 2007.08.14 �C�� <<<<<<<<<<

				this._totalCount = employees.Count;
			}
			else
			{
                // 2007.08.14 �C�� >>>>>>>>>>
                //status = this._employeeAcs.SearchAll(
				//			out employees,
				//			out this._totalCount,
				//			out this._nextData,
				//			this._enterpriseCode,
				//			readCount,
				//			this._prevEmployee);
                status = this._employeeAcs.SearchAll(
                            out employees,
                            out employeesDtl,
                            out this._totalCount,
                            out this._nextData,
                            this._enterpriseCode,
                            readCount,
                            this._prevEmployee,
                            this._employeeDtl);
                // 2007.08.14 �C�� <<<<<<<<<<
            }

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 2010/02/18 Add >>>
                    List<FeliCaMngWork> felicaMngLs = null;
                    if (_optFeliCaAcs)
                    {
                        if (_optFeliCaAcs)
                        {
                            _employeeAcs.SearchStaticMemory_FeliCa(out felicaMngLs);
                        }
                    }
                    // 2010/02/18 Add <<<

                    ReadSecInfoSet();

                    ArrayList employeeList = new ArrayList();

                    // --- ADD 2009/03/17 ��QID:11347�Ή�------------------------------------------------------>>>>>
                    // �f�[�^�r���[�\������
                    switch (LoginInfoAcquisition.Employee.UserAdminFlag)
                    {
                        // ���[�U�[�Ǘ��҃t���O = 1,2 �̃f�[�^�͕\�����Ȃ�
                        case 0:
                            {
                                foreach (Employee employee in employees)
                                {
                                    if ((employee.UserAdminFlag != 1) && (employee.UserAdminFlag != 2))
                                    {
                                        employeeList.Add(employee.Clone());
                                    }
                                }
                                break;
                            }
                        // ���[�U�[�Ǘ��҃t���O = 0,1 �̃f�[�^��\������
                        case 1:
                            {
                                foreach (Employee employee in employees)
                                {
                                    if ((employee.UserAdminFlag == 0) || (employee.UserAdminFlag == 1))
                                    {
                                        employeeList.Add(employee.Clone());
                                    }
                                }
                                break;
                            }
                        // ���[�U�[�Ǘ��҃t���O = 1,2 �̃f�[�^��\������
                        case 2:
                            {
                                foreach (Employee employee in employees)
                                {
                                    if ((employee.UserAdminFlag == 1) || (employee.UserAdminFlag == 2))
                                    {
                                        employeeList.Add(employee.Clone());
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    // --- ADD 2009/03/17 ��QID:11347�Ή�------------------------------------------------------<<<<<
                    
					// �ŏI�̏]�ƈ��I�u�W�F�N�g��ޔ�����
                    // --- CHG 2009/03/17 ��QID:11347�Ή�------------------------------------------------------>>>>>
                    //this._prevEmployee = ((Employee)employees[employees.Count - 1]).Clone();
                    this._prevEmployee = ((Employee)employeeList[employeeList.Count - 1]).Clone();
                    // --- CHG 2009/03/17 ��QID:11347�Ή�------------------------------------------------------<<<<<

					int index = 0;
                    // --- CHG 2009/03/17 ��QID:11347�Ή�------------------------------------------------------>>>>>
                    //foreach (Employee employee in employees)
                    foreach (Employee employee in employeeList)
                    // --- CHG 2009/03/17 ��QID:11347�Ή�------------------------------------------------------<<<<<
                    {
						if (this._employeeTable.ContainsKey(employee.FileHeaderGuid) == false)
						{
							EmployeeToDataSet(employee.Clone(), index);
                            // 2010/02/18 Add >>>
                            if (_optFeliCaAcs)
                            {
                                if (felicaMngLs != null)
                                {
                                    FeliCaMngWork felicaMng;
                                    felicaMng = felicaMngLs.Find(delegate(FeliCaMngWork itm)
                                    {
                                        return (itm.EmployeeCode == employee.EmployeeCode);
                                    });
                                    FeliCaMngToDataSet(felicaMng, employee.EmployeeCode);
                                }

                            }
                            // 2010/02/18 Add <<<
							++index;
						}
					}

                    // 2007.08.14 �ǉ� >>>>>>>>>>
                    this._employeeDtlData = employeesDtl;
                    // 2007.08.14 �ǉ� <<<<<<<<<<

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(
						this,								  // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
						ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							  // �v���O��������
						"Search",							  // ��������
						TMsgDisp.OPE_GET,					  // �I�y���[�V����
						ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
						this._employeeAcs,					  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��

					break;
				}
			}

			totalCount = this._totalCount;

			return status;
		}

		/// <summary>
		/// �l�N�X�g�f�[�^��������
		/// </summary>
		/// <param name="readCount">���o�Ώی���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			int dummy = 0;
			ArrayList employees = null;
            ArrayList employeesDtl = null;  // 2007.08.14 �ǉ�

			// ���o�Ώی�����0�̏ꍇ�́A�c��̑S���𒊏o
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

            // 2007.08.14 �C�� >>>>>>>>>>
            //int status = this._employeeAcs.SearchAll(
			//				out employees,
			//				out dummy,
			//				out this._nextData,
			//				this._enterpriseCode,
			//				readCount,
			//				this._prevEmployee);
            int status = this._employeeAcs.SearchAll(
                            out employees,
                            out employeesDtl,
                            out dummy,
                            out this._nextData,
                            this._enterpriseCode,
                            readCount,
                            this._prevEmployee,
                            this._employeeDtl);
            // 2007.08.14 �C�� <<<<<<<<<<

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 2010/02/18 Add >>>
                    List<FeliCaMngWork> felicaMngLs = null;
                    if (_optFeliCaAcs)
                    {
                        _employeeAcs.SearchStaticMemory_FeliCa(out felicaMngLs);
                    }
                    // 2010/02/18 Add <<<

                    // �ŏI�̏]�ƈ��N���X��ޔ�����
					this._prevEmployee = ((Employee)employees[employees.Count - 1]).Clone();

					int index = 0;
					foreach (Employee employee in employees)
					{
						if (this._employeeTable.ContainsKey(employee.FileHeaderGuid) == false)
						{
							index = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Count;
							EmployeeToDataSet(employee.Clone(), index);
                            // 2010/02/18 Add >>>
                            if (_optFeliCaAcs)
                            {
                                if (felicaMngLs != null)
                                {
                                    FeliCaMngWork felicaMng;
                                    felicaMng = felicaMngLs.Find(delegate(FeliCaMngWork itm)
                                    {
                                        return (itm.EmployeeCode == employee.EmployeeCode);
                                    });

                                    if (felicaMng != null)
                                        FeliCaMngToDataSet(felicaMng, employee.EmployeeCode);
                                }

                            }
                            // 2010/02/18 Add <<<
						}
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					TMsgDisp.Show(
						this,								  // �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
						ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							  // �v���O��������
						"SearchNext",						  // ��������
						TMsgDisp.OPE_GET,					  // �I�y���[�V����
						ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
						status,								  // �X�e�[�^�X�l
						this._employeeAcs,					  // �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				  // �\������{�^��
						MessageBoxDefaultButton.Button1);	  // �����\���{�^��

					break;
				}
			}

			return status;
		}

		/// <summary>
		/// �f�[�^�폜����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �I�𒆂̃f�[�^���폜���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Delete()
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
			Employee employee = ((Employee)this._employeeTable[guid]).Clone();
            EmployeeDtl employeeDtl = null;
            if (employee != null)
            {
                employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
            }

            // 2007.08.14 �C�� >>>>>>>>>>
            //int status = this._employeeAcs.LogicalDelete(ref employee);
            int status = this._employeeAcs.LogicalDelete(ref employee, ref employeeDtl);
            // 2007.08.14 �C�� <<<<<<<<<<

            // 2010/02/18 Add >>>
            FeliCaMngWork felicaMng = null;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (_optFeliCaAcs)
                {
                    string idm = string.Empty;
                    if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                        idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                    _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                    if (felicaMng != null)
                        status = _employeeAcs.LogicalDelete_FeliCa(ref felicaMng);
                }
            }
            // 2010/02/18 Add <<<

            switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 2010/02/18 Add >>>
                    if (_optFeliCaAcs)
                        FeliCaMngToDataSet(felicaMng, employee.EmployeeCode);
                    // 2010/02/18 Add <<<
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// �r������
					ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._employeeAcs);
					return status;
				}

				//// 2005.11.16 ADD UENO///////////////////////////////////////////////////////////////
				case -2:
				{
					//���Ɛݒ�Ŏg�p��
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						ASSEMBLY_ID,
						"���̃��R�[�h�͎��Ɛݒ�Ŏg�p����Ă��邽�ߍ폜�ł��܂���",
						status,
						MessageBoxButtons.OK);
					this.Hide();

					return status;
				}
				//// 2005.11.16 END UENO///////////////////////////////////////////////////////////////

				default:
				{
					TMsgDisp.Show(
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"Delete",							// ��������
						TMsgDisp.OPE_HIDE,					// �I�y���[�V����
						ERR_RDEL_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						this._employeeAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��

					return status;
				}
			}

			// �f�[�^�Z�b�g�W�J����
			EmployeeToDataSet(employee.Clone(), this._dataIndex);
            ScreenToEmployeeDtl(employeeDtl);   // 2007.08.14 �ǉ�

			return status;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ������������s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Print()
		{
			// ����p�A�Z���u�������[�h����i�������j
			return 0;
		}

		/// <summary>
		/// �O���b�h��O�Ϗ��擾����
		/// </summary>
		/// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
		/// <remarks>
		/// <br>Note       : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
			appearanceTable.Add(SECTIONNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(KANA_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(SHORTNAME_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(SEXNAME_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(BIRTHDAY_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(COMPANYTELNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(PORTABLETELNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //appearanceTable.Add(POSTNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            ////appearanceTable.Add(FRONTMECHANAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(INOUTSIDECOMPANYNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));            
            //appearanceTable.Add(BUSINESSNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
            //appearanceTable.Add(GELAVORRATECOST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, MONEY_FORMAT, Color.Black));
            //appearanceTable.Add(CILAVORRATECOST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, MONEY_FORMAT, Color.Black));
            //appearanceTable.Add(BPLAVORRATECOST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, MONEY_FORMAT, Color.Black));
            //appearanceTable.Add(BRLAVORRATECOST_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleRight, MONEY_FORMAT, Color.Black));

            // DEL 2008/10/10 �s��Ή�[6440] ---------->>>>>
            //appearanceTable.Add(JOBTYPE_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            //appearanceTable.Add(EMPLOYMENTFORM_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
            // DEL 2008/10/10 �s��Ή�[6440] ----------<<<<
            // ADD 2008/10/10 �s��Ή�[6440] ---------->>>>>
            appearanceTable.Add(JOBTYPE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            appearanceTable.Add(EMPLOYMENTFORM_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // ADD 2008/10/10 �s��Ή�[6440] ----------<<<<<
            
			appearanceTable.Add(ENTERCOMPANYDATE_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(RETIREMENTDATE_TITLE, new GridColAppearance(MGridColDispType.DetailsOnly, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(LOGINID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2010/02/18 Add >>>
            if (_optFeliCaAcs)
            {   //�t�F���J�A�N�Z�X�T�[�r�X�I�v�V���������Ȃ�
                appearanceTable.Add(FELICAIDM_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(FELICAIDMSTATE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
                appearanceTable.Add(FELICAMNGKIND_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
            }
            // 2010/02/18 Add <<<

			return appearanceTable;
		}

        /// <summary>
        /// ���Џ��ǂݍ��ݏ���
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���Џ��̎擾���s���B</br>
        /// <br>Programmer  : 980035 ���� ��`</br>
        /// <br>Date        : 2008.01.16</br>
        /// </remarks>
        public void GetCompanyInf()
        {
            // ���Џ��ǂݍ���
            int status = this._companyInfAcs.Read(out this._companyInf, this._enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._secMngDiv = this._companyInf.SecMngDiv;
            }
        }
        # endregion

		# endregion

		#region ��Private Menbers
		private EmployeeAcs _employeeAcs;
		private Employee _prevEmployee;
		private SecInfoAcs _secInfoAcs;
        //private UserGuideAcs _userGuideAcs;     // DEL 2008/11/04 �s��Ή�[7289]
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _employeeTable;
		// �v���p�e�B�p
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private Employee _employeeClone;
		//_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
		private int _indexBuf;
		/// <summary>���_�I�v�V�����t���O</summary>
		private bool _optSection = false;
        private int _secMngDiv;                 // 2008.01.16 �ǉ�

        // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- >>>>> 
        // ���j���[�ȈՋN���I�v�V����
        private bool _opMenuSimpleStart = false;
        // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- <<<<<

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        // �������x���P�f�[�^
        private Hashtable AuthorityLevel1Table;
        // �������x���Q�f�[�^
        private Hashtable AuthorityLevel2Table;

        private ArrayList _employeeDtlData;     // 2007.08.14 �ǉ�
        private EmployeeDtl _employeeDtl;       // 2007.08.14 �ǉ�
        private EmployeeDtl _employeeDtlClone;  // 2007.08.14 �ǉ�

        // ���Џ��A�N�Z�X�N���X
        private CompanyInfAcs _companyInfAcs;   // 2008.01.16 �ǉ�
        private CompanyInf _companyInf;         // 2008.01.16 �ǉ�

        private SecInfoSetAcs _secInfoSetAcs;
        private SubSectionAcs _subSectionAcs;
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, SubSection> _subSectionDic;

        // ADD 2008/10/10 �s��Ή�[6442] ---------->>>>>
        /// <summary>�N�����̋敪���X�g</summary>
        List<emDateFormat> _yearOnlyList;
        /// <summary>�N�������̋敪���X�g</summary>
        List<emDateFormat> _monthOnlyList;
        // ADD 2008/10/10 �s��Ή�[6442] ----------<<<<<

        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g

        // 2010/02/18 Add >>>
        private bool _optFeliCaAcs = false;
        // 2010/02/18 Add <<<
        # endregion

		# region ��Consts
		// Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
		private const string DELETE_DATE = "�폜��";
		private const string SECTIONNAME_TITLE = "�������_";
		private const string CODE_TITLE = "�S���҃R�[�h";
		private const string NAME_TITLE = "�S���Җ�";
        // DEL 2008/10/09 �s��Ή�[6441] ��
        //private const string KANA_TITLE = "�S���҃J�i";
        private const string KANA_TITLE = "�S����(��)"; // ADD 2008/10/09 �s��Ή�[6441]
		private const string SHORTNAME_TITLE = "�S���җ���";
		private const string SEXNAME_TITLE = "����";
		private const string BIRTHDAY_TITLE = "���N����";
		private const string COMPANYTELNO_TITLE = "�d�b�ԍ�(���)";
		private const string PORTABLETELNO_TITLE = "�d�b�ԍ�(�g��)";
        //private const string POSTNAME_TITLE = "��E";           // DEL 2008/11/04 �s��Ή�[7289]
        //private const string FRONTMECHANAME_TITLE = "��t�E���J";
        // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
        //private const string INOUTSIDECOMPANYNAME_TITLE = "�Г��E�ЊO";
        //private const string BUSINESSNAME_TITLE = "�Ɩ�";
        // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
        //private const string GELAVORRATECOST_TITLE = "���o���[�g����(���)";
        //private const string CILAVORRATECOST_TITLE = "���o���[�g����(�Ԍ�)";
        //private const string BRLAVORRATECOST_TITLE = "���o���[�g����(���)";
        //private const string BPLAVORRATECOST_TITLE = "���o���[�g����(�h��)";
        // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
        //private const string JOBTYPE_TITLE = "�E��";
        //private const string EMPLOYMENTFORM_TITLE = "�ٗp�`��";
        // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
        // ADD 2008/11/04 �s��Ή�[7289] ---------->>>>>
        private const string JOBTYPE_TITLE = "���[���i�Ɩ��j";
        private const string EMPLOYMENTFORM_TITLE = "���[���i�����j";
        // ADD 2008/11/04 �s��Ή�[7289] ----------<<<<<
        // 2007.09.04 �ǉ� >>>>>>>>>>
        private const int       NULL_JOBTYPE_CODE = 0;
        private const string    NULL_JOBTYPE_NAME = "";        
        private const int       NULL_EMPLOYMENTFORM_CODE = 0;
        private const string    NULL_EMPLOYMENTFORM_NAME = "";
        // 2007.09.04 �ǉ� <<<<<<<<<<

		private const string ENTERCOMPANYDATE_TITLE = "���Г�";
		private const string RETIREMENTDATE_TITLE = "�ސE��";
		private const string LOGINID_TITLE = "���O�C��ID";
		private const string GUID_TITLE = "GUID";
		private const string EMPLOYEE_TABLE = "EMPLOYEE";
		
		// Format��`
        //private const string MONEY_FORMAT = "###,###,##0�~";

		// �ҏW���[�h
		private const string INSERT_MODE = "�V�K���[�h";
		private const string UPDATE_MODE = "�X�V���[�h";
		private const string DELETE_MODE = "�폜���[�h";

		// �R���g���[������
		private const string TAB1_NAME = "GeneralTab";
		private const string TAB2_NAME = "SecurityTab";
        //private const string TAB3_NAME = "DetailsTab";  // 2007.08.14 �ǉ�
		// Message�֘A��`
		private const string ASSEMBLY_ID	= "SFTOK09380U";
		private const string PG_NM			= "�����ӕی���Гo�^�C��";
		private const string ERR_READ_MSG	= "�ǂݍ��݂Ɏ��s���܂����B";
		private const string ERR_DPR_MSG	= "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_DPR_MSG2 = "���̃t�F���JID�͊��Ɏg�p����Ă��܂��B";   // 2010/02/18 Add
		private const string ERR_RDEL_MSG	= "�폜�Ɏ��s���܂����B";
		private const string ERR_UPDT_MSG	= "�o�^�Ɏ��s���܂����B";
		private const string ERR_RVV_MSG	= "�����Ɏ��s���܂����B";
		private const string ERR_800_MSG	= "���ɑ��[�����X�V����Ă��܂�";
		private const string ERR_801_MSG	= "���ɑ��[�����폜����Ă��܂�";
		private const string SDC_RDEL_MSG	= "�}�X�^����폜����Ă��܂�";

        // 2010/02/18 Add >>>
        private const string FELICAIDM_TITLE = "FeliCaIDm";
        private const string FELICAIDMSTATE_TITLE = "�t�F���J���";
        private const string FELICAMNGKIND_TITLE = "FeliCa�Ǘ����";
        // 2010/02/18 Add <<<

        #endregion
    
		# region ��Main
		/// <summary>�A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFTOK09380UA());
		}
		# endregion

		#region ��IMasterMaintenanceInputStart Members
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paraTable"></param>
		/// <returns></returns>
		public DialogResult ShowDialog(Hashtable paraTable)
		{
			this.ShowDialog();
			return this.DialogResult;
		}
		#endregion

		# region ��Private Methods
        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>�ǉ�</summary>
            Insert = 1,
            /// <summary>�C��</summary>
            Update = 2,
            /// <summary>�_���폜</summary>
            LogicalDelete = 3,
            /// <summary>���S�폜</summary>
            Delete = 4,
            /// <summary>����</summary>
            Revive = 5,
        }

        // ���쌠���̐���I�u�W�F�N�g�ۗ̕L
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateMasterMaintenanceOperationAuthority("SFTOK09380U", this);
                }
                return _operationAuthority;
            }
        }

		/// <summary>
		/// �]�ƈ��I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
		/// </summary>
		/// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
		/// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note       : �]�ƈ��N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void EmployeeToDataSet(Employee employee, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Count <= index))
			{
				// �V�K�Ɣ��f���āA�s��ǉ�����
				DataRow dataRow = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].NewRow();
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Add(dataRow);

				// index���s�̍ŏI�s�ԍ�����
				index = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Count - 1;
			}

			if (employee.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][DELETE_DATE] = employee.UpdateDateTimeJpInFormal;
			}
													   
			// �������_
            this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][SECTIONNAME_TITLE] = GetSectionName(employee.BelongSectionCode);
			// �]�ƈ��R�[�h
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][CODE_TITLE] = employee.EmployeeCode;
			// ����
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][NAME_TITLE] = employee.Name;
			// �J�i
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][KANA_TITLE] = employee.Kana;
			// �Z�k����
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][SHORTNAME_TITLE] = employee.ShortName;
			// ���ʖ���
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][SEXNAME_TITLE] = employee.SexName;
			// ���N����
			if (employee.Birthday == DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BIRTHDAY_TITLE] = DBNull.Value;
			}
			else
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BIRTHDAY_TITLE] = employee.BirthdayJpFormal;
			}
			// �d�b�ԍ��i��Ёj
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][COMPANYTELNO_TITLE] = employee.CompanyTelNo;
			// �d�b�ԍ��i�g�сj
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][PORTABLETELNO_TITLE] = employee.PortableTelNo;
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
			// ��E����
            //string wkString;
            //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.PostCode, employee.PostCode);
            //// ADD 2008/10/10 �s��Ή�[6440] ---------->>>>>
            //if (wkString.Equals("���o�^"))
            //{
            //    wkString = "";
            //}
            //// ADD 2008/10/10 �s��Ή�[6440] ----------<<<<<            
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][POSTNAME_TITLE] = wkString;
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
			// ��t�E���J����
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][FRONTMECHANAME_TITLE] = employee.FrontMechaName;
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //// �Г��E�ЊO����
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][INOUTSIDECOMPANYNAME_TITLE] = employee.InOutsideCompanyName;
            
            //// �Ɩ�����
            //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.BusinessCode, employee.BusinessCode);
            //// ADD 2008/10/10 �s��Ή�[6440] ---------->>>>>
            //if (wkString.Equals("���o�^"))
            //{
            //    wkString = "";
            //}
            //// ADD 2008/10/10 �s��Ή�[6440] ----------<<<<<
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BUSINESSNAME_TITLE] = wkString;
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
			// ���o���[�g�����i��ʁj
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][GELAVORRATECOST_TITLE] = employee.LvrRtCstGeneral;
			// ���o���[�g�����i�Ԍ��j
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][CILAVORRATECOST_TITLE] = employee.LvrRtCstCarInspect;
			// ���o���[�g�����i����j
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BRLAVORRATECOST_TITLE] = employee.LvrRtCstBodyRepair;
			// ���o���[�g�����i�h���j
            //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][BPLAVORRATECOST_TITLE] = employee.LvrRtCstBodyPaint;

            // 2007.09.04 �C�� >>>>>>>>>>
            // �E��
            if (this.AuthorityLevel1Table.ContainsKey(employee.AuthorityLevel1.ToString()))
            {
                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][JOBTYPE_TITLE] = this.AuthorityLevel1Table[employee.AuthorityLevel1.ToString()].ToString();
                //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][JOBTYPE_TITLE] = employee.AuthorityLevel1;
            }
            else
            {
                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][JOBTYPE_TITLE] = this.AuthorityLevel1Table[NULL_JOBTYPE_CODE.ToString()].ToString();
            }

            // �ٗp�`��
            if (this.AuthorityLevel2Table.ContainsKey(employee.AuthorityLevel2.ToString()))
            {
                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][EMPLOYMENTFORM_TITLE] = this.AuthorityLevel2Table[employee.AuthorityLevel2.ToString()].ToString();
                //this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][EMPLOYMENTFORM_TITLE] = employee.AuthorityLevel2;
            }
            else
            {
                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][EMPLOYMENTFORM_TITLE] = this.AuthorityLevel2Table[NULL_EMPLOYMENTFORM_CODE.ToString()].ToString();
            }
            // 2007.09.04 �C�� <<<<<<<<<<

			// ���Г�
			if (employee.EnterCompanyDate == DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][ENTERCOMPANYDATE_TITLE]= DBNull.Value;
			}
			else
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][ENTERCOMPANYDATE_TITLE]= employee.EnterCompanyDateJpFormal;
			}
			// �ގГ�
			if (employee.RetirementDate == DateTime.MinValue)
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][RETIREMENTDATE_TITLE]  = DBNull.Value;
			}
			else
			{
				this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][RETIREMENTDATE_TITLE]  = employee.RetirementDateJpFormal;
			}
			// ���O�C��ID
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][LOGINID_TITLE]	= employee.LoginId;
			// GUID
			this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[index][GUID_TITLE] = employee.FileHeaderGuid;

			if (this._employeeTable.ContainsKey(employee.FileHeaderGuid))
			{
				this._employeeTable.Remove(employee.FileHeaderGuid);
			}
			this._employeeTable.Add(employee.FileHeaderGuid, employee);
        }

        // 2010/02/18 Add >>>
        /// <summary>
        /// FeliCa�Ǘ��I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="felicaMng">�t�F���J�Ǘ����[�N</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ��N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private void FeliCaMngToDataSet(FeliCaMngWork felicaMng, string employeeCode)
        {
            // �t�F���J�A�N�Z�X�T�[�r�X�I�v�V�����������Ȃ�I��
            if (!_optFeliCaAcs) return;

            // ����s���擾����
            DataRow[] dataRows = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Select(CODE_TITLE + " = '" + employeeCode + "'");
            if ((dataRows == null) || (dataRows.Length == 0)) return;
            DataRow dataRow = dataRows[0];

            if (felicaMng == null)
            {
                dataRow[FELICAIDMSTATE_TITLE] = string.Empty;
                dataRow[FELICAIDM_TITLE] = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(felicaMng.FeliCaIDm))
            {
                dataRow[FELICAIDMSTATE_TITLE] = string.Empty;
                dataRow[FELICAIDM_TITLE] = string.Empty;
            }
            else
            {
                dataRow[FELICAIDMSTATE_TITLE] = "�o�^��";
                dataRow[FELICAIDM_TITLE] = felicaMng.FeliCaIDm;
            }
            dataRow[FELICAMNGKIND_TITLE] = felicaMng.FeliCaMngKind;
        }
        // 2010/02/18 Add <<<

		/// <summary>
		/// �f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
		///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable employeeTable = new DataTable(EMPLOYEE_TABLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
			employeeTable.Columns.Add(DELETE_DATE,				  typeof(string));
			employeeTable.Columns.Add(SECTIONNAME_TITLE,		  typeof(string));
			employeeTable.Columns.Add(CODE_TITLE,				  typeof(string));
			employeeTable.Columns.Add(NAME_TITLE,				  typeof(string));
			employeeTable.Columns.Add(KANA_TITLE,				  typeof(string));
			employeeTable.Columns.Add(SHORTNAME_TITLE,			  typeof(string));
			employeeTable.Columns.Add(SEXNAME_TITLE,			  typeof(string));
			employeeTable.Columns.Add(BIRTHDAY_TITLE,			  typeof(string));
			employeeTable.Columns.Add(COMPANYTELNO_TITLE,		  typeof(string));
			employeeTable.Columns.Add(PORTABLETELNO_TITLE,		  typeof(string));
            //employeeTable.Columns.Add(FRONTMECHANAME_TITLE,		  typeof(string));
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //employeeTable.Columns.Add(INOUTSIDECOMPANYNAME_TITLE, typeof(string));            
            //employeeTable.Columns.Add(POSTNAME_TITLE,			  typeof(string));
            //employeeTable.Columns.Add(BUSINESSNAME_TITLE,		  typeof(string));
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
            //employeeTable.Columns.Add(GELAVORRATECOST_TITLE,	  typeof(long));
            //employeeTable.Columns.Add(CILAVORRATECOST_TITLE,	  typeof(long));
            //employeeTable.Columns.Add(BPLAVORRATECOST_TITLE,	  typeof(long));
            //employeeTable.Columns.Add(BRLAVORRATECOST_TITLE,	  typeof(long));

            employeeTable.Columns.Add(JOBTYPE_TITLE,              typeof(string));
            employeeTable.Columns.Add(EMPLOYMENTFORM_TITLE,       typeof(string));

			employeeTable.Columns.Add(ENTERCOMPANYDATE_TITLE,     typeof(string));
			employeeTable.Columns.Add(RETIREMENTDATE_TITLE,		  typeof(string));
			employeeTable.Columns.Add(LOGINID_TITLE,			  typeof(string));
			employeeTable.Columns.Add(GUID_TITLE,				  typeof(Guid));

            // 2010/02/18 Add >>>
            if (_optFeliCaAcs)
            {
                employeeTable.Columns.Add(FELICAIDMSTATE_TITLE,   typeof(string));
                employeeTable.Columns[FELICAIDMSTATE_TITLE].DefaultValue = string.Empty;
                employeeTable.Columns.Add(FELICAIDM_TITLE,        typeof(string));
                employeeTable.Columns.Add(FELICAMNGKIND_TITLE,    typeof(Int32));
            }
            // 2010/02/18 Add <<<

			this.Bind_DataSet.Tables.Add(employeeTable);
		}

		/// <summary>
		/// ��ʏ����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			this.Sex_tComboEditor.Items.Clear();
			this.Sex_tComboEditor.Items.Add(0,"�j");									
			this.Sex_tComboEditor.Items.Add(1,"��");									
			this.Sex_tComboEditor.Items.Add(2,"�s��");

            //this.PostCode_tComboEditor.Items.Clear();       // DEL 2008/11/04 �s��Ή�[7289]

            //this.FrontMechaCode_tComboEditor.Items.Clear();
            //this.FrontMechaCode_tComboEditor.Items.Add(0,"��t");						
            //this.FrontMechaCode_tComboEditor.Items.Add(1,"���J");						
            //this.FrontMechaCode_tComboEditor.Items.Add(2,"�c��");						

            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //this.InOutsideCompanyCode_tComboEditor.Items.Clear();
            //this.InOutsideCompanyCode_tComboEditor.Items.Add(0,"�Г�");
            //this.InOutsideCompanyCode_tComboEditor.Items.Add(1,"�ЊO");

            //this.BusinessCode_tComboEditor.Items.Clear();
			// DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<

			#region // -- Del 2012.05.29 30182 R.Tachiya --
			//// 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			////this.Ok_Button.Location = new System.Drawing.Point(535, 494);
			////this.Cancel_Button.Location = new System.Drawing.Point(660, 494);
			////this.Delete_Button.Location = new System.Drawing.Point(410, 494);
			////this.Revive_Button.Location = new System.Drawing.Point(535, 494);
			//this.Ok_Button.Location = new System.Drawing.Point(535, 562);
			//this.Cancel_Button.Location = new System.Drawing.Point(660, 562);
			//this.Delete_Button.Location = new System.Drawing.Point(410, 562);
			//this.Revive_Button.Location = new System.Drawing.Point(535, 562);
			//// 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			#endregion

			// -- Add St 2012.05.29 30182 R.Tachiya --
			this.Ok_Button.Location = new System.Drawing.Point(535, 589);
			this.Cancel_Button.Location = new System.Drawing.Point(660, 589);
			this.Delete_Button.Location = new System.Drawing.Point(410, 589);
			this.Revive_Button.Location = new System.Drawing.Point(535, 589);
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

			// �������x���P(�E��)�R���{�G�f�B�^�[
            this.JobType_tComboEditor.Items.Clear();
            foreach (DictionaryEntry de in AuthorityLevel1Table)
            {
                if (Int32.Parse(de.Key.ToString()) != 0)
                {
                    this.JobType_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }

            //this.JobType_tComboEditor.Items.Add(80, "�X��");
            //this.JobType_tComboEditor.Items.Add(70, "�X���̔���(���Ј�)");
            //this.JobType_tComboEditor.Items.Add(60, "�X���̔���(�A���o�C�g)");
            //this.JobType_tComboEditor.Items.Add(40, "�o�b�N���[�h�S����");
            //this.JobType_tComboEditor.Items.Add(20, "����(���Ј�)");
            //this.JobType_tComboEditor.Items.Add(10, "����(�A���o�C�g)");


            // �������x���Q(�ٗp�`��)�R���{�G�f�B�^�[
            this.EmploymentForm_tComboEditor.Items.Clear();
            foreach (DictionaryEntry de in AuthorityLevel2Table)
            {
                if (Int32.Parse(de.Key.ToString()) != 0)
                {
                    this.EmploymentForm_tComboEditor.Items.Add(de.Key, de.Value.ToString());
                }
            }
            
            //this.EmploymentForm_tComboEditor.Items.Add(50, "���Ј�");
            //this.EmploymentForm_tComboEditor.Items.Add(10, "�A���o�C�g");

            // 2008.01.16 �ǉ� >>>>>>>>>>
            // �����Ǘ�
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (this._secMngDiv != 2)
            {
                this.BelongMinSectionTitle_Label.Visible = false;
                this.BelongMinSectionCode_tNedit.Visible = false;
                this.BelongMinSectionName_tEdit.Visible = false;
                this.BelongMinSectionGuide_ultraButton.Visible = false;

                this.OldBelongMinSecTitle_Label.Visible = false;
                this.OldBelongMinSecCd_tNedit.Visible = false;
                this.OldBelongMinSecNm_tEdit.Visible = false;
                this.OldBelongMinSecGd_ultraButton.Visible = false;
            }
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            if (this._secMngDiv == 0)
            {
                this.BelongSubSectionTitle_Label.Visible = false;
                this.tNedit_SubSectionCode.Visible = false;
                this.BelongSubSectionName_tEdit.Visible = false;
                this.BelongSubSectionGuide_ultraButton.Visible = false;

                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this.OldBelongSubSecTitle_Label.Visible = false;
                this.OldBelongSubSecCd_tNedit.Visible = false;
                this.OldBelongSubSecNm_tEdit.Visible = false;
                this.OldBelongSubSecGd_ultraButton.Visible = false;
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            }
            // 2008.01.16 �ǉ� <<<<<<<<<<

            // 2010/02/18 Add >>>
            FeliCaMngDelete_uButton.Visible = _optFeliCaAcs;
            FeliCaMngGuide_uButton.Visible = _optFeliCaAcs;
            FeliCaInfo_Title_uLabel.Visible = _optFeliCaAcs;
            FeliCaInfo_uLabel.Visible = _optFeliCaAcs;
            // 2010/02/18 Add <<<
		}

		/// <summary>
		/// ��ʃN���A����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��ʂ��N���A���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.Guid_Label.Text = "";	
			this.tEdit_EmployeeCode.Text = "";							
			this.Name_tEdit.Text = "";						
			this.ShortName_tEdit.Text = "";						
			this.Kana_tEdit.Text = "";								
			this.Sex_tComboEditor.Value = 0;						
			this.Birthday_tDateEdit.Clear();								
			this.CompanyTelNo_tEdit.Clear();
            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.MailAddress1_tEdit.Clear();
            this.MailAddress2_tEdit.Clear();
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            this.PortableTelNo_tEdit.Clear();
			this.EnterCompanyDate_tDateEdit.Clear();
			this.RetirementDate_tDateEdit.Clear();
            //this.FrontMechaCode_tComboEditor.SelectedIndex = 0;
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //this.InOutsideCompanyCode_tComboEditor.SelectedIndex = 0;
            //this.PostCode_tComboEditor.SelectedIndex = 0;
            //this.BusinessCode_tComboEditor.SelectedIndex = 0;
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<
            //this.BelongSelectionCode_tComboEditor.SelectedIndex = 0;  // 2008/06/04 �폜
            //this.LvrRtCstGeneral_tNedit.Clear();
            //this.LvrRtCstCarInspect_tNedit.Clear();
            //this.LvrRtCstBodyRepair_tNedit.Clear();
            //this.LvrRtCstBodyPaint_tNedit.Clear();

            // --- CHG 2008/10/02 --------------------------------------------------------------------->>>>>
            //this.JobType_tComboEditor.SelectedIndex = 6;
            //this.EmploymentForm_tComboEditor.SelectedIndex = 0;
            this.JobType_tComboEditor.SelectedIndex = -1;
            this.EmploymentForm_tComboEditor.SelectedIndex = -1;
            // --- CHG 2008/10/02 ---------------------------------------------------------------------<<<<<

			// -- Add St 2012.05.29 30182 R.Tachiya --
			this.SalSlipInpBootCnt_tNedit.Clear();
			this.CustLedgerBootCnt_tNedit.Clear();
			// -- Add St 2012.05.29 30182 R.Tachiya --

			this.UserAdminName_uLabel.Text = "";

			this.LoginId_tEdit.Clear();
			this.LoginPassword_tEdit.Clear();
			this.LoginPasswordAgain_tEdit.Clear();

            // 2010/02/18 Add >>>
            if (_optFeliCaAcs)
            {
                this.FeliCaInfo_uLabel.Text = string.Empty;
                this.FeliCaInfo_uLabel.Tag = null;
            }
            // 2010/02/18 Add <<<

            ScreenClearSub();   // 2007.08.14 �ǉ�
		}

        // 2007.08.14 �ǉ� >>>>>>>>>>
        /// <summary>
        /// ��ʃN���A�T�u����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ڍ׉�ʂ��N���A���܂��B</br>
        /// <br>Programmer : 980035 ����  ��`</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void ScreenClearSub()
        {
            this.tNedit_SubSectionCode.Clear();
            this.BelongSubSectionName_tEdit.Clear();
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.BelongMinSectionCode_tNedit.Clear();
            this.BelongMinSectionName_tEdit.Clear();
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            this.EmployAnalysCode1_tNedit.Clear();
            this.EmployAnalysCode2_tNedit.Clear();
            this.EmployAnalysCode3_tNedit.Clear();
            this.EmployAnalysCode4_tNedit.Clear();
            this.EmployAnalysCode5_tNedit.Clear();
            this.EmployAnalysCode6_tNedit.Clear();

            this.UOESnmDiv_tEdit.Clear();      //2008.11.10 add
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.OldBelongSectionCd_tEdit.Clear();
            this.OldBelongSectionNm_tEdit.Clear();
            this.OldBelongSubSecCd_tNedit.Clear();
            this.OldBelongSubSecNm_tEdit.Clear();
            this.OldBelongMinSecCd_tNedit.Clear();
            this.OldBelongMinSecNm_tEdit.Clear();
            this.SectionChgDate_tDateEdit.Clear();
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        }
        // 2007.08.14 �ǉ� <<<<<<<<<<

        /// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
            // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- >>>>> 
            // ���j���[�ȈՋN���I�v�V���������̏ꍇ
            if (!this._opMenuSimpleStart)
            {
                // ���Ӑ�d�q�����N���������ڂ͔�\��
                this.ultraLabel12.Visible = false;
                this.CustLedgerBootCnt_tNedit.Visible = false;
                // ����`�[���͋N���������ڂ͔�\��
                this.ultraLabel13.Visible = false;
                this.SalSlipInpBootCnt_tNedit.Visible = false;
            }
            // ----- ADD huangt 2013/05/24 Redmine#35765 ---------- <<<<<

			if (this.DataIndex < 0)
			{
				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

				// �{�^���ݒ�
				this.Ok_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				//_dataIndex�o�b�t�@�ێ�
				this._indexBuf = this._dataIndex;

				// ��ʓ��͋����䏈��
				ScreenInputPermissionControl(true);

                // --- ADD 2009/03/17 ��QID:11347�Ή�------------------------------------------------------>>>>>
                MainTabControl.Tabs[1].Visible = true;
                // --- ADD 2009/03/17 ��QID:11347�Ή�------------------------------------------------------<<<<<
                
                // ���_�I�v�V���������̏ꍇ
				if (!this._optSection)
				{
					// �������_�ݒ�𖳌��ɂ���
                    // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
                    //this.BelongSelectionCode_tComboEditor.SelectedIndex = 0;
                    //this.BelongSelectionCode_tComboEditor.Enabled = false;
                    this.tEdit_SectionCode.Clear();
                    this.tEdit_SectionName.Clear();
                    this.tEdit_SectionCode.Enabled = false;
                    this.SectionGuide_Button.Enabled = false;
                    // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
                }
				
				Employee employee = new Employee();
                EmployeeDtl employeeDtl = new EmployeeDtl();
                _employeeDtl = new EmployeeDtl();
                //�N���[���쐬
				this._employeeClone = employee.Clone(); 
				DispToEmployee(ref this._employeeClone);
                this._employeeDtlClone = employeeDtl.Clone();
                DispToEmployeeDtl(ref this._employeeDtlClone);

				// �]�ƈ��R�[�h���͉�
				this.tEdit_EmployeeCode.Enabled = true;

				// �t�H�[�J�X�ݒ�
				this.tEdit_EmployeeCode.Focus();

                // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
                //this.PostCode_tComboEditor.NullText     = "";
                //this.BusinessCode_tComboEditor.NullText = "";
                // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
			}
			else
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				Employee employee = (Employee)this._employeeTable[guid];
                EmployeeDtl employeeDtl = null; 
                if (employee != null)
                {
                    employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
				}

				if (employee.LogicalDeleteCode == 0)
				{
					// �X�V���[�h
					this.Mode_Label.Text = UPDATE_MODE;

					// �{�^���ݒ�
					this.Ok_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					// ��ʓ��͋����䏈��
					ScreenInputPermissionControl(true);

                    // --- ADD 2009/03/17 ��QID:11347�Ή�------------------------------------------------------>>>>>
                    switch (LoginInfoAcquisition.Employee.UserAdminFlag)
                    {
                        case 0:
                            {
                                MainTabControl.Tabs[0].Visible = true;
                                JobType_tComboEditor.Enabled = false;
                                EmploymentForm_tComboEditor.Enabled = false;
                                break;
                            }
                        case 1:
                            {
                                MainTabControl.Tabs[0].Visible = true;
                                if (employee.UserAdminFlag == 0)
                                {
                                    JobType_tComboEditor.Enabled = true;
                                    EmploymentForm_tComboEditor.Enabled = true;
                                }
                                else
                                {
                                    JobType_tComboEditor.Enabled = false;
                                    EmploymentForm_tComboEditor.Enabled = false;
                                }
                                break;
                            }
                        case 2:
                            {
                                MainTabControl.Tabs[0].Visible = false;
                                break;
                            }
                        default:
                            {
                                MainTabControl.Tabs[0].Visible = true;
                                JobType_tComboEditor.Enabled = true;
                                EmploymentForm_tComboEditor.Enabled = true;
                                break;
                            }
                    }
                    // --- ADD 2009/03/17 ��QID:11347�Ή�------------------------------------------------------<<<<<

					// ��ʓW�J����
					EmployeeToScreen(employee);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.15 TAKAHASHI ADD START
                    // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
                    //string wkString;
                    //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.PostCode, employee.PostCode);
                    //employee.PostName = wkString;
                                        
                    //// ��E�敪
                    //if (employee.PostName == "���o�^")
                    //{
                    //    this.PostCode_tComboEditor.SelectedIndex = 0;
                    //}
                    //else if (employee.PostName == "")
                    //{
                    //    this.PostCode_tComboEditor.NullText = "";
                    //}
                    //else
                    //{
                    //    this.PostCode_tComboEditor.NullText = "�폜��";
                    //}

                    //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.BusinessCode, employee.BusinessCode);
                    //employee.BusinessName = wkString;

                    //// �Ɩ��敪
                    //if (employee.BusinessName == "���o�^")
                    //{
                    //    this.BusinessCode_tComboEditor.SelectedIndex = 0;
                    //}
                    //else if (employee.BusinessName == "")
                    //{
                    //    this.BusinessCode_tComboEditor.NullText = "";
                    //}
                    //else
                    //{
                    //    this.BusinessCode_tComboEditor.NullText = "�폜��";
                    //}
                    // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.15 TAKAHASHI ADD END

					//�N���[���쐬
					this._employeeClone = employee.Clone(); 
					DispToEmployee(ref this._employeeClone);
                    if (employeeDtl != null)
                    {
                        this._employeeDtlClone = employeeDtl.Clone();
                        DispToEmployeeDtl(ref this._employeeDtlClone);
                    }
                    else
                    {
                        this._employeeDtlClone = new EmployeeDtl();
                        DispToEmployeeDtl(ref this._employeeDtlClone);
                    }
                    //_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;
                                                   
					// �X�V���[�h�̏ꍇ�́A�]�ƈ��R�[�h�̂ݓ��͕s�Ƃ���
					this.tEdit_EmployeeCode.Enabled = false;

					// ���_�I�v�V��������
					if (!this._optSection)
					{
                        // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
                        //this.BelongSelectionCode_tComboEditor.Enabled = false;
                        this.tEdit_SectionCode.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
                    }

                    // 2010/02/18 Add >>>
                    if (_optFeliCaAcs)
                    {
                        string idm = string.Empty;
                        if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                            idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                        FeliCaMngWork felicaMng;
                        _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                        if (felicaMng != null)
                        {
                            if (string.IsNullOrEmpty(felicaMng.FeliCaIDm))
                            {
                                this.FeliCaInfo_uLabel.Text = string.Empty;
                                this.FeliCaInfo_uLabel.Tag = null;
                            }
                            else
                            {
                                this.FeliCaInfo_uLabel.Text = "�o�^��";
                                this.FeliCaInfo_uLabel.Tag = felicaMng.FeliCaIDm;
                            }
                        }
                        else
                        {
                            this.FeliCaInfo_uLabel.Text = string.Empty;
                            this.FeliCaInfo_uLabel.Tag = null;
                        }
                    }
                    // 2010/02/18 Add <<<

					// �t�H�[�J�X�ݒ�
                    this.Name_tEdit.Focus();
					this.Name_tEdit.SelectAll();
				}
				else
				{
					// �폜���[�h
					this.Mode_Label.Text = DELETE_MODE;

					// �{�^���ݒ�
					this.Ok_Button.Visible = false;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;

					//_dataIndex�o�b�t�@�ێ�
					this._indexBuf = this._dataIndex;

					// ��ʓ��͋����䏈��
					ScreenInputPermissionControl(false);

                    // --- ADD 2009/03/17 ��QID:11347�Ή�------------------------------------------------------>>>>>
                    MainTabControl.Tabs[1].Visible = true;
                    // --- ADD 2009/03/17 ��QID:11347�Ή�------------------------------------------------------<<<<<

					// ��ʓW�J����
					EmployeeToScreen(employee);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.15 TAKAHASHI ADD START
                    // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
                    //string wkString;
                    //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.PostCode, employee.PostCode);
                    //employee.PostName = wkString;

                    //// ��E�敪
                    //if (employee.PostName == "���o�^")
                    //{
                    //    this.PostCode_tComboEditor.SelectedIndex = 0;
                    //}
                    //else if (employee.PostName == "")
                    //{
                    //    this.PostCode_tComboEditor.NullText = "";
                    //}
                    //else
                    //{
                    //    this.PostCode_tComboEditor.NullText = "�폜��";
                    //}

                    //this._userGuideAcs.GetGuideName(out wkString, this._enterpriseCode, (int)UserGdGuideDivCodeAcsData.BusinessCode, employee.BusinessCode);
                    //employee.BusinessName = wkString;

                    //// �Ɩ��敪
                    //if (employee.BusinessName == "���o�^")
                    //{
                    //    this.BusinessCode_tComboEditor.SelectedIndex = 0;
                    //}
                    //else if (employee.BusinessName == "")
                    //{
                    //    this.BusinessCode_tComboEditor.NullText = "";
                    //}
                    //else
                    //{
                    //    this.BusinessCode_tComboEditor.NullText = "�폜��";
                    //}

                    // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.15 TAKAHASHI ADD END

                    // 2010/02/18 Add >>>
                    if (_optFeliCaAcs)
                    {
                        string idm = string.Empty;
                        if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                            idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                        FeliCaMngWork felicaMng;
                        _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                        if (felicaMng != null)
                        {
                            if (string.IsNullOrEmpty(felicaMng.FeliCaIDm))
                            {
                                this.FeliCaInfo_uLabel.Text = string.Empty;
                                this.FeliCaInfo_uLabel.Tag = null;
                            }
                            else
                            {
                                this.FeliCaInfo_uLabel.Text = "�o�^��";
                                this.FeliCaInfo_uLabel.Tag = felicaMng.FeliCaIDm;
                            }
                        }
                        else
                        {
                            this.FeliCaInfo_uLabel.Text = string.Empty;
                            this.FeliCaInfo_uLabel.Tag = null;
                        }
                    }
                    // 2010/02/18 Add <<<

					// �t�H�[�J�X�ݒ�
					this.Delete_Button.Focus();
				}

			}
		}

		/// <summary>
		/// ��ʓ��͋����䏈��
		/// </summary>
		/// <param name="enabled">���͋��ݒ�l</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
            // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
            //// --- ���_�I�v�V�����ɉ������������_�R���{�{�b�N�X�̃Z�b�g --- //
            //this.BelongSelectionCode_tComboEditor.Items.Clear();						
			
            ////���_�I�v�V��������
            //if (!this._optSection)
            //{
            //    if (this.Mode_Label.Text == INSERT_MODE)
            //    {
            //        this.BelongSelectionCode_tComboEditor.Items.Add(this._secInfoAcs.SecInfoSet.SectionCode.TrimEnd(), this._secInfoAcs.SecInfoSet.SectionGuideNm);
            //    }
            //    else
            //    {
            //        foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            //        {
            //            this.BelongSelectionCode_tComboEditor.Items.Add(si.SectionCode.TrimEnd(), si.SectionGuideNm);
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
            //    {
            //        this.BelongSelectionCode_tComboEditor.Items.Add(si.SectionCode.TrimEnd(), si.SectionGuideNm);
            //    }
            //}

            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();

            //���_�I�v�V��������
            if (!this._optSection)
            {
                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    this.tEdit_SectionCode.DataText = this._secInfoAcs.SecInfoSet.SectionCode.TrimEnd();
                    this.tEdit_SectionName.DataText = this._secInfoAcs.SecInfoSet.SectionGuideNm.Trim();
                }
            }
            // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<

			// --- ���A���^�C���ɍX�V�����悤���A�����[�g���������Ȃ��悤Static����擾 --- //
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //// ��E�敪���Z�b�g
            //ArrayList retList = null;
            //this.PostCode_tComboEditor.Items.Clear();
            //int status = GetUserGdInfo(out retList, (int)UserGdGuideDivCodeAcsData.PostCode);
            //if (status == 0)
            //{
            //    // �󔒂��Z�b�g
            //    this.PostCode_tComboEditor.Items.Add(0, " ");
				
            //    foreach (UserGdBd userGdBd in retList)
            //    {
            //        if (userGdBd.LogicalDeleteCode == 0)
            //        {
            //            this.PostCode_tComboEditor.Items.Add(userGdBd.GuideCode, userGdBd.GuideName);
            //        }
            //    }
            //}

            //// �Ɩ��敪���Z�b�g
            //retList = null;
            //this.BusinessCode_tComboEditor.Items.Clear();
            //status = GetUserGdInfo(out retList, (int)UserGdGuideDivCodeAcsData.BusinessCode);
            //if (status == 0)
            //{
            //    // �󔒂��Z�b�g
            //    this.BusinessCode_tComboEditor.Items.Add(0, " ");

            //    foreach (UserGdBd userGdBd in retList)
            //    {
            //        if (userGdBd.LogicalDeleteCode == 0)
            //        {
            //            this.BusinessCode_tComboEditor.Items.Add(userGdBd.GuideCode, userGdBd.GuideName);	
            //        }
            //    }
            //}
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<

			this.tEdit_EmployeeCode.Enabled = enabled;
			this.Name_tEdit.Enabled = enabled;
			this.ShortName_tEdit.Enabled = enabled;
			this.Kana_tEdit.Enabled = enabled;
			this.Sex_tComboEditor.Enabled = enabled;
			this.Birthday_tDateEdit.Enabled = enabled;
			this.CompanyTelNo_tEdit.Enabled = enabled;
			this.PortableTelNo_tEdit.Enabled = enabled;
            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.MailAddress1_tEdit.Enabled = enabled;
            this.MailAddress2_tEdit.Enabled = enabled;
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            this.EnterCompanyDate_tDateEdit.Enabled = enabled;
			this.RetirementDate_tDateEdit.Enabled = enabled;
            //this.FrontMechaCode_tComboEditor.Enabled = enabled;
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //this.InOutsideCompanyCode_tComboEditor.Enabled = enabled;
            //this.PostCode_tComboEditor.Enabled = enabled;
            //this.BusinessCode_tComboEditor.Enabled = enabled;
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
            //this.LvrRtCstGeneral_tNedit.Enabled = enabled;
            //this.LvrRtCstCarInspect_tNedit.Enabled = enabled;
            //this.LvrRtCstBodyRepair_tNedit.Enabled = enabled;
            //this.LvrRtCstBodyPaint_tNedit.Enabled = enabled;
            // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
            //this.BelongSelectionCode_tComboEditor.Enabled = enabled;
            this.tEdit_SectionCode.Enabled = enabled;
            this.SectionGuide_Button.Enabled = enabled;
            // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<

            this.JobType_tComboEditor.Enabled = enabled;
            this.EmploymentForm_tComboEditor.Enabled = enabled;

			// -- Add St 2012.05.29 30182 R.Tachiya --
			this.SalSlipInpBootCnt_tNedit.Enabled = enabled;
			this.CustLedgerBootCnt_tNedit.Enabled = enabled;
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

			this.LoginId_tEdit.Enabled = enabled;
			this.LoginPassword_tEdit.Enabled = enabled;
			this.LoginPasswordAgain_tEdit.Enabled = enabled;

            // 2007.08.14 �ǉ� >>>>>>>>>>
            this.tNedit_SubSectionCode.Enabled = enabled;
            //this.BelongMinSectionCode_tNedit.Enabled = enabled;  // DEL 2008/06/04
            this.EmployAnalysCode1_tNedit.Enabled = enabled;
            this.EmployAnalysCode2_tNedit.Enabled = enabled;
            this.EmployAnalysCode3_tNedit.Enabled = enabled;
            this.EmployAnalysCode4_tNedit.Enabled = enabled;
            this.EmployAnalysCode5_tNedit.Enabled = enabled;
            this.EmployAnalysCode6_tNedit.Enabled = enabled;
            this.UOESnmDiv_tEdit.Enabled = enabled;     //2008.11.10 add
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.OldBelongSectionCd_tEdit.Enabled = enabled;
            this.OldBelongSubSecCd_tNedit.Enabled = enabled;
            this.OldBelongMinSecCd_tNedit.Enabled = enabled;
            this.SectionChgDate_tDateEdit.Enabled = enabled;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            this.BelongSubSectionGuide_ultraButton.Enabled = enabled;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.BelongMinSectionGuide_ultraButton.Enabled = enabled;
            this.OldBelongSectionGd_ultraButton.Enabled = enabled;
            this.OldBelongSubSecGd_ultraButton.Enabled = enabled;
            this.OldBelongMinSecGd_ultraButton.Enabled = enabled;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // 2007.08.14 �ǉ� <<<<<<<<<<

            // 2010/02/18 Add >>>
            this.FeliCaMngGuide_uButton.Enabled = enabled;
            this.FeliCaMngDelete_uButton.Enabled = enabled;
            // 2010/02/18 Add <<<
		}

		/// <summary>
		/// �]�ƈ��N���X��ʓW�J����
		/// </summary>
		/// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �]�ƈ��I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private void EmployeeToScreen(Employee employee)
		{
			this.Guid_Label.Text = employee.FileHeaderGuid.ToString();
			this.tEdit_EmployeeCode.Text = employee.EmployeeCode;
			this.Name_tEdit.Text = employee.Name;
			this.ShortName_tEdit.Text = employee.ShortName;
			this.Kana_tEdit.Text = employee.Kana;
			this.Sex_tComboEditor.Value = employee.SexCode;
            //this.PostCode_tComboEditor.Value = employee.PostCode;           // DEL 2008/11/04 �s��Ή�[7289]
            //this.FrontMechaCode_tComboEditor.Value = employee.FrontMechaCode;
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //this.InOutsideCompanyCode_tComboEditor.Value = employee.InOutsideCompanyCode;
            //this.BusinessCode_tComboEditor.Value = employee.BusinessCode;
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
            //this.LvrRtCstGeneral_tNedit.SetValue(employee.LvrRtCstGeneral);
            //this.LvrRtCstCarInspect_tNedit.SetValue(employee.LvrRtCstCarInspect);
            //this.LvrRtCstBodyRepair_tNedit.SetValue(employee.LvrRtCstBodyRepair);
            //this.LvrRtCstBodyPaint_tNedit.SetValue(employee.LvrRtCstBodyPaint);
            // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
            //this.BelongSelectionCode_tComboEditor.Value = employee.BelongSectionCode.TrimEnd();
            this.tEdit_SectionCode.DataText = employee.BelongSectionCode.Trim();
            this.tEdit_SectionName.DataText = GetSectionName(employee.BelongSectionCode.Trim());
            // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
            this.CompanyTelNo_tEdit.Text = employee.CompanyTelNo;
			this.PortableTelNo_tEdit.Text = employee.PortableTelNo;

			if (employee.Birthday != DateTime.MinValue)
			{
				this.Birthday_tDateEdit.SetDateTime(employee.Birthday);
			}
			else
			{
				this.Birthday_tDateEdit.Clear();
			}
			if (employee.EnterCompanyDate != DateTime.MinValue)
			{
				this.EnterCompanyDate_tDateEdit.SetDateTime(employee.EnterCompanyDate);
			}
			else
			{
				this.EnterCompanyDate_tDateEdit.Clear();
			}
			if (employee.RetirementDate != DateTime.MinValue)
			{
				this.RetirementDate_tDateEdit.SetDateTime(employee.RetirementDate);
			}
			else
			{
				RetirementDate_tDateEdit.Clear();
			}

			this.LoginId_tEdit.Text = employee.LoginId;
			this.LoginPassword_tEdit.Text = employee.LoginPassword;
			this.LoginPasswordAgain_tEdit.Text = employee.LoginPassword;
			this.UserAdminName_uLabel.Text = employee.UserAdminName;

            this.JobType_tComboEditor.Value = employee.AuthorityLevel1;
            this.EmploymentForm_tComboEditor.Value = employee.AuthorityLevel2;

			// -- Add St 2012.05.29 30182 R.Tachiya --
			this.SalSlipInpBootCnt_tNedit.SetInt(employee.SalSlipInpBootCnt);
			this.CustLedgerBootCnt_tNedit.SetInt(employee.CustLedgerBootCnt);
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

            // 2007.08.14 �ǉ� >>>>>>>>>>
            EmployeeDtl employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
            if (employeeDtl != null)
            {
                this.tNedit_SubSectionCode.SetInt(employeeDtl.BelongSubSectionCode);
                this.BelongSubSectionName_tEdit.Text = GetSubSectionName(employeeDtl.BelongSubSectionCode);
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this.BelongMinSectionCode_tNedit.SetInt(employeeDtl.BelongMinSectionCode);
                this.BelongMinSectionName_tEdit.Text = employeeDtl.BelongMinSectionName;
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                this.EmployAnalysCode1_tNedit.SetInt(employeeDtl.EmployAnalysCode1);
                this.EmployAnalysCode2_tNedit.SetInt(employeeDtl.EmployAnalysCode2);
                this.EmployAnalysCode3_tNedit.SetInt(employeeDtl.EmployAnalysCode3);
                this.EmployAnalysCode4_tNedit.SetInt(employeeDtl.EmployAnalysCode4);
                this.EmployAnalysCode5_tNedit.SetInt(employeeDtl.EmployAnalysCode5);
                this.EmployAnalysCode6_tNedit.SetInt(employeeDtl.EmployAnalysCode6);

                this.UOESnmDiv_tEdit.Text = employeeDtl.UOESnmDiv;   //2008.11.10 add
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                this.OldBelongSectionCd_tEdit.DataText = employeeDtl.OldBelongSectionCd;
                this.OldBelongSectionNm_tEdit.DataText = employeeDtl.OldBelongSectionNm;
                this.OldBelongSubSecCd_tNedit.SetInt(employeeDtl.OldBelongSubSecCd);
                this.OldBelongSubSecNm_tEdit.DataText  = employeeDtl.OldBelongSubSecNm;
                this.OldBelongMinSecCd_tNedit.SetInt(employeeDtl.OldBelongMinSecCd);
                this.OldBelongMinSecNm_tEdit.DataText  = employeeDtl.OldBelongMinSecNm;

                if (DateTime.Parse(employeeDtl.SectionChgDate.ToString()) != DateTime.MinValue)
                {
                    this.SectionChgDate_tDateEdit.SetDateTime(DateTime.Parse(employeeDtl.SectionChgDate.ToString()));
                }
                else
                {
                    this.SectionChgDate_tDateEdit.Clear();
                }
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

                _employeeDtl = employeeDtl;
            }
            else
            {
                ScreenClearSub();
                _employeeDtl = new EmployeeDtl();
            }
            // 2007.08.14 �ǉ� <<<<<<<<<<

            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            this.MailAddress1_tEdit.Text = _employeeDtl.MailAddress1;
            this.MailAddress2_tEdit.Text = _employeeDtl.MailAddress2;
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        // 2007.08.14 �ǉ� >>>>>>>>>>
        /// <summary>
		/// �]�ƈ��ڍ׃N���X��ʓW�J����
		/// </summary>
        /// <param name="employeeCode">�]�ƈ��ڍ׃I�u�W�F�N�g</param>
		/// <remarks>
        /// <br>Note       : �]�ƈ��ڍ׃I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
		/// <br>Programmer : 980035 ����  ��`</br>
		/// <br>Date       : 2007.08.14</br>
		/// </remarks>
        private EmployeeDtl EmployeeDtlToScreen(String employeeCode)
        {
            if (_employeeDtlData.Count > 0)
            {
                foreach (EmployeeDtl employeeDtl in _employeeDtlData)
                {
                    if (employeeDtl.EmployeeCode.Trim() == employeeCode.Trim())
                    {
                        return employeeDtl;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// �]�ƈ��ڍ׃N���X��ʓW�J����
        /// </summary>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̃f�[�^���]�ƈ��ڍ׃I�u�W�F�N�g�ɓW�J���܂��B</br>
        /// <br>Programmer : 980035 ����  ��`</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void ScreenToEmployeeDtl(EmployeeDtl employeeDtl)
        {
            if (_employeeDtlData.Count > 0)
            {
                ArrayList wkList = new ArrayList();
                wkList = _employeeDtlData;
                EmployeeDtl _wkEmployeeDtl;

                for (int i = 0; i < _employeeDtlData.Count; i++)
                {
                    _wkEmployeeDtl = wkList[i] as EmployeeDtl;
                    if (_wkEmployeeDtl.EmployeeCode.Trim() == employeeDtl.EmployeeCode.Trim())
                    {
                        wkList[i] = employeeDtl;
                        _employeeDtlData = wkList;
                        return;
                    }
                }
            }

            _employeeDtlData.Add(employeeDtl);
        }

        /// <summary>
        /// �]�ƈ��ڍ׃N���X��ʓW�J����
        /// </summary>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̃f�[�^���]�ƈ��ڍ׃I�u�W�F�N�g����폜���܂��B</br>
        /// <br>Programmer : 980035 ����  ��`</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void EmployeeDtlDelete(EmployeeDtl employeeDtl)
        {
            if (_employeeDtlData.Count > 0)
            {
                ArrayList wkList = new ArrayList();
                wkList = _employeeDtlData;
                EmployeeDtl _wkEmployeeDtl;

                for (int i = 0; i < _employeeDtlData.Count; i++)
                {
                    _wkEmployeeDtl = wkList[i] as EmployeeDtl;
                    if (_wkEmployeeDtl.EmployeeCode.Trim() == employeeDtl.EmployeeCode.Trim())
                    {
                        wkList.RemoveAt(i);
                        _employeeDtlData = wkList;
                        return;
                    }
                }
            }
        }
        // 2007.08.14 �ǉ� <<<<<<<<<<

		/// <summary>
		/// Value�`�F�b�N�����iint�j
		/// </summary>
		/// <param name="sorce">tCombo��Value</param>
		/// <returns>�`�F�b�N��̒l</returns>
		/// <remarks>
		/// <br>Note		: tCombo�̒l��Class�ɓ���鎞��NULL�`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: 22033 �O��  �M�j</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private int ValueToInt(object sorce)
		{
			int dest = 0;
			try
			{
				dest = Convert.ToInt32(sorce);
			}
			catch
			{
				return dest;
			}
			return dest;
		}

		/// <summary>
		/// ��ʏ��]�ƈ��N���X�i�[����
		/// </summary>
		/// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ��ʏ�񂩂�]�ƈ��I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
 		private void DispToEmployee(ref Employee employee)
		{
			if (employee == null)
			{
				// �V�K�̏ꍇ
				employee = new Employee();
			}

			employee.EnterpriseCode			= this._enterpriseCode;
			employee.EmployeeCode			= this.tEdit_EmployeeCode.Text;
			employee.Name					= this.Name_tEdit.Text;
			employee.Kana					= this.Kana_tEdit.Text;
			employee.ShortName				= this.ShortName_tEdit.Text;
			employee.SexCode				= ValueToInt(this.Sex_tComboEditor.Value);
			employee.SexName				= this.Sex_tComboEditor.SelectedItem.ToString();
			employee.Birthday				= this.Birthday_tDateEdit.GetDateTime();
			employee.CompanyTelNo			= this.CompanyTelNo_tEdit.Text;
			employee.PortableTelNo			= this.PortableTelNo_tEdit.Text;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.15 TAKAHASHI DELETE START
//			employee.PostCode				= ValueToInt(this.PostCode_tComboEditor.Value);
//			employee.BusinessCode			= ValueToInt(this.BusinessCode_tComboEditor.Value);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.15 TAKAHASHI DELETE END

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.15 TAKAHASHI ADD START
            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            //if (this.PostCode_tComboEditor.SelectedItem != null)
            //{
            //    employee.PostCode = ValueToInt(this.PostCode_tComboEditor.Value);
            //}

            //if (this.BusinessCode_tComboEditor.SelectedItem != null)
            //{
            //    employee.BusinessCode = ValueToInt(this.BusinessCode_tComboEditor.Value);
            //}
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.15 TAKAHASHI ADD END
            employee.PostCode = 0;      // ADD 2008/11/04 �s��Ή�[7289] ���ڍ폜�ɂ�菉���l��ݒ�
            employee.BusinessCode = 0;  // ADD 2008/11/04 �s��Ή�[7289] ���ڍ폜�ɂ�菉���l��ݒ�

            //employee.FrontMechaCode			= ValueToInt(this.FrontMechaCode_tComboEditor.Value);
            //employee.InOutsideCompanyCode = ValueToInt(this.InOutsideCompanyCode_tComboEditor.Value);     // DEL 2008/11/04 �s��Ή�[7289]
            employee.InOutsideCompanyCode = 0;  // ADD 2008/11/04 �s��Ή�[7289] ���ڍ폜�ɂ�菉���l��ݒ�
            // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
            //if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
            //    employee.BelongSectionCode		= this.BelongSelectionCode_tComboEditor.Value.ToString();
            employee.BelongSectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            employee.BelongSectionName = GetSectionName(employee.BelongSectionCode);
            // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
            employee.CompanyTelNo = this.CompanyTelNo_tEdit.Text;
			employee.PortableTelNo			= this.PortableTelNo_tEdit.Text;
            //employee.LvrRtCstGeneral		= this.LvrRtCstGeneral_tNedit.GetInt();
            //employee.LvrRtCstCarInspect		= this.LvrRtCstCarInspect_tNedit.GetInt();
            //employee.LvrRtCstBodyRepair		= this.LvrRtCstBodyRepair_tNedit.GetInt();
            //employee.LvrRtCstBodyPaint		= this.LvrRtCstBodyPaint_tNedit.GetInt();
			employee.LoginId				= this.LoginId_tEdit.Text;
			employee.LoginPassword			= this.LoginPassword_tEdit.Text;
			employee.EnterCompanyDate		= this.EnterCompanyDate_tDateEdit.GetDateTime();
			employee.RetirementDate			= this.RetirementDate_tDateEdit.GetDateTime();

            if (this.JobType_tComboEditor.SelectedItem != null)
            {
                employee.AuthorityLevel1 = ValueToInt(this.JobType_tComboEditor.Value);
            }

            if (this.EmploymentForm_tComboEditor.SelectedItem != null)
            {
                employee.AuthorityLevel2 = ValueToInt(this.EmploymentForm_tComboEditor.Value);
            }

			// -- Add St 2012.05.29 30182 R.Tachiya --
			employee.SalSlipInpBootCnt = ValueToInt(this.SalSlipInpBootCnt_tNedit.Value);
			employee.CustLedgerBootCnt = ValueToInt(this.CustLedgerBootCnt_tNedit.Value);
			// -- Add Ed 2012.05.29 30182 R.Tachiya --
		}

        // 2007.08.14 �ǉ� >>>>>>>>>>
        /// <summary>
        /// ��ʏ��]�ƈ��ڍ׃N���X�i�[����
        /// </summary>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�]�ƈ��ڍ׃I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 980035 ����  ��`</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void DispToEmployeeDtl(ref EmployeeDtl employeeDtl)
        {
            if (employeeDtl == null)
            {
                // �V�K�̏ꍇ
                employeeDtl = new EmployeeDtl();
            }

            if (_employeeDtl != null)
            {
                employeeDtl.CreateDateTime    = _employeeDtl.CreateDateTime;
                employeeDtl.UpdateDateTime    = _employeeDtl.UpdateDateTime;
                employeeDtl.EnterpriseCode    = _employeeDtl.EnterpriseCode;
                employeeDtl.FileHeaderGuid    = _employeeDtl.FileHeaderGuid;
                employeeDtl.UpdEmployeeCode   = _employeeDtl.UpdEmployeeCode;
                employeeDtl.UpdAssemblyId1    = _employeeDtl.UpdAssemblyId1;
                employeeDtl.UpdAssemblyId2    = _employeeDtl.UpdAssemblyId2;
                employeeDtl.LogicalDeleteCode = _employeeDtl.LogicalDeleteCode;
            }

            employeeDtl.EnterpriseCode = this._enterpriseCode;
            employeeDtl.EmployeeCode = this.tEdit_EmployeeCode.Text;

            employeeDtl.BelongSubSectionCode = this.tNedit_SubSectionCode.GetInt();
            employeeDtl.BelongSubSectionName = this.BelongSubSectionName_tEdit.Text;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            employeeDtl.BelongMinSectionCode = this.BelongMinSectionCode_tNedit.GetInt();
            employeeDtl.BelongMinSectionName = this.BelongMinSectionName_tEdit.Text;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            employeeDtl.EmployAnalysCode1 = this.EmployAnalysCode1_tNedit.GetInt();
            employeeDtl.EmployAnalysCode2 = this.EmployAnalysCode2_tNedit.GetInt();
            employeeDtl.EmployAnalysCode3 = this.EmployAnalysCode3_tNedit.GetInt();
            employeeDtl.EmployAnalysCode4 = this.EmployAnalysCode4_tNedit.GetInt();
            employeeDtl.EmployAnalysCode5 = this.EmployAnalysCode5_tNedit.GetInt();
            employeeDtl.EmployAnalysCode6 = this.EmployAnalysCode6_tNedit.GetInt();

            employeeDtl.UOESnmDiv = this.UOESnmDiv_tEdit.Text;   //2008.11.10 add
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            employeeDtl.OldBelongSectionCd = this.OldBelongSectionCd_tEdit.DataText;
            employeeDtl.OldBelongSectionNm = this.OldBelongSectionNm_tEdit.DataText;
            employeeDtl.OldBelongSubSecCd  = this.OldBelongSubSecCd_tNedit.GetInt();
            employeeDtl.OldBelongSubSecNm  = this.OldBelongSubSecNm_tEdit.DataText;
            employeeDtl.OldBelongMinSecCd  = this.OldBelongMinSecCd_tNedit.GetInt();
            employeeDtl.OldBelongMinSecNm  = this.OldBelongMinSecNm_tEdit.DataText;

            employeeDtl.SectionChgDate = this.SectionChgDate_tDateEdit.GetDateTime().Date;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            employeeDtl.MailAddress1 = this.MailAddress1_tEdit.Text.Trim();
            employeeDtl.MailAddress2 = this.MailAddress2_tEdit.Text.Trim();
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        }
        // 2007.08.14 �ǉ� <<<<<<<<<<

        // 2010/02/18 Add >>>
        /// <summary>
        /// ��ʏ��FeliCa�Ǘ��N���X�i�[����
        /// </summary>
        /// <param name="feliCaMng">�t�F���J�Ǘ��I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�t�F���J�Ǘ��I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private void DispToFeliCaMng(ref FeliCaMngWork feliCaMng)
        {
            if (feliCaMng == null)
            {
                // �V�K�̏ꍇ
                feliCaMng = new FeliCaMngWork();
            }

            feliCaMng.EnterpriseCode = this._enterpriseCode;
            feliCaMng.FeliCaMngKind = 1;
            if (this.FeliCaInfo_uLabel.Tag != null)
                feliCaMng.FeliCaIDm = (string)this.FeliCaInfo_uLabel.Tag;
            else
                feliCaMng.FeliCaIDm = string.Empty;
            //feliCaMng.EmployeeCode = this.EmployeeCode_tEdit.Text;
            feliCaMng.EmployeeCode = this.tEdit_EmployeeCode.Text;
        }
        // 2010/02/18 Add <<<

        #region DEL 2008/06/04 Partsman�p�ɕύX
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// ��ʓ��͏��s���`�F�b�N����
		/// </summary>
		/// <param name="control">�s���ΏۃR���g���[��</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="selectedTab">�R���e�i�̂s����</param>
		/// <param name="loginID">���O�C��ID</param>
		/// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
 		private bool ScreenDataCheck(ref Control control, ref string message, ref Infragistics.Win.UltraWinTabControl.UltraTab selectedTab, string loginID)
		{
			bool result = true;

			// --- ���O�C��ID�̏d���`�F�b�N --- //

			// ���O�C��ID������Row
			string filter = LOGINID_TITLE + " = '" + this.LoginId_tEdit.Text + "'";
			DataRow[] rows = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Select(filter);

			if (this.tEdit_EmployeeCode.Text.Trim() == "")
			{
				// �]�ƈ��R�[�h
				control = this.tEdit_EmployeeCode;
				message = this.EmployeeCode_Title_Label.Text + "����͂��ĉ������B";
				selectedTab = this.
         * .Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.Name_tEdit.Text.Trim() == "")
			{
				// �]�ƈ�����
				control = this.Name_tEdit;
				message = this.Name_Title_Label.Text + "����͂��ĉ������B";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.Kana_tEdit.Text.Trim() == "")
			{
				// �J�i
				control = this.Kana_tEdit;
				message = this.Kana_Title_Label.Text + "����͂��ĉ������B";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.LoginId_tEdit.Text.Trim() == "")
			{
				// ���O�C���h�c
				control = this.LoginId_tEdit;
				message = this.LoginId_Title_Label.Text + "����͂��ĉ������B";
				selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
				result = false;
			}
			else if (this.LoginPassword_tEdit.Text.Trim() == "")
			{
				// ���O�C���p�X���[�h
				control = this.LoginPassword_tEdit;
				message = this.LoginPassword_Title_Label.Text + "����͂��ĉ������B";
				selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
				result = false;
			}
			else if (this.LoginPasswordAgain_tEdit.Text.Trim() == "")
			{
				// �m�F�p���O�C���p�X���[�h
				control = this.LoginPasswordAgain_tEdit;
				message = this.LoginPasswordAgain_Title_Label.Text + "����͂��ĉ������B";
				selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
				result = false;
			}
			else if (this.LoginPassword_tEdit.Text.Trim() != this.LoginPasswordAgain_tEdit.Text.Trim())
			{
				// �p�X���[�h�Ⴂ
				control = this.LoginPasswordAgain_tEdit;
				message = "�p�X���[�h���Ⴂ�܂��B";
				selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
				result = false;
			}
			else if (this.Birthday_tDateEdit.CheckInputData() != null)
			{
				// ���N����
				control = this.Birthday_tDateEdit;
				message = "���͂��ꂽ���t���s���ł��B";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.EnterCompanyDate_tDateEdit.CheckInputData() != null)
			{
				// ���Г�
				control = this.EnterCompanyDate_tDateEdit;
				message = "���͂��ꂽ���t���s���ł��B";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
			else if (this.RetirementDate_tDateEdit.CheckInputData() != null)
			{
				// �ގГ�
				control = this.RetirementDate_tDateEdit;
				message = "���͂��ꂽ���t���s���ł��B";
				selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
				result = false;
			}
            else if (this.BelongSelectionCode_tComboEditor.Value == null)
            {
                // �������_
                control = this.BelongSelectionCode_tComboEditor;
                message = this.BelongSelectionCode_Title_Label.Text + "��ݒ肵�ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                result = false;
            }
            else if (this.JobType_tComboEditor.Value == null)
            {
                // �E��
                control = this.JobType_tComboEditor;
                message = this.JobType_ultraLabel.Text + "��ݒ肵�ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                result = false;
            }
            else if (this.EmploymentForm_tComboEditor.Value == null)
            {
                // �ٗp�`��
                control = this.EmploymentForm_tComboEditor;
                message = this.EmploymentForm_ultraLabel.Text + "��ݒ肵�ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                result = false;
            }
            else if (this.tNedit_SubSectionCode.DataText.Trim() != "")
            {
                // ����R�[�h
                if (GetSubSectionName(this.tNedit_SubSectionCode.GetInt()) == "")
                {
                    this.BelongSubSectionName_tEdit.Clear();
                    control = this.tNedit_SubSectionCode;
                    message = "�}�X�^�ɓo�^����Ă��܂���B";
                    selectedTab = this.MainTabControl.Tabs[TAB3_NAME];
                    result = false;
                }
            }
            else if ((rows.Length != 0) &&
                (this.Mode_Label.Text == INSERT_MODE))
            {
                // ���O�C���h�c�d���i�V�K���j
                control = this.LoginId_tEdit;
                message = "����" + this.LoginId_Title_Label.Text + "�͊��ɓo�^����Ă��܂��B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                result = false;
            }
            else if ((rows.Length != 0) &&
                (this.Mode_Label.Text == UPDATE_MODE) &&
                (this.LoginId_tEdit.Text != loginID))
            {
                // ���O�C���h�c�d���i�X�V���j
                control = this.LoginId_tEdit;
                message = "����" + this.LoginId_Title_Label.Text + "�͊��ɓo�^����Ă��܂��B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                result = false;
            }

			return result;
		}
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/04 Partsman�p�ɕύX

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="selectedTab">�R���e�i�̂s����</param>
        /// <param name="loginID">���O�C��ID</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        // 2010/02/18 >>>
        //private bool ScreenDataCheck(ref Control control, ref string message, ref UltraTab selectedTab, string loginID)
        private bool ScreenDataCheck(ref Control control, ref string message, ref UltraTab selectedTab, string loginID, string feliCaIdm)
        // 2010/02/18 <<<
        {
            // --- ���O�C��ID�̏d���`�F�b�N --- //

            // ���O�C��ID������Row
            string filter = LOGINID_TITLE + " = '" + this.LoginId_tEdit.Text + "'";
            DataRow[] rows = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Select(filter);

            // 2010/02/18 Add >>>
            DataRow[] rows2 = null;
            if (_optFeliCaAcs)
            {
                if (!string.IsNullOrEmpty(feliCaIdm))
                {
                    string filter2 = FELICAIDM_TITLE + " = '" + feliCaIdm + "'";
                    rows2 = this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Select(filter2);
                }
            }
            // 2010/02/18 Add <<<

            if (this.tEdit_EmployeeCode.Text.Trim() == "")
            {
                // �]�ƈ��R�[�h
                control = this.tEdit_EmployeeCode;
                message = this.EmployeeCode_Title_Label.Text + "����͂��ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.Name_tEdit.Text.Trim() == "")
            {
                // �]�ƈ�����
                control = this.Name_tEdit;
                message = this.Name_Title_Label.Text + "����͂��ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.Kana_tEdit.Text.Trim() == "")
            {
                // �J�i
                control = this.Kana_tEdit;
                message = this.Kana_Title_Label.Text + "����͂��ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            // ADD 2008/10/10 �s��Ή�[6442] ---------->>>>>
            if (DateEditNoInputCheck(this.Birthday_tDateEdit))
            {
                // ���N����
                control = this.Birthday_tDateEdit;
                message = "���͂��ꂽ���t���s���ł��B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (DateEditNoInputCheck(this.EnterCompanyDate_tDateEdit))
            {
                // ���Г�
                control = this.EnterCompanyDate_tDateEdit;
                message = "���͂��ꂽ���t���s���ł��B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (DateEditNoInputCheck(this.RetirementDate_tDateEdit))
            {
                // �ގГ�
                control = this.RetirementDate_tDateEdit;
                message = "���͂��ꂽ���t���s���ł��B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            // ADD 2008/10/10 �s��Ή�[6442] ----------<<<<<
            if (this.Birthday_tDateEdit.CheckInputData() != null)
            {
                // ���N����
                control = this.Birthday_tDateEdit;
                message = "���͂��ꂽ���t���s���ł��B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.EnterCompanyDate_tDateEdit.CheckInputData() != null)
            {
                // ���Г�
                control = this.EnterCompanyDate_tDateEdit;
                message = "���͂��ꂽ���t���s���ł��B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.RetirementDate_tDateEdit.CheckInputData() != null)
            {
                // �ގГ�
                control = this.RetirementDate_tDateEdit;
                message = "���͂��ꂽ���t���s���ł��B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.JobType_tComboEditor.Value == null)
            {
                // �E��
                control = this.JobType_tComboEditor;
                message = this.JobType_ultraLabel.Text + "��ݒ肵�ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.EmploymentForm_tComboEditor.Value == null)
            {
                // �ٗp�`��
                control = this.EmploymentForm_tComboEditor;
                message = this.EmploymentForm_ultraLabel.Text + "��ݒ肵�ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.tEdit_SectionCode.DataText.Trim() == "")
            {
                // �������_
                control = this.tEdit_SectionCode;
                message = this.BelongSelectionCode_Title_Label.Text + "��ݒ肵�ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            if (this.tEdit_SectionCode.DataText.Trim() != "")
            {
                if (GetSectionName(this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0')) == "")
                {
                    this.tEdit_SectionName.Clear();
                    control = this.tEdit_SectionCode;
                    message = "�}�X�^�ɓo�^����Ă��܂���B";
                    selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                    return (false);
                }
            }

            // ----- ADD huangt 2013/05/21 Redmine#35765 ---------- >>>>> 
            // ����`�[���͋N����������
            if (this.SalSlipInpBootCnt_tNedit.GetInt() > 5)
            {
                control = this.SalSlipInpBootCnt_tNedit;
                message = "����`�[���͋N�������͂T���ȉ���ݒ肵�ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            // ���Ӑ�d�q�����N����������
            if (this.CustLedgerBootCnt_tNedit.GetInt() > 5)
            {
                control = this.CustLedgerBootCnt_tNedit;
                message = "���Ӑ�d�q�����N�������͂T���ȉ���ݒ肵�ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB1_NAME];
                return (false);
            }
            // ----- ADD huangt 2013/05/21 Redmine#35765 ---------- <<<<<

            if (this.tNedit_SubSectionCode.DataText.Trim() != "")
            {
                // ����R�[�h
                if (GetSubSectionName(this.tNedit_SubSectionCode.GetInt()) == "")
                {
                    this.BelongSubSectionName_tEdit.Clear();
                    control = this.tNedit_SubSectionCode;
                    message = "�}�X�^�ɓo�^����Ă��܂���B";
                    //selectedTab = this.MainTabControl.Tabs[TAB3_NAME];
                    return (false);
                }
            }
            if (this.LoginId_tEdit.Text.Trim() == "")
            {
                // ���O�C���h�c
                control = this.LoginId_tEdit;
                message = this.LoginId_Title_Label.Text + "����͂��ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if (this.LoginPassword_tEdit.Text.Trim() == "")
            {
                // ���O�C���p�X���[�h
                control = this.LoginPassword_tEdit;
                message = this.LoginPassword_Title_Label.Text + "����͂��ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }

            //2008.11.12 add ���O�C���p�X���[�h�����`�F�b�N������ǉ� ----------------------------->>
            if (this.LoginPassword_tEdit.Text.Trim().Length < 4)
            {
                // ���O�C���p�X���[�h
                control = this.LoginPassword_tEdit;
                message = this.LoginPassword_Title_Label.Text + "�͂S���ȏ�̒l����͂��ĉ�����";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            //2008.11.12 add -------------------------------------------------------------------<<
            
            if (this.LoginPasswordAgain_tEdit.Text.Trim() == "")
            {
                // �m�F�p���O�C���p�X���[�h
                control = this.LoginPasswordAgain_tEdit;
                message = this.LoginPasswordAgain_Title_Label.Text + "����͂��ĉ������B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if (this.LoginPassword_tEdit.Text.Trim() != this.LoginPasswordAgain_tEdit.Text.Trim())
            {
                // �p�X���[�h�Ⴂ
                control = this.LoginPasswordAgain_tEdit;
                message = "�p�X���[�h���Ⴂ�܂��B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if ((rows.Length != 0) &&
                (this.Mode_Label.Text == INSERT_MODE))
            {
                // ���O�C���h�c�d���i�V�K���j
                control = this.LoginId_tEdit;
                message = "����" + this.LoginId_Title_Label.Text + "�͊��ɓo�^����Ă��܂��B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if ((rows.Length != 0) &&
                (this.Mode_Label.Text == UPDATE_MODE) &&
                (this.LoginId_tEdit.Text != loginID))
            {
                // ���O�C���h�c�d���i�X�V���j
                control = this.LoginId_tEdit;
                message = "����" + this.LoginId_Title_Label.Text + "�͊��ɓo�^����Ă��܂��B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }

            // 2010/02/18 Add >>>
            if ((_optFeliCaAcs) && (rows2 != null) && (rows2.Length != 0) && (this.Mode_Label.Text == INSERT_MODE))
            {
                // felicaidm�d���i�V�K���j
                control = this.FeliCaMngGuide_uButton;
                message = "����" + this.FeliCaInfo_Title_uLabel.Text + "�́u�R�[�h�F" + ((string)rows2[0][CODE_TITLE]).TrimEnd() + "�v�u���́F" + ((string)rows2[0][NAME_TITLE]).TrimEnd() + "�v�̃f�[�^�Ŋ��ɓo�^����Ă��܂��B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            if ((_optFeliCaAcs) && (rows2 != null) && (rows2.Length != 0) && (this.Mode_Label.Text == UPDATE_MODE) && (this.tEdit_EmployeeCode.Text != (string)rows2[0][CODE_TITLE]))
            {
                // felicaidm�d���i�X�V���j
                control = this.FeliCaMngGuide_uButton;
                message = "����" + this.FeliCaInfo_Title_uLabel.Text + "�́u�R�[�h�F" + ((string)rows2[0][CODE_TITLE]).TrimEnd() + "�v�u���́F" + ((string)rows2[0][NAME_TITLE]).TrimEnd() + "�v�̃f�[�^�Ŋ��ɓo�^����Ă��܂��B";
                selectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                return (false);
            }
            // 2010/02/18 Add <<<

            return (true);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
        ///// <summary>
        ///// ���[�U�[�K�C�h�I�u�W�F�N�g�擾����
        ///// </summary>
        ///// <param name="retList">���[�U�[�K�C�h�I�u�W�F�N�gLIST</param>
        ///// <param name="guideDivCode">�K�C�h�敪�R�[�h</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : ���[�U�[�K�C�h����w��K�C�h�敪�̃I�u�W�F�N�g���擾���܂��B</br>
        ///// <br>Programmer : 22033 �O��  �M�j</br>
        ///// <br>Date       : 2005.09.20</br>
        ///// </remarks>
        //private int GetUserGdInfo(out ArrayList retList, int guideDivCode)
        //{
        //    retList = new ArrayList();
        //    ArrayList userGdBdList = new ArrayList();
        //    int status = 0;
        //    status = this._userGuideAcs.SearchGuideBufStaticMemory(out userGdBdList, this._enterpriseCode, guideDivCode);
        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                foreach (UserGdBd userGdBd in userGdBdList)
        //                {
        //                    if (userGdBd.UserGuideDivCd == guideDivCode)
        //                    {
        //                        retList.Add(userGdBd);
        //                    }
        //                }

        //                break;
        //            }
        //        case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //            {
        //                break;
        //            }
        //        // ---DEL 2008/10/06 �s��Ή�[6265] ------------------------------------------->>>>>
            
        //        //    default:
        //        //    {
        //        //        TMsgDisp.Show( 
        //        //            this,								  // �e�E�B���h�E�t�H�[��
        //        //            emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
        //        //            ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
        //        //            this.Text,							  // �v���O��������
        //        //            "GetUserGdInfo",					  // ��������
        //        //            TMsgDisp.OPE_GET,					  // �I�y���[�V����
        //        //            ERR_READ_MSG,						  // �\�����郁�b�Z�[�W 
        //        //            status,								  // �X�e�[�^�X�l
        //        //            this._employeeAcs,					  // �G���[�����������I�u�W�F�N�g
        //        //            MessageBoxButtons.OK,				  // �\������{�^��
        //        //            MessageBoxDefaultButton.Button1);	  // �����\���{�^��

        //        //        break;
        //        //    }
        //        // ---DEL 2008/10/06 �s��Ή�[6265] -------------------------------------------<<<<<
        //    }
            
            
        //    return status;
        //}
        // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<

		/// <summary>
		/// �r������
		/// </summary>
		/// <param name="operation">�I�y���[�V����</param>
		/// <param name="erObject">�G���[�I�u�W�F�N�g</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
		/// <br>Programmer : 22033  �O�� �M�j</br>
		/// <br>Date       : 2005.09.21</br>
		/// </remarks>
		private void ExclusiveTransaction(int status, string operation, object erObject)
		{				   
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"ExclusiveTransaction",				// ��������
						operation,							// �I�y���[�V����
						ERR_800_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						erObject,							// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"ExclusiveTransaction",				// ��������
						operation,							// �I�y���[�V����
						ERR_801_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						erObject,							// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					break;
				}
			}
		}

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���喼�̎擾����
        /// </summary>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <returns>���喼��</returns>
        /// <remarks>
        /// <br>Note       : ���喼�̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        private string GetSubSectionName(int subSectionCode)
        {
            string subSectionName = "";

            if (this._subSectionDic.ContainsKey(subSectionCode))
            {
                subSectionName = this._subSectionDic[subSectionCode].SubSectionName.Trim();
            }

            return subSectionName;
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        private void SetControlSize()
        {
            this.Name_tEdit.Size = new Size(496, 24);
            this.Kana_tEdit.Size = new Size(252, 24);
            this.tEdit_SectionCode.Size = new Size(36, 24);
            this.tEdit_SectionName.Size = new Size(179, 24);
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<


        // ADD 2008/10/10 �s��Ή�[6442] ---------->>>>>
        /// <summary>
        /// ���tEdit �����̓`�F�b�N
        /// </summary>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool DateEditNoInputCheck(TDateEdit2 targetDateEdit)
        {
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            if (_yearOnlyList.Contains(targetDateEdit.DateFormat))
            {
                // �N�̂�
                if (yy == 0) return true;
            }
            else if (_monthOnlyList.Contains(targetDateEdit.DateFormat))
            {
                if (yy == 0 && mm == 0) return true;
            }
            else
            {
                // ���ׂĖ����͉͂�
                if (yy == 0 && mm == 0 && dd == 0) return false;
            }

            if (yy < 1900)
            {
                return true;
            }
            // �N�����ʓ��̓`�F�b�N
            else if ((yy == 0) || (mm == 0) || (dd == 0))
            {
                return true;
            }
            // �P�����t�Ó����`�F�b�N
            else if (TDateTime.IsAvailableDate(targetDateEdit.GetDateTime()) == false)
            {
                return true;
            }

            return false;
        }
        // ADD 2008/10/10 �s��Ή�[6442] ----------<<<<<

		# endregion

		#region ��Control Events
		/// <summary>
		/// Form.Load �C�x���g(SFTOK09380UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFTOK09380UA_Load(object sender, System.EventArgs e)
		{
			// �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // �K�C�h�{�^���̃A�C�R���ݒ�
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BelongSubSectionGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // 2010/02/18 Add >>>
            this.FeliCaMngGuide_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.FeliCaMngDelete_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.DELETE];
            // 2010/02/18 Add <<<

            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this.BelongMinSectionGuide_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.OldBelongSectionGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.OldBelongSubSecGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.OldBelongMinSecGd_ultraButton.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

            // ���Џ��擾
            this.GetCompanyInf();   // 2008.01.16 �ǉ�

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // ��ʏ����ݒ菈��
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing �C�x���g(SFTOK09380UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFTOK09380UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;

			// �t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged �C�x���g(SFTOK09380UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFTOK09380UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// �������g����\���ɂȂ����ꍇ�A
			// �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

            MainTabControl.Tabs[0].Visible = true;
            MainTabControl.Tabs[1].Visible = true;

			MainTabControl.SelectedTab = MainTabControl.Tabs[0];

            ScreenClear();

			Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click �C�x���g(Ok_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (SaveProc() == false)
			{
				return;
			}
			// �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// �f�[�^�C���f�b�N�X������������
				this.DataIndex = -1;

				// ��ʃN���A����
				ScreenClear();

				// �V�K���[�h
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				ScreenInputPermissionControl(true);

				//���_�I�v�V��������
				if (!this._optSection)
				{
                    // --- CHG 2008/06/04 --------------------------------------------------------------------->>>>>
                    //this.BelongSelectionCode_tComboEditor.SelectedIndex = 0;
                    //this.BelongSelectionCode_tComboEditor.Enabled = false;
                    this.tEdit_SectionCode.Clear();
                    this.tEdit_SectionName.Clear();
                    this.tEdit_SectionCode.Enabled = false;
                    this.tEdit_SectionName.Enabled = false;
                    // --- CHG 2008/06/04 ---------------------------------------------------------------------<<<<<
                }

				// �N���[�����ēx�擾����
				Employee employee = new Employee();
                EmployeeDtl employeeDtl = new EmployeeDtl();
				
				//�N���[���쐬
				this._employeeClone = employee.Clone(); 
				DispToEmployee(ref this._employeeClone);
                this._employeeDtlClone = employeeDtl.Clone();
                DispToEmployeeDtl(ref this._employeeDtlClone);

				this.MainTabControl.Tabs["GeneralTab"].Selected = true;
				this.tEdit_EmployeeCode.Focus();
			}
			else
			{
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
			}
		}

		/// <summary>
		/// �]�ƈ����o�^����
		/// </summary>
		/// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����o�^���s���܂��B</br>
		/// <br>Programmer : 22033�@�O��  �M�j</br>
		/// <br>Date       : 2005.05.20</br>
		/// </remarks>
		private bool SaveProc()
		{
			Control control = null;
			string message = null;
			string loginID = "";
			Infragistics.Win.UltraWinTabControl.UltraTab selectedTab = this.MainTabControl.Tabs[TAB1_NAME];

			Employee employee = null;
            EmployeeDtl employeeDtl = null; // 2007.08.14 �ǉ�

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				employee = ((Employee)this._employeeTable[guid]).Clone();
			}

			// ���O�C��ID�d���`�F�b�N�p�ϐ��Z�b�g
			if (employee != null)
			{
				loginID = employee.LoginId;
			}

            // 2010/02/18 >>>
            //if (!ScreenDataCheck(ref control, ref message, ref selectedTab, loginID))
            if (!ScreenDataCheck(ref control, ref message, ref selectedTab, loginID, (string)this.FeliCaInfo_uLabel.Tag))
            // 2010/02/18 <<<
            {
				TMsgDisp.Show( 
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
					ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
					message,							// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);				// �\������{�^��

				this.MainTabControl.SelectedTab = selectedTab;
				control.Focus();
				return false;
			}

			this.DispToEmployee(ref employee);
            this.DispToEmployeeDtl(ref employeeDtl);    // 2007.08.14 �ǉ�

            // 2007.08.14 �C�� >>>>>>>>>>
            //int status = this._employeeAcs.Write(ref employee);
            int status = this._employeeAcs.Write(ref employee, ref employeeDtl);
            // 2007.08.14 �C�� <<<<<<<<<<

            // 2010/02/18 Add >>>
            FeliCaMngWork felicaMngwk = null;
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // FeliCa���̏�������
                if (!_optFeliCaAcs) return true;

                string idm = string.Empty;
                if (this.DataIndex >= 0)
                {
                    // �L���b�V������擾
                    if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                        idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                    _employeeAcs.ReadStaticMemory_FeliCa(out felicaMngwk, idm, 1);
                }
                // ��ʏ��Ƃ���IDm���o�^��
                if (this.FeliCaInfo_uLabel.Tag != null)
                {
                    // ���ɓo�^��IDm������
                    if (!string.IsNullOrEmpty(idm))
                    {
                        // IDm�ύX(Delete �� Insert)
                        if (felicaMngwk != null)
                            status = this._employeeAcs.Delete_FeliCa(felicaMngwk);
                        felicaMngwk = new FeliCaMngWork();
                    }
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {

                        // ��ʏ��㏑��
                        this.DispToFeliCaMng(ref felicaMngwk);
                        // DB������
                        status = _employeeAcs.Write_Felica(ref felicaMngwk);
                        // IDm�d����
                        if (status == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
                        {
                            TMsgDisp.Show(
                                this,								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                ERR_DPR_MSG2,						// �\�����郁�b�Z�[�W 
                                status,								// �X�e�[�^�X�l
                                MessageBoxButtons.OK);				// �\������{�^��

                            this.MainTabControl.SelectedTab = this.MainTabControl.Tabs[TAB2_NAME];
                            this.FeliCaMngGuide_uButton.Focus();
                            return false;
                        }
                    }
                }
                else
                {
                    // �o�^�ς݂��N���A���ꂽ�ꍇ�f�[�^���폜����
                    if (!string.IsNullOrEmpty(idm))
                    {
                        status = _employeeAcs.Delete_FeliCa(felicaMngwk);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            felicaMngwk = null;
                        }
                    }
                }
            }
            // 2010/02/18 Add <<<

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    // 2010/02/18 Add >>>
                    // DataSet�X�V
                    FeliCaMngToDataSet(felicaMngwk, employee.EmployeeCode);
                    // 2010/02/18 Add <<<
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						ERR_DPR_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						MessageBoxButtons.OK);				// �\������{�^��

					this.MainTabControl.SelectedTab = this.MainTabControl.Tabs[TAB1_NAME];
					this.tEdit_EmployeeCode.Focus();
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._employeeAcs);

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
					TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						this.Text,							// �v���O��������
						"SaveProc",							// ��������
						TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
						ERR_UPDT_MSG,						// �\�����郁�b�Z�[�W 
						status,								// �X�e�[�^�X�l
						this._employeeAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,				// �\������{�^��
						MessageBoxDefaultButton.Button1);	// �����\���{�^��
					
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
			}

			// DataSet�W�J����
			EmployeeToDataSet(employee, this.DataIndex);
            ScreenToEmployeeDtl(employeeDtl);   // 2007.08.14 �ǉ�
			
			return true;
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//�ۑ��m�F
				Employee compareEmployee = new Employee();
				compareEmployee = this._employeeClone.Clone();
                EmployeeDtl compareEmployeeDtl = new EmployeeDtl();     // 2007.08.14 �ǉ�
                compareEmployeeDtl = this._employeeDtlClone.Clone();    // 2007.08.14 �ǉ�
                //���݂̉�ʏ����擾����
				DispToEmployee(ref compareEmployee);
                DispToEmployeeDtl(ref compareEmployeeDtl);  // 2007.08.14 �ǉ�

                // 2010/02/18 Add >>>
                string idm = string.Empty;
                if ((_optFeliCaAcs) && (this.DataIndex >= 0))
                {
                    // �L���b�V������擾
                    if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                        idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                }
                // 2010/02/18 Add <<<

                //�ŏ��Ɏ擾������ʏ��Ɣ�r
                // 2007.08.14 �C�� >>>>>>>>>>
                //if (!(this._employeeClone.Equals(compareEmployee)))
                // 2010/02/18 >>>
                //if (!(this._employeeClone.Equals(compareEmployee)) || !(this._employeeDtlClone.EqualsDtl(compareEmployeeDtl)))
                if ((!(this._employeeClone.Equals(compareEmployee)) || !(this._employeeDtlClone.EqualsDtl(compareEmployeeDtl)))
                    || ((idm != (string)FeliCaInfo_uLabel.Tag) && ((string)FeliCaInfo_uLabel.Tag != null))
                    || ((_optFeliCaAcs) && (idm != (string)FeliCaInfo_uLabel.Tag) && (!string.IsNullOrEmpty(idm))))
                // 2010/02/18 <<<
                // 2007.08.14 �C�� <<<<<<<<<<
                {
					//��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
					DialogResult res = TMsgDisp.Show( 
						this,								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
						ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
						"",									// �\�����郁�b�Z�[�W 
						0,									// �X�e�[�^�X�l
						MessageBoxButtons.YesNoCancel);		// �\������{�^��

					switch(res)
					{
						case DialogResult.Yes:
						{
							if (SaveProc() == false)
							{
								return;
							}

							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
								UnDisplaying(this, me);
							}

							break;
						}
						case DialogResult.No:
						{
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
							}

							break;
						}
						default:
						{
							// 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                tEdit_EmployeeCode.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
							return;
						}
					}
				}
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
		}

		/// <summary>
		/// Control.Click �C�x���g(Delete_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        ASSEMBLY_ID,
                        "���쌠���̐����ɂ��A�{�@�\�͎g�p�ł��܂���B",
                        0,
                        MessageBoxButtons.OK);
            }
            else
            {
                DialogResult result = TMsgDisp.Show(
                this,													// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_QUESTION,						// �G���[���x��
                ASSEMBLY_ID,											// �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" + "��낵���ł����H",	// �\�����郁�b�Z�[�W 
                0,														// �X�e�[�^�X�l
                MessageBoxButtons.OKCancel,								// �\������{�^��
                MessageBoxDefaultButton.Button2);						// �����\���{�^��


                if (result == DialogResult.OK)
                {
                    Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
                    Employee employee = ((Employee)this._employeeTable[guid]).Clone();
                    EmployeeDtl employeeDtl = null;
                    if (employee != null)
                    {
                        employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
                    }

                    // 2007.08.14 �C�� >>>>>>>>>>
                    //int status = this._employeeAcs.Delete(employee);
                    int status = this._employeeAcs.Delete(employee, employeeDtl);
                    // 2007.08.14 �C�� <<<<<<<<<<

                    // 2010/02/18 Add >>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        if (_optFeliCaAcs)
                        {
                            FeliCaMngWork felicaMng;
                            string idm = string.Empty;
                            if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                                idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                            _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                            if (felicaMng != null)
                                status = _employeeAcs.Delete_FeliCa(felicaMng);
                        }
                    }
                    // 2010/02/18 Add <<<

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this.DataIndex].Delete();
                                this._employeeTable.Remove(employee.FileHeaderGuid);

                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                            {
                                ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._employeeAcs);

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

                                return;
                            }
                        default:
                            {
                                TMsgDisp.Show(
                                    this,								  // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                                    ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                                    this.Text,							  // �v���O��������
                                    "Delete_Button_Click",				  // ��������
                                    TMsgDisp.OPE_DELETE,				  // �I�y���[�V����
                                    ERR_RDEL_MSG,						  // �\�����郁�b�Z�[�W 
                                    status,								  // �X�e�[�^�X�l
                                    this._employeeAcs,					  // �G���[�����������I�u�W�F�N�g
                                    MessageBoxButtons.OK,				  // �\������{�^��
                                    MessageBoxDefaultButton.Button1);	  // �����\���{�^��

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

                                return;
                            }
                    }
                    EmployeeDtlDelete(employeeDtl); // 2007.08.14 �ǉ�
                }
                else
                {
                    this.Delete_Button.Focus();
                    return;
                }
            }

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
        }

		/// <summary>
		/// Control.Click �C�x���g(Revive_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            if (MyOpeCtrl.Disabled((int)OperationCode.Revive))
            {
                TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        ASSEMBLY_ID,
                        "���쌠���̐����ɂ��A�{�@�\�͎g�p�ł��܂���B",
                        0,
                        MessageBoxButtons.OK);
            }
            else
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][GUID_TITLE];
                Employee employee = ((Employee)_employeeTable[guid]).Clone();
                EmployeeDtl employeeDtl = null;
                if (employee != null)
                {
                    employeeDtl = EmployeeDtlToScreen(employee.EmployeeCode);
                }

                // 2007.08.14 �ǉ� >>>>>>>>>>
                //int status = this._employeeAcs.Revival(ref employee);
                int status = this._employeeAcs.Revival(ref employee, ref employeeDtl);
                // 2007.08.14 �ǉ� <<<<<<<<<<

                // 2010/02/18 Add >>>
                FeliCaMngWork felicaMng = null;
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    if (_optFeliCaAcs)
                    {
                        string idm = string.Empty;
                        if (this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE] != DBNull.Value)
                            idm = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[this._dataIndex][FELICAIDM_TITLE];
                        _employeeAcs.ReadStaticMemory_FeliCa(out felicaMng, idm, 1);
                        if (felicaMng != null)
                            status = _employeeAcs.Revival_FeliCa(ref felicaMng);
                    }
                }
                // 2010/02/18 Add <<<

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        {
                            ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._employeeAcs);

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

                            return;
                        }
                    default:
                        {
                            TMsgDisp.Show(
                                this,								  // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOPDISP,	  // �G���[���x��
                                ASSEMBLY_ID,						  // �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Text,							  // �v���O��������
                                "Revive_Button_Click",				  // ��������
                                TMsgDisp.OPE_UPDATE,				  // �I�y���[�V����
                                ERR_RVV_MSG,						  // �\�����郁�b�Z�[�W 
                                status,								  // �X�e�[�^�X�l
                                this._employeeAcs,					  // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,				  // �\������{�^��
                                MessageBoxDefaultButton.Button1);	  // �����\���{�^��

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

                            return;
                        }
                }

                // DataSet�W�J����
                EmployeeToDataSet(employee, this.DataIndex);
                ScreenToEmployeeDtl(employeeDtl);   // 2007.08.14 �ǉ�

                // 2010/02/18 Add >>>
                if (_optFeliCaAcs)
                    FeliCaMngToDataSet(felicaMng, employee.EmployeeCode);
                // 2010/02/18 Add <<<

            }

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
		}

		/// <summary>
		/// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
		///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
		///					  �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;

            // �}�X�^�Ǎ�����
            ReadSecInfoSet();
            ReadSubSection();

            // ��ʍč\�z����
			ScreenReconstruction();
		}

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// TRetKeyControl.ChangeFocus �C�x���g �C�x���g(tRetKeyControl1)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �t�H�[�J�X���J�ڂ���ۂɔ������܂��B</br>
		/// <br>Programmer  : 980076 �Ȓ�  ����Y</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            // 2007.08.14 �ǉ� >>>>>>>>>>
            if (this._employeeDtl == null) return;
            //int status;
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // �����_�ł̏]�ƈ��ڍ׃N���X�̏���ޔ�����
            EmployeeDtl employeesDtlWork = this._employeeDtl;
            EmployeeDtl employeesDtlBuff = this._employeeDtl;

            switch (e.PrevCtrl.Name)
            {
                #region < ���� >
                // ���� ============================================ //
                case "BelongSubSectionCode_tNedit":
                    {
                        if (this._employeeDtlClone.BelongSubSectionCode.CompareTo(this.BelongSubSectionCode_tNedit.GetInt()) != 0)
                        {
                            string belongSectionCode = "";
                            if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
                                belongSectionCode = this.BelongSelectionCode_tComboEditor.Value.ToString();
                            if (belongSectionCode == "")
                            {
                                this.BelongSubSectionCode_tNedit.Clear();
                                this.BelongSubSectionName_tEdit.Clear();
                                break;
                            }

                            // ���l�݂̂����͂���Ă��邩�H
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                            if (regex.IsMatch(this.BelongSubSectionCode_tNedit.DataText))
                            {
                                SubSection subSection = new SubSection();
                                SubSectionAcs subSectionAcs = new SubSectionAcs();

                                int status = subSectionAcs.Read(out subSection, this._enterpriseCode, belongSectionCode, this.BelongSubSectionCode_tNedit.GetInt());

                                #region < ��ʕ\������ >
                                if (status == 0)
                                {
                                    #region -- �擾�f�[�^�W�J --
                                    // �擾�f�[�^�\��
                                    this.BelongSubSectionName_tEdit.DataText = subSection.SubSectionName;

                                    #endregion
                                }
                                else
                                {
                                    #region -- �擾���s --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������f�[�^�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.BelongSubSectionCode_tNedit.Clear();
                                    this.BelongSubSectionName_tEdit.Clear();

                                    this.BelongMinSectionCode_tNedit.Clear();
                                    this.BelongMinSectionName_tEdit.Clear();
                                    #endregion
                                }
                                #endregion

                            }
                            else if (this.BelongSubSectionCode_tNedit.DataText.Trim() == "")
                            {
                                // �R�[�h���N���A���ꂽ�ꍇ�́A���̂��N���A
                                this.BelongSubSectionCode_tNedit.Clear();
                                this.BelongSubSectionName_tEdit.Clear();

                                this.BelongMinSectionCode_tNedit.Clear();
                                this.BelongMinSectionName_tEdit.Clear();
                            }

                            #region < �ҏW�O�f�[�^�ێ� >
                            // �ҏW���ꂽ����ҏW�O�f�[�^�Ƃ��ĕێ�
                            this._employeeDtlClone.BelongSubSectionCode = this.BelongSubSectionCode_tNedit.GetInt();
                            this._employeeDtlClone.BelongSubSectionName = this.BelongSubSectionName_tEdit.DataText;
                            #endregion
                        }

                        break;
                    }
                #endregion

                #region < �� >
                // �� ============================================ //
                case "BelongMinSectionCode_tNedit":
                    {
                        if (this._employeeDtlClone.BelongMinSectionCode.CompareTo(this.BelongMinSectionCode_tNedit.GetInt()) != 0)
                        {
                            string belongSectionCode = "";
                            if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
                                belongSectionCode = this.BelongSelectionCode_tComboEditor.Value.ToString();
                            if (belongSectionCode == "")
                            {
                                this.BelongMinSectionCode_tNedit.Clear();
                                this.BelongMinSectionName_tEdit.Clear();
                                break;
                            }

                            // ���l�݂̂����͂���Ă��邩�H
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                            if (regex.IsMatch(this.BelongMinSectionCode_tNedit.DataText))
                            {
                                MinSection minSection = new MinSection();
                                MinSectionAcs minSectionAcs = new MinSectionAcs();

                                int status = minSectionAcs.Read(out minSection, this._enterpriseCode, belongSectionCode, this.BelongSubSectionCode_tNedit.GetInt(), this.BelongMinSectionCode_tNedit.GetInt());

                                #region < ��ʕ\������ >
                                if (status == 0)
                                {
                                    #region -- �擾�f�[�^�W�J --
                                    // �擾�f�[�^�\��
                                    this.BelongMinSectionName_tEdit.DataText = minSection.MinSectionName;

                                    #endregion
                                }
                                else
                                {
                                    #region -- �擾���s --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������f�[�^�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.BelongMinSectionCode_tNedit.Clear();
                                    this.BelongMinSectionName_tEdit.Clear();
                                    #endregion
                                }
                                #endregion

                            }
                            else if (this.BelongMinSectionCode_tNedit.DataText.Trim() == "")
                            {
                                // �R�[�h���N���A���ꂽ�ꍇ�́A���̂��N���A
                                this.BelongMinSectionCode_tNedit.Clear();
                                this.BelongMinSectionName_tEdit.Clear();
                            }

                            #region < �ҏW�O�f�[�^�ێ� >
                            // �ҏW���ꂽ����ҏW�O�f�[�^�Ƃ��ĕێ�
                            this._employeeDtlClone.BelongMinSectionCode = this.BelongMinSectionCode_tNedit.GetInt();
                            this._employeeDtlClone.BelongMinSectionName = this.BelongMinSectionName_tEdit.DataText;
                            #endregion
                        }
                        break;
                    }
                #endregion
                #region < �����_ >
                // �����_ ============================================ //
                case "OldBelongSectionCd_tEdit":
                    {
                        if (this._employeeDtlClone.OldBelongSectionCd.CompareTo(this.OldBelongSectionCd_tEdit.DataText) != 0)
                        {
                            if (this.OldBelongSectionCd_tEdit.DataText.Trim() != "")
                            {
                                SecInfoSet secInfoSet;
                                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();

                                int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText);

                                #region < ��ʕ\������ >

                                if (status == 0)
                                {
                                    #region -- �擾�f�[�^�W�J --
                                    // �擾�f�[�^�\��
                                    // ���_����ʕ\��
                                    this.OldBelongSectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;
                                    this.OldBelongSubSecCd_tNedit.Clear();
                                    this.OldBelongSubSecNm_tEdit.Clear();
                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();

                                    #endregion
                                }
                                else
                                {
                                    #region -- �擾���s --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������f�[�^�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.OldBelongSectionCd_tEdit.Clear();
                                    this.OldBelongSectionNm_tEdit.Clear();
                                    this.OldBelongSubSecCd_tNedit.Clear();
                                    this.OldBelongSubSecNm_tEdit.Clear();
                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                this.OldBelongSectionCd_tEdit.Clear();
                                this.OldBelongSectionNm_tEdit.Clear();
                                this.OldBelongSubSecCd_tNedit.Clear();
                                this.OldBelongSubSecNm_tEdit.Clear();
                                this.OldBelongMinSecCd_tNedit.Clear();
                                this.OldBelongMinSecNm_tEdit.Clear();
                            }

                            #region < �ҏW�O�f�[�^�ێ� >
                            // �ҏW���ꂽ����ҏW�O�f�[�^�Ƃ��ĕێ�
                            this._employeeDtlClone.OldBelongSectionCd = this.OldBelongSectionCd_tEdit.DataText;
                            this._employeeDtlClone.OldBelongSectionNm = this.OldBelongSectionNm_tEdit.DataText;
                            #endregion
                        }
                        break;
                    }
                #endregion

                #region < ������ >
                // ������ ============================================ //
                case "OldBelongSubSecCd_tNedit":
                    {
                        if (this._employeeDtlClone.OldBelongSubSecCd.CompareTo(this.OldBelongSubSecCd_tNedit.GetInt()) != 0)
                        {
                            if (this.OldBelongSectionCd_tEdit.DataText.Trim() == "")
                            {
                                this.OldBelongSubSecCd_tNedit.Clear();
                                this.OldBelongSubSecNm_tEdit.Clear();
                                break;
                            }

                            // ���l�݂̂����͂���Ă��邩�H
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                            if (regex.IsMatch(this.OldBelongSubSecCd_tNedit.DataText))
                            {
                                SubSection subSection = new SubSection();
                                SubSectionAcs subSectionAcs = new SubSectionAcs();

                                int status = subSectionAcs.Read(out subSection, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText, this.OldBelongSubSecCd_tNedit.GetInt());

                                #region < ��ʕ\������ >
                                if (status == 0)
                                {
                                    #region -- �擾�f�[�^�W�J --
                                    // �擾�f�[�^�\��
                                    this.OldBelongSubSecNm_tEdit.DataText = subSection.SubSectionName;
                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();

                                    #endregion
                                }
                                else
                                {
                                    #region -- �擾���s --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������f�[�^�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.OldBelongSubSecCd_tNedit.Clear();
                                    this.OldBelongSubSecNm_tEdit.Clear();
                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();
                                    #endregion
                                }
                                #endregion

                            }
                            else if (this.OldBelongSubSecCd_tNedit.DataText.Trim() == "")
                            {
                                // �R�[�h���N���A���ꂽ�ꍇ�́A���̂��N���A
                                this.OldBelongSubSecCd_tNedit.Clear();
                                this.OldBelongSubSecNm_tEdit.Clear();
                                this.OldBelongMinSecCd_tNedit.Clear();
                                this.OldBelongMinSecNm_tEdit.Clear();
                            }

                            #region < �ҏW�O�f�[�^�ێ� >
                            // �ҏW���ꂽ����ҏW�O�f�[�^�Ƃ��ĕێ�
                            this._employeeDtlClone.OldBelongSubSecCd = this.OldBelongSubSecCd_tNedit.GetInt();
                            this._employeeDtlClone.OldBelongSubSecNm = this.OldBelongSubSecNm_tEdit.DataText;
                            #endregion
                        }

                        break;
                    }
                #endregion

                #region < ���� >
                // ���� ============================================ //
                case "OldBelongMinSecCd_tNedit":
                    {
                        if (this._employeeDtlClone.OldBelongMinSecCd.CompareTo(this.OldBelongMinSecCd_tNedit.GetInt()) != 0)
                        {
                            if (this.OldBelongSectionCd_tEdit.DataText.Trim() == "")
                            {
                                this.OldBelongMinSecCd_tNedit.Clear();
                                this.OldBelongMinSecNm_tEdit.Clear();
                                break;
                            }

                            // ���l�݂̂����͂���Ă��邩�H
                            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
                            if (regex.IsMatch(this.OldBelongMinSecCd_tNedit.DataText))
                            {
                                MinSection minSection = new MinSection();
                                MinSectionAcs minSectionAcs = new MinSectionAcs();

                                int status = minSectionAcs.Read(out minSection, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText, this.OldBelongSubSecCd_tNedit.GetInt(), this.OldBelongMinSecCd_tNedit.GetInt());

                                #region < ��ʕ\������ >
                                if (status == 0)
                                {
                                    #region -- �擾�f�[�^�W�J --
                                    // �擾�f�[�^�\��
                                    this.OldBelongMinSecNm_tEdit.DataText = minSection.MinSectionName;

                                    #endregion
                                }
                                else
                                {
                                    #region -- �擾���s --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "�Y������f�[�^�����݂��܂���B",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.OldBelongMinSecCd_tNedit.Clear();
                                    this.OldBelongMinSecNm_tEdit.Clear();
                                    #endregion
                                }
                                #endregion

                            }
                            else if (this.BelongMinSectionCode_tNedit.DataText.Trim() == "")
                            {
                                // �R�[�h���N���A���ꂽ�ꍇ�́A���̂��N���A
                                this.OldBelongMinSecCd_tNedit.Clear();
                                this.OldBelongMinSecNm_tEdit.Clear();
                            }

                            #region < �ҏW�O�f�[�^�ێ� >
                            // �ҏW���ꂽ����ҏW�O�f�[�^�Ƃ��ĕێ�
                            this._employeeDtlClone.OldBelongMinSecCd = this.OldBelongMinSecCd_tNedit.GetInt();
                            this._employeeDtlClone.OldBelongMinSecNm = this.OldBelongMinSecNm_tEdit.DataText;
                            #endregion
                        }
                        break;
                    }
                #endregion
            }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
		/// <summary>
		/// TEdit.ValueChanged �C�x���g �C�x���g(Name_tEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : ���̂�ύX�����ۂɔ������܂��B</br>
		/// <br>Programmer  : 22024 ����@�_�u</br>
		/// <br>Date        : 2005.06.13</br>
		/// </remarks>
		private void Name_tEdit_ValueChanged(object sender, System.EventArgs e)
		{
			if (this.Name_tEdit.DataText.Equals(""))
			{
				this.Kana_tEdit.Clear();
			}
		}
		
		/// <summary>
		/// UltraTabControl.SelectedTabChanged �C�x���g �C�x���g(MainTabControl)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: SelectedTab���ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer  : 22024 ����@�_�u</br>
		/// <br>Date        : 2005.06.21</br>
		/// </remarks>
		private void MainTabControl_SelectedTabChanged(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e)
		{
			if (this.MainTabControl.SelectedTab == this.MainTabControl.Tabs[TAB1_NAME])
			{
				if (this.Mode_Label.Text == INSERT_MODE)
				{
					this.tEdit_EmployeeCode.Focus();
					this.tEdit_EmployeeCode.SelectAll();
				}
				else if (this.Mode_Label.Text == UPDATE_MODE)
				{
					this.Name_tEdit.Focus();
					this.Name_tEdit.SelectAll();
				}
				else
				{
					this.Delete_Button.Focus();
				}
			}
			else if (this.MainTabControl.SelectedTab == this.MainTabControl.Tabs[TAB2_NAME])
			{
				if ((this.Mode_Label.Text == INSERT_MODE) ||
					(this.Mode_Label.Text == UPDATE_MODE))
				{
					this.LoginId_tEdit.Focus();
					this.LoginId_tEdit.SelectAll();
				}
				else
				{
					this.Delete_Button.Focus();
				}
			}
            //// 2007.08.14 �ǉ� >>>>>>>>>>
            //else if (this.MainTabControl.SelectedTab == this.MainTabControl.Tabs[TAB3_NAME])
            //{
            //    if ((this.Mode_Label.Text == INSERT_MODE) ||
            //        (this.Mode_Label.Text == UPDATE_MODE))
            //    {
            //        this.tNedit_SubSectionCode.Focus();
            //        this.tNedit_SubSectionCode.SelectAll();
            //    }
            //    else
            //    {
            //        this.Delete_Button.Focus();
            //    }
            //}
            //// 2007.08.14 �ǉ� <<<<<<<<<<
        }
		# endregion

        # region �K�C�h�{�^���C�x���g
        #region DEL 2008/06/04 Partsman�p�ɕύX
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��������R�[�h�K�C�h�{�^���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void BelongSubSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            string belongSectionCode;
            if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
            {
                belongSectionCode = this.BelongSelectionCode_tComboEditor.Value.ToString();
            }
            else
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                SubSectionAcs subSectionAcs = new SubSectionAcs();
                SubSection subSection = new SubSection();

                int status = subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode, belongSectionCode);
                if (status != 0) return;

                // �擾�f�[�^�\��
                this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                this.BelongSubSectionName_tEdit.DataText = subSection.SubSectionName;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/04 Partsman�p�ɕύX

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��������R�[�h�K�C�h�{�^���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void BelongSubSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SubSection subSection;

                int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode);
                if (status != 0) return;

                // �擾�f�[�^�\��
                this.tNedit_SubSectionCode.SetInt(subSection.SubSectionCode);
                this.BelongSubSectionName_tEdit.DataText = subSection.SubSectionName;

                //this.EmployAnalysCode1_tNedit.Focus();  // ADD 2008/10/09 �s��Ή�[6439]  // DEL 2008/11/04 �s��Ή�[7289]
                //this.Sex_tComboEditor.Focus();      // ADD 2008/11/04 �s��Ή�[7289]
                this.UOESnmDiv_tEdit.Focus();      // ADD 2008.11.14 �s��Ή�[7905]
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

            if (e.PrevCtrl.Name == "tEdit_SectionCode")
            {
                // ���_�R�[�h�������͂̏ꍇ
                if (this.tEdit_SectionCode.DataText.Trim() == "")
                {
                    this.tEdit_SectionName.Clear();
                    return;
                }

                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');

                // ���_���̎擾
                this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                if (e.ShiftKey == true)
                {
                    return;
                }

                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (this.tEdit_SectionName.DataText.Trim() != "")
                    {
                        // --- CHG 2009/02/13 ��QID:11419�Ή�------------------------------------------------------>>>>>
                        //e.NextCtrl = this.Ok_Button;        // DEL 2008/11/04 �s��Ή�[7289]
                        //e.NextCtrl = this.tNedit_SubSectionCode;        // ADD 2008/11/04 �s��Ή�[7289]
                        if (this.tNedit_SubSectionCode.Visible == true)
                        {
                            e.NextCtrl = this.tNedit_SubSectionCode;
                        }
                        else
                        {
                            e.NextCtrl = UOESnmDiv_tEdit;
                        }
                        // --- CHG 2009/02/13 ��QID:11419�Ή�------------------------------------------------------<<<<<
                    }
                }
            }
            else if (e.PrevCtrl.Name == "tNedit_SubSectionCode")
            {
                // ��������R�[�h�������͂̏ꍇ
                if (this.tNedit_SubSectionCode.DataText.Trim() == "")
                {
                    this.BelongSubSectionName_tEdit.Clear();
                    return;
                }

                // ��������R�[�h�擾
                int subSectionCode = this.tNedit_SubSectionCode.GetInt();

                // �������喼��
                this.BelongSubSectionName_tEdit.DataText = GetSubSectionName(subSectionCode);

                if (e.ShiftKey == true)
                {
                    return;
                }

                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (this.BelongSubSectionName_tEdit.DataText.Trim() != "")
                    {
                        //e.NextCtrl = this.EmployAnalysCode1_tNedit;     // DEL 2008/11/04 �s��Ή�[7289]
                        //e.NextCtrl = this.Sex_tComboEditor;     // ADD 2008/11/04 �s��Ή�[7289]
                        e.NextCtrl = this.UOESnmDiv_tEdit;     // ADD 2008.11.10 UOE���̋敪�ǉ�
                    }
                }
            }
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
            else if (e.PrevCtrl.Name == "tEdit_EmployeeCode")
            {
                // �S���҃R�[�h
                if (this._dataIndex < 0)
                {
                    if (e.NextCtrl.Name == "Cancel_Button")
                    {
                        // �J�ڐ悪����{�^��
                        _modeFlg = true;
                    }
                    else if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_EmployeeCode;
                    }
                }
            }
            // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void Kana_tEdit_ValueChanged(object sender, EventArgs e)
        {
            TEdit tEdit = (TEdit)sender;

            // ���p�ɕϊ�

            // 2008/11/06 modify [7412] start
            // ���͕��������擾���܂�
            int textLength = tEdit.Text.Replace("\r\n", "").Length;

            // ���̓o�C�g�����擾���܂�
            int textByte = Encoding.GetEncoding("Shift_JIS").GetByteCount(tEdit.Text.Replace("\r\n", ""));

            // �Q�o�C�g�������������Ƃ��̂ݕϊ�
            if (textLength != textByte)
            {
                tEdit.Text = Strings.StrConv(tEdit.Text.Trim(), VbStrConv.Narrow, 0);
            }
            // 2008/11/06 modify [7412] end
            
        }

        /// <summary>
        /// Button_Click �C�x���g(�]�ƈ��K�C�h)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            SecInfoSet secInfoSet;

            try
            {
                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    // �]�ƈ��R�[�h
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // �]�ƈ���
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    //this.Ok_Button.Focus(); // ADD 2008/10/09 �s��Ή�[6439]  // DEL 2008/11/04 �s��Ή�[7289]
                    this.tNedit_SubSectionCode.Focus(); // ADD 2008/11/04 �s��Ή�[7289]
                }
            }
            catch
            {
            }
        }

        // 2010/02/18 Add >>>
        /// <summary>
        /// FeliCa�K�C�h�{�^���N���b�N
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: FeliCa�K�C�h�{�^���N���b�N���̃C�x���g�ł��B</br>
        /// <br>Programmer  : 30517 �Ė� �x��</br>
        /// <br>Date        : 2010/02/18</br>
        /// </remarks>
        private void FeliCaMngGuide_uButton_Click(object sender, EventArgs e)
        {
            UInt64 feliCaIdm = 0;
            SFCMN03505CE feliCaGuide = new SFCMN03505CE();      // FeliCa�����̓t�H�[��
            DialogResult dialogRet;

            feliCaGuide.Text = "�t�F���J�J�[�hID�o�^";

            // �t�F���J�����̓t�H�[���N��
            dialogRet = feliCaGuide.ShowFeliCaReadForm(ref feliCaIdm, this);
            if (dialogRet == DialogResult.OK)
            {
                if (!feliCaIdm.Equals(0))
                {
                    // �J�[�h���ǂݎ�萬��
                    this.FeliCaInfo_uLabel.Text = "�o�^��";
                    this.FeliCaInfo_uLabel.Tag = TStrUtils.PadCharRight(feliCaIdm.ToString(), 20);
                }
            }
        }

        /// <summary>
        /// FeliCa�J�[�h���폜�{�^���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: FeliCa���폜�{�^���N���C�N���̃C�x���g�ł��B</br>
        /// <br>Programmer  : 30517 �Ė� �x��</br>
        /// <br>Date        : 2010/02/18</br>
        /// </remarks>
        private void FeliCaMngDelete_uButton_Click(object sender, EventArgs e)
        {
            // FeliCa�̉�ʏ����N���A
            this.FeliCaInfo_uLabel.Text = string.Empty;
            this.FeliCaInfo_uLabel.Tag = null;
        }
        // 2010/02/18 Add <<<



        /// <summary>
        /// ���_���ݒ�}�X�^�Ǎ�����
        /// </summary>
        private void ReadSecInfoSet()
        {
            try
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// ����}�X�^�Ǎ�����
        /// </summary>
        private void ReadSubSection()
        {
            try
            {
                this._subSectionDic = new Dictionary<int, SubSection>();

                ArrayList retList;

                int status = this._subSectionAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (SubSection subSection in retList)
                    {
                        if (subSection.LogicalDeleteCode == 0)
                        {
                            this._subSectionDic.Add(subSection.SubSectionCode, subSection);
                        }
                    }
                }
            }
            catch
            {
                this._subSectionDic = new Dictionary<int, SubSection>();
            }
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� >>>>>>START
        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            // �S���҃R�[�h
            string employeeCode = tEdit_EmployeeCode.Text.TrimEnd().PadLeft(4, '0');

            for (int i = 0; i < this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsEmployeeCode = (string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[i][CODE_TITLE];
                if (employeeCode.Equals(dsEmployeeCode.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[EMPLOYEE_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h�̏]�ƈ��ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // �S���҃R�[�h�̃N���A
                        tEdit_EmployeeCode.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        ASSEMBLY_ID,                            // �A�Z���u���h�c�܂��̓N���X�h�c
                        "���͂��ꂽ�R�[�h�̏]�ƈ��ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H",   // �\�����郁�b�Z�[�W
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
                                // �S���҃R�[�h�̃N���A
                                tEdit_EmployeeCode.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 ���� �V�K���[�h���烂�[�h�ύX�Ή� <<<<<<END

        /// <summary>
        /// �p�X���[�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginPassword_tEdit_Leave(object sender, EventArgs e)
        {
            /*2008.11.12 del ScreenDataCheck���\�b�h�Ƀ`�F�b�N�������ړ� --------------------------->>
            // 2008/11/06 add [7366] start
            if (this.LoginPassword_tEdit.Text.Trim().Length < 4)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_EXCLAMATION, ASSEMBLY_ID, this.Text,
                    "Password", TMsgDisp.OPE_GET, "�S���ȏ�̒l����͂��ĉ�����", // �\�����郁�b�Z�[�W 
                    0, this.LoginPassword_tEdit,
                    MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);	  // �����\���{�^��

                this.LoginPassword_tEdit.Clear();
                this.LoginPassword_tEdit.Focus();
            }
            // 2008/11/06 add [7366] end
              2008.11.12 del -------------------------------------------------------------------<<*/ 
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �����ۃR�[�h�K�C�h�{�^���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void BelongMinSectionGuide_ultraButton_Click(object sender, EventArgs e)
        {
            string belongSectionCode;
            if (this.BelongSelectionCode_tComboEditor.SelectedItem != null)
            {
                belongSectionCode = this.BelongSelectionCode_tComboEditor.Value.ToString();
            }
            else
            {
                return;
            }

            MinSectionAcs minSectionAcs = new MinSectionAcs();
            MinSection minSection = new MinSection();

            int status = minSectionAcs.ExecuteGuid(out minSection, this._enterpriseCode, belongSectionCode);
            if (status != 0) return;

            
            // �擾�f�[�^�\��
            this.BelongMinSectionCode_tNedit.SetInt(minSection.MinSectionCode);
            this.BelongMinSectionName_tEdit.DataText = minSection.MinSectionName;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���������_�R�[�h�K�C�h�{�^���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void OldBelongSectionGd_ultraButton_Click(object sender, EventArgs e)
        {
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
            SecInfoSet secInfoSet = new SecInfoSet();

            int status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            if (status != 0) return;

            
            // �擾�f�[�^�\��
            this.OldBelongSectionCd_tEdit.DataText = secInfoSet.SectionCode;
            this.OldBelongSectionNm_tEdit.DataText = secInfoSet.SectionGuideNm;
            
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ����������R�[�h�K�C�h�{�^���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void OldBelongSubSecGd_ultraButton_Click(object sender, EventArgs e)
        {
            if (this.OldBelongSectionCd_tEdit.DataText.Trim() == "")
            {
                return;
            }

            SubSectionAcs subSectionAcs = new SubSectionAcs();
            SubSection subSection = new SubSection();

            int status = subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText);
            if (status != 0) return;

            // �擾�f�[�^�\��
            this.OldBelongSubSecCd_tNedit.SetInt(subSection.SubSectionCode);
            this.OldBelongSubSecNm_tEdit.DataText = subSection.SubSectionName;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �������ۃR�[�h�K�C�h�{�^���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        private void OldBelongMinSecGd_ultraButton_Click(object sender, EventArgs e)
        {
            if (this.OldBelongSectionCd_tEdit.DataText.Trim() == "")
            {
                return;
            }

            MinSectionAcs minSectionAcs = new MinSectionAcs();
            MinSection minSection = new MinSection();

            int status = minSectionAcs.ExecuteGuid(out minSection, this._enterpriseCode, this.OldBelongSectionCd_tEdit.DataText);
            if (status != 0) return;

            // �擾�f�[�^�\��
            this.OldBelongMinSecCd_tNedit.SetInt(minSection.MinSectionCode);
            this.OldBelongMinSecNm_tEdit.DataText = minSection.MinSectionName;
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        # endregion
    }

	# region �]�ƈ�������͈̓N���X
	/// <summary>
	/// �]�ƈ�������͈̓N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �]�ƈ�������͈͂̃N���X�ł��B</br>
	/// <br>Programmer : 20054 �c��  �w</br>
	/// <br>Date       : 2005.04.13</br>
	/// <br></br>
	/// </remarks>
	public class sendEmployeeData
	{
		/// <summary>
		/// �]�ƈ�������͈̓N���X�f�[�^�Z�b�g����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����p�̃f�[�^�Z�b�g�ł��B</br>
		/// <br>Programmer : 20054 �c��  �w</br>
		/// <br>Date       : 2005.04.13</br>
		/// </remarks>
		public DataSet dataSet;

		/// <summary>
		/// �]�ƈ����n�b�V���e�[�u��
		/// </summary>
		/// <remarks>
		/// <br>Note       : ����p�̃n�b�V���e�[�u���ł��B</br>
		/// <br>Programmer : 20054 �c��  �w</br>
		/// <br>Date       : 2005.04.13</br>
		/// </remarks>
		public Hashtable emphashtable;
	}
	# endregion

	# region �]�ƈ���������o�����N���X
	/// <summary>
	/// �]�ƈ���������o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �]�ƈ���������o�����̃N���X�ł��B</br>
	/// <br>Programmer : 20054 �c��  �w</br>
	/// <br>Date       : 2005.04.13</br>
	/// <br></br>
	/// </remarks>
	public class ConditionData
	{
		/// <summary>
		/// �J�n�]�ƈ��R�[�h
		/// </summary>
		public string StartEmployeeCode;
		/// <summary>
		/// �I���]�ƈ��R�[�h
		/// </summary>
		public string EndEmployeeCode;
		/// <summary>
		/// �J�n�]�ƈ�����
		/// </summary>
		public string StartEmployeeName;
		/// <summary>
		/// �I���]�ƈ�����
		/// </summary>
		public string EndEmployeeName;
		/// <summary>
		/// �J�n���_�R�[�h
		/// </summary>
		public string StartSectionCode;
		/// <summary>
		/// �J�n���_�R�[�h
		/// </summary>
		public string EndSectionCode;
		/// <summary>
		/// �J�n���_����
		/// </summary>
		public string StartSectionName;
		/// <summary>
		/// �J�n���_����
		/// </summary>
		public string EndSectionName;
	}
	# endregion
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Ӑ挳���Ɖ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���Ӑ挳���Ɖ�̃f�[�^�A�N�Z�X�N���X</br>
	/// <br>Programer	: 20081 �D�c �E�l</br>
	/// <br>Date		: 2007.10.18</br>
    /// <br>Programmer  : 30009 �a�J ���</br>
    /// <br>Date        : 2009.01.21</br>
    /// <br>Note        : PM.NS�p�ɏC��</br>
    /// <br>Note        : ��DC��PM�ŕύX���K�v�ȕ����̂ݏC�����܂����B��</br>
    /// <br>Note        : ��PM�ŕs�v�ȏ����������Ă���肪�Ȃ���΂��̂܂܂ɂ��Ă���܂���</br>
    /// <br>Date        : 2014/02/20</br>
    /// <br>Note        : �d�|�ꗗ ��2294�Ή�</br>
    /// <br>Note        : ���|���擾���̃G���[Status���O�ŕԂ��悤�ɏC��</br>
    /// <br>Update Note : 2014/02/26 �c����</br>
    /// <br>            : Redmine#42188 �o�͋��z�敪�ǉ�</br>
    /// <br>UpdateNote  : 2015/09/21 �c�v�t</br>
    /// <br>�Ǘ��ԍ�    : 11170168-00</br>
    /// <br>            : Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br>
    /// </remarks>
	public class CsLedgerDmdAcs
	{
		#region �� Constructor
		/// <summary>
		/// ���Ӑ挳���Ɖ�A�N�Z�X�N���X�R���X�g���N�^�[
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public CsLedgerDmdAcs()
		{
		}

		/// <summary>
		/// ���Ӑ挳���Ɖ�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		static CsLedgerDmdAcs()
		{
			// ���_���擾���i�C���X�^���X��
			_secInfoAcs = new SecInfoAcs();
			// ���v�p�v��N����(�J�n)            
			_ttlAddUpDateSpanStart = new DateTime(1, 1, 1);
			// ���v�p�v��N����(�I��)            
			_ttlAddUpDateSpanEnd = new DateTime(1, 1, 1);
			// �f�[�^�Z�b�g�쐬
			SettingDataSet();
			// �g�p����e�[�u��������
			_csLedgerCustomerHTable = new Hashtable();
			_sectionHTable = new Hashtable();
			_secCodeList = new ArrayList();
			_htCAddUpUpDate = new Hashtable();
            // �������[�N�e�[�u��
			_depsitHTable = new Hashtable();
			// ���O�C�����_�擾
			Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
			if (loginEmployee != null)
			{
				_mySectionCode = loginEmployee.BelongSectionCode;
			}
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                _iCustDmdPrcInfGetDB = (ICustDmdPrcInfGetDB)MediationCustDmdPrcInfGetDB.GetCustDmdPrcInfGetDB();
                _iCustAccRecInfGetDB = (ICustAccRecInfGetDB)MediationCustAccRecInfGetDB.GetCustAccRecInfGetDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                _iCustDmdPrcInfGetDB = null;
                _iCustAccRecInfGetDB = null;
            }

		}
		#endregion �� Constructor

        

        #region �� Static Member
        /// <summary>���[�h</summary>
        private static int _imode;

        /// <summary>�����Ɖ�f�[�^�Z�b�g</summary>
		private static DataSet _csLedgerDataSet = null;

		/// <summary>�����Ɖ�׃f�[�^�e�[�u��(�`�[�ꗗ)</summary>
		private static DataTable _csLedgerSlipDataTable = null;

        /// <summary>�����Ɖ�׉�ʗp�f�[�^�r���[(�`�[�ꗗ)</summary>
		private static DataView _csLedgerSlipDataView = null;

		/// <summary>�����Ɖ�׃f�[�^�e�[�u��(���׈ꗗ)</summary>
		private static DataTable _csLedgerDtlDataTable = null;

        /// <summary>�����Ɖ�׉�ʗp�f�[�^�r���[(���׈ꗗ)</summary>
		private static DataView _csLedgerDtlDataView = null;

        /// <summary>�����Ɖ�׃f�[�^�e�[�u��(�c���ꗗ)</summary>
        private static DataTable _csLedgerBlanceDataTable = null;

        /// <summary>�����Ɖ�׉�ʗp�f�[�^�r���[(�c���ꗗ)</summary>
        private static DataView _csLedgerBlanceDataView = null;

		/// <summary>���Ӑ搿�����z�f�[�^�e�[�u��</summary>
		private static DataTable _custDmdPrcDataTable = null;

		/// <summary>���Ӑ搿�����z�f�[�^�r���[</summary>
		private static DataView _custDmdPrcDataView = null;

		/// <summary>�����f�[�^���X�g</summary>
		private static Hashtable _depsitHTable = null;

		/// <summary>�������Ӑ���</summary>
		private static Hashtable _csLedgerCustomerHTable = null;

		/// <summary>���͈�(�J�n)</summary>
		private static DateTime _ttlAddUpDateSpanStart = new DateTime(1, 1, 1);

		/// <summary>���͈�(�I��)</summary>
		private static DateTime _ttlAddUpDateSpanEnd = new DateTime(1, 1, 1);

		/// <summary>�v��N����(�J�n)</summary>
		private static DateTime _addUpDateStart = new DateTime(1, 1, 1);

		/// <summary>�v��N����(�I��)</summary>
		private static DateTime _addUpDateEnd = new DateTime(1, 1, 1);

		/// <summary>���_�e�[�u���擾�p</summary>
		private static Hashtable _sectionHTable = null;
		private static ArrayList _secCodeList = null;

		/// <summary>�����_�R�[�h</summary>
		private static string _mySectionCode = "";

		/// <summary>�{�Ћ@�\�L��[true:�{�Ћ@�\,false:���_�@�\]</summary>
		private static bool _isMainOfficeFunc = false;
		
		/// <summary>�\���Ώۋ��_�R�[�h</summary>
		private static string _targetSectionCode = "";

		/// <summary>�����X�V�N�����e�[�u��[KEY:����,Value:�����X�V�N����(int)]</summary>
		private static Hashtable _htCAddUpUpDate = null;

		/// <summary>���_���擾���i</summary>
		private static SecInfoAcs _secInfoAcs = null;

		// Acs Class -------------------------------------------------------------
		/// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
		private static PrtOutSetAcs _prtOutSetAcs = null;

		/// <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
		private static PrtOutSet _prtOutSetData = null;

		/// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
		private static AlItmDspNmAcs _alItmDspNmAcs = null;

		/// <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
		private static AlItmDspNm _alItmDspNmData = null;

        private static ICustDmdPrcInfGetDB _iCustDmdPrcInfGetDB = null;
        private static ICustAccRecInfGetDB _iCustAccRecInfGetDB = null;
        #endregion �� Static Member

		#region �� Public Const
		/// <summary>�����Ɖ�f�[�^�Z�b�g��</summary>
		public const string CT_CsLedgerDataSet = "CsLedgerDataSet";
		/// <summary>���Ӑ搿�����z�e�[�u������</summary>
		public const string Ct_Tbl_CustDmdPrcDataTable = "CustDmdPrcDataTable";
		/// <summary>�����Ɖ�p�e�[�u������(�`�[�ꗗ��ʕ\���p)</summary>
		public const string Ct_Tbl_CsLedgerSlipDataTable = "CsLedgerSlipDataTable";
        /// <summary>�����Ɖ�p�e�[�u������(���׈ꗗ��ʕ\���p)</summary>
        public const string Ct_Tbl_CsLedgerDtlDataTable = "CsLedgerDtlDataTable";
        /// <summary>�����Ɖ�p�e�[�u������(�c���ꗗ��ʕ\���p)</summary>
        public const string Ct_Tbl_CsLedgerBalanceDataTable = "CsLedgerBalanceDataTable";


		#region �� ���Ӑ搿�����z�J�������(�ӕ\���p)
		/// <summary>�v�㋒�_�R�[�h</summary>
		public const string Ct_CsDmd_AddUpSecCode = "AddUpSecCode";
		/// <summary>�v�㋒�_����</summary>
		public const string Ct_CsDmd_AddUpSecName = "AddUpSecName";
		/// <summary>�v��N����</summary>
		public const string Ct_CsDmd_AddUpDate = "AddUpDate";
        /// <summary>���[�^�C�g��</summary>
        public const string Ct_CsDmd_SlitTitle = "SlitTitle";
        /// <summary>�v��N����(Int�^)</summary>
		public const string Ct_CsDmd_AddUpDateInt = "AddUpDateInt";
		/// <summary>�v��N��</summary>
		public const string Ct_CsDmd_AddUpYearMonth = "AddUpYearMonth";
		/// <summary>�O�񐿋����z</summary>
		public const string Ct_CsDmd_LastTimeDemand = "LastTimeDemand";
		/// <summary>����������z�i�ʏ�����j</summary>
		public const string Ct_CsDmd_ThisTimeDmdNrml = "ThisTimeDmdNrml";
		/// <summary>����J�z�c���i�����v�j</summary>
		public const string Ct_CsDmd_ThisTimeTtlBlcDmd = "ThisTimeTtlBlcDmd";
        /// <summary>���E�㍡�񔄏���z</summary>
        public const string Ct_CsDmd_OfsThisTimeSales = "OfsThisTimeSales";
        /// <summary>���E�㍡�񔄏�����</summary>
        public const string Ct_CsDmd_OfsThisSalesTax = "OfsThisSalesTax";
		/// <summary>���񔄏���z</summary>
		public const string Ct_CsDmd_ThisTimeSales = "ThisTimeSales";
		/// <summary>����œ]�ŕ���</summary>
		public const string Ct_CsDmd_ConsTaxLayMethod = "ConsTaxLayMethod";
		/// <summary>����œ]�ŕ�������</summary>
		public const string Ct_CsDmd_ConsTaxLayMethodName = "ConsTaxLayMethodName";
		/// <summary>�v�Z�㐿�����z</summary>
		public const string Ct_CsDmd_AfCalDemandPrice = "AfCalDemandPrice";
		/// <summary>��2��O�c���i�����v�j</summary>
		public const string Ct_CsDmd_AcpOdrTtl2TmBfBlDmd = "AcpOdrTtl2TmBfBlDmd";
		/// <summary>��3��O�c���i�����v�j</summary>
		public const string Ct_CsDmd_AcpOdrTtl3TmBfBlDmd = "AcpOdrTtl3TmBfBlDmd";
		/// <summary>�����X�V���s�N����</summary>
		public const string Ct_CsDmd_CAddUpUpdExecDate = "CAddUpUpdExecDate";
		/// <summary>���σt���O</summary>
		public const string Ct_CsDmd_CloseFlag = "CloseFlag";
        /// <summary>�ԕi�E�l���z</summary>
        public const string Ct_CsDmd_ThisRgdsDis = "ThisRgdsDis";
        /// <summary>�ō�����z</summary>
        public const string Ct_CsDmd_ThisSalesTaxTotal = "ThisSalesTaxTotal";
		/// <summary>���t�͈́i�J�n�j</summary>
		public const string Ct_CsDmd_StartDateSpan = "StartDateSpan";
		/// <summary>���t�͈́i�I���j</summary>
		public const string Ct_CsDmd_EndDateSpan = "EndDateSpan";
        /// <summary>������R�[�h</summary>
        public const string Ct_CsDmd_ClaimCode = "ClaimCode";
        /// <summary>�����旪��</summary>
        public const string Ct_CsDmd_ClaimSnm = "ClaimSnm";
        /// <summary>���Ӑ�R�[�h</summary>
		public const string Ct_CsDmd_CustomerCode = "CustomerCode";
		/// <summary>����</summary>
		public const string Ct_CsDmd_Name = "Name";
		/// <summary>���̂Q</summary>
		public const string Ct_CsDmd_Name2 = "Name2";
        /// <summary>���Ӑ旪��</summary>
        public const string Ct_CsDmd_CustomerSnm = "CustomerSnm";
		//--------------------------------------------------
		//  ���̑�����(����p)
		//--------------------------------------------------
		/// <summary>�v��N��(����p)</summary>
		public const string Ct_CsDmd_PrintAddUpYearMonth = "PrintAddUpYearMonth";
		/// <summary>�v��N����(����p)</summary>
		public const string Ct_CsDmd_PrintAddUpDate = "PrintAddUpDate";
		/// <summary>�v��N�����J�n(�ꊇ����p)</summary>
		public const string Ct_CsDmd_StratAddUpDate = "StartAddUpDate";
        /// <summary> �ԕi�E�l�����v </summary>
        public const string Col_CsDmd_RgdsDisT = "RgdsDisT";
        /// <summary> ����`�[���� </summary>
        public const string Col_CsDmd_SalesSlipCount = "SalesSlipCount";
        /// <summary> �O�񔄊|���z </summary>
        public const string Col_CsDmd_LastTimeAccRec = "LastTimeAccRec";
        /// <summary> ����J�z�c�� </summary>
        public const string Col_CsDmd_ThisTimeTtlBlcAcc = "ThisTimeTtlBlcAcc";
        /// <summary> �ō�����z </summary>
        public const string Col_CsDmd_TimeSalesTax = "TimeSalesTax";
        /// <summary> �v�Z�㓖�����|���z(�������̔��|���z)</summary>
        public const string Col_CsDmd_AfCalTMonthAccRec = "AfCalTMonthAccRec";

		#endregion

		#region �� �����Ɖ�p�J�������(�`�[�ꗗ��ʕ\���p)
        /// <summary>������R�[�h</summary>
        public const string Ct_CsLedger_ClaimCode = "ClaimCode";
		/// <summary>���Ӑ�R�[�h</summary>
		public const string Ct_CsLedger_CustomerCode = "CustomerCode";
		/// <summary>�v����t(���)</summary>
		public const string Ct_CsLedger_AddUpDate = "AddUpDate";
		/// <summary>�O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)</summary>
		public const string Ct_CsLedger_BalanseCode = "BalanseCode";
		/// <summary>���R�[�h�敪(0:����,1:����)</summary>
		public const string Ct_CsLedger_RecordCode = "RecordCode";
		/// <summary>���|�敪(0:���|�Ȃ�,1:���|)</summary>
		public const string Ct_CsLedger_AccRecDivCd = "SalesSlipKind";
		/// <summary>�`�[���</summary>
		public const string Ct_CsLedger_SalesSlipKindName = "SalesSlipKindName";
		/// <summary>����`�[�敪(0:����,1:�ԕi)</summary>
		public const string Ct_CsLedger_SalesSlipCd = "SalesSlipCd";
		/// <summary>�ԓ`�敪(0:��,1:��,2���E�ςݍ�)</summary>
		public const string Ct_CsLedger_DebitNoteDiv = "DebitNoteDiv";
		/// <summary>�v����t</summary>
		public const string Ct_CsLedger_AddUpADate = "AddUpADate";
		/// <summary>�v����t(Int)</summary>
		public const string Ct_CsLedger_AddUpADateInt = "AddUpADateInt";
		/// <summary>�v����t(�\���p)</summary>
		public const string Ct_CsLedger_AddUpADateDisp = "AddUpADateDisp";
		/// <summary>�`�[�ԍ�</summary>
		public const string Ct_CsLedger_SlipNo = "SlipNo";
		/// <summary>�󒍁E�������e</summary>
		public const string Ct_CsLedger_SlipDetail = "SlipDetail";
		/// <summary>������z</summary>
		public const string Ct_CsLedger_SalesTotal = "SalesTotal";
        /// <summary>������z(�����p)</summary>
        public const string Ct_CsLedger_SalesTotal1 = "SalesTotal1";
        /// <summary>��������</summary>
        public const string Ct_CsLedger_SalesSubtotalTax = "SalesSubtotalTax";
        /// <summary>��������(����)</summary>
        public const string Ct_CsLedger_SalesSubtotalTax1 = "SalesSubtotalTax1";
        /// <summary>�ō�����z</summary>
        public const string Ct_CsLedger_ThisSalesTaxTotal = "ThisSalesTaxTotal";
        /// <summary>��`�x������(�\���p)</summary>
        public const string Ct_CsLedger_DraftPayTimeLimit = "DraftPayTimeLimit";
        /// <summary>�������z</summary>
		public const string Ct_CsLedger_Deposit = "Deposit";
		/// <summary>�c��</summary>
		public const string Ct_CsLedger_Balance = "Balance";
		/// <summary>�`�[���l</summary>
		public const string Ct_CsLedger_SlipNote = "SlipNote";
        /// <summary>�`�[���l2</summary>
        public const string Ct_CsLedger_SlipNote2 = "SlipNote2";
        /// <summary>�v�㋒�_�R�[�h</summary>
		public const string Ct_CsLedger_AddUpSecCode = "AddUpSecCode";
		/// <summary>�v�㋒�_����</summary>
		public const string Ct_CsLedger_AddUpSecName = "AddUpSecName";
        /// <summary>�����`�[�ԍ��i���ׁj</summary>
        public const string Ct_CsLedger_PartySlipNumDtl = "PartySlipNum";
        /// <summary>�󎚋敪</summary>
        public const string Ct_CsLedger_PrtDiv = "PrtDiv";
        /// <summary>UOE���}�[�N1</summary>
        public const string Ct_CsLedger_UOERemark1 = "UOERemark1";
        /// <summary>UOE���}�[�N2</summary>
        public const string Ct_CsLedger_UOERemark2 = "UOERemark2";
        #endregion

        #region �� �����Ɖ�p�J�������(���׈ꗗ��ʕ\���p)
        /// <summary>������R�[�h</summary>
        public const string Ct_CsLedgerDtl_ClaimCode = "ClaimCode";
        /// <summary>���Ӑ�R�[�h</summary>
		public const string Ct_CsLedgerDtl_CustomerCode = "CustomerCode";
		/// <summary>�v����t(���)</summary>
		public const string Ct_CsLedgerDtl_AddUpDate = "AddUpDate";
		/// <summary>�O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)</summary>
		public const string Ct_CsLedgerDtl_BalanseCode = "BalanseCode";
		/// <summary>���R�[�h�敪(0:����,1:����)</summary>
		public const string Ct_CsLedgerDtl_RecordCode = "RecordCode";
		/// <summary>�`�[���</summary>
		public const string Ct_CsLedgerDtl_SalesSlipKindName = "SalesSlipKindName";
		/// <summary>����`�[�敪(0:����,1:�ԕi)</summary>
		public const string Ct_CsLedgerDtl_SalesSlipCd = "SalesSlipCd";
		/// <summary>�ԓ`�敪(0:��,1:��,2���E�ςݍ�)</summary>
		public const string Ct_CsLedgerDtl_DebitNoteDiv = "DebitNoteDiv";
		/// <summary>�v����t</summary>
		public const string Ct_CsLedgerDtl_AddUpADate = "AddUpADate";
		/// <summary>�v����t(Int)</summary>
		public const string Ct_CsLedgerDtl_AddUpADateInt = "AddUpADateInt";
		/// <summary>�v����t(�\���p)</summary>
		public const string Ct_CsLedgerDtl_AddUpADateDisp = "AddUpADateDisp";
		/// <summary>�`�[�ԍ��E�����ԍ�</summary>
		/// <remarks>���`��:����`�[�ԍ��A������:�����ԍ�</remarks>
		public const string Ct_CsLedgerDtl_SlipNo = "SlipNo";
		/// <summary>�v�㋒�_�R�[�h</summary>
		public const string Ct_CsLedgerDtl_AddUpSecCode = "AddUpSecCode";
		/// <summary>�v�㋒�_����</summary>
        public const string Ct_CsLedgerDtl_AddUpSecName = "AddUpSecName";
        /// <summary>������z</summary>
        public const string Ct_CsLedgerDtl_SalesTotal = "SalesTotal";
        /// <summary>��������</summary>
        public const string Ct_CsLedgerDtl_SalesSubtotalTax = "SalesSubtotalTax";
        /// <summary>�ō�����z</summary>
        public const string Ct_CsLedgerDtl_ThisSalesTaxTotal = "ThisSalesTaxTotal";
        /// <summary>��`�x������(�\���p)</summary>
        public const string Ct_CsLedgerDtl_DraftPayTimeLimit = "DraftPayTimeLimit";
        /// <summary>�󒍁E�������e</summary>
        public const string Ct_CsLedgerDtl_SlipDetail = "SlipDetail";
        /// <summary>�c��</summary>
        public const string Ct_CsLedgerDtl_Balance = "Balance";
        /// <summary>�������z</summary>
        public const string Ct_CsLedgerDtl_Deposit = "Deposit";
        /// <summary>�`�[���l</summary>
        public const string Ct_CsLedgerDtl_SlipNote = "SlipNote";
        /// <summary>�`�[���l2</summary>
        public const string Ct_CsLedgerDtl_SlipNote2 = "SlipNote2";
        /// <summary>����s�ԍ�</summary>
        public const string Ct_CsLedgerDtl_SalesRowNo = "SalesRowNo";
        /// <summary>���i�ԍ�</summary>
        public const string Ct_CsLedgerDtl_GoodsNo = "GoodsNo";
        /// <summary>���i����</summary>
        public const string Ct_CsLedgerDtl_GoodsName = "GoodsName";
        /// <summary>�o�א�</summary>
        public const string Ct_CsLedgerDtl_ShipmentCnt = "ShipmentCnt";
        /// <summary>����P���i�Ŕ��C�����j</summary>
        public const string Ct_CsLedgerDtl_SalesUnPrcTaxExcFl = "SalesUnPrcTaxExcFl";
        /// <summary>������z�i�Ŕ����j</summary>
        public const string Ct_CsLedgerDtl_SalesMoneyTaxExc = "SalesMoneyTaxExc";
        /// <summary>������z�i�����p�j</summary>
        public const string Ct_CsLedgerDtl_SalesMoneyTaxExc1 = "SalesMoneyTaxExc1";
        /// <summary>������z�����</summary>
        public const string Ct_CsLedgerDtl_SalsePriceConsTax = "SalsePriceConsTax";
        /// <summary>������z�����(�����p)</summary>
        public const string Ct_CsLedgerDtl_SalsePriceConsTax1 = "SalsePriceConsTax1";
        /// <summary>�����`�[�ԍ��i���ׁj</summary> 
        public const string Ct_CsLedgerDtl_PartySlipNumDtl = "PartySlipNumDtl";
        /// <summary>UOE���}�[�N1</summary>
        public const string Ct_CsLedgerDtl_UOERemark1 = "UOERemark1";
        /// <summary>UOE���}�[�N2</summary>
        public const string Ct_CsLedgerDtl_UOERemark2 = "UOERemark2";
        /// <summary>�d����R�[�h</summary>
        public const string Ct_CsLedgerDtl_SupplierCd = "SupplierCd";

        // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� >>>>>>START
        /// <summary>����œ]�ŕ���</summary>
        public const string Ct_CsLedgerDtl_ConsTaxLayMethod = "ConsTaxLayMethod";
        /// <summary>�ېŋ敪</summary>
        public const string Ct_CsLedgerDtl_TaxationDivCd = "TaxationDivCd";
        // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� <<<<<<END
                                    
        #endregion

        #region �� �����Ɖ�p�J�������(�c���ꗗ��ʕ\���p)
        /// <summary>�v�㋒�_�R�[�h</summary>
        public const string Ct_CsLedgerBlance_AddUpSecCode = "AddUpSecCode";
        /// <summary>�v�㋒�_����</summary>
        public const string Ct_CsLedgerBlance_AddUpSecName = "AddUpSecName";
        /// <summary>�v��N����</summary>
        public const string Ct_CsLedgerBlance_AddUpDate = "AddUpDate";
        /// <summary>���[�^�C�g��</summary>
        public const string Ct_CsLedgerBlance_SlitTitle = "SlitTitle";
        /// <summary>�v��N����(Int�^)</summary>
        public const string Ct_CsLedgerBlance_AddUpDateInt = "AddUpDateInt";
        /// <summary>�v��N��</summary>
        public const string Ct_CsLedgerBlance_AddUpYearMonth = "AddUpYearMonth";
        /// <summary>�O�񐿋����z</summary>
        public const string Ct_CsLedgerBlance_LastTimeDemand = "LastTimeDemand";
        /// <summary>����������z�i�ʏ�����j</summary>
        public const string Ct_CsLedgerBlance_ThisTimeDmdNrml = "ThisTimeDmdNrml";
        /// <summary>����J�z�c���i�����v�j</summary>
        public const string Ct_CsLedgerBlance_ThisTimeTtlBlcDmd = "ThisTimeTtlBlcDmd";
        /// <summary>���E�㍡�񔄏���z</summary>
        public const string Ct_CsLedgerBlance_OfsThisTimeSales = "OfsThisTimeSales";
        /// <summary>���E�㍡�񔄏�����</summary>
        public const string Ct_CsLedgerBlance_OfsThisSalesTax = "OfsThisSalesTax";
        /// <summary>���񔄏���z</summary>
        public const string Ct_CsLedgerBlance_ThisTimeSales = "ThisTimeSales";
        /// <summary>����œ]�ŕ���</summary>
        public const string Ct_CsLedgerBlance_ConsTaxLayMethod = "ConsTaxLayMethod";
        /// <summary>����œ]�ŕ�������</summary>
        public const string Ct_CsLedgerBlance_ConsTaxLayMethodName = "ConsTaxLayMethodName";
        /// <summary>�v�Z�㐿�����z</summary>
        public const string Ct_CsLedgerBlance_AfCalDemandPrice = "AfCalDemandPrice";
        /// <summary>��2��O�c���i�����v�j</summary>
        public const string Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd = "AcpOdrTtl2TmBfBlDmd";
        /// <summary>��3��O�c���i�����v�j</summary>
        public const string Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd = "AcpOdrTtl3TmBfBlDmd";
        /// <summary>�����X�V���s�N����</summary>
        public const string Ct_CsLedgerBlance_CAddUpUpdExecDate = "CAddUpUpdExecDate";
        /// <summary>���σt���O</summary>
        public const string Ct_CsLedgerBlance_CloseFlag = "CloseFlag";
        /// <summary>�ԕi�E�l���z</summary>
        public const string Ct_CsLedgerBlance_ThisRgdsDis = "ThisRgdsDis";
        /// <summary>�ō�����z</summary>
        public const string Ct_CsLedgerBlance_ThisSalesTaxTotal = "ThisSalesTaxTotal";
        /// <summary>���t�͈́i�J�n�j</summary>
        public const string Ct_CsLedgerBlance_StartDateSpan = "StartDateSpan";
        /// <summary>���t�͈́i�I���j</summary>
        public const string Ct_CsLedgerBlance_EndDateSpan = "EndDateSpan";
        /// <summary>������R�[�h</summary>
        public const string Ct_CsLedgerBlance_ClaimCode = "ClaimCode";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string Ct_CsLedgerBlance_CustomerCode = "CustomerCode";
        /// <summary>����</summary>
        public const string Ct_CsLedgerBlance_Name = "Name";
        /// <summary>���̂Q</summary>
        public const string Ct_CsLedgerBlance_Name2 = "Name2";
        #endregion

		#endregion �� Public Member

		#region �� Public Enum
		/// <summary>�������ׂ̃��R�[�h�敪�̗񋓌^</summary>
		public enum LedgerDtlRecordState : int
		{
			/// <summary>����</summary>
			Sales = 0,
			/// <summary>����</summary>
			Deposit = 1,
		}

		/// <summary>�������ׂ̑O�c�J�z�敪�̗񋓌^�ł��B</summary>
		public enum LedgerDtlBalanseState : int
		{
			/// <summary>�O�c</summary>
			Balance = 0,
			/// <summary>���̑�(�� or ��)</summary>
			Others = 1,
			/// <summary>�����</summary>
			ConsTax = 2,
			/// <summary>�J�z</summary>
			Carried = 3,
		}

		/// <summary>�ԓ`�敪(0:��,1:��,2:���E�ςݍ�)</summary>
		public enum LedgerDtlDebitNoteDivState : int
		{
			/// <summary>��</summary>
			Black = 0,
			/// <summary>��</summary>
			Red = 1,
			/// <summary>���E�ςݍ�</summary>
			OffsetBlack = 2,
		}

		/// <summary>����`�[�敪(0:����,1:�ԕi)</summary>
		public enum LedgerDtlSalesSlipCdState : int
		{
			/// <summary>����</summary>
			Sale = 0,
            /// <summary>�ԕi</summary>
            Back = 1,
            /// <summary>�l��</summary>
            Discount = 2,
		}

		/// <summary>���t���O�敪(0:����,1:����)</summary>
		public enum CloseFlagState : int
		{
			/// <summary>����</summary>
			NotClose = 0,
			/// <summary>����</summary>
			Close = 1,
		}


		#endregion �� Public Enum

		#region �� Public Property

		/// <summary>�������׃f�[�^�Z�b�g�v���p�e�B</summary>
		public DataSet CsLedgerDataSet
		{
			get { return _csLedgerDataSet; }
		}

		/// <summary>�������׃f�[�^�e�[�u���v���p�e�B(�`�[�ꗗ)</summary>
		public DataTable CsLedgerSlipDataTable
		{
			get { return _csLedgerSlipDataTable; }
		}

		/// <summary>�������׃f�[�^�r���[�v���p�e�B(�`�[�ꗗ)</summary>
		public DataView CsLedgerSlipDataView
		{
			get { return _csLedgerSlipDataView; }
		}

		/// <summary>�������׃f�[�^�e�[�u���v���p�e�B(���׈ꗗ)</summary>
		public DataTable CsLedgerDtlDataTable
		{
			get { return _csLedgerDtlDataTable; }
		}

		/// <summary>�������׃f�[�^�r���[�v���p�e�B(���׈ꗗ)</summary>
		public DataView CsLedgerDtlDataView
		{
			get { return _csLedgerDtlDataView; }
		}

        /// <summary>�������׃f�[�^�e�[�u���v���p�e�B(�c���ꗗ)</summary>
        public DataTable CsLedgerBalanceDataTable
        {
            get { return _csLedgerBlanceDataTable; }
        }

        /// <summary>�������׃f�[�^�r���[�v���p�e�B(�c���ꗗ)</summary>
        public DataView CsLedgerBalanceDataView
        {
            get { return _csLedgerBlanceDataView; }
        }

		/// <summary>���Ӑ���z�f�[�^�e�[�u���v���p�e�B</summary>
		public DataTable CustDmdPrcDataTable
		{
			get { return _custDmdPrcDataTable; }
		}

		/// <summary>���Ӑ���z�f�[�^�r���[�v���p�e�B</summary>
		public DataView CustDmdPrcDataView
		{
			get { return _custDmdPrcDataView; }
		}

		/// <summary>�����`�[�f�[�^�e�[�u���v���p�e�B</summary>
		public Hashtable DepsitHTable
		{
			get { return _depsitHTable; }
		}

		/// <summary>���͈́i�J�n�j</summary>
		public DateTime TtlAddUpDateSpanStart
		{
			get { return _ttlAddUpDateSpanStart; }
		}

		/// <summary>���͈́i�I���j</summary>
		public DateTime TtlAddUpDateSpanEnd
		{
			get { return _ttlAddUpDateSpanEnd; }
		}

		/// <summary>�v��N�����i�J�n�j</summary>
		public DateTime AddUpDateStart
		{
			get { return _addUpDateStart; }
		}

		/// <summary>�v��N�����i�I���j</summary>
		public DateTime AddUpDateEnd
		{
			get { return _addUpDateEnd; }
		}

		/// <summary>���_��񃊃X�g</summary>
		public Hashtable SectionHTable
		{
			get { return _sectionHTable; }
		}

		/// <summary>���_�R�[�h���X�g</summary>
		public ArrayList SecCodeList
		{
			get { return _secCodeList;}
		}

		#endregion �� Public Property

		#region �� Public Static Method
		/// <summary>
		/// �f�[�^�Z�b�g�A�f�[�^�e�[�u���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static void SettingDataSet()
		{
			if (_csLedgerDataSet == null)
			{
			    _csLedgerDataSet = new DataSet();
			    CreateTableSchemer_CsLedgerSlipDataTable(ref _csLedgerDataSet);
                CreateTableSchemer_CsLedgerDtlDataTable(ref _csLedgerDataSet);
                CreateTableSchemer_CsLedgerBalanceDataTable(ref _csLedgerDataSet);
                CreateTableSchemer_CustDmdPrcDataTable(ref _csLedgerDataSet);
			}
		}


		#region �� ���Ӑ搿�����z(�ӗp)�e�[�u���X�L�[�}��`
		/// <summary>
		/// ���Ӑ搿�����z(�ӗp)�e�[�u���X�L�[�}��`
		/// </summary>
		/// <param name="ds"></param>
		public static void CreateTableSchemer_CustDmdPrcDataTable(ref DataSet ds)
		{
			DataTable dt = new DataTable(Ct_Tbl_CustDmdPrcDataTable);

			#region
			dt.Columns.Add(Ct_CsDmd_AddUpSecCode, typeof( string )); // �v�㋒�_�R�[�h
			dt.Columns[Ct_CsDmd_AddUpSecCode].Caption = "�v�㋒�_�R�[�h";

			dt.Columns.Add(Ct_CsDmd_AddUpSecName, typeof( string )); // �v�㋒�_����
			dt.Columns[Ct_CsDmd_AddUpSecName].Caption = "�v�㋒�_����";

			dt.Columns.Add(Ct_CsDmd_AddUpDate, typeof( DateTime )); // �v��N����
			dt.Columns[Ct_CsDmd_AddUpDate].Caption = "�v��N����";

            dt.Columns.Add(Ct_CsDmd_SlitTitle, typeof(string)); // ���[�^�C�g��
            dt.Columns[Ct_CsDmd_SlitTitle].Caption = "���[�^�C�g��";

			dt.Columns.Add(Ct_CsDmd_AddUpDateInt, typeof( Int32 )); // �v��N����(Int)
			dt.Columns[Ct_CsDmd_AddUpDateInt].Caption = "�v��N����";

			dt.Columns.Add(Ct_CsDmd_AddUpYearMonth, typeof( Int32 )); // �v��N��
			dt.Columns[Ct_CsDmd_AddUpYearMonth].Caption = "�v��N��";

			dt.Columns.Add(Ct_CsDmd_LastTimeDemand, typeof( Int64 )); // �O�񐿋����z
			dt.Columns[Ct_CsDmd_LastTimeDemand].Caption = "�O�񐿋����z";

			dt.Columns.Add(Ct_CsDmd_ThisTimeDmdNrml, typeof( Int64 )); // ����������z�i�ʏ�����j
			dt.Columns[Ct_CsDmd_ThisTimeDmdNrml].Caption = "����������z�i�ʏ�����j";

			dt.Columns.Add(Ct_CsDmd_ThisTimeTtlBlcDmd, typeof( Int64 )); // ����J�z�c���i�����v�j
			dt.Columns[Ct_CsDmd_ThisTimeTtlBlcDmd].Caption = "����J�z�c���i�����v�j";

			dt.Columns.Add(Ct_CsDmd_OfsThisTimeSales, typeof( Int64 )); // ���E�㍡�񔄏���z
			dt.Columns[Ct_CsDmd_OfsThisTimeSales].Caption = "���E�㍡�񔄏���z";

			dt.Columns.Add(Ct_CsDmd_OfsThisSalesTax, typeof( Int64 )); // ���E�㍡�񔄏�����
			dt.Columns[Ct_CsDmd_OfsThisSalesTax].Caption = "���E�㍡�񔄏�����";

			dt.Columns.Add(Ct_CsDmd_ThisTimeSales, typeof( Int64 )); // ���񔄏���z
			dt.Columns[Ct_CsDmd_ThisTimeSales].Caption = "���񔄏���z";

			dt.Columns.Add(Ct_CsDmd_ConsTaxLayMethod, typeof( Int32 )); // ����œ]�ŕ���
			dt.Columns[Ct_CsDmd_ConsTaxLayMethod].Caption = "����œ]�ŕ���";

			dt.Columns.Add(Ct_CsDmd_ConsTaxLayMethodName, typeof( string )); // ����œ]�ŕ���
			dt.Columns[Ct_CsDmd_ConsTaxLayMethodName].Caption = "����œ]�ŕ���";

			dt.Columns.Add(Ct_CsDmd_AfCalDemandPrice, typeof( Int64 )); // �v�Z�㐿�����z
			dt.Columns[Ct_CsDmd_AfCalDemandPrice].Caption = "�v�Z�㐿�����z";

			dt.Columns.Add(Ct_CsDmd_AcpOdrTtl2TmBfBlDmd, typeof( Int64 )); // ��2��O�c���i�����v�j
			dt.Columns[Ct_CsDmd_AcpOdrTtl2TmBfBlDmd].Caption = "��2��O�c���i�����v�j";

			dt.Columns.Add(Ct_CsDmd_AcpOdrTtl3TmBfBlDmd, typeof( Int64 )); // ��3��O�c���i�����v�j
			dt.Columns[Ct_CsDmd_AcpOdrTtl3TmBfBlDmd].Caption = "��3��O�c���i�����v�j";

			dt.Columns.Add(Ct_CsDmd_CAddUpUpdExecDate, typeof( Int32 )); // �����X�V���s�N����
			dt.Columns[Ct_CsDmd_CAddUpUpdExecDate].Caption = "�����X�V���s�N����";

			dt.Columns.Add(Ct_CsDmd_CloseFlag, typeof( Int32 )); // ���������ʔ�
			dt.Columns[Ct_CsDmd_CloseFlag].Caption = "���σt���O";

			dt.Columns.Add(Ct_CsDmd_ThisRgdsDis, typeof( Int64 )); // �ԕi�E�l���z
			dt.Columns[Ct_CsDmd_ThisRgdsDis].Caption = "�ԕi�E�l���z";

			dt.Columns.Add(Ct_CsDmd_ThisSalesTaxTotal, typeof( Int64 )); // �ō�����z
			dt.Columns[Ct_CsDmd_ThisSalesTaxTotal].Caption = "�ō�����z";

			dt.Columns.Add(Ct_CsDmd_StartDateSpan, typeof( Int32 )); // ���t�͈́i�J�n�j
			dt.Columns[Ct_CsDmd_StartDateSpan].Caption = "���t�͈́i�J�n�j";

			dt.Columns.Add(Ct_CsDmd_EndDateSpan, typeof( Int32 )); // ���t�͈́i�I���j
			dt.Columns[Ct_CsDmd_EndDateSpan].Caption = "���t�͈́i�I���j";

			dt.Columns.Add(Ct_CsDmd_ClaimCode, typeof( Int32 )); // ������R�[�h
            dt.Columns[Ct_CsDmd_ClaimCode].Caption = "������R�[�h";

			dt.Columns.Add(Ct_CsDmd_ClaimSnm, typeof( string )); // �����旪��
			dt.Columns[Ct_CsDmd_ClaimSnm].Caption = "�����旪��";

			dt.Columns.Add(Ct_CsDmd_CustomerCode, typeof( Int32 )); // ���Ӑ�R�[�h
			dt.Columns[Ct_CsDmd_CustomerCode].Caption = "���Ӑ�R�[�h";

			dt.Columns.Add(Ct_CsDmd_Name, typeof( string )); // ���Ӑ於��
			dt.Columns[Ct_CsDmd_Name].Caption = "���Ӑ於��";

			dt.Columns.Add(Ct_CsDmd_Name2, typeof( string )); // ���Ӑ於��2
			dt.Columns[Ct_CsDmd_Name2].Caption = "���Ӑ於��2";

			dt.Columns.Add(Ct_CsDmd_CustomerSnm, typeof( string )); // ����
			dt.Columns[Ct_CsDmd_CustomerSnm].Caption = "���Ӑ旪��";

			dt.Columns.Add(Ct_CsDmd_PrintAddUpYearMonth, typeof( Int32 )); // �v��N��
			dt.Columns[Ct_CsDmd_PrintAddUpYearMonth].Caption = "�v��N��";

			dt.Columns.Add(Ct_CsDmd_PrintAddUpDate, typeof( Int32 )); // �v��N����
			dt.Columns[Ct_CsDmd_PrintAddUpDate].Caption = "�v��N����";

			dt.Columns.Add(Ct_CsDmd_StratAddUpDate, typeof( string )); // �W����
			dt.Columns[Ct_CsDmd_StratAddUpDate].Caption = "�v��N�����J�n";

			dt.Columns.Add(Col_CsDmd_RgdsDisT, typeof( Int64 )); // �ԕi�E�l�����v
			dt.Columns[Col_CsDmd_RgdsDisT].Caption = "�ԕi�E�l�����v";

			dt.Columns.Add(Col_CsDmd_SalesSlipCount, typeof( Int32 )); // ����`�[����
			dt.Columns[Col_CsDmd_SalesSlipCount].Caption = "����`�[����";

			dt.Columns.Add(Col_CsDmd_LastTimeAccRec, typeof( Int64 )); // �O�񔄊|���z
			dt.Columns[Col_CsDmd_LastTimeAccRec].Caption = "�O�񔄊|���z";

			dt.Columns.Add(Col_CsDmd_ThisTimeTtlBlcAcc, typeof( Int64 )); // ����J�z�c��
			dt.Columns[Col_CsDmd_ThisTimeTtlBlcAcc].Caption = "����J�z�c��(���|)";

			dt.Columns.Add(Col_CsDmd_TimeSalesTax, typeof( Int64 )); // �ō�����z
			dt.Columns[Col_CsDmd_TimeSalesTax].Caption = "�ō�����z";

			dt.Columns.Add(Col_CsDmd_AfCalTMonthAccRec, typeof( Int64 )); // �v�Z�㓖�����|���z
			dt.Columns[Col_CsDmd_AfCalTMonthAccRec].Caption = "�v�Z�㓖�����|���z";
			#endregion

			ds.Tables.Add( dt );

			string sort = Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;

			// ���Ӑ搿�����z�e�[�u��
			_custDmdPrcDataTable = dt;
			_custDmdPrcDataView  = new DataView( dt, string.Empty, sort, DataViewRowState.CurrentRows );

		}
		#endregion

		#region �� �����Ɖ�p(�`�[�ꗗ��ʕ\���p)�e�[�u���X�L�[�}��`
		/// <summary>
		/// �����p(�`�[�ꗗ��ʕ\���p)�e�[�u���X�L�[�}��`
		/// </summary>
		/// <param name="ds"></param>
		public static void CreateTableSchemer_CsLedgerSlipDataTable(ref DataSet ds)
		{
			DataTable dt = new DataTable( Ct_Tbl_CsLedgerSlipDataTable );

			#region
			dt.Columns.Add(Ct_CsLedger_ClaimCode, typeof( Int32 )); // ������R�[�h
			dt.Columns[Ct_CsLedger_ClaimCode].Caption = "������R�[�h";

			dt.Columns.Add(Ct_CsLedger_CustomerCode, typeof( Int32 )); // ���Ӑ�R�[�h
			dt.Columns[Ct_CsLedger_CustomerCode].Caption = "���Ӑ�R�[�h";

			dt.Columns.Add(Ct_CsLedger_AddUpDate, typeof( Int32 )); // �v����t(���)
			dt.Columns[Ct_CsLedger_AddUpDate].Caption = "�v��N����";

			dt.Columns.Add(Ct_CsLedger_BalanseCode, typeof( Int32 )); // �O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)
			dt.Columns[Ct_CsLedger_BalanseCode].Caption = "�O�c�J�z�敪";

			dt.Columns.Add(Ct_CsLedger_RecordCode, typeof( Int32 )); // ���R�[�h�敪
			dt.Columns[Ct_CsLedger_RecordCode].Caption = "���R�[�h�敪";

			dt.Columns.Add(Ct_CsLedger_SalesSlipCd, typeof( Int32 )); // ����`�[�敪(0:����,1:�ԕi)
			dt.Columns[Ct_CsLedger_SalesSlipCd].Caption = "����`�[�敪";

			dt.Columns.Add(Ct_CsLedger_DebitNoteDiv, typeof( Int32 )); // �ԓ`�敪
			dt.Columns[Ct_CsLedger_DebitNoteDiv].Caption = "�ԓ`�敪";

			dt.Columns.Add(Ct_CsLedger_AddUpADate, typeof( DateTime )); // �v����t
			dt.Columns[Ct_CsLedger_AddUpADate].Caption = "�v����t";

			dt.Columns.Add(Ct_CsLedger_AddUpADateInt, typeof( Int32 )); // �v����t(Int)
			dt.Columns[Ct_CsLedger_AddUpADateInt].Caption = "�v����t";

			dt.Columns.Add(Ct_CsLedger_AddUpADateDisp, typeof( string )); // �v����t(�\���p)
			dt.Columns[Ct_CsLedger_AddUpADateDisp].Caption = "�v����t";

			dt.Columns.Add(Ct_CsLedger_SlipNo, typeof( string )); // �`�[�ԍ��E�����ԍ�
			dt.Columns[Ct_CsLedger_SlipNo].Caption = "�`�[�ԍ�";

            dt.Columns.Add(Ct_CsLedger_AccRecDivCd, typeof(string)); // ���|�敪(0:���|�Ȃ�,1:���|)
			dt.Columns[Ct_CsLedger_AccRecDivCd].Caption = "���|�敪";

			dt.Columns.Add(Ct_CsLedger_SalesSlipKindName, typeof( string )); // �`�[���
			dt.Columns[Ct_CsLedger_SalesSlipKindName].Caption = "�`�[���";

			dt.Columns.Add(Ct_CsLedger_SlipDetail, typeof( string )); // �󒍁E�������e
			dt.Columns[Ct_CsLedger_SlipDetail].Caption = "���e";

			dt.Columns.Add(Ct_CsLedger_SalesTotal, typeof( Int64 )); // ������z
			dt.Columns[Ct_CsLedger_SalesTotal].Caption = "������z";

            dt.Columns.Add(Ct_CsLedger_SalesTotal1, typeof(Int64)); // ������z(�����p)
            dt.Columns[Ct_CsLedger_SalesTotal1].Caption = "������z(�����p)";

			dt.Columns.Add(Ct_CsLedger_SalesSubtotalTax, typeof( Int64 )); // ��������
			dt.Columns[Ct_CsLedger_SalesSubtotalTax].Caption = "��������";

            dt.Columns.Add(Ct_CsLedger_SalesSubtotalTax1, typeof(Int64)); // ��������(�����p)
            dt.Columns[Ct_CsLedger_SalesSubtotalTax1].Caption = "��������(�����p)";

			dt.Columns.Add(Ct_CsLedger_ThisSalesTaxTotal, typeof( Int64 )); // �ō�����z
			dt.Columns[Ct_CsLedger_ThisSalesTaxTotal].Caption = "�ō�����z";

            dt.Columns.Add(Ct_CsLedger_DraftPayTimeLimit, typeof(string)); // ��`�x������(�\���p)
            dt.Columns[Ct_CsLedger_DraftPayTimeLimit].Caption = "��`�x������";

            dt.Columns.Add(Ct_CsLedgerDtl_GoodsName, typeof(string));   // ���i����
            dt.Columns[Ct_CsLedgerDtl_GoodsName].Caption = "���i����";

            dt.Columns.Add(Ct_CsLedger_Deposit, typeof(Int64)); // �������z
			dt.Columns[Ct_CsLedger_Deposit].Caption = "�������z";

			dt.Columns.Add(Ct_CsLedger_Balance, typeof( Int64 )); // �c��
			dt.Columns[Ct_CsLedger_Balance].Caption = "�c��";

			dt.Columns.Add(Ct_CsLedger_SlipNote, typeof( string )); // ���l
			dt.Columns[Ct_CsLedger_SlipNote].Caption = "���l";

            dt.Columns.Add(Ct_CsLedger_SlipNote2, typeof(string)); // ���l2
            dt.Columns[Ct_CsLedger_SlipNote2].Caption = "���l";

			dt.Columns.Add(Ct_CsLedger_AddUpSecCode, typeof( string )); // �v�㋒�_�R�[�h
			dt.Columns[Ct_CsLedger_AddUpSecCode].Caption = "�v�㋒�_�R�[�h";

			dt.Columns.Add(Ct_CsLedger_AddUpSecName, typeof( string )); // �v�㋒�_����
			dt.Columns[Ct_CsLedger_AddUpSecName].Caption = "�v�㋒�_����";

			dt.Columns.Add(Ct_CsLedger_PartySlipNumDtl, typeof( string )); // �����`�[�ԍ��i���ׁj
			dt.Columns[Ct_CsLedger_PartySlipNumDtl].Caption = "�����`�[�ԍ�";

			dt.Columns.Add(Ct_CsLedger_PrtDiv, typeof( Int32 )); // �󎚋敪
			dt.Columns[Ct_CsLedger_PrtDiv].Caption = "�󎚋敪";

            dt.Columns.Add(Ct_CsLedger_UOERemark1, typeof(string)); // UOE���}�[�N1
            dt.Columns[Ct_CsLedger_UOERemark1].Caption = "���}�[�N1";

            dt.Columns.Add(Ct_CsLedger_UOERemark2, typeof(string)); // UOE���}�[�N2
            dt.Columns[Ct_CsLedger_UOERemark2].Caption = "���}�[�N1";
            #endregion

            ds.Tables.Add(dt);

            string sort = Ct_CsLedger_ClaimCode + "," + Ct_CsLedger_AddUpDate + "," + Ct_CsLedger_BalanseCode + "," + Ct_CsLedger_AddUpADateInt + "," + Ct_CsLedger_RecordCode + "," + Ct_CsLedger_SlipNo;
            
			_csLedgerSlipDataTable	= dt;
			_csLedgerSlipDataView	= new DataView(_csLedgerSlipDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
		}
		#endregion

		#region �� �����Ɖ�p(���׈ꗗ��ʕ\���p)�e�[�u���X�L�[�}��`
		/// <summary>
		/// �����p(���׈ꗗ��ʕ\���p)�e�[�u���X�L�[�}��`
		/// </summary>
		/// <param name="ds"></param>
		public static void CreateTableSchemer_CsLedgerDtlDataTable(ref DataSet ds)
		{
			DataTable dt = new DataTable( Ct_Tbl_CsLedgerDtlDataTable );

			#region
			dt.Columns.Add(Ct_CsLedgerDtl_ClaimCode, typeof( Int32 )); // ������R�[�h
			dt.Columns[Ct_CsLedgerDtl_ClaimCode].Caption = "������R�[�h";

			dt.Columns.Add(Ct_CsLedgerDtl_CustomerCode, typeof( Int32 )); // ���Ӑ�R�[�h
			dt.Columns[Ct_CsLedgerDtl_CustomerCode].Caption = "���Ӑ�R�[�h";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpDate, typeof( Int32 )); // �v����t(���)
			dt.Columns[Ct_CsLedgerDtl_AddUpDate].Caption = "�v��N����";

			dt.Columns.Add(Ct_CsLedgerDtl_BalanseCode, typeof( Int32 )); // �O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)
			dt.Columns[Ct_CsLedgerDtl_BalanseCode].Caption = "�O�c�J�z�敪";

			dt.Columns.Add(Ct_CsLedgerDtl_RecordCode, typeof( Int32 )); // ���R�[�h�敪
			dt.Columns[Ct_CsLedgerDtl_RecordCode].Caption = "���R�[�h�敪";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesSlipCd, typeof( Int32 )); // ����`�[�敪(0:����,1:�ԕi)
			dt.Columns[Ct_CsLedgerDtl_SalesSlipCd].Caption = "����`�[�敪";

			dt.Columns.Add(Ct_CsLedgerDtl_DebitNoteDiv, typeof( Int32 )); // �ԓ`�敪
			dt.Columns[Ct_CsLedgerDtl_DebitNoteDiv].Caption = "�ԓ`�敪";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpADate, typeof( DateTime )); // �v����t
			dt.Columns[Ct_CsLedgerDtl_AddUpADate].Caption = "�v����t";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpADateInt, typeof( Int32 )); // �v����t(Int)
			dt.Columns[Ct_CsLedgerDtl_AddUpADateInt].Caption = "�v����t";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpADateDisp, typeof( string )); // �v����t(�\���p)
			dt.Columns[Ct_CsLedgerDtl_AddUpADateDisp].Caption = "�v����t";

			dt.Columns.Add(Ct_CsLedgerDtl_SlipNo, typeof( string )); // �`�[�ԍ��E�����ԍ�
			dt.Columns[Ct_CsLedgerDtl_SlipNo].Caption = "�`�[�ԍ�";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesSlipKindName, typeof( string )); // �`�[���
			dt.Columns[Ct_CsLedgerDtl_SalesSlipKindName].Caption = "�`�[���";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpSecCode, typeof( string )); // �v�㋒�_�R�[�h
			dt.Columns[Ct_CsLedgerDtl_AddUpSecCode].Caption = "�v�㋒�_�R�[�h";

			dt.Columns.Add(Ct_CsLedgerDtl_AddUpSecName, typeof( string )); // �v�㋒�_����
			dt.Columns[Ct_CsLedgerDtl_AddUpSecName].Caption = "�v�㋒�_����";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesTotal, typeof( Int64 )); // ������z
			dt.Columns[Ct_CsLedgerDtl_SalesTotal].Caption = "������z";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesSubtotalTax, typeof( Int64 )); // ��������
			dt.Columns[Ct_CsLedgerDtl_SalesSubtotalTax].Caption = "������z";

			dt.Columns.Add(Ct_CsLedgerDtl_ThisSalesTaxTotal, typeof( Int64 )); // �ō�����z
			dt.Columns[Ct_CsLedgerDtl_ThisSalesTaxTotal].Caption = "�ō�����z";

			dt.Columns.Add(Ct_CsLedgerDtl_DraftPayTimeLimit, typeof( string )); // ��`�x������(�\���p)
			dt.Columns[Ct_CsLedgerDtl_DraftPayTimeLimit].Caption = "��`�x������";

			dt.Columns.Add(Ct_CsLedgerDtl_SlipDetail, typeof( string )); // �󒍁E�������e
			dt.Columns[Ct_CsLedgerDtl_SlipDetail].Caption = "�󒍁E�������e";

			dt.Columns.Add(Ct_CsLedgerDtl_Balance, typeof( Int64 ));      // �c��
			dt.Columns[Ct_CsLedgerDtl_Balance].Caption = "�c��";

			dt.Columns.Add(Ct_CsLedgerDtl_Deposit, typeof( Int64 ));      // �������z
			dt.Columns[Ct_CsLedgerDtl_Deposit].Caption = "�����z";

			dt.Columns.Add(Ct_CsLedgerDtl_SlipNote, typeof( string ));    // �`�[���l
			dt.Columns[Ct_CsLedgerDtl_SlipNote].Caption = "�`�[���l";

			dt.Columns.Add(Ct_CsLedgerDtl_SlipNote2, typeof( string ));   // �`�[���l2
			dt.Columns[Ct_CsLedgerDtl_SlipNote2].Caption = "�`�[���l2";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesRowNo, typeof( Int32 ));   // ����s�ԍ�
			dt.Columns[Ct_CsLedgerDtl_SalesRowNo].Caption = "����s�ԍ�";

			dt.Columns.Add(Ct_CsLedgerDtl_GoodsNo, typeof( string ));     // ���i�ԍ�
			dt.Columns[Ct_CsLedgerDtl_GoodsNo].Caption = "���i�ԍ�";

			dt.Columns.Add(Ct_CsLedgerDtl_GoodsName, typeof( string ));   // ���i����
			dt.Columns[Ct_CsLedgerDtl_GoodsName].Caption = "���i����";

			dt.Columns.Add(Ct_CsLedgerDtl_ShipmentCnt, typeof( double )); // �o�א�
			dt.Columns[Ct_CsLedgerDtl_ShipmentCnt].Caption = "�o�א�";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesUnPrcTaxExcFl, typeof( double )); // ����P���i�Ŕ��C�����j
			dt.Columns[Ct_CsLedgerDtl_SalesUnPrcTaxExcFl].Caption = "����P��";

			dt.Columns.Add(Ct_CsLedgerDtl_SalesMoneyTaxExc, typeof( Int64 ));    // ������z�i�Ŕ����j
			dt.Columns[Ct_CsLedgerDtl_SalesMoneyTaxExc].Caption = "������z";

            dt.Columns.Add(Ct_CsLedgerDtl_SalesMoneyTaxExc1, typeof(Int64));    // ������z�i�����p�j
            dt.Columns[Ct_CsLedgerDtl_SalesMoneyTaxExc1].Caption = "������z�i�����p�j";

            dt.Columns.Add(Ct_CsLedgerDtl_SalsePriceConsTax, typeof(Int64));     // �����
            dt.Columns[Ct_CsLedgerDtl_SalsePriceConsTax].Caption = "������z�����";

            dt.Columns.Add(Ct_CsLedgerDtl_SalsePriceConsTax1, typeof(Int64));    // �����(�����p)
            dt.Columns[Ct_CsLedgerDtl_SalsePriceConsTax1].Caption = "������z�����(�����p)";

			dt.Columns.Add(Ct_CsLedgerDtl_PartySlipNumDtl, typeof( string ));    // �����`�[�ԍ��i���ׁj
			dt.Columns[Ct_CsLedgerDtl_PartySlipNumDtl].Caption = "�����`�[�ԍ�";

            dt.Columns.Add(Ct_CsLedgerDtl_UOERemark1, typeof(string)); // UOE���}�[�N1
            dt.Columns[Ct_CsLedgerDtl_UOERemark1].Caption = "���}�[�N1";

            dt.Columns.Add(Ct_CsLedgerDtl_UOERemark2, typeof(string)); // UOE���}�[�N2
            dt.Columns[Ct_CsLedgerDtl_UOERemark2].Caption = "���}�[�N1";

            dt.Columns.Add(Ct_CsLedgerDtl_SupplierCd, typeof(Int32));   // �d����R�[�h
            dt.Columns[Ct_CsLedgerDtl_SupplierCd].Caption = "�d����R�[�h";

            // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� >>>>>>START
            dt.Columns.Add(Ct_CsLedgerDtl_ConsTaxLayMethod, typeof(Int32));   // ����œ]�ŕ���
            dt.Columns[Ct_CsLedgerDtl_ConsTaxLayMethod].Caption = "����œ]�ŕ���";

            dt.Columns.Add(Ct_CsLedgerDtl_TaxationDivCd, typeof(Int32));   // �ېŋ敪
            dt.Columns[Ct_CsLedgerDtl_TaxationDivCd].Caption = "�ېŋ敪";
            // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� <<<<<<END
                                    
            #endregion

            ds.Tables.Add(dt);

            string sort = Ct_CsLedgerDtl_ClaimCode + "," + Ct_CsLedgerDtl_AddUpDate + "," + Ct_CsLedgerDtl_BalanseCode + "," + Ct_CsLedgerDtl_AddUpADateInt + "," + Ct_CsLedgerDtl_RecordCode + "," + Ct_CsLedgerDtl_SlipNo + "," + Ct_CsLedgerDtl_SalesRowNo;

			_csLedgerDtlDataTable	= dt;
			_csLedgerDtlDataView	= new DataView(_csLedgerDtlDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
		}
		#endregion



        #region �� �����Ɖ�p(�c���ꗗ��ʕ\���p)�e�[�u���X�L�[�}��`
        /// <summary>
        /// �����Ɖ�p(�c���ꗗ��ʕ\���p)�e�[�u���X�L�[�}��`
        /// </summary>
        /// <param name="ds"></param>
        public static void CreateTableSchemer_CsLedgerBalanceDataTable(ref DataSet ds)
        {
            DataTable dt = new DataTable(Ct_Tbl_CsLedgerBalanceDataTable);

            #region
            dt.Columns.Add(Ct_CsLedgerBlance_AddUpSecCode, typeof(string)); // �v�㋒�_�R�[�h
            dt.Columns[Ct_CsLedgerBlance_AddUpSecCode].Caption = "�v�㋒�_�R�[�h";

            dt.Columns.Add(Ct_CsLedgerBlance_AddUpSecName, typeof(string)); // �v�㋒�_����
            dt.Columns[Ct_CsLedgerBlance_AddUpSecName].Caption = "�v�㋒�_����";

            dt.Columns.Add(Ct_CsLedgerBlance_AddUpDate, typeof(DateTime)); // �v��N����
            dt.Columns[Ct_CsLedgerBlance_AddUpDate].Caption = "�v��N����";

            dt.Columns.Add(Ct_CsLedgerBlance_SlitTitle, typeof(string)); // ���[�^�C�g��
            dt.Columns[Ct_CsLedgerBlance_SlitTitle].Caption = "���[�^�C�g��";

            dt.Columns.Add(Ct_CsLedgerBlance_AddUpDateInt, typeof(Int32)); // �v��N����(Int)
            dt.Columns[Ct_CsLedgerBlance_AddUpDateInt].Caption = "�v��N����";

            dt.Columns.Add(Ct_CsLedgerBlance_AddUpYearMonth, typeof(Int32)); // �v��N��
            dt.Columns[Ct_CsLedgerBlance_AddUpYearMonth].Caption = "�v��N��";

            dt.Columns.Add(Ct_CsLedgerBlance_LastTimeDemand, typeof(Int64)); // �O�񐿋����z
            dt.Columns[Ct_CsLedgerBlance_LastTimeDemand].Caption = "�O�񐿋����z";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisTimeDmdNrml, typeof(Int64)); // ����������z�i�ʏ�����j
            dt.Columns[Ct_CsLedgerBlance_ThisTimeDmdNrml].Caption = "����������z�i�ʏ�����j";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisTimeTtlBlcDmd, typeof(Int64)); // ����J�z�c���i�����v�j
            dt.Columns[Ct_CsLedgerBlance_ThisTimeTtlBlcDmd].Caption = "����J�z�c���i�����v�j";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisTimeSales, typeof(Int64)); // ���񔄏���z
            dt.Columns[Ct_CsLedgerBlance_ThisTimeSales].Caption = "���񔄏���z";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisRgdsDis, typeof(Int64)); // �ԕi�E�l���z
            dt.Columns[Ct_CsLedgerBlance_ThisRgdsDis].Caption = "�ԕi�E�l���z";

            dt.Columns.Add(Ct_CsLedgerBlance_OfsThisTimeSales, typeof(Int64)); // ���E�㍡�񔄏���z
            dt.Columns[Ct_CsLedgerBlance_OfsThisTimeSales].Caption = "���E�㍡�񔄏���z";

            dt.Columns.Add(Ct_CsLedgerBlance_OfsThisSalesTax, typeof(Int64)); // ���E�㍡�񔄏�����
            dt.Columns[Ct_CsLedgerBlance_OfsThisSalesTax].Caption = "���E�㍡�񔄏�����";

            dt.Columns.Add(Ct_CsLedgerBlance_ThisSalesTaxTotal, typeof(Int64)); // �ō�����z
            dt.Columns[Ct_CsLedgerBlance_ThisSalesTaxTotal].Caption = "�ō�����z";

            dt.Columns.Add(Ct_CsLedgerBlance_ConsTaxLayMethod, typeof(Int32)); // ����œ]�ŕ���
            dt.Columns[Ct_CsLedgerBlance_ConsTaxLayMethod].Caption = "����œ]�ŕ���";

            dt.Columns.Add(Ct_CsLedgerBlance_ConsTaxLayMethodName, typeof(string)); // ����œ]�ŕ���
            dt.Columns[Ct_CsLedgerBlance_ConsTaxLayMethodName].Caption = "����œ]�ŕ���";

            dt.Columns.Add(Ct_CsLedgerBlance_AfCalDemandPrice, typeof(Int64)); // �v�Z�㐿�����z
            dt.Columns[Ct_CsLedgerBlance_AfCalDemandPrice].Caption = "�v�Z�㐿�����z";

            dt.Columns.Add(Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd, typeof(Int64)); // ��2��O�c���i�����v�j
            dt.Columns[Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd].Caption = "��2��O�c���i�����v�j";

            dt.Columns.Add(Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd, typeof(Int64)); // ��3��O�c���i�����v�j
            dt.Columns[Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd].Caption = "��3��O�c���i�����v�j";

            dt.Columns.Add(Ct_CsLedgerBlance_CAddUpUpdExecDate, typeof(Int32)); // �����X�V���s�N����
            dt.Columns[Ct_CsLedgerBlance_CAddUpUpdExecDate].Caption = "�����X�V���s�N����";

            dt.Columns.Add(Ct_CsLedgerBlance_CloseFlag, typeof(Int32)); // ���������ʔ�
            dt.Columns[Ct_CsLedgerBlance_CloseFlag].Caption = "���σt���O";

            dt.Columns.Add(Ct_CsLedgerBlance_StartDateSpan, typeof(Int32)); // ���t�͈́i�J�n�j
            dt.Columns[Ct_CsLedgerBlance_StartDateSpan].Caption = "���t�͈́i�J�n�j";

            dt.Columns.Add(Ct_CsLedgerBlance_EndDateSpan, typeof(Int32)); // ���t�͈́i�I���j
            dt.Columns[Ct_CsLedgerBlance_EndDateSpan].Caption = "���t�͈́i�I���j";

            dt.Columns.Add(Ct_CsLedgerBlance_ClaimCode, typeof(Int32)); // ������R�[�h
            dt.Columns[Ct_CsLedgerBlance_ClaimCode].Caption = "������R�[�h";

            dt.Columns.Add(Ct_CsLedgerBlance_CustomerCode, typeof(Int32)); // ���Ӑ�R�[�h
            dt.Columns[Ct_CsLedgerBlance_CustomerCode].Caption = "���Ӑ�R�[�h";

            dt.Columns.Add(Ct_CsLedgerBlance_Name, typeof(string)); // ���Ӑ於��
            dt.Columns[Ct_CsLedgerBlance_Name].Caption = "���Ӑ於��";

            dt.Columns.Add(Ct_CsLedgerBlance_Name2, typeof(string)); // ���Ӑ於��2
            dt.Columns[Ct_CsLedgerBlance_Name2].Caption = "���Ӑ於��2";
            #endregion

            ds.Tables.Add(dt);

            string sort = Ct_CsLedgerBlance_AddUpSecCode + "," + Ct_CsLedgerBlance_ClaimCode + "," + Ct_CsLedgerBlance_AddUpDate;

            _csLedgerBlanceDataTable = dt;
            _csLedgerBlanceDataView = new DataView(_csLedgerBlanceDataTable, string.Empty, sort, DataViewRowState.CurrentRows);
        }
        #endregion

        #endregion �� Public Static Method

        #region �� Private Static Method
        #region �� KingetCall
        #region �� ����KINGET�R�[���֐�
        /// <summary>
		/// ����KINGET�R�[���֐�
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="startCustomerCode">�J�n���Ӑ�R�[�h</param>
        /// <param name="endCustomerCode">�I�����Ӑ�R�[�h</param>
        /// <param name="stratdt">�v��N��(�J�n)</param>
		/// <param name="enddt">�v��N��(�I��)</param>
		/// <param name="viewSectionCd">�\�����_�R�[�h</param>
		/// <param name="sectionCodeList">���_�R�[�h���X�g</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : ����KINGET���ďo���܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
        /// <br>Programer	: 30009 �a�J ���</br>
        /// <br>Date		: 2009.01.21</br>
        /// <br>Note		: �����[�g���ňꕔ�@�\(�d�q�����p�̏���)���폜���ꂽ�ׁA�Y�������̏������폜���܂���</br>
        /// <br>Note		: �܂��A���݂̃����[�g�ɍ��킹�������ɕύX���邽�߁A�ʃA�N�Z�X�N���X�ōs���Ă���������</br>
        /// <br>Note		: ���N���X�Ɉړ����܂���</br>
        /// </remarks>
        private static int SeiKingetCall(string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int stratdt, int enddt, string viewSectionCd, ArrayList sectionCodeList, int outMoneyDiv)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			ArrayList dmdprcList = null;
            Hashtable salesBTable = null;
            Hashtable salesHTable = null;
            Hashtable salesDTable = null;
            Hashtable depositHTable = null;

            // �S�Ђ�I��
            if ((sectionCodeList.Count == 1) && (sectionCodeList[0].ToString() == "0"))
            {
                sectionCodeList = null;
            }

			try
			{
				// ����KINGET�R�[��
				// �ʏ탂�[�h
                status = GetCustDmdPrcAcsSearch(out dmdprcList,
                    out salesBTable,
                    out salesHTable,
                    out salesDTable,
                    out depositHTable,
					enterpriseCode,
    				sectionCodeList,
					customerCode,
                    startCustomerCode,
                    endCustomerCode,
    				stratdt,
					enddt,
                    outMoneyDiv);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
								// ���Ӑ���ݒ�           
								CustDmdPrcWorkToCustomer(enterpriseCode, dmdprcList);

								// �������zDataTable�쐬
								foreach (CustDmdPrcInfGetWork csdmd in dmdprcList)
								{
									DataRow row = CustDmdPrcWorkToDataRow(csdmd);
									_custDmdPrcDataTable.Rows.Add(row);
								}

								// �v��͈͐ݒ�
								SetCustomerAddUpDateSpanAndAddUpDate(customerCode, viewSectionCd);

								// ����E�����E�c���f�[�^�e�[�u���ݒ�
                                SalesAndDepsitToDataTable(salesBTable, salesHTable, salesDTable, depositHTable, viewSectionCd, false);

								// �������[�N������ێ��p�ɐݒ�
								foreach (DictionaryEntry entry in depositHTable)
								{
									ArrayList arDeposit = entry.Value as ArrayList;

									if (arDeposit != null)
									{
										foreach (LedgerDepsitMainWork wk in arDeposit)
										{
											if (wk != null)
											{
                                                string key = string.Empty;
                                                key = wk.AddUpSecCode + "_" + wk.ClaimCode.ToString() + "_" + wk.CustomerCode.ToString() + "_" + String.Format("{0:D9}", wk.DepositSlipNo);
                                                if (!_depsitHTable.ContainsKey(key))
                                                {
                                                    //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                                    //(�{����D�N���X�Ɏ������ׂ�����)
                                                    //_depsitHTable.Add(key, wk.Clone());
                                                    LedgerDepsitMainWork wk2 = new LedgerDepsitMainWork();
                                                    wk2.AcptAnOdrStatus = wk.AcptAnOdrStatus;
                                                    wk2.AddUpADate = wk.AddUpADate;
                                                    wk2.AddUpSecCode = wk.AddUpSecCode.ToString();
                                                    wk2.ClaimCode = wk.ClaimCode;
                                                    wk2.ClaimName = wk.ClaimName.ToString();
                                                    wk2.ClaimName2 = wk.ClaimName2.ToString();
                                                    wk2.ClaimSnm = wk.ClaimSnm.ToString();
                                                    wk2.CustomerCode = wk.CustomerCode;
                                                    wk2.CustomerName = wk.CustomerName.ToString();
                                                    wk2.CustomerName2 = wk.CustomerName2.ToString();
                                                    wk2.CustomerSnm = wk.CustomerSnm.ToString();
                                                    wk2.Deposit = wk.Deposit;
                                                    wk2.DepositAgentCode = wk.DepositAgentCode.ToString();
                                                    wk2.DepositAgentNm = wk.DepositAgentNm.ToString();
                                                    wk2.DepositDate = wk.DepositDate;
                                                    wk2.DepositDebitNoteCd = wk.DepositDebitNoteCd;
                                                    wk2.DepositInputAgentCd = wk.DepositInputAgentCd.ToString();
                                                    wk2.DepositInputAgentNm = wk.DepositInputAgentNm.ToString();
                                                    wk2.DepositRowNo = wk.DepositRowNo;
                                                    wk2.DepositSlipNo = wk.DepositSlipNo;
                                                    wk2.EnterpriseCode = wk.EnterpriseCode.ToString();
                                                    wk2.InputDepositSecCd = wk.InputDepositSecCd.ToString();
                                                    wk2.MoneyKindCode = wk.MoneyKindCode;
                                                    wk2.MoneyKindDiv = wk.MoneyKindDiv;
                                                    wk2.MoneyKindName = wk.MoneyKindName.ToString();
                                                    wk2.Outline = wk.Outline.ToString();
                                                    wk2.SalesSlipNum = wk.SalesSlipNum.ToString();
                                                    wk2.UpdateSecCd = wk.UpdateSecCd.ToString();
                                                    wk2.ValidityTerm = wk.ValidityTerm;
                                                    _depsitHTable.Add(key, wk2);
                                                }
											}
										}
									}
								}
							break;
						}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						{
							break;
						}
					default:
						throw new CsLedgerException("�������̎擾�Ɏ��s���܂����B", status);
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				throw new CsLedgerException(ex.Message, status);
			}

			return status;
		}
		#endregion
        /// <summary>
        /// �������擾�����i�v��N���͈͎w��j
        /// </summary>
        /// <param name="custDmdPrcInfGetWorkList">���Ӑ搿�����z�N���X���[�N���X�g</param>
        /// <param name="ledgerSalesBlanceWorkHash">�����c�����e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerSalesSlipWorkHash">�������e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerSalesDtlWorkHash">������񖾍׃e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerDepsitMainWorkHash">�������e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">�v�㋒�_�R�[�h���X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="startCustomerCode">�J�n���Ӑ�R�[�h</param>
        /// <param name="endCustomerCode">�I�����Ӑ�R�[�h</param>
        /// <param name="startAddUpYearMonth">�v��N���i�J�n�j(YYYYMM)</param>
        /// <param name="endAddUpYearMonth">�v��N���i�I���j(YYYYMM)</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����p�����[�^�̓��e�œ��Ӑ搿�������擾���܂��B
        ///                : ��ɓ��Ӑ挳���ɂĎg�p���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Update Note: 2014/02/26 �c����</br>
        /// <br>           : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// </remarks>
        private static int GetCustDmdPrcAcsSearch(out ArrayList custDmdPrcInfGetWorkList, out Hashtable ledgerSalesBlanceWorkHash, out Hashtable ledgerSalesSlipWorkHash, out Hashtable ledgerSalesDtlWorkHash, out Hashtable ledgerDepsitMainWorkHash,
            string enterpriseCode, ArrayList addUpSecCodeList, int customerCode, int startCustomerCode, int endCustomerCode, int startAddUpYearMonth, int endAddUpYearMonth, int outMoneyDiv)
        {
            // �������擾���o�����p�����[�^�N���X����
            CustDmdPrcInfSearchParameter parameter = new CustDmdPrcInfSearchParameter();
            parameter.EnterpriseCode = enterpriseCode;

            if (addUpSecCodeList != null)
            {
                parameter.AddUpSecCodeList = (string[])addUpSecCodeList.ToArray(typeof(string));
            }
            parameter.StartCustomerCode = startCustomerCode;
            parameter.EndCustomerCode = endCustomerCode;
            parameter.StartAddUpYearMonth = DateTime.ParseExact(startAddUpYearMonth.ToString(), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            parameter.EndAddUpYearMonth = DateTime.ParseExact(endAddUpYearMonth.ToString(), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            // ������񌟍�����
            //return GetCustDmdPrcAcsSearchDB(out custDmdPrcInfGetWorkList, out ledgerSalesBlanceWorkHash, out ledgerSalesSlipWorkHash, out ledgerSalesDtlWorkHash, out ledgerDepsitMainWorkHash, parameter);// DEL 2014/02/26 �c���� Redmine#42188
            return GetCustDmdPrcAcsSearchDB(out custDmdPrcInfGetWorkList, out ledgerSalesBlanceWorkHash, out ledgerSalesSlipWorkHash, out ledgerSalesDtlWorkHash, out ledgerDepsitMainWorkHash, parameter, outMoneyDiv);// ADD 2014/02/26 �c���� Redmine#42188
        }

        /// <summary>
        /// ������񌟍�����
        /// </summary>
        /// <param name="custDmdPrcInfGetWorkList">���Ӑ搿�����z�N���X���[�N���X�g</param>
        /// <param name="ledgerSalesBlanceWorkHash">�c�����e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerSalesSlipWorkHash">������e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerSalesDtlWorkHash">���㖾�׏��e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerDepsitMainWorkHash">�������e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="parameter">�������擾���o�����p�����[�^�N���X</param>
        /// <param name="outMoneyDiv">outMoneyDiv</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : ���������擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Programer	: 30009 �a�J ���</br>
        /// <br>Date		: 2009.01.21</br>
        /// <br>Update Note: 2014/02/26 �c����</br>
        /// <br>           : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// <br>UpdateNote : 2015/09/21 �c�v�t</br>
        /// <br>           : Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br> 
        /// </remarks>
        private static int GetCustDmdPrcAcsSearchDB(out ArrayList custDmdPrcInfGetWorkList, out Hashtable ledgerSalesBlanceWorkHash, out Hashtable ledgerSalesSlipWorkHash, out Hashtable ledgerSalesDtlWorkHash, out Hashtable ledgerDepsitMainWorkHash,
            //CustDmdPrcInfSearchParameter parameter)// DEL 2014/02/26 �c���� Redmine#42188
            CustDmdPrcInfSearchParameter parameter, int outMoneyDiv)// ADD 2014/02/26 �c���� Redmine#42188
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custDmdPrcInfGetWorkList = null;
            ledgerSalesBlanceWorkHash = null;
            ledgerSalesSlipWorkHash = null;
            ledgerSalesDtlWorkHash = null;
            ledgerDepsitMainWorkHash = null;

            try
            {
                // �����[�g�߂�l�錾
                object objCustDmdPrcInfGetWorkList = null;
                object objLedgerSalesSlipWorkList = null;
                object objLedgerSalesDtlWorkList = null;
                object objLedgerDepsitMainWorkList = null;
                object objCustDmdPrcInfGetWorkList2 = null;            //DMY
                object objLedgerDepsitMainWorkList2 = null;            //DMY

                // �������擾����
                status = _iCustDmdPrcInfGetDB.SearchSlip(out objCustDmdPrcInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, parameter);
                status2 = _iCustDmdPrcInfGetDB.SearchDtl(out objCustDmdPrcInfGetWorkList2, out objLedgerSalesDtlWorkList, out objLedgerDepsitMainWorkList2, parameter);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status2;

                // �擾�����f�[�^
                custDmdPrcInfGetWorkList = objCustDmdPrcInfGetWorkList as ArrayList;
                ArrayList ledgerSalesBlanceWorkList = objCustDmdPrcInfGetWorkList as ArrayList;
                ArrayList ledgerSalesSlipWorkList = objLedgerSalesSlipWorkList as ArrayList;
                ArrayList ledgerSalesDtlWorkList = objLedgerSalesDtlWorkList as ArrayList;
                ArrayList ledgerDepsitMainWorkList = objLedgerDepsitMainWorkList as ArrayList;

                // ���Ӑ搿�����z��񃊃X�g���������͔�����
                if (custDmdPrcInfGetWorkList == null) return status;

                ledgerSalesBlanceWorkHash = new Hashtable();
                ledgerSalesSlipWorkHash = new Hashtable();
                ledgerSalesDtlWorkHash = new Hashtable();
                ledgerDepsitMainWorkHash = new Hashtable();

                int ledgerSalesBlanceWorkCounter = 0;
                int ledgerSalesSlipWorkCounter = 0;
                int ledgerSalesDtlWorkCounter = 0;
                int ledgerDepsitMainWorkCounter = 0;

                // ---ADD 2014/02/26 �c���� Redmine#42188---->>>>>
                List<CustDmdPrcInfGetWork> custDmdPrcInfGetDelList = new List<CustDmdPrcInfGetWork>();

                bool salesSlipFlag = false;
                bool salesSalesDtl = false;
                bool salesDepsitMain = false;
                // ---ADD 2014/02/26 �c���� Redmine#42188----<<<<<

                // �擾�������Ӑ搿�����z��񃊃X�g���܂킷
                foreach (CustDmdPrcInfGetWork custDmdPrcInfGetWork in custDmdPrcInfGetWorkList)
                {
                    // ---ADD 2014/02/26 �c���� Redmine#42188---->>>>>
                    salesSlipFlag = false;
                    salesSalesDtl = false;
                    salesDepsitMain = false;
                    // ---ADD 2014/02/26 �c���� Redmine#42188----<<<<<

                    // �c�������擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerSalesBlanceWorkList != null) && (ledgerSalesBlanceWorkList.Count > 0))
                    {
                        // �擾�����c���f�[�^���܂킷
                        foreach (CustDmdPrcInfGetWork ledgerSalesBlanceWork in ledgerSalesBlanceWorkList)
                        {
                            // �c���f�[�^�̌v����t���擾                                
                            DateTime workAddUpADate = ledgerSalesBlanceWork.AddUpDate;

                            // �v�㋒�_������ŁA����f�[�^�̌v����t�����Ӑ搿�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                            if ((ledgerSalesBlanceWork.AddUpSecCode.TrimEnd() == custDmdPrcInfGetWork.AddUpSecCode.TrimEnd()) &&
                                (ledgerSalesBlanceWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&
                                (workAddUpADate >= custDmdPrcInfGetWork.LastCAddUpUpdDate) &&
                                (workAddUpADate <= custDmdPrcInfGetWork.AddUpDate))
                            {
                                int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpDate);

                                // Hashtable�ɓ���̌v����t���������͍쐬
                                if (!ledgerSalesBlanceWorkHash.Contains(addUpDate)) ledgerSalesBlanceWorkHash.Add(addUpDate, new ArrayList());

                                // ���Ӑ搿�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�ɔ���f�[�^��ArrayList�ɂ��ĂԂ牺����
                                ArrayList list = (ArrayList)ledgerSalesBlanceWorkHash[addUpDate];
                                //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                //(�{����D�N���X�Ɏ������ׂ�����)
                                //list.Add(ledgerSalesBlanceWork.Clone());
                                CustDmdPrcInfGetWork wk = new CustDmdPrcInfGetWork();
                                wk.AcpOdrTtl2TmBfBlDmd = ledgerSalesBlanceWork.AcpOdrTtl2TmBfBlDmd;
                                wk.AcpOdrTtl3TmBfBlDmd = ledgerSalesBlanceWork.AcpOdrTtl3TmBfBlDmd;
                                wk.AddUpDate = ledgerSalesBlanceWork.AddUpDate;
                                wk.AddUpSecCode = ledgerSalesBlanceWork.AddUpSecCode;
                                wk.AddUpYearMonth = ledgerSalesBlanceWork.AddUpYearMonth;
                                wk.AfCalDemandPrice = ledgerSalesBlanceWork.AfCalDemandPrice;
                                wk.BalanceAdjust = ledgerSalesBlanceWork.BalanceAdjust;
                                wk.CAddUpUpdExecDate = ledgerSalesBlanceWork.CAddUpUpdExecDate;
                                wk.ClaimCode = ledgerSalesBlanceWork.ClaimCode;
                                wk.ClaimName = ledgerSalesBlanceWork.ClaimName.ToString();
                                wk.ClaimName2 = ledgerSalesBlanceWork.ClaimName2.ToString();
                                wk.ClaimSnm = ledgerSalesBlanceWork.ClaimSnm.ToString();
                                wk.CloseFlg = ledgerSalesBlanceWork.CloseFlg;
                                wk.ConsTaxLayMethod = ledgerSalesBlanceWork.ConsTaxLayMethod;
                                wk.CustomerCode = ledgerSalesBlanceWork.CustomerCode;
                                wk.CustomerName = ledgerSalesBlanceWork.CustomerName.ToString();
                                wk.CustomerName2 = ledgerSalesBlanceWork.CustomerName2.ToString();
                                wk.CustomerSnm = ledgerSalesBlanceWork.CustomerSnm.ToString();
                                wk.EnterpriseCode = ledgerSalesBlanceWork.EnterpriseCode.ToString();
                                wk.LastCAddUpUpdDate = ledgerSalesBlanceWork.LastCAddUpUpdDate;
                                wk.LastTimeDemand = ledgerSalesBlanceWork.LastTimeDemand;
                                wk.OfsThisSalesTax = ledgerSalesBlanceWork.OfsThisSalesTax;
                                wk.OfsThisTimeSales = ledgerSalesBlanceWork.OfsThisTimeSales;
                                wk.ResultsSectCd = ledgerSalesBlanceWork.ResultsSectCd.ToString();
                                wk.SalesSlipCount = ledgerSalesBlanceWork.SalesSlipCount;
                                wk.StartCAddUpUpdDate = ledgerSalesBlanceWork.StartCAddUpUpdDate;
                                wk.TaxAdjust = ledgerSalesBlanceWork.TaxAdjust;
                                wk.ThisSalesPrcTaxDis = ledgerSalesBlanceWork.ThisSalesPrcTaxDis;
                                wk.ThisSalesPrcTaxRgds = ledgerSalesBlanceWork.ThisSalesPrcTaxRgds;
                                wk.ThisSalesPricDis = ledgerSalesBlanceWork.ThisSalesPricDis;
                                wk.ThisSalesPricRgds = ledgerSalesBlanceWork.ThisSalesPricRgds;
                                wk.ThisSalesTax = ledgerSalesBlanceWork.ThisSalesTax;
                                wk.ThisTimeDmdNrml = ledgerSalesBlanceWork.ThisTimeDmdNrml;
                                wk.ThisTimeSales = ledgerSalesBlanceWork.ThisTimeSales;
                                wk.ThisTimeTtlBlcDmd = ledgerSalesBlanceWork.ThisTimeTtlBlcDmd;
                                list.Add(wk);
                              
                                ledgerSalesBlanceWorkCounter++;
                            }
                        }
                    }

                    // ����f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerSalesSlipWorkList != null) && (ledgerSalesSlipWorkList.Count > 0))
                    {
                        // �擾��������f�[�^���܂킷
                        foreach (ArrayList arrayList in ledgerSalesSlipWorkList)
                        {
                            foreach (LedgerSalesSlipWork ledgerSalesSlipWork in arrayList)
                            {
                                // ����f�[�^�̌v����t���擾
                                DateTime workAddUpADate = ledgerSalesSlipWork.AddUpADate;

                                // �v�㋒�_������ŁA����f�[�^�̌v����t�����Ӑ搿�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
                                //if ((ledgerSalesSlipWork.DemandAddUpSecCd.TrimEnd() == custDmdPrcInfGetWork.AddUpSecCode.TrimEnd()) &&
                                //    (ledgerSalesSlipWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&
                                // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
                                if ((ledgerSalesSlipWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&            // ADD 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�
                                    (workAddUpADate >= custDmdPrcInfGetWork.LastCAddUpUpdDate) &&
                                    (workAddUpADate <= custDmdPrcInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!ledgerSalesSlipWorkHash.Contains(addUpDate)) ledgerSalesSlipWorkHash.Add(addUpDate, new ArrayList());

                                    // ���Ӑ搿�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�ɔ���f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)ledgerSalesSlipWorkHash[addUpDate];
                                    //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                    //(�{����D�N���X�Ɏ������ׂ�����)
                                    //list.Add(ledgerSalesSlipWork.Clone());
                                    LedgerSalesSlipWork wk = new LedgerSalesSlipWork();
                                    wk.AccRecDivCd = ledgerSalesSlipWork.AccRecDivCd;
                                    wk.AcptAnOdrStatus = ledgerSalesSlipWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerSalesSlipWork.AddUpADate;
                                    wk.ClaimCode = ledgerSalesSlipWork.ClaimCode;
                                    wk.ClaimSnm = ledgerSalesSlipWork.ClaimSnm.ToString();
                                    wk.CustomerCode = ledgerSalesSlipWork.CustomerCode;
                                    wk.CustomerName = ledgerSalesSlipWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerSalesSlipWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerSalesSlipWork.CustomerSnm.ToString();
                                    wk.DebitNLnkSalesSlNum = ledgerSalesSlipWork.DebitNLnkSalesSlNum.ToString();
                                    wk.DebitNoteDiv = ledgerSalesSlipWork.DebitNoteDiv;
                                    wk.DemandAddUpSecCd = ledgerSalesSlipWork.DemandAddUpSecCd.ToString();
                                    wk.EnterpriseCode = ledgerSalesSlipWork.EnterpriseCode.ToString();
                                    wk.FrontEmployeeCd = ledgerSalesSlipWork.FrontEmployeeCd.ToString();
                                    wk.FrontEmployeeNm = ledgerSalesSlipWork.FrontEmployeeNm.ToString();
                                    wk.HonorificTitle = ledgerSalesSlipWork.HonorificTitle.ToString();
                                    wk.InputAgenCd = ledgerSalesSlipWork.InputAgenCd.ToString();
                                    wk.InputAgenNm = ledgerSalesSlipWork.InputAgenNm.ToString();
                                    wk.PartySaleSlipNum = ledgerSalesSlipWork.PartySaleSlipNum.ToString();
                                    wk.ResultsAddUpSecCd = ledgerSalesSlipWork.ResultsAddUpSecCd.ToString();
                                    wk.SalesDate = ledgerSalesSlipWork.SalesDate;
                                    wk.SalesEmployeeCd = ledgerSalesSlipWork.SalesEmployeeCd.ToString();
                                    wk.SalesEmployeeNm = ledgerSalesSlipWork.SalesEmployeeNm.ToString();
                                    wk.SalesGoodsCd = ledgerSalesSlipWork.SalesGoodsCd;
                                    wk.SalesInpSecCd = ledgerSalesSlipWork.SalesInpSecCd.ToString();
                                    wk.SalesInputCode = ledgerSalesSlipWork.SalesInputCode.ToString();
                                    wk.SalesInputName = ledgerSalesSlipWork.SalesInputName.ToString();
                                    wk.SalesSlipCd = ledgerSalesSlipWork.SalesSlipCd;
                                    wk.SalesSlipNum = ledgerSalesSlipWork.SalesSlipNum.ToString();
                                    wk.SalesSubtotalTax = ledgerSalesSlipWork.SalesSubtotalTax;
                                    wk.SalesSubtotalTaxExc = ledgerSalesSlipWork.SalesSubtotalTaxExc;
                                    wk.SalesSubtotalTaxInc = ledgerSalesSlipWork.SalesSubtotalTaxInc;
                                    wk.SearchSlipDate = ledgerSalesSlipWork.SearchSlipDate;
                                    wk.SectionCode = ledgerSalesSlipWork.SectionCode.ToString();
                                    wk.ShipmentDay = ledgerSalesSlipWork.ShipmentDay;
                                    wk.SlipNote = ledgerSalesSlipWork.SlipNote.ToString();
                                    wk.SlipNote2 = ledgerSalesSlipWork.SlipNote2.ToString();
                                    wk.SlipNote3 = ledgerSalesSlipWork.SlipNote3.ToString();
                                    wk.UoeRemark1 = ledgerSalesSlipWork.UoeRemark1.ToString();
                                    wk.UoeRemark2 = ledgerSalesSlipWork.UoeRemark2.ToString();
                                    wk.UpdateSecCd = ledgerSalesSlipWork.UpdateSecCd.ToString();
                                    // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� >>>>>>START
                                    wk.ConsTaxLayMethod = ledgerSalesSlipWork.ConsTaxLayMethod;
                                    // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� <<<<<<END
                                    // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� >>>>>>START
                                    wk.SalesTotalTaxExc = ledgerSalesSlipWork.SalesTotalTaxExc;
                                    // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� <<<<<<END
                                    list.Add(wk);
                                    ledgerSalesSlipWorkCounter++;
                                    salesSlipFlag = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // ���㖾�׃f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerSalesDtlWorkList != null) && (ledgerSalesDtlWorkList.Count > 0))
                    {
                        // �擾��������f�[�^���܂킷
                        foreach (ArrayList arrayList in ledgerSalesDtlWorkList)
                        {
                            foreach (LedgerSalesDetailWork ledgerSalesDtlWork in arrayList)
                            {
                                // ����f�[�^�̌v����t���擾
                                DateTime workAddUpADate = ledgerSalesDtlWork.AddUpADate;

                                // �v�㋒�_������ŁA����f�[�^�̌v����t�����Ӑ搿�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
                                //if ((ledgerSalesDtlWork.DemandAddUpSecCd.TrimEnd() == custDmdPrcInfGetWork.AddUpSecCode.TrimEnd()) &&
                                //    (ledgerSalesDtlWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&
                                // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
                                if ((ledgerSalesDtlWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&       // ADD 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�         
                                    (workAddUpADate >= custDmdPrcInfGetWork.LastCAddUpUpdDate) &&
                                    (workAddUpADate <= custDmdPrcInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!ledgerSalesDtlWorkHash.Contains(addUpDate)) ledgerSalesDtlWorkHash.Add(addUpDate, new ArrayList());

                                    // ���Ӑ搿�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�ɔ���f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)ledgerSalesDtlWorkHash[addUpDate];
                                    //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                    //(�{����D�N���X�Ɏ������ׂ�����)
                                    //list.Add(ledgerSalesDtlWork.Clone());
                                    LedgerSalesDetailWork wk = new LedgerSalesDetailWork();
                                    wk.AccRecDivCd = ledgerSalesDtlWork.AccRecDivCd;
                                    wk.AcptAnOdrStatus = ledgerSalesDtlWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerSalesDtlWork.AddUpADate;
                                    wk.ClaimCode = ledgerSalesDtlWork.ClaimCode;
                                    wk.ClaimSnm = ledgerSalesDtlWork.ClaimSnm.ToString();
                                    wk.CommonSeqNo = ledgerSalesDtlWork.CommonSeqNo;
                                    wk.CustomerCode = ledgerSalesDtlWork.CustomerCode;
                                    wk.CustomerName = ledgerSalesDtlWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerSalesDtlWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerSalesDtlWork.CustomerSnm.ToString();
                                    wk.DebitNLnkSalesSlNum = ledgerSalesDtlWork.DebitNLnkSalesSlNum.ToString();
                                    wk.DebitNoteDiv = ledgerSalesDtlWork.DebitNoteDiv;
                                    wk.DemandAddUpSecCd = ledgerSalesDtlWork.DemandAddUpSecCd.ToString();
                                    wk.EnterpriseCode = ledgerSalesDtlWork.EnterpriseCode.ToString();
                                    wk.FrontEmployeeCd = ledgerSalesDtlWork.FrontEmployeeCd.ToString();
                                    wk.FrontEmployeeNm = ledgerSalesDtlWork.FrontEmployeeNm.ToString();
                                    wk.GoodsName = ledgerSalesDtlWork.GoodsName.ToString();
                                    wk.GoodsNameKana = ledgerSalesDtlWork.GoodsNameKana.ToString();
                                    wk.GoodsNo = ledgerSalesDtlWork.GoodsNo.ToString();
                                    wk.HonorificTitle = ledgerSalesDtlWork.HonorificTitle.ToString();
                                    wk.InputAgenCd = ledgerSalesDtlWork.InputAgenCd.ToString();
                                    wk.InputAgenNm = ledgerSalesDtlWork.InputAgenNm.ToString();
                                    wk.PartySaleSlipNum = ledgerSalesDtlWork.PartySaleSlipNum.ToString();
                                    wk.ResultsAddUpSecCd = ledgerSalesDtlWork.ResultsAddUpSecCd.ToString();
                                    wk.SalesDate = ledgerSalesDtlWork.SalesDate;
                                    wk.SalesEmployeeCd = ledgerSalesDtlWork.SalesEmployeeCd.ToString();
                                    wk.SalesEmployeeNm = ledgerSalesDtlWork.SalesEmployeeNm.ToString();
                                    wk.SalesGoodsCd = ledgerSalesDtlWork.SalesGoodsCd;
                                    wk.SalesInpSecCd = ledgerSalesDtlWork.SalesInpSecCd.ToString();
                                    wk.SalesInputCode = ledgerSalesDtlWork.SalesInputCode.ToString();
                                    wk.SalesInputName = ledgerSalesDtlWork.SalesInputName.ToString();
                                    wk.SalesMoneyTaxExc = ledgerSalesDtlWork.SalesMoneyTaxExc;
                                    wk.SalesPriceConsTax = ledgerSalesDtlWork.SalesPriceConsTax;
                                    wk.SalesRowDerivNo = ledgerSalesDtlWork.SalesRowDerivNo;
                                    wk.SalesRowNo = ledgerSalesDtlWork.SalesRowNo;
                                    wk.SalesSlipCd = ledgerSalesDtlWork.SalesSlipCd;
                                    wk.SalesSlipDtlNum = ledgerSalesDtlWork.SalesSlipDtlNum;
                                    wk.SalesSlipNum = ledgerSalesDtlWork.SalesSlipNum.ToString();
                                    wk.SalesSubtotalTax = ledgerSalesDtlWork.SalesSubtotalTax;
                                    wk.SalesSubtotalTaxExc = ledgerSalesDtlWork.SalesSubtotalTaxExc;
                                    wk.SalesSubtotalTaxInc = ledgerSalesDtlWork.SalesSubtotalTaxInc;
                                    wk.SalesUnPrcTaxExcFl = ledgerSalesDtlWork.SalesUnPrcTaxExcFl;
                                    wk.SearchSlipDate = ledgerSalesDtlWork.SearchSlipDate;
                                    wk.SectionCode = ledgerSalesDtlWork.SectionCode.ToString();
                                    wk.ShipmentCnt = ledgerSalesDtlWork.ShipmentCnt;
                                    wk.ShipmentDay = ledgerSalesDtlWork.ShipmentDay;
                                    wk.SlipNote = ledgerSalesDtlWork.SlipNote.ToString();
                                    wk.SlipNote2 = ledgerSalesDtlWork.SlipNote2.ToString();
                                    wk.SlipNote3 = ledgerSalesDtlWork.SlipNote3.ToString();
                                    wk.SupplierCd = ledgerSalesDtlWork.SupplierCd;
                                    wk.SupplierSnm = ledgerSalesDtlWork.SupplierSnm.ToString();
                                    wk.UoeRemark1 = ledgerSalesDtlWork.UoeRemark1.ToString();
                                    wk.UoeRemark2 = ledgerSalesDtlWork.UoeRemark2.ToString();
                                    wk.UpdateSecCd = ledgerSalesDtlWork.UpdateSecCd.ToString();
                                    // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� >>>>>>START
                                    wk.ConsTaxLayMethod = ledgerSalesDtlWork.ConsTaxLayMethod;
                                    wk.TaxationDivCd = ledgerSalesDtlWork.TaxationDivCd;
                                    // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� <<<<<<END
                                    list.Add(wk);
                                    ledgerSalesDtlWorkCounter++;
                                    salesSalesDtl = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // �����f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerDepsitMainWorkList != null) && (ledgerDepsitMainWorkList.Count > 0))
                    {
                        // �擾���������f�[�^���܂킷
                        foreach (ArrayList arrayList in ledgerDepsitMainWorkList)
                        {
                            foreach (LedgerDepsitMainWork ledgerDepsitMainWork in arrayList)
                            {
                                // �����f�[�^�̌v����t���擾
                                DateTime workAddUpADate = ledgerDepsitMainWork.AddUpADate;

                                // �v�㋒�_������ŁA�����f�[�^�̌v����t�����Ӑ搿�����z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                if ((ledgerDepsitMainWork.AddUpSecCode.TrimEnd() == custDmdPrcInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    (ledgerDepsitMainWork.ClaimCode == custDmdPrcInfGetWork.ClaimCode) &&
                                    (workAddUpADate >= custDmdPrcInfGetWork.LastCAddUpUpdDate) &&
                                    (workAddUpADate <= custDmdPrcInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!ledgerDepsitMainWorkHash.Contains(addUpDate)) ledgerDepsitMainWorkHash.Add(addUpDate, new ArrayList());

                                    // ���Ӑ搿�����z�}�X�^�̌v��N������KEY�ɂ���Hashtable�ɓ����f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)ledgerDepsitMainWorkHash[addUpDate];
                                    //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                    //(�{����D�N���X�Ɏ������ׂ�����)
                                    //list.Add(ledgerDepsitMainWork.Clone());
                                    LedgerDepsitMainWork wk2 = new LedgerDepsitMainWork();
                                    wk2.AcptAnOdrStatus = ledgerDepsitMainWork.AcptAnOdrStatus;
                                    wk2.AddUpADate = ledgerDepsitMainWork.AddUpADate;
                                    wk2.AddUpSecCode = ledgerDepsitMainWork.AddUpSecCode.ToString();
                                    wk2.ClaimCode = ledgerDepsitMainWork.ClaimCode;
                                    wk2.ClaimName = ledgerDepsitMainWork.ClaimName.ToString();
                                    wk2.ClaimName2 = ledgerDepsitMainWork.ClaimName2.ToString();
                                    wk2.ClaimSnm = ledgerDepsitMainWork.ClaimSnm.ToString();
                                    wk2.CustomerCode = ledgerDepsitMainWork.CustomerCode;
                                    wk2.CustomerName = ledgerDepsitMainWork.CustomerName.ToString();
                                    wk2.CustomerName2 = ledgerDepsitMainWork.CustomerName2.ToString();
                                    wk2.CustomerSnm = ledgerDepsitMainWork.CustomerSnm.ToString();
                                    wk2.Deposit = ledgerDepsitMainWork.Deposit;
                                    wk2.DepositAgentCode = ledgerDepsitMainWork.DepositAgentCode.ToString();
                                    wk2.DepositAgentNm = ledgerDepsitMainWork.DepositAgentNm.ToString();
                                    wk2.DepositDate = ledgerDepsitMainWork.DepositDate;
                                    wk2.DepositDebitNoteCd = ledgerDepsitMainWork.DepositDebitNoteCd;
                                    wk2.DepositInputAgentCd = ledgerDepsitMainWork.DepositInputAgentCd.ToString();
                                    wk2.DepositInputAgentNm = ledgerDepsitMainWork.DepositInputAgentNm.ToString();
                                    wk2.DepositRowNo = ledgerDepsitMainWork.DepositRowNo;
                                    wk2.DepositSlipNo = ledgerDepsitMainWork.DepositSlipNo;
                                    wk2.EnterpriseCode = ledgerDepsitMainWork.EnterpriseCode.ToString();
                                    wk2.InputDepositSecCd = ledgerDepsitMainWork.InputDepositSecCd.ToString();
                                    wk2.MoneyKindCode = ledgerDepsitMainWork.MoneyKindCode;
                                    wk2.MoneyKindDiv = ledgerDepsitMainWork.MoneyKindDiv;
                                    wk2.MoneyKindName = ledgerDepsitMainWork.MoneyKindName.ToString();
                                    wk2.Outline = ledgerDepsitMainWork.Outline.ToString();
                                    wk2.SalesSlipNum = ledgerDepsitMainWork.SalesSlipNum.ToString();
                                    wk2.UpdateSecCd = ledgerDepsitMainWork.UpdateSecCd.ToString();
                                    wk2.ValidityTerm = ledgerDepsitMainWork.ValidityTerm;
                                    list.Add(wk2);
                                    ledgerDepsitMainWorkCounter++;
                                    salesDepsitMain = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // -----ADD 2014/02/26 �c���� Redmine#42188 ----->>>>>
                    if (salesSlipFlag == false
                      && salesSalesDtl == false
                      && salesDepsitMain == false
                      && outMoneyDiv == 1
                      && custDmdPrcInfGetWork.LastTimeDemand == 0         // �O�񐿋����z
                      && custDmdPrcInfGetWork.AcpOdrTtl2TmBfBlDmd == 0    // ��2��O�c���i�����v�j
                      && custDmdPrcInfGetWork.AcpOdrTtl3TmBfBlDmd == 0)   // ��3��O�c���i�����v�j
                    {
                        custDmdPrcInfGetDelList.Add(custDmdPrcInfGetWork);
                    }
                    // -----ADD 2014/02/26 �c���� Redmine#42188 -----<<<<<
                }

                // -----ADD 2014/02/26 �c���� Redmine#42188 ------------------------->>>>>
                if (outMoneyDiv == 0) return status;
                // �S�ċ��z0�̏ꍇ�A������Ȃ�
                foreach (CustDmdPrcInfGetWork wkCustDmdPrcInfGet in custDmdPrcInfGetDelList)
                {

                    if (custDmdPrcInfGetWorkList.Contains(wkCustDmdPrcInfGet))
                    {
                        custDmdPrcInfGetWorkList.Remove(wkCustDmdPrcInfGet);
                    }
                }

                // �S�ăf�[�^�t�B���^������A�߂�X�e�[�^�X���ύX����
                if (custDmdPrcInfGetWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                // -----ADD 2014/02/26 �c���� Redmine#42188 -------------------------<<<<<

                return status;
            }
            catch (Exception e)
            {
                custDmdPrcInfGetWorkList = null;
                ledgerSalesBlanceWorkHash = null;
                ledgerSalesSlipWorkHash = null;
                ledgerSalesDtlWorkHash = null;
                ledgerDepsitMainWorkHash = null;
                _iCustDmdPrcInfGetDB = null;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new CsLedgerException(e.Message, status);

            }
        }

        #region �� ���|KINGET�R�[���֐�
		/// <summary>
		/// ���|KINGET�R�[���֐�
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="startCustomerCode">�J�n���Ӑ�R�[�h</param>
        /// <param name="endCustomerCode">�I�����Ӑ�R�[�h</param>
        /// <param name="stratdt">�v��N��(�J�n)</param>
		/// <param name="enddt">�v��N��(�I��)</param>
		/// <param name="viewSectionCd">�\�����_�R�[�h</param>
		/// <param name="sectionCodeList">���_�R�[�h���X�g</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : ���|KINGET���ďo���܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
        /// <br>Programer	: 30009 �a�J ���</br>
        /// <br>Date		: 2009.01.21</br>
        /// <br>Note		: �����[�g���ňꕔ�@�\(�d�q�����p�̏���)���폜���ꂽ�ׁA�Y�������̏������폜���܂���</br>
        /// <br>Note		: �܂��A���݂̃����[�g�ɍ��킹�������ɕύX���邽�߁A�ʃA�N�Z�X�N���X�ōs���Ă���������</br>
        /// <br>Note		: ���N���X�Ɉړ����܂���</br>
        /// </remarks>
        private static int UriKingetCall(string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int stratdt, int enddt, string viewSectionCd, ArrayList sectionCodeList, int outMoneyDiv)
        {
		    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

		    ArrayList accRecList = null;
            Hashtable salesBTable = null;
            Hashtable salesHTable = null;
            Hashtable salesDTable = null;
            Hashtable depositHTable = null;

            // �S�Ђ�I��
            if ((sectionCodeList.Count == 1) && (sectionCodeList[0].ToString() == "0"))
            {
                sectionCodeList = null;
            }

		    try
		    {
		        // ���|KINGET�R�[��
                status = getCustAccRecAcsSearch(out accRecList,
                out salesBTable,
                        out salesHTable,
                        out salesDTable,
                        out depositHTable,
   						enterpriseCode,
						sectionCodeList,
						customerCode,
                        startCustomerCode,
                        endCustomerCode,
						stratdt,
						enddt,
                        outMoneyDiv);
		        switch (status)
		        {
		            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		                {
								// ���Ӑ���ݒ�           
								CustAccRecWorkToCustomer(enterpriseCode, accRecList);

								// �������zDataTable�쐬
								foreach ( CustAccRecInfGetWork csAccRec in accRecList )
								{
								    DataRow row = CustAccRecWorkToDataRow(csAccRec);
								    _custDmdPrcDataTable.Rows.Add(row);
								}

								// �v��͈͐ݒ�
								SetCustomerAddUpDateSpanAndAddUpDate(customerCode, viewSectionCd);

								// ����E�����f�[�^�e�[�u���ݒ�
                                SalesAndDepsitToDataTable(salesBTable, salesHTable, salesDTable, depositHTable, viewSectionCd, false);

								// �������[�N������ێ��p�ɐݒ�
								foreach ( DictionaryEntry entry in depositHTable )
								{
									ArrayList arDeposit = entry.Value as ArrayList;

									if ( arDeposit != null )
									{
										foreach ( LedgerDepsitMainWork wk in arDeposit )
										{
											if ( wk != null )
											{
                                                string key = string.Empty;
                                                key = wk.AddUpSecCode + "_" + wk.ClaimCode.ToString() + "_" + wk.CustomerCode.ToString() + "_" + String.Format("{0:D9}", wk.DepositSlipNo);
                                                if (!_depsitHTable.ContainsKey(key))
                                                {    
                                                    //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                                    //(�{����D�N���X�Ɏ������ׂ�����)
                                                    //_depsitHTable.Add(key, wk.Clone());
                                                    LedgerDepsitMainWork wk2 = new LedgerDepsitMainWork();
                                                    wk2.AcptAnOdrStatus = wk.AcptAnOdrStatus;
                                                    wk2.AddUpADate = wk.AddUpADate;
                                                    wk2.AddUpSecCode = wk.AddUpSecCode.ToString();
                                                    wk2.ClaimCode = wk.ClaimCode;
                                                    wk2.ClaimName = wk.ClaimName.ToString();
                                                    wk2.ClaimName2 = wk.ClaimName2.ToString();
                                                    wk2.ClaimSnm = wk.ClaimSnm.ToString();
                                                    wk2.CustomerCode = wk.CustomerCode;
                                                    wk2.CustomerName = wk.CustomerName.ToString();
                                                    wk2.CustomerName2 = wk.CustomerName2.ToString();
                                                    wk2.CustomerSnm = wk.CustomerSnm.ToString();
                                                    wk2.Deposit = wk.Deposit;
                                                    wk2.DepositAgentCode = wk.DepositAgentCode.ToString();
                                                    wk2.DepositAgentNm = wk.DepositAgentNm.ToString();
                                                    wk2.DepositDate = wk.DepositDate;
                                                    wk2.DepositDebitNoteCd = wk.DepositDebitNoteCd;
                                                    wk2.DepositInputAgentCd = wk.DepositInputAgentCd.ToString();
                                                    wk2.DepositInputAgentNm = wk.DepositInputAgentNm.ToString();
                                                    wk2.DepositRowNo = wk.DepositRowNo;
                                                    wk2.DepositSlipNo = wk.DepositSlipNo;
                                                    wk2.EnterpriseCode = wk.EnterpriseCode.ToString();
                                                    wk2.InputDepositSecCd = wk.InputDepositSecCd.ToString();
                                                    wk2.MoneyKindCode = wk.MoneyKindCode;
                                                    wk2.MoneyKindDiv = wk.MoneyKindDiv;
                                                    wk2.MoneyKindName = wk.MoneyKindName.ToString();
                                                    wk2.Outline = wk.Outline.ToString();
                                                    wk2.SalesSlipNum = wk.SalesSlipNum.ToString();
                                                    wk2.UpdateSecCd = wk.UpdateSecCd.ToString();
                                                    wk2.ValidityTerm = wk.ValidityTerm;
                                                    _depsitHTable.Add(key, wk2);

                                                }
											}
										}
									}
								}
		                    break;
		                }
		            case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		            case (int)ConstantManagement.DB_Status.ctDB_EOF:
		                {
		                    break;
		                }
		            default:
		                throw new CsLedgerException("���|���̎擾�Ɏ��s���܂����B", status);
		        }
		    }
            // --- ADD 2014/02/20 T.Miyamoto ------------------------------>>>>>
            catch (CsLedgerException ex)
            {
                throw new CsLedgerException(ex.Message, ex.Status);
            }
            // --- ADD 2014/02/20 T.Miyamoto ------------------------------<<<<<
		    catch ( Exception ex )
		    {
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
		        throw new CsLedgerException(ex.Message, status);
		    }
		    return status;
		}
		#endregion

        /// <summary>
        /// ���|���擾�����i�v��N���͈͎w��j
        /// </summary>
        /// <param name="custAccRecInfGetWorkList">���Ӑ攄�|���z�N���X���[�N���X�g</param>
        /// <param name="ledgerSalesBlanceWorkHash">���|�c�����e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerSalesSlipWorkHash">���|���e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerSalesDtlWorkHash">���|���e�[�u��(����)(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerDepsitMainWorkHash">�������e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="addUpSecCodeList">�v�㋒�_�R�[�h���X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="startCustomerCode">�J�n���Ӑ�R�[�h</param>
        /// <param name="endCustomerCode">�I�����Ӑ�R�[�h</param>
        /// <param name="startAddUpYearMonth">�v��N���i�J�n�j(YYYYMM)</param>
        /// <param name="endAddUpYearMonth">�v��N���i�I���j(YYYYMM)</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����p�����[�^�̓��e�œ��Ӑ攄�|�����擾���܂��B
        ///                : ��ɓ��Ӑ挳���ɂĎg�p���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Update Note: 2014/02/26 �c����</br>
        /// <br>           : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// </remarks>
        private static int getCustAccRecAcsSearch(out ArrayList custAccRecInfGetWorkList, out Hashtable ledgerSalesBlanceWorkHash, out Hashtable ledgerSalesSlipWorkHash, out Hashtable ledgerSalesDtlWorkHash, out Hashtable ledgerDepsitMainWorkHash,
            string enterpriseCode, ArrayList addUpSecCodeList, int customerCode, int startCustomerCode, int endCustomerCode, int startAddUpYearMonth, int endAddUpYearMonth, int outMoneyDiv)
        {
            // ���|���擾���o�����p�����[�^�N���X����
            CustAccRecInfSearchParameter parameter = new CustAccRecInfSearchParameter();
            parameter.EnterpriseCode = enterpriseCode;
            if (addUpSecCodeList != null)
            {
                parameter.AddUpSecCodeList = (string[])addUpSecCodeList.ToArray(typeof(string));
            }
            parameter.StartCustomerCode = startCustomerCode;
            parameter.EndCustomerCode = endCustomerCode;
            parameter.StartAddUpYearMonth = DateTime.ParseExact(startAddUpYearMonth.ToString(), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            parameter.EndAddUpYearMonth = DateTime.ParseExact(endAddUpYearMonth.ToString(), "yyyyMM", System.Globalization.DateTimeFormatInfo.InvariantInfo);
  
            // ���|��񌟍�����
            //return getCustAccRecAcsSearchDB(out custAccRecInfGetWorkList, out ledgerSalesBlanceWorkHash, out ledgerSalesSlipWorkHash, out ledgerSalesDtlWorkHash, out ledgerDepsitMainWorkHash, parameter);// DEL 2014/02/27 ���N�n��
            return getCustAccRecAcsSearchDB(out custAccRecInfGetWorkList, out ledgerSalesBlanceWorkHash, out ledgerSalesSlipWorkHash, out ledgerSalesDtlWorkHash, out ledgerDepsitMainWorkHash, parameter, outMoneyDiv);// ADD 2014/02/27 ���N�n��
        }

        /// <summary>
        /// ���|��񌟍�����
        /// </summary>
        /// <param name="custAccRecInfGetWorkList">���Ӑ攄�|���z�N���X���[�N���X�g</param>
        /// <param name="ledgerSalesBlanceWorkHash">����c�����e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerSalesSlipWorkHash">������e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerSalesDtlWorkHash">���㖾�׏��e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="ledgerDepsitMainWorkHash">�������e�[�u��(HashTable[�v��N����]->ArrayList)</param>
        /// <param name="parameter">���|���擾���o�����p�����[�^�N���X</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : ���|�����擾���܂��B</br>
        /// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.10.18</br>
        /// <br>Update Note: 2014/02/26 �c����</br>
        /// <br>           : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// <br>UpdateNote : 2015/09/21 �c�v�t</br>
        /// <br>           : Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br> 
        /// </remarks>
        private static int getCustAccRecAcsSearchDB(out ArrayList custAccRecInfGetWorkList, out Hashtable ledgerSalesBlanceWorkHash, out Hashtable ledgerSalesSlipWorkHash, out Hashtable ledgerSalesDtlWorkHash, out Hashtable ledgerDepsitMainWorkHash,
            //CustAccRecInfSearchParameter parameter)// DEL 2014/02/27 ���N�n��
            CustAccRecInfSearchParameter parameter, int outMoneyDiv)// ADD 2014/02/27 ���N�n��
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_EOF;
            custAccRecInfGetWorkList = null;
            ledgerSalesBlanceWorkHash = null;
            ledgerSalesSlipWorkHash = null;
            ledgerDepsitMainWorkHash = null;
            ledgerSalesDtlWorkHash = null;

            try
            {
                // �����[�g�߂�l�錾
                object objCustAccRecInfGetWorkList = null;
                object objLedgerSalesSlipWorkList = null;
                object objLedgerDepsitMainWorkList = null;
                object objLedgerSalesDtlWorkList = null;
                object objCustAccRecInfGetWorkList2 = null;            //DMY
                object objLedgerDepsitMainWorkList2 = null;            //DMY

                // ���|���擾����
                // --- UPD 2014/02/20 T.Miyamoto ------------------------------>>>>>
                //status = _iCustAccRecInfGetDB.SearchSlip(out objCustAccRecInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, parameter);
                //status2 = _iCustAccRecInfGetDB.SearchDtl(out objCustAccRecInfGetWorkList2, out objLedgerSalesDtlWorkList, out objLedgerDepsitMainWorkList2, parameter);
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                //if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                status = _iCustAccRecInfGetDB.SearchSlip(out objCustAccRecInfGetWorkList, out objLedgerSalesSlipWorkList, out objLedgerDepsitMainWorkList, parameter);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status;
                status2 = _iCustAccRecInfGetDB.SearchDtl(out objCustAccRecInfGetWorkList2, out objLedgerSalesDtlWorkList, out objLedgerDepsitMainWorkList2, parameter);
                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return status2;
                // --- UPD 2014/02/20 T.Miyamoto ------------------------------<<<<<

                // �擾�����f�[�^
                custAccRecInfGetWorkList = objCustAccRecInfGetWorkList as ArrayList;
                ArrayList ledgerSalesBlanceWorkList = objCustAccRecInfGetWorkList as ArrayList;
                ArrayList ledgerSalesSlipWorkList = objLedgerSalesSlipWorkList as ArrayList;
                ArrayList ledgerSalesDtlWorkList = objLedgerSalesDtlWorkList as ArrayList;
                ArrayList ledgerDepsitMainWorkList = objLedgerDepsitMainWorkList as ArrayList;

                // ���Ӑ攄�|���z��񃊃X�g���������͔�����
                if (custAccRecInfGetWorkList == null) return status;

                ledgerSalesBlanceWorkHash = new Hashtable();
                ledgerSalesSlipWorkHash = new Hashtable();
                ledgerSalesDtlWorkHash = new Hashtable();
                ledgerDepsitMainWorkHash = new Hashtable();

                int ledgerSalesBlanceWorkCounter = 0;
                int ledgerSalesSlipWorkCounter = 0;
                int ledgerSalesDtlWorkCounter = 0;
                int ledgerDepsitMainWorkCounter = 0;

                // ---ADD 2014/02/26 �c���� Redmine#42188---->>>>>
                List<CustAccRecInfGetWork> custAccRecInfGetDelList = new List<CustAccRecInfGetWork>();

                bool salesSlipFlag = false;
                bool salesSalesDtl = false;
                bool salesDepsitMain = false;
                // ---ADD 2014/02/26 �c���� Redmine#42188----<<<<<

                // �擾�������Ӑ攄�|���z��񃊃X�g���܂킷
                foreach (CustAccRecInfGetWork custAccRecInfGetWork in custAccRecInfGetWorkList)
                {
                    // ---ADD 2014/02/26 �c���� Redmine#42188---->>>>>
                    salesSlipFlag = false;
                    salesSalesDtl = false;
                    salesDepsitMain = false;
                    // ---ADD 2014/02/26 �c���� Redmine#42188----<<<<<

                    // �c���f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerSalesBlanceWorkList != null) && (ledgerSalesBlanceWorkList.Count > 0))
                    {
                        // �擾�����c���f�[�^���܂킷
                        foreach (CustAccRecInfGetWork ledgerSalesBlanceWork in ledgerSalesBlanceWorkList)
                        {
                            // �c���f�[�^�̌v����t���擾
                            DateTime workAddUpADate = ledgerSalesBlanceWork.AddUpDate;

                            // �v�㋒�_������ŁA����f�[�^�̌v����t�����Ӑ攄�|���z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                            if ((ledgerSalesBlanceWork.AddUpSecCode.TrimEnd() == custAccRecInfGetWork.AddUpSecCode.TrimEnd()) &&
                                (ledgerSalesBlanceWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&
                                (workAddUpADate >= custAccRecInfGetWork.StMonCAddUpUpdDate) &&
                                (workAddUpADate <= custAccRecInfGetWork.AddUpDate))
                            {
                                int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custAccRecInfGetWork.AddUpDate);

                                // Hashtable�ɓ���̌v����t���������͍쐬
                                if (!ledgerSalesBlanceWorkHash.Contains(addUpDate)) ledgerSalesBlanceWorkHash.Add(addUpDate, new ArrayList());

                                // ���Ӑ攄�|���z�}�X�^�̌v��N������KEY�ɂ���Hashtable�ɔ���f�[�^��ArrayList�ɂ��ĂԂ牺����
                                ArrayList list = (ArrayList)ledgerSalesBlanceWorkHash[addUpDate];
                                //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                //(�{����D�N���X�Ɏ������ׂ�����)
                                //list.Add(ledgerSalesBlanceWork.Clone());
                                CustAccRecInfGetWork wk = new CustAccRecInfGetWork();
                                wk.AcpOdrTtl2TmBfAccRec = ledgerSalesBlanceWork.AcpOdrTtl2TmBfAccRec;
                                wk.AcpOdrTtl3TmBfAccRec = ledgerSalesBlanceWork.AcpOdrTtl3TmBfAccRec;
                                wk.AddUpDate = ledgerSalesBlanceWork.AddUpDate;
                                wk.AddUpSecCode = ledgerSalesBlanceWork.AddUpSecCode.ToString();
                                wk.AddUpYearMonth = ledgerSalesBlanceWork.AddUpYearMonth;
                                wk.AfCalTMonthAccRec = ledgerSalesBlanceWork.AfCalTMonthAccRec;
                                wk.BalanceAdjust = ledgerSalesBlanceWork.BalanceAdjust;
                                wk.ClaimCode = ledgerSalesBlanceWork.ClaimCode;
                                wk.ClaimName = ledgerSalesBlanceWork.ClaimName.ToString();
                                wk.ClaimName2 = ledgerSalesBlanceWork.ClaimName2.ToString();
                                wk.ClaimSnm = ledgerSalesBlanceWork.ClaimSnm.ToString();
                                wk.CloseFlg = wk.CloseFlg;
                                wk.ConsTaxLayMethod = ledgerSalesBlanceWork.ConsTaxLayMethod;
                                wk.CustomerCode = ledgerSalesBlanceWork.CustomerCode;
                                wk.CustomerName = ledgerSalesBlanceWork.CustomerName.ToString();
                                wk.CustomerName2 = ledgerSalesBlanceWork.CustomerName2.ToString();
                                wk.CustomerSnm = ledgerSalesBlanceWork.CustomerSnm.ToString();
                                wk.EnterpriseCode = ledgerSalesBlanceWork.EnterpriseCode.ToString();
                                wk.LaMonCAddUpUpdDate = ledgerSalesBlanceWork.LaMonCAddUpUpdDate;
                                wk.LastTimeAccRec = ledgerSalesBlanceWork.LastTimeAccRec;
                                wk.MonthAddUpExpDate = ledgerSalesBlanceWork.MonthAddUpExpDate;
                                wk.OfsThisSalesTax = ledgerSalesBlanceWork.OfsThisSalesTax;
                                wk.OfsThisTimeSales = ledgerSalesBlanceWork.OfsThisTimeSales;
                                wk.SalesSlipCount = ledgerSalesBlanceWork.SalesSlipCount;
                                wk.StMonCAddUpUpdDate = ledgerSalesBlanceWork.StMonCAddUpUpdDate;
                                wk.TaxAdjust = ledgerSalesBlanceWork.TaxAdjust;
                                wk.ThisSalesPrcTaxDis = ledgerSalesBlanceWork.ThisSalesPrcTaxDis;
                                wk.ThisSalesPrcTaxRgds = ledgerSalesBlanceWork.ThisSalesPrcTaxRgds;
                                wk.ThisSalesPricDis = ledgerSalesBlanceWork.ThisSalesPricDis;
                                wk.ThisSalesPricRgds = ledgerSalesBlanceWork.ThisSalesPricRgds;
                                wk.ThisSalesTax = ledgerSalesBlanceWork.ThisSalesTax;
                                wk.ThisTimeDmdNrml = ledgerSalesBlanceWork.ThisTimeDmdNrml;
                                wk.ThisTimeSales = ledgerSalesBlanceWork.ThisTimeSales;
                                wk.ThisTimeTtlBlcAcc = ledgerSalesBlanceWork.ThisTimeTtlBlcAcc;
                                list.Add(wk);
                                ledgerSalesBlanceWorkCounter++;
                            }
                        }
                    }

                    // ����f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerSalesSlipWorkList != null) && (ledgerSalesSlipWorkList.Count > 0))
                    {
                        // �擾��������f�[�^���܂킷
                        foreach (ArrayList arrayList in ledgerSalesSlipWorkList)
                        {
                            foreach (LedgerSalesSlipWork ledgerSalesSlipWork in arrayList)
                            {
                                // ����f�[�^�̌v����t���擾
                                DateTime workAddUpADate = ledgerSalesSlipWork.AddUpADate;

                                // �v�㋒�_������ŁA����f�[�^�̌v����t�����Ӑ攄�|���z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
                                //if ((ledgerSalesSlipWork.DemandAddUpSecCd.TrimEnd() == custAccRecInfGetWork.AddUpSecCode.TrimEnd()) &&
                                //    (ledgerSalesSlipWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&
                                // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
                                if ((ledgerSalesSlipWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&     // ADD 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�
                                    (workAddUpADate >= custAccRecInfGetWork.StMonCAddUpUpdDate) &&
                                    (workAddUpADate <= custAccRecInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custAccRecInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!ledgerSalesSlipWorkHash.Contains(addUpDate)) ledgerSalesSlipWorkHash.Add(addUpDate, new ArrayList());

                                    // ���Ӑ攄�|���z�}�X�^�̌v��N������KEY�ɂ���Hashtable�ɔ���f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)ledgerSalesSlipWorkHash[addUpDate];
                                    //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                    //(�{����D�N���X�Ɏ������ׂ�����)
                                    //list.Add(ledgerSalesSlipWork.Clone());
                                    LedgerSalesSlipWork wk = new LedgerSalesSlipWork();
                                    wk.AccRecDivCd = ledgerSalesSlipWork.AccRecDivCd;
                                    wk.AcptAnOdrStatus = ledgerSalesSlipWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerSalesSlipWork.AddUpADate;
                                    wk.ClaimCode = ledgerSalesSlipWork.ClaimCode;
                                    wk.ClaimSnm = ledgerSalesSlipWork.ClaimSnm.ToString();
                                    wk.CustomerCode = ledgerSalesSlipWork.CustomerCode;
                                    wk.CustomerName = ledgerSalesSlipWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerSalesSlipWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerSalesSlipWork.CustomerSnm.ToString();
                                    wk.DebitNLnkSalesSlNum = ledgerSalesSlipWork.DebitNLnkSalesSlNum.ToString();
                                    wk.DebitNoteDiv = ledgerSalesSlipWork.DebitNoteDiv;
                                    wk.DemandAddUpSecCd = ledgerSalesSlipWork.DemandAddUpSecCd.ToString();
                                    wk.EnterpriseCode = ledgerSalesSlipWork.EnterpriseCode.ToString();
                                    wk.FrontEmployeeCd = ledgerSalesSlipWork.FrontEmployeeCd.ToString();
                                    wk.FrontEmployeeNm = ledgerSalesSlipWork.FrontEmployeeNm.ToString();
                                    wk.HonorificTitle = ledgerSalesSlipWork.HonorificTitle.ToString();
                                    wk.InputAgenCd = ledgerSalesSlipWork.InputAgenCd.ToString();
                                    wk.InputAgenNm = ledgerSalesSlipWork.InputAgenNm.ToString();
                                    wk.PartySaleSlipNum = ledgerSalesSlipWork.PartySaleSlipNum.ToString();
                                    wk.ResultsAddUpSecCd = ledgerSalesSlipWork.ResultsAddUpSecCd.ToString();
                                    wk.SalesDate = ledgerSalesSlipWork.SalesDate;
                                    wk.SalesEmployeeCd = ledgerSalesSlipWork.SalesEmployeeCd.ToString();
                                    wk.SalesEmployeeNm = ledgerSalesSlipWork.SalesEmployeeNm.ToString();
                                    wk.SalesGoodsCd = ledgerSalesSlipWork.SalesGoodsCd;
                                    wk.SalesInpSecCd = ledgerSalesSlipWork.SalesInpSecCd.ToString();
                                    wk.SalesInputCode = ledgerSalesSlipWork.SalesInputCode.ToString();
                                    wk.SalesInputName = ledgerSalesSlipWork.SalesInputName.ToString();
                                    wk.SalesSlipCd = ledgerSalesSlipWork.SalesSlipCd;
                                    wk.SalesSlipNum = ledgerSalesSlipWork.SalesSlipNum.ToString();
                                    wk.SalesSubtotalTax = ledgerSalesSlipWork.SalesSubtotalTax;
                                    wk.SalesSubtotalTaxExc = ledgerSalesSlipWork.SalesSubtotalTaxExc;
                                    wk.SalesSubtotalTaxInc = ledgerSalesSlipWork.SalesSubtotalTaxInc;
                                    wk.SearchSlipDate = ledgerSalesSlipWork.SearchSlipDate;
                                    wk.SectionCode = ledgerSalesSlipWork.SectionCode.ToString();
                                    wk.ShipmentDay = ledgerSalesSlipWork.ShipmentDay;
                                    wk.SlipNote = ledgerSalesSlipWork.SlipNote.ToString();
                                    wk.SlipNote2 = ledgerSalesSlipWork.SlipNote2.ToString();
                                    wk.SlipNote3 = ledgerSalesSlipWork.SlipNote3.ToString();
                                    wk.UoeRemark1 = ledgerSalesSlipWork.UoeRemark1.ToString();
                                    wk.UoeRemark2 = ledgerSalesSlipWork.UoeRemark2.ToString();
                                    wk.UpdateSecCd = ledgerSalesSlipWork.UpdateSecCd.ToString();
                                    // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� >>>>>>START
                                    wk.ConsTaxLayMethod = ledgerSalesSlipWork.ConsTaxLayMethod;
                                    // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� <<<<<<END
                                    // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� >>>>>>START
                                    wk.SalesTotalTaxExc = ledgerSalesSlipWork.SalesTotalTaxExc;
                                    // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� <<<<<<END
                                    list.Add(wk);
                                    ledgerSalesSlipWorkCounter++;
                                    salesSlipFlag = true;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // ���㖾�׃f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerSalesDtlWorkList != null) && (ledgerSalesDtlWorkList.Count > 0))
                    {
                        // �擾��������f�[�^���܂킷
                        foreach (ArrayList arrayList in ledgerSalesDtlWorkList)
                        {
                            foreach (LedgerSalesDetailWork ledgerSalesDtlWork in arrayList)
                            {
                                // ����f�[�^�̌v����t���擾
                                DateTime workAddUpADate = ledgerSalesDtlWork.AddUpADate;

                                // �v�㋒�_������ŁA����f�[�^�̌v����t�����Ӑ攄�|���z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
                                //if ((ledgerSalesDtlWork.DemandAddUpSecCd.TrimEnd() == custAccRecInfGetWork.AddUpSecCode.TrimEnd()) &&
                                //    (ledgerSalesDtlWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&
                                // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
                                if ((ledgerSalesDtlWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&       // ADD 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�
                                    (workAddUpADate >= custAccRecInfGetWork.StMonCAddUpUpdDate) &&
                                    (workAddUpADate <= custAccRecInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custAccRecInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!ledgerSalesDtlWorkHash.Contains(addUpDate)) ledgerSalesDtlWorkHash.Add(addUpDate, new ArrayList());

                                    // ���Ӑ攄�|���z�}�X�^�̌v��N������KEY�ɂ���Hashtable�ɔ���f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)ledgerSalesDtlWorkHash[addUpDate];
                                    //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                    //(�{����D�N���X�Ɏ������ׂ�����)
                                    //list.Add(ledgerSalesDtlWork.Clone());
                                    LedgerSalesDetailWork wk = new LedgerSalesDetailWork();
                                    wk.AccRecDivCd = ledgerSalesDtlWork.AccRecDivCd;
                                    wk.AcptAnOdrStatus = ledgerSalesDtlWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerSalesDtlWork.AddUpADate;
                                    wk.ClaimCode = ledgerSalesDtlWork.ClaimCode;
                                    wk.ClaimSnm = ledgerSalesDtlWork.ClaimSnm.ToString();
                                    wk.CommonSeqNo = ledgerSalesDtlWork.CommonSeqNo;
                                    wk.CustomerCode = ledgerSalesDtlWork.CustomerCode;
                                    wk.CustomerName = ledgerSalesDtlWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerSalesDtlWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerSalesDtlWork.CustomerSnm.ToString();
                                    wk.DebitNLnkSalesSlNum = ledgerSalesDtlWork.DebitNLnkSalesSlNum.ToString();
                                    wk.DebitNoteDiv = ledgerSalesDtlWork.DebitNoteDiv;
                                    wk.DemandAddUpSecCd = ledgerSalesDtlWork.DemandAddUpSecCd.ToString();
                                    wk.EnterpriseCode = ledgerSalesDtlWork.EnterpriseCode.ToString();
                                    wk.FrontEmployeeCd = ledgerSalesDtlWork.FrontEmployeeCd.ToString();
                                    wk.FrontEmployeeNm = ledgerSalesDtlWork.FrontEmployeeNm.ToString();
                                    wk.GoodsName = ledgerSalesDtlWork.GoodsName.ToString();
                                    wk.GoodsNameKana = ledgerSalesDtlWork.GoodsNameKana.ToString();
                                    wk.GoodsNo = ledgerSalesDtlWork.GoodsNo.ToString();
                                    wk.HonorificTitle = ledgerSalesDtlWork.HonorificTitle.ToString();
                                    wk.InputAgenCd = ledgerSalesDtlWork.InputAgenCd.ToString();
                                    wk.InputAgenNm = ledgerSalesDtlWork.InputAgenNm.ToString();
                                    wk.PartySaleSlipNum = ledgerSalesDtlWork.PartySaleSlipNum.ToString();
                                    wk.ResultsAddUpSecCd = ledgerSalesDtlWork.ResultsAddUpSecCd.ToString();
                                    wk.SalesDate = ledgerSalesDtlWork.SalesDate;
                                    wk.SalesEmployeeCd = ledgerSalesDtlWork.SalesEmployeeCd.ToString();
                                    wk.SalesEmployeeNm = ledgerSalesDtlWork.SalesEmployeeNm.ToString();
                                    wk.SalesGoodsCd = ledgerSalesDtlWork.SalesGoodsCd;
                                    wk.SalesInpSecCd = ledgerSalesDtlWork.SalesInpSecCd.ToString();
                                    wk.SalesInputCode = ledgerSalesDtlWork.SalesInputCode.ToString();
                                    wk.SalesInputName = ledgerSalesDtlWork.SalesInputName.ToString();
                                    wk.SalesMoneyTaxExc = ledgerSalesDtlWork.SalesMoneyTaxExc;
                                    wk.SalesPriceConsTax = ledgerSalesDtlWork.SalesPriceConsTax;
                                    wk.SalesRowDerivNo = ledgerSalesDtlWork.SalesRowDerivNo;
                                    wk.SalesRowNo = ledgerSalesDtlWork.SalesRowNo;
                                    wk.SalesSlipCd = ledgerSalesDtlWork.SalesSlipCd;
                                    wk.SalesSlipDtlNum = ledgerSalesDtlWork.SalesSlipDtlNum;
                                    wk.SalesSlipNum = ledgerSalesDtlWork.SalesSlipNum.ToString();
                                    wk.SalesSubtotalTax = ledgerSalesDtlWork.SalesSubtotalTax;
                                    wk.SalesSubtotalTaxExc = ledgerSalesDtlWork.SalesSubtotalTaxExc;
                                    wk.SalesSubtotalTaxInc = ledgerSalesDtlWork.SalesSubtotalTaxInc;
                                    wk.SalesUnPrcTaxExcFl = ledgerSalesDtlWork.SalesUnPrcTaxExcFl;
                                    wk.SearchSlipDate = ledgerSalesDtlWork.SearchSlipDate;
                                    wk.SectionCode = ledgerSalesDtlWork.SectionCode.ToString();
                                    wk.ShipmentCnt = ledgerSalesDtlWork.ShipmentCnt;
                                    wk.ShipmentDay = ledgerSalesDtlWork.ShipmentDay;
                                    wk.SlipNote = ledgerSalesDtlWork.SlipNote.ToString();
                                    wk.SlipNote2 = ledgerSalesDtlWork.SlipNote2.ToString();
                                    wk.SlipNote3 = ledgerSalesDtlWork.SlipNote3.ToString();
                                    wk.SupplierCd = ledgerSalesDtlWork.SupplierCd;
                                    wk.SupplierSnm = ledgerSalesDtlWork.SupplierSnm.ToString();
                                    wk.UoeRemark1 = ledgerSalesDtlWork.UoeRemark1.ToString();
                                    wk.UoeRemark2 = ledgerSalesDtlWork.UoeRemark2.ToString();
                                    wk.UpdateSecCd = ledgerSalesDtlWork.UpdateSecCd.ToString();
                                    // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� >>>>>>START
                                    wk.ConsTaxLayMethod = ledgerSalesDtlWork.ConsTaxLayMethod;
                                    wk.TaxationDivCd = ledgerSalesDtlWork.TaxationDivCd;
                                    // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� <<<<<<END
                                    list.Add(wk);
                                    ledgerSalesDtlWorkCounter++;
                                    salesSalesDtl = false;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }

                    // �����f�[�^���擾���Ă��āA�߂�l���X�g�ɑS�ē]�L���Ă��Ȃ���
                    if ((ledgerDepsitMainWorkList != null) && (ledgerDepsitMainWorkList.Count > 0))
                    {
                        // �擾���������f�[�^���܂킷
                        foreach (ArrayList arrayList in ledgerDepsitMainWorkList)
                        {
                            foreach (LedgerDepsitMainWork ledgerDepsitMainWork in arrayList)
                            {
                                // �����f�[�^�̌v����t���擾
                                DateTime workAddUpADate = ledgerDepsitMainWork.AddUpADate;

                                // �v�㋒�_������ŁA�����f�[�^�̌v����t�����Ӑ攄�|���z�}�X�^�̒����t�͈͂ɓ����Ă���ꍇ
                                if ((ledgerDepsitMainWork.AddUpSecCode.TrimEnd() == custAccRecInfGetWork.AddUpSecCode.TrimEnd()) &&
                                    (ledgerDepsitMainWork.ClaimCode == custAccRecInfGetWork.ClaimCode) &&
                                    (workAddUpADate >= custAccRecInfGetWork.StMonCAddUpUpdDate) &&
                                    (workAddUpADate <= custAccRecInfGetWork.AddUpDate))
                                {
                                    int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", custAccRecInfGetWork.AddUpDate);

                                    // Hashtable�ɓ���̌v����t���������͍쐬
                                    if (!ledgerDepsitMainWorkHash.Contains(addUpDate)) ledgerDepsitMainWorkHash.Add(addUpDate, new ArrayList());

                                    // ���Ӑ攄�|���z�}�X�^�̌v��N������KEY�ɂ���Hashtable�ɓ����f�[�^��ArrayList�ɂ��ĂԂ牺����
                                    ArrayList list = (ArrayList)ledgerDepsitMainWorkHash[addUpDate];
                                    //D�N���X����Clone()���\�b�h���폜���ꂽ���߁A�ʂ̕��@�Ŏ���
                                    //(�{����D�N���X�Ɏ������ׂ�����)
                                    //list.Add(ledgerDepsitMainWork.Clone());
                                    LedgerDepsitMainWork wk = new LedgerDepsitMainWork();
                                    wk.AcptAnOdrStatus = ledgerDepsitMainWork.AcptAnOdrStatus;
                                    wk.AddUpADate = ledgerDepsitMainWork.AddUpADate;
                                    wk.AddUpSecCode = ledgerDepsitMainWork.AddUpSecCode.ToString();
                                    wk.ClaimCode = ledgerDepsitMainWork.ClaimCode;
                                    wk.ClaimName = ledgerDepsitMainWork.ClaimName.ToString();
                                    wk.ClaimName2 = ledgerDepsitMainWork.ClaimName2.ToString();
                                    wk.ClaimSnm = ledgerDepsitMainWork.ClaimSnm.ToString();
                                    wk.CustomerCode = ledgerDepsitMainWork.CustomerCode;
                                    wk.CustomerName = ledgerDepsitMainWork.CustomerName.ToString();
                                    wk.CustomerName2 = ledgerDepsitMainWork.CustomerName2.ToString();
                                    wk.CustomerSnm = ledgerDepsitMainWork.CustomerSnm.ToString();
                                    wk.Deposit = ledgerDepsitMainWork.Deposit;
                                    wk.DepositAgentCode = ledgerDepsitMainWork.DepositAgentCode.ToString();
                                    wk.DepositAgentNm = ledgerDepsitMainWork.DepositAgentNm.ToString();
                                    wk.DepositDate = ledgerDepsitMainWork.DepositDate;
                                    wk.DepositDebitNoteCd = ledgerDepsitMainWork.DepositDebitNoteCd;
                                    wk.DepositInputAgentCd = ledgerDepsitMainWork.DepositInputAgentCd.ToString();
                                    wk.DepositInputAgentNm = ledgerDepsitMainWork.DepositInputAgentNm.ToString();
                                    wk.DepositRowNo = ledgerDepsitMainWork.DepositRowNo;
                                    wk.DepositSlipNo = ledgerDepsitMainWork.DepositSlipNo;
                                    wk.EnterpriseCode = ledgerDepsitMainWork.EnterpriseCode.ToString();
                                    wk.InputDepositSecCd = ledgerDepsitMainWork.InputDepositSecCd.ToString();
                                    wk.MoneyKindCode = ledgerDepsitMainWork.MoneyKindCode;
                                    wk.MoneyKindDiv = ledgerDepsitMainWork.MoneyKindDiv;
                                    wk.MoneyKindName = ledgerDepsitMainWork.MoneyKindName.ToString();
                                    wk.Outline = ledgerDepsitMainWork.Outline.ToString();
                                    wk.SalesSlipNum = ledgerDepsitMainWork.SalesSlipNum.ToString();
                                    wk.UpdateSecCd = ledgerDepsitMainWork.UpdateSecCd.ToString();
                                    wk.ValidityTerm = ledgerDepsitMainWork.ValidityTerm;
                                    list.Add(wk);
                                    ledgerDepsitMainWorkCounter++;
                                    salesDepsitMain = false;// ADD 2014/02/26 �c���� Redmine#42188
                                }
                            }
                        }
                    }
                    // ---ADD 2014/02/26 �c���� Redmine#42188 ------>>>>>
                    if (salesSlipFlag == false
                     && salesSalesDtl == false
                     && salesDepsitMain == false
                     && outMoneyDiv == 1
                     && custAccRecInfGetWork.LastTimeAccRec == 0         // �O�񔄊|���z
                     && custAccRecInfGetWork.AcpOdrTtl2TmBfAccRec == 0   // ��2��O�c���i���|�v�j
                     && custAccRecInfGetWork.AcpOdrTtl3TmBfAccRec == 0)  // ��3��O�c���i���|�v�j
                    {
                        custAccRecInfGetDelList.Add(custAccRecInfGetWork);
                    }
                    // ---ADD 2014/02/26 �c���� Redmine#42188 ------<<<<<
                }
                // ---ADD 2014/02/26 �c���� Redmine#42188 ------>>>>>
                if (outMoneyDiv == 0) return status;
                // �S�ċ��z0�̏ꍇ�A������Ȃ�
                foreach (CustAccRecInfGetWork wkCustAccRecInfGet in custAccRecInfGetDelList)
                {

                    if (custAccRecInfGetWorkList.Contains(wkCustAccRecInfGet))
                    {
                        custAccRecInfGetWorkList.Remove(wkCustAccRecInfGet);
                    }
                }

                // �S�ăf�[�^�t�B���^������A�߂�X�e�[�^�X���ύX����
                if (custAccRecInfGetWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                // ---ADD 2014/02/26 �c���� Redmine#42188 ------<<<<<

                return status;
            }
            catch (Exception e)
            {
                custAccRecInfGetWorkList = null;
                ledgerSalesBlanceWorkHash = null;
                ledgerSalesSlipWorkHash = null;
                ledgerSalesDtlWorkHash = null;
                ledgerDepsitMainWorkHash = null;

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                throw new CsLedgerException(e.Message, status);
            }
        }


		#region �� ����E�����f�[�^�����Ɖ�׃e�[�u���ݒ菈��
		/// <summary>
		/// ����E�����f�[�^�����Ɖ�׃e�[�u���ݒ菈��
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note        : ����E�������X�g��茳���Ɖ�׃e�[�u���ɖ��ׂ�ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
        private static void SalesAndDepsitToDataTable(Hashtable salesBTable, Hashtable salesHTable, Hashtable salesDTable, Hashtable depsitHTable, string viewSecCd, bool isNotCloseOnly)
		{
			if (_custDmdPrcDataView.Count != 0)
			{
				// ���_�ʂɑO��c���s�E�J�z�c���s���쐬���� 
				for (int i = 0; i < _custDmdPrcDataView.Count; i++)
				{
					// DataRow �� �������z�N���X
					CsLedgerDmdPrc dmdPrc = DataRowToCsLedgerDmdPrc(_custDmdPrcDataView[i].Row);

					CsLedgerCustomer csLedgerCustomer = 
						(CsLedgerCustomer)_csLedgerCustomerHTable[
							dmdPrc.ClaimCode.ToString() + "_" +
							TDateTime.DateTimeToLongDate( dmdPrc.AddUpDate ).ToString() + "_" +
							dmdPrc.AddUpSecCode];

					// KEY���̐ݒ�
					int keyDate = TDateTime.DateTimeToLongDate(dmdPrc.AddUpDate);
					string addUpSecCd = dmdPrc.AddUpSecCode;

					// �O��c�����L��ꍇ�O��c���s�쐬
					if (dmdPrc.LastTimeDemand != 0)
					{
					    
                        if ( isNotCloseOnly )
						{
						}
						else
						{
                            //�ʏ�Search�Ŗ����f�[�^�̏ꍇ�ɏ�����ԂőO��c���s�͍쐬���Ȃ�
							if ( dmdPrc.CloseFlag == (int)CloseFlagState.Close )
							{
								// �O��c���s�쐬
								_csLedgerSlipDataTable.Rows.Add(
								MakingBalanceDataRow( (int)LedgerDtlBalanseState.Balance, dmdPrc, addUpSecCd, keyDate));
							}
						}
					}

                    // �����P�ʂ̏ꍇ
   					if ( csLedgerCustomer.CustTaxLayCd == 2 )
                    {                       
                        if(isNotCloseOnly)
                        {
                        }
                        else
                        {
                            // ����`�[�����݂���A�������͓������z������(����c�͖����J�E���g�����̂���)
					        if ((dmdPrc.SlipCount > 0) || (dmdPrc.ThisTimeDmdNrml != 0))
					        {
								// ���ς̂Ƃ���������ōs�쐬
								if ( dmdPrc.CloseFlag == (int)CloseFlagState.Close )
								{
									// ����ōs�쐬
									_csLedgerSlipDataTable.Rows.Add(MakingBalanceDataRow((int)LedgerDtlBalanseState.ConsTax, dmdPrc, addUpSecCd, keyDate));
								}
					        }
                        }                      
                    }
                  
                    // �J�z�c���s�쐬����
                    //�����f�[�^���H
                    if(isNotCloseOnly)
                    { 
                    }
                    else
                    {
                        //�ʏ�Search�Ŗ����f�[�^�̏ꍇ�ɏ�����ԂőO��c���s�͍쐬���Ȃ�
						if ( dmdPrc.CloseFlag == (int)CloseFlagState.Close )
						{
							//���σf�[�^
							// �J�z�c���s�쐬
							_csLedgerSlipDataTable.Rows.Add(MakingBalanceDataRow((int)LedgerDtlBalanseState.Others, dmdPrc, addUpSecCd, keyDate));
						}
                    }
 
                }
				// ����E�������׍s���쐬����
                SettingDataCsLedgerTable(salesBTable, salesHTable, salesDTable, depsitHTable);
			}
		}
		#endregion

		#region �� �J�z�c���s�쐬
		/// <summary>
		/// �J�z�c���s�쐬
		/// </summary>
		/// <param name="makeMode">[0:�J�z�c��,1:�O��c��]</param>
		/// <param name="csLedgerDmdPrc">���Ӑ�N���X</param>
		/// <param name="addUpSecCd">�����v�㋒�_�R�[�h</param>
		/// <param name="addUpDate">�v��N����</param>
		/// <remarks>
		/// <br>Note       : ���_���ɌJ�z�c���s���쐬���܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow MakingBalanceDataRow(int makeMode, CsLedgerDmdPrc csLedgerDmdPrc, string addUpSecCd, Int32 addUpDate)
		{
			DataRow row = _csLedgerSlipDataTable.NewRow();

			// ������R�[�h
			row[Ct_CsLedger_ClaimCode] = csLedgerDmdPrc.ClaimCode;
			// ���Ӑ�R�[�h
			row[Ct_CsLedger_CustomerCode] = csLedgerDmdPrc.CustomerCode;
			// �v��N����
			row[Ct_CsLedger_AddUpDate] = addUpDate;
			// ���R�[�h�敪(0:����,1:����)
			row[Ct_CsLedger_RecordCode] = LedgerDtlRecordState.Sales;
			// �O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)
			if (makeMode == (int)LedgerDtlBalanseState.Balance)
			{
				row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.Balance;
				row[Ct_CsLedger_SlipDetail] = "�y�@�O��J�z�@�z";
				row[Ct_CsLedger_Balance] = csLedgerDmdPrc.LastTimeDemand;

			}
			else if ( makeMode == (int)LedgerDtlBalanseState.ConsTax )
			{
				row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.ConsTax;
				row[Ct_CsLedger_SlipDetail] = "�� �� ��";
				//row[Ct_CsLedger_SalesSubtotalTax] = csLedgerDmdPrc.ThisSalesTax;
			}
			else
			{
				row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.Carried;
				row[Ct_CsLedger_SlipDetail] = "�y�@�J�z�c���@�z" + TDateTime.DateTimeToString("yyyy.mm.dd", DateConverter.GetDateTimeFromYYYYMMDD(addUpDate));
				// �J�z�c���͋��_�ʂɍČv�Z����K�v������I�I
				row[Ct_CsLedger_Balance] = 0;
			}
			// �v���(Int)
			row[Ct_CsLedger_AddUpADateInt] = addUpDate;
			// �v�㋒�_�R�[�h
			row[Ct_CsLedger_AddUpSecCode] = addUpSecCd;
			// �v�㋒�_����(�J�z�c���s�͋��_���̂�\�����Ȃ�)
			row[Ct_CsLedger_AddUpSecName] = "";

			return row;
		}
		#endregion

		#region �� �����Ɖ�׃f�[�^�ݒ菈��
		/// <summary>
		/// �����Ɖ�׃f�[�^�ݒ菈��
		/// </summary>
        /// <param name="salesBTable">�c�����X�g</param>
        /// <param name="salesHTable">���ナ�X�g</param>
        /// <param name="salesDTable">���㖾�׃��X�g</param>
        /// <param name="depsitHTable">�������X�g</param>
        /// <remarks>
		/// <br>Note        : �������z���R�[�h�̌v��͈͂̔���E�����f�[�^�������Ɖ�׃e�[�u���ɐݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
        private static void SettingDataCsLedgerTable(Hashtable salesBTable, Hashtable salesHTable, Hashtable salesDTable, Hashtable depsitHTable)
		{
            if (salesBTable != null)
            {
                // �c���s�쐬(HashTable Key: �v��N����(int),Value: �Y���v��N�����̔��ヌ�R�[�h���X�g)
                foreach (DictionaryEntry entry in salesBTable)
                {
                    int keyDate = TStrConv.StrToIntDef(entry.Key.ToString(), 0);
                    ArrayList arDmdSalesB = (ArrayList)entry.Value;

                    DataRow addRow;

                    if (_imode == 0) // �������[�h
                    {
                        foreach (CustDmdPrcInfGetWork dmdSalesB in arDmdSalesB)
                        {
                            addRow = CustDmdPrcWorkToBlanceDataRow(keyDate, dmdSalesB);
                            if (addRow != null)
                            {
                                _csLedgerBlanceDataTable.Rows.Add(addRow);
                            }
                        }
                    }
                    else
                    {
                        foreach (CustAccRecInfGetWork dmdSalesB in arDmdSalesB)
                        {
                            addRow = CustDmdPrcWorkToBlanceDataRow(keyDate, dmdSalesB);
                            if (addRow != null)
                            {
                                _csLedgerBlanceDataTable.Rows.Add(addRow);
                            }
                        }
                    }
                }
            }

            if (salesHTable != null)
			{
				// ����s�쐬(HashTable Key: �v��N����(int),Value: �Y���v��N�����̔��ヌ�R�[�h���X�g)
				foreach (DictionaryEntry entry in salesHTable)
				{
					int keyDate = TStrConv.StrToIntDef(entry.Key.ToString(), 0);
					ArrayList arDmdSales = (ArrayList)entry.Value;

					DataRow addRow;
					foreach (LedgerSalesSlipWork dmdSales in arDmdSales)
					{
                        // �������[�h�ŏ���Œ���(���|�p)�܂��͎c������(���|�p)�̏ꍇ���f�[�^������
                        if ((_imode == 0) && ((dmdSales.SalesGoodsCd == 4) || (dmdSales.SalesGoodsCd == 5))) continue;
                        // �������[�h�Ō����̏ꍇ���f�[�^������
                        if ((_imode == 0) && (dmdSales.AccRecDivCd == 0)) continue;

                        addRow = SalesToCsLedgerSlipDataRow(keyDate, dmdSales); 
						if ( addRow != null )
						{
							_csLedgerSlipDataTable.Rows.Add( addRow );
						}
					}
				}
			}

			if (salesDTable != null)
			{
				// ���㖾�׍s�쐬(HashTable Key: �v��N����(int),Value: �Y���v��N�����̔��ヌ�R�[�h���X�g)
				foreach (DictionaryEntry entry in salesDTable)
				{
					int keyDate = TStrConv.StrToIntDef(entry.Key.ToString(), 0);
					ArrayList arDmdSalesD = (ArrayList)entry.Value;

					DataRow addRow;
                    foreach (LedgerSalesDetailWork dmdSalesD in arDmdSalesD)
					{
                        // �������[�h�ŏ���Œ���(���|�p)�܂��͎c������(���|�p)�̏ꍇ���f�[�^������
                        if ((_imode == 0) && ((dmdSalesD.SalesGoodsCd == 4) || (dmdSalesD.SalesGoodsCd == 5))) continue;

                        // �������[�h�Ō����̏ꍇ���f�[�^������
                        if ((_imode == 0) && (dmdSalesD.AccRecDivCd == 0)) continue;

						addRow = SalesToCsLedgerDtlDataRow(keyDate, dmdSalesD); 
						if ( addRow != null )
						{
							_csLedgerDtlDataTable.Rows.Add( addRow );
						}
					}
				}
			}

            if (depsitHTable != null)
            {

                // �������׍s�쐬(HashTable Key: �v��N����(int),Value: �Y���v��N�����̓������R�[�h���X�g)
                foreach (DictionaryEntry entry in depsitHTable)
                {
                    // �����_�����p�N���X�쐬
                    LedgerDepsitMainWork otherDeposit = new LedgerDepsitMainWork();

                    int keyDate = TStrConv.StrToIntDef(entry.Key.ToString(), 0);
                    ArrayList arDeposits = (ArrayList)entry.Value;

                    foreach (LedgerDepsitMainWork depsit in arDeposits)
                    {
                        _csLedgerSlipDataTable.Rows.Add(DepsitToCsLedgerSlipDataRow(keyDate, depsit));
                        _csLedgerDtlDataTable.Rows.Add(DepsitToCsLedgerDtlDataRow(keyDate, depsit));
                    }
                }
            }
   		}
		#endregion

        #region �� �c����񂩂猳���Ɖ�׏��f�[�^�s�ݒ菈��
        /// <summary>
        /// �c����񂩂猳���Ɖ�׏��f�[�^�s�ݒ菈��
        /// </summary>
        /// <param name="addUpDate">�v��N����(���P��)</param>
        /// <param name="custDmdPrcInfGetWork">��������f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note        : �c����񂩂猳���Ɖ�׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
        /// <br>Programer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.10.18</br>
        /// </remarks>
        private static DataRow CustDmdPrcWorkToBlanceDataRow(int addUpDate, CustDmdPrcInfGetWork custDmdPrcInfGetWork)
        {
            DataRow row = _csLedgerBlanceDataTable.NewRow();
            // �v�㋒�_�R�[�h
            row[Ct_CsLedgerBlance_AddUpSecCode] = custDmdPrcInfGetWork.AddUpSecCode;

            // �v�㋒�_����
            string sectionName = "";
            if (_sectionHTable.ContainsKey(custDmdPrcInfGetWork.AddUpSecCode))
            {
                SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[custDmdPrcInfGetWork.AddUpSecCode];
                sectionName = secInfoSet.SectionGuideNm;
            }

            row[Ct_CsLedgerBlance_AddUpSecName] = sectionName;

            row[Ct_CsLedgerBlance_ClaimCode] = custDmdPrcInfGetWork.ClaimCode;                                         // ������R�[�h
            row[Ct_CsLedgerBlance_CustomerCode] = custDmdPrcInfGetWork.CustomerCode;                                   // ���Ӑ�R�[�h
            row[Ct_CsLedgerBlance_AddUpDate] = custDmdPrcInfGetWork.AddUpDate;                                         // �v��N����
            row[Ct_CsLedgerBlance_SlitTitle] = "�����c";        // ���[�^�C�g��
            row[Ct_CsLedgerBlance_AddUpDateInt] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate);        // �v��N����
            row[Ct_CsLedgerBlance_AddUpYearMonth] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpYearMonth); // �v��N��
            row[Ct_CsLedgerBlance_LastTimeDemand] = custDmdPrcInfGetWork.LastTimeDemand;                               // �O�񐿋����z
            row[Ct_CsLedgerBlance_ThisTimeDmdNrml] = custDmdPrcInfGetWork.ThisTimeDmdNrml;                             // ����������z�i�ʏ�����j
            row[Ct_CsLedgerBlance_ThisTimeTtlBlcDmd] = custDmdPrcInfGetWork.ThisTimeTtlBlcDmd;                         // ����J�z�c���i�����v�j
            row[Ct_CsLedgerBlance_OfsThisTimeSales] = custDmdPrcInfGetWork.OfsThisTimeSales;                           // ���E�㍡�񔄏���z           
            row[Ct_CsLedgerBlance_OfsThisSalesTax] = custDmdPrcInfGetWork.OfsThisSalesTax;    // ���E�㍡�񔄏�����                      
            row[Ct_CsLedgerBlance_ThisTimeSales] = custDmdPrcInfGetWork.ThisTimeSales;        // ���񔄏���z
            row[Ct_CsLedgerBlance_AfCalDemandPrice] = custDmdPrcInfGetWork.AfCalDemandPrice;           // �v�Z�㐿�����z
            row[Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd] = custDmdPrcInfGetWork.AcpOdrTtl2TmBfBlDmd;     // ��2��O�c���i�����v�j
            row[Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd] = custDmdPrcInfGetWork.AcpOdrTtl3TmBfBlDmd;     // ��3��O�c���i�����v�j
            row[Ct_CsLedgerBlance_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.CAddUpUpdExecDate);     // �����X�V���s�N����
            row[Ct_CsLedgerBlance_CloseFlag] = custDmdPrcInfGetWork.CloseFlg;                                                    // ���σt���O
            row[Ct_CsLedgerBlance_ThisRgdsDis] = custDmdPrcInfGetWork.ThisSalesPricRgds + custDmdPrcInfGetWork.ThisSalesPricDis; // �ԕi�E�l���z
            row[Ct_CsLedgerBlance_ThisSalesTaxTotal] = custDmdPrcInfGetWork.OfsThisTimeSales + custDmdPrcInfGetWork.OfsThisSalesTax;   // �ō�����z
            row[Ct_CsLedgerBlance_StartDateSpan] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.StartCAddUpUpdDate);   // ���t�͈́i�J�n�j
            row[Ct_CsLedgerBlance_EndDateSpan] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate);       // ���t�͈́i�I���j
            row[Ct_CsLedgerBlance_Name] = custDmdPrcInfGetWork.CustomerName;             // ���Ӑ於��
            row[Ct_CsLedgerBlance_Name2] = custDmdPrcInfGetWork.CustomerName2;           // ���Ӑ於��2

            return row;
        }
        #endregion

        #region �� �c����񂩂猳���Ɖ�׏��f�[�^�s�ݒ菈��
        /// <summary>
        /// �c����񂩂猳���Ɖ�׏��f�[�^�s�ݒ菈��
        /// </summary>
        /// <param name="addUpDate">�v��N����(���P��)</param>
        /// <param name="custAccRecInfGetWork">��������f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note        : �c����񂩂猳���Ɖ�׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
        /// <br>Programer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.10.18</br>
        /// </remarks>
        private static DataRow CustDmdPrcWorkToBlanceDataRow(int addUpDate, CustAccRecInfGetWork custAccRecInfGetWork)
        {
            DataRow row = _csLedgerBlanceDataTable.NewRow();
            // �v�㋒�_�R�[�h
            row[Ct_CsLedgerBlance_AddUpSecCode] = custAccRecInfGetWork.AddUpSecCode;

            // �v�㋒�_����
            string sectionName = "";
            if (_sectionHTable.ContainsKey(custAccRecInfGetWork.AddUpSecCode))
            {
                SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[custAccRecInfGetWork.AddUpSecCode];
                sectionName = secInfoSet.SectionGuideNm;
            }

            row[Ct_CsLedgerBlance_AddUpSecName] = sectionName;

            row[Ct_CsLedgerBlance_ClaimCode] = custAccRecInfGetWork.ClaimCode;                                         // ������R�[�h
            row[Ct_CsLedgerBlance_CustomerCode] = custAccRecInfGetWork.CustomerCode;                                   // ���Ӑ�R�[�h
            row[Ct_CsLedgerBlance_AddUpDate] = custAccRecInfGetWork.AddUpDate;                                         // �v��N����
            row[Ct_CsLedgerBlance_SlitTitle] = "���|�c";        // ���[�^�C�g��
            row[Ct_CsLedgerBlance_AddUpDateInt] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpDate);        // �v��N����
            row[Ct_CsLedgerBlance_AddUpYearMonth] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpYearMonth); // �v��N��
            row[Ct_CsLedgerBlance_LastTimeDemand] = custAccRecInfGetWork.LastTimeAccRec;                               // �O�񔄊|���z
            row[Ct_CsLedgerBlance_ThisTimeDmdNrml] = custAccRecInfGetWork.ThisTimeDmdNrml;                             // ����������z�i�ʏ�����j
            row[Ct_CsLedgerBlance_ThisTimeTtlBlcDmd] = custAccRecInfGetWork.ThisTimeTtlBlcAcc;                         // ����J�z�c���i���|�v�j
            row[Ct_CsLedgerBlance_OfsThisTimeSales] = custAccRecInfGetWork.OfsThisTimeSales;                           // ���E�㍡�񔄏���z           
            row[Ct_CsLedgerBlance_OfsThisSalesTax] = custAccRecInfGetWork.OfsThisSalesTax;    // ���E�㍡�񔄏�����                      
            row[Ct_CsLedgerBlance_ThisTimeSales] = custAccRecInfGetWork.ThisTimeSales;        // ���񔄏���z
            row[Ct_CsLedgerBlance_AfCalDemandPrice] = custAccRecInfGetWork.AfCalTMonthAccRec;           // �v�Z�㐿�����z
            row[Ct_CsLedgerBlance_AcpOdrTtl2TmBfBlDmd] = custAccRecInfGetWork.AcpOdrTtl2TmBfAccRec;     // ��2��O�c���i���|�v�j
            row[Ct_CsLedgerBlance_AcpOdrTtl3TmBfBlDmd] = custAccRecInfGetWork.AcpOdrTtl3TmBfAccRec;     // ��3��O�c���i���|�v�j
            row[Ct_CsLedgerBlance_CAddUpUpdExecDate] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.MonthAddUpExpDate);     // �����X�V���s�N����
            row[Ct_CsLedgerBlance_CloseFlag] = custAccRecInfGetWork.CloseFlg;                                                    // ���σt���O
            row[Ct_CsLedgerBlance_ThisRgdsDis] = custAccRecInfGetWork.ThisSalesPricRgds + custAccRecInfGetWork.ThisSalesPricDis; // �ԕi�E�l���z
            row[Ct_CsLedgerBlance_ThisSalesTaxTotal] = custAccRecInfGetWork.OfsThisTimeSales + custAccRecInfGetWork.OfsThisSalesTax;   // �ō�����z
            row[Ct_CsLedgerBlance_StartDateSpan] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.StMonCAddUpUpdDate);   // ���t�͈́i�J�n�j
            row[Ct_CsLedgerBlance_EndDateSpan] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpDate);       // ���t�͈́i�I���j
            row[Ct_CsLedgerBlance_Name] = custAccRecInfGetWork.CustomerName;             // ���Ӑ於��
            row[Ct_CsLedgerBlance_Name2] = custAccRecInfGetWork.CustomerName2;           // ���Ӑ於��2

            return row;
        }
        #endregion

        #region �� �����񂩂猳���Ɖ�׏��f�[�^�s�ݒ菈��
        /// <summary>
		/// �����񂩂猳���Ɖ�׏��f�[�^�s�ݒ菈��
		/// </summary>
		/// <param name="addUpDate">�v��N����(���P��)</param>
		/// <param name="dmd">��������f�[�^�N���X</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : �����񂩂猳���Ɖ�׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow SalesToCsLedgerSlipDataRow(int addUpDate, LedgerSalesSlipWork dmd)
		{
			DataRow row = _csLedgerSlipDataTable.NewRow();

            // ������R�[�h
			row[Ct_CsLedger_ClaimCode] = dmd.ClaimCode;
            // ���Ӑ�R�[�h
			row[Ct_CsLedger_CustomerCode] = dmd.CustomerCode;
			// �v��N����
			row[Ct_CsLedger_AddUpDate] = addUpDate;
			// ���R�[�h�敪(0:����,1:����)
			row[Ct_CsLedger_RecordCode] = LedgerDtlRecordState.Sales;
			// �O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)
			row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.Others;
			// �ԓ`�敪(0:��,1:��,2���E�ςݍ�)
			row[Ct_CsLedger_DebitNoteDiv] = dmd.DebitNoteDiv;
            if (dmd.DebitNoteDiv == 0)
            {
				row[Ct_CsLedger_DebitNoteDiv] = 2;
			}
			// �v����t
			row[Ct_CsLedger_AddUpADate] = dmd.AddUpADate;
			// �v����t(Int)
			row[Ct_CsLedger_AddUpADateInt] = TDateTime.DateTimeToLongDate( dmd.AddUpADate );
			// �v����t(�\���p)
			row[Ct_CsLedger_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // ����`�[�敪
            row[Ct_CsLedger_SalesSlipCd] = dmd.SalesSlipCd;
            string sliptypenm = "";
            switch (dmd.SalesSlipCd)
			{
				case 0:
					sliptypenm = "����";
					break;
				case 1:
					sliptypenm = "�ԕi";
					break;
				default:
					sliptypenm = "����";
					break;
			}
			row[Ct_CsLedger_SalesSlipKindName] = sliptypenm;

			// �`�[�ԍ�
			row[Ct_CsLedger_SlipNo] = dmd.SalesSlipNum;
			// �󒍁E�������e
			// Todo:���e���\������Ȃ��Ƃ��͂���������
            string slipDetail = "";
            
            switch (dmd.SalesGoodsCd)
            { 
                case 0:
                    slipDetail = "���i";
                    break;
                case 1:
                    slipDetail = "�� �i �O";
                    break;
                case 2:
                    slipDetail = "����Œ���";
                    break;
                case 3:
                    slipDetail = "�c������";
                    break;
                case 4:
                    slipDetail = "���|�p����Œ���";
                    break;
                case 5:
                    slipDetail = "���|�p�c������";
                    break;
            }
            row[Ct_CsLedger_SlipDetail] = slipDetail;
			
			// ������z
            // �c�������̏ꍇ
            if ((dmd.SalesGoodsCd == 3) || (dmd.SalesGoodsCd == 5)) 
            {
                row[Ct_CsLedger_SalesTotal] = dmd.SalesSubtotalTaxInc;
                row[Ct_CsLedger_SalesTotal1] = dmd.SalesSubtotalTaxInc;
            }
            else
            {
                // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� >>>>>>START
                //row[Ct_CsLedger_SalesTotal] = dmd.SalesSubtotalTaxExc;
                row[Ct_CsLedger_SalesTotal] = dmd.SalesTotalTaxExc;
                // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� <<<<<<END
                row[Ct_CsLedger_SalesTotal1] = 0;

            }
            // ��������
            row[Ct_CsLedger_SalesSubtotalTax] = dmd.SalesSubtotalTax;
            // ��������(�����p)
            if ((dmd.SalesGoodsCd == 2) || (dmd.SalesGoodsCd == 4))
            {
                row[Ct_CsLedger_SalesSubtotalTax1] = dmd.SalesSubtotalTax;
            }
            else
            {
                row[Ct_CsLedger_SalesSubtotalTax1] = 0;
            }
            // �ō����v
            // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� >>>>>>START
            //row[Ct_CsLedger_ThisSalesTaxTotal] = dmd.SalesSubtotalTaxExc + dmd.SalesSubtotalTax;
            row[Ct_CsLedger_ThisSalesTaxTotal] = dmd.SalesTotalTaxExc + dmd.SalesSubtotalTax;
            // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� <<<<<<END
            // ���l
			row[Ct_CsLedger_SlipNote] = dmd.SlipNote;
            // ���l2
            row[Ct_CsLedger_SlipNote2] = dmd.SlipNote2;

            //���}�[�N1
            row[Ct_CsLedger_UOERemark1] = dmd.UoeRemark1;
            //���}�[�N2
            row[Ct_CsLedger_UOERemark2] = dmd.UoeRemark2;

            // �c���v�Z�͔���E������DataTable�ɃZ�b�g������ōs���܂��B
			
			row[Ct_CsLedger_AddUpSecCode] = dmd.DemandAddUpSecCd;	// �v�㋒�_�R�[�h
			// �v�㋒�_����
			string sectionName = "";
			if (_sectionHTable.ContainsKey(dmd.DemandAddUpSecCd))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[dmd.DemandAddUpSecCd];
				sectionName = secInfoSet.SectionGuideNm;
			}
			row[Ct_CsLedger_AddUpSecName] = sectionName;

            // �����`�[�ԍ��i���ׁj
            row[Ct_CsLedger_PartySlipNumDtl] = dmd.PartySaleSlipNum;

            // �󎚋敪
            row[Ct_CsLedger_PrtDiv] = 1;

   			return row;
		}

		/// <summary>
		/// �����񂩂猳���Ɖ�׏��f�[�^�s�ݒ菈��
		/// </summary>
		/// <param name="addUpDate">�v��N����(���P��)</param>
		/// <param name="dmd">��������f�[�^�N���X</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : �����񂩂猳���Ɖ�׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
        private static DataRow SalesToCsLedgerDtlDataRow(int addUpDate, LedgerSalesDetailWork dmd)
		{
			DataRow row = _csLedgerDtlDataTable.NewRow();

            // ������R�[�h
            row[Ct_CsLedgerDtl_ClaimCode] = dmd.ClaimCode;
            // ���Ӑ�R�[�h
            row[Ct_CsLedgerDtl_CustomerCode] = dmd.CustomerCode;
			// �v��N����
            row[Ct_CsLedgerDtl_AddUpDate] = addUpDate;
			// ���R�[�h�敪(0:����,1:����)
            row[Ct_CsLedgerDtl_RecordCode] = LedgerDtlRecordState.Sales;
			// �O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)
            row[Ct_CsLedgerDtl_BalanseCode] = LedgerDtlBalanseState.Others;
			// �ԓ`�敪(0:��,1:��,2���E�ςݍ�)
            row[Ct_CsLedgerDtl_DebitNoteDiv] = dmd.DebitNoteDiv;
            if (dmd.DebitNoteDiv == 0)
            {
                row[Ct_CsLedgerDtl_DebitNoteDiv] = 2;
			}
			// �v����t
            row[Ct_CsLedgerDtl_AddUpADate] = dmd.AddUpADate;
			// �v����t(Int)
            row[Ct_CsLedgerDtl_AddUpADateInt] = TDateTime.DateTimeToLongDate(dmd.AddUpADate);
			// �v����t(�\���p)
            row[Ct_CsLedgerDtl_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", dmd.AddUpADate);
            // ����`�[�敪
            row[Ct_CsLedgerDtl_SalesSlipCd] = dmd.SalesSlipCd;
            string sliptypenm = "";
            switch (dmd.SalesSlipCd)
			{
				case 0:
					sliptypenm = "����";
					break;
				case 1:
					sliptypenm = "�ԕi";
					break;
				default:
					sliptypenm = "����";
					break;
			}
            row[Ct_CsLedgerDtl_SalesSlipKindName] = sliptypenm;

			// �`�[�ԍ��E�����ԍ�
            row[Ct_CsLedgerDtl_SlipNo] = dmd.SalesSlipNum;
            // �v�㋒�_�R�[�h
            row[Ct_CsLedgerDtl_AddUpSecCode] = dmd.DemandAddUpSecCd;	
			// �v�㋒�_����
			string sectionName = "";
			if (_sectionHTable.ContainsKey(dmd.DemandAddUpSecCd))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[dmd.DemandAddUpSecCd];
				sectionName = secInfoSet.SectionGuideNm;
			}
            row[Ct_CsLedgerDtl_AddUpSecName] = sectionName;
            // ������z                          
            // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� >>>>>>START
            //row[Ct_CsLedgerDtl_SalesTotal] = dmd.SalesSubtotalTaxExc;
            row[Ct_CsLedgerDtl_SalesTotal] = dmd.SalesTotalTaxExc;
            // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� <<<<<<END
            // ��������                           
            row[Ct_CsLedgerDtl_SalesSubtotalTax] = dmd.SalesSubtotalTax;
            // �ō�����z
            // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� >>>>>>START
            //row[Ct_CsLedgerDtl_ThisSalesTaxTotal] = dmd.SalesSubtotalTaxExc + dmd.SalesSubtotalTax;
            row[Ct_CsLedgerDtl_ThisSalesTaxTotal] = dmd.SalesTotalTaxExc + dmd.SalesSubtotalTax;
            // 2009.03.02 30413 ���� ����`�[���v�i�Ŕ����j�̒ǉ� <<<<<<END
            // �`�[���l
            row[Ct_CsLedgerDtl_SlipNote] = dmd.SlipNote; 
            // �`�[���l2
            row[Ct_CsLedgerDtl_SlipNote2] = dmd.SlipNote2;
            //���}�[�N1
            row[Ct_CsLedgerDtl_UOERemark1] = dmd.UoeRemark1;
            //���}�[�N2
            row[Ct_CsLedgerDtl_UOERemark2] = dmd.UoeRemark2;
            // ����s�ԍ�
            row[Ct_CsLedgerDtl_SalesRowNo] = dmd.SalesRowNo;
            // ���[�J�[����
            // ���i�ԍ�
            row[Ct_CsLedgerDtl_GoodsNo] = dmd.GoodsNo;
            // ���i����
            row[Ct_CsLedgerDtl_GoodsName] = dmd.GoodsName;
            // �o�א�
            // ����P��
            if ((dmd.SalesGoodsCd == 0) || (dmd.SalesGoodsCd == 1))
            {
                row[Ct_CsLedgerDtl_ShipmentCnt] = dmd.ShipmentCnt;
                row[Ct_CsLedgerDtl_SalesUnPrcTaxExcFl] = dmd.SalesUnPrcTaxExcFl;
            }
            else
            {
                row[Ct_CsLedgerDtl_ShipmentCnt] = 0;
                row[Ct_CsLedgerDtl_SalesUnPrcTaxExcFl] = 0;
            }
            // ������z
            // �c�������̏ꍇ
            if ((dmd.SalesGoodsCd == 3) || (dmd.SalesGoodsCd == 5))
            {
                row[Ct_CsLedgerDtl_SalesMoneyTaxExc] = dmd.SalesSubtotalTaxInc;
                row[Ct_CsLedgerDtl_SalesMoneyTaxExc1] = dmd.SalesSubtotalTaxInc;
            }
            else
            {
                if ((dmd.SalesGoodsCd == 0) || (dmd.SalesGoodsCd == 1))
                {
                    row[Ct_CsLedgerDtl_SalesMoneyTaxExc] = dmd.SalesMoneyTaxExc;
                }
                else
                {
                    row[Ct_CsLedgerDtl_SalesMoneyTaxExc] = 0;
                }
                row[Ct_CsLedgerDtl_SalesMoneyTaxExc1] = 0;
            }
            // ������z�����
            // ����Œ����̏ꍇ
            if ((dmd.SalesGoodsCd == 2) || (dmd.SalesGoodsCd == 4))
            {
                row[Ct_CsLedgerDtl_SalsePriceConsTax] = dmd.SalesSubtotalTax;
                row[Ct_CsLedgerDtl_SalsePriceConsTax1] = dmd.SalesSubtotalTax;
            }
            else
            {
                if ((dmd.SalesGoodsCd == 0) || (dmd.SalesGoodsCd == 1))
                {
                    row[Ct_CsLedgerDtl_SalsePriceConsTax] = dmd.SalesPriceConsTax;
                }
                else
                {
                    row[Ct_CsLedgerDtl_SalsePriceConsTax] = 0;
                }
                row[Ct_CsLedgerDtl_SalsePriceConsTax1] = 0;
            }
           
            // ���i����
            row[Ct_CsLedgerDtl_SupplierCd] = dmd.SupplierCd;

            // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� >>>>>>START
            // ����œ]�ŕ���
            row[Ct_CsLedgerDtl_ConsTaxLayMethod] = dmd.ConsTaxLayMethod;
            // �ېŋ敪
            row[Ct_CsLedgerDtl_TaxationDivCd] = dmd.TaxationDivCd;
            // 2009.02.25 30413 ���� ����œ]�ŕ����̒ǉ� <<<<<<END
                                    
           return row;
		}
		#endregion

		#region �� ������񂩂猳�����׏��f�[�^�s�ݒ菈��
		/// <summary>
		/// ������񂩂猳�����׏��f�[�^�s�ݒ菈��
		/// </summary>
		/// <param name="AddUpDate">�v��N����(���P��)</param>
		/// <param name="depsit">�����f�[�^�N���X</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : ������񂩂猳�����׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow DepsitToCsLedgerSlipDataRow(int AddUpDate, LedgerDepsitMainWork depsit)
		{
			DataRow row = _csLedgerSlipDataTable.NewRow();

			// ������R�[�h
			row[Ct_CsLedger_ClaimCode] = depsit.ClaimCode;
			// ���Ӑ�R�[�h
			row[Ct_CsLedger_CustomerCode] = depsit.CustomerCode;
			// �v��N����
			row[Ct_CsLedger_AddUpDate] = AddUpDate;
			// ���R�[�h�敪(0:����,1:����)
			row[Ct_CsLedger_RecordCode] = LedgerDtlRecordState.Deposit;
			// �O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)
			row[Ct_CsLedger_BalanseCode] = LedgerDtlBalanseState.Others;
			// �ԓ`�敪(0:��,1:��,2���E�ςݍ�)
			row[Ct_CsLedger_DebitNoteDiv] = depsit.DepositDebitNoteCd;
			// �v����t
			row[Ct_CsLedger_AddUpADate] = depsit.DepositDate;
			// �v����t
			row[Ct_CsLedger_AddUpADateInt] = TDateTime.DateTimeToLongDate( depsit.DepositDate );
			// �v����t(�\���p)
			row[Ct_CsLedger_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", depsit.DepositDate);
			// ����`�[�敪
			row[Ct_CsLedger_SalesSlipCd] = 0;
			// �`�[���
            row[Ct_CsLedger_SalesSlipKindName] = "����";
            // ��������
            row[Ct_CsLedgerDtl_GoodsName] = string.Format("{0}", depsit.MoneyKindName);
            // �����ԍ�
            row[Ct_CsLedger_SlipNo] = String.Format("{0:D9}", depsit.DepositSlipNo);
            // ��`�x������(�\���p)
            row[Ct_CsLedger_DraftPayTimeLimit] = TDateTime.DateTimeToString("YYYY/MM/DD", depsit.ValidityTerm);
            // �������z
            row[Ct_CsLedger_Deposit] = depsit.Deposit;
			row[Ct_CsLedger_AddUpSecCode] = depsit.AddUpSecCode;	// �v�㋒�_�R�[�h
			// �v�㋒�_����
			string sectionName = "";
			if (_sectionHTable.ContainsKey(depsit.AddUpSecCode))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[depsit.AddUpSecCode];
				sectionName = secInfoSet.SectionGuideNm;
			}
			row[Ct_CsLedger_AddUpSecName] = sectionName;

            // �󎚋敪
            row[Ct_CsLedger_PrtDiv] = 1;

			return row;
		}
		#endregion

        #region �� ������񂩂猳�����׏��f�[�^�s�ݒ菈��
        /// <summary>
        /// ������񂩂猳�����׏��f�[�^�s�ݒ菈��
        /// </summary>
        /// <param name="AddUpDate">�v��N����(���P��)</param>
        /// <param name="depsit">�����f�[�^�N���X</param>
        /// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
        /// <remarks>
        /// <br>Note        : ������񂩂猳�����׏��̃f�[�^�s�֐ݒ肵�܂��B</br>
        /// <br>Programer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.10.18</br>
        /// </remarks>
        private static DataRow DepsitToCsLedgerDtlDataRow(int AddUpDate, LedgerDepsitMainWork depsit)
        {
            DataRow row = _csLedgerDtlDataTable.NewRow();

            // ������R�[�h
            row[Ct_CsLedgerDtl_ClaimCode] = depsit.ClaimCode;
            // ���Ӑ�R�[�h
            row[Ct_CsLedgerDtl_CustomerCode] = depsit.CustomerCode;
            // �v��N����
            row[Ct_CsLedgerDtl_AddUpDate] = AddUpDate;
            // ���R�[�h�敪(0:����,1:����)
            row[Ct_CsLedgerDtl_RecordCode] = LedgerDtlRecordState.Deposit;
            // �O�c�J�z�敪(0:�O�c,1:���̑�(�� or ��),2:�J�z)
            row[Ct_CsLedgerDtl_BalanseCode] = LedgerDtlBalanseState.Others;
            // �ԓ`�敪(0:��,1:��,2���E�ςݍ�)
            row[Ct_CsLedgerDtl_DebitNoteDiv] = depsit.DepositDebitNoteCd;
            // �v����t
            row[Ct_CsLedgerDtl_AddUpADate] = depsit.DepositDate;
            // �v����t
            row[Ct_CsLedgerDtl_AddUpADateInt] = TDateTime.DateTimeToLongDate(depsit.DepositDate);
            // �v����t(�\���p)
            row[Ct_CsLedgerDtl_AddUpADateDisp] = TDateTime.DateTimeToString("YYYY/MM/DD", depsit.DepositDate);
            // ����`�[�敪
            row[Ct_CsLedgerDtl_SalesSlipCd] = 0;
            // �`�[���
            row[Ct_CsLedgerDtl_SalesSlipKindName] = "����";
            // �����ԍ�
            row[Ct_CsLedgerDtl_SlipNo] = String.Format("{0:000000000}", depsit.DepositSlipNo);
            // ��`�x������(�\���p)
            row[Ct_CsLedgerDtl_DraftPayTimeLimit] = TDateTime.DateTimeToString("YYYY/MM/DD", depsit.ValidityTerm);
            // ��������
            row[Ct_CsLedgerDtl_GoodsName] = string.Format("{0}", depsit.MoneyKindName);
            // �������z
            row[Ct_CsLedgerDtl_Deposit] = depsit.Deposit;
            row[Ct_CsLedgerDtl_AddUpSecCode] = depsit.AddUpSecCode;	// �v�㋒�_�R�[�h
            // �v�㋒�_����
            string sectionName = "";
            if (_sectionHTable.ContainsKey(depsit.AddUpSecCode))
            {
                SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[depsit.AddUpSecCode];
                sectionName = secInfoSet.SectionGuideNm;
            }
            row[Ct_CsLedgerDtl_AddUpSecName] = sectionName;

            return row;
        }
        #endregion

		#region �� ���Ӑ���StaticMemory�ݒ菈��
		/// <summary>
		/// ���Ӑ���StaticMemory�ݒ菈��
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="custDmdPrcInfGetWorks">KINGET�p�����[�^</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : KINGET�p�����[�^��蓾�Ӑ����StaticMemory�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static int CustDmdPrcWorkToCustomer(string enterpriseCode, ArrayList custDmdPrcInfGetWorks)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			string key = "";
			
			foreach (CustDmdPrcInfGetWork custDmdPrcInfGetWork in custDmdPrcInfGetWorks)
			{
                key = custDmdPrcInfGetWork.ClaimCode.ToString() + "_" + TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate).ToString() + "_" + custDmdPrcInfGetWork.AddUpSecCode;

				if (!_csLedgerCustomerHTable.ContainsKey(key))
				{
					CsLedgerCustomer cs = new CsLedgerCustomer();

                    // ������R�[�h
                    cs.ClaimCode = custDmdPrcInfGetWork.ClaimCode;
                    // ����
                    cs.SNm = custDmdPrcInfGetWork.ClaimSnm;
                    // ���Ӑ�R�[�h
					cs.CustomerCode = custDmdPrcInfGetWork.CustomerCode;
					// ����
					cs.Name = custDmdPrcInfGetWork.CustomerName;
					// ���̂Q
					cs.Name2 = custDmdPrcInfGetWork.CustomerName2;
					// ����œ]�ŕ���
					cs.CustTaxLayCd = custDmdPrcInfGetWork.ConsTaxLayMethod;
					
					_csLedgerCustomerHTable.Add(key, cs);
				}
				
			}
			return status;
		}
		#endregion

		#region �� ���Ӑ���StaticMemory�ݒ菈��
		/// <summary>
		/// ���Ӑ���StaticMemory�ݒ菈��
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="custAccRecInfGetWorks">KINGET�p�����[�^</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note        : KINGET�p�����[�^��蓾�Ӑ����StaticMemory�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static int CustAccRecWorkToCustomer(string enterpriseCode, ArrayList custAccRecInfGetWorks)
		{
		    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			string key = "";

			foreach (CustAccRecInfGetWork custAccRecInfGetWork in custAccRecInfGetWorks)
		    {
				
                key = custAccRecInfGetWork.ClaimCode.ToString() + "_" + TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpDate).ToString() + "_" + custAccRecInfGetWork.AddUpSecCode;

				if (!_csLedgerCustomerHTable.ContainsKey(key))
		        {
		            CsLedgerCustomer cs = new CsLedgerCustomer();

                    // ������R�[�h
                    cs.ClaimCode = custAccRecInfGetWork.ClaimCode;
                    // �����旪��
                    cs.SNm = custAccRecInfGetWork.ClaimSnm;
		            // ���Ӑ�R�[�h
		            cs.CustomerCode = custAccRecInfGetWork.CustomerCode;
		            // ����
		            cs.Name = custAccRecInfGetWork.CustomerName;
		            // ���̂Q
		            cs.Name2 = custAccRecInfGetWork.CustomerName2;
                    cs.SNm = custAccRecInfGetWork.CustomerSnm;

					// ����œ]�ŕ���
					cs.CustTaxLayCd = custAccRecInfGetWork.ConsTaxLayMethod;

					_csLedgerCustomerHTable.Add(key, cs);
		        }
				
		    }
		    return status;
		}
		#endregion

		#region �� ���Ӑ搿�����z���f�[�^�s�ݒ菈��(����)
		/// <summary>
		/// ���Ӑ搿�����z���f�[�^�s�ݒ菈��(����)
		/// </summary>
        /// <param name="custDmdPrcInfGetWork">����KINGET�߂�p�����[�^</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : ���Ӑ搿�����z�����f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow CustDmdPrcWorkToDataRow(CustDmdPrcInfGetWork custDmdPrcInfGetWork)
		{
			DataRow newRow = _custDmdPrcDataTable.NewRow();

			CustDmdPrcWorkToDataRow( ref newRow, custDmdPrcInfGetWork );

			return newRow;
		}
		#endregion

		#region �� ���Ӑ搿�����z���f�[�^�s�ݒ菈��(����)
		/// <summary>
		/// ���Ӑ搿�����z���f�[�^�s�ݒ菈��(����)
		/// </summary>
		/// <param name="newRow">�Ώۍs</param>
        /// <param name="custDmdPrcInfGetWork">����KINGET�߂�p�����[�^</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : ���Ӑ搿�����z�����f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow CustDmdPrcWorkToDataRow(ref DataRow newRow, CustDmdPrcInfGetWork custDmdPrcInfGetWork)
		{
			// �v�㋒�_�R�[�h
			newRow[Ct_CsDmd_AddUpSecCode] = custDmdPrcInfGetWork.AddUpSecCode;

			// �v�㋒�_����
			string sectionName = "";
			if (_sectionHTable.ContainsKey(custDmdPrcInfGetWork.AddUpSecCode))
			{
				SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[custDmdPrcInfGetWork.AddUpSecCode];
				sectionName = secInfoSet.SectionGuideNm;
			}

			newRow[Ct_CsDmd_AddUpSecName] = sectionName;

            newRow[Ct_CsDmd_ClaimCode] = custDmdPrcInfGetWork.ClaimCode;        // ������R�[�h
            newRow[Ct_CsDmd_ClaimSnm]  = custDmdPrcInfGetWork.ClaimSnm;         // �����旪��
            newRow[Ct_CsDmd_CustomerCode] = custDmdPrcInfGetWork.CustomerCode;  // ���Ӑ�R�[�h
            newRow[Ct_CsDmd_CustomerSnm] = custDmdPrcInfGetWork.CustomerSnm;    // ���Ӑ旪��
            newRow[Ct_CsDmd_AddUpDate] = custDmdPrcInfGetWork.AddUpDate;                                      // �v��N����
            newRow[Ct_CsDmd_SlitTitle] = "�����c";                                      // ���[�^�C�g��
            newRow[Ct_CsDmd_AddUpDateInt] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate);      // �v��N����
			newRow[Ct_CsDmd_AddUpYearMonth		]	= TDateTime.DateTimeToLongDate( custDmdPrcInfGetWork.AddUpYearMonth ); // �v��N��
			newRow[Ct_CsDmd_LastTimeDemand		]	= custDmdPrcInfGetWork.LastTimeDemand;                                 // �O�񐿋����z
			newRow[Ct_CsDmd_ThisTimeDmdNrml		]	= custDmdPrcInfGetWork.ThisTimeDmdNrml;    // ����������z�i�ʏ�����j
			newRow[Ct_CsDmd_ThisTimeTtlBlcDmd	]	= custDmdPrcInfGetWork.ThisTimeTtlBlcDmd;  // ����J�z�c���i�����v�j
			newRow[Ct_CsDmd_OfsThisTimeSales	]	= custDmdPrcInfGetWork.OfsThisTimeSales;   // ���E�㍡�񔄏���z           
			newRow[Ct_CsDmd_OfsThisSalesTax	    ]	= custDmdPrcInfGetWork.OfsThisSalesTax;    // ���E�㍡�񔄏�����                      
            newRow[Ct_CsDmd_ThisTimeSales       ]   = custDmdPrcInfGetWork.ThisTimeSales;      // ���񔄏���z
			newRow[Ct_CsDmd_AfCalDemandPrice	]	= custDmdPrcInfGetWork.AfCalDemandPrice;    // �v�Z�㐿�����z
			newRow[Ct_CsDmd_AcpOdrTtl2TmBfBlDmd	]	= custDmdPrcInfGetWork.AcpOdrTtl2TmBfBlDmd; // ��2��O�c���i�����v�j
			newRow[Ct_CsDmd_AcpOdrTtl3TmBfBlDmd	]	= custDmdPrcInfGetWork.AcpOdrTtl3TmBfBlDmd; // ��3��O�c���i�����v�j
			newRow[Ct_CsDmd_CAddUpUpdExecDate	]	= TDateTime.DateTimeToLongDate( custDmdPrcInfGetWork.CAddUpUpdExecDate ); // �����X�V���s�N����
			newRow[Ct_CsDmd_CloseFlag			]	= custDmdPrcInfGetWork.CloseFlg;            // ���σt���O
            // 2009.03.02 30413 ���� �ԕi�A�l���̕����𔽓]������ >>>>>>START
            //newRow[Ct_CsDmd_ThisRgdsDis         ]   = custDmdPrcInfGetWork.ThisSalesPricRgds + custDmdPrcInfGetWork.ThisSalesPricDis; // �ԕi�E�l���z
            newRow[Ct_CsDmd_ThisRgdsDis         ]   = -(custDmdPrcInfGetWork.ThisSalesPricRgds + custDmdPrcInfGetWork.ThisSalesPricDis); // �ԕi�E�l���z
            // 2009.03.02 30413 ���� �ԕi�A�l���̕����𔽓]������ <<<<<<END
            newRow[Ct_CsDmd_ThisSalesTaxTotal] = custDmdPrcInfGetWork.OfsThisTimeSales + custDmdPrcInfGetWork.OfsThisSalesTax;   // �ō�����z
            newRow[Ct_CsDmd_StartDateSpan] = TDateTime.DateTimeToLongDate( custDmdPrcInfGetWork.StartCAddUpUpdDate );   // ���t�͈́i�J�n�j
            newRow[Ct_CsDmd_EndDateSpan] = TDateTime.DateTimeToLongDate(custDmdPrcInfGetWork.AddUpDate);     // ���t�͈́i�I���j
            newRow[Ct_CsDmd_Name] = custDmdPrcInfGetWork.CustomerName;    // ���Ӑ於��
			newRow[Ct_CsDmd_Name2				]	= custDmdPrcInfGetWork.CustomerName2;   // ���Ӑ於��2
			
			int yy = 0;
			int mm = 0;
			int dd = 0;
			string strGengo = "";
			int status;

			// �v��N��(����p)
			status = TDateTime.SplitDate("YYYYMMDD", custDmdPrcInfGetWork.AddUpYearMonth,
			    ref strGengo,
			    ref yy,
			    ref mm,
			    ref dd);
			if (status == 0)
			{
				newRow[Ct_CsDmd_PrintAddUpYearMonth] = yy * 100 + mm;
			}

			// �v��N����(����p)
			newRow[Ct_CsDmd_PrintAddUpDate] = TDateTime.DateTimeToLongDate( custDmdPrcInfGetWork.AddUpDate );

            // �ԕi�E�l�����v
            newRow[Col_CsDmd_RgdsDisT           ]   = custDmdPrcInfGetWork.ThisSalesPricRgds + custDmdPrcInfGetWork.ThisSalesPricDis;

            // ����`�[����
            newRow[Col_CsDmd_SalesSlipCount] = custDmdPrcInfGetWork.SalesSlipCount;	       // ���`�`�[����

			newRow.EndEdit();

			return newRow;
		}
		#endregion

		#region �� ���Ӑ搿�����z���f�[�^�s�ݒ菈��(���|)
		/// <summary>
		/// ���Ӑ搿�����z���f�[�^�s�ݒ菈��(���|)
		/// </summary>
		/// <param name="custAccRecInfGetWork">���|KINGET�߂�p�����[�^</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : ���Ӑ搿�����z�����f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow CustAccRecWorkToDataRow(CustAccRecInfGetWork custAccRecInfGetWork)
		{
			DataRow newRow = _custDmdPrcDataTable.NewRow();

			CustAccRecWorkToDataRow( ref newRow, custAccRecInfGetWork );

			return newRow;
		}
		#endregion
		#region �� ���Ӑ搿�����z���f�[�^�s�ݒ菈��(���|)
		/// <summary>
		/// ���Ӑ搿�����z���f�[�^�s�ݒ菈��(���|)
		/// </summary>
		/// <param name="newRow">�Ώۍs</param>
		/// <param name="custAccRecInfGetWork">����KINGET�߂�p�����[�^</param>
		/// <returns>�ݒ肳�ꂽ�f�[�^�s</returns>
		/// <remarks>
		/// <br>Note        : ���Ӑ搿�����z�����f�[�^�s�֐ݒ肵�܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static DataRow CustAccRecWorkToDataRow(ref DataRow newRow, CustAccRecInfGetWork custAccRecInfGetWork)
		{
		    // �v�㋒�_�R�[�h
		    newRow[Ct_CsDmd_AddUpSecCode] = custAccRecInfGetWork.AddUpSecCode;

		    // �v�㋒�_����
		    string sectionName = "";
		    if (_sectionHTable.ContainsKey(custAccRecInfGetWork.AddUpSecCode))
		    {
		        SecInfoSet secInfoSet = (SecInfoSet)_sectionHTable[custAccRecInfGetWork.AddUpSecCode];
		        sectionName = secInfoSet.SectionGuideNm;
		    }

		    newRow[Ct_CsDmd_AddUpSecName] = sectionName;
            newRow[Ct_CsDmd_ClaimCode	] = custAccRecInfGetWork.ClaimCode;     // ������R�[�h
            newRow[Ct_CsDmd_ClaimSnm	] = custAccRecInfGetWork.ClaimSnm;      // �����旪��
            newRow[Ct_CsDmd_SlitTitle] = "���|�c";                                      // ���[�^�C�g��
            newRow[Ct_CsDmd_CustomerCode] = custAccRecInfGetWork.CustomerCode;                              // ���Ӑ�R�[�h
		    newRow[Ct_CsDmd_CustomerSnm		    ]	= custAccRecInfGetWork.CustomerSnm;                               // ���Ӑ旪��
            newRow[Ct_CsDmd_AddUpDate			]	= custAccRecInfGetWork.AddUpDate;                                 // �v��N����
		    newRow[Ct_CsDmd_AddUpDateInt		]	= TDateTime.DateTimeToLongDate( custAccRecInfGetWork.AddUpDate ); // �v��N����
		    newRow[Ct_CsDmd_AddUpYearMonth		]	= TDateTime.DateTimeToLongDate( custAccRecInfGetWork.AddUpYearMonth ); // �v��N��
		    newRow[Ct_CsDmd_LastTimeDemand		]	= custAccRecInfGetWork.LastTimeAccRec;  // �O�񐿋����z

		    newRow[Ct_CsDmd_ThisTimeDmdNrml		]	= custAccRecInfGetWork.ThisTimeDmdNrml;    // ����������z�i�ʏ�����j
		    newRow[Ct_CsDmd_ThisTimeTtlBlcDmd	]	= custAccRecInfGetWork.ThisTimeTtlBlcAcc;  // ����J�z�c���i�����v�j
            newRow[Ct_CsDmd_OfsThisTimeSales	]	= custAccRecInfGetWork.OfsThisTimeSales;   // ���E�㍡�񔄏���z
            newRow[Ct_CsDmd_OfsThisSalesTax	    ]	= custAccRecInfGetWork.OfsThisSalesTax;    // ���E�㍡�񔄏�����
            newRow[Ct_CsDmd_ThisTimeSales       ]   = custAccRecInfGetWork.ThisTimeSales;      // ���񔄏���z
		    newRow[Ct_CsDmd_AfCalDemandPrice	]	= custAccRecInfGetWork.AfCalTMonthAccRec;    // �v�Z�㐿�����z
		    newRow[Ct_CsDmd_AcpOdrTtl2TmBfBlDmd	]	= custAccRecInfGetWork.AcpOdrTtl2TmBfAccRec; // ��2��O�c���i�����v�j
		    newRow[Ct_CsDmd_AcpOdrTtl3TmBfBlDmd	]	= custAccRecInfGetWork.AcpOdrTtl3TmBfAccRec; // ��3��O�c���i�����v�j
		    newRow[Ct_CsDmd_CAddUpUpdExecDate	]	= 0; // �����X�V���s�N����
		    newRow[Ct_CsDmd_CloseFlag			]	= custAccRecInfGetWork.CloseFlg; // ���σt���O
            // 2009.03.02 30413 ���� �ԕi�A�l���̕����𔽓]������ >>>>>>START
            //newRow[Ct_CsDmd_ThisRgdsDis         ]   = custAccRecInfGetWork.ThisSalesPricRgds + custAccRecInfGetWork.ThisSalesPricDis; // �ԕi�E�l��
            newRow[Ct_CsDmd_ThisRgdsDis         ]   = -(custAccRecInfGetWork.ThisSalesPricRgds + custAccRecInfGetWork.ThisSalesPricDis); // �ԕi�E�l��
            // 2009.03.02 30413 ���� �ԕi�A�l���̕����𔽓]������ <<<<<<END
            newRow[Ct_CsDmd_ThisSalesTaxTotal] = custAccRecInfGetWork.OfsThisTimeSales + custAccRecInfGetWork.OfsThisSalesTax;   // �ō�
            newRow[Ct_CsDmd_StartDateSpan] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.StMonCAddUpUpdDate); // ���t�͈́i�J�n�j
            newRow[Ct_CsDmd_EndDateSpan] = TDateTime.DateTimeToLongDate(custAccRecInfGetWork.AddUpDate); // ���t�͈́i�I���j
		    newRow[Ct_CsDmd_Name				]	= custAccRecInfGetWork.CustomerName; // ���Ӑ於��
		    newRow[Ct_CsDmd_Name2				]	= custAccRecInfGetWork.CustomerName2; // ���Ӑ於��2

		    int yy = 0;
		    int mm = 0;
		    int dd = 0;
		    string strGengo = "";
		    int status;

		    // �v��N��(����p)
		    status = TDateTime.SplitDate("YYYYMMDD", custAccRecInfGetWork.AddUpYearMonth,
		        ref strGengo,
		        ref yy,
		        ref mm,
		        ref dd);
		    if (status == 0)
		    {
				newRow[Ct_CsDmd_PrintAddUpYearMonth] = yy * 100 + mm;
		    }

		    // �v��N����(����p)
			newRow[Ct_CsDmd_PrintAddUpDate] = TDateTime.DateTimeToLongDate( custAccRecInfGetWork.AddUpDate );

             // �ԕi�E�l��
            newRow[Col_CsDmd_RgdsDisT         ] = custAccRecInfGetWork.ThisSalesPricRgds + custAccRecInfGetWork.ThisSalesPricDis;

            // ���`�`�[����
            newRow[Col_CsDmd_SalesSlipCount	  ]	= custAccRecInfGetWork.SalesSlipCount;	    

            newRow[Col_CsDmd_LastTimeAccRec	  ]	= custAccRecInfGetWork.LastTimeAccRec;                                            // �O�񔄊|���z

            newRow[Col_CsDmd_ThisTimeTtlBlcAcc]	= custAccRecInfGetWork.ThisTimeTtlBlcAcc;                                         // ����J�z�c��

            newRow[Col_CsDmd_TimeSalesTax     ] = custAccRecInfGetWork.OfsThisTimeSales + custAccRecInfGetWork.OfsThisSalesTax;   // �ō�����z
            
            newRow[Col_CsDmd_AfCalTMonthAccRec]	= custAccRecInfGetWork.AfCalTMonthAccRec;                                         // �v�Z�㐿�����z

		    newRow.EndEdit();

		    return newRow;
		}
		#endregion


        #region �� �ڋq�ʌv��N���͈͎擾����
        /// <summary>
		/// �ڋq�ʌv��N���͈͎擾����
		/// </summary>
		/// <param name="cutomerCode">���Ӑ�R�[�h</param>
		/// <param name="viewSecCd">�\�����_�R�[�h</param>
		/// <remarks>
		/// <br>Note        : ���\�b�h���e��������܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
        public static void SetCustomerAddUpDateSpanAndAddUpDate(int cutomerCode, string viewSecCd)
		{
            //������Privte��Public�ɕύX
			string sort = Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_AddUpDate;
			string filter = String.Format("{0} = {1} AND {2} = '{3}'", Ct_CsDmd_ClaimCode, cutomerCode, Ct_CsDmd_AddUpSecCode, viewSecCd);
			DataView dv = new DataView(_custDmdPrcDataTable, filter, sort, DataViewRowState.CurrentRows);

			// �S�Ѓ��R�[�h�݂̂ōi�荞��        

			if (dv.Count > 0)
			{
				CsLedgerDmdPrc csDmdPrc;

				// �J�n�擾
				csDmdPrc = DataRowToCsLedgerDmdPrc(dv[0].Row);
				_ttlAddUpDateSpanStart = TDateTime.LongDateToDateTime(csDmdPrc.StartDateSpan);
				_addUpDateStart = csDmdPrc.AddUpDate;

				// �I���擾
				csDmdPrc = DataRowToCsLedgerDmdPrc(dv[dv.Count - 1].Row);

				if ( ( csDmdPrc.CloseFlag == (int)CloseFlagState.NotClose ) &&  ( dv.Count > 1 ))
				{
					csDmdPrc = DataRowToCsLedgerDmdPrc(dv[dv.Count - 2].Row);
				}

				_ttlAddUpDateSpanEnd = TDateTime.LongDateToDateTime(csDmdPrc.EndDateSpan);
				_addUpDateEnd = csDmdPrc.AddUpDate;
			}
		}
		#endregion

		#region �� �f�[�^�s��蓾�Ӑ搿�����(�����Ɖ�p)�擾
		/// <summary>
		/// �f�[�^�s��蓾�Ӑ搿�����(�����Ɖ�p)�擾
		/// </summary>
		/// <param name="dr">�f�[�^�s���</param>
		/// <returns>���Ӑ搿�����z���(�����Ɖ�p�ɉ��H�ς�)</returns>
		/// <remarks>
		/// <br>Note        : �f�[�^�s��茳���Ɖ�p�ɉ��H���ꂽ���Ӑ搿��(��)�����擾���܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static CsLedgerDmdPrc DataRowToCsLedgerDmdPrc(DataRow dr)
		{
			CsLedgerDmdPrc csLedgerDmdPrc = new CsLedgerDmdPrc();

			csLedgerDmdPrc.AddUpSecCode				= GetCellString		(dr[Ct_CsDmd_AddUpSecCode			]);		// �v�㋒�_�R�[�h
            csLedgerDmdPrc.ClaimCode				= GetCellInt32		(dr[Ct_CsDmd_ClaimCode			    ]);		// ������R�[�h
			csLedgerDmdPrc.CustomerCode				= GetCellInt32		(dr[Ct_CsDmd_CustomerCode			]);		// ���Ӑ�R�[�h
			csLedgerDmdPrc.AddUpDate				= GetCellDateTime	(dr[Ct_CsDmd_AddUpDate				]);		// �v��N����
			csLedgerDmdPrc.AddUpYearMonth			= GetCellInt32		(dr[Ct_CsDmd_AddUpYearMonth			]);		// �v��N��
			csLedgerDmdPrc.LastTimeDemand			= GetCellInt64		(dr[Ct_CsDmd_LastTimeDemand			]);		// �O�񐿋����z
            csLedgerDmdPrc.SlipCount = GetCellInt32(dr[Col_CsDmd_SalesSlipCount]);		// �`�[����
			csLedgerDmdPrc.ThisTimeDmdNrml			= GetCellInt64		(dr[Ct_CsDmd_ThisTimeDmdNrml		]);		// ����������z�i�ʏ�����j
			csLedgerDmdPrc.ThisTimeTtlBlcDmd		= GetCellInt64		(dr[Ct_CsDmd_ThisTimeTtlBlcDmd		]);		// ����J�z�c���i�����v�j
            csLedgerDmdPrc.OfsThisTimeSales         = GetCellInt64      (dr[Ct_CsDmd_OfsThisTimeSales       ]);		// ���E�㍡�񔄏���z
            csLedgerDmdPrc.OfsThisSalesTax          = GetCellInt64      (dr[Ct_CsDmd_OfsThisSalesTax        ]);		// ���E�㍡�񔄏�����
			csLedgerDmdPrc.ThisTimeSales			= GetCellInt64		(dr[Ct_CsDmd_ThisTimeSales			]);		// ���񔄏���z
            csLedgerDmdPrc.AfCalDemandPrice			= GetCellInt64		(dr[Ct_CsDmd_AfCalDemandPrice		]);		// �v�Z�㐿�����z
			csLedgerDmdPrc.AcpOdrTtl2TmBfBlDmd		= GetCellInt64		(dr[Ct_CsDmd_AcpOdrTtl2TmBfBlDmd	]);		// ��2��O�c���i�����v�j
			csLedgerDmdPrc.AcpOdrTtl3TmBfBlDmd		= GetCellInt64		(dr[Ct_CsDmd_AcpOdrTtl3TmBfBlDmd	]);		// ��3��O�c���i�����v�j
			csLedgerDmdPrc.StartDateSpan			= GetCellInt32		(dr[Ct_CsDmd_StartDateSpan			]);		// ���t�͈�(�J�n)
			csLedgerDmdPrc.EndDateSpan				= GetCellInt32		(dr[Ct_CsDmd_EndDateSpan			]);		// ���t�͈�(�I��)
			csLedgerDmdPrc.CloseFlag				= GetCellInt32		(dr[Ct_CsDmd_CloseFlag				]);		// ���σt���O
   			csLedgerDmdPrc.CustTaxLayMethod			= GetCellInt32		(dr[Ct_CsDmd_ConsTaxLayMethod		]);		// ����œ]�ŕ���
			return csLedgerDmdPrc;
		}

		#endregion

		#endregion

		#region �� �f�[�^�擾
		/// <summary>
		/// �f�[�^�Z����������擾
		/// </summary>
		/// <param name="cell">�f�[�^�Z��</param>
		/// <returns>�擾������</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static string GetCellString(object cell)
		{
			return (cell != DBNull.Value) ? (string)cell : string.Empty;
		}

		/// <summary>
		/// �f�[�^�Z����Int32�擾
		/// </summary>
		/// <param name="cell">�f�[�^�Z��</param>
		/// <returns>�擾���l</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static Int32 GetCellInt32(object cell)
		{
			return (cell != DBNull.Value) ? (Int32)cell : 0;
		}

		/// <summary>
		/// �f�[�^�Z����Int64�擾
		/// </summary>
		/// <param name="cell">�f�[�^�Z��</param>
		/// <returns>�擾���l</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static Int64 GetCellInt64(object cell)
		{
			return (cell != DBNull.Value) ? (Int64)cell : 0;
		}

		/// <summary>
		/// �f�[�^�Z����DateTime�擾
		/// </summary>
		/// <param name="cell">�f�[�^�Z��</param>
		/// <returns>�擾DateTime</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z���Ɋi�[����Ă���l��DBNull���ǂ����𔻕ʂ��Ēl��Ԃ��܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private static DateTime GetCellDateTime(object cell)
		{
			return (cell != DBNull.Value) ? (DateTime)cell : new DateTime(1, 1, 1);
		}
		#endregion
		#endregion

		#region �� Public Method
		#region �� �ϐ��������֘A
		#region �� �����ݒ���Ǎ�
		/// <summary>
		/// �����ݒ���Ǎ�
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ���̓Ǎ����s���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public int InitSettingDataRead(string enterpriseCode, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = string.Empty;

			try
			{
				// �����_�R�[�h���ݒ肳��Ă��Ȃ��ꍇ
				if (_mySectionCode == string.Empty)
				{
					message = "���O�C���S���҂̏������_���ݒ肳��Ă��܂���\n\r���_�ݒ���s���ċN�����Ă�������";
					return (int)ConstantManagement.MethodResult.ctFNC_WARNING;
				}

				// ���_���擾
				_sectionHTable.Clear();
				_secCodeList.Clear();

				foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
				{
					_sectionHTable.Add(secInfoSet.SectionCode, secInfoSet.Clone());
					_secCodeList.Add(secInfoSet.SectionCode);
				}
				_secCodeList.Sort(new SecInfoKey0());

				// �c���\�����_�擾
				status = GetOwnSeCtrlCode(_mySectionCode, SecInfoAcs.CtrlFuncCode.BalanceDispSecCd, out _targetSectionCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						message = String.Format("���_�R�[�h �u{0}�v�̎c���\�����_���ݒ肳��Ă��܂���", _mySectionCode)
											+ "\n\r���_����ݒ���s���ċN�����Ă�������";
						return status;
					}
					default:
					{
						message = String.Format("���_�R�[�h �u{0}�v�̋��_������̎擾�Ɏ��s���܂���", _mySectionCode)
											+ "\n\r���_����ݒ���s���ċN�����Ă�������";
						return status;
					}
				}

				// �{�Ћ@�\�L��
				_isMainOfficeFunc = (_secInfoAcs.GetMainOfficeFuncFlag(_mySectionCode) == 1);

				if ( _alItmDspNmAcs == null )
					_alItmDspNmAcs = new AlItmDspNmAcs();

				// �S�̍��ڕ\���ݒ�̎擾 
				status = _alItmDspNmAcs.ReadStatic(out _alItmDspNmData, enterpriseCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						break;
					default:
						message = "�S�̍��ڕ\���ݒ�̓ǂݍ��݂Ɏ��s���܂���";
						break;
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return status;
		}
		#endregion

		#region �� ���[�o�͐ݒ�Ǎ�
		/// <summary>
		/// ���[�o�͐ݒ�Ǎ�
		/// </summary>
		/// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			prtOutSet = null;
			message = string.Empty;

			// Static�ɕێ��ς݂̏ꍇ
			if (_prtOutSetData != null)
			{
				prtOutSet = _prtOutSetData.Clone();
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			try
			{
				// ���[�o�͐ݒ�A�N�Z�X�N���X
				if (_prtOutSetAcs == null)
					_prtOutSetAcs = new PrtOutSetAcs();

				status = _prtOutSetAcs.Read(out _prtOutSetData, LoginInfoAcquisition.EnterpriseCode, _mySectionCode);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						prtOutSet = _prtOutSetData.Clone();
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						prtOutSet = new PrtOutSet();
						break;
					}
					default:
					{
						prtOutSet = new PrtOutSet();
						message = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
						break;
					}
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}

			return status;
		}
		#endregion

		#region �� �S�̍��ڕ\���ݒ�f�[�^�N���X�擾
		/// <summary>
		/// �S�̍��ڕ\���ݒ�f�[�^�N���X�擾
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�S�̍��ڕ\���ݒ�f�[�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : �S�̍��ڕ\���ݒ�f�[�^�N���X�̎擾���s���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public AlItmDspNm GetAlItmDspNm(string enterpriseCode)
		{
			AlItmDspNm alItmDspNm = null;

			// Static�ɂ��łɂ���΂����Ԃ�
			if (_alItmDspNmData != null)
			{
				alItmDspNm = _alItmDspNmData.Clone();
			}
			else
			{
				this.ReadAlItmDspNm(out alItmDspNm, enterpriseCode);
			}

			return alItmDspNm;
		}
		#endregion

		#region �� �S�̍��ڕ\���ݒ�Ǎ���
		/// <summary>
		/// �S�̍��ڕ\���ݒ�Ǎ���
		/// </summary>
		/// <param name="alItmDspNm">�S�̍��ڕ\���ݒ�f�[�^�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>0:����,4:�f�[�^����,���̑�:�ُ�</returns>
		/// <remarks>
		/// <br>Note       : �S�̍��ڕ\���ݒ�f�[�^�N���X�̎擾���s���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private int ReadAlItmDspNm(out AlItmDspNm alItmDspNm, string enterpriseCode)
		{
			if (_alItmDspNmAcs == null) _alItmDspNmAcs = new AlItmDspNmAcs();
			
			// �S�̍��ڕ\���ݒ�̎擾 
			int status = _alItmDspNmAcs.ReadStatic(out alItmDspNm, enterpriseCode);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					break;
				}
				default:
				{
					break;
				}
			}
			return status;
		}
		#endregion

		#region �� �{�Ћ@�\�L���擾
		/// <summary>
		/// �{�Ћ@�\�L���擾
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>true: �{��,false: ���_</returns>
		/// <remarks>
		/// <br>Note       : �{�Ћ@�\�L���`�F�b�N���s���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool CheckMainOfficeFunc(string sectionCode)
		{
			return (_secInfoAcs.GetMainOfficeFuncFlag(sectionCode) == 1);
		}
		#endregion

		#region �� ����@�\���_�擾
		/// <summary>
		/// ����@�\���_�擾
		/// </summary>
		/// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
		/// <param name="ctrlFuncCode">�擾���鐧��@�\�R�[�h</param>
		/// <param name="ctrlSectionCode">�Ώې��䋒�_�R�[�h</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �Y�����_�̋��_������̓Ǎ����s���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public int GetOwnSeCtrlCode(string sectionCode, SecInfoAcs.CtrlFuncCode ctrlFuncCode, out string ctrlSectionCode)
		{
			// �Ώې��䋒�_�̏����l�͎����_
			ctrlSectionCode = sectionCode;

			SecInfoSet secInfoSet;
            int status = _secInfoAcs.GetSecInfo(sectionCode, out secInfoSet);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				if (secInfoSet != null)
				{
					ctrlSectionCode = secInfoSet.SectionCode;
				}
				else
				{
					// ���_����ݒ肪����Ă��Ȃ�
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}

			return status;
		}
		#endregion
		#endregion �� �ϐ��������֘A

		#region �� �����Ɖ�f�[�^�擾�֘A
		#region �� �����Ɖ�f�[�^�擾����
		/// <summary>
		/// �����Ɖ�f�[�^�擾����
		/// </summary>
		/// <param name="mode">�Ǎ����[�h[0:����,1:���|]</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="startCustomerCode">�J�n���Ӑ�R�[�h</param>
        /// <param name="endCustomerCode">�I�����Ӑ�R�[�h</param>
        /// <param name="stratdt">�����͈�(�J�n)</param>
		/// <param name="enddt">�����͈�(�I��)</param>
		/// <param name="sectionCode">�Ώۋ��_�R�[�h</param>
		/// <param name="sectionCodeList">���_�R�[�h���X�g</param>
		/// <param name="isBufferClear">StaticMemory�������t���O[True:����������, False:���������Ȃ�]</param>
		/// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="outMoneyDiv">�o�͋��z�敪</param>
        /// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : �Ώۓ��Ӑ�̌����Ɖ�f�[�^���擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
        public int Read(int mode, string enterpriseCode, int customerCode, int startCustomerCode, int endCustomerCode, int stratdt, int enddt, string sectionCode, ArrayList sectionCodeList, bool isBufferClear, out string message, int outMoneyDiv)
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			message = "";
            _imode = mode;

			try
			{
				// �ÓI�̈擯��������
				lock (typeof(CsLedgerDmdAcs))
				{
					// StaticMemory�@������
					if ( isBufferClear )
						InitializeCustomerLedger();

					switch (mode)
					{
						case 0:
							// ����KINGETCALL
                            status = SeiKingetCall(enterpriseCode, customerCode, startCustomerCode, endCustomerCode, stratdt, enddt, sectionCode, sectionCodeList, outMoneyDiv);
                            break;
						case 1:
							// ���|KINGETCALL
                            status = UriKingetCall(enterpriseCode, customerCode, startCustomerCode, endCustomerCode, stratdt, enddt, sectionCode, sectionCodeList, outMoneyDiv);
                            break;
						default:
							break;
					}
				}
			}
			catch (CsLedgerException ex)
			{
				status = ex.Status;
				message = ex.Message;
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

			return status;
		}
		#endregion

		#region �� �������׏��t�B���^�����O����
		/// <summary>
		/// �������׏��t�B���^�����O����
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="startDate">�v��N����(�J�n)</param>
		/// <param name="endDate">�v��N����(�I��)</param>
		/// <param name="sectionCode">�v�㋒�_�R�[�h</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �������ׂ��w��̌v��N�����Ńt�B���^�����O���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public void FilterAddUpDateCsLedgerSlip(int customerCode, int startDate, int endDate, string sectionCode)
		{
			FilterAddUpDateCsLedgerSlip(customerCode, startDate, endDate, sectionCode, ref _csLedgerSlipDataView);
		}
		#endregion

        #region �� �������׏��t�B���^�����O����
        /// <summary>
        /// �������׏��t�B���^�����O����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="startDate">�v��N����(�J�n)</param>
        /// <param name="endDate">�v��N����(�I��)</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �������ׂ��w��̌v��N�����Ńt�B���^�����O���܂��B</br>
        /// <br>Programer  : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.10.18</br>
        /// </remarks>
        public void FilterAddUpDateCsLedgerDtl(int customerCode, int startDate, int endDate, string sectionCode)
        {
            FilterAddUpDateCsLedgerDtl(customerCode, startDate, endDate, sectionCode, ref _csLedgerDtlDataView);
        }
        #endregion

		#region �� �����Ɖ�׏��t�B���^�����O����
        /// <summary>
        /// �����Ɖ�׏��t�B���^�����O����(���׏��)
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="startDate">�v��N����(�J�n)</param>
        /// <param name="endDate">�v��N����(�I��)</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="dv">�t�B���^��DataView</param>
        /// <remarks>
        /// <br>Note       : �����Ɖ�ׂ��w��̌v��N�����Ńt�B���^�����O���܂��B(���׏��)</br>
        /// <br>Programer  : 20081 �D�c �E�l</br>
        /// <br>Date       : 2007.10.18</br>
        /// </remarks>
        public void FilterAddUpDateCsLedgerDtl(int customerCode, int startDate, int endDate, string sectionCode, ref DataView dv)
        {
            string querry = "";
            string secCodeBalnce = "";
            string secCode = "";

            secCodeBalnce = sectionCode;
            secCode = sectionCode;

            // �v��͈͎w��
            if (startDate != endDate)
            {
                querry = String.Format("{0} = {1} AND {2} <= {3} AND (({4} = 0 AND {5} = {6} AND {7} = '{8}') OR ({9} IN (1,3) AND {10} = '{11}')) ",
                    Ct_CsLedgerDtl_ClaimCode,
                    customerCode,
                    Ct_CsLedgerDtl_AddUpADateInt,
                    endDate.ToString(),
                    Ct_CsLedgerDtl_BalanseCode,
                    Ct_CsLedgerDtl_AddUpDate,
                    startDate.ToString(),
                    Ct_CsLedgerDtl_AddUpSecCode,
                    secCodeBalnce,
                    Ct_CsLedgerDtl_BalanseCode,
                    Ct_CsLedgerDtl_AddUpSecCode,
                    secCode);

                querry += String.Format(" OR ({0}={1} AND {2}='{3}')",
                    Ct_CsLedgerDtl_BalanseCode, (int)LedgerDtlBalanseState.ConsTax,
                    Ct_CsLedgerDtl_AddUpSecCode, secCode);

                dv.RowFilter = querry;
            }

            // �P���w��
            else
            {

                querry = String.Format("{0} = {1} AND {2} = {3} AND (({4} IN (0,1,3) AND {5} = '{6}')",
                    Ct_CsLedgerDtl_ClaimCode,
                    customerCode,
                    Ct_CsLedgerDtl_AddUpDate,
                    startDate.ToString(),
                    Ct_CsLedgerDtl_BalanseCode,
                    Ct_CsLedgerDtl_AddUpSecCode,
                    secCode);

                querry += String.Format(" OR ({0}={1} AND {2}='{3}'))",
                    Ct_CsLedgerDtl_BalanseCode, (int)LedgerDtlBalanseState.ConsTax,
                    Ct_CsLedgerDtl_AddUpSecCode, secCode);

                dv.RowFilter = querry;

            }
        }

		/// <summary>
		/// �����Ɖ�׏��t�B���^�����O����(�`�[�ꗗ)
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="startDate">�v��N����(�J�n)</param>
		/// <param name="endDate">�v��N����(�I��)</param>
		/// <param name="sectionCode">�v�㋒�_�R�[�h</param>
		/// <param name="dv">�t�B���^��DataView</param>
		/// <remarks>
        /// <br>Note       : �����Ɖ�ׂ��w��̌v��N�����Ńt�B���^�����O���܂��B(�`�[�ꗗ)</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public void FilterAddUpDateCsLedgerSlip(int customerCode, int startDate, int endDate, string sectionCode, ref DataView dv)
		{
			string querry = "";
			string secCodeBalnce = "";
			string secCode = "";

			secCodeBalnce = sectionCode;
			secCode = sectionCode;

			// �v��͈͎w��
			if (startDate != endDate)
			{
				querry = String.Format("{0} = {1} AND {2} <= {3} AND (({4} = 0 AND {5} = {6} AND {7} = '{8}') OR ({9} IN (1,3) AND {10} = '{11}')) ",
				    Ct_CsLedger_ClaimCode,
				    customerCode,
				    Ct_CsLedger_AddUpADateInt,
				    endDate.ToString(),
				    Ct_CsLedger_BalanseCode,
				    Ct_CsLedger_AddUpDate,
				    startDate.ToString(),
				    Ct_CsLedger_AddUpSecCode,
				    secCodeBalnce,
				    Ct_CsLedger_BalanseCode,
				    Ct_CsLedger_AddUpSecCode,
				    secCode);

			    querry += String.Format(" OR ({0}={1} AND {2}='{3}')",
			        Ct_CsLedger_BalanseCode, (int)LedgerDtlBalanseState.ConsTax,
			        Ct_CsLedger_AddUpSecCode, secCode);

				dv.RowFilter = querry;
			}

			// �P���w��
			else
			{

				querry = String.Format("{0} = {1} AND {2} = {3} AND (({4} IN (0,1,3) AND {5} = '{6}')",
					Ct_CsLedger_ClaimCode,
					customerCode,
					Ct_CsLedger_AddUpDate,
					startDate.ToString(),
					Ct_CsLedger_BalanseCode,
					Ct_CsLedger_AddUpSecCode,
					secCode);

				querry += String.Format(" OR ({0}={1} AND {2}='{3}'))",
					Ct_CsLedger_BalanseCode, (int)LedgerDtlBalanseState.ConsTax,
					Ct_CsLedger_AddUpSecCode, secCode);

				dv.RowFilter = querry;

			}

			// �c���Čv�Z
			CalculattonNowBalance(ref dv);
		}
		#endregion

		#region �� �c���Čv�Z����
		/// <summary>
		/// �c���Čv�Z����
		/// </summary>
		/// <param name="dv">�f�[�^�r���[</param>
		/// <remarks>
		/// <br>Note       : �����œn���ꂽDataView�ɑ΂��Ďc���̌v�Z���s���܂��B</br>
		/// <br>Programer	: 20081 �D�c �E�l</br>
		/// <br>Date		: 2007.10.18</br>
		/// </remarks>
		private static void CalculattonNowBalance(ref DataView dv)
		{
			Int64 balance = 0;

			for (int index = 0; index < dv.Count; index++)
			{
				DataRowView drv = dv[index];

				// �O�c�̏ꍇ
				if (GetCellInt32(drv[Ct_CsLedger_BalanseCode]) == (int)LedgerDtlBalanseState.Balance)
				{
					// �O�c���R�[�h�����݂���ꍇ�̂ݎc����ێ�
					balance = GetCellInt64(drv[Ct_CsLedger_Balance]);
				}

				Int64 deposit		= GetCellInt64(drv[Ct_CsLedger_Deposit			]);	// �����z
				Int64 sales			= GetCellInt64(drv[Ct_CsLedger_SalesTotal		]);	// ����
				Int64 salesTax		= GetCellInt64(drv[Ct_CsLedger_SalesSubtotalTax	]);	// ��������

				// �c���ύX
				drv.BeginEdit();
				// Todo:���ׂ̎c�������������Ȃ����炱���K����
				balance += sales + salesTax - deposit; // �c��=����+��������-����
                
				drv[Ct_CsLedger_Balance	] = balance;
				drv.EndEdit();
			}
		}
		#endregion

		#region �� �����Ɖ�f�[�^����������
		/// <summary>
		/// �����Ɖ�f�[�^����������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static�������������܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
			_addUpDateStart = new DateTime(1, 1, 1);
			_addUpDateEnd = new DateTime(1, 1, 1);
			_ttlAddUpDateSpanStart = new DateTime(1, 1, 1);
			_ttlAddUpDateSpanEnd = new DateTime(1, 1, 1);

			// �e�[�u���s������
			_csLedgerCustomerHTable.Clear();
			_csLedgerSlipDataTable.Rows.Clear();
            _csLedgerDtlDataTable.Rows.Clear();
            _csLedgerBlanceDataTable.Rows.Clear();
			_custDmdPrcDataTable.Rows.Clear();
			//_custDmdPrcPrintDataTable.Rows.Clear();

			_depsitHTable.Clear();

			// �����\�[�g�����ݒ�    
			_custDmdPrcDataView.Sort = Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;
            _csLedgerSlipDataView.Sort = Ct_CsLedger_ClaimCode + "," + Ct_CsLedger_AddUpDate + "," + Ct_CsLedger_BalanseCode + "," + Ct_CsLedger_AddUpADateInt + "," + Ct_CsLedger_RecordCode + "," + Ct_CsLedger_SlipNo;
            _csLedgerDtlDataView.Sort = Ct_CsLedgerDtl_ClaimCode + "," + Ct_CsLedgerDtl_AddUpDate + "," + Ct_CsLedgerDtl_BalanseCode + "," + Ct_CsLedgerDtl_AddUpADateInt + "," + Ct_CsLedgerDtl_RecordCode + "," + Ct_CsLedgerDtl_SlipNo + "," + Ct_CsLedgerDtl_SalesRowNo;
            _csLedgerBlanceDataView.Sort = Ct_CsLedgerBlance_AddUpSecCode + "," + Ct_CsLedgerBlance_ClaimCode + "," + Ct_CsLedgerBlance_AddUpDate;

			// �t�B���^�[����������
			_custDmdPrcDataView.RowFilter = "";
			_csLedgerSlipDataView.RowFilter = "";
            _csLedgerDtlDataView.RowFilter = "";
            _csLedgerBlanceDataView.RowFilter = "";
		}
		#endregion
		#endregion

		#region �� �Ӄf�[�^�쐬�֘A
		#region �� ���Ӑ挳���p�Ӄf�[�^�z��擾
		/// <summary>
		/// ���Ӑ挳���p�Ӄf�[�^�z��擾
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="csLedgerDmdPrc">���Ӑ挳���p�Ӄf�[�^�z��</param>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ挳���p�Ӄf�[�^���擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool SearchCustDmdPrcToList(string sectionCode, out CsLedgerDmdPrc[] csLedgerDmdPrc, out string msg)
		{
			return SearchCustDmdPrcToList(0, sectionCode, out csLedgerDmdPrc, out msg);
		}
		#endregion

		#region �� ���Ӑ挳���p�Ӄf�[�^�z��擾
		/// <summary>
		/// ���Ӑ挳���p�Ӄf�[�^�z��擾(���t���O�w��)
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="customerCode">���Ӑ溰��</param>
		/// <param name="addupDate">�v��N����</param>
		/// <param name="csLedgerDmdPrc">���Ӑ挳���p�Ӄf�[�^�z��</param>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ挳���p�Ӄf�[�^���擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.05.14</br>
		/// </remarks>
		public bool ReadCustDmdPrcToList(string sectionCode, int customerCode, int addupDate, out CsLedgerDmdPrc[] csLedgerDmdPrc, out string msg)
		{
			CsLedgerDmdPrc[] csLedgerDmdPrcWork;
			csLedgerDmdPrc = null;
			// �w�肵�����Ӑ�̊Ӄf�[�^��S�Ď擾
			bool isStatus = SearchCustDmdPrcToList(customerCode, sectionCode, out csLedgerDmdPrcWork, out msg);

			// �w�肳�ꂽ�v����̃f�[�^���擾
			if ( isStatus )
			{
				if ( csLedgerDmdPrcWork.Length > 0 )
				{
					for( int index = 0; index < csLedgerDmdPrcWork.Length; index++ )
					{
						if (TDateTime.DateTimeToLongDate( csLedgerDmdPrcWork[index].AddUpDate ) == addupDate )
						{
							csLedgerDmdPrc = new CsLedgerDmdPrc[1];
							csLedgerDmdPrc[0] = csLedgerDmdPrcWork[index];
							break;
						}
					}
				}
			}

			return isStatus;
		}
		#endregion

		#region �� ���Ӑ挳���p�Ӄf�[�^�z��擾(���Ӑ�w��)
		/// <summary>
		/// ���Ӑ挳���p�Ӄf�[�^�z��擾(���Ӑ�w��)
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="csLedgerDmdPrc">���Ӑ挳���p�Ӄf�[�^�z��</param>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ挳���p�Ӄf�[�^���擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool SearchCustDmdPrcToList(int customerCode, string sectionCode, out CsLedgerDmdPrc[] csLedgerDmdPrc, out string msg)
		{
			csLedgerDmdPrc = null;
			ArrayList csLedgerDmdList;
			bool exist = SearchCustDmdPrcToArray(customerCode, sectionCode, out csLedgerDmdList, out msg);
			if (exist)
			{
				csLedgerDmdPrc = (CsLedgerDmdPrc[])csLedgerDmdList.ToArray(typeof(CsLedgerDmdPrc));
			}
			return exist;
		}
		#endregion

		#region �� ���Ӑ挳���p�Ӄf�[�^�z��擾
		/// <summary>
		/// ���Ӑ挳���p�Ӄf�[�^�z��擾
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="csLedgerDmdList">���Ӑ挳���p�Ӄf�[�^���X�g</param>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ挳���p�Ӄf�[�^���擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool SearchCustDmdPrcToArray(string sectionCode, out ArrayList csLedgerDmdList, out string msg)
		{
			return SearchCustDmdPrcToArray(0, sectionCode, out csLedgerDmdList, out msg);
		}
		#endregion

		#region �� ���Ӑ挳���p�Ӄf�[�^���X�g�擾(���Ӑ�w��)
		/// <summary>
		/// ���Ӑ挳���p�Ӄf�[�^���X�g�擾(���Ӑ�w��)
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="csLedgerDmdList">���Ӑ挳���p�Ӄf�[�^���X�g</param>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ挳���p�Ӄf�[�^���擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool SearchCustDmdPrcToArray(int customerCode, string sectionCode, out ArrayList csLedgerDmdList, out string msg)
		{
			csLedgerDmdList = null;
			msg = string.Empty;

			if (_custDmdPrcDataTable.Rows.Count > 0)
			{
				StringBuilder filter = new StringBuilder(String.Format("{0}='{1}'", Ct_CsDmd_AddUpSecCode, sectionCode));

				// ���Ӑ�R�[�h���w�肳��Ă���ꍇ
				if (customerCode != 0)	filter.Append(String.Format(" AND {0}={1}", Ct_CsDmd_ClaimCode, customerCode));

				string sort		= Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;

				// ���Ӑ挳���p�Ӄf�[�^���z��񃊃X�g�擾
				csLedgerDmdList = this.GetCsLedgerDmdPrcList(filter.ToString(), sort);

				return true;
			}
			else
			{
				msg = "���������܂���B";
				return false;
			}
		}
		#endregion

		#region �� ���Ӑ挳���Ɖ�p�Ӄf�[�^DataView�擾
		/// <summary>
		/// ���Ӑ挳���Ɖ�p�Ӄf�[�^DataView�擾
		/// </summary>
		/// <param name="sectionCode">�w�苒�_�R�[�h</param>
		/// <param name="dv">���Ӑ���zDataView</param>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ挳���Ɖ�p�Ӄf�[�^���擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool GetStaticCustDmdPrcToDataView(string sectionCode, out DataView dv, out string msg)
		{
			dv = null;
			msg = "���������܂���B";

			if (_custDmdPrcDataTable.Rows.Count > 0)
			{
				string filter = String.Format("{0}='{1}'", Ct_CsDmd_AddUpSecCode, sectionCode);
				string sort = Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;

				dv = new DataView(_custDmdPrcDataTable, filter, sort, DataViewRowState.CurrentRows);

				if (dv.Count > 0) return true;
			}

			return false;
		}
		#endregion

		#region �� �����Ɖ�Ӑ���(static memory)�̎擾
		/// <summary>
		/// �����Ɖ�Ӑ���(static memory)�̎擾
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>�����Ɖ�Ӑ���f�[�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�����擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public CsLedgerCustomer CustomerInfo(int customerCode)
		{
			if (_csLedgerCustomerHTable.Contains(customerCode))
			{
				CsLedgerCustomer cs = (CsLedgerCustomer)_csLedgerCustomerHTable[customerCode];
				return cs.Clone();
			}
			else
			{
				return new CsLedgerCustomer();
			}
		}
		#endregion

		#region �� �������Ӑ���(static memory)�̎擾
		/// <summary>
		/// �������Ӑ���(static memory)�̎擾
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="addUpdate">�v���</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>�������Ӑ���f�[�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�����擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public CsLedgerCustomer CustomerInfo(int customerCode,int addUpdate,string sectionCode)
		{
            string key = customerCode.ToString() + "_" + addUpdate.ToString() + "_" + sectionCode;
			if (_csLedgerCustomerHTable.Contains(key))
			{
				CsLedgerCustomer cs = (CsLedgerCustomer)_csLedgerCustomerHTable[key];
				return cs.Clone();
			}
			else
			{
				return new CsLedgerCustomer();
			}
		}
		#endregion
		
		#region �� �������Ӑ���z���v���(static memory)�̎擾
		/// <summary>
		/// �������Ӑ���z���v���(static memory)�̎擾
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="sectionCode">�w�苒�_�R�[�h</param>
		/// <param name="csLedgerDmdPrc">���Ӑ挳���x�����z���v���</param>
		/// <param name="msg">�G���[���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ���z�̍��v�����擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool GetTotalCustDmdPrc(int customerCode, string sectionCode, out CsLedgerDmdPrc csLedgerDmdPrc, out string msg)
		{
			msg = string.Empty;
			csLedgerDmdPrc = null;
			int totalCleateCounter = 0;

			ArrayList custDmdPrcList;

			if (SearchCustDmdPrcToArray(customerCode, sectionCode, out custDmdPrcList, out msg))
			{
				csLedgerDmdPrc = new CsLedgerDmdPrc();

				for (int index = 0; index < custDmdPrcList.Count; index++)
				{
					CsLedgerDmdPrc wkCsLedgeDmdPrc = (CsLedgerDmdPrc)custDmdPrcList[index];

					// ���ς݃f�[�^�͊ӂɉ����Ȃ�
					if ( wkCsLedgeDmdPrc.CloseFlag == (int)CloseFlagState.NotClose )
						continue;

					// ���v�^�u�쐬���f�J�E���^�[
					totalCleateCounter++;

					if (index == 0)
					{
						
						csLedgerDmdPrc.AddUpSecCode			= wkCsLedgeDmdPrc.AddUpSecCode;				// ���_�R�[�h
                        csLedgerDmdPrc.ClaimCode            = wkCsLedgeDmdPrc.ClaimCode;                // ������R�[�h

						csLedgerDmdPrc.CustomerCode			= wkCsLedgeDmdPrc.CustomerCode;				// ���Ӑ�R�[�h
						// 3��O�c��,2��O�c��,�O��c��,�v�Z���������z�͐擪���R�[�h�̋��z���
						csLedgerDmdPrc.AcpOdrTtl3TmBfBlDmd	= wkCsLedgeDmdPrc.AcpOdrTtl3TmBfBlDmd;		// ��3��O�c��
						csLedgerDmdPrc.AcpOdrTtl2TmBfBlDmd	= wkCsLedgeDmdPrc.AcpOdrTtl2TmBfBlDmd;		// ��2��O�c��
						csLedgerDmdPrc.LastTimeDemand		= wkCsLedgeDmdPrc.LastTimeDemand;			// �O�񐿋����z
					}
					
					csLedgerDmdPrc.ThisTimeDmdNrml		+= wkCsLedgeDmdPrc.ThisTimeDmdNrml;		// ����������z�i�ʏ�����j
					csLedgerDmdPrc.ThisTimeTtlBlcDmd	+= wkCsLedgeDmdPrc.ThisTimeTtlBlcDmd;	// ����J�z�c���i�����v�j
                    csLedgerDmdPrc.OfsThisTimeSales     += wkCsLedgeDmdPrc.OfsThisTimeSales;    // ���E�㍡�񔄏���z
                    csLedgerDmdPrc.OfsThisSalesTax      += wkCsLedgeDmdPrc.OfsThisSalesTax;     // ���E�䍡�񔄏�����          
					csLedgerDmdPrc.ThisTimeSales		+= wkCsLedgeDmdPrc.ThisTimeSales;		// ���񔄏���z
				}
				
				if ( totalCleateCounter < 2 )
				{
					return false;
				}
				
				// Todo:�ӂ̍��v���������������炱������������
				int listCount = custDmdPrcList.Count;
				int afCalDemandIndex = 1;
				if ( ((CsLedgerDmdPrc)custDmdPrcList[listCount - afCalDemandIndex ]).CloseFlag == (int)CloseFlagState.NotClose &&
					listCount > 1)
					afCalDemandIndex = 2;
				else
					// �ŏI���R�[�h�������߂̏ꍇ
					// �ŏI���R�[�h�̈��O�̌v�Z�㐿�����z�����v�^�u�̌v�Z�㐿�����z�ɂȂ�
					// �����������̈ꌬ�����Ȃ��ꍇ�͍Ō�̃��R�[�h���Ƃ邵���Ȃ�
					afCalDemandIndex = 1;

				// �c��
				csLedgerDmdPrc.AfCalDemandPrice = ((CsLedgerDmdPrc)custDmdPrcList[listCount - afCalDemandIndex ]).AfCalDemandPrice;

				//�ŏI�̌v�����߂�(���v�^�u���I�����ꂽ���Ɋӂɕ\�������]�ŕ����͂��̌��̐ݒ�ɂȂ�)
				csLedgerDmdPrc.AddUpDate = ((CsLedgerDmdPrc)custDmdPrcList[listCount - afCalDemandIndex ]).AddUpDate;

				csLedgerDmdPrc.StartDateSpan		= TDateTime.DateTimeToLongDate(_ttlAddUpDateSpanStart);		// ���Ώۓ��t�͈́i�J�n�j
				csLedgerDmdPrc.EndDateSpan			= TDateTime.DateTimeToLongDate(_ttlAddUpDateSpanEnd);		// ���Ώۓ��t�͈́i�I���j

				csLedgerDmdPrc.CloseFlag			= (int)CloseFlagState.Close;		// ���Ώۓ��t�͈́i�I���j
				return true;
			}
			else
			{
				return false;

			}
		}


		#endregion

		#endregion

		#region �� ���Ӑ���擾
		#region �� �������Ӑ���z���(Static Memory)�̎擾(���Ӑ�w��)
		/// <summary>
		/// �������Ӑ���z���(Static Memory)�̎擾(���Ӑ�w��)
		/// </summary>
		/// <param name="customerCode">�w�蓾�Ӑ�R�[�h</param>
		/// <param name="sectionCode">�w�苒�_�R�[�h</param>
		/// <param name="addUpDate">�w��v��N����</param>
		/// <param name="csLedgerDmdPrc">�������z�f�[�^�N���X</param>
		/// <param name="msg">���b�Z�[�W</param>
		/// <returns>true:�擾����,false:�f�[�^�Ȃ�</returns>
		/// <remarks>
		/// <br>Note       : �w�蓾�Ӑ�A���_�A�v��N�����̐������z���R�[�h���擾���܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		public bool GetDmdPrc(int customerCode, string sectionCode, int addUpDate, out CsLedgerDmdPrc csLedgerDmdPrc, out string msg)
		{
			msg = string.Empty;

			if (_custDmdPrcDataTable.Rows.Count != 0)
			{
				string sort = Ct_CsDmd_AddUpSecCode + "," + Ct_CsDmd_ClaimCode + "," + Ct_CsDmd_AddUpDate;
				
				DataView dv = new DataView(_custDmdPrcDataTable, string.Empty, sort, DataViewRowState.CurrentRows);

				DateTime dtaddUpDate = DateConverter.GetDateTimeFromYYYYMMDD(addUpDate);

				object[] findKey = new object[] { sectionCode, customerCode, dtaddUpDate };

				// �r���[������(���݂��Ȃ��ꍇ��-1���߂�)
				int index = dv.Find(findKey);

				if (index < 0)
				{
					// �󃌃R�[�h�����
					csLedgerDmdPrc = new CsLedgerDmdPrc();
				}
				else
				{
					csLedgerDmdPrc = DataRowToCsLedgerDmdPrc(dv[index].Row);
				}
				return true;
			}
			else
			{
				msg = "���������܂���B";
				csLedgerDmdPrc = null;
				return false;
			}
		}
		#endregion
		#endregion

		#endregion �� Public Method

		#region �� Private Method
		/// <summary>
		/// ���Ӑ挳���Ɖ�p�Ӄf�[�^���X�g�擾
		/// </summary>
		/// <param name="filter">�t�B���^</param>
		/// <param name="sort">�\�[�g</param>
		/// <returns>���Ӑ挳���Ɖ�p�Ӄf�[�^���X�g</returns>
		/// <remarks>
		/// <br>Note       : �����ɍ��������Ӑ挳���Ɖ�p�Ӄf�[�^�����X�g�ŕԂ��܂��B
		///					 �����ɍ������̂��P���������ꍇ�ɂ͋󃌃R�[�h���P���ǉ����ĕԂ��܂��B</br>
		/// <br>Programer  : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.10.18</br>
		/// </remarks>
		private ArrayList GetCsLedgerDmdPrcList(string filter, string sort)
		{
			ArrayList csLedgerDmdPrcList = new ArrayList();

			DataView dv = new DataView(_custDmdPrcDataTable, filter, sort, DataViewRowState.CurrentRows);
			if (dv.Count == 0)
			{
				// �󃌃R�[�h�쐬
				csLedgerDmdPrcList.Add(new CsLedgerDmdPrc());
			}
			else
			{
				for (int index = 0; index < dv.Count; index++)
				{
					csLedgerDmdPrcList.Add(DataRowToCsLedgerDmdPrc(dv[index].Row));
				}
			}

			return csLedgerDmdPrcList;
		}
		#endregion �� Private Method

		// ===================================================================================== //
		// ��O�N���X
		// ===================================================================================== //
		#region ��O�N���X
		private class CsLedgerException : ApplicationException
		{
			private int _status;

			#region constructor
			public CsLedgerException(string message, int status)
				: base(message)
			{
				this._status = status;
			}
			#endregion

			#region public property
			public int Status
			{
				get { return this._status; }
			}
			#endregion
		}
		#endregion

		#region InnerClass DateTime �� Int32�ϊ��N���X
		private class DateConverter
		{
			/// <summary>
			/// DateTime�l�擾(Int32 YYYYMMDD���)
			/// </summary>
			/// <param name="dateInt32">YYYYMMDD(Int32)</param>
			/// <returns>DateTime�l</returns>
			public static DateTime GetDateTimeFromYYYYMMDD(Int32 dateInt32)
			{
				if (dateInt32 == 0) return DateTime.MinValue;
				else
				{
					try
					{
						if (dateInt32 == 0) return DateTime.MinValue;
						else if (dateInt32 == 99999999) return DateTime.MaxValue;
						else
						{
							int yyyy = dateInt32 / 10000;
							int mm = (dateInt32 % 10000) / 100;
							int dd = dateInt32 % 100;
							DateTime retDate = new DateTime(yyyy, mm, dd);
							return retDate;
						}
					}
					//����͈͓��t�Ŗ�����΍ŏ��l���Z�b�g
					catch (Exception)
					{
						return DateTime.MinValue;
					}
				}
			}

			/// <summary>
			/// DateTime�l�擾(Int32 YYYYMM���)
			/// </summary>
			/// <param name="dateInt32">YYYYMM(Int32)</param>
			/// <returns>DateTime�l</returns>
			public static DateTime GetDateTimeFromYYYYMM(Int32 dateInt32)
			{
				if (dateInt32 == 0) return DateTime.MinValue;
				else
				{
					try
					{
						if (dateInt32 == 0) return DateTime.MinValue;
						else if (dateInt32 == 999999) return DateTime.MaxValue;
						else
						{
							int yyyy = dateInt32 / 100;
							int mm = dateInt32 % 100;
							int dd = DateTime.DaysInMonth(yyyy, mm);
							DateTime retDate = new DateTime(yyyy, mm, dd);
							return retDate;
						}
					}
					//����͈͓��t�Ŗ�����΍ŏ��l���Z�b�g
					catch (Exception)
					{
						return DateTime.MinValue;
					}
				}
			}
		}
		#endregion

		#region ICompare �̎�����
		/// <summary>
		/// ���_�R�[�h���בւ��pKEY
		/// </summary>
		class SecInfoKey0 : IComparer
		{
			public int Compare(object x, object y)
			{
				string cx = x.ToString();
				string cy = y.ToString();
				return cx.CompareTo(cy);
			}
		}
		#endregion
	}
}

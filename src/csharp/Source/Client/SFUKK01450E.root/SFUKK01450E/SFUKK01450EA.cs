using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SearchDepsitMain
	/// <summary>
	///                      ���������f�[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���������f�[�^�N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   �ؑ� ����</br>
	/// <br>Genarated Date   :   2007/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007.10.05 20081 �D�c �E�l �����}�X�^�̃��C�A�E�g�ύX�ɂ��C�� DC.NS�p�ɕύX</br>
    /// <br>Update Note      :   2008/06/26 30414 �E �K�j �����}�X�^�̃��C�A�E�g�ύX�ɂ��C�� Partsman�p�ɕύX</br>
	/// </remarks>
    public class SearchDepsitMain
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>�����ԍ��敪</summary>
        /// <remarks>0:��,1:��,2:���E�ςݍ�</remarks>
        private Int32 _depositDebitNoteCd;

        /// <summary>�����`�[�ԍ�</summary>
        private Int32 _depositSlipNo;

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";

        /// <summary>�������͋��_�R�[�h</summary>
        /// <remarks>�������͂������_�R�[�h</remarks>
        private string _inputDepositSecCd = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>�����^ �f�[�^�̓o�^�X�V���_</remarks>
        private string _updateSecCd = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�ۃR�[�h</summary>
        private Int32 _minSectionCode;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>�������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

        /// <summary>�v����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>��������R�[�h</summary>
        private Int32 _depositKindCode;

        /// <summary>�������햼��</summary>
        private string _depositKindName = "";

        /// <summary>��������敪</summary>
        private Int32 _depositKindDivCd;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>�����v</summary>
        private Int64 _depositTotal;

        /// <summary>�������z</summary>
        /// <remarks>�l���E�萔�����������z</remarks>
        private Int64 _deposit;

        /// <summary>�萔�������z</summary>
        private Int64 _feeDeposit;

        /// <summary>�l�������z</summary>
        private Int64 _discountDeposit;

        /// <summary>���������敪</summary>
        /// <remarks>0:�ʏ����,1:��������</remarks>
        private Int32 _autoDepositCd;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�a����敪</summary>
        /// <remarks>0:�ʏ����,1:�a�������</remarks>
        private Int32 _depositCd;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>��`�U�o��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>��`�x������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftPayTimeLimit;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>��`���</summary>
        private Int32 _draftKind;

        /// <summary>��`��ޖ���</summary>
        /// <remarks>�񑩁A�בցA���؎�</remarks>
        private string _draftKindName = "";

        /// <summary>��`�敪</summary>
        private Int32 _draftDivide;

        /// <summary>��`�敪����</summary>
        /// <remarks>���U�A��</remarks>
        private string _draftDivideName = "";

        /// <summary>��`�ԍ�</summary>
        private string _draftNo = "";

        /// <summary>���������z</summary>
        private Int64 _depositAllowance;

        /// <summary>���������c��</summary>
        private Int64 _depositAlwcBlnce;

        /// <summary>�ԍ������A���ԍ�</summary>
        private Int32 _debitNoteLinkDepoNo;

        /// <summary>�ŏI�������݌v���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _lastReconcileAddUpDt;

        /// <summary>�����S���҃R�[�h</summary>
        private string _depositAgentCode = "";

        /// <summary>�����S���Җ���</summary>
        private string _depositAgentNm = "";

        /// <summary>�������͎҃R�[�h</summary>
        private string _depositInputAgentCd = "";

        /// <summary>�������͎Җ���</summary>
        private string _depositInputAgentNm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>������R�[�h</summary>
        /// <remarks>�����擾�Ӑ�</remarks>
        private Int32 _claimCode;

        /// <summary>�����於��</summary>
        /// <remarks>�������Ӑ於��</remarks>
        private string _claimName = "";

        /// <summary>�����於��2</summary>
        /// <remarks>�������Ӑ於�̂Q</remarks>
        private string _claimName2 = "";

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>�`�[�E�v</summary>
        /// <remarks>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</remarks>
        private string _outline = "";

        /// <summary>��s�R�[�h</summary>
        /// <remarks>�X�֋ǁF9900</remarks>
        private Int32 _bankCode;

        /// <summary>��s����</summary>
        private string _bankName = "";

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�d�c�h���M��</summary>
        private Int32 _ediSendDate;

        /// <summary>�d�c�h�捞��</summary>
        private Int32 _ediTakeInDate;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>�a����敪����</summary>
        /// <remarks>���C�A�E�g�Ɏ蓮�Œǉ�</remarks>
        private string _depositNm = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�����s�ԍ�(1�`10)</summary>
        private Int32[] _depositRowNo = new Int32[10];
        /// <summary>����R�[�h(1�`10)</summary>
        private Int32[] _moneyKindCode = new Int32[10];
        /// <summary>���햼��(1�`10)</summary>
        private String[] _moneyKindName = new String[10];
        /// <summary>����敪(1�`10)</summary>
        private Int32[] _moneyKindDiv = new Int32[10];
        /// <summary>�������z(1�`10)</summary>
        private Int64[] _depositDtl = new Int64[10];
        /// <summary>�L������(1�`10)</summary>
        private DateTime[] _validityTerm = new DateTime[10];
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        private DateTime _inputDay;

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  DepositDebitNoteCd
        /// <summary>�����ԍ��敪�v���p�e�B</summary>
        /// <value>0:��,1:��,2:���E�ςݍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ԍ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositDebitNoteCd
        {
            get { return _depositDebitNoteCd; }
            set { _depositDebitNoteCd = value; }
        }

        /// public propaty name  :  DepositSlipNo
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositSlipNo
        {
            get { return _depositSlipNo; }
            set { _depositSlipNo = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  InputDepositSecCd
        /// <summary>�������͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�������͂������_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDepositSecCd
        {
            get { return _inputDepositSecCd; }
            set { _inputDepositSecCd = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  UpdateSecCd
        /// <summary>�X�V���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^ �f�[�^�̓o�^�X�V���_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateSecCd
        {
            get { return _updateSecCd; }
            set { _updateSecCd = value; }
        }

        /// public propaty name  :  SubSectionCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubSectionCode
        {
            get { return _subSectionCode; }
            set { _subSectionCode = value; }
        }

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  MinSectionCode
        /// <summary>�ۃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ۃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MinSectionCode
        {
            get { return _minSectionCode; }
            set { _minSectionCode = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DepositDate
        /// <summary>�������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DepositDate
        {
            get { return _depositDate; }
            set { _depositDate = value; }
        }

        /// public propaty name  :  DepositDateJpFormal
        /// <summary>�������t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateJpInFormal
        /// <summary>�������t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateAdFormal
        /// <summary>�������t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateAdInFormal
        /// <summary>�������t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _depositDate); }
            set { }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpADate
        {
            get { return _addUpADate; }
            set { _addUpADate = value; }
        }

        /// public propaty name  :  AddUpADateJpFormal
        /// <summary>�v����t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateJpInFormal
        /// <summary>�v����t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdFormal
        /// <summary>�v����t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate); }
            set { }
        }

        /// public propaty name  :  AddUpADateAdInFormal
        /// <summary>�v����t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpADateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate); }
            set { }
        }

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DepositKindCode
        /// <summary>��������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositKindCode
        {
            get { return _depositKindCode; }
            set { _depositKindCode = value; }
        }

        /// public propaty name  :  DepositKindName
        /// <summary>�������햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositKindName
        {
            get { return _depositKindName; }
            set { _depositKindName = value; }
        }

        /// public propaty name  :  DepositKindDivCd
        /// <summary>��������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositKindDivCd
        {
            get { return _depositKindDivCd; }
            set { _depositKindDivCd = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DepositTotal
        /// <summary>�����v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositTotal
        {
            get { return _depositTotal; }
            set { _depositTotal = value; }
        }

        /// public propaty name  :  Deposit
        /// <summary>�������z�v���p�e�B</summary>
        /// <value>�l���E�萔�����������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        /// public propaty name  :  FeeDeposit
        /// <summary>�萔�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FeeDeposit
        {
            get { return _feeDeposit; }
            set { _feeDeposit = value; }
        }

        /// public propaty name  :  DiscountDeposit
        /// <summary>�l�������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountDeposit
        {
            get { return _discountDeposit; }
            set { _discountDeposit = value; }
        }

        /// public propaty name  :  AutoDepositCd
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>0:�ʏ����,1:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoDepositCd
        {
            get { return _autoDepositCd; }
            set { _autoDepositCd = value; }
        }

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DepositCd
        /// <summary>�a����敪�v���p�e�B</summary>
        /// <value>0:�ʏ����,1:�a�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositCd
        {
            get { return _depositCd; }
            set { _depositCd = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DraftDrawingDate
        /// <summary>��`�U�o���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DraftDrawingDate
        {
            get { return _draftDrawingDate; }
            set { _draftDrawingDate = value; }
        }

        /// public propaty name  :  DraftDrawingDateJpFormal
        /// <summary>��`�U�o�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDrawingDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateJpInFormal
        /// <summary>��`�U�o�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDrawingDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateAdFormal
        /// <summary>��`�U�o�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDrawingDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateAdInFormal
        /// <summary>��`�U�o�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDrawingDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DraftPayTimeLimit
        /// <summary>��`�x�������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DraftPayTimeLimit
        {
            get { return _draftPayTimeLimit; }
            set { _draftPayTimeLimit = value; }
        }

        /// public propaty name  :  DraftPayTimeLimitJpFormal
        /// <summary>��`�x������ �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x������ �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftPayTimeLimitJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _draftPayTimeLimit); }
            set { }
        }

        /// public propaty name  :  DraftPayTimeLimitJpInFormal
        /// <summary>��`�x������ �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x������ �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftPayTimeLimitJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _draftPayTimeLimit); }
            set { }
        }

        /// public propaty name  :  DraftPayTimeLimitAdFormal
        /// <summary>��`�x������ ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x������ ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftPayTimeLimitAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _draftPayTimeLimit); }
            set { }
        }

        /// public propaty name  :  DraftPayTimeLimitAdInFormal
        /// <summary>��`�x������ ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�x������ ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftPayTimeLimitAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _draftPayTimeLimit); }
            set { }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DraftKind
        /// <summary>��`��ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`��ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftKind
        {
            get { return _draftKind; }
            set { _draftKind = value; }
        }

        /// public propaty name  :  DraftKindName
        /// <summary>��`��ޖ��̃v���p�e�B</summary>
        /// <value>�񑩁A�בցA���؎�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftKindName
        {
            get { return _draftKindName; }
            set { _draftKindName = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>��`�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  DraftDivideName
        /// <summary>��`�敪���̃v���p�e�B</summary>
        /// <value>���U�A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDivideName
        {
            get { return _draftDivideName; }
            set { _draftDivideName = value; }
        }

        /// public propaty name  :  DraftNo
        /// <summary>��`�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftNo
        {
            get { return _draftNo; }
            set { _draftNo = value; }
        }

        /// public propaty name  :  DepositAllowance
        /// <summary>���������z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAllowance
        {
            get { return _depositAllowance; }
            set { _depositAllowance = value; }
        }

        /// public propaty name  :  DepositAlwcBlnce
        /// <summary>���������c���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DepositAlwcBlnce
        {
            get { return _depositAlwcBlnce; }
            set { _depositAlwcBlnce = value; }
        }

        /// public propaty name  :  DebitNoteLinkDepoNo
        /// <summary>�ԍ������A���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ������A���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteLinkDepoNo
        {
            get { return _debitNoteLinkDepoNo; }
            set { _debitNoteLinkDepoNo = value; }
        }

        /// public propaty name  :  LastReconcileAddUpDt
        /// <summary>�ŏI�������݌v����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�������݌v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LastReconcileAddUpDt
        {
            get { return _lastReconcileAddUpDt; }
            set { _lastReconcileAddUpDt = value; }
        }

        /// public propaty name  :  LastReconcileAddUpDtJpFormal
        /// <summary>�ŏI�������݌v��� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�������݌v��� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastReconcileAddUpDtJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _lastReconcileAddUpDt); }
            set { }
        }

        /// public propaty name  :  LastReconcileAddUpDtJpInFormal
        /// <summary>�ŏI�������݌v��� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�������݌v��� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastReconcileAddUpDtJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _lastReconcileAddUpDt); }
            set { }
        }

        /// public propaty name  :  LastReconcileAddUpDtAdFormal
        /// <summary>�ŏI�������݌v��� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�������݌v��� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastReconcileAddUpDtAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _lastReconcileAddUpDt); }
            set { }
        }

        /// public propaty name  :  LastReconcileAddUpDtAdInFormal
        /// <summary>�ŏI�������݌v��� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI�������݌v��� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LastReconcileAddUpDtAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _lastReconcileAddUpDt); }
            set { }
        }

        /// public propaty name  :  DepositAgentCode
        /// <summary>�����S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositAgentCode
        {
            get { return _depositAgentCode; }
            set { _depositAgentCode = value; }
        }

        /// public propaty name  :  DepositAgentNm
        /// <summary>�����S���Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositAgentNm
        {
            get { return _depositAgentNm; }
            set { _depositAgentNm = value; }
        }

        /// public propaty name  :  DepositInputAgentCd
        /// <summary>�������͎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositInputAgentCd
        {
            get { return _depositInputAgentCd; }
            set { _depositInputAgentCd = value; }
        }

        /// public propaty name  :  DepositInputAgentNm
        /// <summary>�������͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositInputAgentNm
        {
            get { return _depositInputAgentNm; }
            set { _depositInputAgentNm = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>�����擾�Ӑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>�����於�̃v���p�e�B</summary>
        /// <value>�������Ӑ於��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>�����於��2�v���p�e�B</summary>
        /// <value>�������Ӑ於�̂Q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>�����旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// <value>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  BankCode
        /// <summary>��s�R�[�h�v���p�e�B</summary>
        /// <value>�X�֋ǁF9900</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BankCode
        {
            get { return _bankCode; }
            set { _bankCode = value; }
        }

        /// public propaty name  :  BankName
        /// <summary>��s���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  EdiSendDate
        /// <summary>�d�c�h���M���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdiSendDate
        {
            get { return _ediSendDate; }
            set { _ediSendDate = value; }
        }

        /// public propaty name  :  EdiTakeInDate
        /// <summary>�d�c�h�捞���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h�捞���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdiTakeInDate
        {
            get { return _ediTakeInDate; }
            set { _ediTakeInDate = value; }
        }
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DepositNm
        /// <summary>�a����敪���̃v���p�e�B</summary>
        /// <value>���C�A�E�g�Ɏ蓮�Œǉ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositNm
        {
            get { return _depositNm; }
            set { _depositNm = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  AddUpSecName
        /// <summary>�v�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }

        // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
        /// public property name  :  DepositRowNo
        /// <summary>�����s�ԍ�(1�`10)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ�(1�`10)�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public Int32[] DepositRowNo
        {
            get { return _depositRowNo; }
            set { _depositRowNo = value; }
        }
        /// public property name  :  MoneyKindCode
        /// <summary>����R�[�h(1�`10)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h(1�`10)�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public Int32[] MoneyKindCode
        {
            get { return _moneyKindCode; }
            set { _moneyKindCode = value; }
        }
        /// public property name  :  MoneyKindName
        /// <summary>���햼��(1�`10)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼��(1�`10)�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public String[] MoneyKindName
        {
            get { return _moneyKindName; }
            set { _moneyKindName = value; }
        }
        /// public property name  :  MoneyKindDiv
        /// <summary>����敪(1�`10)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪(1�`10)�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public Int32[] MoneyKindDiv
        {
            get { return _moneyKindDiv; }
            set { _moneyKindDiv = value; }
        }
        /// public property name  :  DepositDtl
        /// <summary>�������z(1�`10)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z(1�`10)�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public Int64[] DepositDtl
        {
            get { return _depositDtl; }
            set { _depositDtl = value; }
        }
        /// public property name  :  ValidityTerm
        /// <summary>�L������(1�`10)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L������(1�`10)�v���p�e�B</br>
        /// <br>Programer        :   30414 �E �K�j</br>
        /// <br>Date             :   2008/06/26</br>
        /// </remarks>
        public DateTime[] ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }
        // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<

        /// public propaty name  :  InputDay
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// <summary>
        /// ���������f�[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SearchDepsitMain�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepsitMain�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchDepsitMain()
        {
        }

        /// <summary>
        /// ���������f�[�^�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)</param>
        /// <param name="depositDebitNoteCd">�����ԍ��敪(0:��,1:��,2:���E�ςݍ�)</param>
        /// <param name="depositSlipNo">�����`�[�ԍ�</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="inputDepositSecCd">�������͋��_�R�[�h(�������͂������_�R�[�h)</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h(�����^ �f�[�^�̓o�^�X�V���_)</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="depositDate">�������t(YYYYMMDD)</param>
        /// <param name="addUpADate">�v����t(YYYYMMDD)</param>
        /// <param name="depositTotal">�����v</param>
        /// <param name="deposit">�������z(�l���E�萔�����������z)</param>
        /// <param name="feeDeposit">�萔�������z</param>
        /// <param name="discountDeposit">�l�������z</param>
        /// <param name="autoDepositCd">���������敪(0:�ʏ����,1:��������)</param>
        /// <param name="draftDrawingDate">��`�U�o��(YYYYMMDD)</param>
        /// <param name="draftKind">��`���</param>
        /// <param name="draftKindName">��`��ޖ���(�񑩁A�בցA���؎�)</param>
        /// <param name="draftDivide">��`�敪</param>
        /// <param name="draftDivideName">��`�敪����(���U�A��)</param>
        /// <param name="draftNo">��`�ԍ�</param>
        /// <param name="depositAllowance">���������z</param>
        /// <param name="depositAlwcBlnce">���������c��</param>
        /// <param name="debitNoteLinkDepoNo">�ԍ������A���ԍ�</param>
        /// <param name="lastReconcileAddUpDt">�ŏI�������݌v���(YYYYMMDD)</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ���</param>
        /// <param name="depositInputAgentCd">�������͎҃R�[�h</param>
        /// <param name="depositInputAgentNm">�������͎Җ���</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="claimCode">������R�[�h(�����擾�Ӑ�)</param>
        /// <param name="claimName">�����於��(�������Ӑ於��)</param>
        /// <param name="claimName2">�����於��2(�������Ӑ於�̂Q)</param>
        /// <param name="claimSnm">�����旪��</param>
        /// <param name="outline">�`�[�E�v(�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[)</param>
        /// <param name="bankCode">��s�R�[�h(�X�֋ǁF9900)</param>
        /// <param name="bankName">��s����</param>
        /// <param name="depositNm">�a����敪����(���C�A�E�g�Ɏ蓮�Œǉ�)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <param name="depositRowNo">�����s�ԍ�(1�`10)</param>
        /// <param name="moneyKindCode">����R�[�h(1�`10)</param>
        /// <param name="moneyKindName">���햼��(1�`10)</param>
        /// <param name="moneyKindDiv">����敪(1�`10)</param>
        /// <param name="depositDtl">�������z(1�`10)</param>
        /// <param name="validityTerm">�L������(1�`10)</param>
        /// <param name="inputDay">���͓�</param>
        /// <returns>SearchDepsitMain�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepsitMain�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        //public SearchDepsitMain(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 acptAnOdrStatus, Int32 depositDebitNoteCd, Int32 depositSlipNo, string salesSlipNum, string inputDepositSecCd, string addUpSecCode, string updateSecCd, Int32 subSectionCode, Int32 minSectionCode, DateTime depositDate, DateTime addUpADate, Int32 depositKindCode, string depositKindName, Int32 depositKindDivCd, Int64 depositTotal, Int64 deposit, Int64 feeDeposit, Int64 discountDeposit, Int32 autoDepositCd, Int32 depositCd, DateTime draftDrawingDate, DateTime draftPayTimeLimit, Int32 draftKind, string draftKindName, Int32 draftDivide, string draftDivideName, string draftNo, Int64 depositAllowance, Int64 depositAlwcBlnce, Int32 debitNoteLinkDepoNo, DateTime lastReconcileAddUpDt, string depositAgentCode, string depositAgentNm, string depositInputAgentCd, string depositInputAgentNm, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 claimCode, string claimName, string claimName2, string claimSnm, string outline, Int32 bankCode, string bankName, Int32 ediSendDate, Int32 ediTakeInDate, string depositNm, string enterpriseName, string updEmployeeName, string addUpSecName)
        public SearchDepsitMain(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, 
                                string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, 
                                Int32 acptAnOdrStatus, Int32 depositDebitNoteCd, Int32 depositSlipNo, string salesSlipNum, 
                                string inputDepositSecCd, string addUpSecCode, string updateSecCd, Int32 subSectionCode, 
                                DateTime depositDate, DateTime addUpADate, Int64 depositTotal, Int64 deposit, Int64 feeDeposit, 
                                Int64 discountDeposit, Int32 autoDepositCd, DateTime draftDrawingDate, 
                                Int32 draftKind, string draftKindName, Int32 draftDivide, string draftDivideName, 
                                string draftNo, Int64 depositAllowance, Int64 depositAlwcBlnce, Int32 debitNoteLinkDepoNo, 
                                DateTime lastReconcileAddUpDt, string depositAgentCode, string depositAgentNm, 
                                string depositInputAgentCd, string depositInputAgentNm, Int32 customerCode, string customerName, 
                                string customerName2, string customerSnm, Int32 claimCode, string claimName, string claimName2, 
                                string claimSnm, string outline, Int32 bankCode, string bankName, string depositNm, 
                                string enterpriseName, string updEmployeeName, string addUpSecName, Int32[] depositRowNo, 
                                Int32[] moneyKindCode, string[] moneyKindName, Int32[] moneyKindDiv, Int64[] depositDtl, 
                                DateTime[] validityTerm, DateTime inputDay)
        // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._depositDebitNoteCd = depositDebitNoteCd;
            this._depositSlipNo = depositSlipNo;
            this._salesSlipNum = salesSlipNum;
            this._inputDepositSecCd = inputDepositSecCd;
            this._addUpSecCode = addUpSecCode;
            this._updateSecCd = updateSecCd;
            this._subSectionCode = subSectionCode;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._minSectionCode = minSectionCode;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this.DepositDate = depositDate;
            this.AddUpADate = addUpADate;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._depositKindCode = depositKindCode;
            this._depositKindName = depositKindName;
            this._depositKindDivCd = depositKindDivCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._depositTotal = depositTotal;
            this._deposit = deposit;
            this._feeDeposit = feeDeposit;
            this._discountDeposit = discountDeposit;
            this._autoDepositCd = autoDepositCd;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._depositCd = depositCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this.DraftDrawingDate = draftDrawingDate;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this.DraftPayTimeLimit = draftPayTimeLimit;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._draftKind = draftKind;
            this._draftKindName = draftKindName;
            this._draftDivide = draftDivide;
            this._draftDivideName = draftDivideName;
            this._draftNo = draftNo;
            this._depositAllowance = depositAllowance;
            this._depositAlwcBlnce = depositAlwcBlnce;
            this._debitNoteLinkDepoNo = debitNoteLinkDepoNo;
            this.LastReconcileAddUpDt = lastReconcileAddUpDt;
            this._depositAgentCode = depositAgentCode;
            this._depositAgentNm = depositAgentNm;
            this._depositInputAgentCd = depositInputAgentCd;
            this._depositInputAgentNm = depositInputAgentNm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._outline = outline;
            this._bankCode = bankCode;
            this._bankName = bankName;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._ediSendDate = ediSendDate;
            this._ediTakeInDate = ediTakeInDate;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._depositNm = depositNm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                this._depositRowNo[index] = depositRowNo[index];
                this._moneyKindCode[index] = moneyKindCode[index];
                this._moneyKindName[index] = moneyKindName[index];
                this._moneyKindDiv[index] = moneyKindDiv[index];
                this._depositDtl[index] = depositDtl[index];
                this._validityTerm[index] = validityTerm[index];
            }
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            this._inputDay = inputDay;
        }

        /// <summary>
        /// ���������f�[�^�N���X��������
        /// </summary>
        /// <returns>SearchDepsitMain�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SearchDepsitMain�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchDepsitMain Clone()
        {
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //return new SearchDepsitMain(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, this._depositDebitNoteCd, this._depositSlipNo, this._salesSlipNum, this._inputDepositSecCd, this._addUpSecCode, this._updateSecCd, this._subSectionCode, this._minSectionCode, this._depositDate, this._addUpADate, this._depositKindCode, this._depositKindName, this._depositKindDivCd, this._depositTotal, this._deposit, this._feeDeposit, this._discountDeposit, this._autoDepositCd, this._depositCd, this._draftDrawingDate, this._draftPayTimeLimit, this._draftKind, this._draftKindName, this._draftDivide, this._draftDivideName, this._draftNo, this._depositAllowance, this._depositAlwcBlnce, this._debitNoteLinkDepoNo, this._lastReconcileAddUpDt, this._depositAgentCode, this._depositAgentNm, this._depositInputAgentCd, this._depositInputAgentNm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._outline, this._bankCode, this._bankName, this._ediSendDate, this._ediTakeInDate, this._depositNm, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
            return new SearchDepsitMain(this._createDateTime, this._updateDateTime, this._enterpriseCode, 
                                        this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, 
                                        this._updAssemblyId2, this._logicalDeleteCode, this._acptAnOdrStatus, 
                                        this._depositDebitNoteCd, this._depositSlipNo, this._salesSlipNum, 
                                        this._inputDepositSecCd, this._addUpSecCode, this._updateSecCd, 
                                        this._subSectionCode, this._depositDate, this._addUpADate, this._depositTotal,
                                        this._deposit, this._feeDeposit, this._discountDeposit, 
                                        this._autoDepositCd, this._draftDrawingDate, 
                                        this._draftKind, this._draftKindName, this._draftDivide, 
                                        this._draftDivideName, this._draftNo, this._depositAllowance, 
                                        this._depositAlwcBlnce, this._debitNoteLinkDepoNo, this._lastReconcileAddUpDt, 
                                        this._depositAgentCode, this._depositAgentNm, this._depositInputAgentCd, 
                                        this._depositInputAgentNm, this._customerCode, this._customerName, 
                                        this._customerName2, this._customerSnm, this._claimCode, 
                                        this._claimName, this._claimName2, this._claimSnm, 
                                        this._outline, this._bankCode, this._bankName, 
                                        this._depositNm, this._enterpriseName, this._updEmployeeName, 
                                        this._addUpSecName, this._depositRowNo, this._moneyKindCode, 
                                        this._moneyKindName, this._moneyKindDiv, this._depositDtl, 
                                        this._validityTerm, this._inputDay);
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ���������f�[�^�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchDepsitMain�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepsitMain�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SearchDepsitMain target)
        {
            //return ((this.CreateDateTime == target.CreateDateTime)
            //     && (this.UpdateDateTime == target.UpdateDateTime)
            //     && (this.EnterpriseCode == target.EnterpriseCode)
            //     && (this.FileHeaderGuid == target.FileHeaderGuid)
            //     && (this.UpdEmployeeCode == target.UpdEmployeeCode)
            //     && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
            //     && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
            //     && (this.LogicalDeleteCode == target.LogicalDeleteCode)
            //     && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
            //     && (this.DepositDebitNoteCd == target.DepositDebitNoteCd)
            //     && (this.DepositSlipNo == target.DepositSlipNo)
            //     && (this.SalesSlipNum == target.SalesSlipNum)
            //     && (this.InputDepositSecCd == target.InputDepositSecCd)
            //     && (this.AddUpSecCode == target.AddUpSecCode)
            //     && (this.UpdateSecCd == target.UpdateSecCd)
            //     && (this.SubSectionCode == target.SubSectionCode)
            //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.MinSectionCode == target.MinSectionCode)
            //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //     && (this.DepositDate == target.DepositDate)
            //     && (this.AddUpADate == target.AddUpADate)
            //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.DepositKindCode == target.DepositKindCode)
            //    && (this.DepositKindName == target.DepositKindName)
            //    && (this.DepositKindDivCd == target.DepositKindDivCd)
            //    && (this.DepositTotal == target.DepositTotal)
            //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //     && (this.Deposit == target.Deposit)
            //     && (this.FeeDeposit == target.FeeDeposit)
            //     && (this.DiscountDeposit == target.DiscountDeposit)
            //     && (this.AutoDepositCd == target.AutoDepositCd)
            //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.DepositCd == target.DepositCd)
            //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //    && (this.DraftDrawingDate == target.DraftDrawingDate)
            //   /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //   && (this.DraftPayTimeLimit == target.DraftPayTimeLimit)
            //      --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //     && (this.DraftKind == target.DraftKind)
            //     && (this.DraftKindName == target.DraftKindName)
            //     && (this.DraftDivide == target.DraftDivide)
            //     && (this.DraftDivideName == target.DraftDivideName)
            //     && (this.DraftNo == target.DraftNo)
            //     && (this.DepositAllowance == target.DepositAllowance)
            //     && (this.DepositAlwcBlnce == target.DepositAlwcBlnce)
            //     && (this.DebitNoteLinkDepoNo == target.DebitNoteLinkDepoNo)
            //     && (this.LastReconcileAddUpDt == target.LastReconcileAddUpDt)
            //     && (this.DepositAgentCode == target.DepositAgentCode)
            //     && (this.DepositAgentNm == target.DepositAgentNm)
            //     && (this.DepositInputAgentCd == target.DepositInputAgentCd)
            //     && (this.DepositInputAgentNm == target.DepositInputAgentNm)
            //     && (this.CustomerCode == target.CustomerCode)
            //     && (this.CustomerName == target.CustomerName)
            //     && (this.CustomerName2 == target.CustomerName2)
            //     && (this.CustomerSnm == target.CustomerSnm)
            //     && (this.ClaimCode == target.ClaimCode)
            //     && (this.ClaimName == target.ClaimName)
            //     && (this.ClaimName2 == target.ClaimName2)
            //     && (this.ClaimSnm == target.ClaimSnm)
            //     && (this.Outline == target.Outline)
            //     && (this.BankCode == target.BankCode)
            //     && (this.BankName == target.BankName)
            //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.EdiSendDate == target.EdiSendDate)
            //    && (this.EdiTakeInDate == target.EdiTakeInDate)
            //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            //    && (this.DepositNm == target.DepositNm)
            //    && (this.EnterpriseName == target.EnterpriseName)
            //    && (this.UpdEmployeeName == target.UpdEmployeeName)
            //    && (this.AddUpSecName == target.AddUpSecName)
            //    // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            //    && (this.DepositRowNo == target.DepositRowNo)
            //    && (this.MoneyKindCode == target.MoneyKindCode)
            //    && (this.MoneyKindName == target.MoneyKindName)
            //    && (this.MoneyKindDiv == target.MoneyKindDiv)
            //    && (this.DepositDtl == target.DepositDtl)
            //    && (this.ValidityTerm == target.ValidityTerm)
            //    // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            //    );
            if (this.CreateDateTime != target.CreateDateTime) { return (false); }
            if (this.UpdateDateTime != target.UpdateDateTime) { return (false); }
            if (this.EnterpriseCode != target.EnterpriseCode) { return (false); }
            if (this.FileHeaderGuid != target.FileHeaderGuid) { return (false); }
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) { return (false); }
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) { return (false); }
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) { return (false); }
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) { return (false); }
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) { return (false); }
            if (this.DepositDebitNoteCd != target.DepositDebitNoteCd) { return (false); }
            if (this.DepositSlipNo != target.DepositSlipNo) { return (false); }
            if (this.SalesSlipNum != target.SalesSlipNum) { return (false); }
            if (this.InputDepositSecCd != target.InputDepositSecCd) { return (false); }
            if (this.AddUpSecCode != target.AddUpSecCode) { return (false); }
            if (this.UpdateSecCd != target.UpdateSecCd) { return (false); }
            if (this.SubSectionCode != target.SubSectionCode) { return (false); }
            if (this.DepositDate != target.DepositDate) { return (false); }
            if (this.AddUpADate != target.AddUpADate) { return (false); }
            if (this.Deposit != target.Deposit) { return (false); }
            if (this.FeeDeposit != target.FeeDeposit) { return (false); }
            if (this.DiscountDeposit != target.DiscountDeposit) { return (false); }
            if (this.AutoDepositCd != target.AutoDepositCd) { return (false); }
            if (this.DraftDrawingDate != target.DraftDrawingDate) { return (false); }
            if (this.DraftKind != target.DraftKind) { return (false); }
            if (this.DraftKindName != target.DraftKindName) { return (false); }
            if (this.DraftDivide != target.DraftDivide) { return (false); }
            if (this.DraftDivideName != target.DraftDivideName) { return (false); }
            if (this.DraftNo != target.DraftNo) { return (false); }
            if (this.DepositAllowance != target.DepositAllowance) { return (false); }
            if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) { return (false); }
            if (this.DebitNoteLinkDepoNo != target.DebitNoteLinkDepoNo) { return (false); }
            if (this.LastReconcileAddUpDt != target.LastReconcileAddUpDt) { return (false); }
            if (this.DepositAgentCode != target.DepositAgentCode) { return (false); }
            if (this.DepositAgentNm != target.DepositAgentNm) { return (false); }
            if (this.DepositInputAgentCd != target.DepositInputAgentCd) { return (false); }
            if (this.DepositInputAgentNm != target.DepositInputAgentNm) { return (false); }
            if (this.CustomerCode != target.CustomerCode) { return (false); }
            if (this.CustomerName != target.CustomerName) { return (false); }
            if (this.CustomerName2 != target.CustomerName2) { return (false); }
            if (this.CustomerSnm != target.CustomerSnm) { return (false); }
            if (this.ClaimCode != target.ClaimCode) { return (false); }
            if (this.ClaimName != target.ClaimName) { return (false); }
            if (this.ClaimName2 != target.ClaimName2) { return (false); }
            if (this.ClaimSnm != target.ClaimSnm) { return (false); }
            if (this.Outline != target.Outline) { return (false); }
            if (this.BankCode != target.BankCode) { return (false); }
            if (this.BankName != target.BankName) { return (false); }
            if (this.DepositNm != target.DepositNm) { return (false); }
            if (this.EnterpriseName != target.EnterpriseName) { return (false); }
            if (this.UpdEmployeeName != target.UpdEmployeeName) { return (false); }
            if (this.AddUpSecName != target.AddUpSecName) { return (false); }
            for (int index = 0; index < 10; index++)
            {
                if (this.DepositRowNo != target.DepositRowNo) { return (false); }
                if (this.MoneyKindCode != target.MoneyKindCode) { return (false); }
                if (this.MoneyKindName != target.MoneyKindName) { return (false); }
                if (this.MoneyKindDiv != target.MoneyKindDiv) { return (false); }
                if (this.DepositDtl != target.DepositDtl) { return (false); }
                if (this.ValidityTerm != target.ValidityTerm) { return (false); }
            }
            if (this.InputDay != target.InputDay) { return (false); }

            return (true);
       }

        /// <summary>
        /// ���������f�[�^�N���X��r����
        /// </summary>
        /// <param name="searchDepsitMain1">
        ///                    ��r����SearchDepsitMain�N���X�̃C���X�^���X
        /// </param>
        /// <param name="searchDepsitMain2">��r����SearchDepsitMain�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepsitMain�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SearchDepsitMain searchDepsitMain1, SearchDepsitMain searchDepsitMain2)
       {
           //return ((searchDepsitMain1.CreateDateTime == searchDepsitMain2.CreateDateTime)
           //     && (searchDepsitMain1.UpdateDateTime == searchDepsitMain2.UpdateDateTime)
           //     && (searchDepsitMain1.EnterpriseCode == searchDepsitMain2.EnterpriseCode)
           //     && (searchDepsitMain1.FileHeaderGuid == searchDepsitMain2.FileHeaderGuid)
           //     && (searchDepsitMain1.UpdEmployeeCode == searchDepsitMain2.UpdEmployeeCode)
           //     && (searchDepsitMain1.UpdAssemblyId1 == searchDepsitMain2.UpdAssemblyId1)
           //     && (searchDepsitMain1.UpdAssemblyId2 == searchDepsitMain2.UpdAssemblyId2)
           //     && (searchDepsitMain1.LogicalDeleteCode == searchDepsitMain2.LogicalDeleteCode)
           //     && (searchDepsitMain1.AcptAnOdrStatus == searchDepsitMain2.AcptAnOdrStatus)
           //     && (searchDepsitMain1.DepositDebitNoteCd == searchDepsitMain2.DepositDebitNoteCd)
           //     && (searchDepsitMain1.DepositSlipNo == searchDepsitMain2.DepositSlipNo)
           //     && (searchDepsitMain1.SalesSlipNum == searchDepsitMain2.SalesSlipNum)
           //     && (searchDepsitMain1.InputDepositSecCd == searchDepsitMain2.InputDepositSecCd)
           //     && (searchDepsitMain1.AddUpSecCode == searchDepsitMain2.AddUpSecCode)
           //     && (searchDepsitMain1.UpdateSecCd == searchDepsitMain2.UpdateSecCd)
           //     && (searchDepsitMain1.SubSectionCode == searchDepsitMain2.SubSectionCode)
           //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //    && (searchDepsitMain1.MinSectionCode == searchDepsitMain2.MinSectionCode)
           //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //      && (searchDepsitMain1.DepositDate == searchDepsitMain2.DepositDate)
           //      && (searchDepsitMain1.AddUpADate == searchDepsitMain2.AddUpADate)
           //     /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //     && (searchDepsitMain1.DepositKindCode == searchDepsitMain2.DepositKindCode)
           //     && (searchDepsitMain1.DepositKindName == searchDepsitMain2.DepositKindName)
           //     && (searchDepsitMain1.DepositKindDivCd == searchDepsitMain2.DepositKindDivCd)
           //     && (searchDepsitMain1.DepositTotal == searchDepsitMain2.DepositTotal)
           //        --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //      && (searchDepsitMain1.Deposit == searchDepsitMain2.Deposit)
           //      && (searchDepsitMain1.FeeDeposit == searchDepsitMain2.FeeDeposit)
           //      && (searchDepsitMain1.DiscountDeposit == searchDepsitMain2.DiscountDeposit)
           //      && (searchDepsitMain1.AutoDepositCd == searchDepsitMain2.AutoDepositCd)
           //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //    && (searchDepsitMain1.DepositCd == searchDepsitMain2.DepositCd)
           //       --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //    && (searchDepsitMain1.DraftDrawingDate == searchDepsitMain2.DraftDrawingDate)
           //   /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //   && (searchDepsitMain1.DraftPayTimeLimit == searchDepsitMain2.DraftPayTimeLimit)
           //      --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //      && (searchDepsitMain1.DraftKind == searchDepsitMain2.DraftKind)
           //      && (searchDepsitMain1.DraftKindName == searchDepsitMain2.DraftKindName)
           //      && (searchDepsitMain1.DraftDivide == searchDepsitMain2.DraftDivide)
           //      && (searchDepsitMain1.DraftDivideName == searchDepsitMain2.DraftDivideName)
           //      && (searchDepsitMain1.DraftNo == searchDepsitMain2.DraftNo)
           //      && (searchDepsitMain1.DepositAllowance == searchDepsitMain2.DepositAllowance)
           //      && (searchDepsitMain1.DepositAlwcBlnce == searchDepsitMain2.DepositAlwcBlnce)
           //      && (searchDepsitMain1.DebitNoteLinkDepoNo == searchDepsitMain2.DebitNoteLinkDepoNo)
           //      && (searchDepsitMain1.LastReconcileAddUpDt == searchDepsitMain2.LastReconcileAddUpDt)
           //      && (searchDepsitMain1.DepositAgentCode == searchDepsitMain2.DepositAgentCode)
           //      && (searchDepsitMain1.DepositAgentNm == searchDepsitMain2.DepositAgentNm)
           //      && (searchDepsitMain1.DepositInputAgentCd == searchDepsitMain2.DepositInputAgentCd)
           //      && (searchDepsitMain1.DepositInputAgentNm == searchDepsitMain2.DepositInputAgentNm)
           //      && (searchDepsitMain1.CustomerCode == searchDepsitMain2.CustomerCode)
           //      && (searchDepsitMain1.CustomerName == searchDepsitMain2.CustomerName)
           //      && (searchDepsitMain1.CustomerName2 == searchDepsitMain2.CustomerName2)
           //      && (searchDepsitMain1.CustomerSnm == searchDepsitMain2.CustomerSnm)
           //      && (searchDepsitMain1.ClaimCode == searchDepsitMain2.ClaimCode)
           //      && (searchDepsitMain1.ClaimName == searchDepsitMain2.ClaimName)
           //      && (searchDepsitMain1.ClaimName2 == searchDepsitMain2.ClaimName2)
           //      && (searchDepsitMain1.ClaimSnm == searchDepsitMain2.ClaimSnm)
           //      && (searchDepsitMain1.Outline == searchDepsitMain2.Outline)
           //      && (searchDepsitMain1.BankCode == searchDepsitMain2.BankCode)
           //      && (searchDepsitMain1.BankName == searchDepsitMain2.BankName)
           //    /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
           //    && (searchDepsitMain1.EdiSendDate == searchDepsitMain2.EdiSendDate)
           //    && (searchDepsitMain1.EdiTakeInDate == searchDepsitMain2.EdiTakeInDate)
           //      --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
           //      && (searchDepsitMain1.DepositNm == searchDepsitMain2.DepositNm)
           //      && (searchDepsitMain1.EnterpriseName == searchDepsitMain2.EnterpriseName)
           //      && (searchDepsitMain1.UpdEmployeeName == searchDepsitMain2.UpdEmployeeName)
           //      && (searchDepsitMain1.AddUpSecName == searchDepsitMain2.AddUpSecName)
           //      // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
           //      && (searchDepsitMain1.DepositRowNo == searchDepsitMain2.DepositRowNo)
           //      && (searchDepsitMain1.MoneyKindCode == searchDepsitMain2.MoneyKindCode)
           //      && (searchDepsitMain1.MoneyKindName == searchDepsitMain2.MoneyKindName)
           //      && (searchDepsitMain1.MoneyKindDiv == searchDepsitMain2.MoneyKindDiv)
           //      && (searchDepsitMain1.DepositDtl == searchDepsitMain2.DepositDtl)
           //      && (searchDepsitMain1.ValidityTerm == searchDepsitMain2.ValidityTerm)
           //      // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
           //      );
            if (searchDepsitMain1.CreateDateTime != searchDepsitMain2.CreateDateTime) { return (false); }
            if (searchDepsitMain1.UpdateDateTime != searchDepsitMain2.UpdateDateTime) { return (false); }
            if (searchDepsitMain1.EnterpriseCode != searchDepsitMain2.EnterpriseCode) { return (false); }
            if (searchDepsitMain1.FileHeaderGuid != searchDepsitMain2.FileHeaderGuid) { return (false); }
            if (searchDepsitMain1.UpdEmployeeCode != searchDepsitMain2.UpdEmployeeCode) { return (false); }
            if (searchDepsitMain1.UpdAssemblyId1 != searchDepsitMain2.UpdAssemblyId1) { return (false); }
            if (searchDepsitMain1.UpdAssemblyId2 != searchDepsitMain2.UpdAssemblyId2) { return (false); }
            if (searchDepsitMain1.LogicalDeleteCode != searchDepsitMain2.LogicalDeleteCode) { return (false); }
            if (searchDepsitMain1.AcptAnOdrStatus != searchDepsitMain2.AcptAnOdrStatus) { return (false); }
            if (searchDepsitMain1.DepositDebitNoteCd != searchDepsitMain2.DepositDebitNoteCd) { return (false); }
            if (searchDepsitMain1.DepositSlipNo != searchDepsitMain2.DepositSlipNo) { return (false); }
            if (searchDepsitMain1.SalesSlipNum != searchDepsitMain2.SalesSlipNum) { return (false); }
            if (searchDepsitMain1.InputDepositSecCd != searchDepsitMain2.InputDepositSecCd) { return (false); }
            if (searchDepsitMain1.AddUpSecCode != searchDepsitMain2.AddUpSecCode) { return (false); }
            if (searchDepsitMain1.UpdateSecCd != searchDepsitMain2.UpdateSecCd) { return (false); }
            if (searchDepsitMain1.SubSectionCode != searchDepsitMain2.SubSectionCode) { return (false); }
            if (searchDepsitMain1.DepositDate != searchDepsitMain2.DepositDate) { return (false); }
            if (searchDepsitMain1.AddUpADate != searchDepsitMain2.AddUpADate) { return (false); }
            if (searchDepsitMain1.Deposit != searchDepsitMain2.Deposit) { return (false); }
            if (searchDepsitMain1.FeeDeposit != searchDepsitMain2.FeeDeposit) { return (false); }
            if (searchDepsitMain1.DiscountDeposit != searchDepsitMain2.DiscountDeposit) { return (false); }
            if (searchDepsitMain1.AutoDepositCd != searchDepsitMain2.AutoDepositCd) { return (false); }
            if (searchDepsitMain1.DraftDrawingDate != searchDepsitMain2.DraftDrawingDate) { return (false); }
            if (searchDepsitMain1.DraftKind != searchDepsitMain2.DraftKind) { return (false); }
            if (searchDepsitMain1.DraftKindName != searchDepsitMain2.DraftKindName) { return (false); }
            if (searchDepsitMain1.DraftDivide != searchDepsitMain2.DraftDivide) { return (false); }
            if (searchDepsitMain1.DraftDivideName != searchDepsitMain2.DraftDivideName) { return (false); }
            if (searchDepsitMain1.DraftNo != searchDepsitMain2.DraftNo) { return (false); }
            if (searchDepsitMain1.DepositAllowance != searchDepsitMain2.DepositAllowance) { return (false); }
            if (searchDepsitMain1.DepositAlwcBlnce != searchDepsitMain2.DepositAlwcBlnce) { return (false); }
            if (searchDepsitMain1.DebitNoteLinkDepoNo != searchDepsitMain2.DebitNoteLinkDepoNo) { return (false); }
            if (searchDepsitMain1.LastReconcileAddUpDt != searchDepsitMain2.LastReconcileAddUpDt) { return (false); }
            if (searchDepsitMain1.DepositAgentCode != searchDepsitMain2.DepositAgentCode) { return (false); }
            if (searchDepsitMain1.DepositAgentNm != searchDepsitMain2.DepositAgentNm) { return (false); }
            if (searchDepsitMain1.DepositInputAgentCd != searchDepsitMain2.DepositInputAgentCd) { return (false); }
            if (searchDepsitMain1.DepositInputAgentNm != searchDepsitMain2.DepositInputAgentNm) { return (false); }
            if (searchDepsitMain1.CustomerCode != searchDepsitMain2.CustomerCode) { return (false); }
            if (searchDepsitMain1.CustomerName != searchDepsitMain2.CustomerName) { return (false); }
            if (searchDepsitMain1.CustomerName2 != searchDepsitMain2.CustomerName2) { return (false); }
            if (searchDepsitMain1.CustomerSnm != searchDepsitMain2.CustomerSnm) { return (false); }
            if (searchDepsitMain1.ClaimCode != searchDepsitMain2.ClaimCode) { return (false); }
            if (searchDepsitMain1.ClaimName != searchDepsitMain2.ClaimName) { return (false); }
            if (searchDepsitMain1.ClaimName2 != searchDepsitMain2.ClaimName2) { return (false); }
            if (searchDepsitMain1.ClaimSnm != searchDepsitMain2.ClaimSnm) { return (false); }
            if (searchDepsitMain1.Outline != searchDepsitMain2.Outline) { return (false); }
            if (searchDepsitMain1.BankCode != searchDepsitMain2.BankCode) { return (false); }
            if (searchDepsitMain1.BankName != searchDepsitMain2.BankName) { return (false); }
            if (searchDepsitMain1.DepositNm != searchDepsitMain2.DepositNm) { return (false); }
            if (searchDepsitMain1.EnterpriseName != searchDepsitMain2.EnterpriseName) { return (false); }
            if (searchDepsitMain1.UpdEmployeeName != searchDepsitMain2.UpdEmployeeName) { return (false); }
            if (searchDepsitMain1.AddUpSecName != searchDepsitMain2.AddUpSecName) { return (false); }
            for (int index = 0; index < 10; index++)
            {
                if (searchDepsitMain1.DepositRowNo != searchDepsitMain2.DepositRowNo) { return (false); }
                if (searchDepsitMain1.MoneyKindCode != searchDepsitMain2.MoneyKindCode) { return (false); }
                if (searchDepsitMain1.MoneyKindName != searchDepsitMain2.MoneyKindName) { return (false); }
                if (searchDepsitMain1.MoneyKindDiv != searchDepsitMain2.MoneyKindDiv) { return (false); }
                if (searchDepsitMain1.DepositDtl != searchDepsitMain2.DepositDtl) { return (false); }
                if (searchDepsitMain1.ValidityTerm != searchDepsitMain2.ValidityTerm) { return (false); }
            }
            if (searchDepsitMain1.InputDay != searchDepsitMain2.InputDay) { return (false); }

            return (true);
        }
        /// <summary>
        /// ���������f�[�^�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchDepsitMain�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepsitMain�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SearchDepsitMain target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.DepositDebitNoteCd != target.DepositDebitNoteCd) resList.Add("DepositDebitNoteCd");
            if (this.DepositSlipNo != target.DepositSlipNo) resList.Add("DepositSlipNo");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.InputDepositSecCd != target.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.MinSectionCode != target.MinSectionCode) resList.Add("MinSectionCode");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DepositDate != target.DepositDate) resList.Add("DepositDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DepositKindCode != target.DepositKindCode) resList.Add("DepositKindCode");
            if (this.DepositKindName != target.DepositKindName) resList.Add("DepositKindName");
            if (this.DepositKindDivCd != target.DepositKindDivCd) resList.Add("DepositKindDivCd");
            if (this.DepositTotal != target.DepositTotal) resList.Add("DepositTotal");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.Deposit != target.Deposit) resList.Add("Deposit");
            if (this.FeeDeposit != target.FeeDeposit) resList.Add("FeeDeposit");
            if (this.DiscountDeposit != target.DiscountDeposit) resList.Add("DiscountDeposit");
            if (this.AutoDepositCd != target.AutoDepositCd) resList.Add("AutoDepositCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DepositCd != target.DepositCd) resList.Add("DepositCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DraftPayTimeLimit != target.DraftPayTimeLimit) resList.Add("DraftPayTimeLimit");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DraftKind != target.DraftKind) resList.Add("DraftKind");
            if (this.DraftKindName != target.DraftKindName) resList.Add("DraftKindName");
            if (this.DraftDivide != target.DraftDivide) resList.Add("DraftDivide");
            if (this.DraftDivideName != target.DraftDivideName) resList.Add("DraftDivideName");
            if (this.DraftNo != target.DraftNo) resList.Add("DraftNo");
            if (this.DepositAllowance != target.DepositAllowance) resList.Add("DepositAllowance");
            if (this.DepositAlwcBlnce != target.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (this.DebitNoteLinkDepoNo != target.DebitNoteLinkDepoNo) resList.Add("DebitNoteLinkDepoNo");
            if (this.LastReconcileAddUpDt != target.LastReconcileAddUpDt) resList.Add("LastReconcileAddUpDt");
            if (this.DepositAgentCode != target.DepositAgentCode) resList.Add("DepositAgentCode");
            if (this.DepositAgentNm != target.DepositAgentNm) resList.Add("DepositAgentNm");
            if (this.DepositInputAgentCd != target.DepositInputAgentCd) resList.Add("DepositInputAgentCd");
            if (this.DepositInputAgentNm != target.DepositInputAgentNm) resList.Add("DepositInputAgentNm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.Outline != target.Outline) resList.Add("Outline");
            if (this.BankCode != target.BankCode) resList.Add("BankCode");
            if (this.BankName != target.BankName) resList.Add("BankName");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.EdiSendDate != target.EdiSendDate) resList.Add("EdiSendDate");
            if (this.EdiTakeInDate != target.EdiTakeInDate) resList.Add("EdiTakeInDate");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DepositNm != target.DepositNm) resList.Add("DepositNm");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                if (this.DepositRowNo[index] != target.DepositRowNo[index]) resList.Add("DepositRowNo");
                if (this.MoneyKindCode[index] != target.MoneyKindCode[index]) resList.Add("MoneyKindCode");
                if (this.MoneyKindName[index] != target.MoneyKindName[index]) resList.Add("MoneyKindName");
                if (this.MoneyKindDiv[index] != target.MoneyKindDiv[index]) resList.Add("MoneyKindDiv");
                if (this.DepositDtl[index] != target.DepositDtl[index]) resList.Add("DepositDtl");
                if (this.ValidityTerm[index] != target.ValidityTerm[index]) resList.Add("ValidityTerm");
            }
            //if (this.DepositRowNo != target.DepositRowNo) resList.Add("DepositRowNo");
            //if (this.MoneyKindCode != target.MoneyKindCode) resList.Add("MoneyKindCode");
            //if (this.MoneyKindName != target.MoneyKindName) resList.Add("MoneyKindName");
            //if (this.MoneyKindDiv != target.MoneyKindDiv) resList.Add("MoneyKindDiv");
            //if (this.DepositDtl != target.DepositDtl) resList.Add("DepositDtl");
            //if (this.ValidityTerm != target.ValidityTerm) resList.Add("ValidityTerm");
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            if (this.InputDay != target.InputDay) resList.Add("InputDay");

            return resList;
        }

        /// <summary>
        /// ���������f�[�^�N���X��r����
        /// </summary>
        /// <param name="searchDepsitMain1">��r����SearchDepsitMain�N���X�̃C���X�^���X</param>
        /// <param name="searchDepsitMain2">��r����SearchDepsitMain�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepsitMain�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SearchDepsitMain searchDepsitMain1, SearchDepsitMain searchDepsitMain2)
        {
            ArrayList resList = new ArrayList();
            if (searchDepsitMain1.CreateDateTime != searchDepsitMain2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchDepsitMain1.UpdateDateTime != searchDepsitMain2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchDepsitMain1.EnterpriseCode != searchDepsitMain2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchDepsitMain1.FileHeaderGuid != searchDepsitMain2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchDepsitMain1.UpdEmployeeCode != searchDepsitMain2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchDepsitMain1.UpdAssemblyId1 != searchDepsitMain2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchDepsitMain1.UpdAssemblyId2 != searchDepsitMain2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchDepsitMain1.LogicalDeleteCode != searchDepsitMain2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchDepsitMain1.AcptAnOdrStatus != searchDepsitMain2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (searchDepsitMain1.DepositDebitNoteCd != searchDepsitMain2.DepositDebitNoteCd) resList.Add("DepositDebitNoteCd");
            if (searchDepsitMain1.DepositSlipNo != searchDepsitMain2.DepositSlipNo) resList.Add("DepositSlipNo");
            if (searchDepsitMain1.SalesSlipNum != searchDepsitMain2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (searchDepsitMain1.InputDepositSecCd != searchDepsitMain2.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (searchDepsitMain1.AddUpSecCode != searchDepsitMain2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (searchDepsitMain1.UpdateSecCd != searchDepsitMain2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (searchDepsitMain1.SubSectionCode != searchDepsitMain2.SubSectionCode) resList.Add("SubSectionCode");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.MinSectionCode != searchDepsitMain2.MinSectionCode) resList.Add("MinSectionCode");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.DepositDate != searchDepsitMain2.DepositDate) resList.Add("DepositDate");
            if (searchDepsitMain1.AddUpADate != searchDepsitMain2.AddUpADate) resList.Add("AddUpADate");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.DepositKindCode != searchDepsitMain2.DepositKindCode) resList.Add("DepositKindCode");
            if (searchDepsitMain1.DepositKindName != searchDepsitMain2.DepositKindName) resList.Add("DepositKindName");
            if (searchDepsitMain1.DepositKindDivCd != searchDepsitMain2.DepositKindDivCd) resList.Add("DepositKindDivCd");
            if (searchDepsitMain1.DepositTotal != searchDepsitMain2.DepositTotal) resList.Add("DepositTotal");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.Deposit != searchDepsitMain2.Deposit) resList.Add("Deposit");
            if (searchDepsitMain1.FeeDeposit != searchDepsitMain2.FeeDeposit) resList.Add("FeeDeposit");
            if (searchDepsitMain1.DiscountDeposit != searchDepsitMain2.DiscountDeposit) resList.Add("DiscountDeposit");
            if (searchDepsitMain1.AutoDepositCd != searchDepsitMain2.AutoDepositCd) resList.Add("AutoDepositCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.DepositCd != searchDepsitMain2.DepositCd) resList.Add("DepositCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.DraftDrawingDate != searchDepsitMain2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.DraftPayTimeLimit != searchDepsitMain2.DraftPayTimeLimit) resList.Add("DraftPayTimeLimit");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.DraftKind != searchDepsitMain2.DraftKind) resList.Add("DraftKind");
            if (searchDepsitMain1.DraftKindName != searchDepsitMain2.DraftKindName) resList.Add("DraftKindName");
            if (searchDepsitMain1.DraftDivide != searchDepsitMain2.DraftDivide) resList.Add("DraftDivide");
            if (searchDepsitMain1.DraftDivideName != searchDepsitMain2.DraftDivideName) resList.Add("DraftDivideName");
            if (searchDepsitMain1.DraftNo != searchDepsitMain2.DraftNo) resList.Add("DraftNo");
            if (searchDepsitMain1.DepositAllowance != searchDepsitMain2.DepositAllowance) resList.Add("DepositAllowance");
            if (searchDepsitMain1.DepositAlwcBlnce != searchDepsitMain2.DepositAlwcBlnce) resList.Add("DepositAlwcBlnce");
            if (searchDepsitMain1.DebitNoteLinkDepoNo != searchDepsitMain2.DebitNoteLinkDepoNo) resList.Add("DebitNoteLinkDepoNo");
            if (searchDepsitMain1.LastReconcileAddUpDt != searchDepsitMain2.LastReconcileAddUpDt) resList.Add("LastReconcileAddUpDt");
            if (searchDepsitMain1.DepositAgentCode != searchDepsitMain2.DepositAgentCode) resList.Add("DepositAgentCode");
            if (searchDepsitMain1.DepositAgentNm != searchDepsitMain2.DepositAgentNm) resList.Add("DepositAgentNm");
            if (searchDepsitMain1.DepositInputAgentCd != searchDepsitMain2.DepositInputAgentCd) resList.Add("DepositInputAgentCd");
            if (searchDepsitMain1.DepositInputAgentNm != searchDepsitMain2.DepositInputAgentNm) resList.Add("DepositInputAgentNm");
            if (searchDepsitMain1.CustomerCode != searchDepsitMain2.CustomerCode) resList.Add("CustomerCode");
            if (searchDepsitMain1.CustomerName != searchDepsitMain2.CustomerName) resList.Add("CustomerName");
            if (searchDepsitMain1.CustomerName2 != searchDepsitMain2.CustomerName2) resList.Add("CustomerName2");
            if (searchDepsitMain1.CustomerSnm != searchDepsitMain2.CustomerSnm) resList.Add("CustomerSnm");
            if (searchDepsitMain1.ClaimCode != searchDepsitMain2.ClaimCode) resList.Add("ClaimCode");
            if (searchDepsitMain1.ClaimName != searchDepsitMain2.ClaimName) resList.Add("ClaimName");
            if (searchDepsitMain1.ClaimName2 != searchDepsitMain2.ClaimName2) resList.Add("ClaimName2");
            if (searchDepsitMain1.ClaimSnm != searchDepsitMain2.ClaimSnm) resList.Add("ClaimSnm");
            if (searchDepsitMain1.Outline != searchDepsitMain2.Outline) resList.Add("Outline");
            if (searchDepsitMain1.BankCode != searchDepsitMain2.BankCode) resList.Add("BankCode");
            if (searchDepsitMain1.BankName != searchDepsitMain2.BankName) resList.Add("BankName");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepsitMain1.EdiSendDate != searchDepsitMain2.EdiSendDate) resList.Add("EdiSendDate");
            if (searchDepsitMain1.EdiTakeInDate != searchDepsitMain2.EdiTakeInDate) resList.Add("EdiTakeInDate");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepsitMain1.DepositNm != searchDepsitMain2.DepositNm) resList.Add("DepositNm");
            if (searchDepsitMain1.EnterpriseName != searchDepsitMain2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchDepsitMain1.UpdEmployeeName != searchDepsitMain2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchDepsitMain1.AddUpSecName != searchDepsitMain2.AddUpSecName) resList.Add("AddUpSecName");
            // --- ADD 2008/06/26 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                if (searchDepsitMain1.DepositRowNo[index] != searchDepsitMain2.DepositRowNo[index]) resList.Add("DepositRowNo");
                if (searchDepsitMain1.MoneyKindCode[index] != searchDepsitMain2.MoneyKindCode[index]) resList.Add("MoneyKindCode");
                if (searchDepsitMain1.MoneyKindName[index] != searchDepsitMain2.MoneyKindName[index]) resList.Add("MoneyKindName");
                if (searchDepsitMain1.MoneyKindDiv[index] != searchDepsitMain2.MoneyKindDiv[index]) resList.Add("MoneyKindDiv");
                if (searchDepsitMain1.DepositDtl[index] != searchDepsitMain2.DepositDtl[index]) resList.Add("DepositDtl");
                if (searchDepsitMain1.ValidityTerm[index] != searchDepsitMain2.ValidityTerm[index]) resList.Add("ValidityTerm");
            }
            //if (searchDepsitMain1.DepositRowNo != searchDepsitMain2.DepositRowNo) resList.Add("DepositRowNo");
            //if (searchDepsitMain1.MoneyKindCode != searchDepsitMain2.MoneyKindCode) resList.Add("MoneyKindCode");
            //if (searchDepsitMain1.MoneyKindName != searchDepsitMain2.MoneyKindName) resList.Add("MoneyKindName");
            //if (searchDepsitMain1.MoneyKindDiv != searchDepsitMain2.MoneyKindDiv) resList.Add("MoneyKindDiv");
            //if (searchDepsitMain1.DepositDtl != searchDepsitMain2.DepositDtl) resList.Add("DepositDtl");
            //if (searchDepsitMain1.ValidityTerm != searchDepsitMain2.ValidityTerm) resList.Add("ValidityTerm");
            // --- ADD 2008/06/26 ---------------------------------------------------------------------<<<<<
            if (searchDepsitMain1.InputDay != searchDepsitMain2.InputDay) resList.Add("InputDay");

            return resList;
        }
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /*
    /// public class name:   IOWriteMAHNBDepositWork
    /// <summary>
    ///                      ��������f�[�^(IOWriteMAHNBDeposit)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��������f�[�^(IOWriteMAHNBDeposit)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMAHNBDepositWork : IFileHeader
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

        /// <summary>�ۃR�[�h</summary>
        private Int32 _minSectionCode;

        /// <summary>�������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

        /// <summary>�v����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>��������R�[�h</summary>
        private Int32 _depositKindCode;

        /// <summary>�������햼��</summary>
        private string _depositKindName = "";

        /// <summary>��������敪</summary>
        private Int32 _depositKindDivCd;

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

        /// <summary>�a����敪</summary>
        /// <remarks>0:�ʏ����,1:�a�������</remarks>
        private Int32 _depositCd;

        /// <summary>��`�U�o��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>��`�x������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftPayTimeLimit;

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

        /// <summary>�d�c�h���M��</summary>
        private DateTime _ediSendDate;

        /// <summary>�d�c�h�捞��</summary>
        private DateTime _ediTakeInDate;


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

        /// public propaty name  :  EdiSendDate
        /// <summary>�d�c�h���M���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�c�h���M���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime EdiSendDate
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
        public DateTime EdiTakeInDate
        {
            get { return _ediTakeInDate; }
            set { _ediTakeInDate = value; }
        }


        /// <summary>
        /// ��������f�[�^(IOWriteMAHNBDeposit)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>IOWriteMAHNBDepositWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMAHNBDepositWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public IOWriteMAHNBDepositWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>IOWriteMAHNBDepositWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   IOWriteMAHNBDepositWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class IOWriteMAHNBDepositWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMAHNBDepositWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMAHNBDepositWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMAHNBDepositWork || graph is ArrayList || graph is IOWriteMAHNBDepositWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(IOWriteMAHNBDepositWork).FullName));

            if (graph != null && graph is IOWriteMAHNBDepositWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMAHNBDepositWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMAHNBDepositWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMAHNBDepositWork[])graph).Length;
            }
            else if (graph is IOWriteMAHNBDepositWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //�����ԍ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDebitNoteCd
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositSlipNo
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //�������͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InputDepositSecCd
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�X�V���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //�ۃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDate
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //��������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositKindCode
            //�������햼��
            serInfo.MemberInfo.Add(typeof(string)); //DepositKindName
            //��������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositKindDivCd
            //�����v
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositTotal
            //�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit
            //�萔�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //FeeDeposit
            //�l�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountDeposit
            //���������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoDepositCd
            //�a����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositCd
            //��`�U�o��
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
            //��`�x������
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftPayTimeLimit
            //��`���
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftKind
            //��`��ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //DraftKindName
            //��`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
            //��`�敪����
            serInfo.MemberInfo.Add(typeof(string)); //DraftDivideName
            //��`�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //DraftNo
            //���������z
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAllowance
            //���������c��
            serInfo.MemberInfo.Add(typeof(Int64)); //DepositAlwcBlnce
            //�ԍ������A���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkDepoNo
            //�ŏI�������݌v���
            serInfo.MemberInfo.Add(typeof(Int32)); //LastReconcileAddUpDt
            //�����S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DepositAgentCode
            //�����S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //DepositAgentNm
            //�������͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //DepositInputAgentCd
            //�������͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //DepositInputAgentNm
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //�����於��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName
            //�����於��2
            serInfo.MemberInfo.Add(typeof(string)); //ClaimName2
            //�����旪��
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSnm
            //�`�[�E�v
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //��s�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //��s����
            serInfo.MemberInfo.Add(typeof(string)); //BankName
            //�d�c�h���M��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiSendDate
            //�d�c�h�捞��
            serInfo.MemberInfo.Add(typeof(Int32)); //EdiTakeInDate


            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteMAHNBDepositWork)
            {
                IOWriteMAHNBDepositWork temp = (IOWriteMAHNBDepositWork)graph;

                SetIOWriteMAHNBDepositWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMAHNBDepositWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMAHNBDepositWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMAHNBDepositWork temp in lst)
                {
                    SetIOWriteMAHNBDepositWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMAHNBDepositWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 56;

        /// <summary>
        ///  IOWriteMAHNBDepositWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMAHNBDepositWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetIOWriteMAHNBDepositWork(System.IO.BinaryWriter writer, IOWriteMAHNBDepositWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //�����ԍ��敪
            writer.Write(temp.DepositDebitNoteCd);
            //�����`�[�ԍ�
            writer.Write(temp.DepositSlipNo);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //�������͋��_�R�[�h
            writer.Write(temp.InputDepositSecCd);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�X�V���_�R�[�h
            writer.Write(temp.UpdateSecCd);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //�ۃR�[�h
            writer.Write(temp.MinSectionCode);
            //�������t
            writer.Write((Int64)temp.DepositDate.Ticks);
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //��������R�[�h
            writer.Write(temp.DepositKindCode);
            //�������햼��
            writer.Write(temp.DepositKindName);
            //��������敪
            writer.Write(temp.DepositKindDivCd);
            //�����v
            writer.Write(temp.DepositTotal);
            //�������z
            writer.Write(temp.Deposit);
            //�萔�������z
            writer.Write(temp.FeeDeposit);
            //�l�������z
            writer.Write(temp.DiscountDeposit);
            //���������敪
            writer.Write(temp.AutoDepositCd);
            //�a����敪
            writer.Write(temp.DepositCd);
            //��`�U�o��
            writer.Write((Int64)temp.DraftDrawingDate.Ticks);
            //��`�x������
            writer.Write((Int64)temp.DraftPayTimeLimit.Ticks);
            //��`���
            writer.Write(temp.DraftKind);
            //��`��ޖ���
            writer.Write(temp.DraftKindName);
            //��`�敪
            writer.Write(temp.DraftDivide);
            //��`�敪����
            writer.Write(temp.DraftDivideName);
            //��`�ԍ�
            writer.Write(temp.DraftNo);
            //���������z
            writer.Write(temp.DepositAllowance);
            //���������c��
            writer.Write(temp.DepositAlwcBlnce);
            //�ԍ������A���ԍ�
            writer.Write(temp.DebitNoteLinkDepoNo);
            //�ŏI�������݌v���
            writer.Write((Int64)temp.LastReconcileAddUpDt.Ticks);
            //�����S���҃R�[�h
            writer.Write(temp.DepositAgentCode);
            //�����S���Җ���
            writer.Write(temp.DepositAgentNm);
            //�������͎҃R�[�h
            writer.Write(temp.DepositInputAgentCd);
            //�������͎Җ���
            writer.Write(temp.DepositInputAgentNm);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //������R�[�h
            writer.Write(temp.ClaimCode);
            //�����於��
            writer.Write(temp.ClaimName);
            //�����於��2
            writer.Write(temp.ClaimName2);
            //�����旪��
            writer.Write(temp.ClaimSnm);
            //�`�[�E�v
            writer.Write(temp.Outline);
            //��s�R�[�h
            writer.Write(temp.BankCode);
            //��s����
            writer.Write(temp.BankName);
            //�d�c�h���M��
            writer.Write((Int64)temp.EdiSendDate.Ticks);
            //�d�c�h�捞��
            writer.Write((Int64)temp.EdiTakeInDate.Ticks);

        }

        /// <summary>
        ///  IOWriteMAHNBDepositWork�C���X�^���X�擾
        /// </summary>
        /// <returns>IOWriteMAHNBDepositWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMAHNBDepositWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private IOWriteMAHNBDepositWork GetIOWriteMAHNBDepositWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            IOWriteMAHNBDepositWork temp = new IOWriteMAHNBDepositWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //�����ԍ��敪
            temp.DepositDebitNoteCd = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.DepositSlipNo = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //�������͋��_�R�[�h
            temp.InputDepositSecCd = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�X�V���_�R�[�h
            temp.UpdateSecCd = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //�ۃR�[�h
            temp.MinSectionCode = reader.ReadInt32();
            //�������t
            temp.DepositDate = new DateTime(reader.ReadInt64());
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //��������R�[�h
            temp.DepositKindCode = reader.ReadInt32();
            //�������햼��
            temp.DepositKindName = reader.ReadString();
            //��������敪
            temp.DepositKindDivCd = reader.ReadInt32();
            //�����v
            temp.DepositTotal = reader.ReadInt64();
            //�������z
            temp.Deposit = reader.ReadInt64();
            //�萔�������z
            temp.FeeDeposit = reader.ReadInt64();
            //�l�������z
            temp.DiscountDeposit = reader.ReadInt64();
            //���������敪
            temp.AutoDepositCd = reader.ReadInt32();
            //�a����敪
            temp.DepositCd = reader.ReadInt32();
            //��`�U�o��
            temp.DraftDrawingDate = new DateTime(reader.ReadInt64());
            //��`�x������
            temp.DraftPayTimeLimit = new DateTime(reader.ReadInt64());
            //��`���
            temp.DraftKind = reader.ReadInt32();
            //��`��ޖ���
            temp.DraftKindName = reader.ReadString();
            //��`�敪
            temp.DraftDivide = reader.ReadInt32();
            //��`�敪����
            temp.DraftDivideName = reader.ReadString();
            //��`�ԍ�
            temp.DraftNo = reader.ReadString();
            //���������z
            temp.DepositAllowance = reader.ReadInt64();
            //���������c��
            temp.DepositAlwcBlnce = reader.ReadInt64();
            //�ԍ������A���ԍ�
            temp.DebitNoteLinkDepoNo = reader.ReadInt32();
            //�ŏI�������݌v���
            temp.LastReconcileAddUpDt = new DateTime(reader.ReadInt64());
            //�����S���҃R�[�h
            temp.DepositAgentCode = reader.ReadString();
            //�����S���Җ���
            temp.DepositAgentNm = reader.ReadString();
            //�������͎҃R�[�h
            temp.DepositInputAgentCd = reader.ReadString();
            //�������͎Җ���
            temp.DepositInputAgentNm = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //������R�[�h
            temp.ClaimCode = reader.ReadInt32();
            //�����於��
            temp.ClaimName = reader.ReadString();
            //�����於��2
            temp.ClaimName2 = reader.ReadString();
            //�����旪��
            temp.ClaimSnm = reader.ReadString();
            //�`�[�E�v
            temp.Outline = reader.ReadString();
            //��s�R�[�h
            temp.BankCode = reader.ReadInt32();
            //��s����
            temp.BankName = reader.ReadString();
            //�d�c�h���M��
            temp.EdiSendDate = new DateTime(reader.ReadInt64());
            //�d�c�h�捞��
            temp.EdiTakeInDate = new DateTime(reader.ReadInt64());


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>IOWriteMAHNBDepositWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMAHNBDepositWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMAHNBDepositWork temp = GetIOWriteMAHNBDepositWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (IOWriteMAHNBDepositWork[])lst.ToArray(typeof(IOWriteMAHNBDepositWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    */
}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region --- DEL 2008/08/25 M.Kubota --->>>
    # if false
    /// public class name:   IOWriteMASIRPaymentWork
    /// <summary>
    ///                      �d���x���f�[�^���[�N(IOWriteMASIRPayment)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���x���f�[�^���[�N(IOWriteMASIRPayment)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/01/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMASIRPaymentWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�x���`�[�ԍ�</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _paymentSlipNo;

        /// <summary>�d���`��</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _customerSnm = "";

        /// <summary>�x����R�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _payeeName = "";

        /// <summary>�x���於��2</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _payeeSnm = "";

        /// <summary>�x�����͋��_�R�[�h</summary>
        /// <remarks>�d�����_�R�[�h���Z�b�g</remarks>
        private string _paymentInpSectionCd = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�d���v�㋒�_�R�[�h���Z�b�g</remarks>
        private string _addUpSecCode = "";

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>���_�R�[�h���Z�b�g</remarks>
        private string _updateSecCd = "";

        /// <summary>����R�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _subSectionCode;

        /// <summary>�ۃR�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _minSectionCode;

        /// <summary>�x�����t</summary>
        /// <remarks>�d�������Z�b�g</remarks>
        private DateTime _paymentDate;

        /// <summary>�v����t</summary>
        /// <remarks>�d���v����t���Z�b�g</remarks>
        private DateTime _addUpADate;

        /// <summary>�x������R�[�h</summary>
        /// <remarks>UI���Őݒ�</remarks>
        private Int32 _paymentMoneyKindCode;

        /// <summary>�x�����햼��</summary>
        /// <remarks>UI���Őݒ�</remarks>
        private string _paymentMoneyKindName = "";

        /// <summary>�x������敪</summary>
        /// <remarks>UI���Őݒ�</remarks>
        private Int32 _paymentMoneyKindDiv;

        /// <summary>�x���v</summary>
        /// <remarks>�d�����z���v���Z�b�g</remarks>
        private Int64 _paymentTotal;

        /// <summary>�x�����z</summary>
        /// <remarks>�d�����z���v���Z�b�g</remarks>
        private Int64 _payment;

        /// <summary>�萔���x���z</summary>
        /// <remarks>���ݒ�</remarks>
        private Int64 _feePayment;

        /// <summary>�l���x���z</summary>
        /// <remarks>���ݒ�</remarks>
        private Int64 _discountPayment;

        /// <summary>���x�[�g�x���z</summary>
        /// <remarks>���ݒ�</remarks>
        private Int64 _rebatePayment;

        /// <summary>�����x���敪</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _autoPayment;

        /// <summary>�N���W�b�g�^���[���敪</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _creditOrLoanCd;

        /// <summary>�N���W�b�g��ЃR�[�h</summary>
        /// <remarks>���ݒ�</remarks>
        private string _creditCompanyCode = "";

        /// <summary>��`�U�o��</summary>
        /// <remarks>���ݒ�</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>��`�x������</summary>
        /// <remarks>���ݒ�</remarks>
        private DateTime _draftPayTimeLimit;

        /// <summary>��`���</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _draftKind;

        /// <summary>��`��ޖ���</summary>
        /// <remarks>���ݒ�</remarks>
        private string _draftKindName = "";

        /// <summary>��`�敪</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _draftDivide;

        /// <summary>��`�敪����</summary>
        /// <remarks>���ݒ�</remarks>
        private string _draftDivideName = "";

        /// <summary>��`�ԍ�</summary>
        /// <remarks>���ݒ�</remarks>
        private string _draftNo = "";

        /// <summary>�ԍ��x���A���ԍ�</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _debitNoteLinkPayNo;

        /// <summary>�x���S���҃R�[�h</summary>
        /// <remarks>�d���S���҃R�[�h���Z�b�g</remarks>
        private string _paymentAgentCode = "";

        /// <summary>�x���S���Җ���</summary>
        /// <remarks>�d���S���Җ��̂��Z�b�g</remarks>
        private string _paymentAgentName = "";

        /// <summary>�x�����͎҃R�[�h</summary>
        /// <remarks>�d�����͎҃R�[�h���Z�b�g</remarks>
        private string _paymentInputAgentCd = "";

        /// <summary>�x�����͎Җ���</summary>
        /// <remarks>�d�����͎Җ��̂��Z�b�g</remarks>
        private string _paymentInputAgentNm = "";

        /// <summary>�`�[�E�v</summary>
        /// <remarks>�d���`�[�ԍ����Z�b�g</remarks>
        private string _outline = "";

        /// <summary>��s�R�[�h</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _bankCode;

        /// <summary>��s����</summary>
        /// <remarks>���ݒ�</remarks>
        private string _bankName = "";

        /// <summary>�d�c�h���M��</summary>
        /// <remarks>���ݒ�</remarks>
        private DateTime _ediSendDate;

        /// <summary>�d�c�h�捞��</summary>
        /// <remarks>���ݒ�</remarks>
        private DateTime _ediTakeInDate;


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>�x���`�[�ԍ��v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
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
        /// <value>�d���f�[�^���</value>
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
        /// <value>�d���f�[�^���</value>
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
        /// <value>�d���f�[�^���</value>
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

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於��2�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  PaymentInpSectionCd
        /// <summary>�x�����͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�d�����_�R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInpSectionCd
        {
            get { return _paymentInpSectionCd; }
            set { _paymentInpSectionCd = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�d���v�㋒�_�R�[�h���Z�b�g</value>
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
        /// <value>���_�R�[�h���Z�b�g</value>
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
        /// <value>�d���f�[�^���</value>
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
        /// <value>�d���f�[�^���</value>
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

        /// public propaty name  :  PaymentDate
        /// <summary>�x�����t�v���p�e�B</summary>
        /// <value>�d�������Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>�d���v����t���Z�b�g</value>
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

        /// public propaty name  :  PaymentMoneyKindCode
        /// <summary>�x������R�[�h�v���p�e�B</summary>
        /// <value>UI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentMoneyKindCode
        {
            get { return _paymentMoneyKindCode; }
            set { _paymentMoneyKindCode = value; }
        }

        /// public propaty name  :  PaymentMoneyKindName
        /// <summary>�x�����햼�̃v���p�e�B</summary>
        /// <value>UI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentMoneyKindName
        {
            get { return _paymentMoneyKindName; }
            set { _paymentMoneyKindName = value; }
        }

        /// public propaty name  :  PaymentMoneyKindDiv
        /// <summary>�x������敪�v���p�e�B</summary>
        /// <value>UI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentMoneyKindDiv
        {
            get { return _paymentMoneyKindDiv; }
            set { _paymentMoneyKindDiv = value; }
        }

        /// public propaty name  :  PaymentTotal
        /// <summary>�x���v�v���p�e�B</summary>
        /// <value>�d�����z���v���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PaymentTotal
        {
            get { return _paymentTotal; }
            set { _paymentTotal = value; }
        }

        /// public propaty name  :  Payment
        /// <summary>�x�����z�v���p�e�B</summary>
        /// <value>�d�����z���v���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        /// public propaty name  :  FeePayment
        /// <summary>�萔���x���z�v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔���x���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>�l���x���z�v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���x���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }

        /// public propaty name  :  RebatePayment
        /// <summary>���x�[�g�x���z�v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���x�[�g�x���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 RebatePayment
        {
            get { return _rebatePayment; }
            set { _rebatePayment = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>�����x���敪�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  CreditOrLoanCd
        /// <summary>�N���W�b�g�^���[���敪�v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���W�b�g�^���[���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CreditOrLoanCd
        {
            get { return _creditOrLoanCd; }
            set { _creditOrLoanCd = value; }
        }

        /// public propaty name  :  CreditCompanyCode
        /// <summary>�N���W�b�g��ЃR�[�h�v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N���W�b�g��ЃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreditCompanyCode
        {
            get { return _creditCompanyCode; }
            set { _creditCompanyCode = value; }
        }

        /// public propaty name  :  DraftDrawingDate
        /// <summary>��`�U�o���v���p�e�B</summary>
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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

        /// public propaty name  :  DebitNoteLinkPayNo
        /// <summary>�ԍ��x���A���ԍ��v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��x���A���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteLinkPayNo
        {
            get { return _debitNoteLinkPayNo; }
            set { _debitNoteLinkPayNo = value; }
        }

        /// public propaty name  :  PaymentAgentCode
        /// <summary>�x���S���҃R�[�h�v���p�e�B</summary>
        /// <value>�d���S���҃R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentAgentCode
        {
            get { return _paymentAgentCode; }
            set { _paymentAgentCode = value; }
        }

        /// public propaty name  :  PaymentAgentName
        /// <summary>�x���S���Җ��̃v���p�e�B</summary>
        /// <value>�d���S���Җ��̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentAgentName
        {
            get { return _paymentAgentName; }
            set { _paymentAgentName = value; }
        }

        /// public propaty name  :  PaymentInputAgentCd
        /// <summary>�x�����͎҃R�[�h�v���p�e�B</summary>
        /// <value>�d�����͎҃R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInputAgentCd
        {
            get { return _paymentInputAgentCd; }
            set { _paymentInputAgentCd = value; }
        }

        /// public propaty name  :  PaymentInputAgentNm
        /// <summary>�x�����͎Җ��̃v���p�e�B</summary>
        /// <value>�d�����͎Җ��̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInputAgentNm
        {
            get { return _paymentInputAgentNm; }
            set { _paymentInputAgentNm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// <value>�d���`�[�ԍ����Z�b�g</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// �d���x���f�[�^���[�N(IOWriteMASIRPayment)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public IOWriteMASIRPaymentWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>IOWriteMASIRPaymentWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class IOWriteMASIRPaymentWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
    #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMASIRPaymentWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMASIRPaymentWork || graph is ArrayList || graph is IOWriteMASIRPaymentWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(IOWriteMASIRPaymentWork).FullName));

            if (graph != null && graph is IOWriteMASIRPaymentWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRPaymentWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMASIRPaymentWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMASIRPaymentWork[])graph).Length;
            }
            else if (graph is IOWriteMASIRPaymentWork)
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
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�x���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSlipNo
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���於��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //�x���於��2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�x�����͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInpSectionCd
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�X�V���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //�ۃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //�x�����t
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //�x������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMoneyKindCode
            //�x�����햼��
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMoneyKindName
            //�x������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMoneyKindDiv
            //�x���v
            serInfo.MemberInfo.Add(typeof(Int64)); //PaymentTotal
            //�x�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment
            //�萔���x���z
            serInfo.MemberInfo.Add(typeof(Int64)); //FeePayment
            //�l���x���z
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPayment
            //���x�[�g�x���z
            serInfo.MemberInfo.Add(typeof(Int64)); //RebatePayment
            //�����x���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
            //�N���W�b�g�^���[���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CreditOrLoanCd
            //�N���W�b�g��ЃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CreditCompanyCode
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
            //�ԍ��x���A���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkPayNo
            //�x���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentCode
            //�x���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentName
            //�x�����͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentCd
            //�x�����͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentNm
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
            if (graph is IOWriteMASIRPaymentWork)
            {
                IOWriteMASIRPaymentWork temp = (IOWriteMASIRPaymentWork)graph;

                SetIOWriteMASIRPaymentWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMASIRPaymentWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMASIRPaymentWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMASIRPaymentWork temp in lst)
                {
                    SetIOWriteMASIRPaymentWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMASIRPaymentWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 55;

        /// <summary>
        ///  IOWriteMASIRPaymentWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetIOWriteMASIRPaymentWork(System.IO.BinaryWriter writer, IOWriteMASIRPaymentWork temp)
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
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�x���`�[�ԍ�
            writer.Write(temp.PaymentSlipNo);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���於��
            writer.Write(temp.PayeeName);
            //�x���於��2
            writer.Write(temp.PayeeName2);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�x�����͋��_�R�[�h
            writer.Write(temp.PaymentInpSectionCd);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�X�V���_�R�[�h
            writer.Write(temp.UpdateSecCd);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //�ۃR�[�h
            writer.Write(temp.MinSectionCode);
            //�x�����t
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //�x������R�[�h
            writer.Write(temp.PaymentMoneyKindCode);
            //�x�����햼��
            writer.Write(temp.PaymentMoneyKindName);
            //�x������敪
            writer.Write(temp.PaymentMoneyKindDiv);
            //�x���v
            writer.Write(temp.PaymentTotal);
            //�x�����z
            writer.Write(temp.Payment);
            //�萔���x���z
            writer.Write(temp.FeePayment);
            //�l���x���z
            writer.Write(temp.DiscountPayment);
            //���x�[�g�x���z
            writer.Write(temp.RebatePayment);
            //�����x���敪
            writer.Write(temp.AutoPayment);
            //�N���W�b�g�^���[���敪
            writer.Write(temp.CreditOrLoanCd);
            //�N���W�b�g��ЃR�[�h
            writer.Write(temp.CreditCompanyCode);
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
            //�ԍ��x���A���ԍ�
            writer.Write(temp.DebitNoteLinkPayNo);
            //�x���S���҃R�[�h
            writer.Write(temp.PaymentAgentCode);
            //�x���S���Җ���
            writer.Write(temp.PaymentAgentName);
            //�x�����͎҃R�[�h
            writer.Write(temp.PaymentInputAgentCd);
            //�x�����͎Җ���
            writer.Write(temp.PaymentInputAgentNm);
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
        ///  IOWriteMASIRPaymentWork�C���X�^���X�擾
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private IOWriteMASIRPaymentWork GetIOWriteMASIRPaymentWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            IOWriteMASIRPaymentWork temp = new IOWriteMASIRPaymentWork();

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
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�x���`�[�ԍ�
            temp.PaymentSlipNo = reader.ReadInt32();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���於��
            temp.PayeeName = reader.ReadString();
            //�x���於��2
            temp.PayeeName2 = reader.ReadString();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�x�����͋��_�R�[�h
            temp.PaymentInpSectionCd = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�X�V���_�R�[�h
            temp.UpdateSecCd = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //�ۃR�[�h
            temp.MinSectionCode = reader.ReadInt32();
            //�x�����t
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //�x������R�[�h
            temp.PaymentMoneyKindCode = reader.ReadInt32();
            //�x�����햼��
            temp.PaymentMoneyKindName = reader.ReadString();
            //�x������敪
            temp.PaymentMoneyKindDiv = reader.ReadInt32();
            //�x���v
            temp.PaymentTotal = reader.ReadInt64();
            //�x�����z
            temp.Payment = reader.ReadInt64();
            //�萔���x���z
            temp.FeePayment = reader.ReadInt64();
            //�l���x���z
            temp.DiscountPayment = reader.ReadInt64();
            //���x�[�g�x���z
            temp.RebatePayment = reader.ReadInt64();
            //�����x���敪
            temp.AutoPayment = reader.ReadInt32();
            //�N���W�b�g�^���[���敪
            temp.CreditOrLoanCd = reader.ReadInt32();
            //�N���W�b�g��ЃR�[�h
            temp.CreditCompanyCode = reader.ReadString();
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
            //�ԍ��x���A���ԍ�
            temp.DebitNoteLinkPayNo = reader.ReadInt32();
            //�x���S���҃R�[�h
            temp.PaymentAgentCode = reader.ReadString();
            //�x���S���Җ���
            temp.PaymentAgentName = reader.ReadString();
            //�x�����͎҃R�[�h
            temp.PaymentInputAgentCd = reader.ReadString();
            //�x�����͎Җ���
            temp.PaymentInputAgentNm = reader.ReadString();
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
        /// <returns>IOWriteMASIRPaymentWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMASIRPaymentWork temp = GetIOWriteMASIRPaymentWork(reader, serInfo);
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
                    retValue = (IOWriteMASIRPaymentWork[])lst.ToArray(typeof(IOWriteMASIRPaymentWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
# endif
    # endregion --- DEL 2008/08/25 M.Kubota ---<<<

    /// public class name:   IOWriteMASIRPaymentWork
    /// <summary>
    ///                      �d���x���f�[�^���[�N(IOWriteMASIRPayment)���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���x���f�[�^���[�N(IOWriteMASIRPayment)���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/08/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/08/26  �v�ۓc</br>
    /// <br>                 :   �d����R�[�h �ǉ�</br>
    /// <br>                 :   �d���於�P�E�Q�E���� �ǉ�</br>
    /// <br>                 :   ���x�[�g�x���z �폜</br>
    /// <br>                 :   �N���W�b�g�^���[���敪�E�N���W�b�g��ЃR�[�h �폜</br>
    /// <br>                 :   ��`�x������ </br>
    /// <br>                 :   �d�c�h���M���E�d�c�h�捞�� �폜</br>
    /// <br>                 :   ���Ӑ�R�[�h �폜</br>
    /// <br>                 :   ���Ӑ於�́E���̂Q�E���� �폜</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class IOWriteMASIRPaymentWork : IFileHeader
    {
        /// <summary>�쐬����</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>�����[�g���Őݒ�</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�x���`�[�ԍ�</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _paymentSlipNo;

        /// <summary>�d���`��</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>�x����R�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        /// <remarks>UI���Őݒ�</remarks>
        private string _payeeName = "";

        /// <summary>�x���於��2</summary>
        /// <remarks>UI���Őݒ�</remarks>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _payeeSnm = "";

        /// <summary>�d����R�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _supplierNm2 = "";

        /// <summary>�d���旪��</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private string _supplierSnm = "";

        /// <summary>�x�����͋��_�R�[�h</summary>
        /// <remarks>�d�����_�R�[�h���Z�b�g</remarks>
        private string _paymentInpSectionCd = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�d���v�㋒�_�R�[�h���Z�b�g</remarks>
        private string _addUpSecCode = "";

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>���_�R�[�h���Z�b�g</remarks>
        private string _updateSecCd = "";

        /// <summary>����R�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _subSectionCode;

        /// <summary>�ۃR�[�h</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _minSectionCode;

        /// <summary>�x�����t</summary>
        /// <remarks>�d�������Z�b�g</remarks>
        private DateTime _paymentDate;

        /// <summary>�v����t</summary>
        /// <remarks>�d���v����t���Z�b�g</remarks>
        private DateTime _addUpADate;

        /// <summary>�x������R�[�h</summary>
        /// <remarks>UI���Őݒ�</remarks>
        private Int32 _paymentMoneyKindCode;

        /// <summary>�x�����햼��</summary>
        /// <remarks>UI���Őݒ�</remarks>
        private string _paymentMoneyKindName = "";

        /// <summary>�x������敪</summary>
        /// <remarks>UI���Őݒ�</remarks>
        private Int32 _paymentMoneyKindDiv;

        /// <summary>�x���v</summary>
        /// <remarks>�d�����z���v���Z�b�g</remarks>
        private Int64 _paymentTotal;

        /// <summary>�x�����z</summary>
        /// <remarks>�d�����z���v���Z�b�g</remarks>
        private Int64 _payment;

        /// <summary>�萔���x���z</summary>
        /// <remarks>���ݒ�</remarks>
        private Int64 _feePayment;

        /// <summary>�l���x���z</summary>
        /// <remarks>���ݒ�</remarks>
        private Int64 _discountPayment;

        /// <summary>�����x���敪</summary>
        /// <remarks>�d���f�[�^���</remarks>
        private Int32 _autoPayment;

        /// <summary>��`�U�o��</summary>
        /// <remarks>���ݒ�</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>��`���</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _draftKind;

        /// <summary>��`��ޖ���</summary>
        /// <remarks>���ݒ�</remarks>
        private string _draftKindName = "";

        /// <summary>��`�敪</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _draftDivide;

        /// <summary>��`�敪����</summary>
        /// <remarks>���ݒ�</remarks>
        private string _draftDivideName = "";

        /// <summary>��`�ԍ�</summary>
        /// <remarks>���ݒ�</remarks>
        private string _draftNo = "";

        /// <summary>�ԍ��x���A���ԍ�</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _debitNoteLinkPayNo;

        /// <summary>�x���S���҃R�[�h</summary>
        /// <remarks>�d���S���҃R�[�h���Z�b�g</remarks>
        private string _paymentAgentCode = "";

        /// <summary>�x���S���Җ���</summary>
        /// <remarks>�d���S���Җ��̂��Z�b�g</remarks>
        private string _paymentAgentName = "";

        /// <summary>�x�����͎҃R�[�h</summary>
        /// <remarks>�d�����͎҃R�[�h���Z�b�g</remarks>
        private string _paymentInputAgentCd = "";

        /// <summary>�x�����͎Җ���</summary>
        /// <remarks>�d�����͎Җ��̂��Z�b�g</remarks>
        private string _paymentInputAgentNm = "";

        /// <summary>�`�[�E�v</summary>
        /// <remarks>�d���`�[�ԍ����Z�b�g</remarks>
        private string _outline = "";

        /// <summary>��s�R�[�h</summary>
        /// <remarks>���ݒ�</remarks>
        private Int32 _bankCode;

        /// <summary>��s����</summary>
        /// <remarks>���ݒ�</remarks>
        private string _bankName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�d���f�[�^���</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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
        /// <value>�����[�g���Őݒ�</value>
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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>�x���`�[�ԍ��v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
        }

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// <value>UI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於��2�v���p�e�B</summary>
        /// <value>UI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於1�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>�d���於2�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  PaymentInpSectionCd
        /// <summary>�x�����͋��_�R�[�h�v���p�e�B</summary>
        /// <value>�d�����_�R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInpSectionCd
        {
            get { return _paymentInpSectionCd; }
            set { _paymentInpSectionCd = value; }
        }

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�d���v�㋒�_�R�[�h���Z�b�g</value>
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
        /// <value>���_�R�[�h���Z�b�g</value>
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
        /// <value>�d���f�[�^���</value>
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
        /// <value>�d���f�[�^���</value>
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

        /// public propaty name  :  PaymentDate
        /// <summary>�x�����t�v���p�e�B</summary>
        /// <value>�d�������Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }

        /// public propaty name  :  AddUpADate
        /// <summary>�v����t�v���p�e�B</summary>
        /// <value>�d���v����t���Z�b�g</value>
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

        /// public propaty name  :  PaymentMoneyKindCode
        /// <summary>�x������R�[�h�v���p�e�B</summary>
        /// <value>UI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentMoneyKindCode
        {
            get { return _paymentMoneyKindCode; }
            set { _paymentMoneyKindCode = value; }
        }

        /// public propaty name  :  PaymentMoneyKindName
        /// <summary>�x�����햼�̃v���p�e�B</summary>
        /// <value>UI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentMoneyKindName
        {
            get { return _paymentMoneyKindName; }
            set { _paymentMoneyKindName = value; }
        }

        /// public propaty name  :  PaymentMoneyKindDiv
        /// <summary>�x������敪�v���p�e�B</summary>
        /// <value>UI���Őݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentMoneyKindDiv
        {
            get { return _paymentMoneyKindDiv; }
            set { _paymentMoneyKindDiv = value; }
        }

        /// public propaty name  :  PaymentTotal
        /// <summary>�x���v�v���p�e�B</summary>
        /// <value>�d�����z���v���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PaymentTotal
        {
            get { return _paymentTotal; }
            set { _paymentTotal = value; }
        }

        /// public propaty name  :  Payment
        /// <summary>�x�����z�v���p�e�B</summary>
        /// <value>�d�����z���v���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        /// public propaty name  :  FeePayment
        /// <summary>�萔���x���z�v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �萔���x���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 FeePayment
        {
            get { return _feePayment; }
            set { _feePayment = value; }
        }

        /// public propaty name  :  DiscountPayment
        /// <summary>�l���x���z�v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l���x���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DiscountPayment
        {
            get { return _discountPayment; }
            set { _discountPayment = value; }
        }

        /// public propaty name  :  AutoPayment
        /// <summary>�����x���敪�v���p�e�B</summary>
        /// <value>�d���f�[�^���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����x���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoPayment
        {
            get { return _autoPayment; }
            set { _autoPayment = value; }
        }

        /// public propaty name  :  DraftDrawingDate
        /// <summary>��`�U�o���v���p�e�B</summary>
        /// <value>���ݒ�</value>
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

        /// public propaty name  :  DraftKind
        /// <summary>��`��ރv���p�e�B</summary>
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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

        /// public propaty name  :  DebitNoteLinkPayNo
        /// <summary>�ԍ��x���A���ԍ��v���p�e�B</summary>
        /// <value>���ݒ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԍ��x���A���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteLinkPayNo
        {
            get { return _debitNoteLinkPayNo; }
            set { _debitNoteLinkPayNo = value; }
        }

        /// public propaty name  :  PaymentAgentCode
        /// <summary>�x���S���҃R�[�h�v���p�e�B</summary>
        /// <value>�d���S���҃R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentAgentCode
        {
            get { return _paymentAgentCode; }
            set { _paymentAgentCode = value; }
        }

        /// public propaty name  :  PaymentAgentName
        /// <summary>�x���S���Җ��̃v���p�e�B</summary>
        /// <value>�d���S���Җ��̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentAgentName
        {
            get { return _paymentAgentName; }
            set { _paymentAgentName = value; }
        }

        /// public propaty name  :  PaymentInputAgentCd
        /// <summary>�x�����͎҃R�[�h�v���p�e�B</summary>
        /// <value>�d�����͎҃R�[�h���Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInputAgentCd
        {
            get { return _paymentInputAgentCd; }
            set { _paymentInputAgentCd = value; }
        }

        /// public propaty name  :  PaymentInputAgentNm
        /// <summary>�x�����͎Җ��̃v���p�e�B</summary>
        /// <value>�d�����͎Җ��̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentInputAgentNm
        {
            get { return _paymentInputAgentNm; }
            set { _paymentInputAgentNm = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>�`�[�E�v�v���p�e�B</summary>
        /// <value>�d���`�[�ԍ����Z�b�g</value>
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
        /// <value>���ݒ�</value>
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
        /// <value>���ݒ�</value>
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


        /// <summary>
        /// �d���x���f�[�^���[�N(IOWriteMASIRPayment)���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public IOWriteMASIRPaymentWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>IOWriteMASIRPaymentWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class IOWriteMASIRPaymentWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  IOWriteMASIRPaymentWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is IOWriteMASIRPaymentWork || graph is ArrayList || graph is IOWriteMASIRPaymentWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(IOWriteMASIRPaymentWork).FullName));

            if (graph != null && graph is IOWriteMASIRPaymentWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.IOWriteMASIRPaymentWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is IOWriteMASIRPaymentWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((IOWriteMASIRPaymentWork[])graph).Length;
            }
            else if (graph is IOWriteMASIRPaymentWork)
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
            //�ԓ`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteDiv
            //�x���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSlipNo
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�d���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�x���於��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //�x���於��2
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�x�����͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInpSectionCd
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�X�V���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdateSecCd
            //����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //�ۃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MinSectionCode
            //�x�����t
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate
            //�v����t
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpADate
            //�x������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMoneyKindCode
            //�x�����햼��
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMoneyKindName
            //�x������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMoneyKindDiv
            //�x���v
            serInfo.MemberInfo.Add(typeof(Int64)); //PaymentTotal
            //�x�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment
            //�萔���x���z
            serInfo.MemberInfo.Add(typeof(Int64)); //FeePayment
            //�l���x���z
            serInfo.MemberInfo.Add(typeof(Int64)); //DiscountPayment
            //�����x���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoPayment
            //��`�U�o��
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
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
            //�ԍ��x���A���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DebitNoteLinkPayNo
            //�x���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentCode
            //�x���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //PaymentAgentName
            //�x�����͎҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentCd
            //�x�����͎Җ���
            serInfo.MemberInfo.Add(typeof(string)); //PaymentInputAgentNm
            //�`�[�E�v
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //��s�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BankCode
            //��s����
            serInfo.MemberInfo.Add(typeof(string)); //BankName


            serInfo.Serialize(writer, serInfo);
            if (graph is IOWriteMASIRPaymentWork)
            {
                IOWriteMASIRPaymentWork temp = (IOWriteMASIRPaymentWork)graph;

                SetIOWriteMASIRPaymentWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is IOWriteMASIRPaymentWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((IOWriteMASIRPaymentWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (IOWriteMASIRPaymentWork temp in lst)
                {
                    SetIOWriteMASIRPaymentWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// IOWriteMASIRPaymentWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 49;

        /// <summary>
        ///  IOWriteMASIRPaymentWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetIOWriteMASIRPaymentWork(System.IO.BinaryWriter writer, IOWriteMASIRPaymentWork temp)
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
            //�ԓ`�敪
            writer.Write(temp.DebitNoteDiv);
            //�x���`�[�ԍ�
            writer.Write(temp.PaymentSlipNo);
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�d���`�[�ԍ�
            writer.Write(temp.SupplierSlipNo);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�x���於��
            writer.Write(temp.PayeeName);
            //�x���於��2
            writer.Write(temp.PayeeName2);
            //�x���旪��
            writer.Write(temp.PayeeSnm);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於1
            writer.Write(temp.SupplierNm1);
            //�d���於2
            writer.Write(temp.SupplierNm2);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�x�����͋��_�R�[�h
            writer.Write(temp.PaymentInpSectionCd);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�X�V���_�R�[�h
            writer.Write(temp.UpdateSecCd);
            //����R�[�h
            writer.Write(temp.SubSectionCode);
            //�ۃR�[�h
            writer.Write(temp.MinSectionCode);
            //�x�����t
            writer.Write((Int64)temp.PaymentDate.Ticks);
            //�v����t
            writer.Write((Int64)temp.AddUpADate.Ticks);
            //�x������R�[�h
            writer.Write(temp.PaymentMoneyKindCode);
            //�x�����햼��
            writer.Write(temp.PaymentMoneyKindName);
            //�x������敪
            writer.Write(temp.PaymentMoneyKindDiv);
            //�x���v
            writer.Write(temp.PaymentTotal);
            //�x�����z
            writer.Write(temp.Payment);
            //�萔���x���z
            writer.Write(temp.FeePayment);
            //�l���x���z
            writer.Write(temp.DiscountPayment);
            //�����x���敪
            writer.Write(temp.AutoPayment);
            //��`�U�o��
            writer.Write((Int64)temp.DraftDrawingDate.Ticks);
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
            //�ԍ��x���A���ԍ�
            writer.Write(temp.DebitNoteLinkPayNo);
            //�x���S���҃R�[�h
            writer.Write(temp.PaymentAgentCode);
            //�x���S���Җ���
            writer.Write(temp.PaymentAgentName);
            //�x�����͎҃R�[�h
            writer.Write(temp.PaymentInputAgentCd);
            //�x�����͎Җ���
            writer.Write(temp.PaymentInputAgentNm);
            //�`�[�E�v
            writer.Write(temp.Outline);
            //��s�R�[�h
            writer.Write(temp.BankCode);
            //��s����
            writer.Write(temp.BankName);

        }

        /// <summary>
        ///  IOWriteMASIRPaymentWork�C���X�^���X�擾
        /// </summary>
        /// <returns>IOWriteMASIRPaymentWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private IOWriteMASIRPaymentWork GetIOWriteMASIRPaymentWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            IOWriteMASIRPaymentWork temp = new IOWriteMASIRPaymentWork();

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
            //�ԓ`�敪
            temp.DebitNoteDiv = reader.ReadInt32();
            //�x���`�[�ԍ�
            temp.PaymentSlipNo = reader.ReadInt32();
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�d���`�[�ԍ�
            temp.SupplierSlipNo = reader.ReadInt32();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�x���於��
            temp.PayeeName = reader.ReadString();
            //�x���於��2
            temp.PayeeName2 = reader.ReadString();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於1
            temp.SupplierNm1 = reader.ReadString();
            //�d���於2
            temp.SupplierNm2 = reader.ReadString();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�x�����͋��_�R�[�h
            temp.PaymentInpSectionCd = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�X�V���_�R�[�h
            temp.UpdateSecCd = reader.ReadString();
            //����R�[�h
            temp.SubSectionCode = reader.ReadInt32();
            //�ۃR�[�h
            temp.MinSectionCode = reader.ReadInt32();
            //�x�����t
            temp.PaymentDate = new DateTime(reader.ReadInt64());
            //�v����t
            temp.AddUpADate = new DateTime(reader.ReadInt64());
            //�x������R�[�h
            temp.PaymentMoneyKindCode = reader.ReadInt32();
            //�x�����햼��
            temp.PaymentMoneyKindName = reader.ReadString();
            //�x������敪
            temp.PaymentMoneyKindDiv = reader.ReadInt32();
            //�x���v
            temp.PaymentTotal = reader.ReadInt64();
            //�x�����z
            temp.Payment = reader.ReadInt64();
            //�萔���x���z
            temp.FeePayment = reader.ReadInt64();
            //�l���x���z
            temp.DiscountPayment = reader.ReadInt64();
            //�����x���敪
            temp.AutoPayment = reader.ReadInt32();
            //��`�U�o��
            temp.DraftDrawingDate = new DateTime(reader.ReadInt64());
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
            //�ԍ��x���A���ԍ�
            temp.DebitNoteLinkPayNo = reader.ReadInt32();
            //�x���S���҃R�[�h
            temp.PaymentAgentCode = reader.ReadString();
            //�x���S���Җ���
            temp.PaymentAgentName = reader.ReadString();
            //�x�����͎҃R�[�h
            temp.PaymentInputAgentCd = reader.ReadString();
            //�x�����͎Җ���
            temp.PaymentInputAgentNm = reader.ReadString();
            //�`�[�E�v
            temp.Outline = reader.ReadString();
            //��s�R�[�h
            temp.BankCode = reader.ReadInt32();
            //��s����
            temp.BankName = reader.ReadString();


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
        /// <returns>IOWriteMASIRPaymentWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   IOWriteMASIRPaymentWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                IOWriteMASIRPaymentWork temp = GetIOWriteMASIRPaymentWork(reader, serInfo);
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
                    retValue = (IOWriteMASIRPaymentWork[])lst.ToArray(typeof(IOWriteMASIRPaymentWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

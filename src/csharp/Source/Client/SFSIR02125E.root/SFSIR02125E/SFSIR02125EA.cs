using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchPaymentSlp
    /// <summary>
    ///                      �x���`�[�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x���`�[�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/07/08 30414 �E �K�j Partsman�p�ɕύX</br>
    /// <br>                     �� �x���`�[�}�X�^(SFSIR02135E)�Ɠ��l�̓��e�ׁ̈A</br>
    /// <br>                        �ύX���������ꍇ�́A�x���`�[�}�X�^�̕���</br>
    /// <br>                        �ύX���e���m�F���邱�ƁI</br>
    /// </remarks>
    public class SearchPaymentSlp
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

        /// <summary>�ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;

        /// <summary>�x���`�[�ԍ�</summary>
        private Int32 _paymentSlipNo;

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d���`�[�ԍ�</summary>
        private Int32 _supplierSlipNo;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        private string _supplierNm2 = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�x����R�[�h</summary>
        /// <remarks>�x����̐e�R�[�h</remarks>
        private Int32 _payeeCode;

        /// <summary>�x���於��</summary>
        private string _payeeName = "";

        /// <summary>�x���於��2</summary>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        private string _payeeSnm = "";

        /// <summary>�x�����͋��_�R�[�h</summary>
        /// <remarks>�����^ �x�����͂������_�R�[�h</remarks>
        private string _paymentInpSectionCd = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�X�V���_�R�[�h</summary>
        /// <remarks>�����^ �f�[�^�̓o�^�X�V���_</remarks>
        private string _updateSecCd = "";

        /// <summary>����R�[�h</summary>
        private Int32 _subSectionCode;

        /// <summary>�x�����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _paymentDate;

        /// <summary>�v����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpADate;

        /// <summary>�x���v</summary>
        /// <remarks>�x�����z�{�萔���x���z�{�l���x���z</remarks>
        private Int64 _paymentTotal;

        /// <summary>�x�����z</summary>
        private Int64 _payment;

        /// <summary>�萔���x���z</summary>
        private Int64 _feePayment;

        /// <summary>�l���x���z</summary>
        private Int64 _discountPayment;

        /// <summary>�����x���敪</summary>
        /// <remarks>0:�ʏ�x��,�@1:�����x��</remarks>
        private Int32 _autoPayment;

        /// <summary>��`�U�o��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

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

        /// <summary>�ԍ��x���A���ԍ�</summary>
        private Int32 _debitNoteLinkPayNo;

        /// <summary>�x���S���҃R�[�h</summary>
        private string _paymentAgentCode = "";

        /// <summary>�x���S���Җ���</summary>
        private string _paymentAgentName = "";

        /// <summary>�x�����͎҃R�[�h</summary>
        private string _paymentInputAgentCd = "";

        /// <summary>�x�����͎Җ���</summary>
        private string _paymentInputAgentNm = "";

        /// <summary>�`�[�E�v</summary>
        /// <remarks>�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[</remarks>
        private string _outline = "";

        /// <summary>��s�R�[�h</summary>
        /// <remarks>�X�֋ǁF9900</remarks>
        private Int32 _bankCode;

        /// <summary>��s����</summary>
        private string _bankName = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// <summary>�x���s�ԍ�</summary>
        private Int32[] _paymentRowNoDtl = new Int32[10];

        /// <summary>����R�[�h</summary>
        private Int32[] _moneyKindCodeDtl = new Int32[10];

        /// <summary>���햼��</summary>
        private String[] _moneyKindNameDtl = new String[10];

        /// <summary>����敪</summary>
        private Int32[] _moneyKindDivDtl = new Int32[10];

        /// <summary>�x�����z</summary>
        private Int64[] _paymentDtl = new Int64[10];

        /// <summary>�L������</summary>
        private DateTime[] _validityTermDtl = new DateTime[10];

        /// <summary>�ŏI�v�����</summary>
        private Int32 _cAddUpUpdDate;
        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

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

        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
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
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// <value>�x����̐e�R�[�h</value>
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
        /// <value>�����^ �x�����͂������_�R�[�h</value>
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

        /// public propaty name  :  PaymentDate
        /// <summary>�x�����t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  PaymentDateJpFormal
        /// <summary>�x�����t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _paymentDate); }
            set { }
        }

        /// public propaty name  :  PaymentDateJpInFormal
        /// <summary>�x�����t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _paymentDate); }
            set { }
        }

        /// public propaty name  :  PaymentDateAdFormal
        /// <summary>�x�����t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _paymentDate); }
            set { }
        }

        /// public propaty name  :  PaymentDateAdInFormal
        /// <summary>�x�����t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _paymentDate); }
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

        /// public propaty name  :  PaymentTotal
        /// <summary>�x���v�v���p�e�B</summary>
        /// <value>�x�����z�{�萔���x���z�{�l���x���z</value>
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
        /// <value>0:�ʏ�x��,�@1:�����x��</value>
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

        /// public propaty name  :  DebitNoteLinkPayNo
        /// <summary>�ԍ��x���A���ԍ��v���p�e�B</summary>
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

        // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
        /// public property name  :  PaymentRowNoDtl
        /// <summary>�x���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] PaymentRowNoDtl
        {
            get { return _paymentRowNoDtl; }
            set { _paymentRowNoDtl = value; }
        }

        /// public property name  :  MoneyKindCodeDtl
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] MoneyKindCodeDtl
        {
            get { return _moneyKindCodeDtl; }
            set { _moneyKindCodeDtl = value; }
        }

        /// public property name  :  MoneyKindNameDtl
        /// <summary>���햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String[] MoneyKindNameDtl
        {
            get { return _moneyKindNameDtl; }
            set { _moneyKindNameDtl = value; }
        }

        /// public property name  :  MoneyKindDivDtl
        /// <summary>����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] MoneyKindDivDtl
        {
            get { return _moneyKindDivDtl; }
            set { _moneyKindDivDtl = value; }
        }

        /// public property name  :  PaymentDtl
        /// <summary>�x�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64[] PaymentDtl
        {
            get { return _paymentDtl; }
            set { _paymentDtl = value; }
        }

        /// public property name  :  ValidityTermDtl
        /// <summary>�L�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime[] ValidityTermDtl
        {
            get { return _validityTermDtl; }
            set { _validityTermDtl = value; }
        }
        /// public property name  :  CAddUpUpdDate
        /// <summary>�L�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CAddUpUpdDate
        {
            get { return _cAddUpUpdDate; }
            set { _cAddUpUpdDate = value; }
        }

        // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<

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
        /// �x���`�[�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SearchPaymentSlp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchPaymentSlp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchPaymentSlp()
        {
            for (int index = 0; index < this._moneyKindNameDtl.Length; index++)
            {
                this._moneyKindNameDtl[index] = "";
            }
        }

        /// <summary>
        /// �x���`�[�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="debitNoteDiv">�ԓ`�敪(0:���`,1:�ԓ`,2:����)</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
        /// <param name="supplierFormal">�d���`��(0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierNm1">�d���於1</param>
        /// <param name="supplierNm2">�d���於2</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <param name="payeeCode">�x����R�[�h(�x����̐e�R�[�h)</param>
        /// <param name="payeeName">�x���於��</param>
        /// <param name="payeeName2">�x���於��2</param>
        /// <param name="payeeSnm">�x���旪��</param>
        /// <param name="paymentInpSectionCd">�x�����͋��_�R�[�h(�����^ �x�����͂������_�R�[�h)</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="updateSecCd">�X�V���_�R�[�h(�����^ �f�[�^�̓o�^�X�V���_)</param>
        /// <param name="subSectionCode">����R�[�h</param>
        /// <param name="paymentDate">�x�����t(YYYYMMDD)</param>
        /// <param name="addUpADate">�v����t(YYYYMMDD)</param>
        /// <param name="paymentTotal">�x���v(�x�����z�{�萔���x���z�{�l���x���z)</param>
        /// <param name="payment">�x�����z</param>
        /// <param name="feePayment">�萔���x���z</param>
        /// <param name="discountPayment">�l���x���z</param>
        /// <param name="autoPayment">�����x���敪(0:�ʏ�x��,�@1:�����x��)</param>
        /// <param name="draftDrawingDate">��`�U�o��(YYYYMMDD)</param>
        /// <param name="draftKind">��`���</param>
        /// <param name="draftKindName">��`��ޖ���(�񑩁A�בցA���؎�)</param>
        /// <param name="draftDivide">��`�敪</param>
        /// <param name="draftDivideName">��`�敪����(���U�A��)</param>
        /// <param name="draftNo">��`�ԍ�</param>
        /// <param name="debitNoteLinkPayNo">�ԍ��x���A���ԍ�</param>
        /// <param name="paymentAgentCode">�x���S���҃R�[�h</param>
        /// <param name="paymentAgentName">�x���S���Җ���</param>
        /// <param name="paymentInputAgentCd">�x�����͎҃R�[�h</param>
        /// <param name="paymentInputAgentNm">�x�����͎Җ���</param>
        /// <param name="outline">�`�[�E�v(�Ԕ̂̏ꍇ�A�E�v+��������+�Ǘ��ԍ����i�[)</param>
        /// <param name="bankCode">��s�R�[�h(�X�֋ǁF9900)</param>
        /// <param name="bankName">��s����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <param name="paymentRowNoDtl">�x���s�ԍ�</param>
        /// <param name="moneyKindCodeDtl">����R�[�h</param>
        /// <param name="moneyKindNameDtl">���햼��</param>
        /// <param name="moneyKindDivDtl">����敪</param>
        /// <param name="paymentDtl">�x�����z</param>
        /// <param name="validityTermDtl">�L�����z</param>
        /// <param name="cAddUpUpdDate">�ŏI�v�����</param>
        /// <param name="inputDay">���͓�</param>
        /// <returns>SearchPaymentSlp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchPaymentSlp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchPaymentSlp(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 debitNoteDiv, Int32 paymentSlipNo, Int32 supplierFormal, Int32 supplierSlipNo, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, Int32 payeeCode, string payeeName, string payeeName2, string payeeSnm, string paymentInpSectionCd, string addUpSecCode, string updateSecCd, Int32 subSectionCode, DateTime paymentDate, DateTime addUpADate, Int64 paymentTotal, Int64 payment, Int64 feePayment, Int64 discountPayment, Int32 autoPayment, DateTime draftDrawingDate, Int32 draftKind, string draftKindName, Int32 draftDivide, string draftDivideName, string draftNo, Int32 debitNoteLinkPayNo, string paymentAgentCode, string paymentAgentName, string paymentInputAgentCd, string paymentInputAgentNm, string outline, Int32 bankCode, string bankName, string enterpriseName, string updEmployeeName, string addUpSecName, Int32[] paymentRowNoDtl, Int32[] moneyKindCodeDtl, String[] moneyKindNameDtl, Int32[] moneyKindDivDtl, Int64[] paymentDtl, DateTime[] validityTermDtl, int cAddUpUpdDate, DateTime inputDay)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._debitNoteDiv = debitNoteDiv;
            this._paymentSlipNo = paymentSlipNo;
            this._supplierFormal = supplierFormal;
            this._supplierSlipNo = supplierSlipNo;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierNm2 = supplierNm2;
            this._supplierSnm = supplierSnm;
            this._payeeCode = payeeCode;
            this._payeeName = payeeName;
            this._payeeName2 = payeeName2;
            this._payeeSnm = payeeSnm;
            this._paymentInpSectionCd = paymentInpSectionCd;
            this._addUpSecCode = addUpSecCode;
            this._updateSecCd = updateSecCd;
            this._subSectionCode = subSectionCode;
            this.PaymentDate = paymentDate;
            this.AddUpADate = addUpADate;
            this._paymentTotal = paymentTotal;
            this._payment = payment;
            this._feePayment = feePayment;
            this._discountPayment = discountPayment;
            this._autoPayment = autoPayment;
            this.DraftDrawingDate = draftDrawingDate;
            this._draftKind = draftKind;
            this._draftKindName = draftKindName;
            this._draftDivide = draftDivide;
            this._draftDivideName = draftDivideName;
            this._draftNo = draftNo;
            this._debitNoteLinkPayNo = debitNoteLinkPayNo;
            this._paymentAgentCode = paymentAgentCode;
            this._paymentAgentName = paymentAgentName;
            this._paymentInputAgentCd = paymentInputAgentCd;
            this._paymentInputAgentNm = paymentInputAgentNm;
            this._outline = outline;
            this._bankCode = bankCode;
            this._bankName = bankName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                this._paymentRowNoDtl[index] = paymentRowNoDtl[index];
                this._moneyKindCodeDtl[index] = moneyKindCodeDtl[index];
                this._moneyKindNameDtl[index] = moneyKindNameDtl[index];
                this._moneyKindDivDtl[index] = moneyKindDivDtl[index];
                this._paymentDtl[index] = paymentDtl[index];
                this._validityTermDtl[index] = validityTermDtl[index];
            }
            this._cAddUpUpdDate = cAddUpUpdDate;
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
            this._inputDay = inputDay;
        }

        /// <summary>
        /// �x���`�[�}�X�^��������
        /// </summary>
        /// <returns>SearchPaymentSlp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SearchPaymentSlp�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchPaymentSlp Clone()
        {
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
            //return new SearchPaymentSlp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._debitNoteDiv, this._paymentSlipNo, this._supplierFormal, this._supplierSlipNo, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._paymentInpSectionCd, this._addUpSecCode, this._updateSecCd, this._subSectionCode, this._paymentDate, this._addUpADate, this._paymentTotal, this._payment, this._feePayment, this._discountPayment, this._autoPayment, this._draftDrawingDate, this._draftKind, this._draftKindName, this._draftDivide, this._draftDivideName, this._draftNo, this._debitNoteLinkPayNo, this._paymentAgentCode, this._paymentAgentName, this._paymentInputAgentCd, this._paymentInputAgentNm, this._outline, this._bankCode, this._bankName, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
            return new SearchPaymentSlp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._debitNoteDiv, this._paymentSlipNo, this._supplierFormal, this._supplierSlipNo, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._payeeCode, this._payeeName, this._payeeName2, this._payeeSnm, this._paymentInpSectionCd, this._addUpSecCode, this._updateSecCd, this._subSectionCode, this._paymentDate, this._addUpADate, this._paymentTotal, this._payment, this._feePayment, this._discountPayment, this._autoPayment, this._draftDrawingDate, this._draftKind, this._draftKindName, this._draftDivide, this._draftDivideName, this._draftNo, this._debitNoteLinkPayNo, this._paymentAgentCode, this._paymentAgentName, this._paymentInputAgentCd, this._paymentInputAgentNm, this._outline, this._bankCode, this._bankName, this._enterpriseName, this._updEmployeeName, this._addUpSecName, this._paymentRowNoDtl, this._moneyKindCodeDtl, this._moneyKindNameDtl, this._moneyKindDivDtl, this._paymentDtl, this._validityTermDtl, this._cAddUpUpdDate, this._inputDay);
            // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
        }

        /// <summary>
        /// �x���`�[�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchPaymentSlp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchPaymentSlp�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SearchPaymentSlp target)
        {
            if (this.CreateDateTime != target.CreateDateTime) { return (false); }
            if (this.UpdateDateTime != target.UpdateDateTime) { return (false); }
            if (this.EnterpriseCode.Trim() != target.EnterpriseCode.Trim()) { return (false); }
            if (this.FileHeaderGuid != target.FileHeaderGuid) { return (false); }
            if (this.UpdEmployeeCode.Trim() != target.UpdEmployeeCode.Trim()) { return (false); }
            if (this.UpdAssemblyId1.Trim() != target.UpdAssemblyId1.Trim()) { return (false); }
            if (this.UpdAssemblyId2.Trim() != target.UpdAssemblyId2.Trim()) { return (false); }
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) { return (false); }
            if (this.DebitNoteDiv != target.DebitNoteDiv) { return (false); }
            if (this.PaymentSlipNo != target.PaymentSlipNo) { return (false); }
            if (this.SupplierFormal != target.SupplierFormal) { return (false); }
            if (this.SupplierSlipNo != target.SupplierSlipNo) { return (false); }
            if (this.SupplierCd != target.SupplierCd) { return (false); }
            if (this.SupplierNm1.Trim() != target.SupplierNm1.Trim()) { return (false); }
            if (this.SupplierNm2.Trim() != target.SupplierNm2.Trim()) { return (false); }
            if (this.SupplierSnm.Trim() != target.SupplierSnm.Trim()) { return (false); }
            if (this.PayeeCode != target.PayeeCode) { return (false); }
            if (this.PayeeName.Trim() != target.PayeeName.Trim()) { return (false); }
            if (this.PayeeName2.Trim() != target.PayeeName2.Trim()) { return (false); }
            if (this.PayeeSnm.Trim() != target.PayeeSnm.Trim()) { return (false); }
            if (this.PaymentInpSectionCd.Trim() != target.PaymentInpSectionCd.Trim()) { return (false); }
            if (this.AddUpSecCode.Trim() != target.AddUpSecCode.Trim()) { return (false); }
            if (this.UpdateSecCd.Trim() != target.UpdateSecCd.Trim()) { return (false); }
            if (this.SubSectionCode != target.SubSectionCode) { return (false); }
            if (this.PaymentDate != target.PaymentDate) { return (false); }
            if (this.AddUpADate != target.AddUpADate) { return (false); }
            if (this.PaymentTotal != target.PaymentTotal) { return (false); }
            if (this.Payment != target.Payment) { return (false); }
            if (this.FeePayment != target.FeePayment) { return (false); }
            if (this.DiscountPayment != target.DiscountPayment) { return (false); }
            if (this.AutoPayment != target.AutoPayment) { return (false); }
            if (this.DraftDrawingDate != target.DraftDrawingDate) { return (false); }
            if (this.DraftKind != target.DraftKind) { return (false); }
            if (this.DraftKindName.Trim() != target.DraftKindName.Trim()) { return (false); }
            if (this.DraftDivide != target.DraftDivide) { return (false); }
            if (this.DraftDivideName.Trim() != target.DraftDivideName.Trim()) { return (false); }
            if (this.DraftNo.Trim() != target.DraftNo.Trim()) { return (false); }
            if (this.DebitNoteLinkPayNo != target.DebitNoteLinkPayNo) { return (false); }
            if (this.PaymentAgentCode.Trim() != target.PaymentAgentCode.Trim()) { return (false); }
            if (this.PaymentAgentName.Trim() != target.PaymentAgentName.Trim()) { return (false); }
            if (this.PaymentInputAgentCd.Trim() != target.PaymentInputAgentCd.Trim()) { return (false); }
            if (this.PaymentInputAgentNm.Trim() != target.PaymentInputAgentNm.Trim()) { return (false); }
            if (this.Outline.Trim() != target.Outline.Trim()) { return (false); }
            if (this.BankCode != target.BankCode) { return (false); }
            if (this.BankName.Trim() != target.BankName.Trim()) { return (false); }
            if (this.EnterpriseName.Trim() != target.EnterpriseName.Trim()) { return (false); }
            if (this.UpdEmployeeName.Trim() != target.UpdEmployeeName.Trim()) { return (false); }
            if (this.AddUpSecName.Trim() != target.AddUpSecName.Trim()) { return (false); }
            if (this.CAddUpUpdDate != target.CAddUpUpdDate) { return (false); }
            for (int index = 0; index < 10; index++)
            {
                if (this.PaymentRowNoDtl[index] != target.PaymentRowNoDtl[index]) { return (false); }
                if (this.MoneyKindCodeDtl[index] != target.MoneyKindCodeDtl[index]) { return (false); }
                if (this.MoneyKindNameDtl[index].Trim() != target.MoneyKindNameDtl[index].Trim()) { return (false); }
                if (this.MoneyKindDivDtl[index] != target.MoneyKindDivDtl[index]) { return (false); }
                if (this.PaymentDtl[index] != target.PaymentDtl[index]) { return (false); }
                if (this.ValidityTermDtl[index] != target.ValidityTermDtl[index]) { return (false); }
            }
            if (this.InputDay != target.InputDay) { return (false); }

            return (true);
        }

        /// <summary>
        /// �x���`�[�}�X�^��r����
        /// </summary>
        /// <param name="SearchPaymentSlp1">
        ///                    ��r����SearchPaymentSlp�N���X�̃C���X�^���X
        /// </param>
        /// <param name="SearchPaymentSlp2">��r����SearchPaymentSlp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchPaymentSlp�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SearchPaymentSlp searchPaymentSlp1, SearchPaymentSlp searchPaymentSlp2)
        {
            if (searchPaymentSlp1.CreateDateTime != searchPaymentSlp2.CreateDateTime) { return (false); }
            if (searchPaymentSlp1.UpdateDateTime != searchPaymentSlp2.UpdateDateTime) { return (false); }
            if (searchPaymentSlp1.EnterpriseCode.Trim() != searchPaymentSlp2.EnterpriseCode.Trim()) { return (false); }
            if (searchPaymentSlp1.FileHeaderGuid != searchPaymentSlp2.FileHeaderGuid) { return (false); }
            if (searchPaymentSlp1.UpdEmployeeCode.Trim() != searchPaymentSlp2.UpdEmployeeCode.Trim()) { return (false); }
            if (searchPaymentSlp1.UpdAssemblyId1.Trim() != searchPaymentSlp2.UpdAssemblyId1.Trim()) { return (false); }
            if (searchPaymentSlp1.UpdAssemblyId2.Trim() != searchPaymentSlp2.UpdAssemblyId2.Trim()) { return (false); }
            if (searchPaymentSlp1.LogicalDeleteCode != searchPaymentSlp2.LogicalDeleteCode) { return (false); }
            if (searchPaymentSlp1.DebitNoteDiv != searchPaymentSlp2.DebitNoteDiv) { return (false); }
            if (searchPaymentSlp1.PaymentSlipNo != searchPaymentSlp2.PaymentSlipNo) { return (false); }
            if (searchPaymentSlp1.SupplierFormal != searchPaymentSlp2.SupplierFormal) { return (false); }
            if (searchPaymentSlp1.SupplierSlipNo != searchPaymentSlp2.SupplierSlipNo) { return (false); }
            if (searchPaymentSlp1.SupplierCd != searchPaymentSlp2.SupplierCd) { return (false); }
            if (searchPaymentSlp1.SupplierNm1.Trim() != searchPaymentSlp2.SupplierNm1.Trim()) { return (false); }
            if (searchPaymentSlp1.SupplierNm2.Trim() != searchPaymentSlp2.SupplierNm2.Trim()) { return (false); }
            if (searchPaymentSlp1.SupplierSnm.Trim() != searchPaymentSlp2.SupplierSnm.Trim()) { return (false); }
            if (searchPaymentSlp1.PayeeCode != searchPaymentSlp2.PayeeCode) { return (false); }
            if (searchPaymentSlp1.PayeeName.Trim() != searchPaymentSlp2.PayeeName.Trim()) { return (false); }
            if (searchPaymentSlp1.PayeeName2.Trim() != searchPaymentSlp2.PayeeName2.Trim()) { return (false); }
            if (searchPaymentSlp1.PayeeSnm.Trim() != searchPaymentSlp2.PayeeSnm.Trim()) { return (false); }
            if (searchPaymentSlp1.PaymentInpSectionCd.Trim() != searchPaymentSlp2.PaymentInpSectionCd.Trim()) { return (false); }
            if (searchPaymentSlp1.AddUpSecCode.Trim() != searchPaymentSlp2.AddUpSecCode.Trim()) { return (false); }
            if (searchPaymentSlp1.UpdateSecCd.Trim() != searchPaymentSlp2.UpdateSecCd.Trim()) { return (false); }
            if (searchPaymentSlp1.SubSectionCode != searchPaymentSlp2.SubSectionCode) { return (false); }
            if (searchPaymentSlp1.PaymentDate != searchPaymentSlp2.PaymentDate) { return (false); }
            if (searchPaymentSlp1.AddUpADate != searchPaymentSlp2.AddUpADate) { return (false); }
            if (searchPaymentSlp1.PaymentTotal != searchPaymentSlp2.PaymentTotal) { return (false); }
            if (searchPaymentSlp1.Payment != searchPaymentSlp2.Payment) { return (false); }
            if (searchPaymentSlp1.FeePayment != searchPaymentSlp2.FeePayment) { return (false); }
            if (searchPaymentSlp1.DiscountPayment != searchPaymentSlp2.DiscountPayment) { return (false); }
            if (searchPaymentSlp1.AutoPayment != searchPaymentSlp2.AutoPayment) { return (false); }
            if (searchPaymentSlp1.DraftDrawingDate != searchPaymentSlp2.DraftDrawingDate) { return (false); }
            if (searchPaymentSlp1.DraftKind != searchPaymentSlp2.DraftKind) { return (false); }
            if (searchPaymentSlp1.DraftKindName.Trim() != searchPaymentSlp2.DraftKindName.Trim()) { return (false); }
            if (searchPaymentSlp1.DraftDivide != searchPaymentSlp2.DraftDivide) { return (false); }
            if (searchPaymentSlp1.DraftDivideName.Trim() != searchPaymentSlp2.DraftDivideName.Trim()) { return (false); }
            if (searchPaymentSlp1.DraftNo.Trim() != searchPaymentSlp2.DraftNo.Trim()) { return (false); }
            if (searchPaymentSlp1.DebitNoteLinkPayNo != searchPaymentSlp2.DebitNoteLinkPayNo) { return (false); }
            if (searchPaymentSlp1.PaymentAgentCode.Trim() != searchPaymentSlp2.PaymentAgentCode.Trim()) { return (false); }
            if (searchPaymentSlp1.PaymentAgentName.Trim() != searchPaymentSlp2.PaymentAgentName.Trim()) { return (false); }
            if (searchPaymentSlp1.PaymentInputAgentCd.Trim() != searchPaymentSlp2.PaymentInputAgentCd.Trim()) { return (false); }
            if (searchPaymentSlp1.PaymentInputAgentNm.Trim() != searchPaymentSlp2.PaymentInputAgentNm.Trim()) { return (false); }
            if (searchPaymentSlp1.Outline.Trim() != searchPaymentSlp2.Outline.Trim()) { return (false); }
            if (searchPaymentSlp1.BankCode != searchPaymentSlp2.BankCode) { return (false); }
            if (searchPaymentSlp1.BankName.Trim() != searchPaymentSlp2.BankName.Trim()) { return (false); }
            if (searchPaymentSlp1.EnterpriseName.Trim() != searchPaymentSlp2.EnterpriseName.Trim()) { return (false); }
            if (searchPaymentSlp1.UpdEmployeeName.Trim() != searchPaymentSlp2.UpdEmployeeName.Trim()) { return (false); }
            if (searchPaymentSlp1.AddUpSecName.Trim() != searchPaymentSlp2.AddUpSecName.Trim()) { return (false); }
            if (searchPaymentSlp1.CAddUpUpdDate != searchPaymentSlp2.CAddUpUpdDate) { return (false); }
            for (int index = 0; index < 10; index++)
            {
                if (searchPaymentSlp1.PaymentRowNoDtl[index] != searchPaymentSlp2.PaymentRowNoDtl[index]) { return (false); }
                if (searchPaymentSlp1.MoneyKindCodeDtl[index] != searchPaymentSlp2.MoneyKindCodeDtl[index]) { return (false); }
                if (searchPaymentSlp1.MoneyKindNameDtl[index].Trim() != searchPaymentSlp2.MoneyKindNameDtl[index].Trim()) { return (false); }
                if (searchPaymentSlp1.MoneyKindDivDtl[index] != searchPaymentSlp2.MoneyKindDivDtl[index]) { return (false); }
                if (searchPaymentSlp1.PaymentDtl[index] != searchPaymentSlp2.PaymentDtl[index]) { return (false); }
                if (searchPaymentSlp1.ValidityTermDtl[index] != searchPaymentSlp2.ValidityTermDtl[index]) { return (false); }
            }
            if (searchPaymentSlp1.InputDay != searchPaymentSlp2.InputDay) { return (false); }

            return (true);
        }
        /// <summary>
        /// �x���`�[�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchPaymentSlp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchPaymentSlp�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SearchPaymentSlp target)
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
            if (this.DebitNoteDiv != target.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (this.PaymentSlipNo != target.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierNm1 != target.SupplierNm1) resList.Add("SupplierNm1");
            if (this.SupplierNm2 != target.SupplierNm2) resList.Add("SupplierNm2");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.PayeeCode != target.PayeeCode) resList.Add("PayeeCode");
            if (this.PayeeName != target.PayeeName) resList.Add("PayeeName");
            if (this.PayeeName2 != target.PayeeName2) resList.Add("PayeeName2");
            if (this.PayeeSnm != target.PayeeSnm) resList.Add("PayeeSnm");
            if (this.PaymentInpSectionCd != target.PaymentInpSectionCd) resList.Add("PaymentInpSectionCd");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.UpdateSecCd != target.UpdateSecCd) resList.Add("UpdateSecCd");
            if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
            if (this.PaymentDate != target.PaymentDate) resList.Add("PaymentDate");
            if (this.AddUpADate != target.AddUpADate) resList.Add("AddUpADate");
            if (this.PaymentTotal != target.PaymentTotal) resList.Add("PaymentTotal");
            if (this.Payment != target.Payment) resList.Add("Payment");
            if (this.FeePayment != target.FeePayment) resList.Add("FeePayment");
            if (this.DiscountPayment != target.DiscountPayment) resList.Add("DiscountPayment");
            if (this.AutoPayment != target.AutoPayment) resList.Add("AutoPayment");
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (this.DraftKind != target.DraftKind) resList.Add("DraftKind");
            if (this.DraftKindName != target.DraftKindName) resList.Add("DraftKindName");
            if (this.DraftDivide != target.DraftDivide) resList.Add("DraftDivide");
            if (this.DraftDivideName != target.DraftDivideName) resList.Add("DraftDivideName");
            if (this.DraftNo != target.DraftNo) resList.Add("DraftNo");
            if (this.DebitNoteLinkPayNo != target.DebitNoteLinkPayNo) resList.Add("DebitNoteLinkPayNo");
            if (this.PaymentAgentCode != target.PaymentAgentCode) resList.Add("PaymentAgentCode");
            if (this.PaymentAgentName != target.PaymentAgentName) resList.Add("PaymentAgentName");
            if (this.PaymentInputAgentCd != target.PaymentInputAgentCd) resList.Add("PaymentInputAgentCd");
            if (this.PaymentInputAgentNm != target.PaymentInputAgentNm) resList.Add("PaymentInputAgentNm");
            if (this.Outline != target.Outline) resList.Add("Outline");
            if (this.BankCode != target.BankCode) resList.Add("BankCode");
            if (this.BankName != target.BankName) resList.Add("BankName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                if (this.PaymentRowNoDtl[index] != target.PaymentRowNoDtl[index]) resList.Add("PaymentRowNoDtl");
                if (this.MoneyKindCodeDtl[index] != target.MoneyKindCodeDtl[index]) resList.Add("MoneyKindCodeDtl");
                if (this.MoneyKindNameDtl[index].Trim() != target.MoneyKindNameDtl[index].Trim()) resList.Add("MoneyKindNameDtl");
                if (this.MoneyKindDivDtl[index] != target.MoneyKindDivDtl[index]) resList.Add("MoneyKindDivDtl");
                if (this.PaymentDtl[index] != target.PaymentDtl[index]) resList.Add("PaymentDtl");
                if (this.ValidityTermDtl[index] != target.ValidityTermDtl[index]) resList.Add("ValidityTermDtl");
            }
            if (this.CAddUpUpdDate != target.CAddUpUpdDate) resList.Add("CAddUpUpdDate");
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
            if (this.InputDay != target.InputDay) resList.Add("InputDay");

            return resList;
        }

        /// <summary>
        /// �x���`�[�}�X�^��r����
        /// </summary>
        /// <param name="searchPaymentSlp1">��r����SearchPaymentSlp�N���X�̃C���X�^���X</param>
        /// <param name="searchPaymentSlp2">��r����SearchPaymentSlp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchPaymentSlp�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SearchPaymentSlp searchPaymentSlp1, SearchPaymentSlp searchPaymentSlp2)
        {
            ArrayList resList = new ArrayList();
            if (searchPaymentSlp1.CreateDateTime != searchPaymentSlp2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchPaymentSlp1.UpdateDateTime != searchPaymentSlp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchPaymentSlp1.EnterpriseCode != searchPaymentSlp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchPaymentSlp1.FileHeaderGuid != searchPaymentSlp2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchPaymentSlp1.UpdEmployeeCode != searchPaymentSlp2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchPaymentSlp1.UpdAssemblyId1 != searchPaymentSlp2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchPaymentSlp1.UpdAssemblyId2 != searchPaymentSlp2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchPaymentSlp1.LogicalDeleteCode != searchPaymentSlp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchPaymentSlp1.DebitNoteDiv != searchPaymentSlp2.DebitNoteDiv) resList.Add("DebitNoteDiv");
            if (searchPaymentSlp1.PaymentSlipNo != searchPaymentSlp2.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (searchPaymentSlp1.SupplierFormal != searchPaymentSlp2.SupplierFormal) resList.Add("SupplierFormal");
            if (searchPaymentSlp1.SupplierSlipNo != searchPaymentSlp2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (searchPaymentSlp1.SupplierCd != searchPaymentSlp2.SupplierCd) resList.Add("SupplierCd");
            if (searchPaymentSlp1.SupplierNm1 != searchPaymentSlp2.SupplierNm1) resList.Add("SupplierNm1");
            if (searchPaymentSlp1.SupplierNm2 != searchPaymentSlp2.SupplierNm2) resList.Add("SupplierNm2");
            if (searchPaymentSlp1.SupplierSnm != searchPaymentSlp2.SupplierSnm) resList.Add("SupplierSnm");
            if (searchPaymentSlp1.PayeeCode != searchPaymentSlp2.PayeeCode) resList.Add("PayeeCode");
            if (searchPaymentSlp1.PayeeName != searchPaymentSlp2.PayeeName) resList.Add("PayeeName");
            if (searchPaymentSlp1.PayeeName2 != searchPaymentSlp2.PayeeName2) resList.Add("PayeeName2");
            if (searchPaymentSlp1.PayeeSnm != searchPaymentSlp2.PayeeSnm) resList.Add("PayeeSnm");
            if (searchPaymentSlp1.PaymentInpSectionCd != searchPaymentSlp2.PaymentInpSectionCd) resList.Add("PaymentInpSectionCd");
            if (searchPaymentSlp1.AddUpSecCode != searchPaymentSlp2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (searchPaymentSlp1.UpdateSecCd != searchPaymentSlp2.UpdateSecCd) resList.Add("UpdateSecCd");
            if (searchPaymentSlp1.SubSectionCode != searchPaymentSlp2.SubSectionCode) resList.Add("SubSectionCode");
            if (searchPaymentSlp1.PaymentDate != searchPaymentSlp2.PaymentDate) resList.Add("PaymentDate");
            if (searchPaymentSlp1.AddUpADate != searchPaymentSlp2.AddUpADate) resList.Add("AddUpADate");
            if (searchPaymentSlp1.PaymentTotal != searchPaymentSlp2.PaymentTotal) resList.Add("PaymentTotal");
            if (searchPaymentSlp1.Payment != searchPaymentSlp2.Payment) resList.Add("Payment");
            if (searchPaymentSlp1.FeePayment != searchPaymentSlp2.FeePayment) resList.Add("FeePayment");
            if (searchPaymentSlp1.DiscountPayment != searchPaymentSlp2.DiscountPayment) resList.Add("DiscountPayment");
            if (searchPaymentSlp1.AutoPayment != searchPaymentSlp2.AutoPayment) resList.Add("AutoPayment");
            if (searchPaymentSlp1.DraftDrawingDate != searchPaymentSlp2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (searchPaymentSlp1.DraftKind != searchPaymentSlp2.DraftKind) resList.Add("DraftKind");
            if (searchPaymentSlp1.DraftKindName != searchPaymentSlp2.DraftKindName) resList.Add("DraftKindName");
            if (searchPaymentSlp1.DraftDivide != searchPaymentSlp2.DraftDivide) resList.Add("DraftDivide");
            if (searchPaymentSlp1.DraftDivideName != searchPaymentSlp2.DraftDivideName) resList.Add("DraftDivideName");
            if (searchPaymentSlp1.DraftNo != searchPaymentSlp2.DraftNo) resList.Add("DraftNo");
            if (searchPaymentSlp1.DebitNoteLinkPayNo != searchPaymentSlp2.DebitNoteLinkPayNo) resList.Add("DebitNoteLinkPayNo");
            if (searchPaymentSlp1.PaymentAgentCode != searchPaymentSlp2.PaymentAgentCode) resList.Add("PaymentAgentCode");
            if (searchPaymentSlp1.PaymentAgentName != searchPaymentSlp2.PaymentAgentName) resList.Add("PaymentAgentName");
            if (searchPaymentSlp1.PaymentInputAgentCd != searchPaymentSlp2.PaymentInputAgentCd) resList.Add("PaymentInputAgentCd");
            if (searchPaymentSlp1.PaymentInputAgentNm != searchPaymentSlp2.PaymentInputAgentNm) resList.Add("PaymentInputAgentNm");
            if (searchPaymentSlp1.Outline != searchPaymentSlp2.Outline) resList.Add("Outline");
            if (searchPaymentSlp1.BankCode != searchPaymentSlp2.BankCode) resList.Add("BankCode");
            if (searchPaymentSlp1.BankName != searchPaymentSlp2.BankName) resList.Add("BankName");
            if (searchPaymentSlp1.EnterpriseName != searchPaymentSlp2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchPaymentSlp1.UpdEmployeeName != searchPaymentSlp2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchPaymentSlp1.AddUpSecName != searchPaymentSlp2.AddUpSecName) resList.Add("AddUpSecName");
            // --- ADD 2008/07/08 --------------------------------------------------------------------->>>>>
            for (int index = 0; index < 10; index++)
            {
                if (searchPaymentSlp1.PaymentRowNoDtl[index] != searchPaymentSlp2.PaymentRowNoDtl[index]) resList.Add("PaymentRowNoDtl");
                if (searchPaymentSlp1.MoneyKindCodeDtl[index] != searchPaymentSlp2.MoneyKindCodeDtl[index]) resList.Add("MoneyKindCodeDtl");
                if (searchPaymentSlp1.MoneyKindNameDtl[index].Trim() != searchPaymentSlp2.MoneyKindNameDtl[index].Trim()) resList.Add("MoneyKindNameDtl");
                if (searchPaymentSlp1.MoneyKindDivDtl[index] != searchPaymentSlp2.MoneyKindDivDtl[index]) resList.Add("MoneyKindDivDtl");
                if (searchPaymentSlp1.PaymentDtl[index] != searchPaymentSlp2.PaymentDtl[index]) resList.Add("PaymentDtl");
                if (searchPaymentSlp1.ValidityTermDtl[index] != searchPaymentSlp2.ValidityTermDtl[index]) resList.Add("ValidityTermDtl");
            }
            if (searchPaymentSlp1.CAddUpUpdDate != searchPaymentSlp2.CAddUpUpdDate) resList.Add("CAddUpUpdDate");
            // --- ADD 2008/07/08 ---------------------------------------------------------------------<<<<<
            if (searchPaymentSlp1.InputDay != searchPaymentSlp2.InputDay) resList.Add("InputDay");

            return resList;
        }
    }
}

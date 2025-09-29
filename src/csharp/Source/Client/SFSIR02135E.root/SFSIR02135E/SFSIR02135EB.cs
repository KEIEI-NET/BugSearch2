using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PaymentDtl
    /// <summary>
    ///                      �x�����׃f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x�����׃f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2008/09/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PaymentDtl
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

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�x���`�[�ԍ�</summary>
        private Int32 _paymentSlipNo;

        /// <summary>�x���s�ԍ�</summary>
        private Int32 _paymentRowNo;

        /// <summary>����R�[�h</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode;

        /// <summary>���햼��</summary>
        private string _moneyKindName = "";

        /// <summary>����敪</summary>
        private Int32 _moneyKindDiv;

        /// <summary>�x�����z</summary>
        private Int64 _payment;

        /// <summary>�L������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _validityTerm;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>����敪����</summary>
        private string _moneyKindDivName = "";


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

        /// public propaty name  :  PaymentRowNo
        /// <summary>�x���s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo
        {
            get { return _paymentRowNo; }
            set { _paymentRowNo = value; }
        }

        /// public propaty name  :  MoneyKindCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode
        {
            get { return _moneyKindCode; }
            set { _moneyKindCode = value; }
        }

        /// public propaty name  :  MoneyKindName
        /// <summary>���햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName
        {
            get { return _moneyKindName; }
            set { _moneyKindName = value; }
        }

        /// public propaty name  :  MoneyKindDiv
        /// <summary>����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv
        {
            get { return _moneyKindDiv; }
            set { _moneyKindDiv = value; }
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

        /// public propaty name  :  ValidityTerm
        /// <summary>�L�������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }

        /// public propaty name  :  ValidityTermJpFormal
        /// <summary>�L������ �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L������ �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidityTermJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _validityTerm); }
            set { }
        }

        /// public propaty name  :  ValidityTermJpInFormal
        /// <summary>�L������ �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L������ �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidityTermJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _validityTerm); }
            set { }
        }

        /// public propaty name  :  ValidityTermAdFormal
        /// <summary>�L������ ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L������ ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidityTermAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _validityTerm); }
            set { }
        }

        /// public propaty name  :  ValidityTermAdInFormal
        /// <summary>�L������ ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L������ ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ValidityTermAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _validityTerm); }
            set { }
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

        /// public propaty name  :  MoneyKindDivName
        /// <summary>����敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindDivName
        {
            get { return _moneyKindDivName; }
            set { _moneyKindDivName = value; }
        }


        /// <summary>
        /// �x�����׃f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>PaymentDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PaymentDtl()
        {
        }

        /// <summary>
        /// �x�����׃f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="supplierFormal">�d���`��(0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
        /// <param name="paymentRowNo">�x���s�ԍ�</param>
        /// <param name="moneyKindCode">����R�[�h(1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����)</param>
        /// <param name="moneyKindName">���햼��</param>
        /// <param name="moneyKindDiv">����敪</param>
        /// <param name="payment">�x�����z</param>
        /// <param name="validityTerm">�L������(YYYYMMDD)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="moneyKindDivName">����敪����</param>
        /// <returns>PaymentDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDtl�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PaymentDtl(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierFormal, Int32 paymentSlipNo, Int32 paymentRowNo, Int32 moneyKindCode, string moneyKindName, Int32 moneyKindDiv, Int64 payment, DateTime validityTerm, string enterpriseName, string updEmployeeName, string moneyKindDivName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierFormal = supplierFormal;
            this._paymentSlipNo = paymentSlipNo;
            this._paymentRowNo = paymentRowNo;
            this._moneyKindCode = moneyKindCode;
            this._moneyKindName = moneyKindName;
            this._moneyKindDiv = moneyKindDiv;
            this._payment = payment;
            this.ValidityTerm = validityTerm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._moneyKindDivName = moneyKindDivName;

        }

        /// <summary>
        /// �x�����׃f�[�^��������
        /// </summary>
        /// <returns>PaymentDtl�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PaymentDtl�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PaymentDtl Clone()
        {
            return new PaymentDtl(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierFormal, this._paymentSlipNo, this._paymentRowNo, this._moneyKindCode, this._moneyKindName, this._moneyKindDiv, this._payment, this._validityTerm, this._enterpriseName, this._updEmployeeName, this._moneyKindDivName);
        }

        /// <summary>
        /// �x�����׃f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PaymentDtl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDtl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PaymentDtl target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.PaymentSlipNo == target.PaymentSlipNo)
                 && (this.PaymentRowNo == target.PaymentRowNo)
                 && (this.MoneyKindCode == target.MoneyKindCode)
                 && (this.MoneyKindName == target.MoneyKindName)
                 && (this.MoneyKindDiv == target.MoneyKindDiv)
                 && (this.Payment == target.Payment)
                 && (this.ValidityTerm == target.ValidityTerm)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.MoneyKindDivName == target.MoneyKindDivName));
        }

        /// <summary>
        /// �x�����׃f�[�^��r����
        /// </summary>
        /// <param name="paymentDtl1">
        ///                    ��r����PaymentDtl�N���X�̃C���X�^���X
        /// </param>
        /// <param name="paymentDtl2">��r����PaymentDtl�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDtl�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PaymentDtl paymentDtl1, PaymentDtl paymentDtl2)
        {
            return ((paymentDtl1.CreateDateTime == paymentDtl2.CreateDateTime)
                 && (paymentDtl1.UpdateDateTime == paymentDtl2.UpdateDateTime)
                 && (paymentDtl1.EnterpriseCode == paymentDtl2.EnterpriseCode)
                 && (paymentDtl1.FileHeaderGuid == paymentDtl2.FileHeaderGuid)
                 && (paymentDtl1.UpdEmployeeCode == paymentDtl2.UpdEmployeeCode)
                 && (paymentDtl1.UpdAssemblyId1 == paymentDtl2.UpdAssemblyId1)
                 && (paymentDtl1.UpdAssemblyId2 == paymentDtl2.UpdAssemblyId2)
                 && (paymentDtl1.LogicalDeleteCode == paymentDtl2.LogicalDeleteCode)
                 && (paymentDtl1.SupplierFormal == paymentDtl2.SupplierFormal)
                 && (paymentDtl1.PaymentSlipNo == paymentDtl2.PaymentSlipNo)
                 && (paymentDtl1.PaymentRowNo == paymentDtl2.PaymentRowNo)
                 && (paymentDtl1.MoneyKindCode == paymentDtl2.MoneyKindCode)
                 && (paymentDtl1.MoneyKindName == paymentDtl2.MoneyKindName)
                 && (paymentDtl1.MoneyKindDiv == paymentDtl2.MoneyKindDiv)
                 && (paymentDtl1.Payment == paymentDtl2.Payment)
                 && (paymentDtl1.ValidityTerm == paymentDtl2.ValidityTerm)
                 && (paymentDtl1.EnterpriseName == paymentDtl2.EnterpriseName)
                 && (paymentDtl1.UpdEmployeeName == paymentDtl2.UpdEmployeeName)
                 && (paymentDtl1.MoneyKindDivName == paymentDtl2.MoneyKindDivName));
        }
        /// <summary>
        /// �x�����׃f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PaymentDtl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDtl�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PaymentDtl target)
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
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.PaymentSlipNo != target.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (this.PaymentRowNo != target.PaymentRowNo) resList.Add("PaymentRowNo");
            if (this.MoneyKindCode != target.MoneyKindCode) resList.Add("MoneyKindCode");
            if (this.MoneyKindName != target.MoneyKindName) resList.Add("MoneyKindName");
            if (this.MoneyKindDiv != target.MoneyKindDiv) resList.Add("MoneyKindDiv");
            if (this.Payment != target.Payment) resList.Add("Payment");
            if (this.ValidityTerm != target.ValidityTerm) resList.Add("ValidityTerm");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.MoneyKindDivName != target.MoneyKindDivName) resList.Add("MoneyKindDivName");

            return resList;
        }

        /// <summary>
        /// �x�����׃f�[�^��r����
        /// </summary>
        /// <param name="paymentDtl1">��r����PaymentDtl�N���X�̃C���X�^���X</param>
        /// <param name="paymentDtl2">��r����PaymentDtl�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentDtl�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PaymentDtl paymentDtl1, PaymentDtl paymentDtl2)
        {
            ArrayList resList = new ArrayList();
            if (paymentDtl1.CreateDateTime != paymentDtl2.CreateDateTime) resList.Add("CreateDateTime");
            if (paymentDtl1.UpdateDateTime != paymentDtl2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (paymentDtl1.EnterpriseCode != paymentDtl2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (paymentDtl1.FileHeaderGuid != paymentDtl2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (paymentDtl1.UpdEmployeeCode != paymentDtl2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (paymentDtl1.UpdAssemblyId1 != paymentDtl2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (paymentDtl1.UpdAssemblyId2 != paymentDtl2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (paymentDtl1.LogicalDeleteCode != paymentDtl2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (paymentDtl1.SupplierFormal != paymentDtl2.SupplierFormal) resList.Add("SupplierFormal");
            if (paymentDtl1.PaymentSlipNo != paymentDtl2.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (paymentDtl1.PaymentRowNo != paymentDtl2.PaymentRowNo) resList.Add("PaymentRowNo");
            if (paymentDtl1.MoneyKindCode != paymentDtl2.MoneyKindCode) resList.Add("MoneyKindCode");
            if (paymentDtl1.MoneyKindName != paymentDtl2.MoneyKindName) resList.Add("MoneyKindName");
            if (paymentDtl1.MoneyKindDiv != paymentDtl2.MoneyKindDiv) resList.Add("MoneyKindDiv");
            if (paymentDtl1.Payment != paymentDtl2.Payment) resList.Add("Payment");
            if (paymentDtl1.ValidityTerm != paymentDtl2.ValidityTerm) resList.Add("ValidityTerm");
            if (paymentDtl1.EnterpriseName != paymentDtl2.EnterpriseName) resList.Add("EnterpriseName");
            if (paymentDtl1.UpdEmployeeName != paymentDtl2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (paymentDtl1.MoneyKindDivName != paymentDtl2.MoneyKindDivName) resList.Add("MoneyKindDivName");

            return resList;
        }
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerChangeResult
    /// <summary>
    ///                      ���Ӑ�}�X�^�i�ϓ����j
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�}�X�^�i�ϓ����j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomerChangeResult
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

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�^�M�z</summary>
        /// <remarks>�f�b�h���C��</remarks>
        private Int64 _creditMoney;

        /// <summary>�x���^�M�z</summary>
        /// <remarks>�x���\���p</remarks>
        private Int64 _warningCreditMoney;

        /// <summary>���ݔ��|�c��</summary>
        /// <remarks>�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V</remarks>
        private Int64 _prsntAccRecBalance;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";


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

        /// public propaty name  :  CreditMoney
        /// <summary>�^�M�z�v���p�e�B</summary>
        /// <value>�f�b�h���C��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CreditMoney
        {
            get { return _creditMoney; }
            set { _creditMoney = value; }
        }

        /// public propaty name  :  WarningCreditMoney
        /// <summary>�x���^�M�z�v���p�e�B</summary>
        /// <value>�x���\���p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���^�M�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 WarningCreditMoney
        {
            get { return _warningCreditMoney; }
            set { _warningCreditMoney = value; }
        }

        /// public propaty name  :  PrsntAccRecBalance
        /// <summary>���ݔ��|�c���v���p�e�B</summary>
        /// <value>�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ݔ��|�c���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PrsntAccRecBalance
        {
            get { return _prsntAccRecBalance; }
            set { _prsntAccRecBalance = value; }
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


        /// <summary>
        /// ���Ӑ�}�X�^�i�ϓ����j�R���X�g���N�^
        /// </summary>
        /// <returns>CustomerChangeResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerChangeResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerChangeResult()
        {
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�ϓ����j�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="creditMoney">�^�M�z(�f�b�h���C��)</param>
        /// <param name="warningCreditMoney">�x���^�M�z(�x���\���p)</param>
        /// <param name="prsntAccRecBalance">���ݔ��|�c��(�����f�[�^�A����f�[�^�i���|�j��o�^����ꍇ�Ƀ��A���ɍX�V)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>CustomerChangeResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerChangeResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerChangeResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, Int64 creditMoney, Int64 warningCreditMoney, Int64 prsntAccRecBalance, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this._creditMoney = creditMoney;
            this._warningCreditMoney = warningCreditMoney;
            this._prsntAccRecBalance = prsntAccRecBalance;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�ϓ����j��������
        /// </summary>
        /// <returns>CustomerChangeResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustomerChangeResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustomerChangeResult Clone()
        {
            return new CustomerChangeResult(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._creditMoney, this._warningCreditMoney, this._prsntAccRecBalance, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�ϓ����j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerChangeResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustomerChangeResult target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CreditMoney == target.CreditMoney)
                 && (this.WarningCreditMoney == target.WarningCreditMoney)
                 && (this.PrsntAccRecBalance == target.PrsntAccRecBalance)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�ϓ����j��r����
        /// </summary>
        /// <param name="CustomerChangeResult1">
        ///                    ��r����CustomerChangeResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="CustomerChangeResult2">��r����CustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerChangeResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustomerChangeResult CustomerChangeResult1, CustomerChangeResult CustomerChangeResult2)
        {
            return ((CustomerChangeResult1.CreateDateTime == CustomerChangeResult2.CreateDateTime)
                 && (CustomerChangeResult1.UpdateDateTime == CustomerChangeResult2.UpdateDateTime)
                 && (CustomerChangeResult1.EnterpriseCode == CustomerChangeResult2.EnterpriseCode)
                 && (CustomerChangeResult1.FileHeaderGuid == CustomerChangeResult2.FileHeaderGuid)
                 && (CustomerChangeResult1.UpdEmployeeCode == CustomerChangeResult2.UpdEmployeeCode)
                 && (CustomerChangeResult1.UpdAssemblyId1 == CustomerChangeResult2.UpdAssemblyId1)
                 && (CustomerChangeResult1.UpdAssemblyId2 == CustomerChangeResult2.UpdAssemblyId2)
                 && (CustomerChangeResult1.LogicalDeleteCode == CustomerChangeResult2.LogicalDeleteCode)
                 && (CustomerChangeResult1.CustomerCode == CustomerChangeResult2.CustomerCode)
                 && (CustomerChangeResult1.CreditMoney == CustomerChangeResult2.CreditMoney)
                 && (CustomerChangeResult1.WarningCreditMoney == CustomerChangeResult2.WarningCreditMoney)
                 && (CustomerChangeResult1.PrsntAccRecBalance == CustomerChangeResult2.PrsntAccRecBalance)
                 && (CustomerChangeResult1.EnterpriseName == CustomerChangeResult2.EnterpriseName)
                 && (CustomerChangeResult1.UpdEmployeeName == CustomerChangeResult2.UpdEmployeeName));
        }
        /// <summary>
        /// ���Ӑ�}�X�^�i�ϓ����j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerChangeResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustomerChangeResult target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CreditMoney != target.CreditMoney) resList.Add("CreditMoney");
            if (this.WarningCreditMoney != target.WarningCreditMoney) resList.Add("WarningCreditMoney");
            if (this.PrsntAccRecBalance != target.PrsntAccRecBalance) resList.Add("PrsntAccRecBalance");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�ϓ����j��r����
        /// </summary>
        /// <param name="CustomerChangeResult1">��r����CustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <param name="CustomerChangeResult2">��r����CustomerChangeResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustomerChangeResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustomerChangeResult CustomerChangeResult1, CustomerChangeResult CustomerChangeResult2)
        {
            ArrayList resList = new ArrayList();
            if (CustomerChangeResult1.CreateDateTime != CustomerChangeResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (CustomerChangeResult1.UpdateDateTime != CustomerChangeResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (CustomerChangeResult1.EnterpriseCode != CustomerChangeResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (CustomerChangeResult1.FileHeaderGuid != CustomerChangeResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (CustomerChangeResult1.UpdEmployeeCode != CustomerChangeResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (CustomerChangeResult1.UpdAssemblyId1 != CustomerChangeResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (CustomerChangeResult1.UpdAssemblyId2 != CustomerChangeResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (CustomerChangeResult1.LogicalDeleteCode != CustomerChangeResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (CustomerChangeResult1.CustomerCode != CustomerChangeResult2.CustomerCode) resList.Add("CustomerCode");
            if (CustomerChangeResult1.CreditMoney != CustomerChangeResult2.CreditMoney) resList.Add("CreditMoney");
            if (CustomerChangeResult1.WarningCreditMoney != CustomerChangeResult2.WarningCreditMoney) resList.Add("WarningCreditMoney");
            if (CustomerChangeResult1.PrsntAccRecBalance != CustomerChangeResult2.PrsntAccRecBalance) resList.Add("PrsntAccRecBalance");
            if (CustomerChangeResult1.EnterpriseName != CustomerChangeResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (CustomerChangeResult1.UpdEmployeeName != CustomerChangeResult2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}

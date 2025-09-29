using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustSalesTarget
    /// <summary>
    ///                      ���Ӑ�ʔ���ڕW�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�ʔ���ڕW�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/28</br>
    /// <br>Genarated Date   :   2008/10/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustSalesTarget
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

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�ڕW�ݒ�敪</summary>
        /// <remarks>10�F���ԖڕW,20�F�ʊ��ԖڕW</remarks>
        private Int32 _targetSetCd;

        /// <summary>�ڕW�Δ�敪</summary>
        /// <remarks>10:���_,20:���_+����,21:���_+����+��,22:���_+�]�ƈ�,30:���_+���Ӑ�,31:���_+�Ǝ�,32:���_+�̔��ر,33:���_+�̔��ر+���Ӑ�,40:���_+Ұ��,41:���_+Ұ��+���i</remarks>
        private Int32 _targetContrastCd;

        /// <summary>�ڕW�敪�R�[�h</summary>
        /// <remarks>���ԖڕW�FYYYYMM�A�ʊ��ԖڕW�F�C�ӃR�[�h</remarks>
        private string _targetDivideCode = "";

        /// <summary>�ڕW�敪����</summary>
        private string _targetDivideName = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>����ڕW����</summary>
        private Double _salesTargetCount;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  TargetSetCd
        /// <summary>�ڕW�ݒ�敪�v���p�e�B</summary>
        /// <value>10�F���ԖڕW,20�F�ʊ��ԖڕW</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetSetCd
        {
            get { return _targetSetCd; }
            set { _targetSetCd = value; }
        }

        /// public propaty name  :  TargetContrastCd
        /// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
        /// <value>10:���_,20:���_+����,21:���_+����+��,22:���_+�]�ƈ�,30:���_+���Ӑ�,31:���_+�Ǝ�,32:���_+�̔��ر,33:���_+�̔��ر+���Ӑ�,40:���_+Ұ��,41:���_+Ұ��+���i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�Δ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get { return _targetContrastCd; }
            set { _targetContrastCd = value; }
        }

        /// public propaty name  :  TargetDivideCode
        /// <summary>�ڕW�敪�R�[�h�v���p�e�B</summary>
        /// <value>���ԖڕW�FYYYYMM�A�ʊ��ԖڕW�F�C�ӃR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TargetDivideCode
        {
            get { return _targetDivideCode; }
            set { _targetDivideCode = value; }
        }

        /// public propaty name  :  TargetDivideName
        /// <summary>�ڕW�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TargetDivideName
        {
            get { return _targetDivideName; }
            set { _targetDivideName = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
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

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyStaDateJpFormal
        /// <summary>�K�p�J�n�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyStaDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateJpInFormal
        /// <summary>�K�p�J�n�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyStaDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateAdFormal
        /// <summary>�K�p�J�n�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyStaDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateAdInFormal
        /// <summary>�K�p�J�n�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyStaDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  ApplyEndDateJpFormal
        /// <summary>�K�p�I���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyEndDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateJpInFormal
        /// <summary>�K�p�I���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyEndDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateAdFormal
        /// <summary>�K�p�I���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyEndDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateAdInFormal
        /// <summary>�K�p�I���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyEndDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount
        /// <summary>����ڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get { return _salesTargetCount; }
            set { _salesTargetCount = value; }
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

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }


        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>CustSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSalesTarget()
        {
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="targetSetCd">�ڕW�ݒ�敪(10�F���ԖڕW,20�F�ʊ��ԖڕW)</param>
        /// <param name="targetContrastCd">�ڕW�Δ�敪(10:���_,20:���_+����,21:���_+����+��,22:���_+�]�ƈ�,30:���_+���Ӑ�,31:���_+�Ǝ�,32:���_+�̔��ر,33:���_+�̔��ر+���Ӑ�,40:���_+Ұ��,41:���_+Ұ��+���i)</param>
        /// <param name="targetDivideCode">�ڕW�敪�R�[�h(���ԖڕW�FYYYYMM�A�ʊ��ԖڕW�F�C�ӃR�[�h)</param>
        /// <param name="targetDivideName">�ڕW�敪����</param>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <param name="salesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="applyStaDate">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="applyEndDate">�K�p�I����(YYYYMMDD)</param>
        /// <param name="salesTargetMoney">����ڕW���z</param>
        /// <param name="salesTargetProfit">����ڕW�e���z</param>
        /// <param name="salesTargetCount">����ڕW����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="businessTypeName">�Ǝ햼��</param>
        /// <returns>CustSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSalesTarget(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 targetSetCd, Int32 targetContrastCd, string targetDivideCode, string targetDivideName, Int32 businessTypeCode, Int32 salesAreaCode, Int32 customerCode, DateTime applyStaDate, DateTime applyEndDate, Int64 salesTargetMoney, Int64 salesTargetProfit, Double salesTargetCount, string enterpriseName, string updEmployeeName, string businessTypeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._targetSetCd = targetSetCd;
            this._targetContrastCd = targetContrastCd;
            this._targetDivideCode = targetDivideCode;
            this._targetDivideName = targetDivideName;
            this._businessTypeCode = businessTypeCode;
            this._salesAreaCode = salesAreaCode;
            this._customerCode = customerCode;
            this.ApplyStaDate = applyStaDate;
            this.ApplyEndDate = applyEndDate;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._businessTypeName = businessTypeName;

        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��������
        /// </summary>
        /// <returns>CustSalesTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustSalesTarget�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSalesTarget Clone()
        {
            return new CustSalesTarget(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._targetSetCd, this._targetContrastCd, this._targetDivideCode, this._targetDivideName, this._businessTypeCode, this._salesAreaCode, this._customerCode, this._applyStaDate, this._applyEndDate, this._salesTargetMoney, this._salesTargetProfit, this._salesTargetCount, this._enterpriseName, this._updEmployeeName, this._businessTypeName);
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustSalesTarget target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.TargetSetCd == target.TargetSetCd)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.TargetDivideCode == target.TargetDivideCode)
                 && (this.TargetDivideName == target.TargetDivideName)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BusinessTypeName == target.BusinessTypeName));
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="custSalesTarget1">
        ///                    ��r����CustSalesTarget�N���X�̃C���X�^���X
        /// </param>
        /// <param name="custSalesTarget2">��r����CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustSalesTarget custSalesTarget1, CustSalesTarget custSalesTarget2)
        {
            return ((custSalesTarget1.CreateDateTime == custSalesTarget2.CreateDateTime)
                 && (custSalesTarget1.UpdateDateTime == custSalesTarget2.UpdateDateTime)
                 && (custSalesTarget1.EnterpriseCode == custSalesTarget2.EnterpriseCode)
                 && (custSalesTarget1.FileHeaderGuid == custSalesTarget2.FileHeaderGuid)
                 && (custSalesTarget1.UpdEmployeeCode == custSalesTarget2.UpdEmployeeCode)
                 && (custSalesTarget1.UpdAssemblyId1 == custSalesTarget2.UpdAssemblyId1)
                 && (custSalesTarget1.UpdAssemblyId2 == custSalesTarget2.UpdAssemblyId2)
                 && (custSalesTarget1.LogicalDeleteCode == custSalesTarget2.LogicalDeleteCode)
                 && (custSalesTarget1.SectionCode == custSalesTarget2.SectionCode)
                 && (custSalesTarget1.TargetSetCd == custSalesTarget2.TargetSetCd)
                 && (custSalesTarget1.TargetContrastCd == custSalesTarget2.TargetContrastCd)
                 && (custSalesTarget1.TargetDivideCode == custSalesTarget2.TargetDivideCode)
                 && (custSalesTarget1.TargetDivideName == custSalesTarget2.TargetDivideName)
                 && (custSalesTarget1.BusinessTypeCode == custSalesTarget2.BusinessTypeCode)
                 && (custSalesTarget1.SalesAreaCode == custSalesTarget2.SalesAreaCode)
                 && (custSalesTarget1.CustomerCode == custSalesTarget2.CustomerCode)
                 && (custSalesTarget1.ApplyStaDate == custSalesTarget2.ApplyStaDate)
                 && (custSalesTarget1.ApplyEndDate == custSalesTarget2.ApplyEndDate)
                 && (custSalesTarget1.SalesTargetMoney == custSalesTarget2.SalesTargetMoney)
                 && (custSalesTarget1.SalesTargetProfit == custSalesTarget2.SalesTargetProfit)
                 && (custSalesTarget1.SalesTargetCount == custSalesTarget2.SalesTargetCount)
                 && (custSalesTarget1.EnterpriseName == custSalesTarget2.EnterpriseName)
                 && (custSalesTarget1.UpdEmployeeName == custSalesTarget2.UpdEmployeeName)
                 && (custSalesTarget1.BusinessTypeName == custSalesTarget2.BusinessTypeName));
        }
        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesTarget�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustSalesTarget target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.TargetSetCd != target.TargetSetCd) resList.Add("TargetSetCd");
            if (this.TargetContrastCd != target.TargetContrastCd) resList.Add("TargetContrastCd");
            if (this.TargetDivideCode != target.TargetDivideCode) resList.Add("TargetDivideCode");
            if (this.TargetDivideName != target.TargetDivideName) resList.Add("TargetDivideName");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�ʔ���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="custSalesTarget1">��r����CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <param name="custSalesTarget2">��r����CustSalesTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSalesTarget�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustSalesTarget custSalesTarget1, CustSalesTarget custSalesTarget2)
        {
            ArrayList resList = new ArrayList();
            if (custSalesTarget1.CreateDateTime != custSalesTarget2.CreateDateTime) resList.Add("CreateDateTime");
            if (custSalesTarget1.UpdateDateTime != custSalesTarget2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (custSalesTarget1.EnterpriseCode != custSalesTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custSalesTarget1.FileHeaderGuid != custSalesTarget2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (custSalesTarget1.UpdEmployeeCode != custSalesTarget2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (custSalesTarget1.UpdAssemblyId1 != custSalesTarget2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (custSalesTarget1.UpdAssemblyId2 != custSalesTarget2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (custSalesTarget1.LogicalDeleteCode != custSalesTarget2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (custSalesTarget1.SectionCode != custSalesTarget2.SectionCode) resList.Add("SectionCode");
            if (custSalesTarget1.TargetSetCd != custSalesTarget2.TargetSetCd) resList.Add("TargetSetCd");
            if (custSalesTarget1.TargetContrastCd != custSalesTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (custSalesTarget1.TargetDivideCode != custSalesTarget2.TargetDivideCode) resList.Add("TargetDivideCode");
            if (custSalesTarget1.TargetDivideName != custSalesTarget2.TargetDivideName) resList.Add("TargetDivideName");
            if (custSalesTarget1.BusinessTypeCode != custSalesTarget2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (custSalesTarget1.SalesAreaCode != custSalesTarget2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (custSalesTarget1.CustomerCode != custSalesTarget2.CustomerCode) resList.Add("CustomerCode");
            if (custSalesTarget1.ApplyStaDate != custSalesTarget2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (custSalesTarget1.ApplyEndDate != custSalesTarget2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (custSalesTarget1.SalesTargetMoney != custSalesTarget2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (custSalesTarget1.SalesTargetProfit != custSalesTarget2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (custSalesTarget1.SalesTargetCount != custSalesTarget2.SalesTargetCount) resList.Add("SalesTargetCount");
            if (custSalesTarget1.EnterpriseName != custSalesTarget2.EnterpriseName) resList.Add("EnterpriseName");
            if (custSalesTarget1.UpdEmployeeName != custSalesTarget2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (custSalesTarget1.BusinessTypeName != custSalesTarget2.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PayDraftData
    /// <summary>
    ///                      �x����`�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x����`�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2010/04/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/10  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �J���[�R�[�h</br>
    /// <br>                 :   �J���[����1</br>
    /// <br>                 :   �g�����R�[�h</br>
    /// <br>                 :   �g��������</br>
    /// <br>Update Note      :   2008/6/30  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �����I�u�W�F�N�g�z��</br>
    /// <br>Update Note      :   2008/7/8  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �����@�^���i�G���W���j</br>
    /// <br>Update Note      :   2008/9/19  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   ���[�J�[���p����</br>
    /// <br>                 :   �Ԏ피�p����</br>
    /// <br>Update Note      :   2008/12/17  ����</br>
    /// <br>                 :   ���ڏC���i�m�t�k�k���ɕύX�j</br>
    /// <br>                 :   �^���i�ޕʋL���j�A�^���i�t���^�j</br>
    /// <br>Update Note      :   2009/9/1  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �@���q�ǉ����P</br>
    /// <br>                 :   �@���q�ǉ����Q</br>
    /// <br>                 :   �@���q���l</br>
    /// </remarks>
    public class PayDraftData
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

        /// <summary>�x����`�ԍ�</summary>
        private string _payDraftNo = "";

        /// <summary>��`���</summary>
        /// <remarks>0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����</remarks>
        private Int32 _draftKindCd;

        /// <summary>��`�敪</summary>
        /// <remarks>0:���U 1:���U�@���������U�敪</remarks>
        private Int32 _draftDivide;

        /// <summary>�x�����z</summary>
        private Int64 _payment;

        /// <summary>��s�E�x�X�R�[�h</summary>
        /// <remarks>��4����s���ޤ��3���x�X����</remarks>
        private Int32 _bankAndBranchCd;

        /// <summary>��s�E�x�X����</summary>
        private string _bankAndBranchNm = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>���q�ł���`�ް����쐬�Ȃ̂ŕK�v</remarks>
        private string _addUpSecCode = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        private string _supplierNm2 = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _procDate;

        /// <summary>��`�U�o��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>�L������</summary>
        /// <remarks>YYYYMMDD�@�������A�������Ƃ��Ďg�p</remarks>
        private Int32 _validityTerm;

        /// <summary>��`���ϓ�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _draftStmntDate;

        /// <summary>�`�[�E�v1</summary>
        private string _outline1 = "";

        /// <summary>�`�[�E�v2</summary>
        private string _outline2 = "";

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�x���`�[�ԍ�</summary>
        private Int32 _paymentSlipNo;

        /// <summary>�x���s�ԍ�</summary>
        /// <remarks>���x���ݒ�����ޢ��`��̐ݒ�ԍ����</remarks>
        private Int32 _paymentRowNo;

        /// <summary>�x�����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _paymentDate;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";


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

        /// public propaty name  :  PayDraftNo
        /// <summary>�x����`�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����`�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayDraftNo
        {
            get { return _payDraftNo; }
            set { _payDraftNo = value; }
        }

        /// public propaty name  :  DraftKindCd
        /// <summary>��`��ʃv���p�e�B</summary>
        /// <value>0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftKindCd
        {
            get { return _draftKindCd; }
            set { _draftKindCd = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>��`�敪�v���p�e�B</summary>
        /// <value>0:���U 1:���U�@���������U�敪</value>
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

        /// public propaty name  :  BankAndBranchCd
        /// <summary>��s�E�x�X�R�[�h�v���p�e�B</summary>
        /// <value>��4����s���ޤ��3���x�X����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�E�x�X�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BankAndBranchCd
        {
            get { return _bankAndBranchCd; }
            set { _bankAndBranchCd = value; }
        }

        /// public propaty name  :  BankAndBranchNm
        /// <summary>��s�E�x�X���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�E�x�X���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BankAndBranchNm
        {
            get { return _bankAndBranchNm; }
            set { _bankAndBranchNm = value; }
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

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���q�ł���`�ް����쐬�Ȃ̂ŕK�v</value>
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

        /// public propaty name  :  ProcDate
        /// <summary>�������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDate
        {
            get { return _procDate; }
            set { _procDate = value; }
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

        /// public propaty name  :  ValidityTerm
        /// <summary>�L�������v���p�e�B</summary>
        /// <value>YYYYMMDD�@�������A�������Ƃ��Ďg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }

        /// public propaty name  :  DraftStmntDate
        /// <summary>��`���ϓ��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`���ϓ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftStmntDate
        {
            get { return _draftStmntDate; }
            set { _draftStmntDate = value; }
        }

        /// public propaty name  :  Outline1
        /// <summary>�`�[�E�v1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Outline1
        {
            get { return _outline1; }
            set { _outline1 = value; }
        }

        /// public propaty name  :  Outline2
        /// <summary>�`�[�E�v2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Outline2
        {
            get { return _outline2; }
            set { _outline2 = value; }
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
        /// <value>���x���ݒ�����ޢ��`��̐ݒ�ԍ����</value>
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


        /// <summary>
        /// �x����`�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>PayDraftData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PayDraftData()
        {
        }

        /// <summary>
        /// �x����`�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="payDraftNo">�x����`�ԍ�</param>
        /// <param name="draftKindCd">��`���(0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����)</param>
        /// <param name="draftDivide">��`�敪(0:���U 1:���U�@���������U�敪)</param>
        /// <param name="payment">�x�����z</param>
        /// <param name="bankAndBranchCd">��s�E�x�X�R�[�h(��4����s���ޤ��3���x�X����)</param>
        /// <param name="bankAndBranchNm">��s�E�x�X����</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(���q�ł���`�ް����쐬�Ȃ̂ŕK�v)</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierNm1">�d���於1</param>
        /// <param name="supplierNm2">�d���於2</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <param name="procDate">������(YYYYMMDD)</param>
        /// <param name="draftDrawingDate">��`�U�o��(YYYYMMDD)</param>
        /// <param name="validityTerm">�L������(YYYYMMDD�@�������A�������Ƃ��Ďg�p)</param>
        /// <param name="draftStmntDate">��`���ϓ�(YYYYMMDD)</param>
        /// <param name="outline1">�`�[�E�v1</param>
        /// <param name="outline2">�`�[�E�v2</param>
        /// <param name="supplierFormal">�d���`��(0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="paymentSlipNo">�x���`�[�ԍ�</param>
        /// <param name="paymentRowNo">�x���s�ԍ�(���x���ݒ�����ޢ��`��̐ݒ�ԍ����)</param>
        /// <param name="paymentDate">�x�����t(YYYYMMDD)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <returns>PayDraftData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PayDraftData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string payDraftNo, Int32 draftKindCd, Int32 draftDivide, Int64 payment, Int32 bankAndBranchCd, string bankAndBranchNm, string sectionCode, string addUpSecCode, Int32 supplierCd, string supplierNm1, string supplierNm2, string supplierSnm, Int32 procDate, DateTime draftDrawingDate, Int32 validityTerm, Int32 draftStmntDate, string outline1, string outline2, Int32 supplierFormal, Int32 paymentSlipNo, Int32 paymentRowNo, DateTime paymentDate, string enterpriseName, string updEmployeeName, string addUpSecName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._payDraftNo = payDraftNo;
            this._draftKindCd = draftKindCd;
            this._draftDivide = draftDivide;
            this._payment = payment;
            this._bankAndBranchCd = bankAndBranchCd;
            this._bankAndBranchNm = bankAndBranchNm;
            this._sectionCode = sectionCode;
            this._addUpSecCode = addUpSecCode;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierNm2 = supplierNm2;
            this._supplierSnm = supplierSnm;
            this._procDate = procDate;
            this.DraftDrawingDate = draftDrawingDate;
            this._validityTerm = validityTerm;
            this._draftStmntDate = draftStmntDate;
            this._outline1 = outline1;
            this._outline2 = outline2;
            this._supplierFormal = supplierFormal;
            this._paymentSlipNo = paymentSlipNo;
            this._paymentRowNo = paymentRowNo;
            this.PaymentDate = paymentDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// �x����`�f�[�^��������
        /// </summary>
        /// <returns>PayDraftData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PayDraftData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PayDraftData Clone()
        {
            return new PayDraftData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._payDraftNo, this._draftKindCd, this._draftDivide, this._payment, this._bankAndBranchCd, this._bankAndBranchNm, this._sectionCode, this._addUpSecCode, this._supplierCd, this._supplierNm1, this._supplierNm2, this._supplierSnm, this._procDate, this._draftDrawingDate, this._validityTerm, this._draftStmntDate, this._outline1, this._outline2, this._supplierFormal, this._paymentSlipNo, this._paymentRowNo, this._paymentDate, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
        }

        /// <summary>
        /// �x����`�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PayDraftData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PayDraftData target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.PayDraftNo == target.PayDraftNo)
                 && (this.DraftKindCd == target.DraftKindCd)
                 && (this.DraftDivide == target.DraftDivide)
                 && (this.Payment == target.Payment)
                 && (this.BankAndBranchCd == target.BankAndBranchCd)
                 && (this.BankAndBranchNm == target.BankAndBranchNm)
                 && (this.SectionCode == target.SectionCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierNm1 == target.SupplierNm1)
                 && (this.SupplierNm2 == target.SupplierNm2)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.ProcDate == target.ProcDate)
                 && (this.DraftDrawingDate == target.DraftDrawingDate)
                 && (this.ValidityTerm == target.ValidityTerm)
                 && (this.DraftStmntDate == target.DraftStmntDate)
                 && (this.Outline1 == target.Outline1)
                 && (this.Outline2 == target.Outline2)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.PaymentSlipNo == target.PaymentSlipNo)
                 && (this.PaymentRowNo == target.PaymentRowNo)
                 && (this.PaymentDate == target.PaymentDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// �x����`�f�[�^��r����
        /// </summary>
        /// <param name="payDraftData1">
        ///                    ��r����PayDraftData�N���X�̃C���X�^���X
        /// </param>
        /// <param name="payDraftData2">��r����PayDraftData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PayDraftData payDraftData1, PayDraftData payDraftData2)
        {
            return ((payDraftData1.CreateDateTime == payDraftData2.CreateDateTime)
                 && (payDraftData1.UpdateDateTime == payDraftData2.UpdateDateTime)
                 && (payDraftData1.EnterpriseCode == payDraftData2.EnterpriseCode)
                 && (payDraftData1.FileHeaderGuid == payDraftData2.FileHeaderGuid)
                 && (payDraftData1.UpdEmployeeCode == payDraftData2.UpdEmployeeCode)
                 && (payDraftData1.UpdAssemblyId1 == payDraftData2.UpdAssemblyId1)
                 && (payDraftData1.UpdAssemblyId2 == payDraftData2.UpdAssemblyId2)
                 && (payDraftData1.LogicalDeleteCode == payDraftData2.LogicalDeleteCode)
                 && (payDraftData1.PayDraftNo == payDraftData2.PayDraftNo)
                 && (payDraftData1.DraftKindCd == payDraftData2.DraftKindCd)
                 && (payDraftData1.DraftDivide == payDraftData2.DraftDivide)
                 && (payDraftData1.Payment == payDraftData2.Payment)
                 && (payDraftData1.BankAndBranchCd == payDraftData2.BankAndBranchCd)
                 && (payDraftData1.BankAndBranchNm == payDraftData2.BankAndBranchNm)
                 && (payDraftData1.SectionCode == payDraftData2.SectionCode)
                 && (payDraftData1.AddUpSecCode == payDraftData2.AddUpSecCode)
                 && (payDraftData1.SupplierCd == payDraftData2.SupplierCd)
                 && (payDraftData1.SupplierNm1 == payDraftData2.SupplierNm1)
                 && (payDraftData1.SupplierNm2 == payDraftData2.SupplierNm2)
                 && (payDraftData1.SupplierSnm == payDraftData2.SupplierSnm)
                 && (payDraftData1.ProcDate == payDraftData2.ProcDate)
                 && (payDraftData1.DraftDrawingDate == payDraftData2.DraftDrawingDate)
                 && (payDraftData1.ValidityTerm == payDraftData2.ValidityTerm)
                 && (payDraftData1.DraftStmntDate == payDraftData2.DraftStmntDate)
                 && (payDraftData1.Outline1 == payDraftData2.Outline1)
                 && (payDraftData1.Outline2 == payDraftData2.Outline2)
                 && (payDraftData1.SupplierFormal == payDraftData2.SupplierFormal)
                 && (payDraftData1.PaymentSlipNo == payDraftData2.PaymentSlipNo)
                 && (payDraftData1.PaymentRowNo == payDraftData2.PaymentRowNo)
                 && (payDraftData1.PaymentDate == payDraftData2.PaymentDate)
                 && (payDraftData1.EnterpriseName == payDraftData2.EnterpriseName)
                 && (payDraftData1.UpdEmployeeName == payDraftData2.UpdEmployeeName)
                 && (payDraftData1.AddUpSecName == payDraftData2.AddUpSecName));
        }
        /// <summary>
        /// �x����`�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PayDraftData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PayDraftData target)
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
            if (this.PayDraftNo != target.PayDraftNo) resList.Add("PayDraftNo");
            if (this.DraftKindCd != target.DraftKindCd) resList.Add("DraftKindCd");
            if (this.DraftDivide != target.DraftDivide) resList.Add("DraftDivide");
            if (this.Payment != target.Payment) resList.Add("Payment");
            if (this.BankAndBranchCd != target.BankAndBranchCd) resList.Add("BankAndBranchCd");
            if (this.BankAndBranchNm != target.BankAndBranchNm) resList.Add("BankAndBranchNm");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierNm1 != target.SupplierNm1) resList.Add("SupplierNm1");
            if (this.SupplierNm2 != target.SupplierNm2) resList.Add("SupplierNm2");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.ProcDate != target.ProcDate) resList.Add("ProcDate");
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (this.ValidityTerm != target.ValidityTerm) resList.Add("ValidityTerm");
            if (this.DraftStmntDate != target.DraftStmntDate) resList.Add("DraftStmntDate");
            if (this.Outline1 != target.Outline1) resList.Add("Outline1");
            if (this.Outline2 != target.Outline2) resList.Add("Outline2");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.PaymentSlipNo != target.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (this.PaymentRowNo != target.PaymentRowNo) resList.Add("PaymentRowNo");
            if (this.PaymentDate != target.PaymentDate) resList.Add("PaymentDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// �x����`�f�[�^��r����
        /// </summary>
        /// <param name="payDraftData1">��r����PayDraftData�N���X�̃C���X�^���X</param>
        /// <param name="payDraftData2">��r����PayDraftData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PayDraftData payDraftData1, PayDraftData payDraftData2)
        {
            ArrayList resList = new ArrayList();
            if (payDraftData1.CreateDateTime != payDraftData2.CreateDateTime) resList.Add("CreateDateTime");
            if (payDraftData1.UpdateDateTime != payDraftData2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (payDraftData1.EnterpriseCode != payDraftData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (payDraftData1.FileHeaderGuid != payDraftData2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (payDraftData1.UpdEmployeeCode != payDraftData2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (payDraftData1.UpdAssemblyId1 != payDraftData2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (payDraftData1.UpdAssemblyId2 != payDraftData2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (payDraftData1.LogicalDeleteCode != payDraftData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (payDraftData1.PayDraftNo != payDraftData2.PayDraftNo) resList.Add("PayDraftNo");
            if (payDraftData1.DraftKindCd != payDraftData2.DraftKindCd) resList.Add("DraftKindCd");
            if (payDraftData1.DraftDivide != payDraftData2.DraftDivide) resList.Add("DraftDivide");
            if (payDraftData1.Payment != payDraftData2.Payment) resList.Add("Payment");
            if (payDraftData1.BankAndBranchCd != payDraftData2.BankAndBranchCd) resList.Add("BankAndBranchCd");
            if (payDraftData1.BankAndBranchNm != payDraftData2.BankAndBranchNm) resList.Add("BankAndBranchNm");
            if (payDraftData1.SectionCode != payDraftData2.SectionCode) resList.Add("SectionCode");
            if (payDraftData1.AddUpSecCode != payDraftData2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (payDraftData1.SupplierCd != payDraftData2.SupplierCd) resList.Add("SupplierCd");
            if (payDraftData1.SupplierNm1 != payDraftData2.SupplierNm1) resList.Add("SupplierNm1");
            if (payDraftData1.SupplierNm2 != payDraftData2.SupplierNm2) resList.Add("SupplierNm2");
            if (payDraftData1.SupplierSnm != payDraftData2.SupplierSnm) resList.Add("SupplierSnm");
            if (payDraftData1.ProcDate != payDraftData2.ProcDate) resList.Add("ProcDate");
            if (payDraftData1.DraftDrawingDate != payDraftData2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (payDraftData1.ValidityTerm != payDraftData2.ValidityTerm) resList.Add("ValidityTerm");
            if (payDraftData1.DraftStmntDate != payDraftData2.DraftStmntDate) resList.Add("DraftStmntDate");
            if (payDraftData1.Outline1 != payDraftData2.Outline1) resList.Add("Outline1");
            if (payDraftData1.Outline2 != payDraftData2.Outline2) resList.Add("Outline2");
            if (payDraftData1.SupplierFormal != payDraftData2.SupplierFormal) resList.Add("SupplierFormal");
            if (payDraftData1.PaymentSlipNo != payDraftData2.PaymentSlipNo) resList.Add("PaymentSlipNo");
            if (payDraftData1.PaymentRowNo != payDraftData2.PaymentRowNo) resList.Add("PaymentRowNo");
            if (payDraftData1.PaymentDate != payDraftData2.PaymentDate) resList.Add("PaymentDate");
            if (payDraftData1.EnterpriseName != payDraftData2.EnterpriseName) resList.Add("EnterpriseName");
            if (payDraftData1.UpdEmployeeName != payDraftData2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (payDraftData1.AddUpSecName != payDraftData2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}

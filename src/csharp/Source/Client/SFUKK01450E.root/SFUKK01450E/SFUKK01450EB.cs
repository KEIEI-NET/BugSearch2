using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchDepositAlw
    /// <summary>
    ///                      �������������f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �������������f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/10/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2007/06/26 30414 �E �K�j Partsman�p�ɕύX</br>
    /// </remarks>
    public class SearchDepositAlw
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

        /// <summary>�������͋��_�R�[�h</summary>
        /// <remarks>�������͂������_�R�[�h</remarks>
        private string _inputDepositSecCd = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";

        /// <summary>�����ݓ�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _reconcileDate;

        /// <summary>�����݌v���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _reconcileAddUpDate;

        /// <summary>�����`�[�ԍ�</summary>
        private Int32 _depositSlipNo;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>��������R�[�h</summary>
        private Int32 _depositKindCode;

        /// <summary>�������햼��</summary>
        private string _depositKindName = "";
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

        /// <summary>���������z</summary>
        private Int64 _depositAllowance;

        /// <summary>�����S���҃R�[�h</summary>
        private string _depositAgentCode = "";

        /// <summary>�����S���Җ���</summary>
        private string _depositAgentNm = "";

        /// <summary>������R�[�h</summary>
        private Int32 _claimCode;

        /// <summary>�����於��</summary>
        private string _claimName = "";

        /// <summary>�����於��2</summary>
        private string _claimName2 = "";

        /// <summary>�����旪��</summary>
        private string _claimSnm = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�ԓ`���E�敪</summary>
        /// <remarks>0:��,1:��,2:���E�ςݍ�</remarks>
        private Int32 _debitNoteOffSetCd;

        /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
        /// <summary>�a����敪</summary>
        /// <remarks>0:�ʏ����,1:�a�������</remarks>
        private Int32 _depositCd;
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// public propaty name  :  ReconcileDate
        /// <summary>�����ݓ��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݓ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ReconcileDate
        {
            get { return _reconcileDate; }
            set { _reconcileDate = value; }
        }

        /// public propaty name  :  ReconcileDateJpFormal
        /// <summary>�����ݓ� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݓ� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReconcileDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _reconcileDate); }
            set { }
        }

        /// public propaty name  :  ReconcileDateJpInFormal
        /// <summary>�����ݓ� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݓ� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReconcileDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _reconcileDate); }
            set { }
        }

        /// public propaty name  :  ReconcileDateAdFormal
        /// <summary>�����ݓ� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݓ� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReconcileDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _reconcileDate); }
            set { }
        }

        /// public propaty name  :  ReconcileDateAdInFormal
        /// <summary>�����ݓ� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ݓ� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReconcileDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _reconcileDate); }
            set { }
        }

        /// public propaty name  :  ReconcileAddUpDate
        /// <summary>�����݌v����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����݌v����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ReconcileAddUpDate
        {
            get { return _reconcileAddUpDate; }
            set { _reconcileAddUpDate = value; }
        }

        /// public propaty name  :  ReconcileAddUpDateJpFormal
        /// <summary>�����݌v��� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����݌v��� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReconcileAddUpDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _reconcileAddUpDate); }
            set { }
        }

        /// public propaty name  :  ReconcileAddUpDateJpInFormal
        /// <summary>�����݌v��� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����݌v��� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReconcileAddUpDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _reconcileAddUpDate); }
            set { }
        }

        /// public propaty name  :  ReconcileAddUpDateAdFormal
        /// <summary>�����݌v��� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����݌v��� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReconcileAddUpDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _reconcileAddUpDate); }
            set { }
        }

        /// public propaty name  :  ReconcileAddUpDateAdInFormal
        /// <summary>�����݌v��� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����݌v��� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ReconcileAddUpDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _reconcileAddUpDate); }
            set { }
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
           --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/

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

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  DebitNoteOffSetCd
        /// <summary>�ԓ`���E�敪�v���p�e�B</summary>
        /// <value>0:��,1:��,2:���E�ςݍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`���E�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DebitNoteOffSetCd
        {
            get { return _debitNoteOffSetCd; }
            set { _debitNoteOffSetCd = value; }
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
        /// �������������f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>SearchDepositAlw�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepositAlw�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchDepositAlw()
        {
        }

        /// <summary>
        /// �������������f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inputDepositSecCd">�������͋��_�R�[�h(�������͂������_�R�[�h)</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="reconcileDate">�����ݓ�(YYYYMMDD)</param>
        /// <param name="reconcileAddUpDate">�����݌v���(YYYYMMDD)</param>
        /// <param name="depositSlipNo">�����`�[�ԍ�</param>
        /// <param name="depositAllowance">���������z</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
        /// <param name="depositAgentNm">�����S���Җ���</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="claimName">�����於��</param>
        /// <param name="claimName2">�����於��2</param>
        /// <param name="claimSnm">�����旪��</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="debitNoteOffSetCd">�ԓ`���E�敪(0:��,1:��,2:���E�ςݍ�)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <returns>SearchDepositAlw�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepositAlw�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
        //public SearchDepositAlw(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inputDepositSecCd, string addUpSecCode, Int32 acptAnOdrStatus, string salesSlipNum, DateTime reconcileDate, DateTime reconcileAddUpDate, Int32 depositSlipNo, Int32 depositKindCode, string depositKindName, Int64 depositAllowance, string depositAgentCode, string depositAgentNm, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 debitNoteOffSetCd, Int32 depositCd, string enterpriseName, string updEmployeeName, string addUpSecName)
        public SearchDepositAlw(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inputDepositSecCd, string addUpSecCode, Int32 acptAnOdrStatus, string salesSlipNum, DateTime reconcileDate, DateTime reconcileAddUpDate, Int32 depositSlipNo, Int64 depositAllowance, string depositAgentCode, string depositAgentNm, Int32 claimCode, string claimName, string claimName2, string claimSnm, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 debitNoteOffSetCd, string enterpriseName, string updEmployeeName, string addUpSecName)
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
            this._inputDepositSecCd = inputDepositSecCd;
            this._addUpSecCode = addUpSecCode;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._salesSlipNum = salesSlipNum;
            this.ReconcileDate = reconcileDate;
            this.ReconcileAddUpDate = reconcileAddUpDate;
            this._depositSlipNo = depositSlipNo;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._depositKindCode = depositKindCode;
            this._depositKindName = depositKindName;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._depositAllowance = depositAllowance;
            this._depositAgentCode = depositAgentCode;
            this._depositAgentNm = depositAgentNm;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._debitNoteOffSetCd = debitNoteOffSetCd;
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            this._depositCd = depositCd;
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// �������������f�[�^��������
        /// </summary>
        /// <returns>SearchDepositAlw�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SearchDepositAlw�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SearchDepositAlw Clone()
        {
            // --- CHG 2008/06/26 --------------------------------------------------------------------->>>>>
            //return new SearchDepositAlw(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inputDepositSecCd, this._addUpSecCode, this._acptAnOdrStatus, this._salesSlipNum, this._reconcileDate, this._reconcileAddUpDate, this._depositSlipNo, this._depositKindCode, this._depositKindName, this._depositAllowance, this._depositAgentCode, this._depositAgentNm, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._debitNoteOffSetCd, this._depositCd, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
            return new SearchDepositAlw(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inputDepositSecCd, this._addUpSecCode, this._acptAnOdrStatus, this._salesSlipNum, this._reconcileDate, this._reconcileAddUpDate, this._depositSlipNo, this._depositAllowance, this._depositAgentCode, this._depositAgentNm, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._debitNoteOffSetCd, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
            // --- CHG 2008/06/26 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// �������������f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchDepositAlw�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepositAlw�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SearchDepositAlw target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InputDepositSecCd == target.InputDepositSecCd)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.ReconcileDate == target.ReconcileDate)
                 && (this.ReconcileAddUpDate == target.ReconcileAddUpDate)
                 && (this.DepositSlipNo == target.DepositSlipNo)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (this.DepositKindCode == target.DepositKindCode)
                && (this.DepositKindName == target.DepositKindName)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                && (this.DepositAllowance == target.DepositAllowance)
                && (this.DepositAgentCode == target.DepositAgentCode)
                && (this.DepositAgentNm == target.DepositAgentNm)
                && (this.ClaimCode == target.ClaimCode)
                && (this.ClaimName == target.ClaimName)
                && (this.ClaimName2 == target.ClaimName2)
                && (this.ClaimSnm == target.ClaimSnm)
                && (this.CustomerCode == target.CustomerCode)
                && (this.CustomerName == target.CustomerName)
                && (this.CustomerName2 == target.CustomerName2)
                && (this.CustomerSnm == target.CustomerSnm)
                && (this.DebitNoteOffSetCd == target.DebitNoteOffSetCd)
               /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
               && (this.DepositCd == target.DepositCd)
                  --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// �������������f�[�^��r����
        /// </summary>
        /// <param name="searchDepositAlw1">
        ///                    ��r����SearchDepositAlw�N���X�̃C���X�^���X
        /// </param>
        /// <param name="searchDepositAlw2">��r����SearchDepositAlw�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepositAlw�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SearchDepositAlw searchDepositAlw1, SearchDepositAlw searchDepositAlw2)
        {
            return ((searchDepositAlw1.CreateDateTime == searchDepositAlw2.CreateDateTime)
                 && (searchDepositAlw1.UpdateDateTime == searchDepositAlw2.UpdateDateTime)
                 && (searchDepositAlw1.EnterpriseCode == searchDepositAlw2.EnterpriseCode)
                 && (searchDepositAlw1.FileHeaderGuid == searchDepositAlw2.FileHeaderGuid)
                 && (searchDepositAlw1.UpdEmployeeCode == searchDepositAlw2.UpdEmployeeCode)
                 && (searchDepositAlw1.UpdAssemblyId1 == searchDepositAlw2.UpdAssemblyId1)
                 && (searchDepositAlw1.UpdAssemblyId2 == searchDepositAlw2.UpdAssemblyId2)
                 && (searchDepositAlw1.LogicalDeleteCode == searchDepositAlw2.LogicalDeleteCode)
                 && (searchDepositAlw1.InputDepositSecCd == searchDepositAlw2.InputDepositSecCd)
                 && (searchDepositAlw1.AddUpSecCode == searchDepositAlw2.AddUpSecCode)
                 && (searchDepositAlw1.AcptAnOdrStatus == searchDepositAlw2.AcptAnOdrStatus)
                 && (searchDepositAlw1.SalesSlipNum == searchDepositAlw2.SalesSlipNum)
                 && (searchDepositAlw1.ReconcileDate == searchDepositAlw2.ReconcileDate)
                 && (searchDepositAlw1.ReconcileAddUpDate == searchDepositAlw2.ReconcileAddUpDate)
                 && (searchDepositAlw1.DepositSlipNo == searchDepositAlw2.DepositSlipNo)
                /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
                && (searchDepositAlw1.DepositKindCode == searchDepositAlw2.DepositKindCode)
                && (searchDepositAlw1.DepositKindName == searchDepositAlw2.DepositKindName)
                   --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                && (searchDepositAlw1.DepositAllowance == searchDepositAlw2.DepositAllowance)
                && (searchDepositAlw1.DepositAgentCode == searchDepositAlw2.DepositAgentCode)
                && (searchDepositAlw1.DepositAgentNm == searchDepositAlw2.DepositAgentNm)
                && (searchDepositAlw1.ClaimCode == searchDepositAlw2.ClaimCode)
                && (searchDepositAlw1.ClaimName == searchDepositAlw2.ClaimName)
                && (searchDepositAlw1.ClaimName2 == searchDepositAlw2.ClaimName2)
                && (searchDepositAlw1.ClaimSnm == searchDepositAlw2.ClaimSnm)
                && (searchDepositAlw1.CustomerCode == searchDepositAlw2.CustomerCode)
                && (searchDepositAlw1.CustomerName == searchDepositAlw2.CustomerName)
                && (searchDepositAlw1.CustomerName2 == searchDepositAlw2.CustomerName2)
                && (searchDepositAlw1.CustomerSnm == searchDepositAlw2.CustomerSnm)
                && (searchDepositAlw1.DebitNoteOffSetCd == searchDepositAlw2.DebitNoteOffSetCd)
               /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
               && (searchDepositAlw1.DepositCd == searchDepositAlw2.DepositCd)
                  --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
                 && (searchDepositAlw1.EnterpriseName == searchDepositAlw2.EnterpriseName)
                 && (searchDepositAlw1.UpdEmployeeName == searchDepositAlw2.UpdEmployeeName)
                 && (searchDepositAlw1.AddUpSecName == searchDepositAlw2.AddUpSecName));
        }
        /// <summary>
        /// �������������f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SearchDepositAlw�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepositAlw�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SearchDepositAlw target)
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
            if (this.InputDepositSecCd != target.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.ReconcileDate != target.ReconcileDate) resList.Add("ReconcileDate");
            if (this.ReconcileAddUpDate != target.ReconcileAddUpDate) resList.Add("ReconcileAddUpDate");
            if (this.DepositSlipNo != target.DepositSlipNo) resList.Add("DepositSlipNo");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DepositKindCode != target.DepositKindCode) resList.Add("DepositKindCode");
            if (this.DepositKindName != target.DepositKindName) resList.Add("DepositKindName");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.DepositAllowance != target.DepositAllowance) resList.Add("DepositAllowance");
            if (this.DepositAgentCode != target.DepositAgentCode) resList.Add("DepositAgentCode");
            if (this.DepositAgentNm != target.DepositAgentNm) resList.Add("DepositAgentNm");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.DebitNoteOffSetCd != target.DebitNoteOffSetCd) resList.Add("DebitNoteOffSetCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (this.DepositCd != target.DepositCd) resList.Add("DepositCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// �������������f�[�^��r����
        /// </summary>
        /// <param name="searchDepositAlw1">��r����SearchDepositAlw�N���X�̃C���X�^���X</param>
        /// <param name="searchDepositAlw2">��r����SearchDepositAlw�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SearchDepositAlw�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SearchDepositAlw searchDepositAlw1, SearchDepositAlw searchDepositAlw2)
        {
            ArrayList resList = new ArrayList();
            if (searchDepositAlw1.CreateDateTime != searchDepositAlw2.CreateDateTime) resList.Add("CreateDateTime");
            if (searchDepositAlw1.UpdateDateTime != searchDepositAlw2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (searchDepositAlw1.EnterpriseCode != searchDepositAlw2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (searchDepositAlw1.FileHeaderGuid != searchDepositAlw2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (searchDepositAlw1.UpdEmployeeCode != searchDepositAlw2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (searchDepositAlw1.UpdAssemblyId1 != searchDepositAlw2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (searchDepositAlw1.UpdAssemblyId2 != searchDepositAlw2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (searchDepositAlw1.LogicalDeleteCode != searchDepositAlw2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (searchDepositAlw1.InputDepositSecCd != searchDepositAlw2.InputDepositSecCd) resList.Add("InputDepositSecCd");
            if (searchDepositAlw1.AddUpSecCode != searchDepositAlw2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (searchDepositAlw1.AcptAnOdrStatus != searchDepositAlw2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (searchDepositAlw1.SalesSlipNum != searchDepositAlw2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (searchDepositAlw1.ReconcileDate != searchDepositAlw2.ReconcileDate) resList.Add("ReconcileDate");
            if (searchDepositAlw1.ReconcileAddUpDate != searchDepositAlw2.ReconcileAddUpDate) resList.Add("ReconcileAddUpDate");
            if (searchDepositAlw1.DepositSlipNo != searchDepositAlw2.DepositSlipNo) resList.Add("DepositSlipNo");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepositAlw1.DepositKindCode != searchDepositAlw2.DepositKindCode) resList.Add("DepositKindCode");
            if (searchDepositAlw1.DepositKindName != searchDepositAlw2.DepositKindName) resList.Add("DepositKindName");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepositAlw1.DepositAllowance != searchDepositAlw2.DepositAllowance) resList.Add("DepositAllowance");
            if (searchDepositAlw1.DepositAgentCode != searchDepositAlw2.DepositAgentCode) resList.Add("DepositAgentCode");
            if (searchDepositAlw1.DepositAgentNm != searchDepositAlw2.DepositAgentNm) resList.Add("DepositAgentNm");
            if (searchDepositAlw1.ClaimCode != searchDepositAlw2.ClaimCode) resList.Add("ClaimCode");
            if (searchDepositAlw1.ClaimName != searchDepositAlw2.ClaimName) resList.Add("ClaimName");
            if (searchDepositAlw1.ClaimName2 != searchDepositAlw2.ClaimName2) resList.Add("ClaimName2");
            if (searchDepositAlw1.ClaimSnm != searchDepositAlw2.ClaimSnm) resList.Add("ClaimSnm");
            if (searchDepositAlw1.CustomerCode != searchDepositAlw2.CustomerCode) resList.Add("CustomerCode");
            if (searchDepositAlw1.CustomerName != searchDepositAlw2.CustomerName) resList.Add("CustomerName");
            if (searchDepositAlw1.CustomerName2 != searchDepositAlw2.CustomerName2) resList.Add("CustomerName2");
            if (searchDepositAlw1.CustomerSnm != searchDepositAlw2.CustomerSnm) resList.Add("CustomerSnm");
            if (searchDepositAlw1.DebitNoteOffSetCd != searchDepositAlw2.DebitNoteOffSetCd) resList.Add("DebitNoteOffSetCd");
            /* --- DEL 2008/06/26 --------------------------------------------------------------------->>>>>
            if (searchDepositAlw1.DepositCd != searchDepositAlw2.DepositCd) resList.Add("DepositCd");
               --- DEL 2008/06/26 ---------------------------------------------------------------------<<<<<*/
            if (searchDepositAlw1.EnterpriseName != searchDepositAlw2.EnterpriseName) resList.Add("EnterpriseName");
            if (searchDepositAlw1.UpdEmployeeName != searchDepositAlw2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (searchDepositAlw1.AddUpSecName != searchDepositAlw2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}
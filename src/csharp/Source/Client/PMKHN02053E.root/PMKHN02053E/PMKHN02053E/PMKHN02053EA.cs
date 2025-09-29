//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\�@�����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Campaignst
    /// <summary>
    ///  �L�����y�[�����ѕ\�@�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[�����ѕ\�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/05/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignRsltList
    {
        # region �� private field ��

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

        // <summary>�W�v�P��</summary>
        /// <remarks>0:���i�� 1:���Ӑ�� 2:�S���ҕ�</remarks>
        private TotalTypeState _totalType;

        /// <summary>�L�����y�[�����{���_</summary>
        private string _campexecSecCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>�����^�@���z�񍀖�</remarks>
        private string[] _sectionCodes;

        /// <summary>�L�����y�[���R�[�h</summary>
        private Int32 _campaignCode;

        /// <summary>�L�����y�[������</summary>
        private string _campaignName = "";

        /// <summary>�L�����y�[���Ώۋ敪</summary>
        /// <remarks>0:�S���Ӑ�,1:�Ώۓ��Ӑ�,9:���~</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>�K�p�J�n��</summary>
        private Int32 _applyStaDate;

        /// <summary>�K�p�I����</summary>
        private Int32 _applyEndDate;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _customerCodeSt;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _customerCodeEd;

        /// <summary>�J�n�]�ƈ��R�[�h</summary>
        private string _employeeCodeSt = "";

        /// <summary>�I���]�ƈ��R�[�h</summary>
        private string _employeeCodeEd = "";

        /// <summary>�J�n�󒍎҃R�[�h</summary>
        private string _acceptOdrCodeSt = "";

        /// <summary>�I���󒍎҃R�[�h</summary>
        private string _acceptOdrCodeEd = "";

        /// <summary>�J�n���s�҃R�[�h</summary>
        private string _printerCodeSt = "";

        /// <summary>�I�����s�҃R�[�h</summary>
        private string _printerCodeEd = "";

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>�J�n���i�����ރR�[�h</summary>
        private Int32 _goodsMGroupSt;

        /// <summary>�I�����i�����ރR�[�h</summary>
        private Int32 _goodsMGroupEd;

        /// <summary>�J�nBL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>�I��BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�J�n���i�ԍ�</summary>
        private string _goodsNoSt = "";

        /// <summary>�I�����i�ԍ�</summary>
        private string _goodsNoEd = "";

        /// <summary>����(���_���ŉ���)</summary>
        /// <remarks>0:�Ȃ� 1:����</remarks>
        private Int32 _crModeSec;

        /// <summary>����(�S���Җ��ŉ���)</summary>
        /// <remarks>0:�Ȃ� 1:����</remarks>
        private Int32 _crModeEmp;

        /// <summary>����(�n�斈�ŉ���)</summary>
        /// <remarks>0:�Ȃ� 1:����</remarks>
        private Int32 _crModeArea;

        /// <summary>�J�n�n��R�[�h</summary>
        private Int32 _areaCodeSt;

        /// <summary>�I���n��R�[�h</summary>
        private Int32 _areaCodeEd;

        /// <summary>�J�n�Ώۓ��t</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonthSt;

        /// <summary>�I���Ώۓ��t</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonthEd;

        /// <summary>�J�n�Ώۓ��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpYearMonthDaySt;

        /// <summary>�I���Ώۓ��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _addUpYearMonthDayEd;

        /// <summary>�o�͏�</summary>
        /// <remarks>0:�O���[�v�R�[�h,1:BL�R�[�h</remarks>
        private Int32 _outputSort;

        /// <summary>�����</summary>
        /// <remarks>0�F�i�ԁ{���[�J�[,1�F���[�J�[�{�i��</remarks>
        private Int32 _printSort;

        /// <summary>����^�C�v</summary>
        /// <remarks>0:����,1:����,3:���t</remarks>
        private Int32 _printType;

        /// <summary>���גP��</summary>
        /// <remarks>0�F�i�ԁA1�FBL���ށA2�F��ٰ�ߺ���</remarks>
        private Int32 _detail;

        /// <summary>���v�P��</summary>
        /// <remarks>0�F��ٰ�ߺ��ށA1�FBL����</remarks>
        private Int32 _total;

        /// <summary>�J�n�̔��敪�R�[�h</summary>
        private Int32 _salesCodeSt;

        /// <summary>�I���̔��敪�R�[�h</summary>
        private Int32 _salesCodeEd;

        # endregion  �� private field ��

        # region �� public propaty ��

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

        /// public propaty name  :  TotalType
        /// <summary>���[�W�v�敪�v���p�e�B</summary>
        /// <value>0:���i�ʁ^1:���Ӑ�ʁ^2:�S���ҕʁ^3:�q�ɕ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�W�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TotalTypeState TotalType
        {
            get { return _totalType; }
            set { _totalType = value; }
        }

        /// public propaty name  :  CampexecSecCode
        /// <summary>�L�����y�[�����{���_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����{���_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CampexecSecCode
        {
            get { return _campexecSecCode; }
            set { _campexecSecCode = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>�����^�@���z�񍀖�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  CampaignName
        /// <summary>�L�����y�[�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  CampaignObjDiv
        /// <summary>�L�����y�[���Ώۋ敪�v���p�e�B</summary>
        /// <value>0:�S���Ӑ�,1:�Ώۓ��Ӑ�,9:���~</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignObjDiv
        {
            get { return _campaignObjDiv; }
            set { _campaignObjDiv = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
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

        // public propaty name  :  CustomerCodeSt
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        // public propaty name  :  CustomerCodeEd
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  EmployeeCodeSt
        /// <summary>�J�n�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeSt
        {
            get { return _employeeCodeSt; }
            set { _employeeCodeSt = value; }
        }

        /// public propaty name  :  EmployeeCodeEd
        /// <summary>�I���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCodeEd
        {
            get { return _employeeCodeEd; }
            set { _employeeCodeEd = value; }
        }

        /// public propaty name  :  AcceptOdrCodeSt
        /// <summary>�J�n�󒍎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�󒍎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcceptOdrCodeSt
        {
            get { return _acceptOdrCodeSt; }
            set { _acceptOdrCodeSt = value; }
        }

        /// public propaty name  :  AcceptOdrCodeEd
        /// <summary>�I���󒍎҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���󒍎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AcceptOdrCodeEd
        {
            get { return _acceptOdrCodeEd; }
            set { _acceptOdrCodeEd = value; }
        }

        /// public propaty name  :  PrinterCodeSt
        /// <summary>�J�n���s�҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���󒍎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrinterCodeSt
        {
            get { return _printerCodeSt; }
            set { _printerCodeSt = value; }
        }

        /// public propaty name  :  PrinterCodeEd
        /// <summary>�I�����s�҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�󒍎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrinterCodeEd
        {
            get { return _printerCodeEd; }
            set { _printerCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  GoodsMGroupSt
        /// <summary>�J�n���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroupSt
        {
            get { return _goodsMGroupSt; }
            set { _goodsMGroupSt = value; }
        }

        /// public propaty name  :  GoodsMGroupEd
        /// <summary>�I�����i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroupEd
        {
            get { return _goodsMGroupEd; }
            set { _goodsMGroupEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>�J�nBL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>�I��BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsNoSt
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>�I�����i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  AddUpYearMonthSt
        /// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonthSt
        {
            get { return _addUpYearMonthSt; }
            set { _addUpYearMonthSt = value; }
        }

        /// public propaty name  :  AddUpYearMonthEd
        /// <summary>�I���Ώ۔N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonthEd
        {
            get { return _addUpYearMonthEd; }
            set { _addUpYearMonthEd = value; }
        }

        /// public propaty name  :  AddUpYearMonthDaySt
        /// <summary>�J�n�Ώ۔N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonthDaySt
        {
            get { return _addUpYearMonthDaySt; }
            set { _addUpYearMonthDaySt = value; }
        }

        /// public propaty name  :  AddUpYearMonthDayEd
        /// <summary>�I���Ώ۔N���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώ۔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpYearMonthDayEd
        {
            get { return _addUpYearMonthDayEd; }
            set { _addUpYearMonthDayEd = value; }
        }

        /// public propaty name  :  CrModeSec
        /// <summary>����(���_���ŉ���)�v���p�e�B</summary>
        /// <value>0:�Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(���_���ŉ���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CrModeSec
        {
            get { return _crModeSec; }
            set { _crModeSec = value; }
        }

        /// public propaty name  :  CrModeEmp
        /// <summary>����(�S���Җ��ŉ���)�v���p�e�B</summary>
        /// <value>0:�Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�S���Җ��ŉ���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CrModeEmp
        {
            get { return _crModeEmp; }
            set { _crModeEmp = value; }
        }

        //  dingjx  >>>
        // public propaty name  :  AreaCodeSt
        /// <summary>�J�n�n��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�n��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AreaCodeSt
        {
            get { return _areaCodeSt; }
            set { _areaCodeSt = value; }
        }

        // public propaty name  :  AreaCodeEd
        /// <summary>�I���n��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���n��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AreaCodeEd
        {
            get { return _areaCodeEd; }
            set { _areaCodeEd = value; }
        }

        /// public propaty name  :  CrModeArea
        /// <summary>����(�n�斈�ŉ���)�v���p�e�B</summary>
        /// <value>0:�Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����(�n�斈�ŉ���)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CrModeArea
        {
            get { return _crModeArea; }
            set { _crModeArea = value; }
        }
        //  dingjx  <<<

        /// public propaty name  :  OutputSort
        /// <summary>�o�͏��v���p�e�B</summary>
        /// <value>0:�O���[�v�R�[�h 1:BL�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�[�g���ڃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutputSort
        {
            get { return _outputSort; }
            set { _outputSort = value; }
        }

        /// public propaty name  :  PrintSort
        /// <summary>������v���p�e�B</summary>
        /// <value>0�F�i�ԁ{���[�J�[,1�F���[�J�[�{�i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintSort
        {
            get { return _printSort; }
            set { _printSort = value; }
        }

        /// public propaty name  :  PrintType
        /// <summary>�󎚃^�C�v�v���p�e�B</summary>
        /// <value>0:����,1:����,3:���t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󎚃^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  Detail
        /// <summary>���גP�ʃv���p�e�B</summary>
        /// <value>0�F�i�ԁ{���[�J�[,1�F���[�J�[�{�i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���גP�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }

        /// public propaty name  :  Total
        /// <summary>���v�P�ʃv���p�e�B</summary>
        /// <value>0:����,1:����,3:���t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v�P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Total
        {
            get { return _total; }
            set { _total = value; }
        }


        /// public propaty name  :  SalesCodeSt
        /// <summary>�J�n�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>�I���̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
        }

        # endregion �� public propaty ��

        # region �� public method ��
        /// <summary>
        /// �L�����y�[�����ѕ\�R���X�g���N�^
        /// </summary>
        /// <returns>Campaignst�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Campaignst�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignRsltList()
        {
        }
        
        # endregion �� public method ��

        # region �� public propaty (���������ȊO) ��
        /// <summary>
        /// ���[�W�v�敪�@���̎擾
        /// </summary>
        public string TotalTypeName
        {
            get
            {
                switch (this._totalType)
                {
                    case TotalTypeState.EachGoods:
                        return ct_totalTypeState_EachGoods;
                    case TotalTypeState.EachCustomer:
                        return ct_totalTypeState_EachCustomer;
                    case TotalTypeState.EachEmployee:
                        return ct_totalTypeState_EachEmployee;
                    case TotalTypeState.EachAcceptOdr:
                        return ct_totalTypeState_EachAcceptOdr;
                    case TotalTypeState.EachPrinter:
                        return ct_totalTypeState_EachPrinter;
                    case TotalTypeState.EachArea:
                        return ct_totalTypeState_EachArea;
                    case TotalTypeState.EachSales:
                        return ct_totalTypeState_EachSales;
                    default:
                        return string.Empty;
                }
            }
        }
        # endregion �� public propaty (���������ȊO) ��

        # region �� public Enum (���������ȊO) ��
        /// <summary>
        /// ���[�W�v�敪�@�񋓌^
        /// </summary>
        public enum TotalTypeState
        {
            /// <summary>���i��</summary>
            EachGoods = 0,
            /// <summary>���Ӑ��</summary>
            EachCustomer = 1,
            /// <summary>�S���ҕ�</summary>
            EachEmployee = 2,
            /// <summary>�󒍎ҕ�</summary>
            EachAcceptOdr = 3,
            /// <summary>���s�ҕ�</summary>
            EachPrinter = 4,
            /// <summary>�n���</summary>
            EachArea = 5,
            /// <summary>�̔��敪��</summary>
            EachSales = 6,
        }
        # endregion �� public Enum (���������ȊO) ��

        #region �� public const ��
        /// <summary>���[�W�v�敪�@���i��</summary>
        public const string ct_totalTypeState_EachGoods = "���i��";
        /// <summary>���[�W�v�敪�@���Ӑ��</summary>
        public const string ct_totalTypeState_EachCustomer = "���Ӑ��";
        /// <summary>���[�W�v�敪�@�S���ҕ�</summary>
        public const string ct_totalTypeState_EachEmployee = "�S���ҕ�";
        /// <summary>���[�W�v�敪�@���i��</summary>
        public const string ct_totalTypeState_EachAcceptOdr = "�󒍎ҕ�";
        /// <summary>���[�W�v�敪�@���Ӑ��</summary>
        public const string ct_totalTypeState_EachPrinter = "���s�ҕ�";
        /// <summary>���[�W�v�敪�@�S���ҕ�</summary>
        public const string ct_totalTypeState_EachArea = "�n���";
        /// <summary>���[�W�v�敪�@�S���ҕ�</summary>
        public const string ct_totalTypeState_EachSales = "�̔��敪��";
        #endregion �� public const ��
    }
}

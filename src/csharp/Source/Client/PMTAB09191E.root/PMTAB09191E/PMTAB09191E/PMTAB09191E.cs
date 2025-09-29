//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : PMTAB�����\���]�ƈ��ݒ�}�X�^
// �v���O�����T�v   : PMTAB�����\���]�ƈ��ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31065 �L�� ���O
// �� �� ��  2014/09/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PmtDefEmp
    /// <summary>
    ///                      PMTAB�����\���]�ƈ��ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   PMTAB�����\���]�ƈ��ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2013/5/28</br>
    /// <br>Genarated Date   :   2014/09/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PmtDefEmp
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

        /// <summary>���O�C���S���҃R�[�h</summary>
        private string _loginAgenCode = "";

        /// <summary>�S���ҋ敪</summary>
        /// <remarks>0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l</remarks>
        private Int32 _salesEmpDiv;

        /// <summary>�̔��]�ƈ��R�[�h</summary>
        /// <remarks>�v��S���ҁi�S���ҁj</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>�󒍎ҋ敪</summary>
        /// <remarks>0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l</remarks>
        private Int32 _frontEmpDiv;

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>��t�S���ҁi�󒍎ҁj</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>���s�ҋ敪</summary>
        /// <remarks>0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l</remarks>
        private Int32 _salesInputDiv;

        /// <summary>������͎҃R�[�h</summary>
        /// <remarks>���͒S���ҁi���s�ҁj</remarks>
        private string _salesInputCode = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";


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

        /// public propaty name  :  LoginAgenCode
        /// <summary>���O�C���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginAgenCode
        {
            get { return _loginAgenCode; }
            set { _loginAgenCode = value; }
        }

        /// public propaty name  :  SalesEmpDiv
        /// <summary>�S���ҋ敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �S���ҋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesEmpDiv
        {
            get { return _salesEmpDiv; }
            set { _salesEmpDiv = value; }
        }

        /// public propaty name  :  SalesEmployeeCd
        /// <summary>�̔��]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�v��S���ҁi�S���ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeCd
        {
            get { return _salesEmployeeCd; }
            set { _salesEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmpDiv
        /// <summary>�󒍎ҋ敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍎ҋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FrontEmpDiv
        {
            get { return _frontEmpDiv; }
            set { _frontEmpDiv = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>��t�S���ҁi�󒍎ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  SalesInputDiv
        /// <summary>���s�ҋ敪�v���p�e�B</summary>
        /// <value>0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�ҋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesInputDiv
        {
            get { return _salesInputDiv; }
            set { _salesInputDiv = value; }
        }

        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h�v���p�e�B</summary>
        /// <value>���͒S���ҁi���s�ҁj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
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

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }


        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PmtDefEmp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtDefEmp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmtDefEmp()
        {
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="loginAgenCode">���O�C���S���҃R�[�h</param>
        /// <param name="salesEmpDiv">�S���ҋ敪(0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l)</param>
        /// <param name="salesEmployeeCd">�̔��]�ƈ��R�[�h(�v��S���ҁi�S���ҁj)</param>
        /// <param name="frontEmpDiv">�󒍎ҋ敪(0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l)</param>
        /// <param name="frontEmployeeCd">��t�]�ƈ��R�[�h(��t�S���ҁi�󒍎ҁj)</param>
        /// <param name="salesInputDiv">���s�ҋ敪(0:���Ӑ�S���� 1:���O�C���S���� 2:�� 3:�Œ�l)</param>
        /// <param name="salesInputCode">������͎҃R�[�h(���͒S���ҁi���s�ҁj)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
        /// <returns>PmtDefEmp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtDefEmp�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmtDefEmp(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string loginAgenCode, Int32 salesEmpDiv, string salesEmployeeCd, Int32 frontEmpDiv, string frontEmployeeCd, Int32 salesInputDiv, string salesInputCode, string enterpriseName, string updEmployeeName, string salesEmployeeNm)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._loginAgenCode = loginAgenCode;
            this._salesEmpDiv = salesEmpDiv;
            this._salesEmployeeCd = salesEmployeeCd;
            this._frontEmpDiv = frontEmpDiv;
            this._frontEmployeeCd = frontEmployeeCd;
            this._salesInputDiv = salesInputDiv;
            this._salesInputCode = salesInputCode;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._salesEmployeeNm = salesEmployeeNm;

        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^��������
        /// </summary>
        /// <returns>PmtDefEmp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PmtDefEmp�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmtDefEmp Clone()
        {
            return new PmtDefEmp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._loginAgenCode, this._salesEmpDiv, this._salesEmployeeCd, this._frontEmpDiv, this._frontEmployeeCd, this._salesInputDiv, this._salesInputCode, this._enterpriseName, this._updEmployeeName, this._salesEmployeeNm);
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PmtDefEmp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtDefEmp�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PmtDefEmp target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.LoginAgenCode == target.LoginAgenCode)
                 && (this.SalesEmpDiv == target.SalesEmpDiv)
                 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                 && (this.FrontEmpDiv == target.FrontEmpDiv)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.SalesInputDiv == target.SalesInputDiv)
                 && (this.SalesInputCode == target.SalesInputCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm));
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="pmtDefEmp1">
        ///                    ��r����PmtDefEmp�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pmtDefEmp2">��r����PmtDefEmp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtDefEmp�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PmtDefEmp pmtDefEmp1, PmtDefEmp pmtDefEmp2)
        {
            return ((pmtDefEmp1.CreateDateTime == pmtDefEmp2.CreateDateTime)
                 && (pmtDefEmp1.UpdateDateTime == pmtDefEmp2.UpdateDateTime)
                 && (pmtDefEmp1.EnterpriseCode == pmtDefEmp2.EnterpriseCode)
                 && (pmtDefEmp1.FileHeaderGuid == pmtDefEmp2.FileHeaderGuid)
                 && (pmtDefEmp1.UpdEmployeeCode == pmtDefEmp2.UpdEmployeeCode)
                 && (pmtDefEmp1.UpdAssemblyId1 == pmtDefEmp2.UpdAssemblyId1)
                 && (pmtDefEmp1.UpdAssemblyId2 == pmtDefEmp2.UpdAssemblyId2)
                 && (pmtDefEmp1.LogicalDeleteCode == pmtDefEmp2.LogicalDeleteCode)
                 && (pmtDefEmp1.LoginAgenCode == pmtDefEmp2.LoginAgenCode)
                 && (pmtDefEmp1.SalesEmpDiv == pmtDefEmp2.SalesEmpDiv)
                 && (pmtDefEmp1.SalesEmployeeCd == pmtDefEmp2.SalesEmployeeCd)
                 && (pmtDefEmp1.FrontEmpDiv == pmtDefEmp2.FrontEmpDiv)
                 && (pmtDefEmp1.FrontEmployeeCd == pmtDefEmp2.FrontEmployeeCd)
                 && (pmtDefEmp1.SalesInputDiv == pmtDefEmp2.SalesInputDiv)
                 && (pmtDefEmp1.SalesInputCode == pmtDefEmp2.SalesInputCode)
                 && (pmtDefEmp1.EnterpriseName == pmtDefEmp2.EnterpriseName)
                 && (pmtDefEmp1.UpdEmployeeName == pmtDefEmp2.UpdEmployeeName)
                 && (pmtDefEmp1.SalesEmployeeNm == pmtDefEmp2.SalesEmployeeNm));
        }
        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PmtDefEmp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtDefEmp�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PmtDefEmp target)
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
            if (this.LoginAgenCode != target.LoginAgenCode) resList.Add("LoginAgenCode");
            if (this.SalesEmpDiv != target.SalesEmpDiv) resList.Add("SalesEmpDiv");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.FrontEmpDiv != target.FrontEmpDiv) resList.Add("FrontEmpDiv");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.SalesInputDiv != target.SalesInputDiv) resList.Add("SalesInputDiv");
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");

            return resList;
        }

        /// <summary>
        /// PMTAB�����\���]�ƈ��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="pmtDefEmp1">��r����PmtDefEmp�N���X�̃C���X�^���X</param>
        /// <param name="pmtDefEmp2">��r����PmtDefEmp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmtDefEmp�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PmtDefEmp pmtDefEmp1, PmtDefEmp pmtDefEmp2)
        {
            ArrayList resList = new ArrayList();
            if (pmtDefEmp1.CreateDateTime != pmtDefEmp2.CreateDateTime) resList.Add("CreateDateTime");
            if (pmtDefEmp1.UpdateDateTime != pmtDefEmp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pmtDefEmp1.EnterpriseCode != pmtDefEmp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (pmtDefEmp1.FileHeaderGuid != pmtDefEmp2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (pmtDefEmp1.UpdEmployeeCode != pmtDefEmp2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (pmtDefEmp1.UpdAssemblyId1 != pmtDefEmp2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (pmtDefEmp1.UpdAssemblyId2 != pmtDefEmp2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (pmtDefEmp1.LogicalDeleteCode != pmtDefEmp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pmtDefEmp1.LoginAgenCode != pmtDefEmp2.LoginAgenCode) resList.Add("LoginAgenCode");
            if (pmtDefEmp1.SalesEmpDiv != pmtDefEmp2.SalesEmpDiv) resList.Add("SalesEmpDiv");
            if (pmtDefEmp1.SalesEmployeeCd != pmtDefEmp2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (pmtDefEmp1.FrontEmpDiv != pmtDefEmp2.FrontEmpDiv) resList.Add("FrontEmpDiv");
            if (pmtDefEmp1.FrontEmployeeCd != pmtDefEmp2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (pmtDefEmp1.SalesInputDiv != pmtDefEmp2.SalesInputDiv) resList.Add("SalesInputDiv");
            if (pmtDefEmp1.SalesInputCode != pmtDefEmp2.SalesInputCode) resList.Add("SalesInputCode");
            if (pmtDefEmp1.EnterpriseName != pmtDefEmp2.EnterpriseName) resList.Add("EnterpriseName");
            if (pmtDefEmp1.UpdEmployeeName != pmtDefEmp2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (pmtDefEmp1.SalesEmployeeNm != pmtDefEmp2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");

            return resList;
        }
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustSlipMng
    /// <summary>
    ///                      ���Ӑ�}�X�^�i�`�[�Ǘ��j
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�}�X�^�i�`�[�Ǘ��j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/8/10</br>
    /// <br>Genarated Date   :   2007/12/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   12/19  ����</br>
    /// <br>                 :   �f�[�^���̓V�X�e���̒ǉ�</br>
    /// </remarks>
    public class CustSlipMng
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

        /// <summary>�f�[�^���̓V�X�e��</summary>
        /// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
        private Int32 _dataInputSystem;

        /// <summary>�`�[������</summary>
        /// <remarks>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�}</remarks>
        private Int32 _slipPrtKind;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>0�̏ꍇ�͎��Аݒ薔�͓��Ӑ�ݒ�</remarks>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>0�̏ꍇ�͎��Аݒ薔�͋��_�ݒ�</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�`�[����ݒ�p���[ID</summary>
        /// <remarks>�`�[����ݒ�p</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�f�[�^���̓V�X�e������</summary>
        /// <remarks>����,����,���,�Ԕ�</remarks>
        private string _dataInputSystemName = "";


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

        /// public propaty name  :  DataInputSystem
        /// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
        /// <value>0:����,1:����,2:���,3:�Ԕ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>�`�[�����ʃv���p�e�B</summary>
        /// <value>10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�}</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�͎��Аݒ薔�͓��Ӑ�ݒ�</value>
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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// <value>0�̏ꍇ�͎��Аݒ薔�͋��_�ݒ�</value>
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

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>�`�[����ݒ�p���[ID�v���p�e�B</summary>
        /// <value>�`�[����ݒ�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[����ݒ�p���[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
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

        /// public propaty name  :  DataInputSystemName
        /// <summary>�f�[�^���̓V�X�e�����̃v���p�e�B</summary>
        /// <value>����,����,���,�Ԕ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���̓V�X�e�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DataInputSystemName
        {
            get { return _dataInputSystemName; }
            set { _dataInputSystemName = value; }
        }


        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j�R���X�g���N�^
        /// </summary>
        /// <returns>CustSlipMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSlipMng()
        {
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="dataInputSystem">�f�[�^���̓V�X�e��(0:����,1:����,2:���,3:�Ԕ�)</param>
        /// <param name="slipPrtKind">�`�[������(10:���Ϗ�,20:�w�����i�������j,21:���菑,30:�[�i��,40:�ԕi�`�[,100:���[�N�V�[�g,110:�{�f�B���@�})</param>
        /// <param name="customerCode">���Ӑ�R�[�h(0�̏ꍇ�͎��Аݒ�)</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="slipPrtSetPaperId">�`�[����ݒ�p���[ID(�`�[����ݒ�p)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="dataInputSystemName">�f�[�^���̓V�X�e������(����,����,���,�Ԕ�)</param>
        /// <returns>CustSlipMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSlipMng(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string sectionCode, Int32 customerCode, string customerSnm, string slipPrtSetPaperId, string enterpriseName, string updEmployeeName, string dataInputSystemName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._dataInputSystem = dataInputSystem;
            this._slipPrtKind = slipPrtKind;
            this._sectionCode = sectionCode;
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._dataInputSystemName = dataInputSystemName;

        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j��������
        /// </summary>
        /// <returns>CustSlipMng�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustSlipMng�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSlipMng Clone()
        {
            return new CustSlipMng(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._dataInputSystem, this._slipPrtKind, this._sectionCode, this._customerCode, this._customerSnm, this._slipPrtSetPaperId, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName);
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustSlipMng�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipMng�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustSlipMng target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.DataInputSystem == target.DataInputSystem)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DataInputSystemName == target.DataInputSystemName));
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j��r����
        /// </summary>
        /// <param name="custSlipMng1">
        ///                    ��r����CustSlipMng�N���X�̃C���X�^���X
        /// </param>
        /// <param name="custSlipMng2">��r����CustSlipMng�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipMng�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustSlipMng custSlipMng1, CustSlipMng custSlipMng2)
        {
            return ((custSlipMng1.CreateDateTime == custSlipMng2.CreateDateTime)
                 && (custSlipMng1.UpdateDateTime == custSlipMng2.UpdateDateTime)
                 && (custSlipMng1.EnterpriseCode == custSlipMng2.EnterpriseCode)
                 && (custSlipMng1.FileHeaderGuid == custSlipMng2.FileHeaderGuid)
                 && (custSlipMng1.UpdEmployeeCode == custSlipMng2.UpdEmployeeCode)
                 && (custSlipMng1.UpdAssemblyId1 == custSlipMng2.UpdAssemblyId1)
                 && (custSlipMng1.UpdAssemblyId2 == custSlipMng2.UpdAssemblyId2)
                 && (custSlipMng1.LogicalDeleteCode == custSlipMng2.LogicalDeleteCode)
                 && (custSlipMng1.DataInputSystem == custSlipMng2.DataInputSystem)
                 && (custSlipMng1.SlipPrtKind == custSlipMng2.SlipPrtKind)
                 && (custSlipMng1.CustomerCode == custSlipMng2.CustomerCode)
                 && (custSlipMng1.CustomerSnm == custSlipMng2.CustomerSnm)
                 && (custSlipMng1.SlipPrtSetPaperId == custSlipMng2.SlipPrtSetPaperId)
                 && (custSlipMng1.EnterpriseName == custSlipMng2.EnterpriseName)
                 && (custSlipMng1.UpdEmployeeName == custSlipMng2.UpdEmployeeName)
                 && (custSlipMng1.DataInputSystemName == custSlipMng2.DataInputSystemName));
        }
        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustSlipMng�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipMng�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustSlipMng target)
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
            if (this.DataInputSystem != target.DataInputSystem) resList.Add("DataInputSystem");
            if (this.SlipPrtKind != target.SlipPrtKind) resList.Add("SlipPrtKind");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SlipPrtSetPaperId != target.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.DataInputSystemName != target.DataInputSystemName) resList.Add("DataInputSystemName");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�Ǘ��j��r����
        /// </summary>
        /// <param name="custSlipMng1">��r����CustSlipMng�N���X�̃C���X�^���X</param>
        /// <param name="custSlipMng2">��r����CustSlipMng�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipMng�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustSlipMng custSlipMng1, CustSlipMng custSlipMng2)
        {
            ArrayList resList = new ArrayList();
            if (custSlipMng1.CreateDateTime != custSlipMng2.CreateDateTime) resList.Add("CreateDateTime");
            if (custSlipMng1.UpdateDateTime != custSlipMng2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (custSlipMng1.EnterpriseCode != custSlipMng2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custSlipMng1.FileHeaderGuid != custSlipMng2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (custSlipMng1.UpdEmployeeCode != custSlipMng2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (custSlipMng1.UpdAssemblyId1 != custSlipMng2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (custSlipMng1.UpdAssemblyId2 != custSlipMng2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (custSlipMng1.LogicalDeleteCode != custSlipMng2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (custSlipMng1.DataInputSystem != custSlipMng2.DataInputSystem) resList.Add("DataInputSystem");
            if (custSlipMng1.SlipPrtKind != custSlipMng2.SlipPrtKind) resList.Add("SlipPrtKind");
            if (custSlipMng1.CustomerCode != custSlipMng2.CustomerCode) resList.Add("CustomerCode");
            if (custSlipMng1.CustomerSnm != custSlipMng2.CustomerSnm) resList.Add("CustomerSnm");
            if (custSlipMng1.SlipPrtSetPaperId != custSlipMng2.SlipPrtSetPaperId) resList.Add("SlipPrtSetPaperId");
            if (custSlipMng1.EnterpriseName != custSlipMng2.EnterpriseName) resList.Add("EnterpriseName");
            if (custSlipMng1.UpdEmployeeName != custSlipMng2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (custSlipMng1.DataInputSystemName != custSlipMng2.DataInputSystemName) resList.Add("DataInputSystemName");

            return resList;
        }
    }
}

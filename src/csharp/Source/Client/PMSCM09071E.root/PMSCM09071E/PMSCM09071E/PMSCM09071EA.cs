using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PM7RkSetting
    /// <summary>
    ///                      PM7�A�g�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   PM7�A�g�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/7/12</br>
    /// <br>Genarated Date   :   2011/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PM7RkSetting
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

        /// <summary>����A�g�����敪</summary>
        /// <remarks>0�F���Ȃ��@1�F���� �@�����l���u0�F���Ȃ��v</remarks>
        private Int32 _salesRkAutoCode;

        /// <summary>����A�g�������M�Ԋu</summary>
        private Int64 _salesRkAutoSndTime;

        /// <summary>�}�X�^�A�g�����敪</summary>
        /// <remarks>0�F���Ȃ��@1�F���� �@�����l���u0�F���Ȃ��v</remarks>
        private Int32 _masterRkAutoCode;

        /// <summary>�}�X�^�A�g������M�Ԋu</summary>
        private Int64 _masterRkAutoRcvTime;

        /// <summary>�e�L�X�g�i�[�t�H���_</summary>
        private string _textSaveFolder = "";

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

        /// public propaty name  :  SalesRkAutoCode
        /// <summary>����A�g�����敪�v���p�e�B</summary>
        /// <value>0�F���Ȃ��@1�F���� �@�����l���u0�F���Ȃ��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����A�g�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRkAutoCode
        {
            get { return _salesRkAutoCode; }
            set { _salesRkAutoCode = value; }
        }

        /// public propaty name  :  SalesRkAutoSndTime
        /// <summary>����A�g�������M�Ԋu�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����A�g�������M�Ԋu�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesRkAutoSndTime
        {
            get { return _salesRkAutoSndTime; }
            set { _salesRkAutoSndTime = value; }
        }

        /// public propaty name  :  MasterRkAutoCode
        /// <summary>�}�X�^�A�g�����敪�v���p�e�B</summary>
        /// <value>0�F���Ȃ��@1�F���� �@�����l���u0�F���Ȃ��v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^�A�g�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MasterRkAutoCode
        {
            get { return _masterRkAutoCode; }
            set { _masterRkAutoCode = value; }
        }

        /// public propaty name  :  MasterRkAutoRcvTime
        /// <summary>�}�X�^�A�g������M�Ԋu�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^�A�g������M�Ԋu�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MasterRkAutoRcvTime
        {
            get { return _masterRkAutoRcvTime; }
            set { _masterRkAutoRcvTime = value; }
        }

        /// public propaty name  :  TextSaveFolder
        /// <summary>�e�L�X�g�i�[�t�H���_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�L�X�g�i�[�t�H���_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TextSaveFolder
        {
            get { return _textSaveFolder; }
            set { _textSaveFolder = value; }
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
        /// PM7�A�g�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PM7RkSetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSetting�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PM7RkSetting()
        {
        }

        /// <summary>
        /// PM7�A�g�ݒ�}�X�^�R���X�g���N�^
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
        /// <param name="salesRkAutoCode">����A�g�����敪(0�F���Ȃ��@1�F���� �@�����l���u0�F���Ȃ��v)</param>
        /// <param name="salesRkAutoSndTime">����A�g�������M�Ԋu</param>
        /// <param name="masterRkAutoCode">�}�X�^�A�g�����敪(0�F���Ȃ��@1�F���� �@�����l���u0�F���Ȃ��v)</param>
        /// <param name="masterRkAutoRcvTime">�}�X�^�A�g������M�Ԋu</param>
        /// <param name="textSaveFolder">�e�L�X�g�i�[�t�H���_</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>PM7RkSetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSetting�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PM7RkSetting(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesRkAutoCode, Int64 salesRkAutoSndTime, Int32 masterRkAutoCode, Int64 masterRkAutoRcvTime, string textSaveFolder, string enterpriseName, string updEmployeeName)
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
            this._salesRkAutoCode = salesRkAutoCode;
            this._salesRkAutoSndTime = salesRkAutoSndTime;
            this._masterRkAutoCode = masterRkAutoCode;
            this._masterRkAutoRcvTime = masterRkAutoRcvTime;
            this._textSaveFolder = textSaveFolder;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// PM7�A�g�ݒ�}�X�^��������
        /// </summary>
        /// <returns>PM7RkSetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PM7RkSetting�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PM7RkSetting Clone()
        {
            return new PM7RkSetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesRkAutoCode, this._salesRkAutoSndTime, this._masterRkAutoCode, this._masterRkAutoRcvTime, this._textSaveFolder, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// PM7�A�g�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PM7RkSetting�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSetting�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PM7RkSetting target)
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
                 && (this.SalesRkAutoCode == target.SalesRkAutoCode)
                 && (this.SalesRkAutoSndTime == target.SalesRkAutoSndTime)
                 && (this.MasterRkAutoCode == target.MasterRkAutoCode)
                 && (this.MasterRkAutoRcvTime == target.MasterRkAutoRcvTime)
                 && (this.TextSaveFolder == target.TextSaveFolder)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// PM7�A�g�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="pM7RkSetting1">
        ///                    ��r����PM7RkSetting�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pM7RkSetting2">��r����PM7RkSetting�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSetting�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PM7RkSetting pM7RkSetting1, PM7RkSetting pM7RkSetting2)
        {
            return ((pM7RkSetting1.CreateDateTime == pM7RkSetting2.CreateDateTime)
                 && (pM7RkSetting1.UpdateDateTime == pM7RkSetting2.UpdateDateTime)
                 && (pM7RkSetting1.EnterpriseCode == pM7RkSetting2.EnterpriseCode)
                 && (pM7RkSetting1.FileHeaderGuid == pM7RkSetting2.FileHeaderGuid)
                 && (pM7RkSetting1.UpdEmployeeCode == pM7RkSetting2.UpdEmployeeCode)
                 && (pM7RkSetting1.UpdAssemblyId1 == pM7RkSetting2.UpdAssemblyId1)
                 && (pM7RkSetting1.UpdAssemblyId2 == pM7RkSetting2.UpdAssemblyId2)
                 && (pM7RkSetting1.LogicalDeleteCode == pM7RkSetting2.LogicalDeleteCode)
                 && (pM7RkSetting1.SectionCode == pM7RkSetting2.SectionCode)
                 && (pM7RkSetting1.SalesRkAutoCode == pM7RkSetting2.SalesRkAutoCode)
                 && (pM7RkSetting1.SalesRkAutoSndTime == pM7RkSetting2.SalesRkAutoSndTime)
                 && (pM7RkSetting1.MasterRkAutoCode == pM7RkSetting2.MasterRkAutoCode)
                 && (pM7RkSetting1.MasterRkAutoRcvTime == pM7RkSetting2.MasterRkAutoRcvTime)
                 && (pM7RkSetting1.TextSaveFolder == pM7RkSetting2.TextSaveFolder)
                 && (pM7RkSetting1.EnterpriseName == pM7RkSetting2.EnterpriseName)
                 && (pM7RkSetting1.UpdEmployeeName == pM7RkSetting2.UpdEmployeeName));
        }
        /// <summary>
        /// PM7�A�g�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PM7RkSetting�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSetting�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PM7RkSetting target)
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
            if (this.SalesRkAutoCode != target.SalesRkAutoCode) resList.Add("SalesRkAutoCode");
            if (this.SalesRkAutoSndTime != target.SalesRkAutoSndTime) resList.Add("SalesRkAutoSndTime");
            if (this.MasterRkAutoCode != target.MasterRkAutoCode) resList.Add("MasterRkAutoCode");
            if (this.MasterRkAutoRcvTime != target.MasterRkAutoRcvTime) resList.Add("MasterRkAutoRcvTime");
            if (this.TextSaveFolder != target.TextSaveFolder) resList.Add("TextSaveFolder");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// PM7�A�g�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="pM7RkSetting1">��r����PM7RkSetting�N���X�̃C���X�^���X</param>
        /// <param name="pM7RkSetting2">��r����PM7RkSetting�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PM7RkSetting�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PM7RkSetting pM7RkSetting1, PM7RkSetting pM7RkSetting2)
        {
            ArrayList resList = new ArrayList();
            if (pM7RkSetting1.CreateDateTime != pM7RkSetting2.CreateDateTime) resList.Add("CreateDateTime");
            if (pM7RkSetting1.UpdateDateTime != pM7RkSetting2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pM7RkSetting1.EnterpriseCode != pM7RkSetting2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (pM7RkSetting1.FileHeaderGuid != pM7RkSetting2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (pM7RkSetting1.UpdEmployeeCode != pM7RkSetting2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (pM7RkSetting1.UpdAssemblyId1 != pM7RkSetting2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (pM7RkSetting1.UpdAssemblyId2 != pM7RkSetting2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (pM7RkSetting1.LogicalDeleteCode != pM7RkSetting2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pM7RkSetting1.SectionCode != pM7RkSetting2.SectionCode) resList.Add("SectionCode");
            if (pM7RkSetting1.SalesRkAutoCode != pM7RkSetting2.SalesRkAutoCode) resList.Add("SalesRkAutoCode");
            if (pM7RkSetting1.SalesRkAutoSndTime != pM7RkSetting2.SalesRkAutoSndTime) resList.Add("SalesRkAutoSndTime");
            if (pM7RkSetting1.MasterRkAutoCode != pM7RkSetting2.MasterRkAutoCode) resList.Add("MasterRkAutoCode");
            if (pM7RkSetting1.MasterRkAutoRcvTime != pM7RkSetting2.MasterRkAutoRcvTime) resList.Add("MasterRkAutoRcvTime");
            if (pM7RkSetting1.TextSaveFolder != pM7RkSetting2.TextSaveFolder) resList.Add("TextSaveFolder");
            if (pM7RkSetting1.EnterpriseName != pM7RkSetting2.EnterpriseName) resList.Add("EnterpriseName");
            if (pM7RkSetting1.UpdEmployeeName != pM7RkSetting2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ��ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���|��
// �C �� ��  2011/11/10  �C�����e : Redmine#26228�@���_�Ǘ����ǁ^�`�[���t�ɂ�钊�o�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecMngSet
    /// <summary>
    ///                      ���_�Ǘ��ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���_�Ǘ��ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   �����</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/03/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SecMngSet
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

        /// <summary>���</summary>
        /// <remarks>0:�f�[�^�@1:�}�X�^</remarks>
        private Int32 _kind;

        /// <summary>��M��</summary>
        /// <remarks>0:���M 1:��M</remarks>
        private Int32 _receiveCondition;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�V���N���s���t</summary>
        /// <remarks>�ŏI���M��</remarks>
        private DateTime _syncExecDate;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

		/// <summary>���M�拒�_�R�[�h</summary>
		private string _sendDestSecCode = "";

		/// <summary>�������M�敪</summary>
		/// <remarks>0�F�������M����A1�F�������M���Ȃ�</remarks>
		private Int32 _autoSendDiv;

		/// <summary>���M�σf�[�^�C���敪</summary>
		/// <remarks>0�F�C���A1�F�C���s��</remarks>//DEL 2011/11/10 xupz
        /// <remarks>0�F�C���A1�F�C���s�i���M���s���ȑO�j�A2�F�C���s�i�`�[���t�ȑO</remarks>//ADD 2011/11/10 xupz
		private Int32 _sndFinDataEdDiv;

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  Kind
        /// <summary>��ʃv���p�e�B</summary>
        /// <value>0:�f�[�^�@1:�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ʃv���p�e�B</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public Int32 Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        /// public propaty name  :  ReceiveCondition
        /// <summary>��M�󋵃v���p�e�B</summary>
        /// <value>0:���M 1:��M</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�󋵃v���p�e�B</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public Int32 ReceiveCondition
        {
            get { return _receiveCondition; }
            set { _receiveCondition = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SyncExecDate
        /// <summary>�V���N���s���t�v���p�e�B</summary>
        /// <value>�ŏI���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N���s���t�v���p�e�B</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public DateTime SyncExecDate
        {
            get { return _syncExecDate; }
            set { _syncExecDate = value; }
        }

        /// public propaty name  :  SyncExecDateJpFormal
        /// <summary>�V���N���s���t �a��v���p�e�B</summary>
        /// <value>�ŏI���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N���s���t �a��v���p�e�B</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string SyncExecDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _syncExecDate); }
            set { }
        }

        /// public propaty name  :  SyncExecDateJpInFormal
        /// <summary>�V���N���s���t �a��(��)�v���p�e�B</summary>
        /// <value>�ŏI���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N���s���t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string SyncExecDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _syncExecDate); }
            set { }
        }

        /// public propaty name  :  SyncExecDateAdFormal
        /// <summary>�V���N���s���t ����v���p�e�B</summary>
        /// <value>�ŏI���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N���s���t ����v���p�e�B</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string SyncExecDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _syncExecDate); }
            set { }
        }

        /// public propaty name  :  SyncExecDateAdInFormal
        /// <summary>�V���N���s���t ����(��)�v���p�e�B</summary>
        /// <value>�ŏI���M��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N���s���t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string SyncExecDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _syncExecDate); }
            set { }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   �����</br>
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
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


		/// public propaty name  :  SendDestSecCode
		/// <summary>���M�拒�_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���M�拒�_�R�[�h�v���p�e�B</br>
		/// </remarks>
		public string SendDestSecCode
		{
			get { return _sendDestSecCode; }
			set { _sendDestSecCode = value; }
		}

		/// public propaty name  :  AutoSendDiv
		/// <summary>�������M�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������M�敪�v���p�e�B</br>
		/// </remarks>
		public Int32 AutoSendDiv
		{
			get { return _autoSendDiv; }
			set { _autoSendDiv = value; }
		}

		/// public propaty name  :  SndFinDataEdDiv
		/// <summary>���M�σf�[�^�C���敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���M�σf�[�^�C���敪�v���p�e�B</br>
		/// </remarks>
		public Int32 SndFinDataEdDiv
		{
			get { return _sndFinDataEdDiv; }
			set { _sndFinDataEdDiv = value; }
		}

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SecMngSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public SecMngSet()
        {
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="kind">���(0:�f�[�^�@1:�}�X�^)</param>
        /// <param name="receiveCondition">��M��(0:���M 1:��M)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="syncExecDate">�V���N���s���t(�ŏI���M��)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="sendDestSecCode">���M�拒�_�R�[�h</param>
		/// <param name="autoSendDiv">�������M�敪</param>
		/// <param name="sndFinDataEdDiv">���M�σf�[�^�C���敪</param>
        /// <returns>SecMngSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
		public SecMngSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 kind, Int32 receiveCondition, string sectionCode, DateTime syncExecDate, string enterpriseName, string updEmployeeName, string sendDestSecCode, Int32 autoSendDiv, Int32 sndFinDataEdDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._kind = kind;
            this._receiveCondition = receiveCondition;
            this._sectionCode = sectionCode;
            this.SyncExecDate = syncExecDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
			this._sendDestSecCode = sendDestSecCode;
			this._autoSendDiv = autoSendDiv;
			this._sndFinDataEdDiv = sndFinDataEdDiv;
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^��������
        /// </summary>
        /// <returns>SecMngSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecMngSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public SecMngSet Clone()
        {
			return new SecMngSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._kind, this._receiveCondition, this._sectionCode, this._syncExecDate, this._enterpriseName, this._updEmployeeName, this._sendDestSecCode, this._autoSendDiv, this._sndFinDataEdDiv);
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SecMngSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public bool Equals(SecMngSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.Kind == target.Kind)
                 && (this.ReceiveCondition == target.ReceiveCondition)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SyncExecDate == target.SyncExecDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
			     && (this.SendDestSecCode == target.SendDestSecCode)
			     && (this.AutoSendDiv == target.AutoSendDiv)
			     && (this.SndFinDataEdDiv == target.SndFinDataEdDiv)
				 );
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="secMngSet1">
        ///                    ��r����SecMngSet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="secMngSet2">��r����SecMngSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public static bool Equals(SecMngSet secMngSet1, SecMngSet secMngSet2)
        {
            return ((secMngSet1.CreateDateTime == secMngSet2.CreateDateTime)
                 && (secMngSet1.UpdateDateTime == secMngSet2.UpdateDateTime)
                 && (secMngSet1.EnterpriseCode == secMngSet2.EnterpriseCode)
                 && (secMngSet1.FileHeaderGuid == secMngSet2.FileHeaderGuid)
                 && (secMngSet1.UpdEmployeeCode == secMngSet2.UpdEmployeeCode)
                 && (secMngSet1.UpdAssemblyId1 == secMngSet2.UpdAssemblyId1)
                 && (secMngSet1.UpdAssemblyId2 == secMngSet2.UpdAssemblyId2)
                 && (secMngSet1.LogicalDeleteCode == secMngSet2.LogicalDeleteCode)
                 && (secMngSet1.Kind == secMngSet2.Kind)
                 && (secMngSet1.ReceiveCondition == secMngSet2.ReceiveCondition)
                 && (secMngSet1.SectionCode == secMngSet2.SectionCode)
                 && (secMngSet1.SyncExecDate == secMngSet2.SyncExecDate)
                 && (secMngSet1.EnterpriseName == secMngSet2.EnterpriseName)
                 && (secMngSet1.UpdEmployeeName == secMngSet2.UpdEmployeeName)
				 && (secMngSet1.SendDestSecCode == secMngSet2.SendDestSecCode)
				 && (secMngSet1.AutoSendDiv == secMngSet2.AutoSendDiv)
				 && (secMngSet1.SndFinDataEdDiv == secMngSet2.SndFinDataEdDiv)
				 );
        }
        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SecMngSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public ArrayList Compare(SecMngSet target)
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
            if (this.Kind != target.Kind) resList.Add("Kind");
            if (this.ReceiveCondition != target.ReceiveCondition) resList.Add("ReceiveCondition");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SyncExecDate != target.SyncExecDate) resList.Add("SyncExecDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
			if (this.SendDestSecCode != target.SendDestSecCode) resList.Add("SendDestSecCode");
			if (this.AutoSendDiv != target.AutoSendDiv) resList.Add("AutoSendDiv");
			if (this.SndFinDataEdDiv != target.SndFinDataEdDiv) resList.Add("SndFinDataEdDiv");

            return resList;
        }

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="secMngSet1">��r����SecMngSet�N���X�̃C���X�^���X</param>
        /// <param name="secMngSet2">��r����SecMngSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecMngSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   �����</br>
        /// </remarks>
        public static ArrayList Compare(SecMngSet secMngSet1, SecMngSet secMngSet2)
        {
            ArrayList resList = new ArrayList();
            if (secMngSet1.CreateDateTime != secMngSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (secMngSet1.UpdateDateTime != secMngSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (secMngSet1.EnterpriseCode != secMngSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (secMngSet1.FileHeaderGuid != secMngSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (secMngSet1.UpdEmployeeCode != secMngSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (secMngSet1.UpdAssemblyId1 != secMngSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (secMngSet1.UpdAssemblyId2 != secMngSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (secMngSet1.LogicalDeleteCode != secMngSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (secMngSet1.Kind != secMngSet2.Kind) resList.Add("Kind");
            if (secMngSet1.ReceiveCondition != secMngSet2.ReceiveCondition) resList.Add("ReceiveCondition");
            if (secMngSet1.SectionCode != secMngSet2.SectionCode) resList.Add("SectionCode");
            if (secMngSet1.SyncExecDate != secMngSet2.SyncExecDate) resList.Add("SyncExecDate");
            if (secMngSet1.EnterpriseName != secMngSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (secMngSet1.UpdEmployeeName != secMngSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");
			if (secMngSet1.SendDestSecCode != secMngSet2.SendDestSecCode) resList.Add("SendDestSecCode");
			if (secMngSet1.AutoSendDiv != secMngSet2.AutoSendDiv) resList.Add("AutoSendDiv");
			if (secMngSet1.SndFinDataEdDiv != secMngSet2.SndFinDataEdDiv) resList.Add("SndFinDataEdDiv");

            return resList;
        }
    }
}
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SyncReqDataWork
    /// <summary>
    ///                      �����v���f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����v���f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/11</br>
    /// <br>Genarated Date   :   2014/08/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SyncReqDataWork : IFileHeader
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

        /// <summary>�����v���敪</summary>
        /// <remarks>0:INSERT 1:UPDATE 2:DELETE</remarks>
        private Int32 _syncReqDiv;

        /// <summary>�g�����U�N�V����ID</summary>
        private Int64 _transctId;

        /// <summary>�V���N�Ώۃe�[�u��ID</summary>
        private string _syncTableID = "";

        /// <summary>�����Ώۋ敪</summary>
        /// <remarks>0:�s�P�ʁA1:�\�P�ʁ@2�F�\�P��(���񓯊�)</remarks>
        private Int32 _syncTargetDiv;
        
        /// <summary>���������敪</summary>
        /// <remarks>0:�����A1:�o�b�`</remarks>
        private Int32 _syncProcDiv;

        /// <summary>�����Ώۃ��R�[�h�@�L�[����ID</summary>
        /// <remarks>�Ώۃe�[�u���̃v���C�}���[�L�[�̊e����ID���^�u��؂蕶����ɕϊ�����������</remarks>
        private string _syncObjRecKeyItmId = "";

        /// <summary>�����Ώۃ��R�[�h�@�L�[�l</summary>
        /// <remarks>�Ώۃ��R�[�h�̃v���C�}���[�L�[�̊e���ڂ̒l���^�u��؂蕶����ɕϊ����ꂽ������</remarks>
        private string _syncObjRecKeyVal = "";

        /// <summary>�����Ώۃ��R�[�h�@�X�V����ID</summary>
        /// <remarks>�X�V�Ώۂ̍���ID�i�^�u��؂蕶����j</remarks>
        private string _syncObjRecUpdItmId = "";

        /// <summary>�����Ώۃ��R�[�h�@�X�V�@�l</summary>
        /// <remarks>�X�V�Ώۂ̍��ڂ̒l�i�^�u��؂蕶����j</remarks>
        private string _syncObjRecUpdVal = "";

        /// <summary>�������s����</summary>
        /// <remarks>0:������ 1:���������� 2:�������s</remarks>
        private Int32 _syncExecRslt;

        /// <summary>�Ď��s��</summary>
        private Int32 _retryCount;

        /// <summary>�G���[�X�e�[�^�X</summary>
        private Int32 _errorStatus;

        /// <summary>�G���[���e</summary>
        private string _errorContents = "";

        /// <summary>�f�[�^����</summary>
        private Int32 _syncDataCount;

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

        /// public propaty name  :  SyncReqDiv
        /// <summary>�����v���敪�v���p�e�B</summary>
        /// <value>0:INSERT 1:UPDATE 2:DELETE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SyncReqDiv
        {
            get { return _syncReqDiv; }
            set { _syncReqDiv = value; }
        }

        /// public propaty name  :  TransctId
        /// <summary>�g�����U�N�V����ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�����U�N�V����ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TransctId
        {
            get { return _transctId; }
            set { _transctId = value; }
        }

        /// public propaty name  :  SyncTableID
        /// <summary>�V���N�Ώۃe�[�u��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V���N�Ώۃe�[�u��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SyncTableID
        {
            get { return _syncTableID; }
            set { _syncTableID = value; }
        }

        /// public propaty name  :  SyncTargetDiv
        /// <summary>�����Ώۋ敪�v���p�e�B</summary>
        /// <value>0:�s�P�ʁA1:�\�P�ʁ@2�F�\�P��(���񓯊�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SyncTargetDiv
        {
            get { return _syncTargetDiv; }
            set { _syncTargetDiv = value; }
        }

        /// public propaty name  :  SyncProcDiv
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>0:�����A1:�o�b�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SyncProcDiv
        {
            get { return _syncProcDiv; }
            set { _syncProcDiv = value; }
        }

        /// public propaty name  :  SyncObjRecKeyItmId
        /// <summary>�����Ώۃ��R�[�h�@�L�[����ID�v���p�e�B</summary>
        /// <value>�Ώۃe�[�u���̃v���C�}���[�L�[�̊e����ID���^�u��؂蕶����ɕϊ�����������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ώۃ��R�[�h�@�L�[����ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SyncObjRecKeyItmId
        {
            get { return _syncObjRecKeyItmId; }
            set { _syncObjRecKeyItmId = value; }
        }

        /// public propaty name  :  SyncObjRecKeyVal
        /// <summary>�����Ώۃ��R�[�h�@�L�[�l�v���p�e�B</summary>
        /// <value>�Ώۃ��R�[�h�̃v���C�}���[�L�[�̊e���ڂ̒l���^�u��؂蕶����ɕϊ����ꂽ������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ώۃ��R�[�h�@�L�[�l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SyncObjRecKeyVal
        {
            get { return _syncObjRecKeyVal; }
            set { _syncObjRecKeyVal = value; }
        }

        /// public propaty name  :  SyncObjRecUpdItmId
        /// <summary>�����Ώۃ��R�[�h�@�X�V����ID�v���p�e�B</summary>
        /// <value>�X�V�Ώۂ̍���ID�i�^�u��؂蕶����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ώۃ��R�[�h�@�X�V����ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SyncObjRecUpdItmId
        {
            get { return _syncObjRecUpdItmId; }
            set { _syncObjRecUpdItmId = value; }
        }

        /// public propaty name  :  SyncObjRecUpdVal
        /// <summary>�����Ώۃ��R�[�h�@�X�V�@�l�v���p�e�B</summary>
        /// <value>�X�V�Ώۂ̍��ڂ̒l�i�^�u��؂蕶����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ώۃ��R�[�h�@�X�V�@�l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SyncObjRecUpdVal
        {
            get { return _syncObjRecUpdVal; }
            set { _syncObjRecUpdVal = value; }
        }

        /// public propaty name  :  SyncExecRslt
        /// <summary>�������s���ʃv���p�e�B</summary>
        /// <value>0:������ 1:���������� 2:�������s</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������s���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SyncExecRslt
        {
            get { return _syncExecRslt; }
            set { _syncExecRslt = value; }
        }

        /// public propaty name  :  RetryCount
        /// <summary>�Ď��s�񐔃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ď��s�񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetryCount
        {
            get { return _retryCount; }
            set { _retryCount = value; }
        }

        /// public propaty name  :  ErrorStatus
        /// <summary>�G���[�X�e�[�^�X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[�X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorStatus
        {
            get { return _errorStatus; }
            set { _errorStatus = value; }
        }

        /// public propaty name  :  ErrorContents
        /// <summary>�G���[���e�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���e�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrorContents
        {
            get { return _errorContents; }
            set { _errorContents = value; }
        }

        /// public propaty name  :  SyncDataCount
        /// <summary>�f�[�^�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SyncDataCount
        {
            get { return _syncDataCount; }
            set { _syncDataCount = value; }
        }

        /// <summary>
        /// �����v���f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SyncReqDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SyncReqDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SyncReqDataWork()
        {
        }

        /// <summary>
        /// �����v���f�[�^���[�N��������
        /// </summary>
        /// <returns>SyncReqDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SyncReqDataWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SyncReqDataWork Clone()
        {
            return new SyncReqDataWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._syncReqDiv, this._transctId, this._syncTableID, this._syncTargetDiv, this._syncProcDiv, this._syncObjRecKeyItmId, this._syncObjRecKeyVal, this._syncObjRecUpdItmId, this._syncObjRecUpdVal, this._syncExecRslt, this._retryCount, this._errorStatus, this._errorContents, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._syncDataCount);
        }

        /// <summary>
        /// �����v���f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="syncReqDiv">�����v���敪(0:INSERT 1:UPDATE 2:DELETE)</param>
        /// <param name="transctId">�g�����U�N�V����ID</param>
        /// <param name="syncTableID">�V���N�Ώۃe�[�u��ID</param>
        /// <param name="syncTargetDiv">�����Ώۋ敪(0:�s�P�ʁA1:�\�P�ʁ@2�F�\�P��(���񓯊�))</param>
        /// <param name="syncObjRecKeyItmId">�����Ώۃ��R�[�h�@�L�[����ID(�Ώۃe�[�u���̃v���C�}���[�L�[�̊e����ID���^�u��؂蕶����ɕϊ�����������)</param>
        /// <param name="syncObjRecKeyVal">�����Ώۃ��R�[�h�@�L�[�l(�Ώۃ��R�[�h�̃v���C�}���[�L�[�̊e���ڂ̒l���^�u��؂蕶����ɕϊ����ꂽ������)</param>
        /// <param name="syncObjRecUpdItmId">�����Ώۃ��R�[�h�@�X�V����ID(�X�V�Ώۂ̍���ID�i�^�u��؂蕶����j)</param>
        /// <param name="syncObjRecUpdVal">�����Ώۃ��R�[�h�@�X�V�@�l(�X�V�Ώۂ̍��ڂ̒l�i�^�u��؂蕶����j)</param>
        /// <param name="syncExecRslt">�������s����(0:������ 1:���������� 2:�������s)</param>
        /// <param name="retryCount">�Ď��s��</param>
        /// <param name="errorStatus">�G���[�X�e�[�^�X</param>
        /// <param name="errorContents">�G���[���e</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// /// <param name="syncDataCount">�f�[�^����</param>
        /// <returns>SyncReqDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SyncReqDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SyncReqDataWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, Int32 syncReqDiv, Int64 transctId, string syncTableID, Int32 syncTargetDiv, Int32 syncProcDiv, string syncObjRecKeyItmId, string syncObjRecKeyVal, string syncObjRecUpdItmId, string syncObjRecUpdVal, Int32 syncExecRslt, Int32 retryCount, Int32 errorStatus, string errorContents, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 syncDataCount)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._syncReqDiv = syncReqDiv;
            this._transctId = transctId;
            this._syncTableID = syncTableID;
            this._syncTargetDiv = syncTargetDiv;
            this._syncProcDiv = syncProcDiv;
            this._syncObjRecKeyItmId = syncObjRecKeyItmId;
            this._syncObjRecKeyVal = syncObjRecKeyVal;
            this._syncObjRecUpdItmId = syncObjRecUpdItmId;
            this._syncObjRecUpdVal = syncObjRecUpdVal;
            this._syncExecRslt = syncExecRslt;
            this._retryCount = retryCount;
            this._errorStatus = errorStatus;
            this._errorContents = errorContents;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._syncDataCount = syncDataCount;

        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SyncReqDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SyncReqDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SyncReqDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SyncReqDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SyncReqDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SyncReqDataWork || graph is ArrayList || graph is SyncReqDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SyncReqDataWork).FullName));

            if (graph != null && graph is SyncReqDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SyncReqDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SyncReqDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SyncReqDataWork[])graph).Length;
            }
            else if (graph is SyncReqDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�����v���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncReqDiv
            //�g�����U�N�V����ID
            serInfo.MemberInfo.Add(typeof(Int64)); //TransctId
            //�V���N�Ώۃe�[�u��ID
            serInfo.MemberInfo.Add(typeof(string)); //SyncTableID
            //�����Ώۋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncTargetDiv
            //���������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncProcDiv
            //�����Ώۃ��R�[�h�@�L�[����ID
            serInfo.MemberInfo.Add(typeof(string)); //SyncObjRecKeyItmId
            //�����Ώۃ��R�[�h�@�L�[�l
            serInfo.MemberInfo.Add(typeof(string)); //SyncObjRecKeyVal
            //�����Ώۃ��R�[�h�@�X�V����ID
            serInfo.MemberInfo.Add(typeof(string)); //SyncObjRecUpdItmId
            //�����Ώۃ��R�[�h�@�X�V�@�l
            serInfo.MemberInfo.Add(typeof(string)); //SyncObjRecUpdVal
            //�������s����
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncExecRslt
            //�Ď��s��
            serInfo.MemberInfo.Add(typeof(Int32)); //RetryCount
            //�G���[�X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //ErrorStatus
            //�G���[���e
            serInfo.MemberInfo.Add(typeof(string)); //ErrorContents
            //�f�[�^����
            serInfo.MemberInfo.Add(typeof(Int32)); //SyncDataCount


            serInfo.Serialize(writer, serInfo);
            if (graph is SyncReqDataWork)
            {
                SyncReqDataWork temp = (SyncReqDataWork)graph;

                SetSyncReqDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SyncReqDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SyncReqDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SyncReqDataWork temp in lst)
                {
                    SetSyncReqDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SyncReqDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 22;

        /// <summary>
        ///  SyncReqDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SyncReqDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSyncReqDataWork(System.IO.BinaryWriter writer, SyncReqDataWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�����v���敪
            writer.Write(temp.SyncReqDiv);
            //�g�����U�N�V����ID
            writer.Write(temp.TransctId);
            //�V���N�Ώۃe�[�u��ID
            writer.Write(temp.SyncTableID);
            //�����Ώۋ敪
            writer.Write(temp.SyncTargetDiv);
            //���������敪
            writer.Write(temp.SyncProcDiv);
            //�����Ώۃ��R�[�h�@�L�[����ID
            writer.Write(temp.SyncObjRecKeyItmId);
            //�����Ώۃ��R�[�h�@�L�[�l
            writer.Write(temp.SyncObjRecKeyVal);
            //�����Ώۃ��R�[�h�@�X�V����ID
            writer.Write(temp.SyncObjRecUpdItmId);
            //�����Ώۃ��R�[�h�@�X�V�@�l
            writer.Write(temp.SyncObjRecUpdVal);
            //�������s����
            writer.Write(temp.SyncExecRslt);
            //�Ď��s��
            writer.Write(temp.RetryCount);
            //�G���[�X�e�[�^�X
            writer.Write(temp.ErrorStatus);
            //�G���[���e
            writer.Write(temp.ErrorContents);
            //�f�[�^����
            writer.Write(temp.SyncDataCount);

        }

        /// <summary>
        ///  SyncReqDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SyncReqDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SyncReqDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SyncReqDataWork GetSyncReqDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SyncReqDataWork temp = new SyncReqDataWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�����v���敪
            temp.SyncReqDiv = reader.ReadInt32();
            //�g�����U�N�V����ID
            temp.TransctId = reader.ReadInt64();
            //�V���N�Ώۃe�[�u��ID
            temp.SyncTableID = reader.ReadString();
            //�����Ώۋ敪
            temp.SyncTargetDiv = reader.ReadInt32();
            //���������敪
            temp.SyncProcDiv = reader.ReadInt32();
            //�����Ώۃ��R�[�h�@�L�[����ID
            temp.SyncObjRecKeyItmId = reader.ReadString();
            //�����Ώۃ��R�[�h�@�L�[�l
            temp.SyncObjRecKeyVal = reader.ReadString();
            //�����Ώۃ��R�[�h�@�X�V����ID
            temp.SyncObjRecUpdItmId = reader.ReadString();
            //�����Ώۃ��R�[�h�@�X�V�@�l
            temp.SyncObjRecUpdVal = reader.ReadString();
            //�������s����
            temp.SyncExecRslt = reader.ReadInt32();
            //�Ď��s��
            temp.RetryCount = reader.ReadInt32();
            //�G���[�X�e�[�^�X
            temp.ErrorStatus = reader.ReadInt32();
            //�G���[���e
            temp.ErrorContents = reader.ReadString();
            //�f�[�^����
            temp.SyncDataCount = reader.ReadInt32();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SyncReqDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SyncReqDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SyncReqDataWork temp = GetSyncReqDataWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SyncReqDataWork[])lst.ToArray(typeof(SyncReqDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

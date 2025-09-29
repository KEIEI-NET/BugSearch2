using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConnectInfoWork
    /// <summary>
    ///                      �ڑ�����ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ڑ�����ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2013/6/26</br>
    /// <br>Genarated Date   :   2013/06/26  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConnectInfoWork : IFileHeader
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
        private Int32 _logicalDeleteCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�ڑ��p�X���[�h</summary>
        private string _connectPassword = "";

        /// <summary>�ڑ����[�UID</summary>
        private string _connectUserId = "";

        /// <summary>������z�敪�i�_�C�n�c�j</summary>
        private Int32 _daihatsuOrdreDiv;

        /// <summary>���O�C���^�C���A�E�g</summary>
        private Int32 _loginTimeoutVal;

        /// <summary>����URL</summary>
        private string _orderUrl = "";

        /// <summary>�݌Ɋm�FURL</summary>
        private string _stockCheckUrl = "";

        /// <summary>�ڑ��v���O�����^�C�v</summary>
        private Int32 _cnectProgramType;

        /// <summary>�ڑ��t�@�C��ID</summary>
        private string _cnectFileId = "";

        /// <summary>�ڑ����M�敪</summary>
        private Int32 _cnectSendDiv;

        /// <summary>�ڑ��Ώۋ敪</summary>
        private Int32 _cnectObjectDiv;

        /// <summary>���g���C��</summary>
        private Int32 _retryCnt;

        /// <summary>�������M�敪</summary>
        private Int32 _autoSendDiv;

        /// <summary>�N������</summary>
        private Int32 _bootTime;

        /// <summary>�[���ԍ�</summary>
        private Int32 _cashRegisterNo;

        /// <summary>���M�[��(IP�A�h���X�j</summary>
        private string _sendMachineIpAddr = "";

        /// <summary>���M�[��(�R���s���[�^�[���j</summary>
        private string _sendMachineName = "";

        /// <summary>S&E�ڑ����[�UID</summary>
        private string _sandECnctUserId = "";

        /// <summary>S&E�ڑ��p�X���[�h</summary>
        private string _sandECnctPass = "";

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

        /// public propaty name  :  ConnectPassword
        /// <summary>�ڑ��p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ��p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ConnectPassword
        {
            get { return _connectPassword; }
            set { _connectPassword = value; }
        }

        /// public propaty name  :  ConnectUserId
        /// <summary>�ڑ����[�UID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ����[�UID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ConnectUserId
        {
            get { return _connectUserId; }
            set { _connectUserId = value; }
        }

        /// public propaty name  :  DaihatsuOrdreDiv
        /// <summary>������z�敪�i�_�C�n�c�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�敪�i�_�C�n�c�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DaihatsuOrdreDiv
        {
            get { return _daihatsuOrdreDiv; }
            set { _daihatsuOrdreDiv = value; }
        }

        /// public propaty name  :  LoginTimeoutVal
        /// <summary>���O�C���^�C���A�E�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���^�C���A�E�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LoginTimeoutVal
        {
            get { return _loginTimeoutVal; }
            set { _loginTimeoutVal = value; }
        }

        /// public propaty name  :  OrderUrl
        /// <summary>����URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderUrl
        {
            get { return _orderUrl; }
            set { _orderUrl = value; }
        }

        /// public propaty name  :  StockCheckUrl
        /// <summary>�݌Ɋm�FURL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɋm�FURL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockCheckUrl
        {
            get { return _stockCheckUrl; }
            set { _stockCheckUrl = value; }
        }

        /// public propaty name  :  CnectProgramType
        /// <summary>�ڑ��v���O�����^�C�v�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ��v���O�����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CnectProgramType
        {
            get { return _cnectProgramType; }
            set { _cnectProgramType = value; }
        }

        /// public propaty name  :  CnectFileId
        /// <summary>�ڑ��t�@�C��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ��t�@�C��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CnectFileId
        {
            get { return _cnectFileId; }
            set { _cnectFileId = value; }
        }

        /// public propaty name  :  CnectSendDiv
        /// <summary>�ڑ����M�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ����M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CnectSendDiv
        {
            get { return _cnectSendDiv; }
            set { _cnectSendDiv = value; }
        }

        /// public propaty name  :  CnectObjectDiv
        /// <summary>�ڑ��Ώۋ敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ��Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CnectObjectDiv
        {
            get { return _cnectObjectDiv; }
            set { _cnectObjectDiv = value; }
        }

        /// public propaty name  :  RetryCnt
        /// <summary>���g���C�񐔃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���g���C�񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RetryCnt
        {
            get { return _retryCnt; }
            set { _retryCnt = value; }
        }

        /// public propaty name  :  AutoSendDiv
        /// <summary>�������M�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoSendDiv
        {
            get { return _autoSendDiv; }
            set { _autoSendDiv = value; }
        }

        /// public propaty name  :  BootTime
        /// <summary>�N�����ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �N�����ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BootTime
        {
            get { return _bootTime; }
            set { _bootTime = value; }
        }

        /// public propaty name  :  CashRegisterNo
        /// <summary>�[���ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  SendMachineIpAddr
        /// <summary>���M�[��(IP�A�h���X�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�[��(IP�A�h���X�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendMachineIpAddr
        {
            get { return _sendMachineIpAddr; }
            set { _sendMachineIpAddr = value; }
        }

        /// public propaty name  :  SendMachineName
        /// <summary>���M�[��(�R���s���[�^�[���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�[��(�R���s���[�^�[���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendMachineName
        {
            get { return _sendMachineName; }
            set { _sendMachineName = value; }
        }

        /// public propaty name  :  SAndECnctUserId
        /// <summary>S&E�ڑ����[�UID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   S&E�ڑ����[�UID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SAndECnctUserId
        {
            get { return _sandECnctUserId; }
            set { _sandECnctUserId = value; }
        }

        /// public propaty name  :  SAndECnctPass
        /// <summaryS&E�ڑ��p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   S&E�ڑ��p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SAndECnctPass
        {
            get { return _sandECnctPass; }
            set { _sandECnctPass = value; }
        }

        /// <summary>
        /// �ڑ�����ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ConnectInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConnectInfoWork()
        {
        }

        /// <summary>
        /// �ڑ�����ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="connectPassword">�ڑ��p�X���[�h</param>
        /// <param name="connectUserId">�ڑ����[�UID</param>
        /// <param name="daihatsuOrdreDiv">������z�敪�i�_�C�n�c�j</param>
        /// <param name="loginTimeoutVal">���O�C���^�C���A�E�g</param>
        /// <param name="orderUrl">����URL</param>
        /// <param name="stockCheckUrl">�݌Ɋm�FURL</param>
        /// <param name="cnectProgramType">�ڑ��v���O�����^�C�v</param>
        /// <param name="cnectFileId">�ڑ��t�@�C��ID</param>
        /// <param name="cnectSendDiv">�ڑ����M�敪</param>
        /// <param name="cnectObjectDiv">�ڑ��Ώۋ敪</param>
        /// <param name="retryCnt">���g���C��</param>
        /// <param name="autoSendDiv">�������M�敪</param>
        /// <param name="bootTime">�N������</param>
        /// <param name="sendMachineIpAddr">���M�[��(IP�A�h���X�j</param>
        /// <param name="sendMachineName">���M�[��(�R���s���[�^�[���j</param>
        /// <returns>ConnectInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConnectInfoWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierCd, string connectPassword, string connectUserId, Int32 daihatsuOrdreDiv, Int32 loginTimeoutVal, string orderUrl, string stockCheckUrl, Int32 cnectProgramType, string cnectFileId, Int32 cnectSendDiv, Int32 cnectObjectDiv, Int32 retryCnt, Int32 autoSendDiv, Int32 bootTime, string sendMachineIpAddr, string sendMachineName, string sandECnctUserId, string sandECnctPass, int cashRegisterNo)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._supplierCd = supplierCd;
            this._connectPassword = connectPassword;
            this._connectUserId = connectUserId;
            this._daihatsuOrdreDiv = daihatsuOrdreDiv;
            this._loginTimeoutVal = loginTimeoutVal;
            this._orderUrl = orderUrl;
            this._stockCheckUrl = stockCheckUrl;
            this._cnectProgramType = cnectProgramType;
            this._cnectFileId = cnectFileId;
            this._cnectSendDiv = cnectSendDiv;
            this._cnectObjectDiv = cnectObjectDiv;
            this._retryCnt = retryCnt;
            this._autoSendDiv = autoSendDiv;
            this._bootTime = bootTime;
            this._sendMachineIpAddr = sendMachineIpAddr;
            this._sendMachineName = sendMachineName;
            this._sandECnctUserId = sandECnctUserId;
            this._sandECnctPass = sandECnctPass;
            this._cashRegisterNo = cashRegisterNo;

        }

        /// <summary>
        /// �ڑ�����ݒ胏�[�N��������
        /// </summary>
        /// <returns>ConnectInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ConnectInfoWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConnectInfoWork Clone()
        {
            return new ConnectInfoWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierCd, this._connectPassword, this._connectUserId, this._daihatsuOrdreDiv, this._loginTimeoutVal, this._orderUrl, this._stockCheckUrl, this._cnectProgramType, this._cnectFileId, this._cnectSendDiv, this._cnectObjectDiv, this._retryCnt, this._autoSendDiv, this._bootTime, this._sendMachineIpAddr, this._sendMachineName, this._sandECnctUserId, this._sandECnctPass, this._cashRegisterNo);
        }
    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>ConnectInfoWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class ConnectInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ConnectInfoWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ConnectInfoWork || graph is ArrayList || graph is ConnectInfoWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(ConnectInfoWork).FullName));

            if (graph != null && graph is ConnectInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ConnectInfoWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ConnectInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ConnectInfoWork[])graph).Length;
            }
            else if (graph is ConnectInfoWork)
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
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�ڑ��p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //ConnectPassword
            //�ڑ����[�UID
            serInfo.MemberInfo.Add(typeof(string)); //ConnectUserId
            //������z�敪�i�_�C�n�c�j
            serInfo.MemberInfo.Add(typeof(Int32)); //DaihatsuOrdreDiv
            //���O�C���^�C���A�E�g
            serInfo.MemberInfo.Add(typeof(Int32)); //LoginTimeoutVal
            //����URL
            serInfo.MemberInfo.Add(typeof(string)); //OrderUrl
            //�݌Ɋm�FURL
            serInfo.MemberInfo.Add(typeof(string)); //StockCheckUrl
            //�ڑ��v���O�����^�C�v
            serInfo.MemberInfo.Add(typeof(Int32)); //CnectProgramType
            //�ڑ��t�@�C��ID
            serInfo.MemberInfo.Add(typeof(string)); //CnectFileId
            //�ڑ����M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CnectSendDiv
            //�ڑ��Ώۋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CnectObjectDiv
            //���g���C��
            serInfo.MemberInfo.Add(typeof(Int32)); //RetryCnt
            //�������M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoSendDiv
            //�N������
            serInfo.MemberInfo.Add(typeof(Int32)); //BootTime
            //���M�[��(IP�A�h���X�j
            serInfo.MemberInfo.Add(typeof(string)); //SendMachineIpAddr
            //���M�[��(�R���s���[�^�[���j
            serInfo.MemberInfo.Add(typeof(string)); //SendMachineName
            //S&E�ڑ����[�UID
            serInfo.MemberInfo.Add(typeof(string)); 
            //S&E�ڑ��p�X���[�h
            serInfo.MemberInfo.Add(typeof(string));
            //�[���ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); 

            serInfo.Serialize(writer, serInfo);
            if (graph is ConnectInfoWork)
            {
                ConnectInfoWork temp = (ConnectInfoWork)graph;

                SetConnectInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ConnectInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ConnectInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ConnectInfoWork temp in lst)
                {
                    SetConnectInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ConnectInfoWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 27; 

        /// <summary>
        ///  ConnectInfoWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetConnectInfoWork(System.IO.BinaryWriter writer, ConnectInfoWork temp)
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
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�ڑ��p�X���[�h
            writer.Write(temp.ConnectPassword);
            //�ڑ����[�UID
            writer.Write(temp.ConnectUserId);
            //������z�敪�i�_�C�n�c�j
            writer.Write(temp.DaihatsuOrdreDiv);
            //���O�C���^�C���A�E�g
            writer.Write(temp.LoginTimeoutVal);
            //����URL
            writer.Write(temp.OrderUrl);
            //�݌Ɋm�FURL
            writer.Write(temp.StockCheckUrl);
            //�ڑ��v���O�����^�C�v
            writer.Write(temp.CnectProgramType);
            //�ڑ��t�@�C��ID
            writer.Write(temp.CnectFileId);
            //�ڑ����M�敪
            writer.Write(temp.CnectSendDiv);
            //�ڑ��Ώۋ敪
            writer.Write(temp.CnectObjectDiv);
            //���g���C��
            writer.Write(temp.RetryCnt);
            //�������M�敪
            writer.Write(temp.AutoSendDiv);
            //�N������
            writer.Write(temp.BootTime);
            //���M�[��(IP�A�h���X�j
            writer.Write(temp.SendMachineIpAddr);
            //���M�[��(�R���s���[�^�[���j
            writer.Write(temp.SendMachineName);
            //S&E�ڑ����[�UID
            writer.Write(temp.SAndECnctUserId);
            //S&E�ڑ��p�X���[�h
            writer.Write(temp.SAndECnctPass);
            //�[���ԍ�
            writer.Write(temp.CashRegisterNo);
        }

        /// <summary>
        ///  ConnectInfoWork�C���X�^���X�擾
        /// </summary>
        /// <returns>ConnectInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private ConnectInfoWork GetConnectInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            ConnectInfoWork temp = new ConnectInfoWork();

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
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�ڑ��p�X���[�h
            temp.ConnectPassword = reader.ReadString();
            //�ڑ����[�UID
            temp.ConnectUserId = reader.ReadString();
            //������z�敪�i�_�C�n�c�j
            temp.DaihatsuOrdreDiv = reader.ReadInt32();
            //���O�C���^�C���A�E�g
            temp.LoginTimeoutVal = reader.ReadInt32();
            //����URL
            temp.OrderUrl = reader.ReadString();
            //�݌Ɋm�FURL
            temp.StockCheckUrl = reader.ReadString();
            //�ڑ��v���O�����^�C�v
            temp.CnectProgramType = reader.ReadInt32();
            //�ڑ��t�@�C��ID
            temp.CnectFileId = reader.ReadString();
            //�ڑ����M�敪
            temp.CnectSendDiv = reader.ReadInt32();
            //�ڑ��Ώۋ敪
            temp.CnectObjectDiv = reader.ReadInt32();
            //���g���C��
            temp.RetryCnt = reader.ReadInt32();
            //�������M�敪
            temp.AutoSendDiv = reader.ReadInt32();
            //�N������
            temp.BootTime = reader.ReadInt32();
            //���M�[��(IP�A�h���X�j
            temp.SendMachineIpAddr = reader.ReadString();
            //���M�[��(�R���s���[�^�[���j
            temp.SendMachineName = reader.ReadString();
            //S&E�ڑ����[�UID
            temp.SAndECnctUserId = reader.ReadString();
            //S&E�ڑ��p�X���[�h
            temp.SAndECnctPass = reader.ReadString();
            //�[���ԍ�
            temp.CashRegisterNo = reader.ReadInt32();

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
        /// <returns>ConnectInfoWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConnectInfoWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ConnectInfoWork temp = GetConnectInfoWork(reader, serInfo);
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
                    retValue = (ConnectInfoWork[])lst.ToArray(typeof(ConnectInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


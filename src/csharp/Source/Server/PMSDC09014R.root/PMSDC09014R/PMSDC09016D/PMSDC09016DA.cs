using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalCprtConnectInfoWork
    /// <summary>
    ///                      �ڑ�����ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ڑ�����ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2019/12/03</br>
    /// <br>Update Note      :   2020/02/04 ���c �`�[</br>
    /// <br>�Ǘ��ԍ�         :   11570219-00</br>
    /// <br>                 : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalCprtConnectInfoWork : IFileHeader
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

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�v���g�R��</summary>
        private Int32 _protocol;

        /// <summary>���O�C���^�C���A�E�g</summary>
        /// <remarks>�b</remarks>
        private Int32 _loginTimeoutVal;

        /// <summary>�A�g��h���C��</summary>
        private string _cprtDomain = "";

        /// <summary>�A�g��URL</summary>
        private string _cprtUrl = "";

        /// <summary>�ڑ��v���O�����^�C�v</summary>
        private Int32 _cnectProgramType;

        /// <summary>�ڑ��t�@�C��ID</summary>
        private string _cnectFileId = "";

        /// <summary>�ڑ����M�敪</summary>
        /// <remarks>0:�����M,1:�S��</remarks>
        private Int32 _cnectSendDiv;

        /// <summary>�ڑ��Ώۋ敪</summary>
        /// <remarks>0:�O��,1:����</remarks>
        private Int32 _cnectObjectDiv;

        /// <summary>���g���C��</summary>
        private Int32 _retryCnt;

        /// <summary>�������M�敪</summary>
        private Int32 _autoSendDiv;

        /// <summary>�N������</summary>
        private Int32 _bootTime;

        /// <summary>�I������</summary>
        private Int32 _endTime;

        /// <summary>���s�Ԋu</summary>
        private Int32 _execInterval;

        /// <summary>���M�[��(IP�A�h���X�j</summary>
        private string _sendMachineIpAddr = "";

        /// <summary>���M�[��(�R���s���[�^�[���j</summary>
        private string _sendMachineName = "";

        /// <summary>���M�ڑ��p�X���[�h</summary>
        private string _sendCcnctPass = "";

        /// <summary>���M�ڑ����[�U�[�R�[�h</summary>
        private string _sendCcnctUserid = "";

        /// <summary>���W�ԍ�</summary>
        /// <remarks>�}�V���ԍ�</remarks>
        private Int32 _cashregiSterno;

        /// <summary>�O�񎩓����M����</summary>
        /// <remarks>DateTime:���x��100�i�m�b</remarks>
        private DateTime _ltAtSadDateTime;

        /// <summary>���񑗐M���</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _frstSendDate;

        //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
        /// <summary>���l�P�ݒ�敪</summary>
        /// <remarks>0:���l�P,1:�w�����ԍ�,2:���M���Ȃ�</remarks>
        private Int32 _note1SetDiv;

        /// <summary>���l�Q�ݒ�敪</summary>
        /// <remarks>0:���l�Q,1:�w�����ԍ�,2:���M���Ȃ�</remarks>
        private Int32 _note2SetDiv;

        /// <summary>���l�R�ݒ�敪</summary>
        /// <remarks>0:���l�R,1:�w�����ԍ�,2:���M���Ȃ�</remarks>
        private Int32 _note3SetDiv;
        //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�         :   11570219-00</br>
        /// <br>                 : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
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

        /// public propaty name  :  Protocol
        /// <summary>�v���g�R���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v���g�R���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Protocol
        {
            get { return _protocol; }
            set { _protocol = value; }
        }

        /// public propaty name  :  LoginTimeoutVal
        /// <summary>���O�C���^�C���A�E�g�v���p�e�B</summary>
        /// <value>�b</value>
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

        /// public propaty name  :  CprtDomain
        /// <summary>�A�g��h���C���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g��h���C���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CprtDomain
        {
            get { return _cprtDomain; }
            set { _cprtDomain = value; }
        }

        /// public propaty name  :  CprtUrl
        /// <summary>�A�g��URL�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �A�g��URL�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CprtUrl
        {
            get { return _cprtUrl; }
            set { _cprtUrl = value; }
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
        /// <value>0:�����M,1:�S��</value>
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
        /// <value>0:�O��,1:����</value>
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

        /// public propaty name  :  EndTime
        /// <summary>�I�����ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        /// public propaty name  :  ExecInterval
        /// <summary>���s�Ԋu�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�Ԋu�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ExecInterval
        {
            get { return _execInterval; }
            set { _execInterval = value; }
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

        /// public propaty name  :  SendCcnctPass
        /// <summary>���M�ڑ��p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�ڑ��p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendCcnctPass
        {
            get { return _sendCcnctPass; }
            set { _sendCcnctPass = value; }
        }

        /// public propaty name  :  SendCcnctUserid
        /// <summary>���M�ڑ����[�U�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���M�ڑ����[�U�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SendCcnctUserid
        {
            get { return _sendCcnctUserid; }
            set { _sendCcnctUserid = value; }
        }

        /// public propaty name  :  CashregiSterno
        /// <summary>���W�ԍ��v���p�e�B</summary>
        /// <value>�}�V���ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���W�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashregiSterno
        {
            get { return _cashregiSterno; }
            set { _cashregiSterno = value; }
        }

        /// public propaty name  :  LtAtSadDateTime
        /// <summary>�O�񎩓����M�����v���p�e�B</summary>
        /// <value>DateTime:���x��100�i�m�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O�񎩓����M�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime LtAtSadDateTime
        {
            get { return _ltAtSadDateTime; }
            set { _ltAtSadDateTime = value; }
        }

        /// public propaty name  :  FrstSendDate
        /// <summary>���񑗐M����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񑗐M����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FrstSendDate
        {
            get { return _frstSendDate; }
            set { _frstSendDate = value; }
        }

        //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
        /// public propaty name  :  Note1SetDiv
        /// <summary>���l�P�ݒ�敪�v���p�e�B</summary>
        /// <value>0:���l�P,1:�w�����ԍ�,2:���M���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�P�ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Note1SetDiv
        {
            get { return _note1SetDiv; }
            set { _note1SetDiv = value; }
        }

        /// public propaty name  :  Note2SetDiv
        /// <summary>���l�Q�ݒ�敪�v���p�e�B</summary>
        /// <value>0:���l�Q,1:�w�����ԍ�,2:���M���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�Q�ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Note2SetDiv
        {
            get { return _note2SetDiv; }
            set { _note2SetDiv = value; }
        }

        /// public propaty name  :  Note3SetDiv
        /// <summary>���l�R�ݒ�敪�v���p�e�B</summary>
        /// <value>0:���l�R,1:�w�����ԍ�,2:���M���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�R�ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Note3SetDiv
        {
            get { return _note3SetDiv; }
            set { _note3SetDiv = value; }
        }
        //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

        /// <summary>
        /// ����A�g�ڑ���񃏁[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SalCprtConnectInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtConnectInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SalCprtConnectInfoWork()
        {
        }

        /// <summary>
        /// ����A�g�ڑ���񃏁[�N�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="supplierCd">�d����R�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="protocol">�v���g�R��</param>
		/// <param name="loginTimeoutVal">���O�C���^�C���A�E�g(�b)</param>
		/// <param name="cprtDomain">�A�g��h���C��</param>
		/// <param name="cprtUrl">�A�g��URL</param>
		/// <param name="cnectProgramType">�ڑ��v���O�����^�C�v</param>
		/// <param name="cnectFileId">�ڑ��t�@�C��ID</param>
		/// <param name="cnectSendDiv">�ڑ����M�敪(0:�����M,1:�S��)</param>
		/// <param name="cnectObjectDiv">�ڑ��Ώۋ敪(0:�O��,1:����)</param>
		/// <param name="retryCnt">���g���C��</param>
		/// <param name="autoSendDiv">�������M�敪</param>
		/// <param name="bootTime">�N������</param>
		/// <param name="endTime">�I������</param>
		/// <param name="execInterval">���s�Ԋu</param>
		/// <param name="sendMachineIpAddr">���M�[��(IP�A�h���X�j</param>
		/// <param name="sendMachineName">���M�[��(�R���s���[�^�[���j</param>
		/// <param name="sendCcnctPass">���M�ڑ��p�X���[�h</param>
		/// <param name="sendCcnctUserid">���M�ڑ����[�U�[�R�[�h</param>
		/// <param name="cashregiSterno">���W�ԍ�(�}�V���ԍ�)</param>
		/// <param name="ltAtSadDateTime">�O�񎩓����M����(DateTime:���x��100�i�m�b)</param>
		/// <param name="frstSendDate">���񑗐M���(YYYYMMDD)</param>
        /// <param name="note1SetDiv">���l�P�ݒ�敪(0:���l�P,1:�w�����ԍ�,2:���M���Ȃ�)</param>
        /// <param name="note2SetDiv">���l�Q�ݒ�敪(0:���l�P,1:�w�����ԍ�,2:���M���Ȃ�)</param>
        /// <param name="note3SetDiv">���l�R�ݒ�敪(0:���l�P,1:�w�����ԍ�,2:���M���Ȃ�)</param>
        /// <returns>SalCprtConnectInfo�N���X�̃C���X�^���X</returns>
		/// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtConnectInfoWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�         :   11570219-00</br>
        /// <br>                 : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        public SalCprtConnectInfoWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 supplierCd, string sectionCode, Int32 customerCode, Int32 protocol, Int32 loginTimeoutVal, string cprtDomain, string cprtUrl, Int32 cnectProgramType, string cnectFileId, Int32 cnectSendDiv, Int32 cnectObjectDiv, Int32 retryCnt, Int32 autoSendDiv, Int32 bootTime, Int32 endTime, Int32 execInterval, string sendMachineIpAddr, string sendMachineName, string sendCcnctPass, string sendCcnctUserid, Int32 cashregiSterno, DateTime ltAtSadDateTime, Int32 frstSendDate, Int32 note1SetDiv, Int32 note2SetDiv, Int32 note3SetDiv)
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
			this._sectionCode = sectionCode;
			this._customerCode = customerCode;
			this._protocol = protocol;
			this._loginTimeoutVal = loginTimeoutVal;
			this._cprtDomain = cprtDomain;
			this._cprtUrl = cprtUrl;
			this._cnectProgramType = cnectProgramType;
			this._cnectFileId = cnectFileId;
			this._cnectSendDiv = cnectSendDiv;
			this._cnectObjectDiv = cnectObjectDiv;
			this._retryCnt = retryCnt;
			this._autoSendDiv = autoSendDiv;
			this._bootTime = bootTime;
			this._endTime = endTime;
			this._execInterval = execInterval;
			this._sendMachineIpAddr = sendMachineIpAddr;
			this._sendMachineName = sendMachineName;
			this._sendCcnctPass = sendCcnctPass;
			this._sendCcnctUserid = sendCcnctUserid;
			this._cashregiSterno = cashregiSterno;
			this._ltAtSadDateTime = ltAtSadDateTime;
			this._frstSendDate = frstSendDate;
            //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            this._note1SetDiv = note1SetDiv;
            this._note2SetDiv = note2SetDiv;
            this._note3SetDiv = note3SetDiv;
            //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
		}
        /// <summary>
        /// ����A�g�ڑ����}�X�^��������
        /// </summary>
        /// <returns>SalCprtConnectInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalCprtConnectInfo�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�         :   11570219-00</br>
        /// <br>                 : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        public SalCprtConnectInfoWork Clone()
        {
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            //return new SalCprtConnectInfoWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierCd, this._sectionCode, this._customerCode, this._protocol, this._loginTimeoutVal, this._cprtDomain, this._cprtUrl, this._cnectProgramType, this._cnectFileId, this._cnectSendDiv, this._cnectObjectDiv, this._retryCnt, this._autoSendDiv, this._bootTime, this._endTime, this._execInterval, this._sendMachineIpAddr, this._sendMachineName, this._sendCcnctPass, this._sendCcnctUserid, this._cashregiSterno, this._ltAtSadDateTime, this._frstSendDate);
            return new SalCprtConnectInfoWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._supplierCd, this._sectionCode, this._customerCode, this._protocol, this._loginTimeoutVal, this._cprtDomain, this._cprtUrl, this._cnectProgramType, this._cnectFileId, this._cnectSendDiv, this._cnectObjectDiv, this._retryCnt, this._autoSendDiv, this._bootTime, this._endTime, this._execInterval, this._sendMachineIpAddr, this._sendMachineName, this._sendCcnctPass, this._sendCcnctUserid, this._cashregiSterno, this._ltAtSadDateTime, this._frstSendDate, this._note1SetDiv, this._note2SetDiv, this._note3SetDiv);
            //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
        }

    }


    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SalCprtConnectInfoWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SalCprtConnectInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SalCprtConnectInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtConnectInfoWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�         :   11570219-00</br>
        /// <br>                 : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalCprtConnectInfoWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalCprtConnectInfoWork || graph is ArrayList || graph is SalCprtConnectInfoWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SalCprtConnectInfoWork).FullName));

            if (graph != null && graph is SalCprtConnectInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalCprtConnectInfoWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalCprtConnectInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalCprtConnectInfoWork[])graph).Length;
            }
            else if (graph is SalCprtConnectInfoWork)
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
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�v���g�R��
            serInfo.MemberInfo.Add(typeof(Int32)); //Protocol
            //���O�C���^�C���A�E�g
            serInfo.MemberInfo.Add(typeof(Int32)); //LoginTimeoutVal
            //�A�g��h���C��
            serInfo.MemberInfo.Add(typeof(string)); //CprtDomain
            //�A�g��URL
            serInfo.MemberInfo.Add(typeof(string)); //CprtUrl
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
            //�I������
            serInfo.MemberInfo.Add(typeof(Int32)); //EndTime
            //���s�Ԋu
            serInfo.MemberInfo.Add(typeof(Int32)); //ExecInterval
            //���M�[��(IP�A�h���X�j
            serInfo.MemberInfo.Add(typeof(string)); //SendMachineIpAddr
            //���M�[��(�R���s���[�^�[���j
            serInfo.MemberInfo.Add(typeof(string)); //SendMachineName
            //���M�ڑ��p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //SendCcnctPass
            //���M�ڑ����[�U�[�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SendCcnctUserid
            //���W�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //CashregiSterno
            //�O�񎩓����M����
            serInfo.MemberInfo.Add(typeof(Int64)); //LtAtSadDateTime
            //���񑗐M���
            serInfo.MemberInfo.Add(typeof(Int32)); //FrstSendDate
            //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            //���l�P�ݒ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //Note1SetDiv
            //���l�Q�ݒ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //Note2SetDiv
            //���l�R�ݒ�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //Note3SetDiv
            //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

            serInfo.Serialize(writer, serInfo);
            if (graph is SalCprtConnectInfoWork)
            {
                SalCprtConnectInfoWork temp = (SalCprtConnectInfoWork)graph;

                SetSalCprtConnectInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalCprtConnectInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalCprtConnectInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalCprtConnectInfoWork temp in lst)
                {
                    SetSalCprtConnectInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalCprtConnectInfoWork�����o��(public�v���p�e�B��)
        /// </summary>
        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
        //private const int currentMemberCount = 31;
        private const int currentMemberCount = 34;
        //�� UPD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

        /// <summary>
        ///  SalCprtConnectInfoWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtConnectInfoWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�         :   11570219-00</br>
        /// <br>                 : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private void SetSalCprtConnectInfoWork(System.IO.BinaryWriter writer, SalCprtConnectInfoWork temp)
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
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�v���g�R��
            writer.Write(temp.Protocol);
            //���O�C���^�C���A�E�g
            writer.Write(temp.LoginTimeoutVal);
            //�A�g��h���C��
            writer.Write(temp.CprtDomain);
            //�A�g��URL
            writer.Write(temp.CprtUrl);
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
            //�I������
            writer.Write(temp.EndTime);
            //���s�Ԋu
            writer.Write(temp.ExecInterval);
            //���M�[��(IP�A�h���X�j
            writer.Write(temp.SendMachineIpAddr);
            //���M�[��(�R���s���[�^�[���j
            writer.Write(temp.SendMachineName);
            //���M�ڑ��p�X���[�h
            writer.Write(temp.SendCcnctPass);
            //���M�ڑ����[�U�[�R�[�h
            writer.Write(temp.SendCcnctUserid);
            //���W�ԍ�
            writer.Write(temp.CashregiSterno);
            //�O�񎩓����M����
            writer.Write((Int64)temp.LtAtSadDateTime.Ticks);
            //���񑗐M���
            writer.Write(temp.FrstSendDate);
            //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            //���l�P�ݒ�敪
            writer.Write(temp.Note1SetDiv);
            //���l�Q�ݒ�敪
            writer.Write(temp.Note2SetDiv);
            //���l�R�ݒ�敪
            writer.Write(temp.Note3SetDiv);
            //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
        }

        /// <summary>
        ///  SalCprtConnectInfoWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SalCprtConnectInfoWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtConnectInfoWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2020/02/04 ���c �`�[</br>
        /// <br>�Ǘ��ԍ�         :   11570219-00</br>
        /// <br>                 : �i�C�����e�ꗗNo.2�j���l�ݒ�ύX���ڒǉ�</br>
        /// </remarks>
        private SalCprtConnectInfoWork GetSalCprtConnectInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SalCprtConnectInfoWork temp = new SalCprtConnectInfoWork();

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
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�v���g�R��
            temp.Protocol = reader.ReadInt32();
            //���O�C���^�C���A�E�g
            temp.LoginTimeoutVal = reader.ReadInt32();
            //�A�g��h���C��
            temp.CprtDomain = reader.ReadString();
            //�A�g��URL
            temp.CprtUrl = reader.ReadString();
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
            //�I������
            temp.EndTime = reader.ReadInt32();
            //���s�Ԋu
            temp.ExecInterval = reader.ReadInt32();
            //���M�[��(IP�A�h���X�j
            temp.SendMachineIpAddr = reader.ReadString();
            //���M�[��(�R���s���[�^�[���j
            temp.SendMachineName = reader.ReadString();
            //���M�ڑ��p�X���[�h
            temp.SendCcnctPass = reader.ReadString();
            //���M�ڑ����[�U�[�R�[�h
            temp.SendCcnctUserid = reader.ReadString();
            //���W�ԍ�
            temp.CashregiSterno = reader.ReadInt32();
            //�O�񎩓����M����
            temp.LtAtSadDateTime = new DateTime(reader.ReadInt64());
            //���񑗐M���
            temp.FrstSendDate = reader.ReadInt32();
            //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2
            //���l�P�ݒ�敪
            temp.Note1SetDiv = reader.ReadInt32();
            //���l�Q�ݒ�敪
            temp.Note2SetDiv = reader.ReadInt32();
            //���l�R�ݒ�敪
            temp.Note3SetDiv = reader.ReadInt32();
            //�� ADD 2020/02/04 Y.Terada  �C�����e�ꗗNo.2

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
        /// <returns>SalCprtConnectInfoWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalCprtConnectInfoWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalCprtConnectInfoWork temp = GetSalCprtConnectInfoWork(reader, serInfo);
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
                    retValue = (SalCprtConnectInfoWork[])lst.ToArray(typeof(SalCprtConnectInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


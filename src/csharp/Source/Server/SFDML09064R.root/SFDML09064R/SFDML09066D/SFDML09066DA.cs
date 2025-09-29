using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MailSndMngWork
    /// <summary>
    ///                      ���[�����M�Ǘ����[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�����M�Ǘ����[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/03/05</br>
    /// <br>Genarated Date   :   2006/10/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006/09/29  980056 �c�c</br>
    /// <br>                 :   �e���ڂ�S�ʓI�Ɍ������B</br>
    /// <br>                 :   (�ύX�O�̃��C�A�E�g�̓}�X�^�����e�ȊO</br>
    /// <br>                 :   �g�p����Ă��Ȃ��̂ő啝�ȏC��������</br>
    /// <br>                 :   �܂�)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MailSndMngWork : IFileHeader
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

        /// <summary>e-mail���M�Ǘ��ԍ�</summary>
        /// <remarks>0 �Œ�</remarks>
        private Int32 _mailSendMngNo;

        /// <summary>���[���A�h���X</summary>
        /// <remarks>���[���̃��[���A�h���X</remarks>
        private string _mailAddress = "";

        /// <summary>�_�C�����A�b�v�敪</summary>
        /// <remarks>���[���̍ہALAN�ڑ����_�C���������f����0:LAN, 1:�_�C�����A�b�v</remarks>
        private Int32 _dialUpCode;

        /// <summary>�_�C�����A�b�v�ڑ�����</summary>
        /// <remarks>RAS�E���[���i�_�C�����A�b�v�ڑ��j�̍�</remarks>
        private string _dialUpConnectName = "";

        /// <summary>�_�C�����A�b�v���O�C����</summary>
        private string _dialUpLoginName = "";

        /// <summary>�_�C�����A�b�v�p�X���[�h</summary>
        private string _dialUpPassword = "";

        /// <summary>�ڑ���d�b�ԍ�</summary>
        private string _accessTelNo = "";

        /// <summary>POP3���[�U�[ID</summary>
        private string _pop3UserId = "";

        /// <summary>POP3�p�X���[�h</summary>
        private string _pop3Password = "";

        /// <summary>POP3�T�[�o�[��</summary>
        private string _pop3ServerName = "";

        /// <summary>SMTP�T�[�o�[��</summary>
        private string _smtpServerName = "";

        /// <summary>SMTP���[�UID</summary>
        /// <remarks>SMTP�F��ID</remarks>
        private string _smtpUserId = "";

        /// <summary>SMTP�p�X���[�h</summary>
        /// <remarks>SMTP�F�؃p�X���[�h</remarks>
        private string _smtpPassword = "";

        /// <summary>SMTP�F�؎g�p�敪</summary>
        /// <remarks>0:�g�p���Ȃ�, 1:POP�F�؂Ɠ���ID��p�X���[�h���g�p����, 2:SMTP�F�؂́V</remarks>
        private Int32 _smtpAuthUseDiv;

        /// <summary>���o�l��</summary>
        /// <remarks>���[���̍��o�l</remarks>
        private string _senderName = "";

        /// <summary>POP Before SMTP�g�p�敪</summary>
        /// <remarks>0:�g�p���Ȃ�, 1:�g�p����</remarks>
        private Int32 _popBeforeSmtpUseDiv;

        /// <summary>POP�T�[�o �|�[�g�ԍ�</summary>
        private Int32 _popServerPortNo;

        /// <summary>SMTP�T�[�o �|�[�g�ԍ�</summary>
        private Int32 _smtpServerPortNo;

        /// <summary>���[���T�[�o�^�C���A�E�g�l</summary>
        /// <remarks>�b</remarks>
        private Int32 _mailServerTimeoutVal;

        /// <summary>�o�b�N�A�b�v���M�敪</summary>
        /// <remarks>0:���ЃA�h���X�Ƀo�b�N�A�b�v���M����, 1:���M���Ȃ�</remarks>
        private Int32 _backupSendDivCd;

        /// <summary>�o�b�N�A�b�v�`��</summary>
        /// <remarks>0:���[���`��(BCC),  1:�ꗗ�\�`��(�Ȉ�)</remarks>
        private Int32 _backupFormal;

        /// <summary>���[�����M�����P�ʌ���</summary>
        /// <remarks>0:�����������Ȃ�, 0�ȊO:������������P�ʌ���</remarks>
        private Int32 _mailSendDivUnitCnt;


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

        /// public propaty name  :  MailSendMngNo
        /// <summary>e-mail���M�Ǘ��ԍ��v���p�e�B</summary>
        /// <value>0 �Œ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   e-mail���M�Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailSendMngNo
        {
            get { return _mailSendMngNo; }
            set { _mailSendMngNo = value; }
        }

        /// public propaty name  :  MailAddress
        /// <summary>���[���A�h���X�v���p�e�B</summary>
        /// <value>���[���̃��[���A�h���X</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress
        {
            get { return _mailAddress; }
            set { _mailAddress = value; }
        }

        /// public propaty name  :  DialUpCode
        /// <summary>�_�C�����A�b�v�敪�v���p�e�B</summary>
        /// <value>���[���̍ہALAN�ڑ����_�C���������f����0:LAN, 1:�_�C�����A�b�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_�C�����A�b�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DialUpCode
        {
            get { return _dialUpCode; }
            set { _dialUpCode = value; }
        }

        /// public propaty name  :  DialUpConnectName
        /// <summary>�_�C�����A�b�v�ڑ����̃v���p�e�B</summary>
        /// <value>RAS�E���[���i�_�C�����A�b�v�ڑ��j�̍�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_�C�����A�b�v�ڑ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DialUpConnectName
        {
            get { return _dialUpConnectName; }
            set { _dialUpConnectName = value; }
        }

        /// public propaty name  :  DialUpLoginName
        /// <summary>�_�C�����A�b�v���O�C�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_�C�����A�b�v���O�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DialUpLoginName
        {
            get { return _dialUpLoginName; }
            set { _dialUpLoginName = value; }
        }

        /// public propaty name  :  DialUpPassword
        /// <summary>�_�C�����A�b�v�p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_�C�����A�b�v�p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DialUpPassword
        {
            get { return _dialUpPassword; }
            set { _dialUpPassword = value; }
        }

        /// public propaty name  :  AccessTelNo
        /// <summary>�ڑ���d�b�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڑ���d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AccessTelNo
        {
            get { return _accessTelNo; }
            set { _accessTelNo = value; }
        }

        /// public propaty name  :  Pop3UserId
        /// <summary>POP3���[�U�[ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POP3���[�U�[ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Pop3UserId
        {
            get { return _pop3UserId; }
            set { _pop3UserId = value; }
        }

        /// public propaty name  :  Pop3Password
        /// <summary>POP3�p�X���[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POP3�p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Pop3Password
        {
            get { return _pop3Password; }
            set { _pop3Password = value; }
        }

        /// public propaty name  :  Pop3ServerName
        /// <summary>POP3�T�[�o�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POP3�T�[�o�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Pop3ServerName
        {
            get { return _pop3ServerName; }
            set { _pop3ServerName = value; }
        }

        /// public propaty name  :  SmtpServerName
        /// <summary>SMTP�T�[�o�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTP�T�[�o�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SmtpServerName
        {
            get { return _smtpServerName; }
            set { _smtpServerName = value; }
        }

        /// public propaty name  :  SmtpUserId
        /// <summary>SMTP���[�UID�v���p�e�B</summary>
        /// <value>SMTP�F��ID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTP���[�UID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SmtpUserId
        {
            get { return _smtpUserId; }
            set { _smtpUserId = value; }
        }

        /// public propaty name  :  SmtpPassword
        /// <summary>SMTP�p�X���[�h�v���p�e�B</summary>
        /// <value>SMTP�F�؃p�X���[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTP�p�X���[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SmtpPassword
        {
            get { return _smtpPassword; }
            set { _smtpPassword = value; }
        }

        /// public propaty name  :  SmtpAuthUseDiv
        /// <summary>SMTP�F�؎g�p�敪�v���p�e�B</summary>
        /// <value>0:�g�p���Ȃ�, 1:POP�F�؂Ɠ���ID��p�X���[�h���g�p����, 2:SMTP�F�؂́V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTP�F�؎g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SmtpAuthUseDiv
        {
            get { return _smtpAuthUseDiv; }
            set { _smtpAuthUseDiv = value; }
        }

        /// public propaty name  :  SenderName
        /// <summary>���o�l���v���p�e�B</summary>
        /// <value>���[���̍��o�l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���o�l���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SenderName
        {
            get { return _senderName; }
            set { _senderName = value; }
        }

        /// public propaty name  :  PopBeforeSmtpUseDiv
        /// <summary>POP Before SMTP�g�p�敪�v���p�e�B</summary>
        /// <value>0:�g�p���Ȃ�, 1:�g�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POP Before SMTP�g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PopBeforeSmtpUseDiv
        {
            get { return _popBeforeSmtpUseDiv; }
            set { _popBeforeSmtpUseDiv = value; }
        }

        /// public propaty name  :  PopServerPortNo
        /// <summary>POP�T�[�o �|�[�g�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   POP�T�[�o �|�[�g�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PopServerPortNo
        {
            get { return _popServerPortNo; }
            set { _popServerPortNo = value; }
        }

        /// public propaty name  :  SmtpServerPortNo
        /// <summary>SMTP�T�[�o �|�[�g�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SMTP�T�[�o �|�[�g�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SmtpServerPortNo
        {
            get { return _smtpServerPortNo; }
            set { _smtpServerPortNo = value; }
        }

        /// public propaty name  :  MailServerTimeoutVal
        /// <summary>���[���T�[�o�^�C���A�E�g�l�v���p�e�B</summary>
        /// <value>�b</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���T�[�o�^�C���A�E�g�l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailServerTimeoutVal
        {
            get { return _mailServerTimeoutVal; }
            set { _mailServerTimeoutVal = value; }
        }

        /// public propaty name  :  BackupSendDivCd
        /// <summary>�o�b�N�A�b�v���M�敪�v���p�e�B</summary>
        /// <value>0:���ЃA�h���X�Ƀo�b�N�A�b�v���M����, 1:���M���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v���M�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BackupSendDivCd
        {
            get { return _backupSendDivCd; }
            set { _backupSendDivCd = value; }
        }

        /// public propaty name  :  BackupFormal
        /// <summary>�o�b�N�A�b�v�`���v���p�e�B</summary>
        /// <value>0:���[���`��(BCC),  1:�ꗗ�\�`��(�Ȉ�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�b�N�A�b�v�`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BackupFormal
        {
            get { return _backupFormal; }
            set { _backupFormal = value; }
        }

        /// public propaty name  :  MailSendDivUnitCnt
        /// <summary>���[�����M�����P�ʌ����v���p�e�B</summary>
        /// <value>0:�����������Ȃ�, 0�ȊO:������������P�ʌ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�����M�����P�ʌ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailSendDivUnitCnt
        {
            get { return _mailSendDivUnitCnt; }
            set { _mailSendDivUnitCnt = value; }
        }


        /// <summary>
        /// ���[�����M�Ǘ����[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MailSndMngWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailSndMngWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailSndMngWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>MailSndMngWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   MailSndMngWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class MailSndMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailSndMngWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MailSndMngWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MailSndMngWork || graph is ArrayList || graph is MailSndMngWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(MailSndMngWork).FullName));

            if (graph != null && graph is MailSndMngWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MailSndMngWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MailSndMngWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MailSndMngWork[])graph).Length;
            }
            else if (graph is MailSndMngWork)
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
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //e-mail���M�Ǘ��ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendMngNo
            //���[���A�h���X
            serInfo.MemberInfo.Add(typeof(string)); //MailAddress
            //�_�C�����A�b�v�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DialUpCode
            //�_�C�����A�b�v�ڑ�����
            serInfo.MemberInfo.Add(typeof(string)); //DialUpConnectName
            //�_�C�����A�b�v���O�C����
            serInfo.MemberInfo.Add(typeof(string)); //DialUpLoginName
            //�_�C�����A�b�v�p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //DialUpPassword
            //�ڑ���d�b�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //AccessTelNo
            //POP3���[�U�[ID
            serInfo.MemberInfo.Add(typeof(string)); //Pop3UserId
            //POP3�p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //Pop3Password
            //POP3�T�[�o�[��
            serInfo.MemberInfo.Add(typeof(string)); //Pop3ServerName
            //SMTP�T�[�o�[��
            serInfo.MemberInfo.Add(typeof(string)); //SmtpServerName
            //SMTP���[�UID
            serInfo.MemberInfo.Add(typeof(string)); //SmtpUserId
            //SMTP�p�X���[�h
            serInfo.MemberInfo.Add(typeof(string)); //SmtpPassword
            //SMTP�F�؎g�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SmtpAuthUseDiv
            //���o�l��
            serInfo.MemberInfo.Add(typeof(string)); //SenderName
            //POP Before SMTP�g�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PopBeforeSmtpUseDiv
            //POP�T�[�o �|�[�g�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //PopServerPortNo
            //SMTP�T�[�o �|�[�g�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //SmtpServerPortNo
            //���[���T�[�o�^�C���A�E�g�l
            serInfo.MemberInfo.Add(typeof(Int32)); //MailServerTimeoutVal
            //�o�b�N�A�b�v���M�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //BackupSendDivCd
            //�o�b�N�A�b�v�`��
            serInfo.MemberInfo.Add(typeof(Int32)); //BackupFormal
            //���[�����M�����P�ʌ���
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendDivUnitCnt


            serInfo.Serialize(writer, serInfo);
            if (graph is MailSndMngWork)
            {
                MailSndMngWork temp = (MailSndMngWork)graph;

                SetMailSndMngWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MailSndMngWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MailSndMngWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MailSndMngWork temp in lst)
                {
                    SetMailSndMngWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MailSndMngWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 31;

        /// <summary>
        ///  MailSndMngWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailSndMngWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetMailSndMngWork(System.IO.BinaryWriter writer, MailSndMngWork temp)
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
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //e-mail���M�Ǘ��ԍ�
            writer.Write(temp.MailSendMngNo);
            //���[���A�h���X
            writer.Write(temp.MailAddress);
            //�_�C�����A�b�v�敪
            writer.Write(temp.DialUpCode);
            //�_�C�����A�b�v�ڑ�����
            writer.Write(temp.DialUpConnectName);
            //�_�C�����A�b�v���O�C����
            writer.Write(temp.DialUpLoginName);
            //�_�C�����A�b�v�p�X���[�h
            writer.Write(temp.DialUpPassword);
            //�ڑ���d�b�ԍ�
            writer.Write(temp.AccessTelNo);
            //POP3���[�U�[ID
            writer.Write(temp.Pop3UserId);
            //POP3�p�X���[�h
            writer.Write(temp.Pop3Password);
            //POP3�T�[�o�[��
            writer.Write(temp.Pop3ServerName);
            //SMTP�T�[�o�[��
            writer.Write(temp.SmtpServerName);
            //SMTP���[�UID
            writer.Write(temp.SmtpUserId);
            //SMTP�p�X���[�h
            writer.Write(temp.SmtpPassword);
            //SMTP�F�؎g�p�敪
            writer.Write(temp.SmtpAuthUseDiv);
            //���o�l��
            writer.Write(temp.SenderName);
            //POP Before SMTP�g�p�敪
            writer.Write(temp.PopBeforeSmtpUseDiv);
            //POP�T�[�o �|�[�g�ԍ�
            writer.Write(temp.PopServerPortNo);
            //SMTP�T�[�o �|�[�g�ԍ�
            writer.Write(temp.SmtpServerPortNo);
            //���[���T�[�o�^�C���A�E�g�l
            writer.Write(temp.MailServerTimeoutVal);
            //�o�b�N�A�b�v���M�敪
            writer.Write(temp.BackupSendDivCd);
            //�o�b�N�A�b�v�`��
            writer.Write(temp.BackupFormal);
            //���[�����M�����P�ʌ���
            writer.Write(temp.MailSendDivUnitCnt);

        }

        /// <summary>
        ///  MailSndMngWork�C���X�^���X�擾
        /// </summary>
        /// <returns>MailSndMngWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailSndMngWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private MailSndMngWork GetMailSndMngWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            MailSndMngWork temp = new MailSndMngWork();

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
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //e-mail���M�Ǘ��ԍ�
            temp.MailSendMngNo = reader.ReadInt32();
            //���[���A�h���X
            temp.MailAddress = reader.ReadString();
            //�_�C�����A�b�v�敪
            temp.DialUpCode = reader.ReadInt32();
            //�_�C�����A�b�v�ڑ�����
            temp.DialUpConnectName = reader.ReadString();
            //�_�C�����A�b�v���O�C����
            temp.DialUpLoginName = reader.ReadString();
            //�_�C�����A�b�v�p�X���[�h
            temp.DialUpPassword = reader.ReadString();
            //�ڑ���d�b�ԍ�
            temp.AccessTelNo = reader.ReadString();
            //POP3���[�U�[ID
            temp.Pop3UserId = reader.ReadString();
            //POP3�p�X���[�h
            temp.Pop3Password = reader.ReadString();
            //POP3�T�[�o�[��
            temp.Pop3ServerName = reader.ReadString();
            //SMTP�T�[�o�[��
            temp.SmtpServerName = reader.ReadString();
            //SMTP���[�UID
            temp.SmtpUserId = reader.ReadString();
            //SMTP�p�X���[�h
            temp.SmtpPassword = reader.ReadString();
            //SMTP�F�؎g�p�敪
            temp.SmtpAuthUseDiv = reader.ReadInt32();
            //���o�l��
            temp.SenderName = reader.ReadString();
            //POP Before SMTP�g�p�敪
            temp.PopBeforeSmtpUseDiv = reader.ReadInt32();
            //POP�T�[�o �|�[�g�ԍ�
            temp.PopServerPortNo = reader.ReadInt32();
            //SMTP�T�[�o �|�[�g�ԍ�
            temp.SmtpServerPortNo = reader.ReadInt32();
            //���[���T�[�o�^�C���A�E�g�l
            temp.MailServerTimeoutVal = reader.ReadInt32();
            //�o�b�N�A�b�v���M�敪
            temp.BackupSendDivCd = reader.ReadInt32();
            //�o�b�N�A�b�v�`��
            temp.BackupFormal = reader.ReadInt32();
            //���[�����M�����P�ʌ���
            temp.MailSendDivUnitCnt = reader.ReadInt32();


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
        /// <returns>MailSndMngWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailSndMngWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MailSndMngWork temp = GetMailSndMngWork(reader, serInfo);
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
                    retValue = (MailSndMngWork[])lst.ToArray(typeof(MailSndMngWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

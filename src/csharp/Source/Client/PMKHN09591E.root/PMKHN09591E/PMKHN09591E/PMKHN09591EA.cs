//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�����ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���[�����ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2010/05/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MailInfoSetting
    /// <summary>
    ///                      ���[�����ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�����ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/05/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MailInfoSetting
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

        /// <summary>�t�@�C���p�X��</summary>
        /// <remarks>���[���ۑ���p�X</remarks>
        private string _filePathNm = "";

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

        /// public propaty name  :  FilePathNm
        /// <summary>�t�@�C���p�X���v���p�e�B</summary>
        /// <value>���[���ۑ���p�X</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���p�X���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FilePathNm
        {
            get { return _filePathNm; }
            set { _filePathNm = value; }
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
        /// ���[�����ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>MailInfoSetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailInfoSetting�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailInfoSetting()
        {
        }

        /// <summary>
        /// ���[�����ݒ�}�X�^�R���X�g���N�^
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
        /// <param name="mailSendMngNo">e-mail���M�Ǘ��ԍ�(0 �Œ�)</param>
        /// <param name="mailAddress">���[���A�h���X(���[���̃��[���A�h���X)</param>
        /// <param name="dialUpCode">�_�C�����A�b�v�敪(���[���̍ہALAN�ڑ����_�C���������f����0:LAN, 1:�_�C�����A�b�v)</param>
        /// <param name="dialUpConnectName">�_�C�����A�b�v�ڑ�����(RAS�E���[���i�_�C�����A�b�v�ڑ��j�̍�)</param>
        /// <param name="dialUpLoginName">�_�C�����A�b�v���O�C����</param>
        /// <param name="dialUpPassword">�_�C�����A�b�v�p�X���[�h</param>
        /// <param name="accessTelNo">�ڑ���d�b�ԍ�</param>
        /// <param name="pop3UserId">POP3���[�U�[ID</param>
        /// <param name="pop3Password">POP3�p�X���[�h</param>
        /// <param name="pop3ServerName">POP3�T�[�o�[��</param>
        /// <param name="smtpServerName">SMTP�T�[�o�[��</param>
        /// <param name="smtpUserId">SMTP���[�UID(SMTP�F��ID)</param>
        /// <param name="smtpPassword">SMTP�p�X���[�h(SMTP�F�؃p�X���[�h)</param>
        /// <param name="smtpAuthUseDiv">SMTP�F�؎g�p�敪(0:�g�p���Ȃ�, 1:POP�F�؂Ɠ���ID��p�X���[�h���g�p����, 2:SMTP�F�؂́V)</param>
        /// <param name="senderName">���o�l��(���[���̍��o�l)</param>
        /// <param name="popBeforeSmtpUseDiv">POP Before SMTP�g�p�敪(0:�g�p���Ȃ�, 1:�g�p����)</param>
        /// <param name="popServerPortNo">POP�T�[�o �|�[�g�ԍ�</param>
        /// <param name="smtpServerPortNo">SMTP�T�[�o �|�[�g�ԍ�</param>
        /// <param name="mailServerTimeoutVal">���[���T�[�o�^�C���A�E�g�l(�b)</param>
        /// <param name="backupSendDivCd">�o�b�N�A�b�v���M�敪(0:���ЃA�h���X�Ƀo�b�N�A�b�v���M����, 1:���M���Ȃ�)</param>
        /// <param name="backupFormal">�o�b�N�A�b�v�`��(0:���[���`��(BCC),  1:�ꗗ�\�`��(�Ȉ�))</param>
        /// <param name="mailSendDivUnitCnt">���[�����M�����P�ʌ���(0:�����������Ȃ�, 0�ȊO:������������P�ʌ���)</param>
        /// <param name="filePathNm">�t�@�C���p�X��(���[���ۑ���p�X)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>MailInfoSetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailInfoSetting�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailInfoSetting(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 mailSendMngNo, string mailAddress, Int32 dialUpCode, string dialUpConnectName, string dialUpLoginName, string dialUpPassword, string accessTelNo, string pop3UserId, string pop3Password, string pop3ServerName, string smtpServerName, string smtpUserId, string smtpPassword, Int32 smtpAuthUseDiv, string senderName, Int32 popBeforeSmtpUseDiv, Int32 popServerPortNo, Int32 smtpServerPortNo, Int32 mailServerTimeoutVal, Int32 backupSendDivCd, Int32 backupFormal, Int32 mailSendDivUnitCnt, string filePathNm, string enterpriseName, string updEmployeeName)
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
            this._mailSendMngNo = mailSendMngNo;
            this._mailAddress = mailAddress;
            this._dialUpCode = dialUpCode;
            this._dialUpConnectName = dialUpConnectName;
            this._dialUpLoginName = dialUpLoginName;
            this._dialUpPassword = dialUpPassword;
            this._accessTelNo = accessTelNo;
            this._pop3UserId = pop3UserId;
            this._pop3Password = pop3Password;
            this._pop3ServerName = pop3ServerName;
            this._smtpServerName = smtpServerName;
            this._smtpUserId = smtpUserId;
            this._smtpPassword = smtpPassword;
            this._smtpAuthUseDiv = smtpAuthUseDiv;
            this._senderName = senderName;
            this._popBeforeSmtpUseDiv = popBeforeSmtpUseDiv;
            this._popServerPortNo = popServerPortNo;
            this._smtpServerPortNo = smtpServerPortNo;
            this._mailServerTimeoutVal = mailServerTimeoutVal;
            this._backupSendDivCd = backupSendDivCd;
            this._backupFormal = backupFormal;
            this._mailSendDivUnitCnt = mailSendDivUnitCnt;
            this._filePathNm = filePathNm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// ���[�����ݒ�}�X�^��������
        /// </summary>
        /// <returns>MailInfoSetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MailInfoSetting�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MailInfoSetting Clone()
        {
            return new MailInfoSetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._mailSendMngNo, this._mailAddress, this._dialUpCode, this._dialUpConnectName, this._dialUpLoginName, this._dialUpPassword, this._accessTelNo, this._pop3UserId, this._pop3Password, this._pop3ServerName, this._smtpServerName, this._smtpUserId, this._smtpPassword, this._smtpAuthUseDiv, this._senderName, this._popBeforeSmtpUseDiv, this._popServerPortNo, this._smtpServerPortNo, this._mailServerTimeoutVal, this._backupSendDivCd, this._backupFormal, this._mailSendDivUnitCnt, this._filePathNm, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// ���[�����ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MailInfoSetting�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailInfoSetting�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(MailInfoSetting target)
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
                 && (this.MailSendMngNo == target.MailSendMngNo)
                 && (this.MailAddress == target.MailAddress)
                 && (this.DialUpCode == target.DialUpCode)
                 && (this.DialUpConnectName == target.DialUpConnectName)
                 && (this.DialUpLoginName == target.DialUpLoginName)
                 && (this.DialUpPassword == target.DialUpPassword)
                 && (this.AccessTelNo == target.AccessTelNo)
                 && (this.Pop3UserId == target.Pop3UserId)
                 && (this.Pop3Password == target.Pop3Password)
                 && (this.Pop3ServerName == target.Pop3ServerName)
                 && (this.SmtpServerName == target.SmtpServerName)
                 && (this.SmtpUserId == target.SmtpUserId)
                 && (this.SmtpPassword == target.SmtpPassword)
                 && (this.SmtpAuthUseDiv == target.SmtpAuthUseDiv)
                 && (this.SenderName == target.SenderName)
                 && (this.PopBeforeSmtpUseDiv == target.PopBeforeSmtpUseDiv)
                 && (this.PopServerPortNo == target.PopServerPortNo)
                 && (this.SmtpServerPortNo == target.SmtpServerPortNo)
                 && (this.MailServerTimeoutVal == target.MailServerTimeoutVal)
                 && (this.BackupSendDivCd == target.BackupSendDivCd)
                 && (this.BackupFormal == target.BackupFormal)
                 && (this.MailSendDivUnitCnt == target.MailSendDivUnitCnt)
                 && (this.FilePathNm == target.FilePathNm)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// ���[�����ݒ�}�X�^��r����
        /// </summary>
        /// <param name="mailInfoSetting1">
        ///                    ��r����MailInfoSetting�N���X�̃C���X�^���X
        /// </param>
        /// <param name="mailInfoSetting2">��r����MailInfoSetting�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailInfoSetting�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(MailInfoSetting mailInfoSetting1, MailInfoSetting mailInfoSetting2)
        {
            return ((mailInfoSetting1.CreateDateTime == mailInfoSetting2.CreateDateTime)
                 && (mailInfoSetting1.UpdateDateTime == mailInfoSetting2.UpdateDateTime)
                 && (mailInfoSetting1.EnterpriseCode == mailInfoSetting2.EnterpriseCode)
                 && (mailInfoSetting1.FileHeaderGuid == mailInfoSetting2.FileHeaderGuid)
                 && (mailInfoSetting1.UpdEmployeeCode == mailInfoSetting2.UpdEmployeeCode)
                 && (mailInfoSetting1.UpdAssemblyId1 == mailInfoSetting2.UpdAssemblyId1)
                 && (mailInfoSetting1.UpdAssemblyId2 == mailInfoSetting2.UpdAssemblyId2)
                 && (mailInfoSetting1.LogicalDeleteCode == mailInfoSetting2.LogicalDeleteCode)
                 && (mailInfoSetting1.SectionCode == mailInfoSetting2.SectionCode)
                 && (mailInfoSetting1.MailSendMngNo == mailInfoSetting2.MailSendMngNo)
                 && (mailInfoSetting1.MailAddress == mailInfoSetting2.MailAddress)
                 && (mailInfoSetting1.DialUpCode == mailInfoSetting2.DialUpCode)
                 && (mailInfoSetting1.DialUpConnectName == mailInfoSetting2.DialUpConnectName)
                 && (mailInfoSetting1.DialUpLoginName == mailInfoSetting2.DialUpLoginName)
                 && (mailInfoSetting1.DialUpPassword == mailInfoSetting2.DialUpPassword)
                 && (mailInfoSetting1.AccessTelNo == mailInfoSetting2.AccessTelNo)
                 && (mailInfoSetting1.Pop3UserId == mailInfoSetting2.Pop3UserId)
                 && (mailInfoSetting1.Pop3Password == mailInfoSetting2.Pop3Password)
                 && (mailInfoSetting1.Pop3ServerName == mailInfoSetting2.Pop3ServerName)
                 && (mailInfoSetting1.SmtpServerName == mailInfoSetting2.SmtpServerName)
                 && (mailInfoSetting1.SmtpUserId == mailInfoSetting2.SmtpUserId)
                 && (mailInfoSetting1.SmtpPassword == mailInfoSetting2.SmtpPassword)
                 && (mailInfoSetting1.SmtpAuthUseDiv == mailInfoSetting2.SmtpAuthUseDiv)
                 && (mailInfoSetting1.SenderName == mailInfoSetting2.SenderName)
                 && (mailInfoSetting1.PopBeforeSmtpUseDiv == mailInfoSetting2.PopBeforeSmtpUseDiv)
                 && (mailInfoSetting1.PopServerPortNo == mailInfoSetting2.PopServerPortNo)
                 && (mailInfoSetting1.SmtpServerPortNo == mailInfoSetting2.SmtpServerPortNo)
                 && (mailInfoSetting1.MailServerTimeoutVal == mailInfoSetting2.MailServerTimeoutVal)
                 && (mailInfoSetting1.BackupSendDivCd == mailInfoSetting2.BackupSendDivCd)
                 && (mailInfoSetting1.BackupFormal == mailInfoSetting2.BackupFormal)
                 && (mailInfoSetting1.MailSendDivUnitCnt == mailInfoSetting2.MailSendDivUnitCnt)
                 && (mailInfoSetting1.FilePathNm == mailInfoSetting2.FilePathNm)
                 && (mailInfoSetting1.EnterpriseName == mailInfoSetting2.EnterpriseName)
                 && (mailInfoSetting1.UpdEmployeeName == mailInfoSetting2.UpdEmployeeName));
        }
        /// <summary>
        /// ���[�����ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MailInfoSetting�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailInfoSetting�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(MailInfoSetting target)
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
            if (this.MailSendMngNo != target.MailSendMngNo) resList.Add("MailSendMngNo");
            if (this.MailAddress != target.MailAddress) resList.Add("MailAddress");
            if (this.DialUpCode != target.DialUpCode) resList.Add("DialUpCode");
            if (this.DialUpConnectName != target.DialUpConnectName) resList.Add("DialUpConnectName");
            if (this.DialUpLoginName != target.DialUpLoginName) resList.Add("DialUpLoginName");
            if (this.DialUpPassword != target.DialUpPassword) resList.Add("DialUpPassword");
            if (this.AccessTelNo != target.AccessTelNo) resList.Add("AccessTelNo");
            if (this.Pop3UserId != target.Pop3UserId) resList.Add("Pop3UserId");
            if (this.Pop3Password != target.Pop3Password) resList.Add("Pop3Password");
            if (this.Pop3ServerName != target.Pop3ServerName) resList.Add("Pop3ServerName");
            if (this.SmtpServerName != target.SmtpServerName) resList.Add("SmtpServerName");
            if (this.SmtpUserId != target.SmtpUserId) resList.Add("SmtpUserId");
            if (this.SmtpPassword != target.SmtpPassword) resList.Add("SmtpPassword");
            if (this.SmtpAuthUseDiv != target.SmtpAuthUseDiv) resList.Add("SmtpAuthUseDiv");
            if (this.SenderName != target.SenderName) resList.Add("SenderName");
            if (this.PopBeforeSmtpUseDiv != target.PopBeforeSmtpUseDiv) resList.Add("PopBeforeSmtpUseDiv");
            if (this.PopServerPortNo != target.PopServerPortNo) resList.Add("PopServerPortNo");
            if (this.SmtpServerPortNo != target.SmtpServerPortNo) resList.Add("SmtpServerPortNo");
            if (this.MailServerTimeoutVal != target.MailServerTimeoutVal) resList.Add("MailServerTimeoutVal");
            if (this.BackupSendDivCd != target.BackupSendDivCd) resList.Add("BackupSendDivCd");
            if (this.BackupFormal != target.BackupFormal) resList.Add("BackupFormal");
            if (this.MailSendDivUnitCnt != target.MailSendDivUnitCnt) resList.Add("MailSendDivUnitCnt");
            if (this.FilePathNm != target.FilePathNm) resList.Add("FilePathNm");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// ���[�����ݒ�}�X�^��r����
        /// </summary>
        /// <param name="mailInfoSetting1">��r����MailInfoSetting�N���X�̃C���X�^���X</param>
        /// <param name="mailInfoSetting2">��r����MailInfoSetting�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MailInfoSetting�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(MailInfoSetting mailInfoSetting1, MailInfoSetting mailInfoSetting2)
        {
            ArrayList resList = new ArrayList();
            if (mailInfoSetting1.CreateDateTime != mailInfoSetting2.CreateDateTime) resList.Add("CreateDateTime");
            if (mailInfoSetting1.UpdateDateTime != mailInfoSetting2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (mailInfoSetting1.EnterpriseCode != mailInfoSetting2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (mailInfoSetting1.FileHeaderGuid != mailInfoSetting2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (mailInfoSetting1.UpdEmployeeCode != mailInfoSetting2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (mailInfoSetting1.UpdAssemblyId1 != mailInfoSetting2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (mailInfoSetting1.UpdAssemblyId2 != mailInfoSetting2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (mailInfoSetting1.LogicalDeleteCode != mailInfoSetting2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (mailInfoSetting1.SectionCode != mailInfoSetting2.SectionCode) resList.Add("SectionCode");
            if (mailInfoSetting1.MailSendMngNo != mailInfoSetting2.MailSendMngNo) resList.Add("MailSendMngNo");
            if (mailInfoSetting1.MailAddress != mailInfoSetting2.MailAddress) resList.Add("MailAddress");
            if (mailInfoSetting1.DialUpCode != mailInfoSetting2.DialUpCode) resList.Add("DialUpCode");
            if (mailInfoSetting1.DialUpConnectName != mailInfoSetting2.DialUpConnectName) resList.Add("DialUpConnectName");
            if (mailInfoSetting1.DialUpLoginName != mailInfoSetting2.DialUpLoginName) resList.Add("DialUpLoginName");
            if (mailInfoSetting1.DialUpPassword != mailInfoSetting2.DialUpPassword) resList.Add("DialUpPassword");
            if (mailInfoSetting1.AccessTelNo != mailInfoSetting2.AccessTelNo) resList.Add("AccessTelNo");
            if (mailInfoSetting1.Pop3UserId != mailInfoSetting2.Pop3UserId) resList.Add("Pop3UserId");
            if (mailInfoSetting1.Pop3Password != mailInfoSetting2.Pop3Password) resList.Add("Pop3Password");
            if (mailInfoSetting1.Pop3ServerName != mailInfoSetting2.Pop3ServerName) resList.Add("Pop3ServerName");
            if (mailInfoSetting1.SmtpServerName != mailInfoSetting2.SmtpServerName) resList.Add("SmtpServerName");
            if (mailInfoSetting1.SmtpUserId != mailInfoSetting2.SmtpUserId) resList.Add("SmtpUserId");
            if (mailInfoSetting1.SmtpPassword != mailInfoSetting2.SmtpPassword) resList.Add("SmtpPassword");
            if (mailInfoSetting1.SmtpAuthUseDiv != mailInfoSetting2.SmtpAuthUseDiv) resList.Add("SmtpAuthUseDiv");
            if (mailInfoSetting1.SenderName != mailInfoSetting2.SenderName) resList.Add("SenderName");
            if (mailInfoSetting1.PopBeforeSmtpUseDiv != mailInfoSetting2.PopBeforeSmtpUseDiv) resList.Add("PopBeforeSmtpUseDiv");
            if (mailInfoSetting1.PopServerPortNo != mailInfoSetting2.PopServerPortNo) resList.Add("PopServerPortNo");
            if (mailInfoSetting1.SmtpServerPortNo != mailInfoSetting2.SmtpServerPortNo) resList.Add("SmtpServerPortNo");
            if (mailInfoSetting1.MailServerTimeoutVal != mailInfoSetting2.MailServerTimeoutVal) resList.Add("MailServerTimeoutVal");
            if (mailInfoSetting1.BackupSendDivCd != mailInfoSetting2.BackupSendDivCd) resList.Add("BackupSendDivCd");
            if (mailInfoSetting1.BackupFormal != mailInfoSetting2.BackupFormal) resList.Add("BackupFormal");
            if (mailInfoSetting1.MailSendDivUnitCnt != mailInfoSetting2.MailSendDivUnitCnt) resList.Add("MailSendDivUnitCnt");
            if (mailInfoSetting1.FilePathNm != mailInfoSetting2.FilePathNm) resList.Add("FilePathNm");
            if (mailInfoSetting1.EnterpriseName != mailInfoSetting2.EnterpriseName) resList.Add("EnterpriseName");
            if (mailInfoSetting1.UpdEmployeeName != mailInfoSetting2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}

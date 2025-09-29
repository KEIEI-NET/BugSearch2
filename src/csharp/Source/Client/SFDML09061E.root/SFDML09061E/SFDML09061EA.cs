using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MailSndMng
	/// <summary>
	///                      ���[�����M�Ǘ��}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���[�����M�Ǘ��}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2005/03/05</br>
	/// <br>Genarated Date   :   2006/10/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2006/09/29  980056 �c�c</br>
	/// <br>                 :   �e���ڂ�S�ʓI�Ɍ������B</br>
	/// <br>                 :   (�ύX�O�̃��C�A�E�g�̓}�X�^�����e�ȊO</br>
	/// <br>                 :   �g�p����Ă��Ȃ��̂ő啝�ȏC��������</br>
	/// <br>                 :   �܂�)</br>
	/// </remarks>
	public class MailSndMng
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
			get{return _createDateTime;}
			set{_createDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
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
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
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
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
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
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
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
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
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
			get{return _sectionCode;}
			set{_sectionCode = value;}
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
			get{return _mailSendMngNo;}
			set{_mailSendMngNo = value;}
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
			get{return _mailAddress;}
			set{_mailAddress = value;}
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
			get{return _dialUpCode;}
			set{_dialUpCode = value;}
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
			get{return _dialUpConnectName;}
			set{_dialUpConnectName = value;}
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
			get{return _dialUpLoginName;}
			set{_dialUpLoginName = value;}
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
			get{return _dialUpPassword;}
			set{_dialUpPassword = value;}
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
			get{return _accessTelNo;}
			set{_accessTelNo = value;}
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
			get{return _pop3UserId;}
			set{_pop3UserId = value;}
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
			get{return _pop3Password;}
			set{_pop3Password = value;}
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
			get{return _pop3ServerName;}
			set{_pop3ServerName = value;}
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
			get{return _smtpServerName;}
			set{_smtpServerName = value;}
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
			get{return _smtpUserId;}
			set{_smtpUserId = value;}
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
			get{return _smtpPassword;}
			set{_smtpPassword = value;}
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
			get{return _smtpAuthUseDiv;}
			set{_smtpAuthUseDiv = value;}
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
			get{return _senderName;}
			set{_senderName = value;}
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
			get{return _popBeforeSmtpUseDiv;}
			set{_popBeforeSmtpUseDiv = value;}
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
			get{return _popServerPortNo;}
			set{_popServerPortNo = value;}
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
			get{return _smtpServerPortNo;}
			set{_smtpServerPortNo = value;}
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
			get{return _mailServerTimeoutVal;}
			set{_mailServerTimeoutVal = value;}
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
			get{return _backupSendDivCd;}
			set{_backupSendDivCd = value;}
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
			get{return _backupFormal;}
			set{_backupFormal = value;}
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
			get{return _mailSendDivUnitCnt;}
			set{_mailSendDivUnitCnt = value;}
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
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
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
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}


		/// <summary>
		/// ���[�����M�Ǘ��}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>MailSndMng�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailSndMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MailSndMng()
		{
		}

		/// <summary>
		/// ���[�����M�Ǘ��}�X�^�R���X�g���N�^
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
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>MailSndMng�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailSndMng�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MailSndMng(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 mailSendMngNo,string mailAddress,Int32 dialUpCode,string dialUpConnectName,string dialUpLoginName,string dialUpPassword,string accessTelNo,string pop3UserId,string pop3Password,string pop3ServerName,string smtpServerName,string smtpUserId,string smtpPassword,Int32 smtpAuthUseDiv,string senderName,Int32 popBeforeSmtpUseDiv,Int32 popServerPortNo,Int32 smtpServerPortNo,Int32 mailServerTimeoutVal,Int32 backupSendDivCd,Int32 backupFormal,Int32 mailSendDivUnitCnt,string enterpriseName,string updEmployeeName)
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
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// ���[�����M�Ǘ��}�X�^��������
		/// </summary>
		/// <returns>MailSndMng�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MailSndMng�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public MailSndMng Clone()
		{
			return new MailSndMng(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._mailSendMngNo,this._mailAddress,this._dialUpCode,this._dialUpConnectName,this._dialUpLoginName,this._dialUpPassword,this._accessTelNo,this._pop3UserId,this._pop3Password,this._pop3ServerName,this._smtpServerName,this._smtpUserId,this._smtpPassword,this._smtpAuthUseDiv,this._senderName,this._popBeforeSmtpUseDiv,this._popServerPortNo,this._smtpServerPortNo,this._mailServerTimeoutVal,this._backupSendDivCd,this._backupFormal,this._mailSendDivUnitCnt,this._enterpriseName,this._updEmployeeName);
		}

		/// <summary>
		/// ���[�����M�Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�MailSndMng�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailSndMng�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(MailSndMng target)
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
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// ���[�����M�Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="mailSndMng1">
		///                    ��r����MailSndMng�N���X�̃C���X�^���X
		/// </param>
		/// <param name="mailSndMng2">��r����MailSndMng�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailSndMng�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(MailSndMng mailSndMng1, MailSndMng mailSndMng2)
		{
			return ((mailSndMng1.CreateDateTime == mailSndMng2.CreateDateTime)
				 && (mailSndMng1.UpdateDateTime == mailSndMng2.UpdateDateTime)
				 && (mailSndMng1.EnterpriseCode == mailSndMng2.EnterpriseCode)
				 && (mailSndMng1.FileHeaderGuid == mailSndMng2.FileHeaderGuid)
				 && (mailSndMng1.UpdEmployeeCode == mailSndMng2.UpdEmployeeCode)
				 && (mailSndMng1.UpdAssemblyId1 == mailSndMng2.UpdAssemblyId1)
				 && (mailSndMng1.UpdAssemblyId2 == mailSndMng2.UpdAssemblyId2)
				 && (mailSndMng1.LogicalDeleteCode == mailSndMng2.LogicalDeleteCode)
				 && (mailSndMng1.SectionCode == mailSndMng2.SectionCode)
				 && (mailSndMng1.MailSendMngNo == mailSndMng2.MailSendMngNo)
				 && (mailSndMng1.MailAddress == mailSndMng2.MailAddress)
				 && (mailSndMng1.DialUpCode == mailSndMng2.DialUpCode)
				 && (mailSndMng1.DialUpConnectName == mailSndMng2.DialUpConnectName)
				 && (mailSndMng1.DialUpLoginName == mailSndMng2.DialUpLoginName)
				 && (mailSndMng1.DialUpPassword == mailSndMng2.DialUpPassword)
				 && (mailSndMng1.AccessTelNo == mailSndMng2.AccessTelNo)
				 && (mailSndMng1.Pop3UserId == mailSndMng2.Pop3UserId)
				 && (mailSndMng1.Pop3Password == mailSndMng2.Pop3Password)
				 && (mailSndMng1.Pop3ServerName == mailSndMng2.Pop3ServerName)
				 && (mailSndMng1.SmtpServerName == mailSndMng2.SmtpServerName)
				 && (mailSndMng1.SmtpUserId == mailSndMng2.SmtpUserId)
				 && (mailSndMng1.SmtpPassword == mailSndMng2.SmtpPassword)
				 && (mailSndMng1.SmtpAuthUseDiv == mailSndMng2.SmtpAuthUseDiv)
				 && (mailSndMng1.SenderName == mailSndMng2.SenderName)
				 && (mailSndMng1.PopBeforeSmtpUseDiv == mailSndMng2.PopBeforeSmtpUseDiv)
				 && (mailSndMng1.PopServerPortNo == mailSndMng2.PopServerPortNo)
				 && (mailSndMng1.SmtpServerPortNo == mailSndMng2.SmtpServerPortNo)
				 && (mailSndMng1.MailServerTimeoutVal == mailSndMng2.MailServerTimeoutVal)
				 && (mailSndMng1.BackupSendDivCd == mailSndMng2.BackupSendDivCd)
				 && (mailSndMng1.BackupFormal == mailSndMng2.BackupFormal)
				 && (mailSndMng1.MailSendDivUnitCnt == mailSndMng2.MailSendDivUnitCnt)
				 && (mailSndMng1.EnterpriseName == mailSndMng2.EnterpriseName)
				 && (mailSndMng1.UpdEmployeeName == mailSndMng2.UpdEmployeeName));
		}
		/// <summary>
		/// ���[�����M�Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�MailSndMng�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailSndMng�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(MailSndMng target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.MailSendMngNo != target.MailSendMngNo)resList.Add("MailSendMngNo");
			if(this.MailAddress != target.MailAddress)resList.Add("MailAddress");
			if(this.DialUpCode != target.DialUpCode)resList.Add("DialUpCode");
			if(this.DialUpConnectName != target.DialUpConnectName)resList.Add("DialUpConnectName");
			if(this.DialUpLoginName != target.DialUpLoginName)resList.Add("DialUpLoginName");
			if(this.DialUpPassword != target.DialUpPassword)resList.Add("DialUpPassword");
			if(this.AccessTelNo != target.AccessTelNo)resList.Add("AccessTelNo");
			if(this.Pop3UserId != target.Pop3UserId)resList.Add("Pop3UserId");
			if(this.Pop3Password != target.Pop3Password)resList.Add("Pop3Password");
			if(this.Pop3ServerName != target.Pop3ServerName)resList.Add("Pop3ServerName");
			if(this.SmtpServerName != target.SmtpServerName)resList.Add("SmtpServerName");
			if(this.SmtpUserId != target.SmtpUserId)resList.Add("SmtpUserId");
			if(this.SmtpPassword != target.SmtpPassword)resList.Add("SmtpPassword");
			if(this.SmtpAuthUseDiv != target.SmtpAuthUseDiv)resList.Add("SmtpAuthUseDiv");
			if(this.SenderName != target.SenderName)resList.Add("SenderName");
			if(this.PopBeforeSmtpUseDiv != target.PopBeforeSmtpUseDiv)resList.Add("PopBeforeSmtpUseDiv");
			if(this.PopServerPortNo != target.PopServerPortNo)resList.Add("PopServerPortNo");
			if(this.SmtpServerPortNo != target.SmtpServerPortNo)resList.Add("SmtpServerPortNo");
			if(this.MailServerTimeoutVal != target.MailServerTimeoutVal)resList.Add("MailServerTimeoutVal");
			if(this.BackupSendDivCd != target.BackupSendDivCd)resList.Add("BackupSendDivCd");
			if(this.BackupFormal != target.BackupFormal)resList.Add("BackupFormal");
			if(this.MailSendDivUnitCnt != target.MailSendDivUnitCnt)resList.Add("MailSendDivUnitCnt");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// ���[�����M�Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="mailSndMng1">��r����MailSndMng�N���X�̃C���X�^���X</param>
		/// <param name="mailSndMng2">��r����MailSndMng�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   MailSndMng�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(MailSndMng mailSndMng1, MailSndMng mailSndMng2)
		{
			ArrayList resList = new ArrayList();
			if(mailSndMng1.CreateDateTime != mailSndMng2.CreateDateTime)resList.Add("CreateDateTime");
			if(mailSndMng1.UpdateDateTime != mailSndMng2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(mailSndMng1.EnterpriseCode != mailSndMng2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(mailSndMng1.FileHeaderGuid != mailSndMng2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(mailSndMng1.UpdEmployeeCode != mailSndMng2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(mailSndMng1.UpdAssemblyId1 != mailSndMng2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(mailSndMng1.UpdAssemblyId2 != mailSndMng2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(mailSndMng1.LogicalDeleteCode != mailSndMng2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(mailSndMng1.SectionCode != mailSndMng2.SectionCode)resList.Add("SectionCode");
			if(mailSndMng1.MailSendMngNo != mailSndMng2.MailSendMngNo)resList.Add("MailSendMngNo");
			if(mailSndMng1.MailAddress != mailSndMng2.MailAddress)resList.Add("MailAddress");
			if(mailSndMng1.DialUpCode != mailSndMng2.DialUpCode)resList.Add("DialUpCode");
			if(mailSndMng1.DialUpConnectName != mailSndMng2.DialUpConnectName)resList.Add("DialUpConnectName");
			if(mailSndMng1.DialUpLoginName != mailSndMng2.DialUpLoginName)resList.Add("DialUpLoginName");
			if(mailSndMng1.DialUpPassword != mailSndMng2.DialUpPassword)resList.Add("DialUpPassword");
			if(mailSndMng1.AccessTelNo != mailSndMng2.AccessTelNo)resList.Add("AccessTelNo");
			if(mailSndMng1.Pop3UserId != mailSndMng2.Pop3UserId)resList.Add("Pop3UserId");
			if(mailSndMng1.Pop3Password != mailSndMng2.Pop3Password)resList.Add("Pop3Password");
			if(mailSndMng1.Pop3ServerName != mailSndMng2.Pop3ServerName)resList.Add("Pop3ServerName");
			if(mailSndMng1.SmtpServerName != mailSndMng2.SmtpServerName)resList.Add("SmtpServerName");
			if(mailSndMng1.SmtpUserId != mailSndMng2.SmtpUserId)resList.Add("SmtpUserId");
			if(mailSndMng1.SmtpPassword != mailSndMng2.SmtpPassword)resList.Add("SmtpPassword");
			if(mailSndMng1.SmtpAuthUseDiv != mailSndMng2.SmtpAuthUseDiv)resList.Add("SmtpAuthUseDiv");
			if(mailSndMng1.SenderName != mailSndMng2.SenderName)resList.Add("SenderName");
			if(mailSndMng1.PopBeforeSmtpUseDiv != mailSndMng2.PopBeforeSmtpUseDiv)resList.Add("PopBeforeSmtpUseDiv");
			if(mailSndMng1.PopServerPortNo != mailSndMng2.PopServerPortNo)resList.Add("PopServerPortNo");
			if(mailSndMng1.SmtpServerPortNo != mailSndMng2.SmtpServerPortNo)resList.Add("SmtpServerPortNo");
			if(mailSndMng1.MailServerTimeoutVal != mailSndMng2.MailServerTimeoutVal)resList.Add("MailServerTimeoutVal");
			if(mailSndMng1.BackupSendDivCd != mailSndMng2.BackupSendDivCd)resList.Add("BackupSendDivCd");
			if(mailSndMng1.BackupFormal != mailSndMng2.BackupFormal)resList.Add("BackupFormal");
			if(mailSndMng1.MailSendDivUnitCnt != mailSndMng2.MailSendDivUnitCnt)resList.Add("MailSendDivUnitCnt");
			if(mailSndMng1.EnterpriseName != mailSndMng2.EnterpriseName)resList.Add("EnterpriseName");
			if(mailSndMng1.UpdEmployeeName != mailSndMng2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}

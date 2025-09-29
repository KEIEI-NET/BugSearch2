using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Net.Mail;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// E-Mail���M���C�u����
	/// </summary>
	/// <remarks>
	/// <br>Note       : E-Mail�̑��M���s���N���X�ł��B</br>
	/// <br>Programer  : 980034 ����  ��`</br>
	/// <br>Date       : 2010.05.25</br>
	/// <br></br>
	/// <br>UpdateNote : XXXX.XX.XX �w�w�w�w</br>
	/// </remarks>
	public class NsEMailSender : IMailSender
	{
		#region Constructor
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public NsEMailSender()
		{

		}
		#endregion

		#region Private Fields
		/// <summary>���[�����M���i</summary>
		private TSMTP _tsmtp;

		/// <summary>���[�����M���C�u��������p�����[�^</summary>
		private MailSenderOperationInfo _mailSenderOperationInfo;
		/// <summary>���M�Ώۃ��[���f�[�^�\�[�X</summary>
		private MailSourceData _mailSendSourceData;
		/// <summary>�o�b�N�A�b�v�폜�Ώۃf�[�^�\�[�X</summary>
		private MailSourceData _deleteBackupSourceData;
		/// <summary>���M�����������Ώۃf�[�^�\�[�X</summary>
		private MailSourceData _initSendHistorySourceData;
		/// <summary>���[�����M�Ǘ��}�X�^</summary>
        private MailInfoSetting _mailInfoSetting;

		/// <summary>���[�����M�p�ҋ@�t���O</summary>
		private bool _mailSendWaitFlg;

		/// <summary>�������b�N�I�u�W�F�N�g</summary>
		private object _syncRoot = new object();

		/// <summary>�������M���E���h</summary>
		private int _splitSendRound;

        /// <summary>�����I���t���O</summary>
        private bool _sendEndFlg = false;
        
		/// <summary>���[�����M�����쐬���C�u��������C���^�t�F�[�X</summary>
		private IMailSendingHistoryMaker _iMailSendingHistoryMaker;

        // PGID
		private const string ctPGID = "PMKHN07505C";
		#endregion

		#region Public Properties
		#region IMailSender Member
		/// <summary>
		/// ���[�����M���C�u�����@�o�[�W����
		/// </summary>
		public string Version
		{
			get { return ".NS MailService 1.1.1.0"; }
        }
        #endregion

        /// <summary>
        /// �����I���t���O
        /// </summary>
        public bool SendEndFlg
        {
            get { return _sendEndFlg; }
        }
		#endregion

		#region Public Methods
		#region IMailSender Member
		/// <summary>
		/// ���[�����M����
		/// </summary>
		/// <param name="mailSenderOperationInfo">���[�����M���C�u��������p�����[�^</param>
		/// <param name="mailSourceData">���M�Ώۃ��[���f�[�^�\�[�X</param>
		/// <returns>�X�e�[�^�X</returns>
		public int SendMail(ref MailSenderOperationInfo mailSenderOperationInfo, MailSourceData mailSourceData)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			// �p�����[�^���v���C�x�[�g�ϐ��Ɏ擾
			this._mailSenderOperationInfo = mailSenderOperationInfo;

			// �߂�p�����[�^������
			this._mailSenderOperationInfo.SendStatus = status;
			this._mailSenderOperationInfo.StatusMessage = "";

			// �p�����[�^�`�F�b�N
			if ((mailSourceData == null) ||
				(mailSourceData.MailDataList == null) ||
				!(mailSourceData.MailDataList.Tables.Contains(MailSourceData.TABLE_MailDataList)) ||
				(mailSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count == 0))
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				this.ShowMessageProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���[�����M�f�[�^������܂���", status);
				return status;
			}

			//** ���[���ݒ���擾 **//
			MailInfoBase mailInfoBase = new MailInfoBase(MailServiceInfoCreateMode.MailSender);

			// ���[�����M�Ǘ��}�X�^
			mailInfoBase.GetMailInfoSetting(out this._mailInfoSetting);

			//** E-Mail���M�O���� **//
			// �t�������pIF�C���X�^���X�擾�E�o�b�N�A�b�v�̏���ꊇ�o�^etc�����s
			status = this.BeforeSendMailOpeProc(ref mailSourceData);

			if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				if (this._mailInfoSetting.DialUpCode == 1)		// �_�C�����A�b�v�L��
				{
					//** �_�C�A���A�b�v�ڑ� **//
					status = this.DialUpConnectionProc();
				}

				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					//** �l�b�g���[�N�m�F **//
					if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
					{
						status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
						this.ShowMessageProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�l�b�g���[�N�ɐڑ�����Ă��܂���", status);
					}

					try
					{
						if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
						{
							//** E-Mail���M���� **//
							status = SendEMailProc();
						}
					}
					catch (Exception ex)
					{
						this.ReleaseMailSendWait((int)ConstantManagement.MethodResult.ctFNC_ERROR, ex.Message, ex);
					}
				}
			}

			//** E-Mail���M�㏈�� **//
			status = this.AfterSendMailOpeProc();

			// �߂�p�����[�^�Z�b�g
			mailSenderOperationInfo = this._mailSenderOperationInfo;

			return this._mailSenderOperationInfo.SendStatus;
		}

		/// <summary>
		/// ���[�����M�֘A�f�[�^�쐬
		/// </summary>
		/// <param name="mailSourceData"></param>
		private void CreateMailSendProcData(ref MailSourceData mailSourceData)
		{
			if ((this._mailSendSourceData != null) && (this._mailSendSourceData.MailDataList != null))
			{
				this._mailSendSourceData.MailDataList.Dispose();
			}
			this._mailSendSourceData = new MailSourceData();

			if ((this._deleteBackupSourceData != null) && (this._deleteBackupSourceData.MailDataList != null))
			{
				this._deleteBackupSourceData.MailDataList.Dispose();
			}
			this._deleteBackupSourceData = new MailSourceData();

			if ((this._initSendHistorySourceData != null) && (this._initSendHistorySourceData.MailDataList != null))
			{
				this._initSendHistorySourceData.MailDataList.Dispose();
			}
			this._initSendHistorySourceData = new MailSourceData();

			// �f�[�^�Z�b�g���쐬���Ȃ���
			this._mailSendSourceData.MailDataList = mailSourceData.MailDataList.Clone();		// �X�L�[�}�̂݃R�s�[
			this._deleteBackupSourceData.MailDataList = mailSourceData.MailDataList.Clone();	// �X�L�[�}�̂݃R�s�[
			this._initSendHistorySourceData.MailDataList = mailSourceData.MailDataList.Clone();	// �X�L�[�}�̂݃R�s�[

			DataTable wkMailTable = this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList];
			DateTime nowTime = Broadleaf.Library.Globarization.TDateTime.GetSFDateNow();
			long sendDateTime = Convert.ToInt64(nowTime.ToString("yyyyMMddHHmmss"));

			foreach (DataRow wkRow in mailSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows)
			{
				// ���M�敪��[0:�񑗐M] or �_���폜�敪��[0:�L��]�ȊO�͑��M�f�[�^�ΏۊO
				if (((int)wkRow[MailSourceData.MEMBER_MailData_MailSendCode1] == 0) ||
					((int)wkRow[MailSourceData.MEMBER_MailData_LogicalDeleteCode] != 0))
				{
					continue;
				}

				// ���M�Ώۃf�[�^�̂���,���[���X�e�[�^�X[5:�G���[�����M]�̓o�b�N�A�b�v�폜�Ώۃf�[�^
				// ���M�Ώۃf�[�^�̂���,���[���X�e�[�^�X[5:�G���[�����M]�͑��M�����������Ώۃf�[�^
				if ((int)wkRow[MailSourceData.MEMBER_MailData_MailStatus] == MailBackup.MailBackup_MailStatus_ERROR)
				{
					this._deleteBackupSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Add(wkRow.ItemArray);
					this._initSendHistorySourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Add(wkRow.ItemArray);
				}

				// ���M�f�[�^�R�s�[
				wkMailTable.Rows.Add(wkRow.ItemArray);

				// �O��G���[�f�[�^�������ꍇ�̓w�b�_���ڍ폜(�ꊇ�o�^���ɍēo�^�����悤��)
				if ((int)wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_MailStatus] == MailBackup.MailBackup_MailStatus_ERROR)
				{
					wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_CreateDateTime] = DateTime.MinValue;
					wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_UpdateDateTime] = DateTime.MinValue;
					wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_FileHeaderGuid] = Guid.Empty;
					wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_MailManagementConsNo] = 0;
				}

				// ���M���o�b�N�A�b�v�ꊇ�o�^�p�Ƀ��[���X�e�[�^�X(5:�G���[�����M)�Ƒ��M�������Z�b�g
				wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_MailStatus] = MailBackup.MailBackup_MailStatus_ERROR;
				wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_SendDateTime] = sendDateTime;

			}
		}
		#endregion
		#endregion

		#region Private Methods
		/// <summary>
		/// �_�C�A���A�b�v�ڑ�����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		private int DialUpConnectionProc()
		{
			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}

		/// <summary>
		/// E-Mail���M����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		private int SendEMailProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			//** ���[�����M���i������ **//
			if (this._tsmtp != null)
			{
				this._tsmtp.SmtpEndSend -= new EventHandler<TSMTP.SendEndEventArgs>(this.TSMTP_SmtpEndSend);
				this._tsmtp.SmtpBusyChanged -= new EventHandler<TSMTP.SendingEventArgs>(this.TSMTP_SmtpBusyChanged);
				this._tsmtp.SmtpConnectedChangedEx -= new EventHandler<TSMTP.SendingEventArgs>(this.TSMTP_SmtpConnectedChangedEx);
				this._tsmtp.Dispose();
				this._tsmtp = null;
			}
			this._tsmtp = new TSMTP();
			this._tsmtp.SmtpEndSend += new EventHandler<TSMTP.SendEndEventArgs>(this.TSMTP_SmtpEndSend);
			this._tsmtp.SmtpBusyChanged += new EventHandler<TSMTP.SendingEventArgs>(this.TSMTP_SmtpBusyChanged);
			this._tsmtp.SmtpConnectedChangedEx += new EventHandler<TSMTP.SendingEventArgs>(this.TSMTP_SmtpConnectedChangedEx);

			//this._tsmtp.MailOptions.SendMethodEnumType = SendMethodEnumTypes.Synchronous;		// ���M���\�b�h�������[�h(�C�x���g�L��(���w���i���M�����̂ݓ���))
			this._tsmtp.MailOptions.DividingSend = true;										// ���M��ʕ������M�ݒ�-ON
			this._tsmtp.ProgressDialog = this._mailSenderOperationInfo.DispProgressDialog;		// �i���_�C�A���O�\���L��
			this._tsmtp.DialogConfirm = false;

			// �f�o�b�O�I�v�V����
			NsEMailSenderOptionInfo optionInfo;
			if (NsEMailSenderOption.GetOptionInfo(out optionInfo))
			{
				this._tsmtp.TraceOptions.Trace = optionInfo.TraceMode;
				this._tsmtp.TraceOptions.TraceLog = optionInfo.TraceLog;
				this._tsmtp.TraceOptions.TraceLogPath = optionInfo.TraceLogPath;
			}

			//** �T�[�o�[�ڑ��֘A�ݒ菈�� **//
			this.ConnectServerSetting();

			// �ꊇ���M����ő匏�����l��
			this._splitSendRound = 0;
			int sendUnitCnt = this._mailInfoSetting.MailSendDivUnitCnt;
			if (sendUnitCnt == 0)
			{
				status = this.SendEMailSubProc(0, this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count);
			}
			else
			{
				// �������M
				int roopCnt = this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count / sendUnitCnt;
				roopCnt += ((this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count % sendUnitCnt) == 0) ? 0 : 1;

				for (int i = 0; i < roopCnt; i++ )
				{
					status = this.SendEMailSubProc(i * sendUnitCnt, sendUnitCnt);

					if (status != 0) break;
					this._splitSendRound++;
				}
			}

			return status;
		}

		/// <summary>
		/// E-Mail���M�T�u����
		/// </summary>
		/// <param name="startDataIndex">���M�f�[�^�ݒ�J�n�C���f�b�N�X</param>
		/// <param name="setDataCount">���M�f�[�^�ݒ�Ώی���</param>
		/// <returns></returns>
		private int SendEMailSubProc(int startDataIndex, int setDataCount)
		{
			int status;

			// �ҋ@�p�t���O������
			this._mailSendWaitFlg = true;

			//** E-Mail���M�f�[�^�ݒ菈�� **//
			this.SendMailMessagesSetting(startDataIndex, setDataCount);

			//** E-Mail���M!! **//
			// ��POP Before SMTP�Ń��O�C���G���[�����������ꍇ�A�{���\�b�h�ŃG���[���߂��Ă��܂��B
			status = this._tsmtp.SendMessage();

			if (status != 0)
			{
				this.ShowErrMessageProc(0, "���[���̑��M�Ɏ��s���܂���\r\n" + this._tsmtp.StatusMessage, this._tsmtp.Status, null);
				return status;
			}
            /*
			// �񓯊����M�̏ꍇ�̓X���b�h�ҋ@
			if (this._tsmtp.MailOptions.SendMethodEnumType == SendMethodEnumTypes.Asynchronous)
			{
				while ((this._mailSendWaitFlg || this._tsmtp.BusyStatus || this._tsmtp.ConnectedStatus))
				{
					Thread.Sleep(1000);
					System.Windows.Forms.Application.DoEvents();
				}
			}
            */
			// Stream�̉��
			for (int i = 0; i < this._tsmtp.MailMessages.Count; i++)
			{
				for (int j = 0; j < this._tsmtp.MailMessages[i].AttachFiles.Count; j++)
				{
					if (this._tsmtp.MailMessages[i].AttachFiles[j].AttachmentFile != null)
					{
						this._tsmtp.MailMessages[i].AttachFiles[j].AttachmentFile.Close();
						this._tsmtp.MailMessages[i].AttachFiles[j].AttachmentFile.Dispose();
					}
				}
			}

			status = this._mailSenderOperationInfo.SendStatus;

			return status;
		}

		/// <summary>
		/// �T�[�o�[�ڑ��֘A�ݒ菈��
		/// </summary>
		private void ConnectServerSetting()
		{
			// �e�T�[�o�[�ݒ�(POP3 & SMTP)
			this._tsmtp.ServerInfo.POPServer = this._mailInfoSetting.Pop3ServerName;
			this._tsmtp.ServerInfo.POPPort = this._mailInfoSetting.PopServerPortNo;
			this._tsmtp.ServerInfo.POPTimeOut = this._mailInfoSetting.MailServerTimeoutVal;

			this._tsmtp.ServerInfo.SMTPServer = this._mailInfoSetting.SmtpServerName;
			this._tsmtp.ServerInfo.SMTPPort = this._mailInfoSetting.SmtpServerPortNo;
			this._tsmtp.ServerInfo.SMTPTimeOut = this._mailInfoSetting.MailServerTimeoutVal;

			// �F�ؐݒ�
			// POP Before SMTP
			if (this._mailInfoSetting.PopBeforeSmtpUseDiv == 1)
			{
				// POP3�F��
				this._tsmtp.AuthorizationInfo.PopAccount = this._mailInfoSetting.Pop3UserId;
				this._tsmtp.AuthorizationInfo.PopPassWord = this._mailInfoSetting.Pop3Password;
			}

			// SMTP-AUTH
			switch (this._mailInfoSetting.SmtpAuthUseDiv)
			{
				case 0:		// �g�p���Ȃ�
					break;
				case 1:		// POP3�F�؂�ID/Pass���g�p
					this._tsmtp.AuthorizationInfo.SmtpAccount = this._mailInfoSetting.Pop3UserId;
					this._tsmtp.AuthorizationInfo.SmtpPassWord = this._mailInfoSetting.Pop3Password;
					break;
				case 2:		// SMTP�F�؂�ID/Pass���g�p
					this._tsmtp.AuthorizationInfo.SmtpAccount = this._mailInfoSetting.SmtpUserId;
					this._tsmtp.AuthorizationInfo.SmtpPassWord = this._mailInfoSetting.SmtpPassword;
					break;
			}

			// �F�ؕ���
			if ((this._mailInfoSetting.PopBeforeSmtpUseDiv == 1) && (this._mailInfoSetting.SmtpAuthUseDiv != 0))
			{
				// ����(None -> POPBeforeSMTP -> SMTPAuth)
				this._tsmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.Auto;
			}
			else if (this._mailInfoSetting.PopBeforeSmtpUseDiv == 1)
			{
				// POP Before SMTP
				this._tsmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.POPBeforeSMTP;
			}
			else if (this._mailInfoSetting.SmtpAuthUseDiv != 0)
			{
				// SMTP-AUTH
				this._tsmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.SMTPAuth;
			}
			else
			{
				// �F�ؖ���
				this._tsmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.None;
			}
		}

		/// <summary>
		/// E-Mail���M�f�[�^�ݒ菈��
		/// </summary>
		/// <param name="startDataIndex">�f�[�^�ݒ�J�n�C���f�b�N�X</param>
		/// <param name="setDataCount">�f�[�^�ݒ�Ώی���</param>
		private void SendMailMessagesSetting(int startDataIndex, int setDataCount)
		{
			// ���b�Z�[�W�N���A(������)
			this._tsmtp.MailMessages.Clear();

			// ���[������ێ�����ϐ���錾���܂�
			// ���[���̏��́A1�����Ƃɂ��� MailMessageStream 1���K�v�ł�
			// ���[�����ݒ��A���[���R���N�V�����v���p�e�B�ł���TPOP.MailStreamCollction��Add���܂�
			// �Ȃ��A���[��1���Ƃ͒ʏ탁�[���[�Ȃǂő��M����P�ʂƓ����ł�
			// 1���̃��[���ɕ����̈����CC�A�Y�t�t�@�C����ݒ肷�鎖���\�ł�
			MailMessageStream mailMsgStream;

			// MailSourceData�ɂ��ď���
			DataRow SourceData;
			for (int i = startDataIndex; i < startDataIndex + setDataCount; i++)
			{
				// ���f�[�^�����𒴂�����I��
				if (i >= this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count)
				{
					break;
				}

				SourceData = this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows[i];

				mailMsgStream = new MailMessageStream();

				// ���M���Z�b�g
				mailMsgStream.From = String.Format("\"{0}\"<{1}>", this._mailInfoSetting.SenderName.Trim(), this._mailInfoSetting.MailAddress.Trim());

				// ���M��Z�b�g
				mailMsgStream.To = new string[] { (string)SourceData[MailSourceData.MEMBER_MailData_MailAddress] };

				// �����Z�b�g
				mailMsgStream.Subject = (string)SourceData[MailSourceData.MEMBER_MailData_MailTitle];

				// BCC���M��Z�b�g (�o�b�N�A�b�v�`��[0:BCC�`��]�̏ꍇ)
				if ((this._mailSenderOperationInfo.SendBccBackup) && (this._mailInfoSetting.BackupFormal == 0))
				{
					mailMsgStream.Bcc = new string[] { mailMsgStream.From };
				}

				// ���[���{�����e�Z�b�g
				switch ((int)SourceData[MailSourceData.MEMBER_MailData_MailFormal])
				{
					case 0:		// TEXT�`��
						mailMsgStream.Text = (string)SourceData[MailSourceData.MEMBER_MailData_MailDocumentCnts];
						break;
					case 1:		// HTML�`��
						// (* ������ *)
						break;
				}

                // CC���M��Z�b�g
                if ((string)SourceData[MailSourceData.MEMBER_MailData_CarbonCopy] != string.Empty)
                {
                    mailMsgStream.Cc = new string[] { (string)SourceData[MailSourceData.MEMBER_MailData_CarbonCopy] };
                }

                // �Y�t�t�@�C���Z�b�g
                if ((string)SourceData[MailSourceData.MEMBER_MailData_AttachFile] != string.Empty)
                {
                    mailMsgStream.FileName = new string[] { (string)SourceData[MailSourceData.MEMBER_MailData_AttachFile] };
                }

                // ���[���f�[�^�����b�Z�[�W�R���N�V�����ɒǉ�
				this._tsmtp.MailMessages.Add(mailMsgStream);
            }
		}

		/// <summary>
		/// E-Mail���M�O����
		/// </summary>
		/// <returns></returns>
		/// <remarks>�t�������pIF�C���X�^���X�擾�E���M�O�o�b�N�A�b�v�ꊇ�o�^�E�G���[���폜</remarks>
		private int BeforeSendMailOpeProc(ref MailSourceData mailSourceData)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			MailFactoryBase mailFactoryBase = new MailFactoryBase(MailServiceInfoCreateMode.MailSender);

			// ���[�����M�����쐬���C�u��������C���^�t�F�[�X�擾
			this._iMailSendingHistoryMaker = mailFactoryBase.GetMailSendingHistoryMakerInterface();

			//** ���[�����M�֘A�f�[�^�쐬 **//
			this.CreateMailSendProcData(ref mailSourceData);

			if (this._iMailSendingHistoryMaker != null)
			{
				// ���M������������
				if (this._initSendHistorySourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count > 0)
				{
					status = this._iMailSendingHistoryMaker.InitializeSendingHistory(ref this._initSendHistorySourceData);

					if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
					{
						this.ShowErrMessageProc(0, "���[�����M�����̏����������Ɏ��s���܂���", status, null);
						return status;
					}
				}
			}

			return status;
		}

		/// <summary>
		/// E-Mail���M�㏈��
		/// </summary>
		private int AfterSendMailOpeProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		/// <summary>
		/// ���M�I���C�x���g�n���h��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void TSMTP_SmtpEndSend(object sender, TSMTP.SendEndEventArgs e)
		public void TSMTP_SmtpEndSend(object sender, TSMTP.SendEndEventArgs e)
		{
			// �ꌏ���M���I������x�ɁA���̃C�x���g���������܂�
			// ���M�ɍs���āA �������T�[�o�[�ɐ������ڑ��ł��Ȃ��Ă��A���̃C�x���g�͔������܂��B
			// ���������������ǂ����́A�K���X�e�[�^�X�Ń`�F�b�N���Ă�������
			// POP Before SMTP�������̃C�x���g�͔������܂�

			lock (this._syncRoot)
			{
				if (e.Status == 0)
				{
					// �����������l���������[���C���f�b�N�X
					// NowMessageNo��1����, ���[���C���f�b�N�X��0����(���M�f�[�^��RowIndex)
					int solvedMailIndex = e.NowMessageNo - 1 + this._splitSendRound * this._mailInfoSetting.MailSendDivUnitCnt;

					// ��x�ł��G���[�����������ꍇ�͈ȍ~�̃��[���ɂ��Ă̓G���[�Ƃ��Ĉ���
					// _mailSendWaitFlg���Q�Ƃ��ăG���[�����������ǂ����𔻒�(�G���[���ɑҋ@�������Ă��邩��)
					if (this._mailSendWaitFlg)
					{
                        //int status;
                        //if (this._iMailSendingHistoryMaker != null)
                        //{
                        //    status = this._iMailSendingHistoryMaker.MakeSendingHistory(solvedMailIndex, ref this._mailSendSourceData);

                        //    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        //    {
                        //        this.ShowErrMessageProc(2, "���[�����M�����̓o�^�Ɏ��s���܂���", status, null);
                        //    }
                        //}
					}

				}
				else
				{
					// ���M�G���[(�X���b�h�ҋ@����)
					this.ReleaseMailSendWait(e.Status, "���[�����M���ɃG���[���������܂���(SmtpEndSend)\r\n" + e.StatusMessage, null);
				}

				// �G���[�����������ꍇ�A�����Ŏ����I�ɃT�[�o�[�Ƃ̐ڑ����������܂����A
				// �O�ׁ̈A���LClose���\�b�h�Ŋm���ɐؒf���Ă�������

				// �Ȃ��A���펞�ł��K�����̐ؒf���\�b�h�͎��s���Ă�������
				// �������̃��b�Z�[�W�╪�����M�s�����ꍇ�A���̃C�x���g�����M��̐����������܂��B���ӂ��Ă�������
				// �@���̏ꍇ�A�N���[�Y���\�b�h�͍Ō�ɂ̂ݔ��s���Ă�������
				// NowMessageNo�����̃C�x���g�𔭐����������b�Z�[�W�̔ԍ��AMaxMessageFig�����M�Ώۂ̑S�����ł�
				if (e.NowMessageNo == e.MaxMessageFig)
				{
					// SMTP�ڑ����
					this._tsmtp.Close();

					// �X���b�h�ҋ@����
					this.ReleaseMailSendWait(0, "", null);

                    if (e.Status == 0)
                    {
                        this._sendEndFlg = true;
                    }
				}
			}
		}

		/// <summary>
		/// �T�[�o�[�ڑ���ԕύX�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TSMTP_SmtpConnectedChangedEx(object sender, TSMTP.SendingEventArgs e)
		{
			lock (this._syncRoot)
			{
				if (e.Status != 0)
				{
					if (this._mailSendWaitFlg)
					{
						// �ڑ��G���[(�X���b�h�ҋ@����)
						this.ReleaseMailSendWait(e.Status, "���[�����M���ɃG���[���������܂���(SmtpConnectedChangedEx)\r\n" + e.StatusMessage, null);
					}
				}
			}
		}

		/// <summary>
		/// Busy��ԕύX�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TSMTP_SmtpBusyChanged(object sender, TSMTP.SendingEventArgs e)
		{
			lock (this._syncRoot)
			{
				if (e.Status != 0)
				{
					if (this._mailSendWaitFlg)
					{
						// �ڑ��G���[(�X���b�h�ҋ@����)
						this.ReleaseMailSendWait(e.Status, "���[�����M���ɃG���[���������܂���(SmtpBusyChanged)\r\n" + e.StatusMessage, null);
					}
				}
			}
		}

		/// <summary>
		/// ���[�����M�X���b�h�ҋ@��������
		/// </summary>
		private void ReleaseMailSendWait(int status, string msg, Exception ex)
		{
			lock (this._syncRoot)
			{
				this._mailSendWaitFlg = false;
			}

			if (status != 0)
			{
				this._mailSenderOperationInfo.SendStatus = status;
				this._mailSenderOperationInfo.StatusMessage = msg;

				this.ShowErrMessageProc(0, msg, status, ex);
			}
		}

		/// <summary>
		/// �G���[�_�C�A���O�\������
		/// </summary>
		/// <param name="showmode">�\�����[�h[0:�ݒ�D��, 1:�����_�C�A���O�\��, 2:�����_�C�A���O��\��(���O�o��)]</param>
		/// <param name="msg">�G���[���b�Z�[�W</param>
		/// <param name="status">�G���[�X�e�[�^�X</param>
		/// <param name="ex">��O�I�u�W�F�N�g</param>
		private void ShowErrMessageProc(int showmode, string msg, int status, Exception ex)
		{
			bool showDialog = false;

			switch (showmode)
			{
				case 0:
					showDialog = this._mailSenderOperationInfo.DispErrorDialog;
					break;
				case 1:
					showDialog = true;
					break;
				case 2:
					showDialog = false;
					break;
			}

			if (ex != null)
			{
				if ((showmode == 0) && (showDialog))
				{
					// �G���[�_�C�A���O�\���L��
					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_STOPDISP,
						ctPGID,
						msg,
						status,
						ex,
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxDefaultButton.Button1);
				}
				else
				{
					// ��O�������̓_�C�A���O�\�����Ȃ��Ă���O�I�u�W�F�N�g�����O�o�͂���
					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_NODISP,
						ctPGID,
						msg,
						status,
						ex,
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxDefaultButton.Button1);
				}
			}
			else
			{
				// �G���[�_�C�A���O�\���L��
				if (showDialog)
				{
					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_STOPDISP,
						ctPGID,
						msg,
						status,
						System.Windows.Forms.MessageBoxButtons.OK);
				}
				else if (showmode == 2)
				{
					// ������\���̏ꍇ�̓��O�o��
					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_NODISP,
						ctPGID,
						msg,
						status,
						System.Windows.Forms.MessageBoxButtons.OK,
						System.Windows.Forms.MessageBoxDefaultButton.Button1);
				}
			}

			this._mailSenderOperationInfo.SendStatus = status;
			this._mailSenderOperationInfo.StatusMessage = msg;
		}

		/// <summary>
		/// ���b�Z�[�W�_�C�A���O�\������
		/// </summary>
		/// <param name="errLevel">�G���[���x��</param>
		/// <param name="msg">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		private void ShowMessageProc(emErrorLevel errLevel, string msg, int status)
		{
			if (this._mailSenderOperationInfo.DispErrorDialog)
			{
				TMsgDisp.Show(
					errLevel,
					ctPGID,
					msg,
					status,
					System.Windows.Forms.MessageBoxButtons.OK);
			}

			this._mailSenderOperationInfo.SendStatus = status;
			this._mailSenderOperationInfo.StatusMessage = msg;
		}
		#endregion
	}
}

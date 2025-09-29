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
	/// E-Mail送信ライブラリ
	/// </summary>
	/// <remarks>
	/// <br>Note       : E-Mailの送信を行うクラスです。</br>
	/// <br>Programer  : 980034 金沢  貞義</br>
	/// <br>Date       : 2010.05.25</br>
	/// <br></br>
	/// <br>UpdateNote : XXXX.XX.XX ＸＸＸＸ</br>
	/// </remarks>
	public class NsEMailSender : IMailSender
	{
		#region Constructor
		/// <summary>
		/// デフォルトコンストラクタ
		/// </summary>
		public NsEMailSender()
		{

		}
		#endregion

		#region Private Fields
		/// <summary>メール送信部品</summary>
		private TSMTP _tsmtp;

		/// <summary>メール送信ライブラリ操作パラメータ</summary>
		private MailSenderOperationInfo _mailSenderOperationInfo;
		/// <summary>送信対象メールデータソース</summary>
		private MailSourceData _mailSendSourceData;
		/// <summary>バックアップ削除対象データソース</summary>
		private MailSourceData _deleteBackupSourceData;
		/// <summary>送信履歴初期化対象データソース</summary>
		private MailSourceData _initSendHistorySourceData;
		/// <summary>メール送信管理マスタ</summary>
        private MailInfoSetting _mailInfoSetting;

		/// <summary>メール送信用待機フラグ</summary>
		private bool _mailSendWaitFlg;

		/// <summary>同期ロックオブジェクト</summary>
		private object _syncRoot = new object();

		/// <summary>分割送信ラウンド</summary>
		private int _splitSendRound;

        /// <summary>処理終了フラグ</summary>
        private bool _sendEndFlg = false;
        
		/// <summary>メール送信履歴作成ライブラリ操作インタフェース</summary>
		private IMailSendingHistoryMaker _iMailSendingHistoryMaker;

        // PGID
		private const string ctPGID = "PMKHN07505C";
		#endregion

		#region Public Properties
		#region IMailSender Member
		/// <summary>
		/// メール送信ライブラリ　バージョン
		/// </summary>
		public string Version
		{
			get { return ".NS MailService 1.1.1.0"; }
        }
        #endregion

        /// <summary>
        /// 処理終了フラグ
        /// </summary>
        public bool SendEndFlg
        {
            get { return _sendEndFlg; }
        }
		#endregion

		#region Public Methods
		#region IMailSender Member
		/// <summary>
		/// メール送信処理
		/// </summary>
		/// <param name="mailSenderOperationInfo">メール送信ライブラリ操作パラメータ</param>
		/// <param name="mailSourceData">送信対象メールデータソース</param>
		/// <returns>ステータス</returns>
		public int SendMail(ref MailSenderOperationInfo mailSenderOperationInfo, MailSourceData mailSourceData)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			// パラメータをプライベート変数に取得
			this._mailSenderOperationInfo = mailSenderOperationInfo;

			// 戻りパラメータ初期化
			this._mailSenderOperationInfo.SendStatus = status;
			this._mailSenderOperationInfo.StatusMessage = "";

			// パラメータチェック
			if ((mailSourceData == null) ||
				(mailSourceData.MailDataList == null) ||
				!(mailSourceData.MailDataList.Tables.Contains(MailSourceData.TABLE_MailDataList)) ||
				(mailSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count == 0))
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				this.ShowMessageProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "メール送信データがありません", status);
				return status;
			}

			//** メール設定情報取得 **//
			MailInfoBase mailInfoBase = new MailInfoBase(MailServiceInfoCreateMode.MailSender);

			// メール送信管理マスタ
			mailInfoBase.GetMailInfoSetting(out this._mailInfoSetting);

			//** E-Mail送信前処理 **//
			// 付随処理用IFインスタンス取得・バックアップの初回一括登録etcを実行
			status = this.BeforeSendMailOpeProc(ref mailSourceData);

			if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				if (this._mailInfoSetting.DialUpCode == 1)		// ダイヤルアップ有無
				{
					//** ダイアルアップ接続 **//
					status = this.DialUpConnectionProc();
				}

				if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					//** ネットワーク確認 **//
					if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
					{
						status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
						this.ShowMessageProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "ネットワークに接続されていません", status);
					}

					try
					{
						if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
						{
							//** E-Mail送信処理 **//
							status = SendEMailProc();
						}
					}
					catch (Exception ex)
					{
						this.ReleaseMailSendWait((int)ConstantManagement.MethodResult.ctFNC_ERROR, ex.Message, ex);
					}
				}
			}

			//** E-Mail送信後処理 **//
			status = this.AfterSendMailOpeProc();

			// 戻りパラメータセット
			mailSenderOperationInfo = this._mailSenderOperationInfo;

			return this._mailSenderOperationInfo.SendStatus;
		}

		/// <summary>
		/// メール送信関連データ作成
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

			// データセットを作成しなおす
			this._mailSendSourceData.MailDataList = mailSourceData.MailDataList.Clone();		// スキーマのみコピー
			this._deleteBackupSourceData.MailDataList = mailSourceData.MailDataList.Clone();	// スキーマのみコピー
			this._initSendHistorySourceData.MailDataList = mailSourceData.MailDataList.Clone();	// スキーマのみコピー

			DataTable wkMailTable = this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList];
			DateTime nowTime = Broadleaf.Library.Globarization.TDateTime.GetSFDateNow();
			long sendDateTime = Convert.ToInt64(nowTime.ToString("yyyyMMddHHmmss"));

			foreach (DataRow wkRow in mailSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows)
			{
				// 送信区分が[0:非送信] or 論理削除区分が[0:有効]以外は送信データ対象外
				if (((int)wkRow[MailSourceData.MEMBER_MailData_MailSendCode1] == 0) ||
					((int)wkRow[MailSourceData.MEMBER_MailData_LogicalDeleteCode] != 0))
				{
					continue;
				}

				// 送信対象データのうち,メールステータス[5:エラー未送信]はバックアップ削除対象データ
				// 送信対象データのうち,メールステータス[5:エラー未送信]は送信履歴初期化対象データ
				if ((int)wkRow[MailSourceData.MEMBER_MailData_MailStatus] == MailBackup.MailBackup_MailStatus_ERROR)
				{
					this._deleteBackupSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Add(wkRow.ItemArray);
					this._initSendHistorySourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Add(wkRow.ItemArray);
				}

				// 送信データコピー
				wkMailTable.Rows.Add(wkRow.ItemArray);

				// 前回エラーデータだった場合はヘッダ項目削除(一括登録時に再登録されるように)
				if ((int)wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_MailStatus] == MailBackup.MailBackup_MailStatus_ERROR)
				{
					wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_CreateDateTime] = DateTime.MinValue;
					wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_UpdateDateTime] = DateTime.MinValue;
					wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_FileHeaderGuid] = Guid.Empty;
					wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_MailManagementConsNo] = 0;
				}

				// 送信分バックアップ一括登録用にメールステータス(5:エラー未送信)と送信日時をセット
				wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_MailStatus] = MailBackup.MailBackup_MailStatus_ERROR;
				wkMailTable.Rows[wkMailTable.Rows.Count - 1][MailSourceData.MEMBER_MailData_SendDateTime] = sendDateTime;

			}
		}
		#endregion
		#endregion

		#region Private Methods
		/// <summary>
		/// ダイアルアップ接続処理
		/// </summary>
		/// <returns>ステータス</returns>
		private int DialUpConnectionProc()
		{
			return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
		}

		/// <summary>
		/// E-Mail送信処理
		/// </summary>
		/// <returns>ステータス</returns>
		private int SendEMailProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			//** メール送信部品初期化 **//
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

			//this._tsmtp.MailOptions.SendMethodEnumType = SendMethodEnumTypes.Synchronous;		// 送信メソッド同期モード(イベント有り(下層部品送信部分のみ同期))
			this._tsmtp.MailOptions.DividingSend = true;										// 送信先別分割送信設定-ON
			this._tsmtp.ProgressDialog = this._mailSenderOperationInfo.DispProgressDialog;		// 進捗ダイアログ表示有無
			this._tsmtp.DialogConfirm = false;

			// デバッグオプション
			NsEMailSenderOptionInfo optionInfo;
			if (NsEMailSenderOption.GetOptionInfo(out optionInfo))
			{
				this._tsmtp.TraceOptions.Trace = optionInfo.TraceMode;
				this._tsmtp.TraceOptions.TraceLog = optionInfo.TraceLog;
				this._tsmtp.TraceOptions.TraceLogPath = optionInfo.TraceLogPath;
			}

			//** サーバー接続関連設定処理 **//
			this.ConnectServerSetting();

			// 一括送信する最大件数を考慮
			this._splitSendRound = 0;
			int sendUnitCnt = this._mailInfoSetting.MailSendDivUnitCnt;
			if (sendUnitCnt == 0)
			{
				status = this.SendEMailSubProc(0, this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count);
			}
			else
			{
				// 分割送信
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
		/// E-Mail送信サブ処理
		/// </summary>
		/// <param name="startDataIndex">送信データ設定開始インデックス</param>
		/// <param name="setDataCount">送信データ設定対象件数</param>
		/// <returns></returns>
		private int SendEMailSubProc(int startDataIndex, int setDataCount)
		{
			int status;

			// 待機用フラグ初期化
			this._mailSendWaitFlg = true;

			//** E-Mail送信データ設定処理 **//
			this.SendMailMessagesSetting(startDataIndex, setDataCount);

			//** E-Mail送信!! **//
			// ※POP Before SMTPでログインエラーが発生した場合、本メソッドでエラーが戻ってきます。
			status = this._tsmtp.SendMessage();

			if (status != 0)
			{
				this.ShowErrMessageProc(0, "メールの送信に失敗しました\r\n" + this._tsmtp.StatusMessage, this._tsmtp.Status, null);
				return status;
			}
            /*
			// 非同期送信の場合はスレッド待機
			if (this._tsmtp.MailOptions.SendMethodEnumType == SendMethodEnumTypes.Asynchronous)
			{
				while ((this._mailSendWaitFlg || this._tsmtp.BusyStatus || this._tsmtp.ConnectedStatus))
				{
					Thread.Sleep(1000);
					System.Windows.Forms.Application.DoEvents();
				}
			}
            */
			// Streamの解放
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
		/// サーバー接続関連設定処理
		/// </summary>
		private void ConnectServerSetting()
		{
			// 各サーバー設定(POP3 & SMTP)
			this._tsmtp.ServerInfo.POPServer = this._mailInfoSetting.Pop3ServerName;
			this._tsmtp.ServerInfo.POPPort = this._mailInfoSetting.PopServerPortNo;
			this._tsmtp.ServerInfo.POPTimeOut = this._mailInfoSetting.MailServerTimeoutVal;

			this._tsmtp.ServerInfo.SMTPServer = this._mailInfoSetting.SmtpServerName;
			this._tsmtp.ServerInfo.SMTPPort = this._mailInfoSetting.SmtpServerPortNo;
			this._tsmtp.ServerInfo.SMTPTimeOut = this._mailInfoSetting.MailServerTimeoutVal;

			// 認証設定
			// POP Before SMTP
			if (this._mailInfoSetting.PopBeforeSmtpUseDiv == 1)
			{
				// POP3認証
				this._tsmtp.AuthorizationInfo.PopAccount = this._mailInfoSetting.Pop3UserId;
				this._tsmtp.AuthorizationInfo.PopPassWord = this._mailInfoSetting.Pop3Password;
			}

			// SMTP-AUTH
			switch (this._mailInfoSetting.SmtpAuthUseDiv)
			{
				case 0:		// 使用しない
					break;
				case 1:		// POP3認証のID/Passを使用
					this._tsmtp.AuthorizationInfo.SmtpAccount = this._mailInfoSetting.Pop3UserId;
					this._tsmtp.AuthorizationInfo.SmtpPassWord = this._mailInfoSetting.Pop3Password;
					break;
				case 2:		// SMTP認証のID/Passを使用
					this._tsmtp.AuthorizationInfo.SmtpAccount = this._mailInfoSetting.SmtpUserId;
					this._tsmtp.AuthorizationInfo.SmtpPassWord = this._mailInfoSetting.SmtpPassword;
					break;
			}

			// 認証方式
			if ((this._mailInfoSetting.PopBeforeSmtpUseDiv == 1) && (this._mailInfoSetting.SmtpAuthUseDiv != 0))
			{
				// 自動(None -> POPBeforeSMTP -> SMTPAuth)
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
				// 認証無し
				this._tsmtp.AuthorizationInfo.AuthType = TSMTP.AuthorizationTypes.None;
			}
		}

		/// <summary>
		/// E-Mail送信データ設定処理
		/// </summary>
		/// <param name="startDataIndex">データ設定開始インデックス</param>
		/// <param name="setDataCount">データ設定対象件数</param>
		private void SendMailMessagesSetting(int startDataIndex, int setDataCount)
		{
			// メッセージクリア(初期化)
			this._tsmtp.MailMessages.Clear();

			// メール情報を保持する変数を宣言します
			// メールの情報は、1件ごとにこの MailMessageStream 1個が必要です
			// メール情報設定後、メールコレクションプロパティであるTPOP.MailStreamCollctionにAddします
			// なお、メール1件とは通常メーラーなどで送信する単位と同じです
			// 1件のメールに複数の宛先やCC、添付ファイルを設定する事が可能です
			MailMessageStream mailMsgStream;

			// MailSourceDataについて処理
			DataRow SourceData;
			for (int i = startDataIndex; i < startDataIndex + setDataCount; i++)
			{
				// 実データ件数を超えたら終了
				if (i >= this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count)
				{
					break;
				}

				SourceData = this._mailSendSourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows[i];

				mailMsgStream = new MailMessageStream();

				// 送信元セット
				mailMsgStream.From = String.Format("\"{0}\"<{1}>", this._mailInfoSetting.SenderName.Trim(), this._mailInfoSetting.MailAddress.Trim());

				// 送信先セット
				mailMsgStream.To = new string[] { (string)SourceData[MailSourceData.MEMBER_MailData_MailAddress] };

				// 件名セット
				mailMsgStream.Subject = (string)SourceData[MailSourceData.MEMBER_MailData_MailTitle];

				// BCC送信先セット (バックアップ形式[0:BCC形式]の場合)
				if ((this._mailSenderOperationInfo.SendBccBackup) && (this._mailInfoSetting.BackupFormal == 0))
				{
					mailMsgStream.Bcc = new string[] { mailMsgStream.From };
				}

				// メール本文内容セット
				switch ((int)SourceData[MailSourceData.MEMBER_MailData_MailFormal])
				{
					case 0:		// TEXT形式
						mailMsgStream.Text = (string)SourceData[MailSourceData.MEMBER_MailData_MailDocumentCnts];
						break;
					case 1:		// HTML形式
						// (* 未実装 *)
						break;
				}

                // CC送信先セット
                if ((string)SourceData[MailSourceData.MEMBER_MailData_CarbonCopy] != string.Empty)
                {
                    mailMsgStream.Cc = new string[] { (string)SourceData[MailSourceData.MEMBER_MailData_CarbonCopy] };
                }

                // 添付ファイルセット
                if ((string)SourceData[MailSourceData.MEMBER_MailData_AttachFile] != string.Empty)
                {
                    mailMsgStream.FileName = new string[] { (string)SourceData[MailSourceData.MEMBER_MailData_AttachFile] };
                }

                // メールデータをメッセージコレクションに追加
				this._tsmtp.MailMessages.Add(mailMsgStream);
            }
		}

		/// <summary>
		/// E-Mail送信前処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>付随処理用IFインスタンス取得・送信前バックアップ一括登録・エラー分削除</remarks>
		private int BeforeSendMailOpeProc(ref MailSourceData mailSourceData)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			MailFactoryBase mailFactoryBase = new MailFactoryBase(MailServiceInfoCreateMode.MailSender);

			// メール送信履歴作成ライブラリ操作インタフェース取得
			this._iMailSendingHistoryMaker = mailFactoryBase.GetMailSendingHistoryMakerInterface();

			//** メール送信関連データ作成 **//
			this.CreateMailSendProcData(ref mailSourceData);

			if (this._iMailSendingHistoryMaker != null)
			{
				// 送信履歴初期処理
				if (this._initSendHistorySourceData.MailDataList.Tables[MailSourceData.TABLE_MailDataList].Rows.Count > 0)
				{
					status = this._iMailSendingHistoryMaker.InitializeSendingHistory(ref this._initSendHistorySourceData);

					if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
					{
						this.ShowErrMessageProc(0, "メール送信履歴の初期化処理に失敗しました", status, null);
						return status;
					}
				}
			}

			return status;
		}

		/// <summary>
		/// E-Mail送信後処理
		/// </summary>
		private int AfterSendMailOpeProc()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		/// <summary>
		/// 送信終了イベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void TSMTP_SmtpEndSend(object sender, TSMTP.SendEndEventArgs e)
		public void TSMTP_SmtpEndSend(object sender, TSMTP.SendEndEventArgs e)
		{
			// 一件送信が終了する度に、このイベントが発生します
			// 送信に行って、 正しくサーバーに正しく接続できなくても、このイベントは発生します。
			// 正しく言ったかどうかは、必ずステータスでチェックしてください
			// POP Before SMTP中もこのイベントは発生します

			lock (this._syncRoot)
			{
				if (e.Status == 0)
				{
					// 自動分割を考慮したメールインデックス
					// NowMessageNoは1発番, メールインデックスは0発番(送信データのRowIndex)
					int solvedMailIndex = e.NowMessageNo - 1 + this._splitSendRound * this._mailInfoSetting.MailSendDivUnitCnt;

					// 一度でもエラーが発生した場合は以降のメールについてはエラーとして扱う
					// _mailSendWaitFlgを参照してエラーがあったかどうかを判定(エラー時に待機解除しているから)
					if (this._mailSendWaitFlg)
					{
                        //int status;
                        //if (this._iMailSendingHistoryMaker != null)
                        //{
                        //    status = this._iMailSendingHistoryMaker.MakeSendingHistory(solvedMailIndex, ref this._mailSendSourceData);

                        //    if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        //    {
                        //        this.ShowErrMessageProc(2, "メール送信履歴の登録に失敗しました", status, null);
                        //    }
                        //}
					}

				}
				else
				{
					// 送信エラー(スレッド待機解除)
					this.ReleaseMailSendWait(e.Status, "メール送信中にエラーが発生しました(SmtpEndSend)\r\n" + e.StatusMessage, null);
				}

				// エラーが発生した場合、内部で自動的にサーバーとの接続を解除しますが、
				// 念の為、下記Closeメソッドで確実に切断してください

				// なお、正常時でも必ずこの切断メソッドは実行してください
				// ※複数のメッセージや分割送信行った場合、このイベントが送信先の数分発生します。注意してください
				// 　この場合、クローズメソッドは最後にのみ発行してください
				// NowMessageNoがこのイベントを発生させたメッセージの番号、MaxMessageFigが送信対象の全件数です
				if (e.NowMessageNo == e.MaxMessageFig)
				{
					// SMTP接続解放
					this._tsmtp.Close();

					// スレッド待機解除
					this.ReleaseMailSendWait(0, "", null);

                    if (e.Status == 0)
                    {
                        this._sendEndFlg = true;
                    }
				}
			}
		}

		/// <summary>
		/// サーバー接続状態変更イベント
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
						// 接続エラー(スレッド待機解除)
						this.ReleaseMailSendWait(e.Status, "メール送信中にエラーが発生しました(SmtpConnectedChangedEx)\r\n" + e.StatusMessage, null);
					}
				}
			}
		}

		/// <summary>
		/// Busy状態変更イベント
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
						// 接続エラー(スレッド待機解除)
						this.ReleaseMailSendWait(e.Status, "メール送信中にエラーが発生しました(SmtpBusyChanged)\r\n" + e.StatusMessage, null);
					}
				}
			}
		}

		/// <summary>
		/// メール送信スレッド待機解除処理
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
		/// エラーダイアログ表示処理
		/// </summary>
		/// <param name="showmode">表示モード[0:設定優先, 1:強制ダイアログ表示, 2:強制ダイアログ非表示(ログ出力)]</param>
		/// <param name="msg">エラーメッセージ</param>
		/// <param name="status">エラーステータス</param>
		/// <param name="ex">例外オブジェクト</param>
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
					// エラーダイアログ表示有り
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
					// 例外発生時はダイアログ表示がなくても例外オブジェクトをログ出力する
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
				// エラーダイアログ表示有り
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
					// 強制非表示の場合はログ出力
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
		/// メッセージダイアログ表示処理
		/// </summary>
		/// <param name="errLevel">エラーレベル</param>
		/// <param name="msg">表示メッセージ</param>
		/// <param name="status">ステータス</param>
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

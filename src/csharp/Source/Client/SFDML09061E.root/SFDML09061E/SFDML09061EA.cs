using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   MailSndMng
	/// <summary>
	///                      メール送信管理マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   メール送信管理マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/03/05</br>
	/// <br>Genarated Date   :   2006/10/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2006/09/29  980056 祖慶</br>
	/// <br>                 :   各項目を全面的に見直し。</br>
	/// <br>                 :   (変更前のレイアウトはマスタメンテ以外</br>
	/// <br>                 :   使用されていないので大幅な修正をして</br>
	/// <br>                 :   ます)</br>
	/// </remarks>
	public class MailSndMng
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>e-mail送信管理番号</summary>
		/// <remarks>0 固定</remarks>
		private Int32 _mailSendMngNo;

		/// <summary>メールアドレス</summary>
		/// <remarks>自端末のメールアドレス</remarks>
		private string _mailAddress = "";

		/// <summary>ダイヤルアップ区分</summary>
		/// <remarks>メールの際、LAN接続かダイヤルか判断する0:LAN, 1:ダイヤルアップ</remarks>
		private Int32 _dialUpCode;

		/// <summary>ダイヤルアップ接続名称</summary>
		/// <remarks>RAS・メール（ダイヤルアップ接続）の際</remarks>
		private string _dialUpConnectName = "";

		/// <summary>ダイヤルアップログイン名</summary>
		private string _dialUpLoginName = "";

		/// <summary>ダイヤルアップパスワード</summary>
		private string _dialUpPassword = "";

		/// <summary>接続先電話番号</summary>
		private string _accessTelNo = "";

		/// <summary>POP3ユーザーID</summary>
		private string _pop3UserId = "";

		/// <summary>POP3パスワード</summary>
		private string _pop3Password = "";

		/// <summary>POP3サーバー名</summary>
		private string _pop3ServerName = "";

		/// <summary>SMTPサーバー名</summary>
		private string _smtpServerName = "";

		/// <summary>SMTPユーザID</summary>
		/// <remarks>SMTP認証ID</remarks>
		private string _smtpUserId = "";

		/// <summary>SMTPパスワード</summary>
		/// <remarks>SMTP認証パスワード</remarks>
		private string _smtpPassword = "";

		/// <summary>SMTP認証使用区分</summary>
		/// <remarks>0:使用しない, 1:POP認証と同じID･パスワードを使用する, 2:SMTP認証の〃</remarks>
		private Int32 _smtpAuthUseDiv;

		/// <summary>差出人名</summary>
		/// <remarks>メールの差出人</remarks>
		private string _senderName = "";

		/// <summary>POP Before SMTP使用区分</summary>
		/// <remarks>0:使用しない, 1:使用する</remarks>
		private Int32 _popBeforeSmtpUseDiv;

		/// <summary>POPサーバ ポート番号</summary>
		private Int32 _popServerPortNo;

		/// <summary>SMTPサーバ ポート番号</summary>
		private Int32 _smtpServerPortNo;

		/// <summary>メールサーバタイムアウト値</summary>
		/// <remarks>秒</remarks>
		private Int32 _mailServerTimeoutVal;

		/// <summary>バックアップ送信区分</summary>
		/// <remarks>0:自社アドレスにバックアップ送信する, 1:送信しない</remarks>
		private Int32 _backupSendDivCd;

		/// <summary>バックアップ形式</summary>
		/// <remarks>0:メール形式(BCC),  1:一覧表形式(簡易)</remarks>
		private Int32 _backupFormal;

		/// <summary>メール送信分割単位件数</summary>
		/// <remarks>0:自動分割しない, 0以外:自動分割する単位件数</remarks>
		private Int32 _mailSendDivUnitCnt;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";


		/// public propaty name  :  CreateDateTime
		/// <summary>作成日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>更新日時プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>論理削除区分プロパティ</summary>
		/// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   論理削除区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  MailSendMngNo
		/// <summary>e-mail送信管理番号プロパティ</summary>
		/// <value>0 固定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   e-mail送信管理番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailSendMngNo
		{
			get{return _mailSendMngNo;}
			set{_mailSendMngNo = value;}
		}

		/// public propaty name  :  MailAddress
		/// <summary>メールアドレスプロパティ</summary>
		/// <value>自端末のメールアドレス</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メールアドレスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MailAddress
		{
			get{return _mailAddress;}
			set{_mailAddress = value;}
		}

		/// public propaty name  :  DialUpCode
		/// <summary>ダイヤルアップ区分プロパティ</summary>
		/// <value>メールの際、LAN接続かダイヤルか判断する0:LAN, 1:ダイヤルアップ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ダイヤルアップ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DialUpCode
		{
			get{return _dialUpCode;}
			set{_dialUpCode = value;}
		}

		/// public propaty name  :  DialUpConnectName
		/// <summary>ダイヤルアップ接続名称プロパティ</summary>
		/// <value>RAS・メール（ダイヤルアップ接続）の際</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ダイヤルアップ接続名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DialUpConnectName
		{
			get{return _dialUpConnectName;}
			set{_dialUpConnectName = value;}
		}

		/// public propaty name  :  DialUpLoginName
		/// <summary>ダイヤルアップログイン名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ダイヤルアップログイン名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DialUpLoginName
		{
			get{return _dialUpLoginName;}
			set{_dialUpLoginName = value;}
		}

		/// public propaty name  :  DialUpPassword
		/// <summary>ダイヤルアップパスワードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ダイヤルアップパスワードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DialUpPassword
		{
			get{return _dialUpPassword;}
			set{_dialUpPassword = value;}
		}

		/// public propaty name  :  AccessTelNo
		/// <summary>接続先電話番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   接続先電話番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AccessTelNo
		{
			get{return _accessTelNo;}
			set{_accessTelNo = value;}
		}

		/// public propaty name  :  Pop3UserId
		/// <summary>POP3ユーザーIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   POP3ユーザーIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Pop3UserId
		{
			get{return _pop3UserId;}
			set{_pop3UserId = value;}
		}

		/// public propaty name  :  Pop3Password
		/// <summary>POP3パスワードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   POP3パスワードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Pop3Password
		{
			get{return _pop3Password;}
			set{_pop3Password = value;}
		}

		/// public propaty name  :  Pop3ServerName
		/// <summary>POP3サーバー名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   POP3サーバー名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Pop3ServerName
		{
			get{return _pop3ServerName;}
			set{_pop3ServerName = value;}
		}

		/// public propaty name  :  SmtpServerName
		/// <summary>SMTPサーバー名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SMTPサーバー名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SmtpServerName
		{
			get{return _smtpServerName;}
			set{_smtpServerName = value;}
		}

		/// public propaty name  :  SmtpUserId
		/// <summary>SMTPユーザIDプロパティ</summary>
		/// <value>SMTP認証ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SMTPユーザIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SmtpUserId
		{
			get{return _smtpUserId;}
			set{_smtpUserId = value;}
		}

		/// public propaty name  :  SmtpPassword
		/// <summary>SMTPパスワードプロパティ</summary>
		/// <value>SMTP認証パスワード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SMTPパスワードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SmtpPassword
		{
			get{return _smtpPassword;}
			set{_smtpPassword = value;}
		}

		/// public propaty name  :  SmtpAuthUseDiv
		/// <summary>SMTP認証使用区分プロパティ</summary>
		/// <value>0:使用しない, 1:POP認証と同じID･パスワードを使用する, 2:SMTP認証の〃</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SMTP認証使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SmtpAuthUseDiv
		{
			get{return _smtpAuthUseDiv;}
			set{_smtpAuthUseDiv = value;}
		}

		/// public propaty name  :  SenderName
		/// <summary>差出人名プロパティ</summary>
		/// <value>メールの差出人</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   差出人名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SenderName
		{
			get{return _senderName;}
			set{_senderName = value;}
		}

		/// public propaty name  :  PopBeforeSmtpUseDiv
		/// <summary>POP Before SMTP使用区分プロパティ</summary>
		/// <value>0:使用しない, 1:使用する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   POP Before SMTP使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PopBeforeSmtpUseDiv
		{
			get{return _popBeforeSmtpUseDiv;}
			set{_popBeforeSmtpUseDiv = value;}
		}

		/// public propaty name  :  PopServerPortNo
		/// <summary>POPサーバ ポート番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   POPサーバ ポート番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PopServerPortNo
		{
			get{return _popServerPortNo;}
			set{_popServerPortNo = value;}
		}

		/// public propaty name  :  SmtpServerPortNo
		/// <summary>SMTPサーバ ポート番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SMTPサーバ ポート番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SmtpServerPortNo
		{
			get{return _smtpServerPortNo;}
			set{_smtpServerPortNo = value;}
		}

		/// public propaty name  :  MailServerTimeoutVal
		/// <summary>メールサーバタイムアウト値プロパティ</summary>
		/// <value>秒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メールサーバタイムアウト値プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailServerTimeoutVal
		{
			get{return _mailServerTimeoutVal;}
			set{_mailServerTimeoutVal = value;}
		}

		/// public propaty name  :  BackupSendDivCd
		/// <summary>バックアップ送信区分プロパティ</summary>
		/// <value>0:自社アドレスにバックアップ送信する, 1:送信しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   バックアップ送信区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BackupSendDivCd
		{
			get{return _backupSendDivCd;}
			set{_backupSendDivCd = value;}
		}

		/// public propaty name  :  BackupFormal
		/// <summary>バックアップ形式プロパティ</summary>
		/// <value>0:メール形式(BCC),  1:一覧表形式(簡易)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   バックアップ形式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BackupFormal
		{
			get{return _backupFormal;}
			set{_backupFormal = value;}
		}

		/// public propaty name  :  MailSendDivUnitCnt
		/// <summary>メール送信分割単位件数プロパティ</summary>
		/// <value>0:自動分割しない, 0以外:自動分割する単位件数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メール送信分割単位件数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MailSendDivUnitCnt
		{
			get{return _mailSendDivUnitCnt;}
			set{_mailSendDivUnitCnt = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}


		/// <summary>
		/// メール送信管理マスタコンストラクタ
		/// </summary>
		/// <returns>MailSndMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailSndMngクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MailSndMng()
		{
		}

		/// <summary>
		/// メール送信管理マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="mailSendMngNo">e-mail送信管理番号(0 固定)</param>
		/// <param name="mailAddress">メールアドレス(自端末のメールアドレス)</param>
		/// <param name="dialUpCode">ダイヤルアップ区分(メールの際、LAN接続かダイヤルか判断する0:LAN, 1:ダイヤルアップ)</param>
		/// <param name="dialUpConnectName">ダイヤルアップ接続名称(RAS・メール（ダイヤルアップ接続）の際)</param>
		/// <param name="dialUpLoginName">ダイヤルアップログイン名</param>
		/// <param name="dialUpPassword">ダイヤルアップパスワード</param>
		/// <param name="accessTelNo">接続先電話番号</param>
		/// <param name="pop3UserId">POP3ユーザーID</param>
		/// <param name="pop3Password">POP3パスワード</param>
		/// <param name="pop3ServerName">POP3サーバー名</param>
		/// <param name="smtpServerName">SMTPサーバー名</param>
		/// <param name="smtpUserId">SMTPユーザID(SMTP認証ID)</param>
		/// <param name="smtpPassword">SMTPパスワード(SMTP認証パスワード)</param>
		/// <param name="smtpAuthUseDiv">SMTP認証使用区分(0:使用しない, 1:POP認証と同じID･パスワードを使用する, 2:SMTP認証の〃)</param>
		/// <param name="senderName">差出人名(メールの差出人)</param>
		/// <param name="popBeforeSmtpUseDiv">POP Before SMTP使用区分(0:使用しない, 1:使用する)</param>
		/// <param name="popServerPortNo">POPサーバ ポート番号</param>
		/// <param name="smtpServerPortNo">SMTPサーバ ポート番号</param>
		/// <param name="mailServerTimeoutVal">メールサーバタイムアウト値(秒)</param>
		/// <param name="backupSendDivCd">バックアップ送信区分(0:自社アドレスにバックアップ送信する, 1:送信しない)</param>
		/// <param name="backupFormal">バックアップ形式(0:メール形式(BCC),  1:一覧表形式(簡易))</param>
		/// <param name="mailSendDivUnitCnt">メール送信分割単位件数(0:自動分割しない, 0以外:自動分割する単位件数)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>MailSndMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailSndMngクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
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
		/// メール送信管理マスタ複製処理
		/// </summary>
		/// <returns>MailSndMngクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいMailSndMngクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public MailSndMng Clone()
		{
			return new MailSndMng(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._mailSendMngNo,this._mailAddress,this._dialUpCode,this._dialUpConnectName,this._dialUpLoginName,this._dialUpPassword,this._accessTelNo,this._pop3UserId,this._pop3Password,this._pop3ServerName,this._smtpServerName,this._smtpUserId,this._smtpPassword,this._smtpAuthUseDiv,this._senderName,this._popBeforeSmtpUseDiv,this._popServerPortNo,this._smtpServerPortNo,this._mailServerTimeoutVal,this._backupSendDivCd,this._backupFormal,this._mailSendDivUnitCnt,this._enterpriseName,this._updEmployeeName);
		}

		/// <summary>
		/// メール送信管理マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のMailSndMngクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailSndMngクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
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
		/// メール送信管理マスタ比較処理
		/// </summary>
		/// <param name="mailSndMng1">
		///                    比較するMailSndMngクラスのインスタンス
		/// </param>
		/// <param name="mailSndMng2">比較するMailSndMngクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailSndMngクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
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
		/// メール送信管理マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のMailSndMngクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailSndMngクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
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
		/// メール送信管理マスタ比較処理
		/// </summary>
		/// <param name="mailSndMng1">比較するMailSndMngクラスのインスタンス</param>
		/// <param name="mailSndMng2">比較するMailSndMngクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   MailSndMngクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
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

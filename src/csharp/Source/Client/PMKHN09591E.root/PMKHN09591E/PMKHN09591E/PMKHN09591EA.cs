//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メール情報設定マスタメンテナンス
// プログラム概要   : メール情報設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/05/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MailInfoSetting
    /// <summary>
    ///                      メール情報設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   メール情報設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/05/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MailInfoSetting
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

        /// <summary>ファイルパス名</summary>
        /// <remarks>メール保存先パス</remarks>
        private string _filePathNm = "";

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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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
            get { return _sectionCode; }
            set { _sectionCode = value; }
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
            get { return _mailSendMngNo; }
            set { _mailSendMngNo = value; }
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
            get { return _mailAddress; }
            set { _mailAddress = value; }
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
            get { return _dialUpCode; }
            set { _dialUpCode = value; }
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
            get { return _dialUpConnectName; }
            set { _dialUpConnectName = value; }
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
            get { return _dialUpLoginName; }
            set { _dialUpLoginName = value; }
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
            get { return _dialUpPassword; }
            set { _dialUpPassword = value; }
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
            get { return _accessTelNo; }
            set { _accessTelNo = value; }
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
            get { return _pop3UserId; }
            set { _pop3UserId = value; }
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
            get { return _pop3Password; }
            set { _pop3Password = value; }
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
            get { return _pop3ServerName; }
            set { _pop3ServerName = value; }
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
            get { return _smtpServerName; }
            set { _smtpServerName = value; }
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
            get { return _smtpUserId; }
            set { _smtpUserId = value; }
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
            get { return _smtpPassword; }
            set { _smtpPassword = value; }
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
            get { return _smtpAuthUseDiv; }
            set { _smtpAuthUseDiv = value; }
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
            get { return _senderName; }
            set { _senderName = value; }
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
            get { return _popBeforeSmtpUseDiv; }
            set { _popBeforeSmtpUseDiv = value; }
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
            get { return _popServerPortNo; }
            set { _popServerPortNo = value; }
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
            get { return _smtpServerPortNo; }
            set { _smtpServerPortNo = value; }
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
            get { return _mailServerTimeoutVal; }
            set { _mailServerTimeoutVal = value; }
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
            get { return _backupSendDivCd; }
            set { _backupSendDivCd = value; }
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
            get { return _backupFormal; }
            set { _backupFormal = value; }
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
            get { return _mailSendDivUnitCnt; }
            set { _mailSendDivUnitCnt = value; }
        }

        /// public propaty name  :  FilePathNm
        /// <summary>ファイルパス名プロパティ</summary>
        /// <value>メール保存先パス</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ファイルパス名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string FilePathNm
        {
            get { return _filePathNm; }
            set { _filePathNm = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// メール情報設定マスタコンストラクタ
        /// </summary>
        /// <returns>MailInfoSettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailInfoSettingクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailInfoSetting()
        {
        }

        /// <summary>
        /// メール情報設定マスタコンストラクタ
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
        /// <param name="filePathNm">ファイルパス名(メール保存先パス)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>MailInfoSettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailInfoSettingクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
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
        /// メール情報設定マスタ複製処理
        /// </summary>
        /// <returns>MailInfoSettingクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいMailInfoSettingクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailInfoSetting Clone()
        {
            return new MailInfoSetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._mailSendMngNo, this._mailAddress, this._dialUpCode, this._dialUpConnectName, this._dialUpLoginName, this._dialUpPassword, this._accessTelNo, this._pop3UserId, this._pop3Password, this._pop3ServerName, this._smtpServerName, this._smtpUserId, this._smtpPassword, this._smtpAuthUseDiv, this._senderName, this._popBeforeSmtpUseDiv, this._popServerPortNo, this._smtpServerPortNo, this._mailServerTimeoutVal, this._backupSendDivCd, this._backupFormal, this._mailSendDivUnitCnt, this._filePathNm, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// メール情報設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のMailInfoSettingクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailInfoSettingクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
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
        /// メール情報設定マスタ比較処理
        /// </summary>
        /// <param name="mailInfoSetting1">
        ///                    比較するMailInfoSettingクラスのインスタンス
        /// </param>
        /// <param name="mailInfoSetting2">比較するMailInfoSettingクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailInfoSettingクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
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
        /// メール情報設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のMailInfoSettingクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailInfoSettingクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
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
        /// メール情報設定マスタ比較処理
        /// </summary>
        /// <param name="mailInfoSetting1">比較するMailInfoSettingクラスのインスタンス</param>
        /// <param name="mailInfoSetting2">比較するMailInfoSettingクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailInfoSettingクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
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

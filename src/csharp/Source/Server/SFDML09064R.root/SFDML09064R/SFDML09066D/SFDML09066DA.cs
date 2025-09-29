using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MailSndMngWork
    /// <summary>
    ///                      メール送信管理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   メール送信管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2005/03/05</br>
    /// <br>Genarated Date   :   2006/10/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006/09/29  980056 祖慶</br>
    /// <br>                 :   各項目を全面的に見直し。</br>
    /// <br>                 :   (変更前のレイアウトはマスタメンテ以外</br>
    /// <br>                 :   使用されていないので大幅な修正をして</br>
    /// <br>                 :   ます)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MailSndMngWork : IFileHeader
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


        /// <summary>
        /// メール送信管理ワークコンストラクタ
        /// </summary>
        /// <returns>MailSndMngWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailSndMngWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MailSndMngWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MailSndMngWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MailSndMngWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MailSndMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailSndMngWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MailSndMngWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MailSndMngWork || graph is ArrayList || graph is MailSndMngWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MailSndMngWork).FullName));

            if (graph != null && graph is MailSndMngWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MailSndMngWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
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

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //e-mail送信管理番号
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendMngNo
            //メールアドレス
            serInfo.MemberInfo.Add(typeof(string)); //MailAddress
            //ダイヤルアップ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DialUpCode
            //ダイヤルアップ接続名称
            serInfo.MemberInfo.Add(typeof(string)); //DialUpConnectName
            //ダイヤルアップログイン名
            serInfo.MemberInfo.Add(typeof(string)); //DialUpLoginName
            //ダイヤルアップパスワード
            serInfo.MemberInfo.Add(typeof(string)); //DialUpPassword
            //接続先電話番号
            serInfo.MemberInfo.Add(typeof(string)); //AccessTelNo
            //POP3ユーザーID
            serInfo.MemberInfo.Add(typeof(string)); //Pop3UserId
            //POP3パスワード
            serInfo.MemberInfo.Add(typeof(string)); //Pop3Password
            //POP3サーバー名
            serInfo.MemberInfo.Add(typeof(string)); //Pop3ServerName
            //SMTPサーバー名
            serInfo.MemberInfo.Add(typeof(string)); //SmtpServerName
            //SMTPユーザID
            serInfo.MemberInfo.Add(typeof(string)); //SmtpUserId
            //SMTPパスワード
            serInfo.MemberInfo.Add(typeof(string)); //SmtpPassword
            //SMTP認証使用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SmtpAuthUseDiv
            //差出人名
            serInfo.MemberInfo.Add(typeof(string)); //SenderName
            //POP Before SMTP使用区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PopBeforeSmtpUseDiv
            //POPサーバ ポート番号
            serInfo.MemberInfo.Add(typeof(Int32)); //PopServerPortNo
            //SMTPサーバ ポート番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SmtpServerPortNo
            //メールサーバタイムアウト値
            serInfo.MemberInfo.Add(typeof(Int32)); //MailServerTimeoutVal
            //バックアップ送信区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BackupSendDivCd
            //バックアップ形式
            serInfo.MemberInfo.Add(typeof(Int32)); //BackupFormal
            //メール送信分割単位件数
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
        /// MailSndMngWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 31;

        /// <summary>
        ///  MailSndMngWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailSndMngWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMailSndMngWork(System.IO.BinaryWriter writer, MailSndMngWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //e-mail送信管理番号
            writer.Write(temp.MailSendMngNo);
            //メールアドレス
            writer.Write(temp.MailAddress);
            //ダイヤルアップ区分
            writer.Write(temp.DialUpCode);
            //ダイヤルアップ接続名称
            writer.Write(temp.DialUpConnectName);
            //ダイヤルアップログイン名
            writer.Write(temp.DialUpLoginName);
            //ダイヤルアップパスワード
            writer.Write(temp.DialUpPassword);
            //接続先電話番号
            writer.Write(temp.AccessTelNo);
            //POP3ユーザーID
            writer.Write(temp.Pop3UserId);
            //POP3パスワード
            writer.Write(temp.Pop3Password);
            //POP3サーバー名
            writer.Write(temp.Pop3ServerName);
            //SMTPサーバー名
            writer.Write(temp.SmtpServerName);
            //SMTPユーザID
            writer.Write(temp.SmtpUserId);
            //SMTPパスワード
            writer.Write(temp.SmtpPassword);
            //SMTP認証使用区分
            writer.Write(temp.SmtpAuthUseDiv);
            //差出人名
            writer.Write(temp.SenderName);
            //POP Before SMTP使用区分
            writer.Write(temp.PopBeforeSmtpUseDiv);
            //POPサーバ ポート番号
            writer.Write(temp.PopServerPortNo);
            //SMTPサーバ ポート番号
            writer.Write(temp.SmtpServerPortNo);
            //メールサーバタイムアウト値
            writer.Write(temp.MailServerTimeoutVal);
            //バックアップ送信区分
            writer.Write(temp.BackupSendDivCd);
            //バックアップ形式
            writer.Write(temp.BackupFormal);
            //メール送信分割単位件数
            writer.Write(temp.MailSendDivUnitCnt);

        }

        /// <summary>
        ///  MailSndMngWorkインスタンス取得
        /// </summary>
        /// <returns>MailSndMngWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailSndMngWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MailSndMngWork GetMailSndMngWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MailSndMngWork temp = new MailSndMngWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //e-mail送信管理番号
            temp.MailSendMngNo = reader.ReadInt32();
            //メールアドレス
            temp.MailAddress = reader.ReadString();
            //ダイヤルアップ区分
            temp.DialUpCode = reader.ReadInt32();
            //ダイヤルアップ接続名称
            temp.DialUpConnectName = reader.ReadString();
            //ダイヤルアップログイン名
            temp.DialUpLoginName = reader.ReadString();
            //ダイヤルアップパスワード
            temp.DialUpPassword = reader.ReadString();
            //接続先電話番号
            temp.AccessTelNo = reader.ReadString();
            //POP3ユーザーID
            temp.Pop3UserId = reader.ReadString();
            //POP3パスワード
            temp.Pop3Password = reader.ReadString();
            //POP3サーバー名
            temp.Pop3ServerName = reader.ReadString();
            //SMTPサーバー名
            temp.SmtpServerName = reader.ReadString();
            //SMTPユーザID
            temp.SmtpUserId = reader.ReadString();
            //SMTPパスワード
            temp.SmtpPassword = reader.ReadString();
            //SMTP認証使用区分
            temp.SmtpAuthUseDiv = reader.ReadInt32();
            //差出人名
            temp.SenderName = reader.ReadString();
            //POP Before SMTP使用区分
            temp.PopBeforeSmtpUseDiv = reader.ReadInt32();
            //POPサーバ ポート番号
            temp.PopServerPortNo = reader.ReadInt32();
            //SMTPサーバ ポート番号
            temp.SmtpServerPortNo = reader.ReadInt32();
            //メールサーバタイムアウト値
            temp.MailServerTimeoutVal = reader.ReadInt32();
            //バックアップ送信区分
            temp.BackupSendDivCd = reader.ReadInt32();
            //バックアップ形式
            temp.BackupFormal = reader.ReadInt32();
            //メール送信分割単位件数
            temp.MailSendDivUnitCnt = reader.ReadInt32();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
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
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>MailSndMngWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MailSndMngWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
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

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;


namespace Broadleaf.Library.Net.Mail
{
    /// <summary>
    /// TSMTP(メール送信)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SuperFrontman専用メール送信コンポーネントクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.15</br>
    /// <br></br>
    /// <br>Update Note: 2006.11.20 鹿野　幸生</br>
    /// </remarks>
    public partial class TSMTP : Component
    {
        //  バージョン
        const string ctDefaultMailerName = "SuperFrontman Mail Delivery Program ver 1.0";
        
        //  コンポーネント・イベント
        /// <summary>TSMTPコンポーネントサーバー接続状況変化イベント</summary>
        public event EventHandler<SendingEventArgs> SmtpConnectedChangedEx;
        /// <summary>TSMTPコンポーネントBUSY状況変化イベント</summary>
        public event EventHandler<SendingEventArgs> SmtpBusyChanged;
        /// <summary>TSMTPコンポーネント送信イベント</summary>
        public event EventHandler<SendEndEventArgs> SmtpEndSend;
        /// <summary>TSMTPコンポーネント送信進捗イベント</summary>
        public event EventHandler<SendingProgressEventArgs> SmtpProgress;
        /// <summary>TSMTPコンポーネントトレースイベント</summary>
        public event EventHandler<SendingEventArgs> SmtpTrace;
        /// <summary>TPOPコンポーネントサーバー接続状況変化イベント</summary>
        public event EventHandler<SendingEventArgs> PopConnectedChangedEx;
        /// <summary>TPOPコンポーネントBUSY状況変化イベント</summary>
        public event EventHandler<SendingEventArgs> PopBusyChanged;
        /// <summary>TPOPコンポーネント受信進捗イベント</summary>
        public event EventHandler<SendingProgressEventArgs> PopProgress;
        /// <summary>TPOPコンポーネントトレースイベント</summary>
        public event EventHandler<SendingEventArgs> PopTrace;

        //  基のSMTP、POP3コンポーネント
        private Dart.PowerTCP.Mail.Smtp mSmtp;
        private Dart.PowerTCP.Mail.Pop mPop;

        //  待ち時間作成用のタイマーコンポ
        private Timer intTimer;

        //  進捗状況表示画面
        private ProgressWindow pWin = new ProgressWindow();

        //  各種メール送信に必要なプロパティの実体
        private ServerInfomation mServerInfo = new ServerInfomation();
        private AuthorizationInfomation mAuthorizationInfo = new AuthorizationInfomation();
        private MailOption mMailOp = new MailOption();
        private TraceOption mTraceOp = new TraceOption();
        private MailMessageStreamCollection mMMessages = new MailMessageStreamCollection();
        private object mTag = new object();
        private SmtpSendResult mSmtpSendResult = new SmtpSendResult();          //  2006.11.20  追加

        //  進捗状況表示画面の設定プロパティの実体
        //private bool mProgressDialog;                                         //  2006.11.20  変更
        //private bool mDialogConfirm;                                          //        V
        internal static bool mProgressDialog;                                   //        V
        internal static bool mDialogConfirm;                                    //  2006.11.20  変更

        //  ステータスプロパティの実体
        private object mGlobalStatus;
        private int mStatus;
        private string mStatusMessage;
        private bool mSendingError = false;                 //  送信開始以降、にエラーが発生した場合にtrueになる

        //  接続状況遷移中ステータスプロパティの実体
        private bool mConnectedStatus;
        private bool mBusyStatus;

        //  トレース情報用内部動作専用クラス(元々のプロパティには設定されないケースがあるので)
        private TraceOption mSendingTraceOp = new TraceOption();
        private bool mProgressDialog2;                                          //  2006.11.20  追加

        //  現在・最大構造体
        //private struct SendFigure                                             //  2006.11.20  変更
        internal struct SendFigure
        {
            public int NowNo;
            public int MaxFig;
        }
        //private static SendFigure mSendFigure;                                //  2006.11.20  変更
        internal static SendFigure mSendFigure;

        //  イベントハンドラー部

        /// <summary>
        /// SendingEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信中ステータスイベントパラメータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class SendingEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;

            /// <summary>ステータスコードプロパティ</summary>
            /// <value>送信中ステータス</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>ステータスメッセージプロパティ</summary>
            /// <value>送信中ステータスメッセージ</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>
            /// SendingEventArgsコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : 送信中ステータスイベントパラメータクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.15</br>
            /// </remarks>
            public SendingEventArgs(int Status, string StatusMessage)
                : base()
            {
                _status = Status;
                _statusmsg = StatusMessage;
            }
        }

        /// <summary>
        /// SendEndEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信終了イベントパラメータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class SendEndEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;
            private int _maxfig;
            private int _nownum;

            /// <summary>ステータスコードプロパティ</summary>
            /// <value>送信終了ステータス</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>ステータスメッセージプロパティ</summary>
            /// <value>送信終了ステータスメッセージ</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>送信対象数プロパティ</summary>
            /// <value>送信対象の数</value>
            /// <remarks></remarks>
            public int MaxMessageFig
            {
                get { return _maxfig; }
            }

            /// <summary>現在送信番号プロパティ</summary>
            /// <value>送信対象数の内の送信した番号</value>
            /// <remarks></remarks>
            public int NowMessageNo
            {
                get { return _nownum; }
            }

            /// <summary>
            /// SendEndEventArgsコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : 送信終了ステータスイベントパラメータクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.15</br>
            /// </remarks>
            public SendEndEventArgs(int NowMessageNo, int MaxMessageFig, int Status, string StatusMessage)
                : base()
            {
                _nownum = NowMessageNo;
                _maxfig = MaxMessageFig;
                _status = Status;
                _statusmsg = StatusMessage;
            }
        }

        /// <summary>
        /// SendingProgressEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信中進捗状況イベントパラメータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 2006.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class SendingProgressEventArgs : EventArgs
        {

            private int _maxfig;
            private int _nownum;
            private int _nowpos;
            private int _maxpos;

            /// <summary>現在位置プロパティ</summary>
            /// <value>進捗全体の現在のポジション</value>
            /// <remarks></remarks>
            public int NowPos
            {
                get { return _nowpos; }
            }
            /// <summary>全体位置プロパティ</summary>
            /// <value>進捗全体</value>
            /// <remarks></remarks>
            public int MaxPos
            {
                get { return _maxpos; }
            }

            /// <summary>送信対象数プロパティ</summary>
            /// <value>送信対象の数</value>
            /// <remarks></remarks>
            public int MaxMessageFig
            {
                get { return _maxfig; }
            }

            /// <summary>現在送信番号プロパティ</summary>
            /// <value>送信対象数の内の送信した番号</value>
            /// <remarks></remarks>
            public int NowMessageNo
            {
                get { return _nownum; }
            }

            /// <summary>
            /// SendingProgressEventArgsコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : 送信中進捗状況イベントパラメータクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.15</br>
            /// </remarks>
            public SendingProgressEventArgs(int NowMessageNo, int MaxMessageFig, int NowPos, int MaxPos)
                : base()
            {
                _nownum = NowMessageNo;
                _maxfig = MaxMessageFig;
                _nowpos = NowPos;
                _maxpos = MaxPos;
            }
        }

        /// <summary>
        /// MailOptionClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       : メールオプション用カスタムコンバータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 2006.11.20 鹿野　幸生</br>
        /// </remarks>
        internal class MailOptionClassConverter : ExpandableObjectConverter
        {

            /// <summary>型変換(他型へ変換)可能プロパティ</summary>
            /// <value>他型へ変換する際、型毎に変換の可・不可を返す</value>
            /// <remarks></remarks>
            public override bool CanConvertTo(
                ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(MailOption))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// 変換(他型へ変換)処理
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <param name="destinationType"></param>
            /// <returns>変換結果</returns>
            /// <remarks>
            /// <br>Note       :指定した値オブジェクトを、指定した型に変換する</br>
            /// <br>Programmer  : 96203 鹿野　幸生</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) &&
                    value is MailOption)
                {
                    try
                    {
                        string retval;
                        MailOption mp = (MailOption)value;
                        retval = mp.AdjustTimeZone.ToString() + ",";
                        retval = retval + mp.DeliveryStatusNotification.ToString() + ",";
                        retval = retval + mp.DeliveryStatusNotificationMessage.ToString() + ",";
                        retval = retval + mp.DispositionNotification.ToString() + ",";
                        retval = retval + mp.DispositionNotificationAddress + ",";
                        retval = retval + mp.DividingSend.ToString()+ ",";
                        retval = retval + mp.EnvelopeID + ",";
                        retval = retval + mp.HelloName + ",";
                        retval = retval + mp.ProcTimeOut.ToString() + ",";
                        retval = retval + mp.ReferenceDirectory + ",";
                        //retval = retval + mp.SendMailerName.ToString();                   //  2006.11.20  変更
                        retval = retval + mp.SendMailerName.ToString() + ",";
                        retval = retval + mp.SendMethodEnumType.ToString();                 //  2006.11.20  追加
                        return retval;
                    }
                    catch
                    {
                        throw new ArgumentException("Can not convert '" + (string)value + "' to type MailOptions");
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

            /// <summary>型変換(他型からの変換)可能プロパティ</summary>
            /// <value>他型からの変換する際、型毎に変換の可・不可を返す</value>
            /// <remarks></remarks>
            public override bool CanConvertFrom(
                ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// 変換(他型からの変換)処理
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <returns>変換結果</returns>
            /// <remarks>
            /// <br>Note       :指定した値オブジェクトを、指定した型に変換する</br>
            /// <br>Programmer  : 96203 鹿野　幸生</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    try
                    {
//                        string[] vs = value.ToString().Split((new char[] { ',' }), 11);           //  2006.11.20  変更
                        string[] vs = value.ToString().Split((new char[] { ',' }), 12);
                        MailOption mp = new MailOption();

                        if (vs[0].IndexOf("true", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.AdjustTimeZone = true;
                        else
                            mp.AdjustTimeZone = false;
                        if (vs[1].IndexOf("true",  StringComparison.OrdinalIgnoreCase) > -1)
                            mp.DeliveryStatusNotification = true;
                        else
                            mp.DeliveryStatusNotification = false;
                        if (vs[2].IndexOf("true",  StringComparison.OrdinalIgnoreCase) > -1)
                            mp.DeliveryStatusNotificationMessage = true;
                        else
                            mp.DeliveryStatusNotificationMessage = false;
                        if (vs[3].IndexOf("true",  StringComparison.OrdinalIgnoreCase) > -1)
                            mp.DispositionNotification = true;
                        else
                            mp.DispositionNotification = false;
                        mp.DispositionNotificationAddress = vs[4];
                        if (vs[5].IndexOf("true", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.DividingSend = true;
                        else
                            mp.DividingSend = false;
                        mp.EnvelopeID = vs[6];
                        mp.HelloName = vs[7];
                        mp.ProcTimeOut = System.Convert.ToInt32(vs[8]);
                        mp.ReferenceDirectory = vs[9];
                        if (vs[10].IndexOf("true", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.SendMailerName = true;
                        else
                            mp.SendMailerName = false;
                        if (vs[11].IndexOf("Asynchronous", StringComparison.OrdinalIgnoreCase) > -1)        //  2006.11.20  追加
                            mp.SendMethodEnumType = SendMethodEnumTypes.Asynchronous;
                        else if (vs[11].IndexOf("Synchronous", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.SendMethodEnumType = SendMethodEnumTypes.Synchronous;
                        else
                            mp.SendMethodEnumType= SendMethodEnumTypes.NoEventSynchronous;
                        return mp;
                    }
                    catch(Exception er)
                    {
                        throw new ArgumentException("Can not convert '" + (string)value + "' to type MailOptions " + er.Message);
                    }
                }
                return base.ConvertFrom(context, culture, value);
            }
        }

        /// <summary>
        /// MailOption
        /// </summary>
        /// <remarks>
        /// <br>Note       : メールオプションクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 2006.11.20 鹿野　幸生</br>
        /// </remarks>
        [TypeConverter(typeof(MailOptionClassConverter))]
        public class MailOption
        {

            //  メールのオプションプロパティの内部保持用
            private bool mDeliveryStatusNotification;
            private bool mDeliveryStatusNotificationMessage;
            private string mDispositionNotificationAddress;
            private bool mDispositionNotification;
            private string mEnvelopeID;
            private bool mSendMailerName;
            private bool mAdjustTimeZone;
            private string mMailerName;
            private string mReferenceDirectory;
            private string mHelloName;
            private bool mDividingSend;
            private int mProcTimeOut;
            private SendMethodEnumTypes mSendMethodEnumType;                    //  2006.11.20 追加

            /// <summary>
            /// MailOptionクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : MailOptionクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.15</br>
            /// </remarks>
            public MailOption()
            {
                mDeliveryStatusNotification = false;
                mDeliveryStatusNotificationMessage = false;
                mDispositionNotificationAddress = "";
                mDispositionNotification = false;
                mEnvelopeID = "";
                mSendMailerName = true;
                mMailerName = ctDefaultMailerName;
                mReferenceDirectory = "";
                mHelloName = "localhost";
                mAdjustTimeZone = true;
                mDividingSend = false;
                mProcTimeOut = 60;
                mSendMethodEnumType = SendMethodEnumTypes.Asynchronous;         //  2006.11.20 追加
            }

            /// <summary>配信状態通知プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("配信状態通知を設定します(対応サーバーのみ)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool DeliveryStatusNotification
            {
                get
                {
                    return (mDeliveryStatusNotification);
                }
                set
                {
                    mDeliveryStatusNotification = value;
                }
            }

            /// <summary>配信状態通知時のメッセージ添付可否プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("配信状態通知にメッセージ添付を設定します(対応サーバーのみ)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool DeliveryStatusNotificationMessage
            {
                get
                {
                    return (mDeliveryStatusNotificationMessage);
                }
                set
                {
                    mDeliveryStatusNotificationMessage = value;
                }
            }

            /// <summary>配信状態通知時のEnvelope-ID設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("配信状態通知時のEnvelope-IDを設定します(対応サーバーのみ)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string EnvelopeID
            {
                get
                {
                    return (mEnvelopeID);
                }
                set
                {
                    mEnvelopeID = value;
                }
            }

            /// <summary>開封確認要求設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("送信者からの開封確認を要求します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool DispositionNotification
            {
                get
                {
                    return (mDispositionNotification);
                }
                set
                {
                    mDispositionNotification = value;
                }
            }

            /// <summary>開封確認・送信先設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("開封確認の送信先を指定します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string DispositionNotificationAddress
            {
                get
                {
                    return (mDispositionNotificationAddress);
                }
                set
                {
                    mDispositionNotificationAddress = value;
                }
            }

            /// <summary>メーラー名称設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("メーラーの名称を通知します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool SendMailerName
            {
                get
                {
                    return (mSendMailerName);
                }
                set
                {
                    mSendMailerName = value;
                }
            }

            /// <summary>メーラー名称プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("メーラー名称が設定されます")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string MailerName
            {
                get
                {
                    return (mMailerName);
                }
            }

            /// <summary>メールの入力用作業ディレクトリ設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("メールの入力用作業ディレクトリ")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string ReferenceDirectory
            {
                get
                {
                    return (mReferenceDirectory);
                }
                set
                {
                    mReferenceDirectory = value;
                }

            }

            /// <summary>HELLOネーム設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("SMTPサーバーに送信するHELLP or ELHOコマンドのFQDNを設定します(初期値:localhost)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string HelloName
            {
                get
                {
                    return (mHelloName);
                }
                set
                {
                    mHelloName = value;
                }
            }

            /// <summary>ローカル時刻差分修正設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("メールのGMT送信時刻にローカル時刻差分を設定します(初期値:true)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool AdjustTimeZone
            {
                get
                {
                    return (mAdjustTimeZone);
                }
                set
                {
                    mAdjustTimeZone = value;
                }
            }

            /// <summary>送信先別分割送信設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("送信先一件毎にメールを送ります(To指定のみ)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool DividingSend
            {
                get
                {
                    return (mDividingSend);
                }
                set
                {
                    mDividingSend = value;
                }
            }

            /// <summary>処理待ちタイムアウト時間設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("送信時の内部処理の待ち時間を秒単位で設定します(初期値:60秒)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public int ProcTimeOut
            {
                get
                {
                    return (mProcTimeOut);
                }
                set
                {
                    mProcTimeOut = value;
                }
            }

            /// <summary>送信方式設定プロパティ</summary>
            /// <value>Asyncronous:非同期,Syncronous:同期,NoEventSynchronous</value>
            /// <remarks></remarks>
            [Description("送信時の同期・非同期を設定します(初期値:非同期)")]
            public SendMethodEnumTypes SendMethodEnumType                       //  2006.11.20  追加
            {
                get
                {
                    return (mSendMethodEnumType);
                }
                set
                {
                    //  イベント無しならダイアログは強制解除
                    if (mSendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
                    {
                        mProgressDialog = false;
                        mDialogConfirm = false;
                    }
                    mSendMethodEnumType = value;
                }
            }
            
        }

        /// <summary>
        /// SmtpSendResult
        /// </summary>
        /// <remarks>
        /// <br>Note       : SmtpSendResultクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.11.20</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class SmtpSendResult
        {

            private int mTotalFigure;
            private int mSentFigure;

            /// <summary>
            /// SmtpSendResultクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : SmtpSendResultクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.11.20</br>
            /// </remarks>
            public SmtpSendResult()
            {
                mTotalFigure = 0;
                mSentFigure = 0;
            }


            /// <summary>送信対象件数プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Browsable(false)]
            public int TotalFigure
            {
                get
                {
                    return (mTotalFigure);
                }
                internal set
                {
                    mTotalFigure = value;
                }
            }

            /// <summary>送信済件数プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Browsable(false)]
            public int SentFigure
            {
                get
                {
                    return (mSentFigure);
                }
                internal set
                {
                    mSentFigure = value;
                }
            }
        }

        /// <summary>認証方式列挙型</summary>
        /// <remarks>認証方式を表す列挙型です</remarks>
        [TypeConverter(typeof(EnumConverter))]
        public enum AuthorizationTypes
        {
            /// <summary>無し</summary>
            None,
            /// <summary>POP Before SMT型</summary>
            POPBeforeSMTP,
            /// <summary>SMTP AUTH型</summary>
            SMTPAuth,
            /// <summary>自動トライ型</summary>
            Auto
        }

        /// <summary>
        /// AuthorizationInfomationClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       :  承認情報用カスタムコンバータータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class AuthorizationInfomationClassConverter : ExpandableObjectConverter
        {
            /// <summary>型変換(他型へ変換)可能プロパティ</summary>
            /// <value>他型へ変換する際、型毎に変換の可・不可を返す</value>
            /// <remarks></remarks>
            public override bool CanConvertTo(
                ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(AuthorizationInfomation))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// 変換(他型へ変換)処理
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <param name="destinationType"></param>
            /// <returns>変換結果</returns>
            /// <remarks>
            /// <br>Note       :指定した値オブジェクトを、指定した型に変換する</br>
            /// <br>Programmer  : 96203 鹿野　幸生</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) &&
                    value is AuthorizationInfomation)
                {
                    try
                    {
                        string retval;
                        AuthorizationInfomation ai = (AuthorizationInfomation)value;
                        retval = ai.AuthType.ToString() + ",";
                        retval = retval + ai.PopAccount + ",";
                        retval = retval + ai.PopPassWord + ",";
                        retval = retval + ai.SmtpAccount + ",";
                        retval = retval + ai.SmtpPassWord;
                        return retval;
                    }
                    catch (Exception er)
                    {
                        throw new ArgumentException("Can not convert '" + (string)value + "' to type AuthorizationInfo " + er.Message);
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

            /// <summary>型変換(他型からの変換)可能プロパティ</summary>
            /// <value>他型から変換する際、型毎に変換の可・不可を返す</value>
            /// <remarks></remarks>
            public override bool CanConvertFrom(
                ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// 変換(他型からの変換)処理
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <returns>変換結果</returns>
            /// <remarks>
            /// <br>Note       :指定した値オブジェクトを、指定した型に変換する</br>
            /// <br>Programmer  : 96203 鹿野　幸生</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    try
                    {
                        string[] vs = value.ToString().Split(new char[] { ',' }, 3);
                        AuthorizationInfomation ai = new AuthorizationInfomation();
                        if (vs[0].IndexOf("None",  StringComparison.OrdinalIgnoreCase) > -1)
                            ai.AuthType = AuthorizationTypes.None;
                        else if (vs[0].IndexOf("POPBeforeSMTP", StringComparison.OrdinalIgnoreCase) > -1)
                            ai.AuthType = AuthorizationTypes.POPBeforeSMTP;
                        else if (vs[0].IndexOf("SMTPAuth", StringComparison.OrdinalIgnoreCase) > -1)
                            ai.AuthType = AuthorizationTypes.SMTPAuth;
                        else
                            ai.AuthType = AuthorizationTypes.Auto;
                        ai.PopAccount = vs[1];
                        ai.PopPassWord = vs[2];
                        ai.SmtpAccount = vs[3];
                        ai.SmtpPassWord = vs[4];
                        return ai;
                    }
                    catch (Exception er)
                    {
                        throw new ArgumentException("Can not convert '" + (string)value + "' to type AuthorizationInfo " + er.Message);
                    }
                }
                return base.ConvertFrom(context, culture, value);
            }
        }

        //  
        /// <summary>
        /// AuthorizationInfomation
        /// </summary>
        /// <remarks>
        /// <br>Note       :  承認情報クラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        [TypeConverter(typeof(AuthorizationInfomationClassConverter))]
        public class AuthorizationInfomation
        {
            //  承認情報内部保持用
            private string mPopAccount;
            private string mPopPassWord;
            private string mSmtpAccount;
            private string mSmtpPassWord;
            private AuthorizationTypes mAuthType;

            /// <summary>
            /// AuthorizationInfomationクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : AuthorizationInfomationクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.15</br>
            /// </remarks>
            public AuthorizationInfomation()
            {
                mPopAccount = "";
                mPopPassWord = "";
                mSmtpAccount = "";
                mSmtpPassWord = "";
                mAuthType = AuthorizationTypes.None;
            }

            /// <summary>POP3認証用アカウント名プロパティ</summary>
            /// <value>POP3認証に使用するアカウント名・ユーザー名を設定します</value>
            /// <remarks></remarks>
            [Description("POP3認証用のアカウントを設定します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string PopAccount
            {
                get
                {
                    return (mPopAccount);
                }
                set
                {
                    mPopAccount = value;
                }
            }

            /// <summary>POP3認証用パスワードプロパティ</summary>
            /// <value>POP3認証に使用するパスワードを設定します</value>
            /// <remarks></remarks>
            [Description("POP3認証用のパスワードを設定します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string PopPassWord
            {
                get
                {
                    return (mPopPassWord);
                }
                set
                {
                    mPopPassWord = value;
                }

            }

            /// <summary>SMTP認証用アカウント名プロパティ</summary>
            /// <value>SMTP認証に使用するアカウント名・ユーザー名を設定します</value>
            /// <remarks></remarks>
            [Description("SMTP認証用のアカウントを設定します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string SmtpAccount
            {
                get
                {
                    return (mSmtpAccount);
                }
                set
                {
                    mSmtpAccount = value;
                }
            }

            /// <summary>SMTP認証用パスワードプロパティ</summary>
            /// <value>SMTP認証に使用するパスワードを設定します</value>
            /// <remarks></remarks>
            [Description("SMTP認証用のパスワードを設定します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string SmtpPassWord
            {
                get
                {
                    return (mSmtpPassWord);
                }
                set
                {
                    mSmtpPassWord = value;
                }

            }

            /// <summary>認証形式設定プロパティ</summary>
            /// <value>認証形式を設定します</value>
            /// <remarks></remarks>
            [Description("認証方法を設定します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public AuthorizationTypes AuthType
            {
                get
                {
                    return (mAuthType);
                }
                set
                {
                    mAuthType = value;
                }

            }
        }
        
        /// <summary>
        /// ServerInfomationClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       :  サーバー用カスタムコンバータータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class ServerInfomationClassConverter : ExpandableObjectConverter
        {
            /// <summary>型変換(他型へ変換)可能プロパティ</summary>
            /// <value>他型へ変換する際、型毎に変換の可・不可を返す</value>
            /// <remarks></remarks>
            public override bool CanConvertTo(
                ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(ServerInfomation))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// 変換(他型へ変換)処理
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <param name="destinationType"></param>
            /// <returns>変換結果</returns>
            /// <remarks>
            /// <br>Note       :指定した値オブジェクトを、指定した型に変換する</br>
            /// <br>Programmer  : 96203 鹿野　幸生</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) &&
                    value is ServerInfomation)
                {
                    try
                    {
                        string retval;
                        ServerInfomation si = (ServerInfomation)value;
                        retval = si.POPPort.ToString() + ",";
                        retval = retval + si.POPServer + ",";
                        retval = retval + si.POPTimeOut.ToString() + ",";
                        retval = retval + si.SMTPPort.ToString() + ",";
                        retval = retval + si.SMTPServer + ",";
                        retval = retval + si.SMTPTimeOut.ToString();
                        return retval;
                    }
                    catch (Exception er)
                    {
                        throw new ArgumentException("Can not convert '" + (string)value + "' to type ServerInfo " + er.Message);
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

            /// <summary>型変換(他型からの変換)可能プロパティ</summary>
            /// <value>他型から変換する際、型毎に変換の可・不可を返す</value>
            /// <remarks></remarks>
            public override bool CanConvertFrom(
                ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// 変換(他型からの変換)処理
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <returns>変換結果</returns>
            /// <remarks>
            /// <br>Note       :指定した値オブジェクトを、指定した型に変換する</br>
            /// <br>Programmer  : 96203 鹿野　幸生</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    try
                    {
                        string[] vs = value.ToString().Split(new char[] { ',' }, 6);
                        ServerInfomation si = new ServerInfomation();
                        si.POPPort = System.Convert.ToInt32(vs[0]);
                        si.POPServer = vs[1];
                        si.POPTimeOut = System.Convert.ToInt32(vs[2]);
                        si.SMTPPort = System.Convert.ToInt32(vs[3]);
                        si.SMTPServer = vs[4];
                        si.SMTPTimeOut = System.Convert.ToInt32(vs[5]);
                        return si;
                    }
                    catch (Exception er)
                    {
                        throw new ArgumentException("Can not convert '" + (string)value + "' to type ServerInfo " + er.Message);
                    }
                }
                return base.ConvertFrom(context, culture, value);
            }
        }

        /// <summary>
        /// ServerInfomation
        /// </summary>
        /// <remarks>
        /// <br>Note       :  サーバー情報クラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        [TypeConverter(typeof(ServerInfomationClassConverter))]
        public class ServerInfomation
        {
            private string mSMTPServer;
            private int mSMTPPort;
            private int mSMTPTimeOut;
            private string mPOPServer;
            private int mPOPPort;
            private int mPOPTimeOut;

            /// <summary>
            /// ServerInfomationクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : ServerInfomationクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.15</br>
            /// </remarks>
            public ServerInfomation()
            {
                mSMTPServer = "";
                mSMTPPort = 25;
                mSMTPTimeOut = 60;
                mPOPServer = "";
                mPOPPort = 110;
                mPOPTimeOut = 60;
            }

            /// <summary>SMTP Serverアドレスプロパティ</summary>
            /// <value>SMTP Serverのアドレスを設定します</value>
            /// <remarks></remarks>
            [Description("SMTPサーバーを設定します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string SMTPServer
            {
                get
                {
                    return (mSMTPServer);
                }
                set
                {
                    mSMTPServer = value;
                }
            }

            /// <summary>SMTP Serverポートプロパティ</summary>
            /// <value>SMTP Serverのポートを設定します</value>
            /// <remarks></remarks>
            [Description("SMTPサーバーに接続するポートを設定します(初期値:25)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public int SMTPPort
            {
                get
                {
                    return (mSMTPPort);
                }
                set
                {
                    mSMTPPort = value;
                }
            }

            /// <summary>POP3 Servearアドレスプロパティ</summary>
            /// <value>POP3 Serverのアドレス(認証用)を設定します</value>
            /// <remarks></remarks>
            [Description("POP3サーバーを設定します(POP Before SMTP認証時は必須)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string POPServer
            {
                get
                {
                    return (mPOPServer);
                }
                set
                {
                    mPOPServer = value;
                }

            }

            /// <summary>POP3 Servearポートプロパティ</summary>
            /// <value>POP3 Serverのポートを設定します</value>
            /// <remarks></remarks>
            [Description("POP3サーバーに接続するポートを設定します(初期値:110)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public int POPPort
            {
                get
                {
                    return (mPOPPort);
                }
                set
                {
                    mPOPPort = value;
                }
            }

            /// <summary>SMTP Servearタイムアウト時間設定ポートプロパティ</summary>
            /// <value>SMTP Serverのタイムアウト時間を設定します</value>
            /// <remarks></remarks>
            [Description("SMTPサーバーのタイムアウトを秒単位で設定します(初期値:60)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public int SMTPTimeOut
            {
                get
                {
                    return (mSMTPTimeOut);
                }
                set
                {
                    mSMTPTimeOut = value;
                }
            }

            /// <summary>POP3 Servearタイムアウト時間設定ポートプロパティ</summary>
            /// <value>POP3 Serverのタイムアウト時間を設定します</value>
            /// <remarks></remarks>
            [Description("PPOP3サーバーのタイムアウトを秒単位で設定します(初期値:60)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public int POPTimeOut
            {
                get
                {
                    return (mPOPTimeOut);
                }
                set
                {
                    mPOPTimeOut = value;
                }
            }
        }

        /// <summary>
        /// TraceOptionClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       :  トレースオプション用カスタムコンバータータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class TraceOptionClassConverter : ExpandableObjectConverter
        {
            /// <summary>型変換(他型へ変換)可能プロパティ</summary>
            /// <value>他型へ変換する際、型毎に変換の可・不可を返す</value>
            /// <remarks></remarks>
            public override bool CanConvertTo(
                ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(TraceOption))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// 変換(他型へ変換)処理
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <param name="destinationType"></param>
            /// <returns>変換結果</returns>
            /// <remarks>
            /// <br>Note       :指定した値オブジェクトを、指定した型に変換する</br>
            /// <br>Programmer  : 96203 鹿野　幸生</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) &&
                    value is TraceOption)
                {
                    string retval;
                    TraceOption to = (TraceOption)value;
                    retval = to.Trace.ToString() + ",";
                    retval = retval + to.TraceLog.ToString() + ",";
                    retval = retval + to.TraceLogPath;
                    return retval;
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

            /// <summary>型変換(他型からの変換)可能プロパティ</summary>
            /// <value>他型から変換する際、型毎に変換の可・不可を返す</value>
            /// <remarks></remarks>
            public override bool CanConvertFrom(
                ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// 変換(他型からの変換)処理
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <returns>変換結果</returns>
            /// <remarks>
            /// <br>Note       :指定した値オブジェクトを、指定した型に変換する</br>
            /// <br>Programmer  : 96203 鹿野　幸生</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    string[] vs = value.ToString().Split(new char[] { ',' }, 3);
                    TraceOption to = new TraceOption();
                    if (vs[0].IndexOf("true",  StringComparison.OrdinalIgnoreCase)  > -1)
                        to.Trace = true;
                    else
                        to.Trace = false;
                    if (vs[1].IndexOf("true", StringComparison.OrdinalIgnoreCase) > -1)
                        to.TraceLog = true;
                    else
                        to.TraceLog = false;
                    to.TraceLogPath = vs[2];
                    return to;
                }
                return base.ConvertFrom(context, culture, value);
            }
        }

        //  
        /// <summary>
        /// TraceOption
        /// </summary>
        /// <remarks>
        /// <br>Note       :  トレースオプションタクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        [TypeConverter(typeof(TraceOptionClassConverter))]
        public class TraceOption
        {

            //  内部保持情報
            private bool mTrace;
            private bool mTraceLog;
            private string mTraceLogPath;

            /// <summary>
            /// TraceOptionクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : TraceOptionクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.15</br>
            /// </remarks>
            public TraceOption()
            {
	            mTrace = false;
	            mTraceLog = false;
	            mTraceLogPath = "";
            }

            /// <summary>Trace可否プロパティ</summary>
            /// <value>Trace可・不可を設定します</value>
            /// <remarks></remarks>
            [Category("Option"), Description("デバッグ用にトレース状況を表示します(ProgressDialogがONになります)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool Trace
            {
                get
                {
                    return (mTrace);
                }
                set
                {
                    mTrace = value;
                }

            }

            /// <summary>Traceログ出力可否プロパティ</summary>
            /// <value>Traceログ出力可・不可を設定します</value>
            /// <remarks></remarks>
            [Category("Option"),Description("デバッグ用にトレースログを出力します(画面表示無し)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool TraceLog
            {
                get
                {
                    return (mTraceLog);
                }
                set
                {
                    mTraceLog = value;
                }

            }

            /// <summary>Traceログパスプロパティ</summary>
            /// <value>Traceログパスを設定します</value>
            /// <remarks></remarks>
            [Category("Option"),Description("トレースログのパスを指定します(設定無しの場合、カレントにTSMTP.LOGで出力されます)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string TraceLogPath
            {
                get
                {
                    return (mTraceLogPath);
                }
                set
                {
                    mTraceLogPath = value;
                }

            }
        }

        /// <summary>
        /// TSMTPクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : TSMTPクラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// </remarks>
        public TSMTP()
        {
            InitializeComponent();

            mProgressDialog = false;
            mDialogConfirm = false;
            mStatus = 0;
            mStatusMessage = "";
            mConnectedStatus = false;
            mBusyStatus = false;
            mTag = null;
            mProgressDialog2 = false;                                           //  2006.11.20  追加

            //  SMTPコンポーネントのインスタンスを作成
            mSmtp = new Dart.PowerTCP.Mail.Smtp();
            //  SMTPコンポーネントのイベントを設定
            mSmtp.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mSmtp_ConnectedChangedEx);
            mSmtp.BusyChanged += new EventHandler(mSmtp_BusyChanged);
            mSmtp.EndSend += new Dart.PowerTCP.Mail.SendEventHandler(mSmtp_EndSend);
            mSmtp.Progress += new Dart.PowerTCP.Mail.SmtpProgressEventHandler(mSmtp_Progress);
            mSmtp.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mSmtp_Trace);

            //  POPコンポーネントのインスタンスを作成
            mPop = new Dart.PowerTCP.Mail.Pop();
            //  POPコンポーネントのイベントを設定
            mPop.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mPop_ConnectedChangedEx);
            mPop.BusyChanged += new EventHandler(mPop_BusyChanged);
            mPop.Progress += new Dart.PowerTCP.Mail.PopProgressEventHandler(mPop_Progress);
            mPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);

            //  Timerコンポーネントのインスタンスを作成
            intTimer = new Timer();
            intTimer.Enabled = false;
            intTimer.Tag = 0;
            //  Timerコンポーネントのイベントを設定
            intTimer.Tick += new EventHandler(intTimer_Tick);
        }

        /// <summary>
        /// TSMTPクラスコンストラクタ(画面貼り付け用)
        /// </summary>
        /// <remarks>
        /// <br>Note       : TSMTPクラスコンストラクタ(画面貼り付け用)</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.15</br>
        /// </remarks>
        public TSMTP(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            mProgressDialog = false;
            mDialogConfirm = false;
            mStatus = 0;
            mStatusMessage = "";
            mConnectedStatus = false;
            mBusyStatus = false;
            mTag = null;
            mProgressDialog2 = false;                                           //  2006.11.20  追加

            //  SMTPコンポーネントのインスタンスを作成
            mSmtp = new Dart.PowerTCP.Mail.Smtp();
            //  SMTPコンポーネントのイベントを設定
            mSmtp.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mSmtp_ConnectedChangedEx);
            mSmtp.BusyChanged += new EventHandler(mSmtp_BusyChanged);
            mSmtp.EndSend += new Dart.PowerTCP.Mail.SendEventHandler(mSmtp_EndSend);
            mSmtp.Progress += new Dart.PowerTCP.Mail.SmtpProgressEventHandler(mSmtp_Progress);
            mSmtp.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mSmtp_Trace);

            //  POPコンポーネントのインスタンスを作成
            mPop = new Dart.PowerTCP.Mail.Pop();
            //  POPコンポーネントのイベントを設定
            mPop.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mPop_ConnectedChangedEx);
            mPop.BusyChanged += new EventHandler(mPop_BusyChanged);
            mPop.Progress += new Dart.PowerTCP.Mail.PopProgressEventHandler(mPop_Progress);
            mPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);

            //  Timerコンポーネントのインスタンスを作成
            intTimer = new Timer();
            intTimer.Enabled = false;
            intTimer.Tag = 0;
            //  Timerコンポーネントのイベントを設定
            intTimer.Tick += new EventHandler(intTimer_Tick);

        }

        /// <summary>
        /// 待ち時間の割り込み処理イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 待ち時間の割り込み処理時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        private void intTimer_Tick(object sender, EventArgs e)
        {

            //  タイマー停止
            intTimer.Enabled = false;

            //  割り込み発生
            intTimer.Tag = 1;

        }


        /// <summary>
        /// POPサーバー・コネクト状況変化時イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : POPコンポーネントによるPOPサーバーコネクト状況変化時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        void mPop_ConnectedChangedEx(object sender, EventArgs e)
        {
            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            if ((mProgressDialog == true) || (mProgressDialog2 == true))
            {
                pWin.AddStatus("POP Before SMTP Connect Status : " + mPop.Connected.ToString(), false);
            }

            EventHandler<SendingEventArgs> h = PopConnectedChangedEx;
            SendingEventArgs args = new SendingEventArgs(mStatus, mStatusMessage);

            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        /// <summary>
        /// POPサーバー・BUSY状況変化時イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : POPコンポーネントによるPOPサーバー・BUSY状況変化時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        void mPop_BusyChanged(object sender, EventArgs e)
        {

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }
            EventHandler<SendingEventArgs> h = PopBusyChanged;
            SendingEventArgs args = new SendingEventArgs(mStatus, mStatusMessage);

            if (null != h)
            {
                h(this, args);
            }
        }

        /// <summary>
        /// POPサーバー・通信時進捗状況イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : POPサーバー・通信時進捗状況変化時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        void mPop_Progress(object sender, Dart.PowerTCP.Mail.PopProgressEventArgs e)
        {
            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            EventHandler<SendingProgressEventArgs> h = PopProgress;
            SendingProgressEventArgs args = new SendingProgressEventArgs(0, 0, (int)e.Position, (int)e.Length);
              
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        /// <summary>
        /// POPサーバー・トレースイベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : POPサーバー・トレース時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        void mPop_Trace(object sender, Dart.PowerTCP.Mail.SegmentEventArgs e)
        {

            //  トレース表示
            if (mSendingTraceOp.Trace == true)
            {
                if (e.Segment != null)
                {
                    pWin.AddStatus("Trace : Segment =>" + e.Segment.ToString().Trim(), mSendingTraceOp.Trace);
                }
            }

            //  トレースログ出力(トレース表示と出力は別物)
            if ((mSendingTraceOp.TraceLog == true) && (e.Segment != null))
            {
                try
                {
                    // イベントデータをバイト配列内に格納します。
                    byte[] buffer = System.Text.Encoding.Default.GetBytes(e.Segment.ToString());
                    // FileStream を作成します。
                    FileStream f = new FileStream(mSendingTraceOp.TraceLogPath, FileMode.Append);
                    // ストリームにデータを書き込みます。
                    f.Write(buffer, 0, buffer.Length);
                    // FileStream を終了します。
                    f.Close();
                }
                catch
                { }
            }

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            EventHandler<SendingEventArgs> h = PopTrace;
            SendingEventArgs args = new SendingEventArgs(mStatus, mStatusMessage);

            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        /// <summary>
        /// SMTPサーバー・コネクト状況変化時イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : SMTPコンポーネントによるSMTPサーバーコネクト状況変化時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_ConnectedChangedEx(object sender, EventArgs e)
        {

            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            if ((mProgressDialog == true) || (mProgressDialog2 == true))
            {
                pWin.AddStatus("Connect Status : " + mSmtp.Connected.ToString(), false);
            }

            EventHandler<SendingEventArgs> h = SmtpConnectedChangedEx;
            SendingEventArgs args = new SendingEventArgs(mStatus, mStatusMessage);

            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        /// <summary>
        /// POPサーバー・BUSY状況変化時イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : SMTPコンポーネントによるSMTPサーバー・BUSY状況変化時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_BusyChanged(object sender, EventArgs e)
        {

            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            EventHandler<SendingEventArgs> h = SmtpBusyChanged;
            SendingEventArgs args = new SendingEventArgs(mStatus, mStatusMessage);

            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }

        }

        /// <summary>
        /// SMTPサーバー・送信終了時イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : SMTPサーバー・送信終了時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_EndSend(object sender, Dart.PowerTCP.Mail.SmtpEventArgs e)
        {

            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            mSmtp_EndSend2(sender, e.Exception, e.State);

        }

        private void mSmtp_EndSend2(object sender, Exception er, object eo)
        {
            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  送信開始以降にエラーが発生していたら、このイベントは通過させない
            //  (エラー発生後も送信イベントが発生するので、これを停める為→非同期の為仕方なし)
            if (mSendingError == true)
            {
                 return;
            }

            if (er == null)
            {
                if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true))
                    {
                    pWin.AddStatus("Send End : Normal", false);
                }
            }
            else
            {
                mStatus = 5;
                mStatusMessage = er.Message;
                if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true))
                {
                    pWin.AddStatus("Send End : Error => " + mStatusMessage, false);
                }
                try
                {
                    mSmtp.Close();
                }
                catch
                { }
            }

            if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible ==true))
            {
                if ((mDialogConfirm == false) && (((SendFigure)eo).NowNo == ((SendFigure)eo).MaxFig) && (mSendingTraceOp.Trace == false))
                {
                    pWin.HideWindow();
                }
                if ((mDialogConfirm == false) && (mStatus != 0) && (mSendingTraceOp.Trace == false))
                {
                    pWin.HideWindow();
                }
            }

            //  送信開始以降、にエラーが発生した場合にtrueにする
            if (mStatus != 0)
            {
                mSendingError = true;
            }
            else                                                                //  2006.11.20  追加
            {
                //  非同期型の場合のみ成功したら送信済み件数をアップ
                if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Asynchronous)
                {
                    mSmtpSendResult.SentFigure++;
                }
            }

            EventHandler<SendEndEventArgs> h = SmtpEndSend;

            SendEndEventArgs args = new SendEndEventArgs(((SendFigure)eo).NowNo, ((SendFigure)eo).MaxFig, mStatus, mStatusMessage);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        /// <summary>
        /// SMTPサーバー・通信時進捗状況イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : SMTPサーバー・通信時進捗状況変化時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_Progress(object sender, Dart.PowerTCP.Mail.ProgressEventArgs e)
        {
            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }


            if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true))
            {
                pWin.SetProgress((int)e.Position, (int)e.Length);
            }

            EventHandler<SendingProgressEventArgs> h = SmtpProgress;
            SendingProgressEventArgs args = new SendingProgressEventArgs(((SendFigure)mGlobalStatus).NowNo, ((SendFigure)mGlobalStatus).MaxFig, (int)e.Position, (int)e.Length);

            if (null != h)
            {
                 Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                 Application.DoEvents();
             }
        }

        /// <summary>
        /// SMTPサーバー・トレースイベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : SMTPサーバー・トレース時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_Trace(object sender, Dart.PowerTCP.Mail.SegmentEventArgs e)
        {
            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  トレース表示
            if (mSendingTraceOp.Trace == true)
            {
                if (e.Segment != null)
                {
                    pWin.AddStatus("Trace : Segment =>" + e.Segment.ToString().Trim(), mSendingTraceOp.Trace);
                }
            }

            //  トレースログ出力(トレース表示と出力は別物)
            if ((mSendingTraceOp.TraceLog == true) && (e.Segment != null))
            {
                try
                {
                    // イベントデータをバイト配列内に格納します。
                    byte[] buffer = System.Text.Encoding.Default.GetBytes(e.Segment.ToString());
                    // FileStream を作成します。
                    FileStream f = new FileStream(mSendingTraceOp.TraceLogPath, FileMode.Append);
                    // ストリームにデータを書き込みます。
                    f.Write(buffer, 0, buffer.Length);
                    // FileStream を終了します。
                    f.Close();
                }
                catch
                {
                }
            }

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            EventHandler<SendingEventArgs> h = SmtpTrace;
            SendingEventArgs args = new SendingEventArgs(mStatus, mStatusMessage);

            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        /// <summary>コネクトステータスプロパティ</summary>
        /// <value>SMTPサーバーへの接続状況が設定されます</value>
        /// <remarks></remarks>
        [Category("Status"), Description("サーバーへの接続状態")]
        [Browsable(false)]
        public bool ConnectedStatus
        {
            get
            {
                return (mConnectedStatus);
            }

        }

        /// <summary>BUSYステータスプロパティ</summary>
        /// <value>SMTPサーバーとの通信状況が設定されます</value>
        /// <remarks></remarks>
        [Category("Status"), Description("コマンド実行中状況")]
        [Browsable(false)]
        public bool BusyStatus
        {
            get
            {
                return (mBusyStatus);
            }

        }

        /// <summary>ステータスコードプロパティ</summary>
        /// <value>ステータスコードが設定されます</value>
        /// <remarks></remarks>
        [Category("Status"), Description("送信結果などのステータスコード")]
        [Browsable(false)]
        public int Status
        {
            get
            {
                return ( mStatus);
            }

        }

        /// <summary>ステータスメッセージプロパティ</summary>
        /// <value>ステータスメッセージが設定されます</value>
        /// <remarks></remarks>
        [Category("Status"), Description("送信結果などのステータスメッセージ")]
        [Browsable(false)]
        public string StatusMessage
        {
            get
            {
                return (mStatusMessage);
            }

        }

        /// <summary>サーバー情報プロパティ</summary>
        /// <value>サーバーの各種情報を設定します</value>
        /// <remarks></remarks>
        [Category("Server"), Description("サーバーの各種情報を設定します")]
        public ServerInfomation ServerInfo
        {
            get
            {
                return (mServerInfo);
            }
            set
            {
                mServerInfo = value;
            }

        }
        /// <summary>メールメッセージ情報プロパティ</summary>
        /// <value>メールメッセージの各種情報を設定します</value>
        /// <remarks></remarks>
        [Browsable(false)]
        public MailMessageStreamCollection MailMessages
        {
            get
            {
                return (mMMessages);
            }
            set
            {
                mMMessages = value;
            }

        }

        /// <summary>承認情報プロパティ</summary>
        /// <value>承認の各種情報を設定します</value>
        /// <remarks></remarks>
        [Category("Authorization"), Description("認証に関する設定をします")]
        public AuthorizationInfomation AuthorizationInfo
        {
            get
            {
                return (mAuthorizationInfo);
            }
            set
            {
                mAuthorizationInfo = value;
            }

        }

        /// <summary>メールオプションプロパティ</summary>
        /// <value>メールの各種オプションを設定します</value>
        /// <remarks></remarks>
        [Category("Option"), Description("メールオプション機能に関する設定をします")]
        public MailOption MailOptions
        {
            get
            {
                return (mMailOp);
            }
            set
            {
                mMailOp = value;
            }

        }

        /// <summary>デバッグオプションプロパティ</summary>
        /// <value>デバッグ用の各種オプションを設定します</value>
        /// <remarks></remarks>
        [Category("Option"), Description("デバッグ用にトレース機能に関する設定します")]
        public TraceOption TraceOptions
        {
            get
            {
                return (mTraceOp);
            }
            set
            {
                mTraceOp = value;
            }

        }

        /// <summary>進捗状況画面表示プロパティ</summary>
        /// <value>進捗状況を子画面表示するかどうかの設定します</value>
        /// <remarks></remarks>
        [Category("Option"), Description("送信状況のダイアログ表示の設定をします")]
        public bool ProgressDialog
        {
            get
            {
                return (mProgressDialog);
            }
            set
            {
                mProgressDialog = value;
            }

        }

        /// <summary>進捗状況画面・自動クローズ設定プロパティ</summary>
        /// <value>進捗状況の子画面を自動クローズするかボタンクローズするかの設定をします</value>
        /// <remarks></remarks>
        [Category("Option"),Description("ボタンでのみダイアログを閉じます")]
        public bool DialogConfirm
        {
            get
            {
                return (mDialogConfirm);
            }
            set
            {
                mDialogConfirm = value;
            }

        }

        /// <summary>コントロールに関するデータを格納するオブジェクトを設定・取得します</summary>
        /// <value>コントロールに関するデータを格納するオブジェクト</value>
        /// <remarks></remarks>
        [Browsable(false)]
        public object Tag
        {
            get
            {
                return (mTag);
            }
            set
            {
                mTag = value;
            }

        }

        /// <summary>送信結果プロパティ(読み取り専用)</summary>
        /// <value>メールの送信結果を取得します</value>
        /// <remarks></remarks>
        [Browsable(false)]
        public SmtpSendResult SmtpSendResultInfo                                //  2006.11.20  追加
        {
            get
            {
                return (mSmtpSendResult);
            }
            internal set
            {
                mSmtpSendResult = value;
            }

        }


        /// <summary>
        /// メール送信処理
        /// </summary>
        /// <returns>送信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー,5:送信パラメータ設定エラー,7:添付ファイルエラー,9:送信エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてメールの送信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage()
        {
            //  統一内部メソッドを呼び出す
            return SendMessages(mMMessages, mProgressDialog, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);
                        
        }

        /// <summary>
        /// メール送信処理
        /// </summary>
        /// <param name="messages">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <returns>送信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー,5:送信パラメータ設定エラー,7:添付ファイルエラー,9:送信エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数・プロパティ設定に基づいてメールの送信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress)
        {
            //  統一内部メソッドを呼び出す
            return SendMessages(messages, ShowProgress, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// メール送信処理
        /// </summary>
        /// <param name="messages">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <returns>送信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー,5:送信パラメータ設定エラー,7:添付ファイルエラー,9:送信エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数・プロパティ設定に基づいてメールの送信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress, ServerInfomation svrinf)
        {
            //  統一内部メソッドを呼び出す
            return SendMessages(messages, ShowProgress, svrinf, mAuthorizationInfo, mMailOp, mTraceOp);
        }

        /// <summary>
        /// メール送信処理
        /// </summary>
        /// <param name="messages">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <returns>送信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー,5:送信パラメータ設定エラー,7:添付ファイルエラー,9:送信エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数・プロパティ設定に基づいてメールの送信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf)
        {
            //  統一内部メソッドを呼び出す
            return SendMessages(messages, ShowProgress, svrinf, authinf, mMailOp, mTraceOp);
        }

        /// <summary>
        /// メール送信処理
        /// </summary>
        /// <param name="messages">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <returns>送信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー,5:送信パラメータ設定エラー,7:添付ファイルエラー,9:送信エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数・プロパティ設定に基づいてメールの送信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp)
        {
            //  統一内部メソッドを呼び出す
            return SendMessages(messages, ShowProgress, svrinf, authinf, mailOp, mTraceOp);
        }

        /// <summary>
        /// メール送信処理
        /// </summary>
        /// <param name="messages">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>送信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー,5:送信パラメータ設定エラー,7:添付ファイルエラー,9:送信エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数設定に基づいてメールの送信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {
            //  統一内部メソッドを呼び出す
            return SendMessages(messages, ShowProgress, svrinf, authinf, mailOp, traceOp);
        }

        /// <summary>
        /// メール送信(内部)処理
        /// </summary>
        /// <param name="messages">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>送信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー,5:送信パラメータ設定エラー,7:添付ファイルエラー,9:送信エラー)</returns>
        /// <remarks>
        /// <br>Note       :メールの送信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        private int SendMessages(MailMessageStreamCollection messages, bool ShowProgress, TSMTP.ServerInfomation svrinf, TSMTP.AuthorizationInfomation authinf, TSMTP.MailOption mailOp, TSMTP.TraceOption traceOp)
        {

            int nRetCd = 0;
            int nStep = 0;

            if (mSmtp.Busy == true)
            {
                mStatus = 1;
                mStatusMessage = "現在、処理中です。操作を実行できません。";
                return 1;
            }

            //  状況表示設定を引き継ぐ
            mProgressDialog2 = ShowProgress;                                    //  2006.11.20  追加

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  変更
            if (mMailOp.SendMethodEnumType != SendMethodEnumTypes.NoEventSynchronous)
            {
                //  ダイアログ表示制御
                if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (traceOp.Trace == true) || (mDialogConfirm == true))
                {
                    if (pWin.Visible == false)
                    {
                        pWin.Show();
                        pWin.SetTitle("送信");
                    }
                    if ((traceOp.Trace == true) || (mDialogConfirm == true))
                    {
                        pWin.SetButtonVisible(true);
                    }
                    else
                    {
                        pWin.SetButtonVisible(false);
                    }
                }

                if (traceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  動作中トレースモードの引継ぎを行う
                mSendingTraceOp = traceOp;
            }
            else
            {
                //  イベント無しならダイアログは強制解除
                mProgressDialog = false;
                mDialogConfirm = false;
                //  動作中トレースモードの引継ぎを行う(イベント無しならトレースログのみ可能とする)
                TraceOption top = new TraceOption();
                top.Trace = false;
                top.TraceLog = traceOp.TraceLog;
                top.TraceLogPath = traceOp.TraceLogPath;
                mSendingTraceOp = top;
            }
            //  トレースがログ出力指定がある場合、ログファイル名を決定しておく。
            if (mSendingTraceOp.TraceLog == true)
            {
                string TraceLogPath;
                if (mSendingTraceOp.TraceLogPath.Trim().Length > 0)
                {
                    TraceLogPath = Path.Combine(Path.GetDirectoryName(mSendingTraceOp.TraceLogPath), Path.GetFileNameWithoutExtension(mSendingTraceOp.TraceLogPath) + System.DateTime.Now.ToString("yyyyMMddHHmm") + Path.GetExtension(mSendingTraceOp.TraceLogPath));
                }
                else
                {
                    TraceLogPath = "tsmtp" + System.DateTime.Now.ToString("yyyyMMddHHmm") + ".log";
                }
                mSendingTraceOp.TraceLogPath = TraceLogPath;

            }

            pWin.AddStatus("Ready Setting for Send", false);

            try
            {
                //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                if (mSendingTraceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  内部SMTPコンポーネントを設定
                mSmtp.Server = svrinf.SMTPServer;
                mSmtp.ServerPort = svrinf.SMTPPort;
                mSmtp.HelloName = mailOp.HelloName;
                mSmtp.Timeout = svrinf.SMTPTimeOut * 1000;

                //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                if (mSendingTraceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }

                //  認証方式に従い、認証情報を設定
                if ((authinf.AuthType == TSMTP.AuthorizationTypes.SMTPAuth) || (authinf.AuthType == TSMTP.AuthorizationTypes.Auto))
                {
                    mSmtp.Username = authinf.SmtpAccount;
                    mSmtp.Password = authinf.SmtpPassWord;
                }
                //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                if (mSendingTraceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  配信状態通知
                if (mailOp.DeliveryStatusNotification == true)
                {
                    // EnvelopeID は、DSN の「Original-Envelope-ID」ヘッダとして返されます
                    mSmtp.DSN.EnvelopeID = mailOp.EnvelopeID;
                    // ヘッダだけでなく、メッセージ全体を返します
                    mSmtp.DSN.ReturnMessage = mailOp.DeliveryStatusNotificationMessage;
                    // 処理の成功、失敗、または遅延時に DSN を送信します（このプロパティは追加型です）。
                    mSmtp.DSN.Type = Dart.PowerTCP.Mail.DSNType.Failure | Dart.PowerTCP.Mail.DSNType.Success | Dart.PowerTCP.Mail.DSNType.Delay;
                }

                //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                if (mSendingTraceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  HelloNameを設定
                mSmtp.HelloName = mailOp.HelloName;

                //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                if (mSendingTraceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  POPサーバーにログイン(認証が必要な場合)
                if ((authinf.AuthType == TSMTP.AuthorizationTypes.Auto) || (authinf.AuthType == TSMTP.AuthorizationTypes.POPBeforeSMTP))
                {
                    pWin.AddStatus("POP Before SMTP Login....", false);
                    try
                    {
                        mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.None;
                        mPop.Timeout = svrinf.POPTimeOut * 1000;
                        mPop.AutoLogout = false;
                        mPop.Login(svrinf.POPServer, authinf.PopAccount, authinf.PopPassWord);
                    }
                    catch (Exception er)
                    {
                        pWin.AddStatus("POP Befofe SMTP : Error => " + er.Message.ToString(), false);
                        mStatus = 1;
                        mStatusMessage = "POP Befofe SMTP : Error " + er.Message;
                        if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                        {
                            if ((mDialogConfirm == false) && (mSendingTraceOp.Trace == false))
                            {
                                pWin.HideWindow();
                            }
                        }
                        mStatusMessage = "POP認証に失敗しました";                 // 2006.11.20  追加
                        return 3;
                    }
                    if (mPop.Connected == true)
                    {
                        try
                        {
                            mPop.Logout();
                            pWin.AddStatus("POP Before SMTP Logout", false);
                        }
                        catch
                        {
                        }
                    }
                }

                //  予め送信件数を取得しておく
                int nowNo = 0;
                int maxFig = 0;
                mSmtpSendResult.SentFigure = 0;                                 //  2006.11.20  追加
                for (int i = 0; i < messages.Count; i++)
                {
                    if (mailOp.DividingSend == true)
                    {
                        maxFig = maxFig + messages[i].To.Length;
                        mSmtpSendResult.TotalFigure = maxFig;                   //  2006.11.20  追加
                    }
                    else
                    {
                        ++maxFig;
                    }
                }
                //  メッセージコレクション分メッセージを送り続ける
                nStep = 0;
                for (int i = 0; i < messages.Count; i++)
                {

                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Loop Step" + (i + 1), mSendingTraceOp.Trace);
                    }

                    //  割り込みタイマーを発生
                    intTimer.Interval = mailOp.ProcTimeOut * 1000;
                    intTimer.Tag = 0;
                    intTimer.Enabled = true;
                    while (mSmtp.Busy == true)
                    {
                        Application.DoEvents();
                        if ((int)intTimer.Tag == 1)
                        {
                            //  待ち時間が経過していたら強制停止
                            throw new Exception("処理時間待ちでタイムアウトが発生しました。");
                        }
                    }
                    intTimer.Enabled = false;

                    Dart.PowerTCP.Mail.MessageStream mailMsg;

                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  送信内容がHTMLで、且つ、パスしての場合、ここでメールストリームに取り込む必要が有る
                    if (messages[i].HtmlPath.Trim().Length > 0)
                    {
                        //  HTMLのパス指定
                        mailMsg = new Dart.PowerTCP.Mail.MessageStream(messages[i].HtmlPath);
                    }
                    else
                    {
                        //  ノーマルパターン
                        mailMsg = new Dart.PowerTCP.Mail.MessageStream();
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  GMTのにローカル差分を＋する
                    if (mailOp.AdjustTimeZone == true)
                    {
                        string sTime = System.DateTime.Now.ToString("r");　　　　            // ローカルの現在時刻を取得
                        string sTimeOffset = System.DateTime.Now.ToString("zzz");           // タイムゾーン　オフセットを取得
                        string sHeaderDate = sTime.Substring(0, sTime.Length - 3) + sTimeOffset.Replace(":", "");   // フォーマット設定
                        mailMsg.Header.Add(Dart.PowerTCP.Mail.HeaderLabelType.Date, sHeaderDate);                   //　メールヘッダにセット
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  メーラー名称設定
                    if (mailOp.SendMailerName == true)
                    {
                        mailMsg.Mailer = ctDefaultMailerName;
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    // 開封確認
                    if (mailOp.DispositionNotification == true)
                    {
                        string SendAddress;
                        if (mailOp.DispositionNotificationAddress.Trim().Length == 0)
                        {
                            SendAddress = messages[i].From;
                        }
                        else
                        {
                            SendAddress = mailOp.DispositionNotificationAddress;
                        }
                        mailMsg.Header.Add("Disposition-Notification-To: " + SendAddress);
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  CC送信先セット
                    for (int j = 0; j < messages[i].Cc.Length; j++)
                    {
                        mailMsg.CC.Add(new Dart.PowerTCP.Mail.MailAddress(messages[i].Cc[j]));
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  BCC送信先セット
                    for (int j = 0; j < messages[i].Bcc.Length; j++)
                    {
                        mailMsg.BCC.Add(new Dart.PowerTCP.Mail.MailAddress(messages[i].Bcc[j]));
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  件名
                    mailMsg.Subject = messages[i].Subject;
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }

                    //  メール内容セット
                    if (messages[i].HtmlPath.Trim().Length > 0)
                    {
                    }
                    else if (messages[i].AlterText.Trim().Length > 0)
                    {
                        //  HTMLメール
                        //  先ずはHTMLを入れる器となるメッセージストリームを作る(multipart/related最初に読み込まれる設定)
                        Dart.PowerTCP.Mail.MessageStream mps1 = new Dart.PowerTCP.Mail.MessageStream();
                        mps1.Type = ContentEnumTypes.MultipartRelated;
                        mps1.MimeBoundary = "----=_NextPart_11_" + System.DateTime.Now.ToString("MMddHHmm" + ":1");
                        mailMsg.Parts.Complex.Add(mps1);
                        //  オルタネートテキストとHTMLを入れる器を作る
                        Dart.PowerTCP.Mail.MessageStream mps2 = new Dart.PowerTCP.Mail.MessageStream();
                        mps2.Type = ContentEnumTypes.MultipartAlternative;
                        mps2.MimeBoundary = "----=_NextPart_12_" + System.DateTime.Now.ToString("MMddHHmm"+":2");
                        mps1.Parts.Complex.Add(mps2);
                        //  オルタネートテキストを入れる器を作る
                        Dart.PowerTCP.Mail.MessagePartStream mps3 = new Dart.PowerTCP.Mail.MessagePartStream();
                        mps3.ContentType = ContentEnumTypes.TextPlain;
                        mps3.Charset = "iso-2022-jp";
                        mps3.Text = messages[i].AlterText;              //  一応いれておく(本当はただのTEXTが良い)
                        mps2.Parts.Add(mps3);
                        //  HTMLを入れる器を作る
                        Dart.PowerTCP.Mail.MessagePartStream mps4 = new Dart.PowerTCP.Mail.MessagePartStream();
                        mps4.Text = messages[i].AlterText;              //  
                        mps4.ContentType = ContentEnumTypes.TextHtml;
                        try
                        {
                            //  HTMLファイルの仕様に合わせてエンコードする
                            if (mps4.Text.IndexOf("charset=iso-2022-jp", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                mps4.Charset = "iso-2022-jp";
                            }
                            else if (mps4.Text.IndexOf("charset=shift_jis", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                mps4.Charset = "shift_jis";
                            }
                            else if (mps4.Text.IndexOf("charset=utf-7", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                mps4.Charset = "utf-7";
                            }
                            else if (mps4.Text.IndexOf("charset=utf-8", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                mps4.Charset = "utf-8";
                            }
                            else if (mps4.Text.IndexOf("charset=utf-16", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                mps4.Charset = "utf-16";
                            }
                            else if (mps4.Text.IndexOf("charset=utf-32", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                mps4.Charset = "utf-32";
                            }
                            else if (mps4.Text.IndexOf("charset=euc-jp", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                mps4.Charset = "euc-jp";
                            }
                            else if (mps4.Text.IndexOf("charset=x-mac-japanese", StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                mps4.Charset = "x-mac-japanese";
                            }
                            else
                            {
                                mps4.Charset = "iso-2022-jp";
                            }
                        }
                        catch
                        {
                            mps4.Charset = "iso-2022-jp";
                        }
                        mps2.Parts.Add(mps4);
                        mailMsg.Type = ContentEnumTypes.MultipartMixed;
                        mailMsg.MimeBoundary ="----=_NextPart_10_" + System.DateTime.Now.ToString("MMddHHmm" + ":0");
                    }
                    else
                    {
                        //  通常テキストメール
                        mailMsg.Text = messages[i].Text;
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  添付ファイルアタッチ(Mime)
                    if ((messages[i].FileName != null) && (messages[i].FileName.Length > 0))
                    {
                        //  ファイルパス指定(簡易タイプ)
                        for (int j = 0; j < messages[i].FileName.Length; j++)
                        {
                            pWin.AddStatus("Biding Attachment File.....", false);
                            if (File.Exists(messages[i].FileName[j]) == false)
                            {
                                mStatus = 1;
                                mStatusMessage = "指定された添付ファイルが存在しません FilePath = " + messages[i].FileName[j];
                                pWin.AddStatus("Biding Attachment File Error => NotFound", false);
                                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                                {
                                    if ((mDialogConfirm == false) && (mSendingTraceOp.Trace == false))
                                    {
                                        pWin.HideWindow();
                                    }
                                }
                                return 7;
                            }
                            mailMsg.Attachments.Add(new Dart.PowerTCP.Mail.MimeAttachmentStream(messages[i].FileName[j]));
                        }
                    }
                    else
                    {
                        //  詳細タイプ
                        for (int j = 0; j < messages[i].AttachFiles.Count; j++)
                        {
                            pWin.AddStatus("Biding Attachment File.....", false);
                            if (messages[i].AttachFiles[j].AttachFileRecvType == AttachFileRecvEnumTypes.File)
                            {
                                if (File.Exists(messages[i].AttachFiles[j].AttachmentFilePath) == false)
                                {
                                    mStatus = 1;
                                    mStatusMessage = "指定された添付ファイルが存在しません FilePath = " + messages[i].AttachFiles[j].AttachmentFilePath;
                                    pWin.AddStatus("Biding Attachment File Error => NotFound", false);
                                    if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                                    {
                                        if ((mDialogConfirm == false) && (mSendingTraceOp.Trace == false))
                                        {
                                            pWin.HideWindow();
                                        }
                                    }
                                    return 7;
                                }
                                mailMsg.Attachments.Add(new Dart.PowerTCP.Mail.MimeAttachmentStream(messages[i].AttachFiles[j].AttachmentFilePath));
                            }
                            else
                            {
                                Dart.PowerTCP.Mail.MimeAttachmentStream mas;
                                if (messages[i].AttachFiles[j].AttachmentFile.GetType() == typeof(MemoryStream))
                                {
                                    mas = new Dart.PowerTCP.Mail.MimeAttachmentStream(((MemoryStream)messages[i].AttachFiles[j].AttachmentFile), messages[i].AttachFiles[j].AttachmentFilePath, Dart.PowerTCP.Mail.ContentType.ApplicationZip, Dart.PowerTCP.Mail.ContentEncoding.Base64, "");
                                }
                                else
                                {
                                    mas = new Dart.PowerTCP.Mail.MimeAttachmentStream((FileStream)messages[i].AttachFiles[j].AttachmentFile);
                                }
                                mas.ContentEncoding = Dart.PowerTCP.Mail.ContentEncoding.Base64;
                                mas.Type = messages[i].AttachFiles[j].ContentType;
                                mailMsg.Attachments.Add(mas);

                            }
                        }
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  メールタイプセット(タイプが設定されて無い場合のみ)
                    if (messages[i].HtmlPath.Trim().Length > 0)
                    {
                    }
                    else if (messages[i].AlterText.Trim().Length > 0)
                    {
                        //  HTMLメール
                        if (mailMsg.Type.ToString().Trim().Length == 0)
                        {
                            if (messages[i].ContentType.Trim().Length > 0)
                            {
                                mailMsg.Type = messages[i].ContentType;
                            }
                            else
                            {
                                mailMsg.Type = ContentEnumTypes.TextHtml;
                            }
                        }
                    }
                    else
                    {
                        //  通常テキストメール
                        if ((mailMsg.Type.ToString().Trim().Length == 0) && (messages[i].ContentType.Trim().Length > 0))
                        {
                            mailMsg.Type = messages[i].ContentType;
                        }
                    }


                    //  ステータスを初期化
                    mGlobalStatus = null;
                    mStatus = 0;
                    mStatusMessage = "";
                    mSendingError = false;                 //  送信開始以降、にエラーが発生した場合にtrueになる

                    //if (traceOp.Trace == true)                                    //  2006.11.20  変更
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  トレース
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  送信先セット
                    //  分割指定があれば、送信先ごとにメッセージを作成して送る
                    //  To指定は、同時に送られた他のアドレスが丸見えになるので不味い(情報漏洩の元になる)
                    if (mailOp.DividingSend == true)
                    {
                        for (int j = 1; j <= messages[i].To.Length; j++)
                        {

                            //  送信開始
                            try
                            {
                                //  割り込みタイマーを発生
                                intTimer.Interval = mailOp.ProcTimeOut * 1000;
                                intTimer.Tag = 0;
                                intTimer.Enabled = true;
                                while (mSmtp.Busy == true)
                                {
                                    Application.DoEvents();
                                    if ((int)intTimer.Tag == 1)
                                    {
                                        //  待ち時間が経過していたら強制停止
                                        throw new Exception("処理時間待ちでタイムアウトが発生しました。");
                                    }
                                }
                                intTimer.Enabled = false;

                                Dart.PowerTCP.Mail.MessageStream lMM = mailMsg.Clone();
                                //  送信先をセット
                                lMM.To.Add(new Dart.PowerTCP.Mail.MailAddress(messages[i].To[j - 1]));
                                //  送信元をセット
                                lMM.From = new Dart.PowerTCP.Mail.MailAddress(messages[i].From);

                                if (mStatus != 0)
                                {
                                    mStatus = 9;                                        //  2006.11.20  追加
                                    break;
                                }
                                //  送信
                                pWin.SetLabelProgress(nowNo + 1, maxFig);
                                pWin.SetProgress((int)0, (int)0);
                                mSendFigure.NowNo = ++nowNo;
                                mSendFigure.MaxFig = maxFig;
                                mSmtpSendResult.TotalFigure = mSendFigure.MaxFig;       //  2006.11.20  追加
                                mGlobalStatus = mSendFigure;
                                //mSmtp.BeginSend(lMM, mGlobalStatus);                  //  2006.11.20  追加
                                //  設定により、同期・非同期を分ける
                                if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Asynchronous)
                                {
                                    //  非同期型
                                    mSmtp.BeginSend(lMM, mGlobalStatus);
                                }
                                else
                                {
                                    //  同期型
                                    Dart.PowerTCP.Mail.SmtpResult sdRetCd = mSmtp.Send(lMM);
                                    if (sdRetCd.Recipients.Count > 0)
                                    {
                                        if (sdRetCd.Recipients[0].ServerResponse.Code == 250)
                                        {
                                            mStatus = 0;
                                            mStatusMessage = "";
                                            mSmtpSendResult.SentFigure++;                   //  2006.11.20  追加
                                        }
                                        else
                                        {
                                            mStatus = sdRetCd.Recipients[0].ServerResponse.Code;
                                            mStatusMessage = sdRetCd.Recipients[0].ServerResponse.Text;
                                        }
                                    }
                                    else
                                    {
                                        mStatus = 9;
                                        mStatusMessage = "Send Error";
                                    }
                                    //  同期型(イベント有り)ならSmtpSendEndイベントを発生
                                    if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Synchronous)
                                    {
                                        mSmtp_EndSend2(mSmtp, null, mSendFigure);
                                    }
                                    //  エラーなら中止
                                    if (mStatus != 0)
                                    {
                                        mStatus = 9;                                        //  2006.11.20  追加
                                        break;
                                    }
                                }
                                pWin.AddStatus("Send Start", false);
                                pWin.AddStatus("Sending Mail " + nowNo.ToString() + " Times.....", false);

                            }
                            catch (Exception er)
                            {
                                pWin.AddStatus("Send Start : Error => " + er.Message, false);
                                mStatus = 1;
                                mStatusMessage = er.Message;
                                nRetCd = 9;
                                //  同期型(イベント有り)ならSmtpSendEndイベントを発生          //  2006.11.20  追加
                                if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Synchronous)
                                {
                                    mSmtp_EndSend2(mSmtp, er, mSendFigure);
                                }
                                break;
                            }
                        }

                    }
                    else
                    {
                        //  送信先をセット
                        for (int j = 0; j < messages[i].To.Length; j++)
                        {
                            mailMsg.To.Add(new Dart.PowerTCP.Mail.MailAddress(messages[i].To[j]));
                        }
                        //  送信元をセット
                        mailMsg.From = new Dart.PowerTCP.Mail.MailAddress(messages[i].From);

                        //  送信開始
                        try
                        {
                            //  割り込みタイマーを発生
                            intTimer.Interval = mailOp.ProcTimeOut * 1000;
                            intTimer.Tag = 0;
                            intTimer.Enabled = true;
                            while (mSmtp.Busy == true)
                            {
                                Application.DoEvents();
                                if ((int)intTimer.Tag == 1)
                                {
                                    //  待ち時間が経過していたら強制停止
                                    throw new Exception("処理時間待ちでタイムアウトが発生しました。");
                                }
                            }
                            intTimer.Enabled = false;
                            if (mStatus != 0)
                            {
                                mStatus = 9;                                            //  2006.11.20  追加
                                break;
                            }
                            //  送信
                            pWin.SetLabelProgress(nowNo + 1, maxFig);
                            mSendFigure.NowNo = ++nowNo;
                            mSendFigure.MaxFig = maxFig;
                            mSmtpSendResult.TotalFigure = mSendFigure.MaxFig;           //  2006.11.20  追加
                            mGlobalStatus = mSendFigure;
                            //mSmtp.BeginSend(mailMsg, mGlobalStatus);                  //  2006.11.20  追加
                            //  設定により、同期・非同期を分ける
                            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Asynchronous)
                            {
                                //  非同期型
                                mSmtp.BeginSend(mailMsg, mGlobalStatus);
                            }
                            else
                            {
                                //  同期型
                                Dart.PowerTCP.Mail.SmtpResult sdRetCd = mSmtp.Send(mailMsg);
                                if (sdRetCd.Recipients.Count > 0)
                                {
                                    if (sdRetCd.Recipients[0].ServerResponse.Code == 250)
                                    {
                                        mStatus = 0;
                                        mStatusMessage = "";
                                        mSmtpSendResult.SentFigure++;                   //  2006.11.20  追加
                                    }
                                    else
                                    {
                                        mStatus = sdRetCd.Recipients[0].ServerResponse.Code;
                                        mStatusMessage = sdRetCd.Recipients[0].ServerResponse.Text;
                                    }
                                }
                                else
                                {
                                    mStatus = 9;
                                    mStatusMessage = "Send Error";
                                }
                                //  同期型(イベント有り)ならSmtpSendEndイベントを発生
                                if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Synchronous)
                                {
                                    mSmtp_EndSend2(mSmtp, null, mSendFigure);
                                }
                                //  エラーなら中止                                   
                                if (mStatus != 0)
                                {
                                    mStatus = 9;                                        
                                    break;
                                }
                            }
                            pWin.AddStatus("Send Start", false);
                            pWin.AddStatus("Sending Mail.....", false);
                        }
                        catch (Exception er)
                        {
                            pWin.AddStatus("Send Start : Error => " + er.Message, false);
                            mStatus = 1;
                            mStatusMessage = er.Message;
                            nRetCd = 9;
                            //  同期型(イベント有り)ならSmtpSendEndイベントを発生          //  2006.11.20  追加
                            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Synchronous)
                            {
                                mSmtp_EndSend2(mSmtp, er, mSendFigure);
                            }
                            break;                                                      //  2006.11.20  追加
                        }
                    }
                }
            }
            catch (Exception er)
            {
                pWin.AddStatus("Send Start : Error => " + er.Message, false);
                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                {
                    if ((mDialogConfirm == false) && (mSendingTraceOp.Trace == false))
                    {
                        pWin.HideWindow();
                    }
                }
                mStatus = 1;
                mStatusMessage = er.Message;
                nRetCd = 5;
            }


            return nRetCd;
        }

        /// <summary>
        ///  サーバー切断処理
        /// </summary>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       : サーバーとの接続を終了します。通信中でも切断が可能です。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public void Close()
        {
            mSmtp.Close();
        }

        /// <summary>
        /// SMTPサーバー接続チェック処理
        /// </summary>
        /// <returns>SMTPサーバー接続チェック結果(0:成功,1:成功(SMTP AUTH付き),3:POP認証エラー,5:接続エラー,7:応答エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてSMTPサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection()
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(mProgressDialog, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// SMTPサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <returns>SMTPサーバー接続チェック結果(0:成功,1:成功(SMTP AUTH付き),3:POP認証エラー,5:接続エラー,7:応答エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてSMTPサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// SMTPサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <returns>SMTPサーバー接続チェック結果(0:成功,1:成功(SMTP AUTH付き),3:POP認証エラー,5:接続エラー,7:応答エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてSMTPサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, svrinf, mAuthorizationInfo, mMailOp, mTraceOp);
        }

        /// <summary>
        /// SMTPサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <returns>SMTPサーバー接続チェック結果(0:成功,1:成功(SMTP AUTH付き),3:POP認証エラー,5:接続エラー,7:応答エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてSMTPサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, svrinf, authinf, mMailOp, mTraceOp);
        }

        /// <summary>
        /// SMTPサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <returns>SMTPサーバー接続チェック結果(0:成功,1:成功(SMTP AUTH付き),3:POP認証エラー,5:接続エラー,7:応答エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてSMTPサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, svrinf, authinf, mailOp, mTraceOp);
        }

        /// <summary>
        /// SMTPサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>SMTPサーバー接続チェック結果(0:成功,1:成功(SMTP AUTH付き),3:POP認証エラー,5:接続エラー,7:応答エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてSMTPサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, svrinf, authinf, mailOp, traceOp);
        }

        /// <summary>
        /// SMTPサーバー接続チェック(内部)処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>SMTPサーバー接続チェック結果(0:成功,1:成功(SMTP AUTH付き),3:POP認証エラー,5:接続エラー,7:応答エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてSMTPサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        private int CheckServerConnections(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {

            string[] HelloCommnd = { "EHLO", "HELLO" };

            int nRetCd = 0;

            //  SMTPインスタンス作成
            Dart.PowerTCP.Mail.Segment seg;
            Dart.PowerTCP.Mail.Tcp lTcp = new Dart.PowerTCP.Mail.Tcp();
            lTcp.DoEvents = true;
            lTcp.NoDelay = true;
            lTcp.ReceiveTimeout = svrinf.POPTimeOut * 1000;
            lTcp.SendTimeout = svrinf.SMTPTimeOut * 1000;
            lTcp.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mSmtp_Trace);

            //  POPインスタンス作成
            Dart.PowerTCP.Mail.Pop lPop = new Dart.PowerTCP.Mail.Pop();
            lPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);


            try
            {
                mStatus = 0;
                mStatusMessage = "";

                //  状況表示設定を引き継ぐ
                mProgressDialog2 = ShowProgress;

                //  イベント無しの場合、トレース無し・ダイアログ無し
                if (mailOp.SendMethodEnumType != SendMethodEnumTypes.NoEventSynchronous)
                {
                    //  ダイアログ表示制御
                    if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (traceOp.Trace == true) || (mDialogConfirm == true))
                    {
                        if (pWin.Visible == false)
                        {
                            pWin.Show();
                            pWin.SetTitle("接続テスト");
                            pWin.AddStatus("Connect Check Start........", false);
                        }
                        if ((traceOp.Trace == true) || (mDialogConfirm == true))
                        {
                            pWin.SetButtonVisible(true);
                        }
                        else
                        {
                            pWin.SetButtonVisible(false);
                        }
                    }
                    //  動作中トレースモードの引継ぎを行う
                    mSendingTraceOp = traceOp;
                }
                else
                {
                    //  イベント無しならダイアログは強制解除
                    mProgressDialog = false;
                    mDialogConfirm = false;
                    //  動作中トレースモードの引継ぎを行う(イベント無しならトレースログのみ可能とする)
                    TraceOption top = new TraceOption();
                    top.Trace = false;
                    top.TraceLog = traceOp.TraceLog;
                    top.TraceLogPath = traceOp.TraceLogPath;
                    mSendingTraceOp = top;
                }

                //  トレースがログ出力指定がある場合、ログファイル名を決定しておく。
                if (mSendingTraceOp.TraceLog == true)
                {
                    string TraceLogPath;
                    if (mSendingTraceOp.TraceLogPath.Trim().Length > 0)
                    {
                        TraceLogPath = Path.Combine(Path.GetDirectoryName(mSendingTraceOp.TraceLogPath), Path.GetFileNameWithoutExtension(mSendingTraceOp.TraceLogPath) + System.DateTime.Now.ToString("yyyyMMddHHmm") + Path.GetExtension(mSendingTraceOp.TraceLogPath));
                    }
                    else
                    {
                        TraceLogPath = "tsmtp" + System.DateTime.Now.ToString("yyyyMMddHHmm") + ".log";
                    }
                    mSendingTraceOp.TraceLogPath = TraceLogPath;

                }

                //  POPサーバーにログイン(認証が必要な場合)
                if ((authinf.AuthType == TSMTP.AuthorizationTypes.Auto) || (authinf.AuthType == TSMTP.AuthorizationTypes.POPBeforeSMTP))
                {
                    pWin.AddStatus("POP Server Login....", true);
                    try
                    {
                        lPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.None;
                        lPop.Timeout = svrinf.POPTimeOut * 1000;
                        lPop.AutoLogout = false;
                        lPop.Login(svrinf.POPServer, authinf.PopAccount, authinf.PopPassWord);
                    }
                    catch (Exception er)
                    {
                        pWin.AddStatus("POP Server Login NG " + er.Message.ToString(), false);
                        mStatus = 1;
                        mStatusMessage = "POP Server Login NG " + er.Message;
                        if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                        {
                            if ((mDialogConfirm == false) && (mSendingTraceOp.Trace == false))
                            {
                                pWin.HideWindow();
                            }
                        }
                        mStatus = 1;
                        mStatusMessage = "POP認証に失敗しました";
                        return 3;
                    }
                    if (lPop.Connected == true)
                    {
                        try
                        {
                            lPop.Logout();
                            pWin.AddStatus("POP Server Logout", false);
                        }
                        catch
                        {
                        }
                    }
                    pWin.AddStatus("POP Server Login Check OK", false);
                }

                // SMTPポートへの接続を試みます。
                pWin.SetProgress(1, 4);
                try
                {
                    //  トレース
                    pWin.AddStatus("Connect Sart......", mSendingTraceOp.Trace);
                    lTcp.Connect(svrinf.SMTPServer, svrinf.SMTPPort, "", 0);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    //  トレース
                    pWin.AddStatus("Connect Start NG", false);
                    mStatus = 2;
                    mStatusMessage = ex.Message;
                    return 5;
                }

                if (lTcp.Connected == false)
                {
                    pWin.AddStatus("Connect Start NG", false);
                    mStatus = 3;
                    mStatusMessage = "接続できませんでした";
                    return 5;
                }

                //  CONNECT結果受信
                pWin.SetProgress(2, 4);
                try
                {
                    // データを受信します。このオーバーロードは単純に、すべての有効データを受信します。
                    seg = lTcp.Receive();
                }
                catch (Exception ex)
                {
                    //  トレース
                    pWin.AddStatus("Connect Reply NG", false);
                    mStatus = 4;
                    mStatusMessage = ex.Message;
                    return 5;
                }
                if (seg.ToString().IndexOf("220 ") == -1)
                {
                    //  トレース
                    pWin.AddStatus("Connect Reply NG", false);
                    mStatus = 5;
                    mStatusMessage = "接続できませんでした " + seg.ToString();
                    return 5;
                }
                pWin.AddStatus("Connect Reply OK", false);

                //  EHLO or HELLO送信(EHLO → HELLOの順に試行)
                pWin.AddStatus("Hello Sart .....", false);
                for (int i = 0; i < 2; i++)
                {
                    try
                    {
                        //  トレース
                        pWin.AddStatus("Hello Sart By " + HelloCommnd[i], false);
                        seg = lTcp.Send(HelloCommnd[i] + " " + mailOp.HelloName + "\n");
                    }
                    catch (Exception ex)
                    {
                        pWin.AddStatus("Hello Sart NG", false);
                        mStatus = 6;
                        mStatusMessage = ex.Message;
                        return 7;
                    }

                    // 結果受信
                    pWin.SetProgress(3, 4);
                    pWin.AddStatus("Hello Reply OK", false);
                    while (true)
                    {
                        try
                        {
                            // データを受信
                            seg = lTcp.Receive();
                            //  結果が複数行の場合、行単位で分解して表示
                            string[] sHeloRep = seg.ToString().Split('\n');
                            if (seg.ToString().IndexOf("250") == -1)
                            {
                                if (i == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    //  トレース
                                    pWin.AddStatus("Hello Reply NG", false);
                                    mStatus = 7;
                                    mStatusMessage = "接続できませんでした " + seg.ToString();
                                    return 7;
                                }
                            }
                            //  SMTP AUTHチェック
                            if (seg.ToString().IndexOf("AUTH") > -1)
                            {
                                //  SMTP AUTH有り
                                nRetCd = 1;
                                mStatusMessage = "指定サーバーは SMTP AUTH 対応です";
                                pWin.AddStatus("Server Support SMTP ATUTH!", false);
                            }
                            foreach (string s in sHeloRep)
                            {
                                if (s.Trim().Length != 0)
                                {
                                    pWin.AddStatus("Server Reply => " + s.Trim(), false);
                                }
                            }

                            if (seg.ToString().IndexOf("250 ") > -1)
                            {
                                break;
                            }

                        }
                        catch (Exception ex)
                        {
                            //  トレース
                            pWin.AddStatus("Hello Reply NG", false);
                            mStatus = 8;
                            mStatusMessage = ex.Message;
                            return 7;
                        }
                    }
                    if (seg.ToString().IndexOf("250 ") > -1)
                    {
                        break;
                    }
                }

                pWin.SetProgress(4, 4);
                pWin.AddStatus("Connect Check OK", false);

                //  終了
                return nRetCd;
            }
            finally
            {
                //  インスタンス解放
                if (lPop != null)
                {
                    lPop.Logout();
                    lPop.Dispose();
                }
                if (lTcp != null)
                {
                    lTcp.Close();
                    lTcp.Dispose();
                }

                //  ダイアログの後始末
                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mSendingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                {
                    if ((mDialogConfirm == false) && (mSendingTraceOp.Trace == false))
                    {
                        pWin.HideWindow();
                    }
                }


            }

        }

    }
}

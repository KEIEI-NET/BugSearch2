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
    /// TPOP(メール受信)クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : SuperFrontman専用メール受信コンポーネントクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/21 金沢 貞義</br>
    /// <br>             「Mail for .net 3.1.0.1」への対応</br>																						
    /// </remarks>
    public partial class TPOP : Component
    {
        //  コンポーネント・イベント
        /// <summary>TPOPコンポーネントサーバー接続状況変化イベント</summary>
        public event EventHandler<ReceivingEventArgs> PopConnectedChangedEx;
        /// <summary>TPOPコンポーネントBUSY状況変化イベント</summary>
        public event EventHandler<ReceivingEventArgs> PopBusyChanged;
        /// <summary>TPOPコンポーネント受信進捗イベント</summary>
        public event EventHandler<ReceivingProgressEventArgs> PopProgress;
        /// <summary>TPOPコンポーネントトレースイベント</summary>
        public event EventHandler<ReceivingEventArgs> PopTrace;
        /// <summary>TPOPコンポーネントサーバーログインイベント</summary>
        public event EventHandler<ReceivingLoginEventArgs> PopEndLogin;
        /// <summary>TPOPコンポーネントサーバーログアウトイベント</summary>
        public event EventHandler<ReceivingEventArgs> PopEndLogout;
        /// <summary>TPOPコンポーネント受信イベント</summary>
        public event EventHandler<ReceivingGetEndEventArgs> PopEndGetMessege;

        //  基のSMTP、POP3コンポーネント
        private Dart.PowerTCP.Mail.Pop mPop;

        //  待ち時間作成用のタイマーコンポ
        private Timer intTimer;

        //  進捗状況表示画面
        private ProgressWindow pWin = new ProgressWindow();

        //  各種メール受信に必要なプロパティの実体
        private ServerInfomation mServerInfo = new ServerInfomation();
        private AuthorizationInfomation mAuthorizationInfo = new AuthorizationInfomation();
        private MailOption mMailOp = new MailOption();
        private TraceOption mTraceOp = new TraceOption();
        private MailMessageStreamCollection mMMessages = new MailMessageStreamCollection();
        private object mTag = new object();
        private PopReceiveResult mPopReceiveResult = new PopReceiveResult();    //  2006.11.20  追加

        //  進捗状況表示画面の設定プロパティの実体
        //private bool mProgressDialog;                                         //  2006.11.20  変更
        //private bool mDialogConfirm;                                          //        V
        internal static bool mProgressDialog;                                   //        V
        internal static bool mDialogConfirm;                                    //  2006.11.20  変更

        //  ステータスプロパティの実体
        private object mGlobalStatus;
        private int mStatus;
        private string mStatusMessage;

        //  接続状況遷移中ステータスプロパティの実体
        private bool mConnectedStatus;
        private bool mBusyStatus;           //  POPコンポーネントのBUSY
        private bool mBusyStatus2;          //  内部処理用のBUSY

        //  現在取得中のメール情報
        private int mPahase;                //  取得工程(0:Login,1:GetMessage)
        private int mNowMessageIdx;         //  取得した最新のメッセージインデックス(解析後処理内部の配列用)
        private int mNowProgressIdx;        //  現在取得中のメッセージインデックス(プログレス処理内部の配列用)
        private int mNowMessageID;          //  現在取得中のメッセージのID(サーバー付与ID)
        private int mMaxGetMessageFig;      //  現在取得対象の最大メッセージ数
        private int mMaxExtMessageFig;      //  現在取得中の最大メッセージのID(サーバーに存在する数)

        //  内部動作専用クラス(元々のプロパティには設定されないケースがあるので)
        private TraceOption mReceivingTraceOp = new TraceOption();
        private MailOption mReceivingMailOp = new MailOption();
        private bool mReceivingProgressDialog;
        private bool mProgressDialog2;                                          //  2006.11.20  追加

        //  イベントハンドラー部

        /// <summary>
        /// ReceivingGetEndEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受信終了イベントパラメータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class ReceivingGetEndEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;
            private int _maxfig;
            private int _nownum;

            /// <summary>ステータスコードプロパティ</summary>
            /// <value>受信ステータス</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>ステータスメッセージプロパティ</summary>
            /// <value>受信ステータスメッセージ</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>受信対象メッセージ数プロパティ</summary>
            /// <value>受信対象のメッセージ数</value>
            /// <remarks></remarks>
            public int MaxMessageFig
            {
                get { return _maxfig; }
            }

            /// <summary>現在メッセージ番号プロパティ</summary>
            /// <value>受信対象メッセージ数の内の取得したメッセージ番号</value>
            /// <remarks></remarks>
            public int NowMessageNo
            {
                get { return _nownum; }
            }

            /// <summary>
            /// ReceivingGetEndEventArgsコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : 受信終了イベントパラメータクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public ReceivingGetEndEventArgs(int NowMessageNo, int MaxMessageFig, int Status, string StatusMessage)
                : base()
            {
                _nownum = NowMessageNo;
                _maxfig = MaxMessageFig;
                _status = Status;
                _statusmsg = StatusMessage;
            }
        }

        /// <summary>
        /// ReceivingLoginEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログイン終了イベントパラメータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class ReceivingLoginEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;
            private int _messagefig;

            /// <summary>ステータスコードプロパティ</summary>
            /// <value>ログインステータス</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>ステータスメッセージプロパティ</summary>
            /// <value>ログインステータスメッセージ</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>サーバーメッセージ数プロパティ</summary>
            /// <value>サーバーに保存されているメッセージ数</value>
            /// <remarks></remarks>
            public int MessageFig
            {
                get { return _messagefig; }
            }

            /// <summary>
            /// ReceivingEventArgsコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : 受信中ステータスイベントパラメータクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public ReceivingLoginEventArgs(int Status, string StatusMessage, int MessageFig)
                : base()
            {
                _status = Status;
                _statusmsg = StatusMessage;
                _messagefig = MessageFig;
            }
        }

        /// <summary>
        /// ReceivingEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受信中ステータスイベントパラメータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class ReceivingEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;

            /// <summary>ステータスコードプロパティ</summary>
            /// <value>受信中ステータス</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>ステータスメッセージプロパティ</summary>
            /// <value>受信中ステータスメッセージ</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>
            /// ReceivingEventArgsコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : 受信中ステータスイベントパラメータクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public ReceivingEventArgs(int Status, string StatusMessage)
                : base()
            {
                _status = Status;
                _statusmsg = StatusMessage;
            }
        }

        /// <summary>
        /// ReceivingProgressEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受信中進捗状況イベントパラメータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class ReceivingProgressEventArgs : EventArgs
        {

            private int _nowpos;
            private int _maxpos;
            private int _maxfig;
            private int _nownum;

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

            /// <summary>受信対象メッセージ数プロパティ</summary>
            /// <value>受信対象のメッセージ数</value>
            /// <remarks></remarks>
            public int MaxMessageFig
            {
                get { return _maxfig; }
            }

            /// <summary>現在メッセージ番号プロパティ</summary>
            /// <value>受信対象メッセージ数の内の取得したメッセージ番号</value>
            /// <remarks></remarks>
            public int NowMessageNo
            {
                get { return _nownum; }
            }

            /// <summary>
            /// ReceivingProgressEventArgsコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : 受信中進捗状況イベントパラメータクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public ReceivingProgressEventArgs(int NowMessageNo, int MaxMessageFig, int NowPos, int MaxPos)
                : base()
            {
                _nownum = NowMessageNo;
                _maxfig = MaxMessageFig;
                _nowpos = NowPos;
                _maxpos = MaxPos;
            }
        }

        /// <summary>POP接続方式列挙体</summary>
        public enum ReceiveEnumTypes
        {
            /// <summary>ログインのみ</summary>
            LogingOnly,
            /// <summary>受信</summary>
            Receive
        }

        /// <summary>メール受信形式列挙体</summary>
        public enum MailReceiveEnumTypes
        {
            /// <summary>メッセージの自動取得無し</summary>
            None,
            /// <summary>メールヘッダのみ取得</summary>
            Header,
            /// <summary>メール完全取得</summary>
            Complete
        }

        /// <summary>メール受信フィルター列挙体</summary>
        public enum MailFilterModes
        {
            /// <summary>メッセージフィルターのモード：指定なし</summary>
            None,
            /// <summary>メッセージフィルターのモード：送信元指定</summary>
            FromAddress,
            /// <summary>メッセージフィルターのモード：件名指定</summary>
            Subject
        }


        /// <summary>
        /// MailOptionClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       : メールオプション用カスタムコンバータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
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
            /// <br>Date        : 2006.07.19</br>
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
                        retval = mp.AttachFileRecvTypes.ToString() + ",";
                        retval = retval + mp.AutoDelete.ToString() + ",";
                        retval = retval + mp.FilterMode + ",";
                        retval = retval + mp.FilterString + ",";
                        retval = retval + mp.GetAttachmentFile.ToString() + ",";
                        retval = retval + mp.MailReceiveType + ",";
                        retval = retval + mp.ProcTimeOut.ToString() + ",";
                        retval = retval + mp.ReceivedDirectory + ",";
                        //retval = retval + mp.ReceiveType;                                     //  2006.11.20  変更
                        retval = retval + mp.ReceiveType + ",";
                        retval = retval + mp.ReceiveMethodEnumType.ToString();                  //  2006.11.20  追加
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
            /// <br>Date        : 2006.07.19</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    try
                    {
                        //string[] vs = value.ToString().Split((new char[] { ',' }), 9);                //  2006.11.20  変更
                        string[] vs = value.ToString().Split((new char[] { ',' }), 10);
                        MailOption mp = new MailOption();
                        if (vs[0].IndexOf("File", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.AttachFileRecvTypes = AttachFileRecvEnumTypes.Stream;
                        else
                            mp.AttachFileRecvTypes = AttachFileRecvEnumTypes.Stream;
                        if (vs[1].IndexOf("true", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.AutoDelete = true;
                        else
                            mp.AutoDelete = false;
                        if (vs[2].IndexOf("FromAddress", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.FilterMode = MailFilterModes.FromAddress;
                        else if (vs[2].IndexOf("Subject", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.FilterMode = MailFilterModes.Subject;
                        else
                            mp.FilterMode = MailFilterModes.None;
                        mp.FilterString = vs[3];
                        if (vs[4].IndexOf("true", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.GetAttachmentFile = true;
                        else
                            mp.GetAttachmentFile = false;
                        if (vs[5].IndexOf("None", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.MailReceiveType = MailReceiveEnumTypes.None;
                        else if (vs[5].IndexOf("Header", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.MailReceiveType = MailReceiveEnumTypes.Header;
                        else
                            mp.MailReceiveType = MailReceiveEnumTypes.Complete;
                        mp.ProcTimeOut = System.Convert.ToInt32(vs[6]);
                        mp.ReceivedDirectory = vs[7];
                        if (vs[8].IndexOf("LoginOnly", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.ReceiveType = ReceiveEnumTypes.LogingOnly;
                        else
                            mp.ReceiveType = ReceiveEnumTypes.Receive;
                        if (vs[10].IndexOf("Asynchronous", StringComparison.OrdinalIgnoreCase) > -1)        //  2006.11.20  追加
                            mp.ReceiveMethodEnumType = ReceiveMethodEnumTypes.Asynchronous;
                        else if (vs[10].IndexOf("Synchronous", StringComparison.OrdinalIgnoreCase) > -1)
                            mp.ReceiveMethodEnumType = ReceiveMethodEnumTypes.Synchronous;
                        else
                            mp.ReceiveMethodEnumType = ReceiveMethodEnumTypes.NoEventSynchronous;
                        return mp;
                    }
                    catch (Exception er)
                    {
                        throw new ArgumentException("Can not convert '" + (string)value + "' to type MailOptions " + er.Message);
                    }
                }
                return base.ConvertFrom(context, culture, value);
            }
        }

        /// <summary>
        /// MailOptionClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       : メールオプションクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 2006.11.20 鹿野　幸生</br>
        /// </remarks>
        [TypeConverter(typeof(MailOptionClassConverter))]
        public class MailOption
        {

            //  メールのオプションプロパティの内部保持用
            private string mReceivedDirectory;
            private bool mAutoDelete;
            private MailReceiveEnumTypes mMailReceiveType;
            private bool mGetAttachmentFile;
            private AttachFileRecvEnumTypes mAttachFileRecvTypes;
            private MailFilterModes mFilterMode;
            private string mFilterString;
            private int mProcTimeOut;
            private ReceiveEnumTypes mReceiveType;
            private ReceiveMethodEnumTypes mReceiveMethodEnumType;              //  2006.11.20 追加

            /// <summary>
            /// MailOptionクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : MailOptionクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public MailOption()
            {
                mReceivedDirectory = "";
                mAutoDelete = false;
                mMailReceiveType = MailReceiveEnumTypes.Complete;
                mReceiveType = ReceiveEnumTypes.Receive;
                mGetAttachmentFile = true;
                mAttachFileRecvTypes = AttachFileRecvEnumTypes.File;
                FilterMode =  MailFilterModes.None;
                FilterString = "";
                mProcTimeOut = 60;
            }

            /// <summary>メールの受信ディレクトリ設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("メールの受信ディレクトリ")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string ReceivedDirectory
            {
                get
                {
                    return (mReceivedDirectory);
                }
                set
                {
                    mReceivedDirectory = value;
                }

            }

            /// <summary>AutoDelete設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("POPサーバーからメールを受信した際に、そのメールをサーバーから削除するかどうかを設定します(初期値:false)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool AutoDelete
            {
                get
                {
                    return (mAutoDelete);
                }
                set
                {
                    mAutoDelete = value;
                }
            }

            /// <summary>MailReceiveType設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("POPサーバー接続時のログイン・受信をどう制御するのかを設定します(初期値:Receive)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public ReceiveEnumTypes ReceiveType
            {
                get
                {
                    return (mReceiveType);
                }
                set
                {
                    mReceiveType = value;
                }
            }

            /// <summary>MailReceiveType設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("POPサーバーログイン時にメール受信をどう制御するのかを設定します(初期値:Compelete)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public MailReceiveEnumTypes MailReceiveType
            {
                get
                {
                    return (mMailReceiveType);
                }
                set
                {
                    mMailReceiveType = value;
                }
            }

            /// <summary>フィルター受信モード設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("フィルター受信のモードを設定します(初期値:None)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public MailFilterModes FilterMode
            {
                get
                {
                    return (mFilterMode);
                }
                set
                {
                    mFilterMode = value;
                }
            }

            /// <summary>フィルター文字列設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("フィルター受信する際の文字列を設定します")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string FilterString
            {
                get
                {
                    return (mFilterString);
                }
                set
                {
                    mFilterString = value;
                }
            }

            /// <summary>添付ファイル受信設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("添付ファイルを受信するかどうか設定します(初期値:True)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public bool GetAttachmentFile
            {
                get
                {
                    return (mGetAttachmentFile);
                }
                set
                {
                    mGetAttachmentFile = value;
                }
            }

            /// <summary>添付ファイル受信タイプ設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("添付ファイルをファイルStreamどちらで受信するか設定します(初期値:File)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public AttachFileRecvEnumTypes AttachFileRecvTypes
            {
                get
                {
                    return (mAttachFileRecvTypes);
                }
                set
                {
                    mAttachFileRecvTypes = value;
                }
            }

            /// <summary>処理待ちタイムアウト時間設定プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("メールや添付ファイル解析など内部処理の待ち時間を秒単位で設定します(初期値:60秒)")]
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
            public ReceiveMethodEnumTypes ReceiveMethodEnumType                 //  2006.11.20  追加
            {
                get
                {
                    return (mReceiveMethodEnumType);
                }
                set
                {
                    //  イベント無しならダイアログは強制解除
                    if (mReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
                    {
                        mProgressDialog = false;
                        mDialogConfirm = false;
                    }
                    mReceiveMethodEnumType = value;
                }
            }
        }

        /// <summary>
        /// AuthorizationInfomationClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       :  承認情報用カスタムコンバータータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
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
            /// <br>Date        : 2006.07.19</br>
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
                        retval = ai.Account + ",";
                        retval = retval + ai.AuthType.ToString() + ",";
                        retval = retval + ai.PassWord;
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
            /// <br>Date        : 2006.07.19</br>
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
                        ai.Account = vs[0];
                        if (vs[1].IndexOf("None", StringComparison.OrdinalIgnoreCase) > -1)
                            ai.AuthType = AuthorizationTypes.None;
                        else if (vs[1].IndexOf("APOP", StringComparison.OrdinalIgnoreCase) > -1)
                            ai.AuthType = AuthorizationTypes.APOP;
                        else if (vs[1].IndexOf("POP3", StringComparison.OrdinalIgnoreCase) > -1)
                            ai.AuthType = AuthorizationTypes.POP3;
                        else
                            ai.AuthType = AuthorizationTypes.Auto;
                        ai.PassWord = vs[2];
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

        /// <summary>認証方式列挙型</summary>
        /// <remarks>認証方式を表す列挙型です</remarks>
        [TypeConverter(typeof(EnumConverter))]
        public enum AuthorizationTypes
        {
            /// <summary>無し</summary>
            None,
            /// <summary>APOP型</summary>
            APOP,
            /// <summary>POP3(通常方式)型</summary>
            POP3,
            /// <summary>自動トライ型</summary>
            Auto
        }

        /// <summary>
        /// AuthorizationInfomation
        /// </summary>
        /// <remarks>
        /// <br>Note       :  承認情報クラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 2006.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        [TypeConverter(typeof(AuthorizationInfomationClassConverter))]
        public class AuthorizationInfomation
        {
            //  承認情報内部保持用
            private string mAccount;
            private string mPassWord;
            private AuthorizationTypes mAuthType;

            /// <summary>
            /// AuthorizationInfomationクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : AuthorizationInfomationクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public AuthorizationInfomation()
            {
                mAccount = "";
                mPassWord = "";
                mAuthType = AuthorizationTypes.Auto;
            }

            /// <summary>認証用アカウント名プロパティ</summary>
            /// <value>認証に使用するアカウント名・ユーザー名を設定します</value>
            /// <remarks></remarks>
            [Description("認証用のアカウントを設定します(認証方法共通設定)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string Account
            {
                get
                {
                    return (mAccount);
                }
                set
                {
                    mAccount = value;
                }
            }

            /// <summary>認証用パスワードプロパティ</summary>
            /// <value>認証に使用するパスワードを設定します</value>
            /// <remarks></remarks>
            [Description("認証用のパスワードを設定します(認証方法共通設定)")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string PassWord
            {
                get
                {
                    return (mPassWord);
                }
                set
                {
                    mPassWord = value;
                }

            }

            /// <summary>認証形式設定プロパティ</summary>
            /// <value>認証形式を設定します</value>
            /// <remarks></remarks>
            [Description("認証方法を設定します(初期値:Auto)")]
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
        /// <br>Date       : 2006.07.19</br>
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
            /// <br>Date        : 2006.07.19</br>
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
                        retval = retval + si.POPTimeOut.ToString();
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
            /// <br>Date        : 2006.07.19</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    try
                    {
                        string[] vs = value.ToString().Split(new char[] { ',' }, 3);
                        ServerInfomation si = new ServerInfomation();
                        si.POPPort = System.Convert.ToInt32(vs[0]);
                        si.POPServer = vs[1];
                        si.POPTimeOut = System.Convert.ToInt32(vs[2]);
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
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        [TypeConverter(typeof(ServerInfomationClassConverter))]
        public class ServerInfomation
        {
            private string mPOPServer;
            private int mPOPPort;
            private int mPOPTimeOut;

            /// <summary>
            /// ServerInfomationクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : ServerInfomationクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public ServerInfomation()
            {
                mPOPServer = "";
                mPOPPort = 110;
                mPOPTimeOut = 60;
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
        /// MiniMailMessage
        /// </summary>
        /// <remarks>
        /// <br>Note       :  メールメッセージクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        private class MiniMailMessage
        {
            //  内部情報保持用
            public string Subject;
            public string AlterText;
            public string Text;
            public string From;
            public string HtmlPath;
            public string[] To;
            public string[] Cc;
            public string[] Bcc;
            public string ContentType;
            public string ContentID;
            public string Date;
            public string FileName;
            public string CharaSet;
            public AttachmentCollection AttachFiles;
            public LinkPartsCollection LinkParts;

            public MiniMailMessage()
            {
                Subject = "";
                AlterText = "";
                Text = "";
                From = "";
                HtmlPath = "";
                To = null;
                Cc = null;
                Bcc = null;
                ContentType = "";
                ContentID = "";
                Date = "";
                FileName = "";
                CharaSet = "";
                AttachFiles = new AttachmentCollection();
                LinkParts = new LinkPartsCollection();
            }

        }

        /// <summary>
        /// TraceOptionClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       :  トレースオプション用カスタムコンバータータクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
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
            /// <br>Date        : 2006.07.19</br>
            /// </remarks>
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) &&
                    value is TraceOption)
                {
                    string retval;
                    TraceOption to = (TraceOption)value;
                    retval = to.Trace.ToString() + "|";
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
            /// <br>Date        : 2006.07.19</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    string[] vs = value.ToString().Split(new char[] { ',' }, 3);
                    TraceOption to = new TraceOption();
                    if (vs[0] == "true")
                        to.Trace = true;
                    else
                        to.Trace = false;
                    if (vs[1] == "true")
                        to.TraceLog = true;
                    else
                        to.TraceLog = false;
                    to.TraceLogPath = vs[2];
                    return to;
                }
                return base.ConvertFrom(context, culture, value);
            }
        }

        /// <summary>
        /// TraceOption
        /// </summary>
        /// <remarks>
        /// <br>Note       :  トレースオプションタクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
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
            /// <br>Date       : 2006.07.19</br>
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
            [Category("Option"), Description("デバッグ用にトレースログを出力します(画面表示無し)")]
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
            [Category("Option"), Description("トレースログのパスを指定します(設定無しの場合、カレントにTPOP.LOGで出力されます)")]
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
        /// TPOPクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : TPOPクラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public TPOP()
        {
            InitializeComponent();

            mProgressDialog = false;
            mDialogConfirm = false;
            mStatus = 0;
            mStatusMessage = "";
            mConnectedStatus = false;
            mBusyStatus = false;
            mBusyStatus2 = false;
            mNowMessageIdx = 0;
            mNowProgressIdx = 0;
            mNowMessageID = 0;
            mMaxGetMessageFig = 0;
            mMaxExtMessageFig = 0;
            mPahase = 0;
            mTag = null;

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
        /// PopReceiveResult
        /// </summary>
        /// <remarks>
        /// <br>Note       : PopReceiveResultクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.11.20</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
        /// </remarks>
        public class PopReceiveResult
        {

            private int mTotalFigure;
            private int mReceiveFigure;

            /// <summary>
            /// PopReceiveResultクラスコンストラクタ
            /// </summary>
            /// <remarks>
            /// <br>Note       : PopReceiveResultクラスコンストラクタ</br>
            /// <br>Programmer : 96203 鹿野　幸生</br>
            /// <br>Date       : 2006.11.20</br>
            /// </remarks>
            public PopReceiveResult()
            {
                mTotalFigure = 0;
                mReceiveFigure = 0;
            }


            /// <summary>受信対象件数プロパティ</summary>
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

            /// <summary>受信済件数プロパティ</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Browsable(false)]
            public int ReceivetFigure
            {
                get
                {
                    return (mReceiveFigure);
                }
                internal set
                {
                    mReceiveFigure = value;
                }
            }
        }

        /// <summary>
        /// TPOPクラスコンストラクタ(画面貼り付け用)
        /// </summary>
        /// <remarks>
        /// <br>Note       : TPOPクラスコンストラクタ(画面貼り付け用)</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public TPOP(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            mProgressDialog = false;
            mDialogConfirm = false;
            mStatus = 0;
            mStatusMessage = "";
            mConnectedStatus = false;
            mBusyStatus = false;
            mBusyStatus2 = false;
            mNowMessageIdx = 0;
            mNowProgressIdx = 0;
            mNowMessageID = 0;
            mMaxGetMessageFig = 0;
            mMaxExtMessageFig = 0;
            mPahase = 0;
            mTag = null;

            //  POPコンポーネントのインスタンスを作成
            mPop = new Dart.PowerTCP.Mail.Pop();
            //  POPコンポーネントのイベントを設定
            mPop.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mPop_ConnectedChangedEx);
            mPop.BusyChanged += new EventHandler(mPop_BusyChanged);
            mPop.Progress += new Dart.PowerTCP.Mail.PopProgressEventHandler(mPop_Progress);
            mPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);
            mPop.EndGet += new Dart.PowerTCP.Mail.PopEventHandler(mPop_EndGet);
            mPop.EndLogin += new Dart.PowerTCP.Mail.ExceptionEventHandler(mPop_EndLogin);
            mPop.EndLogout += new Dart.PowerTCP.Mail.ExceptionEventHandler(mPop_EndLogout);

            //  Timerコンポーネントのインスタンスを作成
            intTimer = new Timer();
            intTimer.Enabled = false;
            intTimer.Tag = 0;
            //  Timerコンポーネントのイベントを設定
            intTimer.Tick += new EventHandler(intTimer_Tick);

        }

        /// <summary>
        /// TPOPクラスデストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : TPOPクラスデストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        ~TPOP() 
        {
            try
            {
                mPop.Dispose();
            }
            catch
            { }
        }

        /// <summary>
        /// 待ち時間の割り込み処理イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : 待ち時間の割り込み処理時に発生します</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void intTimer_Tick(object sender, EventArgs e)
        {

            //  タイマー停止
            intTimer.Enabled = false;

            //  割り込み発生通知
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
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_ConnectedChangedEx(object sender, EventArgs e)
        {

            //  ステータスセット
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  ダイアログ表示有りなら情報通知
            pWin.AddStatus("POP Before SMTP Connect Status : " + mPop.Connected.ToString(), false);

            //  イベントキック
            EventHandler<ReceivingEventArgs> h = PopConnectedChangedEx;
            ReceivingEventArgs args = new ReceivingEventArgs(mStatus, mStatusMessage);
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
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_BusyChanged(object sender, EventArgs e)
        {

            //  ステータスセット
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  イベントキック
            EventHandler<ReceivingEventArgs> h = PopBusyChanged;
            ReceivingEventArgs args = new ReceivingEventArgs(mStatus, mStatusMessage);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
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
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_Progress(object sender, Dart.PowerTCP.Mail.PopProgressEventArgs e)
        {

            //  ステータスセット
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  ログイン時はプログレス表示しない(ログイン時でも件数分別々にプログレスが発生するケースが有る為)
            if (mPahase == 0)
            {
                return;
            }

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  プログレス表示有りなら通知
            if ((mReceivingProgressDialog == true) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true))
            {
                pWin.SetProgress((int)e.Position, (int)e.Length);
            }

            //  現在工程によって、対象変数を分ける
            int NowNo, MaxFig;
            if (mPahase == 0)
            {
                //  ログイン時なら、POPサーバーと同じ
                NowNo = System.Convert.ToInt32(e.PopMessage.Id);
                MaxFig = mPop.Messages.Length;
            }
            else
            {
                //  取得時なら取得対象のみ(フィルターを考慮)
                NowNo = mNowProgressIdx;
                MaxFig = mMaxGetMessageFig;
            }

            //  イベントキック
            EventHandler<ReceivingProgressEventArgs> h = PopProgress;
            ReceivingProgressEventArgs args = new ReceivingProgressEventArgs(NowNo, MaxFig, (int)e.Position, (int)e.Length);
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
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_Trace(object sender, Dart.PowerTCP.Mail.SegmentEventArgs e)
        {

            //  ステータスセット
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  トレース表示
            if (mReceivingTraceOp.Trace == true)
            {
                if (e.Segment != null)
                {
                    pWin.AddStatus("Trace : Segment =>" + e.Segment.ToString().Trim(), mReceivingTraceOp.Trace);
                }
            }

            //  トレースログ出力(トレース表示と出力は別物)
            if ((mReceivingTraceOp.TraceLog == true) && (e.Segment != null))
            {
                mBusyStatus2 = true;                //  処理中に設定
                try
                {
                    // イベントデータをバイト配列内に格納します。
                    byte[] buffer = System.Text.Encoding.Default.GetBytes(e.Segment.ToString());
                    // FileStream を作成します。
                    using (FileStream f = new FileStream(mReceivingTraceOp.TraceLogPath, FileMode.Append))
                    {
                        // ストリームにデータを書き込みます。
                        f.Write(buffer, 0, buffer.Length);
                        // FileStream を終了します。
                        f.Close();
                    }
                }
                catch
                { }
                mBusyStatus2 = false;                //  処理終了に設定
            }

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  イベントキック
            EventHandler<ReceivingEventArgs> h = PopTrace;
            ReceivingEventArgs args = new ReceivingEventArgs(mStatus, mStatusMessage);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        /// <summary>
        /// メール取得イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : メール取得時に発生します(設定次第で一件でも前件でも発生する)</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_EndGet(object sender, Dart.PowerTCP.Mail.PopEventArgs e)
        {

            //  ステータスセット
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  取得出来たら解析(一件毎の解析)
            if (e.Exception == null)
            {
                try
                {
                    //  割り込みタイマーを発生
                    intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                    intTimer.Tag = 0;
                    intTimer.Enabled = true;
                    while (mBusyStatus2 == true)
                    {
                        Application.DoEvents();
                        if ((int)intTimer.Tag == 1)
                        {
                            //  待ち時間が経過していたら強制停止
                            throw new Exception("処理時間待ちでタイムアウトが発生しました。");
                        }

                    }
                    intTimer.Enabled = false;
                    mBusyStatus2 = true;                                        //  処理中に設定
                    //  解析
                    mStatus = AnalyzeMessage(e.PopMessage);
                    mNowMessageID = System.Convert.ToInt32(e.PopMessage.Id);    //  現在取得中のメッセージのID(サーバー付与ID)
                    pWin.AddStatus("Receive Analyzing ID = " + mNowMessageIdx.ToString(), false);
                    mBusyStatus2 = false;                                       //  処理終了に設定
                }
                catch(Exception er)
                {
                    mStatus = 5;
                    mStatusMessage = er.Message;
                }
            }
            else
            {
                mStatus = 5;
                mStatusMessage = e.Exception.Message;
            }

            //  メッセージがMAXだったら、終了扱い
            if (mNowMessageIdx >= mMaxGetMessageFig)
            {
                pWin.AddStatus("Receive End : All Messages", false);
                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                {
                    if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
                    {
                        pWin.HideWindow();
                    }
                }
            }
            else
            {
                pWin.AddStatus("Receive End ID = " + e.PopMessage.Id, false);
            }

            //  イベントキック
            EventHandler<ReceivingGetEndEventArgs> h = PopEndGetMessege;
            ReceivingGetEndEventArgs args = new ReceivingGetEndEventArgs(mNowMessageIdx, mMaxGetMessageFig, mStatus, mStatusMessage);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }

            if (mStatus != 0)
            {
                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                {
                    if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
                    {
                        pWin.HideWindow();
                    }
                }
            }
        }

        /// <summary>
        /// ログイン終了イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ログイン終了時に発生します(成功でも失敗でも発生する)</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_EndLogin(object sender, Dart.PowerTCP.Mail.ExceptionEventArgs e)
        {

            //  ステータスセット
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  ログイン出来たら件数によりメッセージなど変更
            if (e.Exception == null)
            {
                pWin.AddStatus("POP Login OK", false);

                if (mPop.Messages.Length == 0)
                {
                    //  メール無し
                    mStatus = 1;
                    mStatusMessage = "未読メールは有りません";
                    pWin.AddStatus("No Message", false);
                    pWin.AddStatus("Receive End", false);
                }
                else
                {
                    //  メール有り
                    pWin.AddStatus(mPop.Messages.Length.ToString() + " Messages on Server", false);
                    pWin.AddStatus("Receive Sart", false);
                }
            }
            else
            {
                //  ログインエラー
                pWin.AddStatus("POP Login : Error => " + e.Exception.Message, false);
                mStatus = 3;
                mStatusMessage = e.Exception.Message;
                try
                {
                    if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                    {
                        if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
                        {
                            pWin.HideWindow();
                        }
                    }
                    //  ログアウトを試みる
                    mPop.Logout();
                }
                catch
                { }
            }
            
            //  件数表示制御用の変数を初期化
            mNowMessageIdx = 0;                             //  現在取得中のメッセージインデックス(処理内部の配列用)
            mNowMessageID = 0;                              //  現在取得中のメッセージのID(サーバー付与ID)
            mMaxGetMessageFig = 0;                          //  現在取得対象の最大メッセージ数
            mMaxExtMessageFig = mPop.Messages.Length;       //  現在取得中の最大メッセージのID(サーバーに存在する数)

            //  イベントキック
            EventHandler<ReceivingLoginEventArgs> h = PopEndLogin;
            ReceivingLoginEventArgs args = new ReceivingLoginEventArgs(mStatus, mStatusMessage, mMaxExtMessageFig);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }

            //  エラー無しの時のみログイン後の取得処理を行う
            if (e.Exception == null) 
            {
                if ((mReceivingMailOp.ReceiveType == ReceiveEnumTypes.LogingOnly) || (mReceivingMailOp.MailReceiveType == MailReceiveEnumTypes.None))
                {
                    //  ログインのみ、或いは受信無しの場合、ここで終了
                    pWin.AddStatus("POP Login OK", false);
                }
                else if (mPop.Messages.Length != 0)
                {
                    //  コンプリート指定で、且つメール有りならメッセージ取得開始
                    pWin.AddStatus("POP Get Message", false);
                    GetMessage();
                }
                else
                {
                    //  メッセージ無し(上部で設定済み)
                }
            }

        }

        /// <summary>
        /// ログアウト終了イベント
        /// </summary>
        /// <param name="sender">イベント発生コントロール</param>
        /// <param name="e">イベントデータ</param>
        /// <remarks>
        /// <br>Note　　　  : ログアウト終了時に発生します(成功でも失敗でも発生する)</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_EndLogout(object sender, Dart.PowerTCP.Mail.ExceptionEventArgs e)
        {
            //  ステータスセット
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  追加
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }


            //  ログアウト状況表示
            if (e.Exception == null)
            {
                //  成功
                pWin.AddStatus("POP Logout OK", false);
            }
            else
            {
                //  失敗
                pWin.AddStatus("POP Logout Error => " + e.Exception.Message, false);
                mStatus = 9;
                mStatusMessage = e.Exception.Message;
                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                {
                    if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
                    {
                        pWin.HideWindow();
                    }
                }
            }

            //  イベントキック
            EventHandler<ReceivingEventArgs> h = PopEndLogout;
            ReceivingEventArgs args = new ReceivingEventArgs(mStatus, mStatusMessage);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        //  プロパティ部
        
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
        /// <value>POPサーバーとの通信状況が設定されます</value>
        /// <remarks></remarks>
        [Category("Status"), Description("コマンド実行中状況")]
        [Browsable(false)]
        public bool BusyStatus
        {
            get
            {
                return (mBusyStatus | mBusyStatus2);
            }

        }

        /// <summary>ステータスコードプロパティ</summary>
        /// <value>ステータスコードが設定されます</value>
        /// <remarks></remarks>
        [Category("Status"), Description("受信結果などのステータスコード")]
        [Browsable(false)]
        public int Status
        {
            get
            {
                return (mStatus);
            }

        }

        /// <summary>ステータスメッセージプロパティ</summary>
        /// <value>ステータスメッセージが設定されます</value>
        /// <remarks></remarks>
        [Category("Status"), Description("受信結果などのステータスメッセージ")]
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
        [Category("Option"), Description("受信状況のダイアログ表示の設定をします")]
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
        [Category("Option"), Description("ボタンでのみダイアログを閉じます")]
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

        /// <summary>受信結果プロパティ(読み取り専用)</summary>
        /// <value>メールの受信結果を取得します</value>
        /// <remarks></remarks>
        [Browsable(false)]
        public PopReceiveResult PopReceiveResultInfo                                //  2006.11.20  追加
        {
            get
            {
                return (mPopReceiveResult);
            }
            internal set
            {
                mPopReceiveResult = value;
            }

        }

        /// <summary>
        /// メール受信処理
        /// </summary>
        /// <returns>受信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてメールの受信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage()
        {
            //  統一内部メソッドを呼び出す
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.Asynchronous)
            {
                return ReceiveMessages(mMMessages, mProgressDialog, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);
            }
            else
            {
                return ReceiveMessages2(mMMessages, mProgressDialog, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);
            }

        }

        /// <summary>
        /// メール受信処理
        /// </summary>
        /// <param name="message">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <returns>受信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数・プロパティ設定に基づいてメールの受信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress)
        {
            //  統一内部メソッドを呼び出す                                        //  2006.11.20  変更
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.Asynchronous)
            {
                return ReceiveMessages(message, ShowProgress, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);
            }
            else
            {
                return ReceiveMessages2(message, ShowProgress, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);
            }

        }

        /// <summary>
        /// メール受信処理
        /// </summary>
        /// <param name="message">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <returns>受信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数・プロパティ設定に基づいてメールの受信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress, ServerInfomation svrinf)
        {
            //  統一内部メソッドを呼び出す                                        //  2006.11.20  変更
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.Asynchronous)
            {
                return ReceiveMessages(message, ShowProgress, svrinf, mAuthorizationInfo, mMailOp, mTraceOp);
            }
            else
            {
                return ReceiveMessages2(message, ShowProgress, svrinf, mAuthorizationInfo, mMailOp, mTraceOp);
            }
        }

        /// <summary>
        /// メール受信処理
        /// </summary>
        /// <param name="message">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <returns>受信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数・プロパティ設定に基づいてメールの受信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf)
        {
            //  統一内部メソッドを呼び出す                                        //  2006.11.20  変更
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.Asynchronous)
            {
                return ReceiveMessages(message, ShowProgress, svrinf, authinf, mMailOp, mTraceOp);
            }
            else
            {
                return ReceiveMessages2(message, ShowProgress, svrinf, authinf, mMailOp, mTraceOp);
            }
        }

        /// <summary>
        /// メール受信処理
        /// </summary>
        /// <param name="message">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <returns>受信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数・プロパティ設定に基づいてメールの受信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp)
        {
            //  統一内部メソッドを呼び出す                                        //  2006.11.20  変更
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.Asynchronous)
            {
                return ReceiveMessages(message, ShowProgress, svrinf, authinf, mailOp, mTraceOp);
            }
            else
            {
                return ReceiveMessages2(message, ShowProgress, svrinf, authinf, mailOp, mTraceOp);
            }
        }

        /// <summary>
        /// メール受信処理
        /// </summary>
        /// <param name="message">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>受信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー)</returns>
        /// <remarks>
        /// <br>Note       :引数設定に基づいてメールの受信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {
            //  統一内部メソッドを呼び出す                                        //  2006.11.20  変更
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.Asynchronous)
            {
                return ReceiveMessages(message, ShowProgress, svrinf, authinf, mailOp, traceOp);
            }
            else
            {
                return ReceiveMessages2(message, ShowProgress, svrinf, authinf, mailOp, traceOp);
            }
        }

        /// <summary>
        /// メール非同期受信(内部)処理
        /// </summary>
        /// <param name="message">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>受信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー)</returns>
        /// <remarks>
        /// <br>Note       :メールの受信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int ReceiveMessages(MailMessageStreamCollection message, bool ShowProgress, TPOP.ServerInfomation svrinf, TPOP.AuthorizationInfomation authinf, TPOP.MailOption mailOp, TPOP.TraceOption traceOp)
        {

            int nRetCd = 0;
            int nStep = 0;

            //   既に処理中なら受信不可
            if (mPop.Busy == true)
            {
                mStatus = 1;
                mStatusMessage = "現在、処理中です。操作を実行できません。";
                return 1;
            }

            //  状況表示設定を引き継ぐ
            mProgressDialog2 = ShowProgress;                                    //  2006.11.20  追加

            //  ダイアログ表示制御
            if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (traceOp.Trace == true) || (mDialogConfirm == true))
            {
                if (pWin.Visible == false)
                {
                    pWin.Show();
                    pWin.SetTitle("受信");
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
                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
            }

            //  動作中メールオプションなどの引継ぎを行う
            mReceivingMailOp = mailOp;
            mReceivingProgressDialog = ShowProgress;

            //  動作中トレースモードの引継ぎを行う
            mReceivingTraceOp = traceOp;
            //  トレースがログ出力指定がある場合、ログファイル名を決定しておく。
            if (mReceivingTraceOp.TraceLog == true)
            {
                string TraceLogPath;
                if (mReceivingTraceOp.TraceLogPath.Trim().Length > 0)
                {
                    TraceLogPath = Path.Combine(Path.GetDirectoryName(mReceivingTraceOp.TraceLogPath), Path.GetFileNameWithoutExtension(mReceivingTraceOp.TraceLogPath) + System.DateTime.Now.ToString("yyyyMMddHHmm") + Path.GetExtension(mReceivingTraceOp.TraceLogPath));
                }
                else
                {
                    TraceLogPath = "tpop" + System.DateTime.Now.ToString("yyyyMMddHHmm") + ".log";
                }
                mReceivingTraceOp.TraceLogPath = TraceLogPath;

            }

            pWin.AddStatus("Ready Setting for Recept", false);

            if (traceOp.Trace == true)
            {
                //  トレース
                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
            }


            //  ステータスを初期化
            mGlobalStatus = null;
            mStatus = 0;
            mStatusMessage = "";
            mMMessages.Clear();

            //  タイムアウトを設定
            mPop.Timeout = svrinf.POPTimeOut * 1000;

            // 取得メッセージ数に関する変数をリセット
            mPahase = 0;                //  現在工程 (0:Login,1:GetMessage)
            mNowMessageIdx = 0;         //  現在取得中のメッセージインデックス(処理内部の配列用)
            mNowProgressIdx = 0;        //  
            mNowMessageID = 0;          //  現在取得中のメッセージのID(サーバー付与ID)
            mMaxGetMessageFig = 0;      //  現在取得対象の最大メッセージ数
            mMaxExtMessageFig = 0;      //  現在取得中の最大メッセージのID(サーバーに存在する数)

            mBusyStatus2 = true;            //  処理中に設定

            if (traceOp.Trace == true)
            {
                //  トレース
                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
            }


            //  POPサーバーにログイン(認証が必要な場合)
            try
            {
                //  この時点でビジーなら待つ
                //  割り込みタイマーを発生
                intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                intTimer.Tag = 0;
                intTimer.Enabled = true;
                while (mPop.Busy == true)
                {
                    Application.DoEvents();
                    if ((int)intTimer.Tag == 1)
                    {
                        //  待ち時間が経過していたら強制停止
                        throw new Exception("処理時間待ちでタイムアウトが発生しました。");
                    }
                }
                intTimer.Enabled = false;
                if (traceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
                }

                //  接続済みなら、一旦解除する
                if (mPop.Connected == true)
                {
                    mPop.Logout();
                }
                if (traceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
                }

                //  フィルター受信モードに従い、受信方法を設定
                if (mailOp.FilterMode == MailFilterModes.None)
                {
                    //  メール受信タイプに従い細工をする
                    if (mailOp.MailReceiveType == MailReceiveEnumTypes.None)
                    {
                        mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.None;
                    }
                    else if (mailOp.MailReceiveType == MailReceiveEnumTypes.Complete)
                    {
                        mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.None;
                    }
                    else
                    {
                        mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.Header;
                    }
                }
                else
                {
                    mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.Header;
                }
                if (traceOp.Trace == true)
                {
                    //  トレース
                    pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
                }
                //  接続＆初期情報取得
                mPop.AutoLogout = false;
                mPop.AutoDelete = false;
                // --- DEL 2010/06/21 -------------------------------->>>>>
                //mPop.BeginLogin(svrinf.POPServer, svrinf.POPPort, "", svrinf.POPPort, authinf.Account, authinf.PassWord, mGlobalStatus);
                // --- DEL 2010/06/21 --------------------------------<<<<<
                // --- ADD 2010/06/21 -------------------------------->>>>>
                mPop.BeginLogin(svrinf.POPServer, svrinf.POPPort, "", svrinf.POPPort, authinf.Account, authinf.PassWord, Dart.PowerTCP.Mail.PopLoginMethod.Clear, mGlobalStatus);
                // --- ADD 2010/06/21 --------------------------------<<<<<
                pWin.AddStatus("POP Login........", false);
            }
            catch (Exception er)
            {
                //  エラー
                pWin.AddStatus("POP Login : Error => " + er.Message.ToString(), false);
                mStatus = 1;
                mStatusMessage = er.Message;
                nRetCd = 3;
                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                {
                    if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
                    {
                        pWin.HideWindow();
                    }
                }
            }

            mBusyStatus2 = false;            //  処理中に設定
            return nRetCd;
        }

        /// <summary>
        /// メール同期受信(内部)処理
        /// </summary>
        /// <param name="message">メールメッセージコレクション</param>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>受信処理キック時結果(送信結果では無い-0:成功,1:BUSY,3:認証エラー)</returns>
        /// <remarks>
        /// <br>Note       :メールの受信を行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        private int ReceiveMessages2(MailMessageStreamCollection message, bool ShowProgress, TPOP.ServerInfomation svrinf, TPOP.AuthorizationInfomation authinf, TPOP.MailOption mailOp, TPOP.TraceOption traceOp)
        {

            int nRetCd = 0;
            int nStep = 0;

            //   既に処理中なら受信不可
            if (mPop.Busy == true)
            {
                mStatus = 1;
                mStatusMessage = "現在、処理中です。操作を実行できません。";
                return 1;
            }

            //  状況表示設定を引き継ぐ
            mProgressDialog2 = ShowProgress;                                    //  2006.11.20  追加

            //  イベント無しの場合、トレース無し・ダイアログ無し                   //  2006.11.20  変更
            if (mMailOp.ReceiveMethodEnumType != ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                //  ダイアログ表示制御
                if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (traceOp.Trace == true) || (mDialogConfirm == true))
                {
                    if (pWin.Visible == false)
                    {
                        pWin.Show();
                        pWin.SetTitle("受信");
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
                    pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
                }
                mReceivingProgressDialog = ShowProgress;
                //  動作中トレースモードの引継ぎを行う
                mReceivingTraceOp = traceOp;
            }
            else
            {
                mReceivingProgressDialog = false;
                //  イベント無しならダイアログは強制解除
                mDialogConfirm = false;
                //  動作中トレースモードの引継ぎを行う(イベント無しならトレースログのみ可能とする)
                TraceOption top = new TraceOption();
                top.Trace = false;
                top.TraceLog = traceOp.TraceLog;
                top.TraceLogPath = traceOp.TraceLogPath;
                mReceivingTraceOp = top;
            }

            //  動作中メールオプションなどの引継ぎを行う
            mReceivingMailOp = mailOp;

            //  トレースがログ出力指定がある場合、ログファイル名を決定しておく。
            if (mReceivingTraceOp.TraceLog == true)
            {
                string TraceLogPath;
                if (mReceivingTraceOp.TraceLogPath.Trim().Length > 0)
                {
                    TraceLogPath = Path.Combine(Path.GetDirectoryName(mReceivingTraceOp.TraceLogPath), Path.GetFileNameWithoutExtension(mReceivingTraceOp.TraceLogPath) + System.DateTime.Now.ToString("yyyyMMddHHmm") + Path.GetExtension(mReceivingTraceOp.TraceLogPath));
                }
                else
                {
                    TraceLogPath = "tpop" + System.DateTime.Now.ToString("yyyyMMddHHmm") + ".log";
                }
                mReceivingTraceOp.TraceLogPath = TraceLogPath;

            }

            pWin.AddStatus("Ready Setting for Recept", false);

            pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);

            //  ステータスを初期化
            mGlobalStatus = null;
            mStatus = 0;
            mStatusMessage = "";
            mMMessages.Clear();

            //  タイムアウトを設定
            mPop.Timeout = svrinf.POPTimeOut * 1000;

            // 取得メッセージ数に関する変数をリセット
            mPahase = 0;                //  現在工程 (0:Login,1:GetMessage)
            mNowMessageIdx = 0;         //  現在取得中のメッセージインデックス(処理内部の配列用)
            mNowProgressIdx = 0;        //  
            mNowMessageID = 0;          //  現在取得中のメッセージのID(サーバー付与ID)
            mMaxGetMessageFig = 0;      //  現在取得対象の最大メッセージ数
            mMaxExtMessageFig = 0;      //  現在取得中の最大メッセージのID(サーバーに存在する数)

            //  受信件数をリセット                                               //  2006.11.20  追加
            mPopReceiveResult.ReceivetFigure = 0;                               
            mPopReceiveResult.TotalFigure = 0;

            mBusyStatus2 = true;            //  処理中に設定

            //  トレース
            pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);


            //  POPサーバーにログイン(認証が必要な場合)
            try
            {
                //  この時点でビジーなら待つ
                //  割り込みタイマーを発生
                intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                intTimer.Tag = 0;
                intTimer.Enabled = true;
                while (mPop.Busy == true)
                {
                    Application.DoEvents();
                    if ((int)intTimer.Tag == 1)
                    {
                        //  待ち時間が経過していたら強制停止
                        throw new Exception("処理時間待ちでタイムアウトが発生しました。");
                    }
                }
                intTimer.Enabled = false;

                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);

                //  接続済みなら、一旦解除する
                if (mPop.Connected == true)
                {
                    mPop.Logout();
                }

                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);

                //  フィルター受信モードに従い、受信方法を設定
                if (mailOp.FilterMode == MailFilterModes.None)
                {
                    //  メール受信タイプに従い細工をする
                    if (mailOp.MailReceiveType == MailReceiveEnumTypes.None)
                    {
                        mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.None;
                    }
                    else if (mailOp.MailReceiveType == MailReceiveEnumTypes.Complete)
                    {
                        mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.None;
                    }
                    else
                    {
                        mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.Header;
                    }
                }
                else
                {
                    mPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.Header;
                }

                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);

                //  接続＆初期情報取得
                mPop.AutoLogout = false;
                mPop.AutoDelete = false;
                mPop.DoEvents = true;
                pWin.AddStatus("POP Login........", false);
                mPop.Login(svrinf.POPServer, svrinf.POPPort, "", 0, authinf.Account, authinf.PassWord);

                //  ログイン出来たら件数によりメッセージなど変更
                pWin.AddStatus("POP Login OK", false);

                if (mPop.Messages.Length == 0)
                {
                    //  メール無し
                    mStatus = 1;
                    mStatusMessage = "未読メールは有りません";
                    pWin.AddStatus("No Message", false);
                    pWin.AddStatus("Receive End", false);
                }
                else
                {
                    //  メール有り
                    pWin.AddStatus(mPop.Messages.Length.ToString() + " Messages on Server", false);
                    pWin.AddStatus("Receive Sart", false);

                    //  件数表示制御用の変数を初期化
                    mMaxExtMessageFig = mPop.Messages.Length;       //  現在取得した最大メッセージのID(サーバーに存在する数)
                    mPopReceiveResult.TotalFigure = mMaxExtMessageFig;          //  2006.11.20  追加

                    if ((mReceivingMailOp.ReceiveType == ReceiveEnumTypes.LogingOnly) || (mReceivingMailOp.MailReceiveType == MailReceiveEnumTypes.None))
                    {
                        //  ログインのみ、或いは受信無しの場合、ここで終了
                        pWin.AddStatus("POP Login OK", false);
                    }
                    else
                    {
                        //  コンプリート指定で、且つメール有りならメッセージ取得開始
                        pWin.AddStatus("POP Get Message", false);
                        GetMessage2();
                    }
                }
            }
            catch (Exception er)
            {
                //  エラー
                pWin.AddStatus("POP Login : Error => " + er.Message.ToString(), false);
                mStatus = 1;
                mStatusMessage = er.Message;
                nRetCd = 3;
                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                {
                    if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
                    {
                        pWin.HideWindow();
                    }
                }
            }

            mBusyStatus2 = false;            //  処理中に設定
            return nRetCd;
        }
       
        
        /// <summary>
        ///  サーバー切断処理
        /// </summary>
        /// <returns>無し</returns>
        /// <remarks>
        /// <br>Note       : サーバーとの接続を終了します。通信中でも切断が可能です。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        public void Logout()
        {
            mGlobalStatus = null;
            try
            {
                //mPop.BeginLogout(mGlobalStatus);                                                  //  2006.11.20  変更
                //pWin.AddStatus("POP Logout.....", false);                                         //          V
                if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.Asynchronous)           //          V
                {                                                                                   //          V
                    mPop.BeginLogout(mGlobalStatus);                                                //          V
                    pWin.AddStatus("POP Logout.....", false);                                       //          V
                }                                                                                   //          V
                else                                                                                //          V
                {                                                                                   //          V
                    pWin.AddStatus("POP Logout.....", false);                                       //          V
                    mPop.Logout();                                                                  //          V
                    pWin.AddStatus("POP Logout OK", false);                                         //          V
                }                                                                                   //  2006.11.20  変更

            }
            catch(Exception er)
            {
                mStatus = 5;
                mStatusMessage = er.Message;
            }
        }


        /// <summary>
        /// メッセージ取得(非同期)処理
        /// </summary>
        /// <returns>取得結果</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
       [STAThread]
        private int GetMessage()
        {
            if (mPop.Connected ==  true)
            {
                ArrayList alGet = new ArrayList();

                //  自動削除機能制御
                if (mReceivingMailOp.AutoDelete == true)
                {
                    mPop.AutoDelete = true;
                }
                else
                {
                    mPop.AutoDelete = false;
                }

                for (int i = 0; i < mPop.Messages.Length; i++)
                {
                    try
                    {
                        bool bGet = false;
                        //  この時点でビジーなら待つ
                        //  割り込みタイマーを発生
                        intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                        intTimer.Tag = 0;
                        intTimer.Enabled = true;
                        while ((mPop.Busy == true) || (mBusyStatus2 == true))
                        {
                            Application.DoEvents();
                            if ((int)intTimer.Tag == 1)
                            {
                                //  待ち時間が経過していたら強制停止
                                throw new Exception("処理時間待ちでタイムアウトが発生しました。");
                            }
                        }
                        intTimer.Enabled = false;
                        if (mReceivingMailOp.FilterMode == MailFilterModes.Subject)
                        {
                            if (mPop.Messages[i].Message.Subject.IndexOf(mReceivingMailOp.FilterString, StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                bGet = true;
                            }
                        }
                        else if (mReceivingMailOp.FilterMode == MailFilterModes.FromAddress)
                        {
                            if (mPop.Messages[i].Message.From.ToString().IndexOf(mReceivingMailOp.FilterString, StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                bGet = true;
                            }
                        }
                        else
                        {
                            bGet = true;
                        }
                        if (bGet == true)
                        {
                            ++mMaxGetMessageFig;
                        }
                        alGet.Add(bGet);
                    }
                    catch (Exception er)
                    {
                        mStatus = 5;
                        mStatusMessage = er.Message;
                        pWin.AddStatus("Receive Failed ID = " + mPop.Messages[i].Id , false);
                    }

                }

                //  現在工程 (0:Login,1:GetMessage)
                mPahase = 1;

                //  メールヘッダのみならここで全てを処理する
                int nowI = 0;
                if (mReceivingMailOp.MailReceiveType == MailReceiveEnumTypes.Header)
                {
                    for (int i = 0; i < mPop.Messages.Length; i++)
                    {
                        if ((bool)alGet[i] == true)
                        {
                            ++nowI;
                            pWin.AddStatus("Receive Analyzing ID = " + nowI.ToString(), false);
                            AnalyzeHeader(mPop.Messages[i]);
                            //  メッセージがMAXだったら、終了扱い
                            if (nowI >= mMaxGetMessageFig)
                            {
                                pWin.AddStatus("Receive End : All Messages", false);
                            }
                            else
                            {
                                pWin.AddStatus("Receive End ID = " + nowI.ToString(), false);
                            }

                            EventHandler<ReceivingGetEndEventArgs> h = PopEndGetMessege;
                            ReceivingGetEndEventArgs args = new ReceivingGetEndEventArgs(mNowMessageIdx, mMaxGetMessageFig, mStatus, mStatusMessage);

                            if (null != h)
                            {
                                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                                Application.DoEvents();
                            }
                        }
                    }
                    //  ヘッダのみの場合、ここで抜ける
                    return 0;
                }

                nowI = 0;
                for (int i = 0; i < mPop.Messages.Length; i++)
                {
                    try
                    {
                        //  この時点でビジーなら待つ
                        //  割り込みタイマーを発生
                        intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                        intTimer.Tag = 0;
                        intTimer.Enabled = true;
                        while ((mPop.Busy == true) || (mBusyStatus2 == true))
                        {
                            Application.DoEvents();
                            if ((int)intTimer.Tag == 1)
                            {
                                //  待ち時間が経過していたら強制停止
                                throw new Exception("処理時間待ちでタイムアウトが発生しました。");
                            }
                        }
                        intTimer.Enabled = false;
                        if ((bool)alGet[i] == true)
                        {
                            ++mNowProgressIdx;                  //  進捗表示用
                            ++nowI;                             //  メッセージ表示用(必ずしも進捗表示がBeginGetの後に正しいとは限らない→非同期)
                            mGlobalStatus = i;
                            pWin.SetLabelProgress(mNowProgressIdx, mMaxGetMessageFig);
                            pWin.SetProgress((int)0, (int)0);
                            mPop.Messages[i].BeginGet(mGlobalStatus);
                            pWin.AddStatus("Receive Mail ID = " + nowI.ToString() + " .....", false);
                        }
                    }
                    catch (Exception er)
                    {
                        mStatus = 5;
                        mStatusMessage = er.Message;
                        pWin.AddStatus("Receive Failed ID = " + nowI.ToString() + " Error => " + er.Message, false);
                    }

                }
            }

            return 0;
        }

        /// <summary>
        /// メッセージ取得(同期)処理
        /// </summary>
        /// <returns>取得結果</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        [STAThread]
        private int GetMessage2()
        {
            if (mPop.Connected == true)
            {
                ArrayList alGet = new ArrayList();

                //  自動削除機能制御
                if (mReceivingMailOp.AutoDelete == true)
                {
                    mPop.AutoDelete = true;
                }
                else
                {
                    mPop.AutoDelete = false;
                }

                for (int i = 0; i < mPop.Messages.Length; i++)
                {
                    try
                    {
                        bool bGet = false;
                        if (mReceivingMailOp.FilterMode == MailFilterModes.Subject)
                        {
                            if (mPop.Messages[i].Message.Subject.IndexOf(mReceivingMailOp.FilterString, StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                bGet = true;
                            }
                        }
                        else if (mReceivingMailOp.FilterMode == MailFilterModes.FromAddress)
                        {
                            if (mPop.Messages[i].Message.From.ToString().IndexOf(mReceivingMailOp.FilterString, StringComparison.OrdinalIgnoreCase) > -1)
                            {
                                bGet = true;
                            }
                        }
                        else
                        {
                            bGet = true;
                        }
                        if (bGet == true)
                        {
                            ++mMaxGetMessageFig;
                        }
                        alGet.Add(bGet);
                    }
                    catch (Exception er)
                    {
                        mStatus = 5;
                        mStatusMessage = er.Message;
                        pWin.AddStatus("Receive Failed ID = " + mPop.Messages[i].Id, false);
                    }

                }

                //  総受信件数をセット
                mPopReceiveResult.TotalFigure = mMaxGetMessageFig;

                //  現在工程 (0:Login,1:GetMessage)
                mPahase = 1;

                //  メールヘッダのみならここで全てを処理する
                int nowI = 0;
                if (mReceivingMailOp.MailReceiveType == MailReceiveEnumTypes.Header)
                {
                    for (int i = 0; i < mPop.Messages.Length; i++)
                    {
                        if ((bool)alGet[i] == true)
                        {
                            ++nowI;
                            pWin.AddStatus("Receive Analyzing ID = " + nowI.ToString(), false);
                            AnalyzeHeader(mPop.Messages[i]);
                            //  受信済み件数をセット
                            mPopReceiveResult.ReceivetFigure++;
                            //  イベント無しの場合、トレース無し・ダイアログ無し
                            if (mMailOp.ReceiveMethodEnumType != ReceiveMethodEnumTypes.NoEventSynchronous)
                            {
                                //  受信イベント発生
                                EventHandler<ReceivingGetEndEventArgs> h = PopEndGetMessege;
                                ReceivingGetEndEventArgs args = new ReceivingGetEndEventArgs(mNowMessageIdx, mMaxGetMessageFig, mStatus, mStatusMessage);
                                if (null != h)
                                {
                                    Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                                    Application.DoEvents();
                                }
                            }
                            //  メッセージがMAXだったら、終了扱い
                            if (nowI >= mMaxGetMessageFig)
                            {
                                pWin.AddStatus("Receive End : All Messages", false);
                            }
                            else
                            {
                                pWin.AddStatus("Receive End ID = " + nowI.ToString(), false);
                            }

                        }
                    }
                    //  ヘッダのみの場合、ここで抜ける
                    return 0;
                }

                nowI = 0;
                for (int i = 0; i < mPop.Messages.Length; i++)
                {
                    try
                    {
                        if ((bool)alGet[i] == true)
                        {
                            ++mNowProgressIdx;                  //  進捗表示用
                            ++nowI;                             //  メッセージ表示用(必ずしも進捗表示がBeginGetの後に正しいとは限らない→非同期)
                            mGlobalStatus = i;
                            pWin.SetLabelProgress(mNowProgressIdx, mMaxGetMessageFig);
                            pWin.SetProgress((int)0, (int)0);
                            pWin.AddStatus("Receive Mail ID = " + nowI.ToString() + " .....", false);
                            mPop.Messages[i].Get();
                            if (mPop.Messages[i].Exception == null)
                            {
                                pWin.AddStatus("Receive Analyzing ID = " + nowI.ToString(), false);
                                mStatus = AnalyzeMessage(mPop.Messages[i]);
                                mNowMessageID = System.Convert.ToInt32(mPop.Messages[i].Id);    //  現在取得中のメッセージのID(サーバー付与ID)
                                //  受信済み件数をセット
                                if (mStatus == 0)
                                {
                                    mPopReceiveResult.ReceivetFigure++;
                                }
                            }
                            else
                            {
                                mStatus = 5;
                                mStatusMessage = mPop.Messages[i].Exception.Message;
                            }
                            //  イベント無しの場合、トレース無し・ダイアログ無し
                            if (mMailOp.ReceiveMethodEnumType != ReceiveMethodEnumTypes.NoEventSynchronous)
                            {
                                //  受信イベント発生
                                EventHandler<ReceivingGetEndEventArgs> h = PopEndGetMessege;
                                ReceivingGetEndEventArgs args = new ReceivingGetEndEventArgs(mNowMessageIdx, mMaxGetMessageFig, mStatus, mStatusMessage);
                                if (null != h)
                                {
                                    Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                                    Application.DoEvents();
                                }
                            }
                            //  メッセージがMAXだったら、終了扱い
                            if (mNowMessageIdx >= mMaxGetMessageFig)
                            {
                                pWin.AddStatus("Receive End : All Messages", false);
                                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                                {
                                    if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
                                    {
                                        pWin.HideWindow();
                                    }
                                }
                            }
                            else
                            {
                                pWin.AddStatus("Receive End ID = " + nowI.ToString(), false);
                            }
                        }
                    }
                    catch (Exception er)
                    {
                        mStatus = 5;
                        mStatusMessage = er.Message;
                        pWin.AddStatus("Receive Failed ID = " + nowI.ToString() + " Error => " + er.Message, false);
                    }

                }
            }

            return 0;
        }

        /// <summary>
        /// メッセージ(ヘッダ部)解析メイン処理
        /// </summary>
        /// <param name="pm">メッセージストリーム</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzeHeader(Dart.PowerTCP.Mail.PopMessage pm)
        {
            int nRtncd = 0;

            MailMessageStream mms = new MailMessageStream();

            //  複数のメッセージが同期に
            int idx = mMMessages.Add(mms) + 1;

            try
            {

                //  送信先
                string[] sTo = new string[pm.Message.To.Count];
                for (int i = 0; i < pm.Message.To.Count; i++)
                {
                    sTo[i] = pm.Message.To.ToString();
                }
                if (sTo.Length != 0)
                {
                    mms.To = sTo;
                }
                //  CC送信先
                string[] sCc = new string[pm.Message.CC.Count];
                for (int i = 0; i < pm.Message.CC.Count; i++)
                {
                    sCc[i] = pm.Message.CC.ToString();
                }
                if (sCc.Length != 0)
                {
                    mms.Cc = sCc;
                }
                //  発信者
                mms.From = pm.Message.From.ToString();
                //  件名
                mms.Subject = pm.Message.Subject;
                //  Date
                mms.Date = pm.Message.Date;


                mNowMessageIdx = idx;                                     //  現在取得中のメッセージインデックス(処理内部の配列用)

            }
            catch (Exception er)
            {
                nRtncd = 6;
                mStatus = 6;
                mStatusMessage = er.Message;
                pWin.AddStatus("Analyzing Mail Header ID = " + idx.ToString() + " Error => " + mStatusMessage, false);
            }

            return nRtncd;
        }

        /// <summary>
        /// メッセージ解析メイン処理
        /// </summary>
        /// <param name="pm">メッセージストリーム</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzeMessage(Dart.PowerTCP.Mail.PopMessage pm)
        {
            int nRtncd = 0;

            MailMessageStream mms = new MailMessageStream();

            //  複数のメッセージが同期に
            int idx = mMMessages.Add(mms) + 1;

            //  添付ファイルの確認
            if ( pm.Message.Attachments.Count > 0)
            {
                //  添付取得有り
                if (mReceivingMailOp.GetAttachmentFile == true)
                {
                    //  添付をファイルに落とす
                    if (mReceivingMailOp.AttachFileRecvTypes == AttachFileRecvEnumTypes.File)
                    {

                        string[] atFile = new string[pm.Message.Attachments.Count];
                        try
                        {
                            //  添付ファイル解凍

                            //  ディレクトリ指定が有れば、強制作成
                            string drs = "";
                            if (mReceivingMailOp.ReceivedDirectory.Trim().Length > 0)
                            {
                                try
                                {
                                    drs = Path.GetDirectoryName(mReceivingMailOp.ReceivedDirectory);
                                    if (drs == null)
                                    {
                                        drs = "";
                                    }

                                }
                                catch { }
                            }
                            drs = Path.Combine(drs, idx.ToString());
                            Directory.CreateDirectory(drs);
                            Dart.PowerTCP.Mail.Attachments att = pm.Message.Attachments;
                            for (int i = 0; i < att.Count; i++)
                            {
                                pWin.AddStatus("Extracting Attach File for ID = " + idx.ToString(), false);
                                att[i].Save(Path.Combine(drs, att[i].FileName), true);
                                Attachment at = new Attachment();
                                at.AttachmentFilePath = Path.Combine(drs, att[i].FileName);
                                at.AttachmentFile = null;
                                at.AttachFileRecvType = AttachFileRecvEnumTypes.File;
                                mms.AttachFiles.Add(at);
                                atFile[i] = at.AttachmentFilePath;
                            }
                            mms.FileName = (string[])atFile.Clone();
                        }
                        catch(Exception er)
                        {
                            mStatus = 5;
                            mStatusMessage = er.Message;
                            pWin.AddStatus("Extracting Attach File ID = " + idx.ToString() + " Error => " + mStatusMessage, false);
                        }
                    }
                    else
                    {
                        try
                        {
                            Dart.PowerTCP.Mail.Attachments att = pm.Message.Attachments;
                            for (int i = 0; i < att.Count; i++)
                            {
                                pWin.AddStatus("Extracting Attach File for ID = " + idx.ToString(), false);
                                Attachment at = new Attachment();
                                at.AttachmentFilePath = att[i].FileName;
                                att[i].Content.Position =0;
                                at.AttachmentFile = att[i].Content;
                                at.AttachFileRecvType = AttachFileRecvEnumTypes.Stream;
                                mms.AttachFiles.Add(at);
                            }
                        }
                        catch (Exception er)
                        {
                            mStatus = 5;
                            mStatusMessage = er.Message;
                            pWin.AddStatus("Extracting Attach File ID = " + idx.ToString() + " Error => " + mStatusMessage, false);
                        }

                    }
                }
            }

            //  解析
            MiniMailMessage mm = new MiniMailMessage();
            if (pm.Message.Type.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) > -1)
            {
                //  マルチパートなら
                AnalyzePopMessage(pm.Message, ref mm, idx);
            }
            else
            {
                //  マルチパートで無ければ解析無しで元のメッセージを転記
                mm.ContentType = pm.Message.Type;
                if (mm.ContentType == ContentEnumTypes.TextPlain)
                {
                    mm.Text = pm.Message.Text;
                    mm.AlterText = "";
                }
                else
                {
                    mm.Text = pm.Message.Text;
                    mm.AlterText = pm.Message.Text;
                }
            }

            //  送信先
            string[] sTo = new string [pm.Message.To.Count];
            for (int i = 0; i < pm.Message.To.Count; i++)
            {
                sTo[i] = pm.Message.To.ToString();
            }
            if (sTo.Length != 0) 
            {
                mms.To = sTo;
            }
            //  CC送信先
            string[] sCc = new string[pm.Message.CC.Count];
            for (int i = 0; i < pm.Message.CC.Count; i++)
            {
                sCc[i] = pm.Message.CC.ToString();
            }
            if (sCc.Length != 0)
            {
                mms.Cc = sCc;
            }
            //  発信者
            mms.From =pm.Message.From.ToString();
            //  件名
            mms.Subject = pm.Message.Subject;
            //  Date
            mms.Date = pm.Message.Date;

            //  マルチパートが正しく解析できなかった時の事を考えて予めメッセージの本文をセットしておく
            mms.Text = pm.Message.Text;

            //  PlaneTextかHtmlTextかを判断(添付ファイルは別途ハンドリングするので、ここでは気にする必要が無い)
            mms.ContentType = mm.ContentType;
            if (mm.ContentType == ContentEnumTypes.TextPlain)
            {
                mms.Text = mm.Text;
                mms.AlterText = "";
            }
            else if ((mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
            {
                mms.Text = mm.Text;
                mms.AlterText = mm.AlterText;
                //  画像ファイルなどのリンク情報を物理ファイル名で置き換える
                //  完了後にディレクトリにHTMLファイルも落とす
                try
                {
                    //  先ずはリンク情報を書き換え
                    for (int i = 0; i < mm.LinkParts.Count; i++)
                    {
                        mms.AlterText = mm.AlterText.Replace("cid:" + mm.LinkParts[i].ContentID, "file://"+mm.LinkParts[i].LinkPartsPath);
                    }
                    //  HTMLファイルを落とす
                    //  ディレクトリ指定が有れば、強制作成
                    string drs = "";
                    if (mReceivingMailOp.ReceivedDirectory.Trim().Length > 0)
                    {
                        try
                        {
                            drs = Path.GetDirectoryName(mReceivingMailOp.ReceivedDirectory);
                            if (drs == null)
                            {
                                drs = "";
                            }

                        }
                        catch { }
                    }
                    drs = Path.Combine(drs, idx.ToString());
                    Directory.CreateDirectory(drs);
                    if (mm.HtmlPath.Trim().Length == 0)
                    {
                        if (mm.ContentType == ContentEnumTypes.TextXml)
                        {
                            mms.HtmlPath = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".xml";
                        }
                        else
                        {
                            mms.HtmlPath = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".htm";
                        }
                    }
                    else
                    {
                        mms.HtmlPath = mm.HtmlPath;
                    }
                    mms.HtmlPath = Path.Combine(drs, mms.HtmlPath);
                    Encoding ecd;
                    try
                    {
                        //  本体ファイルの仕様に合わせてエンコードする
                        if (mms.AlterText.IndexOf("charset=iso-2022-jp", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ecd = System.Text.Encoding.GetEncoding("iso-2022-jp");
                        }
                        else if (mms.AlterText.IndexOf("charset=shift_jis", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ecd = System.Text.Encoding.GetEncoding("shift_jis");
                        }
                        else if (mms.AlterText.IndexOf("charset=utf-7", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ecd = System.Text.Encoding.GetEncoding("utf-7");
                        }
                        else if (mms.AlterText.IndexOf("charset=utf-8", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ecd = System.Text.Encoding.GetEncoding("utf-8");
                        }
                        else if (mms.AlterText.IndexOf("charset=utf-16", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ecd = System.Text.Encoding.GetEncoding("utf-16");
                        }
                        else if (mms.AlterText.IndexOf("charset=utf-32", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ecd = System.Text.Encoding.GetEncoding("utf-32");
                        }
                        else if (mms.AlterText.IndexOf("charset=euc-jp", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ecd = System.Text.Encoding.GetEncoding("euc-jp");
                        }
                        else if (mms.AlterText.IndexOf("charset=x-mac-japanese", StringComparison.OrdinalIgnoreCase) > -1)
                        {
                            ecd = System.Text.Encoding.GetEncoding("x-mac-japanese");
                        }
                        else
                        {
                            ecd = System.Text.Encoding.GetEncoding(mm.CharaSet);
                        }
                    }
                    catch
                    {
                        ecd = System.Text.Encoding.GetEncoding("iso-2022-jp");
                    }
                    using (StreamWriter sw = new StreamWriter(mms.HtmlPath, false, ecd))
                    {
                        sw.Write(mms.AlterText);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch(Exception er)
                {
                    nRtncd = 6;
                    mStatus = 6;
                    mStatusMessage = er.Message;
                    pWin.AddStatus("Creatingg HTML-Mail ID = " + idx.ToString() + " Error => " + mStatusMessage, false);
                }
            }

            mNowMessageIdx = idx;                                     //  現在取得中のメッセージインデックス(処理内部の配列用)

            return nRtncd;
        }

        /// <summary>
        /// Popメッセージストリーム解析処理
        /// </summary>
        /// <param name="pm">元メッセージストリーム</param>
        /// <param name="imm">解析後情報</param>
        /// <param name="idx">メールメッセージNo(内部配列処理用)</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzePopMessage(Dart.PowerTCP.Mail.MessageStream pm, ref MiniMailMessage imm, int idx)
        {
            try
            {
                //  メッセージの数分回しながら解析を行う
                for (int i = 0; i < pm.Parts.Count; i++)
                {
                    if (pm.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessagePartStream))
                    {
                        //  MIMEパーツ型なら、MIME構造を解析する
                        MiniMailMessage mm = new MiniMailMessage();
                        int retcd = AnalyzePopMessageParts((Dart.PowerTCP.Mail.MessagePartStream)pm.Parts[i], ref mm, idx);
                        if ((mm.ContentType == ContentEnumTypes.TextPlain) || (mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                            {
                            //  テキスト系は本文として受け入れる
                            imm.ContentType = mm.ContentType;
                            imm.AlterText = mm.AlterText;
                            imm.Text = mm.Text;
                            imm.ContentID = mm.ContentID;
                            imm.FileName = mm.FileName;
                            imm.HtmlPath = mm.HtmlPath;
                            imm.CharaSet = mm.CharaSet;
                        }
                        else
                        {
                            //  テキスト系以外は付属物として受け入れる(後で親内のContentIDを一気に書き換える)
                            if (retcd == 0)
                            {
                                imm.LinkParts.Add(mm.LinkParts[0]);
                            }
                        }
                    }
                    else if (pm.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessageStream))
                    {
                        //  メッセージストリームならメッセージが入れ子になって入っているので、解析
                        AnalyzePopMessageStream((Dart.PowerTCP.Mail.MessageStream)pm.Parts[i], ref imm, idx);
                    }
                }
                //  本文は必ず親そのもののTextに入っていない(但し、マルチパートの場合、ごちゃごちゃに入るので、信頼できない)
                imm.Text = pm.Text;

                return 0;

            }
            catch (Exception er)
            {
                mStatus = 7;
                mStatusMessage = er.Message;
                pWin.AddStatus("Analyzing Mail Message ID = " + idx.ToString() + " Error => " + mStatusMessage, false);
                return 7;

            }

        }

        /// <summary>
        /// Popメッセージストリーム部品部分解析処理
        /// </summary>
        /// <param name="prt">元メッセージストリーム</param>
        /// <param name="imm">解析後情報</param>
        /// <param name="idx">メールメッセージNo(内部配列処理用)</param>
        /// <returns>処理結果(ゼロ:正常,1:対象無し,5:エラー)</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzePopMessageParts(Dart.PowerTCP.Mail.MessagePartStream prt, ref MiniMailMessage imm, int idx)
        {
            //(添付ファイルは別途ハンドリングするので、ここでは気にする必要が無い)

            try
            {

                if (prt.ContentType == ContentEnumTypes.TextPlain)
                {
                    //  テキスト系は本文として受け入れる
                    imm.ContentType = prt.ContentType;
                    imm.Text = prt.Text;
                    imm.ContentID = prt.ContentId;
                    imm.FileName = prt.FileName;
                    imm.HtmlPath = "";
                    imm.CharaSet = prt.Charset;
                }
                else if (prt.ContentType == ContentEnumTypes.TextHtml)
                {
                    //  テキスト系は本文として受け入れる
                    imm.ContentType = prt.ContentType;
                    imm.AlterText = prt.Text;
                    imm.Text = prt.Text;
                    imm.ContentID = prt.ContentId;
                    imm.FileName = prt.FileName;
                    imm.HtmlPath = prt.FileName;
                    imm.CharaSet = prt.Charset;
                }
                else if (prt.ContentType == ContentEnumTypes.TextXml)
                {
                    //  テキスト系は本文として受け入れる
                    imm.ContentType = prt.ContentType;
                    imm.AlterText = prt.Text;
                    imm.Text = prt.Text;
                    imm.ContentID = prt.ContentId;
                    imm.FileName = prt.FileName;
                    imm.HtmlPath = prt.FileName;
                    imm.CharaSet = prt.Charset;
                }
                //            else if (prt.ContentType.IndexOf("image/", StringComparison.OrdinalIgnoreCase) > -1)
                else
                {
                    if (prt.FileName != "")
                    {
                        //  ディレクトリ指定が有れば、強制作成
                        string drs = "";
                        if (mReceivingMailOp.ReceivedDirectory.Trim().Length > 0)
                        {
                            try
                            {
                                drs = Path.GetDirectoryName(mReceivingMailOp.ReceivedDirectory);
                                if (drs == null)
                                {
                                    drs = "";
                                }

                            }
                            catch { }
                        }
                        drs = Path.Combine(drs, idx.ToString());
                        Directory.CreateDirectory(drs);
                        //  画像ファイル系は特別扱い
                        if (mPop.UseMemoryStreams == true)
                        {
                            //  MemorySream
                            byte[] buff = new byte[prt.Length];
                            MemoryStream ms = (MemoryStream)prt.Content;
                            ms.Position = 0;
                            ms.Read(buff, 0, (int)prt.Length);
                            using (FileStream fs = new FileStream(Path.Combine(drs, prt.FileName), FileMode.OpenOrCreate))
                            {
                                fs.Position = 0;
                                fs.Write(buff, 0, (int)prt.Length);
                                fs.Flush();
                                LinkParts ls = new LinkParts();
                                ls.LinkPartsType = LinkPartsEnumTypes.Stream;
                                ls.ContentType = prt.ContentType;
                                ls.ContentID = prt.ContentId;
                                ls.LinkPartsFile = ms;
                                ls.LinkPartsPath = Path.Combine(drs, prt.FileName);
                                imm.LinkParts.Add(ls);
                                fs.Close();
                            }
                        }
                        else
                        {
                            //  FileStream
                            byte[] buff = new byte[prt.Length];
                            MemoryStream ms = (MemoryStream)prt.Content;
                            ms.Position = 0;
                            ms.Read(buff, 0, (int)ms.Length);
                            using (FileStream fs = new FileStream(Path.Combine(drs, prt.FileName), FileMode.OpenOrCreate))
                            {
                                fs.Position = 0;
                                fs.Write(buff, 0, (int)prt.Length);
                                fs.Flush();
                                LinkParts ls = new LinkParts();
                                ls.LinkPartsType = LinkPartsEnumTypes.Stream;
                                ls.ContentType = prt.ContentType;
                                ls.ContentID = prt.ContentId;
                                ls.LinkPartsFile = ms;
                                ls.LinkPartsPath = Path.Combine(drs, prt.FileName);
                                imm.LinkParts.Add(ls);
                                fs.Close();
                            }
                        }
                        imm.ContentType = prt.ContentType;
                        imm.ContentID = prt.ContentId;
                        imm.FileName = prt.FileName;
                        imm.CharaSet = prt.Charset;
                    }
                    else
                    {
                        return 1;
                    }
                }

                return 0;
            }
            catch (Exception er)
            {
                mStatus = 7;
                mStatusMessage = er.Message;
                pWin.AddStatus("Analyzing Mail Parts ID = " + idx.ToString() + " Error => " + mStatusMessage, false);
                return 7;

            }

        }


        /// <summary>
        /// Popメッセージストリーム解析処理
        /// </summary>
        /// <param name="prt">元メッセージストリーム</param>
        /// <param name="imm">解析後情報</param>
        /// <param name="idx">メールメッセージNo(内部配列処理用)</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzePopMessageStream(Dart.PowerTCP.Mail.MessageStream prt, ref MiniMailMessage imm, int idx)
        {
            //(添付ファイルは別途ハンドリングするので、ここでは気にする必要が無い)

            try
            {
                //  データが複数のパートによって構成され、最初のパートが残りの全パートを参照している
                //  例えば、HTMLベースのデータで、インデックスゼロに親のHTMLデータ、インデックス1以上に画像などの関連データが入っている
                if (prt.Type == ContentEnumTypes.MultipartRelated)
                {
                    //  子データのContentIDを保存して、後に親側のデータを一気に書き換える
                    ArrayList lstContentID = new ArrayList();
                    ArrayList lstFileName = new ArrayList();

                    //  つまり、複数のパートで一つのデータを構成しているので、一斉に解析する必要がある
                    //  ちなみにインデックス=ゼロが親データ
                    for (int i = 0; i < prt.Parts.Count; i++)
                    {
                        if (prt.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessagePartStream))
                        {
                            MiniMailMessage mm = new MiniMailMessage();
                            int retcd = AnalyzePopMessageParts((Dart.PowerTCP.Mail.MessagePartStream)prt.Parts[i], ref mm, idx);
                            if ((mm.ContentType == ContentEnumTypes.TextPlain) || (mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                            {
                                //  戻ってきた内容は最優先表示対象
                                imm.Text = mm.Text;
                                imm.AlterText = mm.AlterText;
                                imm.ContentType = mm.ContentType;
                                imm.ContentID = mm.ContentID;
                                imm.FileName = mm.FileName;
                                imm.HtmlPath = mm.HtmlPath;
                                imm.CharaSet = mm.CharaSet;
                            }
                            else
                            {
                                //  テキスト系以外は付属物として受け入れる(後で親内のContentIDを一気に書き換える)
                                if (retcd == 0)
                                {
                                    imm.LinkParts.Add(mm.LinkParts[0]);
                                }
                            }
                        }
                        else if (prt.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessageStream))
                        {
                            AnalyzePopMessageStream((Dart.PowerTCP.Mail.MessageStream)prt.Parts[i], ref imm, idx);
                        }

                    }
                    //  全部終わったらContentIDを一気に書き換える
                    //  予定

                }
                //  一つのデータを表すのに、複数の方法で入れてある
                //  例えば、HTMLメールで、インデックスゼロにテキスト代替データ、インデックス1にHTML(或いは主たる何かの)データ
                else if (prt.Type == ContentEnumTypes.MultipartAlternative)
                {
                    //  つまり、複数のパートで一つのデータを表してしている
                    //  ちなみにインデックス=ゼロが代替データ(本当のデータ表現方法に従ったものはインデックス=ゼロ以外に入っている)
                    for (int i = 0; i < prt.Parts.Count; i++)
                    {
                        if (prt.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessagePartStream))
                        {
                            MiniMailMessage mm = new MiniMailMessage();
                            int retcd = AnalyzePopMessageParts((Dart.PowerTCP.Mail.MessagePartStream)prt.Parts[i], ref mm, idx);
                            if ((mm.ContentType == ContentEnumTypes.TextPlain) || (mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                            {
                                if (i == 0)
                                {
                                    //  代替表現対象
                                    if (mm.ContentType == ContentEnumTypes.TextPlain)
                                    {
                                        //  ゼロは代替テキストとして特別扱い
                                        imm.Text = mm.Text;
                                    }
                                    else if ((mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                                    {
                                        imm.AlterText = mm.AlterText;
                                    }
                                    imm.ContentType = mm.ContentType;
                                }
                                else if (i != 0)
                                {
                                    //  本当の表現対象(現在はゼロと同じロジックだが、ロジック分岐がありうるので別にした)
                                    if (mm.ContentType == ContentEnumTypes.TextPlain)
                                    {
                                        //  ゼロは代替テキストとして特別扱い
                                        imm.Text = mm.Text;
                                    }
                                    else if ((mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                                    {
                                        imm.AlterText = mm.AlterText;
                                    }
                                    //  ContentTypeはHTML・XMLコンテンツを優先
                                    imm.ContentType = mm.ContentType;
                                }
                                imm.FileName = mm.FileName;
                                imm.HtmlPath = mm.HtmlPath;
                                imm.CharaSet = mm.CharaSet;
                            }
                            else
                            {
                                //  テキスト系以外は付属物として受け入れる(後で親内のContentIDを一気に書き換える)
                                if (retcd == 0)
                                {
                                    imm.LinkParts.Add(mm.LinkParts[0]);
                                }
                            }

                        }
                        else if (prt.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessageStream))
                        {
                            AnalyzePopMessageStream((Dart.PowerTCP.Mail.MessageStream)prt.Parts[i], ref imm, idx);
                        }

                    }
                }
                //  その他のマルチパートはデータを表すのに、複数の方法で入れてある
                //  例えば、HTMLメールで、インデックスゼロにテキスト代替データ、インデックス1にHTML(或いは主たる何かの)データ
                else
                {
                    //  つまり、複数のパートで一つのデータを表してしている
                    //  ちなみにインデックス=ゼロが代替データ(本当のデータ表現方法に従ったものはインデックス=ゼロ以外に入っている)
                    for (int i = 0; i < prt.Parts.Count; i++)
                    {
                        if (prt.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessagePartStream))
                        {
                            MiniMailMessage mm = new MiniMailMessage();
                            int retcd = AnalyzePopMessageParts((Dart.PowerTCP.Mail.MessagePartStream)prt.Parts[i], ref mm, idx);
                            if ((mm.ContentType == ContentEnumTypes.TextPlain) || (mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                            {
                                if (i == 0)
                                {
                                    //  代替表現対象
                                    if (mm.ContentType == ContentEnumTypes.TextPlain)
                                    {
                                        //  ゼロは代替テキストとして特別扱い
                                        imm.Text = mm.Text;
                                    }
                                    else if ((mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                                    {
                                        imm.AlterText = mm.AlterText;
                                    }
                                    imm.ContentType = mm.ContentType;
                                }
                                else if (i != 0)
                                {
                                    //  本当の表現対象(現在はゼロと同じロジックだが、ロジック分岐がありうるので別にした)
                                    if (mm.ContentType == ContentEnumTypes.TextPlain)
                                    {
                                        //  ゼロは代替テキストとして特別扱い
                                        imm.Text = mm.Text;
                                    }
                                    else if ((mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                                    {
                                        imm.AlterText = mm.AlterText;
                                    }
                                    //  ContentTypeはHTML・XMLコンテンツを優先
                                    imm.ContentType = mm.ContentType;
                                }
                                imm.FileName = mm.FileName;
                                imm.HtmlPath = mm.HtmlPath;
                                imm.CharaSet = mm.CharaSet;
                            }
                            else
                            {
                                //  テキスト系以外は付属物として受け入れる(後で親内のContentIDを一気に書き換える)
                                if (retcd == 0)
                                {
                                    imm.LinkParts.Add(mm.LinkParts[0]);
                                }
                            }

                        }
                        else if (prt.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessageStream))
                        {
                            AnalyzePopMessageStream((Dart.PowerTCP.Mail.MessageStream)prt.Parts[i], ref imm, idx);
                        }

                    }
                }
                return 0;
            }
            catch (Exception er)
            {
                mStatus = 7;
                mStatusMessage = er.Message;
                pWin.AddStatus("Analyzing Mail ID = " + idx.ToString() + " Error => " + mStatusMessage, false);
                return 7;

            }


        }

        /// <summary>
        /// POPサーバー接続チェック処理
        /// </summary>
        /// <returns>popサーバー接続チェック結果(0:成功,3:POP認証エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてpopサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection()
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(mProgressDialog, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// popサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <returns>popサーバー接続チェック結果(0:成功,3:POP認証エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてpopサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// popサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <returns>popサーバー接続チェック結果(0:成功,3:POP認証エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてpopサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, svrinf, mAuthorizationInfo, mMailOp, mTraceOp);
        }

        /// <summary>
        /// popサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <returns>popサーバー接続チェック結果(0:成功,3:POP認証エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてpopサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, svrinf, authinf, mMailOp, mTraceOp);
        }

        /// <summary>
        /// popサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <returns>popサーバー接続チェック結果(0:成功,3:POP認証エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてpopサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, svrinf, authinf, mailOp, mTraceOp);
        }

        /// <summary>
        /// popサーバー接続チェック処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>popサーバー接続チェック結果(0:成功,3:POP認証エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてpopサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {
            //  統一内部メソッドを呼び出す
            return CheckServerConnections(ShowProgress, svrinf, authinf, mailOp, traceOp);
        }

        /// <summary>
        /// popサーバー接続チェック(内部)処理
        /// </summary>
        /// <param name="ShowProgress">プログレス表示設定</param>
        /// <param name="svrinf">サーバー情報クラスオブジェクト</param>
        /// <param name="authinf">認証情報クラスオブジェクト</param>
        /// <param name="mailOp">メールオプション情報クラスオブジェクト</param>
        /// <param name="traceOp">トレース情報クラスオブジェクト</param>
        /// <returns>popサーバー接続チェック結果(0:成功,3:POP認証エラー,9:エラー)</returns>
        /// <remarks>
        /// <br>Note       :プロパティ設定に基づいてpopサーバーとの接続チェックを行います。</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        private int CheckServerConnections(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {

            int nRetCd = 0;

            Dart.PowerTCP.Mail.Pop lPop = new Dart.PowerTCP.Mail.Pop();
            lPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);

            try
            {
                mStatus = 0;
                mStatusMessage = "";

                //  状況表示設定を引き継ぐ
                mProgressDialog2 = ShowProgress;

                //  イベント無しの場合、トレース無し・ダイアログ無し
                if (mReceivingMailOp.ReceiveMethodEnumType != ReceiveMethodEnumTypes.NoEventSynchronous)
                {
                    //  ダイアログ表示制御
                    if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (mTraceOp.Trace == true) || (mDialogConfirm == true))
                    {
                        if (pWin.Visible == false)
                        {
                            pWin.Show();
                            pWin.SetTitle("接続テスト");
                            pWin.AddStatus("Connect Check Start........", false);
                        }
                        if ((mTraceOp.Trace == true) || (mDialogConfirm == true))
                        {
                            pWin.SetButtonVisible(true);
                        }
                        else
                        {
                            pWin.SetButtonVisible(false);
                        }
                    }
                    //  動作中トレースモードの引継ぎを行う
                    mReceivingTraceOp = mTraceOp;
                }
                else
                {
                    //  イベント無しならダイアログは強制解除
                    mProgressDialog = false;
                    mDialogConfirm = false;
                    //  動作中トレースモードの引継ぎを行う(イベント無しならトレースログのみ可能とする)
                    TraceOption top = new TraceOption();
                    top.Trace = false;
                    top.TraceLog = mTraceOp.TraceLog;
                    top.TraceLogPath = mTraceOp.TraceLogPath;
                    mReceivingTraceOp = top;
                }

                //  トレースがログ出力指定がある場合、ログファイル名を決定しておく。
                if (mReceivingTraceOp.TraceLog == true)
                {
                    string TraceLogPath;
                    if (mReceivingTraceOp.TraceLogPath.Trim().Length > 0)
                    {
                        TraceLogPath = Path.Combine(Path.GetDirectoryName(mReceivingTraceOp.TraceLogPath), Path.GetFileNameWithoutExtension(mReceivingTraceOp.TraceLogPath) + System.DateTime.Now.ToString("yyyyMMddHHmm") + Path.GetExtension(mReceivingTraceOp.TraceLogPath));
                    }
                    else
                    {
                        TraceLogPath = "tpop" + System.DateTime.Now.ToString("yyyyMMddHHmm") + ".log";
                    }
                    mReceivingTraceOp.TraceLogPath = TraceLogPath;

                }

                //  POPサーバーにログイン(認証が必要な場合)
                pWin.AddStatus("POP Server Login....", true);
                try
                {
                    lPop.AutoGet = Dart.PowerTCP.Mail.MessageSection.None;
                    lPop.Timeout = mServerInfo.POPTimeOut * 1000;
                    lPop.AutoLogout = false;
                    lPop.Login(mServerInfo.POPServer, mAuthorizationInfo.Account, mAuthorizationInfo.PassWord);
                }
                catch (Exception er)
                {
                    pWin.AddStatus("POP Server Login NG " + er.Message.ToString(), false);
                    mStatus = 1;
                    mStatusMessage = "POP Server Login NG " + er.Message;
                    if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                    {
                        if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
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
                else
                {
                    mStatus = 2;
                    mStatusMessage = "POP認証に失敗しました";
                    return 3;
                }
                pWin.AddStatus("POP Server Login Check OK", false);

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

                //  ダイアログの後始末
                if ((((mProgressDialog == true) || (mProgressDialog2 == true)) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true)) && (pWin.Visible == true))
                {
                    if ((mDialogConfirm == false) && (mReceivingTraceOp.Trace == false))
                    {
                        pWin.HideWindow();
                    }
                }


            }
        }

    }
}


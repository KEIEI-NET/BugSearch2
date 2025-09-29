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
    /// TSMTP(���[�����M)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : SuperFrontman��p���[�����M�R���|�[�l���g�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.15</br>
    /// <br></br>
    /// <br>Update Note: 2006.11.20 ����@�K��</br>
    /// </remarks>
    public partial class TSMTP : Component
    {
        //  �o�[�W����
        const string ctDefaultMailerName = "SuperFrontman Mail Delivery Program ver 1.0";
        
        //  �R���|�[�l���g�E�C�x���g
        /// <summary>TSMTP�R���|�[�l���g�T�[�o�[�ڑ��󋵕ω��C�x���g</summary>
        public event EventHandler<SendingEventArgs> SmtpConnectedChangedEx;
        /// <summary>TSMTP�R���|�[�l���gBUSY�󋵕ω��C�x���g</summary>
        public event EventHandler<SendingEventArgs> SmtpBusyChanged;
        /// <summary>TSMTP�R���|�[�l���g���M�C�x���g</summary>
        public event EventHandler<SendEndEventArgs> SmtpEndSend;
        /// <summary>TSMTP�R���|�[�l���g���M�i���C�x���g</summary>
        public event EventHandler<SendingProgressEventArgs> SmtpProgress;
        /// <summary>TSMTP�R���|�[�l���g�g���[�X�C�x���g</summary>
        public event EventHandler<SendingEventArgs> SmtpTrace;
        /// <summary>TPOP�R���|�[�l���g�T�[�o�[�ڑ��󋵕ω��C�x���g</summary>
        public event EventHandler<SendingEventArgs> PopConnectedChangedEx;
        /// <summary>TPOP�R���|�[�l���gBUSY�󋵕ω��C�x���g</summary>
        public event EventHandler<SendingEventArgs> PopBusyChanged;
        /// <summary>TPOP�R���|�[�l���g��M�i���C�x���g</summary>
        public event EventHandler<SendingProgressEventArgs> PopProgress;
        /// <summary>TPOP�R���|�[�l���g�g���[�X�C�x���g</summary>
        public event EventHandler<SendingEventArgs> PopTrace;

        //  ���SMTP�APOP3�R���|�[�l���g
        private Dart.PowerTCP.Mail.Smtp mSmtp;
        private Dart.PowerTCP.Mail.Pop mPop;

        //  �҂����ԍ쐬�p�̃^�C�}�[�R���|
        private Timer intTimer;

        //  �i���󋵕\�����
        private ProgressWindow pWin = new ProgressWindow();

        //  �e�탁�[�����M�ɕK�v�ȃv���p�e�B�̎���
        private ServerInfomation mServerInfo = new ServerInfomation();
        private AuthorizationInfomation mAuthorizationInfo = new AuthorizationInfomation();
        private MailOption mMailOp = new MailOption();
        private TraceOption mTraceOp = new TraceOption();
        private MailMessageStreamCollection mMMessages = new MailMessageStreamCollection();
        private object mTag = new object();
        private SmtpSendResult mSmtpSendResult = new SmtpSendResult();          //  2006.11.20  �ǉ�

        //  �i���󋵕\����ʂ̐ݒ�v���p�e�B�̎���
        //private bool mProgressDialog;                                         //  2006.11.20  �ύX
        //private bool mDialogConfirm;                                          //        V
        internal static bool mProgressDialog;                                   //        V
        internal static bool mDialogConfirm;                                    //  2006.11.20  �ύX

        //  �X�e�[�^�X�v���p�e�B�̎���
        private object mGlobalStatus;
        private int mStatus;
        private string mStatusMessage;
        private bool mSendingError = false;                 //  ���M�J�n�ȍ~�A�ɃG���[�����������ꍇ��true�ɂȂ�

        //  �ڑ��󋵑J�ڒ��X�e�[�^�X�v���p�e�B�̎���
        private bool mConnectedStatus;
        private bool mBusyStatus;

        //  �g���[�X���p���������p�N���X(���X�̃v���p�e�B�ɂ͐ݒ肳��Ȃ��P�[�X������̂�)
        private TraceOption mSendingTraceOp = new TraceOption();
        private bool mProgressDialog2;                                          //  2006.11.20  �ǉ�

        //  ���݁E�ő�\����
        //private struct SendFigure                                             //  2006.11.20  �ύX
        internal struct SendFigure
        {
            public int NowNo;
            public int MaxFig;
        }
        //private static SendFigure mSendFigure;                                //  2006.11.20  �ύX
        internal static SendFigure mSendFigure;

        //  �C�x���g�n���h���[��

        /// <summary>
        /// SendingEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���M���X�e�[�^�X�C�x���g�p�����[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class SendingEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;

            /// <summary>�X�e�[�^�X�R�[�h�v���p�e�B</summary>
            /// <value>���M���X�e�[�^�X</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>�X�e�[�^�X���b�Z�[�W�v���p�e�B</summary>
            /// <value>���M���X�e�[�^�X���b�Z�[�W</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>
            /// SendingEventArgs�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ���M���X�e�[�^�X�C�x���g�p�����[�^�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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
        /// <br>Note       : ���M�I���C�x���g�p�����[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class SendEndEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;
            private int _maxfig;
            private int _nownum;

            /// <summary>�X�e�[�^�X�R�[�h�v���p�e�B</summary>
            /// <value>���M�I���X�e�[�^�X</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>�X�e�[�^�X���b�Z�[�W�v���p�e�B</summary>
            /// <value>���M�I���X�e�[�^�X���b�Z�[�W</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>���M�Ώې��v���p�e�B</summary>
            /// <value>���M�Ώۂ̐�</value>
            /// <remarks></remarks>
            public int MaxMessageFig
            {
                get { return _maxfig; }
            }

            /// <summary>���ݑ��M�ԍ��v���p�e�B</summary>
            /// <value>���M�Ώې��̓��̑��M�����ԍ�</value>
            /// <remarks></remarks>
            public int NowMessageNo
            {
                get { return _nownum; }
            }

            /// <summary>
            /// SendEndEventArgs�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ���M�I���X�e�[�^�X�C�x���g�p�����[�^�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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
        /// <br>Note       : ���M���i���󋵃C�x���g�p�����[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 2006.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class SendingProgressEventArgs : EventArgs
        {

            private int _maxfig;
            private int _nownum;
            private int _nowpos;
            private int _maxpos;

            /// <summary>���݈ʒu�v���p�e�B</summary>
            /// <value>�i���S�̂̌��݂̃|�W�V����</value>
            /// <remarks></remarks>
            public int NowPos
            {
                get { return _nowpos; }
            }
            /// <summary>�S�̈ʒu�v���p�e�B</summary>
            /// <value>�i���S��</value>
            /// <remarks></remarks>
            public int MaxPos
            {
                get { return _maxpos; }
            }

            /// <summary>���M�Ώې��v���p�e�B</summary>
            /// <value>���M�Ώۂ̐�</value>
            /// <remarks></remarks>
            public int MaxMessageFig
            {
                get { return _maxfig; }
            }

            /// <summary>���ݑ��M�ԍ��v���p�e�B</summary>
            /// <value>���M�Ώې��̓��̑��M�����ԍ�</value>
            /// <remarks></remarks>
            public int NowMessageNo
            {
                get { return _nownum; }
            }

            /// <summary>
            /// SendingProgressEventArgs�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ���M���i���󋵃C�x���g�p�����[�^�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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
        /// <br>Note       : ���[���I�v�V�����p�J�X�^���R���o�[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 2006.11.20 ����@�K��</br>
        /// </remarks>
        internal class MailOptionClassConverter : ExpandableObjectConverter
        {

            /// <summary>�^�ϊ�(���^�֕ϊ�)�\�v���p�e�B</summary>
            /// <value>���^�֕ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
            /// <remarks></remarks>
            public override bool CanConvertTo(
                ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(MailOption))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// �ϊ�(���^�֕ϊ�)����
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <param name="destinationType"></param>
            /// <returns>�ϊ�����</returns>
            /// <remarks>
            /// <br>Note       :�w�肵���l�I�u�W�F�N�g���A�w�肵���^�ɕϊ�����</br>
            /// <br>Programmer  : 96203 ����@�K��</br>
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
                        //retval = retval + mp.SendMailerName.ToString();                   //  2006.11.20  �ύX
                        retval = retval + mp.SendMailerName.ToString() + ",";
                        retval = retval + mp.SendMethodEnumType.ToString();                 //  2006.11.20  �ǉ�
                        return retval;
                    }
                    catch
                    {
                        throw new ArgumentException("Can not convert '" + (string)value + "' to type MailOptions");
                    }
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

            /// <summary>�^�ϊ�(���^����̕ϊ�)�\�v���p�e�B</summary>
            /// <value>���^����̕ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
            /// <remarks></remarks>
            public override bool CanConvertFrom(
                ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// �ϊ�(���^����̕ϊ�)����
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <returns>�ϊ�����</returns>
            /// <remarks>
            /// <br>Note       :�w�肵���l�I�u�W�F�N�g���A�w�肵���^�ɕϊ�����</br>
            /// <br>Programmer  : 96203 ����@�K��</br>
            /// <br>Date        : 2006.07.15</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    try
                    {
//                        string[] vs = value.ToString().Split((new char[] { ',' }), 11);           //  2006.11.20  �ύX
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
                        if (vs[11].IndexOf("Asynchronous", StringComparison.OrdinalIgnoreCase) > -1)        //  2006.11.20  �ǉ�
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
        /// <br>Note       : ���[���I�v�V�����N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 2006.11.20 ����@�K��</br>
        /// </remarks>
        [TypeConverter(typeof(MailOptionClassConverter))]
        public class MailOption
        {

            //  ���[���̃I�v�V�����v���p�e�B�̓����ێ��p
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
            private SendMethodEnumTypes mSendMethodEnumType;                    //  2006.11.20 �ǉ�

            /// <summary>
            /// MailOption�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : MailOption�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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
                mSendMethodEnumType = SendMethodEnumTypes.Asynchronous;         //  2006.11.20 �ǉ�
            }

            /// <summary>�z�M��Ԓʒm�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("�z�M��Ԓʒm��ݒ肵�܂�(�Ή��T�[�o�[�̂�)")]
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

            /// <summary>�z�M��Ԓʒm���̃��b�Z�[�W�Y�t�ۃv���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("�z�M��Ԓʒm�Ƀ��b�Z�[�W�Y�t��ݒ肵�܂�(�Ή��T�[�o�[�̂�)")]
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

            /// <summary>�z�M��Ԓʒm����Envelope-ID�ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("�z�M��Ԓʒm����Envelope-ID��ݒ肵�܂�(�Ή��T�[�o�[�̂�)")]
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

            /// <summary>�J���m�F�v���ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���M�҂���̊J���m�F��v�����܂�")]
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

            /// <summary>�J���m�F�E���M��ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("�J���m�F�̑��M����w�肵�܂�")]
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

            /// <summary>���[���[���̐ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���[���[�̖��̂�ʒm���܂�")]
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

            /// <summary>���[���[���̃v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���[���[���̂��ݒ肳��܂�")]
            [RefreshProperties(RefreshProperties.Repaint)]
            public string MailerName
            {
                get
                {
                    return (mMailerName);
                }
            }

            /// <summary>���[���̓��͗p��ƃf�B���N�g���ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���[���̓��͗p��ƃf�B���N�g��")]
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

            /// <summary>HELLO�l�[���ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("SMTP�T�[�o�[�ɑ��M����HELLP or ELHO�R�}���h��FQDN��ݒ肵�܂�(�����l:localhost)")]
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

            /// <summary>���[�J�����������C���ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���[����GMT���M�����Ƀ��[�J������������ݒ肵�܂�(�����l:true)")]
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

            /// <summary>���M��ʕ������M�ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���M��ꌏ���Ƀ��[���𑗂�܂�(To�w��̂�)")]
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

            /// <summary>�����҂��^�C���A�E�g���Ԑݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���M���̓��������̑҂����Ԃ�b�P�ʂŐݒ肵�܂�(�����l:60�b)")]
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

            /// <summary>���M�����ݒ�v���p�e�B</summary>
            /// <value>Asyncronous:�񓯊�,Syncronous:����,NoEventSynchronous</value>
            /// <remarks></remarks>
            [Description("���M���̓����E�񓯊���ݒ肵�܂�(�����l:�񓯊�)")]
            public SendMethodEnumTypes SendMethodEnumType                       //  2006.11.20  �ǉ�
            {
                get
                {
                    return (mSendMethodEnumType);
                }
                set
                {
                    //  �C�x���g�����Ȃ�_�C�A���O�͋�������
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
        /// <br>Note       : SmtpSendResult�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.11.20</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class SmtpSendResult
        {

            private int mTotalFigure;
            private int mSentFigure;

            /// <summary>
            /// SmtpSendResult�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : SmtpSendResult�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
            /// <br>Date       : 2006.11.20</br>
            /// </remarks>
            public SmtpSendResult()
            {
                mTotalFigure = 0;
                mSentFigure = 0;
            }


            /// <summary>���M�Ώی����v���p�e�B</summary>
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

            /// <summary>���M�ό����v���p�e�B</summary>
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

        /// <summary>�F�ؕ����񋓌^</summary>
        /// <remarks>�F�ؕ�����\���񋓌^�ł�</remarks>
        [TypeConverter(typeof(EnumConverter))]
        public enum AuthorizationTypes
        {
            /// <summary>����</summary>
            None,
            /// <summary>POP Before SMT�^</summary>
            POPBeforeSMTP,
            /// <summary>SMTP AUTH�^</summary>
            SMTPAuth,
            /// <summary>�����g���C�^</summary>
            Auto
        }

        /// <summary>
        /// AuthorizationInfomationClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       :  ���F���p�J�X�^���R���o�[�^�[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class AuthorizationInfomationClassConverter : ExpandableObjectConverter
        {
            /// <summary>�^�ϊ�(���^�֕ϊ�)�\�v���p�e�B</summary>
            /// <value>���^�֕ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
            /// <remarks></remarks>
            public override bool CanConvertTo(
                ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(AuthorizationInfomation))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// �ϊ�(���^�֕ϊ�)����
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <param name="destinationType"></param>
            /// <returns>�ϊ�����</returns>
            /// <remarks>
            /// <br>Note       :�w�肵���l�I�u�W�F�N�g���A�w�肵���^�ɕϊ�����</br>
            /// <br>Programmer  : 96203 ����@�K��</br>
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

            /// <summary>�^�ϊ�(���^����̕ϊ�)�\�v���p�e�B</summary>
            /// <value>���^����ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
            /// <remarks></remarks>
            public override bool CanConvertFrom(
                ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// �ϊ�(���^����̕ϊ�)����
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <returns>�ϊ�����</returns>
            /// <remarks>
            /// <br>Note       :�w�肵���l�I�u�W�F�N�g���A�w�肵���^�ɕϊ�����</br>
            /// <br>Programmer  : 96203 ����@�K��</br>
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
        /// <br>Note       :  ���F���N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        [TypeConverter(typeof(AuthorizationInfomationClassConverter))]
        public class AuthorizationInfomation
        {
            //  ���F�������ێ��p
            private string mPopAccount;
            private string mPopPassWord;
            private string mSmtpAccount;
            private string mSmtpPassWord;
            private AuthorizationTypes mAuthType;

            /// <summary>
            /// AuthorizationInfomation�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : AuthorizationInfomation�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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

            /// <summary>POP3�F�ؗp�A�J�E���g���v���p�e�B</summary>
            /// <value>POP3�F�؂Ɏg�p����A�J�E���g���E���[�U�[����ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("POP3�F�ؗp�̃A�J�E���g��ݒ肵�܂�")]
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

            /// <summary>POP3�F�ؗp�p�X���[�h�v���p�e�B</summary>
            /// <value>POP3�F�؂Ɏg�p����p�X���[�h��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("POP3�F�ؗp�̃p�X���[�h��ݒ肵�܂�")]
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

            /// <summary>SMTP�F�ؗp�A�J�E���g���v���p�e�B</summary>
            /// <value>SMTP�F�؂Ɏg�p����A�J�E���g���E���[�U�[����ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("SMTP�F�ؗp�̃A�J�E���g��ݒ肵�܂�")]
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

            /// <summary>SMTP�F�ؗp�p�X���[�h�v���p�e�B</summary>
            /// <value>SMTP�F�؂Ɏg�p����p�X���[�h��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("SMTP�F�ؗp�̃p�X���[�h��ݒ肵�܂�")]
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

            /// <summary>�F�،`���ݒ�v���p�e�B</summary>
            /// <value>�F�،`����ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("�F�ؕ��@��ݒ肵�܂�")]
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
        /// <br>Note       :  �T�[�o�[�p�J�X�^���R���o�[�^�[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class ServerInfomationClassConverter : ExpandableObjectConverter
        {
            /// <summary>�^�ϊ�(���^�֕ϊ�)�\�v���p�e�B</summary>
            /// <value>���^�֕ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
            /// <remarks></remarks>
            public override bool CanConvertTo(
                ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(ServerInfomation))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// �ϊ�(���^�֕ϊ�)����
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <param name="destinationType"></param>
            /// <returns>�ϊ�����</returns>
            /// <remarks>
            /// <br>Note       :�w�肵���l�I�u�W�F�N�g���A�w�肵���^�ɕϊ�����</br>
            /// <br>Programmer  : 96203 ����@�K��</br>
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

            /// <summary>�^�ϊ�(���^����̕ϊ�)�\�v���p�e�B</summary>
            /// <value>���^����ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
            /// <remarks></remarks>
            public override bool CanConvertFrom(
                ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// �ϊ�(���^����̕ϊ�)����
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <returns>�ϊ�����</returns>
            /// <remarks>
            /// <br>Note       :�w�肵���l�I�u�W�F�N�g���A�w�肵���^�ɕϊ�����</br>
            /// <br>Programmer  : 96203 ����@�K��</br>
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
        /// <br>Note       :  �T�[�o�[���N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
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
            /// ServerInfomation�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ServerInfomation�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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

            /// <summary>SMTP Server�A�h���X�v���p�e�B</summary>
            /// <value>SMTP Server�̃A�h���X��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("SMTP�T�[�o�[��ݒ肵�܂�")]
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

            /// <summary>SMTP Server�|�[�g�v���p�e�B</summary>
            /// <value>SMTP Server�̃|�[�g��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("SMTP�T�[�o�[�ɐڑ�����|�[�g��ݒ肵�܂�(�����l:25)")]
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

            /// <summary>POP3 Servear�A�h���X�v���p�e�B</summary>
            /// <value>POP3 Server�̃A�h���X(�F�ؗp)��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("POP3�T�[�o�[��ݒ肵�܂�(POP Before SMTP�F�؎��͕K�{)")]
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

            /// <summary>POP3 Servear�|�[�g�v���p�e�B</summary>
            /// <value>POP3 Server�̃|�[�g��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("POP3�T�[�o�[�ɐڑ�����|�[�g��ݒ肵�܂�(�����l:110)")]
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

            /// <summary>SMTP Servear�^�C���A�E�g���Ԑݒ�|�[�g�v���p�e�B</summary>
            /// <value>SMTP Server�̃^�C���A�E�g���Ԃ�ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("SMTP�T�[�o�[�̃^�C���A�E�g��b�P�ʂŐݒ肵�܂�(�����l:60)")]
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

            /// <summary>POP3 Servear�^�C���A�E�g���Ԑݒ�|�[�g�v���p�e�B</summary>
            /// <value>POP3 Server�̃^�C���A�E�g���Ԃ�ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("PPOP3�T�[�o�[�̃^�C���A�E�g��b�P�ʂŐݒ肵�܂�(�����l:60)")]
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
        /// <br>Note       :  �g���[�X�I�v�V�����p�J�X�^���R���o�[�^�[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class TraceOptionClassConverter : ExpandableObjectConverter
        {
            /// <summary>�^�ϊ�(���^�֕ϊ�)�\�v���p�e�B</summary>
            /// <value>���^�֕ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
            /// <remarks></remarks>
            public override bool CanConvertTo(
                ITypeDescriptorContext context, Type destinationType)
            {
                if (destinationType == typeof(TraceOption))
                    return true;
                return base.CanConvertTo(context, destinationType);
            }

            /// <summary>
            /// �ϊ�(���^�֕ϊ�)����
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <param name="destinationType"></param>
            /// <returns>�ϊ�����</returns>
            /// <remarks>
            /// <br>Note       :�w�肵���l�I�u�W�F�N�g���A�w�肵���^�ɕϊ�����</br>
            /// <br>Programmer  : 96203 ����@�K��</br>
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

            /// <summary>�^�ϊ�(���^����̕ϊ�)�\�v���p�e�B</summary>
            /// <value>���^����ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
            /// <remarks></remarks>
            public override bool CanConvertFrom(
                ITypeDescriptorContext context, Type sourceType)
            {
                if (sourceType == typeof(string))
                    return true;
                return base.CanConvertFrom(context, sourceType);
            }

            /// <summary>
            /// �ϊ�(���^����̕ϊ�)����
            /// </summary>
            /// <param name="context"></param>
            /// <param name="culture"></param>
            /// <param name="value"></param>
            /// <returns>�ϊ�����</returns>
            /// <remarks>
            /// <br>Note       :�w�肵���l�I�u�W�F�N�g���A�w�肵���^�ɕϊ�����</br>
            /// <br>Programmer  : 96203 ����@�K��</br>
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
        /// <br>Note       :  �g���[�X�I�v�V�����^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.15</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        [TypeConverter(typeof(TraceOptionClassConverter))]
        public class TraceOption
        {

            //  �����ێ����
            private bool mTrace;
            private bool mTraceLog;
            private string mTraceLogPath;

            /// <summary>
            /// TraceOption�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : TraceOption�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
            /// <br>Date       : 2006.07.15</br>
            /// </remarks>
            public TraceOption()
            {
	            mTrace = false;
	            mTraceLog = false;
	            mTraceLogPath = "";
            }

            /// <summary>Trace�ۃv���p�e�B</summary>
            /// <value>Trace�E�s��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Category("Option"), Description("�f�o�b�O�p�Ƀg���[�X�󋵂�\�����܂�(ProgressDialog��ON�ɂȂ�܂�)")]
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

            /// <summary>Trace���O�o�͉ۃv���p�e�B</summary>
            /// <value>Trace���O�o�͉E�s��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Category("Option"),Description("�f�o�b�O�p�Ƀg���[�X���O���o�͂��܂�(��ʕ\������)")]
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

            /// <summary>Trace���O�p�X�v���p�e�B</summary>
            /// <value>Trace���O�p�X��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Category("Option"),Description("�g���[�X���O�̃p�X���w�肵�܂�(�ݒ薳���̏ꍇ�A�J�����g��TSMTP.LOG�ŏo�͂���܂�)")]
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
        /// TSMTP�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : TSMTP�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
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
            mProgressDialog2 = false;                                           //  2006.11.20  �ǉ�

            //  SMTP�R���|�[�l���g�̃C���X�^���X���쐬
            mSmtp = new Dart.PowerTCP.Mail.Smtp();
            //  SMTP�R���|�[�l���g�̃C�x���g��ݒ�
            mSmtp.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mSmtp_ConnectedChangedEx);
            mSmtp.BusyChanged += new EventHandler(mSmtp_BusyChanged);
            mSmtp.EndSend += new Dart.PowerTCP.Mail.SendEventHandler(mSmtp_EndSend);
            mSmtp.Progress += new Dart.PowerTCP.Mail.SmtpProgressEventHandler(mSmtp_Progress);
            mSmtp.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mSmtp_Trace);

            //  POP�R���|�[�l���g�̃C���X�^���X���쐬
            mPop = new Dart.PowerTCP.Mail.Pop();
            //  POP�R���|�[�l���g�̃C�x���g��ݒ�
            mPop.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mPop_ConnectedChangedEx);
            mPop.BusyChanged += new EventHandler(mPop_BusyChanged);
            mPop.Progress += new Dart.PowerTCP.Mail.PopProgressEventHandler(mPop_Progress);
            mPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);

            //  Timer�R���|�[�l���g�̃C���X�^���X���쐬
            intTimer = new Timer();
            intTimer.Enabled = false;
            intTimer.Tag = 0;
            //  Timer�R���|�[�l���g�̃C�x���g��ݒ�
            intTimer.Tick += new EventHandler(intTimer_Tick);
        }

        /// <summary>
        /// TSMTP�N���X�R���X�g���N�^(��ʓ\��t���p)
        /// </summary>
        /// <remarks>
        /// <br>Note       : TSMTP�N���X�R���X�g���N�^(��ʓ\��t���p)</br>
        /// <br>Programmer : 96203 ����@�K��</br>
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
            mProgressDialog2 = false;                                           //  2006.11.20  �ǉ�

            //  SMTP�R���|�[�l���g�̃C���X�^���X���쐬
            mSmtp = new Dart.PowerTCP.Mail.Smtp();
            //  SMTP�R���|�[�l���g�̃C�x���g��ݒ�
            mSmtp.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mSmtp_ConnectedChangedEx);
            mSmtp.BusyChanged += new EventHandler(mSmtp_BusyChanged);
            mSmtp.EndSend += new Dart.PowerTCP.Mail.SendEventHandler(mSmtp_EndSend);
            mSmtp.Progress += new Dart.PowerTCP.Mail.SmtpProgressEventHandler(mSmtp_Progress);
            mSmtp.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mSmtp_Trace);

            //  POP�R���|�[�l���g�̃C���X�^���X���쐬
            mPop = new Dart.PowerTCP.Mail.Pop();
            //  POP�R���|�[�l���g�̃C�x���g��ݒ�
            mPop.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mPop_ConnectedChangedEx);
            mPop.BusyChanged += new EventHandler(mPop_BusyChanged);
            mPop.Progress += new Dart.PowerTCP.Mail.PopProgressEventHandler(mPop_Progress);
            mPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);

            //  Timer�R���|�[�l���g�̃C���X�^���X���쐬
            intTimer = new Timer();
            intTimer.Enabled = false;
            intTimer.Tag = 0;
            //  Timer�R���|�[�l���g�̃C�x���g��ݒ�
            intTimer.Tick += new EventHandler(intTimer_Tick);

        }

        /// <summary>
        /// �҂����Ԃ̊��荞�ݏ����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �҂����Ԃ̊��荞�ݏ������ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        private void intTimer_Tick(object sender, EventArgs e)
        {

            //  �^�C�}�[��~
            intTimer.Enabled = false;

            //  ���荞�ݔ���
            intTimer.Tag = 1;

        }


        /// <summary>
        /// POP�T�[�o�[�E�R�l�N�g�󋵕ω����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : POP�R���|�[�l���g�ɂ��POP�T�[�o�[�R�l�N�g�󋵕ω����ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        void mPop_ConnectedChangedEx(object sender, EventArgs e)
        {
            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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
        /// POP�T�[�o�[�EBUSY�󋵕ω����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : POP�R���|�[�l���g�ɂ��POP�T�[�o�[�EBUSY�󋵕ω����ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        void mPop_BusyChanged(object sender, EventArgs e)
        {

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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
        /// POP�T�[�o�[�E�ʐM���i���󋵃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : POP�T�[�o�[�E�ʐM���i���󋵕ω����ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        void mPop_Progress(object sender, Dart.PowerTCP.Mail.PopProgressEventArgs e)
        {
            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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
        /// POP�T�[�o�[�E�g���[�X�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : POP�T�[�o�[�E�g���[�X���ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        void mPop_Trace(object sender, Dart.PowerTCP.Mail.SegmentEventArgs e)
        {

            //  �g���[�X�\��
            if (mSendingTraceOp.Trace == true)
            {
                if (e.Segment != null)
                {
                    pWin.AddStatus("Trace : Segment =>" + e.Segment.ToString().Trim(), mSendingTraceOp.Trace);
                }
            }

            //  �g���[�X���O�o��(�g���[�X�\���Əo�͕͂ʕ�)
            if ((mSendingTraceOp.TraceLog == true) && (e.Segment != null))
            {
                try
                {
                    // �C�x���g�f�[�^���o�C�g�z����Ɋi�[���܂��B
                    byte[] buffer = System.Text.Encoding.Default.GetBytes(e.Segment.ToString());
                    // FileStream ���쐬���܂��B
                    FileStream f = new FileStream(mSendingTraceOp.TraceLogPath, FileMode.Append);
                    // �X�g���[���Ƀf�[�^���������݂܂��B
                    f.Write(buffer, 0, buffer.Length);
                    // FileStream ���I�����܂��B
                    f.Close();
                }
                catch
                { }
            }

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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
        /// SMTP�T�[�o�[�E�R�l�N�g�󋵕ω����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : SMTP�R���|�[�l���g�ɂ��SMTP�T�[�o�[�R�l�N�g�󋵕ω����ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_ConnectedChangedEx(object sender, EventArgs e)
        {

            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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
        /// POP�T�[�o�[�EBUSY�󋵕ω����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : SMTP�R���|�[�l���g�ɂ��SMTP�T�[�o�[�EBUSY�󋵕ω����ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_BusyChanged(object sender, EventArgs e)
        {

            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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
        /// SMTP�T�[�o�[�E���M�I�����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : SMTP�T�[�o�[�E���M�I�����ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_EndSend(object sender, Dart.PowerTCP.Mail.SmtpEventArgs e)
        {

            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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

            //  ���M�J�n�ȍ~�ɃG���[���������Ă�����A���̃C�x���g�͒ʉ߂����Ȃ�
            //  (�G���[����������M�C�x���g����������̂ŁA������߂�ׁ��񓯊��̈׎d���Ȃ�)
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

            //  ���M�J�n�ȍ~�A�ɃG���[�����������ꍇ��true�ɂ���
            if (mStatus != 0)
            {
                mSendingError = true;
            }
            else                                                                //  2006.11.20  �ǉ�
            {
                //  �񓯊��^�̏ꍇ�̂ݐ��������瑗�M�ς݌������A�b�v
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
        /// SMTP�T�[�o�[�E�ʐM���i���󋵃C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : SMTP�T�[�o�[�E�ʐM���i���󋵕ω����ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_Progress(object sender, Dart.PowerTCP.Mail.ProgressEventArgs e)
        {
            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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
        /// SMTP�T�[�o�[�E�g���[�X�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : SMTP�T�[�o�[�E�g���[�X���ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        protected void mSmtp_Trace(object sender, Dart.PowerTCP.Mail.SegmentEventArgs e)
        {
            mConnectedStatus = mSmtp.Connected;
            mBusyStatus = mSmtp.Busy;

            //  �g���[�X�\��
            if (mSendingTraceOp.Trace == true)
            {
                if (e.Segment != null)
                {
                    pWin.AddStatus("Trace : Segment =>" + e.Segment.ToString().Trim(), mSendingTraceOp.Trace);
                }
            }

            //  �g���[�X���O�o��(�g���[�X�\���Əo�͕͂ʕ�)
            if ((mSendingTraceOp.TraceLog == true) && (e.Segment != null))
            {
                try
                {
                    // �C�x���g�f�[�^���o�C�g�z����Ɋi�[���܂��B
                    byte[] buffer = System.Text.Encoding.Default.GetBytes(e.Segment.ToString());
                    // FileStream ���쐬���܂��B
                    FileStream f = new FileStream(mSendingTraceOp.TraceLogPath, FileMode.Append);
                    // �X�g���[���Ƀf�[�^���������݂܂��B
                    f.Write(buffer, 0, buffer.Length);
                    // FileStream ���I�����܂��B
                    f.Close();
                }
                catch
                {
                }
            }

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
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

        /// <summary>�R�l�N�g�X�e�[�^�X�v���p�e�B</summary>
        /// <value>SMTP�T�[�o�[�ւ̐ڑ��󋵂��ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Category("Status"), Description("�T�[�o�[�ւ̐ڑ����")]
        [Browsable(false)]
        public bool ConnectedStatus
        {
            get
            {
                return (mConnectedStatus);
            }

        }

        /// <summary>BUSY�X�e�[�^�X�v���p�e�B</summary>
        /// <value>SMTP�T�[�o�[�Ƃ̒ʐM�󋵂��ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Category("Status"), Description("�R�}���h���s����")]
        [Browsable(false)]
        public bool BusyStatus
        {
            get
            {
                return (mBusyStatus);
            }

        }

        /// <summary>�X�e�[�^�X�R�[�h�v���p�e�B</summary>
        /// <value>�X�e�[�^�X�R�[�h���ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Category("Status"), Description("���M���ʂȂǂ̃X�e�[�^�X�R�[�h")]
        [Browsable(false)]
        public int Status
        {
            get
            {
                return ( mStatus);
            }

        }

        /// <summary>�X�e�[�^�X���b�Z�[�W�v���p�e�B</summary>
        /// <value>�X�e�[�^�X���b�Z�[�W���ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Category("Status"), Description("���M���ʂȂǂ̃X�e�[�^�X���b�Z�[�W")]
        [Browsable(false)]
        public string StatusMessage
        {
            get
            {
                return (mStatusMessage);
            }

        }

        /// <summary>�T�[�o�[���v���p�e�B</summary>
        /// <value>�T�[�o�[�̊e�����ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Category("Server"), Description("�T�[�o�[�̊e�����ݒ肵�܂�")]
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
        /// <summary>���[�����b�Z�[�W���v���p�e�B</summary>
        /// <value>���[�����b�Z�[�W�̊e�����ݒ肵�܂�</value>
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

        /// <summary>���F���v���p�e�B</summary>
        /// <value>���F�̊e�����ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Category("Authorization"), Description("�F�؂Ɋւ���ݒ�����܂�")]
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

        /// <summary>���[���I�v�V�����v���p�e�B</summary>
        /// <value>���[���̊e��I�v�V������ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Category("Option"), Description("���[���I�v�V�����@�\�Ɋւ���ݒ�����܂�")]
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

        /// <summary>�f�o�b�O�I�v�V�����v���p�e�B</summary>
        /// <value>�f�o�b�O�p�̊e��I�v�V������ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Category("Option"), Description("�f�o�b�O�p�Ƀg���[�X�@�\�Ɋւ���ݒ肵�܂�")]
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

        /// <summary>�i���󋵉�ʕ\���v���p�e�B</summary>
        /// <value>�i���󋵂��q��ʕ\�����邩�ǂ����̐ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Category("Option"), Description("���M�󋵂̃_�C�A���O�\���̐ݒ�����܂�")]
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

        /// <summary>�i���󋵉�ʁE�����N���[�Y�ݒ�v���p�e�B</summary>
        /// <value>�i���󋵂̎q��ʂ������N���[�Y���邩�{�^���N���[�Y���邩�̐ݒ�����܂�</value>
        /// <remarks></remarks>
        [Category("Option"),Description("�{�^���ł̂݃_�C�A���O����܂�")]
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

        /// <summary>�R���g���[���Ɋւ���f�[�^���i�[����I�u�W�F�N�g��ݒ�E�擾���܂�</summary>
        /// <value>�R���g���[���Ɋւ���f�[�^���i�[����I�u�W�F�N�g</value>
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

        /// <summary>���M���ʃv���p�e�B(�ǂݎ���p)</summary>
        /// <value>���[���̑��M���ʂ��擾���܂�</value>
        /// <remarks></remarks>
        [Browsable(false)]
        public SmtpSendResult SmtpSendResultInfo                                //  2006.11.20  �ǉ�
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
        /// ���[�����M����
        /// </summary>
        /// <returns>���M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[,5:���M�p�����[�^�ݒ�G���[,7:�Y�t�t�@�C���G���[,9:���M�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â��ă��[���̑��M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage()
        {
            //  ����������\�b�h���Ăяo��
            return SendMessages(mMMessages, mProgressDialog, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);
                        
        }

        /// <summary>
        /// ���[�����M����
        /// </summary>
        /// <param name="messages">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <returns>���M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[,5:���M�p�����[�^�ݒ�G���[,7:�Y�t�t�@�C���G���[,9:���M�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����E�v���p�e�B�ݒ�Ɋ�Â��ă��[���̑��M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress)
        {
            //  ����������\�b�h���Ăяo��
            return SendMessages(messages, ShowProgress, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// ���[�����M����
        /// </summary>
        /// <param name="messages">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <returns>���M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[,5:���M�p�����[�^�ݒ�G���[,7:�Y�t�t�@�C���G���[,9:���M�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����E�v���p�e�B�ݒ�Ɋ�Â��ă��[���̑��M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress, ServerInfomation svrinf)
        {
            //  ����������\�b�h���Ăяo��
            return SendMessages(messages, ShowProgress, svrinf, mAuthorizationInfo, mMailOp, mTraceOp);
        }

        /// <summary>
        /// ���[�����M����
        /// </summary>
        /// <param name="messages">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <returns>���M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[,5:���M�p�����[�^�ݒ�G���[,7:�Y�t�t�@�C���G���[,9:���M�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����E�v���p�e�B�ݒ�Ɋ�Â��ă��[���̑��M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf)
        {
            //  ����������\�b�h���Ăяo��
            return SendMessages(messages, ShowProgress, svrinf, authinf, mMailOp, mTraceOp);
        }

        /// <summary>
        /// ���[�����M����
        /// </summary>
        /// <param name="messages">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <returns>���M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[,5:���M�p�����[�^�ݒ�G���[,7:�Y�t�t�@�C���G���[,9:���M�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����E�v���p�e�B�ݒ�Ɋ�Â��ă��[���̑��M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp)
        {
            //  ����������\�b�h���Ăяo��
            return SendMessages(messages, ShowProgress, svrinf, authinf, mailOp, mTraceOp);
        }

        /// <summary>
        /// ���[�����M����
        /// </summary>
        /// <param name="messages">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>���M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[,5:���M�p�����[�^�ݒ�G���[,7:�Y�t�t�@�C���G���[,9:���M�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����ݒ�Ɋ�Â��ă��[���̑��M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public int SendMessage(MailMessageStreamCollection messages, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {
            //  ����������\�b�h���Ăяo��
            return SendMessages(messages, ShowProgress, svrinf, authinf, mailOp, traceOp);
        }

        /// <summary>
        /// ���[�����M(����)����
        /// </summary>
        /// <param name="messages">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>���M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[,5:���M�p�����[�^�ݒ�G���[,7:�Y�t�t�@�C���G���[,9:���M�G���[)</returns>
        /// <remarks>
        /// <br>Note       :���[���̑��M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        private int SendMessages(MailMessageStreamCollection messages, bool ShowProgress, TSMTP.ServerInfomation svrinf, TSMTP.AuthorizationInfomation authinf, TSMTP.MailOption mailOp, TSMTP.TraceOption traceOp)
        {

            int nRetCd = 0;
            int nStep = 0;

            if (mSmtp.Busy == true)
            {
                mStatus = 1;
                mStatusMessage = "���݁A�������ł��B��������s�ł��܂���B";
                return 1;
            }

            //  �󋵕\���ݒ�������p��
            mProgressDialog2 = ShowProgress;                                    //  2006.11.20  �ǉ�

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ύX
            if (mMailOp.SendMethodEnumType != SendMethodEnumTypes.NoEventSynchronous)
            {
                //  �_�C�A���O�\������
                if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (traceOp.Trace == true) || (mDialogConfirm == true))
                {
                    if (pWin.Visible == false)
                    {
                        pWin.Show();
                        pWin.SetTitle("���M");
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
                    //  �g���[�X
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  ���쒆�g���[�X���[�h�̈��p�����s��
                mSendingTraceOp = traceOp;
            }
            else
            {
                //  �C�x���g�����Ȃ�_�C�A���O�͋�������
                mProgressDialog = false;
                mDialogConfirm = false;
                //  ���쒆�g���[�X���[�h�̈��p�����s��(�C�x���g�����Ȃ�g���[�X���O�̂݉\�Ƃ���)
                TraceOption top = new TraceOption();
                top.Trace = false;
                top.TraceLog = traceOp.TraceLog;
                top.TraceLogPath = traceOp.TraceLogPath;
                mSendingTraceOp = top;
            }
            //  �g���[�X�����O�o�͎w�肪����ꍇ�A���O�t�@�C���������肵�Ă����B
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
                //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                if (mSendingTraceOp.Trace == true)
                {
                    //  �g���[�X
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  ����SMTP�R���|�[�l���g��ݒ�
                mSmtp.Server = svrinf.SMTPServer;
                mSmtp.ServerPort = svrinf.SMTPPort;
                mSmtp.HelloName = mailOp.HelloName;
                mSmtp.Timeout = svrinf.SMTPTimeOut * 1000;

                //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                if (mSendingTraceOp.Trace == true)
                {
                    //  �g���[�X
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }

                //  �F�ؕ����ɏ]���A�F�؏���ݒ�
                if ((authinf.AuthType == TSMTP.AuthorizationTypes.SMTPAuth) || (authinf.AuthType == TSMTP.AuthorizationTypes.Auto))
                {
                    mSmtp.Username = authinf.SmtpAccount;
                    mSmtp.Password = authinf.SmtpPassWord;
                }
                //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                if (mSendingTraceOp.Trace == true)
                {
                    //  �g���[�X
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  �z�M��Ԓʒm
                if (mailOp.DeliveryStatusNotification == true)
                {
                    // EnvelopeID �́ADSN �́uOriginal-Envelope-ID�v�w�b�_�Ƃ��ĕԂ���܂�
                    mSmtp.DSN.EnvelopeID = mailOp.EnvelopeID;
                    // �w�b�_�����łȂ��A���b�Z�[�W�S�̂�Ԃ��܂�
                    mSmtp.DSN.ReturnMessage = mailOp.DeliveryStatusNotificationMessage;
                    // �����̐����A���s�A�܂��͒x������ DSN �𑗐M���܂��i���̃v���p�e�B�͒ǉ��^�ł��j�B
                    mSmtp.DSN.Type = Dart.PowerTCP.Mail.DSNType.Failure | Dart.PowerTCP.Mail.DSNType.Success | Dart.PowerTCP.Mail.DSNType.Delay;
                }

                //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                if (mSendingTraceOp.Trace == true)
                {
                    //  �g���[�X
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  HelloName��ݒ�
                mSmtp.HelloName = mailOp.HelloName;

                //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                if (mSendingTraceOp.Trace == true)
                {
                    //  �g���[�X
                    pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                }
                //  POP�T�[�o�[�Ƀ��O�C��(�F�؂��K�v�ȏꍇ)
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
                        mStatusMessage = "POP�F�؂Ɏ��s���܂���";                 // 2006.11.20  �ǉ�
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

                //  �\�ߑ��M�������擾���Ă���
                int nowNo = 0;
                int maxFig = 0;
                mSmtpSendResult.SentFigure = 0;                                 //  2006.11.20  �ǉ�
                for (int i = 0; i < messages.Count; i++)
                {
                    if (mailOp.DividingSend == true)
                    {
                        maxFig = maxFig + messages[i].To.Length;
                        mSmtpSendResult.TotalFigure = maxFig;                   //  2006.11.20  �ǉ�
                    }
                    else
                    {
                        ++maxFig;
                    }
                }
                //  ���b�Z�[�W�R���N�V���������b�Z�[�W�𑗂葱����
                nStep = 0;
                for (int i = 0; i < messages.Count; i++)
                {

                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Loop Step" + (i + 1), mSendingTraceOp.Trace);
                    }

                    //  ���荞�݃^�C�}�[�𔭐�
                    intTimer.Interval = mailOp.ProcTimeOut * 1000;
                    intTimer.Tag = 0;
                    intTimer.Enabled = true;
                    while (mSmtp.Busy == true)
                    {
                        Application.DoEvents();
                        if ((int)intTimer.Tag == 1)
                        {
                            //  �҂����Ԃ��o�߂��Ă����狭����~
                            throw new Exception("�������ԑ҂��Ń^�C���A�E�g���������܂����B");
                        }
                    }
                    intTimer.Enabled = false;

                    Dart.PowerTCP.Mail.MessageStream mailMsg;

                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  ���M���e��HTML�ŁA���A�p�X���Ă̏ꍇ�A�����Ń��[���X�g���[���Ɏ�荞�ޕK�v���L��
                    if (messages[i].HtmlPath.Trim().Length > 0)
                    {
                        //  HTML�̃p�X�w��
                        mailMsg = new Dart.PowerTCP.Mail.MessageStream(messages[i].HtmlPath);
                    }
                    else
                    {
                        //  �m�[�}���p�^�[��
                        mailMsg = new Dart.PowerTCP.Mail.MessageStream();
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  GMT�̂Ƀ��[�J���������{����
                    if (mailOp.AdjustTimeZone == true)
                    {
                        string sTime = System.DateTime.Now.ToString("r");�@�@�@�@            // ���[�J���̌��ݎ������擾
                        string sTimeOffset = System.DateTime.Now.ToString("zzz");           // �^�C���]�[���@�I�t�Z�b�g���擾
                        string sHeaderDate = sTime.Substring(0, sTime.Length - 3) + sTimeOffset.Replace(":", "");   // �t�H�[�}�b�g�ݒ�
                        mailMsg.Header.Add(Dart.PowerTCP.Mail.HeaderLabelType.Date, sHeaderDate);                   //�@���[���w�b�_�ɃZ�b�g
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  ���[���[���̐ݒ�
                    if (mailOp.SendMailerName == true)
                    {
                        mailMsg.Mailer = ctDefaultMailerName;
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    // �J���m�F
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
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  CC���M��Z�b�g
                    for (int j = 0; j < messages[i].Cc.Length; j++)
                    {
                        mailMsg.CC.Add(new Dart.PowerTCP.Mail.MailAddress(messages[i].Cc[j]));
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  BCC���M��Z�b�g
                    for (int j = 0; j < messages[i].Bcc.Length; j++)
                    {
                        mailMsg.BCC.Add(new Dart.PowerTCP.Mail.MailAddress(messages[i].Bcc[j]));
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  ����
                    mailMsg.Subject = messages[i].Subject;
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }

                    //  ���[�����e�Z�b�g
                    if (messages[i].HtmlPath.Trim().Length > 0)
                    {
                    }
                    else if (messages[i].AlterText.Trim().Length > 0)
                    {
                        //  HTML���[��
                        //  �悸��HTML�������ƂȂ郁�b�Z�[�W�X�g���[�������(multipart/related�ŏ��ɓǂݍ��܂��ݒ�)
                        Dart.PowerTCP.Mail.MessageStream mps1 = new Dart.PowerTCP.Mail.MessageStream();
                        mps1.Type = ContentEnumTypes.MultipartRelated;
                        mps1.MimeBoundary = "----=_NextPart_11_" + System.DateTime.Now.ToString("MMddHHmm" + ":1");
                        mailMsg.Parts.Complex.Add(mps1);
                        //  �I���^�l�[�g�e�L�X�g��HTML�����������
                        Dart.PowerTCP.Mail.MessageStream mps2 = new Dart.PowerTCP.Mail.MessageStream();
                        mps2.Type = ContentEnumTypes.MultipartAlternative;
                        mps2.MimeBoundary = "----=_NextPart_12_" + System.DateTime.Now.ToString("MMddHHmm"+":2");
                        mps1.Parts.Complex.Add(mps2);
                        //  �I���^�l�[�g�e�L�X�g�����������
                        Dart.PowerTCP.Mail.MessagePartStream mps3 = new Dart.PowerTCP.Mail.MessagePartStream();
                        mps3.ContentType = ContentEnumTypes.TextPlain;
                        mps3.Charset = "iso-2022-jp";
                        mps3.Text = messages[i].AlterText;              //  �ꉞ����Ă���(�{���͂�����TEXT���ǂ�)
                        mps2.Parts.Add(mps3);
                        //  HTML�����������
                        Dart.PowerTCP.Mail.MessagePartStream mps4 = new Dart.PowerTCP.Mail.MessagePartStream();
                        mps4.Text = messages[i].AlterText;              //  
                        mps4.ContentType = ContentEnumTypes.TextHtml;
                        try
                        {
                            //  HTML�t�@�C���̎d�l�ɍ��킹�ăG���R�[�h����
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
                        //  �ʏ�e�L�X�g���[��
                        mailMsg.Text = messages[i].Text;
                    }
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  �Y�t�t�@�C���A�^�b�`(Mime)
                    if ((messages[i].FileName != null) && (messages[i].FileName.Length > 0))
                    {
                        //  �t�@�C���p�X�w��(�ȈՃ^�C�v)
                        for (int j = 0; j < messages[i].FileName.Length; j++)
                        {
                            pWin.AddStatus("Biding Attachment File.....", false);
                            if (File.Exists(messages[i].FileName[j]) == false)
                            {
                                mStatus = 1;
                                mStatusMessage = "�w�肳�ꂽ�Y�t�t�@�C�������݂��܂��� FilePath = " + messages[i].FileName[j];
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
                        //  �ڍ׃^�C�v
                        for (int j = 0; j < messages[i].AttachFiles.Count; j++)
                        {
                            pWin.AddStatus("Biding Attachment File.....", false);
                            if (messages[i].AttachFiles[j].AttachFileRecvType == AttachFileRecvEnumTypes.File)
                            {
                                if (File.Exists(messages[i].AttachFiles[j].AttachmentFilePath) == false)
                                {
                                    mStatus = 1;
                                    mStatusMessage = "�w�肳�ꂽ�Y�t�t�@�C�������݂��܂��� FilePath = " + messages[i].AttachFiles[j].AttachmentFilePath;
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
                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  ���[���^�C�v�Z�b�g(�^�C�v���ݒ肳��Ė����ꍇ�̂�)
                    if (messages[i].HtmlPath.Trim().Length > 0)
                    {
                    }
                    else if (messages[i].AlterText.Trim().Length > 0)
                    {
                        //  HTML���[��
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
                        //  �ʏ�e�L�X�g���[��
                        if ((mailMsg.Type.ToString().Trim().Length == 0) && (messages[i].ContentType.Trim().Length > 0))
                        {
                            mailMsg.Type = messages[i].ContentType;
                        }
                    }


                    //  �X�e�[�^�X��������
                    mGlobalStatus = null;
                    mStatus = 0;
                    mStatusMessage = "";
                    mSendingError = false;                 //  ���M�J�n�ȍ~�A�ɃG���[�����������ꍇ��true�ɂȂ�

                    //if (traceOp.Trace == true)                                    //  2006.11.20  �ύX
                    if (mSendingTraceOp.Trace == true)
                    {
                        //  �g���[�X
                        pWin.AddStatus("Send Ready : Step" + (++nStep), mSendingTraceOp.Trace);
                    }
                    //  ���M��Z�b�g
                    //  �����w�肪����΁A���M�悲�ƂɃ��b�Z�[�W���쐬���đ���
                    //  To�w��́A�����ɑ���ꂽ���̃A�h���X���ی����ɂȂ�̂ŕs����(���R�k�̌��ɂȂ�)
                    if (mailOp.DividingSend == true)
                    {
                        for (int j = 1; j <= messages[i].To.Length; j++)
                        {

                            //  ���M�J�n
                            try
                            {
                                //  ���荞�݃^�C�}�[�𔭐�
                                intTimer.Interval = mailOp.ProcTimeOut * 1000;
                                intTimer.Tag = 0;
                                intTimer.Enabled = true;
                                while (mSmtp.Busy == true)
                                {
                                    Application.DoEvents();
                                    if ((int)intTimer.Tag == 1)
                                    {
                                        //  �҂����Ԃ��o�߂��Ă����狭����~
                                        throw new Exception("�������ԑ҂��Ń^�C���A�E�g���������܂����B");
                                    }
                                }
                                intTimer.Enabled = false;

                                Dart.PowerTCP.Mail.MessageStream lMM = mailMsg.Clone();
                                //  ���M����Z�b�g
                                lMM.To.Add(new Dart.PowerTCP.Mail.MailAddress(messages[i].To[j - 1]));
                                //  ���M�����Z�b�g
                                lMM.From = new Dart.PowerTCP.Mail.MailAddress(messages[i].From);

                                if (mStatus != 0)
                                {
                                    mStatus = 9;                                        //  2006.11.20  �ǉ�
                                    break;
                                }
                                //  ���M
                                pWin.SetLabelProgress(nowNo + 1, maxFig);
                                pWin.SetProgress((int)0, (int)0);
                                mSendFigure.NowNo = ++nowNo;
                                mSendFigure.MaxFig = maxFig;
                                mSmtpSendResult.TotalFigure = mSendFigure.MaxFig;       //  2006.11.20  �ǉ�
                                mGlobalStatus = mSendFigure;
                                //mSmtp.BeginSend(lMM, mGlobalStatus);                  //  2006.11.20  �ǉ�
                                //  �ݒ�ɂ��A�����E�񓯊��𕪂���
                                if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Asynchronous)
                                {
                                    //  �񓯊��^
                                    mSmtp.BeginSend(lMM, mGlobalStatus);
                                }
                                else
                                {
                                    //  �����^
                                    Dart.PowerTCP.Mail.SmtpResult sdRetCd = mSmtp.Send(lMM);
                                    if (sdRetCd.Recipients.Count > 0)
                                    {
                                        if (sdRetCd.Recipients[0].ServerResponse.Code == 250)
                                        {
                                            mStatus = 0;
                                            mStatusMessage = "";
                                            mSmtpSendResult.SentFigure++;                   //  2006.11.20  �ǉ�
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
                                    //  �����^(�C�x���g�L��)�Ȃ�SmtpSendEnd�C�x���g�𔭐�
                                    if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Synchronous)
                                    {
                                        mSmtp_EndSend2(mSmtp, null, mSendFigure);
                                    }
                                    //  �G���[�Ȃ璆�~
                                    if (mStatus != 0)
                                    {
                                        mStatus = 9;                                        //  2006.11.20  �ǉ�
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
                                //  �����^(�C�x���g�L��)�Ȃ�SmtpSendEnd�C�x���g�𔭐�          //  2006.11.20  �ǉ�
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
                        //  ���M����Z�b�g
                        for (int j = 0; j < messages[i].To.Length; j++)
                        {
                            mailMsg.To.Add(new Dart.PowerTCP.Mail.MailAddress(messages[i].To[j]));
                        }
                        //  ���M�����Z�b�g
                        mailMsg.From = new Dart.PowerTCP.Mail.MailAddress(messages[i].From);

                        //  ���M�J�n
                        try
                        {
                            //  ���荞�݃^�C�}�[�𔭐�
                            intTimer.Interval = mailOp.ProcTimeOut * 1000;
                            intTimer.Tag = 0;
                            intTimer.Enabled = true;
                            while (mSmtp.Busy == true)
                            {
                                Application.DoEvents();
                                if ((int)intTimer.Tag == 1)
                                {
                                    //  �҂����Ԃ��o�߂��Ă����狭����~
                                    throw new Exception("�������ԑ҂��Ń^�C���A�E�g���������܂����B");
                                }
                            }
                            intTimer.Enabled = false;
                            if (mStatus != 0)
                            {
                                mStatus = 9;                                            //  2006.11.20  �ǉ�
                                break;
                            }
                            //  ���M
                            pWin.SetLabelProgress(nowNo + 1, maxFig);
                            mSendFigure.NowNo = ++nowNo;
                            mSendFigure.MaxFig = maxFig;
                            mSmtpSendResult.TotalFigure = mSendFigure.MaxFig;           //  2006.11.20  �ǉ�
                            mGlobalStatus = mSendFigure;
                            //mSmtp.BeginSend(mailMsg, mGlobalStatus);                  //  2006.11.20  �ǉ�
                            //  �ݒ�ɂ��A�����E�񓯊��𕪂���
                            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Asynchronous)
                            {
                                //  �񓯊��^
                                mSmtp.BeginSend(mailMsg, mGlobalStatus);
                            }
                            else
                            {
                                //  �����^
                                Dart.PowerTCP.Mail.SmtpResult sdRetCd = mSmtp.Send(mailMsg);
                                if (sdRetCd.Recipients.Count > 0)
                                {
                                    if (sdRetCd.Recipients[0].ServerResponse.Code == 250)
                                    {
                                        mStatus = 0;
                                        mStatusMessage = "";
                                        mSmtpSendResult.SentFigure++;                   //  2006.11.20  �ǉ�
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
                                //  �����^(�C�x���g�L��)�Ȃ�SmtpSendEnd�C�x���g�𔭐�
                                if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Synchronous)
                                {
                                    mSmtp_EndSend2(mSmtp, null, mSendFigure);
                                }
                                //  �G���[�Ȃ璆�~                                   
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
                            //  �����^(�C�x���g�L��)�Ȃ�SmtpSendEnd�C�x���g�𔭐�          //  2006.11.20  �ǉ�
                            if (mMailOp.SendMethodEnumType == SendMethodEnumTypes.Synchronous)
                            {
                                mSmtp_EndSend2(mSmtp, er, mSendFigure);
                            }
                            break;                                                      //  2006.11.20  �ǉ�
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
        ///  �T�[�o�[�ؒf����
        /// </summary>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �T�[�o�[�Ƃ̐ڑ����I�����܂��B�ʐM���ł��ؒf���\�ł��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.15</br>
        /// </remarks>
        public void Close()
        {
            mSmtp.Close();
        }

        /// <summary>
        /// SMTP�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <returns>SMTP�T�[�o�[�ڑ��`�F�b�N����(0:����,1:����(SMTP AUTH�t��),3:POP�F�؃G���[,5:�ڑ��G���[,7:�����G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���SMTP�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection()
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(mProgressDialog, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// SMTP�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <returns>SMTP�T�[�o�[�ڑ��`�F�b�N����(0:����,1:����(SMTP AUTH�t��),3:POP�F�؃G���[,5:�ڑ��G���[,7:�����G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���SMTP�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// SMTP�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <returns>SMTP�T�[�o�[�ڑ��`�F�b�N����(0:����,1:����(SMTP AUTH�t��),3:POP�F�؃G���[,5:�ڑ��G���[,7:�����G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���SMTP�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, svrinf, mAuthorizationInfo, mMailOp, mTraceOp);
        }

        /// <summary>
        /// SMTP�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <returns>SMTP�T�[�o�[�ڑ��`�F�b�N����(0:����,1:����(SMTP AUTH�t��),3:POP�F�؃G���[,5:�ڑ��G���[,7:�����G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���SMTP�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, svrinf, authinf, mMailOp, mTraceOp);
        }

        /// <summary>
        /// SMTP�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <returns>SMTP�T�[�o�[�ڑ��`�F�b�N����(0:����,1:����(SMTP AUTH�t��),3:POP�F�؃G���[,5:�ڑ��G���[,7:�����G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���SMTP�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, svrinf, authinf, mailOp, mTraceOp);
        }

        /// <summary>
        /// SMTP�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>SMTP�T�[�o�[�ڑ��`�F�b�N����(0:����,1:����(SMTP AUTH�t��),3:POP�F�؃G���[,5:�ڑ��G���[,7:�����G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���SMTP�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, svrinf, authinf, mailOp, traceOp);
        }

        /// <summary>
        /// SMTP�T�[�o�[�ڑ��`�F�b�N(����)����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>SMTP�T�[�o�[�ڑ��`�F�b�N����(0:����,1:����(SMTP AUTH�t��),3:POP�F�؃G���[,5:�ڑ��G���[,7:�����G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���SMTP�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        private int CheckServerConnections(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {

            string[] HelloCommnd = { "EHLO", "HELLO" };

            int nRetCd = 0;

            //  SMTP�C���X�^���X�쐬
            Dart.PowerTCP.Mail.Segment seg;
            Dart.PowerTCP.Mail.Tcp lTcp = new Dart.PowerTCP.Mail.Tcp();
            lTcp.DoEvents = true;
            lTcp.NoDelay = true;
            lTcp.ReceiveTimeout = svrinf.POPTimeOut * 1000;
            lTcp.SendTimeout = svrinf.SMTPTimeOut * 1000;
            lTcp.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mSmtp_Trace);

            //  POP�C���X�^���X�쐬
            Dart.PowerTCP.Mail.Pop lPop = new Dart.PowerTCP.Mail.Pop();
            lPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);


            try
            {
                mStatus = 0;
                mStatusMessage = "";

                //  �󋵕\���ݒ�������p��
                mProgressDialog2 = ShowProgress;

                //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����
                if (mailOp.SendMethodEnumType != SendMethodEnumTypes.NoEventSynchronous)
                {
                    //  �_�C�A���O�\������
                    if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (traceOp.Trace == true) || (mDialogConfirm == true))
                    {
                        if (pWin.Visible == false)
                        {
                            pWin.Show();
                            pWin.SetTitle("�ڑ��e�X�g");
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
                    //  ���쒆�g���[�X���[�h�̈��p�����s��
                    mSendingTraceOp = traceOp;
                }
                else
                {
                    //  �C�x���g�����Ȃ�_�C�A���O�͋�������
                    mProgressDialog = false;
                    mDialogConfirm = false;
                    //  ���쒆�g���[�X���[�h�̈��p�����s��(�C�x���g�����Ȃ�g���[�X���O�̂݉\�Ƃ���)
                    TraceOption top = new TraceOption();
                    top.Trace = false;
                    top.TraceLog = traceOp.TraceLog;
                    top.TraceLogPath = traceOp.TraceLogPath;
                    mSendingTraceOp = top;
                }

                //  �g���[�X�����O�o�͎w�肪����ꍇ�A���O�t�@�C���������肵�Ă����B
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

                //  POP�T�[�o�[�Ƀ��O�C��(�F�؂��K�v�ȏꍇ)
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
                        mStatusMessage = "POP�F�؂Ɏ��s���܂���";
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

                // SMTP�|�[�g�ւ̐ڑ������݂܂��B
                pWin.SetProgress(1, 4);
                try
                {
                    //  �g���[�X
                    pWin.AddStatus("Connect Sart......", mSendingTraceOp.Trace);
                    lTcp.Connect(svrinf.SMTPServer, svrinf.SMTPPort, "", 0);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    //  �g���[�X
                    pWin.AddStatus("Connect Start NG", false);
                    mStatus = 2;
                    mStatusMessage = ex.Message;
                    return 5;
                }

                if (lTcp.Connected == false)
                {
                    pWin.AddStatus("Connect Start NG", false);
                    mStatus = 3;
                    mStatusMessage = "�ڑ��ł��܂���ł���";
                    return 5;
                }

                //  CONNECT���ʎ�M
                pWin.SetProgress(2, 4);
                try
                {
                    // �f�[�^����M���܂��B���̃I�[�o�[���[�h�͒P���ɁA���ׂĂ̗L���f�[�^����M���܂��B
                    seg = lTcp.Receive();
                }
                catch (Exception ex)
                {
                    //  �g���[�X
                    pWin.AddStatus("Connect Reply NG", false);
                    mStatus = 4;
                    mStatusMessage = ex.Message;
                    return 5;
                }
                if (seg.ToString().IndexOf("220 ") == -1)
                {
                    //  �g���[�X
                    pWin.AddStatus("Connect Reply NG", false);
                    mStatus = 5;
                    mStatusMessage = "�ڑ��ł��܂���ł��� " + seg.ToString();
                    return 5;
                }
                pWin.AddStatus("Connect Reply OK", false);

                //  EHLO or HELLO���M(EHLO �� HELLO�̏��Ɏ��s)
                pWin.AddStatus("Hello Sart .....", false);
                for (int i = 0; i < 2; i++)
                {
                    try
                    {
                        //  �g���[�X
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

                    // ���ʎ�M
                    pWin.SetProgress(3, 4);
                    pWin.AddStatus("Hello Reply OK", false);
                    while (true)
                    {
                        try
                        {
                            // �f�[�^����M
                            seg = lTcp.Receive();
                            //  ���ʂ������s�̏ꍇ�A�s�P�ʂŕ������ĕ\��
                            string[] sHeloRep = seg.ToString().Split('\n');
                            if (seg.ToString().IndexOf("250") == -1)
                            {
                                if (i == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    //  �g���[�X
                                    pWin.AddStatus("Hello Reply NG", false);
                                    mStatus = 7;
                                    mStatusMessage = "�ڑ��ł��܂���ł��� " + seg.ToString();
                                    return 7;
                                }
                            }
                            //  SMTP AUTH�`�F�b�N
                            if (seg.ToString().IndexOf("AUTH") > -1)
                            {
                                //  SMTP AUTH�L��
                                nRetCd = 1;
                                mStatusMessage = "�w��T�[�o�[�� SMTP AUTH �Ή��ł�";
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
                            //  �g���[�X
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

                //  �I��
                return nRetCd;
            }
            finally
            {
                //  �C���X�^���X���
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

                //  �_�C�A���O�̌�n��
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

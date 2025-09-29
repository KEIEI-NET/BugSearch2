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
    /// TPOP(���[����M)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : SuperFrontman��p���[����M�R���|�[�l���g�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/21 ���� ��`</br>
    /// <br>             �uMail for .net 3.1.0.1�v�ւ̑Ή�</br>																						
    /// </remarks>
    public partial class TPOP : Component
    {
        //  �R���|�[�l���g�E�C�x���g
        /// <summary>TPOP�R���|�[�l���g�T�[�o�[�ڑ��󋵕ω��C�x���g</summary>
        public event EventHandler<ReceivingEventArgs> PopConnectedChangedEx;
        /// <summary>TPOP�R���|�[�l���gBUSY�󋵕ω��C�x���g</summary>
        public event EventHandler<ReceivingEventArgs> PopBusyChanged;
        /// <summary>TPOP�R���|�[�l���g��M�i���C�x���g</summary>
        public event EventHandler<ReceivingProgressEventArgs> PopProgress;
        /// <summary>TPOP�R���|�[�l���g�g���[�X�C�x���g</summary>
        public event EventHandler<ReceivingEventArgs> PopTrace;
        /// <summary>TPOP�R���|�[�l���g�T�[�o�[���O�C���C�x���g</summary>
        public event EventHandler<ReceivingLoginEventArgs> PopEndLogin;
        /// <summary>TPOP�R���|�[�l���g�T�[�o�[���O�A�E�g�C�x���g</summary>
        public event EventHandler<ReceivingEventArgs> PopEndLogout;
        /// <summary>TPOP�R���|�[�l���g��M�C�x���g</summary>
        public event EventHandler<ReceivingGetEndEventArgs> PopEndGetMessege;

        //  ���SMTP�APOP3�R���|�[�l���g
        private Dart.PowerTCP.Mail.Pop mPop;

        //  �҂����ԍ쐬�p�̃^�C�}�[�R���|
        private Timer intTimer;

        //  �i���󋵕\�����
        private ProgressWindow pWin = new ProgressWindow();

        //  �e�탁�[����M�ɕK�v�ȃv���p�e�B�̎���
        private ServerInfomation mServerInfo = new ServerInfomation();
        private AuthorizationInfomation mAuthorizationInfo = new AuthorizationInfomation();
        private MailOption mMailOp = new MailOption();
        private TraceOption mTraceOp = new TraceOption();
        private MailMessageStreamCollection mMMessages = new MailMessageStreamCollection();
        private object mTag = new object();
        private PopReceiveResult mPopReceiveResult = new PopReceiveResult();    //  2006.11.20  �ǉ�

        //  �i���󋵕\����ʂ̐ݒ�v���p�e�B�̎���
        //private bool mProgressDialog;                                         //  2006.11.20  �ύX
        //private bool mDialogConfirm;                                          //        V
        internal static bool mProgressDialog;                                   //        V
        internal static bool mDialogConfirm;                                    //  2006.11.20  �ύX

        //  �X�e�[�^�X�v���p�e�B�̎���
        private object mGlobalStatus;
        private int mStatus;
        private string mStatusMessage;

        //  �ڑ��󋵑J�ڒ��X�e�[�^�X�v���p�e�B�̎���
        private bool mConnectedStatus;
        private bool mBusyStatus;           //  POP�R���|�[�l���g��BUSY
        private bool mBusyStatus2;          //  ���������p��BUSY

        //  ���ݎ擾���̃��[�����
        private int mPahase;                //  �擾�H��(0:Login,1:GetMessage)
        private int mNowMessageIdx;         //  �擾�����ŐV�̃��b�Z�[�W�C���f�b�N�X(��͌㏈�������̔z��p)
        private int mNowProgressIdx;        //  ���ݎ擾���̃��b�Z�[�W�C���f�b�N�X(�v���O���X���������̔z��p)
        private int mNowMessageID;          //  ���ݎ擾���̃��b�Z�[�W��ID(�T�[�o�[�t�^ID)
        private int mMaxGetMessageFig;      //  ���ݎ擾�Ώۂ̍ő僁�b�Z�[�W��
        private int mMaxExtMessageFig;      //  ���ݎ擾���̍ő僁�b�Z�[�W��ID(�T�[�o�[�ɑ��݂��鐔)

        //  ���������p�N���X(���X�̃v���p�e�B�ɂ͐ݒ肳��Ȃ��P�[�X������̂�)
        private TraceOption mReceivingTraceOp = new TraceOption();
        private MailOption mReceivingMailOp = new MailOption();
        private bool mReceivingProgressDialog;
        private bool mProgressDialog2;                                          //  2006.11.20  �ǉ�

        //  �C�x���g�n���h���[��

        /// <summary>
        /// ReceivingGetEndEventArgs
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��M�I���C�x���g�p�����[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class ReceivingGetEndEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;
            private int _maxfig;
            private int _nownum;

            /// <summary>�X�e�[�^�X�R�[�h�v���p�e�B</summary>
            /// <value>��M�X�e�[�^�X</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>�X�e�[�^�X���b�Z�[�W�v���p�e�B</summary>
            /// <value>��M�X�e�[�^�X���b�Z�[�W</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>��M�Ώۃ��b�Z�[�W���v���p�e�B</summary>
            /// <value>��M�Ώۂ̃��b�Z�[�W��</value>
            /// <remarks></remarks>
            public int MaxMessageFig
            {
                get { return _maxfig; }
            }

            /// <summary>���݃��b�Z�[�W�ԍ��v���p�e�B</summary>
            /// <value>��M�Ώۃ��b�Z�[�W���̓��̎擾�������b�Z�[�W�ԍ�</value>
            /// <remarks></remarks>
            public int NowMessageNo
            {
                get { return _nownum; }
            }

            /// <summary>
            /// ReceivingGetEndEventArgs�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ��M�I���C�x���g�p�����[�^�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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
        /// <br>Note       : ���O�C���I���C�x���g�p�����[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class ReceivingLoginEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;
            private int _messagefig;

            /// <summary>�X�e�[�^�X�R�[�h�v���p�e�B</summary>
            /// <value>���O�C���X�e�[�^�X</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>�X�e�[�^�X���b�Z�[�W�v���p�e�B</summary>
            /// <value>���O�C���X�e�[�^�X���b�Z�[�W</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>�T�[�o�[���b�Z�[�W���v���p�e�B</summary>
            /// <value>�T�[�o�[�ɕۑ�����Ă��郁�b�Z�[�W��</value>
            /// <remarks></remarks>
            public int MessageFig
            {
                get { return _messagefig; }
            }

            /// <summary>
            /// ReceivingEventArgs�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ��M���X�e�[�^�X�C�x���g�p�����[�^�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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
        /// <br>Note       : ��M���X�e�[�^�X�C�x���g�p�����[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class ReceivingEventArgs : EventArgs
        {
            private int _status;
            private string _statusmsg;

            /// <summary>�X�e�[�^�X�R�[�h�v���p�e�B</summary>
            /// <value>��M���X�e�[�^�X</value>
            /// <remarks></remarks>
            public int Status
            {
                get { return _status; }
            }

            /// <summary>�X�e�[�^�X���b�Z�[�W�v���p�e�B</summary>
            /// <value>��M���X�e�[�^�X���b�Z�[�W</value>
            /// <remarks></remarks>
            public string StatusMessage
            {
                get { return _statusmsg; }
            }

            /// <summary>
            /// ReceivingEventArgs�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ��M���X�e�[�^�X�C�x���g�p�����[�^�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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
        /// <br>Note       : ��M���i���󋵃C�x���g�p�����[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class ReceivingProgressEventArgs : EventArgs
        {

            private int _nowpos;
            private int _maxpos;
            private int _maxfig;
            private int _nownum;

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

            /// <summary>��M�Ώۃ��b�Z�[�W���v���p�e�B</summary>
            /// <value>��M�Ώۂ̃��b�Z�[�W��</value>
            /// <remarks></remarks>
            public int MaxMessageFig
            {
                get { return _maxfig; }
            }

            /// <summary>���݃��b�Z�[�W�ԍ��v���p�e�B</summary>
            /// <value>��M�Ώۃ��b�Z�[�W���̓��̎擾�������b�Z�[�W�ԍ�</value>
            /// <remarks></remarks>
            public int NowMessageNo
            {
                get { return _nownum; }
            }

            /// <summary>
            /// ReceivingProgressEventArgs�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ��M���i���󋵃C�x���g�p�����[�^�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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

        /// <summary>POP�ڑ������񋓑�</summary>
        public enum ReceiveEnumTypes
        {
            /// <summary>���O�C���̂�</summary>
            LogingOnly,
            /// <summary>��M</summary>
            Receive
        }

        /// <summary>���[����M�`���񋓑�</summary>
        public enum MailReceiveEnumTypes
        {
            /// <summary>���b�Z�[�W�̎����擾����</summary>
            None,
            /// <summary>���[���w�b�_�̂ݎ擾</summary>
            Header,
            /// <summary>���[�����S�擾</summary>
            Complete
        }

        /// <summary>���[����M�t�B���^�[�񋓑�</summary>
        public enum MailFilterModes
        {
            /// <summary>���b�Z�[�W�t�B���^�[�̃��[�h�F�w��Ȃ�</summary>
            None,
            /// <summary>���b�Z�[�W�t�B���^�[�̃��[�h�F���M���w��</summary>
            FromAddress,
            /// <summary>���b�Z�[�W�t�B���^�[�̃��[�h�F�����w��</summary>
            Subject
        }


        /// <summary>
        /// MailOptionClassConverter
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[���I�v�V�����p�J�X�^���R���o�[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
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
                        //retval = retval + mp.ReceiveType;                                     //  2006.11.20  �ύX
                        retval = retval + mp.ReceiveType + ",";
                        retval = retval + mp.ReceiveMethodEnumType.ToString();                  //  2006.11.20  �ǉ�
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
            /// <br>Date        : 2006.07.19</br>
            /// </remarks>
            public override object ConvertFrom(ITypeDescriptorContext context,
                CultureInfo culture, object value)
            {
                if (value is string)
                {
                    try
                    {
                        //string[] vs = value.ToString().Split((new char[] { ',' }), 9);                //  2006.11.20  �ύX
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
                        if (vs[10].IndexOf("Asynchronous", StringComparison.OrdinalIgnoreCase) > -1)        //  2006.11.20  �ǉ�
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
        /// <br>Note       : ���[���I�v�V�����N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 2006.11.20 ����@�K��</br>
        /// </remarks>
        [TypeConverter(typeof(MailOptionClassConverter))]
        public class MailOption
        {

            //  ���[���̃I�v�V�����v���p�e�B�̓����ێ��p
            private string mReceivedDirectory;
            private bool mAutoDelete;
            private MailReceiveEnumTypes mMailReceiveType;
            private bool mGetAttachmentFile;
            private AttachFileRecvEnumTypes mAttachFileRecvTypes;
            private MailFilterModes mFilterMode;
            private string mFilterString;
            private int mProcTimeOut;
            private ReceiveEnumTypes mReceiveType;
            private ReceiveMethodEnumTypes mReceiveMethodEnumType;              //  2006.11.20 �ǉ�

            /// <summary>
            /// MailOption�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : MailOption�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
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

            /// <summary>���[���̎�M�f�B���N�g���ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���[���̎�M�f�B���N�g��")]
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

            /// <summary>AutoDelete�ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("POP�T�[�o�[���烁�[������M�����ۂɁA���̃��[�����T�[�o�[����폜���邩�ǂ�����ݒ肵�܂�(�����l:false)")]
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

            /// <summary>MailReceiveType�ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("POP�T�[�o�[�ڑ����̃��O�C���E��M���ǂ����䂷��̂���ݒ肵�܂�(�����l:Receive)")]
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

            /// <summary>MailReceiveType�ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("POP�T�[�o�[���O�C�����Ƀ��[����M���ǂ����䂷��̂���ݒ肵�܂�(�����l:Compelete)")]
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

            /// <summary>�t�B���^�[��M���[�h�ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("�t�B���^�[��M�̃��[�h��ݒ肵�܂�(�����l:None)")]
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

            /// <summary>�t�B���^�[������ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("�t�B���^�[��M����ۂ̕������ݒ肵�܂�")]
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

            /// <summary>�Y�t�t�@�C����M�ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("�Y�t�t�@�C������M���邩�ǂ����ݒ肵�܂�(�����l:True)")]
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

            /// <summary>�Y�t�t�@�C����M�^�C�v�ݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("�Y�t�t�@�C�����t�@�C��Stream�ǂ���Ŏ�M���邩�ݒ肵�܂�(�����l:File)")]
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

            /// <summary>�����҂��^�C���A�E�g���Ԑݒ�v���p�e�B</summary>
            /// <value></value>
            /// <remarks></remarks>
            [Description("���[����Y�t�t�@�C����͂ȂǓ��������̑҂����Ԃ�b�P�ʂŐݒ肵�܂�(�����l:60�b)")]
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
            public ReceiveMethodEnumTypes ReceiveMethodEnumType                 //  2006.11.20  �ǉ�
            {
                get
                {
                    return (mReceiveMethodEnumType);
                }
                set
                {
                    //  �C�x���g�����Ȃ�_�C�A���O�͋�������
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
        /// <br>Note       :  ���F���p�J�X�^���R���o�[�^�[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
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

        /// <summary>�F�ؕ����񋓌^</summary>
        /// <remarks>�F�ؕ�����\���񋓌^�ł�</remarks>
        [TypeConverter(typeof(EnumConverter))]
        public enum AuthorizationTypes
        {
            /// <summary>����</summary>
            None,
            /// <summary>APOP�^</summary>
            APOP,
            /// <summary>POP3(�ʏ����)�^</summary>
            POP3,
            /// <summary>�����g���C�^</summary>
            Auto
        }

        /// <summary>
        /// AuthorizationInfomation
        /// </summary>
        /// <remarks>
        /// <br>Note       :  ���F���N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 2006.xx.xx �w�w  �w�w</br>
        /// </remarks>
        [TypeConverter(typeof(AuthorizationInfomationClassConverter))]
        public class AuthorizationInfomation
        {
            //  ���F�������ێ��p
            private string mAccount;
            private string mPassWord;
            private AuthorizationTypes mAuthType;

            /// <summary>
            /// AuthorizationInfomation�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : AuthorizationInfomation�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public AuthorizationInfomation()
            {
                mAccount = "";
                mPassWord = "";
                mAuthType = AuthorizationTypes.Auto;
            }

            /// <summary>�F�ؗp�A�J�E���g���v���p�e�B</summary>
            /// <value>�F�؂Ɏg�p����A�J�E���g���E���[�U�[����ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("�F�ؗp�̃A�J�E���g��ݒ肵�܂�(�F�ؕ��@���ʐݒ�)")]
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

            /// <summary>�F�ؗp�p�X���[�h�v���p�e�B</summary>
            /// <value>�F�؂Ɏg�p����p�X���[�h��ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("�F�ؗp�̃p�X���[�h��ݒ肵�܂�(�F�ؕ��@���ʐݒ�)")]
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

            /// <summary>�F�،`���ݒ�v���p�e�B</summary>
            /// <value>�F�،`����ݒ肵�܂�</value>
            /// <remarks></remarks>
            [Description("�F�ؕ��@��ݒ肵�܂�(�����l:Auto)")]
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
        /// <br>Date       : 2006.07.19</br>
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
        /// <br>Note       :  �T�[�o�[���N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        [TypeConverter(typeof(ServerInfomationClassConverter))]
        public class ServerInfomation
        {
            private string mPOPServer;
            private int mPOPPort;
            private int mPOPTimeOut;

            /// <summary>
            /// ServerInfomation�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : ServerInfomation�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
            /// <br>Date       : 2006.07.19</br>
            /// </remarks>
            public ServerInfomation()
            {
                mPOPServer = "";
                mPOPPort = 110;
                mPOPTimeOut = 60;
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
        /// MiniMailMessage
        /// </summary>
        /// <remarks>
        /// <br>Note       :  ���[�����b�Z�[�W�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        private class MiniMailMessage
        {
            //  �������ێ��p
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
        /// <br>Note       :  �g���[�X�I�v�V�����p�J�X�^���R���o�[�^�[�^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
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
        /// <br>Note       :  �g���[�X�I�v�V�����^�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
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
            /// <br>Date       : 2006.07.19</br>
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
            [Category("Option"), Description("�f�o�b�O�p�Ƀg���[�X���O���o�͂��܂�(��ʕ\������)")]
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
            [Category("Option"), Description("�g���[�X���O�̃p�X���w�肵�܂�(�ݒ薳���̏ꍇ�A�J�����g��TPOP.LOG�ŏo�͂���܂�)")]
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
        /// TPOP�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : TPOP�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
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
        /// PopReceiveResult
        /// </summary>
        /// <remarks>
        /// <br>Note       : PopReceiveResult�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.11.20</br>
        /// <br></br>
        /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
        /// </remarks>
        public class PopReceiveResult
        {

            private int mTotalFigure;
            private int mReceiveFigure;

            /// <summary>
            /// PopReceiveResult�N���X�R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// <br>Note       : PopReceiveResult�N���X�R���X�g���N�^</br>
            /// <br>Programmer : 96203 ����@�K��</br>
            /// <br>Date       : 2006.11.20</br>
            /// </remarks>
            public PopReceiveResult()
            {
                mTotalFigure = 0;
                mReceiveFigure = 0;
            }


            /// <summary>��M�Ώی����v���p�e�B</summary>
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

            /// <summary>��M�ό����v���p�e�B</summary>
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
        /// TPOP�N���X�R���X�g���N�^(��ʓ\��t���p)
        /// </summary>
        /// <remarks>
        /// <br>Note       : TPOP�N���X�R���X�g���N�^(��ʓ\��t���p)</br>
        /// <br>Programmer : 96203 ����@�K��</br>
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

            //  POP�R���|�[�l���g�̃C���X�^���X���쐬
            mPop = new Dart.PowerTCP.Mail.Pop();
            //  POP�R���|�[�l���g�̃C�x���g��ݒ�
            mPop.ConnectedChangedEx += new Dart.PowerTCP.Mail.EventHandlerEx(mPop_ConnectedChangedEx);
            mPop.BusyChanged += new EventHandler(mPop_BusyChanged);
            mPop.Progress += new Dart.PowerTCP.Mail.PopProgressEventHandler(mPop_Progress);
            mPop.Trace += new Dart.PowerTCP.Mail.SegmentEventHandler(mPop_Trace);
            mPop.EndGet += new Dart.PowerTCP.Mail.PopEventHandler(mPop_EndGet);
            mPop.EndLogin += new Dart.PowerTCP.Mail.ExceptionEventHandler(mPop_EndLogin);
            mPop.EndLogout += new Dart.PowerTCP.Mail.ExceptionEventHandler(mPop_EndLogout);

            //  Timer�R���|�[�l���g�̃C���X�^���X���쐬
            intTimer = new Timer();
            intTimer.Enabled = false;
            intTimer.Tag = 0;
            //  Timer�R���|�[�l���g�̃C�x���g��ݒ�
            intTimer.Tick += new EventHandler(intTimer_Tick);

        }

        /// <summary>
        /// TPOP�N���X�f�X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : TPOP�N���X�f�X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
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
        /// �҂����Ԃ̊��荞�ݏ����C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �҂����Ԃ̊��荞�ݏ������ɔ������܂�</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void intTimer_Tick(object sender, EventArgs e)
        {

            //  �^�C�}�[��~
            intTimer.Enabled = false;

            //  ���荞�ݔ����ʒm
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
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_ConnectedChangedEx(object sender, EventArgs e)
        {

            //  �X�e�[�^�X�Z�b�g
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  �_�C�A���O�\���L��Ȃ���ʒm
            pWin.AddStatus("POP Before SMTP Connect Status : " + mPop.Connected.ToString(), false);

            //  �C�x���g�L�b�N
            EventHandler<ReceivingEventArgs> h = PopConnectedChangedEx;
            ReceivingEventArgs args = new ReceivingEventArgs(mStatus, mStatusMessage);
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
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_BusyChanged(object sender, EventArgs e)
        {

            //  �X�e�[�^�X�Z�b�g
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  �C�x���g�L�b�N
            EventHandler<ReceivingEventArgs> h = PopBusyChanged;
            ReceivingEventArgs args = new ReceivingEventArgs(mStatus, mStatusMessage);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
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
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_Progress(object sender, Dart.PowerTCP.Mail.PopProgressEventArgs e)
        {

            //  �X�e�[�^�X�Z�b�g
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  ���O�C�����̓v���O���X�\�����Ȃ�(���O�C�����ł��������ʁX�Ƀv���O���X����������P�[�X���L���)
            if (mPahase == 0)
            {
                return;
            }

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  �v���O���X�\���L��Ȃ�ʒm
            if ((mReceivingProgressDialog == true) || (mReceivingTraceOp.Trace == true) || (mDialogConfirm == true))
            {
                pWin.SetProgress((int)e.Position, (int)e.Length);
            }

            //  ���ݍH���ɂ���āA�Ώەϐ��𕪂���
            int NowNo, MaxFig;
            if (mPahase == 0)
            {
                //  ���O�C�����Ȃ�APOP�T�[�o�[�Ɠ���
                NowNo = System.Convert.ToInt32(e.PopMessage.Id);
                MaxFig = mPop.Messages.Length;
            }
            else
            {
                //  �擾���Ȃ�擾�Ώۂ̂�(�t�B���^�[���l��)
                NowNo = mNowProgressIdx;
                MaxFig = mMaxGetMessageFig;
            }

            //  �C�x���g�L�b�N
            EventHandler<ReceivingProgressEventArgs> h = PopProgress;
            ReceivingProgressEventArgs args = new ReceivingProgressEventArgs(NowNo, MaxFig, (int)e.Position, (int)e.Length);
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
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_Trace(object sender, Dart.PowerTCP.Mail.SegmentEventArgs e)
        {

            //  �X�e�[�^�X�Z�b�g
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  �g���[�X�\��
            if (mReceivingTraceOp.Trace == true)
            {
                if (e.Segment != null)
                {
                    pWin.AddStatus("Trace : Segment =>" + e.Segment.ToString().Trim(), mReceivingTraceOp.Trace);
                }
            }

            //  �g���[�X���O�o��(�g���[�X�\���Əo�͕͂ʕ�)
            if ((mReceivingTraceOp.TraceLog == true) && (e.Segment != null))
            {
                mBusyStatus2 = true;                //  �������ɐݒ�
                try
                {
                    // �C�x���g�f�[�^���o�C�g�z����Ɋi�[���܂��B
                    byte[] buffer = System.Text.Encoding.Default.GetBytes(e.Segment.ToString());
                    // FileStream ���쐬���܂��B
                    using (FileStream f = new FileStream(mReceivingTraceOp.TraceLogPath, FileMode.Append))
                    {
                        // �X�g���[���Ƀf�[�^���������݂܂��B
                        f.Write(buffer, 0, buffer.Length);
                        // FileStream ���I�����܂��B
                        f.Close();
                    }
                }
                catch
                { }
                mBusyStatus2 = false;                //  �����I���ɐݒ�
            }

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  �C�x���g�L�b�N
            EventHandler<ReceivingEventArgs> h = PopTrace;
            ReceivingEventArgs args = new ReceivingEventArgs(mStatus, mStatusMessage);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        /// <summary>
        /// ���[���擾�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[���擾���ɔ������܂�(�ݒ莟��ňꌏ�ł��O���ł���������)</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_EndGet(object sender, Dart.PowerTCP.Mail.PopEventArgs e)
        {

            //  �X�e�[�^�X�Z�b�g
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  �擾�o��������(�ꌏ���̉��)
            if (e.Exception == null)
            {
                try
                {
                    //  ���荞�݃^�C�}�[�𔭐�
                    intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                    intTimer.Tag = 0;
                    intTimer.Enabled = true;
                    while (mBusyStatus2 == true)
                    {
                        Application.DoEvents();
                        if ((int)intTimer.Tag == 1)
                        {
                            //  �҂����Ԃ��o�߂��Ă����狭����~
                            throw new Exception("�������ԑ҂��Ń^�C���A�E�g���������܂����B");
                        }

                    }
                    intTimer.Enabled = false;
                    mBusyStatus2 = true;                                        //  �������ɐݒ�
                    //  ���
                    mStatus = AnalyzeMessage(e.PopMessage);
                    mNowMessageID = System.Convert.ToInt32(e.PopMessage.Id);    //  ���ݎ擾���̃��b�Z�[�W��ID(�T�[�o�[�t�^ID)
                    pWin.AddStatus("Receive Analyzing ID = " + mNowMessageIdx.ToString(), false);
                    mBusyStatus2 = false;                                       //  �����I���ɐݒ�
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

            //  ���b�Z�[�W��MAX��������A�I������
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

            //  �C�x���g�L�b�N
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
        /// ���O�C���I���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���O�C���I�����ɔ������܂�(�����ł����s�ł���������)</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_EndLogin(object sender, Dart.PowerTCP.Mail.ExceptionEventArgs e)
        {

            //  �X�e�[�^�X�Z�b�g
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }

            //  ���O�C���o�����猏���ɂ�胁�b�Z�[�W�ȂǕύX
            if (e.Exception == null)
            {
                pWin.AddStatus("POP Login OK", false);

                if (mPop.Messages.Length == 0)
                {
                    //  ���[������
                    mStatus = 1;
                    mStatusMessage = "���ǃ��[���͗L��܂���";
                    pWin.AddStatus("No Message", false);
                    pWin.AddStatus("Receive End", false);
                }
                else
                {
                    //  ���[���L��
                    pWin.AddStatus(mPop.Messages.Length.ToString() + " Messages on Server", false);
                    pWin.AddStatus("Receive Sart", false);
                }
            }
            else
            {
                //  ���O�C���G���[
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
                    //  ���O�A�E�g�����݂�
                    mPop.Logout();
                }
                catch
                { }
            }
            
            //  �����\������p�̕ϐ���������
            mNowMessageIdx = 0;                             //  ���ݎ擾���̃��b�Z�[�W�C���f�b�N�X(���������̔z��p)
            mNowMessageID = 0;                              //  ���ݎ擾���̃��b�Z�[�W��ID(�T�[�o�[�t�^ID)
            mMaxGetMessageFig = 0;                          //  ���ݎ擾�Ώۂ̍ő僁�b�Z�[�W��
            mMaxExtMessageFig = mPop.Messages.Length;       //  ���ݎ擾���̍ő僁�b�Z�[�W��ID(�T�[�o�[�ɑ��݂��鐔)

            //  �C�x���g�L�b�N
            EventHandler<ReceivingLoginEventArgs> h = PopEndLogin;
            ReceivingLoginEventArgs args = new ReceivingLoginEventArgs(mStatus, mStatusMessage, mMaxExtMessageFig);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }

            //  �G���[�����̎��̂݃��O�C����̎擾�������s��
            if (e.Exception == null) 
            {
                if ((mReceivingMailOp.ReceiveType == ReceiveEnumTypes.LogingOnly) || (mReceivingMailOp.MailReceiveType == MailReceiveEnumTypes.None))
                {
                    //  ���O�C���̂݁A�����͎�M�����̏ꍇ�A�����ŏI��
                    pWin.AddStatus("POP Login OK", false);
                }
                else if (mPop.Messages.Length != 0)
                {
                    //  �R���v���[�g�w��ŁA�����[���L��Ȃ烁�b�Z�[�W�擾�J�n
                    pWin.AddStatus("POP Get Message", false);
                    GetMessage();
                }
                else
                {
                    //  ���b�Z�[�W����(�㕔�Őݒ�ς�)
                }
            }

        }

        /// <summary>
        /// ���O�A�E�g�I���C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�����R���g���[��</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���O�A�E�g�I�����ɔ������܂�(�����ł����s�ł���������)</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private void mPop_EndLogout(object sender, Dart.PowerTCP.Mail.ExceptionEventArgs e)
        {
            //  �X�e�[�^�X�Z�b�g
            mConnectedStatus = mPop.Connected;
            mBusyStatus = mPop.Busy;

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ǉ�
            if (mMailOp.ReceiveMethodEnumType == ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                return;
            }


            //  ���O�A�E�g�󋵕\��
            if (e.Exception == null)
            {
                //  ����
                pWin.AddStatus("POP Logout OK", false);
            }
            else
            {
                //  ���s
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

            //  �C�x���g�L�b�N
            EventHandler<ReceivingEventArgs> h = PopEndLogout;
            ReceivingEventArgs args = new ReceivingEventArgs(mStatus, mStatusMessage);
            if (null != h)
            {
                Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                Application.DoEvents();
            }
        }

        //  �v���p�e�B��
        
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
        /// <value>POP�T�[�o�[�Ƃ̒ʐM�󋵂��ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Category("Status"), Description("�R�}���h���s����")]
        [Browsable(false)]
        public bool BusyStatus
        {
            get
            {
                return (mBusyStatus | mBusyStatus2);
            }

        }

        /// <summary>�X�e�[�^�X�R�[�h�v���p�e�B</summary>
        /// <value>�X�e�[�^�X�R�[�h���ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Category("Status"), Description("��M���ʂȂǂ̃X�e�[�^�X�R�[�h")]
        [Browsable(false)]
        public int Status
        {
            get
            {
                return (mStatus);
            }

        }

        /// <summary>�X�e�[�^�X���b�Z�[�W�v���p�e�B</summary>
        /// <value>�X�e�[�^�X���b�Z�[�W���ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Category("Status"), Description("��M���ʂȂǂ̃X�e�[�^�X���b�Z�[�W")]
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
        [Category("Option"), Description("��M�󋵂̃_�C�A���O�\���̐ݒ�����܂�")]
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
        [Category("Option"), Description("�{�^���ł̂݃_�C�A���O����܂�")]
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

        /// <summary>��M���ʃv���p�e�B(�ǂݎ���p)</summary>
        /// <value>���[���̎�M���ʂ��擾���܂�</value>
        /// <remarks></remarks>
        [Browsable(false)]
        public PopReceiveResult PopReceiveResultInfo                                //  2006.11.20  �ǉ�
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
        /// ���[����M����
        /// </summary>
        /// <returns>��M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â��ă��[���̎�M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage()
        {
            //  ����������\�b�h���Ăяo��
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
        /// ���[����M����
        /// </summary>
        /// <param name="message">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <returns>��M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����E�v���p�e�B�ݒ�Ɋ�Â��ă��[���̎�M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress)
        {
            //  ����������\�b�h���Ăяo��                                        //  2006.11.20  �ύX
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
        /// ���[����M����
        /// </summary>
        /// <param name="message">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <returns>��M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����E�v���p�e�B�ݒ�Ɋ�Â��ă��[���̎�M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress, ServerInfomation svrinf)
        {
            //  ����������\�b�h���Ăяo��                                        //  2006.11.20  �ύX
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
        /// ���[����M����
        /// </summary>
        /// <param name="message">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <returns>��M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����E�v���p�e�B�ݒ�Ɋ�Â��ă��[���̎�M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf)
        {
            //  ����������\�b�h���Ăяo��                                        //  2006.11.20  �ύX
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
        /// ���[����M����
        /// </summary>
        /// <param name="message">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <returns>��M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����E�v���p�e�B�ݒ�Ɋ�Â��ă��[���̎�M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp)
        {
            //  ����������\�b�h���Ăяo��                                        //  2006.11.20  �ύX
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
        /// ���[����M����
        /// </summary>
        /// <param name="message">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>��M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[)</returns>
        /// <remarks>
        /// <br>Note       :�����ݒ�Ɋ�Â��ă��[���̎�M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        [STAThread]
        public int ReceiveMessage(MailMessageStreamCollection message, bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {
            //  ����������\�b�h���Ăяo��                                        //  2006.11.20  �ύX
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
        /// ���[���񓯊���M(����)����
        /// </summary>
        /// <param name="message">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>��M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[)</returns>
        /// <remarks>
        /// <br>Note       :���[���̎�M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int ReceiveMessages(MailMessageStreamCollection message, bool ShowProgress, TPOP.ServerInfomation svrinf, TPOP.AuthorizationInfomation authinf, TPOP.MailOption mailOp, TPOP.TraceOption traceOp)
        {

            int nRetCd = 0;
            int nStep = 0;

            //   ���ɏ������Ȃ��M�s��
            if (mPop.Busy == true)
            {
                mStatus = 1;
                mStatusMessage = "���݁A�������ł��B��������s�ł��܂���B";
                return 1;
            }

            //  �󋵕\���ݒ�������p��
            mProgressDialog2 = ShowProgress;                                    //  2006.11.20  �ǉ�

            //  �_�C�A���O�\������
            if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (traceOp.Trace == true) || (mDialogConfirm == true))
            {
                if (pWin.Visible == false)
                {
                    pWin.Show();
                    pWin.SetTitle("��M");
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
                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
            }

            //  ���쒆���[���I�v�V�����Ȃǂ̈��p�����s��
            mReceivingMailOp = mailOp;
            mReceivingProgressDialog = ShowProgress;

            //  ���쒆�g���[�X���[�h�̈��p�����s��
            mReceivingTraceOp = traceOp;
            //  �g���[�X�����O�o�͎w�肪����ꍇ�A���O�t�@�C���������肵�Ă����B
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
                //  �g���[�X
                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
            }


            //  �X�e�[�^�X��������
            mGlobalStatus = null;
            mStatus = 0;
            mStatusMessage = "";
            mMMessages.Clear();

            //  �^�C���A�E�g��ݒ�
            mPop.Timeout = svrinf.POPTimeOut * 1000;

            // �擾���b�Z�[�W���Ɋւ���ϐ������Z�b�g
            mPahase = 0;                //  ���ݍH�� (0:Login,1:GetMessage)
            mNowMessageIdx = 0;         //  ���ݎ擾���̃��b�Z�[�W�C���f�b�N�X(���������̔z��p)
            mNowProgressIdx = 0;        //  
            mNowMessageID = 0;          //  ���ݎ擾���̃��b�Z�[�W��ID(�T�[�o�[�t�^ID)
            mMaxGetMessageFig = 0;      //  ���ݎ擾�Ώۂ̍ő僁�b�Z�[�W��
            mMaxExtMessageFig = 0;      //  ���ݎ擾���̍ő僁�b�Z�[�W��ID(�T�[�o�[�ɑ��݂��鐔)

            mBusyStatus2 = true;            //  �������ɐݒ�

            if (traceOp.Trace == true)
            {
                //  �g���[�X
                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
            }


            //  POP�T�[�o�[�Ƀ��O�C��(�F�؂��K�v�ȏꍇ)
            try
            {
                //  ���̎��_�Ńr�W�[�Ȃ�҂�
                //  ���荞�݃^�C�}�[�𔭐�
                intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                intTimer.Tag = 0;
                intTimer.Enabled = true;
                while (mPop.Busy == true)
                {
                    Application.DoEvents();
                    if ((int)intTimer.Tag == 1)
                    {
                        //  �҂����Ԃ��o�߂��Ă����狭����~
                        throw new Exception("�������ԑ҂��Ń^�C���A�E�g���������܂����B");
                    }
                }
                intTimer.Enabled = false;
                if (traceOp.Trace == true)
                {
                    //  �g���[�X
                    pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
                }

                //  �ڑ��ς݂Ȃ�A��U��������
                if (mPop.Connected == true)
                {
                    mPop.Logout();
                }
                if (traceOp.Trace == true)
                {
                    //  �g���[�X
                    pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
                }

                //  �t�B���^�[��M���[�h�ɏ]���A��M���@��ݒ�
                if (mailOp.FilterMode == MailFilterModes.None)
                {
                    //  ���[����M�^�C�v�ɏ]���׍H������
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
                    //  �g���[�X
                    pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
                }
                //  �ڑ����������擾
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
                //  �G���[
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

            mBusyStatus2 = false;            //  �������ɐݒ�
            return nRetCd;
        }

        /// <summary>
        /// ���[��������M(����)����
        /// </summary>
        /// <param name="message">���[�����b�Z�[�W�R���N�V����</param>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>��M�����L�b�N������(���M���ʂł͖���-0:����,1:BUSY,3:�F�؃G���[)</returns>
        /// <remarks>
        /// <br>Note       :���[���̎�M���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        private int ReceiveMessages2(MailMessageStreamCollection message, bool ShowProgress, TPOP.ServerInfomation svrinf, TPOP.AuthorizationInfomation authinf, TPOP.MailOption mailOp, TPOP.TraceOption traceOp)
        {

            int nRetCd = 0;
            int nStep = 0;

            //   ���ɏ������Ȃ��M�s��
            if (mPop.Busy == true)
            {
                mStatus = 1;
                mStatusMessage = "���݁A�������ł��B��������s�ł��܂���B";
                return 1;
            }

            //  �󋵕\���ݒ�������p��
            mProgressDialog2 = ShowProgress;                                    //  2006.11.20  �ǉ�

            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����                   //  2006.11.20  �ύX
            if (mMailOp.ReceiveMethodEnumType != ReceiveMethodEnumTypes.NoEventSynchronous)
            {
                //  �_�C�A���O�\������
                if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (traceOp.Trace == true) || (mDialogConfirm == true))
                {
                    if (pWin.Visible == false)
                    {
                        pWin.Show();
                        pWin.SetTitle("��M");
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
                    pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);
                }
                mReceivingProgressDialog = ShowProgress;
                //  ���쒆�g���[�X���[�h�̈��p�����s��
                mReceivingTraceOp = traceOp;
            }
            else
            {
                mReceivingProgressDialog = false;
                //  �C�x���g�����Ȃ�_�C�A���O�͋�������
                mDialogConfirm = false;
                //  ���쒆�g���[�X���[�h�̈��p�����s��(�C�x���g�����Ȃ�g���[�X���O�̂݉\�Ƃ���)
                TraceOption top = new TraceOption();
                top.Trace = false;
                top.TraceLog = traceOp.TraceLog;
                top.TraceLogPath = traceOp.TraceLogPath;
                mReceivingTraceOp = top;
            }

            //  ���쒆���[���I�v�V�����Ȃǂ̈��p�����s��
            mReceivingMailOp = mailOp;

            //  �g���[�X�����O�o�͎w�肪����ꍇ�A���O�t�@�C���������肵�Ă����B
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

            //  �X�e�[�^�X��������
            mGlobalStatus = null;
            mStatus = 0;
            mStatusMessage = "";
            mMMessages.Clear();

            //  �^�C���A�E�g��ݒ�
            mPop.Timeout = svrinf.POPTimeOut * 1000;

            // �擾���b�Z�[�W���Ɋւ���ϐ������Z�b�g
            mPahase = 0;                //  ���ݍH�� (0:Login,1:GetMessage)
            mNowMessageIdx = 0;         //  ���ݎ擾���̃��b�Z�[�W�C���f�b�N�X(���������̔z��p)
            mNowProgressIdx = 0;        //  
            mNowMessageID = 0;          //  ���ݎ擾���̃��b�Z�[�W��ID(�T�[�o�[�t�^ID)
            mMaxGetMessageFig = 0;      //  ���ݎ擾�Ώۂ̍ő僁�b�Z�[�W��
            mMaxExtMessageFig = 0;      //  ���ݎ擾���̍ő僁�b�Z�[�W��ID(�T�[�o�[�ɑ��݂��鐔)

            //  ��M���������Z�b�g                                               //  2006.11.20  �ǉ�
            mPopReceiveResult.ReceivetFigure = 0;                               
            mPopReceiveResult.TotalFigure = 0;

            mBusyStatus2 = true;            //  �������ɐݒ�

            //  �g���[�X
            pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);


            //  POP�T�[�o�[�Ƀ��O�C��(�F�؂��K�v�ȏꍇ)
            try
            {
                //  ���̎��_�Ńr�W�[�Ȃ�҂�
                //  ���荞�݃^�C�}�[�𔭐�
                intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                intTimer.Tag = 0;
                intTimer.Enabled = true;
                while (mPop.Busy == true)
                {
                    Application.DoEvents();
                    if ((int)intTimer.Tag == 1)
                    {
                        //  �҂����Ԃ��o�߂��Ă����狭����~
                        throw new Exception("�������ԑ҂��Ń^�C���A�E�g���������܂����B");
                    }
                }
                intTimer.Enabled = false;

                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);

                //  �ڑ��ς݂Ȃ�A��U��������
                if (mPop.Connected == true)
                {
                    mPop.Logout();
                }

                pWin.AddStatus("Receive Ready : Step" + (++nStep), mReceivingTraceOp.Trace);

                //  �t�B���^�[��M���[�h�ɏ]���A��M���@��ݒ�
                if (mailOp.FilterMode == MailFilterModes.None)
                {
                    //  ���[����M�^�C�v�ɏ]���׍H������
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

                //  �ڑ����������擾
                mPop.AutoLogout = false;
                mPop.AutoDelete = false;
                mPop.DoEvents = true;
                pWin.AddStatus("POP Login........", false);
                mPop.Login(svrinf.POPServer, svrinf.POPPort, "", 0, authinf.Account, authinf.PassWord);

                //  ���O�C���o�����猏���ɂ�胁�b�Z�[�W�ȂǕύX
                pWin.AddStatus("POP Login OK", false);

                if (mPop.Messages.Length == 0)
                {
                    //  ���[������
                    mStatus = 1;
                    mStatusMessage = "���ǃ��[���͗L��܂���";
                    pWin.AddStatus("No Message", false);
                    pWin.AddStatus("Receive End", false);
                }
                else
                {
                    //  ���[���L��
                    pWin.AddStatus(mPop.Messages.Length.ToString() + " Messages on Server", false);
                    pWin.AddStatus("Receive Sart", false);

                    //  �����\������p�̕ϐ���������
                    mMaxExtMessageFig = mPop.Messages.Length;       //  ���ݎ擾�����ő僁�b�Z�[�W��ID(�T�[�o�[�ɑ��݂��鐔)
                    mPopReceiveResult.TotalFigure = mMaxExtMessageFig;          //  2006.11.20  �ǉ�

                    if ((mReceivingMailOp.ReceiveType == ReceiveEnumTypes.LogingOnly) || (mReceivingMailOp.MailReceiveType == MailReceiveEnumTypes.None))
                    {
                        //  ���O�C���̂݁A�����͎�M�����̏ꍇ�A�����ŏI��
                        pWin.AddStatus("POP Login OK", false);
                    }
                    else
                    {
                        //  �R���v���[�g�w��ŁA�����[���L��Ȃ烁�b�Z�[�W�擾�J�n
                        pWin.AddStatus("POP Get Message", false);
                        GetMessage2();
                    }
                }
            }
            catch (Exception er)
            {
                //  �G���[
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

            mBusyStatus2 = false;            //  �������ɐݒ�
            return nRetCd;
        }
       
        
        /// <summary>
        ///  �T�[�o�[�ؒf����
        /// </summary>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �T�[�o�[�Ƃ̐ڑ����I�����܂��B�ʐM���ł��ؒf���\�ł��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        public void Logout()
        {
            mGlobalStatus = null;
            try
            {
                //mPop.BeginLogout(mGlobalStatus);                                                  //  2006.11.20  �ύX
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
                }                                                                                   //  2006.11.20  �ύX

            }
            catch(Exception er)
            {
                mStatus = 5;
                mStatusMessage = er.Message;
            }
        }


        /// <summary>
        /// ���b�Z�[�W�擾(�񓯊�)����
        /// </summary>
        /// <returns>�擾����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
       [STAThread]
        private int GetMessage()
        {
            if (mPop.Connected ==  true)
            {
                ArrayList alGet = new ArrayList();

                //  �����폜�@�\����
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
                        //  ���̎��_�Ńr�W�[�Ȃ�҂�
                        //  ���荞�݃^�C�}�[�𔭐�
                        intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                        intTimer.Tag = 0;
                        intTimer.Enabled = true;
                        while ((mPop.Busy == true) || (mBusyStatus2 == true))
                        {
                            Application.DoEvents();
                            if ((int)intTimer.Tag == 1)
                            {
                                //  �҂����Ԃ��o�߂��Ă����狭����~
                                throw new Exception("�������ԑ҂��Ń^�C���A�E�g���������܂����B");
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

                //  ���ݍH�� (0:Login,1:GetMessage)
                mPahase = 1;

                //  ���[���w�b�_�݂̂Ȃ炱���őS�Ă���������
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
                            //  ���b�Z�[�W��MAX��������A�I������
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
                    //  �w�b�_�݂̂̏ꍇ�A�����Ŕ�����
                    return 0;
                }

                nowI = 0;
                for (int i = 0; i < mPop.Messages.Length; i++)
                {
                    try
                    {
                        //  ���̎��_�Ńr�W�[�Ȃ�҂�
                        //  ���荞�݃^�C�}�[�𔭐�
                        intTimer.Interval = mReceivingMailOp.ProcTimeOut * 1000;
                        intTimer.Tag = 0;
                        intTimer.Enabled = true;
                        while ((mPop.Busy == true) || (mBusyStatus2 == true))
                        {
                            Application.DoEvents();
                            if ((int)intTimer.Tag == 1)
                            {
                                //  �҂����Ԃ��o�߂��Ă����狭����~
                                throw new Exception("�������ԑ҂��Ń^�C���A�E�g���������܂����B");
                            }
                        }
                        intTimer.Enabled = false;
                        if ((bool)alGet[i] == true)
                        {
                            ++mNowProgressIdx;                  //  �i���\���p
                            ++nowI;                             //  ���b�Z�[�W�\���p(�K�������i���\����BeginGet�̌�ɐ������Ƃ͌���Ȃ����񓯊�)
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
        /// ���b�Z�[�W�擾(����)����
        /// </summary>
        /// <returns>�擾����</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        [STAThread]
        private int GetMessage2()
        {
            if (mPop.Connected == true)
            {
                ArrayList alGet = new ArrayList();

                //  �����폜�@�\����
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

                //  ����M�������Z�b�g
                mPopReceiveResult.TotalFigure = mMaxGetMessageFig;

                //  ���ݍH�� (0:Login,1:GetMessage)
                mPahase = 1;

                //  ���[���w�b�_�݂̂Ȃ炱���őS�Ă���������
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
                            //  ��M�ς݌������Z�b�g
                            mPopReceiveResult.ReceivetFigure++;
                            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����
                            if (mMailOp.ReceiveMethodEnumType != ReceiveMethodEnumTypes.NoEventSynchronous)
                            {
                                //  ��M�C�x���g����
                                EventHandler<ReceivingGetEndEventArgs> h = PopEndGetMessege;
                                ReceivingGetEndEventArgs args = new ReceivingGetEndEventArgs(mNowMessageIdx, mMaxGetMessageFig, mStatus, mStatusMessage);
                                if (null != h)
                                {
                                    Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                                    Application.DoEvents();
                                }
                            }
                            //  ���b�Z�[�W��MAX��������A�I������
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
                    //  �w�b�_�݂̂̏ꍇ�A�����Ŕ�����
                    return 0;
                }

                nowI = 0;
                for (int i = 0; i < mPop.Messages.Length; i++)
                {
                    try
                    {
                        if ((bool)alGet[i] == true)
                        {
                            ++mNowProgressIdx;                  //  �i���\���p
                            ++nowI;                             //  ���b�Z�[�W�\���p(�K�������i���\����BeginGet�̌�ɐ������Ƃ͌���Ȃ����񓯊�)
                            mGlobalStatus = i;
                            pWin.SetLabelProgress(mNowProgressIdx, mMaxGetMessageFig);
                            pWin.SetProgress((int)0, (int)0);
                            pWin.AddStatus("Receive Mail ID = " + nowI.ToString() + " .....", false);
                            mPop.Messages[i].Get();
                            if (mPop.Messages[i].Exception == null)
                            {
                                pWin.AddStatus("Receive Analyzing ID = " + nowI.ToString(), false);
                                mStatus = AnalyzeMessage(mPop.Messages[i]);
                                mNowMessageID = System.Convert.ToInt32(mPop.Messages[i].Id);    //  ���ݎ擾���̃��b�Z�[�W��ID(�T�[�o�[�t�^ID)
                                //  ��M�ς݌������Z�b�g
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
                            //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����
                            if (mMailOp.ReceiveMethodEnumType != ReceiveMethodEnumTypes.NoEventSynchronous)
                            {
                                //  ��M�C�x���g����
                                EventHandler<ReceivingGetEndEventArgs> h = PopEndGetMessege;
                                ReceivingGetEndEventArgs args = new ReceivingGetEndEventArgs(mNowMessageIdx, mMaxGetMessageFig, mStatus, mStatusMessage);
                                if (null != h)
                                {
                                    Application.OpenForms[0].BeginInvoke(h, new object[] { this, args });
                                    Application.DoEvents();
                                }
                            }
                            //  ���b�Z�[�W��MAX��������A�I������
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
        /// ���b�Z�[�W(�w�b�_��)��̓��C������
        /// </summary>
        /// <param name="pm">���b�Z�[�W�X�g���[��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzeHeader(Dart.PowerTCP.Mail.PopMessage pm)
        {
            int nRtncd = 0;

            MailMessageStream mms = new MailMessageStream();

            //  �����̃��b�Z�[�W��������
            int idx = mMMessages.Add(mms) + 1;

            try
            {

                //  ���M��
                string[] sTo = new string[pm.Message.To.Count];
                for (int i = 0; i < pm.Message.To.Count; i++)
                {
                    sTo[i] = pm.Message.To.ToString();
                }
                if (sTo.Length != 0)
                {
                    mms.To = sTo;
                }
                //  CC���M��
                string[] sCc = new string[pm.Message.CC.Count];
                for (int i = 0; i < pm.Message.CC.Count; i++)
                {
                    sCc[i] = pm.Message.CC.ToString();
                }
                if (sCc.Length != 0)
                {
                    mms.Cc = sCc;
                }
                //  ���M��
                mms.From = pm.Message.From.ToString();
                //  ����
                mms.Subject = pm.Message.Subject;
                //  Date
                mms.Date = pm.Message.Date;


                mNowMessageIdx = idx;                                     //  ���ݎ擾���̃��b�Z�[�W�C���f�b�N�X(���������̔z��p)

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
        /// ���b�Z�[�W��̓��C������
        /// </summary>
        /// <param name="pm">���b�Z�[�W�X�g���[��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzeMessage(Dart.PowerTCP.Mail.PopMessage pm)
        {
            int nRtncd = 0;

            MailMessageStream mms = new MailMessageStream();

            //  �����̃��b�Z�[�W��������
            int idx = mMMessages.Add(mms) + 1;

            //  �Y�t�t�@�C���̊m�F
            if ( pm.Message.Attachments.Count > 0)
            {
                //  �Y�t�擾�L��
                if (mReceivingMailOp.GetAttachmentFile == true)
                {
                    //  �Y�t���t�@�C���ɗ��Ƃ�
                    if (mReceivingMailOp.AttachFileRecvTypes == AttachFileRecvEnumTypes.File)
                    {

                        string[] atFile = new string[pm.Message.Attachments.Count];
                        try
                        {
                            //  �Y�t�t�@�C����

                            //  �f�B���N�g���w�肪�L��΁A�����쐬
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

            //  ���
            MiniMailMessage mm = new MiniMailMessage();
            if (pm.Message.Type.IndexOf("multipart/", StringComparison.OrdinalIgnoreCase) > -1)
            {
                //  �}���`�p�[�g�Ȃ�
                AnalyzePopMessage(pm.Message, ref mm, idx);
            }
            else
            {
                //  �}���`�p�[�g�Ŗ�����Ή�͖����Ō��̃��b�Z�[�W��]�L
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

            //  ���M��
            string[] sTo = new string [pm.Message.To.Count];
            for (int i = 0; i < pm.Message.To.Count; i++)
            {
                sTo[i] = pm.Message.To.ToString();
            }
            if (sTo.Length != 0) 
            {
                mms.To = sTo;
            }
            //  CC���M��
            string[] sCc = new string[pm.Message.CC.Count];
            for (int i = 0; i < pm.Message.CC.Count; i++)
            {
                sCc[i] = pm.Message.CC.ToString();
            }
            if (sCc.Length != 0)
            {
                mms.Cc = sCc;
            }
            //  ���M��
            mms.From =pm.Message.From.ToString();
            //  ����
            mms.Subject = pm.Message.Subject;
            //  Date
            mms.Date = pm.Message.Date;

            //  �}���`�p�[�g����������͂ł��Ȃ��������̎����l���ė\�߃��b�Z�[�W�̖{�����Z�b�g���Ă���
            mms.Text = pm.Message.Text;

            //  PlaneText��HtmlText���𔻒f(�Y�t�t�@�C���͕ʓr�n���h�����O����̂ŁA�����ł͋C�ɂ���K�v������)
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
                //  �摜�t�@�C���Ȃǂ̃����N���𕨗��t�@�C�����Œu��������
                //  ������Ƀf�B���N�g����HTML�t�@�C�������Ƃ�
                try
                {
                    //  �悸�̓����N������������
                    for (int i = 0; i < mm.LinkParts.Count; i++)
                    {
                        mms.AlterText = mm.AlterText.Replace("cid:" + mm.LinkParts[i].ContentID, "file://"+mm.LinkParts[i].LinkPartsPath);
                    }
                    //  HTML�t�@�C���𗎂Ƃ�
                    //  �f�B���N�g���w�肪�L��΁A�����쐬
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
                        //  �{�̃t�@�C���̎d�l�ɍ��킹�ăG���R�[�h����
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

            mNowMessageIdx = idx;                                     //  ���ݎ擾���̃��b�Z�[�W�C���f�b�N�X(���������̔z��p)

            return nRtncd;
        }

        /// <summary>
        /// Pop���b�Z�[�W�X�g���[����͏���
        /// </summary>
        /// <param name="pm">�����b�Z�[�W�X�g���[��</param>
        /// <param name="imm">��͌���</param>
        /// <param name="idx">���[�����b�Z�[�WNo(�����z�񏈗��p)</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzePopMessage(Dart.PowerTCP.Mail.MessageStream pm, ref MiniMailMessage imm, int idx)
        {
            try
            {
                //  ���b�Z�[�W�̐����񂵂Ȃ����͂��s��
                for (int i = 0; i < pm.Parts.Count; i++)
                {
                    if (pm.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessagePartStream))
                    {
                        //  MIME�p�[�c�^�Ȃ�AMIME�\������͂���
                        MiniMailMessage mm = new MiniMailMessage();
                        int retcd = AnalyzePopMessageParts((Dart.PowerTCP.Mail.MessagePartStream)pm.Parts[i], ref mm, idx);
                        if ((mm.ContentType == ContentEnumTypes.TextPlain) || (mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                            {
                            //  �e�L�X�g�n�͖{���Ƃ��Ď󂯓����
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
                            //  �e�L�X�g�n�ȊO�͕t�����Ƃ��Ď󂯓����(��Őe����ContentID����C�ɏ���������)
                            if (retcd == 0)
                            {
                                imm.LinkParts.Add(mm.LinkParts[0]);
                            }
                        }
                    }
                    else if (pm.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessageStream))
                    {
                        //  ���b�Z�[�W�X�g���[���Ȃ烁�b�Z�[�W������q�ɂȂ��ē����Ă���̂ŁA���
                        AnalyzePopMessageStream((Dart.PowerTCP.Mail.MessageStream)pm.Parts[i], ref imm, idx);
                    }
                }
                //  �{���͕K���e���̂��̂�Text�ɓ����Ă��Ȃ�(�A���A�}���`�p�[�g�̏ꍇ�A�����Ⴒ����ɓ���̂ŁA�M���ł��Ȃ�)
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
        /// Pop���b�Z�[�W�X�g���[�����i������͏���
        /// </summary>
        /// <param name="prt">�����b�Z�[�W�X�g���[��</param>
        /// <param name="imm">��͌���</param>
        /// <param name="idx">���[�����b�Z�[�WNo(�����z�񏈗��p)</param>
        /// <returns>��������(�[��:����,1:�Ώۖ���,5:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzePopMessageParts(Dart.PowerTCP.Mail.MessagePartStream prt, ref MiniMailMessage imm, int idx)
        {
            //(�Y�t�t�@�C���͕ʓr�n���h�����O����̂ŁA�����ł͋C�ɂ���K�v������)

            try
            {

                if (prt.ContentType == ContentEnumTypes.TextPlain)
                {
                    //  �e�L�X�g�n�͖{���Ƃ��Ď󂯓����
                    imm.ContentType = prt.ContentType;
                    imm.Text = prt.Text;
                    imm.ContentID = prt.ContentId;
                    imm.FileName = prt.FileName;
                    imm.HtmlPath = "";
                    imm.CharaSet = prt.Charset;
                }
                else if (prt.ContentType == ContentEnumTypes.TextHtml)
                {
                    //  �e�L�X�g�n�͖{���Ƃ��Ď󂯓����
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
                    //  �e�L�X�g�n�͖{���Ƃ��Ď󂯓����
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
                        //  �f�B���N�g���w�肪�L��΁A�����쐬
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
                        //  �摜�t�@�C���n�͓��ʈ���
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
        /// Pop���b�Z�[�W�X�g���[����͏���
        /// </summary>
        /// <param name="prt">�����b�Z�[�W�X�g���[��</param>
        /// <param name="imm">��͌���</param>
        /// <param name="idx">���[�����b�Z�[�WNo(�����z�񏈗��p)</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       :</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.07.19</br>
        /// </remarks>
        private int AnalyzePopMessageStream(Dart.PowerTCP.Mail.MessageStream prt, ref MiniMailMessage imm, int idx)
        {
            //(�Y�t�t�@�C���͕ʓr�n���h�����O����̂ŁA�����ł͋C�ɂ���K�v������)

            try
            {
                //  �f�[�^�������̃p�[�g�ɂ���č\������A�ŏ��̃p�[�g���c��̑S�p�[�g���Q�Ƃ��Ă���
                //  �Ⴆ�΁AHTML�x�[�X�̃f�[�^�ŁA�C���f�b�N�X�[���ɐe��HTML�f�[�^�A�C���f�b�N�X1�ȏ�ɉ摜�Ȃǂ̊֘A�f�[�^�������Ă���
                if (prt.Type == ContentEnumTypes.MultipartRelated)
                {
                    //  �q�f�[�^��ContentID��ۑ����āA��ɐe���̃f�[�^����C�ɏ���������
                    ArrayList lstContentID = new ArrayList();
                    ArrayList lstFileName = new ArrayList();

                    //  �܂�A�����̃p�[�g�ň�̃f�[�^���\�����Ă���̂ŁA��Ăɉ�͂���K�v������
                    //  ���Ȃ݂ɃC���f�b�N�X=�[�����e�f�[�^
                    for (int i = 0; i < prt.Parts.Count; i++)
                    {
                        if (prt.Parts[i].GetType() == typeof(Dart.PowerTCP.Mail.MessagePartStream))
                        {
                            MiniMailMessage mm = new MiniMailMessage();
                            int retcd = AnalyzePopMessageParts((Dart.PowerTCP.Mail.MessagePartStream)prt.Parts[i], ref mm, idx);
                            if ((mm.ContentType == ContentEnumTypes.TextPlain) || (mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                            {
                                //  �߂��Ă������e�͍ŗD��\���Ώ�
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
                                //  �e�L�X�g�n�ȊO�͕t�����Ƃ��Ď󂯓����(��Őe����ContentID����C�ɏ���������)
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
                    //  �S���I�������ContentID����C�ɏ���������
                    //  �\��

                }
                //  ��̃f�[�^��\���̂ɁA�����̕��@�œ���Ă���
                //  �Ⴆ�΁AHTML���[���ŁA�C���f�b�N�X�[���Ƀe�L�X�g��փf�[�^�A�C���f�b�N�X1��HTML(�����͎傽�鉽����)�f�[�^
                else if (prt.Type == ContentEnumTypes.MultipartAlternative)
                {
                    //  �܂�A�����̃p�[�g�ň�̃f�[�^��\���Ă��Ă���
                    //  ���Ȃ݂ɃC���f�b�N�X=�[������փf�[�^(�{���̃f�[�^�\�����@�ɏ]�������̂̓C���f�b�N�X=�[���ȊO�ɓ����Ă���)
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
                                    //  ��֕\���Ώ�
                                    if (mm.ContentType == ContentEnumTypes.TextPlain)
                                    {
                                        //  �[���͑�փe�L�X�g�Ƃ��ē��ʈ���
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
                                    //  �{���̕\���Ώ�(���݂̓[���Ɠ������W�b�N�����A���W�b�N���򂪂��肤��̂ŕʂɂ���)
                                    if (mm.ContentType == ContentEnumTypes.TextPlain)
                                    {
                                        //  �[���͑�փe�L�X�g�Ƃ��ē��ʈ���
                                        imm.Text = mm.Text;
                                    }
                                    else if ((mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                                    {
                                        imm.AlterText = mm.AlterText;
                                    }
                                    //  ContentType��HTML�EXML�R���e���c��D��
                                    imm.ContentType = mm.ContentType;
                                }
                                imm.FileName = mm.FileName;
                                imm.HtmlPath = mm.HtmlPath;
                                imm.CharaSet = mm.CharaSet;
                            }
                            else
                            {
                                //  �e�L�X�g�n�ȊO�͕t�����Ƃ��Ď󂯓����(��Őe����ContentID����C�ɏ���������)
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
                //  ���̑��̃}���`�p�[�g�̓f�[�^��\���̂ɁA�����̕��@�œ���Ă���
                //  �Ⴆ�΁AHTML���[���ŁA�C���f�b�N�X�[���Ƀe�L�X�g��փf�[�^�A�C���f�b�N�X1��HTML(�����͎傽�鉽����)�f�[�^
                else
                {
                    //  �܂�A�����̃p�[�g�ň�̃f�[�^��\���Ă��Ă���
                    //  ���Ȃ݂ɃC���f�b�N�X=�[������փf�[�^(�{���̃f�[�^�\�����@�ɏ]�������̂̓C���f�b�N�X=�[���ȊO�ɓ����Ă���)
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
                                    //  ��֕\���Ώ�
                                    if (mm.ContentType == ContentEnumTypes.TextPlain)
                                    {
                                        //  �[���͑�փe�L�X�g�Ƃ��ē��ʈ���
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
                                    //  �{���̕\���Ώ�(���݂̓[���Ɠ������W�b�N�����A���W�b�N���򂪂��肤��̂ŕʂɂ���)
                                    if (mm.ContentType == ContentEnumTypes.TextPlain)
                                    {
                                        //  �[���͑�փe�L�X�g�Ƃ��ē��ʈ���
                                        imm.Text = mm.Text;
                                    }
                                    else if ((mm.ContentType == ContentEnumTypes.TextHtml) || (mm.ContentType == ContentEnumTypes.TextXml))
                                    {
                                        imm.AlterText = mm.AlterText;
                                    }
                                    //  ContentType��HTML�EXML�R���e���c��D��
                                    imm.ContentType = mm.ContentType;
                                }
                                imm.FileName = mm.FileName;
                                imm.HtmlPath = mm.HtmlPath;
                                imm.CharaSet = mm.CharaSet;
                            }
                            else
                            {
                                //  �e�L�X�g�n�ȊO�͕t�����Ƃ��Ď󂯓����(��Őe����ContentID����C�ɏ���������)
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
        /// POP�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <returns>pop�T�[�o�[�ڑ��`�F�b�N����(0:����,3:POP�F�؃G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���pop�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection()
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(mProgressDialog, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// pop�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <returns>pop�T�[�o�[�ڑ��`�F�b�N����(0:����,3:POP�F�؃G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���pop�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, mServerInfo, mAuthorizationInfo, mMailOp, mTraceOp);

        }

        /// <summary>
        /// pop�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <returns>pop�T�[�o�[�ڑ��`�F�b�N����(0:����,3:POP�F�؃G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���pop�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, svrinf, mAuthorizationInfo, mMailOp, mTraceOp);
        }

        /// <summary>
        /// pop�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <returns>pop�T�[�o�[�ڑ��`�F�b�N����(0:����,3:POP�F�؃G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���pop�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, svrinf, authinf, mMailOp, mTraceOp);
        }

        /// <summary>
        /// pop�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <returns>pop�T�[�o�[�ڑ��`�F�b�N����(0:����,3:POP�F�؃G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���pop�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, svrinf, authinf, mailOp, mTraceOp);
        }

        /// <summary>
        /// pop�T�[�o�[�ڑ��`�F�b�N����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>pop�T�[�o�[�ڑ��`�F�b�N����(0:����,3:POP�F�؃G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���pop�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.11.20</br>
        /// </remarks>
        public int CheckServerConnection(bool ShowProgress, ServerInfomation svrinf, AuthorizationInfomation authinf, MailOption mailOp, TraceOption traceOp)
        {
            //  ����������\�b�h���Ăяo��
            return CheckServerConnections(ShowProgress, svrinf, authinf, mailOp, traceOp);
        }

        /// <summary>
        /// pop�T�[�o�[�ڑ��`�F�b�N(����)����
        /// </summary>
        /// <param name="ShowProgress">�v���O���X�\���ݒ�</param>
        /// <param name="svrinf">�T�[�o�[���N���X�I�u�W�F�N�g</param>
        /// <param name="authinf">�F�؏��N���X�I�u�W�F�N�g</param>
        /// <param name="mailOp">���[���I�v�V�������N���X�I�u�W�F�N�g</param>
        /// <param name="traceOp">�g���[�X���N���X�I�u�W�F�N�g</param>
        /// <returns>pop�T�[�o�[�ڑ��`�F�b�N����(0:����,3:POP�F�؃G���[,9:�G���[)</returns>
        /// <remarks>
        /// <br>Note       :�v���p�e�B�ݒ�Ɋ�Â���pop�T�[�o�[�Ƃ̐ڑ��`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
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

                //  �󋵕\���ݒ�������p��
                mProgressDialog2 = ShowProgress;

                //  �C�x���g�����̏ꍇ�A�g���[�X�����E�_�C�A���O����
                if (mReceivingMailOp.ReceiveMethodEnumType != ReceiveMethodEnumTypes.NoEventSynchronous)
                {
                    //  �_�C�A���O�\������
                    if (((mProgressDialog == true) || (mProgressDialog2 == true)) || (mTraceOp.Trace == true) || (mDialogConfirm == true))
                    {
                        if (pWin.Visible == false)
                        {
                            pWin.Show();
                            pWin.SetTitle("�ڑ��e�X�g");
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
                    //  ���쒆�g���[�X���[�h�̈��p�����s��
                    mReceivingTraceOp = mTraceOp;
                }
                else
                {
                    //  �C�x���g�����Ȃ�_�C�A���O�͋�������
                    mProgressDialog = false;
                    mDialogConfirm = false;
                    //  ���쒆�g���[�X���[�h�̈��p�����s��(�C�x���g�����Ȃ�g���[�X���O�̂݉\�Ƃ���)
                    TraceOption top = new TraceOption();
                    top.Trace = false;
                    top.TraceLog = mTraceOp.TraceLog;
                    top.TraceLogPath = mTraceOp.TraceLogPath;
                    mReceivingTraceOp = top;
                }

                //  �g���[�X�����O�o�͎w�肪����ꍇ�A���O�t�@�C���������肵�Ă����B
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

                //  POP�T�[�o�[�Ƀ��O�C��(�F�؂��K�v�ȏꍇ)
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
                else
                {
                    mStatus = 2;
                    mStatusMessage = "POP�F�؂Ɏ��s���܂���";
                    return 3;
                }
                pWin.AddStatus("POP Server Login Check OK", false);

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

                //  �_�C�A���O�̌�n��
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


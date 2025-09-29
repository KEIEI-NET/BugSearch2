using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace Broadleaf.Library.Net.Mail
{

    /// <summary>
    /// �R���e���g�^�C�v�񋓗p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���e���g�^�C�v�񋓗p�g�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 2006.11.20 ����@�K��</br>
    /// </remarks>
    public static class ContentEnumTypes
    {
        /// <summary>�f�[�^���A�l����ǉ\�ȃe�L�X�g�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string TextPlain = "text/plain";
        /// <summary>�f�[�^�� Microsoft Word �h�L�������g�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ApplicationMsword = "application/msword";
        /// <summary>�f�[�^�� wav �����t�@�C���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string AudioMicrosoftWav = "audio/microsoft-wav";
        /// <summary>application/microsoft-group�ɐݒ�</summary>
        public const string ApplicationMicrosoftGroup = "application/microsoft-group";
        /// <summary>�f�[�^�� zip �G���R�[�h����Ă��邱�Ƃ��Ӗ����܂�</summary>
        public const string ApplicationZip = "application/zip";
        /// <summary>�f�[�^�� Adobe PDF�iPortable Document Format�j�t�@�C���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ApplicationPdf = "application/pdf";
        /// <summary>�f�[�^�� Adobe PostScript �t�@�C���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ApplicationPostscript = "application/postscript";
        /// <summary>�f�[�^�� JPEG �`���̉摜�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ImageJpeg = "image/jpeg";
        /// <summary>�f�[�^�� GIF �`���̉摜�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ImageGif = "image/gif";
        /// <summary>�f�[�^�� TIFF �`���̉摜�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ImageTiff = "image/tiff";
        /// <summary>�f�[�^�� MPEG �`���̃r�f�I�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string VideoMpeg = "video/mpeg";
        /// <summary>�f�[�^�� QuickTime �`���̃r�f�I�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string VideoQuicktime = "video/quicktime";
        /// <summary>�f�[�^�� HTML �`���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string TextHtml = "text/html";
        /// <summary>�v�ɐݒ�f�[�^�� BinHex �G���R�[�h�X�L�[���ɂ���ăG���R�[�h����Ă��邱�Ƃ��Ӗ����܂�</summary>
        public const string ApplicationMacBinhex40 = "application/mac-binhex40";
        /// <summary>�f�[�^�� Microsoft Wordperfect �t�@�C���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ApplicationWordperfect51 = "application/wordperfect5.1";
        /// <summary>�f�[�^�������I�[�f�B�I�`���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string AudioVndQcelp = "audio/vnd.qcelp";
        /// <summary>�f�[�^�� Microsoft Excel �t�@�C���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ApplicationVndMsExcel = "application/vnd.ms-excel";
        /// <summary>�f�[�^�� Microsoft PowerPoint �t�@�C���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string ApplicationVndMsPowerpoint = "application/vnd.ms-powerpoint";
        /// <summary>�f�[�^�� gzip �G���R�[�h����Ă��邱�Ƃ��Ӗ����܂�</summary>
        public const string Application_xGzip = "application/x-gzip";
        /// <summary>�_�E�����[�h���Ƀu���E�U�� [���O��t���ĕۑ�] �_�C�A���O�{�b�N�X��\������悤�Ɏw�肵�܂�</summary>
        public const string ApplicationXMsdownload = "application/x-msdownload";
        /// <summary>�f�[�^�� RFC 822 ���b�Z�[�W�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string Rfc822 = "rfc822";
        /// <summary>�f�[�^�������̃p�[�g�ɂ���č\������A�ŏ��̃p�[�g���c��̑S�p�[�g���Q�Ƃ��Ă��邱�Ƃ��Ӗ����܂�</summary>
        public const string MultipartRelated = "multipart/related";
        /// <summary>�f�[�^�� XML �`���ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string TextXml = "text/xml";
        /// <summary>�f�[�^���J�X�P�[�h�^�X�^�C���V�[�g�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string TextCss = "text/css";
        /// <summary>��M���̔\�͂����f�ł��Ȃ��ꍇ�A�����̃^�C�v�𑗐M���邽�߂ɂ��΂��Ύg�p����܂�</summary>
        public const string MultipartAlternative = "multipart/alternative";
        /// <summary>�f�[�^���A�݂��Ɋ֘A���̂Ȃ��A��\���^�̕����I�u�W�F�N�g�ł��邱�Ƃ��Ӗ����܂�</summary>
        public const string MultipartMixed = "multipart/mixed";
    }

    /// <summary>�Y�t�t�@�C���񋓌^</summary>
    /// <remarks>�Y�t�t�@�C����\���񋓌^�ł�</remarks>
    public enum AttachFileRecvEnumTypes
    {
        /// <summary>�X�g���[���^�n��</summary>
        Stream,
        /// <summary>�t�@�C���p�X�n��</summary>
        File
    }

    /// <summary>���M�����񋓌^</summary>
    /// <remarks>���M�̕�����\���񋓌^�ł�</remarks>
    public enum SendMethodEnumTypes                                             //  2006.11.20 �ǉ�
    {
        /// <summary>�񓯊��^(��ɃC�x���g�L��)</summary>
        Asynchronous,
        /// <summary>�����^(���M�C�x���g�L��)</summary>
        Synchronous,
        /// <summary>�����^(���M�C�x���g����)</summary>
        NoEventSynchronous
    }

    /// <summary>��M�����񋓌^</summary>
    /// <remarks>��M�̕�����\���񋓌^�ł�</remarks>
    public enum ReceiveMethodEnumTypes                                          //  2006.11.20 �ǉ�
    {
        /// <summary>�񓯊��^(��ɃC�x���g�L��)</summary>
        Asynchronous,
        /// <summary>�����^(���M�C�x���g�L��)</summary>
        Synchronous,
        /// <summary>�����^(���M�C�x���g����)</summary>
        NoEventSynchronous
    }

    /// <summary>
    /// Attachment
    /// </summary>
    /// <remarks>
    /// <br>Note       :  �Y�t�t�@�C���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class Attachment
    {
        /// <summary>�Y�t�t�@�C���^</summary>
        public AttachFileRecvEnumTypes AttachFileRecvType;
        /// <summary>�R���e���g�^�C�v(�Y�t�t�@�C���̎��)�^</summary>
        public string ContentType;
        /// <summary>�Y�t�t�@�C���̃X�g���[��</summary>
        public  Stream AttachmentFile;
        /// <summary>�Y�t�t�@�C���̃p�X���</summary>
        public string AttachmentFilePath;

    }

    /// <summary>
    /// AttachmentCollection
    /// </summary>
    /// <remarks>
    /// <br>Note       :  �Y�t�t�@�C�� �R���N�V�����N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class AttachmentCollection : ArrayList
    {
        /// <summary>
        /// AttachmentCollection�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : AttachmentCollection�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public AttachmentCollection()
            : base()
        {
        }


        /// <summary>�Y�t�A�C�e���v���p�e�B</summary>
        /// <value>�Y�t �R���N�V�����̃A�C�e���ł�</value>
        /// <remarks></remarks>
        public Attachment this[int index]
        {
            get
            {
                return ((Attachment)base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

    }

    /// <summary>�Y�t�t�@�C���E�����N�t�@�C���^�C�v�񋓌^</summary>
    /// <remarks>�Y�t�t�@�C���E�����N�t�@�C���^�C�v��\���񋓌^�ł�</remarks>
    public enum LinkPartsEnumTypes
    {
        /// <summary>�X�g���[���^�n��</summary>
        Stream,
        /// <summary>�t�@�C���p�X�n��</summary>
        File
    }

    //  �Y�t�������N�t�@�C��
    /// <summary>
    /// LinkParts
    /// </summary>
    /// <remarks>
    /// <br>Note       :  �Y�t�������N�t�@�C���N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.15</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class LinkParts
    {
        /// <summary>�Y�t�������N�t�@�C���^</summary>
        public LinkPartsEnumTypes LinkPartsType;
        /// <summary>�R���e���g�^�C�v(�t�@�C���̎��)�^</summary>
        public string ContentType;
        /// <summary>�R���e���gID</summary>
        public string ContentID;
        /// <summary>�Y�t�������N�t�@�C�� �X�g���[��</summary>
        public object LinkPartsFile;
        /// <summary>�Y�t�������N�t�@�C�� �p�X</summary>
        public string LinkPartsPath;

    }

    /// <summary>
    /// LinkPartsCollection
    /// </summary>
    /// <remarks>
    /// <br>Note       :  �Y�t�������N�t�@�C�� �R���N�V�����N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.15</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class LinkPartsCollection : ArrayList
    {

        /// <summary>�Y�t�������N�t�@�C���A�C�e���v���p�e�B</summary>
        /// <value>�Y�t�������N�t�@�C�� �R���N�V�����̃A�C�e���ł�</value>
        /// <remarks></remarks>
        public LinkParts this[int index]
        {
            get
            {
                return ((LinkParts)base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

    }

    /// <summary>
    /// MailMessageStreamCollection
    /// </summary>
    /// <remarks>
    /// <br>Note       :  ���[�����b�Z�[�W �R���N�V�����N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class MailMessageStreamCollection : ArrayList
    {
        /// <summary>
        /// AttachmentCollection�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : MailMessageStreamCollection�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public MailMessageStreamCollection()
            : base()
        {
        }


        /// <summary>�Y�t�A�C�e���v���p�e�B</summary>
        /// <value>�Y�t �R���N�V�����̃A�C�e���ł�</value>
        /// <remarks></remarks>
        public MailMessageStream this[int index]
        {
            get
            {
                return ((MailMessageStream)base[index]);
            }
            set
            {
                base[index] = value;
            }
        }


    }


    /// <summary>
    /// MailMessageClassConverter
    /// </summary>
    /// <remarks>
    /// <br>Note       :  ���[�����b�Z�[�W�p�J�X�^���R���o�[�^�[�^�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class MailMessageStreamClassConverter : ExpandableObjectConverter
    {
        /// <summary>�^�ϊ�(���^�֕ϊ�)�\�v���p�e�B</summary>
        /// <value>���^�֕ϊ�����ہA�^���ɕϊ��̉E�s��Ԃ�</value>
        /// <remarks></remarks>
        public override bool CanConvertTo(
            ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(MailMessageStream))
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
            if (destinationType == typeof(string) && value is MailMessageStream)
            {
                try
                {
                    string retval;
                    MailMessageStream mm = (MailMessageStream)value;
                    retval = mm.AlterText + ",";
                    retval = retval + "[";
                    for (int i = 0; i < mm.Bcc.Length; i++)
                    {
                        retval = retval + mm.Bcc[i];
                        if (i < mm.Bcc.Length - 1)
                        {
                            retval = retval + "|";
                        }
                    }
                    retval = retval + "],";
                    retval = retval + "[";
                    for (int i = 0; i < mm.Cc.Length; i++)
                    {
                        retval = retval + mm.Cc[i];
                        if (i < mm.Cc.Length - 1)
                        {
                            retval = retval + "|";
                        }
                    }
                    retval = retval + "],";
                    retval = retval + "[";
                    for (int i = 0; i < mm.FileName.Length; i++)
                    {
                        retval = retval + mm.FileName[i];
                        if (i < mm.FileName.Length - 1)
                        {
                            retval = retval + "|";
                        }
                    }
                    retval = retval + "],";
                    retval = retval + mm.From + ",";
                    retval = retval + mm.HtmlPath + ",";
                    retval = retval + mm.Subject + ",";
                    retval = retval + mm.Text + ",";
                    retval = retval + "[";
                    for (int i = 0; i < mm.To.Length; i++)
                    {
                        retval = retval + mm.To[i];
                        if (i < mm.To.Length - 1)
                        {
                            retval = retval + "|";
                        }
                    }
                    retval = retval + "]";
                    return retval;
                }
                catch (Exception er)
                {
                    throw new ArgumentException("Can not convert '" + (string)value + "' to type MailMessageStream " + er.Message);
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
                    string[] vs = value.ToString().Split(new char[] { ',' }, 9);
                    MailMessageStream mm = new MailMessageStream();
                    mm.AlterText = vs[0];
                    string[] vsBcc = vs[1].ToString().Split(new char[] { '|' }, 512);
                    mm.Bcc = (string[])vsBcc.Clone();
                    string[] vsCc = vs[2].ToString().Split(new char[] { '|' }, 512);
                    mm.Cc = (string[])vsCc.Clone();
                    string[] vsPath = vs[3].ToString().Split(new char[] { '|' }, 512);
                    mm.FileName = (string[])vsPath.Clone();
                    mm.From = vs[4];
                    mm.HtmlPath = vs[5];
                    mm.Subject = vs[6];
                    mm.Text = vs[7];
                    string[] vsTo = vs[8].ToString().Split(new char[] { '|' }, 512);
                    mm.To = (string[])vsTo.Clone();
                    return mm;
                }
                catch (Exception er)
                {
                    throw new ArgumentException("Can not convert '" + (string)value + "' to type MailMessageStream " + er.Message);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }


    /// <summary>
    /// MailMessage
    /// </summary>
    /// <remarks>
    /// <br>Note       :  ���[�����b�Z�[�W�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    [TypeConverter(typeof(MailMessageStreamClassConverter))]
    public class MailMessageStream
    {
        //  �������ێ��p
        private string mSubject;
        private string mAlterText;
        private string mText;
        private string mFrom;
        private string mHtmlPath;
        private string[] mTo;
        private string[] mCc;
        private string[] mBcc;
        private string mContentType;
        private string mContentID;
        private string mDate;
        private string[] mFileName;
        /// <summary>�Y�t�t�@�C�� �R���N�V����</summary>
        public AttachmentCollection AttachFiles;
        /// <summary>�����N�t�@�C�� �R���N�V����</summary>
        public LinkPartsCollection LinkParts;

        /// <summary>
        /// MailMessage�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : MailMessage�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public MailMessageStream()
        {
            mSubject = "";
            mAlterText = "";
            mText = "";
            mFrom = "";
            mContentType = "";
            mContentID = "";
            mDate = "";
            mHtmlPath = "";
            mTo = new string[0];
            mCc = new string[0];
            mBcc = new string[0];

            AttachFiles = new AttachmentCollection();
            LinkParts = new LinkPartsCollection();
        }

        /// <summary>�����v���p�e�B</summary>
        /// <value>������ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("������ݒ肵�܂�")]
        public string Subject
        {
            get
            {
                return (mSubject);
            }
            set
            {
                mSubject = value;
            }
        }

        /// <summary>HTML���[���p�{��(HTML�L�q)�v���p�e�B</summary>
        /// <value>HTML���[���p�{����ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("HTML�^���[����M����HTML���e��ݒ肵�܂�(�����Ă���Ζ{�����D��)")]
        public string AlterText
        {
            get
            {
                return (mAlterText);
            }
            set
            {
                mAlterText = value;
            }
        }

        /// <summary>���[���{���v���p�e�B</summary>
        /// <value>���[���{����ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("�{����ݒ肵�܂�")]
        public string Text
        {
            get
            {
                return (mText);
            }
            set
            {
                mText = value;
            }
        }

        /// <summary>��M�����[���A�h���X�v���p�e�B</summary>
        /// <value>��M�����[���A�h���X��ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("��M�����[���A�h���X��ݒ肵�܂�")]
        public string From
        {
            get
            {
                return (mFrom);
            }
            set
            {
                mFrom = value;
            }
        }

        /// <summary>��M�惁�[���A�h���X�z��v���p�e�B</summary>
        /// <value>��M�惁�[���A�h���X�̔z���ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("��M�惁�[���A�h���X��ݒ肵�܂�(�����ݒ��)")]
        public String[] To
        {
            get
            {
                return (mTo);
            }
            set
            {
                mTo = value;
            }
        }

        /// <summary>CC��M�惁�[���A�h���X�z��v���p�e�B</summary>
        /// <value>CC��M�惁�[���A�h���X�̔z���ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("CC��M�惁�[���A�h���X��ݒ肵�܂�(�����ݒ��)")]
        public String[] Cc
        {
            get
            {
                return (mCc);
            }
            set
            {
                mCc = value;
            }
        }

        /// <summary>BCC���M�惁�[���A�h���X�z��v���p�e�B</summary>
        /// <value>BCC���M�惁�[���A�h���X�̔z���ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("BCC���M�惁�[���A�h���X��ݒ肵�܂�(��M���͎Q�ƕs��)")]
        public String[] Bcc
        {
            get
            {
                return (mBcc);
            }
            set
            {
                mBcc = value;
            }
        }

        /// <summary>ContentType�v���p�e�B</summary>
        /// <value>ContentType���ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Description("��M�������[���̎�R���e���c���")]
        public string ContentType
        {
            get
            {
                return (mContentType);
            }
            set
            {
                mContentType = value;
            }
        }

        /// <summary>ContentID�v���p�e�B</summary>
        /// <value>ContentID���ݒ肳��܂�</value>
        /// <remarks></remarks>
        [Description("��M���ɂ͎g�p����܂���")]
        public string ContentID
        {
            get
            {
                return (mContentID);
            }
            set
            {
                mContentID = value;
            }
        }

        /// <summary>HTML���[���\�[�X�p�X�v���p�e�B</summary>
        /// <value>HTML���[���̌��ɂȂ�\�[�X�̃p�X��ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("HTML���[���̌��ƂȂ�HTML�\�[�X���p�X�w��Őݒ肵�܂�")]
        public string HtmlPath
        {
            get
            {
                return (mHtmlPath);
            }
            set
            {
                mHtmlPath = value;
            }
        }

        /// <summary>HTML���[���\�[�X�p�X�v���p�e�B</summary>
        /// <value>HTML���[���̌��ɂȂ�\�[�X�̃p�X��ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("��M������ݒ肵�܂�(�ʏ�̓��t�`���ł͖����̂Œ���)")]
        public string Date
        {
            get
            {
                return (mDate);
            }
            set
            {
                mDate = value;
            }
        }

        /// <summary>�Y�t�t�@�C���p�X�̔z��v���p�e�B</summary>
        /// <value>�Y�t�t�@�C���p�X�̔z���ݒ肵�܂�</value>
        /// <remarks></remarks>
        [Description("�Y�t�t�@�C���p�X��ݒ肵�܂�(������)")]
        public string[] FileName
        {
            get
            {
                return (mFileName);
            }
            set
            {
                mFileName = value;
            }
        }


    }

}

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
    /// コンテントタイプ列挙用クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンテントタイプ列挙用トクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 2006.11.20 鹿野　幸生</br>
    /// </remarks>
    public static class ContentEnumTypes
    {
        /// <summary>データが、人が解読可能なテキストであることを意味します</summary>
        public const string TextPlain = "text/plain";
        /// <summary>データが Microsoft Word ドキュメントであることを意味します</summary>
        public const string ApplicationMsword = "application/msword";
        /// <summary>データが wav 音声ファイルであることを意味します</summary>
        public const string AudioMicrosoftWav = "audio/microsoft-wav";
        /// <summary>application/microsoft-groupに設定</summary>
        public const string ApplicationMicrosoftGroup = "application/microsoft-group";
        /// <summary>データが zip エンコードされていることを意味します</summary>
        public const string ApplicationZip = "application/zip";
        /// <summary>データが Adobe PDF（Portable Document Format）ファイルであることを意味します</summary>
        public const string ApplicationPdf = "application/pdf";
        /// <summary>データが Adobe PostScript ファイルであることを意味します</summary>
        public const string ApplicationPostscript = "application/postscript";
        /// <summary>データが JPEG 形式の画像であることを意味します</summary>
        public const string ImageJpeg = "image/jpeg";
        /// <summary>データが GIF 形式の画像であることを意味します</summary>
        public const string ImageGif = "image/gif";
        /// <summary>データが TIFF 形式の画像であることを意味します</summary>
        public const string ImageTiff = "image/tiff";
        /// <summary>データが MPEG 形式のビデオであることを意味します</summary>
        public const string VideoMpeg = "video/mpeg";
        /// <summary>データが QuickTime 形式のビデオであることを意味します</summary>
        public const string VideoQuicktime = "video/quicktime";
        /// <summary>データが HTML 形式であることを意味します</summary>
        public const string TextHtml = "text/html";
        /// <summary>」に設定データが BinHex エンコードスキームによってエンコードされていることを意味します</summary>
        public const string ApplicationMacBinhex40 = "application/mac-binhex40";
        /// <summary>データが Microsoft Wordperfect ファイルであることを意味します</summary>
        public const string ApplicationWordperfect51 = "application/wordperfect5.1";
        /// <summary>データが音声オーディオ形式であることを意味します</summary>
        public const string AudioVndQcelp = "audio/vnd.qcelp";
        /// <summary>データが Microsoft Excel ファイルであることを意味します</summary>
        public const string ApplicationVndMsExcel = "application/vnd.ms-excel";
        /// <summary>データが Microsoft PowerPoint ファイルであることを意味します</summary>
        public const string ApplicationVndMsPowerpoint = "application/vnd.ms-powerpoint";
        /// <summary>データが gzip エンコードされていることを意味します</summary>
        public const string Application_xGzip = "application/x-gzip";
        /// <summary>ダウンロード時にブラウザが [名前を付けて保存] ダイアログボックスを表示するように指定します</summary>
        public const string ApplicationXMsdownload = "application/x-msdownload";
        /// <summary>データが RFC 822 メッセージであることを意味します</summary>
        public const string Rfc822 = "rfc822";
        /// <summary>データが複数のパートによって構成され、最初のパートが残りの全パートを参照していることを意味します</summary>
        public const string MultipartRelated = "multipart/related";
        /// <summary>データが XML 形式であることを意味します</summary>
        public const string TextXml = "text/xml";
        /// <summary>データがカスケード型スタイルシートであることを意味します</summary>
        public const string TextCss = "text/css";
        /// <summary>受信側の能力が判断できない場合、複数のタイプを送信するためにしばしば使用されます</summary>
        public const string MultipartAlternative = "multipart/alternative";
        /// <summary>データが、互いに関連性のない、非構造型の複数オブジェクトであることを意味します</summary>
        public const string MultipartMixed = "multipart/mixed";
    }

    /// <summary>添付ファイル列挙型</summary>
    /// <remarks>添付ファイルを表す列挙型です</remarks>
    public enum AttachFileRecvEnumTypes
    {
        /// <summary>ストリーム型渡し</summary>
        Stream,
        /// <summary>ファイルパス渡し</summary>
        File
    }

    /// <summary>送信方式列挙型</summary>
    /// <remarks>送信の方式を表す列挙型です</remarks>
    public enum SendMethodEnumTypes                                             //  2006.11.20 追加
    {
        /// <summary>非同期型(常にイベント有り)</summary>
        Asynchronous,
        /// <summary>同期型(送信イベント有り)</summary>
        Synchronous,
        /// <summary>同期型(送信イベント無し)</summary>
        NoEventSynchronous
    }

    /// <summary>受信方式列挙型</summary>
    /// <remarks>受信の方式を表す列挙型です</remarks>
    public enum ReceiveMethodEnumTypes                                          //  2006.11.20 追加
    {
        /// <summary>非同期型(常にイベント有り)</summary>
        Asynchronous,
        /// <summary>同期型(送信イベント有り)</summary>
        Synchronous,
        /// <summary>同期型(送信イベント無し)</summary>
        NoEventSynchronous
    }

    /// <summary>
    /// Attachment
    /// </summary>
    /// <remarks>
    /// <br>Note       :  添付ファイルクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class Attachment
    {
        /// <summary>添付ファイル型</summary>
        public AttachFileRecvEnumTypes AttachFileRecvType;
        /// <summary>コンテントタイプ(添付ファイルの種類)型</summary>
        public string ContentType;
        /// <summary>添付ファイルのストリーム</summary>
        public  Stream AttachmentFile;
        /// <summary>添付ファイルのパス情報</summary>
        public string AttachmentFilePath;

    }

    /// <summary>
    /// AttachmentCollection
    /// </summary>
    /// <remarks>
    /// <br>Note       :  添付ファイル コレクションクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class AttachmentCollection : ArrayList
    {
        /// <summary>
        /// AttachmentCollectionクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : AttachmentCollectionクラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public AttachmentCollection()
            : base()
        {
        }


        /// <summary>添付アイテムプロパティ</summary>
        /// <value>添付 コレクションのアイテムです</value>
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

    /// <summary>添付ファイル・リンクファイルタイプ列挙型</summary>
    /// <remarks>添付ファイル・リンクファイルタイプを表す列挙型です</remarks>
    public enum LinkPartsEnumTypes
    {
        /// <summary>ストリーム型渡し</summary>
        Stream,
        /// <summary>ファイルパス渡し</summary>
        File
    }

    //  添付＆リンクファイル
    /// <summary>
    /// LinkParts
    /// </summary>
    /// <remarks>
    /// <br>Note       :  添付＆リンクファイルクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.15</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class LinkParts
    {
        /// <summary>添付＆リンクファイル型</summary>
        public LinkPartsEnumTypes LinkPartsType;
        /// <summary>コンテントタイプ(ファイルの種類)型</summary>
        public string ContentType;
        /// <summary>コンテントID</summary>
        public string ContentID;
        /// <summary>添付＆リンクファイル ストリーム</summary>
        public object LinkPartsFile;
        /// <summary>添付＆リンクファイル パス</summary>
        public string LinkPartsPath;

    }

    /// <summary>
    /// LinkPartsCollection
    /// </summary>
    /// <remarks>
    /// <br>Note       :  添付＆リンクファイル コレクションクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.15</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class LinkPartsCollection : ArrayList
    {

        /// <summary>添付＆リンクファイルアイテムプロパティ</summary>
        /// <value>添付＆リンクファイル コレクションのアイテムです</value>
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
    /// <br>Note       :  メールメッセージ コレクションクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class MailMessageStreamCollection : ArrayList
    {
        /// <summary>
        /// AttachmentCollectionクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : MailMessageStreamCollectionクラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.07.19</br>
        /// </remarks>
        public MailMessageStreamCollection()
            : base()
        {
        }


        /// <summary>添付アイテムプロパティ</summary>
        /// <value>添付 コレクションのアイテムです</value>
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
    /// <br>Note       :  メールメッセージ用カスタムコンバータータクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class MailMessageStreamClassConverter : ExpandableObjectConverter
    {
        /// <summary>型変換(他型へ変換)可能プロパティ</summary>
        /// <value>他型へ変換する際、型毎に変換の可・不可を返す</value>
        /// <remarks></remarks>
        public override bool CanConvertTo(
            ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(MailMessageStream))
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
    /// <br>Note       :  メールメッセージクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.07.19</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    [TypeConverter(typeof(MailMessageStreamClassConverter))]
    public class MailMessageStream
    {
        //  内部情報保持用
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
        /// <summary>添付ファイル コレクション</summary>
        public AttachmentCollection AttachFiles;
        /// <summary>リンクファイル コレクション</summary>
        public LinkPartsCollection LinkParts;

        /// <summary>
        /// MailMessageクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : MailMessageクラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
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

        /// <summary>件名プロパティ</summary>
        /// <value>件名を設定します</value>
        /// <remarks></remarks>
        [Description("件名を設定します")]
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

        /// <summary>HTMLメール用本文(HTML記述)プロパティ</summary>
        /// <value>HTMLメール用本文を設定します</value>
        /// <remarks></remarks>
        [Description("HTML型メール受信時にHTML内容を設定します(入っていれば本文より優先)")]
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

        /// <summary>メール本文プロパティ</summary>
        /// <value>メール本文を設定します</value>
        /// <remarks></remarks>
        [Description("本文を設定します")]
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

        /// <summary>受信元メールアドレスプロパティ</summary>
        /// <value>受信元メールアドレスを設定します</value>
        /// <remarks></remarks>
        [Description("受信元メールアドレスを設定します")]
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

        /// <summary>受信先メールアドレス配列プロパティ</summary>
        /// <value>受信先メールアドレスの配列を設定します</value>
        /// <remarks></remarks>
        [Description("受信先メールアドレスを設定します(複数設定可)")]
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

        /// <summary>CC受信先メールアドレス配列プロパティ</summary>
        /// <value>CC受信先メールアドレスの配列を設定します</value>
        /// <remarks></remarks>
        [Description("CC受信先メールアドレスを設定します(複数設定可)")]
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

        /// <summary>BCC送信先メールアドレス配列プロパティ</summary>
        /// <value>BCC送信先メールアドレスの配列を設定します</value>
        /// <remarks></remarks>
        [Description("BCC送信先メールアドレスを設定します(受信時は参照不可)")]
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

        /// <summary>ContentTypeプロパティ</summary>
        /// <value>ContentTypeが設定されます</value>
        /// <remarks></remarks>
        [Description("受信したメールの主コンテンツ種類")]
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

        /// <summary>ContentIDプロパティ</summary>
        /// <value>ContentIDが設定されます</value>
        /// <remarks></remarks>
        [Description("受信時には使用されません")]
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

        /// <summary>HTMLメールソースパスプロパティ</summary>
        /// <value>HTMLメールの元になるソースのパスを設定します</value>
        /// <remarks></remarks>
        [Description("HTMLメールの元となるHTMLソースをパス指定で設定します")]
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

        /// <summary>HTMLメールソースパスプロパティ</summary>
        /// <value>HTMLメールの元になるソースのパスを設定します</value>
        /// <remarks></remarks>
        [Description("受信日時を設定します(通常の日付形式では無いので注意)")]
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

        /// <summary>添付ファイルパスの配列プロパティ</summary>
        /// <value>添付ファイルパスの配列を設定します</value>
        /// <remarks></remarks>
        [Description("添付ファイルパスを設定します(複数可)")]
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

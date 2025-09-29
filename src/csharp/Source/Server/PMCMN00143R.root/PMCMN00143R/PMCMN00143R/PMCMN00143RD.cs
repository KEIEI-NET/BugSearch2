//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώێ����X�V�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώێ����X�V���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;
using System.Xml;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���o�[�g�Ώێ����X�VWebRequest
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώێ����X�VWebRequest</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjDBWebRequest
    {
        #region �񋓑�

        /// <summary>
        /// WebRequest Check Param
        /// </summary>
        public enum WebReqChkPrm
        {
            /// <summary>Unauthorized Access Pt0</summary>
            UnauthorizedAccessPt0 = 0
          , /// <summary>Unauthorized Access Pt1</summary>
            UnauthorizedAccessPt1 = 1
        };

        #endregion //�񋓑�

        #region �萔

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00143R_WebRequestSetting.xml";

        /// <summary>
        /// ���g���C��
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 1;

        /// <summary>
        /// ���g���C�Ԋu(�~���b)
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 1;

        /// <summary>
        /// WEBRequest�^�C���A�E�g�i�~���b�j
        /// </summary>
        private const int WEB_REQUEST_TIMEOUT = 1;

        /// <summary>
        /// WEBRequest ENCODING
        /// </summary>
        private const string WEB_REQUEST_ENCODING = "utf-8";

        /// <summary>
        /// WEBRequest URL
        /// </summary>
        private const string WEB_REQUEST_URL = "https://accs.broadleaf.co.jp/partsman/access/check/request";

        /// <summary>
        /// WEBRequest METHOD
        /// </summary>
        private const string WEB_REQUEST_METHOD = "POST";

        /// <summary>
        /// WEBRequest CONTENTTYPE
        /// </summary>
        private const string WEB_REQUEST_CONTENTTYPE = "application/json";

        /// <summary>
        /// WEBRequest HEADERS KEY
        /// </summary>
        private const string WEB_REQUEST_HEADERS_KEY = "bl-api-access-param";

        /// <summary>
        /// WEBRequest HEADERS VALUE
        /// </summary>
        private const string WEB_REQUEST_HEADERS_VALUE = "Unauthorized";

        /// <summary>
        /// WEBRequest PARAM
        /// </summary>
        private const string WEB_REQUEST_PARAM = "access = \"check\"";

        #endregion // �萔

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// ���g���C��
        /// </summary>
        private int _retryCount;

        /// <summary>
        /// ���g���C�Ԋu(�~���b)
        /// </summary>
        private int _retryInterval;

        /// <summary>
        /// WEBRequest�^�C���A�E�g�i�~���b�j
        /// </summary>
        private int _webRequestTimeout;

        /// <summary>
        /// WEBRequest ENCODING
        /// </summary>
        private string _webRequestEncoding;

        /// <summary>
        /// WEBRequest URL
        /// </summary>
        private string _webRequestUrl;

        /// <summary>
        /// WEBRequest METHOD
        /// </summary>
        private string _webRequestMethod;

        /// <summary>
        /// WEBRequest CONTENTTYPE
        /// </summary>
        private string _webRequestContentType;

        /// <summary>
        /// WEBRequest HEADERS KEY
        /// </summary>
        private string _webRequestHeadersKey;

        /// <summary>
        /// WEBRequest HEADERS VALUE
        /// </summary>
        private string _webRequestHeadersValue;

        /// <summary>
        /// WEBRequest PARAM
        /// </summary>
        private string _webRequestParam;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώێ����X�VWebRequest
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjDBWebRequest()
        {
            try
            {
                #region �ݒ�t�@�C���擾

                // �����l�ݒ�
                _retryCount = RETRY_COUNT_DEFAULT;                      // ���g���C��
                _retryInterval = RETRY_INTERVAL_DEFAULT;                // ���g���C�Ԋu(�~���b)
                _webRequestTimeout = WEB_REQUEST_TIMEOUT;               // WEBRequest�^�C���A�E�g�i�~���b�j
                _webRequestEncoding = WEB_REQUEST_ENCODING;             // WEBRequest ENCODING
                _webRequestUrl = WEB_REQUEST_URL;                       // WEBRequest URL
                _webRequestMethod = WEB_REQUEST_METHOD;                 // WEBRequest METHOD
                _webRequestContentType = WEB_REQUEST_CONTENTTYPE;       // WEBRequest CONTENTTYPE
                _webRequestHeadersKey = WEB_REQUEST_HEADERS_KEY;        // WEBRequest HEADERS KEY
                _webRequestHeadersValue = WEB_REQUEST_HEADERS_VALUE;    // WEBRequest HEADERS VALUE
                _webRequestParam = WEB_REQUEST_PARAM;                   // WEBRequest PARAM

                string fileName = this.InitializeXmlSettings();

                if (fileName != string.Empty)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    try
                    {
                        using (XmlReader reader = XmlReader.Create(fileName, settings))
                        {
                            while (reader.Read())
                            {
                                if (reader.IsStartElement("RetryCount")) _retryCount = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("RetryInterval")) _retryInterval = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("WebRequestTimeout")) _webRequestTimeout = reader.ReadElementContentAsInt();
                                if (reader.IsStartElement("WebRequestEncoding")) _webRequestEncoding = reader.ReadElementContentAsString();
                                if (reader.IsStartElement("WebRequestUrl")) _webRequestUrl = reader.ReadElementContentAsString();
                                if (reader.IsStartElement("WebRequestMethod")) _webRequestMethod = reader.ReadElementContentAsString();
                                if (reader.IsStartElement("WebRequestContentType")) _webRequestContentType = reader.ReadElementContentAsString();
                                if (reader.IsStartElement("WebRequestHeadersKey")) _webRequestHeadersKey = reader.ReadElementContentAsString();
                                if (reader.IsStartElement("WebRequestHeadersValue")) _webRequestHeadersValue = reader.ReadElementContentAsString();
                                if (reader.IsStartElement("WebRequestParam")) _webRequestParam = reader.ReadElementContentAsString();
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                #endregion // �ݒ�t�@�C���擾

            }
            catch
            {
            }
        }

        #endregion //�R���X�g���N�^

        #region �R���o�[�g�Ώێ����X�VWebRequest
        /// <summary>
        /// �R���o�[�g�Ώێ����X�VWebRequest
        /// </summary>
        /// <param name="checkParam">�`�F�b�N�p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώێ����X�V���܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjDBWebReqRes(int checkParam)
        {
            int status = (int)ConvObjDBParam.StatusCode.Normal;

            int retryCnt = 0;

            try
            {
                HttpWebRequest req = null;
                HttpWebResponse res = null;
                Stream srm = null;
                StreamWriter swr = null;
                StreamReader srr = null;
                string strHtml = string.Empty;

                // ����I������܂Ń��g���C�񐔕����g���C����
                while (retryCnt < _retryCount)
                {
                    // ���g���C��wait����
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(_retryInterval);
                    }

                    try
                    {
                        req = (HttpWebRequest)WebRequest.Create(_webRequestUrl);
                        req.Timeout = _webRequestTimeout;  // �^�C���A�E�g(�~���b)
                        req.ContentType = _webRequestContentType;
                        req.Method = _webRequestMethod;
                        req.Headers.Add("bl-api-unauthorized-param", checkParam.ToString());
                        req.Headers.Add(_webRequestHeadersKey, _webRequestHeadersValue);    // �J�X�^���w�b�_

                        using (swr = new StreamWriter(req.GetRequestStream()))
                        {
                            swr.Write(_webRequestParam);
                        }

                        res = (HttpWebResponse)req.GetResponse();
                        if (res.StatusCode != HttpStatusCode.OK)
                        {
                        }
                        else
                        {
                            srr = new StreamReader(res.GetResponseStream(), Encoding.GetEncoding(_webRequestEncoding));
                            strHtml = srr.ReadToEnd();
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (srr != null)
                        {
                            srr.Close();
                            srr.Dispose();
                        }

                        if (srm != null)
                        {
                            srm.Close();
                            srm.Dispose();
                        }

                        if (res != null)
                        {
                            res.Close();
                        }
                    }

                    if (status == (int)ConvObjDBParam.StatusCode.Normal)
                    {
                        // ����I���̂��߃��g���C���Ȃ�
                        break;
                    }
                
                    retryCnt += 1;
                }
            }
            catch
            {
            }
            finally
            {
            }
        
            return status;
        }

        #endregion //�R���o�[�g�Ώێ����X�VWebRequest

        #region �� Private Methods

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C���ݒ���擾����
        /// �t�@�C�������݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch
            {
                //���O�o��
            }

            return path;
        }
        #endregion  //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�̃p�X�擾
        /// �t�H���_�����݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g��
                        // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch
            {
                //���O�o��
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // �J�����g�t�H���_

        #endregion // �� Private Methods


    }
}

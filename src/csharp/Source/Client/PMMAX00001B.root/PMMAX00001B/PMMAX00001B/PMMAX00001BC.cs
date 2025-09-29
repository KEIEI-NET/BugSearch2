using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

using Newtonsoft.Json;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public class BuhinMaxRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public enum MAX_Status
        {
            /// <summary>����</summary>
            ct_NORMAL = 0,
            /// <summary>�ꕔ�o�^���s</summary>
            ct_SOME_FAIL = 5,
            /// <summary>���s��</summary>
            ct_RUN = 100,
            /// <summary>�V�X�e����O</summary>
            ct_SYS_ERROR = 1000,
            /// <summary>�N���C�A���g�ڑ��G���[</summary>
            ct_CNT_ERROR = 400,
            /// <summary>�T�[�o�[�ڑ��G���[</summary>
            ct_SVR_ERROR = 500,
            /// <summary>�F�؃G���[</summary>
            ct_AUT_ERROR = 403,
        }

        private const string ct_BuhinMaxUrlInfoFile = "PMMAX00001B_Info.XML"; // �ݒ�t�@�C��

        #region URL�ݒ�t�@�C���Ǎ�[DecryptFile]
        /// <summary>
        /// XML�擾�i�������j����
        /// </summary>
        /// <param name="buhinMaxUrlInfo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int DecryptFile(out BuhinMaxUrlInfo buhinMaxUrlInfo, out string message)
        {
            int status = (int)MAX_Status.ct_SYS_ERROR;
            message = string.Empty;

            // �������x�N�^
            byte[] InitVector = Encoding.Default.GetBytes("Partsman");
            // ���E���h�L�[�e�[�u��
            byte[] Key = Encoding.Default.GetBytes("Partsman13571357");

            buhinMaxUrlInfo = new BuhinMaxUrlInfo();

            System.IO.FileStream inFs = null;
            System.Security.Cryptography.ICryptoTransform decryptor = null;
            System.Security.Cryptography.CryptoStream cryptStrm = null;
            string sourceFile = string.Empty;
            try
            {
                sourceFile = System.Windows.Forms.Application.StartupPath + "\\" + ct_BuhinMaxUrlInfoFile;
                if (!System.IO.File.Exists(sourceFile))
                {
                    throw new FileNotFoundException();
                }

                TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();

                //���L�L�[�Ə������x�N�^��ݒ�
                des3.IV = InitVector;
                des3.Key = Key;

                //�Í������ꂽ�t�@�C����ǂݍ��ނ��߂�FileStream
                inFs = new System.IO.FileStream(sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                //�Ώ̕������I�u�W�F�N�g�̍쐬
                decryptor = des3.CreateDecryptor();

                //�Í������ꂽ�f�[�^��ǂݍ��ނ��߂�CryptoStream�̍쐬
                cryptStrm = new System.Security.Cryptography.CryptoStream(inFs, decryptor, System.Security.Cryptography.CryptoStreamMode.Read);

                //
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(BuhinMaxUrlInfo));

                buhinMaxUrlInfo = (BuhinMaxUrlInfo)serializer.Deserialize(cryptStrm);

                status = (int)MAX_Status.ct_NORMAL;
            }
            catch (System.IO.FileNotFoundException)
            {
                // �t�@�C�������݂��Ȃ��ꍇ�̓G���[�Ƃ���
                message = "���iMAX�ڑ�����t�@�C��������܂���B";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                //����
                if (cryptStrm != null) cryptStrm.Close();
                if (decryptor != null) decryptor.Dispose();
                if (inFs != null) inFs.Close();
            }
            return status;
        }
        #endregion URL�ݒ�t�@�C���Ǎ�[DecryptFile]

        #region ���iMAX���O�C������
        /// <summary>
        /// ���iMAX�Ƀ��O�C������
        /// </summary>
        /// <param name="loginID">�F��ID</param>
        /// <param name="password">�F�؃p�X���[�h</param>
        /// <param name="url">�F�؃p�X���[�h</param>
        /// <param name="cc">�N�b�L�[</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns></returns>
        public int LoginBuhinMax(string loginID, string password, string url, ref CookieContainer cc, out string message)
        {
            int status = (int)MAX_Status.ct_SYS_ERROR;

            message = string.Empty;
            try
            {
                string param = "";

                // ���O�C���E�y�[�W�ւ̃A�N�Z�X
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic["id"] = loginID;
                dic["pwd"] = password;

                // POST���\�b�h�̃p�����[�^�쐬
                foreach (string key in dic.Keys)
                    param += String.Format("{0}={1}&", key, dic[key]);

                // param��ASCII������ɃG���R�[�h����
                byte[] data = Encoding.ASCII.GetBytes(param);

                // ���N�G�X�g�̍쐬
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                //���\�b�h��POST���w��
                req.Method = "POST";
                //ContentType��ݒ�
                req.ContentType = "application/x-www-form-urlencoded";
                //POST���M����f�[�^�̒������w��
                req.ContentLength = data.Length;
                //�N�b�L�[�R���e�i
                req.CookieContainer = cc;
                //�ǂݏ����^�C���A�E�g����
                req.ReadWriteTimeout = 60000;
                //�^�C���A�E�g����
                req.Timeout = 60000;

#if DEBUG
                // �f�o�b�O���̂�
                // ���N�G�X�g�𓊂���O�ɍs��
                if (ServicePointManager.ServerCertificateValidationCallback == null)
                {
                    ServicePointManager.ServerCertificateValidationCallback += delegate(Object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;	// �������ŃI���I���ؖ���M�p����B�댯�I(sender��URI�Ƃ����ׂă`�F�b�N���ׂ��I)
                    };
                }
#endif

                //�f�[�^��POST���M���邽�߂�Stream���擾
                Stream reqStream = req.GetRequestStream();
                //���M����f�[�^����������
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                JsonSerializer serializer = this.GetJsonSerializer();
                SyncResponse syncRes;
                status = this.ReadSyncResponse(req, serializer, out syncRes, out message);

                if (status == (int)MAX_Status.ct_NORMAL)
                {
                    // ���O�C������i����j
                    if (syncRes != null)
                    {
                        if (syncRes.Rst_cd == "00")
                        {
                            // ����
                            message = "���iMAX�@���O�C������";
                            status = (int)MAX_Status.ct_NORMAL;
                        }
                        else
                        {
                            // ���s
                            message = syncRes.Rst_msg;
                            status = (int)MAX_Status.ct_AUT_ERROR;
                        }
                    }
                    else
                    {
                        message = "���O�C�������ɂăG���[���������܂����B";
                        status = (int)MAX_Status.ct_SYS_ERROR;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return status;
        }
        #endregion ���iMAX���O�C������

        #region ���iMAX�t�@�C�����M����
        /// <summary>
        /// ���iMAX�Ƀt�@�C���𑗐M����
        /// </summary>
        /// <param name="url">���M���URL</param>
        /// <param name="filePath">���M����t�@�C���̃p�X</param>
        /// <param name="cc">�N�b�L�[</param>
        /// <param name="message">���b�Z�[�W</param>
        public int PostBuhinMax(string url, string filePath, ref CookieContainer cc, out string message)
        {
            message = string.Empty;
            int status = (int)MAX_Status.ct_SYS_ERROR;

            try
            {
                //���M����t�@�C���̃p�X
                string fileName = Path.GetFileName(filePath);
                //�����R�[�h
                Encoding enc = Encoding.GetEncoding("utf-8");
                //��؂蕶����
                string boundary = Environment.TickCount.ToString();
                //WebRequest�̍쐬
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                //�擾�ς݂̃N�b�L�[�R���e�i
                req.CookieContainer = cc;
                //�ǂݏ����^�C���A�E�g����
                req.ReadWriteTimeout = 60000;
                //�^�C���A�E�g����
                req.Timeout = 60000;
                //���\�b�h��POST���w��
                req.Method = "POST";
                //ContentType��ݒ�
                req.ContentType = "multipart/form-data; boundary=" + boundary;

                //POST���M����f�[�^���쐬
                string postData = "";
                postData = "--" + boundary + "\r\n" +
                    "Content-Disposition: form-data; name=\"upfile\"; filename=\"" + fileName + "\"\r\n" +
                    "Content-Type: application/octet-stream\r\n" +
                    "Content-Transfer-Encoding: binary\r\n\r\n";
                //�o�C�g�^�z��ɕϊ�
                byte[] startData = enc.GetBytes(postData);
                postData = "\r\n--" + boundary + "--\r\n";
                byte[] endData = enc.GetBytes(postData);

                //���M����t�@�C�����J��
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                //POST���M����f�[�^�̒������w��
                req.ContentLength = startData.Length + endData.Length + fs.Length;

#if DEBUG
                // �f�o�b�O���̂�
                // ���N�G�X�g�𓊂���O�ɍs��
                if (ServicePointManager.ServerCertificateValidationCallback == null)
                {
                    ServicePointManager.ServerCertificateValidationCallback += delegate(Object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;	// �������ŃI���I���ؖ���M�p����B�댯�I(sender��URI�Ƃ����ׂă`�F�b�N���ׂ��I)
                    };
                }
#endif

                //�f�[�^��POST���M���邽�߂�Stream���擾
                Stream reqStream = req.GetRequestStream();
                //���M����f�[�^����������
                reqStream.Write(startData, 0, startData.Length);
                //�t�@�C���̓��e�𑗐M
                byte[] readData = new byte[0x1000];
                int readSize = 0;
                while (true)
                {
                    readSize = fs.Read(readData, 0, readData.Length);
                    if (readSize == 0)
                        break;
                    reqStream.Write(readData, 0, readSize);
                }
                fs.Close();
                reqStream.Write(endData, 0, endData.Length);
                reqStream.Close();

                JsonSerializer serializer = this.GetJsonSerializer();
                SyncResponse syncRes;

                status = this.ReadSyncResponse(req, serializer, out syncRes, out message);
                if (status == (int)MAX_Status.ct_NORMAL)
                {
                    if (syncRes != null)
                    {
                        if (syncRes.Rst_cd == "00")
                        {
                            // ����
                        }
                        else
                        {
                            // �ُ�
                            message = syncRes.Rst_msg;
                        }
                    }
                    else
                    {
                        message = "�f�[�^���M�����ɂăG���[���������܂����B";
                        status = (int)MAX_Status.ct_SYS_ERROR;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        #endregion ���iMAX�t�@�C�����M����

        #region JSON�`���V���A���C�Y/�f�V���A���C�Y���i�擾
        /// <summary>
        /// JSON�`���ւ̃V���A���C�Y/�f�V���A���C�Y���i���擾���܂��B
        /// </summary>
        /// <returns></returns>
        private JsonSerializer GetJsonSerializer()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            serializer.ObjectCreationHandling = ObjectCreationHandling.Auto;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            serializer.StringEscapeHandling = StringEscapeHandling.EscapeHtml;
            serializer.TypeNameHandling = TypeNameHandling.All;
            serializer.Formatting = Formatting.Indented;

            return serializer;
        }
        #endregion JSON�`���V���A���C�Y/�f�V���A���C�Y���i�擾

        #region ���N�G�X�g����
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <param name="serializer"></param>
        /// <param name="syncRes"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private int ReadSyncResponse(HttpWebRequest req, JsonSerializer serializer, out SyncResponse syncRes, out string message)
        {
            JsonTextReader reader = null;
            StreamReader streamReader = null;
            Stream outStream = null;
            HttpWebResponse response = null;

            int status = (int)MAX_Status.ct_SYS_ERROR;
            int retryCnt = 0;
            bool retryFlg = true;
            syncRes = new SyncResponse();
            message = string.Empty;

            while (true)
            {
                retryCnt++;
                // ���g���C����
                if (retryFlg == false || retryCnt == 3)
                {
                    if (retryFlg)
                    {
                        message = "�ڑ��Ɏ��s���܂����B";
                    }
                    break;
                }

                try
                {
                    response = req.GetResponse() as HttpWebResponse;
                    if (response == null)
                    {
                        throw new Exception("response is null.");
                    }

                    outStream = response.GetResponseStream();
                    streamReader = new StreamReader(outStream);
                    reader = new JsonTextReader(streamReader);
                    syncRes = serializer.Deserialize(reader, typeof(SyncResponse)) as SyncResponse;

                    status = (int)MAX_Status.ct_NORMAL;

                    retryFlg = false;
                }
                catch (WebException ex)
                {
                    response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        message = ex.Message;
                        if (response.StatusCode == HttpStatusCode.InternalServerError ||
                            response.StatusCode == HttpStatusCode.ServiceUnavailable)
                        {
                            // HTTP�X�e�[�^�X: 500, 503
                            status = (int)MAX_Status.ct_SVR_ERROR;
                        }
                        else if (response.StatusCode == HttpStatusCode.BadRequest ||
                                 response.StatusCode == HttpStatusCode.Unauthorized ||
                                 response.StatusCode == HttpStatusCode.NotFound)
                        {
                            // HTTP�X�e�[�^�X:400, 401, 404
                            status = (int)MAX_Status.ct_CNT_ERROR;
                        }
                        else if (response.StatusCode == HttpStatusCode.Forbidden)
                        {
                            // HTTP�X�e�[�^�X:403
                            status = (int)MAX_Status.ct_AUT_ERROR;
                        }
                        retryFlg = false;
                    }
                    else
                    {
                        // ConnectFailure:�ڑ��Ɏ��s���܂����B
                        // NameResolutionFailure:�h���C�� �l�[�� �T�[�r�X���z�X�g�����������܂���ł����B
                        if (ex.Status == WebExceptionStatus.ConnectFailure ||
                            ex.Status == WebExceptionStatus.NameResolutionFailure)
                        {
                            // ���g���C����
                            retryFlg = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                finally
                {
                    ReplicaDBAccessUtils.CloseQuietly(reader);
                    ReplicaDBAccessUtils.CloseQuietly(streamReader);
                    ReplicaDBAccessUtils.CloseQuietly(outStream);

                    if (response != null)
                    {
                        response.Close();
                    }
                }
            }
            return status;
        }
        #endregion ���N�G�X�g����

         #region ���iMAX�ڑ���URL���
        /// <summary>
        /// ���O�C��URL�\�z
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���O�C��URL�\�z���s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2016/02/04</br>
        /// </remarks>
        public int CreateLogInUrl(out string url, out string message)
        {
            message = string.Empty;

            string wkStr = "";
            int status = (int)MAX_Status.ct_NORMAL;

            try
            {
                string domain = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_PARTSMAX_LG);
                string path = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_PARTSMAX_LG, ConstantManagement_SF_PRO.IndexCode_PARTSMAX_LG_WebPath);

                // �u��
                wkStr = UrlReplace(domain, path);
            }
            catch (Exception ex)
            {
                message = "�ڑ���擾���ɃG���[���������܂����B[" + ex.Message + "]";
                return (int)MAX_Status.ct_SYS_ERROR;
            }
            finally
            {
                url = wkStr;
            }
            return status;
        }

        /// <summary>
        /// ���ח\��API�pURL�\�z
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ח\��API�pURL�\�z���s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2016/02/04</br>
        /// </remarks>
        public int CreateExHibitUrl(out string url, out string message)
        {
            message = string.Empty;

            string wkStr = "";
            int status = (int)MAX_Status.ct_NORMAL;

            try
            {
                string domain = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_PARTSMAX_EX);
                string path = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_PARTSMAX_EX, ConstantManagement_SF_PRO.IndexCode_PARTSMAX_EX_WebPath);

                // �u��
                wkStr = UrlReplace(domain, path);
            }
            catch (Exception ex)
            {
                message = "�ڑ���擾���ɃG���[���������܂����B[" + ex.Message + "]";
                return (int)MAX_Status.ct_SYS_ERROR;
            }
            finally
            {
                url = wkStr;
            }
            return status;
        }

        /// <summary>
        /// �o�i�o�^API�pURL�\�z
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�i�o�^API�pURL�\�z���s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2016/02/04</br>
        /// </remarks>
        public int CreateDeriveryUrl(out string url, out string message)
        {
            message = string.Empty;

            string wkStr = "";
            int status = (int)MAX_Status.ct_NORMAL;

            try
            {
                string domain = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_PARTSMAX_DE);
                string path = LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_PARTSMAX_DE, ConstantManagement_SF_PRO.IndexCode_PARTSMAX_DE_WebPath);

                // �u��
                wkStr = UrlReplace(domain, path);
            }
            catch (Exception ex)
            {
                message = "�ڑ���擾���ɃG���[���������܂����B[" + ex.Message + "]";               
                return (int)MAX_Status.ct_SYS_ERROR;
            }
            finally
            {
                url = wkStr;
            }
            return status;
        }

        /// <summary>
        /// URL�u��
        /// </summary>
        /// <remarks>
        /// <br>Note       : URL�u�����s���܂��B</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2016/02/04</br>
        /// </remarks>
        protected static string UrlReplace(string domain, string path)
        {
            string wkStr = domain + path;
            // �u��
            wkStr = wkStr.Replace("$enterpriseCode", LoginInfoAcquisition.EnterpriseCode);
            wkStr = wkStr.Replace("$assemblyVersion", "1.0.0");

            return wkStr;
        }

         #endregion ���iMAX�ڑ���URL���

    }

    #region API����
    /// <summary>
    /// 
    /// </summary>
    public class SyncResponse
    {
        /// <summary>�R�[�h</summary>
        private string _rst_cd;

        /// <summary>���b�Z�[�W</summary>
        private string _rst_msg;

        /// <summary>
        /// �R�[�h
        /// </summary>
        public string Rst_cd
        {
            set { this._rst_cd = value; }
            get { return this._rst_cd; }
        }

        /// <summary>
        /// ���b�Z�[�W
        /// </summary>
        public string Rst_msg
        {
            set { this._rst_msg = value; }
            get { return this._rst_msg; }
        }
    }
    #endregion API����

    #region �I�u�W�F�N�g�j��
    /// <summary>
    /// 
    /// </summary>
    public class ReplicaDBAccessUtils
    {
        /// <summary>
        /// �R���X�g���N�^�B
        /// </summary>
        private ReplicaDBAccessUtils()
        {
        }

        /// <summary>
        /// �I�u�W�F�N�g�̔j�����s���܂��B
        /// ��O���������Ă��������܂��B
        /// </summary>
        /// <param name="obj"></param>
        public static void CloseQuietly(IDisposable obj)
        {
            try
            {
                if (obj != null)
                {
                    obj.Dispose();
                }
            }
            catch
            {
            }
        }
    }
    #endregion �I�u�W�F�N�g�j��

    #region ���iMAX�ڑ���URL���
    /// <summary>
    /// ���iMAX�ڑ���URL���
    /// </summary>
    public class BuhinMaxUrlInfo
    {
        /// <summary>���O�C���A�gAPI</summary>
        private string _cPmLoginAPI;
        /// <summary>�o�i���ח\��A�gAPI</summary>
        private string _cPmExhibitItemsAPI;
        /// <summary>�o�i�݌Ɉꊇ�X�V�A�gAPI</summary>
        private string _cPmDervDirectAPI;

        /// <summary>
        /// ���O�C���A�gAPI
        /// </summary>
        public string CPmLoginAPI
        {
            get { return _cPmLoginAPI; }
            set { _cPmLoginAPI = value; }
        }

        /// <summary>
        /// �o�i���ח\��A�gAPI
        /// </summary>
        public string CPmExhibitItemsAPI
        {
            get { return _cPmExhibitItemsAPI; }
            set { _cPmExhibitItemsAPI = value; }
        }

        /// <summary>
        /// �o�i�݌Ɉꊇ�X�V�A�gAPI
        /// </summary>
        public string CPmDervDirectAPI
        {
            get { return _cPmDervDirectAPI; }
            set { _cPmDervDirectAPI = value; }
        }
    }
    #endregion ���iMAX�ڑ���URL���




}

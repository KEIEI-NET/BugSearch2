using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources; //ADD 2018/10/04 s.kanazawa

//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���[�U�[�f�[�^�z���グ�c�[��
// �v���O�����T�v   �F���[�U�[�f�[�^���w�肳�ꂽ�T�[�o�[�ɋz���グ���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30146 ���{ �G�I 
// �C����    �@�@�@�@�@     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30350 �N�� ���� 
// �C����   2017/9/12�@     �C�����e�F11370077-00 �T�[�o�[����F�؏�񂩂�擾�ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F980035 ���� ��` 
// �C����   2018/10/04      �C�����e�F11370077-00 �T�[�o�[����F�؏�񂩂�擾�ɍĕύX
// ---------------------------------------------------------------------//
namespace PutUserDataTool
{
    public class ToolApplication
    {
        /// <summary>�T�[�o�[�ʐM�Ď��s��</summary>
        public const int SERVER_RETRY_COUNT = 3;

        private static ToolApplication _self;

        #region �����o�ϐ�
        private string _homeDir;

        private string _logFile;

        private string _enterpriseCode;

        private string _authCode;

        private string _pmDbId;

        private string _baseUrl;
        #endregion

        /// <summary>
        /// ���[�U�[AP�C���X�g�[���f�B���N�g���B
        /// ��FC:\Program Files (x86)\PartsmanServer\USER_AP
        /// </summary>
        public string HomeDir
        {
            get { return this._homeDir; }
        }

        /// <summary>
        /// ���O�o�̓t�@�C��
        /// </summary>
        public string LogFile
        {
            get { return this._logFile; }
            set { this._logFile = value; }
        }

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
        }

        /// <summary>
        /// �F�؃R�[�h
        /// </summary>
        public string AuthCode
        {
            get { return this._authCode; }
        }

        /// <summary>
        /// PMDBID
        /// </summary>
        public string PmDbId
        {
            get { return this._pmDbId; }
        }

        /// <summary>
        /// �ڑ������URL
        /// </summary>
        public string BaseUrl
        {
            get { return this._baseUrl; }
        }

        /// <summary>
        /// �R���X�g���N�^�B
        /// </summary>
        /// <param name="homeDir"></param>
        /// <param name="enterpriseCode"></param>
        public ToolApplication(string homeDir, string enterpriseCode)
        {
            this._homeDir = homeDir;
            this._enterpriseCode = enterpriseCode;
            this._authCode = PmSyncAuthenticator.GetAuthenticationKey(this._enterpriseCode);


            object pmDbIdMngWorkObj = new PmDbIdMngWork();
            IPmDbIdMngDB _iPmDbIdMngDB = (IPmDbIdMngDB)MediationPmDbIdMngDB.GetPmDbIdMngDB();
            int status = _iPmDbIdMngDB.Read(ref pmDbIdMngWorkObj, 0);
            if (status != 0)
            {
                throw new Exception("PMDBID�擾���ɃG���[���������܂����B[" + status + "]");
            }
            PmDbIdMngWork pmDbIdMngWork = pmDbIdMngWorkObj as PmDbIdMngWork;
            this._pmDbId = pmDbIdMngWork.DbIdMngGuid.ToString();


            #region �F�؏��`�F�b�N
            FileInfo f = new FileInfo(Path.Combine(homeDir, "SFCMN01001S.exe.config"));
            FileStream fs = null;
            StreamReader reader = null;
            try
            {
                fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                reader = new StreamReader(fs);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //DEL 2018/10/04 s.kanazawa >>>>>>>>>>
                    //if (line.IndexOf("www32") != -1)
                    //{
                    //    this._baseUrl = "https://www.recycle7.com";
                    //    break;
                    //}
                    //else if (line.IndexOf("develop") != -1)
                    //{
                    //    this._baseUrl = "http://10.30.30.246";
                    //    break;
                    //}
                    //else if (line.IndexOf("www40") != -1)
                    //{
                    //    this._baseUrl = null;
                    //    break;
                    //}
                    //DEL 2018/10/04 s.kanazawa <<<<<<<<<<

                    //ADD 2018/10/04 s.kanazawa >>>>>>>>>>
                    this._baseUrl = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_Uploader_Web);
                    break;
                    //ADD 2018/10/04 s.kanazawa <<<<<<<<<<
                }
            }
            finally
            {
                if (fs != null) fs.Close();
                if (reader != null) reader.Close();
            }
            #endregion
        }

        public static void Initialize(string homeDir, string enterpriseCode)
        {
            _self = new ToolApplication(homeDir, enterpriseCode);
        }

        public static ToolApplication GetInstance()
        {
            return _self;
        }

        /// <summary>
        /// �T�[�o�[�ڑ��m�F�����{���܂��B
        /// </summary>
        /// <returns>true:���Ȃ��Afalse:���L��</returns>
        public bool ServerConnectCheck()
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            Stream s = null;
            StreamReader sr = null;
            for (int i = 0; i <= SERVER_RETRY_COUNT; i++)
            {
                try
                {
                    Logger.GetInstance().Log(".", false);
                    //req = WebRequest.Create(string.Format("{0}/rc7/jsp/GetIP.jsp", ToolApplication.GetInstance().BaseUrl)) as HttpWebRequest; //DEL 2018/10/04 s.kanazawa
                    req = WebRequest.Create(string.Format("{0}/pmuploader/jsp/GetIP.jsp", ToolApplication.GetInstance().BaseUrl)) as HttpWebRequest; //ADD 2018/10/04 s.kanazawa
                    req.Method = "GET";
                    req.Headers.Add("X-BLNS-CODE", ToolApplication.GetInstance().EnterpriseCode);
                    req.Headers.Add("X-BLNS-AUTH", ToolApplication.GetInstance().AuthCode);
                    req.Headers.Add("X-BLNS-PMDBID", ToolApplication.GetInstance().PmDbId);

                    res = (HttpWebResponse)req.GetResponse();

                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
                catch (WebException ex)
                {
                    if (i == SERVER_RETRY_COUNT)
                    {
                        HttpWebResponse errorResponse = ex.Response as HttpWebResponse;
                        if (errorResponse != null)
                        {
                            switch (errorResponse.StatusCode)
                            {
                                case HttpStatusCode.BadGateway:
                                case HttpStatusCode.GatewayTimeout:
                                case HttpStatusCode.ProxyAuthenticationRequired:
                                case HttpStatusCode.UseProxy:
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("�T�[�o�[�Ƃ̒ʐM���ɉ��L�y{0}�z�G���[���������܂����B", errorResponse.StatusCode), false);
                                    Logger.GetInstance().Log(Environment.NewLine + "���L�T�[�o�[�Ƃ̒ʐM���ݒ������Ă��邩���m�F���肢���܂��B", false);
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�z�X�g���́F{0}", req.RequestUri.Host), false);
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�|�[�g�ԍ��F{0}", req.RequestUri.Port), false);
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�v���g�R���F{0}", req.RequestUri.Scheme), false);
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�G���[���F{0}", ex.Message), false);
                                    break;
                                case HttpStatusCode.NotFound:
                                    return true;
                                default:
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "�T�[�o�[�Ƃ̒ʐM���ɉ��L�y{0}�z�G���[���������܂����B", errorResponse.StatusCode), false);
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "�@�z�X�g���́F{0}", req.RequestUri.Host), false);
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "�@�|�[�g�ԍ��F{0}", req.RequestUri.Port), false);
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "�@�v���g�R���F{0}", req.RequestUri.Scheme), false);
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "�@�G���[���F{0}", ex.Message), false);
                                    break;
                            }
                        }
                        else
                        {
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("�T�[�o�[�Ƃ̒ʐM���ɉ��L�y{0}�z�G���[���������܂����B", ex.Status), false);
                            Logger.GetInstance().Log(Environment.NewLine + "���L�T�[�o�[�Ƃ̒ʐM���ݒ������Ă��邩���m�F���肢���܂��B", false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�z�X�g���́F{0}", req.RequestUri.Host), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�|�[�g�ԍ��F{0}", req.RequestUri.Port), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�v���g�R���F{0}", req.RequestUri.Scheme), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�G���[���F{0}", ex.Message), false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (i == SERVER_RETRY_COUNT)
                    {
                        Logger.GetInstance().Log(Environment.NewLine + string.Format("�T�[�o�[�Ƃ̒ʐM���ɉ��L�G���[���������܂����B"), false);
                        if (req != null)
                        {
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�z�X�g���́F{0}", req.RequestUri.Host), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�|�[�g�ԍ��F{0}", req.RequestUri.Port), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("�@�v���g�R���F{0}", req.RequestUri.Scheme), false);
                        }
                        Logger.GetInstance().Log(Environment.NewLine + string.Format(" �G���[���F{0}", ex.Message), false);
                    }
                }
                finally
                {
                    if (res != null) res.Close();
                    if (s != null) s.Close();
                    if (sr != null) sr.Close();
                    if (res != null) res.Close();
                }
                Thread.Sleep(300);
            }
            return false;
        }

        public void ApplicationExecRandomSleep()
        {
            Random r = new Random(ToolApplication.GetInstance().EnterpriseCode.GetHashCode());
            Thread.Sleep(r.Next(5) * 1000);//�ҋ@���Ԃ�ύX�B�z�M�ƂԂ������ꍇ�̉e�����ŏ����ɗ}����B
        }
    }
}

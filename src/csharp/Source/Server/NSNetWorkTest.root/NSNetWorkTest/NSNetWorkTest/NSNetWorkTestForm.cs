using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;
using Broadleaf.NSNetworkTest.Data;
using Broadleaf.NSNetworkTest.Net;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Library.Resources;

namespace NSNetworkTest
{
    public partial class NSNetWorkTestForm : Form
    {
        private const string _fileName = "PM_NSNetworkTest.bin";

        /// <summary>���_�Ǘ��̃����[�g</summary>
        private IAPNSNetworkTestDB _iAPNSNetworkTestDB;

        /// <summary>
        /// ���_�Ǘ��̃����[�g���擾���܂��B
        /// </summary>
        private IAPNSNetworkTestDB PMNSNetworkTestDB
        {
            get
            {
                if (_iAPNSNetworkTestDB == null)
                {
                    _iAPNSNetworkTestDB = APNSNetworkTestDB.GetNSNetworkTestDB();
                }
                return _iAPNSNetworkTestDB;
            }
        }

        /// <summary>
        /// �O����s���ʏ��N���X���X�g
        /// </summary>
        List<NSNetworkTestInfo> _nSNetworkTestInfoList = null;

        public NSNetWorkTestForm()
        {
            InitializeComponent();
        }


        #region [ �ʐM�e�X�g���� ]
        /// <summary>
        /// �ʐM�e�X�g�������܂��B
        /// </summary>
        internal void NetWorkTestToAP()
        {
            int result = 0;

            try
            {
                //�@���s����
                long testDateTime = long.Parse(DateTime.Now.Year.ToString("D4")
                                           + DateTime.Now.Month.ToString("D2")
                                           + DateTime.Now.Day.ToString("D2")
                                           + DateTime.Now.Hour.ToString("D2")
                                           + DateTime.Now.Minute.ToString("D2")
                                           + DateTime.Now.Second.ToString("D2"));

                // �{�@Ipv4��IP���擾���܂��B
                string ip = this.GetLocalIpv4();

                //  �e�X�g�ݒ�t�@�C�������݂��Ȃ��ꍇ
                if (!File.Exists(Application.StartupPath + "\\" + _fileName))
                {
                    result = 1;

                    this.Save(ip, testDateTime, result);

                    return;
                }

                // DB�Ɋ����f�[�^���������܂��B
                // �����f�[�^����ꍇ�A�������~���܂��B
                ArrayList tusinTestLogSearchList = new ArrayList();
                TusinTestLogWork tusinTestLogSearchWork = new TusinTestLogWork();
                // ��ƃR�[�h
                tusinTestLogSearchWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // �{�@Ipv4��IP
                tusinTestLogSearchWork.MachineIPAddr = ip;
                // ���������p���[�N���쐬���܂��B
                tusinTestLogSearchList.Add(tusinTestLogSearchWork);
                // ��������
                string message = string.Empty;
                int status = PMNSNetworkTestDB.SearchLogData(tusinTestLogSearchList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // �����f�[�^������ꍇ�A�������~���܂��B
                    return;
                }

                // �e�X�g���ڏ����擾����B
                List<NSNetworkTestInfo> nSNetworkTestInfoList;
                if (!NSNetworkTestInfoList_Deserialize(out nSNetworkTestInfoList, Application.StartupPath + "\\" + _fileName))
                {
                    // BIN�t�@�C���𕪐͎��s�̏ꍇ�A�������~���܂��B
                    return;
                }

                #region �e�X�g���ږ��Ƀ��X�g����
                List<NSNetworkTestInfo> proxyTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.PROXY; });
                List<NSNetworkTestInfo> webTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.WEB; });
                List<NSNetworkTestInfo> apTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP; });
                List<NSNetworkTestInfo> bitsTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.BITS; });
                #endregion

                #region �v���L�V
                //���v���L�V�e�X�g�E�ݒ�擾
                ProxyInfo proxyInfo = NSNetworkTestAccess.CheckProxy();
                foreach (NSNetworkTestInfo nSNetworkTestInfo in proxyTestList)
                {
                    proxyInfo = NSNetworkTestAccess.CheckProxy(nSNetworkTestInfo.NSNetworkTestTargetUri);
                    nSNetworkTestInfo.ProxyInfo = proxyInfo;
                    nSNetworkTestInfo.Ex = proxyInfo.Ex;
                    if (proxyInfo.Ex != null)
                    {
                        WebException webex = (WebException)proxyInfo.Ex;
                        if (webex.Response == null)
                        {
                            //�X�e�[�^�X�R�[�h��������Ȃ���O�͑S�āu-1�v�Ƃ���B
                            nSNetworkTestInfo.WebRequestStatusNo = -1;
                        }
                        else
                        {
                            //HTTP���N�G�X�g�̃X�e�[�^�X���Z�b�g
                            nSNetworkTestInfo.WebRequestStatusNo = (int)((HttpWebResponse)webex.Response).StatusCode;
                        }
                    }
                }
                if (proxyInfo.IsProxy == ProxyInfo.ProxyType.USE && proxyInfo.ProxyAuthentication != ProxyInfo.AuthenticationType.NONE)
                {
                    //�F�؂��K�v�ȃv���L�V�𗘗p���Ă��鎞�ɃG���[�Ƃ���B
                    //���F�؂��K�v�Ȃ��͐���ɓ��삷��B
                    result = 2;
                }
                #endregion

                #region WEB
                if (!TestProc(proxyInfo, webTestList))
                {
                    result = 2;
                }
                #endregion

                #region AP
                if (!TestProc(proxyInfo, apTestList))
                {
                    result = 2;
                }
                #endregion

                #region BITS
                if (!TestProc(proxyInfo, bitsTestList))
                {
                    result = 2;
                }
                #endregion

                // �e�X�g���ʂ����X�g�ɍăZ�b�g����B
                _nSNetworkTestInfoList = nSNetworkTestInfoList;

                // �e�X�g���ʂ�DB�ɕۑ����܂��B
                this.Save(ip, testDateTime, result);

            }
            catch (Exception ex)
            {
                // �Ȃ��B
            }
            finally
            {
                // �Ȃ��B
            }
        }
        #endregion

        #region [ �ʐM�e�X�g���ʂ�DB�ɕۑ����� ]
        /// <summary>
        /// ���O�t�@�C����DB�ɕۑ����܂��B
        /// </summary>
        /// <param name="ip">ipv4��ip</param>
        /// <param name="resultFlg">�ۑ���ԁu�O�FOK�@�P�FNG�v</param>
        /// <returns></returns>
        private void Save(string ip, long testDateTime, int resultFlg)
        {
            // �ۑ����X�g���쐬���܂��B
            ArrayList tusinTestLogList = new ArrayList();
            TusinTestLogWork tusinTestLogWork = new TusinTestLogWork();
            // ��ƃR�[�h
            tusinTestLogWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // IP
            tusinTestLogWork.MachineIPAddr = ip;
            // ���s�J�n����
            tusinTestLogWork.TestDateTime = long.Parse(DateTime.Now.Year.ToString("D4")
                                            + DateTime.Now.Month.ToString("D2")
                                            + DateTime.Now.Day.ToString("D2")
                                            + DateTime.Now.Hour.ToString("D2")
                                            + DateTime.Now.Minute.ToString("D2")
                                            + DateTime.Now.Second.ToString("D2"));

            // �e�X�g���ʂ�OK�̏ꍇ�A
            if (resultFlg == 0)
            {
                tusinTestLogWork.TestResults = 0;
            }
            // �e�X�g���ʂ�NG�̏ꍇ�A
            else if (resultFlg == 1)
            {
                // �G���[���e��ݒ肵�܂��B
                tusinTestLogWork.TestErrContents = "�ݒ�t�@�C�������݂��܂���";
                tusinTestLogWork.TestResults = 1;
            }
            // �e�X�g���ʂ�NG�̏ꍇ�A
            else
            {
                // �G���[���e��ݒ肵�܂��B
                tusinTestLogWork.TestErrContents = GetResultString();
                tusinTestLogWork.TestResults = 1;
            }

            // �ۑ����X�g��ǉ����܂��B
            tusinTestLogList.Add(tusinTestLogWork);

            // �G���[���e��DB�ɕۑ����܂��B
            string message = string.Empty;
            int status = PMNSNetworkTestDB.InsertLogData(tusinTestLogList, out message);
        }
        #endregion

        #region �f�[�^�N���X�ۑ��A�ǂݍ��ݏ���
        /// <summary>
        /// �f�[�^�N���X�ǂݍ���
        /// </summary>
        /// <param name="nSNetworkTestInfoList"></param>
        /// <returns></returns>
        private bool NSNetworkTestInfoList_Deserialize(out List<NSNetworkTestInfo> nSNetworkTestInfoList, string fileName)
        {
            bool result = false;
            nSNetworkTestInfoList = null;
            try
            {
                byte[] desKey;
                byte[] desIv;
                byte[] resultBytes;
                byte[] dataBytes;

                resultBytes = FileReadProc("", fileName, out desKey, out desIv);
                dataBytes = CompoundDataProc(resultBytes, desKey, desIv);
                using (MemoryStream r = new MemoryStream())
                {
                    r.Write(dataBytes, 0, dataBytes.Length);
                    r.Position = 0;
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    nSNetworkTestInfoList = (List<NSNetworkTestInfo>)binaryFormatter.Deserialize(r);
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                nSNetworkTestInfoList = null;
            }
            return result;
        }

        /// <summary>
        /// �t�@�C���Ǎ�����
        /// </summary>
        /// <param name="logFilePath">�ۑ��t�@�C���p�X</param>
        /// <param name="logFileName">�ۑ��t�@�C������</param>
        /// <param name="desKey">�Í����L�[</param>
        /// <param name="desIv">�Í����L�[</param>
        /// <returns>�Ǎ�����</returns>
        private byte[] FileReadProc(string logFilePath, string logFileName, out byte[] desKey, out byte[] desIv)
        {
            desKey = null;
            desIv = null;
            byte[] result = null;

            //�t���p�X�擾
            string logFileFullPath = logFileName;

            //�@�摜��񂪑��݂��Ȃ��ꍇ�I��
            if (!File.Exists(logFileFullPath))
                return result;

            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                //--------------------------------?------------------------------
                RijndaelManaged rijndaelManaged = new RijndaelManaged();

                fs = new FileStream(logFileFullPath, FileMode.Open);
                //�@�t�@�C���ǂݍ���
                br = new BinaryReader(fs);
                desKey = br.ReadBytes((int)rijndaelManaged.Key.Length);
                desIv = br.ReadBytes((int)rijndaelManaged.IV.Length);
                result = br.ReadBytes((int)(fs.Length - (rijndaelManaged.Key.Length + rijndaelManaged.IV.Length)));
                //--------------------------------?-------------------------------
                br.Close();
                br = null;
                fs.Close();
                fs = null;
            }
            catch (Exception ex)
            {
                if (br != null)
                    br.Close();
                if (fs != null)
                    fs.Close();
                throw new Exception(string.Format("�t�@�C���̓Ǎ��Ɏ��s���܂����BException:{0}  FilePath:{1}", ex.Message, logFileFullPath), ex);
            }
            finally
            {
                if (br != null)
                    br.Close();
                if (fs != null)
                    fs.Close();
            }
            return result;
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="data">�������Ώۃf�[�^</param>
        /// <param name="desKey">�Í���KEY</param>
        /// <param name="desIv">�Í���KEY</param>
        /// <returns>��������</returns>
        private byte[] CompoundDataProc(byte[] data, byte[] desKey, byte[] desIv)
        {
            // Trippe DES �̃T�[�r�X �v���o�C�_�𐶐����܂�
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] destination;

            // ���o�͗p�̃X�g���[���𐶐����܂�
            using (MemoryStream ms = new MemoryStream())
            {
                CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateDecryptor(desKey, desIv), CryptoStreamMode.Write);

                // �X�g���[���ɈÍ������ꂽ�f�[�^���������݂܂�
                cs.Write(data, 0, data.Length);
                cs.Close();

                // ���������ꂽ�f�[�^�� byte �z��Ŏ擾���܂�
                destination = ms.ToArray();
                ms.Close();
            }
            return destination;
        }
        #endregion

        #region ���ʏ���
        /// <summary>
        /// �e�X�g���s��
        /// </summary>
        /// <param name="proxyInfo"></param>
        /// <param name="nSNetworkTestInfoList"></param>
        /// <returns></returns>
        private bool TestProc(ProxyInfo proxyInfo, List<NSNetworkTestInfo> nSNetworkTestInfoList)
        {
            bool result = true;
            //�e��e�X�g���s���B
            foreach (NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList)
            {
                //���e�X�g���s��Ȃ��B
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.NONE_TEST)
                {
                    nSNetworkTestInfo.CheckResult = false;
                    continue;
                }

                #region Proxy���
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS)
                {
                    //BITS�iWINHTTP)�̃v���L�V�ݒ���擾
                    ProxyInfo bitsproxyInfo = NSNetworkTestAccess.GetBitsProxyIngo();
                    nSNetworkTestInfo.ProxyInfo = bitsproxyInfo;
                }
                else
                {
                    if (WebRequest.DefaultWebProxy.IsBypassed(nSNetworkTestInfo.NSNetworkTestTargetUri) == false)
                    {
                        nSNetworkTestInfo.ProxyInfo = proxyInfo;
                    }
                }
                #endregion

                #region HTTP
                //��HTTP���N�G�X�g�e�X�g���s���B
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.HTTPREQUEST)
                {
                    if (NSNetworkTestAccess.HttpRequest(nSNetworkTestInfo))
                    {
                        nSNetworkTestInfo.CheckResult = true;
                    }
                    else
                    {
                        result = false;
                        nSNetworkTestInfo.CheckResult = false;
                    }
                }
                #endregion

                #region �|�[�g
                //���|�[�g�ڑ��e�X�g���s���B
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.PORTCONNECT)
                {
                    if (NSNetworkTestAccess.CheckPort(nSNetworkTestInfo))
                    {
                        nSNetworkTestInfo.CheckResult = true;
                    }
                    else
                    {
                        result = false;
                        nSNetworkTestInfo.CheckResult = false;
                    }
                }
                #endregion

                #region BITS
                //��BITS�z�M�e�X�g���s���B
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS)
                {
                    //BITS�iWINHTTP)�̃v���L�V�ݒ���擾
                    ProxyInfo bitsproxyInfo = NSNetworkTestAccess.GetBitsProxyIngo();
                    nSNetworkTestInfo.ProxyInfo = bitsproxyInfo;
                    if (BitsMng.Download(nSNetworkTestInfo))
                    {
                        nSNetworkTestInfo.CheckResult = true;
                    }
                    else
                    {
                        result = false;
                        nSNetworkTestInfo.CheckResult = false;
                    }
                }
                #endregion

            }

            return result;
        }

        /// <summary>
        /// Ipv4��IP���擾���܂�
        /// </summary>
        /// <returns>Ipv4��IP</returns>
        private string GetLocalIpv4()
        {
            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();


                foreach (NetworkInterface network in networkInterfaces)
                {
                    IPInterfaceProperties properties = network.GetIPProperties();

                    foreach (IPAddressInformation address in properties.UnicastAddresses)
                    {
                        if (address.Address.AddressFamily != AddressFamily.InterNetwork)
                            continue;

                        if (IPAddress.IsLoopback(address.Address))
                            continue;

                        return address.Address.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return null;
        }
        #endregion

        #region �e�X�g���ʕ\��
        /// <summary>
        /// �e�X�g���ʏڍו\���p������擾
        /// </summary>
        /// <param name="serverType"></param>
        /// <returns></returns>
        private string GetResultString()
        {
            List<NSNetworkTestInfo.ServerType> errorDictionary = new List<NSNetworkTestInfo.ServerType>();
            StringBuilder stringBuilder = new StringBuilder();

            foreach (NSNetworkTestInfo nSNetworkTestInfo in _nSNetworkTestInfoList)
            {

                if (!nSNetworkTestInfo.CheckResult && nSNetworkTestInfo.Ex != null)
                {

                    if (!errorDictionary.Contains(nSNetworkTestInfo.NSNetworkServerType))
                    {
                        stringBuilder.Append(string.Format("\r\n�y{0}�z\r\n", NSNetworkTestInfo.GetServerTypeName(nSNetworkTestInfo.NSNetworkServerType)));
                        errorDictionary.Add(nSNetworkTestInfo.NSNetworkServerType);
                    }

                    string exMessage = nSNetworkTestInfo.Ex.Message;
                    if (0 <= nSNetworkTestInfo.Ex.Message.IndexOf("�����[�g���������ł��܂���ł����B:"))
                    {
                        try
                        {
                            //�h���C�����G���[���b�Z�[�W�ɕ\�������̂ł�����B������B
                            exMessage = nSNetworkTestInfo.Ex.Message.Split(new char[] { ':' })[0];
                        }
                        catch
                        {
                            //�����̃G���[�͖�������B
                        }
                    }
                    stringBuilder.Append(string.Format("�@��[{0}]\r\n", nSNetworkTestInfo.NSNetworkTestName));
                    stringBuilder.Append(string.Format("�@�@ �E[{0}]�F{1}\r\n", nSNetworkTestInfo.WebRequestStatusNo, exMessage));
                }
            }

            return stringBuilder.ToString();
        }
        #endregion

    }
}
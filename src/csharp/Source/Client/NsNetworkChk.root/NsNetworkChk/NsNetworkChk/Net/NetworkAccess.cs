using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Management;
using System.Threading;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

using Broadleaf.NSNetworkChk.Data;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Broadleaf.NSNetworkChk.Net
{
    /// <summary>
    /// �l�b�g���[�N�ʐM�����N���X
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	���@�k��</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	2019.01.02 ���R</br>
    /// <br>				:	�@AWS�ʐM�e�X�g���ʂ�o�^���鏈���̒ǉ�</br>
    /// <br>				:	�AAWS�ʐM�����e�X�g�����̒ǉ�</br>
    /// <br>				:	�BFTP�`�F�b�N�����̒ǉ�</br>
    /// <br>				:	2019.02.06 �O�c�@��</br>
    /// <br>				:	�@FTP�`�F�b�N����UL�t�@�C������ύX</br>
    /// <br>				:	�AWindows�o�[�W������WindowsOS�����i�[����悤�ɕύX</br>
    /// <br>				:	2019.02.22 ���R</br>
    /// <br>				:	�@�uACTIVE MODE�v��FTP�`�F�b�N�������R�����g�A�E�g����</br>
    /// <br>				:	�A�t�@�C���A�b�v���[�h��ŁA5�b�E�G�C�g�����̒ǉ�</br>
    /// </remarks>
    public class NSNetworkTestAccess
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public NSNetworkTestAccess()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iAWSCommTstRsltDB = (IAWSCommTstRsltDB)MediationAWSCommTstRsltDB.GetAWSCommTstRsltDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iAWSCommTstRsltDB = null;
            }
        }
        #endregion

        #region �����[�g�֘A�i���f�[�^�o�^�j
        /// <summary>
        /// �����[�g�I�u�W�F�N�g (NSNetworkO)
        /// </summary>
        private IAWSCommTstRsltDB _iAWSCommTstRsltDB = null;
        // MD5�C���X�^���X
        private static MD5 md5 = MD5.Create();
        #endregion

        #region �p�u���b�N���\�b�h

        /// <summary>
        /// DB�o�^����
        /// </summary>
        /// <param name="nSNetworkTestInfoList">AWS�e�X�g���N���X�̃��X�g</param>
        /// <param name="aWSCommTstRsltWork">AWS�e�X�g���ʃ��[�N</param>
        /// <param name="msgDiv">���b�Z�[�W�\���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AWS�e�X�g���ʃ��[�N���X�g���쐬���ēo�^�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public int WriteDBData(List<NSNetworkTestInfo> nSNetworkTestInfoList, AWSComRsltWork aWSCommTstRsltWork, out bool msgDiv, out string errMsg)
        {
            msgDiv = false;
            errMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (nSNetworkTestInfoList == null)
            {
                msgDiv = true;
                errMsg = "�e�X�g���ʂ����݂��܂���B";
                status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                return status;
            }

            AWSComRsltWork awsCommTstRsltWork;
            ArrayList awsCommTstRsltWorkList = new ArrayList();

            // MAC��MD5�n�b�V���l
            string mac = GetMacMD5Hash();
            
            if(string.IsNullOrEmpty(mac) == true)
            {
                errMsg = "MAC�A�h���X���擾�ł��܂���B";
                return (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            //Windows�o�[�W�����擾
            string osName = "";
            string osVer = "";
            GetWindowsOSName(ref osName, ref osVer);
            
            foreach (NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList)
            {
                awsCommTstRsltWork = new AWSComRsltWork();

                awsCommTstRsltWork.UserSetDiscId = mac;
                awsCommTstRsltWork.EnterpriseCode = aWSCommTstRsltWork.EnterpriseCode;
                awsCommTstRsltWork.SectionCode = aWSCommTstRsltWork.SectionCode;
                awsCommTstRsltWork.CheckDate = aWSCommTstRsltWork.CheckDate;
                awsCommTstRsltWork.CheckTime = aWSCommTstRsltWork.CheckTime;
                awsCommTstRsltWork.ComputerName = aWSCommTstRsltWork.ComputerName;

                awsCommTstRsltWork.TestName = nSNetworkTestInfo.NSNetworkTestName;

                switch (nSNetworkTestInfo.NSNetworkServerType)
                {
                    case NSNetworkTestInfo.ServerType.WEB:
                        awsCommTstRsltWork.ServerType = 0;
                        break;
                    case NSNetworkTestInfo.ServerType.AP:
                        awsCommTstRsltWork.ServerType = 1;
                        break;
                    case NSNetworkTestInfo.ServerType.BITS:
                        awsCommTstRsltWork.ServerType = 2;
                        break;
                    case NSNetworkTestInfo.ServerType.PROXY:
                        awsCommTstRsltWork.ServerType = 3;
                        break;
                }

                switch (nSNetworkTestInfo.NSNetworkTestType)
                {
                    case NSNetworkTestInfo.TestType.NONE_TEST:
                        awsCommTstRsltWork.TestType = 0;
                        break;
                    case NSNetworkTestInfo.TestType.HTTPREQUEST:
                        awsCommTstRsltWork.TestType = 1;
                        break;
                    case NSNetworkTestInfo.TestType.PORTCONNECT:
                        awsCommTstRsltWork.TestType = 2;
                        break;
                    case NSNetworkTestInfo.TestType.BITS:
                        awsCommTstRsltWork.TestType = 3;
                        break;
                    case NSNetworkTestInfo.TestType.FTPCONNCT:
                        awsCommTstRsltWork.TestType = 4;
                        break;
                }

                awsCommTstRsltWork.TestObjAddr = nSNetworkTestInfo.NSNetworkTestTargetUri.ToString();

                if (nSNetworkTestInfo.CheckResult)
                {
                    awsCommTstRsltWork.CheckRslt = 0;
                }
                else
                {
                    awsCommTstRsltWork.CheckRslt = 1;
                }

                awsCommTstRsltWork.RequestStatusNo = nSNetworkTestInfo.WebRequestStatusNo;

                if (nSNetworkTestInfo.WebRequestStatusNo == 200)
                {
                    awsCommTstRsltWork.RequestMessage = "";
                }
                else
                {
                    awsCommTstRsltWork.RequestMessage = nSNetworkTestInfo.WebRequestStatusMessage;
                }

                awsCommTstRsltWork.WindowsVersion = osVer;
                awsCommTstRsltWork.WindowsOSName = osName;
                awsCommTstRsltWork.AwsReserved1 = "";
                awsCommTstRsltWork.AwsReserved2 = "";
                awsCommTstRsltWork.AwsReserved3 = "";

                awsCommTstRsltWorkList.Add(awsCommTstRsltWork);
            }

            try
            {
                object aWSCommTstRsltWorkList = new object();
                aWSCommTstRsltWorkList = awsCommTstRsltWorkList as object;

                // �o�^����
                if (this._iAWSCommTstRsltDB == null) this._iAWSCommTstRsltDB = (IAWSCommTstRsltDB)MediationAWSCommTstRsltDB.GetAWSCommTstRsltDB();
                status = this._iAWSCommTstRsltDB.WriteDBData(ref aWSCommTstRsltWorkList, out msgDiv, out errMsg);
                //MessageBox.Show("STATUS=" + status.ToString());
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("EX STATUS=" + status.ToString());
                string msg = "AWS�ʐM�e�X�g���ʃ}�X�^�̓o�^�ŗ�O���������܂���[" + ex.Message + "]";
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �n�b�V���l�ϊ�����
        /// </summary>
        /// <returns>MD5�n�b�V���l</returns>
        /// <remarks>
        /// <br>Note       : MAC�A�h���X���擾���AMD5�̃n�b�V���l�ɕϊ�����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public static string GetMacMD5Hash()
        {
            string macStr = GetMacString();
            if (string.IsNullOrEmpty(macStr) == true) return macStr;
            return GetMD5Hash(macStr);
        }

        /// <summary>
        /// WindowsOS���擾
        /// </summary>
        /// <returns>WindowsOS��</returns>
        /// <remarks>
        /// <br>Note       : WindowsVersion����WindowsOS�����擾����B</br>
        /// <br>Programmer : �O�c�@��</br>
        /// <br>Date       : 2019.02.06</br>
        /// </remarks>
        public static void GetWindowsOSName(ref string osName, ref string osVer)
        {
            string osNameBuf = "";
            string osVerBuf = "";

            osName = "";
            osVer = "";

            try
            {
                using (ManagementClass mc = new ManagementClass("Win32_OperatingSystem"))
                {
                    using (ManagementObjectCollection moc = mc.GetInstances())
                    {
                        foreach (ManagementObject mo in moc)
                        {
                            //OS��
                            if (mo["Caption"] != null)
                            {
                                osNameBuf = mo["Caption"].ToString();
//                                MessageBox.Show("OS�� = " + osNameBuf);
                            }
                            else
                            {
//                                MessageBox.Show("OS�� = " + "�Ȃ�NULL");
                            }

                            if (osNameBuf.Length > 50)
                            {
                                osName = osNameBuf.Remove(50);
                            }
                            else
                            {
                                osName = osNameBuf;
                            }
                            //�o�[�W����+�T�[�r�X�p�b�N
                            if (mo["Version"] != null)
                            {
                                osVerBuf = mo["Version"].ToString();
//                                MessageBox.Show("�o�[�W���� = " + osVerBuf);
                            }
                            else
                            {
//                                MessageBox.Show("�o�[�W���� = " + "�Ȃ�NULL");
                            }

                            if (mo["CSDVersion"] != null)
                            {
                                osVerBuf = osVerBuf + " " + mo["CSDVersion"].ToString();
//                                MessageBox.Show("CSD�o�[�W���� = " + osVerBuf);
                            }
                            else
                            {
//                                MessageBox.Show("CSD�o�[�W���� = " + "�Ȃ�NULL");
                            }

                            if (osVerBuf.Length > 50)
                            {
                                osVer = osVerBuf.Remove(50);
                            }
                            else
                            {
                                osVer = osVerBuf;
                            }
                        }
                    }
                }
            }
            catch
            {
//                MessageBox.Show("EXCEPTION");
            }
        }
            
        /// <summary>
        /// MAC�A�h���X�擾����
        /// </summary>
        /// <returns>MAC�A�h���X</returns>
        /// <remarks>
        /// <br>Note       : MAC�A�h���X���擾����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        private static string GetMacString()
        {
            // �l�b�g���[�N�����p�ł��Ȃ��ꍇ�͏I������
            if (!NetworkInterface.GetIsNetworkAvailable())
                return string.Empty;

            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface var in nics)
            {
                if (var.OperationalStatus == OperationalStatus.Up)
                {
                    string macStr = var.GetPhysicalAddress().ToString();

                    if (string.IsNullOrEmpty(macStr) == false)
                    {
                        return macStr;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// MD5�̃n�b�V���l�ɕϊ�����
        /// </summary>
        /// <param name="srcStr">������</param>
        /// <returns>MD5�̃n�b�V���l</returns>
        /// <remarks>
        /// <br>Note       : �������MD5�̃n�b�V���l�ɕϊ�����B</br>
        /// <br>Programmer : �d��</br>
        /// <br>Date       : 2018.04.17</br>
        /// </remarks>
        private static string GetMD5Hash(string srcStr)
        {
            StringBuilder sb = new StringBuilder();

            byte[] source = md5.ComputeHash(Encoding.UTF8.GetBytes(srcStr));

            for (int i = 0; i < source.Length; i++)
            {

                sb.Append(source[i].ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// HTTP���N�G�X�g
        /// </summary>
        /// <param name="nSNetworkTestInfo"></param>
        /// <returns></returns>
        public static bool HttpRequest(NSNetworkTestInfo nSNetworkTestInfo)
        {
            return HttpRequestProc(nSNetworkTestInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="portNo"></param>
        /// <returns></returns>
        public static bool CheckPort(NSNetworkTestInfo nSNetworkTestInfo)
        {
            bool result = false;
            try
            {
                //���ڎw��A�h���X�֐ڑ��m�F����B
                using (TcpClient tcpClient = new TcpClient(nSNetworkTestInfo.NSNetworkTestTargetUri.Host, nSNetworkTestInfo.NSNetworkTestTargetUri.Port))
                {
                    result = tcpClient.Connected;
                }
            }
            catch (Exception ex)
            {
                result = false;
                //�X�e�[�^�X�R�[�h�̕�����Ȃ���O�͑S�āu-1�v�Ƃ���B
                nSNetworkTestInfo.WebRequestStatusNo = -1;
                nSNetworkTestInfo.Ex = ex;
            }

            return result;
        }

        /// <summary>
        /// FTP�`�F�b�N����
        /// </summary>
        /// <param name="nSNetworkTestInfo">�l�b�g���[�N�e�X�g���</param>
        /// <param name="localFileNm">�t�@�C������</param>
        /// <returns>result</returns>
        /// <remarks>
        /// <br>Note       : FTP�`�F�b�N�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public static bool FtpRequest(NSNetworkTestInfo nSNetworkTestInfo, string localFileNm)
        {
            bool result = false;
            try
            {
                string ftpUrl = string.Empty;
                string ftpUserID = string.Empty;
                string ftpPassword = string.Empty;

                string orgUrl = nSNetworkTestInfo.NSNetworkTestTargetUri.AbsoluteUri.Trim();
                string[] sArray = orgUrl.Split('&');

                if (sArray.Length > 2)
                {
                    nSNetworkTestInfo.NSNetworkTestTargetUri = new Uri(sArray[0]);

                    ftpUrl = sArray[0].Replace("ftps://", "ftp://");
                    ftpUserID = sArray[1].Substring(sArray[1].IndexOf(":") + 1);
                    ftpPassword = sArray[2].Substring(sArray[2].IndexOf(":") + 1);
                }
                else
                {
                    nSNetworkTestInfo.NSNetworkTestTargetUri = new Uri(sArray[0]);

                    ftpUrl = sArray[0].Replace("ftps://", "ftp://");
                    ftpUserID = "anonymous";
                    ftpPassword = "";
                }

                string localPath = Path.Combine(System.Windows.Forms.Application.StartupPath, localFileNm);
//                string remoteFileNm = localFileNm.Substring(0, localFileNm.IndexOf(".")) + "_" + System.Environment.MachineName + ".bin";
                Guid guidValue = Guid.NewGuid();
                string remoteFileNm = "FTPCHECK_" + guidValue.ToString() + ".txt";
                string remoteUri = Path.Combine(ftpUrl, remoteFileNm);

                string statusMessageUpload = string.Empty;
                int statusNoUpload;
                bool flgUploadFile = false;
                string statusMessageDelete = string.Empty;
                int statusNoDelete;
                bool flgDeleteFile = false;
//                //ACTIVE MODE
//                flgUploadFile = UploadFile(remoteUri, ftpUserID, ftpPassword, localPath, false, out statusNoUpload, out statusMessageUpload);
//                flgDeleteFile = DeleteFile(remoteUri, ftpUserID, ftpPassword, localPath, false, out statusNoDelete, out statusMessageDelete);
//                if (!flgUploadFile || !flgDeleteFile)
//                {
//                    if (!flgUploadFile)
//                    {
//                        result = false;
//                        nSNetworkTestInfo.WebRequestStatusNo = statusNoUpload;
////                        nSNetworkTestInfo.WebRequestStatusMessage = statusMessageUpload;
//                        nSNetworkTestInfo.WebRequestStatusMessage = statusMessageUpload + "(A/U)";
//                        return result;
//                    }
//                    else if (!flgDeleteFile)
//                    {
//                        result = false;
//                        nSNetworkTestInfo.WebRequestStatusNo = statusNoDelete;
////                        nSNetworkTestInfo.WebRequestStatusMessage = statusMessageDelete;
//                        nSNetworkTestInfo.WebRequestStatusMessage = statusMessageDelete + "(A/D)";
//                        return result;
//                    }
//                }

                //Passive MODE
                flgUploadFile = UploadFile(remoteUri, ftpUserID, ftpPassword, localPath, true, out statusNoUpload, out statusMessageUpload);
                //5�b�E�G�C�g����B
                Thread.Sleep(5000);
                flgDeleteFile = DeleteFile(remoteUri, ftpUserID, ftpPassword, localPath, true, out statusNoDelete, out statusMessageDelete);
                if (!flgUploadFile || !flgDeleteFile)
                {
                    if (!flgUploadFile)
                    {
                        result = false;
                        nSNetworkTestInfo.WebRequestStatusNo = statusNoUpload;
//                        nSNetworkTestInfo.WebRequestStatusMessage = statusMessageUpload;
                        nSNetworkTestInfo.WebRequestStatusMessage = statusMessageUpload + "(P/U)";
                        return result;
                    }
                    else if (!flgDeleteFile)
                    {
                        result = false;
                        nSNetworkTestInfo.WebRequestStatusNo = statusNoDelete;
//                        nSNetworkTestInfo.WebRequestStatusMessage = statusMessageDelete;
                        nSNetworkTestInfo.WebRequestStatusMessage = statusMessageDelete + "(P/D)";
                        return result;
                    }
                }

                if (statusNoDelete == (int)FtpStatusCode.FileActionOK)
                {
                    result = true;
                    nSNetworkTestInfo.WebRequestStatusNo = (int)FtpStatusCode.FileActionOK;
                    nSNetworkTestInfo.WebRequestStatusMessage = statusMessageDelete;
                }
            }
            catch (Exception ex)
            {
                result = false;
                //�X�e�[�^�X�R�[�h�̕�����Ȃ���O�͑S�āu-1�v�Ƃ���B
                nSNetworkTestInfo.WebRequestStatusNo = -1;
                nSNetworkTestInfo.Ex = ex;
            }

            return result;
        }

        /// <summary>
        /// �v���L�V�T�[�o�[�̎�ʃ`�F�b�N
        /// </summary>
        /// <returns></returns>
        public static ProxyInfo CheckProxy()
        {
            Uri target = new Uri("http://www.broadleaf.co.jp");
            return CheckProxyProc(target);
        }

        /// <summary>
        /// �v���L�V�T�[�o�[�̎�ʃ`�F�b�N
        /// </summary>
        /// <returns></returns>
        public static ProxyInfo CheckProxy(Uri target)
        {
            return CheckProxyProc(target);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ProxyInfo GetBitsProxyIngo()
        {
            ProxyInfo proxyInfo = new ProxyInfo();
            WinHttpAPI.WINHTTP_PROXY_INFO winHTTP_PROXY_INFO = new WinHttpAPI.WINHTTP_PROXY_INFO();

            try
            {
                WinHttpAPI.WinHttpGetDefaultProxyConfiguration(ref winHTTP_PROXY_INFO);
                if (winHTTP_PROXY_INFO.lpszProxy == null || winHTTP_PROXY_INFO.lpszProxy == "")
                {
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.NOT_USE;
                }
                else
                {
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.USE;
                    proxyInfo.ProxyUrl = winHTTP_PROXY_INFO.lpszProxy;
                }
            }
            catch (Exception ex)
            {
                proxyInfo.Ex = ex;
            }

            return proxyInfo;
        }

        #endregion

        #region �v���C�x�[�g���\�b�h
        /// <summary>
        /// �t�@�C���A�b�v���[�h����(FTP)
        /// </summary>
        /// <param name="remoteUri">FTP�p�X</param>
        /// <param name="ftpUserID">���O�C�����[�U�[ID</param>
        /// <param name="ftpPassword">���O�C���p�[�X���[�h</param>
        /// <param name="localPath">�t�@�C���p�X</param>
        /// <param name="mode">FTP�]�����[�h(true:Passive���[�h)</param>
        /// <param name="statusNo">�X�e�[�^�X</param>
        /// <param name="statusMessage">���b�Z�[�W</param>
        /// <returns>�A�b�v���[�h����</returns>
        /// <remarks>
        /// <br>Note       : �p�����[�^�Ŏw�肵��FTP�T�[�o�[�Ɏw�肵���t�@�C�����A�b�v���[�h����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        private static bool UploadFile(string remoteUri, string ftpUserID, string ftpPassword, string localPath, bool mode, out int statusNo, out string statusMessage)
        {
            bool result = false;
            statusNo = -1;
            statusMessage = "";

            FileInfo fileInf = new FileInfo(localPath);

            FtpWebRequest reqFTP = null;
            FtpWebResponse resFTP = null;
            FileStream fileStrm = null;
            Stream strm = null;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(remoteUri));
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.KeepAlive = false;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = mode;
                reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                reqFTP.EnableSsl = false;
                reqFTP.ContentLength = fileInf.Length;

                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int contentLen;

                fileStrm = fileInf.OpenRead();
                strm = reqFTP.GetRequestStream();
                contentLen = fileStrm.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fileStrm.Read(buff, 0, buffLength);
                }

                result = true;
            }
            catch(WebException webEx)
            {
                if (webEx.Response == null)
                {
                    statusNo = -1;
                    statusMessage = webEx.Message;
                }
                else
                {
                    statusNo = (int)((FtpWebResponse)webEx.Response).StatusCode;
                    if (statusNo == (int)FtpStatusCode.CommandOK)
                    {
                        result = true;
                    }
                    else
                    {
                        statusMessage = webEx.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                statusNo = -1;
                statusMessage = ex.Message;
            }
            finally
            {
                if (strm != null) strm.Close();
                if (fileStrm != null) fileStrm.Close();
                if (resFTP != null) resFTP.Close();
                reqFTP = null;
            }

            return result;
        }

        /// <summary>
        /// �t�@�C���폜����(FTP)
        /// </summary>
        /// <param name="remoteUri">FTP�p�X</param>
        /// <param name="ftpUserID">���O�C�����[�U�[ID</param>
        /// <param name="ftpPassword">���O�C���p�[�X���[�h</param>
        /// <param name="localPath">�t�@�C���p�X</param>
        /// <param name="mode">FTP�]�����[�h(true:Passive���[�h)</param>
        /// <param name="statusNo">�X�e�[�^�X</param>
        /// <param name="statusMessage">���b�Z�[�W</param>
        /// <returns>�폜����</returns>
        /// <remarks>
        /// <br>Note       : �p�����[�^�Ŏw�肵��FTP�T�[�o�[����w�肵���t�@�C�����폜����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        private static bool DeleteFile(string remoteUri, string ftpUserID, string ftpPassword, string localPath, bool mode, out int statusNo, out string statusMessage)
        {
            bool result = false;
            statusNo = -1;
            statusMessage = "";

            FileInfo fileInf = new FileInfo(localPath);

            FtpWebRequest reqFTP = null;
            FtpWebResponse resFTP = null;
            Stream strm = null;
            StreamReader strmRdr = null;
            try
            {
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(remoteUri));
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                reqFTP.KeepAlive = false;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = mode;
                reqFTP.EnableSsl = false;

                resFTP = (FtpWebResponse)reqFTP.GetResponse();
                if (resFTP.StatusCode == FtpStatusCode.FileActionOK)
                {
                    result = true;
                    statusNo = (int)FtpStatusCode.FileActionOK;
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Response == null)
                {
                    statusNo = -1;
                    statusMessage = webEx.Message;
                }
                else
                {
                    statusNo = (int)((FtpWebResponse)webEx.Response).StatusCode;
                    if (statusNo == (int)FtpStatusCode.CommandOK)
                    {
                        result = true;
                    }
                    else
                    {
                        statusMessage = webEx.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                statusNo = -1;
                statusMessage = ex.Message;
            }
            finally
            {
                if (strmRdr != null) strmRdr.Close();
                if (strm != null) strm.Close();
                if (resFTP != null) resFTP.Close();
                reqFTP = null;
            }

            return result;
        }

        /// <summary>
        /// HTTP���N�G�X�g
        /// </summary>
        /// <param name="nSNetworkTestInfo"></param>
        /// <returns></returns>
        private static bool HttpRequestProc(NSNetworkTestInfo nSNetworkTestInfo)
        {

            bool result = false;
            string responseMessage;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(nSNetworkTestInfo.NSNetworkTestTargetUri);

                //�v���L�V�o�R�Őڑ�����K�v���L��ꍇ
                if (nSNetworkTestInfo.ProxyInfo != null && nSNetworkTestInfo.ProxyInfo.IsProxy != ProxyInfo.ProxyType.NOT_USE)
                {
                    httpWebRequest.Proxy = new WebProxy(nSNetworkTestInfo.ProxyInfo.ProxyUrl);
                    if (nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.NONE)
                    {
                        //�F�ؖ�
                    }
                    else if (nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.BASIC)
                    {
                        httpWebRequest.Proxy.Credentials = new NetworkCredential("id", "pwd");
                    }
                    else if (nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.WINDOWS)
                    {
                        httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    }
                }

                //�T�[�o�[����̉�������M���邽�߂�WebResponse���擾
                nSNetworkTestInfo.WebRequestStatusNo = GetResponseStream(out responseMessage, httpWebRequest);
                //HTTP���N�G�X�g���ʂ��Z�b�g
                nSNetworkTestInfo.WebRequestStatusMessage = responseMessage;

                if (nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.OK)
                {
                    //�ʐMOK
                    result = true;
                }
                else
                {
                    if (nSNetworkTestInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP)
                    {
                        if (nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.InternalServerError)
                        {
                            result = true;
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }

            }
            catch (WebException webex)
            {
                if (webex.Response == null)
                {
                    //�X�e�[�^�X�R�[�h��������Ȃ���O�͑S�āu-1�v�Ƃ���B
                    nSNetworkTestInfo.WebRequestStatusNo = -1;
                }
                else
                {
                    //HTTP���N�G�X�g�̃X�e�[�^�X���Z�b�g
                    nSNetworkTestInfo.WebRequestStatusNo = (int)((HttpWebResponse)webex.Response).StatusCode;

                    //AP�T�[�o�[�����N�G�X�g�X�e�[�^�X��500�̂��̂̓R�l�N�V�����m�����o�����̂Ő���Ƃ݂Ȃ��B
                    if (nSNetworkTestInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP)
                    {
                        if (nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.InternalServerError)
                        {
                            result = true;
                        }
                    }
                }

                //��O�N���X���Z�b�g
                nSNetworkTestInfo.Ex = webex;
                //HTTP���N�G�X�g�̃G���[�̏ڍׂ��Z�b�g
                nSNetworkTestInfo.WebRequestStatusMessage = webex.Message;
            }
            catch (Exception ex)
            {
                //�X�e�[�^�X�R�[�h��������Ȃ���O�͑S�āu-1�v�Ƃ���B
                nSNetworkTestInfo.WebRequestStatusNo = -1;
                //��O�N���X���Z�b�g
                nSNetworkTestInfo.Ex = ex;
                //HTTP���N�G�X�g�̃G���[�̏ڍׂ��Z�b�g
                nSNetworkTestInfo.WebRequestStatusMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// HTTP���X�|���X�擾
        /// </summary>
        /// <param name="httpWebRequest"></param>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        private static int GetResponseStream(out string responseMessage, HttpWebRequest httpWebRequest)
        {
            int status = -1;

            //�T�[�o�[����̉�������M���邽�߂�WebResponse���擾
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                //HTTP���N�G�X�g�̃X�e�[�^�X���Z�b�g
                status = (int)httpWebResponse.StatusCode;

                //�����f�[�^����M���邽�߂�Stream���擾
                using (System.IO.Stream stream = httpWebResponse.GetResponseStream())
                {
                    using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.Default))
                    {
                        responseMessage = streamReader.ReadToEnd();  //��M
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �v���L�V�T�[�o�[�̎�ʃ`�F�b�N
        /// </summary>
        /// <returns></returns>
        private static ProxyInfo CheckProxyProc(Uri target)
        {
            int status = -1;
            string responseMessage;
            ProxyInfo proxyInfo = new ProxyInfo();

            //�f�t�H���g�v���L�V�ݒ�̎擾�i��{�I��IE�Őݒ肳��Ă���������j
            Uri testUri = target;
            Uri proxyUri = target;
            //Uri testUri = new Uri("http://www.broadleaf.co.jp");
            //Uri proxyUri = new Uri("http://www.broadleaf.co.jp");

            try
            {
                proxyUri = WebRequest.DefaultWebProxy.GetProxy(testUri);
                if (proxyUri == testUri)
                {
                    //�v���L�V����
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.NOT_USE;
                    return proxyInfo;
                }
            }
            catch (WebException wex)
            {
                //�����ł̗�O�͖�������B
                proxyInfo.Ex = wex;
            }

            //�v���L�V�L��
            proxyInfo.IsProxy = ProxyInfo.ProxyType.USE;
            proxyInfo.ProxyUrl = proxyUri.ToString();

            try
            {
                //�v���L�V�̃o�C�p�X���X�g���擾����@���������A�񐄏����\�b�h����擾����̂Ŋm�����͒ቺ����Ǝv����
                WebProxy workProxy = WebProxy.GetDefaultProxy();
                if (workProxy.Address != null && workProxy.Address.ToString() == proxyUri.ToString())
                {
                    proxyInfo.ProxyBypass.AddRange(workProxy.BypassList);
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //���f�t�H���g�ݒ�ŒʐM���\���`�F�b�N
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if (status == (int)HttpStatusCode.OK)
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.NONE;
                    return proxyInfo;
                }
            }
            catch (WebException wex)
            {
                //�����ł̗�O�͖�������B
                proxyInfo.Ex = wex;
            }


            //�v���L�V�ݒ�
            IWebProxy proxyObject = new WebProxy(proxyUri);

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //���v���L�V�ւ�NTLM�F�؁iWindows�����j���Z�b�g����
                proxyObject.Credentials = CredentialCache.DefaultCredentials;
                httpWebRequest.Proxy = proxyObject;
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if (status == (int)HttpStatusCode.OK)
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.WINDOWS;
                    return proxyInfo;
                }
            }
            catch (WebException wex)
            {
                //�����ł̗�O�͖�������B
                proxyInfo.Ex = wex;
            }

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //���v���L�V�ւ�BASIC�F�؏����Z�b�g����
                proxyObject.Credentials = new NetworkCredential("ID", "PWD");
                httpWebRequest.Proxy = proxyObject;
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if (status == (int)HttpStatusCode.OK)
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.BASIC;
                    return proxyInfo;
                }
            }
            catch (WebException wex)
            {
                //�ŏI�I��WEB��O���Z�b�g����B
                proxyInfo.Ex = wex;
            }
            catch
            {
                //�����ł̗�O�͖�������B
            }


            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //���v���L�V���g�p���Ȃ��Œ��ڐڑ�����
                httpWebRequest.Proxy = null;
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if (status == (int)HttpStatusCode.OK)
                {
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.FREE_USE;
                }
            }
            catch
            {
                //�����ł̗�O�͖�������B
            }

            //�v���L�V�ւ̔F�؂̎�ނ����ʂł��Ȃ������B
            proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.UNKNOWN;
            return proxyInfo;
        }



        #endregion
    }
}

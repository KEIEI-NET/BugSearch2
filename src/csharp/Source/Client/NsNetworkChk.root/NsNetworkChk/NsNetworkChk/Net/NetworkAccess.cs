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
    /// ネットワーク通信処理クラス
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	上野　耕平</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	2019.01.02 朱宝軍</br>
    /// <br>				:	①AWS通信テスト結果を登録する処理の追加</br>
    /// <br>				:	②AWS通信自動テスト処理の追加</br>
    /// <br>				:	③FTPチェック処理の追加</br>
    /// <br>				:	2019.02.06 前田　崇</br>
    /// <br>				:	①FTPチェック時のULファイル名を変更</br>
    /// <br>				:	②WindowsバージョンとWindowsOS名を格納するように変更</br>
    /// <br>				:	2019.02.22 朱宝軍</br>
    /// <br>				:	①「ACTIVE MODE」のFTPチェック処理をコメントアウトする</br>
    /// <br>				:	②ファイルアップロード後で、5秒ウエイト処理の追加</br>
    /// </remarks>
    public class NSNetworkTestAccess
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NSNetworkTestAccess()
        {
            try
            {
                // リモートオブジェクト取得
                this._iAWSCommTstRsltDB = (IAWSCommTstRsltDB)MediationAWSCommTstRsltDB.GetAWSCommTstRsltDB();
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iAWSCommTstRsltDB = null;
            }
        }
        #endregion

        #region リモート関連（実データ登録）
        /// <summary>
        /// リモートオブジェクト (NSNetworkO)
        /// </summary>
        private IAWSCommTstRsltDB _iAWSCommTstRsltDB = null;
        // MD5インスタンス
        private static MD5 md5 = MD5.Create();
        #endregion

        #region パブリックメソッド

        /// <summary>
        /// DB登録処理
        /// </summary>
        /// <param name="nSNetworkTestInfoList">AWSテスト情報クラスのリスト</param>
        /// <param name="aWSCommTstRsltWork">AWSテスト結果ワーク</param>
        /// <param name="msgDiv">メッセージ表示区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AWSテスト結果ワークリストを作成して登録処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
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
                errMsg = "テスト結果が存在しません。";
                status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                return status;
            }

            AWSComRsltWork awsCommTstRsltWork;
            ArrayList awsCommTstRsltWorkList = new ArrayList();

            // MACのMD5ハッシュ値
            string mac = GetMacMD5Hash();
            
            if(string.IsNullOrEmpty(mac) == true)
            {
                errMsg = "MACアドレスが取得できません。";
                return (int)ConstantManagement.DB_Status.ctDB_WARNING;
            }

            //Windowsバージョン取得
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

                // 登録処理
                if (this._iAWSCommTstRsltDB == null) this._iAWSCommTstRsltDB = (IAWSCommTstRsltDB)MediationAWSCommTstRsltDB.GetAWSCommTstRsltDB();
                status = this._iAWSCommTstRsltDB.WriteDBData(ref aWSCommTstRsltWorkList, out msgDiv, out errMsg);
                //MessageBox.Show("STATUS=" + status.ToString());
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("EX STATUS=" + status.ToString());
                string msg = "AWS通信テスト結果マスタの登録で例外が発生しました[" + ex.Message + "]";
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ハッシュ値変換処理
        /// </summary>
        /// <returns>MD5ハッシュ値</returns>
        /// <remarks>
        /// <br>Note       : MACアドレスを取得し、MD5のハッシュ値に変換する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        public static string GetMacMD5Hash()
        {
            string macStr = GetMacString();
            if (string.IsNullOrEmpty(macStr) == true) return macStr;
            return GetMD5Hash(macStr);
        }

        /// <summary>
        /// WindowsOS名取得
        /// </summary>
        /// <returns>WindowsOS名</returns>
        /// <remarks>
        /// <br>Note       : WindowsVersionからWindowsOS名を取得する。</br>
        /// <br>Programmer : 前田　崇</br>
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
                            //OS名
                            if (mo["Caption"] != null)
                            {
                                osNameBuf = mo["Caption"].ToString();
//                                MessageBox.Show("OS名 = " + osNameBuf);
                            }
                            else
                            {
//                                MessageBox.Show("OS名 = " + "なぜNULL");
                            }

                            if (osNameBuf.Length > 50)
                            {
                                osName = osNameBuf.Remove(50);
                            }
                            else
                            {
                                osName = osNameBuf;
                            }
                            //バージョン+サービスパック
                            if (mo["Version"] != null)
                            {
                                osVerBuf = mo["Version"].ToString();
//                                MessageBox.Show("バージョン = " + osVerBuf);
                            }
                            else
                            {
//                                MessageBox.Show("バージョン = " + "なぜNULL");
                            }

                            if (mo["CSDVersion"] != null)
                            {
                                osVerBuf = osVerBuf + " " + mo["CSDVersion"].ToString();
//                                MessageBox.Show("CSDバージョン = " + osVerBuf);
                            }
                            else
                            {
//                                MessageBox.Show("CSDバージョン = " + "なぜNULL");
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
        /// MACアドレス取得処理
        /// </summary>
        /// <returns>MACアドレス</returns>
        /// <remarks>
        /// <br>Note       : MACアドレスを取得する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2019.01.02</br>
        /// </remarks>
        private static string GetMacString()
        {
            // ネットワークが利用できない場合は終了する
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
        /// MD5のハッシュ値に変換処理
        /// </summary>
        /// <param name="srcStr">文字列</param>
        /// <returns>MD5のハッシュ値</returns>
        /// <remarks>
        /// <br>Note       : 文字列をMD5のハッシュ値に変換する。</br>
        /// <br>Programmer : 彭松</br>
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
        /// HTTPリクエスト
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
                //直接指定アドレスへ接続確認する。
                using (TcpClient tcpClient = new TcpClient(nSNetworkTestInfo.NSNetworkTestTargetUri.Host, nSNetworkTestInfo.NSNetworkTestTargetUri.Port))
                {
                    result = tcpClient.Connected;
                }
            }
            catch (Exception ex)
            {
                result = false;
                //ステータスコードの分からない例外は全て「-1」とする。
                nSNetworkTestInfo.WebRequestStatusNo = -1;
                nSNetworkTestInfo.Ex = ex;
            }

            return result;
        }

        /// <summary>
        /// FTPチェック処理
        /// </summary>
        /// <param name="nSNetworkTestInfo">ネットワークテスト情報</param>
        /// <param name="localFileNm">ファイル名称</param>
        /// <returns>result</returns>
        /// <remarks>
        /// <br>Note       : FTPチェック処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
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
                //5秒ウエイトする。
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
                //ステータスコードの分からない例外は全て「-1」とする。
                nSNetworkTestInfo.WebRequestStatusNo = -1;
                nSNetworkTestInfo.Ex = ex;
            }

            return result;
        }

        /// <summary>
        /// プロキシサーバーの種別チェック
        /// </summary>
        /// <returns></returns>
        public static ProxyInfo CheckProxy()
        {
            Uri target = new Uri("http://www.broadleaf.co.jp");
            return CheckProxyProc(target);
        }

        /// <summary>
        /// プロキシサーバーの種別チェック
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

        #region プライベートメソッド
        /// <summary>
        /// ファイルアップロード処理(FTP)
        /// </summary>
        /// <param name="remoteUri">FTPパス</param>
        /// <param name="ftpUserID">ログインユーザーID</param>
        /// <param name="ftpPassword">ログインパースワード</param>
        /// <param name="localPath">ファイルパス</param>
        /// <param name="mode">FTP転送モード(true:Passiveモード)</param>
        /// <param name="statusNo">ステータス</param>
        /// <param name="statusMessage">メッセージ</param>
        /// <returns>アップロード結果</returns>
        /// <remarks>
        /// <br>Note       : パラメータで指定したFTPサーバーに指定したファイルをアップロードする。</br>
        /// <br>Programmer : 朱宝軍</br>
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
        /// ファイル削除処理(FTP)
        /// </summary>
        /// <param name="remoteUri">FTPパス</param>
        /// <param name="ftpUserID">ログインユーザーID</param>
        /// <param name="ftpPassword">ログインパースワード</param>
        /// <param name="localPath">ファイルパス</param>
        /// <param name="mode">FTP転送モード(true:Passiveモード)</param>
        /// <param name="statusNo">ステータス</param>
        /// <param name="statusMessage">メッセージ</param>
        /// <returns>削除結果</returns>
        /// <remarks>
        /// <br>Note       : パラメータで指定したFTPサーバーから指定したファイルを削除する。</br>
        /// <br>Programmer : 朱宝軍</br>
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
        /// HTTPリクエスト
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

                //プロキシ経由で接続する必要が有る場合
                if (nSNetworkTestInfo.ProxyInfo != null && nSNetworkTestInfo.ProxyInfo.IsProxy != ProxyInfo.ProxyType.NOT_USE)
                {
                    httpWebRequest.Proxy = new WebProxy(nSNetworkTestInfo.ProxyInfo.ProxyUrl);
                    if (nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.NONE)
                    {
                        //認証無
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

                //サーバーからの応答を受信するためのWebResponseを取得
                nSNetworkTestInfo.WebRequestStatusNo = GetResponseStream(out responseMessage, httpWebRequest);
                //HTTPリクエスト結果をセット
                nSNetworkTestInfo.WebRequestStatusMessage = responseMessage;

                if (nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.OK)
                {
                    //通信OK
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
                    //ステータスコードが分からない例外は全て「-1」とする。
                    nSNetworkTestInfo.WebRequestStatusNo = -1;
                }
                else
                {
                    //HTTPリクエストのステータスをセット
                    nSNetworkTestInfo.WebRequestStatusNo = (int)((HttpWebResponse)webex.Response).StatusCode;

                    //APサーバーかつリクエストステータスが500のものはコネクション確立が出来たので正常とみなす。
                    if (nSNetworkTestInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP)
                    {
                        if (nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.InternalServerError)
                        {
                            result = true;
                        }
                    }
                }

                //例外クラスをセット
                nSNetworkTestInfo.Ex = webex;
                //HTTPリクエストのエラーの詳細をセット
                nSNetworkTestInfo.WebRequestStatusMessage = webex.Message;
            }
            catch (Exception ex)
            {
                //ステータスコードが分からない例外は全て「-1」とする。
                nSNetworkTestInfo.WebRequestStatusNo = -1;
                //例外クラスをセット
                nSNetworkTestInfo.Ex = ex;
                //HTTPリクエストのエラーの詳細をセット
                nSNetworkTestInfo.WebRequestStatusMessage = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// HTTPレスポンス取得
        /// </summary>
        /// <param name="httpWebRequest"></param>
        /// <param name="responseMessage"></param>
        /// <returns></returns>
        private static int GetResponseStream(out string responseMessage, HttpWebRequest httpWebRequest)
        {
            int status = -1;

            //サーバーからの応答を受信するためのWebResponseを取得
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                //HTTPリクエストのステータスをセット
                status = (int)httpWebResponse.StatusCode;

                //応答データを受信するためのStreamを取得
                using (System.IO.Stream stream = httpWebResponse.GetResponseStream())
                {
                    using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.Default))
                    {
                        responseMessage = streamReader.ReadToEnd();  //受信
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// プロキシサーバーの種別チェック
        /// </summary>
        /// <returns></returns>
        private static ProxyInfo CheckProxyProc(Uri target)
        {
            int status = -1;
            string responseMessage;
            ProxyInfo proxyInfo = new ProxyInfo();

            //デフォルトプロキシ設定の取得（基本的にIEで設定されているやつが取れる）
            Uri testUri = target;
            Uri proxyUri = target;
            //Uri testUri = new Uri("http://www.broadleaf.co.jp");
            //Uri proxyUri = new Uri("http://www.broadleaf.co.jp");

            try
            {
                proxyUri = WebRequest.DefaultWebProxy.GetProxy(testUri);
                if (proxyUri == testUri)
                {
                    //プロキシ無し
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.NOT_USE;
                    return proxyInfo;
                }
            }
            catch (WebException wex)
            {
                //ここでの例外は無視する。
                proxyInfo.Ex = wex;
            }

            //プロキシ有り
            proxyInfo.IsProxy = ProxyInfo.ProxyType.USE;
            proxyInfo.ProxyUrl = proxyUri.ToString();

            try
            {
                //プロキシのバイパスリストを取得する　※ただし、非推奨メソッドから取得するので確実性は低下すると思われる
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

                //●デフォルト設定で通信が可能かチェック
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if (status == (int)HttpStatusCode.OK)
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.NONE;
                    return proxyInfo;
                }
            }
            catch (WebException wex)
            {
                //ここでの例外は無視する。
                proxyInfo.Ex = wex;
            }


            //プロキシ設定
            IWebProxy proxyObject = new WebProxy(proxyUri);

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //●プロキシへのNTLM認証（Windows統合）をセットする
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
                //ここでの例外は無視する。
                proxyInfo.Ex = wex;
            }

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //●プロキシへのBASIC認証情報をセットする
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
                //最終的なWEB例外をセットする。
                proxyInfo.Ex = wex;
            }
            catch
            {
                //ここでの例外は無視する。
            }


            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //●プロキシを使用しないで直接接続する
                httpWebRequest.Proxy = null;
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if (status == (int)HttpStatusCode.OK)
                {
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.FREE_USE;
                }
            }
            catch
            {
                //ここでの例外は無視する。
            }

            //プロキシへの認証の種類が判別できなかった。
            proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.UNKNOWN;
            return proxyInfo;
        }



        #endregion
    }
}

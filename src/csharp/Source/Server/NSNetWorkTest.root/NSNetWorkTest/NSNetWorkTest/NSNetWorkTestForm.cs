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

        /// <summary>拠点管理のリモート</summary>
        private IAPNSNetworkTestDB _iAPNSNetworkTestDB;

        /// <summary>
        /// 拠点管理のリモートを取得します。
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
        /// 前回実行結果情報クラスリスト
        /// </summary>
        List<NSNetworkTestInfo> _nSNetworkTestInfoList = null;

        public NSNetWorkTestForm()
        {
            InitializeComponent();
        }


        #region [ 通信テスト処理 ]
        /// <summary>
        /// 通信テスト処理します。
        /// </summary>
        internal void NetWorkTestToAP()
        {
            int result = 0;

            try
            {
                //　実行時間
                long testDateTime = long.Parse(DateTime.Now.Year.ToString("D4")
                                           + DateTime.Now.Month.ToString("D2")
                                           + DateTime.Now.Day.ToString("D2")
                                           + DateTime.Now.Hour.ToString("D2")
                                           + DateTime.Now.Minute.ToString("D2")
                                           + DateTime.Now.Second.ToString("D2"));

                // 本機Ipv4のIPを取得します。
                string ip = this.GetLocalIpv4();

                //  テスト設定ファイルが存在しない場合
                if (!File.Exists(Application.StartupPath + "\\" + _fileName))
                {
                    result = 1;

                    this.Save(ip, testDateTime, result);

                    return;
                }

                // DBに既存データを検索します。
                // 既存データある場合、処理を停止します。
                ArrayList tusinTestLogSearchList = new ArrayList();
                TusinTestLogWork tusinTestLogSearchWork = new TusinTestLogWork();
                // 企業コード
                tusinTestLogSearchWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // 本機Ipv4のIP
                tusinTestLogSearchWork.MachineIPAddr = ip;
                // 検索条件用ワークを作成します。
                tusinTestLogSearchList.Add(tusinTestLogSearchWork);
                // 検索処理
                string message = string.Empty;
                int status = PMNSNetworkTestDB.SearchLogData(tusinTestLogSearchList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // 既存データがある場合、処理を停止します。
                    return;
                }

                // テスト項目情報を取得する。
                List<NSNetworkTestInfo> nSNetworkTestInfoList;
                if (!NSNetworkTestInfoList_Deserialize(out nSNetworkTestInfoList, Application.StartupPath + "\\" + _fileName))
                {
                    // BINファイルを分析失敗の場合、処理を停止します。
                    return;
                }

                #region テスト項目毎にリスト分け
                List<NSNetworkTestInfo> proxyTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.PROXY; });
                List<NSNetworkTestInfo> webTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.WEB; });
                List<NSNetworkTestInfo> apTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP; });
                List<NSNetworkTestInfo> bitsTestList = nSNetworkTestInfoList.FindAll(delegate(NSNetworkTestInfo workInfo) { return workInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.BITS; });
                #endregion

                #region プロキシ
                //●プロキシテスト・設定取得
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
                            //ステータスコードが分からない例外は全て「-1」とする。
                            nSNetworkTestInfo.WebRequestStatusNo = -1;
                        }
                        else
                        {
                            //HTTPリクエストのステータスをセット
                            nSNetworkTestInfo.WebRequestStatusNo = (int)((HttpWebResponse)webex.Response).StatusCode;
                        }
                    }
                }
                if (proxyInfo.IsProxy == ProxyInfo.ProxyType.USE && proxyInfo.ProxyAuthentication != ProxyInfo.AuthenticationType.NONE)
                {
                    //認証が必要なプロキシを利用している時にエラーとする。
                    //※認証が必要なしは正常に動作する。
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

                // テスト結果をリストに再セットする。
                _nSNetworkTestInfoList = nSNetworkTestInfoList;

                // テスト結果をDBに保存します。
                this.Save(ip, testDateTime, result);

            }
            catch (Exception ex)
            {
                // なし。
            }
            finally
            {
                // なし。
            }
        }
        #endregion

        #region [ 通信テスト結果をDBに保存処理 ]
        /// <summary>
        /// ログファイルをDBに保存します。
        /// </summary>
        /// <param name="ip">ipv4のip</param>
        /// <param name="resultFlg">保存状態「０：OK　１：NG」</param>
        /// <returns></returns>
        private void Save(string ip, long testDateTime, int resultFlg)
        {
            // 保存リストを作成します。
            ArrayList tusinTestLogList = new ArrayList();
            TusinTestLogWork tusinTestLogWork = new TusinTestLogWork();
            // 企業コード
            tusinTestLogWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // IP
            tusinTestLogWork.MachineIPAddr = ip;
            // 実行開始時間
            tusinTestLogWork.TestDateTime = long.Parse(DateTime.Now.Year.ToString("D4")
                                            + DateTime.Now.Month.ToString("D2")
                                            + DateTime.Now.Day.ToString("D2")
                                            + DateTime.Now.Hour.ToString("D2")
                                            + DateTime.Now.Minute.ToString("D2")
                                            + DateTime.Now.Second.ToString("D2"));

            // テスト結果がOKの場合、
            if (resultFlg == 0)
            {
                tusinTestLogWork.TestResults = 0;
            }
            // テスト結果がNGの場合、
            else if (resultFlg == 1)
            {
                // エラー内容を設定します。
                tusinTestLogWork.TestErrContents = "設定ファイルが存在しません";
                tusinTestLogWork.TestResults = 1;
            }
            // テスト結果がNGの場合、
            else
            {
                // エラー内容を設定します。
                tusinTestLogWork.TestErrContents = GetResultString();
                tusinTestLogWork.TestResults = 1;
            }

            // 保存リストを追加します。
            tusinTestLogList.Add(tusinTestLogWork);

            // エラー内容はDBに保存します。
            string message = string.Empty;
            int status = PMNSNetworkTestDB.InsertLogData(tusinTestLogList, out message);
        }
        #endregion

        #region データクラス保存、読み込み処理
        /// <summary>
        /// データクラス読み込み
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
        /// ファイル読込処理
        /// </summary>
        /// <param name="logFilePath">保存ファイルパス</param>
        /// <param name="logFileName">保存ファイル名称</param>
        /// <param name="desKey">暗号化キー</param>
        /// <param name="desIv">暗号化キー</param>
        /// <returns>読込結果</returns>
        private byte[] FileReadProc(string logFilePath, string logFileName, out byte[] desKey, out byte[] desIv)
        {
            desKey = null;
            desIv = null;
            byte[] result = null;

            //フルパス取得
            string logFileFullPath = logFileName;

            //①画像情報が存在しない場合終了
            if (!File.Exists(logFileFullPath))
                return result;

            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                //--------------------------------?------------------------------
                RijndaelManaged rijndaelManaged = new RijndaelManaged();

                fs = new FileStream(logFileFullPath, FileMode.Open);
                //①ファイル読み込み
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
                throw new Exception(string.Format("ファイルの読込に失敗しました。Exception:{0}  FilePath:{1}", ex.Message, logFileFullPath), ex);
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
        /// 複合化処理
        /// </summary>
        /// <param name="data">複合化対象データ</param>
        /// <param name="desKey">暗号化KEY</param>
        /// <param name="desIv">暗号化KEY</param>
        /// <returns>複合結果</returns>
        private byte[] CompoundDataProc(byte[] data, byte[] desKey, byte[] desIv)
        {
            // Trippe DES のサービス プロバイダを生成します
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            byte[] destination;

            // 入出力用のストリームを生成します
            using (MemoryStream ms = new MemoryStream())
            {
                CryptoStream cs = new CryptoStream(ms, rijndaelManaged.CreateDecryptor(desKey, desIv), CryptoStreamMode.Write);

                // ストリームに暗号化されたデータを書き込みます
                cs.Write(data, 0, data.Length);
                cs.Close();

                // 復号化されたデータを byte 配列で取得します
                destination = ms.ToArray();
                ms.Close();
            }
            return destination;
        }
        #endregion

        #region 共通処理
        /// <summary>
        /// テスト実行部
        /// </summary>
        /// <param name="proxyInfo"></param>
        /// <param name="nSNetworkTestInfoList"></param>
        /// <returns></returns>
        private bool TestProc(ProxyInfo proxyInfo, List<NSNetworkTestInfo> nSNetworkTestInfoList)
        {
            bool result = true;
            //各種テストを行う。
            foreach (NSNetworkTestInfo nSNetworkTestInfo in nSNetworkTestInfoList)
            {
                //●テストを行わない。
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.NONE_TEST)
                {
                    nSNetworkTestInfo.CheckResult = false;
                    continue;
                }

                #region Proxy情報
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS)
                {
                    //BITS（WINHTTP)のプロキシ設定を取得
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
                //●HTTPリクエストテストを行う。
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

                #region ポート
                //●ポート接続テストを行う。
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
                //●BITS配信テストを行う。
                if (nSNetworkTestInfo.NSNetworkTestType == NSNetworkTestInfo.TestType.BITS)
                {
                    //BITS（WINHTTP)のプロキシ設定を取得
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
        /// Ipv4のIPを取得すます
        /// </summary>
        /// <returns>Ipv4のIP</returns>
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

        #region テスト結果表示
        /// <summary>
        /// テスト結果詳細表示用文字列取得
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
                        stringBuilder.Append(string.Format("\r\n【{0}】\r\n", NSNetworkTestInfo.GetServerTypeName(nSNetworkTestInfo.NSNetworkServerType)));
                        errorDictionary.Add(nSNetworkTestInfo.NSNetworkServerType);
                    }

                    string exMessage = nSNetworkTestInfo.Ex.Message;
                    if (0 <= nSNetworkTestInfo.Ex.Message.IndexOf("リモート名を解決できませんでした。:"))
                    {
                        try
                        {
                            //ドメインがエラーメッセージに表示されるのでそれを隠蔽する。
                            exMessage = nSNetworkTestInfo.Ex.Message.Split(new char[] { ':' })[0];
                        }
                        catch
                        {
                            //ここのエラーは無視する。
                        }
                    }
                    stringBuilder.Append(string.Format("　■[{0}]\r\n", nSNetworkTestInfo.NSNetworkTestName));
                    stringBuilder.Append(string.Format("　　 ・[{0}]：{1}\r\n", nSNetworkTestInfo.WebRequestStatusNo, exMessage));
                }
            }

            return stringBuilder.ToString();
        }
        #endregion

    }
}
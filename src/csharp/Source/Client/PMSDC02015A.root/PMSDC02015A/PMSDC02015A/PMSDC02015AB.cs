//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上連携手動送信
// プログラム概要   : 売上連携手動送信帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570219-00     作成担当 : 小原
// 作 成 日  2019/12/05      修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上連携手動送信 通信用アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売上連携手動送信の通信で使用する。</br>
    /// <br>Programmer	: 小原</br>
    /// <br>Date		: 2019/12/05</br>
    /// </remarks>
    public class SalesCprtAcsSendRequest
    {
        #region ■ Constructor
        /// <summary>
        /// 売上連携手動送信アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上連携手動送信アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2019/12/05</br>
        /// </remarks>
        public SalesCprtAcsSendRequest()
        {
        }

        /// <summary>
        /// 売上連携手動送信アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上連携手動送信アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2019/12/05</br>
        /// </remarks>
        static SalesCprtAcsSendRequest()
        {
        }
        #endregion ■ Constructor

        #region ■ Static Member

        #region API定義
        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        [DllImport("wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int InternetAttemptConnect(int dwReserved);
        #endregion
        #endregion ■ Static Member

        #region ■ Private Member
        /// <summary>
        /// HTTPリクエストオブジェクト
        /// </summary>
        private HttpWebRequest request = null;

        private const string STRING_BOUNDARY = "-----------------------------7d21cef303f8";
        private const int ERROR_SUCCESS = 0;
        /// <summary> XMLファイル名称 </summary>
        private const string XML_FILE_NAME = "PMSDC02015A_UserSetting.xml";
        private DataSet UiDataSet;

        #endregion ■ Private Member

        #region ■ Public Property
        #endregion ■ Public Property

        #region ■ Public Method
        /// <summary>
        /// Webサーバに送信します。
        /// </summary>
        /// <param name="connectInfoWork">売上連携接続情報</param>
        /// <param name="fileName">ファイル名</param>
        /// <param name="errFlag">エラーフラグ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="timeout">タイムアウト</param>
        /// <param name="retryCnt">リトライ回数</param>
        /// <remarks>
        /// <br>Note	   : Webサーバに送信します。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2019/12/05</br>								
        /// </remarks>
        /// <returns>ステータス</returns>
        public String SendRequest(SalCprtConnectInfoWork connectInfoWork, String fileName, ref bool errFlag, ref string errMsg, int timeout, int retryCnt)
        {
            String ret = "0";
            String dataPath = System.IO.Path.GetFullPath(ConstantManagement_ClientDirectory.PRTOUT);
            String boundary = Environment.TickCount.ToString();
            Encoding enc = Encoding.GetEncoding("shift_jis");
            
            ret = this.RequestOpen(connectInfoWork, out errMsg);
            if (ret != "0")
            {
                return ret;
            }
            ret = this.HeaderMake(connectInfoWork, out errMsg);
            if (ret != "0")
            {
                return ret;
            }
            //POST送信するデータを作成
            string postData = "";
            System.IO.FileStream fs = null;
            System.IO.Stream reqStream = null;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)0x00000C00 | (SecurityProtocolType)0x00000300;

            //postData = "--" + boundary + "\r\n" + "Content-Disposition: form-data; name=\"xml_data\"; filename=\"" +
            //        fileName + "\"\r\n" +
            //    "Content-Type: application/octet-stream";
            try
            {
                postData = STRING_BOUNDARY + "\r\n" + 
                           "Content-Disposition: form-data; name=\"xml_data\"; filename=\"" + fileName + "\"\r\n" +
                           "Content-Type: application/octet-stream" + "\r\n"
                            + "\r\n";

                //バイト型配列に変換
                byte[] startData = enc.GetBytes(postData);
                //postData = "\r\n--" + STRING_BOUNDARY + "--\r\n";
                postData = "\r\n" + STRING_BOUNDARY + "--\r\n";
                byte[] endData = enc.GetBytes(postData);

                //送信するファイルを開く
                fs = new System.IO.FileStream(Path.Combine(dataPath, fileName), System.IO.FileMode.Open,
                    System.IO.FileAccess.Read);

                //POST送信するデータの長さを指定
                request.ContentLength = startData.Length + endData.Length + fs.Length;

                string proxy = GetProxy();
                if (!string.IsNullOrEmpty(proxy))
                {
                    request.Proxy = new System.Net.WebProxy(proxy);
                }
                
                //データをPOST送信するためのStreamを取得
                reqStream = request.GetRequestStream();
                //送信するデータを書き込む
                reqStream.Write(startData, 0, startData.Length);
                //ファイルの内容を送信
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

                //サーバーからの応答を受信するためのWebResponseを取得
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)0x00000C00 | (SecurityProtocolType)0x00000300;
                System.Net.HttpWebResponse res =
                    (System.Net.HttpWebResponse)request.GetResponse();
                //応答データを受信するためのStreamを取得
                System.IO.Stream resStream = res.GetResponseStream();
                //受信して表示
                System.IO.StreamReader sr =
                    new System.IO.StreamReader(resStream, enc);
            }
            catch (WebException wex)
            {
                ret = "90107";
                errMsg = "WebException Message:" + wex.Message + "\r\n" +
                    "Response:" + wex.Response + "\r\n" +
                    "Source:" + wex.Source + "\r\n" +
                    "Status:" + wex.Status;
            }
            catch (Exception ex)
            {
                ret = "90101";
                errMsg = "Exception Message:" + ex.Message + "\r\n" +
                    "Source:" + ex.Source;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
                if (reqStream != null)
                {
                    reqStream.Close();
                }
            }

            return ret;
        }


        /// <summary>
        /// 回線オープン処理
        /// </summary>
        /// <param name="connectInfo">条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 回線オープン処理します。</br>
        /// <br>Programmer	: 小原</br>
        /// <br>Date        : 2019/12/05</br>									
        /// </remarks>
        private string RequestOpen(SalCprtConnectInfoWork connectInfo, out string errMsg)
        {
            bool isConnected;
            int flags;
            string ret = "0";
            errMsg = string.Empty;
            try
            {
                isConnected = InternetGetConnectedState(out flags, 0);

                if (InternetAttemptConnect(0) != ERROR_SUCCESS || isConnected == false)
                {
                    // 回線オープンエラー
                    ret = "90108";
                    return ret;
                }
                string httpHead = "";

                //HTTPS プロトコル  
                if (connectInfo.Protocol == 0)
                {
                    httpHead = "http://";
                }
                else
                {
                    httpHead = "https://";
                }
                //接続先情報マスタの発注手配区分（ダイハツ）＋接続先情報マスタの発注URL＋接続先情報マスタの在庫確認URL
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)0x00000C00 | (SecurityProtocolType)0x00000300;
                request = (HttpWebRequest)HttpWebRequest.Create(httpHead + connectInfo.CprtDomain + connectInfo.CprtUrl);
                request.Method = "POST";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";
            }
            catch (WebException wex)
            {
                ret = "90103";
                errMsg = "WebException Message:" + wex.Message + "\r\n" +
                    "Response:" + wex.Response + "\r\n" +
                    "Source:" + wex.Source + "\r\n" +
                    "Status:" + wex.Status;
            }
            catch (Exception ex)
            {
                ret = "90102";
                errMsg = "Exception Message:" + ex.Message + "\r\n" +
                    "Source:" + ex.Source;
            }
            return ret;
        }

        /// <summary>
        /// ヘッダ情報追加
        /// </summary>
        /// <param name="connectInfo">条件</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note		: ヘッダ情報追加します。</br>
        /// <br>Programmer	: 小原</br>
        /// <br>Date        : 2019/12/05</br>								
        /// </remarks>
        private string HeaderMake(SalCprtConnectInfoWork connectInfo, out string errMsg)
        {
            string ret = "0";
            errMsg = string.Empty;
            try
            {
                request.Accept = "*/*";
                request.Headers.Add("Accept-Language", "ja");
                //WSSE認証用の文字列を作る
                string wsse = CreateWSSEToken(connectInfo.SendCcnctUserid, connectInfo.SendCcnctPass, out errMsg, out ret);
                if (ret != "0")
                {
                    return ret;
                }
                request.Headers.Add("X-WSSE:" + wsse);

                request.ContentType = "multipart/form-data; boundary=" + STRING_BOUNDARY.Substring(2);
                request.KeepAlive = true;
                //接続先情報マスタのログインタイムアウト
                if (connectInfo.LoginTimeoutVal != 0)
                {
                    request.Timeout = connectInfo.LoginTimeoutVal * 1000;
                }
            }
            catch (Exception ex)
            {
                ret = "90104";
                errMsg = "Exception Message:" + ex.Message + "\r\n" +
                    "Source:" + ex.Source;
            }
            return ret;
        }

        /// <summary>
        /// 認証用摘要をを生成します。
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="ret">エラーコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 認証用摘要をを生成します。</br>
        /// <br>Programmer	: 小原</br>
        /// <br>Date        : 2019/12/05</br>							
        /// </remarks>
        private string CreateWSSEToken(string userName, string password, out string errMsg, out string ret)
        {
            //StringBuilder wsseToken = new StringBuilder();
            string wsseToken = String.Empty;
            errMsg = string.Empty;
            ret = "0";
            try
            {
                // --- MOD Kishi ---------->>>>>
                //string nonce = CreateNonce(out errMsg);
                string nonceString = CreateNonce(out errMsg);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    ret = "90106";
                    return string.Empty;
                }
                byte[] nonce = System.Text.Encoding.UTF8.GetBytes(nonceString);
                // --- MOD Kishi ----------<<<<<

                string created = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffffZ");
                // --- MOD Kishi ---------->>>>>
                //string passwordDigest = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetDigest(String.Format("{0}{1}{2}", nonce, created, password), out errMsg)));
                //if (!string.IsNullOrEmpty(errMsg))
                //{
                //    ret = "90106";
                //    return string.Empty;
                //}
                List<byte> lstByte = new List<byte>();
                lstByte.AddRange(nonce);
                lstByte.AddRange(System.Text.Encoding.UTF8.GetBytes(created));
                lstByte.AddRange(System.Text.Encoding.UTF8.GetBytes(password));

                SHA1Managed sha1 = new SHA1Managed();
                byte[] passwordDigest = sha1.ComputeHash(lstByte.ToArray());
                // --- MOD Kishi ----------<<<<<

                //Username Tokenの文字列を生成する 
                // --- MOD Kishi ---------->>>>>
                //wsseToken.Append("UsernameToken ");
                //wsseToken.AppendFormat("Username=\"{0}\", ", userName);
                //wsseToken.AppendFormat("PasswordDigest=\"{0}\", ", passwordDigest);
                //wsseToken.AppendFormat("Nonce=\"{0}\", ", nonce);
                //wsseToken.AppendFormat("Created=\"{0}\" ", created);
                string format = " UsernameToken Username=\"{0}\", PasswordDigest=\"{1}\", Nonce=\"{2}\", Created=\"{3}\"";

                wsseToken = String.Format(format,
                                                  userName,
                                                  Convert.ToBase64String(passwordDigest),
                                                  Convert.ToBase64String(nonce), created);
                // --- MOD Kishi ----------<<<<<
            }
            catch (Exception ex)
            {
                ret = "90105";
                errMsg = "Exception Message:" + ex.Message + "\r\n" +
                    "Source:" + ex.Source;
            }

            return wsseToken;
        }

        /// <summary>
        /// Nonceを生成します。
        /// Nonceは精度の高い擬似乱数生成器を利用してください。
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: Nonceは精度の高い擬似乱数生成します。</br>
        /// <br>Programmer	: 小原</br>
        /// <br>Date        : 2019/12/05</br>								
        /// </remarks>
        private string CreateNonce(out string errMsg)
        {
            Random r = new Random();
            double d1 = r.NextDouble();
            double d2 = d1 * d1;
            return GetDigest(d2.ToString(), out errMsg);
        }

        /// <summary>
        /// 16進数表記のSHA-1メッセージダイジェストを生成します。
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: 16進数表記のSHA-1メッセージダイジェストを生成します。</br>
        /// <br>Programmer	: 小原</br>
        /// <br>Date        : 2019/12/05</br>							
        /// </remarks>
        private string GetDigest(string source, out string errMsg)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            StringBuilder answer = new StringBuilder();
            errMsg = string.Empty;
            try
            {

                foreach (Byte b in sha1.ComputeHash(Encoding.UTF8.GetBytes(source)))
                {
                    if (b < 16)
                    {
                        answer.Append("0");
                    }
                    answer.Append(Convert.ToString(b, 16));
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return answer.ToString();
        }

        /// <summary>
        /// ファイルを変更
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: ファイルを変更します。</br>
        /// <br>Programmer	: 小原</br>
        /// <br>Date        : 2019/12/05</br>								
        /// </remarks>
        private string fileChange(string fileName)
        {
            //ファイルへ送信
            string fileString = "";
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                byte[] byDate = new byte[file.Length];
                char[] charDate = new char[file.Length];
                file.Read(byDate, 0, (int)file.Length);
                Decoder d = Encoding.UTF8.GetDecoder();
                d.GetChars(byDate, 0, byDate.Length, charDate, 0);
                for (int i = 0; i < charDate.Length; i++)
                {
                    fileString = fileString + charDate[i];
                }
                file.Close();
            }
            catch (Exception)
            {
                fileString = "";
            }
            return fileString;
        }

        /// <summary>
        /// Proxy取得
        /// </summary>
        /// <returns>Proxy</returns>
        /// <remarks>
        /// <br>Note	   :  Proxyを取得します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/10</br>						
        /// </remarks>
        public string GetProxy()
        {
            string proxy = string.Empty;
            try
            {
                string fileName = Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME);

                if (UserSettingController.ExistUserSetting(fileName))
                {
                    if (UiDataSet == null)
                    {
                        UiDataSet = new DataSet();
                    }
                    UiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, fileName));
                    proxy = UiDataSet.Tables["WebProxy"].Rows[0][0].ToString();
                }
            }
            catch
            {
                proxy = string.Empty;
            }
            return proxy;
        }

        #endregion ■ Private Method
    }
}

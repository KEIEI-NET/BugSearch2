using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

using Broadleaf.NSNetworkTest.Data;

namespace Broadleaf.NSNetworkTest.Net
{
    /// <summary>
    /// ネットワーク通信処理クラス
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	上野　耕平</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    public class NSNetworkTestAccess
    {
        #region パブリックメソッド
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
                using( TcpClient tcpClient = new TcpClient(nSNetworkTestInfo.NSNetworkTestTargetUri.Host, nSNetworkTestInfo.NSNetworkTestTargetUri.Port) )
                {
                    result = tcpClient.Connected;
                }
            }
            catch( Exception ex )
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
                if( winHTTP_PROXY_INFO.lpszProxy == null || winHTTP_PROXY_INFO.lpszProxy == "" )
                {
                    proxyInfo.IsProxy =  ProxyInfo.ProxyType.NOT_USE;
                }
                else
                {
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.USE;
                    proxyInfo.ProxyUrl = winHTTP_PROXY_INFO.lpszProxy;
                }
            }
            catch(Exception ex)
            {
                proxyInfo.Ex = ex;
            }

            return proxyInfo;
        }

        #endregion

        #region プライベートメソッド
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
                if( nSNetworkTestInfo.ProxyInfo != null && nSNetworkTestInfo.ProxyInfo.IsProxy != ProxyInfo.ProxyType.NOT_USE )
                {
                    httpWebRequest.Proxy = new WebProxy(nSNetworkTestInfo.ProxyInfo.ProxyUrl);
                    if( nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.NONE )
                    {
                        //認証無
                    }
                    else if( nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.BASIC )
                    {
                        httpWebRequest.Proxy.Credentials = new NetworkCredential("id", "pwd");
                    }
                    else if( nSNetworkTestInfo.ProxyInfo.ProxyAuthentication == ProxyInfo.AuthenticationType.WINDOWS )
                    {
                        httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                    }
                }

                //サーバーからの応答を受信するためのWebResponseを取得
                nSNetworkTestInfo.WebRequestStatusNo = GetResponseStream(out responseMessage, httpWebRequest);
                //HTTPリクエスト結果をセット
                nSNetworkTestInfo.WebRequestStatusMessage = responseMessage;

                if( nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.OK )
                {
                    //通信OK
                    result = true;
                }
                else
                {
                    if( nSNetworkTestInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP )
                    {
                        if( nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.InternalServerError )
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
            catch( WebException webex )
            {
                if( webex.Response == null )
                {
                    //ステータスコードが分からない例外は全て「-1」とする。
                    nSNetworkTestInfo.WebRequestStatusNo = -1;
                }
                else 
                {
                    //HTTPリクエストのステータスをセット
                    nSNetworkTestInfo.WebRequestStatusNo = (int)( (HttpWebResponse)webex.Response ).StatusCode;

                    //APサーバーかつリクエストステータスが500のものはコネクション確立が出来たので正常とみなす。
                    if( nSNetworkTestInfo.NSNetworkServerType == NSNetworkTestInfo.ServerType.AP )
                    {
                        if( nSNetworkTestInfo.WebRequestStatusNo == (int)HttpStatusCode.InternalServerError )
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
            catch( Exception ex )
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
            using( HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse() )
            {
                //HTTPリクエストのステータスをセット
                status = (int)httpWebResponse.StatusCode;

                //応答データを受信するためのStreamを取得
                using( System.IO.Stream stream = httpWebResponse.GetResponseStream() )
                {
                    using( System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, Encoding.Default) )
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
                if( proxyUri == testUri )
                {
                    //プロキシ無し
                    proxyInfo.IsProxy = ProxyInfo.ProxyType.NOT_USE;
                    return proxyInfo;
                }
            }
            catch( WebException wex )
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
                if(workProxy.Address != null && workProxy.Address.ToString() == proxyUri.ToString())
                {
                    proxyInfo.ProxyBypass.AddRange(workProxy.BypassList);
                }
            }
            catch(Exception ex)
            {
            }

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(testUri);

                //●デフォルト設定で通信が可能かチェック
                status = GetResponseStream(out responseMessage, httpWebRequest);
                if( status == (int)HttpStatusCode.OK )
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.NONE;
                    return proxyInfo;
                }
            }
            catch( WebException wex )
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
                if( status == (int)HttpStatusCode.OK )
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.WINDOWS;
                    return proxyInfo;
                }
            }
            catch( WebException wex )
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
                if( status == (int)HttpStatusCode.OK )
                {
                    proxyInfo.ProxyAuthentication = ProxyInfo.AuthenticationType.BASIC;
                    return proxyInfo;
                }
            }
            catch( WebException wex )
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
                if( status == (int)HttpStatusCode.OK )
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

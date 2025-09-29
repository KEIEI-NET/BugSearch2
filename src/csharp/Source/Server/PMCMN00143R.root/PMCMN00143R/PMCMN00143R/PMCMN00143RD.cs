//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動更新メンテナンス
// プログラム概要   : コンバート対象自動更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
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
    /// コンバート対象自動更新WebRequest
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象自動更新WebRequest</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjDBWebRequest
    {
        #region 列挙体

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

        #endregion //列挙体

        #region 定数

        /// <summary>
        /// 設定ファイル名
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00143R_WebRequestSetting.xml";

        /// <summary>
        /// リトライ回数
        /// </summary>
        private const int RETRY_COUNT_DEFAULT = 1;

        /// <summary>
        /// リトライ間隔(ミリ秒)
        /// </summary>
        private const int RETRY_INTERVAL_DEFAULT = 1;

        /// <summary>
        /// WEBRequestタイムアウト（ミリ秒）
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

        #endregion // 定数

        #region プライベートフィールド

        /// <summary>
        /// リトライ回数
        /// </summary>
        private int _retryCount;

        /// <summary>
        /// リトライ間隔(ミリ秒)
        /// </summary>
        private int _retryInterval;

        /// <summary>
        /// WEBRequestタイムアウト（ミリ秒）
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

        #endregion //プライベートフィールド

        #region コンストラクタ

        /// <summary>
        /// コンバート対象自動更新WebRequest
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjDBWebRequest()
        {
            try
            {
                #region 設定ファイル取得

                // 初期値設定
                _retryCount = RETRY_COUNT_DEFAULT;                      // リトライ回数
                _retryInterval = RETRY_INTERVAL_DEFAULT;                // リトライ間隔(ミリ秒)
                _webRequestTimeout = WEB_REQUEST_TIMEOUT;               // WEBRequestタイムアウト（ミリ秒）
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
                #endregion // 設定ファイル取得

            }
            catch
            {
            }
        }

        #endregion //コンストラクタ

        #region コンバート対象自動更新WebRequest
        /// <summary>
        /// コンバート対象自動更新WebRequest
        /// </summary>
        /// <param name="checkParam">チェックパラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象自動更新します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
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

                // 正常終了するまでリトライ回数分リトライする
                while (retryCnt < _retryCount)
                {
                    // リトライ時waitする
                    if (retryCnt > 0)
                    {
                        Thread.Sleep(_retryInterval);
                    }

                    try
                    {
                        req = (HttpWebRequest)WebRequest.Create(_webRequestUrl);
                        req.Timeout = _webRequestTimeout;  // タイムアウト(ミリ秒)
                        req.ContentType = _webRequestContentType;
                        req.Method = _webRequestMethod;
                        req.Headers.Add("bl-api-unauthorized-param", checkParam.ToString());
                        req.Headers.Add(_webRequestHeadersKey, _webRequestHeadersValue);    // カスタムヘッダ

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
                        // 正常終了のためリトライしない
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

        #endregion //コンバート対象自動更新WebRequest

        #region ■ Private Methods

        #region XMLファイル操作
        /// <summary>
        /// XMLファイル設定情報取得処理
        /// ファイルが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // カレントディレクトリ取得
                homeDir = this.GetCurrentDirectory();

                // ディレクトリ情報にXMLファイル名を連結
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // ファイルが存在しない場合は空白にする
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch
            {
                //ログ出力
            }

            return path;
        }
        #endregion  //XMLファイル操作

        #region カレントフォルダ
        /// <summary>
        /// カレントフォルダのパス取得
        /// フォルダが存在しない場合は空文字を戻す
        /// </summary>
        /// <returns>フルパスファイル名</returns>
        /// <remarks>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML格納ディレクトリ取得
            try
            {
                // dll格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // 末尾の「\」は常になし

                // レジストリ情報よりUSER_APのキー情報を取得
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // レジストリ情報を取得できない場合は初期ディレクトリ
                        // 運用上ありえないケース
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

                // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
                // 運用上ありえないケース
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch
            {
                //ログ出力
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // カレントフォルダ

        #endregion // ■ Private Methods


    }
}

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
            /// <summary>正常</summary>
            ct_NORMAL = 0,
            /// <summary>一部登録失敗</summary>
            ct_SOME_FAIL = 5,
            /// <summary>実行中</summary>
            ct_RUN = 100,
            /// <summary>システム例外</summary>
            ct_SYS_ERROR = 1000,
            /// <summary>クライアント接続エラー</summary>
            ct_CNT_ERROR = 400,
            /// <summary>サーバー接続エラー</summary>
            ct_SVR_ERROR = 500,
            /// <summary>認証エラー</summary>
            ct_AUT_ERROR = 403,
        }

        private const string ct_BuhinMaxUrlInfoFile = "PMMAX00001B_Info.XML"; // 設定ファイル

        #region URL設定ファイル読込[DecryptFile]
        /// <summary>
        /// XML取得（複合化）処理
        /// </summary>
        /// <param name="buhinMaxUrlInfo"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int DecryptFile(out BuhinMaxUrlInfo buhinMaxUrlInfo, out string message)
        {
            int status = (int)MAX_Status.ct_SYS_ERROR;
            message = string.Empty;

            // 初期化ベクタ
            byte[] InitVector = Encoding.Default.GetBytes("Partsman");
            // ラウンドキーテーブル
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

                //共有キーと初期化ベクタを設定
                des3.IV = InitVector;
                des3.Key = Key;

                //暗号化されたファイルを読み込むためのFileStream
                inFs = new System.IO.FileStream(sourceFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                //対称復号化オブジェクトの作成
                decryptor = des3.CreateDecryptor();

                //暗号化されたデータを読み込むためのCryptoStreamの作成
                cryptStrm = new System.Security.Cryptography.CryptoStream(inFs, decryptor, System.Security.Cryptography.CryptoStreamMode.Read);

                //
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(BuhinMaxUrlInfo));

                buhinMaxUrlInfo = (BuhinMaxUrlInfo)serializer.Deserialize(cryptStrm);

                status = (int)MAX_Status.ct_NORMAL;
            }
            catch (System.IO.FileNotFoundException)
            {
                // ファイルが存在しない場合はエラーとする
                message = "部品MAX接続先情報ファイルがありません。";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                //閉じる
                if (cryptStrm != null) cryptStrm.Close();
                if (decryptor != null) decryptor.Dispose();
                if (inFs != null) inFs.Close();
            }
            return status;
        }
        #endregion URL設定ファイル読込[DecryptFile]

        #region 部品MAXログイン処理
        /// <summary>
        /// 部品MAXにログインする
        /// </summary>
        /// <param name="loginID">認証ID</param>
        /// <param name="password">認証パスワード</param>
        /// <param name="url">認証パスワード</param>
        /// <param name="cc">クッキー</param>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public int LoginBuhinMax(string loginID, string password, string url, ref CookieContainer cc, out string message)
        {
            int status = (int)MAX_Status.ct_SYS_ERROR;

            message = string.Empty;
            try
            {
                string param = "";

                // ログイン・ページへのアクセス
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic["id"] = loginID;
                dic["pwd"] = password;

                // POSTメソッドのパラメータ作成
                foreach (string key in dic.Keys)
                    param += String.Format("{0}={1}&", key, dic[key]);

                // paramをASCII文字列にエンコードする
                byte[] data = Encoding.ASCII.GetBytes(param);

                // リクエストの作成
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                //メソッドにPOSTを指定
                req.Method = "POST";
                //ContentTypeを設定
                req.ContentType = "application/x-www-form-urlencoded";
                //POST送信するデータの長さを指定
                req.ContentLength = data.Length;
                //クッキーコンテナ
                req.CookieContainer = cc;
                //読み書きタイムアウト時間
                req.ReadWriteTimeout = 60000;
                //タイムアウト時間
                req.Timeout = 60000;

#if DEBUG
                // デバッグ時のみ
                // リクエストを投げる前に行う
                if (ServicePointManager.ServerCertificateValidationCallback == null)
                {
                    ServicePointManager.ServerCertificateValidationCallback += delegate(Object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;	// 無条件でオレオレ証明を信用する。危険！(senderのURIとか調べてチェックすべし！)
                    };
                }
#endif

                //データをPOST送信するためのStreamを取得
                Stream reqStream = req.GetRequestStream();
                //送信するデータを書き込む
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();

                JsonSerializer serializer = this.GetJsonSerializer();
                SyncResponse syncRes;
                status = this.ReadSyncResponse(req, serializer, out syncRes, out message);

                if (status == (int)MAX_Status.ct_NORMAL)
                {
                    // ログイン判定（未定）
                    if (syncRes != null)
                    {
                        if (syncRes.Rst_cd == "00")
                        {
                            // 成功
                            message = "部品MAX　ログイン成功";
                            status = (int)MAX_Status.ct_NORMAL;
                        }
                        else
                        {
                            // 失敗
                            message = syncRes.Rst_msg;
                            status = (int)MAX_Status.ct_AUT_ERROR;
                        }
                    }
                    else
                    {
                        message = "ログイン処理にてエラーが発生しました。";
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
        #endregion 部品MAXログイン処理

        #region 部品MAXファイル送信処理
        /// <summary>
        /// 部品MAXにファイルを送信する
        /// </summary>
        /// <param name="url">送信先のURL</param>
        /// <param name="filePath">送信するファイルのパス</param>
        /// <param name="cc">クッキー</param>
        /// <param name="message">メッセージ</param>
        public int PostBuhinMax(string url, string filePath, ref CookieContainer cc, out string message)
        {
            message = string.Empty;
            int status = (int)MAX_Status.ct_SYS_ERROR;

            try
            {
                //送信するファイルのパス
                string fileName = Path.GetFileName(filePath);
                //文字コード
                Encoding enc = Encoding.GetEncoding("utf-8");
                //区切り文字列
                string boundary = Environment.TickCount.ToString();
                //WebRequestの作成
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                //取得済みのクッキーコンテナ
                req.CookieContainer = cc;
                //読み書きタイムアウト時間
                req.ReadWriteTimeout = 60000;
                //タイムアウト時間
                req.Timeout = 60000;
                //メソッドにPOSTを指定
                req.Method = "POST";
                //ContentTypeを設定
                req.ContentType = "multipart/form-data; boundary=" + boundary;

                //POST送信するデータを作成
                string postData = "";
                postData = "--" + boundary + "\r\n" +
                    "Content-Disposition: form-data; name=\"upfile\"; filename=\"" + fileName + "\"\r\n" +
                    "Content-Type: application/octet-stream\r\n" +
                    "Content-Transfer-Encoding: binary\r\n\r\n";
                //バイト型配列に変換
                byte[] startData = enc.GetBytes(postData);
                postData = "\r\n--" + boundary + "--\r\n";
                byte[] endData = enc.GetBytes(postData);

                //送信するファイルを開く
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                //POST送信するデータの長さを指定
                req.ContentLength = startData.Length + endData.Length + fs.Length;

#if DEBUG
                // デバッグ時のみ
                // リクエストを投げる前に行う
                if (ServicePointManager.ServerCertificateValidationCallback == null)
                {
                    ServicePointManager.ServerCertificateValidationCallback += delegate(Object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;	// 無条件でオレオレ証明を信用する。危険！(senderのURIとか調べてチェックすべし！)
                    };
                }
#endif

                //データをPOST送信するためのStreamを取得
                Stream reqStream = req.GetRequestStream();
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

                JsonSerializer serializer = this.GetJsonSerializer();
                SyncResponse syncRes;

                status = this.ReadSyncResponse(req, serializer, out syncRes, out message);
                if (status == (int)MAX_Status.ct_NORMAL)
                {
                    if (syncRes != null)
                    {
                        if (syncRes.Rst_cd == "00")
                        {
                            // 正常
                        }
                        else
                        {
                            // 異常
                            message = syncRes.Rst_msg;
                        }
                    }
                    else
                    {
                        message = "データ送信処理にてエラーが発生しました。";
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
        #endregion 部品MAXファイル送信処理

        #region JSON形式シリアライズ/デシリアライズ部品取得
        /// <summary>
        /// JSON形式へのシリアライズ/デシリアライズ部品を取得します。
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
        #endregion JSON形式シリアライズ/デシリアライズ部品取得

        #region リクエスト処理
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
                // リトライ無し
                if (retryFlg == false || retryCnt == 3)
                {
                    if (retryFlg)
                    {
                        message = "接続に失敗しました。";
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
                            // HTTPステータス: 500, 503
                            status = (int)MAX_Status.ct_SVR_ERROR;
                        }
                        else if (response.StatusCode == HttpStatusCode.BadRequest ||
                                 response.StatusCode == HttpStatusCode.Unauthorized ||
                                 response.StatusCode == HttpStatusCode.NotFound)
                        {
                            // HTTPステータス:400, 401, 404
                            status = (int)MAX_Status.ct_CNT_ERROR;
                        }
                        else if (response.StatusCode == HttpStatusCode.Forbidden)
                        {
                            // HTTPステータス:403
                            status = (int)MAX_Status.ct_AUT_ERROR;
                        }
                        retryFlg = false;
                    }
                    else
                    {
                        // ConnectFailure:接続に失敗しました。
                        // NameResolutionFailure:ドメイン ネーム サービスをホスト名を解決しませんでした。
                        if (ex.Status == WebExceptionStatus.ConnectFailure ||
                            ex.Status == WebExceptionStatus.NameResolutionFailure)
                        {
                            // リトライする
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
        #endregion リクエスト処理

         #region 部品MAX接続先URL情報
        /// <summary>
        /// ログインURL構築
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログインURL構築を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
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

                // 置換
                wkStr = UrlReplace(domain, path);
            }
            catch (Exception ex)
            {
                message = "接続先取得中にエラーが発生しました。[" + ex.Message + "]";
                return (int)MAX_Status.ct_SYS_ERROR;
            }
            finally
            {
                url = wkStr;
            }
            return status;
        }

        /// <summary>
        /// 入荷予約API用URL構築
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入荷予約API用URL構築を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
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

                // 置換
                wkStr = UrlReplace(domain, path);
            }
            catch (Exception ex)
            {
                message = "接続先取得中にエラーが発生しました。[" + ex.Message + "]";
                return (int)MAX_Status.ct_SYS_ERROR;
            }
            finally
            {
                url = wkStr;
            }
            return status;
        }

        /// <summary>
        /// 出品登録API用URL構築
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出品登録API用URL構築を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
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

                // 置換
                wkStr = UrlReplace(domain, path);
            }
            catch (Exception ex)
            {
                message = "接続先取得中にエラーが発生しました。[" + ex.Message + "]";               
                return (int)MAX_Status.ct_SYS_ERROR;
            }
            finally
            {
                url = wkStr;
            }
            return status;
        }

        /// <summary>
        /// URL置換
        /// </summary>
        /// <remarks>
        /// <br>Note       : URL置換を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2016/02/04</br>
        /// </remarks>
        protected static string UrlReplace(string domain, string path)
        {
            string wkStr = domain + path;
            // 置換
            wkStr = wkStr.Replace("$enterpriseCode", LoginInfoAcquisition.EnterpriseCode);
            wkStr = wkStr.Replace("$assemblyVersion", "1.0.0");

            return wkStr;
        }

         #endregion 部品MAX接続先URL情報

    }

    #region API共通
    /// <summary>
    /// 
    /// </summary>
    public class SyncResponse
    {
        /// <summary>コード</summary>
        private string _rst_cd;

        /// <summary>メッセージ</summary>
        private string _rst_msg;

        /// <summary>
        /// コード
        /// </summary>
        public string Rst_cd
        {
            set { this._rst_cd = value; }
            get { return this._rst_cd; }
        }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Rst_msg
        {
            set { this._rst_msg = value; }
            get { return this._rst_msg; }
        }
    }
    #endregion API共通

    #region オブジェクト破棄
    /// <summary>
    /// 
    /// </summary>
    public class ReplicaDBAccessUtils
    {
        /// <summary>
        /// コンストラクタ。
        /// </summary>
        private ReplicaDBAccessUtils()
        {
        }

        /// <summary>
        /// オブジェクトの破棄を行います。
        /// 例外が発生しても無視します。
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
    #endregion オブジェクト破棄

    #region 部品MAX接続先URL情報
    /// <summary>
    /// 部品MAX接続先URL情報
    /// </summary>
    public class BuhinMaxUrlInfo
    {
        /// <summary>ログイン連携API</summary>
        private string _cPmLoginAPI;
        /// <summary>出品入荷予約連携API</summary>
        private string _cPmExhibitItemsAPI;
        /// <summary>出品在庫一括更新連携API</summary>
        private string _cPmDervDirectAPI;

        /// <summary>
        /// ログイン連携API
        /// </summary>
        public string CPmLoginAPI
        {
            get { return _cPmLoginAPI; }
            set { _cPmLoginAPI = value; }
        }

        /// <summary>
        /// 出品入荷予約連携API
        /// </summary>
        public string CPmExhibitItemsAPI
        {
            get { return _cPmExhibitItemsAPI; }
            set { _cPmExhibitItemsAPI = value; }
        }

        /// <summary>
        /// 出品在庫一括更新連携API
        /// </summary>
        public string CPmDervDirectAPI
        {
            get { return _cPmDervDirectAPI; }
            set { _cPmDervDirectAPI = value; }
        }
    }
    #endregion 部品MAX接続先URL情報




}

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
// システム         ：.NSシリーズ
// プログラム名称   ：ユーザーデータ吸い上げツール
// プログラム概要   ：ユーザーデータを指定されたサーバーに吸い上げを行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30146 松本 宏紀 
// 修正日    　　　　　     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30350 櫻井 亮太 
// 修正日   2017/9/12　     修正内容：11370077-00 サーバー情報を認証情報から取得に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：980035 金沢 貞義 
// 修正日   2018/10/04      修正内容：11370077-00 サーバー情報を認証情報から取得に再変更
// ---------------------------------------------------------------------//
namespace PutUserDataTool
{
    public class ToolApplication
    {
        /// <summary>サーバー通信再試行回数</summary>
        public const int SERVER_RETRY_COUNT = 3;

        private static ToolApplication _self;

        #region メンバ変数
        private string _homeDir;

        private string _logFile;

        private string _enterpriseCode;

        private string _authCode;

        private string _pmDbId;

        private string _baseUrl;
        #endregion

        /// <summary>
        /// ユーザーAPインストールディレクトリ。
        /// 例：C:\Program Files (x86)\PartsmanServer\USER_AP
        /// </summary>
        public string HomeDir
        {
            get { return this._homeDir; }
        }

        /// <summary>
        /// ログ出力ファイル
        /// </summary>
        public string LogFile
        {
            get { return this._logFile; }
            set { this._logFile = value; }
        }

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
        }

        /// <summary>
        /// 認証コード
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
        /// 接続先既定URL
        /// </summary>
        public string BaseUrl
        {
            get { return this._baseUrl; }
        }

        /// <summary>
        /// コンストラクタ。
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
                throw new Exception("PMDBID取得時にエラーが発生しました。[" + status + "]");
            }
            PmDbIdMngWork pmDbIdMngWork = pmDbIdMngWorkObj as PmDbIdMngWork;
            this._pmDbId = pmDbIdMngWork.DbIdMngGuid.ToString();


            #region 認証情報チェック
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
        /// サーバー接続確認を実施します。
        /// </summary>
        /// <returns>true:問題なし、false:問題有り</returns>
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
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("サーバーとの通信中に下記【{0}】エラーが発生しました。", errorResponse.StatusCode), false);
                                    Logger.GetInstance().Log(Environment.NewLine + "下記サーバーとの通信許可設定をされているかご確認お願いします。", false);
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("　ホスト名称：{0}", req.RequestUri.Host), false);
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("　ポート番号：{0}", req.RequestUri.Port), false);
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("　プロトコル：{0}", req.RequestUri.Scheme), false);
                                    Logger.GetInstance().Log(Environment.NewLine + string.Format("　エラー情報：{0}", ex.Message), false);
                                    break;
                                case HttpStatusCode.NotFound:
                                    return true;
                                default:
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "サーバーとの通信中に下記【{0}】エラーが発生しました。", errorResponse.StatusCode), false);
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "　ホスト名称：{0}", req.RequestUri.Host), false);
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "　ポート番号：{0}", req.RequestUri.Port), false);
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "　プロトコル：{0}", req.RequestUri.Scheme), false);
                                    Logger.GetInstance().Log(string.Format(Environment.NewLine + "　エラー情報：{0}", ex.Message), false);
                                    break;
                            }
                        }
                        else
                        {
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("サーバーとの通信中に下記【{0}】エラーが発生しました。", ex.Status), false);
                            Logger.GetInstance().Log(Environment.NewLine + "下記サーバーとの通信許可設定をされているかご確認お願いします。", false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("　ホスト名称：{0}", req.RequestUri.Host), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("　ポート番号：{0}", req.RequestUri.Port), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("　プロトコル：{0}", req.RequestUri.Scheme), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("　エラー情報：{0}", ex.Message), false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (i == SERVER_RETRY_COUNT)
                    {
                        Logger.GetInstance().Log(Environment.NewLine + string.Format("サーバーとの通信中に下記エラーが発生しました。"), false);
                        if (req != null)
                        {
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("　ホスト名称：{0}", req.RequestUri.Host), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("　ポート番号：{0}", req.RequestUri.Port), false);
                            Logger.GetInstance().Log(Environment.NewLine + string.Format("　プロトコル：{0}", req.RequestUri.Scheme), false);
                        }
                        Logger.GetInstance().Log(Environment.NewLine + string.Format(" エラー情報：{0}", ex.Message), false);
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
            Thread.Sleep(r.Next(5) * 1000);//待機時間を変更。配信とぶつかった場合の影響を最小限に抑える。
        }
    }
}

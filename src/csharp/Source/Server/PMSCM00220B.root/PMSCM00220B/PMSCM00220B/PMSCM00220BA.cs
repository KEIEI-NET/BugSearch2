//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 同期レプリカ通信アクセスクラス
// プログラム概要   : 同期レプリカ通信アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 11070136-00  作成担当 : 田建委
// 作 成 日  2014/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Broadleaf.Application.Common;
using Microsoft.Win32;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using System.IO.Compression;
using Broadleaf.Application.Remoting;

using System.Threading;

using Newtonsoft.Json;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 同期レプリカ通信アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: PMデータ同期機能において、レプリカ同期受付サーバーとの通信機能を提供します。</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class ReplicaDBAccessControl
    {
        #region Public Member
        /// <summary>正常終了</summary>
        public const int STATUS_NORMAL = 0;
        /// <summary>自動回答接続エラー</summary>
        public const int STATUS_NOT_CONNECT = 1010;
        /// <summary>データ送信中にエラー</summary>
        public const int STATUS_ERROR_SENDSTART = 1020;
        /// <summary>データ送信完了時にエラー</summary>
        public const int STATUS_ERROR_SENDEND = 1030;
        /// <summary>データ受信時にエラー</summary>
        public const int STATUS_ERROR_RECEIVE = 1040;
        /// <summary>自動回答サーバーでエラー</summary>
        public const int STATUS_ERROR_SERVER = 2000;
        #endregion

        # region ■Private Member
        private const string SYNC_PATH = "{0}/{1}/stock";
        private const string BATCH_SYNC_PATH = "{0}/{1}/batch";
        private const string TRANSLATE_PATH = "{0}/{1}/batch/convert";
        private const string FIRST_SYNC_WRITE = "{0}/{1}/batch";
        private const string FIRST_SYNC_TRANSLATE = "{0}/{1}/batch/convert";
        private const string BLCONTROL_PATH = "{0}/{1}/batch/info";
        private const string WATCH_PATH = "{0}/{1}/batch/status";

        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMSCM00220_Settings.XML";
        #region ○エラー情報
        /// <summary>0:正常終了を表します。</summary>
        private const string ERRSTA_NORMAL = "正常終了";
        /// <summary>1010:自動回答サーバーに接続できません。</summary>
        private const string ERRSTA_CONNECTERR = "自動回答サーバーに接続できません。";
        /// <summary>1020:データ送信中にエラーが発生しました。</summary>
        private const string ERRSTA_SENDINGERR = "データ送信中にエラーが発生しました。";
        /// <summary>1030:データ送信完了時にエラーが発生しました。</summary>
        private const string ERRSTA_SENDFINISHERR = "データ送信完了時にエラーが発生しました。";
        /// <summary>1040:データ受信時にエラーが発生しました。[ST=XXX]</summary>
        private const string ERRSTA_RECEIVEERR = "データ受信時にエラーが発生しました。";
        /// <summary>2000:自動回答サーバーでエラーが発生しました。</summary>
        private const string ERRSTA_AUTOANSWERERR = "自動回答サーバーでエラーが発生しました。";
        #endregion

        /// <summary>_oauthDictonaryのKEY：在庫リアル更新用</summary>
        private const string OATUH_KEY_STOCK = "stock";
        /// <summary>_oauthDictonaryのKEY：在庫リアル更新用以外</summary>
        private const string OATUH_KEY_OTHERS = "others";

        private static int blIntervalTime = 0;
        /// <summary>XMLファイルに設定された情報</summary>
        private ReplicaCommunicationData _replicaCommunicationData;
        /// <summary>作業ディレクトリ</summary>
        private string _workDir = null;
        /// <summary>ログ出力ファイル</summary>
        private string _logFileName;
        /// <summary>PMデータ同期基本認証情報</summary>
        private SyncBasicInfo _syncAuthInfo;
        /// <summary>接続URL</summary>
        private string _url;
        /// <summary>Client-Version</summary>
        private string _clientVersion;
        /// <summary>OAUTH認証情報マップ(KEY= STOCK OR OTHERS)</summary>
        private Dictionary<string, string[]> _oauthDictonary;

        /// <summary>エラーメッセージ</summary>
        private string _errorMessage;
        # endregion

        #region Property
        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMessage
        {
            get { return this._errorMessage; }
        }
        #endregion

        # region ■Constructor
        /// <summary>
        /// 同期レプリカ通信アクセスクラスコンストラクタ
        /// </summary>
        /// <param name="syncAuthInfo">同期認証情報</param>
        /// <remarks>
        /// <br>Note       : 同期レプリカ通信アクセスクラスコンストラクタです。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/11</br>
        /// </remarks>
        public ReplicaDBAccessControl(SyncBasicInfo syncAuthInfo)
        {
            try
            {
                #region ログ出力
                // テキストログ用
                RegistryKey keyForLog = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
                if (keyForLog == null) // あってはいけないケース
                {
                    _workDir = @"C:\Program Files\Partsman\USER_AP"; // レジストリに情報がないため、仮にデフォルトのフォルダを設定
                }
                else
                {
                    // ログ書き込みﾌｫﾙﾀﾞ指定
                    _workDir = keyForLog.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
                string logDir = @"" + _workDir + @"\Log\PMSCM00220B\" + syncAuthInfo.EnterpriseCode;
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                this._logFileName = Path.Combine(logDir, string.Format("PMSCM00220B_{0:yyyyMMdd}.txt", DateTime.Now));
                #endregion

                // XMLファイルに設定された情報を取得する
                _replicaCommunicationData = this.GetXmlInfo();

                if (syncAuthInfo == null)
                {
                    throw new Exception("SyncAuthenticationInfo is null.");
                }
                this._syncAuthInfo = syncAuthInfo;
                this._oauthDictonary = new Dictionary<string, string[]>(4);

                this._url = this._syncAuthInfo.PmSyncUrl;
                this._clientVersion = "1.0.0-dev";

                if (_url.IndexOf('?') != -1)
                {
                    this._url = this._url.Substring(0, _url.IndexOf('?'));
                    string[] tokens = this._syncAuthInfo.PmSyncUrl.Substring(_syncAuthInfo.PmSyncUrl.IndexOf('?') + 1).Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] vals;
                    foreach (string token in tokens)
                    {
                        vals = token.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                        if (vals.Length == 2 && !this._oauthDictonary.ContainsKey(vals[0]))
                        {
                            if (vals[0] != "ClientVersion")
                            {
                                this._oauthDictonary.Add(
                                        vals[0],
                                        new string[]{
                                        vals[1].Substring(0,vals[1].IndexOf(';')),
                                        vals[1].Substring(vals[1].IndexOf(';')+1)
                                    }
                                );
                            }
                            else
                            {
                                this._clientVersion = vals[1];
                            }
                        }
                    }
                }

                //ServicePointManager.ServerCertificateValidationCallback =
                //  new RemoteCertificateValidationCallback(
                //    OnRemoteCertificateValidationCallback);
            }
            catch (Exception ex)
            {
                this._errorMessage = ex.Message;
                ReplicaDBAccessUtils.LogOutput(this._logFileName, "Constractor", ex);
                throw;
            }
        }
        #endregion

        #region ■Public Method
        #region 通常同期要求
        /// <summary>
        /// 同期要求送信
        /// </summary>
        /// <param name="transactionId"></param>
        /// <param name="itemList"></param>
        /// <param name="isReal">true:リアル反映(在庫のみ)、false:バッチ反映</param>
        /// <returns></returns>
        public int SyncWrite(long transactionId, List<SyncReqDataWork> itemList, bool isReal)
        {
            int status = STATUS_ERROR_RECEIVE;
            if (itemList.Count == 0)
            {
                return STATUS_NORMAL;
            }

            const string PROCESS_NAME = "SyncWrite";
            const string HEADER_FMT = "{{ \"TransactionID\":{3},\"SyncTableArray\" : [";

            int retryMaxCount = _replicaCommunicationData.ShortRetryMaxCount;
            int retryCount = 0;
            StringBuilder requestBodyBuilfer = new StringBuilder(1024);
            StringBuilder sendTableList = new StringBuilder();
            #region リクエスト情報構築
            requestBodyBuilfer.AppendFormat(
                                HEADER_FMT
                                , this._syncAuthInfo.EnterpriseCode
                                , this.GetAuthenticationKey()
                                , this._syncAuthInfo.PmDbId
                                , itemList[0].TransctId);
            SyncReqDataWork beforeItem = null;
            long updateDateTime = 0;
            bool isContinue = false;
            foreach (SyncReqDataWork item in itemList)
            {
                if (beforeItem != null && beforeItem.SyncTableID != item.SyncTableID)
                {
                    requestBodyBuilfer.AppendFormat(
                                             "] }},  \"UpdateDateTime\":{0} }}, ",
                                             updateDateTime
                    );
                    updateDateTime = 0;
                    beforeItem = null;
                    isContinue = false;
                }
                if (beforeItem == null)
                {
                    //テーブルヘッダ
                    requestBodyBuilfer.AppendFormat(
                                             "{{\"TableName\":\"{0}\",\"Records\":{{",
                                              item.SyncTableID
                    );
                    //レコードヘッダ
                    requestBodyBuilfer.AppendFormat(
                                             "\"{0}\":[ ",
                                              item.SyncReqDiv
                    );
                    isContinue = false;
                    sendTableList.Append(item.SyncTableID).Append(",");
                }
                else if (beforeItem.SyncReqDiv != item.SyncReqDiv)
                {
                    //レコードヘッダ
                    requestBodyBuilfer.AppendFormat(
                                             " ], \"{0}\":[ ",
                                              item.SyncReqDiv
                    );
                    isContinue = false;
                }
                if (isContinue)
                {
                    requestBodyBuilfer.Append(",");
                }
                requestBodyBuilfer.Append(this.GenerateSyncBatchRecord(item, true));
                isContinue = true;
                if (updateDateTime < item.UpdateDateTime.Ticks)
                {
                    updateDateTime = item.UpdateDateTime.Ticks;
                }
                beforeItem = item;
            }
            requestBodyBuilfer.AppendFormat("] }},  \"UpdateDateTime\":{0} }} ", updateDateTime);
            requestBodyBuilfer.Append("] }");
            #endregion

            ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME + ":処理開始...[" + sendTableList.ToString() + "]");

            HttpWebRequest req = null;
            StreamWriter streamWriter = null;
            bool isRetry = false;
            string url = "";
            while (retryCount < retryMaxCount)
            {
                #region 接続
                try
                {
                    if (isReal)
                    {
                        url = string.Format(SYNC_PATH, this._syncAuthInfo.EnterpriseCode, this._syncAuthInfo.PmDbId);
                        req = this.CreateRequest(url, null, "PUT");
                    }
                    else
                    {
                        url = string.Format(BATCH_SYNC_PATH, this._syncAuthInfo.EnterpriseCode, this._syncAuthInfo.PmDbId);
                        req = this.CreateRequest(url, null, "POST");
                    }
                }
                catch (Exception ex)
                {
                    this._errorMessage = ex.Message;
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                    this.WaitShortRetrimWaitTime();
                    retryCount++;
                    continue;
                }
                #endregion
                #region 送信
                try
                {
                    streamWriter = new StreamWriter(this.GetRequestStream(req));
                    this.SendHttpBody(streamWriter, requestBodyBuilfer.ToString());
                }
                catch (Exception ex)
                {
                    this._errorMessage = ex.Message;
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                    this.WaitShortRetrimWaitTime();
                    retryCount++;
                    continue;
                }
                finally
                {
                    ReplicaDBAccessUtils.CloseQuietly(streamWriter);
                }
                #endregion
                #region 受信
                try
                {
                    JsonSerializer serializer = this.GetJsonSerializer();
                    SyncResponse syncRes = this.ReadSyncResponse(req, serializer);
                    if (syncRes != null)
                    {
                        status = ToSyncStatus(syncRes.Status, ref isRetry);
                        ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME + ":受信結果[" + syncRes.Status + ":" + isRetry + "]");
                        if (!isRetry)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception("response is null.");
                    }
                }
                catch (Exception ex)
                {
                    this._errorMessage = ex.Message;
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                }
                #endregion
                this.WaitShortRetrimWaitTime();
                retryCount++;
            }
            if (status == 202)
            {
                //変換処理中であった場合は、監視処理を行った後に再試行。
                status = this.WatchSyncStatus(0);
                if (status == STATUS_NORMAL)
                {
                    status = this.SyncWrite(transactionId, itemList, isReal);
                }
            }
            return status;
        }
        #endregion

        #region 変換要求API
        /// <summary>
        /// 変換要求API
        /// </summary>
        /// <returns></returns>
        public int TranslateStart()
        {
            int status = STATUS_ERROR_RECEIVE;
            const string PROCESS_NAME = "TranslateStart";

            int retryMaxCount = _replicaCommunicationData.ShortRetryMaxCount;
            int retryCount = 0;
            HttpWebRequest req = null;

            ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME + ":処理開始...");

            bool isRetry = false;
            while (retryCount < retryMaxCount)
            {
                #region 接続
                try
                {
                    string url = string.Format(TRANSLATE_PATH, this._syncAuthInfo.EnterpriseCode, this._syncAuthInfo.PmDbId);
                    req = this.CreateRequest(url, null, "POST");
                }
                catch (Exception ex)
                {
                    this._errorMessage = ex.Message;
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                    this.WaitShortRetrimWaitTime();
                    retryCount++;
                    continue;
                }
                #endregion

                #region 送信
                //try
                //{
                //    streamWriter = new StreamWriter(this.GetRequestStream(req));
                //    this.SendHttpBody(streamWriter, requestBodyBuilfer.ToString());
                //}
                //catch (Exception ex)
                //{
                //    this._errorMessage = ex.Message;
                //    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                //    this.WaitShortRetrimWaitTime();
                //    retryCount++;
                //    continue;
                //}
                //finally
                //{
                //    ReplicaDBAccessUtils.CloseQuietly(streamWriter);
                //}
                #endregion

                #region 受信
                try
                {
                    JsonSerializer serializer = this.GetJsonSerializer();
                    SyncResponse syncRes = this.ReadSyncResponse(req, serializer);
                    if (syncRes != null)
                    {
                        ReplicaDBAccessUtils.LogOutput(this._logFileName, "TranslateStart:" + syncRes.Status);
                        status = ToSyncStatus(syncRes.Status, ref isRetry);
                        if (!isRetry)
                        {
                            break;
                        }
                    }
                    else
                    {
                        throw new Exception("response is null.");
                    }
                }
                catch (Exception ex)
                {
                    this._errorMessage = ex.Message;
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                }
                #endregion
                this.WaitShortRetrimWaitTime();
                retryCount++;
            }
            if (status == 202)
            {
                status = this.WatchSyncStatus(0);
            }
            return status;
        }
        #endregion

        #region BL制御情報取得API
        /// <summary>
        /// BL制御情報の取得
        /// </summary>
        /// <param name="blSyncRequest"></param>
        /// <param name="syncInfo"></param>
        /// <returns></returns>
        public BlSyncControlResponse GetSyncControlInfo(BlSyncControlRequest blSyncRequest)
        {
            int retryMaxCount = _replicaCommunicationData.ShortRetryMaxCount;
            const string PROCESS_NAME = "GetSyncControlInfo";

            int retryCount = 0;
            StringBuilder requestBodyBuilfer = new StringBuilder(1024);
            JsonSerializer serializer = this.GetJsonSerializer();

            HttpWebRequest req = null;
            while (retryCount < retryMaxCount)
            {
                #region 接続
                try
                {
                    string url = string.Format(BLCONTROL_PATH, this._syncAuthInfo.EnterpriseCode, this._syncAuthInfo.PmDbId);
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, "GetSyncControlInfo:" + this._url + url);
                    req = this.CreateRequest(url, null, "GET");
                }
                catch (Exception ex)
                {
                    this._errorMessage = ex.Message;
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                    this.WaitShortRetrimWaitTime();
                    retryCount++;
                    continue;
                }
                #endregion

                #region 受信
                JsonTextReader reader = null;
                StreamReader streamReader = null;
                Stream outStream = null;
                try
                {
                    HttpWebResponse response = req.GetResponse() as HttpWebResponse;
                    if (response == null)
                    {
                        throw new Exception("response is null.");
                    }
                    outStream = response.GetResponseStream();
                    streamReader = new StreamReader(outStream);
                    reader = new JsonTextReader(streamReader);

                    BlSyncControlResponse syncRes = serializer.Deserialize(reader, typeof(BlSyncControlResponse)) as BlSyncControlResponse;
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, "GetSyncControlInfo:STATUS=" + syncRes.Status + ",  Date=" + syncRes.FirstSyncDuration.Date + ",  StartTime=" + syncRes.FirstSyncDuration.StartTime + ",  EndTime=" + syncRes.FirstSyncDuration.EndTime);
                    return syncRes;
                }
                catch (WebException ex)
                {
                    this._errorMessage = ex.Message;
                    HttpWebResponse response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        ReplicaDBAccessUtils.LogOutput(this._logFileName, "GetSyncControlInfo:STATUS=" + response.StatusCode);
                        if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                        {
                            ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                            BlSyncControlResponse res = new BlSyncControlResponse();
                            res.Status = 401;
                            return res;
                        }
                        else if (response.StatusCode == HttpStatusCode.BadRequest)
                        {
                            ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                            BlSyncControlResponse res = new BlSyncControlResponse();
                            res.Status = 400;
                            return res;
                        }
                        else if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            BlSyncControlResponse res = new BlSyncControlResponse();
                            res.Status = 404;
                            return res;
                        }
                    }
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                }
                catch (Exception ex)
                {
                    this._errorMessage = ex.Message;
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                }
                #endregion
                this.WaitShortRetrimWaitTime();
                retryCount++;
            }
            return null;
        }
        #endregion

        #region 700.同期状態監視API
        /// <summary>
        /// 同期状態監視を行います。
        /// </summary>
        /// <returns></returns>
        private int WatchSyncStatus(int watchRetryCount)
        {
            int status = STATUS_ERROR_RECEIVE;
            int watchRetryCountCheck = watchRetryCount;
            do
            {
                if (this._replicaCommunicationData.FirstSyncWatchCount > 0 && this._replicaCommunicationData.FirstSyncWatchCount < watchRetryCountCheck)
                {
                    ReplicaDBAccessUtils.LogOutput(this._logFileName, "同期状態監視API：監視回数オーバー=" + this._replicaCommunicationData.FirstSyncWatchCount);
                    this._errorMessage = "監視回数オーバー:" + this._replicaCommunicationData.FirstSyncWatchCount;
                    return status;
                }
                const string PROCESS_NAME = "WatchSyncStatus";

                int retryMaxCount = this._replicaCommunicationData.FirstSyncWatchCount;
                int retryCount = 0;
                HttpWebRequest req = null;
                bool isRetry = false;
                while (retryCount < retryMaxCount || retryMaxCount < 0)
                {
                    isRetry = false;
                    #region 接続
                    try
                    {
                        string url = string.Format(WATCH_PATH, this._syncAuthInfo.EnterpriseCode, this._syncAuthInfo.PmDbId);
                        req = this.CreateRequest(url, "", "GET");
                    }
                    catch (Exception ex)
                    {
                        this._errorMessage = ex.Message;
                        ReplicaDBAccessUtils.LogOutput(this._logFileName, WATCH_PATH, ex);
                        this.WaitShortRetrimWaitTime();
                        retryCount++;
                        continue;
                    }
                    #endregion

                    #region 送信
                    //try
                    //{
                    //    streamWriter = new StreamWriter(this.GetRequestStream(req));
                    //    this.SendHttpBody(streamWriter, requestBodyBuilfer.ToString());
                    //}
                    //catch (Exception ex)
                    //{
                    //    this._errorMessage = ex.Message;
                    //    ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                    //    this.WaitShortRetrimWaitTime();
                    //    retryCount++;
                    //    continue;
                    //}
                    //finally
                    //{
                    //    ReplicaDBAccessUtils.CloseQuietly(streamWriter);
                    //}
                    #endregion

                    #region 受信
                    try
                    {
                        SyncResponse syncRes = this.ReadSyncResponse(req, GetJsonSerializer());
                        if (syncRes != null)
                        {
                            ReplicaDBAccessUtils.LogOutput(this._logFileName, "WatchSyncStatus:" + syncRes.Status);
                            status = ToSyncStatus(syncRes.Status, ref isRetry);
                            if (!isRetry)
                            {
                                break;
                            }
                        }
                        else
                        {
                            throw new Exception("response is null.");
                        }
                    }
                    catch (Exception ex)
                    {
                        this._errorMessage = ex.Message;
                        ReplicaDBAccessUtils.LogOutput(this._logFileName, PROCESS_NAME, ex);
                        this.WaitShortRetrimWaitTime();
                        retryCount++;
                        continue;
                    }
                    #endregion
                    this.WaitShortRetrimWaitTime();
                    retryCount++;
                }
                if (status == 202)
                {
                    Thread.Sleep(this._replicaCommunicationData.FirstSyncWatchInterval * 1000);
                    watchRetryCountCheck++;
                }
            } while (status == 202);
            return status;
        }
        #endregion

        #region ■private メソッド

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        private void SortWritableList(List<SyncReqDataWork> list)
        {
            list.Sort(new SyncReqDataWorkComparator());
        }

        class SyncReqDataWorkComparator : IComparer<SyncReqDataWork>
        {
            public int Compare(SyncReqDataWork o1, SyncReqDataWork o2)
            {
                if (o1.SyncTableID == o2.SyncTableID)
                {
                    return o1.SyncProcDiv.CompareTo(o2.SyncProcDiv);
                }
                else
                {
                    return o1.SyncTableID.CompareTo(o2.SyncTableID);
                }
            }
        }
        /// <summary>
        /// 文字列をJSON形式に変換。
        /// \等のエスケープ処理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string ToJson(string data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serializer"></param>
        /// <returns></returns>
        private SyncResponse ReadSyncResponse(HttpWebRequest req, JsonSerializer serializer)
        {
            JsonTextReader reader = null;
            StreamReader streamReader = null;
            Stream outStream = null;
            HttpWebResponse response = null;
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

                SyncResponse syncRes = serializer.Deserialize(reader, typeof(SyncResponse)) as SyncResponse;
                blIntervalTime = syncRes.RequestDelayTime;
                return syncRes;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                if (response != null)
                {
                    if (response.StatusCode == HttpStatusCode.InternalServerError || response.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        SyncResponse res = new SyncResponse();
                        res.RequestDelayTime = blIntervalTime;
                        res.Status = 500;
                        return res;
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                    {
                        SyncResponse res = new SyncResponse();
                        res.RequestDelayTime = blIntervalTime;
                        res.Status = 401;
                        return res;
                    }
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        SyncResponse res = new SyncResponse();
                        res.RequestDelayTime = blIntervalTime;
                        res.Status = 400;
                        return res;
                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        SyncResponse res = new SyncResponse();
                        res.RequestDelayTime = blIntervalTime;
                        res.Status = 404;
                        return res;
                    }
                    throw new Exception("response code is invalid: " + response.StatusCode);
                }
                else
                {
                    throw new Exception("response code is invalid: null");

                }
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

        /// <summary>
        /// APIステータスを同期ステータスに変換します。
        /// </summary>
        /// <param name="status"></param>
        /// <param name="isRetry"></param>
        /// <returns></returns>
        private int ToSyncStatus(int apiStatus, ref bool isRetry)
        {
            int status = STATUS_ERROR_SERVER;
            isRetry = false;

            switch (apiStatus)
            {
                case 0:
                case 200:
                    status = STATUS_NORMAL;
                    break;
                case 102:
                case 202:
                    status = apiStatus;
                    break;
                case 400:
                case 401:
                case 403:
                case 404:
                    status = STATUS_ERROR_SERVER;
                    this._errorMessage = "サーバーステータス[" + apiStatus + "]のエラーが発生しています。";
                    break;
                case 500:
                case 503:
                    isRetry = true;
                    this._errorMessage = this._errorMessage = "サーバーステータス[" + apiStatus + "]のエラーが発生しています。";
                    break;
                case 590:
                    status = STATUS_ERROR_SERVER;
                    this._errorMessage = "サーバーステータス[590]";
                    break;
                default:
                    throw new Exception("illegail status.");
            }
            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private String GenerateSyncBatchRecord(SyncReqDataWork item, bool addGenericColumn)
        {
            if (item.SyncReqDiv == 0 || item.SyncReqDiv == 1)
            {
                if (addGenericColumn)
                {

                    int position = 0;
                    int offset = -1;
                    const char tabChar = '\t';
                    do
                    {
                        offset = item.SyncObjRecUpdVal.IndexOf(tabChar, offset + 1);
                        position++;
                    } while (offset != -1 && position < 3);
                    if (position == 3)
                    {
                        return ToJson(item.SyncObjRecUpdVal.Substring(0, offset) + "\t\"\"\t\"\"\t\"\"\t\"\"\t" + item.SyncObjRecUpdVal.Substring(offset + 1));
                    }
                    else
                    {
                        return ToJson(item.SyncObjRecUpdVal);
                    }
                }
                else
                {
                    return ToJson(item.SyncObjRecUpdVal);
                }
            }
            else
            {
                return ToJson(item.SyncObjRecKeyVal);
            }
        }

        /// <summary>
        /// 出力ストリームの取得
        /// </summary>
        /// <returns></returns>
        private Stream GetRequestStream(HttpWebRequest req)
        {
            //デバッグ用
            return req.GetRequestStream();

            //Stream stream = _request.GetRequestStream();
            //stream = new GZipStream(stream, CompressionMode.Compress);
            //return _stream;
        }

        /// <summary>
        /// レプリカ同期受付サーバーに対してHTTP(S)のコネクションを接続します。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="query"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		: レプリカ同期受付サーバーに対してHTTP(S)のコネクションを接続します。。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/11</br>					
        /// </remarks>
        private HttpWebRequest CreateRequest(string path, string query, string method)
        {
            try
            {
                #region Delay
                try
                {
                    Thread.Sleep(blIntervalTime * 1000);
                }
                catch
                {
                }
                #endregion

                HttpWebRequest req = null;
                if (string.IsNullOrEmpty(query))
                {
                    req = HttpWebRequest.Create(this._url + path) as HttpWebRequest;
                }
                else
                {
                    req = HttpWebRequest.Create(this._url + path + "?" + query) as HttpWebRequest;
                }
                if (req == null)
                {
                    throw new Exception("_request is null[" + (this._url + path) + "]");
                }
                //this._request.Headers.Add("Content-Encoding", "gzip");
                req.Method = method;
                req.ReadWriteTimeout = 60000;
                req.Timeout = 60000;
                if (!"GET".Equals(method))
                {
                    req.ContentType = "application/json";
                }
                req.Headers.Add("X-BL-PM-AUTHKEY", this.GetAuthenticationKey());

                req.SendChunked = false;
                req.AllowWriteStreamBuffering = true;

                string oauthKey = (path.EndsWith("/stock")) ? OATUH_KEY_STOCK : OATUH_KEY_OTHERS;
                if (this._oauthDictonary.ContainsKey(oauthKey))
                {
                    string[] tokens = this._oauthDictonary[oauthKey];
                    if (tokens != null && tokens.Length == 2)
                    {
                        MagellanAuthUtils.AddOAuthInfo(req, tokens[0], tokens[1], this._clientVersion);
                    }
                }
                return req;
            }
            catch
            {
                ReplicaDBAccessUtils.LogOutput(this._logFileName, "URL:" + this._syncAuthInfo.PmSyncUrl + path);
                throw;
            }
        }

        /// <summary>
        /// 設定値ShortRetryWaitTime分だけsleepします。
        /// </summary>
        /// <returns></returns>
        private void WaitShortRetrimWaitTime()
        {
            try
            {
                int time = this._replicaCommunicationData.ShortRetryWaitTime;
                if (time > 0)
                {
                    Thread.Sleep(this._replicaCommunicationData.ShortRetryWaitTime);
                }
            }
            catch
            {
            }
        }

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
            return serializer;
        }

        #region ○共通処理部品
        /// <summary>
        /// レプリカ通信設定ファイル読込処理
        /// </summary>
        /// <returns>ReplicaCommunicationData</returns>
        /// <remarks>
        /// <br>Note       : レプリカ通信設定ファイル読込処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/11</br>
        /// </remarks>
        private ReplicaCommunicationData GetXmlInfo()
        {
            string xmlFileName = Path.Combine(_workDir, XML_FILE_NAME);
            ReplicaCommunicationData replicaCommunicationData = new ReplicaCommunicationData();

            try
            {
                replicaCommunicationData = UserSettingController.DeserializeUserSetting<ReplicaCommunicationData>(xmlFileName);
            }
            catch
            {
                //再試行回数
                replicaCommunicationData.ShortRetryMaxCount = 3;
                //再試行間隔(ミリ秒)
                replicaCommunicationData.ShortRetryWaitTime = 500;
                //初回同期監視間隔(秒)
                replicaCommunicationData.FirstSyncWatchInterval = 10;
                //初回同期監視回数(0以下：無制限)
                replicaCommunicationData.FirstSyncWatchCount = 2;
            }
            return replicaCommunicationData;
        }

        /// <summary>
        /// BODY情報の送信。
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        private void SendHttpBody(StreamWriter writer, string value)
        {
            writer.Write(value);
            writer.Flush();
        }
        #endregion

        /// <summary>
        /// 認証kEYの取得。
        /// </summary>
        /// <returns></returns>
        private string GetAuthenticationKey()
        {
            return PmSyncAuthenticator.GetAuthenticationKey(this._syncAuthInfo.EnterpriseCode);
        }
        #endregion
        #endregion

        //#region デバッグ用
        //private bool OnRemoteCertificateValidationCallback(
        //      Object sender,
        //      X509Certificate certificate,
        //      X509Chain chain,
        //      SslPolicyErrors sslPolicyErrors)
        //{
        //    return true;  // 「SSL証明書の使用は問題なし」と示す
        //}
        //#endregion
    }
}

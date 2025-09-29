using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    #region ■レプリカ通信設定ファイル構成
    /// <summary>
    /// レプリカ通信設定ファイル構成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: レプリカ通信設定ファイル構成クラス</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class ReplicaCommunicationData
    {
        /// <summary>再試行回数</summary>
        private int _shortRetryMaxCount;
        /// <summary>再試行間隔</summary>
        private int _shortRetryWaitTime;
        /// <summary>初回同期監視間隔</summary>
        private int _firstSyncWatchInterval;
        /// <summary>初回同期監視回数</summary>
        private int _firstSyncWatchCount;

        /// <summary>
        /// 再試行回数
        /// </summary>
        public int ShortRetryMaxCount
        {
            get
            {
                return _shortRetryMaxCount;
            }
            set
            {
                _shortRetryMaxCount = value;
            }
        }

        /// <summary>
        /// 再試行間隔
        /// </summary>
        public int ShortRetryWaitTime
        {
            get
            {
                return _shortRetryWaitTime;
            }
            set
            {
                _shortRetryWaitTime = value;
            }
        }

        /// <summary>
        /// 初回同期監視間隔
        /// </summary>
        public int FirstSyncWatchInterval
        {
            get
            {
                return _firstSyncWatchInterval;
            }
            set
            {
                _firstSyncWatchInterval = value;
            }
        }

        /// <summary>
        /// 初回同期監視回数
        /// </summary>
        public int FirstSyncWatchCount
        {
            get
            {
                return _firstSyncWatchCount;
            }
            set
            {
                _firstSyncWatchCount = value;
            }
        }
    }
    #endregion

    #region ■PMデータ同期基本認証情報
    /// <summary>
    /// PMデータ同期基本認証情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: PMデータ同期基本認証情報クラス</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class SyncBasicInfo
    {
        //企業コード
        private string _enterpriseCode;

        //レプリカ接続サーバー
        private string _pmSyncUrl;

        //PMDB ID
        private string _pmDbId;

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            set { this._enterpriseCode = value; }
            get { return this._enterpriseCode; }
        }

        /// <summary>
        /// レプリカ接続サーバー
        /// </summary>
        public string PmSyncUrl
        {
            set { this._pmSyncUrl = value; }
            get { return this._pmSyncUrl; }
        }

        /// <summary>
        /// PMDBID
        /// </summary>
        public string PmDbId
        {
            set { this._pmDbId = value; }
            get { return this._pmDbId; }
        }
    }
    #endregion

    #region 000.API共通
    public class SyncResponse
    {
        /// <summary>ステータス</summary>
        private int _status;

        /// <summary>容器送信遅延秒数</summary>
        private int _requestDelayTime;

        /// <summary>
        /// ステータス
        /// </summary>
        public int Status
        {
            set { this._status = value; }
            get { return this._status; }
        }

        /// <summary>
        /// 要求送信遅延秒数
        /// </summary>
        public int RequestDelayTime
        {
            set { this._requestDelayTime = value; }
            get { return this._requestDelayTime; }
        }
    }
    #endregion

    #region 001.通常同期要求API

    #endregion

    #region 100.BL制御情報取得API
    /// <summary>
    /// 100.BL制御情報取得API-リクエストクラス。
    /// </summary>
    /// <remarks>
    /// <br>Note		: 100.BL制御情報取得API-リクエストクラス</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class BlSyncControlRequest
    {
        //企業コード
        private string _enterpriseCode;

        //PMDB ID
        private string _pmDbID;

        //TransactionId
        private long _transactionID;

        //認証KEY
        private string _authenticationKey;

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            set { this._enterpriseCode = value; }
            get { return this._enterpriseCode; }
        }

        /// <summary>
        /// PMDBID
        /// </summary>
        public string PmDbID
        {
            set { this._pmDbID = value; }
            get { return this._pmDbID; }
        }

        /// <summary>
        /// トランザクションID
        /// </summary>
        public long TransactionID
        {
            set { this._transactionID = value; }
            get { return this._transactionID; }
        }

        /// <summary>
        /// 認証KEY
        /// </summary>
        public string AuthenticationKey
        {
            set { this._authenticationKey = value; }
            get { return this._authenticationKey; }
        }
    }

    /// <summary>
    /// 100.BL制御情報取得APIレスポンスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 100.BL制御情報取得APIレスポンスクラス</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class BlSyncControlResponse
    {
        //戻るステータス
        private int _status;

        //初回同期期間情報
        private FirsySyncInfo _firstSyncDuration;

        //同期チェック実施間隔(分)
        private int dataCheckInterval;

        //データアップロード要求情報
        private string _dataUploadRequest;

        /// <summary>
        /// 戻るステータス
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// 初回同期期間情報
        /// </summary>
        public FirsySyncInfo FirstSyncDuration
        {
            get { return _firstSyncDuration; }
            set { _firstSyncDuration = value; }
        }

        /// <summary>
        /// 同期チェック実施間隔(分)
        /// </summary>
        public int DataCheckInterval
        {
            set { this.dataCheckInterval = value; }
            get { return this.dataCheckInterval; }
        }

        /// <summary>
        /// データアップロード要求情報
        /// </summary>
        public string DataUploadRequest
        {
            get { return _dataUploadRequest; }
            set { _dataUploadRequest = value; }
        }
    }
    #endregion

    /// <summary>
    /// 初回同期期間情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 初回同期期間情報クラス</br>
    /// <br>Programmer	: 田建委</br>
    /// <br>Date		: 2014/08/11</br>
    /// </remarks>
    public class FirsySyncInfo
    {
        //初回同期実施日付
        private int _date;
        //初回同期実施開始時間
        private int _startTime;
        //初回同期実施終了時間
        private int _endTime;

        /// <summary>
        /// 初回同期実施日付
        /// </summary>
        public int Date
        {
            get { return _date; }
            set { _date = value; }
        }

        /// <summary>
        /// 初回同期実施開始時間
        /// </summary>
        public int StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        /// <summary>
        /// 初回同期実施終了時間
        /// </summary>
        public int EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
    }


    #region ■エラー情報
    /// <summary>
    /// エラー情報クラス
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>エラーコード</summary>
        private int _errorStatus;
        /// <summary>エラーメッセージ</summary>
        private string _errorContents;

        /// <summary>
        /// エラーコード
        /// </summary>
        public int ErrorStatus
        {
            get { return _errorStatus; }
            set { _errorStatus = value; }
        }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorContents
        {
            get { return _errorContents; }
            set { _errorContents = value; }
        }
    }
    #endregion
}

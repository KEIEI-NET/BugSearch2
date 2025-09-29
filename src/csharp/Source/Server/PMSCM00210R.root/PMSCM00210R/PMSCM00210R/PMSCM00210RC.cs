//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期実行管理 リモートオブジェクト
//                  :   PMSCM00210R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   田建委
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      : 
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMデータ同期基本認証情報
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期実行スレッド(即時)のオブジェクト</br>
    /// <br>Programmer : 松本 宏紀</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    public class SyncAuthenticationInfo
    {
        //企業コード
        private string _enterpriseCode;

        //ユーザーDB接続文字列
        private string _userDbConnectionText;

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
        /// ユーザーDB接続文字列
        /// </summary>
        public string UserDbConnectionText
        {
            set { this._userDbConnectionText = value; }
            get { return this._userDbConnectionText; }
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

        /// <summary>
        /// SyncBasicInfoクラス形式に変換します。
        /// </summary>
        /// <returns></returns>
        public SyncBasicInfo ToSyncBasicInfo()
        {
            SyncBasicInfo answer = new SyncBasicInfo();
            answer.EnterpriseCode = this.EnterpriseCode;
            answer.PmDbId = this.PmDbId;
            answer.PmSyncUrl = this.PmSyncUrl;
            return answer;
        }
    }

    /// <summary>
    /// 同期実行基本情報(BL制御情報)
    /// </summary>
    public class SyncBasicWorkInfo
    {
        //同期チェック実施間隔(分)
        private int dataCheckInterval;

        //初回同期実施日付(0:開始可能日時無し,999999:いつでも実施可能、それ以外:指定日付)
        private int firstSyncDate;

        //初回同期実施開始時間
        private int firstSyncStartTime;

        //初回同期実施終了時間
        private int firstSyncEndTime;

        /// <summary>
        /// 同期チェック実施間隔(分)
        /// </summary>
        public int DataCheckInterval
        {
            set { this.dataCheckInterval = value; }
            get { return this.dataCheckInterval; }
        }

        /// <summary>
        /// 初回同期実施日付(0:開始可能日時無し,999999:いつでも実施可能、それ以外:指定日付)
        /// </summary>
        public int FirstSyncDate
        {
            set { this.firstSyncDate = value; }
            get { return this.firstSyncDate; }
        }

        /// <summary>
        /// 初回同期実施開始時間
        /// </summary>
        public int FirstSyncStartTime
        {
            set { this.firstSyncStartTime = value; }
            get { return this.firstSyncStartTime; }
        }

        /// <summary>
        /// 初回同期実施終了時間
        /// </summary>
        public int FirsySyncEndTime
        {
            set { this.firstSyncEndTime = value; }
            get { return this.firstSyncEndTime; }
        }

        /// <summary>
        /// 初回同期実施期間のチェック
        /// </summary>
        /// <returns></returns>
        public bool CheckFirstSyncExecTime()
        {
            DateTime now = DateTime.Now;
            #region 日付チェック
            if (this.FirstSyncDate == 0)
            {
                return false;
            }
            else if (this.FirstSyncDate != 99999999 && this.FirstSyncDate != 999999)
            {
                int yyyyMMdd = now.Year * 10000 + now.Month * 100 + now.Day;
                if (this.FirstSyncDate != yyyyMMdd)
                {
                    return false;
                }
            }
            #endregion
            #region 時間チェック
            int HHmmss = now.Hour * 10000 + now.Minute * 100 + now.Second;
            if (this.FirstSyncStartTime <= HHmmss && HHmmss <= this.FirsySyncEndTime)
            {
                return true;
            }
            #endregion
            return false;
        }
    }

    /// <summary>
    /// 設定XMLデータオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 設定XMLデータオブジェクト</br>
    /// <br>Programmer : zhubj</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    public class PMSCM00210R_Setting
    {
        /// <summary>
        /// 設定XMLデータワークコンストラクタ
        /// </summary>
        public PMSCM00210R_Setting()
        {
            _maxRetryCount = 0;
            _retryIntervalTime = 0;
            _watchOnReplicaDBIntervalTime = 0;
            _tablesInfoList = new List<SyncTableInfo>();
            _watchOnHesitateTime = 0;
            _batchInterval = 300;
            _dataSendLimitSize = 1000;
            _translateTime = "010000";
        }

        #region Privateメンバ変数
        /// <summary>リトライ回数の最大値 (0以下の場合は無制限)</summary>
        private int _maxRetryCount = 0;
        /// <summary>リトライ間隔（秒）</summary>
        private int _retryIntervalTime = 0;
        /// <summary>レプリカDB定期監視間隔（秒）</summary>
        private int _watchOnReplicaDBIntervalTime = 0;
        /// <summary> 監視猶予時間（秒）</summary>
        private int _watchOnHesitateTime = 0;
        /// <summary> バッチ要求処理間隔 (秒) </summary>
        private int _batchInterval = 0;
        /// <summary>同期対象テーブル名称</summary>
        private List<SyncTableInfo> _tablesInfoList = null;
        /// <summary>データ一括送信件数</summary>
        private int _dataSendLimitSize = 0;
        /// <summary>変換開始要求実施時間</summary>
        private string _translateTime = null;

        #endregion
        /// <summary> 監視猶予時間（秒）</summary>
        public int WatchOnHesitateTime
        {
            get { return _watchOnHesitateTime; }
            set { _watchOnHesitateTime = value; }
        }

        /// <summary>同期対象テーブル名称</summary>
        public List<SyncTableInfo> TablesInfoList
        {
            get { return _tablesInfoList; }
            set { _tablesInfoList = value; }
        }

        /// <summary>リトライ回数の最大値 (0以下の場合は無制限)</summary>
        public int MaxRetryCount
        {
            get { return _maxRetryCount; }
            set { _maxRetryCount = value; }
        }

        /// <summary>リトライ間隔（秒）</summary>
        public int RetryIntervalTime
        {
            get { return _retryIntervalTime; }
            set { _retryIntervalTime = value; }
        }

        /// <summary>レプリカDB定期監視間隔（秒）</summary>
        public int WatchOnReplicaDBIntervalTime
        {
            get { return _watchOnReplicaDBIntervalTime; }
            set { _watchOnReplicaDBIntervalTime = value; }
        }

        /// <summary>
        /// バッチ実行間隔(秒)
        /// </summary>
        public int BatchInterval
        {
            get { return this._batchInterval; }
            set { this._batchInterval = value; }
        }

        /// <summary>データ一括送信件数</summary>
        public int DataSendLimitSize
        {
            get { return this._dataSendLimitSize; }
            set { this._dataSendLimitSize = value; }
        }

        /// <summary>変換開始要求実施時間</summary>
        public string TranslateTime
        {
            get { return this._translateTime; }
            set { this._translateTime = value; }
        }

        /// <summary>
        /// 渡されたtableidに対応する名称の取得
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns></returns>
        public string GetSyncTableNm(string tableId)
        {
            foreach (SyncTableInfo info in this.TablesInfoList)
            {
                if (info.SyncTableId == tableId)
                {
                    return info.SyncTableNm;
                }
            }
            return null;
        }


        /// <summary>
        /// 渡されたtableidに対応する名称の取得
        /// </summary>
        /// <param name="tableId"></param>
        /// <returns></returns>
        public string GetSyncTableJsonId(string tableId)
        {
            foreach (SyncTableInfo info in this.TablesInfoList)
            {
                if (info.SyncTableId == tableId)
                {
                    return info.SyncTableJsonId;
                }
            }
            return null;
        }

        /// <summary>
        /// 渡されたtableidに対応する名称の取得
        /// </summary>
        /// <param name="jsonId"></param>
        /// <returns></returns>
        public string GetSyncTableIdFromJsonId(string jsonId)
        {
            foreach (SyncTableInfo info in this.TablesInfoList)
            {
                if (info.SyncTableJsonId == jsonId)
                {
                    return info.SyncTableId;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// 同期対象テーブルオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期対象テーブルオブジェクト</br>
    /// <br>Programmer : zhubj</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    public class SyncTableInfo
    {
        /// <summary>
        /// 同期対象テーブルデータワークコンストラクタ
        /// </summary>
        public SyncTableInfo()
        {
            _syncTableId = "";
            _syncTableNm = "";
            _syncTableJsonId = "";
        }

        /// <summary>テーブルID</summary>
        private string _syncTableId = "";

        /// <summary>テーブル名称</summary>
        private string _syncTableNm = "";

        /// <summary>テーブルID(JSON送信形式)</summary>
        private string _syncTableJsonId = "";

        /// <summary>テーブル名称</summary>
        public string SyncTableNm
        {
            get { return _syncTableNm; }
            set { _syncTableNm = value; }
        }

        /// <summary>テーブルID</summary>
        public string SyncTableId
        {
            get { return _syncTableId; }
            set { _syncTableId = value; }
        }


        /// <summary>テーブルID</summary>
        public string SyncTableJsonId
        {
            get { return _syncTableJsonId; }
            set { _syncTableJsonId = value; }
        }
    }


}

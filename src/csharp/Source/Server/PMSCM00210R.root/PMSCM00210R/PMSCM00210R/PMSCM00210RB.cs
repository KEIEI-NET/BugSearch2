//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期実行管理 リモートオブジェクト
//                  :   PMSCM00210R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   田建委
// Date             :   2014/08/01
//----------------------------------------------------------------------
// 管理番号              作成担当 : 松本 宏紀
// 修 正 日  2015/02/12  修正内容 : 初回同期以外は変換開始要求を送信しないように修正(#46)
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Remoting.Lifetime;

using Microsoft.SqlServer.Server;
using Microsoft.Win32;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 同期実行クラス リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期実行クラス操作を行うクラスです。</br>
    /// <br>Programmer : zhubj</br>
    /// <br>Date       : 2014/08/07</br>
    /// </remarks>
    [Serializable]
    public partial class SyncExecWorkDB : RemoteWithAppLockDB
    {
        /// <summary>
        /// Singleton Objects 
        /// </summary>
        private static Dictionary<string, SyncExecWorkDB> _dictSelf;

        #region Private Member
        #region　ロックオブジェクト
        // 初回同期スレッド用
        private object _firstSyncObj = new object();
        /// <summary>リアル同期ロックオブジェクト</summary>
        private object _syncReadLockObj = new object();
        /// <summary>バッチ同期ロックオブジェクト</summary>
        private object _syncBatchLockObj = new object();
        /// <summary>変換ロックオブジェクト</summary>
        private object _syncTransLockObj = new object();

        private object _syncExecLock = new object();

        /// <summary>
        /// スレッド間排他制御オブジェクト
        /// </summary>
        public object SyncExecLock
        {
            get { return this._syncExecLock; }
        }
        #endregion

        #region スレッド情報
        // 初回同期スレッド
        private Thread _firstSyncWorker;
        // バッチ同期実行スレッド用
        private Thread _syncExecforRealWorker;
        // バッチ同期実行スレッド用
        private Thread _syncExecforBatchWorker;
        //定期監視スレッド
        private Thread _regularWatchOnWorker;
        //変換開始スレッド
        private Thread _translateWorker;
        #endregion
        #endregion

        #region Property
        // 同期実行時認証情報
        private SyncAuthenticationInfo _syncAuthInfo;
        /// <summary>
        /// 同期実行時認証情報
        /// </summary>
        public SyncAuthenticationInfo SyncAuthInfo
        {
            get { return this._syncAuthInfo; }
        }

        private SynchConfirmDB _synchConfirmDB;
        /// <summary>
        /// 同期状況確認リモート
        /// </summary>
        public SynchConfirmDB WorkerSynchConfirmDB
        {
            get { return this._synchConfirmDB; }
        }

        // 
        private bool _isValidWachWorker;
        /// <summary>
        /// 定期スレッド実行区分(TRUE:実行、FALSE:未実行(他のapで実行中) 
        /// </summary>
        public bool IsValidWachWorker
        {
            get { return this._isValidWachWorker; }
        }

        // 初回同期中状態（数値）
        private int _staticFirstSyncDiv = 0;
        /// <summary>
        /// 初回同期区分(0:未処理、1:同期中、2:同期済み
        /// </summary>
        public int StaticFirstSyncDiv
        {
            get { return this._staticFirstSyncDiv; }
        }

        // 設定情報
        private PMSCM00210R_Setting _xmlSetting;
        /// <summary>
        /// 設定情報
        /// </summary>
        public PMSCM00210R_Setting XmlSetting
        {
            get { return this._xmlSetting; }
        }

        //同期基本情報
        private SyncBasicWorkInfo _syncBasicWorkInfo;
        /// <summary>
        /// 同期基本情報
        /// </summary>
        public SyncBasicWorkInfo SyncWorkInfo
        {
            set { this._syncBasicWorkInfo = value; }
            get { return this._syncBasicWorkInfo; }
        }
        #endregion

        #region インスタンス生成関連
        /// <summary>
        /// インスタンス取得
        /// </summary>
        /// <returns></returns>
        public static SyncExecWorkDB GetInstance(string enterpriseCode)
        {
            if (_dictSelf != null && _dictSelf.ContainsKey(enterpriseCode))
            {
                return _dictSelf[enterpriseCode];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="info"></param>
        /// <param name="pmDbIdDictionary"></param>
        public static void Initialize(SyncAuthenticationInfo info, Dictionary<string, string> pmDbIdDictionary)
        {
            if (info == null)
            {
                throw new NullReferenceException("SyncAuthenticationInfo is null.");
            }
            //SCMオプションチェック。
            List<string> enterpriseList = new CheckOptionWork().GetSoftwarePurchasedPrco(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);

            if (_dictSelf == null)
            {
                _dictSelf = new Dictionary<string, SyncExecWorkDB>();
            }
            Dictionary<string, SyncExecWorkDB> selfDict = new Dictionary<string, SyncExecWorkDB>();
            SyncExecWorkDB self = null;
            SyncAuthenticationInfo epInfo = null;
            foreach (string enterpriseCode in pmDbIdDictionary.Keys)
            {
                if (!enterpriseList.Contains(enterpriseCode))
                {
                    continue;
                }

                if (!_dictSelf.ContainsKey(enterpriseCode))
                {
                    epInfo = new SyncAuthenticationInfo();
                    epInfo.EnterpriseCode = enterpriseCode;
                    epInfo.PmDbId = pmDbIdDictionary[enterpriseCode];
                    epInfo.PmSyncUrl = info.PmSyncUrl;
                    epInfo.UserDbConnectionText = info.UserDbConnectionText;
                    self = new SyncExecWorkDB(epInfo);

                    #region インスタンス生成処理
                    SyncExecThreadDB thread = new SyncExecThreadDB(self);
                    // 同期実行(リアル)
                    self._syncExecforRealWorker = new Thread(thread.SyncRealExecWork);
                    self._syncExecforRealWorker.Name = "syncExecforRealWorker";
                    self._syncExecforRealWorker.IsBackground = true;

                    // 同期実行(バッチ)
                    self._syncExecforBatchWorker = new Thread(thread.SyncBatchExecWork);
                    self._syncExecforBatchWorker.Name = "syncExecforBatchWorker";
                    self._syncExecforBatchWorker.IsBackground = true;

                    // 定期監視
                    self._regularWatchOnWorker = new Thread(new SyncWatchThreadDB(self).RegularWatchOnWork);
                    self._regularWatchOnWorker.IsBackground = true;

                    // 初回同期中状態の更新
                    self.UpdateStaticFirstSyncDiv();
                    self._syncExecforRealWorker.Start();
                    self._syncExecforBatchWorker.Start();

                    // 監視実行管理マスタの更新
                    int status = self.UpdateSyncMonitMngData();
                    if (status != -1 && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        continue;
                    }
                    else
                    {
                        self._firstSyncWorker = new Thread(new FirstSyncExecThreadDB(self).FirstSyncWork);
                        self._firstSyncWorker.IsBackground = true;
                        if (self.StaticFirstSyncDiv < 2)
                        {
                            self._firstSyncWorker.Start();
                        }

                        //変換
                        self._translateWorker = new Thread(new SyncWatchThreadDB(self).TranslateStart);
                        self._translateWorker.IsBackground = true;

                        self._regularWatchOnWorker.Start();
                        self._translateWorker.Start();
                    }
                    #endregion
                    _dictSelf.Add(enterpriseCode, self);
                }
                else
                {
                    self = _dictSelf[enterpriseCode];
                    self.UpdateStaticFirstSyncDiv();
                    #region スレッド再活性処理
                    if (self._syncExecforBatchWorker != null && !self._syncExecforBatchWorker.IsAlive)
                    {
                        self._syncExecforBatchWorker.Start();
                    }
                    if (self._syncExecforRealWorker != null && !self._syncExecforRealWorker.IsAlive)
                    {
                        self._syncExecforRealWorker.Start();
                    }

                    // 監視実行管理マスタの更新
                    int status = self.UpdateSyncMonitMngData();
                    if (status != -1 && status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return;
                    }
                    //一応死んでいたら再起動させる。
                    if (self._firstSyncWorker != null && !self._firstSyncWorker.IsAlive)
                    {
                        self._firstSyncWorker = new Thread(new FirstSyncExecThreadDB(self).FirstSyncWork);
                        if (self.StaticFirstSyncDiv < 2)
                        {
                            self._firstSyncWorker.IsBackground = true;
                            self._firstSyncWorker.Start();
                        }
                    }
                    if (self._translateWorker != null && !self._translateWorker.IsAlive)
                    {
                        self._translateWorker.Start();
                    }
                    if (self._regularWatchOnWorker != null && !self._regularWatchOnWorker.IsAlive)
                    {
                        self._regularWatchOnWorker.Start();
                    }
                    #endregion
                }
            }
        }

        /// <summary>
        /// 同期実行クラスDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private SyncExecWorkDB(SyncAuthenticationInfo info)
        {
            this._syncAuthInfo = info;
            _xmlSetting = null;
            // 設定XML取得処理
            InitializeXmlSettings(info.PmDbId, out _xmlSetting);
            // 設定XML取得失敗場合、処理中止
            if (_xmlSetting == null)
            {
                base.WriteErrorLog("PMSCM00210R_Setting.xml is not found.");
                throw new Exception("PMSCM00210R_Setting.xml is not found.");
            }
            this._syncBasicWorkInfo = new SyncBasicWorkInfo();
            this._syncBasicWorkInfo.DataCheckInterval = 60 * 24; //1日間隔

            // PM側DBアクセス
            this._synchConfirmDB = new SynchConfirmDB();
        }
        #endregion

        #region スレッド管理
        /// <summary>
        /// リアル同期スレッドの待機用
        /// </summary>
        public void SyncThreadWait()
        {
            lock (_syncReadLockObj)
            {
                Monitor.Wait(_syncReadLockObj, XmlSetting.BatchInterval * 1000);
            }
        }

        /// <summary>
        /// リアル同期スレッドの起動用
        /// </summary>
        public void SyncThreadWakeUp()
        {
            lock (_syncReadLockObj)
            {
                Monitor.PulseAll(_syncReadLockObj);
            }
        }

        /// <summary>
        /// バッチ同期スレッドの待機用
        /// </summary>
        public void SyncBatchThreadWait()
        {
            lock (_syncBatchLockObj)
            {
                Monitor.Wait(_syncBatchLockObj, XmlSetting.BatchInterval * 1000);
            }
        }

        /// <summary>
        /// バッチ同期スレッドの起動用
        /// </summary>
        public void SyncBatchThreadWakeUp()
        {
            lock (_syncBatchLockObj)
            {
                Monitor.PulseAll(_syncBatchLockObj);
            }
        }

        /// <summary>
        /// 初回同期スレッド待機用
        /// </summary>
        public void FirstSyncThreadWait()
        {
            lock (_firstSyncObj)
            {
                Monitor.Wait(_firstSyncObj);
            }
        }

        /// <summary>
        /// 初回同期スレッドの起動用
        /// </summary>
        public void FirstSyncThreadWakeUp()
        {
            lock (_firstSyncObj)
            {
                Monitor.PulseAll(_firstSyncObj);
            }
        }

        /// <summary>
        /// 初回同期スレッド待機用
        /// </summary>
        public void TranslateThreadWait()
        {
            DateTime dt = DateTime.ParseExact(string.Format("{0:yyyyMMdd}{1}", DateTime.Now, this.XmlSetting.TranslateTime), "yyyyMMddHHmmss", null);
            if (dt <= DateTime.Now)
            {
                dt = dt.AddDays(1.0);
            }
            TimeSpan ts = (dt - DateTime.Now);
            lock (_syncTransLockObj)
            {
                //MOD:2015/02/12 ------------------ >>>>>
                if (this.StaticFirstSyncDiv == 2)
                {
                    //初回同期が完了しているのであれば、
                    //手動実行などによる明示的な要求がない限りは延々と待機させる。
                    Monitor.Wait(_syncTransLockObj);
                }
                else
                {
                    Monitor.Wait(_syncTransLockObj, ts);
                }
                //MOD:2015/02/12 ------------------ <<<<<
            }
        }

        /// <summary>
        /// 初回同期スレッドの起動用
        /// </summary>
        public void TranslateThreadWakeUp()
        {
            lock (_syncTransLockObj)
            {
                Monitor.PulseAll(_syncTransLockObj);
            }
        }
        #endregion

        #region Public Method
        /// <summary>
        /// 実行スレッド開始処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 実行スレッド開始処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public void StartSyncExec()
        {
            this.SyncThreadWakeUp();
        }

        /// <summary>
        /// 監視実行管理マスタの更新処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 監視実行管理マスタの更新処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public int UpdateSyncMonitMngData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            this._isValidWachWorker = false;
            // 監視実行する場合は、初回同期中状態の更新を行う
            // 監視実行管理マスタより先頭レコード
            string errStr = "";
            string computerName = "";
            // コンピューター名、
            string localName = System.Net.Dns.GetHostName();
            if (localName.Length > 20)
            {
                localName = localName.Substring(0, 20);
            }
            long monitoringTime = 0;
            status = SearchSyncMonitMngData(out computerName, out monitoringTime, out errStr);
            // TODO status 再判断
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                return status;
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // コンピューター名が自端末と異なり
                // 監視実行日時＞（システム日時－レプリカDB定期監視間隔（秒）－監視猶予時間（秒））の場合
                if (!computerName.Equals(localName) &&
                    monitoringTime > (DateTimeToYYYYMMDDHHMMSS(DateTime.Now.AddSeconds((_xmlSetting.WatchOnReplicaDBIntervalTime + _xmlSetting.WatchOnHesitateTime) * -1))))
                {
                    return -1;
                }
            }

            // 監視実行日時
            monitoringTime = DateTimeToYYYYMMDDHHMMSS(DateTime.Now);

            // テーブルロック、更新処理
            status = WriteSyncMonitMngData(localName, monitoringTime);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._isValidWachWorker = true;
            }
            return status;
        }

        /// <summary>
        /// 初回同期中状態の更新処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初回同期中状態の更新処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public int UpdateStaticFirstSyncDiv()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            object retObj = null;
            string errStr = "";

            #region  同期管理マスタが１レコード以上ある場合は、同期完了とみなして、初回同期中状態＝２　をセット
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            //同期実行状態に関わらず初回同期情報の取得
            const string sqlText = " SELECT TOP(1) 1 FROM SYNCREQDATARF AS SUB01 WITH(READUNCOMMITTED) "
                                 + " WHERE "
                                 + " SUB01.ENTERPRISECODERF=@FINDENTERPRISECODE"
                                 + " AND SYNCTARGETDIVRF=2 "
                                 + " ";
            try
            {
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクションを開始
                SqlTransaction sqlTransaction = this.CreateTransaction(ref sqlConnection);

                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                #region パラメータ設定
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);
                #endregion

                sqlReader = sqlCommand.ExecuteReader();
                if (sqlReader.Read())
                {
                    this._staticFirstSyncDiv = 1;//同期中
                }
                else
                {
                    this._staticFirstSyncDiv = 0;//未処理
                }
            }
            finally
            {
                CloseQuietly(sqlReader);
                CloseQuietly(sqlCommand);
                CloseQuietly(sqlConnection);
            }
            #endregion

            if (this._staticFirstSyncDiv == 0)
            {
                retObj = null;
                SyncMngWork con = new SyncMngWork();
                con.EnterpriseCode = this.SyncAuthInfo.EnterpriseCode;
                object param = (object)con;
                status = _synchConfirmDB.SearchSyncMngData(out retObj, out errStr, con, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._staticFirstSyncDiv = 2;//同期済み
                }
            }
            return status;
        }

        /// <summary>
        /// トランザクションIDの取得。
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public long GetTransactionId(SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand("SELECT TOP 1 transaction_id FROM sys.dm_tran_current_transaction", sqlConnection, sqlTransaction);
                object o = sqlCommand.ExecuteScalar();
                if (o is Int64)
                {
                    return (long)o;
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                CloseQuietly(sqlCommand);
            }
        }
        /// <summary>
        /// 日付変換処理
        /// </summary>
        /// <param name="dt">日付</param>
        /// <remarks>
        /// <br>Note       : 日付変換処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        public static long DateTimeToYYYYMMDDHHMMSS(DateTime dt)
        {
            long dtLong = TDateTime.DateTimeToLongDate("YYYYMMDD", dt);
            return dtLong * 1000000 + dt.Hour * 10000 + dt.Minute * 100 + dt.Second;
        }

        /// <summary>
        /// SQLConnectionをクローズします。
        /// 発生する例外は無視します。
        /// </summary>
        /// <param name="sqlConnection"></param>
        public static void CloseQuietly(SqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// SqlCommandをクローズします。
        /// 発生する例外は無視します。
        /// </summary>
        /// <param name="sqlCommand"></param>
        public static void CloseQuietly(SqlCommand sqlCommand)
        {
            try
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// SqlDataReaderをクローズします。
        /// 発生する例外は無視します。
        /// </summary>
        /// <param name="sqlReader"></param>
        public static void CloseQuietly(SqlDataReader sqlReader)
        {
            try
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// sqlTransactionをコミット/ロールバックします。
        /// そしてオブジェクトを破棄します。
        /// </summary>
        /// <param name="sqlTransaction"></param>
        /// <param name="status"></param>
        public static void CommitCloseQuietly(SqlTransaction sqlTransaction, int status)
        {
            try
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //ロールバック
                            sqlTransaction.Rollback();
                        }
                    }
                    sqlTransaction.Dispose();
                }
            }
            catch
            {
            }
        }
        #endregion

        # region Private Method
        /// <summary>
        /// 設定XMLファイル情報取得処理。
        /// パーツマンDBID出力。
        /// ログファイルの削除
        /// </summary>
        /// <param name="pmDbId">パーツマンDBID</param>
        /// <param name="pMSCM00210R_Setting">設定XMLファイル情報</param>
        /// <remarks>
        /// <br>Note       : 設定XMLファイル情報取得処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private void InitializeXmlSettings(string pmDbId, out PMSCM00210R_Setting pMSCM00210R_Setting)
        {
            pMSCM00210R_Setting = null;
            RegistryKey keyForLog = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            string homeDir = keyForLog.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            string path = Path.Combine(homeDir, "PMSCM00210R_Setting.xml");
            #region 設定ファイル読み込み
            if (File.Exists(path))
            {
                System.Xml.XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;
                System.Xml.XmlReader reader = null;

                try
                {
                    reader = System.Xml.XmlReader.Create(path, settings);

                    pMSCM00210R_Setting = new PMSCM00210R_Setting();
                    SyncTableInfo tableInfo = null;
                    string tableId = "";
                    string tableNm = "";
                    string tableJsonId = "";
                    string value;
                    while (reader.Read())
                    {
                        value = reader.Value;
                        // リトライ回数の最大値
                        if (reader.IsStartElement("MaxRetryCount"))
                        {
                            pMSCM00210R_Setting.MaxRetryCount = Convert.ToInt32(reader.ReadElementString("MaxRetryCount").Trim());
                        }
                        // リトライ間隔（秒）
                        if (reader.IsStartElement("RetryIntervalTime"))
                        {
                            pMSCM00210R_Setting.RetryIntervalTime = Convert.ToInt32(reader.ReadElementString("RetryIntervalTime").Trim());
                        }
                        // レプリカDB定期監視間隔（秒）
                        if (reader.IsStartElement("WatchOnReplicaDBIntervalTime"))
                        {
                            pMSCM00210R_Setting.WatchOnReplicaDBIntervalTime = Convert.ToInt32(reader.ReadElementString("WatchOnReplicaDBIntervalTime").Trim());
                        }
                        // 監視猶予時間（秒）
                        if (reader.IsStartElement("WatchOnHesitateTime"))
                        {
                            pMSCM00210R_Setting.WatchOnHesitateTime = Convert.ToInt32(reader.ReadElementString("WatchOnHesitateTime").Trim());
                        }
                        // バッチ実行間隔
                        if (reader.IsStartElement("BatchInterval"))
                        {
                            pMSCM00210R_Setting.BatchInterval = Convert.ToInt32(reader.ReadElementString("BatchInterval").Trim());
                        }
                        // データ一括送信件数
                        if (reader.IsStartElement("DataSendLimitSize"))
                        {
                            pMSCM00210R_Setting.DataSendLimitSize = Convert.ToInt32(reader.ReadElementString("DataSendLimitSize").Trim());
                        }
                        // データ一括送信件数
                        if (reader.IsStartElement("TranslateTime"))
                        {
                            pMSCM00210R_Setting.TranslateTime = reader.ReadElementString("TranslateTime").Trim();
                        }
                        if (reader.IsStartElement("SyncTableInfo") || (reader.NodeType == System.Xml.XmlNodeType.EndElement))
                        {
                            continue;
                        }
                        try
                        {
                            // テーブルID
                            if (reader.IsStartElement("SyncTableId"))
                            {
                                tableId = reader.ReadElementString("SyncTableId");
                            }
                            // テーブル名称
                            if (reader.IsStartElement("SyncTableNm"))
                            {
                                tableNm = reader.ReadElementString("SyncTableNm");
                            }
                            if (reader.IsStartElement("SyncTableJsonId"))
                            {
                                tableJsonId = reader.ReadElementString("SyncTableJsonId");
                            }
                            if (!String.IsNullOrEmpty(tableId) && !String.IsNullOrEmpty(tableNm))
                            {
                                tableInfo = new SyncTableInfo();
                                tableInfo.SyncTableId = tableId;
                                tableInfo.SyncTableNm = tableNm;
                                tableInfo.SyncTableJsonId = tableJsonId;
                                pMSCM00210R_Setting.TablesInfoList.Add(tableInfo);
                                tableId = "";
                                tableNm = "";
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
                finally
                {
                    if (reader != null) reader.Close();
                }
            }
            #endregion

            #region PMDBID出力
            StreamWriter writer = null;
            try
            {
                try
                {
                    if (!Directory.Exists(Path.Combine(homeDir, @"Log\")))
                    {
                        Directory.CreateDirectory(Path.Combine(homeDir, @"Log\"));
                    }
                }
                catch
                {
                }
                writer = File.CreateText(Path.Combine(homeDir, @"Log\PMDBID.txt"));
                writer.WriteLine(pmDbId);
                if (this._syncAuthInfo.PmSyncUrl != null && this._syncAuthInfo.PmSyncUrl.IndexOf("?") != -1)
                {
                    writer.WriteLine(this._syncAuthInfo.PmSyncUrl.Substring(0, this._syncAuthInfo.PmSyncUrl.IndexOf("?")));
                }
                writer.WriteLine(DateTime.Now.ToString());
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            #endregion

            #region ログクリーン
            try
            {
                DirectoryInfo dir = new DirectoryInfo(Path.Combine(homeDir, @"Log\PMSCM00220B"));
                if (dir.Exists)
                {
                    DateTime deleteTime = DateTime.Now.AddMonths(-1);
                    foreach (DirectoryInfo d in dir.GetDirectories())
                    {
                        foreach (FileInfo f in d.GetFiles())
                        {
                            if (f.LastWriteTime <= deleteTime)
                            {
                                f.Delete();
                            }
                        }
                    }
                }
            }
            catch
            {
                //例外処理は隠蔽
                //ロックファイルがあってもそれは無視する。
            }
            #endregion
        }

        /// <summary>
        /// 調査用ログ
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="message"></param>
        /// <param name="type"></param>
        public static void DebugLog(string enterpriseCode, string message, string type)
        {
            RegistryKey keyForLog = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            string homeDir = keyForLog.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            StreamWriter writer = null;
            try
            {
                string logDir = Path.Combine(homeDir, @"Log\PMSCM00220B\" + enterpriseCode);
                try
                {
                    if (!Directory.Exists(logDir))
                    {
                        Directory.CreateDirectory(logDir);
                    }
                }
                catch
                {
                }
                writer = new StreamWriter(Path.Combine(logDir, DateTime.Now.ToString("yyyyMMdd", null) + "_" + type + "_DebugLog.txt"), true);
                writer.WriteLine(string.Format(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " : " + message));
                writer.Flush();
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// 同期監視実行管理の更新処理
        /// </summary>
        /// <param name="computerName">コンピューター名</param>
        /// <param name="monitoringTime">監視時間</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 同期監視実行管理の更新処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private int WriteSyncMonitMngData(string computerName, long monitoringTime)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = WriteSyncMonitMngDataProc(computerName, monitoringTime, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncExecDBWork.WriteSyncMonitMngData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                CommitCloseQuietly(sqlTransaction, status);
                CloseQuietly(sqlConnection);
            }

            return status;
        }

        /// <summary>
        /// 同期監視実行管理の更新処理
        /// </summary>
        /// <param name="computerName">コンピューター名</param>
        /// <param name="monitoringTime">監視時間</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 同期監視実行管理の更新処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private int WriteSyncMonitMngDataProc(string computerName, long monitoringTime, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (computerName != null)
                {
                    sqlCommand = new SqlCommand("SELECT    CREATEDATETIMERF    ,UPDATEDATETIMERF    ,ENTERPRISECODERF    ,FILEHEADERGUIDRF    ,COMPUTERNAMERF    ,MONITORINGTIMERF  FROM SYNCMONITMNGRF WITH (HOLDLOCK) WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection, sqlTransaction);

                    //Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                    //Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);

                    myReader = sqlCommand.ExecuteReader();

                    if (myReader.Read())
                    {
                        //Updateコマンドの生成
                        #region [UPDATE文]

                        sqlCommand.CommandText = "UPDATE SYNCMONITMNGRF SET   UPDATEDATETIMERF=@UPDATEDATETIME   ,COMPUTERNAMERF=@COMPUTERNAME   ,MONITORINGTIMERF=@MONITORINGTIME WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                        #endregion

                        //KEYコマンドを再設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);
                    }
                    else
                    {
                        //Insertコマンドの生成
                        #region [INSERT文]

                        sqlCommand.CommandText = "INSERT INTO SYNCMONITMNGRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, COMPUTERNAMERF, MONITORINGTIMERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @COMPUTERNAME, @MONITORINGTIME)";
                        #endregion
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraComputerName = sqlCommand.Parameters.Add("@COMPUTERNAME", SqlDbType.NVarChar);
                    SqlParameter paraMonitoringTime = sqlCommand.Parameters.Add("@MONITORINGTIME", SqlDbType.BigInt);
                    #endregion

                    #region Parameterオブジェクトへ値設定(更新用)
                    paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(DateTime.Now);
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(DateTime.Now);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);
                    paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(Guid.NewGuid());
                    paraComputerName.Value = SqlDataMediator.SqlSetString(computerName);
                    paraMonitoringTime.Value = SqlDataMediator.SqlSetInt64(monitoringTime);
                    #endregion

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            catch (SqlException ex)
            {
                base.WriteSQLErrorLog(ex, ex.Message, ex.Number);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                base.WriteErrorLog(ex, ex.Message, status);
            }
            finally
            {
                CloseQuietly(myReader);
                CloseQuietly(sqlCommand);
            }

            return status;
        }

        /// <summary>
        /// 同期監視実行管理の検索
        /// </summary>
        /// <param name="computerName">コンピューター名</param>
        /// <param name="monitoringTime">監視時間</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 同期監視実行管理の更新処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private int SearchSyncMonitMngData(out string computerName, out long monitoringTime, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            computerName = "";
            monitoringTime = 0;
            errMessage = string.Empty;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = SearchSyncMonitMngDataProc(out computerName, out monitoringTime, out errMessage, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "SyncExecDBWork.SearchSyncMonitMngData Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                CommitCloseQuietly(sqlTransaction, status);
                CloseQuietly(sqlConnection);
            }

            return status;
        }

        /// <summary>
        /// 同期監視実行管理の検索
        /// </summary>
        /// <param name="computerName">コンピューター名</param>
        /// <param name="monitoringTime">監視時間</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 同期監視実行管理の更新処理を行う。</br>
        /// <br>Programmer : zhubj</br>
        /// <br>Date       : 2014/08/07</br>
        /// </remarks>
        private int SearchSyncMonitMngDataProc(out string computerName, out long monitoringTime, out string errMessage, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMessage = null;
            computerName = "";
            monitoringTime = 0;
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                sqlCommand = new SqlCommand("SELECT    CREATEDATETIMERF    ,UPDATEDATETIMERF ,ENTERPRISECODERF  ,FILEHEADERGUIDRF  ,COMPUTERNAMERF  ,MONITORINGTIMERF  FROM SYNCMONITMNGRF WITH(READUNCOMMITTED) WHERE  ENTERPRISECODERF=@FINDENTERPRISECODE ", sqlConnection, sqlTransaction);
                //企業コード
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(this.SyncAuthInfo.EnterpriseCode);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    computerName = SqlDataMediator.SqlGetString(sqlDataReader, sqlDataReader.GetOrdinal("COMPUTERNAMERF"));
                    monitoringTime = SqlDataMediator.SqlGetInt64(sqlDataReader, sqlDataReader.GetOrdinal("MONITORINGTIMERF"));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteSQLErrorLog(ex);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SyncExecDBWork.SearchSyncMonitMngDataProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                CloseQuietly(sqlDataReader);
                CloseQuietly(sqlCommand);
            }

            return status;
        }


        /// <summary>
        /// SqlConnectionオブジェクトを生成します。
        /// </summary>
        /// <returns>SqlConnectionオブジェクト、もしくはnull</returns>
        /// <remarks>
        /// <br>Programmer : 松本宏紀</br>
        /// <br>Date       : 2014/08/25</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            string connectionText = this._syncAuthInfo.UserDbConnectionText;
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion
    }
}

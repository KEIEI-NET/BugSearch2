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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 同期実行管理 リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期実行管理実データ操作を行うクラスです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2014/08/01</br>
    /// </remarks>
    [Serializable]
    public class SynchExecuteMngDB : RemoteWithAppLockDB, ISynchExecuteMngDB
    {
        #region [ Constructor]
        /// <summary>
        /// 同期実行管理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public SynchExecuteMngDB()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SyncNotify(object sender, EventArgs e)
        {
            SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
            synchExecuteMng.SyncReqExecute();
        }

        /// <summary>
        /// 同期実行クラスをInstance化
        /// </summary>
        /// <param name="syncServUrl"></param>
        private void InitializeSyncExecWorkDB(string syncServUrl)
        {
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            SyncAuthenticationInfo info = new SyncAuthenticationInfo();
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            info.EnterpriseCode = acquisition.EnterpriseCode;
            info.UserDbConnectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            info.PmSyncUrl = syncServUrl;
            //同期実行クラスをInstance化
            SyncExecWorkDB.Initialize(info, this.GetPmDbId());
        }

        private SyncExecWorkDB GetSyncExecWorkDB()
        {
            return SyncExecWorkDB.GetInstance(new ServerLoginInfoAcquisition().EnterpriseCode);
        }
        #endregion

        /// <summary>
        /// 初回同期実施有無判定処理
        /// </summary>
        /// <returns>true:有り,false:無し</returns>
        /// <remarks>
        /// <br>Note       : 初回同期実施有無判定処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        private bool SyncMngDataExists()
        {
            SynchConfirmDB synchConfirmDB = new SynchConfirmDB();
            bool isSyncMngDataExists = synchConfirmDB.SyncMngDataExists();

            return isSyncMngDataExists;
        }

        #region ISynchExecuteMngDB メンバ

        /// <summary>
        /// 最大再試行回数の取得処理
        /// </summary>
        /// <param name="maxRetryCount">最大再試行回数</param>
        /// <remarks>
        /// <br>Note       : 最大再試行回数の取得処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void GetMaxRetryCount(out int maxRetryCount)
        {
            SyncExecWorkDB worker = GetSyncExecWorkDB();
            if (worker == null)
            {
                maxRetryCount = 0;
            }
            else
            {
                maxRetryCount = worker.XmlSetting.MaxRetryCount;
            }
        }

        /// <summary>
        /// 同期要求処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 同期要求処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void SyncReqExecute()
        {
            SyncExecWorkDB worker = GetSyncExecWorkDB();
            if (worker != null)
            {
                worker.StartSyncExec();
            }
        }

        /// <summary>
        /// 変換開始要求処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        public void TranslateExecute()
        {
            string enterpriseCode = new ServerLoginInfoAcquisition().EnterpriseCode;
            SyncExecWorkDB worker = SyncExecWorkDB.GetInstance(enterpriseCode);
            if (worker != null)
            {
                worker.TranslateThreadWakeUp();
            }
        }

        /// <summary>
        /// 指定テーブル同期要求処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableIDList">テーブル名（複数）</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 指定テーブル同期要求処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SyncReqExecuteForTable(string enterpriseCode, object tableIDList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SyncExecWorkDB worker = GetSyncExecWorkDB();
            if (worker == null)
            {
                return status;
            }

            //初回同期実施有無判定処理処理にて初回同期の有無を確認
            if (SyncMngDataExists())
            {
                SynchConfirmDB synchConfirmDB = new SynchConfirmDB();
                ArrayList tableList = (ArrayList)tableIDList;
                status = synchConfirmDB.WriteSyncReqDataForTable(enterpriseCode, tableList, GetSyncExecWorkDB().XmlSetting.MaxRetryCount);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //同期実行スレッドを待ち状態から解放します
                    worker.StartSyncExec();
                    worker.SyncBatchThreadWakeUp();
                }
            }
            return status;
        }

        /// <summary>
        /// 同期要求再開処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 同期要求再開処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int SyncReqReExecute()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SyncExecWorkDB worker = GetSyncExecWorkDB();
            if (worker == null)
            {
                return status;
            }

            //最大試行回数の取得
            int maxRetryCount = 0;
            this.GetMaxRetryCount(out maxRetryCount);

            SynchConfirmDB synchConfirmDB = new SynchConfirmDB();
            status = synchConfirmDB.UpdateRetryCount(maxRetryCount);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //同期実行スレッドを待ち状態から解放します
                worker.StartSyncExec();
                worker.SyncBatchThreadWakeUp();
            }

            return status;
        }

        /// <summary>
        /// 定期起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : クライアントに登録される同期処理起動画面から呼び出されます</br>
        /// <br>             オプションが途中から追加になった場合や、初回同期実行後に</br>
        /// <br>             同期実行クラスをInstance化し、同期処理が動作する様にします。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public void RegularStart(string syncServUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(syncServUrl))
                {
                    throw new Exception("syncServUrl is null.");
                }
                //同期実行クラスがInstance化されていない場合はInstance化
                //同期実行クラスをInstance化
                InitializeSyncExecWorkDB(syncServUrl);
                this.SyncReqExecute();
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SynchExecuteMngDB.RegularStart Exception=" + ex.Message);
            }
        }
        #endregion

        private Dictionary<string, string> GetPmDbId()
        {
            Dictionary<string, string> answer = new Dictionary<string, string>();

            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlReader = null;
            string sqlText = "SELECT ENTERPRISECODERF,DBIDMNGGUIDRF FROM PMDBIDMNGRF WITH(READUNCOMMITTED)";
            string enterpriseCode = null;
            string pmdbid = null;
            try
            {
                sqlConnection = this.CreateSqlConnection(true);
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    enterpriseCode = SqlDataMediator.SqlGetString(sqlReader, sqlReader.GetOrdinal("ENTERPRISECODERF"));
                    pmdbid = SqlDataMediator.SqlGetString(sqlReader, sqlReader.GetOrdinal("DBIDMNGGUIDRF"));
                    answer.Add(enterpriseCode, pmdbid);
                }
                return answer;
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }
    }

    /// <summary>
    /// オプションチェッククラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : オプションチェッククラスです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2014/08/01</br>
    /// </remarks>
    public class CheckOptionWork
    {
        /// <summary>
        /// オプションチェッククラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public CheckOptionWork()
        {

        }

        /// <summary>
        /// オプション有無確認処理
        /// </summary>
        /// <param name="softwareCode">コード</param>
        /// <returns>true:有り,false:無し</returns>
        /// <remarks>
        /// <br>Note       : 指定のソフトウェアコードのオプションが存在するかどうかを確認します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public bool CheckSoftwarePurchasedPrco(string softwareCode)
        {
            bool exists = false;
            try
            {
                object objReslutList = null;

                //オプション管理マスタリモート
                PMOptMngDB pmOptMngDB = new PMOptMngDB();
                int status = pmOptMngDB.SearchAll(out objReslutList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = (ArrayList)objReslutList;

                    if (resultList != null && resultList.Count > 0)
                    {
                        foreach (PMOptMngWork work in resultList)
                        {
                            //オプション利用区分 [0:未使用、1:使用]
                            if (work.OptionCode == softwareCode && work.OptionUseDiv == 1)
                            {
                                exists = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                exists = false;
            }
            return exists;
        }

        /// <summary>
        /// 指定オプション導入済み企業コードの取得
        /// </summary>
        /// <param name="softwareCode">コード</param>
        /// <returns>true:有り,false:無し</returns>
        /// <remarks>
        /// <br>Note       : 指定のソフトウェアコードのオプションが存在するかどうかを確認します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public List<string> GetSoftwarePurchasedPrco(string softwareCode)
        {
            List<string> answer = new List<string>();
            try
            {
                object objReslutList = null;

                //オプション管理マスタリモート
                PMOptMngDB pmOptMngDB = new PMOptMngDB();
                int status = pmOptMngDB.SearchAll(out objReslutList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = (ArrayList)objReslutList;

                    if (resultList != null && resultList.Count > 0)
                    {
                        foreach (PMOptMngWork work in resultList)
                        {
                            //オプション利用区分 [0:未使用、1:使用]
                            if (work.OptionCode == softwareCode && work.OptionUseDiv == 1)
                            {
                                answer.Add(work.EnterpriseCode);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return answer;
        }
    }
}


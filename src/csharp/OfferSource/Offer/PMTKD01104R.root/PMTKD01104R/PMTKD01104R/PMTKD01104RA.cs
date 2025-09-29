//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 提供データ削除処理DBリモートオブジェクト
// プログラム概要   : 提供データ削除処理データ操作を行うクラスです
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内
// 修 正 日  2009/07/21  修正内容 : タイムアウト対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Microsoft.Win32;
using System.Security;
using Broadleaf.Library.Resources;

// 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>. 
using MSMC = Microsoft.SqlServer.Management.Common;
using CustomInstaller;
// 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

namespace Broadleaf.Application.Remoting
{

    internal class LogWriter
    {
        public static void Write(string msg)
        {
            //# if DEBUG
            System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\log.txt", true);
            sw.WriteLine(DateTime.Now.ToString("hh:mm:ss") + "  " + msg);

            sw.Close();
            //# endif
        }
    }

    /// <summary>
    /// 提供データ削除処理READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 提供データ削除処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.06.16</br>
    /// </remarks>
    [Serializable]
    public class OfferDataDeleteDB : RemoteDB, IOfferDataDeleteDB
    {
        # region Constructor
       /// <summary>
        /// 提供データ削除処理コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public OfferDataDeleteDB()
            : base("PMTKD01106D", "Broadleaf.Application.Remoting.ParamData.OfferDataDeleteWork", "OFFERDATADELETE")
        {
        }
        #endregion

        #region 提供データ削除処理
        #region 提供データ削除処理
        /// <summary>
        /// 提供データ削除処理
        /// </summary>
        /// <param name="offerDataDeleteList">提供データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 提供データ削除処理を行うクラスです。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        public int DeleteOfferData(ref object offerDataDeleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                //コレクション生成
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_OfferDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                UbauControl ubauControl = new UbauControl();
                UbauControl.DbMaintenanceInfo dbMaintenanceInfo = new UbauControl.DbMaintenanceInfo();
                InstallationInfo installationInfo = new InstallationInfo();

                installationInfo.ServerName = Environment.MachineName;
                installationInfo.ServerType = "DB";
                installationInfo.ServiceCode = "OFFER_DB";         //DBの種類コード(USER_DB,OFFER_DB等）
                installationInfo.OsAdminId = "";                        //未入力OK
                installationInfo.OsAdminPwd = "";                      //未入力OK
                installationInfo.InstallMngr = "";                      //未入力OK
                installationInfo.ProductCode = ConstantManagement_SF_PRO.ProductCode;      //プロダクトコード(必須)
                installationInfo.DBTblNmLst = new string[] { };

                dbMaintenanceInfo = ubauControl.GetDbInfo(installationInfo, UbauControl.TargetSystem.LSM);

                //sa認証に接続文字列を変更
                SqlConnectionStringBuilder saConText = new SqlConnectionStringBuilder(_connectionText);

                saConText.UserID = dbMaintenanceInfo.MyDbInfo.AdminId;
                saConText.Password = dbMaintenanceInfo.MyDbInfo.AdminPwd;
                // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // 2009/07/21 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //sqlConnection = new SqlConnection(_connectionText);
                sqlConnection = new SqlConnection(saConText.ConnectionString);
                // 2009/07/21 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                sqlConnection.Open();

                // 削除処理を行う
                status = DeleteProc(ref offerDataDeleteList, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferDataDeleteDB.Delete");
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region [DeleteProc]
        /// <summary>
        /// 提供データ削除処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="offerDataDeleteList">提供データ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 提供データ削除処理を行うクラスです。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        private int DeleteProc(ref object offerDataDeleteList, ref SqlConnection sqlConnection)
        {
            // 全てテーブル処理状態
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // 各テーブル処理状態
            int subStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {
                ArrayList list = offerDataDeleteList as ArrayList;
                for (int i = 0; i < list.Count; i++)
                {
                    OfferDataDeleteWork work = (OfferDataDeleteWork)list[i];
                    subStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    // 処理コードにより、クリア処理を行う
                    switch (work.Code)
                    {
                        case 0: // 処理コード＝0：無条件クリア
                            subStatus = DeleteDataByCode0(work.TableID, ref sqlConnection);
                            break;
                        case 9: // 処理コード＝9、データクリア処理対象、ここで何にもしない
                            break;
                    }

                    // 処理結果の設定
                    if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        work.Result = "OK";
                    }
                    else
                    {
                        work.Result = "NG";
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "OfferDataDeleteDB.DeleteProc");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region 処理コード＝0：無条件クリア
        /// <summary>
        /// 処理コード＝0：無条件クリアの処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="tableId">テーブルID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 提供データ削除処理を行うクラスです。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.18</br>
        private int DeleteDataByCode0(string tableId, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // トランザクション開始
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // クリア処理
                status = DeleteDataByCode0Proc(tableId, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode0");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 処理コード＝0：無条件クリアの処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="tableId">テーブルID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 提供データ削除処理を行うクラスです。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        private int DeleteDataByCode0Proc(string tableId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            StringBuilder sqlText = new StringBuilder(string.Empty);
            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);
                //sql文
                // 2009/07/21 >>>>>>>>>>>>>>>>>>>
                //sqlText.Append("DELETE FROM ");
                sqlText.Append("TRUNCATE TABLE ");
                // 2009/07/21 <<<<<<<<<<<<<<<<<<<
                sqlText.Append(tableId);
                sqlCommand.CommandText = sqlText.ToString();

                // ADD 2009/07/13 
                // レコード削除時のTimeoutの設定
                sqlCommand.CommandTimeout = 3600;
                // 実行
                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "OfferDataDeleteDB.DeleteProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OfferDataDeleteDB.DeleteProc" + status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #endregion

        #region サーバーのレジストリ更新処理
        /// <summary>
        /// サーバーのレジストリ更新処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : サーバーのレジストリ更新処理</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.16</br>
        public int ServerRegeditUpdate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string rKeyName = @String.Format("SOFTWARE\\Broadleaf\\Service\\Partsman\\OFFER_AP\\localhost\\OFFER_DB");
            try
            {
                RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName, true);
                // パスは存在ない
                if (rKey == null)
                {
                    rKey = Registry.LocalMachine.CreateSubKey(rKeyName);
                }
                // カレントフォルダの設定
                rKey.SetValue("CurrentVersion", "99.99.99.99", RegistryValueKind.String);
            }
            catch (SecurityException sex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(sex, "OfferDataDeleteDB.ServerRegeditUpdate" + status);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "OfferDataDeleteDB.ServerRegeditUpdate" + status);
            }
            return status;

        }
        #endregion

        #region [トランザクション作成処理]
        /// <summary>
        /// トランザクション作成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            // トランザクション開始
#if DEBUG
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            return sqlTransaction;
        }
        #endregion //トランザクション作成処理

    }
}

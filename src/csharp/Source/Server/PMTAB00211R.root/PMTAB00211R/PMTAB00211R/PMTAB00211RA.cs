//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMTABセッション管理データ  DBリモートオブジェクト
// プログラム概要   : PMTABセッション管理データテーブルに対して追加・更新・削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11300141-00 作成担当 : 譚洪
// 作 成 日  2017/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11202240-00 作成担当 : 脇田　靖之
// 作 成 日  2017/06/09  修正内容 : transaction処理不正対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTABセッション管理データ  DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTABセッション管理データテーブルの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/04/06</br>
    /// </remarks>
    [Serializable]
    public class PmTabSessionMngDB : RemoteDB, IPmTabSessionMngDB
    {
        /// <summary>
        /// PMTABセッション管理データ　DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データテーブルの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public PmTabSessionMngDB()
        {
        }

        #region [PMTABセッション管理データ削除処理]
        /// <summary>
        /// PMTABセッション管理データを削除する
        /// </summary>
        /// <param name="paraPmTabSessionMngObj">PMTABセッション管理データパラメータ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データテーブルの実データ削除を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int DeleteSessionMng(ref object paraPmTabSessionMngObj, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;


            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);
                sqlTransaction = this.CreateTransactionData(ref sqlConnection); // ADD 2017/06/09 y.wakita

                status = this.DeleteSessionMngProc(ref paraPmTabSessionMngObj, ref sqlConnection, ref sqlTransaction, out retMessage);

                // --- ADD 2017/06/09 y.wakita ----->>>>>
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
                // --- ADD 2017/06/09 y.wakita -----<<<<<
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // --- ADD 2017/06/09 y.wakita ----->>>>>
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // --- ADD 2017/06/09 y.wakita -----<<<<<

                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PmTabSessionMngDB.DeleteSessionMng Exception=" + ex.Message, status);
            }
            finally
            {
                // --- ADD 2017/06/09 y.wakita ----->>>>>
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                // --- ADD 2017/06/09 y.wakita -----<<<<<
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }


        /// <summary>
        /// PMTABセッション管理データを削除する(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraPmTabSessionMngObj">PMTABセッション管理データパラメータ</param>
        /// <param name="sqlConnection">データベース接続オブジェクト</param>
        /// <param name="sqlTransaction">トランザクションオブジェクト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データテーブルの実データ削除を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int DeleteSessionMngProc(ref object paraPmTabSessionMngObj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PmTabSessionMngWork pmTabSessionMngWork = null;
            retMessage = string.Empty;

            //ArrayListの場合
            if (paraPmTabSessionMngObj is ArrayList)
            {
                ArrayList pmTabSessionMngWorkList = paraPmTabSessionMngObj as ArrayList;

                if (pmTabSessionMngWorkList.Count > 0)
                    pmTabSessionMngWork = pmTabSessionMngWorkList[0] as PmTabSessionMngWork;
            }

            //パラメータクラスの場合
            if (paraPmTabSessionMngObj is PmTabSessionMngWork)
            {
                pmTabSessionMngWork = paraPmTabSessionMngObj as PmTabSessionMngWork;
            }

            if (pmTabSessionMngWork == null)
            {
                return status;
            }

            status = DeleteSessionMngProc(ref pmTabSessionMngWork, ref sqlConnection, ref sqlTransaction, out retMessage);
            return status;
        }

        /// <summary>
        /// PMTABセッション管理データを削除する
        /// </summary>
        /// <param name="pmTabSessionMngWork">PMTABセッション管理データパラメータ</param>
        /// <param name="sqlConnection">データベース接続オブジェクト</param>
        /// <param name="sqlTransaction">トランザクションオブジェクト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データテーブルの実データ削除を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int DeleteSessionMngProc(ref PmTabSessionMngWork pmTabSessionMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            retMsg = string.Empty;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;

            //●データベースチェック
            if (sqlConnection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                return status;
            }

            try
            {
                // --- DEL 2017/06/09 y.wakita ----->>>>>
                //// コネクション生成
                //sqlConnection = this.CreateSqlConnectionData(true);
                // --- DEL 2017/06/09 y.wakita -----<<<<<

                StringBuilder sqlText = new StringBuilder();

                // --- UPD 2017/06/09 y.wakita ----->>>>>
                //sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);
                // --- UPD 2017/06/09 y.wakita -----<<<<<

                # region [DELETE文]
                sqlText.Append("DELETE FROM PMTABSESSIONMNGRF").Append(Environment.NewLine);
                sqlText.Append("WHERE").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE").Append(Environment.NewLine);
                sqlText.Append("  AND CREATEDATETIMERF < @FINDCREATEDATETIME").Append(Environment.NewLine);
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findCreateDateTime = sqlCommand.Parameters.Add("@FINDCREATEDATETIME", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabSessionMngWork.EnterpriseCode);
                findCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabSessionMngWork.CreateDateTime);

                sqlCommand.CommandText = sqlText.ToString();
                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException e)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(e, "PmTabSessionMngDB.DeleteSessionMngProc Exception=" + e.Message, status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region[セッションID検索処理]
        /// <summary>
        /// セッションID検索処理
        /// </summary>
        /// <param name="pmTabSeesionMngObj">PMTABセッション管理データオブジェクト</param>
        /// <param name="paraPmTabSessionMngObj">PMTABセッション管理データパラメータ</param>
        /// <param name="retMessage">メッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 同一セッションIDの存在チェックを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int SearchSessionId(out object pmTabSeesionMngObj, object paraPmTabSessionMngObj, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            pmTabSeesionMngObj = null;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;        

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);
                status = this.SearchSessionIdProc(pmTabSeesionMngObj, out pmTabSeesionMngObj, ref sqlConnection, ref sqlTransaction, out retMessage);
                
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PmTabSessionMngDB.SearchSessionId Exception=" + ex.Message, status);
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


        /// <summary>
        /// セッションID検索処理する(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraPmTabSessionMngObj">PMTABセッション管理データパラメータ</param>
        /// <param name="pmTabSeesionMngObj">PMTABセッション管理データオブジェクト</param>
        /// <param name="sqlConnection">データベース接続オブジェクト</param>
        /// <param name="sqlTransaction">トランザクションオブジェクト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データテーブルの実データ削除を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int SearchSessionIdProc(object paraPmTabSessionMngObj, out object pmTabSeesionMngObj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PmTabSessionMngWork pmTabSessionMngWork = null;
            pmTabSeesionMngObj = new object();
            retMessage = string.Empty;

            //ArrayListの場合
            if (paraPmTabSessionMngObj is ArrayList)
            {
                ArrayList pmTabSessionMngWorkList = paraPmTabSessionMngObj as ArrayList;

                if (pmTabSessionMngWorkList.Count > 0)
                    pmTabSessionMngWork = pmTabSessionMngWorkList[0] as PmTabSessionMngWork;
            }

            //パラメータクラスの場合
            if (paraPmTabSessionMngObj is PmTabSessionMngWork)
            {
                pmTabSessionMngWork = paraPmTabSessionMngObj as PmTabSessionMngWork;
            }

            if (pmTabSessionMngWork == null)
            {
                return status;
            }

            status = SearchSessionIdProc(pmTabSessionMngWork, out pmTabSeesionMngObj, ref sqlConnection, ref sqlTransaction, out retMessage);
            return status;
        }

        /// <summary>
        /// セッションID検索処理
        /// </summary>
        /// <param name="pmTabSeesionMngWork">PMTABセッション管理データパラメータ</param>
        /// <param name="pmTabSeesionMngObj">PMTABセッション管理データオブジェクト</param>
        /// <param name="sqlConnection">Sql接続情報</param>
        /// <param name="sqlTransaction">トランザクションオブジェクト</param>
        /// <param name="pmTabSeesionMngList">PMTABセッション管理データリスト</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 同一セッションIDの存在チェックを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int SearchSessionIdProc(PmTabSessionMngWork pmTabSeesionMngWork, out object pmTabSeesionMngObj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            pmTabSeesionMngObj = null;
            ArrayList pmTabSeesionMngList = new ArrayList();

            //●データベースチェック
            if (sqlConnection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                return status;
            }

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                sqlCommand.CommandText = MkSelectAllSql(ref sqlCommand, pmTabSeesionMngWork);

                // クエリ実行時のタイムアウト時間を3600秒に設定する
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                PmTabSessionMngWork rsltWork = null;

                while (myReader.Read())
                {
                    // 抽出結果-値セット
                    rsltWork = new PmTabSessionMngWork();

                    rsltWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    rsltWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    rsltWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    rsltWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    rsltWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    rsltWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    rsltWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    rsltWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    rsltWork.BusinessSessionId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSSESSIONIDRF")); // 業務セッションID
                    rsltWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF")); // 受注ステータス
                    rsltWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")); // 伝票番号

                    pmTabSeesionMngList.Add(rsltWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }

                if (rsltWork == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                retMsg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PmTabSessionMngDB.SearchSessionIdProc Exception=" + ex.Message, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            pmTabSeesionMngObj = pmTabSeesionMngList;

            return status;
        }

        #endregion

        #region[PMTABセッション管理データ登録処理]
        /// <summary>
        /// PMTABセッション管理データの新規追加処理
        /// </summary>
        /// <param name="paraPmTabSessionMngObj"> PMTABセッション管理データ</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データテーブルの実データ新規追加を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int WriteSessionMng(ref object paraPmTabSessionMngObj, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);
                sqlTransaction = this.CreateTransactionData(ref sqlConnection); // ADD 2017/06/09 y.wakita

                status = this.WriteSessionMngProc(ref paraPmTabSessionMngObj, ref sqlConnection, ref sqlTransaction, out retMsg);

                // --- ADD 2017/06/09 y.wakita ----->>>>>
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
                // --- ADD 2017/06/09 y.wakita -----<<<<<
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // --- ADD 2017/06/09 y.wakita ----->>>>>
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // --- ADD 2017/06/09 y.wakita -----<<<<<
                
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PmTabSessionMngDB.WriteSessionMng Exception=" + ex.Message, status);
            }
            finally
            {
                // --- ADD 2017/06/09 y.wakita ----->>>>>
                if (sqlTransaction != null)
                    sqlTransaction.Dispose();
                // --- ADD 2017/06/09 y.wakita -----<<<<<
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// セッションID検索処理する(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="paraPmTabSessionMngObj">PMTABセッション管理データパラメータ</param>
        /// <param name="sqlConnection">データベース接続オブジェクト</param>
        /// <param name="sqlTransaction">トランザクションオブジェクト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データテーブルの実データ削除を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int WriteSessionMngProc(ref object paraPmTabSessionMngObj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PmTabSessionMngWork pmTabSessionMngWork = null;
            retMessage = string.Empty;

            //ArrayListの場合
            if (paraPmTabSessionMngObj is ArrayList)
            {
                ArrayList pmTabSessionMngWorkList = paraPmTabSessionMngObj as ArrayList;

                if (pmTabSessionMngWorkList.Count > 0)
                    pmTabSessionMngWork = pmTabSessionMngWorkList[0] as PmTabSessionMngWork;
            }

            //パラメータクラスの場合
            if (paraPmTabSessionMngObj is PmTabSessionMngWork)
            {
                pmTabSessionMngWork = paraPmTabSessionMngObj as PmTabSessionMngWork;
            }

            if (pmTabSessionMngWork == null)
            {
                return status;
            }

            status = WriteSessionMngProc(ref pmTabSessionMngWork, ref sqlConnection, ref sqlTransaction, out retMessage);
            return status;
        }

        /// <summary>
        /// PMTABセッション管理データの新規追加処理
        /// </summary>
        /// <param name="pmTabSeesionMngWork"> PMTABセッション管理データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="retMsg">メッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データ情報を追加します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        public int WriteSessionMngProc(ref PmTabSessionMngWork pmTabSeesionMngWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMsg = string.Empty;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            //●データベースチェック
            if (sqlConnection == null)
            {
                retMsg = "データベースへ接続出来ません。";
                return status;
            }

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                # region 排他用
                sqlCommand.CommandText = MkSelectSql(ref sqlCommand, pmTabSeesionMngWork);
                // クエリ実行時のタイムアウト時間を3600秒に設定する
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 抽出結果-値セット
                    PmTabSessionMngWork rsltWork = new PmTabSessionMngWork();
                    rsltWork.BusinessSessionId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSSESSIONIDRF")); // 業務セッションID
                    return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                }
                # endregion

                sqlText = new StringBuilder();
                # region [INSERT文]
                sqlText.AppendLine("INSERT INTO ");
                sqlText.AppendLine("PMTABSESSIONMNGRF ");
                sqlText.AppendLine("(");
                sqlText.AppendLine("CREATEDATETIMERF, ");
                sqlText.AppendLine("UPDATEDATETIMERF, ");
                sqlText.AppendLine("ENTERPRISECODERF, ");
                sqlText.AppendLine("FILEHEADERGUIDRF, ");
                sqlText.AppendLine("UPDEMPLOYEECODERF, ");
                sqlText.AppendLine("UPDASSEMBLYID1RF, ");
                sqlText.AppendLine("UPDASSEMBLYID2RF, ");
                sqlText.AppendLine("LOGICALDELETECODERF, ");
                sqlText.AppendLine("BUSINESSSESSIONIDRF, ");
                sqlText.AppendLine("ACPTANODRSTATUSRF, ");
                sqlText.AppendLine("SALESSLIPNUMRF ");
                sqlText.AppendLine(") ");
                sqlText.AppendLine("VALUES ");
                sqlText.AppendLine("(");
                sqlText.AppendLine("@CREATEDATETIME, ");
                sqlText.AppendLine("@UPDATEDATETIME, ");
                sqlText.AppendLine("@ENTERPRISECODE, ");
                sqlText.AppendLine("@FILEHEADERGUID, ");
                sqlText.AppendLine("@UPDEMPLOYEECODE, ");
                sqlText.AppendLine("@UPDASSEMBLYID1, ");
                sqlText.AppendLine("@UPDASSEMBLYID2, ");
                sqlText.AppendLine("@LOGICALDELETECODE, ");
                sqlText.AppendLine("@BUSINESSSESSIONID, ");
                sqlText.AppendLine("@ACPTANODRSTATUS, ");
                sqlText.AppendLine("@SALESSLIPNUM ");
                sqlText.AppendLine(")");

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // 登録ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)pmTabSeesionMngWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetInsertHeader(ref flhd, obj);
                if (myReader.IsClosed == false) myReader.Close();
                // Prameterオブジェクトの作成
                sqlCommand.Parameters.Clear();
                # region Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraBusinessSessionId = sqlCommand.Parameters.Add("@BUSINESSSESSIONID", SqlDbType.NChar);
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                SqlParameter paraSalesSlipNum = sqlCommand.Parameters.Add("@SALESSLIPNUM", SqlDbType.NChar);
                # endregion

                # region Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabSeesionMngWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pmTabSeesionMngWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pmTabSeesionMngWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pmTabSeesionMngWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pmTabSeesionMngWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pmTabSeesionMngWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pmTabSeesionMngWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pmTabSeesionMngWork.LogicalDeleteCode);
                paraBusinessSessionId.Value = SqlDataMediator.SqlSetString(pmTabSeesionMngWork.BusinessSessionId);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(pmTabSeesionMngWork.AcptAnOdrStatus);
                paraSalesSlipNum.Value = SqlDataMediator.SqlSetString(pmTabSeesionMngWork.SalesSlipNum);

                # endregion

                sqlCommand.ExecuteNonQuery();
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                retMsg = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "PmTabSessionMngDB.WriteSessionMngProc Exception=" + ex.Message, status);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 出力全項目データの検索クエリの構築
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <returns>クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 出力データの検索クエリの構築を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        private string MkSelectAllSql(ref SqlCommand sqlCommand, PmTabSessionMngWork cndtnWork)
        {
            // 検索クエリ文の構築
            StringBuilder sqlText = new StringBuilder();
            sqlText.AppendLine("SELECT ");
            sqlText.AppendLine("CREATEDATETIMERF "); 
            sqlText.AppendLine(",UPDATEDATETIMERF "); 
            sqlText.AppendLine(",ENTERPRISECODERF "); 
            sqlText.AppendLine(",FILEHEADERGUIDRF "); 
            sqlText.AppendLine(",UPDEMPLOYEECODERF "); 
            sqlText.AppendLine(",UPDASSEMBLYID1RF "); 
            sqlText.AppendLine(",UPDASSEMBLYID2RF "); 
            sqlText.AppendLine(",LOGICALDELETECODERF "); 
            sqlText.AppendLine(",BUSINESSSESSIONIDRF ");  // 業務セッションID
            sqlText.AppendLine(",ACPTANODRSTATUSRF ");  // 受注ステータス
            sqlText.AppendLine(",SALESSLIPNUMRF ");  // 伝票番号
            sqlText.AppendLine("FROM PMTABSESSIONMNGRF "); // PMTABセッション管理データ
            sqlText.AppendLine("WHERE ");
            sqlText.AppendLine("ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            sqlText.AppendLine("AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ");
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            if (!string.IsNullOrEmpty(cndtnWork.BusinessSessionId))
            {
                sqlText.AppendLine("AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID ");
                SqlParameter findParaSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
                findParaSessionId.Value = SqlDataMediator.SqlSetString(cndtnWork.BusinessSessionId);
            }

            if (cndtnWork.AcptAnOdrStatus != 0)
            {
                sqlText.AppendLine("AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS ");
                SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(cndtnWork.AcptAnOdrStatus);
            }
            if (!(string.IsNullOrEmpty(cndtnWork.SalesSlipNum) || cndtnWork.SalesSlipNum.Trim().Equals("000000000")))
            {
                sqlText.AppendLine("AND SALESSLIPNUMRF = @FINDSALESSLIPNUM ");
                SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
                findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(cndtnWork.SalesSlipNum);
            }
            return sqlText.ToString();
        }

        /// <summary>
        /// 排他用の検索クエリの構築
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <returns>クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 出力データの検索クエリの構築を行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        private string MkSelectSql(ref SqlCommand sqlCommand, PmTabSessionMngWork cndtnWork)
        {
            // 検索クエリ文の構築
            StringBuilder sqlText = new StringBuilder();
            sqlText.AppendLine("SELECT ");
            sqlText.AppendLine("BUSINESSSESSIONIDRF ");  // 業務セッションID
            sqlText.AppendLine("FROM PMTABSESSIONMNGRF "); // PMTABセッション管理データ
            sqlText.AppendLine("WHERE ");
            sqlText.AppendLine("ENTERPRISECODERF=@ENTERPRISECODE ");
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            sqlText.AppendLine("AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ");
            SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

            sqlText.AppendLine("AND BUSINESSSESSIONIDRF = @FINDBUSINESSSESSIONID ");
            SqlParameter findParaSessionId = sqlCommand.Parameters.Add("@FINDBUSINESSSESSIONID", SqlDbType.NChar);
            findParaSessionId.Value = SqlDataMediator.SqlSetString(cndtnWork.BusinessSessionId);

            sqlText.AppendLine("AND ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS ");
            SqlParameter findParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
            findParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(cndtnWork.AcptAnOdrStatus);

            sqlText.AppendLine("AND SALESSLIPNUMRF = @FINDSALESSLIPNUM ");
            SqlParameter findParaSalesSlipNum = sqlCommand.Parameters.Add("@FINDSALESSLIPNUM", SqlDbType.NChar);
            findParaSalesSlipNum.Value = SqlDataMediator.SqlSetString(cndtnWork.SalesSlipNum);

            return sqlText.ToString();
        }
        #endregion

        # region ◆ [コネクション生成処理] ◆
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        private SqlTransaction CreateTransactionData(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion ◆ [コネクション生成処理] ◆
    }
}

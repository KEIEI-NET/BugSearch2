//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 決済手形消込処理
// プログラム概要   : 決済手形消込処理DBリモートオブジェクト。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 決済手形消込処理リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 決済手形消込処理の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    [Serializable]
    public class SettlementBillDelDB : RemoteWithAppLockDB, ISettlementBillDelDB
    {
        # region ■ Constructor ■
        /// <summary>
        /// 決済手形消込処理処理READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 決済手形消込処理処理READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        public SettlementBillDelDB()
        {
        }
        #endregion


        #region ■ 決済手形消込処理処理 ■
        /// <summary>
        /// 決済手形消込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="processDate">処理日</param>
        /// <param name="prevTotalMonth">前回締処理月</param>
        /// <param name="billDiv">手形区分0:受取手形;1:支払手形</param>
        /// <param name="pieceDelete">削除件数</param>
        /// <param name="totalpiece">抽出件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 決済手形消込処理を行う。</br>
        /// <br>Programmer	: 張義</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        public int SettlementBillDelProc(string enterpriseCode, int processDate, int prevTotalMonth, int billDiv, out int pieceDelete, out int totalpiece)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pieceDelete = 0;
            totalpiece = 0;
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ShareCheckInfo info = new ShareCheckInfo();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();
                //●トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                #region 排他制御
                //システムロック(企業)
                info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                if (status != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT;
                    return status;
                }
                #endregion
                //手形区分0:受取手形
                if (billDiv == 0)
                {
                    status = SearchRcvDraftDataPieces(enterpriseCode, out totalpiece, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    //手形区分1:支払手形
                    status = SearchPayDraftDataPieces(enterpriseCode, out totalpiece, ref sqlConnection, ref sqlTransaction);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //手形区分0:受取手形
                    if (billDiv == 0)
                    {
                        status = DeleteRcvDraftData(enterpriseCode, processDate, prevTotalMonth, out pieceDelete, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        //手形区分1:支払手形
                        status = DeletePayDraftData(enterpriseCode, processDate, prevTotalMonth, out pieceDelete, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "InspectDateUpdDB.InspectDateUpdProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        //システムロック解除
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = st;
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }


        /// <summary>
        /// 指定された条件の受取手形データ情報を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="totalPieces">件数</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>  
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の受取手形データ情報を戻します。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>        
        private int SearchRcvDraftDataPieces(string enterpriseCode, out int totalPieces, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //変数の宣言
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            totalPieces = 0;

            //変数の初期化
            ArrayList dataList = new ArrayList();

            if (sqlConnection == null)
            {
                return status;
            }

            if (sqlTransaction == null)
            {
                return status;
            }

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, RCVDRAFTNORF FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //パラメータを設定する
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);


                //読み込む
                myReader = sqlCommand.ExecuteReader();
                //読み込めた場合
                while (myReader.Read())
                {
                    totalPieces++;
                    //戻り値を設定する
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SettlementBillDelDB.SearchRcvDraftData");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の支払手形データ情報を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="totalPieces">件数</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>  
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の支払手形データ情報を戻します。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>        
        private int SearchPayDraftDataPieces(string enterpriseCode, out int totalPieces, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //変数の宣言
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            totalPieces = 0;

            //変数の初期化
            ArrayList dataList = new ArrayList();

            if (sqlConnection == null)
            {
                return status;
            }

            if (sqlTransaction == null)
            {
                return status;
            }

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader myReader = null;

            try
            {
                //Selectコマンドの生成
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, PAYDRAFTNORF FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //パラメータを設定する
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);


                //読み込む
                myReader = sqlCommand.ExecuteReader();
                //読み込めた場合
                while (myReader.Read())
                {
                    totalPieces++;
                    //戻り値を設定する
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SettlementBillDelDB.SearchPayDraftData");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }


        /// <summary>
        /// 指定された条件の受取手形データを削除します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="processDate">処理日</param>
        /// <param name="prevTotalMonth">前回締処理月</param>
        /// <param name="pieceDelete">削除件数</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>  
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の受取手形データを削除します。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>        
        private int DeleteRcvDraftData(string enterpriseCode, int processDate, int prevTotalMonth, out int pieceDelete, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //変数の宣言
            int status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

            pieceDelete = 0;

            if (sqlConnection == null)
            {
                return status;
            }

            if (sqlTransaction == null)
            {
                return status;
            }

            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                //Deleteコマンドの生成
                sqlCommand = new SqlCommand("DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DRAFTKINDCDRF!=@FINDDRAFTKINDCD AND VALIDITYTERMRF<=@FINDVALIDITYTERM AND DEPOSITDATERF<=@FINDDEPOSITDATE", sqlConnection, sqlTransaction);
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findParaDraftKindCd = sqlCommand.Parameters.Add("@FINDDRAFTKINDCD", SqlDbType.Int);
                SqlParameter findParaValidityTerm = sqlCommand.Parameters.Add("@FINDVALIDITYTERM", SqlDbType.Int);
                SqlParameter findParaDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findParaDraftKindCd.Value = SqlDataMediator.SqlSetInt32(5);
                findParaValidityTerm.Value = SqlDataMediator.SqlSetInt32(processDate);
                findParaDepositDate.Value = SqlDataMediator.SqlSetInt32(prevTotalMonth);

                pieceDelete = sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SettlementBillDelDB.DeleteRcvDraftData");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            return status;
        }

        /// <summary>
        /// 指定された条件の支払手形データを削除します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="processDate">処理日</param>
        /// <param name="prevTotalMonth">前回締処理月</param>
        /// <param name="pieceDelete">削除件数</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>  
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件の支払手形データを削除します。</br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>        
        private int DeletePayDraftData(string enterpriseCode, int processDate, int prevTotalMonth, out int pieceDelete, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //変数の宣言
            int status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

            pieceDelete = 0;

            if (sqlConnection == null)
            {
                return status;
            }

            if (sqlTransaction == null)
            {
                return status;
            }

            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                //Deleteコマンドの生成
                sqlCommand = new SqlCommand("DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DRAFTKINDCDRF!=@FINDDRAFTKINDCD AND VALIDITYTERMRF<=@FINDVALIDITYTERM AND PAYMENTDATERF<=@FINDPAYMENTDATE", sqlConnection, sqlTransaction);
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findParaDraftKindCd = sqlCommand.Parameters.Add("@FINDDRAFTKINDCD", SqlDbType.Int);
                SqlParameter findParaValidityTerm = sqlCommand.Parameters.Add("@FINDVALIDITYTERM", SqlDbType.Int);
                SqlParameter findParaPaymentDate = sqlCommand.Parameters.Add("@FINDPAYMENTDATE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findParaDraftKindCd.Value = SqlDataMediator.SqlSetInt32(5);
                findParaValidityTerm.Value = SqlDataMediator.SqlSetInt32(processDate);
                findParaPaymentDate.Value = SqlDataMediator.SqlSetInt32(prevTotalMonth);

                pieceDelete = sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SettlementBillDelDB.DeletePayDraftData");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            return status;
        }
        #endregion
    }
}

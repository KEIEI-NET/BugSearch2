//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLコード変換マスタ取得設定マスタメンテ
// プログラム概要   : BLコード変換取得設定マスタメンテDBリモートオブジェクト   
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲 30745
// 作 成 日  2012/08/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// BLコード変換マスタ取得設定マスタメンテリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコード変換マスタ取得設定マスタメンテの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 吉岡 孝憲 30745</br>
    /// <br>Date       : 2012/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class BLGoodsCdChgUDB : RemoteDB, IBLGoodsCdChgUDB
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public BLGoodsCdChgUDB()
            : base("PMKHN09696D", "Broadleaf.Application.Remoting.ParamData.BLGoodsCdChgUWork", "BLGOODSCDCHGURF")
        {
        }

        #region [コネクション生成処理]

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (string.IsNullOrEmpty(connectionText))
            {
                return null;
            }

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }

        #endregion

        #region [トランザクション生成処理]

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <returns>SqlTransaction</returns>
        /// <remarks>
        /// <br>Note       : SqlTransaction生成処理</br>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        #endregion  //トランザクション生成処理

        #region IBLGoodsCdChgUDB メンバ

        /// <summary>
        /// BLコード変換取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="blCodeChangeObj">BLコード変換取得設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Read(ref object blCodeChangeObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                BLGoodsCdChgUWork blCodeChangeWork = blCodeChangeObj as BLGoodsCdChgUWork;

                status = ReadProc(ref blCodeChangeWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Read");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// BLコード変換取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="blCodeChangeWork">BLコード変換取得設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int ReadProc(ref BLGoodsCdChgUWork blCodeChangeWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                sqlText.Append("SELECT ").Append(Environment.NewLine);
                sqlText.Append("  CREATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("  , ENTERPRISECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , FILEHEADERGUIDRF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                sqlText.Append("  , LOGICALDELETECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , SECTIONCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , CUSTOMERCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , PMBLGOODSCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , PMBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                sqlText.Append("  , SFBLGOODSCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , SFBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                sqlText.Append("  , BLGOODSFULLNAMERF ").Append(Environment.NewLine);
                sqlText.Append("  , BLGOODSHALFNAMERF  ").Append(Environment.NewLine);
                sqlText.Append("FROM ").Append(Environment.NewLine);
                sqlText.Append("  BLGOODSCDCHGURF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaPMBlGoodsCode = sqlCommand.Parameters.Add("@FINDPMBLGOODSCODE", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToBLGoodsCdChgUWorkFromReader(ref myReader, ref blCodeChangeWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex);
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
        /// BLコード変換取得設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Delete(ref object blCodeChangeList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // パラメータのキャスト
                ArrayList paraList = blCodeChangeList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.DeleteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Delete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// BLコード変換取得設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>    
        public int DeleteProc(ref ArrayList blCodeChangeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (blCodeChangeList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < blCodeChangeList.Count; i++)
                    {
                        BLGoodsCdChgUWork blCodeChangeWork = blCodeChangeList[i] as BLGoodsCdChgUWork;

                        # region [SELECT文]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM BLGOODSCDCHGURF").Append(Environment.NewLine);
                        sqlText.Append("WHERE ").Append(Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPMBlGoodsCode = sqlCommand.Parameters.Add("@FINDPMBLGOODSCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                        findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != blCodeChangeWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = new StringBuilder();
                            sqlText.Append("DELETE  ").Append(Environment.NewLine);
                            sqlText.Append("FROM ").Append(Environment.NewLine);
                            sqlText.Append("  BLGOODSCDCHGURF  ").Append(Environment.NewLine);
                            sqlText.Append("WHERE ").Append(Environment.NewLine);
                            sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                            findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }
                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Delete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// BLコード変換取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <param name="blCodeChangeObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Search(ref object blCodeChangeList, BLGoodsCdChgUWork blCodeChangeObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            blCodeChangeList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                BLGoodsCdChgUWork blCodeChangeWork = blCodeChangeObj as BLGoodsCdChgUWork;
                status = SearchProc(ref blCodeChangeList, blCodeChangeWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// BLコード変換取得設定マスタメンテ検索処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <param name="blCodeChangeWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>  
        public int SearchProc(ref object blCodeChangeList, BLGoodsCdChgUWork blCodeChangeWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList blCodeChangeArray = blCodeChangeList as ArrayList;

            if (blCodeChangeArray == null)
            {
                blCodeChangeArray = new ArrayList();
            }
            try
            {
                StringBuilder sqlText = new StringBuilder();
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                # region [SELECT文]
                                sqlText.Append("SELECT ").Append(Environment.NewLine);
                sqlText.Append("  CREATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDATEDATETIMERF ").Append(Environment.NewLine);
                sqlText.Append("  , ENTERPRISECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , FILEHEADERGUIDRF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                sqlText.Append("  , UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                sqlText.Append("  , LOGICALDELETECODERF ").Append(Environment.NewLine);
                sqlText.Append("  , SECTIONCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , CUSTOMERCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , PMBLGOODSCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , PMBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                sqlText.Append("  , SFBLGOODSCODERF ").Append(Environment.NewLine);
                sqlText.Append("  , SFBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                sqlText.Append("  , BLGOODSFULLNAMERF ").Append(Environment.NewLine);
                sqlText.Append("  , BLGOODSHALFNAMERF  ").Append(Environment.NewLine);
                sqlText.Append("FROM ").Append(Environment.NewLine);
                sqlText.Append("  BLGOODSCDCHGURF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                sqlText.Append("ORDER BY ").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF, SECTIONCODERF, CUSTOMERCODERF, PMBLGOODSCODERF ").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);

                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                myReader = sqlCommand.ExecuteReader();
                status = CopyToListForSearch(ref myReader, out blCodeChangeArray);
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
            blCodeChangeList = blCodeChangeArray;
            return status;

        }

        /// <summary>
        /// BLコード変換取得設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int Write(ref object blCodeChangeList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // パラメータのキャスト
                ArrayList paraList = blCodeChangeList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                // write実行
                status = this.WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.Write");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// BLコード変換取得設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int WriteProc(ref ArrayList blCodeChangeList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (blCodeChangeList != null)
                {
                    StringBuilder sqlText = new StringBuilder();
                    sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);

                    for (int i = 0; i < blCodeChangeList.Count; i++)
                    {
                        BLGoodsCdChgUWork blCodeChangeWork = blCodeChangeList[i] as BLGoodsCdChgUWork;

                        # region [SELECT文]
                        sqlText = new StringBuilder();
                        sqlText.Append("SELECT UPDATEDATETIMERF").Append(Environment.NewLine);
                        sqlText.Append(" FROM BLGOODSCDCHGURF").Append(Environment.NewLine);
                        sqlText.Append("WHERE ").Append(Environment.NewLine);
                        sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                        sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);

                        sqlCommand.CommandText = sqlText.ToString();
                        # endregion

                        // Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPMBlGoodsCode = sqlCommand.Parameters.Add("@FINDPMBLGOODSCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                        findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != blCodeChangeWork.UpdateDateTime)
                            {
                                if (blCodeChangeWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // 新規登録で該当データ有りの場合には重複
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // 既存データで更新日時違いの場合には排他
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE文]
                            sqlText = new StringBuilder();
                            sqlText.Append("UPDATE BLGOODSCDCHGURF  ").Append(Environment.NewLine);
                            sqlText.Append("SET ").Append(Environment.NewLine);
                            sqlText.Append("  CREATEDATETIMERF = @CREATEDATETIME ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDATEDATETIMERF = @UPDATEDATETIME ").Append(Environment.NewLine);
                            sqlText.Append("  , ENTERPRISECODERF = @ENTERPRISECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , FILEHEADERGUIDRF = @FILEHEADERGUID ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDEMPLOYEECODERF = @UPDEMPLOYEECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDASSEMBLYID1RF = @UPDASSEMBLYID1 ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDASSEMBLYID2RF = @UPDASSEMBLYID2 ").Append(Environment.NewLine);
                            sqlText.Append("  , LOGICALDELETECODERF = @LOGICALDELETECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , SECTIONCODERF = @SECTIONCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , CUSTOMERCODERF = @CUSTOMERCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , PMBLGOODSCODERF = @PMBLGOODSCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , PMBLGOODSCODEDERIVNORF = @PMBLGOODSCODEDERIVNO ").Append(Environment.NewLine);
                            sqlText.Append("  , SFBLGOODSCODERF = @SFBLGOODSCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , SFBLGOODSCODEDERIVNORF = @SFBLGOODSCODEDERIVNO ").Append(Environment.NewLine);
                            sqlText.Append("  , BLGOODSFULLNAMERF = @BLGOODSFULLNAME ").Append(Environment.NewLine);
                            sqlText.Append("  , BLGOODSHALFNAMERF = @BLGOODSHALFNAME ").Append(Environment.NewLine);
                            sqlText.Append("WHERE ").Append(Environment.NewLine);
                            sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                            sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);
                            sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.CustomerCode);
                            findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWork.PMBLGoodsCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)blCodeChangeWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (blCodeChangeWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = new StringBuilder();
                            sqlText.Append("INSERT  ").Append(Environment.NewLine);
                            sqlText.Append("INTO BLGOODSCDCHGURF(  ").Append(Environment.NewLine);
                            sqlText.Append("  CREATEDATETIMERF ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDATEDATETIMERF ").Append(Environment.NewLine);
                            sqlText.Append("  , ENTERPRISECODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , FILEHEADERGUIDRF ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDEMPLOYEECODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDASSEMBLYID1RF ").Append(Environment.NewLine);
                            sqlText.Append("  , UPDASSEMBLYID2RF ").Append(Environment.NewLine);
                            sqlText.Append("  , LOGICALDELETECODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , SECTIONCODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , CUSTOMERCODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , PMBLGOODSCODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , PMBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                            sqlText.Append("  , SFBLGOODSCODERF ").Append(Environment.NewLine);
                            sqlText.Append("  , SFBLGOODSCODEDERIVNORF ").Append(Environment.NewLine);
                            sqlText.Append("  , BLGOODSFULLNAMERF ").Append(Environment.NewLine);
                            sqlText.Append("  , BLGOODSHALFNAMERF ").Append(Environment.NewLine);
                            sqlText.Append(")  ").Append(Environment.NewLine);
                            sqlText.Append("VALUES (  ").Append(Environment.NewLine);
                            sqlText.Append("  @CREATEDATETIME ").Append(Environment.NewLine);
                            sqlText.Append("  , @UPDATEDATETIME ").Append(Environment.NewLine);
                            sqlText.Append("  , @ENTERPRISECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @FILEHEADERGUID ").Append(Environment.NewLine);
                            sqlText.Append("  , @UPDEMPLOYEECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @UPDASSEMBLYID1 ").Append(Environment.NewLine);
                            sqlText.Append("  , @UPDASSEMBLYID2 ").Append(Environment.NewLine);
                            sqlText.Append("  , @LOGICALDELETECODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @SECTIONCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @CUSTOMERCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @PMBLGOODSCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @PMBLGOODSCODEDERIVNO ").Append(Environment.NewLine);
                            sqlText.Append("  , @SFBLGOODSCODE ").Append(Environment.NewLine);
                            sqlText.Append("  , @SFBLGOODSCODEDERIVNO ").Append(Environment.NewLine);
                            sqlText.Append("  , @BLGOODSFULLNAME ").Append(Environment.NewLine);
                            sqlText.Append("  , @BLGOODSHALFNAME ").Append(Environment.NewLine);
                            sqlText.Append(")  ").Append(Environment.NewLine); sqlCommand.CommandText = sqlText.ToString();
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)blCodeChangeWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);

                        SqlParameter paraPMBLGoodsCode = sqlCommand.Parameters.Add("@PMBLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraPMBLGoodsCodeDerivNo = sqlCommand.Parameters.Add("@PMBLGOODSCODEDERIVNO", SqlDbType.Int);
                        SqlParameter paraSFBLGoodsCode = sqlCommand.Parameters.Add("@SFBLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraSFBLGoodsCodeDerivNo = sqlCommand.Parameters.Add("@SFBLGOODSCODEDERIVNO", SqlDbType.Int);
                        SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NChar);
                        SqlParameter paraBLGoodsHalfName = sqlCommand.Parameters.Add("@BLGOODSHALFNAME", SqlDbType.NChar);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blCodeChangeWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blCodeChangeWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(blCodeChangeWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.SectionCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.CustomerCode);

                        paraPMBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.PMBLGoodsCode);
                        paraPMBLGoodsCodeDerivNo.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.PMBLGoodsCodeDerivNo);
                        paraSFBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.SFBLGoodsCode);
                        paraSFBLGoodsCodeDerivNo.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWork.SFBLGoodsCodeDerivNo);
                        paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.BLGoodsFullName);
                        paraBLGoodsHalfName.Value = SqlDataMediator.SqlSetString(blCodeChangeWork.BLGoodsHalfName);

                        # endregion

                        //タイムアウト時間の設定
                        sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

                        sqlCommand.ExecuteNonQuery();
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.LogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        /// BLコード変換取得設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int LogicalDelete(ref object blCodeChangeList)
        {
            return this.LogicalDelete(ref blCodeChangeList, 0);
        }

        /// <summary>
        /// UOE 自社設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="blCodeChangeList">論理削除を操作するUOE 自社設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLGoodsCdChgUWork に格納されているUOE 自社設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer :吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        public int LogicalDelete(ref object blCodeChangeList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                status = this.LogicalDeleteProc(ref blCodeChangeList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "BLGoodsCdChgUDB.LogicalDelete");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // コミット
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ロールバック
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// UOE 自社設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="blCodeChangeList">論理削除を操作するUOE 自社設定マスタ情報を格納する</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLGoodsCdChgUWork に格納されているUOE 自社設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer :吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        private int LogicalDeleteProc(ref object blCodeChangeList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList blCodeChangeArrList = null;
            ArrayList blCodeChangeArrListNew = null;
            try
            {

                if (blCodeChangeList != null)
                {
                    blCodeChangeArrList = blCodeChangeList as ArrayList;
                }
                if (blCodeChangeArrList == null || blCodeChangeArrList.Count == 0)
                {
                    return status;

                }
                blCodeChangeArrListNew = new ArrayList();

                for (int i = 0; i < blCodeChangeArrList.Count; i++)
                {
                    BLGoodsCdChgUWork blCodeChangeWorkEach = blCodeChangeArrList[i] as BLGoodsCdChgUWork;
                    status = LogicalDeleteProcEach(ref blCodeChangeWorkEach, procMode, ref  sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    blCodeChangeArrListNew.Add(blCodeChangeWorkEach);

                    blCodeChangeList = blCodeChangeArrListNew as object;

                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "BLGoodsCdChgUWorkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLGoodsCdChgUWorkDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // myReaderの釈放
                if (myReader != null && !myReader.IsClosed)
                {
                    myReader.Close();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// UOE 自社設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="blCodeChangeWorkEach">論理削除を操作するUOE 自社設定マスタ情報を格納する</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">トランザクション情報</param>
        /// <param name="myReader">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BLGoodsCdChgUWork に格納されているUOE 自社設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer :吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        private int LogicalDeleteProcEach(ref BLGoodsCdChgUWork blCodeChangeWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StringBuilder sqlText = new StringBuilder();

            sqlText.Append("SELECT").Append(Environment.NewLine);
            sqlText.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlText.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlText.Append("FROM").Append(Environment.NewLine);
            sqlText.Append("  BLGOODSCDCHGURF").Append(Environment.NewLine);
            sqlText.Append("WHERE ").Append(Environment.NewLine);
            sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
            sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
            sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
            sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection, sqlTransaction);


            // Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
            SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
            SqlParameter findParaPMBlGoodsCode = sqlCommand.Parameters.Add("@FINDPMBLGOODSCODE", SqlDbType.Int);

            // Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.EnterpriseCode);
            findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.SectionCode);
            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWorkEach.CustomerCode);
            findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWorkEach.PMBLGoodsCode);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                if (_updateDateTime != blCodeChangeWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }

                // 現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                # region [UPDATE文]
                sqlText = new StringBuilder();
                sqlText.Append("UPDATE").Append(Environment.NewLine);
                sqlText.Append("  BLGOODSCDCHGURF").Append(Environment.NewLine);
                sqlText.Append("SET").Append(Environment.NewLine);
                sqlText.Append("  UPDATEDATETIMERF = @UPDATEDATETIME").Append(Environment.NewLine);
                sqlText.Append(" ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE").Append(Environment.NewLine);
                sqlText.Append(" ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1").Append(Environment.NewLine);
                sqlText.Append(" ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2").Append(Environment.NewLine);
                sqlText.Append(" ,LOGICALDELETECODERF = @LOGICALDELETECODE").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                sqlText.Append("  ENTERPRISECODERF = @FINDENTERPRISECODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND SECTIONCODERF = @FINDSECTIONCODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND CUSTOMERCODERF = @FINDCUSTOMERCODE  ").Append(Environment.NewLine);
                sqlText.Append("  AND PMBLGOODSCODERF = @FINDPMBLGOODSCODE ").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlText.ToString();
                # endregion

                // KEYコマンドを再設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.SectionCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWorkEach.CustomerCode);
                findParaPMBlGoodsCode.Value = SqlDataMediator.SqlSetInt(blCodeChangeWorkEach.PMBLGoodsCode);


                // 更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)blCodeChangeWorkEach;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
            }
            else
            {
                // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                return status;
            }

            if (!myReader.IsClosed)
            {
                myReader.Close();
            }
            //論理削除モードの場合
            if (procMode == 0)
            {

                if (logicalDelCd == 0) blCodeChangeWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット

            }
            else
            {
                if (logicalDelCd == 1) blCodeChangeWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除

            }


            // Parameterオブジェクトの作成(更新用)
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

            // Parameterオブジェクトへ値設定(更新用)
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(blCodeChangeWorkEach.UpdateDateTime);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(blCodeChangeWorkEach.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(blCodeChangeWorkEach.LogicalDeleteCode);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            return status;

        }

        /// <summary>
        /// BLコード変換取得設定マスタメンテ復活処理
        /// </summary>
        /// <param name="blCodeChangeList">BLコード変換取得設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object blCodeChangeList)
        {
            return this.LogicalDelete(ref blCodeChangeList, 1);
        }

        #endregion

        #region 内部処理

        # region [クラス格納処理]

        /// <summary>
        /// クラス格納処理 Reader → BLGoodsCdChgUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLGoodsCdChgUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer :吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private BLGoodsCdChgUWork CopyToBLGoodsCdChgUWorkFromReader(ref SqlDataReader myReader)
        {
            BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();

            this.CopyToBLGoodsCdChgUWorkFromReader(ref myReader, ref blCodeChangeWork);

            return blCodeChangeWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → BLGoodsCdChgUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="blCodeChangeWork">BLGoodsCdChgUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer :吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private void CopyToBLGoodsCdChgUWorkFromReader(ref SqlDataReader myReader, ref BLGoodsCdChgUWork blCodeChangeWork)
        {
            if (myReader != null && blCodeChangeWork != null)
            {
                # region クラスへ格納


                blCodeChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                blCodeChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                blCodeChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                blCodeChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                blCodeChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                blCodeChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                blCodeChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                blCodeChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                blCodeChangeWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                blCodeChangeWork.PMBLGoodsCode = SqlDataMediator.SqlGetInt(myReader, myReader.GetOrdinal("PMBLGOODSCODERF"));
                blCodeChangeWork.PMBLGoodsCodeDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PMBLGOODSCODEDERIVNORF"));
                blCodeChangeWork.SFBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SFBLGOODSCODERF"));
                blCodeChangeWork.SFBLGoodsCodeDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SFBLGOODSCODEDERIVNORF"));
                blCodeChangeWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                blCodeChangeWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                # endregion
            }
        }

        /// <summary>
        /// クラス格納処理 Reader → BLGoodsCdChgUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="blCodeChangeWork">BLGoodsCdChgUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer :吉岡 孝憲 30745</br>
        /// <br>Date       : 2012/08/01</br>
        /// </remarks>
        private int CopyToListForSearch(ref SqlDataReader myReader, out ArrayList blCodeChangeWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            blCodeChangeWorkList = new ArrayList();
            //作成日時
            int colIndex_CreateDateTime = 0;
            //更新日時
            int colIndex_UpdateDateTime = 0;
            //企業コード
            int colIndex_EnterpriseCode = 0;
            //GUID
            int colIndex_FileHeaderGuid = 0;
            //更新従業員コード
            int colIndex_UpdEmployeeCode = 0;
            //更新アセンブリID1
            int colIndex_UpdAssemblyId1 = 0;
            //更新アセンブリID2
            int colIndex_UpdAssemblyId2 = 0;
            //論理削除区分
            int colIndex_LogicalDeleteCode = 0;
            //拠点コード
            int colIndex_SectionCode = 0;
            //得意先コード
            int colIndex_CustomerCode = 0;

            //PM側BL商品コード
            int colIndex_PMBLGoodsCode = 0;
            //PM側BL商品コード枝番
            int colIndex_PMBLGoodsCodeDerivNo = 0;
            //SF側BL商品コード
            int colIndex_SFBLGoodsCode = 0;
            //SF側BL商品コード枝番
            int colIndex_SFBLGoodsCodeDerivNo = 0;
            //BL商品コード名称（全角）
            int colIndex_BLGoodsFullName = 0;
            //BL商品コード名称（半角）
            int colIndex_BLGoodsHalfName = 0;

            if (myReader.HasRows)
            {
                //作成日時
                colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                //更新日時
                colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                //企業コード
                colIndex_EnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
                //GUID
                colIndex_FileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
                //更新従業員コード
                colIndex_UpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
                //更新アセンブリID1
                colIndex_UpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
                //更新アセンブリID2
                colIndex_UpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
                //論理削除区分
                colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                //拠点コード
                colIndex_SectionCode = myReader.GetOrdinal("SECTIONCODERF");
                //得意先コード
                colIndex_CustomerCode = myReader.GetOrdinal("CUSTOMERCODERF");

                //PM側BL商品コード
                colIndex_PMBLGoodsCode = myReader.GetOrdinal("PMBLGOODSCODERF");
                //PM側BL商品コード枝番
                colIndex_PMBLGoodsCodeDerivNo = myReader.GetOrdinal("PMBLGOODSCODEDERIVNORF");
                //SF側BL商品コード
                colIndex_SFBLGoodsCode = myReader.GetOrdinal("SFBLGOODSCODERF");
                //SF側BL商品コード枝番
                colIndex_SFBLGoodsCodeDerivNo = myReader.GetOrdinal("SFBLGOODSCODEDERIVNORF");
                //BL商品コード名称（全角）
                colIndex_BLGoodsFullName = myReader.GetOrdinal("BLGOODSFULLNAMERF");
                //BL商品コード名称（半角）
                colIndex_BLGoodsHalfName = myReader.GetOrdinal("BLGOODSHALFNAMERF");
            }
            while (myReader.Read())
            {
                BLGoodsCdChgUWork blCodeChangeWork = new BLGoodsCdChgUWork();
                //作成日時
                blCodeChangeWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //更新日時
                blCodeChangeWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //企業コード
                blCodeChangeWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, colIndex_EnterpriseCode);
                //GUID
                blCodeChangeWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, colIndex_FileHeaderGuid);
                //更新従業員コード
                blCodeChangeWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, colIndex_UpdEmployeeCode);
                //更新アセンブリID1
                blCodeChangeWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId1);
                //更新アセンブリID2
                blCodeChangeWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, colIndex_UpdAssemblyId2);
                //論理削除区分
                blCodeChangeWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //拠点コード
                blCodeChangeWork.SectionCode = SqlDataMediator.SqlGetString(myReader, colIndex_SectionCode);
                //得意先コード
                blCodeChangeWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CustomerCode);

                //PM側BL商品コード
                blCodeChangeWork.PMBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_PMBLGoodsCode);
                //PM側BL商品コード枝番
                blCodeChangeWork.PMBLGoodsCodeDerivNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_PMBLGoodsCodeDerivNo);
                //SF側BL商品コード
                blCodeChangeWork.SFBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_SFBLGoodsCode);
                //SF側BL商品コード枝番
                blCodeChangeWork.SFBLGoodsCodeDerivNo = SqlDataMediator.SqlGetInt32(myReader, colIndex_SFBLGoodsCodeDerivNo);
                //BL商品コード名称（全角）
                blCodeChangeWork.BLGoodsFullName= SqlDataMediator.SqlGetString(myReader, colIndex_BLGoodsFullName);
                //BL商品コード名称（半角）
                blCodeChangeWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, colIndex_BLGoodsHalfName);
                
                blCodeChangeWorkList.Add(blCodeChangeWork);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            if (blCodeChangeWorkList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }
        # endregion

        #endregion

    }
}

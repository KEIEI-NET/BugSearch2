//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCCキャンペーン設定マスタメンテ
// プログラム概要   : PCCキャンペーン設定マスタメンテDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/11/07  修正内容 : 2012/12/12配信 SCM障害№10422対応 問合せ先企業・拠点未指定での取得を可能に
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 孝憲
// 作 成 日  2012/11/27  修正内容 : 2012/12/12配信 システムテスト障害№83対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
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
    /// PCCキャンペーン設定マスタメンテリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCCキャンペーン設定マスタメンテの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date       : 2011.08.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PccCpMsgStDB : RemoteDB, IPccCpMsgStDB
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public PccCpMsgStDB() : base("PMPCC09066D", "Broadleaf.Application.Remoting.ParamData.PccCpMsgStWork", "PCCCPMSGSTRF")
        {
        }

        #region [コネクション生成処理]

        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_SCM_UserDB);
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
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }

        #endregion  //トランザクション生成処理

        #region IPccCpMsgStDB メンバ

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Write(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList)
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
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                //PCCキャンペーンメッセージ設定マスタ
                status = WriteMsgProc(ref pccCpMsgStWorkList, ref sqlConnection,ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //PCCキャンペーン対象設定マスタ
                    status = WriteTgtProc(ref pccCpTgtStWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //PCCキャンペーン品目設定マスタ
                        status = WriteItmProc(ref pccCpItmStWorkList, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Write");
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
        /// PCCキャンペーンメッセージ設定マスタンテ登録、更新処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージ設定マスタ設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteMsgProc(ref object pccCpMsgStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            ArrayList pccCpMsgStWorkArrList = null;
            ArrayList pccCpMsgStWorkArrListNew = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccCpMsgStWorkList != null)
                {
                    pccCpMsgStWorkArrList = pccCpMsgStWorkList as ArrayList;
                }
                if (pccCpMsgStWorkArrList == null || pccCpMsgStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpMsgStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCpMsgStWorkArrList.Count; i++)
                {
                    PccCpMsgStWork pccCpMsgStWorkEach = pccCpMsgStWorkArrList[i] as PccCpMsgStWork;
                    if (pccCpMsgStWorkEach.UpdateFlag == 2)
                    {
                        status = this.DeleteProcMsgEach(ref pccCpMsgStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand,ref myReader);
                    }
                    else
                    {
                        status = WriteMsgProcEach(ref pccCpMsgStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccCpMsgStWorkArrListNew.Add(pccCpMsgStWorkEach);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpMsgStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Write");
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

            pccCpMsgStWorkList = pccCpMsgStWorkArrListNew as Object;

            return status;
        }

         /// <summary>
        /// PCCキャンペーンメッセージ設定マスタンテ登録、更新処理
        /// </summary>
        /// <param name="pccCpMsgStWorkEach">PCCキャンペーンメッセージ設定マスタグループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteMsgProcEach(ref PccCpMsgStWork pccCpMsgStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand,ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;;
            //Selectコマンドの生成
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPMSGSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccCpMsgStWorkEach.UpdateDateTime)
                {
                    //新規登録で該当データ有りの場合には重複
                    if (pccCpMsgStWorkEach.UpdateDateTime == DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    }
                    //既存データで更新日時違いの場合には排他
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCCPMSGSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNCODERF=@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , APPLYSTADATERF=@APPLYSTADATE").Append(Environment.NewLine);
                sqlTxt.Append(" , APPLYENDDATERF=@APPLYENDDATE").Append(Environment.NewLine);
                sqlTxt.Append(" , PCCMSGDOCCNTSRF=@PCCMSGDOCCNTS").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNNAMERF=@CAMPAIGNNAME").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNOBJDIVRF=@CAMPAIGNOBJDIV").Append(Environment.NewLine);

                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //KEYコマンドを再設定
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
                pccCpMsgStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                if (pccCpMsgStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //新規作成時のSQL文を生成
                sqlTxt.Append("INSERT INTO PCCCPMSGSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,APPLYSTADATERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,APPLYENDDATERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,PCCMSGDOCCNTSRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNOBJDIVRF").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@APPLYSTADATE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@APPLYENDDATE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@PCCMSGDOCCNTS").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNNAME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNOBJDIV").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //登録ヘッダ情報を設定
                pccCpMsgStWorkEach.UpdateDateTime = DateTime.Now;
                pccCpMsgStWorkEach.CreateDateTime = DateTime.Now;
                pccCpMsgStWorkEach.LogicalDeleteCode = 0;
            }

            if (!myReader.IsClosed) myReader.Close();
            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqotherEpcd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqotherSeccd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
            SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            SqlParameter paraPccMsgDocCnts = sqlCommand.Parameters.Add("@PCCMSGDOCCNTS", SqlDbType.NVarChar);
            SqlParameter paraCampaignName = sqlCommand.Parameters.Add("@CAMPAIGNNAME", SqlDbType.NVarChar);
            SqlParameter paraCampaignObjDiv = sqlCommand.Parameters.Add("@CAMPAIGNOBJDIV", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpMsgStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpMsgStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.LogicalDeleteCode);
            paraInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
            paraInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            paraApplyStaDate.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.ApplyStaDate);
            paraApplyEndDate.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.ApplyEndDate);
            paraPccMsgDocCnts.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.PccMsgDocCnts);
            paraCampaignName.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.CampaignName);
            paraCampaignObjDiv.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignObjDiv);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        ///PCCキャンペーン対象設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteTgtProc(ref object pccCpTgtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            ArrayList pccCpTgtStWorkListArrList = null;
            ArrayList pccCpTgtStWorkListArrListNew = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccCpTgtStWorkList != null)
                {
                    pccCpTgtStWorkListArrList = pccCpTgtStWorkList as ArrayList;
                }
                if (pccCpTgtStWorkListArrList == null || pccCpTgtStWorkListArrList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                pccCpTgtStWorkListArrListNew = new ArrayList();

                for (int i = 0; i < pccCpTgtStWorkListArrList.Count; i++)
                {
                    PccCpTgtStWork pccCpTgtStWorkEach = pccCpTgtStWorkListArrList[i] as PccCpTgtStWork;
                    if (pccCpTgtStWorkEach.UpdateFlag == 2)
                    {
                        status = this.DeleteProcTgtEach(ref pccCpTgtStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    }
                    else
                    {
                        status = WriteTgtProcEach(ref pccCpTgtStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccCpTgtStWorkListArrListNew.Add(pccCpTgtStWorkEach);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.Write");
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

            pccCpTgtStWorkList = pccCpTgtStWorkListArrListNew as Object;

            return status;
        }

        /// <summary>
        /// PCCキャンペーン対象設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCpTgtStWorkEach">PCCキャンペーン対象設定マスタグループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteTgtProcEach(ref PccCpTgtStWork pccCpTgtStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand,ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Selectコマンドの生成
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPTGTSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqoriginalEpcd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqoriginaLSeccd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
            findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccCpTgtStWorkEach.UpdateDateTime)
                {
                    //新規登録で該当データ有りの場合には重複
                    if (pccCpTgtStWorkEach.UpdateDateTime == DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    }
                    //既存データで更新日時違いの場合には排他
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCCPTGTSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALEPCDRF = @INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQORIGINALSECCDRF = @INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHEREPCDRF = @INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF = @INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNCODERF = @CAMPAIGNCODE").Append(Environment.NewLine);

                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //KEYコマンドを再設定
                findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
                findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
                pccCpTgtStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                if (pccCpTgtStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //新規作成時のSQL文を生成
                sqlTxt.Append("INSERT INTO PCCCPTGTSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //登録ヘッダ情報を設定
                pccCpTgtStWorkEach.UpdateDateTime = DateTime.Now;
                pccCpTgtStWorkEach.CreateDateTime = DateTime.Now;
                pccCpTgtStWorkEach.LogicalDeleteCode = 0;
            }

            if (!myReader.IsClosed) myReader.Close();
            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqoriginalEpcd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter paraInqoriginalSeccd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter paraInqotherEpcd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqotherSeccd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpTgtStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpTgtStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.LogicalDeleteCode);
            paraInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
            paraInqoriginalSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
            paraInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
            paraInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCCキャンペーン品目設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private  int WriteItmProc(ref object pccCpItmStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            ArrayList pccCpItmStWorkListArrList = null;
            ArrayList pccCpItmStWorkListArrListNew = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (pccCpItmStWorkList != null)
                {
                    pccCpItmStWorkListArrList = pccCpItmStWorkList as ArrayList;
                }
                if (pccCpItmStWorkListArrList == null || pccCpItmStWorkListArrList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                pccCpItmStWorkListArrListNew = new ArrayList();

                for (int i = 0; i < pccCpItmStWorkListArrList.Count; i++)
                {
                    PccCpItmStWork pccCpItmStWorkEach = pccCpItmStWorkListArrList[i] as PccCpItmStWork;
                    if (pccCpItmStWorkEach.UpdateFlag == 2)
                    {
                        status = this.DeleteProcItmEach(ref pccCpItmStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    }
                    else
                    {
                        status = WriteItmProcEach(ref pccCpItmStWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                        pccCpItmStWorkListArrListNew.Add(pccCpItmStWorkEach);

                    } if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpItmStDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpItmStDB.Write");
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

            pccCpItmStWorkList = pccCpItmStWorkListArrListNew as Object;

            return status;
        }

        /// <summary>
        /// PCCキャンペーン品目設定マスタンテ登録、更新処理
        /// </summary>
        /// <param name="pccCpItmStWorkEach">PCCキャンペーン品目設定マスタグループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int WriteItmProcEach(ref PccCpItmStWork pccCpItmStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand,ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Selectコマンドの生成
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPITMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            SqlParameter findParaCampStDiv = sqlCommand.Parameters.Add("@FINDCAMPSTDIVRF", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
            findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccCpItmStWorkEach.UpdateDateTime)
                {
                    //新規登録で該当データ有りの場合には重複
                    if (pccCpItmStWorkEach.UpdateDateTime == DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    }
                    //既存データで更新日時違いの場合には排他
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    }
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("UPDATE PCCCPITMSTRF SET  CREATEDATETIMERF=@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);  
                sqlTxt.Append(" , INQOTHEREPCDRF=@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append(" , INQOTHERSECCDRF=@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPAIGNCODERF=@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , CAMPSTDIVRF=@CAMPSTDIV").Append(Environment.NewLine);
                sqlTxt.Append(" , BLGOODSCODERF=@BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append(" , GOODSNORF=@GOODSNO").Append(Environment.NewLine);
                sqlTxt.Append(" , GOODSMAKERCDRF=@GOODSMAKERCD").Append(Environment.NewLine);
                sqlTxt.Append(" , GOODSNAMERF=@GOODSNAME").Append(Environment.NewLine);
                sqlTxt.Append(" , GOODSNAMEKANARF=@GOODSNAMEKANA").Append(Environment.NewLine);
                sqlTxt.Append(" , ITEMQTYRF=@ITEMQTY").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //KEYコマンドを再設定
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
                findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
                pccCpItmStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                if (pccCpItmStWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //新規作成時のSQL文を生成
                sqlTxt.Append("INSERT INTO PCCCPITMSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" (CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,CAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,GOODSNORF").Append(Environment.NewLine);
                sqlTxt.Append("    ,GOODSMAKERCDRF").Append(Environment.NewLine);
                sqlTxt.Append("    ,GOODSNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("    ,GOODSNAMEKANARF").Append(Environment.NewLine);
                sqlTxt.Append("    ,ITEMQTYRF").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlTxt.Append(" VALUES").Append(Environment.NewLine);
                sqlTxt.Append(" (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@INQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@CAMPSTDIV").Append(Environment.NewLine);
                sqlTxt.Append("    ,@BLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("    ,@GOODSNO").Append(Environment.NewLine);
                sqlTxt.Append("    ,@GOODSMAKERCD").Append(Environment.NewLine);
                sqlTxt.Append("    ,@GOODSNAME").Append(Environment.NewLine);
                sqlTxt.Append("    ,@GOODSNAMEKANA").Append(Environment.NewLine);
                sqlTxt.Append("    ,@ITEMQTY").Append(Environment.NewLine);
                sqlTxt.Append(" )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                pccCpItmStWorkEach.UpdateDateTime = DateTime.Now;
                pccCpItmStWorkEach.CreateDateTime = DateTime.Now;
                pccCpItmStWorkEach.LogicalDeleteCode = 0;
            }

            if (!myReader.IsClosed) myReader.Close();
            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqotherEpcd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqotherSeccd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraCampaignCode = sqlCommand.Parameters.Add("@CAMPAIGNCODE", SqlDbType.Int);
            SqlParameter paraCampstDiv = sqlCommand.Parameters.Add("@CAMPSTDIV", SqlDbType.Int);
            SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            SqlParameter paraGoodsMakercd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
            SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
            SqlParameter paraItemQty = sqlCommand.Parameters.Add("@ITEMQTY", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpItmStWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpItmStWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.LogicalDeleteCode);
            paraInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
            paraInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
            paraCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
            paraCampstDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
            paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
            paraGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
            paraGoodsMakercd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            paraGoodsName.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsName);
            paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNameKana);
            paraItemQty.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.ItemQty);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
		}

		/// <summary>
		/// PCCキャンペーン設定情報検索処理
		/// </summary>
		/// <param name="paraObj">検索パラメータ</param>
		/// <param name="pccCpMsgStWorkObj">PCCキャンペーンメッセージ設定情報</param>
		/// <param name="pccCpItmStWorkObj">PCCキャンペーン品目設定情報</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定された条件のPCCキャンペーン設定情報を戻します。</br>
		/// <br>Programmer : huangqb</br>
		/// <br>Date       : 2011.08.11</br>
		/// </remarks>
		public int SearchPccCampaign(object paraObj, out object pccCpMsgStWorkObj, out object pccCpItmStWorkObj, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			SqlConnection sqlConnection = null;
			pccCpMsgStWorkObj = new ArrayList();
			pccCpItmStWorkObj = new ArrayList();
			errMsg = string.Empty;

			try
			{
				// コネクション生成
				sqlConnection = CreateSqlConnection();
				if (sqlConnection == null) return status;
				sqlConnection.Open();

				SearchParaWork searchParaWork = (SearchParaWork)paraObj;
				ArrayList pccCpMsgStWorkList;
				ArrayList pccCpItmStWorkList;

				// PCCキャンペーン設定情報検索
				status = SearchPccCampaignProc(searchParaWork, out pccCpMsgStWorkList, out pccCpItmStWorkList, out errMsg, ref sqlConnection);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					pccCpMsgStWorkObj = (object)pccCpMsgStWorkList;
					pccCpItmStWorkObj = (object)pccCpItmStWorkList;
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				base.WriteErrorLog(ex, "PccCpMsgStDB.SearchPccCampaign");
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
		/// PCCキャンペーンメッセージ設定マスタメンテ検索処理
		/// </summary>
		/// <param name="searchParaWork">検索パラメータ</param>
		/// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージ設定データリスト</param>
		/// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
		/// <param name="errMsg">エラーメッセージ</param>
		///  <param name="sqlConnection">コネクション</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Programmer : 黄海霞</br>
		/// <br>Date       : 2011.08.11</br>
		/// </remarks>
		private int SearchPccCampaignProc(SearchParaWork searchParaWork, out ArrayList pccCpMsgStWorkList, out ArrayList pccCpItmStWorkList, out string errMsg, ref SqlConnection sqlConnection)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;
			pccCpMsgStWorkList = new ArrayList();
			pccCpItmStWorkList = new ArrayList();
			errMsg = string.Empty;

            // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
            bool inqOtherEpFlg = StringChk(searchParaWork.InqOtherEpCd);   //問合せ先企業指定
            bool inqOtherSecFlg = StringChk(searchParaWork.InqOtherSecCd); //問合せ先拠点指定
            // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
			{
				StringBuilder sqlTxt = new StringBuilder(string.Empty);
				StringBuilder sqlSelect = new StringBuilder(string.Empty);
				sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
				sqlSelect.Append("SELECT  ").Append(Environment.NewLine);
				sqlSelect.Append("     PCCCPMSGSTRF.CREATEDATETIMERF AS MSGSTCREATEDATETIMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.UPDATEDATETIMERF AS MSGSTUPDATEDATETIMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.LOGICALDELETECODERF AS MSGSTLOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.INQOTHEREPCDRF AS MSGSTINQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.INQOTHERSECCDRF AS MSGSTINQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.CAMPAIGNCODERF AS MSGSTCAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.APPLYSTADATERF AS MSGSTAPPLYSTADATERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.APPLYENDDATERF AS MSGSTAPPLYENDDATERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.PCCMSGDOCCNTSRF AS MSGSTPCCMSGDOCCNTSRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.CAMPAIGNNAMERF AS MSGSTCAMPAIGNNAMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPMSGSTRF.CAMPAIGNOBJDIVRF AS MSGSTCAMPAIGNOBJDIVRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.CREATEDATETIMERF AS ITMSTCREATEDATETIMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.UPDATEDATETIMERF AS ITMSTUPDATEDATETIMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.LOGICALDELETECODERF AS ITMSTLOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.INQOTHEREPCDRF AS ITMSTINQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.INQOTHERSECCDRF AS ITMSTINQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.CAMPAIGNCODERF AS ITMSTCAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.CAMPSTDIVRF AS ITMSTCAMPSTDIVRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.BLGOODSCODERF AS ITMSTBLGOODSCODERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.GOODSNORF AS ITMSTGOODSNORF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.GOODSMAKERCDRF AS ITMSTGOODSMAKERCDRF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.GOODSNAMERF AS ITMSTGOODSNAMERF ").Append(Environment.NewLine);
				sqlSelect.Append("    ,PCCCPITMSTRF.GOODSNAMEKANARF AS ITMSTGOODSNAMEKANARF ").Append(Environment.NewLine);
                sqlSelect.Append("    ,PCCCPITMSTRF.ITEMQTYRF AS ITEMQTYRF ").Append(Environment.NewLine);

				sqlTxt.Append(sqlSelect);
				sqlTxt.Append("FROM PCCCPTGTSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("INNER JOIN PCCCPMSGSTRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("    ON PCCCPTGTSTRF.LOGICALDELETECODERF = PCCCPMSGSTRF.LOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHEREPCDRF = PCCCPMSGSTRF.INQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHERSECCDRF = PCCCPMSGSTRF.INQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPTGTSTRF.CAMPAIGNCODERF = PCCCPMSGSTRF.CAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlTxt.Append("LEFT JOIN PCCCPITMSTRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("    ON PCCCPMSGSTRF.LOGICALDELETECODERF = PCCCPITMSTRF.LOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHEREPCDRF = PCCCPITMSTRF.INQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHERSECCDRF = PCCCPITMSTRF.INQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.CAMPAIGNCODERF = PCCCPITMSTRF.CAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlTxt.Append("WHERE ").Append(Environment.NewLine);
				sqlTxt.Append("    PCCCPTGTSTRF.INQORIGINALEPCDRF = @FINDINQORIGINALEPCD ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPTGTSTRF.INQORIGINALSECCDRF = @FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                // --- UPD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                //sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHERSECCDRF = @FINDINQOTHERSECCD ").Append(Environment.NewLine);
                if (inqOtherEpFlg)  sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                if (inqOtherSecFlg) sqlTxt.Append("    AND PCCCPTGTSTRF.INQOTHERSECCDRF = @FINDINQOTHERSECCD ").Append(Environment.NewLine);
                // --- UPD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                sqlTxt.Append("    AND PCCCPMSGSTRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.CAMPAIGNOBJDIVRF = @FINDCAMPAIGNOBJDIVSPECIFIER ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.APPLYSTADATERF <= @FINDSEARCHDATE ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.APPLYENDDATERF >= @FINDSEARCHDATE ").Append(Environment.NewLine);

				sqlTxt.Append("UNION ").Append(Environment.NewLine);
				sqlTxt.Append(sqlSelect);
				sqlTxt.Append("FROM PCCCPMSGSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("LEFT JOIN PCCCPITMSTRF WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sqlTxt.Append("    ON PCCCPMSGSTRF.LOGICALDELETECODERF = PCCCPITMSTRF.LOGICALDELETECODERF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHEREPCDRF = PCCCPITMSTRF.INQOTHEREPCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHERSECCDRF = PCCCPITMSTRF.INQOTHERSECCDRF ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.CAMPAIGNCODERF = PCCCPITMSTRF.CAMPAIGNCODERF ").Append(Environment.NewLine);
				sqlTxt.Append("WHERE ").Append(Environment.NewLine);
				sqlTxt.Append("    PCCCPMSGSTRF.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                //sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHERSECCDRF = @FINDINQOTHERSECCD ").Append(Environment.NewLine);
                if (inqOtherEpFlg)  sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHEREPCDRF = @FINDINQOTHEREPCD ").Append(Environment.NewLine);
                if (inqOtherSecFlg) sqlTxt.Append("    AND PCCCPMSGSTRF.INQOTHERSECCDRF = @FINDINQOTHERSECCD ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                sqlTxt.Append("    AND PCCCPMSGSTRF.CAMPAIGNOBJDIVRF = @FINDCAMPAIGNOBJDIVALL ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.APPLYSTADATERF <= @FINDSEARCHDATE ").Append(Environment.NewLine);
				sqlTxt.Append("    AND PCCCPMSGSTRF.APPLYENDDATERF >= @FINDSEARCHDATE ").Append(Environment.NewLine);

				sqlTxt.Append("ORDER BY PCCCPMSGSTRF.APPLYSTADATERF DESC").Append(Environment.NewLine);
				sqlCommand.CommandText = sqlTxt.ToString();

				SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
				SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
				SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
				SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
				SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				SqlParameter findParaCampaignObjDivSpecifier = sqlCommand.Parameters.Add("@FINDCAMPAIGNOBJDIVSPECIFIER", SqlDbType.Int);
				SqlParameter findParaCampaignObjDivAll = sqlCommand.Parameters.Add("@FINDCAMPAIGNOBJDIVALL", SqlDbType.Int);
				SqlParameter findParaSearchDate = sqlCommand.Parameters.Add("@FINDSEARCHDATE", SqlDbType.Int);

				findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(searchParaWork.InqOriginalEpCd);
				findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(searchParaWork.InqOriginalSecCd);
				findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(searchParaWork.InqOtherEpCd);
				findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(searchParaWork.InqOtherSecCd);
				findParaCampaignObjDivSpecifier.Value = SqlDataMediator.SqlSetInt32(1);
				findParaCampaignObjDivAll.Value = SqlDataMediator.SqlSetInt32(0);
				findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
				findParaSearchDate.Value = SqlDataMediator.SqlSetInt32(searchParaWork.SearchDate);
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
				myReader = sqlCommand.ExecuteReader();
                status = this.CopyMsgAndStWorkListFromReader(ref myReader, ref pccCpMsgStWorkList, ref pccCpItmStWorkList);
				
			}
			catch (SqlException ex)
			{
				errMsg = ex.Message;
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.SearchPccCampaignProc", status);
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
        /// PCCキャンペーンメッセージ設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <param name="parsePccCpMsgStWork">検索パラメータ</param>
        /// <param name="parsePccCpTgtStWork">検索パラメータ</param>
        /// <param name="parsePccCpItmStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        ///  <param name="dateSearchFlag">0:日付条件検索なし1：日付条件検索</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Search(out object pccCpMsgStWorkList, out object pccCpTgtStWorkList, out object pccCpItmStWorkList, PccCpMsgStWork parsePccCpMsgStWork, PccCpTgtStWork parsePccCpTgtStWork, PccCpItmStWork parsePccCpItmStWork, int readMode, ConstantManagement.LogicalMode logicalMode, int dateSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pccCpMsgStWorkList = null;
            pccCpTgtStWorkList = null;
            pccCpItmStWorkList = null;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //PCCキャンペーンメッセージ設定マスタ
                status = SearchMsgProc(out pccCpMsgStWorkList, parsePccCpMsgStWork, readMode, logicalMode, ref sqlConnection, dateSearchFlag);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    //PCCキャンペーン対象設定マスタ
                    status = SearchTgtProc(out pccCpTgtStWorkList, parsePccCpTgtStWork, readMode, logicalMode, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        //PCCキャンペーン品目設定マスタ
                        status = SearchItmProc(out pccCpItmStWorkList, parsePccCpItmStWork, readMode, logicalMode, ref sqlConnection);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Search");
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
        /// PCCキャンペーンメッセージ設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="parsePccCpMsgStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        ///  <param name="sqlConnection">コネクション</param>
        /// <param name="dateSearchFlag">0:日付条件検索なし1：日付条件検索</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int SearchMsgProc(out object pccCpMsgStWorkList, PccCpMsgStWork parsePccCpMsgStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, int dateSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCpMsgStWorkList = null;

            // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
            bool inqOtherEpFlg = StringChk(parsePccCpMsgStWork.InqOtherEpCd);   //問合せ先企業指定
            bool inqOtherSecFlg = StringChk(parsePccCpMsgStWork.InqOtherSecCd); //問合せ先拠点指定
            // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,APPLYSTADATERF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,APPLYENDDATERF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,PCCMSGDOCCNTSRF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNNAMERF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNOBJDIVRF ").Append(Environment.NewLine);
                sqlTxt.Append("    FROM PCCCPMSGSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (inqOtherEpFlg && inqOtherSecFlg)
                {
                    // 問合せ先企業・拠点が指定されている
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                }
                else if (inqOtherEpFlg)
                {
                    // 問合せ先企業のみ指定されている
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                }
                else if (inqOtherSecFlg)
                {
                    // 問合せ先拠点のみ指定されている
                    sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                }
                else
                {
                    // 問合せ先企業・拠点が指定されていない
                    sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //以下の追加条件の為のダミー
                }
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                if (dateSearchFlag == 1)
                {
                    sqlTxt.Append("   AND APPLYSTADATERF <= @FINDAPPLYSTADATE").Append(Environment.NewLine);
                    sqlTxt.Append("   AND APPLYENDDATERF >= @FINDAPPLYENDDATE").Append(Environment.NewLine);
                }
                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                sqlTxt.Append("  ORDER BY INQOTHEREPCDRF,INQOTHERSECCDRF, CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                string  month = DateTime.Now.Month.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
                string day = DateTime.Now.Day.ToString();
                if (day.Length == 1)
                {
                    day = "0" + day;
                }
                string dateTime = DateTime.Now.Year + month + day;
                SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpMsgStWork.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpMsgStWork.InqOtherSecCd);
                if (dateSearchFlag == 1)
                {
                    SqlParameter findParaApplystaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
                    SqlParameter findParaApplyendDate = sqlCommand.Parameters.Add("@FINDAPPLYENDDATE", SqlDbType.Int);
                    findParaApplystaDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(dateTime));
                    findParaApplyendDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(dateTime));
                }
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();
                status = this.CopyPccCpMsgStWorkListFromReader(ref myReader, ref al);
                pccCpMsgStWorkList = al;
            }
            catch(SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.SearchMsgProc", status);
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
        /// PCCキャンペーン対象設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定マスタ設定データリスト</param>
        /// <param name="parsePccCpTgtStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int SearchTgtProc(out object pccCpTgtStWorkList, PccCpTgtStWork parsePccCpTgtStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCpTgtStWorkList = null;

            // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
            bool inqOtherEpFlg = StringChk(parsePccCpTgtStWork.InqOtherEpCd);   //問合せ先企業指定
            bool inqOtherSecFlg = StringChk(parsePccCpTgtStWork.InqOtherSecCd); //問合せ先拠点指定
            // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALEPCDRF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQORIGINALSECCDRF ").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("    FROM PCCCPTGTSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (inqOtherEpFlg && inqOtherSecFlg)
                {
                    // 問合せ先企業・拠点が指定されている
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                }
                else if (inqOtherEpFlg)
                {
                    // 問合せ先企業のみ指定されている
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                }
                else if (inqOtherSecFlg)
                {
                    // 問合せ先拠点のみ指定されている
                    sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                }
                else
                {
                    // 問合せ先企業・拠点が指定されていない
                    sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //以下の追加条件の為のダミー
                }
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("  ORDER BY INQOTHEREPCDRF,INQOTHERSECCDRF, CAMPAIGNCODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpTgtStWork.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpTgtStWork.InqOtherSecCd);
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();
                status = this.CopyPccCpTgtStWorkListFromReader(ref myReader, ref al);
                pccCpTgtStWorkList = al;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.SearchTgtProc", status);
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
        /// PCCキャンペーン品目設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定マスタ設定データリスト</param>
        /// <param name="parsePccCpItmStWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int SearchItmProc(out object pccCpItmStWorkList, PccCpItmStWork parsePccCpItmStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {           
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList al = new ArrayList();
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            pccCpItmStWorkList = null;

            // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
            bool inqOtherEpFlg = StringChk(parsePccCpItmStWork.InqOtherEpCd);   //問合せ先企業指定
            bool inqOtherSecFlg = StringChk(parsePccCpItmStWork.InqOtherSecCd); //問合せ先拠点指定
            // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            try
            {
                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,CAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,BLGOODSCODERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,GOODSNORF").Append(Environment.NewLine);
                sqlTxt.Append("      ,GOODSMAKERCDRF").Append(Environment.NewLine);
                sqlTxt.Append("      ,GOODSNAMERF").Append(Environment.NewLine);
                sqlTxt.Append("      ,GOODSNAMEKANARF").Append(Environment.NewLine);
                sqlTxt.Append("      ,ITEMQTYRF").Append(Environment.NewLine);
                sqlTxt.Append("    FROM PCCCPITMSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                if (inqOtherEpFlg && inqOtherSecFlg)
                {
                    // 問合せ先企業・拠点が指定されている
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                }
                else if (inqOtherEpFlg)
                {
                    // 問合せ先企業のみ指定されている
                    sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                }
                else if (inqOtherSecFlg)
                {
                    // 問合せ先拠点のみ指定されている
                    sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                }
                else
                {
                    // 問合せ先企業・拠点が指定されていない
                    sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //以下の追加条件の為のダミー
                }
                // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                
                //論理削除区分
                string wkstring = string.Empty;
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                }
                if (!string.IsNullOrEmpty(wkstring))
                {
                    sqlTxt.Append(wkstring).Append(Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                sqlTxt.Append("  ORDER BY INQOTHEREPCDRF,INQOTHERSECCDRF, CAMPAIGNCODERF, CAMPSTDIVRF,BLGOODSCODERF,GOODSNORF,GOODSMAKERCDRF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpItmStWork.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpItmStWork.InqOtherSecCd);
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);
                myReader = sqlCommand.ExecuteReader();
                status = this.CopyPccCpItmStWorkListFromReader(ref myReader, ref al);
                pccCpItmStWorkList = al;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.SearchItmProc", status);
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
        /// PCCキャンペーンメッセージ設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="dateSearchFlag">0:日付条件検索なし1：日付条件検索</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Read(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, int dateSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //PCCキャンペーンメッセージ設定マスタ
                status = ReadMsgProc(ref pccCpMsgStWorkList,readMode, logicalMode, ref sqlConnection, dateSearchFlag);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //PCCキャンペーン対象設定マスタ
                    status = ReadTgtProc(ref pccCpTgtStWorkList, readMode, logicalMode, ref sqlConnection);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //PCCキャンペーン品目設定マスタ
                        status = ReadItmProc(ref pccCpItmStWorkList, readMode, logicalMode, ref sqlConnection);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Read");
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
        /// PCCキャンペーンメッセージ設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        ///  <param name="sqlConnection">コネクション</param>
        ///  <param name="dateSearchFlag">0:日付条件検索なし1：日付条件検索</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int ReadMsgProc(ref object pccCpMsgStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, int dateSearchFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccCpMsgStWorkArrList = null;
            ArrayList pccCpMsgStWorkArrListNew = null;
            try
            {
                if (pccCpMsgStWorkList != null)
                {
                    pccCpMsgStWorkArrList = pccCpMsgStWorkList as ArrayList;

                }
                if (pccCpMsgStWorkArrList == null || pccCpMsgStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpMsgStWorkArrListNew = new ArrayList();

                foreach (PccCpMsgStWork parsePccCpMsgStWork in pccCpMsgStWorkArrList)
                {
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    bool inqOtherEpFlg = StringChk(parsePccCpMsgStWork.InqOtherEpCd);   //問合せ先企業指定
                    bool inqOtherSecFlg = StringChk(parsePccCpMsgStWork.InqOtherSecCd); //問合せ先拠点指定
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    StringBuilder sqlTxt = new StringBuilder(string.Empty);
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                    sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                    sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,APPLYSTADATERF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,APPLYENDDATERF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,PCCMSGDOCCNTSRF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNNAMERF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNOBJDIVRF ").Append(Environment.NewLine);
                    sqlTxt.Append("    FROM PCCITEMGRPRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    if (inqOtherEpFlg && inqOtherSecFlg)
                    {
                        // 問合せ先企業・拠点が指定されている
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    }
                    else if (inqOtherEpFlg)
                    {
                        // 問合せ先企業のみ指定されている
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    }
                    else if (inqOtherSecFlg)
                    {
                        // 問合せ先拠点のみ指定されている
                        sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    }
                    else
                    {
                        // 問合せ先企業・拠点が指定されていない
                        sqlTxt.Append("   1 = 1").Append(Environment.NewLine); // 以下の追加条件の為のダミー
                    }
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                    if (dateSearchFlag == 1)
                    {
                        sqlTxt.Append("   AND APPLYSTADATERF <= @FINDAPPLYSTADATE").Append(Environment.NewLine);
                        sqlTxt.Append("   AND APPLYENDDATERF >= @FINDAPPLYENDDATE").Append(Environment.NewLine);
                    }
                    //論理削除区分
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    }
                    if (!string.IsNullOrEmpty(wkstring))
                    {
                        sqlTxt.Append(wkstring).Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }

                    sqlTxt.Append("  ORDER BY INQOTHEREPCDRF,INQOTHERSECCDRF,CAMPAIGNCODERF").Append(Environment.NewLine);
                    sqlCommand.CommandText = sqlTxt.ToString();

                    string month = DateTime.Now.Month.ToString();
                    if (month.Length == 1)
                    {
                        month = "0" + month;
                    }
                    string day = DateTime.Now.Day.ToString();
                    if (day.Length == 1)
                    {
                        day = "0" + day;
                    }
                    string dateTime = DateTime.Now.Year + month + day;
                    SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                    findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpMsgStWork.InqOtherEpCd);
                    findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpMsgStWork.InqOtherSecCd);
                    findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(parsePccCpMsgStWork.CampaignCode);
                    if (dateSearchFlag == 1)
                    {
                        SqlParameter findParaApplystaDate = sqlCommand.Parameters.Add("@FINDAPPLYSTADATE", SqlDbType.Int);
                        SqlParameter findParaApplyendDate = sqlCommand.Parameters.Add("@FINDAPPLYENDDATE", SqlDbType.Int);
                        findParaApplystaDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(dateTime));
                        findParaApplyendDate.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(dateTime));
                    }
                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    myReader = sqlCommand.ExecuteReader();
                    ArrayList pccCpMsgStWorkArrListEach = new ArrayList();
                    status = this.CopyPccCpMsgStWorkListFromReader(ref myReader, ref pccCpMsgStWorkArrListNew);
                    pccCpMsgStWorkArrListNew.AddRange(pccCpMsgStWorkArrListEach);
                }
                pccCpMsgStWorkList = pccCpMsgStWorkArrListNew;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.ReadMsgProc", status);
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
        /// PCCキャンペーン対象設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定マスタ設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int ReadTgtProc(ref object pccCpTgtStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList pccCpTgtStWorkArrList = null;
            ArrayList pccCpTgtStWorkArrListNew = null;
            try
            {
                if (pccCpTgtStWorkList != null)
                {
                    pccCpTgtStWorkArrList = pccCpTgtStWorkList as ArrayList;
                }
                if (pccCpTgtStWorkArrList == null || pccCpTgtStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpTgtStWorkArrListNew = new ArrayList();

                foreach (PccCpTgtStWork parsePccCpTgtStWork in pccCpTgtStWorkArrList)
                {
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    bool inqOtherEpFlg = StringChk(parsePccCpTgtStWork.InqOtherEpCd);   //問合せ先企業指定
                    bool inqOtherSecFlg = StringChk(parsePccCpTgtStWork.InqOtherSecCd); //問合せ先拠点指定
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                    StringBuilder sqlTxt = new StringBuilder(string.Empty);
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                    sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                    sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQORIGINALEPCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQORIGINALSECCDRF ").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("    FROM PCCCPTGTSTRF WITH(READUNCOMMITTED) ").Append(Environment.NewLine);
                    sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    if (inqOtherEpFlg && inqOtherSecFlg)
                    {
                        // 問合せ先企業・拠点が指定されている
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    }
                    else if (inqOtherEpFlg)
                    {
                        // 問合せ先企業のみ指定されている
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    }
                    else if (inqOtherSecFlg)
                    {
                        // 問合せ先拠点のみ指定されている
                        sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    }
                    else
                    {
                        // 問合せ先企業・拠点が指定されていない
                        sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //以下の追加条件の為のダミー
                    }
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);

                    //論理削除区分
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    }
                    if (!string.IsNullOrEmpty(wkstring))
                    {
                        sqlTxt.Append(wkstring).Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    sqlCommand.CommandText = sqlTxt.ToString();

                    SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                    findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpTgtStWork.InqOtherEpCd);
                    findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpTgtStWork.InqOtherSecCd);
                    findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(parsePccCpTgtStWork.CampaignCode);
                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    myReader = sqlCommand.ExecuteReader();
                    ArrayList pccCpTgtStWorkArrListEach = new ArrayList();
                    status = this.CopyPccCpTgtStWorkListFromReader(ref myReader, ref pccCpTgtStWorkArrListEach);
                    pccCpTgtStWorkArrListNew.AddRange(pccCpTgtStWorkArrListEach);
                }
                pccCpTgtStWorkList = pccCpTgtStWorkArrListNew;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.ReadTgtProc", status);
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
        /// PCCキャンペーン品目設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定マスタ設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int ReadItmProc(ref object pccCpItmStWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            ArrayList pccCpItmStWorkArrList = null;
            ArrayList pccCpItmStWorkArrListNew = null; 
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCpItmStWorkList != null)
                {
                    pccCpItmStWorkArrList = pccCpItmStWorkList as ArrayList;
                }
                if (pccCpItmStWorkArrList == null || pccCpItmStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpItmStWorkArrListNew = new ArrayList();
                foreach (PccCpItmStWork parsePccCpItmStWork in pccCpItmStWorkArrList)
                {
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    bool inqOtherEpFlg = StringChk(parsePccCpItmStWork.InqOtherEpCd);   //問合せ先企業指定
                    bool inqOtherSecFlg = StringChk(parsePccCpItmStWork.InqOtherSecCd); //問合せ先拠点指定
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                    StringBuilder sqlTxt = new StringBuilder(string.Empty);
                    sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                    sqlTxt.Append("SELECT  ").Append(Environment.NewLine);
                    sqlTxt.Append("       CREATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHEREPCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,INQOTHERSECCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,CAMPAIGNCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("       CAMPSTDIVRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,BLGOODSCODERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,GOODSNORF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,GOODSMAKERCDRF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,GOODSNAMERF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,GOODSNAMEKANARF").Append(Environment.NewLine);
                    sqlTxt.Append("      ,ITEMQTYRF").Append(Environment.NewLine);
                    sqlTxt.Append("    FROM PCCCPITMSTRF WITH(READUNCOMMITTED)  ").Append(Environment.NewLine);
                    sqlTxt.Append("    WHERE ").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    if (inqOtherEpFlg && inqOtherSecFlg)
                    {
                        // 問合せ先企業・拠点が指定されている
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                        sqlTxt.Append("   AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    }
                    else if (inqOtherEpFlg)
                    {
                        // 問合せ先企業のみ指定されている
                        sqlTxt.Append("   INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                    }
                    else if (inqOtherSecFlg)
                    {
                        // 問合せ先拠点のみ指定されている
                        sqlTxt.Append("   INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                    }
                    else
                    {
                        // 問合せ先企業・拠点が指定されていない
                        sqlTxt.Append("   1 = 1").Append(Environment.NewLine); //以下の追加条件の為のダミー
                    }
                    // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    sqlTxt.Append("   AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);

                    //論理削除区分
                    string wkstring = string.Empty;
                    if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData3))
                    {
                        wkstring = "AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                    }
                    else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                        (logicalMode == ConstantManagement.LogicalMode.GetData012))
                    {
                        wkstring = "AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                    }
                    if (!string.IsNullOrEmpty(wkstring))
                    {
                        sqlTxt.Append(wkstring).Append(Environment.NewLine);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                    }
                    sqlCommand.CommandText = sqlTxt.ToString();

                    SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                    findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(parsePccCpItmStWork.InqOtherEpCd);
                    findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(parsePccCpItmStWork.InqOtherSecCd);
                    findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(parsePccCpItmStWork.CampaignCode);
                    //タイムアウト時間の設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                    myReader = sqlCommand.ExecuteReader();
                    ArrayList pccCpItmStWorkArrListEach = new ArrayList();
                    status = this.CopyPccCpItmStWorkListFromReader(ref myReader, ref pccCpItmStWorkArrListEach);
                    pccCpItmStWorkArrListNew.AddRange(pccCpItmStWorkArrListEach);
                }

                pccCpItmStWorkList = pccCpItmStWorkArrListNew;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IPccCpMsgStDB.ReadItmProc", status);
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
        /// PCCキャンペーンメッセージ設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDelete(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList)
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
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);
                // PCCキャンペーンメッセージ設定マスタ
                status = LogicalDeleteMsgProc(ref pccCpMsgStWorkList, 0, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //PCCキャンペーン対象設定マスタ
                    status = LogicalDeleteTgtProc(ref pccCpTgtStWorkList,0, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //PCCキャンペーン品目設定マスタ
                        status = LogicalDeleteItmProc(ref pccCpItmStWorkList, 0, ref sqlConnection, ref sqlTransaction);
                
                    }
                };
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.LogicalDelete");
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
        /// PCC品目グループマスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccItmStWorkList">PCC品目グループデータリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDeleteItmProc(ref object pccItmStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlCommand sqlCommand = null;
            ArrayList pccItmGrpWorkArrList = null;
            ArrayList pccItmGrpWorkArrListNew = null;
            try
            {
                if (pccItmStWorkList != null)
                {
                    pccItmGrpWorkArrList = pccItmStWorkList as ArrayList;

                }
                if (pccItmGrpWorkArrList == null || pccItmGrpWorkArrList.Count == 0)
                {
                    return status;
                }
                pccItmGrpWorkArrListNew = new ArrayList();


                for (int i = 0; i < pccItmGrpWorkArrList.Count; i++)
                {
                    PccCpItmStWork pccItmWorkEach = pccItmGrpWorkArrList[i] as PccCpItmStWork;
                    status = LogicalDeleteProcItmEach(ref pccItmWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccItmGrpWorkArrListNew.Add(pccItmWorkEach);


                }
                pccItmStWorkList = pccItmGrpWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpItmStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpItmStDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCpItmStWorkEach">PCC品目グループ</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int LogicalDeleteProcItmEach(ref PccCpItmStWork pccCpItmStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int logicalDelCd = 0;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPITMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            SqlParameter findParaCampStDiv = sqlCommand.Parameters.Add("@FINDCAMPSTDIVRF", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
            findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccCpItmStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE PCCCPITMSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
                findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
                pccCpItmStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }

            if (!myReader.IsClosed) myReader.Close();

            //論理削除モードの場合
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccCpItmStWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット

            }
            else
            {
                if (logicalDelCd == 1) pccCpItmStWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除

            }

            //Parameterオブジェクトの作成(更新用)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameterオブジェクトへ値設定(更新用)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpItmStWorkEach.UpdateDateTime);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCCキャンペーン対象設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccTgtStWorkList">PPCCキャンペーン対象設定マスタグループデータリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDeleteTgtProc(ref object pccTgtStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;           
            SqlCommand sqlCommand = null;
            ArrayList pccTgtStWorkArrList = null;
            ArrayList pccTgtStWorkArrListNew = null;
            try
            {
                if (pccTgtStWorkList != null)
                {
                    pccTgtStWorkArrList = pccTgtStWorkList as ArrayList;

                }
                if (pccTgtStWorkArrList == null || pccTgtStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccTgtStWorkArrListNew = new ArrayList();


                for (int i = 0; i < pccTgtStWorkArrList.Count; i++)
                {
                    PccCpTgtStWork pccTgtWorkEach = pccTgtStWorkArrList[i] as PccCpTgtStWork;
                    status = LogicalDeleteProcTgtEach(ref pccTgtWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccTgtStWorkArrListNew.Add(pccTgtWorkEach);


                }
                pccTgtStWorkList = pccTgtStWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCpMsgStWorkEach">PCCキャンペーンメッセージ設定マスタグループ</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDeleteProcMsgEach(ref PccCpMsgStWork pccCpMsgStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPMSGSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);

            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccCpMsgStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE PCCCPMSGSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);


                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
                pccCpMsgStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }

            if (!myReader.IsClosed) myReader.Close();

            //論理削除モードの場合
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccCpMsgStWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット

            }
            else
            {
                if (logicalDelCd == 1) pccCpMsgStWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除

            }

            //Parameterオブジェクトの作成(更新用)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameterオブジェクトへ値設定(更新用)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpMsgStWorkEach.UpdateDateTime);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCCキャンペーン対象設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccMsgStWorkList">PCCキャンペーン対象設定マスタタグループデータリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDeleteMsgProc(ref object pccMsgStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
           
            SqlCommand sqlCommand = null;
            ArrayList pccMsgStWorArrList = null;
            ArrayList pccMsgStWorArrListNew = null;
            try
            {
                if (pccMsgStWorkList != null)
                {
                    pccMsgStWorArrList = pccMsgStWorkList as ArrayList;

                }
                if (pccMsgStWorArrList == null || pccMsgStWorArrList.Count == 0)
                {
                    return status;
                }
                pccMsgStWorArrListNew = new ArrayList();


                for (int i = 0; i < pccMsgStWorArrList.Count; i++)
                {
                    PccCpMsgStWork pccMsgWorkEach = pccMsgStWorArrList[i] as PccCpMsgStWork;
                    status = LogicalDeleteProcMsgEach(ref pccMsgWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccMsgStWorArrListNew.Add(pccMsgWorkEach);


                }
                pccMsgStWorkList = pccMsgStWorArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// PCCキャンペーン対象設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCpTgtStWorkEach">PCCキャンペーン対象設定マスタグループ</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int LogicalDeleteProcTgtEach(ref PccCpTgtStWork pccCpTgtStWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPTGTSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqoriginalEpcd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqoriginaLSeccd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
            findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != pccCpTgtStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                sqlTxt.Append("UPDATE PCCCPTGTSTRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append("WHERE").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

                sqlCommand.CommandText = sqlTxt.ToString();

                //Prameterオブジェクトの作成
                SqlParameter findParaInqoriginalEpcd1 = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqoriginaLSeccd1 = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqotherEpcd1 = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqotherSeccd1 = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                SqlParameter findParaCampaignCode1 = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
                //KEYコマンドを再設定
                findParaInqoriginalEpcd1.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
                findParaInqoriginaLSeccd1.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
                findParaInqotherEpcd1.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd1.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
                findParaCampaignCode1.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
                pccCpTgtStWorkEach.UpdateDateTime = DateTime.Now;
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                return status;
            }

            if (!myReader.IsClosed) myReader.Close();

            //論理削除モードの場合
            if (procMode == 0)
            {

                if (logicalDelCd == 0) pccCpTgtStWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット

            }
            else
            {
                if (logicalDelCd == 1) pccCpTgtStWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除

            }

            //Parameterオブジェクトの作成(更新用)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameterオブジェクトへ値設定(更新用)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pccCpTgtStWorkEach.UpdateDateTime);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
       
        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int Delete(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList)
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
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                 //PCCキャンペーン品目設定マスタ
                status = DeleteItmProc(ref pccCpItmStWorkList, ref sqlConnection,ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //PCCキャンペーン対象設定マスタ
                    status = DeleteTgtProc(ref pccCpTgtStWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // PCCキャンペーンメッセージ設定マスタ
                        status = DeleteMsgProc(ref pccCpMsgStWorkList, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.Delete");
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
        /// PCC品目グループマスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCC品目グループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteItmProc(ref object pccCpItmStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccCpItmStWorkArrList = null;
            ArrayList pccCpItmStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCpItmStWorkList != null)
                {
                    pccCpItmStWorkArrList = pccCpItmStWorkList as ArrayList;

                }
                if (pccCpItmStWorkArrList == null || pccCpItmStWorkArrList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                pccCpItmStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCpItmStWorkArrList.Count; i++)
                {
                    PccCpItmStWork pccItmWorkEach = pccCpItmStWorkArrList[i] as PccCpItmStWork;
                    status = DeleteProcItmEach(ref pccItmWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCpItmStWorkArrListNew.Add(pccItmWorkEach);

                }

                pccCpItmStWorkList = pccCpItmStWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpItmStDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpItmStDB.Delete Exception=" + ex.Message);
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
        /// PCC品目設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCpItmStWorkEach">PCC品目グループ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteProcItmEach(ref PccCpItmStWork pccCpItmStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPITMSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
            sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
            sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            SqlParameter findParaCampStDiv = sqlCommand.Parameters.Add("@FINDCAMPSTDIVRF", SqlDbType.Int);
            SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
            findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
            findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccCpItmStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCCPITMSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPSTDIVRF = @FINDCAMPSTDIVRF").Append(Environment.NewLine);
                sqlTxt.Append("  AND BLGOODSCODERF = @FINDBLGOODSCODE").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSNORF = @FINDGOODSNO").Append(Environment.NewLine);
                sqlTxt.Append("  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampaignCode);
                findParaCampStDiv.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.CampStDiv);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.BLGoodsCode);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(pccCpItmStWorkEach.GoodsNo);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pccCpItmStWorkEach.GoodsMakerCd);
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                sqlConnection.Close();
                return status;
            }
            if (!myReader.IsClosed) myReader.Close();

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCCキャンペーン対象設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定マスタグループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteTgtProc(ref object pccCpTgtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccCpTgtStWorkArrList = null;
            ArrayList pccCpTgtStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCpTgtStWorkList != null)
                {
                    pccCpTgtStWorkArrList = pccCpTgtStWorkList as ArrayList;

                }
                if (pccCpTgtStWorkArrList == null || pccCpTgtStWorkArrList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    return status;
                }
                pccCpTgtStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCpTgtStWorkArrList.Count; i++)
                {
                    PccCpTgtStWork pccTgtWorkEach = pccCpTgtStWorkArrList[i] as PccCpTgtStWork;
                    status = DeleteProcTgtEach(ref pccTgtWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCpTgtStWorkArrListNew.Add(pccTgtWorkEach);

                }

                pccCpTgtStWorkList = pccCpTgtStWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.Delete Exception=" + ex.Message);
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
        /// PCCキャンペーン対象設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCpTgtStWorkEach">PCCキャンペーン対象設定マスタグループ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteProcTgtEach(ref PccCpTgtStWork pccCpTgtStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPTGTSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
            
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqoriginalEpcd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqoriginaLSeccd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
            findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccCpTgtStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCCPTGTSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqoriginalEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalEpCd);
                findParaInqoriginaLSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOriginalSecCd);
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpTgtStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpTgtStWorkEach.CampaignCode);
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                sqlConnection.Close();
                return status;
            }
            if (!myReader.IsClosed) myReader.Close();

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージ設定マスタグループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteMsgProc(ref object pccCpMsgStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList pccCpMsgStWorkArrList = null;
            ArrayList pccCpMsgStWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (pccCpMsgStWorkList != null)
                {
                    pccCpMsgStWorkArrList = pccCpMsgStWorkList as ArrayList;

                }
                if (pccCpMsgStWorkArrList == null || pccCpMsgStWorkArrList.Count == 0)
                {
                    return status;
                }
                pccCpMsgStWorkArrListNew = new ArrayList();

                for (int i = 0; i < pccCpMsgStWorkArrList.Count; i++)
                {
                    PccCpMsgStWork pccMsgWorkEach = pccCpMsgStWorkArrList[i] as PccCpMsgStWork;
                    status = DeleteProcMsgEach(ref pccMsgWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    pccCpMsgStWorkArrListNew.Add(pccMsgWorkEach);

                }

                pccCpMsgStWorkList = pccCpMsgStWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "PccCpTgtStDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpTgtStDB.Delete Exception=" + ex.Message);
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
        /// PCCキャンペーンメッセージ設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCpMsgStWorkEach">PCCキャンペーンメッセージ設定マスタグループ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        private int DeleteProcMsgEach(ref PccCpMsgStWork pccCpMsgStWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  PCCCPMSGSTRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);

            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqotherEpcd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqotherSeccd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaCampaignCode = sqlCommand.Parameters.Add("@FINDCAMPAIGNCODE", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
            findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
            findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != pccCpMsgStWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM PCCCPMSGSTRF").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND CAMPAIGNCODERF = @FINDCAMPAIGNCODE").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqotherEpcd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherEpCd);
                findParaInqotherSeccd.Value = SqlDataMediator.SqlSetString(pccCpMsgStWorkEach.InqOtherSecCd);
                findParaCampaignCode.Value = SqlDataMediator.SqlSetInt32(pccCpMsgStWorkEach.CampaignCode);
            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                sqlCommand.Cancel();
                if (!myReader.IsClosed) myReader.Close();
                sqlConnection.Close();
                return status;
            }
            if (!myReader.IsClosed) myReader.Close();

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);
            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }
 
        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList)
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
                // トランザクション開始
                sqlTransaction = this.CreateSqlTransaction(sqlConnection);

                //PCCキャンペーン品目設定マスタ
                status = RevivalLogicalDeleteItmProc(ref pccCpItmStWorkList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // PCCキャンペーン対象設定マスタ
                    status = RevivalLogicalDeleteTgtProc(ref pccCpTgtStWorkList, ref sqlConnection, ref sqlTransaction);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //PCCキャンペーンメッセージ設定マスタ
                        status = RevivalLogicalDeleteMsgProc(ref pccCpMsgStWorkList, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "PccCpMsgStDB.RevivalLogicalDelete");
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
        /// PCCキャンペーン品目設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定マスタグループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteItmProc(ref object pccCpItmStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteItmProc(ref pccCpItmStWorkList, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// // PCCキャンペーン対象設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCpTgtStWorkList">// PCCキャンペーン対象設定マスタグループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteTgtProc(ref object pccCpTgtStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteTgtProc(ref pccCpTgtStWorkList, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        ///PCCキャンペーンメッセージ設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージ設定マスタグループデータリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.07.20</br>
        /// </remarks>
        public int RevivalLogicalDeleteMsgProc(ref object pccCpMsgStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteMsgProc(ref pccCpMsgStWorkList, 1, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// PCCキャンペーンメッセージ設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージマスタ設定データリスト</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.11</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object pccCpMsgStWorkList, ref object pccCpTgtStWorkList, ref object pccCpItmStWorkList, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            return status;
        }

        #endregion

        #region 内部処理
        /// <summary>
        /// PCCキャンペーンメッセージ設定取得処理
        /// </summary>
        /// <param name="myReader">PCCキャンペーンメッセージ設定Reader</param>
        /// <param name="pccCpMsgStWorkList">PCCキャンペーンメッセージ設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyPccCpMsgStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccCpMsgStWorkList)
        {
            pccCpMsgStWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //作成日時
            int colIndex_CreateDateTime = 0;
            //更新日時
            int colIndex_UpdateDateTime = 0;
            //論理削除区分
            int colIndex_LogicalDeleteCode = 0;
            //問合せ先企業コード
            int colIndex_InqOtherEpCd = 0;
            //問合せ先拠点コード
            int colIndex_InqOtherSecCd = 0;
            //キャンペーンコード
            int colIndex_CampaignCode = 0;
            //適用開始日
            int colIndex_ApplyStaDate = 0;
            //適用終了日
            int colIndex_ApplyEndDate = 0;
            //PCCメッセージ本文
            int colIndex_PccMsgDocCnts = 0;
            //キャンペーン名称
            int colIndex_CampaignName = 0;
            //キャンペーン対象区分
            int colIndex_CampaignObjDiv = 0;

            try
            {
                if (myReader.HasRows)
                {
                    //作成日時
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    //更新日時
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    //論理削除区分
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    //問合せ先企業コード
                    colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                    //問合せ先拠点コード
                    colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                    //キャンペーンコード
                    colIndex_CampaignCode = myReader.GetOrdinal("CAMPAIGNCODERF");
                    //適用開始日
                    colIndex_ApplyStaDate = myReader.GetOrdinal("APPLYSTADATERF");
                    //適用終了日
                    colIndex_ApplyEndDate = myReader.GetOrdinal("APPLYENDDATERF");
                    //PCCメッセージ本文
                    colIndex_PccMsgDocCnts = myReader.GetOrdinal("PCCMSGDOCCNTSRF");
                    //キャンペーン名称
                    colIndex_CampaignName = myReader.GetOrdinal("CAMPAIGNNAMERF");
                    //キャンペーン対象区分
                    colIndex_CampaignObjDiv = myReader.GetOrdinal("CAMPAIGNOBJDIVRF");
                }
                while (myReader.Read())
                {
                    PccCpMsgStWork pccCpMsgStWork = new PccCpMsgStWork();
                    //作成日時
                    pccCpMsgStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //更新日時
                    pccCpMsgStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //論理削除区分
                    pccCpMsgStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //問合せ先企業コード
                    pccCpMsgStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //問合せ先拠点コード
                    pccCpMsgStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //キャンペーンコード
                    pccCpMsgStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampaignCode);
                    //適用開始日
                    pccCpMsgStWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_ApplyStaDate);
                    //適用終了日
                    pccCpMsgStWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, colIndex_ApplyEndDate);
                    //PCCメッセージ本文
                    pccCpMsgStWork.PccMsgDocCnts = SqlDataMediator.SqlGetString(myReader, colIndex_PccMsgDocCnts);
                    //キャンペーン名称
                    pccCpMsgStWork.CampaignName = SqlDataMediator.SqlGetString(myReader, colIndex_CampaignName);
                    //キャンペーン対象区分
                    pccCpMsgStWork.CampaignObjDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampaignObjDiv);
                    pccCpMsgStWorkList.Add(pccCpMsgStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccCpMsgStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCCキャンペーン対象設定取得処理
        /// </summary>
        /// <param name="myReader">PCCキャンペーン対象設定Reader</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyPccCpTgtStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccCpTgtStWorkList)
        {
            pccCpTgtStWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //作成日時
            int colIndex_CreateDateTime = 0;
            //更新日時
            int colIndex_UpdateDateTime = 0;
            //論理削除区分
            int colIndex_LogicalDeleteCode = 0;
            //問合せ元企業コード
            int colIndex_InqOriginalEpCd = 0;
            //問合せ元拠点コード
            int colIndex_InqOriginalSecCd = 0;
            //問合せ先企業コード
            int colIndex_InqOtherEpCd = 0;
            //問合せ先拠点コード
            int colIndex_InqOtherSecCd = 0;
            //キャンペーンコード
            int colIndex_CampaignCode = 0;
            try
            {
                if (myReader.HasRows)
                {
                    //作成日時
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    //更新日時
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    //論理削除区分
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    //問合せ元企業コード
                    colIndex_InqOriginalEpCd = myReader.GetOrdinal("INQORIGINALEPCDRF");
                    //問合せ元拠点コード
                    colIndex_InqOriginalSecCd = myReader.GetOrdinal("INQORIGINALSECCDRF");
                    //問合せ先企業コード
                    colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                    //問合せ先拠点コード
                    colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                    //キャンペーンコード
                    colIndex_CampaignCode = myReader.GetOrdinal("CAMPAIGNCODERF");
                }
                while (myReader.Read())
                {
                    PccCpTgtStWork pccCpTgtStWork = new PccCpTgtStWork();
                    //作成日時
                    pccCpTgtStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //更新日時
                    pccCpTgtStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //論理削除区分
                    pccCpTgtStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //問合せ元企業コード
                    pccCpTgtStWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                    //問合せ元拠点コード
                    pccCpTgtStWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                    //問合せ先企業コード
                    pccCpTgtStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //問合せ先拠点コード
                    pccCpTgtStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //キャンペーンコード
                    pccCpTgtStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampaignCode);
                    pccCpTgtStWorkList.Add(pccCpTgtStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccCpTgtStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCCキャンペーン品目設定取得処理
        /// </summary>
        /// <param name="myReader">PCCキャンペーン品目設定Reader</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyPccCpItmStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccCpItmStWorkList)
        {
            pccCpItmStWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //作成日時
            int colIndex_CreateDateTime = 0;
            //更新日時
            int colIndex_UpdateDateTime = 0;
            //論理削除区分
            int colIndex_LogicalDeleteCode = 0;
            //問合せ先企業コード
            int colIndex_InqOtherEpCd = 0;
            //問合せ先拠点コード
            int colIndex_InqOtherSecCd = 0;
            //キャンペーンコード
            int colIndex_CampaignCode = 0;
            //キャンペーン設定区分
            int colIndex_CampStDiv = 0;
            //BL商品コード
            int colIndex_BLGoodsCode = 0;
            //商品番号
            int colIndex_GoodsNo = 0;
            //商品メーカーコード
            int colIndex_GoodsMakerCd = 0;
            //商品名称
            int colIndex_GoodsName = 0;
            //商品名称カナ
            int colIndex_GoodsNameKana = 0;
            //品目QTY
            int colIndex_ItemQty = 0;
            try
            {
                if (myReader.HasRows)
                {
                    //作成日時
                    colIndex_CreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
                    //更新日時
                    colIndex_UpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
                    //論理削除区分
                    colIndex_LogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
                    //問合せ先企業コード
                    colIndex_InqOtherEpCd = myReader.GetOrdinal("INQOTHEREPCDRF");
                    //問合せ先拠点コード
                    colIndex_InqOtherSecCd = myReader.GetOrdinal("INQOTHERSECCDRF");
                    //キャンペーンコード
                    colIndex_CampaignCode = myReader.GetOrdinal("CAMPAIGNCODERF");
                    //キャンペーン設定区分
                    colIndex_CampStDiv = myReader.GetOrdinal("CAMPSTDIVRF");
                    //BL商品コード
                    colIndex_BLGoodsCode = myReader.GetOrdinal("BLGOODSCODERF");
                    //商品番号
                    colIndex_GoodsNo = myReader.GetOrdinal("GOODSNORF");
                    //商品メーカーコード
                    colIndex_GoodsMakerCd = myReader.GetOrdinal("GOODSMAKERCDRF");
                    //商品名称
                    colIndex_GoodsName = myReader.GetOrdinal("GOODSNAMERF");
                    //商品名称カナ
                    colIndex_GoodsNameKana = myReader.GetOrdinal("GOODSNAMEKANARF");
                    //品目QTY
                    colIndex_ItemQty = myReader.GetOrdinal("ITEMQTYRF");
                }
                while (myReader.Read())
                {
                    PccCpItmStWork pccCpItmStWork = new PccCpItmStWork();
                    //作成日時
                    pccCpItmStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                    //更新日時
                    pccCpItmStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                    //論理削除区分
                    pccCpItmStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                    //問合せ先企業コード
                    pccCpItmStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                    //問合せ先拠点コード
                    pccCpItmStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                    //キャンペーンコード
                    pccCpItmStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampaignCode);
                    //キャンペーン設定区分
                    pccCpItmStWork.CampStDiv = SqlDataMediator.SqlGetInt32(myReader, colIndex_CampStDiv);
                    //BL商品コード
                    pccCpItmStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_BLGoodsCode);
                    //商品番号
                    pccCpItmStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsNo);
                    //商品メーカーコード
                    pccCpItmStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_GoodsMakerCd);
                    //商品名称
                    pccCpItmStWork.GoodsName = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsName);
                    //商品名称カナ
                    pccCpItmStWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsNameKana);
                    //品目QTY
                    pccCpItmStWork.ItemQty = SqlDataMediator.SqlGetInt32(myReader, colIndex_ItemQty);
                    pccCpItmStWorkList.Add(pccCpItmStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccCpItmStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        /// <summary>
        /// PCCキャンペーン設定取得処理
        /// </summary>
        /// <param name="myReader">PCCキャンペーン品目設定Reader</param>
        /// <param name="pccCpTgtStWorkList">PCCキャンペーン対象設定データリスト</param>
        /// <param name="pccCpItmStWorkList">PCCキャンペーン品目設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private int CopyMsgAndStWorkListFromReader(ref SqlDataReader myReader, ref ArrayList pccCpMsgStWorkList, ref ArrayList pccCpItmStWorkList)
        {
            pccCpItmStWorkList = new ArrayList();
            pccCpMsgStWorkList = new ArrayList();
            // --- UPD 2012/11/27 吉岡 2012/12/12配信分 システムテスト障害№83 --------->>>>>>>>>>>>>>>>>>>>>>>>
            // Dictionary<int, string> campaignCodeDic = new Dictionary<int, string>();
            Dictionary<string, string> campaignCodeDic = new Dictionary<string, string>();
            // --- UPD 2012/11/27 吉岡 2012/12/12配信分 システムテスト障害№83 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //作成日時
            int colIndexA_CreateDateTime = 0;
            //更新日時
            int colIndexA_UpdateDateTime = 0;
            //論理削除区分
            int colIndexA_LogicalDeleteCode = 0;
            //問合せ先企業コード
            int colIndexA_InqOtherEpCd = 0;
            //問合せ先拠点コード
            int colIndexA_InqOtherSecCd = 0;
            //キャンペーンコード
            int colIndexA_CampaignCode = 0;
            //適用開始日
            int colIndexA_ApplyStaDate = 0;
            //適用終了日
            int colIndexA_ApplyEndDate = 0;
            //PCCメッセージ本文
            int colIndexA_PccMsgDocCnts = 0;
            //キャンペーン名称
            int colIndexA_CampaignName = 0;
            //キャンペーン対象区分
            int colIndexA_CampaignObjDiv = 0;

            //作成日時
            int colIndexB_CreateDateTime = 0;
            //更新日時
            int colIndexB_UpdateDateTime = 0;
            //論理削除区分
            int colIndexB_LogicalDeleteCode = 0;
            //問合せ先企業コード
            int colIndexB_InqOtherEpCd = 0;
            //問合せ先拠点コード
            int colIndexB_InqOtherSecCd = 0;
            //キャンペーンコード
            int colIndexB_CampaignCode = 0;
            //キャンペーン設定区分
            int colIndexB_CampStDiv = 0;
            //BL商品コード
            int colIndexB_BLGoodsCode = 0;
            //商品番号
            int colIndexB_GoodsNo = 0;
            //商品メーカーコード
            int colIndexB_GoodsMakerCd = 0;
            //商品名称
            int colIndexB_GoodsName = 0;
            //商品名称カナ
            int colIndexB_GoodsNameKana = 0;
            //品目QTY
            int colIndexB_ItemQty = 0;
            try
            {
                if (myReader.HasRows)
                {
                    //作成日時
                    colIndexA_CreateDateTime = myReader.GetOrdinal("MSGSTCREATEDATETIMERF");
                    //更新日時
                    colIndexA_UpdateDateTime = myReader.GetOrdinal("MSGSTUPDATEDATETIMERF");
                    //論理削除区分
                    colIndexA_LogicalDeleteCode = myReader.GetOrdinal("MSGSTLOGICALDELETECODERF");
                    //問合せ先企業コード
                    colIndexA_InqOtherEpCd = myReader.GetOrdinal("MSGSTINQOTHEREPCDRF");
                    //問合せ先拠点コード
                    colIndexA_InqOtherSecCd = myReader.GetOrdinal("MSGSTINQOTHERSECCDRF");
                    //キャンペーンコード
                    colIndexA_CampaignCode = myReader.GetOrdinal("MSGSTCAMPAIGNCODERF");
                    //適用開始日
                    colIndexA_ApplyStaDate = myReader.GetOrdinal("MSGSTAPPLYSTADATERF");
                    //適用終了日
                    colIndexA_ApplyEndDate = myReader.GetOrdinal("MSGSTAPPLYENDDATERF");
                    //PCCメッセージ本文
                    colIndexA_PccMsgDocCnts = myReader.GetOrdinal("MSGSTPCCMSGDOCCNTSRF");
                    //キャンペーン名称
                    colIndexA_CampaignName = myReader.GetOrdinal("MSGSTCAMPAIGNNAMERF");
                    //キャンペーン対象区分
                    colIndexA_CampaignObjDiv = myReader.GetOrdinal("MSGSTCAMPAIGNOBJDIVRF");

                    //作成日時
                    colIndexB_CreateDateTime = myReader.GetOrdinal("ITMSTCREATEDATETIMERF");
                    //更新日時
                    colIndexB_UpdateDateTime = myReader.GetOrdinal("ITMSTUPDATEDATETIMERF");
                    //論理削除区分
                    colIndexB_LogicalDeleteCode = myReader.GetOrdinal("ITMSTLOGICALDELETECODERF");
                    //問合せ先企業コード
                    colIndexB_InqOtherEpCd = myReader.GetOrdinal("ITMSTINQOTHEREPCDRF");
                    //問合せ先拠点コード
                    colIndexB_InqOtherSecCd = myReader.GetOrdinal("ITMSTINQOTHERSECCDRF");
                    //キャンペーンコード
                    colIndexB_CampaignCode = myReader.GetOrdinal("ITMSTCAMPAIGNCODERF");
                    //キャンペーン設定区分
                    colIndexB_CampStDiv = myReader.GetOrdinal("ITMSTCAMPSTDIVRF");
                    //BL商品コード
                    colIndexB_BLGoodsCode = myReader.GetOrdinal("ITMSTBLGOODSCODERF");
                    //商品番号
                    colIndexB_GoodsNo = myReader.GetOrdinal("ITMSTGOODSNORF");
                    //商品メーカーコード
                    colIndexB_GoodsMakerCd = myReader.GetOrdinal("ITMSTGOODSMAKERCDRF");
                    //商品名称
                    colIndexB_GoodsName = myReader.GetOrdinal("ITMSTGOODSNAMERF");
                    //商品名称カナ
                    colIndexB_GoodsNameKana = myReader.GetOrdinal("ITMSTGOODSNAMEKANARF");
                    //品目QTY
                    colIndexB_ItemQty = myReader.GetOrdinal("ITEMQTYRF");
                }
                while (myReader.Read())
                {
                    PccCpMsgStWork pccCpMsgStWork = new PccCpMsgStWork();
                    //キャンペーンコード
                    pccCpMsgStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndexA_CampaignCode);
                    // --- UPD 2012/11/27 吉岡 2012/12/12配信分 システムテスト障害№83 --------->>>>>>>>>>>>>>>>>>>>>>>>
                    //問合せ先企業コード
                    pccCpMsgStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndexA_InqOtherEpCd);
                    //問合せ先拠点コード
                    pccCpMsgStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndexA_InqOtherSecCd);
                    // if (!campaignCodeDic.ContainsKey(pccCpMsgStWork.CampaignCode))
                    if (!campaignCodeDic.ContainsKey(pccCpMsgStWork.InqOtherEpCd + ',' + pccCpMsgStWork.InqOtherSecCd + ',' + pccCpMsgStWork.CampaignCode))
                    // --- UPD 2012/11/27 吉岡 2012/12/12配信分 システムテスト障害№83 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        //作成日時
                        pccCpMsgStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndexA_CreateDateTime);
                        //更新日時
                        pccCpMsgStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndexA_UpdateDateTime);
                        //論理削除区分
                        pccCpMsgStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndexA_LogicalDeleteCode);
                        // --- DEL 2012/11/27 吉岡 2012/12/12配信分 システムテスト障害№83 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        ////問合せ先企業コード
                        //pccCpMsgStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndexA_InqOtherEpCd);
                        ////問合せ先拠点コード
                        //pccCpMsgStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndexA_InqOtherSecCd);
                        // --- DEL 2012/11/27 吉岡 2012/12/12配信分 システムテスト障害№83 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                        //キャンペーンコード
                        pccCpMsgStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndexA_CampaignCode);
                        //適用開始日
                        pccCpMsgStWork.ApplyStaDate = SqlDataMediator.SqlGetInt32(myReader, colIndexA_ApplyStaDate);
                        //適用終了日
                        pccCpMsgStWork.ApplyEndDate = SqlDataMediator.SqlGetInt32(myReader, colIndexA_ApplyEndDate);
                        //PCCメッセージ本文
                        pccCpMsgStWork.PccMsgDocCnts = SqlDataMediator.SqlGetString(myReader, colIndexA_PccMsgDocCnts);
                        //キャンペーン名称
                        pccCpMsgStWork.CampaignName = SqlDataMediator.SqlGetString(myReader, colIndexA_CampaignName);
                        //キャンペーン対象区分
                        pccCpMsgStWork.CampaignObjDiv = SqlDataMediator.SqlGetInt32(myReader, colIndexA_CampaignObjDiv);
                        pccCpMsgStWorkList.Add(pccCpMsgStWork);
                        // --- UPD 2012/11/27 吉岡 2012/12/12配信分 システムテスト障害№83 --------->>>>>>>>>>>>>>>>>>>>>>>>
                        // campaignCodeDic.Add(pccCpMsgStWork.CampaignCode, pccCpMsgStWork.CampaignName);
                        campaignCodeDic.Add(pccCpMsgStWork.InqOtherEpCd + ',' + pccCpMsgStWork.InqOtherSecCd + ',' + pccCpMsgStWork.CampaignCode, pccCpMsgStWork.CampaignName);
                        // --- UPD 2012/11/27 吉岡 2012/12/12配信分 システムテスト障害№83 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    PccCpItmStWork pccCpItmStWork = new PccCpItmStWork();
                    //作成日時
                    pccCpItmStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndexB_CreateDateTime);
                    //更新日時
                    pccCpItmStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndexB_UpdateDateTime);
                    //論理削除区分
                    pccCpItmStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndexB_LogicalDeleteCode);
                    //問合せ先企業コード
                    pccCpItmStWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndexB_InqOtherEpCd);
                    //問合せ先拠点コード
                    pccCpItmStWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndexB_InqOtherSecCd);
                    //キャンペーンコード
                    pccCpItmStWork.CampaignCode = SqlDataMediator.SqlGetInt32(myReader, colIndexB_CampaignCode);
                    //キャンペーン設定区分
                    pccCpItmStWork.CampStDiv = SqlDataMediator.SqlGetInt32(myReader, colIndexB_CampStDiv);
                    //BL商品コード
                    pccCpItmStWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, colIndexB_BLGoodsCode);
                    //商品番号
                    pccCpItmStWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, colIndexB_GoodsNo);
                    //商品メーカーコード
                    pccCpItmStWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, colIndexB_GoodsMakerCd);
                    //商品名称
                    pccCpItmStWork.GoodsName = SqlDataMediator.SqlGetString(myReader, colIndexB_GoodsName);
                    //商品名称カナ
                    pccCpItmStWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, colIndexB_GoodsNameKana);
                    //品目QTY
                    pccCpItmStWork.ItemQty = SqlDataMediator.SqlGetInt32(myReader, colIndexB_ItemQty);
                    pccCpItmStWorkList.Add(pccCpItmStWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (pccCpItmStWorkList.Count == 0 && pccCpMsgStWorkList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "IPccItemGrpDB.Search");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }

        // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 内容が設定されているかチェック
        /// </summary>
        /// <param name="para">文字列</param>
        /// <returns>true:設定されている false:設定されていない</returns>
        private bool StringChk(string para)
        {
            if ((para == null) || (para.Trim() == "")) return false;

            return true;
        }
        // --- ADD 2012/11/07 三戸 2012/12/12配信分 SCM障害№10422 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

    }
}

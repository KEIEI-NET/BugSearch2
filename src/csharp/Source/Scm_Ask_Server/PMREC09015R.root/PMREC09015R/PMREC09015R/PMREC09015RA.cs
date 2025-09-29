//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : リコメンド商品関連設定マスタメンテ
// プログラム概要   : リコメンド商品関連設定マスタメンテDBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 作 成 日  2015.01.16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 作 成 日  2015.03.03  修正内容 : リモートの一部修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 松本 宏紀
// 作 成 日  2015.03.24  修正内容 : 品管redmine#3251の対応
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
    /// リコメンド商品関連設定マスタメンテリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : リコメンド商品関連設定マスタメンテの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 西 毅</br>
    /// <br>Date       : 2015.01.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RecGoodsLkDB : RemoteDB, IRecGoodsLkDB
    {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public RecGoodsLkDB()
            : base("PMREC09017D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkWork", "RECGOODSLKRF")
        {
        }

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
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
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        private SqlTransaction CreateSqlTransaction(SqlConnection sqlConnection)
        {
            SqlTransaction retSqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

            return retSqlTransaction;
        }
        #endregion  //トランザクション生成処理

        #region IRecGoodsLkDB メンバ

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int Write(ref object RecGoodsLkWorkList)
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
                // write実行
                status = WriteProc(ref RecGoodsLkWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecStDB.Write");
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
        /// リコメンド商品関連設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int WriteProc(ref object RecGoodsLkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;

            ArrayList RecGoodsLkWorkArrList = null;
            ArrayList RecGoodsLkWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (RecGoodsLkWorkList != null)
                {
                    RecGoodsLkWorkArrList = RecGoodsLkWorkList as ArrayList;

                }
                if (RecGoodsLkWorkArrList == null || RecGoodsLkWorkArrList.Count == 0)
                {
                    return status;
                }
                RecGoodsLkWorkArrListNew = new ArrayList();
                for (int i = 0; i < RecGoodsLkWorkArrList.Count; i++)
                {
                    RecGoodsLkWork RecGoodsLkWorkEach = RecGoodsLkWorkArrList[i] as RecGoodsLkWork;
                    status = this.WriteCmpnyStProcEach(ref RecGoodsLkWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    RecGoodsLkWorkArrListNew.Add(RecGoodsLkWorkEach);
                }

                RecGoodsLkWorkList = RecGoodsLkWorkArrListNew as object;
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecGoodsLkDB.Write", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Write");
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
        /// リコメンド商品関連設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkEach">リコメンド商品関連設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int WriteCmpnyStProcEach(ref RecGoodsLkWork RecGoodsLkWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //Selectコマンドの生成
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  RECGOODSLKRF").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.NChar);
            SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.NChar);
            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
            findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
            findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.RecDestBLGoodsCd;
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != RecGoodsLkWorkEach.UpdateDateTime)
                {
                    //新規登録で該当データ有りの場合には重複
                    if (RecGoodsLkWorkEach.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                    //既存データで更新日時違いの場合には排他
                    else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("     UPDATE RECGOODSLKRF SET CREATEDATETIMERF=@CREATEDATETIME ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       UPDATEDATETIMERF      =@UPDATEDATETIME ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       LOGICALDELETECODERF   =@LOGICALDELETECODE ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQORIGINALEPCDRF     =@INQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQORIGINALSECCDRF    =@INQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQOTHEREPCDRF        =@INQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       INQOTHERSECCDRF       =@INQOTHERSECCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       CUSTOMERCODERF        =@CUSTOMERCODE ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       RECSOURCEBLGOODSCDRF  =@RECSOURCEBLGOODSCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       RECDESTBLGOODSCDRF    =@RECDESTBLGOODSCD ").Append(Environment.NewLine);
                sqlTxt.Append(" ,       GOODSCOMMENTRF        =@GOODSCOMMENT ").Append(Environment.NewLine);


                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHEREPCDRF=@FINDINQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
                sqlTxt.Append("     AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();
                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
                findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.RecDestBLGoodsCd;

                //コネクション文字列取得対応↓↓↓↓↓
                //更新ヘッダ情報を設定
                RecGoodsLkWorkEach.UpdateDateTime = DateTime.Now;

            }
            else
            {
                //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                if (RecGoodsLkWorkEach.UpdateDateTime > DateTime.MinValue)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    myReader.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                //新規作成時のSQL文を生成
                sqlTxt.Append("     INSERT INTO RECGOODSLKRF ").Append(Environment.NewLine);
                sqlTxt.Append("      (CREATEDATETIMERF      ").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF      ").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF   ").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF     ").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF    ").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF        ").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , CUSTOMERCODERF        ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF  ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF    ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSNMRF    ").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF        ").Append(Environment.NewLine);
                sqlTxt.Append("    ) VALUES (@CREATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append("     , @UPDATEDATETIME       ").Append(Environment.NewLine);
                sqlTxt.Append("     , @LOGICALDELETECODE    ").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALEPCD      ").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQORIGINALSECCD     ").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHEREPCD         ").Append(Environment.NewLine);
                sqlTxt.Append("     , @INQOTHERSECCD        ").Append(Environment.NewLine);
                sqlTxt.Append("     , @CUSTOMERCODE         ").Append(Environment.NewLine);
                sqlTxt.Append("     , @RECSOURCEBLGOODSCD   ").Append(Environment.NewLine);
                sqlTxt.Append("     , @RECDESTBLGOODSCD     ").Append(Environment.NewLine);
                sqlTxt.Append("     , @RECDESTBLGOODSNM     ").Append(Environment.NewLine);
                sqlTxt.Append("     , @GOODSCOMMENT         ").Append(Environment.NewLine);
                sqlTxt.Append("     )").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //登録ヘッダ情報を設定
                RecGoodsLkWorkEach.UpdateDateTime = DateTime.Now;
                RecGoodsLkWorkEach.CreateDateTime = DateTime.Now;
                RecGoodsLkWorkEach.LogicalDeleteCode = 0;
            }
            if (!myReader.IsClosed) myReader.Close();
            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
            SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.NChar);
            SqlParameter paraRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCD", SqlDbType.NChar);
            SqlParameter paraRecDestBLGoodsCd = sqlCommand.Parameters.Add("@RECDESTBLGOODSCD", SqlDbType.NChar);
            SqlParameter paraRecDestBLGoodsNm = sqlCommand.Parameters.Add("@RECDESTBLGOODSNM", SqlDbType.NChar);
            SqlParameter paraGoodsComment = sqlCommand.Parameters.Add("@GOODSCOMMENT", SqlDbType.NChar);

            //Prameterオブジェクトの作成
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWorkEach.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWorkEach.UpdateDateTime);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.LogicalDeleteCode);
            paraInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
            paraInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
            paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
            paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
            paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.CustomerCode);
            paraRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.RecSourceBLGoodsCd);
            paraRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.RecDestBLGoodsCd);
            paraRecDestBLGoodsNm.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.RecDestBLGoodsNm);
            paraGoodsComment.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.GoodsComment);
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }


        /// <summary>
        /// リコメンド商品関連設定マスタメンテ検索処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="parseRecGoodsLkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int Search(out object RecGoodsLkWorkList, RecGoodsLkWork parseRecGoodsLkWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            RecGoodsLkWorkList = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchProc(out RecGoodsLkWorkList, parseRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Search");
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
        /// リコメンド商品関連設定マスタメンテ検索処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="parseRecGoodsLkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int SearchProc(out object RecGoodsLkWorkList, RecGoodsLkWork parseRecGoodsLkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CUSTOMERCODERF        ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF     ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSNMRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF           ").Append(Environment.NewLine);
                sqlTxt.Append("      FROM RECGOODSLKRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                //if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalEpCd))
                //{
                sqlTxt.Append("    INQORIGINALEPCDRF=@FINDINQORIGINALEPCD").Append(Environment.NewLine);
                // Prameterオブジェクトの作成
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                // Parameterオブジェクトへ値設定
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOriginalEpCd);
                //}
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalSecCd))
                {
                    if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalEpCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQORIGINALSECCDRF=@FINDINQORIGINALSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOriginalSecCd);
                }
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherEpCd))
                {
                    if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalEpCd) || !string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalSecCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQOTHEREPCDRF=@FINDINQOTHEREPCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherSecCd))
                {
                    if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalEpCd) || !string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalSecCd) || !string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherEpCd))
                    {
                        sqlTxt.Append(" AND ");
                    }
                    sqlTxt.Append(" INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOtherSecCd);
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
                sqlTxt.Append("  ORDER BY INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromSearch(myReader, out al);

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkDB.SearchProc", status);
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


            RecGoodsLkWorkList = al;

            return status;
        }

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ検索処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="parseRecGoodsLkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int SearchForBuyer(out object RecGoodsLkWorkList, RecGoodsLkWork parseRecGoodsLkWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            RecGoodsLkWorkList = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = SearchForBuyerProc(out RecGoodsLkWorkList, parseRecGoodsLkWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Search");
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
        /// リコメンド商品関連設定マスタメンテ検索処理。<br/>
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="parseRecGoodsLkWork">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// 購入者(CarpodTab)側で利用するインターフェースとなります。<br/>
        /// 購入者のキー情報となる連結元企業コードが必須条件となります。<br/>
        /// また企業拠点連結マスタで有効となる接続先における情報のみが返されます。
        /// <br>Programmer : 松本 宏紀</br>
        /// <br>Date       : 2015.02.22</br>
        /// </remarks>
        public int SearchForBuyerProc(out object RecGoodsLkWorkList, RecGoodsLkWork parseRecGoodsLkWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList al = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkWorkList = null;
            try
            {
                #region NOTE:レコメンド商品関連マスタ取得処理と展開処理について
                //write by 松本 宏紀
                //全得意先、全拠点設定における各接続元企業コード、拠点コードに展開する処理も合わせて1つのSQLで実行しています。
                //AP-DB通信量の肥大化を抑えるために、展開処理を別にすることも可能ですが、現状は予測がつかないのでこのままとしています。
                //負荷的な問題により、展開処理とレコメンド商品関連設定マスタ取得処理を分ける場合は、下記のようなSQLとなります。
                //SELECT
                //* --ちゃんと設定してね★
                //FROM RECGOODSLKRF        AS RECGOOD WITH(READUNCOMMITTED)
                //WHERE RECGOOD.LOGICALDELETECODERF = 0
                //  AND EXISTS (
                //     SELECT 1 
                //       FROM SCMEPCNECTRF        AS SUB01 WITH(READUNCOMMITTED)
                //       INNER JOIN SCMEPSCCNTRF  AS SUB02 WITH(READUNCOMMITTED)
                //         ON    SUB02.LOGICALDELETECODERF  = 0
                //           AND SUB02.DISCDIVCDRF          = 0
                //           AND SUB02.CNECTOTHEREPCDRF     = SUB01.CNECTOTHEREPCDRF 
                //           AND (SUB02.PCCUOECOMMMETHODRF  = 1 OR SUB02.SCMCOMMMETHODRF = 1)
                //           AND SUB02.CNECTORIGINALEPCDRF  = SUB01.CNECTORIGINALEPCDRF  
                //           AND (RECGOOD.INQORIGINALSECCDRF = '000000' OR SUB02.CNECTORIGINALSECCDRF = RECGOOD.INQORIGINALSECCDRF )
                //           AND (RECGOOD.INQOTHERSECCDRF = '00' OR SUB02.CNECTOTHERSECCDRF    = RECGOOD.INQOTHERSECCDRF)
                //      WHERE SUB01.LOGICALDELETECODERF = 0
                //        AND SUB01.DISCDIVCDRF         = 0
                //        AND SUB01.CNECTORIGINALEPCDRF = @FINDCNECTORIGINALEPCD
                //        AND SUB01.CNECTOTHEREPCDRF    = RECGOOD.INQOTHEREPCDRF
                //  )
                //;
                #endregion

                #region レコメンド商品関連設定マスタ
                #endregion
                StringBuilder sqlTxt = new StringBuilder(4096);
                sqlCommand = new SqlCommand(string.Empty, sqlConnection);
                sqlTxt.AppendLine(" SELECT * FROM (");
                sqlTxt.AppendLine("   SELECT ");
                sqlTxt.AppendLine("   RECGOOD.CREATEDATETIMERF     AS CREATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECGOOD.UPDATEDATETIMERF     AS UPDATEDATETIMERF, ");
                sqlTxt.AppendLine("   RECGOOD.LOGICALDELETECODERF  AS LOGICALDELETECODERF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTORIGINALEPCDRF  AS INQORIGINALEPCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTORIGINALSECCDRF AS INQORIGINALSECCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTOTHEREPCDRF     AS INQOTHEREPCDRF, ");
                sqlTxt.AppendLine("   EPSCCNT.CNECTOTHERSECCDRF    AS INQOTHERSECCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.CUSTOMERCODERF       AS CUSTOMERCODERF, ");
                sqlTxt.AppendLine("   RECGOOD.RECSOURCEBLGOODSCDRF AS RECSOURCEBLGOODSCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.RECDESTBLGOODSCDRF   AS RECDESTBLGOODSCDRF, ");
                sqlTxt.AppendLine("   RECGOOD.RECDESTBLGOODSNMRF   AS RECDESTBLGOODSNMRF, ");
                sqlTxt.AppendLine("   RECGOOD.GOODSCOMMENTRF       AS GOODSCOMMENTRF, ");
                sqlTxt.AppendLine("   ROW_NUMBER() OVER ( ");
                sqlTxt.AppendLine("     PARTITION BY EPSCCNT.CNECTORIGINALEPCDRF   ,EPSCCNT.CNECTORIGINALSECCDRF   ,EPSCCNT.CNECTOTHEREPCDRF   ,EPSCCNT.CNECTOTHERSECCDRF    ,RECGOOD.RECSOURCEBLGOODSCDRF,RECGOOD.RECDESTBLGOODSCDRF ");
                sqlTxt.AppendLine("     ORDER BY     RECGOOD.INQORIGINALEPCDRF DESC,RECGOOD.INQORIGINALSECCDRF DESC,RECGOOD.INQOTHEREPCDRF DESC,RECGOOD.INQOTHERSECCDRF DESC ,RECGOOD.RECSOURCEBLGOODSCDRF,RECGOOD.RECDESTBLGOODSCDRF DESC ");
                sqlTxt.AppendLine("   ) AS ROWNUM ");
                sqlTxt.AppendLine("   FROM RECGOODSLKRF        AS RECGOOD WITH(READUNCOMMITTED) ");
                sqlTxt.AppendLine("   INNER JOIN  SCMEPCNECTRF AS EPCNECT WITH(READUNCOMMITTED) ");
                sqlTxt.AppendLine("   ON    EPCNECT.LOGICALDELETECODERF = 0 ");
                sqlTxt.AppendLine("     AND EPCNECT.DISCDIVCDRF         = 0 ");
                sqlTxt.AppendLine("     AND EPCNECT.CNECTORIGINALEPCDRF = @FINDCNECTORIGINALEPCD ");
                sqlTxt.AppendLine("     AND EPCNECT.CNECTOTHEREPCDRF    = RECGOOD.INQOTHEREPCDRF ");
                sqlTxt.AppendLine("   INNER JOIN SCMEPSCCNTRF  AS EPSCCNT WITH(READUNCOMMITTED)  ");
                sqlTxt.AppendLine("   ON    EPSCCNT.LOGICALDELETECODERF  = 0 ");
                sqlTxt.AppendLine("     AND EPSCCNT.DISCDIVCDRF          = 0 ");
                #region ADD:2015.03.24 松本 宏紀 #3251 ------------------- >>>>>
                sqlTxt.AppendLine("      AND EPSCCNT.PMUPLOADDIVRF       = 1  ");
                sqlTxt.AppendLine("      AND ISNULL(EPSCCNT.PMDBIDRF,'') != ''");
                #endregion
                sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHEREPCDRF     = EPCNECT.CNECTOTHEREPCDRF  ");
                sqlTxt.AppendLine("     AND (EPSCCNT.PCCUOECOMMMETHODRF  = 1 OR EPSCCNT.SCMCOMMMETHODRF = 1) ");
                sqlTxt.AppendLine("     AND ( ");
                sqlTxt.AppendLine("           RECGOOD.INQORIGINALEPCDRF='0000000000000000' OR ");
                sqlTxt.AppendLine("          (EPSCCNT.CNECTORIGINALEPCDRF  = EPCNECT.CNECTORIGINALEPCDRF  AND EPSCCNT.CNECTORIGINALSECCDRF = RECGOOD.INQORIGINALSECCDRF ) ");
                sqlTxt.AppendLine("         ) ");
                sqlTxt.AppendLine("     AND (RECGOOD.INQOTHERSECCDRF='00' OR EPSCCNT.CNECTOTHERSECCDRF    = RECGOOD.INQOTHERSECCDRF) ");
                sqlTxt.AppendLine("     AND EPSCCNT.CNECTORIGINALEPCDRF = @FINDCNECTORIGINALEPCD  ");
                #region 検索条件設定＆Prameterオブジェクトの作成(接続元、先の企業拠点連結マスタ絞り込み
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDCNECTORIGINALEPCD", SqlDbType.NChar);//★必須条件
                findParaInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOriginalEpCd);

                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOriginalSecCd))//接続元拠点コード
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTORIGINALSECCDRF = @FINDCNECTORIGINALSECCD ");
                    SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDCNECTORIGINALSECCD", SqlDbType.NChar);
                    findParaInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOriginalSecCd);
                }
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherEpCd)) //接続先企業コード
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHEREPCDRF = @FINDCNECTOTHEREPCD ");
                    SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDCNECTOTHEREPCD", SqlDbType.NChar);
                    findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOtherEpCd);
                }
                if (!string.IsNullOrEmpty(parseRecGoodsLkWork.InqOtherSecCd)) //接続先拠点コード
                {
                    sqlTxt.AppendLine("     AND EPSCCNT.CNECTOTHERSECCDRF = @FINDCNECTOTHERSECCD");
                    SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDCNECTOTHERSECCD", SqlDbType.NChar);
                    findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(parseRecGoodsLkWork.InqOtherSecCd);
                }
                #endregion
                sqlTxt.AppendLine("   WHERE RECGOOD.INQOTHEREPCDRF     =  EPSCCNT.CNECTOTHEREPCDRF ");
                sqlTxt.AppendLine("     AND RECGOOD.INQOTHERSECCDRF    IN ('00',EPSCCNT.CNECTOTHERSECCDRF) ");
                sqlTxt.AppendLine("     AND RECGOOD.INQORIGINALEPCDRF  IN ('0000000000000000',EPSCCNT.CNECTORIGINALEPCDRF) ");
                sqlTxt.AppendLine("     AND RECGOOD.INQORIGINALSECCDRF IN ('000000',EPSCCNT.CNECTORIGINALSECCDRF) ");
                #region 検索条件設定＆Prameterオブジェクトの作成(レコメンド商品関連設定マスタでの絞り込み
                //論理削除区分
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlTxt.AppendLine("   AND RECGOOD.LOGICALDELETECODERF = @FINDLOGICALDELETECODE ");
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlTxt.AppendLine("   AND RECGOOD.LOGICALDELETECODERF< @FINDLOGICALDELETECODE ");
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                #endregion
                sqlTxt.AppendLine(" ) AS SUB01  ");
                sqlTxt.AppendLine(" WHERE SUB01.ROWNUM=1  ");
                sqlTxt.AppendLine(" ORDER BY   ");
                sqlTxt.AppendLine("     SUB01.INQORIGINALEPCDRF, ");
                sqlTxt.AppendLine("     SUB01.INQORIGINALSECCDRF, ");
                sqlTxt.AppendLine("     SUB01.INQOTHEREPCDRF, ");
                sqlTxt.AppendLine("     SUB01.INQOTHERSECCDRF, ");
                sqlTxt.AppendLine("     SUB01.RECSOURCEBLGOODSCDRF, ");
                sqlTxt.AppendLine("     SUB01.RECDESTBLGOODSCDRF ");
                sqlCommand.CommandText = sqlTxt.ToString();
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromSearch(myReader, out al);

                if (al.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkDB.SearchProc", status);
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

            RecGoodsLkWorkList = al;
            return status;
        }

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ検索処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int Read(ref object RecGoodsLkWorkList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref RecGoodsLkWorkList, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Read");
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
        /// リコメンド商品関連設定マスタメンテ検索処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int ReadProc(ref object RecGoodsLkWorkList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            RecGoodsLkWork wkRecGoodsLkWorkOld = null;
            RecGoodsLkWork wkRecGoodsLkWorkNew = null;
            ArrayList alOld = new ArrayList();
            if (RecGoodsLkWorkList != null)
            {
                wkRecGoodsLkWorkOld = RecGoodsLkWorkList as RecGoodsLkWork;
            }
            else
            {
                return status;
            }
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            RecGoodsLkWorkList = null;
            try
            {

                StringBuilder sqlTxt = new StringBuilder(string.Empty);
                sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection);
                sqlTxt.Append("     SELECT CREATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , UPDATEDATETIMERF").Append(Environment.NewLine);
                sqlTxt.Append("     , LOGICALDELETECODERF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALEPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQORIGINALSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHEREPCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , INQOTHERSECCDRF").Append(Environment.NewLine);
                sqlTxt.Append("     , CUSTOMERCODERF        ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECSOURCEBLGOODSCDRF     ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSCDRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , RECDESTBLGOODSNMRF       ").Append(Environment.NewLine);
                sqlTxt.Append("     , GOODSCOMMENTRF           ").Append(Environment.NewLine);
                sqlTxt.Append("      FROM RECGOODSLKRF WITH (READUNCOMMITTED)  ").Append(Environment.NewLine);
                sqlTxt.Append("     WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("     INQORIGINALEPCDRF=@FINDINQORIGINALEPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHEREPCDRF=@FINDINQOTHEREPCD ").Append(Environment.NewLine);
                sqlTxt.Append("     AND INQOTHERSECCDRF=@FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("     AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
                sqlTxt.Append("     AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD").Append(Environment.NewLine);

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

                //Prameterオブジェクトの作成
                SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = wkRecGoodsLkWorkOld.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = wkRecGoodsLkWorkOld.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(wkRecGoodsLkWorkOld.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(wkRecGoodsLkWorkOld.InqOtherSecCd);
                findParaRecSourceBLGoodsCd.Value = wkRecGoodsLkWorkOld.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = wkRecGoodsLkWorkOld.RecDestBLGoodsCd;
                //タイムアウト時間の設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);
                myReader = sqlCommand.ExecuteReader();
                status = CopyListFromRead(myReader, ref wkRecGoodsLkWorkNew);
                if (wkRecGoodsLkWorkNew == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "IRecGoodsLkDB.ReadProc", status);
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


            RecGoodsLkWorkList = wkRecGoodsLkWorkNew;

            return status;
        }

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int LogicalDelete(ref object RecGoodsLkWorkList)
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
                status = LogicalDeleteProc(ref RecGoodsLkWorkList, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.LogicalDelete");
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
        /// リコメンド商品関連設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int LogicalDeleteProc(ref object RecGoodsLkWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList RecGoodsLkWorkArrList = null;
            ArrayList RecGoodsLkWorkArrListNew = null;
            try
            {
                if (RecGoodsLkWorkList != null)
                {
                    RecGoodsLkWorkArrList = RecGoodsLkWorkList as ArrayList;

                }
                if (RecGoodsLkWorkArrList == null || RecGoodsLkWorkArrList.Count == 0)
                {
                    return status;
                }
                RecGoodsLkWorkArrListNew = new ArrayList();
                for (int i = 0; i < RecGoodsLkWorkArrList.Count; i++)
                {
                    RecGoodsLkWork RecGoodsLkWorkEach = RecGoodsLkWorkArrList[i] as RecGoodsLkWork;
                    status = LogicalDeleteProcCmpnyEach(ref RecGoodsLkWorkEach, procMode, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    RecGoodsLkWorkArrListNew.Add(RecGoodsLkWorkEach);


                }
                RecGoodsLkWorkList = RecGoodsLkWorkArrListNew as object;

            }
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecGoodsLkDB.LogicalDeleteProc", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.LogicalDeleteProc Exception=" + ex.Message);
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
        /// リコメンド商品関連設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkEach">リコメンド商品関連自社設定</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int LogicalDeleteProcCmpnyEach(ref RecGoodsLkWork RecGoodsLkWorkEach, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {
            int logicalDelCd = 0;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append(" ,LOGICALDELETECODERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  RECGOODSLKRF ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);

            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
            SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);


            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
            findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
            findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.InqOtherSecCd;
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();
            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                if (_updateDateTime != RecGoodsLkWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    return status;
                }
                //現在の論理削除区分を取得
                logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                sqlTxt.Append("UPDATE RECGOODSLKRF SET UPDATEDATETIMERF=@UPDATEDATETIME").Append(Environment.NewLine);
                sqlTxt.Append(" , LOGICALDELETECODERF=@LOGICALDELETECODE").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("      INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);

                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
                findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.InqOtherSecCd;

                //更新ヘッダ情報を設定
                //更新ヘッダ情報を設定
                RecGoodsLkWorkEach.UpdateDateTime = DateTime.Now;

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

                if (logicalDelCd == 0) RecGoodsLkWorkEach.LogicalDeleteCode = 1;//論理削除フラグをセット

            }
            else
            {
                if (logicalDelCd == 1) RecGoodsLkWorkEach.LogicalDeleteCode = 0;//論理削除フラグを解除

            }

            //Parameterオブジェクトの作成(更新用)

            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);

            //Parameterオブジェクトへ値設定(更新用)

            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWorkEach.LogicalDeleteCode);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWorkEach.UpdateDateTime);

            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.TransactionType.TransactionLimitCritical);

            sqlCommand.ExecuteNonQuery();

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// リコメンド商品関連設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int Delete(ref object RecGoodsLkWorkList)
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

                status = DeleteProc(ref RecGoodsLkWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Delete");
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
        /// リコメンド商品関連設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int DeleteProc(ref object RecGoodsLkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            ArrayList RecGoodsLkWorkArrList = null;
            ArrayList RecGoodsLkWorkArrListNew = null;
            SqlCommand sqlCommand = null;
            try
            {
                if (RecGoodsLkWorkList != null)
                {
                    RecGoodsLkWorkArrList = RecGoodsLkWorkList as ArrayList;

                }
                if (RecGoodsLkWorkArrList == null || RecGoodsLkWorkArrList.Count == 0)
                {
                    return status;
                }
                RecGoodsLkWorkArrListNew = new ArrayList();

                for (int i = 0; i < RecGoodsLkWorkArrList.Count; i++)
                {
                    RecGoodsLkWork RecGoodsLkWorkEach = RecGoodsLkWorkArrList[i] as RecGoodsLkWork;
                    status = DeleteProcCmpnyStEach(ref RecGoodsLkWorkEach, ref sqlConnection, ref sqlTransaction, ref sqlCommand, ref myReader);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    RecGoodsLkWorkArrListNew.Add(RecGoodsLkWorkEach);

                }

                RecGoodsLkWorkList = RecGoodsLkWorkArrListNew as object;
            }

            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, "RecGoodsLkDB.Delete", status);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Delete Exception=" + ex.Message);
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
        /// リコメンド商品関連設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="RecGoodsLkWorkEach">リコメンド商品関連設定グループ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="myReader">myReader</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        private int DeleteProcCmpnyStEach(ref RecGoodsLkWork RecGoodsLkWorkEach, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand, ref SqlDataReader myReader)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sqlTxt = new StringBuilder();
            sqlTxt.Append("SELECT").Append(Environment.NewLine);
            sqlTxt.Append("  UPDATEDATETIMERF").Append(Environment.NewLine);
            sqlTxt.Append("FROM").Append(Environment.NewLine);
            sqlTxt.Append("  RECGOODSLKRF ").Append(Environment.NewLine);
            sqlTxt.Append("WHERE").Append(Environment.NewLine);
            sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
            sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);
            sqlCommand = new SqlCommand(sqlTxt.ToString(), sqlConnection, sqlTransaction);


            //Prameterオブジェクトの作成
            SqlParameter findParaInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
            SqlParameter findParaInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
            SqlParameter findParaInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
            SqlParameter findParaRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
            SqlParameter findParaRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);
            //Parameterオブジェクトへ値設定
            findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
            findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
            findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
            findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
            findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
            findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.InqOtherSecCd;
            //タイムアウト時間の設定
            sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitRead);

            myReader = sqlCommand.ExecuteReader();

            if (myReader.Read())
            {
                //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                if (_updateDateTime != RecGoodsLkWorkEach.UpdateDateTime)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();
                    sqlConnection.Close();
                    return status;
                }
                sqlTxt = new StringBuilder();
                sqlTxt.Append("DELETE").Append(Environment.NewLine);
                sqlTxt.Append(" FROM RECGOODSLKRF ").Append(Environment.NewLine);
                sqlTxt.Append(" WHERE ").Append(Environment.NewLine);
                sqlTxt.Append("  INQORIGINALEPCDRF = @FINDINQORIGINALEPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQORIGINALSECCDRF = @FINDINQORIGINALSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHEREPCDRF = @FINDINQOTHEREPCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND INQOTHERSECCDRF = @FINDINQOTHERSECCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND RECSOURCEBLGOODSCDRF = @FINDRECSOURCEBLGOODSCD").Append(Environment.NewLine);
                sqlTxt.Append("  AND RECDESTBLGOODSCDRF = @FINDRECDESTBLGOODSCD").Append(Environment.NewLine);
                sqlCommand.CommandText = sqlTxt.ToString();

                //KEYコマンドを再設定
                findParaInqOriginalEpCd.Value = RecGoodsLkWorkEach.InqOriginalEpCd;
                findParaInqOriginalSecCd.Value = RecGoodsLkWorkEach.InqOriginalSecCd;
                findParaInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherEpCd);
                findParaInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWorkEach.InqOtherSecCd);
                findParaRecSourceBLGoodsCd.Value = RecGoodsLkWorkEach.RecSourceBLGoodsCd;
                findParaRecDestBLGoodsCd.Value = RecGoodsLkWorkEach.InqOtherSecCd;
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
        /// リコメンド商品関連設定マスタメンテ復活処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref object RecGoodsLkWorkList)
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
                status = RevivalLogicalDeleteProc(ref RecGoodsLkWorkList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.RevivalLogicalDelete");
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
        /// リコメンド商品関連設定マスタメンテ復活処理
        /// </summary>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="sqlTransaction">トランザクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        public int RevivalLogicalDeleteProc(ref object RecGoodsLkWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return LogicalDeleteProc(ref  RecGoodsLkWorkList, 1, ref sqlConnection, ref  sqlTransaction);
        }

        #endregion

        #region 内部処理
        /// <summary>
        /// リコメンド商品関連データ取得処理
        /// </summary>
        /// <param name="myReader">リコメンド商品関連設定データReader</param>
        /// <param name="RecGoodsLkWorkList">リコメンド商品関連設定データリスト</param>
        /// <returns>リコメンド商品関連設定データ</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        private int CopyListFromSearch(SqlDataReader myReader, out ArrayList RecGoodsLkWorkList)
        {
            RecGoodsLkWorkList = new ArrayList();
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
            //得意先コード
            int colIndex_CustomerCode = 0;
            //推奨元BL商品コード
            int colIndex_RecSourceBLGoodsCd = 0;
            //推奨先BL商品コード
            int colIndex_RecDestBLGoodsCd = 0;
            //推奨先BL商品コード名称
            int colIndex_RecDestBLGoodsNm = 0;
            //商品コメント
            int colIndex_GoodsComment = 0;
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
                //得意先コード
                colIndex_CustomerCode = myReader.GetOrdinal("CUSTOMERCODERF");
                //推奨元BL商品コード
                colIndex_RecSourceBLGoodsCd = myReader.GetOrdinal("RECSOURCEBLGOODSCDRF");
                //推奨先BL商品コード
                colIndex_RecDestBLGoodsCd = myReader.GetOrdinal("RECDESTBLGOODSCDRF");
                //推奨先BL商品コード名称
                colIndex_RecDestBLGoodsNm = myReader.GetOrdinal("RECDESTBLGOODSNMRF");
                //商品コメント
                colIndex_GoodsComment = myReader.GetOrdinal("GOODSCOMMENTRF");
            }
            while (myReader.Read())
            {

                RecGoodsLkWork RecGoodsLkWork = new RecGoodsLkWork();
                //作成日時	 
                RecGoodsLkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //更新日時	            
                RecGoodsLkWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //論理削除区分	            
                RecGoodsLkWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //問合せ元企業コード	            
                RecGoodsLkWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                //問合せ元拠点コード	            
                RecGoodsLkWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                //問合せ先企業コード	            
                RecGoodsLkWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                //問合せ先拠点コード	            
                RecGoodsLkWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                //得意先コード
                RecGoodsLkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CustomerCode);
                //推奨元BL商品コード
                RecGoodsLkWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecSourceBLGoodsCd);
                //推奨先BL商品コード
                RecGoodsLkWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecDestBLGoodsCd);
                //推奨先BL商品コード名称
                RecGoodsLkWork.RecDestBLGoodsNm = SqlDataMediator.SqlGetString(myReader, colIndex_RecDestBLGoodsNm);
                //商品コメント
                RecGoodsLkWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsComment);

                RecGoodsLkWorkList.Add(RecGoodsLkWork);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }

        /// <summary>
        /// リコメンド商品関連設定データ取得処理
        /// </summary>
        /// <param name="myReader">リコメンド商品関連設定データReader</param>
        /// <param name="RecGoodsLkWork">リコメンド商品関連設定データ</param>
        /// <returns>リコメンド商品関連設定データ</returns>
        /// <remarks>
        /// <br>Programmer : 西 毅</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        private int CopyListFromRead(SqlDataReader myReader, ref RecGoodsLkWork RecGoodsLkWork)
        {
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
            //得意先コード
            int colIndex_CustomerCode = 0;
            //推奨元BL商品コード
            int colIndex_RecSourceBLGoodsCd = 0;
            //推奨先BL商品コード
            int colIndex_RecDestBLGoodsCd = 0;
            //推奨先BL商品コード名称
            int colIndex_RecDestBLGoodsNm = 0;
            //商品コメント
            int colIndex_GoodsComment = 0;
            if (myReader.HasRows)
            {
                RecGoodsLkWork = new RecGoodsLkWork();
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
                //得意先コード
                colIndex_CustomerCode = myReader.GetOrdinal("CUSTOMERCODERF");
                //推奨元BL商品コード
                colIndex_RecSourceBLGoodsCd = myReader.GetOrdinal("RECSOURCEBLGOODSCDRF");
                //推奨先BL商品コード
                colIndex_RecDestBLGoodsCd = myReader.GetOrdinal("RECDESTBLGOODSCDRF");
                //推奨先BL商品コード名称
                colIndex_RecDestBLGoodsNm = myReader.GetOrdinal("RECDESTBLGOODSNMRF");
                //商品コメント
                colIndex_GoodsComment = myReader.GetOrdinal("GOODSCOMMENTRF");

            }
            if (myReader.Read())
            {

                //作成日時	 
                RecGoodsLkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_CreateDateTime);
                //更新日時	            
                RecGoodsLkWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, colIndex_UpdateDateTime);
                //論理削除区分	            
                RecGoodsLkWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_LogicalDeleteCode);
                //問合せ元企業コード	            
                RecGoodsLkWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalEpCd);
                //問合せ元拠点コード	            
                RecGoodsLkWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOriginalSecCd);
                //問合せ先企業コード	            
                RecGoodsLkWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherEpCd);
                //問合せ先拠点コード	            
                RecGoodsLkWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, colIndex_InqOtherSecCd);
                //得意先コード
                RecGoodsLkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, colIndex_CustomerCode);
                //推奨元BL商品コード
                RecGoodsLkWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecSourceBLGoodsCd);
                //推奨先BL商品コード
                RecGoodsLkWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, colIndex_RecDestBLGoodsCd);
                //推奨先BL商品コード名称
                RecGoodsLkWork.RecDestBLGoodsNm = SqlDataMediator.SqlGetString(myReader, colIndex_RecDestBLGoodsNm);
                //商品コメント
                RecGoodsLkWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, colIndex_GoodsComment);

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }


        #endregion

        // --- ADD 2015/01/22 T.Miyamoto ------------------------------------------------------------------------------------------------------------------->>>>>
        #region 【SearchRcmd処理】
        /// <summary>
        /// 指定された条件のリコメンド商品関連設定マスタ情報LISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">エラーmsg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のリコメンド商品関連設定マスタLISTを全て戻します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        /// </remarks>
        public int SearchRcmd(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            try
            {
                return SearchProcRcmd(out retobj, paraobj, readMode, logicalMode, out count, ref errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Search");
                retobj = new ArrayList();
                count = 0;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
        }
        #endregion

        #region 【SearchProcRcmd】
        /// <summary>
        /// 指定された条件のリコメンド商品関連設定マスタ情報LISTを全て戻します
        /// </summary>
        /// <param name="retobj">検索結果</param>
        /// <param name="paraobj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="count">count</param>
        /// <param name="errMsg">エラーmsg</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のリコメンド商品関連設定マスタLISTを全て戻します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        /// </remarks>
        private int SearchProcRcmd(out object retobj, object paraobj, int readMode, ConstantManagement.LogicalMode logicalMode, out int count, ref string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            RecGoodsLkWork RecGoodsLkWork = null;

            retobj = null;
            count = 0;
            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                RecGoodsLkWork = paraobj as RecGoodsLkWork;

                //SQL文生成
                sqlConnection.Open();

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += " CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += ", UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += ", LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += ", INQORIGINALEPCDRF" + Environment.NewLine;
                selectTxt += ", INQORIGINALSECCDRF" + Environment.NewLine;
                selectTxt += ", INQOTHEREPCDRF" + Environment.NewLine;
                selectTxt += ", INQOTHERSECCDRF" + Environment.NewLine;
                selectTxt += ", CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += ", RECSOURCEBLGOODSCDRF" + Environment.NewLine;
                selectTxt += ", RECDESTBLGOODSCDRF" + Environment.NewLine;
                selectTxt += ", RECDESTBLGOODSNMRF" + Environment.NewLine;
                selectTxt += ", GOODSCOMMENTRF" + Environment.NewLine;
                selectTxt += " FROM RECGOODSLKRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt += this.MakeWhereString(ref sqlCommand, RecGoodsLkWork, logicalMode);

                selectTxt += " ORDER BY" + Environment.NewLine;
                selectTxt += " INQOTHERSECCDRF" + Environment.NewLine;
                selectTxt += ", CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += ", RECSOURCEBLGOODSCDRF" + Environment.NewLine;
                selectTxt += ", RECDESTBLGOODSCDRF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    if (al.Count == 20000)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        retobj = al;
                        count = 20001;
                        return status;
                    }
                    RecGoodsLkWork = this.CopyToRecGoodsLkWorkFromReader(ref myReader);

                    al.Add(RecGoodsLkWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                errMsg = ex.ToString();
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (!myReader.IsClosed) myReader.Close();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            retobj = al;
            return status;
        }
        #endregion

        # region -- クラスメンバーコピー処理 --
        /// <summary>
        /// リコメンド商品関連設定マスタマスタクラス格納処理 Reader → RecGoodsLkWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RecGoodsLkWork</returns>
        /// <remarks>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/22</br>
        /// </remarks>
        private RecGoodsLkWork CopyToRecGoodsLkWorkFromReader(ref SqlDataReader myReader)
        {
            RecGoodsLkWork RecGoodsLkWork = new RecGoodsLkWork();

            #region クラスへ格納
            RecGoodsLkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            RecGoodsLkWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            RecGoodsLkWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            RecGoodsLkWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            RecGoodsLkWork.InqOriginalEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALEPCDRF"));
            RecGoodsLkWork.InqOriginalSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQORIGINALSECCDRF"));
            RecGoodsLkWork.InqOtherEpCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHEREPCDRF"));
            RecGoodsLkWork.InqOtherSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INQOTHERSECCDRF"));
            RecGoodsLkWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            RecGoodsLkWork.RecSourceBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECSOURCEBLGOODSCDRF"));
            RecGoodsLkWork.RecDestBLGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECDESTBLGOODSCDRF"));
            RecGoodsLkWork.RecDestBLGoodsNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RECDESTBLGOODSNMRF"));
            RecGoodsLkWork.GoodsComment = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSCOMMENTRF"));
            #endregion

            return RecGoodsLkWork;
        }
        #endregion

        #region 【WHERE文作成】
        private string MakeWhereString(ref SqlCommand sqlCommand, RecGoodsLkWork RecGoodsLkWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE文作成
            string retstring = string.Empty;
            retstring = " WHERE" + Environment.NewLine;

            //論理削除区分
            retstring += " LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);

            //問合せ元企業コード
            if (RecGoodsLkWork.InqOriginalEpCd.Trim() != string.Empty)
            {
                retstring += " AND INQORIGINALEPCDRF=@INQORIGINALEPCD" + Environment.NewLine;
                SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
            }

            //問合せ元拠点コード
            if (RecGoodsLkWork.InqOriginalSecCd.Trim() != string.Empty)
            {
                retstring += " AND INQORIGINALSECCDRF=@INQORIGINALSECCD" + Environment.NewLine;
                SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
            }

            //問合せ先企業コード
            if (RecGoodsLkWork.InqOtherEpCd.Trim() != string.Empty)
            {
                retstring += " AND INQOTHEREPCDRF=@INQOTHEREPCD" + Environment.NewLine;
                SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
            }

            //問合せ先拠点コード
            if (RecGoodsLkWork.InqOtherSecCd.Trim() != string.Empty)
            {
                // --- UPD 2015/03/03 T.Nishi -----<<<<<
                //retstring += " AND (INQOTHERSECCDRF=@INQOTHERSECCD OR INQOTHERSECCDRF=@INQOTHERSECCDALL)" + Environment.NewLine;
                retstring += " AND (INQOTHERSECCDRF=@INQOTHERSECCD)" + Environment.NewLine;
                // --- UPD 2015/03/03 T.Nishi -----<<<<<
                SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                // --- DEL 2015/03/03 T.Nishi -----<<<<<
                //SqlParameter paraInqOtherSecCdAll = sqlCommand.Parameters.Add("@INQOTHERSECCDALL", SqlDbType.NChar);
                //paraInqOtherSecCdAll.Value = SqlDataMediator.SqlSetString("00");
                // --- DEL 2015/03/03 T.Nishi -----<<<<<
            }

            //得意先コード
            if (RecGoodsLkWork.CustomerCode != 0)
            {
                retstring += " AND CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.CustomerCode);
            }

            //推奨元BL商品コード（開始）
            if (RecGoodsLkWork.RecSourceBLGoodsCdSt != 0)
            {
                retstring += " AND RECSOURCEBLGOODSCDRF>=@RECSOURCEBLGOODSCDST" + Environment.NewLine;
                SqlParameter paraRecSourceBLGoodsCdSt = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCDST", SqlDbType.Int);
                paraRecSourceBLGoodsCdSt.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.RecSourceBLGoodsCdSt);
            }
            //推奨元BL商品コード（終了）
            if (RecGoodsLkWork.RecSourceBLGoodsCdEd != 0)
            {
                retstring += " AND RECSOURCEBLGOODSCDRF<=@RECSOURCEBLGOODSCDED" + Environment.NewLine;
                SqlParameter paraRecSourceBLGoodsCdEd = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCDED", SqlDbType.Int);
                paraRecSourceBLGoodsCdEd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.RecSourceBLGoodsCdEd);
            }
            #endregion
            return retstring;
        }
        #endregion

        #region 【削除・更新処理】
        /// <summary>
        /// リコメンド商品関連設定マスタを論理削除と登録、更新します
        /// </summary>
        /// <param name="paraDelObj">削除用RecGoodsLkWorkオブジェクト</param>
        /// <param name="paraUpdObj">更新用RecGoodsLkWorkオブジェクト</param>
        /// <param name="errorObj">RecGoodsLkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リコメンド商品関連設定マスタを論理削除と登録、更新します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        public int DeleteAndWrite(object paraDelObj, ref object paraUpdObj, out object errorObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            errorObj = null;
            ArrayList delList = null;
            ArrayList updList = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction();

                delList = paraDelObj as ArrayList;
                updList = paraUpdObj as ArrayList;

                foreach (RecGoodsLkWork RecGoodsLkWork in delList)
                {
                    object paraObj = RecGoodsLkWork as object;
                    status = this.DeleteProcRcmd(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }
                }


                foreach (RecGoodsLkWork RecGoodsLkWork in updList)
                {
                    object paraObj = RecGoodsLkWork as object;
                    if (RecGoodsLkWork.LogicalDeleteCode == 0)
                    {
                        status = this.ReadDBBeforeSave(ref paraObj, ref sqlConnection, ref sqlTransaction);
                        if (status != 0)
                        {
                            errorObj = paraObj;
                            return status;
                        }

                        status = this.WriteProcRcmd(ref paraObj, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        status = this.LogicalDeleteProcRcmd(ref paraObj, 0, ref sqlConnection, ref sqlTransaction);
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        errorObj = null;
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.DeleteAndWrite");
                errorObj = null;
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
                            //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                            //synchExecuteMng.SyncReqExecute();
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
        #endregion

        #region 【完全削除・復活処理】
        /// <summary>
        /// リコメンド商品関連設定マスタを完全削除、復活します
        /// </summary>
        /// <param name="paraDelObj">削除用RecGoodsLkWorkオブジェクト</param>
        /// <param name="paraUpdObj">更新用RecGoodsLkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : リコメンド商品関連設定マスタを完全削除、復活します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        public int DeleteAndRevival(object paraDelObj, ref object paraUpdObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList delList = null;
            ArrayList updList = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                sqlTransaction = sqlConnection.BeginTransaction();

                delList = paraDelObj as ArrayList;
                updList = paraUpdObj as ArrayList;

                foreach (RecGoodsLkWork RecGoodsLkWork in delList)
                {
                    object paraObj = RecGoodsLkWork as object;
                    status = this.DeleteProcRcmd(paraObj, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }

                foreach (RecGoodsLkWork RecGoodsLkWork in updList)
                {
                    object paraObj = RecGoodsLkWork as object;
                    status = this.LogicalDeleteProcRcmd(ref paraObj, 1, ref sqlConnection, ref sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.DeleteAndWrite");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
                            //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                            //synchExecuteMng.SyncReqExecute();
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
        #endregion

        #region 【WriteRcmd処理】
        /// <summary>
        /// リコメンド商品関連設定マスタを登録、更新します
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リコメンド商品関連設定マスタを登録、更新します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int WriteRcmd(ref object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                status = WriteProc(ref paraobj, ref sqlConnection, ref sqlTransaction);
                //status = this.WriteProcRcmd(ref paraobj, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Write", status);
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
                            //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                            //synchExecuteMng.SyncReqExecute();
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
        #endregion

        #region 【WriteProcRcmd】
        /// <summary>
        /// リコメンド商品関連設定マスタを登録、更新します
        /// </summary>
        /// <param name="paraobj">RecGoodsLkWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リコメンド商品関連設定マスタを登録、更新します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        private int WriteProcRcmd(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        // コネクション生成
                        sqlConnection = CreateSqlConnection();
                        if (sqlConnection == null) return status;

                        sqlConnection.Open();
                    }

                    RecGoodsLkWork RecGoodsLkWork = paraobj as RecGoodsLkWork;

                    //Selectコマンドの生成
                    using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, CUSTOMERCODERF, RECSOURCEBLGOODSCDRF, RECDESTBLGOODSCDRF, RECDESTBLGOODSNMRF, GOODSCOMMENTRF FROM RECGOODSLKRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD", sqlConnection))
                    {

                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        //Prameterオブジェクトの作成
                        SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                        SqlParameter findRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                        findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                        findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                        findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                        findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                        findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != RecGoodsLkWork.UpdateDateTime)
                            {
                                //新規登録で該当データ有りの場合には重複
                                if (RecGoodsLkWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //既存データで更新日時違いの場合には排他
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }
                            sqlCommand.CommandText = "UPDATE RECGOODSLKRF SET CREATEDATETIMERF=@CREATEDATETIME, UPDATEDATETIMERF=@UPDATEDATETIME, LOGICALDELETECODERF=@LOGICALDELETECODE, INQORIGINALEPCDRF=@INQORIGINALEPCD, INQORIGINALSECCDRF=@INQORIGINALSECCD, INQOTHEREPCDRF=@INQOTHEREPCD, INQOTHERSECCDRF=@INQOTHERSECCD, CUSTOMERCODERF=@CUSTOMERCODE, RECSOURCEBLGOODSCDRF=@RECSOURCEBLGOODSCD, RECDESTBLGOODSCDRF=@RECDESTBLGOODSCD, RECDESTBLGOODSNMRF=@RECDESTBLGOODSNM, GOODSCOMMENTRF=@GOODSCOMMENT WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD";

                            //////更新ヘッダ情報を設定
                            ////object obj = (object)this;
                            ////IFileHeader flhd = (IFileHeader)campaignObjGoodsStWork;
                            ////FileHeader fileHeader = new FileHeader(obj);
                            ////fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (RecGoodsLkWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();
                                sqlConnection.Close();
                                return status;
                            }

                            RecGoodsLkWork.UpdateDateTime = DateTime.Now;
                            RecGoodsLkWork.CreateDateTime = DateTime.Now;
                            //新規作成時のSQL文を生成
                            sqlCommand.CommandText = "INSERT INTO RECGOODSLKRF (CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, CUSTOMERCODERF, RECSOURCEBLGOODSCDRF, RECDESTBLGOODSCDRF, RECDESTBLGOODSNMRF, GOODSCOMMENTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @LOGICALDELETECODE, @INQORIGINALEPCD, @INQORIGINALSECCD, @INQOTHEREPCD, @INQOTHERSECCD, @CUSTOMERCODE, @RECSOURCEBLGOODSCD, @RECDESTBLGOODSCD, @RECDESTBLGOODSNM, @GOODSCOMMENT)";
                            //////登録ヘッダ情報を設定
                            ////object obj = (object)this;
                            ////IFileHeader flhd = (IFileHeader)campaignObjGoodsStWork;
                            ////FileHeader fileHeader = new FileHeader(obj);
                            ////fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        //Prameterオブジェクトの作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraInqOriginalEpCd = sqlCommand.Parameters.Add("@INQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter paraInqOriginalSecCd = sqlCommand.Parameters.Add("@INQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter paraInqOtherEpCd = sqlCommand.Parameters.Add("@INQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter paraInqOtherSecCd = sqlCommand.Parameters.Add("@INQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@RECSOURCEBLGOODSCD", SqlDbType.Int);
                        SqlParameter paraRecDestBLGoodsCd = sqlCommand.Parameters.Add("@RECDESTBLGOODSCD", SqlDbType.Int);
                        SqlParameter paraRecDestBLGoodsNm = sqlCommand.Parameters.Add("@RECDESTBLGOODSNM", SqlDbType.NVarChar);
                        SqlParameter paraGoodsComment = sqlCommand.Parameters.Add("@GOODSCOMMENT", SqlDbType.NVarChar);

                        //Parameterオブジェクトへ値設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWork.UpdateDateTime);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.LogicalDeleteCode);
                        paraInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd);
                        paraInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd);
                        paraInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd);
                        paraInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.CustomerCode);
                        paraRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.RecSourceBLGoodsCd);
                        paraRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.RecDestBLGoodsCd);
                        paraRecDestBLGoodsNm.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.RecDestBLGoodsNm);
                        paraGoodsComment.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.GoodsComment);

                        sqlCommand.ExecuteNonQuery();

                        paraobj = RecGoodsLkWork as object;

                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Write");
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }

            return status;
        }
        #endregion

        #region 【DeleteRcmd処理】
        /// <summary>
        /// リコメンド商品関連設定マスタを物理削除します
        /// </summary>
        /// <param name="paraobj">リコメンド商品関連設定マスタオブジェクト</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : リコメンド商品関連設定マスタを物理削除します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int DeleteRcmd(object paraobj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;

            try
            {
                // コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;

                sqlConnection.Open();

                status = this.DeleteProcRcmd(paraobj, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Delete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
                            //SynchExecuteMngDB synchExecuteMng = new SynchExecuteMngDB();
                            //synchExecuteMng.SyncReqExecute();
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
        /// リコメンド商品関連設定マスタを物理削除します
        /// </summary>
        /// <param name="paraobj">リコメンド商品関連設定マスタオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : リコメンド商品関連設定マスタを物理削除します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int DeleteProcRcmd(object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        // コネクション生成
                        sqlConnection = CreateSqlConnection();
                        if (sqlConnection == null) return status;

                        sqlConnection.Open();
                    }

                    RecGoodsLkWork RecGoodsLkWork = paraobj as RecGoodsLkWork;

                    using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, CUSTOMERCODERF, RECSOURCEBLGOODSCDRF, RECDESTBLGOODSCDRF, RECDESTBLGOODSNMRF, GOODSCOMMENTRF FROM RECGOODSLKRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD", sqlConnection))
                    {
                        if (sqlTransaction != null)
                        {
                            sqlCommand.Transaction = sqlTransaction;
                        }

                        //Prameterオブジェクトの作成
                        SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                        SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                        SqlParameter findInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                        SqlParameter findInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                        SqlParameter findRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                        SqlParameter findRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                        findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                        findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                        findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                        findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                        findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                            if (_updateDateTime != RecGoodsLkWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                if (sqlCommand != null)
                                {
                                    sqlCommand.Cancel();
                                    sqlCommand.Dispose();
                                }
                                if (!myReader.IsClosed) myReader.Close();

                                return status;
                            }

                            sqlCommand.CommandText = "DELETE FROM RECGOODSLKRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD";
                            //Parameterオブジェクトへ値設定
                            findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                            findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                            findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                            findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                            findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                            findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);
                        }
                        else
                        {
                            //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            if (sqlCommand != null)
                            {
                                sqlCommand.Cancel();
                                sqlCommand.Dispose();
                            }
                            if (!myReader.IsClosed) myReader.Close();

                            return status;
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        sqlCommand.ExecuteNonQuery();
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(ex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.Delete");
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion

        #region 【LogicalDeleteRcmd処理】
        /// <summary>
        /// リコメンド商品関連設定マスタを論理削除します
        /// </summary>
        /// <param name="paraobj">UOEConnectInfoWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リコメンド商品関連設定マスタを論理削除します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int LogicalDeleteRcmd(ref object paraobj)
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

                status = LogicalDeleteProcRcmd(ref paraobj, 0, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLk.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region 【RevivalLogicalDeleteRcmd処理】
        /// <summary>
        /// 論理削除リコメンド商品関連設定マスタを復活します
        /// </summary>
        /// <param name="paraobj">CampaignMngWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 論理削除リコメンド商品関連設定マスタを復活します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        public int RevivalLogicalDeleteRcmd(ref object paraobj)
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

                status = LogicalDeleteProcRcmd(ref paraobj, 1, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLk.LogicalDelete");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        #region 【LogicalDeleteProcRcmd】
        /// <summary>
        /// リコメンド商品関連設定マスタの論理削除を操作します
        /// </summary>
        /// <param name="paraobj">CampaignMngWorkオブジェクト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リコメンド商品関連設定マスタの論理削除を操作します</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        private int LogicalDeleteProcRcmd(ref object paraobj, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                if (sqlConnection == null)
                {
                    // コネクション生成
                    sqlConnection = CreateSqlConnection();
                    if (sqlConnection == null) return status;

                    sqlConnection.Open();
                }

                RecGoodsLkWork RecGoodsLkWork = paraobj as RecGoodsLkWork;

                using (sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, LOGICALDELETECODERF, INQORIGINALEPCDRF, INQORIGINALSECCDRF, INQOTHEREPCDRF, INQOTHERSECCDRF, CUSTOMERCODERF, RECSOURCEBLGOODSCDRF, RECDESTBLGOODSCDRF, RECDESTBLGOODSNMRF, GOODSCOMMENTRF FROM RECGOODSLKRF WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD", sqlConnection))
                {
                    if (sqlTransaction != null)
                    {
                        sqlCommand.Transaction = sqlTransaction;
                    }

                    //Prameterオブジェクトの作成
                    SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                    SqlParameter findRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                    findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                    findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                    findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                    findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                    findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF")); //更新日時
                        if (_updateDateTime != RecGoodsLkWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

                            if (sqlCommand != null)
                            {
                                sqlCommand.Cancel();
                                sqlCommand.Dispose();
                            }
                            if (!myReader.IsClosed) myReader.Close();

                            return status;
                        }
                        //現在の論理削除区分を取得
                        logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                        sqlCommand.CommandText = "UPDATE RECGOODSLKRF SET UPDATEDATETIMERF=@UPDATEDATETIME, LOGICALDELETECODERF=@LOGICALDELETECODE WHERE INQORIGINALEPCDRF=@FINDINQORIGINALEPCD AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD AND INQOTHEREPCDRF=@FINDINQOTHEREPCD AND INQOTHERSECCDRF=@FINDINQOTHERSECCD AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD";
                        //Parameterオブジェクトへ値設定
                        findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                        findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                        findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                        findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                        findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                        findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                    }
                    else
                    {
                        //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;

                        if (sqlCommand != null)
                        {
                            sqlCommand.Cancel();
                            sqlCommand.Dispose();
                        }
                        if (!myReader.IsClosed) myReader.Close();

                        return status;
                    }
                    sqlCommand.Cancel();
                    if (!myReader.IsClosed) myReader.Close();

                    //論理削除モードの場合
                    if (procMode == 0)
                    {
                        if (logicalDelCd == 0) RecGoodsLkWork.LogicalDeleteCode = 1; //論理削除フラグをセット
                        else                   RecGoodsLkWork.LogicalDeleteCode = 3; //完全削除フラグをセット
                    }
                    else
                    {
                        if (logicalDelCd == 1) RecGoodsLkWork.LogicalDeleteCode = 0; //論理削除フラグを解除
                        else
                        {
                            if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //既に復活している場合はそのまま正常を戻す
                            else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; //完全削除はデータなしを戻す
                            sqlCommand.Cancel();
                            if (!myReader.IsClosed) myReader.Close();
                            sqlConnection.Close();
                            return status;
                        }
                    }

                    RecGoodsLkWork.UpdateDateTime = DateTime.Now;

                    //Parameterオブジェクトの作成(更新用)
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定(更新用)
                    paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(RecGoodsLkWork.UpdateDateTime);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(RecGoodsLkWork.LogicalDeleteCode);

                    sqlCommand.ExecuteNonQuery();

                    paraobj = RecGoodsLkWork as RecGoodsLkWork;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }

            return status;

        }
        #endregion

        #region 【ReadDBBeforeSave処理】
        /// <summary>
        /// リコメンド商品関連設定マスタを登録、更新前、重複レコードの存在チェックを行う
        /// </summary>
        /// <param name="paraobj">CampaignMngWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : リコメンド商品関連設定マスタを登録、更新前、重複レコードの存在チェックを行う</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/23</br>
        /// </remarks>
        private int ReadDBBeforeSave(ref object paraobj, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                try
                {
                    if (sqlConnection == null)
                    {
                        // コネクション生成
                        sqlConnection = CreateSqlConnection();
                        if (sqlConnection == null) return status;

                        sqlConnection.Open();
                    }

                    RecGoodsLkWork RecGoodsLkWork = paraobj as RecGoodsLkWork;
                    string selectTxt = string.Empty;

                    selectTxt += "SELECT " + Environment.NewLine;
                    selectTxt += " CREATEDATETIMERF" + Environment.NewLine;
                    selectTxt += ", UPDATEDATETIMERF" + Environment.NewLine;
                    selectTxt += ", LOGICALDELETECODERF" + Environment.NewLine;
                    selectTxt += ", INQORIGINALEPCDRF" + Environment.NewLine;
                    selectTxt += ", INQORIGINALSECCDRF" + Environment.NewLine;
                    selectTxt += ", INQOTHEREPCDRF" + Environment.NewLine;
                    selectTxt += ", INQOTHERSECCDRF" + Environment.NewLine;
                    selectTxt += ", CUSTOMERCODERF" + Environment.NewLine;
                    selectTxt += ", RECSOURCEBLGOODSCDRF" + Environment.NewLine;
                    selectTxt += ", RECDESTBLGOODSCDRF" + Environment.NewLine;
                    selectTxt += ", RECDESTBLGOODSNMRF" + Environment.NewLine;
                    selectTxt += ", GOODSCOMMENTRF" + Environment.NewLine;
                    selectTxt += " FROM RECGOODSLKRF" + Environment.NewLine;
                    selectTxt += " WHERE" + Environment.NewLine;
                    selectTxt += " INQORIGINALEPCDRF=@FINDINQORIGINALEPCD" + Environment.NewLine;
                    selectTxt += " AND INQORIGINALSECCDRF=@FINDINQORIGINALSECCD" + Environment.NewLine;
                    selectTxt += " AND INQOTHEREPCDRF=@FINDINQOTHEREPCD" + Environment.NewLine;
                    selectTxt += " AND INQOTHERSECCDRF=@FINDINQOTHERSECCD" + Environment.NewLine;
                    selectTxt += " AND RECSOURCEBLGOODSCDRF=@FINDRECSOURCEBLGOODSCD" + Environment.NewLine;
                    selectTxt += " AND RECDESTBLGOODSCDRF=@FINDRECDESTBLGOODSCD" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                    sqlCommand.Transaction = sqlTransaction;

                    //Prameterオブジェクトの作成
                    SqlParameter findInqOriginalEpCd = sqlCommand.Parameters.Add("@FINDINQORIGINALEPCD", SqlDbType.NChar);
                    SqlParameter findInqOriginalSecCd = sqlCommand.Parameters.Add("@FINDINQORIGINALSECCD", SqlDbType.NChar);
                    SqlParameter findInqOtherEpCd = sqlCommand.Parameters.Add("@FINDINQOTHEREPCD", SqlDbType.NChar);
                    SqlParameter findInqOtherSecCd = sqlCommand.Parameters.Add("@FINDINQOTHERSECCD", SqlDbType.NChar);
                    SqlParameter findRecSourceBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECSOURCEBLGOODSCD", SqlDbType.Int);
                    SqlParameter findRecDestBLGoodsCd = sqlCommand.Parameters.Add("@FINDRECDESTBLGOODSCD", SqlDbType.Int);

                    //Parameterオブジェクトへ値設定
                    findInqOriginalEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalEpCd.Trim());
                    findInqOriginalSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOriginalSecCd.Trim());
                    findInqOtherEpCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherEpCd.Trim());
                    findInqOtherSecCd.Value = SqlDataMediator.SqlSetString(RecGoodsLkWork.InqOtherSecCd.Trim());
                    findRecSourceBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecSourceBLGoodsCd);
                    findRecDestBLGoodsCd.Value = SqlDataMediator.SqlSetInt(RecGoodsLkWork.RecDestBLGoodsCd);

                    sqlCommand.CommandText = selectTxt;

                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        return status;
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException sqlex)
                {
                    //基底クラスに例外を渡して処理してもらう
                    status = base.WriteSQLErrorLog(sqlex);
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RecGoodsLkDB.ReadDBBeforeSave", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader.IsClosed == false) myReader.Close();
            }
            return status;
        }
        #endregion
        // --- ADD 2015/01/22 T.Miyamoto -------------------------------------------------------------------------------------------------------------------<<<<<
    }
}

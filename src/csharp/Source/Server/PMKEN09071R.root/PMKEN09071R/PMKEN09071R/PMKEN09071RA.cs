//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   結合マスタ(ユーザー登録)DBリモートオブジェクト
//                  :   PMKEN09071R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.11
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 結合マスタ(ユーザー登録)DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 結合マスタ(ユーザー登録)の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/28 30517 夏野 駿希</br>
    /// <br>             Mantis:14923 結合マスタ処理時にエラー発生する件の修正</br>
    /// </remarks>
    [Serializable]
    public class JoinPartsUDB : RemoteWithAppLockDB, IJoinPartsUDB
    {
        /// <summary>
        /// 結合マスタ(ユーザー登録)DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public JoinPartsUDB() : base("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork", "JOINPARTSURF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の結合マスタ(ユーザー登録)情報を取得します。
        /// </summary>
        /// <param name="joinPartsUObj">JoinPartsUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する結合マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref object joinPartsUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                JoinPartsUWork joinPartsUWork = joinPartsUObj as JoinPartsUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref joinPartsUWork, readMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// 単一の結合マスタ(ユーザー登録)情報を取得します。
        /// </summary>
        /// <param name="joinPartsUWork">JoinPartsUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する結合マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref JoinPartsUWork joinPartsUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref joinPartsUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の結合マスタ(ユーザー登録)情報を取得します。
        /// </summary>
        /// <param name="joinPartsUWork">JoinPartsUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する結合マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int ReadProc(ref JoinPartsUWork joinPartsUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   JOINP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,JOINP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURCEMAKERCODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNOWITHHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNONONEHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS JOINSOURGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS JOINSOURMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM JOINPARTSURF AS JOINP" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURPARTSNOWITHHRF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "WHERE JOINP.ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINP.JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINP.JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINP.JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINP.JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToJoinPartsUWorkFromReader(ref myReader, ref joinPartsUWork, 0);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion

        # region [Delete]
        /// <summary>
        /// 結合マスタ(ユーザー登録)情報を物理削除します
        /// </summary>
        /// <param name="joinPartsUList">物理削除する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する結合マスタ(ユーザー登録)情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(object joinPartsUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = joinPartsUList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// 結合マスタ(ユーザー登録)情報を物理削除します
        /// </summary>
        /// <param name="joinPartsUList">結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList に格納されている結合マスタ(ユーザー登録)情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(ArrayList joinPartsUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(joinPartsUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報を物理削除します
        /// </summary>
        /// <param name="joinPartsUList">結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList に格納されている結合マスタ(ユーザー登録)情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int DeleteProc(ArrayList joinPartsUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (joinPartsUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < joinPartsUList.Count; i++)
                    {
                        JoinPartsUWork joinPartsUWork = joinPartsUList[i] as JoinPartsUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  JOINPARTSURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != joinPartsUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  JOINPARTSURF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                            findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                            findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);

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

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion

        # region [Search]
        /// <summary>
        /// 結合マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="joinPartsUList">検索結果</param>
        /// <param name="joinPartsUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する、全ての結合マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref object joinPartsUList, object joinPartsUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList joinPartsUArray = joinPartsUList as ArrayList;
                JoinPartsUWork joinPartsUWork = joinPartsUObj as JoinPartsUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref joinPartsUArray, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// 結合マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="joinPartsUList">結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="joinPartsUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する、全ての結合マスタ(ユーザー登録)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref ArrayList joinPartsUList, JoinPartsUWork joinPartsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref joinPartsUList, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="joinPartsUList">結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="joinPartsUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する、全ての結合マスタ(ユーザー登録)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int SearchProc(ref ArrayList joinPartsUList, JoinPartsUWork joinPartsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   JOINP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,JOINP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURCEMAKERCODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNOWITHHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNONONEHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS JOINSOURGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS JOINSOURMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM JOINPARTSURF AS JOINP" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURPARTSNOWITHHRF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSD.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERD.LOGICALDELETECODERF=0" + Environment.NewLine;
                
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, joinPartsUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    joinPartsUList.Add(this.CopyToJoinPartsUWorkFromReader(ref myReader ,0));
                }

                if (joinPartsUList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion

        // 2010/01/28 Add >>>
        # region [SearchMstDel]
        /// <summary>
        /// 結合マスタ(ユーザー登録)情報のリストを検索件数分取得します。
        /// </summary>
        /// <param name="joinPartsUList">検索結果</param>
        /// <param name="joinPartsUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="searchCnt">検索件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する、全ての結合マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int SearchMstDel(ref object joinPartsUList, object joinPartsUObj, int readMode, ConstantManagement.LogicalMode logicalMode, int searchCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList joinPartsUArray = joinPartsUList as ArrayList;
                JoinPartsUWork joinPartsUWork = joinPartsUObj as JoinPartsUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchMstDel(ref joinPartsUArray, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, searchCnt);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
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
        /// 結合マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="joinPartsUList">結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="joinPartsUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="searchCnt">検索件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する、全ての結合マスタ(ユーザー登録)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/01/28</br>
        public int SearchMstDel(ref ArrayList joinPartsUList, JoinPartsUWork joinPartsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,int searchCnt)
        {
            // 検索件数が0以下なら全て取得
            if (searchCnt <= 0)
                return this.SearchProc(ref joinPartsUList, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            else
                return this.SearchMstDelProc(ref joinPartsUList, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, searchCnt);
        }

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="joinPartsUList">結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="joinPartsUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="searchCnt">検索件数</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ(ユーザー登録)のキー値が一致する、全ての結合マスタ(ユーザー登録)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/01/28</br>
        private int SearchMstDelProc(ref ArrayList joinPartsUList, JoinPartsUWork joinPartsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int searchCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT TOP " + searchCnt + Environment.NewLine;
                sqlText += "   JOINP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,JOINP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURCEMAKERCODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNOWITHHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNONONEHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS JOINSOURGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS JOINSOURMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM JOINPARTSURF AS JOINP" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURPARTSNOWITHHRF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSD.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERD.LOGICALDELETECODERF=0" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString2(ref sqlCommand, joinPartsUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    joinPartsUList.Add(this.CopyToJoinPartsUWorkFromReader(ref myReader, 0));
                }

                if (joinPartsUList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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
        # endregion
        // 2010/01/28 Add <<<

        # region [Write]
        /// <summary>
        /// 結合マスタ(ユーザー登録)情報を追加・更新します。
        /// </summary>
        /// <param name="joinPartsUList">追加・更新する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList に格納されている結合マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref object joinPartsUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = joinPartsUList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write実行
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// <br>結合マスタ情報を登録、更新します</br>
        /// <br>同一親品番、メーカーコードのデータをいったんDELETEし、新規で内容を登録します</br>
        /// </summary>
        /// <param name="joinPartsUWork">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="joinSourceMakerCode">親メーカーコード</param>
        /// <param name="joinSourPartsNoWithH">親商品セットコード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref object joinPartsUWork, string enterpriseCode, Int32 joinSourceMakerCode, string joinSourPartsNoWithH)
        {
            return this.WriteProc(ref joinPartsUWork, enterpriseCode, joinSourceMakerCode, joinSourPartsNoWithH);
        }

        /// <summary>
        /// <br>結合マスタ情報を登録、更新します</br>
        /// <br>同一親品番、メーカーコードのデータをいったんDELETEし、新規で内容を登録します</br>
        /// </summary>
        /// <param name="joinPartsUWork">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="joinSourceMakerCode">親メーカーコード</param>
        /// <param name="joinSourPartsNoWithH">親商品セットコード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 結合マスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int WriteProc(ref object joinPartsUWork, string enterpriseCode, Int32 joinSourceMakerCode, string joinSourPartsNoWithH)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = joinPartsUWork as ArrayList;
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //DELETE & INSERT でWrite実行
                status = DeleteInsert(ref paraList, enterpriseCode, joinSourceMakerCode, joinSourPartsNoWithH, ref sqlConnection, ref sqlTransaction);

                //戻り値セット
                joinPartsUWork = paraList;
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// 結合マスタ(ユーザー登録)情報を追加・更新します。
        /// </summary>
        /// <param name="joinPartsUList">追加・更新する結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList に格納されている結合マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref ArrayList joinPartsUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (joinPartsUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < joinPartsUList.Count; i++)
                    {
                        JoinPartsUWork joinPartsUWork = joinPartsUList[i] as JoinPartsUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  JOINPARTSURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != joinPartsUWork.UpdateDateTime)
                            {
                                if (joinPartsUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = string.Empty;
                            sqlText = "UPDATE JOINPARTSURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , JOINDISPORDERRF=@JOINDISPORDER , JOINSOURCEMAKERCODERF=@JOINSOURCEMAKERCODE , JOINSOURPARTSNOWITHHRF=@JOINSOURPARTSNOWITHH , JOINSOURPARTSNONONEHRF=@JOINSOURPARTSNONONEH , JOINDESTMAKERCDRF=@JOINDESTMAKERCD , JOINDESTPARTSNORF=@JOINDESTPARTSNO , JOINQTYRF=@JOINQTY , JOINSPECIALNOTERF=@JOINSPECIALNOTE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                            findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                            findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)joinPartsUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (joinPartsUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO JOINPARTSURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, JOINDISPORDERRF, JOINSOURCEMAKERCODERF, JOINSOURPARTSNOWITHHRF, JOINSOURPARTSNONONEHRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, JOINSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @JOINDISPORDER, @JOINSOURCEMAKERCODE, @JOINSOURPARTSNOWITHH, @JOINSOURPARTSNONONEH, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @JOINSPECIALNOTE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)joinPartsUWork;
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
                        SqlParameter paraJoinDispOrder = sqlCommand.Parameters.Add("@JOINDISPORDER", SqlDbType.Int);
                        SqlParameter paraJoinSourceMakerCode = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODE", SqlDbType.Int);
                        SqlParameter paraJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        SqlParameter paraJoinSourPartsNoNoneH = sqlCommand.Parameters.Add("@JOINSOURPARTSNONONEH", SqlDbType.NVarChar);
                        SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                        SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
                        SqlParameter paraJoinSpecialNote = sqlCommand.Parameters.Add("@JOINSPECIALNOTE", SqlDbType.NVarChar);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(joinPartsUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.LogicalDeleteCode);
                        paraJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDispOrder);
                        paraJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        paraJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        paraJoinSourPartsNoNoneH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoNoneH);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);
                        paraJoinQty.Value = SqlDataMediator.SqlSetDouble(joinPartsUWork.JoinQty);
                        paraJoinSpecialNote.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSpecialNote);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(joinPartsUWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            joinPartsUList = al;

            return status;
        }

        /// <summary>
        /// 親品番、メーカーを指定してデータをDELETEし、その後INSERTします
        /// </summary>
        /// <param name="joinPartsUWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="JoinSourceMakerCode">親メーカーコード</param>
        /// <param name="JoinSourPartsNoWithH">親品番</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList に格納されている結合マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int DeleteInsert(ref ArrayList joinPartsUWorkList, string enterpriseCode, Int32 JoinSourceMakerCode, string JoinSourPartsNoWithH, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteInsertProc(ref joinPartsUWorkList, enterpriseCode, JoinSourceMakerCode, JoinSourPartsNoWithH, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 親品番、メーカーを指定してデータをDELETEし、その後INSERTします
        /// </summary>
        /// <param name="joinPartsUWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="JoinSourceMakerCode">親メーカーコード</param>
        /// <param name="JoinSourPartsNoWithH">親品番</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList に格納されている結合マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int DeleteInsertProc(ref ArrayList joinPartsUWorkList, string enterpriseCode, Int32 JoinSourceMakerCode, string JoinSourPartsNoWithH, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string sqlText = string.Empty;
            
            try
            {
                if (joinPartsUWorkList != null)
                {
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  JOINPARTSURF" + Environment.NewLine;
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                    SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(JoinSourceMakerCode);
                    findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(JoinSourPartsNoWithH);

                    sqlCommand.ExecuteNonQuery();

                    //新規作成時のSQL文を生成
                    sqlText = string.Empty;
                    sqlText = "INSERT INTO JOINPARTSURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, JOINDISPORDERRF, JOINSOURCEMAKERCODERF, JOINSOURPARTSNOWITHHRF, JOINSOURPARTSNONONEHRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, JOINSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @JOINDISPORDER, @JOINSOURCEMAKERCODE, @JOINSOURPARTSNOWITHH, @JOINSOURPARTSNONONEH, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @JOINSPECIALNOTE)";
                    
                    sqlCommand.CommandText = sqlText;

                    #region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraJoinDispOrder = sqlCommand.Parameters.Add("@JOINDISPORDER", SqlDbType.Int);
                    SqlParameter paraJoinSourceMakerCode = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODE", SqlDbType.Int);
                    SqlParameter paraJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                    SqlParameter paraJoinSourPartsNoNoneH = sqlCommand.Parameters.Add("@JOINSOURPARTSNONONEH", SqlDbType.NVarChar);
                    SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
                    SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                    SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
                    SqlParameter paraJoinSpecialNote = sqlCommand.Parameters.Add("@JOINSPECIALNOTE", SqlDbType.NVarChar);
                    #endregion

                    for (int i = 0; i < joinPartsUWorkList.Count; i++)
                    {
                        JoinPartsUWork joinPartsUWork = joinPartsUWorkList[i] as JoinPartsUWork;

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)joinPartsUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(joinPartsUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.LogicalDeleteCode);
                        paraJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDispOrder);
                        paraJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        paraJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        paraJoinSourPartsNoNoneH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoNoneH);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);
                        paraJoinQty.Value = SqlDataMediator.SqlSetDouble(joinPartsUWork.JoinQty);
                        paraJoinSpecialNote.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSpecialNote);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(joinPartsUWork);
                    }
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
            }

            return status;
        }
        
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 結合マスタ(ユーザー登録)情報を論理削除します。
        /// </summary>
        /// <param name="joinPartsUList">論理削除する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork に格納されている結合マスタ(ユーザー登録)情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref object joinPartsUList)
        {
            return this.LogicalDelete(ref joinPartsUList, 0);
        }

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報の論理削除を解除します。
        /// </summary>
        /// <param name="joinPartsUList">論理削除を解除する結合マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork に格納されている結合マスタ(ユーザー登録)情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int RevivalLogicalDelete(ref object joinPartsUList)
        {
            return this.LogicalDelete(ref joinPartsUList, 1);
        }

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報の論理削除を操作します。
        /// </summary>
        /// <param name="joinPartsUList">論理削除を操作する結合マスタ(ユーザー登録)情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork に格納されている結合マスタ(ユーザー登録)情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDelete(ref object joinPartsUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = joinPartsUList as ArrayList;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
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
        /// 結合マスタ(ユーザー登録)情報の論理削除を操作します。
        /// </summary>
        /// <param name="joinPartsUList">論理削除を操作する結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork に格納されている結合マスタ(ユーザー登録)情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref ArrayList joinPartsUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref joinPartsUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 結合マスタ(ユーザー登録)情報の論理削除を操作します。
        /// </summary>
        /// <param name="joinPartsUList">論理削除を操作する結合マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork に格納されている結合マスタ(ユーザー登録)情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDeleteProc(ref ArrayList joinPartsUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (joinPartsUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < joinPartsUList.Count; i++)
                    {
                        JoinPartsUWork joinPartsUWork = joinPartsUList[i] as JoinPartsUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  JOINPARTSURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != joinPartsUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  JOINPARTSURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                            findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                            findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)joinPartsUWork;
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

                        // 論理削除モードの場合
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // 既に削除済みの場合正常
                                return status;
                            }
                            else if (logicalDelCd == 0) joinPartsUWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else joinPartsUWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                joinPartsUWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // 既に復活している場合はそのまま正常を戻す
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // 完全削除はデータなしを戻す
                                }

                                return status;
                            }
                        }

                        // Parameterオブジェクトの作成(更新用)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定(更新用)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(joinPartsUWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            joinPartsUList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="joinPartsUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, JoinPartsUWork joinPartsUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  JOINP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND JOINP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND JOINP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            
            //親メーカーコード
            if (joinPartsUWork.JoinSourceMakerCode != 0)
            {
                retstring += "AND JOINP.JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE " + Environment.NewLine;
                SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
            }
            
            //親品番
            if (string.IsNullOrEmpty(joinPartsUWork.JoinSourPartsNoWithH) == false)
            {
                retstring += "AND JOINP.JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH " + Environment.NewLine;
                SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
            }
            
            //子メーカーコード
            if (joinPartsUWork.JoinDestMakerCd != 0)
            {
                retstring += "AND JOINP.JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD " + Environment.NewLine;
                SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
            }
            
            //子品番
            if (string.IsNullOrEmpty(joinPartsUWork.JoinDestPartsNo) == false)
            {
                retstring += "AND JOINP.JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO " + Environment.NewLine;
                SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);
                findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);
            }

            retstring += "ORDER BY JOINP.ENTERPRISECODERF, JOINP.JOINDISPORDERRF, JOINP.JOINSOURCEMAKERCODERF, JOINP.JOINSOURPARTSNOWITHHRF, JOINP.JOINDESTMAKERCDRF, JOINP.JOINDESTPARTSNORF";
            
            return retstring;
        }

        // 2010/01/28 Add >>>
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="joinPartsUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 30517 夏野 駿希</br>
        /// <br>Date       : 2010/01/28</br>
        private string MakeWhereString2(ref SqlCommand sqlCommand, JoinPartsUWork joinPartsUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  JOINP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND JOINP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND JOINP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            if (joinPartsUWork.JoinSourceMakerCode != 0 &&
                string.IsNullOrEmpty(joinPartsUWork.JoinSourPartsNoWithH) == false &&
                joinPartsUWork.JoinDestMakerCd != 0 &&
                string.IsNullOrEmpty(joinPartsUWork.JoinDestPartsNo) == false)
            {
                //親メーカーコード
                retstring += "AND (( JOINP.JOINSOURCEMAKERCODERF>@SEARCHJOINSOURCEMAKERCODE ) " + Environment.NewLine;
                SqlParameter searchParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@SEARCHJOINSOURCEMAKERCODE", SqlDbType.Int);
                searchParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                //親品番
                retstring += "OR ( JOINP.JOINSOURCEMAKERCODERF=@SEARCHJOINSOURCEMAKERCODE AND JOINP.JOINSOURPARTSNOWITHHRF>@SEARCHJOINSOURPARTSNOWITHH ) " + Environment.NewLine;
                SqlParameter searchParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@SEARCHJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                searchParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                //子メーカーコード
                retstring += "OR ( JOINP.JOINSOURCEMAKERCODERF=@SEARCHJOINSOURCEMAKERCODE AND JOINP.JOINSOURPARTSNOWITHHRF=@SEARCHJOINSOURPARTSNOWITHH AND JOINP.JOINDESTMAKERCDRF>@SEARCHJOINDESTMAKERCD ) " + Environment.NewLine;
                SqlParameter searchParaJoinDestMakerCd = sqlCommand.Parameters.Add("@SEARCHJOINDESTMAKERCD", SqlDbType.Int);
                searchParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                //子品番
                retstring += "OR ( JOINP.JOINSOURCEMAKERCODERF=@SEARCHJOINSOURCEMAKERCODE AND JOINP.JOINSOURPARTSNOWITHHRF=@SEARCHJOINSOURPARTSNOWITHH AND JOINP.JOINDESTMAKERCDRF=@SEARCHJOINDESTMAKERCD AND JOINP.JOINDESTPARTSNORF>@SEARCHJOINDESTPARTSNO )) " + Environment.NewLine;
                SqlParameter searchParaJoinDestPartsNo = sqlCommand.Parameters.Add("@SEARCHJOINDESTPARTSNO", SqlDbType.NVarChar);
                searchParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);
            }

            retstring += "ORDER BY JOINP.ENTERPRISECODERF, JOINP.JOINSOURCEMAKERCODERF, JOINP.JOINSOURPARTSNOWITHHRF, JOINP.JOINDESTMAKERCDRF, JOINP.JOINDESTPARTSNORF";

            return retstring;
        }
        // 2010/01/28 Add <<<
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → JoinPartsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">mode</param>
        /// <returns>JoinPartsUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private JoinPartsUWork CopyToJoinPartsUWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            JoinPartsUWork joinPartsUWork = new JoinPartsUWork();

            this.CopyToJoinPartsUWorkFromReader(ref myReader, ref joinPartsUWork, mode);

            return joinPartsUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → JoinPartsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="joinPartsUWork">JoinPartsUWork オブジェクト</param>
        /// <param name="mode">mode</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private void CopyToJoinPartsUWorkFromReader(ref SqlDataReader myReader, ref JoinPartsUWork joinPartsUWork, int mode)
        {
            if (myReader != null && joinPartsUWork != null)
            {
                # region クラスへ格納
                joinPartsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                joinPartsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                joinPartsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                joinPartsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                joinPartsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                joinPartsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                joinPartsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                joinPartsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));
                joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                joinPartsUWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                joinPartsUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                joinPartsUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                joinPartsUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                joinPartsUWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                if (mode == 0)
                {
                    joinPartsUWork.JoinSourGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURGOODSNAMERF"));
                    joinPartsUWork.JoinDestGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTGOODSNAMERF"));
                    joinPartsUWork.JoinSourMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURMAKERNAMERF"));
                    joinPartsUWork.JoinDestMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTMAKERNAMERF"));
                }
                # endregion

            }
        }
        # endregion
    }
}

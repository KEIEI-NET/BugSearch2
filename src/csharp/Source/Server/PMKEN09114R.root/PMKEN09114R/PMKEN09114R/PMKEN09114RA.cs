//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   TBO検索マスタ(ユーザー登録)DBリモートオブジェクト
//                  :   PMKEN09114R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.11.17
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
    /// TBO検索マスタ(ユーザー登録)DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO検索マスタ(ユーザー登録)の実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.11.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class TBOSearchUDB : RemoteWithAppLockDB, ITBOSearchUDB
    {
        /// <summary>
        /// TBO検索マスタ(ユーザー登録)DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        /// </remarks>
        public TBOSearchUDB()
            : base("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork", "TBOSEARCHURF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一のTBO検索マスタ(ユーザー登録)情報を取得します。
        /// </summary>
        /// <param name="tboSearchUObj">TBOSearchUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致するTBO検索マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Read(ref object tboSearchUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                TBOSearchUWork tboSearchUWork = tboSearchUObj as TBOSearchUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref tboSearchUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一のTBO検索マスタ(ユーザー登録)情報を取得します。
        /// </summary>
        /// <param name="tboSearchUWork">TBOSearchUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致するTBO検索マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Read(ref TBOSearchUWork tboSearchUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref tboSearchUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一のTBO検索マスタ(ユーザー登録)情報を取得します。
        /// </summary>
        /// <param name="tboSearchUWork">TBOSearchUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致するTBO検索マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int ReadProc(ref TBOSearchUWork tboSearchUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   TBO.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,TBO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,TBO.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPGENRECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPNAMERF" + Environment.NewLine;
                sqlText += "  ,TBO.CARINFOJOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM TBOSEARCHURF AS TBO" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     TBO.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     TBO.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToTBOSearchUWorkFromReader(ref myReader, ref tboSearchUWork, 0);
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
        /// TBO検索マスタ(ユーザー登録)情報を物理削除します
        /// </summary>
        /// <param name="tboSearchUList">物理削除するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致するTBO検索マスタ(ユーザー登録)情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Delete(object tboSearchUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = tboSearchUList as ArrayList;

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
        /// TBO検索マスタ(ユーザー登録)情報を物理削除します
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Delete(ArrayList tboSearchUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(tboSearchUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報を物理削除します
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int DeleteProc(ArrayList tboSearchUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (tboSearchUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < tboSearchUList.Count; i++)
                    {
                        TBOSearchUWork tboSearchUWork = tboSearchUList[i] as TBOSearchUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                        sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                        sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                        SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != tboSearchUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                            sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                            sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                            sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                            findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                            findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

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
        /// TBO検索マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="tboSearchUList">検索結果</param>
        /// <param name="tboSearchUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致する、全てのTBO検索マスタ(ユーザー登録)情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Search(ref object tboSearchUList, object tboSearchUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList tboSearchUArray = tboSearchUList as ArrayList;
                ArrayList paraList = tboSearchUObj as ArrayList;
                
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    TBOSearchUWork tboSearchUWork = tboSearchUObj as TBOSearchUWork;
                    paraList.Add(tboSearchUWork);

                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref tboSearchUArray, paraList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// TBO検索マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="paraList">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致する、全てのTBO検索マスタ(ユーザー登録)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Search(ref ArrayList tboSearchUList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref tboSearchUList, paraList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報のリストを取得します。
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="paraList">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ(ユーザー登録)のキー値が一致する、全てのTBO検索マスタ(ユーザー登録)情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int SearchProc(ref ArrayList tboSearchUList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   TBO.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,TBO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,TBO.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPGENRECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPNAMERF" + Environment.NewLine;
                sqlText += "  ,TBO.CARINFOJOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM TBOSEARCHURF AS TBO" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     TBO.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSD.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     TBO.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERD.LOGICALDELETECODERF=0" + Environment.NewLine;

                foreach (TBOSearchUWork tboSearchUWork in paraList)
                {
                    sqlCommand.Parameters.Clear();

                    sqlCommand.CommandText = sqlText;
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, tboSearchUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        tboSearchUList.Add(this.CopyToTBOSearchUWorkFromReader(ref myReader, 0));
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }

                if (tboSearchUList.Count > 0)
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

        # region [SearchEquipNameGuide]
        /// <summary>
        /// 装備名称ガイド用のリストを取得します。
        /// </summary>
        /// <param name="tboSearchUList">検索結果</param>
        /// <param name="tboSearchUObj">検索条件</param>
        /// <param name="equipNameSrchTyp">装備名称検索タイプ 0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 装備名称ガイド用のリストを取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int SearchEquipNameGuide(ref object tboSearchUList, object tboSearchUObj, int equipNameSrchTyp)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            TBOSearchUWork tboSearchUWork = null;

            ArrayList tboSearchUArray = new ArrayList();
            ArrayList paraList = tboSearchUObj as ArrayList;

            if (paraList == null)
            {
                tboSearchUWork = tboSearchUObj as TBOSearchUWork;
            }
            else
            {
                if (paraList.Count > 0)
                    tboSearchUWork = paraList[0] as TBOSearchUWork;
            }

            try
            {

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchEquipNameGuide(ref tboSearchUArray, tboSearchUWork, equipNameSrchTyp, ref sqlConnection, ref sqlTransaction);

                tboSearchUList = tboSearchUArray;
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
        /// 装備名称ガイド用のリストを取得します。
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="tboSearchUWork">検索条件</param>
        /// <param name="equipNameSrchTyp">装備名称検索タイプ 0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 装備名称ガイド用のリストを取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int SearchEquipNameGuide(ref ArrayList tboSearchUList, TBOSearchUWork tboSearchUWork, int equipNameSrchTyp, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchEquipNameGuideProc(ref tboSearchUList, tboSearchUWork, equipNameSrchTyp, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 装備名称ガイド用のリストを取得します。
        /// </summary>
        /// <param name="tboSearchUList">TBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="tboSearchUWork">検索条件</param>
        /// <param name="equipNameSrchTyp">装備名称検索タイプ 0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 装備名称ガイド用のリストを取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int SearchEquipNameGuideProc(ref ArrayList tboSearchUList, TBOSearchUWork tboSearchUWork, int equipNameSrchTyp, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT DISTINCT" + Environment.NewLine;
                sqlText += "   TBO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPGENRECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPNAMERF" + Environment.NewLine;
                sqlText += " FROM TBOSEARCHURF AS TBO" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;

                sqlText = string.Empty;
                sqlText += "WHERE" + Environment.NewLine;

                //企業コード
                sqlText += "      TBO.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);

                //論理削除区分
                sqlText += "  AND TBO.LOGICALDELETECODERF = 0" + Environment.NewLine;

                //装備分類
                if (tboSearchUWork.EquipGenreCode != 0)
                {
                    sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                    SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                    findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                }

                //装備名称
                if (string.IsNullOrEmpty(tboSearchUWork.EquipName) == false)
                {
                    sqlText += "  AND EQUIPNAMERF LIKE @FINDEQUIPNAME";
                    SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                    //前方一致検索の場合
                    if (equipNameSrchTyp == 1) tboSearchUWork.EquipName = tboSearchUWork.EquipName + "%";
                    //後方一致検索の場合
                    if (equipNameSrchTyp == 2) tboSearchUWork.EquipName = "%" + tboSearchUWork.EquipName;
                    //曖昧検索の場合
                    if (equipNameSrchTyp == 3) tboSearchUWork.EquipName = "%" + tboSearchUWork.EquipName + "%";

                    findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                }

                sqlCommand.CommandText += sqlText;

                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    TBOSearchUWork tbowork = new TBOSearchUWork();

                    tbowork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    tbowork.EquipGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRECODERF"));
                    tbowork.EquipName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPNAMERF"));

                    tboSearchUList.Add(tbowork);
                }

                if (tboSearchUList.Count > 0)
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

        # region [Write]
        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報を追加・更新します。
        /// </summary>
        /// <param name="tboSearchUList">追加・更新するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Write(ref object tboSearchUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = tboSearchUList as ArrayList;

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
        /// TBO検索マスタ(ユーザー登録)情報を追加・更新します。
        /// </summary>
        /// <param name="tboSearchUList">追加・更新するTBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Write(ref ArrayList tboSearchUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref tboSearchUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報を追加・更新します。
        /// </summary>
        /// <param name="tboSearchUList">追加・更新するTBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int WriteProc(ref ArrayList tboSearchUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (tboSearchUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < tboSearchUList.Count; i++)
                    {
                        TBOSearchUWork tboSearchUWork = tboSearchUList[i] as TBOSearchUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  TBOSEARCHURF " + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                        sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                        sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                        SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != tboSearchUWork.UpdateDateTime)
                            {
                                if (tboSearchUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE TBOSEARCHURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , BLGOODSCODERF=@BLGOODSCODE , EQUIPGENRECODERF=@EQUIPGENRECODE , EQUIPNAMERF=@EQUIPNAME , CARINFOJOINDISPORDERRF=@CARINFOJOINDISPORDER , JOINDESTMAKERCDRF=@JOINDESTMAKERCD , JOINDESTPARTSNORF=@JOINDESTPARTSNO , JOINQTYRF=@JOINQTY , EQUIPSPECIALNOTERF=@EQUIPSPECIALNOTE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE AND EQUIPNAMERF=@FINDEQUIPNAME AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                            findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                            findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)tboSearchUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (tboSearchUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO TBOSEARCHURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BLGOODSCODERF, EQUIPGENRECODERF, EQUIPNAMERF, CARINFOJOINDISPORDERRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, EQUIPSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @BLGOODSCODE, @EQUIPGENRECODE, @EQUIPNAME, @CARINFOJOINDISPORDER, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @EQUIPSPECIALNOTE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)tboSearchUWork;
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
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraEquipGenreCode = sqlCommand.Parameters.Add("@EQUIPGENRECODE", SqlDbType.Int);
                        SqlParameter paraEquipName = sqlCommand.Parameters.Add("@EQUIPNAME", SqlDbType.NVarChar);
                        SqlParameter paraCarInfoJoinDispOrder = sqlCommand.Parameters.Add("@CARINFOJOINDISPORDER", SqlDbType.Int);
                        SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                        SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
                        SqlParameter paraEquipSpecialNote = sqlCommand.Parameters.Add("@EQUIPSPECIALNOTE", SqlDbType.NVarChar);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(tboSearchUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.LogicalDeleteCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.BLGoodsCode);
                        paraEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        paraEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        paraCarInfoJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.CarInfoJoinDispOrder);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);
                        paraJoinQty.Value = SqlDataMediator.SqlSetDouble(tboSearchUWork.JoinQty);
                        paraEquipSpecialNote.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipSpecialNote);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(tboSearchUWork);
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

            tboSearchUList = al;

            return status;
        }

        /// <summary>
        /// <br>TBO検索マスタ情報を登録、更新します</br>
        /// <br>同一装備名称、メーカーコードのデータをいったんDELETEし、新規で内容を登録します</br>
        /// </summary>
        /// <param name="tboSearchUWork">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGenreCode">装備分類</param>
        /// <param name="equipName">装備名称</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int Write(ref object tboSearchUWork, string enterpriseCode, Int32 equipGenreCode, string equipName)
        {
            return this.WriteProc(ref tboSearchUWork, enterpriseCode, equipGenreCode, equipName);
        }

        /// <summary>
        /// <br>TBO検索マスタ情報を登録、更新します</br>
        /// <br>同一装備名称、装備分類のデータをいったんDELETEし、新規で内容を登録します</br>
        /// </summary>
        /// <param name="tboSearchUWork">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGenreCode">装備分類</param>
        /// <param name="equipName">装備名称</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ情報を登録、更新します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int WriteProc(ref object tboSearchUWork, string enterpriseCode, Int32 equipGenreCode, string equipName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //パラメータのキャスト
                ArrayList paraList = tboSearchUWork as ArrayList;
                if (paraList == null) return status;

                //コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                // トランザクション開始
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //DELETE & INSERT でWrite実行
                status = DeleteInsert(ref paraList, enterpriseCode, equipGenreCode, equipName, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);

                //戻り値セット
                tboSearchUWork = paraList;
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
        /// 装備名称、装備分類を指定してデータをDELETEし、その後INSERTします
        /// </summary>
        /// <param name="tboSearchUWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGenreCode">装備分類</param>
        /// <param name="equipName">装備名称</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int DeleteInsert(ref ArrayList tboSearchUWorkList, string enterpriseCode, Int32 equipGenreCode, string equipName, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteInsertProc(ref tboSearchUWorkList, enterpriseCode, equipGenreCode, equipName, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 装備名称、装備分類を指定してデータをDELETEし、その後INSERTします
        /// </summary>
        /// <param name="tboSearchUWorkList">GoodsSetWorkオブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="equipGenreCode">装備分類</param>
        /// <param name="equipName">装備名称</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SQLトランザクション</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList に格納されているTBO検索マスタ(ユーザー登録)情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int DeleteInsertProc(ref ArrayList tboSearchUWorkList, string enterpriseCode, Int32 equipGenreCode, string equipName, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string sqlText = string.Empty;
            
            try
            {
                if (tboSearchUWorkList != null)
                {
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                    sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameterオブジェクトの作成
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                    SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);

                    // Parameterオブジェクトへ値設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(equipGenreCode);
                    findParaEquipName.Value = SqlDataMediator.SqlSetString(equipName);

                    sqlCommand.ExecuteNonQuery();

                    //新規作成時のSQL文を生成
                    sqlText = string.Empty;
                    sqlText = "INSERT INTO TBOSEARCHURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BLGOODSCODERF, EQUIPGENRECODERF, EQUIPNAMERF, CARINFOJOINDISPORDERRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, EQUIPSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @BLGOODSCODE, @EQUIPGENRECODE, @EQUIPNAME, @CARINFOJOINDISPORDER, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @EQUIPSPECIALNOTE)";
                    
                    sqlCommand.CommandText = sqlText;

                    # region Parameterオブジェクトの作成(更新用)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraEquipGenreCode = sqlCommand.Parameters.Add("@EQUIPGENRECODE", SqlDbType.Int);
                    SqlParameter paraEquipName = sqlCommand.Parameters.Add("@EQUIPNAME", SqlDbType.NVarChar);
                    SqlParameter paraCarInfoJoinDispOrder = sqlCommand.Parameters.Add("@CARINFOJOINDISPORDER", SqlDbType.Int);
                    SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
                    SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                    SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
                    SqlParameter paraEquipSpecialNote = sqlCommand.Parameters.Add("@EQUIPSPECIALNOTE", SqlDbType.NVarChar);
                    # endregion

                    for (int i = 0; i < tboSearchUWorkList.Count; i++)
                    {
                        TBOSearchUWork tboSearchUWork = tboSearchUWorkList[i] as TBOSearchUWork;

                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)tboSearchUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(tboSearchUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.LogicalDeleteCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.BLGoodsCode);
                        paraEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        paraEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        paraCarInfoJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.CarInfoJoinDispOrder);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);
                        paraJoinQty.Value = SqlDataMediator.SqlSetDouble(tboSearchUWork.JoinQty);
                        paraEquipSpecialNote.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipSpecialNote);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(tboSearchUWork);
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
        /// TBO検索マスタ(ユーザー登録)情報を論理削除します。
        /// </summary>
        /// <param name="tboSearchUList">論理削除するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork に格納されているTBO検索マスタ(ユーザー登録)情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int LogicalDelete(ref object tboSearchUList)
        {
            return this.LogicalDelete(ref tboSearchUList, 0);
        }

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報の論理削除を解除します。
        /// </summary>
        /// <param name="tboSearchUList">論理削除を解除するTBO検索マスタ(ユーザー登録)情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUUWork に格納されているTBO検索マスタ(ユーザー登録)情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int RevivalLogicalDelete(ref object tboSearchUList)
        {
            return this.LogicalDelete(ref tboSearchUList, 1);
        }

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報の論理削除を操作します。
        /// </summary>
        /// <param name="tboSearchUList">論理削除を操作するTBO検索マスタ(ユーザー登録)情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork に格納されているTBO検索マスタ(ユーザー登録)情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int LogicalDelete(ref object tboSearchUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = tboSearchUList as ArrayList;

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
        /// TBO検索マスタ(ユーザー登録)情報の論理削除を操作します。
        /// </summary>
        /// <param name="tboSearchUList">論理削除を操作するTBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork に格納されているTBO検索マスタ(ユーザー登録)情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        public int LogicalDelete(ref ArrayList tboSearchUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref tboSearchUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// TBO検索マスタ(ユーザー登録)情報の論理削除を操作します。
        /// </summary>
        /// <param name="tboSearchUList">論理削除を操作するTBO検索マスタ(ユーザー登録)情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork に格納されているTBO検索マスタ(ユーザー登録)情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private int LogicalDeleteProc(ref ArrayList tboSearchUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (tboSearchUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < tboSearchUList.Count; i++)
                    {
                        TBOSearchUWork tboSearchUWork = tboSearchUList[i] as TBOSearchUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                        sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                        sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                        SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != tboSearchUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                            sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                            sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                            sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                            findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                            findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)tboSearchUWork;
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
                            else if (logicalDelCd == 0) tboSearchUWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else tboSearchUWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                tboSearchUWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(tboSearchUWork);
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

            tboSearchUList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="tboSearchUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, TBOSearchUWork tboSearchUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  TBO.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring += "  AND TBO.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring += "  AND TBO.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            
            //装備分類
            if (tboSearchUWork.EquipGenreCode != 0)
            {
                retstring += "AND TBO.EQUIPGENRECODERF=@FINDEQUIPGENRECODE " + Environment.NewLine;
                SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
            }
            
            //装備名称
            if (string.IsNullOrEmpty(tboSearchUWork.EquipName) == false)
            {
                retstring += "AND TBO.EQUIPNAMERF=@FINDEQUIPNAME " + Environment.NewLine;
                SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
            }
            
            //結合先メーカーコード
            if (tboSearchUWork.JoinDestMakerCd != 0)
            {
                retstring += "AND TBO.JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD " + Environment.NewLine;
                SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
            }
            
            //結合先品番
            if (string.IsNullOrEmpty(tboSearchUWork.JoinDestPartsNo) == false)
            {
                retstring += "AND TBO.JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO " + Environment.NewLine;
                SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);
                findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);
            }

            retstring += "ORDER BY TBO.ENTERPRISECODERF, TBO.EQUIPGENRECODERF, TBO.EQUIPNAMERF, TBO.CARINFOJOINDISPORDERRF, TBO.JOINDESTMAKERCDRF, TBO.JOINDESTPARTSNORF";
            
            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → TBOSearchUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">mode</param>
        /// <returns>TBOSearchUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        /// </remarks>
        private TBOSearchUWork CopyToTBOSearchUWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            TBOSearchUWork tboSearchUWork = new TBOSearchUWork();

            this.CopyToTBOSearchUWorkFromReader(ref myReader, ref tboSearchUWork, mode);

            return tboSearchUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → TBOSearchUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="tboSearchUWork">TBOSearchUWork オブジェクト</param>
        /// <param name="mode">mode</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.11.17</br>
        /// </remarks>
        private void CopyToTBOSearchUWorkFromReader(ref SqlDataReader myReader, ref TBOSearchUWork tboSearchUWork, int mode)
        {
            if (myReader != null && tboSearchUWork != null)
            {
                # region クラスへ格納
                tboSearchUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                tboSearchUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                tboSearchUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                tboSearchUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                tboSearchUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                tboSearchUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                tboSearchUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                tboSearchUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                tboSearchUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                tboSearchUWork.EquipGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRECODERF"));
                tboSearchUWork.EquipName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPNAMERF"));
                tboSearchUWork.CarInfoJoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINFOJOINDISPORDERRF"));
                tboSearchUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                tboSearchUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                tboSearchUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                tboSearchUWork.EquipSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPSPECIALNOTERF"));

                if (mode == 0)
                {
                    tboSearchUWork.JoinDestMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTMAKERNAMERF"));
                    tboSearchUWork.JoinDestGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTGOODSNAMERF"));
                }
                # endregion

            }
        }
        # endregion
    }
}

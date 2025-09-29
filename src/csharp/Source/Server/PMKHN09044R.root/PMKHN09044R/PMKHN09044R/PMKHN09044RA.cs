//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   離島価格マスタDBリモートオブジェクト
//                  :   PMKHN09044R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008　長内 数馬
// Date             :   2008.06.10
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
    /// 離島価格マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 離島価格マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class IsolIslandPrcDB : RemoteWithAppLockDB, IIsolIslandPrcDB
    {
        /// <summary>
        /// 離島価格マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public IsolIslandPrcDB() : base("PMKHN09046D", "Broadleaf.Application.Remoting.ParamData.IsolIslandPrcWork", "ISOLISLANDPRCRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の離島価格マスタ情報を取得します。
        /// </summary>
        /// <param name="isolIslandPrcObj">IsolIslandPrcWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する離島価格マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref object isolIslandPrcObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                IsolIslandPrcWork isolIslandPrcWork = isolIslandPrcObj as IsolIslandPrcWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref isolIslandPrcWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一の離島価格マスタ情報を取得します。
        /// </summary>
        /// <param name="isolIslandPrcWork">IsolIslandPrcWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する離島価格マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref IsolIslandPrcWork isolIslandPrcWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref isolIslandPrcWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の離島価格マスタ情報を取得します。
        /// </summary>
        /// <param name="isolIslandPrcWork">IsolIslandPrcWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する離島価格マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int ReadProc(ref IsolIslandPrcWork isolIslandPrcWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  ISO.*" + Environment.NewLine;
                sqlText += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  ISOLISLANDPRCRF AS ISO" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     ISO.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND ISO.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "WHERE ISO.ENTERPRISECODERF=@FINDENTERPRISECODE AND ISO.SECTIONCODERF=@FINDSECTIONCODE AND ISO.MAKERCODERF=@FINDMAKERCODE AND ISO.UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
                findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
                findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToIsolIslandPrcWorkFromReader(ref myReader, ref isolIslandPrcWork);
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
        /// 離島価格マスタ情報を物理削除します
        /// </summary>
        /// <param name="isolIslandPrcList">物理削除する離島価格マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する離島価格マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Delete(object isolIslandPrcList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = isolIslandPrcList as ArrayList;

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
        /// 離島価格マスタ情報を物理削除します
        /// </summary>
        /// <param name="isolIslandPrcList">離島価格マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcList に格納されている離島価格マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Delete(ArrayList isolIslandPrcList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(isolIslandPrcList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 離島価格マスタ情報を物理削除します
        /// </summary>
        /// <param name="isolIslandPrcList">離島価格マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcList に格納されている離島価格マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int DeleteProc(ArrayList isolIslandPrcList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (isolIslandPrcList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < isolIslandPrcList.Count; i++)
                    {
                        IsolIslandPrcWork isolIslandPrcWork = isolIslandPrcList[i] as IsolIslandPrcWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ISOLISLANDPRCRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAKERCODERF=@FINDMAKERCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
                        findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
                        findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != isolIslandPrcWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  ISOLISLANDPRCRF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAKERCODERF=@FINDMAKERCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
                            findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
                            findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);

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
        /// 離島価格マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="isolIslandPrcList">検索結果</param>
        /// <param name="isolIslandPrcObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する、全ての離島価格マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref object isolIslandPrcList, object isolIslandPrcObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList isolIslandPrcArray = isolIslandPrcList as ArrayList;
                IsolIslandPrcWork isolIslandPrcWork = isolIslandPrcObj as IsolIslandPrcWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref isolIslandPrcArray, isolIslandPrcWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// 離島価格マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="isolIslandPrcList">離島価格マスタ情報を格納する ArrayList</param>
        /// <param name="isolIslandPrcWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する、全ての離島価格マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref ArrayList isolIslandPrcList, IsolIslandPrcWork isolIslandPrcWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref isolIslandPrcList, isolIslandPrcWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 離島価格マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="isolIslandPrcList">離島価格マスタ情報を格納する ArrayList</param>
        /// <param name="isolIslandPrcWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 離島価格マスタのキー値が一致する、全ての離島価格マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int SearchProc(ref ArrayList isolIslandPrcList, IsolIslandPrcWork isolIslandPrcWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  ISO.*" + Environment.NewLine;
                sqlText += "  ,SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  ISOLISLANDPRCRF AS ISO" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     ISO.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND ISO.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, isolIslandPrcWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    isolIslandPrcList.Add(this.CopyToIsolIslandPrcWorkFromReader(ref myReader));
                }

                if (isolIslandPrcList.Count > 0)
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
        /// 離島価格マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="isolIslandPrcList">追加・更新する離島価格マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcList に格納されている離島価格マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Write(ref object isolIslandPrcList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = isolIslandPrcList as ArrayList;

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
        /// 離島価格マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="isolIslandPrcList">追加・更新する離島価格マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcList に格納されている離島価格マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Write(ref ArrayList isolIslandPrcList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref isolIslandPrcList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 離島価格マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="isolIslandPrcList">追加・更新する離島価格マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcList に格納されている離島価格マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int WriteProc(ref ArrayList isolIslandPrcList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (isolIslandPrcList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < isolIslandPrcList.Count; i++)
                    {
                        IsolIslandPrcWork isolIslandPrcWork = isolIslandPrcList[i] as IsolIslandPrcWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ISOLISLANDPRCRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAKERCODERF=@FINDMAKERCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);



                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
                        findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
                        findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != isolIslandPrcWork.UpdateDateTime)
                            {
                                if (isolIslandPrcWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE ISOLISLANDPRCRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , MAKERCODERF=@MAKERCODE , UPPERLIMITPRICERF=@UPPERLIMITPRICE , FRACTIONPROCUNITRF=@FRACTIONPROCUNIT , FRACTIONPROCCDRF=@FRACTIONPROCCD , UPRATERF=@UPRATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAKERCODERF=@FINDMAKERCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
                            findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
                            findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)isolIslandPrcWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (isolIslandPrcWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO ISOLISLANDPRCRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, MAKERCODERF, UPPERLIMITPRICERF, FRACTIONPROCUNITRF, FRACTIONPROCCDRF, UPRATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @MAKERCODE, @UPPERLIMITPRICE, @FRACTIONPROCUNIT, @FRACTIONPROCCD, @UPRATE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)isolIslandPrcWork;
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
                        SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                        SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Float);
                        SqlParameter paraFractionProcUnit = sqlCommand.Parameters.Add("@FRACTIONPROCUNIT", SqlDbType.Float);
                        SqlParameter paraFractionProcCd = sqlCommand.Parameters.Add("@FRACTIONPROCCD", SqlDbType.Int);
                        SqlParameter paraUpRate = sqlCommand.Parameters.Add("@UPRATE", SqlDbType.Float);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(isolIslandPrcWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(isolIslandPrcWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(isolIslandPrcWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
                        paraMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
                        paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);
                        paraFractionProcUnit.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.FractionProcUnit);
                        paraFractionProcCd.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.FractionProcCd);
                        paraUpRate.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpRate);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(isolIslandPrcWork);
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

            isolIslandPrcList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 離島価格マスタ情報を論理削除します。
        /// </summary>
        /// <param name="isolIslandPrcList">論理削除する離島価格マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork に格納されている離島価格マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int LogicalDelete(ref object isolIslandPrcList)
        {
            return this.LogicalDelete(ref isolIslandPrcList, 0);
        }

        /// <summary>
        /// 離島価格マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="isolIslandPrcList">論理削除を解除する離島価格マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork に格納されている離島価格マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int RevivalLogicalDelete(ref object isolIslandPrcList)
        {
            return this.LogicalDelete(ref isolIslandPrcList, 1);
        }

        /// <summary>
        /// 離島価格マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="isolIslandPrcList">論理削除を操作する離島価格マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork に格納されている離島価格マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int LogicalDelete(ref object isolIslandPrcList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = isolIslandPrcList as ArrayList;

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
        /// 離島価格マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="isolIslandPrcList">論理削除を操作する離島価格マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork に格納されている離島価格マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int LogicalDelete(ref ArrayList isolIslandPrcList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref isolIslandPrcList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 離島価格マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="isolIslandPrcList">論理削除を操作する離島価格マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : isolIslandPrcWork に格納されている離島価格マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int LogicalDeleteProc(ref ArrayList isolIslandPrcList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (isolIslandPrcList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < isolIslandPrcList.Count; i++)
                    {
                        IsolIslandPrcWork isolIslandPrcWork = isolIslandPrcList[i] as IsolIslandPrcWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  ISOLISLANDPRCRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAKERCODERF=@FINDMAKERCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaMakerCode = sqlCommand.Parameters.Add("@FINDMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaUpperLimitPrice = sqlCommand.Parameters.Add("@FINDUPPERLIMITPRICE", SqlDbType.Float);



                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
                        findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
                        findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != isolIslandPrcWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  ISOLISLANDPRCRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND MAKERCODERF=@FINDMAKERCODE AND UPPERLIMITPRICERF=@FINDUPPERLIMITPRICE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
                            findParaMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
                            findParaUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)isolIslandPrcWork;
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
                            else if (logicalDelCd == 0) isolIslandPrcWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else isolIslandPrcWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                isolIslandPrcWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(isolIslandPrcWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(isolIslandPrcWork);
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

            isolIslandPrcList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="isolIslandPrcWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, IsolIslandPrcWork isolIslandPrcWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  ISO.ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND ISO.LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND ISO.LOGICALDELETECODERF < @FINDLOGICALDELETECODE " + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (string.IsNullOrEmpty(isolIslandPrcWork.SectionCode) == false)
            {
                retstring += "AND ISO.SECTIONCODERF=@SECTIONCODE ";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(isolIslandPrcWork.SectionCode);
            }
            
            //メーカーコード
            if (isolIslandPrcWork.MakerCode != 0)
            {
                retstring += "AND ISO.MAKERCODERF=@MAKERCODE ";
                SqlParameter paraMakerCode = sqlCommand.Parameters.Add("@MAKERCODE", SqlDbType.Int);
                paraMakerCode.Value = SqlDataMediator.SqlSetInt32(isolIslandPrcWork.MakerCode);
            }
            
            //上限金額
            if (isolIslandPrcWork.UpperLimitPrice > 0)
            {
                retstring += "AND ISO.UPPERLIMITPRICERF=@UPPERLIMITPRICE ";
                SqlParameter paraUpperLimitPrice = sqlCommand.Parameters.Add("@UPPERLIMITPRICE", SqlDbType.Int);
                paraUpperLimitPrice.Value = SqlDataMediator.SqlSetDouble(isolIslandPrcWork.UpperLimitPrice);
            }
            
            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → IsolIslandPrcWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>IsolIslandPrcWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private IsolIslandPrcWork CopyToIsolIslandPrcWorkFromReader(ref SqlDataReader myReader)
        {
            IsolIslandPrcWork isolIslandPrcWork = new IsolIslandPrcWork();

            this.CopyToIsolIslandPrcWorkFromReader(ref myReader, ref isolIslandPrcWork);

            return isolIslandPrcWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → IsolIslandPrcWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="isolIslandPrcWork">IsolIslandPrcWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private void CopyToIsolIslandPrcWorkFromReader(ref SqlDataReader myReader, ref IsolIslandPrcWork isolIslandPrcWork)
        {
            if (myReader != null && isolIslandPrcWork != null)
            {
                # region クラスへ格納
                isolIslandPrcWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                isolIslandPrcWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                isolIslandPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                isolIslandPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                isolIslandPrcWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                isolIslandPrcWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                isolIslandPrcWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                isolIslandPrcWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                isolIslandPrcWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
                isolIslandPrcWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                isolIslandPrcWork.MakerCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("MAKERCODERF"));
                isolIslandPrcWork.UpperLimitPrice = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UPPERLIMITPRICERF"));
                isolIslandPrcWork.FractionProcUnit = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("FRACTIONPROCUNITRF"));
                isolIslandPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("FRACTIONPROCCDRF"));
                isolIslandPrcWork.UpRate = SqlDataMediator.SqlGetDouble(myReader,myReader.GetOrdinal("UPRATERF"));

                # endregion
            }
        }
        # endregion
    }
}

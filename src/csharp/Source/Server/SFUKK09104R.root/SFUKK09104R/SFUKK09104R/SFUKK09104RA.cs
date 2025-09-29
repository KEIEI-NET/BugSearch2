//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   請求全体設定マスタDBリモートオブジェクト
//                  :   SFUKK09104R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.06.05
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
    /// 請求全体設定マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求全体設定マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.06.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class BillAllStDB : RemoteWithAppLockDB, IBillAllStDB
    {
        /// <summary>
        /// 請求全体設定マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        public BillAllStDB() : base("SFUKK09106D", "Broadleaf.Application.Remoting.ParamData.BillAllStWork", "BILLALLSTRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の請求全体設定マスタ情報を取得します。
        /// </summary>
        /// <param name="billAllStObj">BillAllStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する請求全体設定マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Read(ref object billAllStObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                BillAllStWork billAllStWork = billAllStObj as BillAllStWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref billAllStWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一の請求全体設定マスタ情報を取得します。
        /// </summary>
        /// <param name="billAllStWork">BillAllStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する請求全体設定マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Read(ref BillAllStWork billAllStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return ReadProc(ref billAllStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 単一の請求全体設定マスタ情報を取得します。
        /// </summary>
        /// <param name="billAllStWork">BillAllStWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する請求全体設定マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int ReadProc(ref BillAllStWork billAllStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  BIL.*, SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  BILLALLSTRF AS BIL" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     BIL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND BIL.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlText += "WHERE BIL.ENTERPRISECODERF=@FINDENTERPRISECODE AND BIL.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToBillAllStWorkFromReader(ref myReader, ref billAllStWork);
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
        /// 請求全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="billAllStList">物理削除する請求全体設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する請求全体設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Delete(object billAllStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = billAllStList as ArrayList;

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
        /// 請求全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="billAllStList">請求全体設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList に格納されている請求全体設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Delete(ArrayList billAllStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(billAllStList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 請求全体設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="billAllStList">請求全体設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList に格納されている請求全体設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int DeleteProc(ArrayList billAllStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (billAllStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < billAllStList.Count; i++)
                    {
                        BillAllStWork billAllStWork = billAllStList[i] as BillAllStWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BILLALLSTRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != billAllStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  BILLALLSTRF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);

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
        /// 請求全体設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="billAllStList">検索結果</param>
        /// <param name="billAllStObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する、全ての請求全体設定マスタ情報を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Search(ref object billAllStList, object billAllStObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList billAllStArray = billAllStList as ArrayList;
                BillAllStWork billAllStWork = billAllStObj as BillAllStWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref billAllStArray, billAllStWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// 請求全体設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="billAllStList">請求全体設定マスタ情報を格納する ArrayList</param>
        /// <param name="billAllStWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する、全ての請求全体設定マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Search(ref ArrayList billAllStList, BillAllStWork billAllStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref billAllStList, billAllStWork,readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 請求全体設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="billAllStList">請求全体設定マスタ情報を格納する ArrayList</param>
        /// <param name="billAllStWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求全体設定マスタのキー値が一致する、全ての請求全体設定マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int SearchProc(ref ArrayList billAllStList, BillAllStWork billAllStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "  BIL.*, SEC.SECTIONGUIDENMRF" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  BILLALLSTRF AS BIL" + Environment.NewLine;
                sqlText += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     BIL.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND BIL.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, billAllStWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    billAllStList.Add(this.CopyToBillAllStWorkFromReader(ref myReader));
                }

                if (billAllStList.Count > 0)
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
        /// 請求全体設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="billAllStList">追加・更新する請求全体設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList に格納されている請求全体設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Write(ref object billAllStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = billAllStList as ArrayList;

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
        /// 請求全体設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="billAllStList">追加・更新する請求全体設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList に格納されている請求全体設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int Write(ref ArrayList billAllStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref billAllStList, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 請求全体設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="billAllStList">追加・更新する請求全体設定マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStList に格納されている請求全体設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int WriteProc(ref ArrayList billAllStList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (billAllStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < billAllStList.Count; i++)
                    {
                        BillAllStWork billAllStWork = billAllStList[i] as BillAllStWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BILLALLSTRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != billAllStWork.UpdateDateTime)
                            {
                                if (billAllStWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE BILLALLSTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SECTIONCODERF=@SECTIONCODE , ALLOWANCEPROCCDRF=@ALLOWANCEPROCCD , DEPOSITSLIPMNTCDRF=@DEPOSITSLIPMNTCD , COLLECTPLNDIVRF=@COLLECTPLNDIV ,CUSTOMERTOTALDAY1RF=@CUSTOMERTOTALDAY1 , CUSTOMERTOTALDAY2RF=@CUSTOMERTOTALDAY2 , CUSTOMERTOTALDAY3RF=@CUSTOMERTOTALDAY3 , CUSTOMERTOTALDAY4RF=@CUSTOMERTOTALDAY4 , CUSTOMERTOTALDAY5RF=@CUSTOMERTOTALDAY5 , CUSTOMERTOTALDAY6RF=@CUSTOMERTOTALDAY6 , CUSTOMERTOTALDAY7RF=@CUSTOMERTOTALDAY7 , CUSTOMERTOTALDAY8RF=@CUSTOMERTOTALDAY8 , CUSTOMERTOTALDAY9RF=@CUSTOMERTOTALDAY9 , CUSTOMERTOTALDAY10RF=@CUSTOMERTOTALDAY10 , CUSTOMERTOTALDAY11RF=@CUSTOMERTOTALDAY11 , CUSTOMERTOTALDAY12RF=@CUSTOMERTOTALDAY12 , SUPPLIERTOTALDAY1RF=@SUPPLIERTOTALDAY1 , SUPPLIERTOTALDAY2RF=@SUPPLIERTOTALDAY2 , SUPPLIERTOTALDAY3RF=@SUPPLIERTOTALDAY3 , SUPPLIERTOTALDAY4RF=@SUPPLIERTOTALDAY4 , SUPPLIERTOTALDAY5RF=@SUPPLIERTOTALDAY5 , SUPPLIERTOTALDAY6RF=@SUPPLIERTOTALDAY6 , SUPPLIERTOTALDAY7RF=@SUPPLIERTOTALDAY7 , SUPPLIERTOTALDAY8RF=@SUPPLIERTOTALDAY8 , SUPPLIERTOTALDAY9RF=@SUPPLIERTOTALDAY9 , SUPPLIERTOTALDAY10RF=@SUPPLIERTOTALDAY10 , SUPPLIERTOTALDAY11RF=@SUPPLIERTOTALDAY11 , SUPPLIERTOTALDAY12RF=@SUPPLIERTOTALDAY12 WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)billAllStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (billAllStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO BILLALLSTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, ALLOWANCEPROCCDRF, DEPOSITSLIPMNTCDRF, COLLECTPLNDIVRF, CUSTOMERTOTALDAY1RF, CUSTOMERTOTALDAY2RF, CUSTOMERTOTALDAY3RF, CUSTOMERTOTALDAY4RF, CUSTOMERTOTALDAY5RF, CUSTOMERTOTALDAY6RF, CUSTOMERTOTALDAY7RF, CUSTOMERTOTALDAY8RF, CUSTOMERTOTALDAY9RF, CUSTOMERTOTALDAY10RF, CUSTOMERTOTALDAY11RF, CUSTOMERTOTALDAY12RF, SUPPLIERTOTALDAY1RF, SUPPLIERTOTALDAY2RF, SUPPLIERTOTALDAY3RF, SUPPLIERTOTALDAY4RF, SUPPLIERTOTALDAY5RF, SUPPLIERTOTALDAY6RF, SUPPLIERTOTALDAY7RF, SUPPLIERTOTALDAY8RF, SUPPLIERTOTALDAY9RF, SUPPLIERTOTALDAY10RF, SUPPLIERTOTALDAY11RF, SUPPLIERTOTALDAY12RF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @ALLOWANCEPROCCD, @DEPOSITSLIPMNTCD, @COLLECTPLNDIV, @CUSTOMERTOTALDAY1, @CUSTOMERTOTALDAY2, @CUSTOMERTOTALDAY3, @CUSTOMERTOTALDAY4, @CUSTOMERTOTALDAY5, @CUSTOMERTOTALDAY6, @CUSTOMERTOTALDAY7, @CUSTOMERTOTALDAY8, @CUSTOMERTOTALDAY9, @CUSTOMERTOTALDAY10, @CUSTOMERTOTALDAY11, @CUSTOMERTOTALDAY12, @SUPPLIERTOTALDAY1, @SUPPLIERTOTALDAY2, @SUPPLIERTOTALDAY3, @SUPPLIERTOTALDAY4, @SUPPLIERTOTALDAY5, @SUPPLIERTOTALDAY6, @SUPPLIERTOTALDAY7, @SUPPLIERTOTALDAY8, @SUPPLIERTOTALDAY9, @SUPPLIERTOTALDAY10, @SUPPLIERTOTALDAY11, @SUPPLIERTOTALDAY12)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)billAllStWork;
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
                        SqlParameter paraAllowanceProcCd = sqlCommand.Parameters.Add("@ALLOWANCEPROCCD", SqlDbType.Int);
                        SqlParameter paraDepositSlipMntCd = sqlCommand.Parameters.Add("@DEPOSITSLIPMNTCD", SqlDbType.Int);
                        SqlParameter paraCollectPlnDiv = sqlCommand.Parameters.Add("@COLLECTPLNDIV", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay1 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY1", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay2 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY2", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay3 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY3", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay4 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY4", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay5 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY5", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay6 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY6", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay7 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY7", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay8 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY8", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay9 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY9", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay10 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY10", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay11 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY11", SqlDbType.Int);
                        SqlParameter paraCustomerTotalDay12 = sqlCommand.Parameters.Add("@CUSTOMERTOTALDAY12", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay1 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY1", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay2 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY2", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay3 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY3", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay4 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY4", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay5 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY5", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay6 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY6", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay7 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY7", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay8 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY8", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay9 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY9", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay10 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY10", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay11 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY11", SqlDbType.Int);
                        SqlParameter paraSupplierTotalDay12 = sqlCommand.Parameters.Add("@SUPPLIERTOTALDAY12", SqlDbType.Int);

                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billAllStWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billAllStWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(billAllStWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(billAllStWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);
                        paraAllowanceProcCd.Value = SqlDataMediator.SqlSetInt32(billAllStWork.AllowanceProcCd);
                        paraDepositSlipMntCd.Value = SqlDataMediator.SqlSetInt32(billAllStWork.DepositSlipMntCd);
                        paraCollectPlnDiv.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CollectPlnDiv);
                        paraCustomerTotalDay1.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay1);
                        paraCustomerTotalDay2.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay2);
                        paraCustomerTotalDay3.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay3);
                        paraCustomerTotalDay4.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay4);
                        paraCustomerTotalDay5.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay5);
                        paraCustomerTotalDay6.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay6);
                        paraCustomerTotalDay7.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay7);
                        paraCustomerTotalDay8.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay8);
                        paraCustomerTotalDay9.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay9);
                        paraCustomerTotalDay10.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay10);
                        paraCustomerTotalDay11.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay11);
                        paraCustomerTotalDay12.Value = SqlDataMediator.SqlSetInt32(billAllStWork.CustomerTotalDay12);
                        paraSupplierTotalDay1.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay1);
                        paraSupplierTotalDay2.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay2);
                        paraSupplierTotalDay3.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay3);
                        paraSupplierTotalDay4.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay4);
                        paraSupplierTotalDay5.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay5);
                        paraSupplierTotalDay6.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay6);
                        paraSupplierTotalDay7.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay7);
                        paraSupplierTotalDay8.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay8);
                        paraSupplierTotalDay9.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay9);
                        paraSupplierTotalDay10.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay10);
                        paraSupplierTotalDay11.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay11);
                        paraSupplierTotalDay12.Value = SqlDataMediator.SqlSetInt32(billAllStWork.SupplierTotalDay12);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(billAllStWork);
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

            billAllStList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 請求全体設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="billAllStList">論理削除する請求全体設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork に格納されている請求全体設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int LogicalDelete(ref object billAllStList)
        {
            return this.LogicalDelete(ref billAllStList, 0);
        }

        /// <summary>
        /// 請求全体設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="billAllStList">論理削除を解除する請求全体設定マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork に格納されている請求全体設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int RevivalLogicalDelete(ref object billAllStList)
        {
            return this.LogicalDelete(ref billAllStList, 1);
        }

        /// <summary>
        /// 請求全体設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="billAllStList">論理削除を操作する請求全体設定マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork に格納されている請求全体設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int LogicalDelete(ref object billAllStList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = billAllStList as ArrayList;

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
        /// 請求全体設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="billAllStList">論理削除を操作する請求全体設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork に格納されている請求全体設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        public int LogicalDelete(ref ArrayList billAllStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref billAllStList, procMode, ref sqlConnection, ref sqlTransaction);
        }
        /// <summary>
        /// 請求全体設定マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="billAllStList">論理削除を操作する請求全体設定マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : billAllStWork に格納されている請求全体設定マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private int LogicalDeleteProc(ref ArrayList billAllStList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (billAllStList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < billAllStList.Count; i++)
                    {
                        BillAllStWork billAllStWork = billAllStList[i] as BillAllStWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  BILLALLSTRF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != billAllStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  BILLALLSTRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)billAllStWork;
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
                            else if (logicalDelCd == 0) billAllStWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else billAllStWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                billAllStWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(billAllStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(billAllStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(billAllStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(billAllStWork);
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

            billAllStList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="billAllStWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, BillAllStWork billAllStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  BIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(billAllStWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND BIL.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND BIL.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //拠点コード
            if (string.IsNullOrEmpty(billAllStWork.SectionCode) == false)
            {
                wkstring += " AND BIL.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(billAllStWork.SectionCode);
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → BillAllStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BillAllStWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        private BillAllStWork CopyToBillAllStWorkFromReader(ref SqlDataReader myReader)
        {
            BillAllStWork billAllStWork = new BillAllStWork();

            this.CopyToBillAllStWorkFromReader(ref myReader, ref billAllStWork);

            return billAllStWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → BillAllStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="billAllStWork">BillAllStWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.06.05</br>
        /// </remarks>
        private void CopyToBillAllStWorkFromReader(ref SqlDataReader myReader, ref BillAllStWork billAllStWork)
        {
            if (myReader != null && billAllStWork != null)
            {
                # region クラスへ格納
                billAllStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("CREATEDATETIMERF"));
                billAllStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader,myReader.GetOrdinal("UPDATEDATETIMERF"));
                billAllStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("ENTERPRISECODERF"));
                billAllStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader,myReader.GetOrdinal("FILEHEADERGUIDRF"));
                billAllStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                billAllStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                billAllStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                billAllStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("LOGICALDELETECODERF"));
                billAllStWork.SectionCode = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONCODERF"));
                billAllStWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader,myReader.GetOrdinal("SECTIONGUIDENMRF"));
                billAllStWork.AllowanceProcCd = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("ALLOWANCEPROCCDRF"));
                billAllStWork.DepositSlipMntCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEPOSITSLIPMNTCDRF"));
                billAllStWork.CollectPlnDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTPLNDIVRF"));
                billAllStWork.CustomerTotalDay1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERTOTALDAY1RF"));
                billAllStWork.CustomerTotalDay2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY2RF"));
                billAllStWork.CustomerTotalDay3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY3RF"));
                billAllStWork.CustomerTotalDay4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY4RF"));
                billAllStWork.CustomerTotalDay5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY5RF"));
                billAllStWork.CustomerTotalDay6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY6RF"));
                billAllStWork.CustomerTotalDay7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY7RF"));
                billAllStWork.CustomerTotalDay8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY8RF"));
                billAllStWork.CustomerTotalDay9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY9RF"));
                billAllStWork.CustomerTotalDay10 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY10RF"));
                billAllStWork.CustomerTotalDay11 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY11RF"));
                billAllStWork.CustomerTotalDay12 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("CUSTOMERTOTALDAY12RF"));
                billAllStWork.SupplierTotalDay1 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY1RF"));
                billAllStWork.SupplierTotalDay2 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY2RF"));
                billAllStWork.SupplierTotalDay3 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY3RF"));
                billAllStWork.SupplierTotalDay4 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY4RF"));
                billAllStWork.SupplierTotalDay5 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY5RF"));
                billAllStWork.SupplierTotalDay6 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY6RF"));
                billAllStWork.SupplierTotalDay7 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY7RF"));
                billAllStWork.SupplierTotalDay8 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY8RF"));
                billAllStWork.SupplierTotalDay9 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY9RF"));
                billAllStWork.SupplierTotalDay10 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY10RF"));
                billAllStWork.SupplierTotalDay11 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY11RF"));
                billAllStWork.SupplierTotalDay12 = SqlDataMediator.SqlGetInt32(myReader,myReader.GetOrdinal("SUPPLIERTOTALDAY12RF"));

                # endregion
            }
        }
        # endregion
    }
}

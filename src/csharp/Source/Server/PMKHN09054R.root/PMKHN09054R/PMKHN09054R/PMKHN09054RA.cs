//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   部位マスタDBリモートオブジェクト
//                  :   PMKHN09054R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008　長内　数馬
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
    /// 部位マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部位マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PartsPosCodeUDB : RemoteWithAppLockDB, IPartsPosCodeUDB
    {
        /// <summary>
        /// 部位マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public PartsPosCodeUDB() : base("PMKHN09056D", "Broadleaf.Application.Remoting.ParamData.PartsPosCodeUWork", "PARTSPOSCODEURF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の部位マスタ情報を取得します。
        /// </summary>
        /// <param name="partsPosCodeUObj">PartsPosCodeUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する部位マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref object partsPosCodeUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUObj as PartsPosCodeUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref partsPosCodeUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一の部位マスタ情報を取得します。
        /// </summary>
        /// <param name="partsPosCodeUWork">PartsPosCodeUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する部位マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref PartsPosCodeUWork partsPosCodeUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref partsPosCodeUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の部位マスタ情報を取得します。
        /// </summary>
        /// <param name="partsPosCodeUWork">PartsPosCodeUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する部位マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int ReadProc(ref PartsPosCodeUWork partsPosCodeUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,SEARCHPARTSPOSCODERF" + Environment.NewLine;
                sqlText += "  ,SEARCHPARTSPOSNAMERF" + Environment.NewLine;
                sqlText += "  ,POSDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,OFFERDATADIVRF" + Environment.NewLine;
                sqlText += " FROM PARTSPOSCODEURF" + Environment.NewLine;
                sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);


                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPartsPosCodeUWorkFromReader(ref myReader, ref partsPosCodeUWork);
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
        /// 部位マスタ情報を物理削除します
        /// </summary>
        /// <param name="partsPosCodeUList">物理削除する部位マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する部位マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(object partsPosCodeUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = partsPosCodeUList as ArrayList;

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
        /// 部位マスタ情報を物理削除します
        /// </summary>
        /// <param name="partsPosCodeUList">部位マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList に格納されている部位マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(ArrayList partsPosCodeUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(partsPosCodeUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部位マスタ情報を物理削除します
        /// </summary>
        /// <param name="partsPosCodeUList">部位マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList に格納されている部位マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int DeleteProc(ArrayList partsPosCodeUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (partsPosCodeUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsPosCodeUList.Count; i++)
                    {
                        PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUList[i] as PartsPosCodeUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                        sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                        findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                        findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != partsPosCodeUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                            findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                            findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

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
        /// 部位マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="partsPosCodeUList">検索結果</param>
        /// <param name="partsPosCodeUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する、全ての部位マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref object partsPosCodeUList, object partsPosCodeUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList partsPosCodeUArray = partsPosCodeUList as ArrayList;
                PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUObj as PartsPosCodeUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref partsPosCodeUArray, partsPosCodeUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// 部位マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="partsPosCodeUList">部位マスタ情報を格納する ArrayList</param>
        /// <param name="partsPosCodeUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する、全ての部位マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref ArrayList partsPosCodeUList, PartsPosCodeUWork partsPosCodeUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref partsPosCodeUList, partsPosCodeUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部位マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="partsPosCodeUList">部位マスタ情報を格納する ArrayList</param>
        /// <param name="partsPosCodeUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部位マスタのキー値が一致する、全ての部位マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int SearchProc(ref ArrayList partsPosCodeUList, PartsPosCodeUWork partsPosCodeUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "  ,SEARCHPARTSPOSCODERF" + Environment.NewLine;
                sqlText += "  ,SEARCHPARTSPOSNAMERF" + Environment.NewLine;
                sqlText += "  ,POSDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,TBSPARTSCODERF" + Environment.NewLine;
                sqlText += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                sqlText += "  ,OFFERDATERF" + Environment.NewLine;
                sqlText += "  ,OFFERDATADIVRF" + Environment.NewLine;
                sqlText += " FROM PARTSPOSCODEURF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, partsPosCodeUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    partsPosCodeUList.Add(this.CopyToPartsPosCodeUWorkFromReader(ref myReader));
                }

                if (partsPosCodeUList.Count > 0)
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
        /// 部位マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="partsPosCodeUList">追加・更新する部位マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList に格納されている部位マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref object partsPosCodeUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = partsPosCodeUList as ArrayList;

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
        /// 部位マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="partsPosCodeUList">追加・更新する部位マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList に格納されている部位マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref ArrayList partsPosCodeUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref partsPosCodeUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部位マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="partsPosCodeUList">追加・更新する部位マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUList に格納されている部位マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int WriteProc(ref ArrayList partsPosCodeUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (partsPosCodeUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsPosCodeUList.Count; i++)
                    {
                        PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUList[i] as PartsPosCodeUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                        sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                        findParaSectionCode.Value = partsPosCodeUWork.SectionCode.Trim();
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                        findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != partsPosCodeUWork.UpdateDateTime)
                            {
                                if (partsPosCodeUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE PARTSPOSCODEURF SET" + Environment.NewLine;
                            sqlText += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " , SEARCHPARTSPOSCODERF=@SEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += " , SEARCHPARTSPOSNAMERF=@SEARCHPARTSPOSNAME" + Environment.NewLine;
                            sqlText += " , POSDISPORDERRF=@POSDISPORDER" + Environment.NewLine;
                            sqlText += " , TBSPARTSCODERF=@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += " , TBSPARTSCDDERIVEDNORF=@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += " , OFFERDATERF = @OFFERDATE" + Environment.NewLine;
                            sqlText += " , OFFERDATADIVRF = @OFFERDATADIV" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                            findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                            findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsPosCodeUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);

                            //提供データを修正した場合は提供データ区分に１をセットする
                            if ((partsPosCodeUWork.OfferDate != DateTime.MinValue) && (partsPosCodeUWork.OfferDataDiv == 0))
                            {
                                partsPosCodeUWork.OfferDataDiv = 1;
                            }
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (partsPosCodeUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO PARTSPOSCODEURF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "  ,SECTIONCODERF" + Environment.NewLine;
                            sqlText += "  ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "  ,SEARCHPARTSPOSCODERF" + Environment.NewLine;
                            sqlText += "  ,SEARCHPARTSPOSNAMERF" + Environment.NewLine;
                            sqlText += "  ,POSDISPORDERRF" + Environment.NewLine;
                            sqlText += "  ,TBSPARTSCODERF" + Environment.NewLine;
                            sqlText += "  ,TBSPARTSCDDERIVEDNORF" + Environment.NewLine;
                            sqlText += "  , OFFERDATERF" + Environment.NewLine;
                            sqlText += "  , OFFERDATADIVRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "  ,@SECTIONCODE" + Environment.NewLine;
                            sqlText += "  ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  ,@SEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  ,@SEARCHPARTSPOSNAME" + Environment.NewLine;
                            sqlText += "  ,@POSDISPORDER" + Environment.NewLine;
                            sqlText += "  ,@TBSPARTSCODE" + Environment.NewLine;
                            sqlText += "  ,@TBSPARTSCDDERIVEDNO" + Environment.NewLine;
                            sqlText += "  ,@OFFERDATE" + Environment.NewLine;
                            sqlText += "  ,@OFFERDATADIV" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsPosCodeUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameterオブジェクトの作成(更新用)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);  // 作成日時
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);  // 更新日時
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);  // 企業コード
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);  // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);  // 更新従業員コード
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);  // 更新アセンブリID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);  // 更新アセンブリID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);  // 論理削除区分
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);  // 拠点コード
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);  // 得意先コード
                        SqlParameter paraSearchPartsPosCode = sqlCommand.Parameters.Add("@SEARCHPARTSPOSCODE", SqlDbType.Int);  // 検索部位コード
                        SqlParameter paraSearchPartsPosName = sqlCommand.Parameters.Add("@SEARCHPARTSPOSNAME", SqlDbType.NVarChar);  // 検索部位コード名称
                        SqlParameter paraPosDispOrder = sqlCommand.Parameters.Add("@POSDISPORDER", SqlDbType.Int);  // 検索部位表示順位
                        SqlParameter paraTbsPartsCode = sqlCommand.Parameters.Add("@TBSPARTSCODE", SqlDbType.Int);  // 翼部品コード
                        SqlParameter paraTbsPartsCdDerivedNo = sqlCommand.Parameters.Add("@TBSPARTSCDDERIVEDNO", SqlDbType.Int);  // 翼部品コード枝番
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);  // 提供日付
                        SqlParameter paraOfferDataDiv = sqlCommand.Parameters.Add("@OFFERDATADIV", SqlDbType.Int);  // 提供データ区分
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsPosCodeUWork.CreateDateTime);  // 作成日時
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsPosCodeUWork.UpdateDateTime);  // 更新日時
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);  // 企業コード
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(partsPosCodeUWork.FileHeaderGuid);  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdEmployeeCode);  // 更新従業員コード
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId1);  // 更新アセンブリID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId2);  // 更新アセンブリID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.LogicalDeleteCode);  // 論理削除区分
                        paraSectionCode.Value = partsPosCodeUWork.SectionCode.Trim();  // 拠点コード
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);  // 得意先コード
                        paraSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);  // 検索部位コード
                        paraSearchPartsPosName.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.SearchPartsPosName);  // 検索部位コード名称
                        paraPosDispOrder.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.PosDispOrder);  // 検索部位表示順位
                        paraTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);  // 翼部品コード
                        paraTbsPartsCdDerivedNo.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCdDerivedNo);  // 翼部品コード枝番
                        paraOfferDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(partsPosCodeUWork.OfferDate);  // 提供日付
                        paraOfferDataDiv.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.OfferDataDiv);  // 提供データ区分
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsPosCodeUWork);
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

            partsPosCodeUList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 部位マスタ情報を論理削除します。
        /// </summary>
        /// <param name="partsPosCodeUList">論理削除する部位マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されている部位マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref object partsPosCodeUList)
        {
            return this.LogicalDelete(ref partsPosCodeUList, 0);
        }

        /// <summary>
        /// 部位マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="partsPosCodeUList">論理削除を解除する部位マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されている部位マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int RevivalLogicalDelete(ref object partsPosCodeUList)
        {
            return this.LogicalDelete(ref partsPosCodeUList, 1);
        }

        /// <summary>
        /// 部位マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="partsPosCodeUList">論理削除を操作する部位マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されている部位マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDelete(ref object partsPosCodeUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = partsPosCodeUList as ArrayList;

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
        /// 部位マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="partsPosCodeUList">論理削除を操作する部位マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されている部位マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref ArrayList partsPosCodeUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref partsPosCodeUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部位マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="partsPosCodeUList">論理削除を操作する部位マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsPosCodeUWork に格納されている部位マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDeleteProc(ref ArrayList partsPosCodeUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (partsPosCodeUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsPosCodeUList.Count; i++)
                    {
                        PartsPosCodeUWork partsPosCodeUWork = partsPosCodeUList[i] as PartsPosCodeUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                        sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                        SqlParameter findParaTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                        findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                        findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                        findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != partsPosCodeUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PARTSPOSCODEURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND SEARCHPARTSPOSCODERF=@FINDSEARCHPARTSPOSCODE" + Environment.NewLine;
                            sqlText += "  AND TBSPARTSCODERF=@FINDTBSPARTSCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            // Parameterオブジェクトへ値設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);
                            findParaSectionCode.Value = partsPosCodeUWork.SectionCode;
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);
                            findParaSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
                            findParaTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsPosCodeUWork;
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
                            else if (logicalDelCd == 0) partsPosCodeUWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else partsPosCodeUWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                partsPosCodeUWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsPosCodeUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsPosCodeUWork);
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

            partsPosCodeUList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="partsPosCodeUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PartsPosCodeUWork partsPosCodeUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsPosCodeUWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            
            //拠点コード
            if (string.IsNullOrEmpty(partsPosCodeUWork.SectionCode) == false)
            {
                retstring += "AND SECTIONCODERF = @FINDSECTIONCODE" + Environment.NewLine;
                SqlParameter findSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                findSectionCode.Value = partsPosCodeUWork.SectionCode;
            }

            //得意先コード
            if (partsPosCodeUWork.CustomerCode != 0)
            {
                retstring += "AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.CustomerCode);

            }

            //検索部位コード
            if (partsPosCodeUWork.SearchPartsPosCode != 0)
            {
                retstring += "AND SEARCHPARTSPOSCODERF = @FINDSEARCHPARTSPOSCODE"  + Environment.NewLine;
                SqlParameter findSearchPartsPosCode = sqlCommand.Parameters.Add("@FINDSEARCHPARTSPOSCODE", SqlDbType.Int);
                findSearchPartsPosCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.SearchPartsPosCode);
            }    

            //BLコード
            if (partsPosCodeUWork.TbsPartsCode != 0)
            {
                retstring += "AND TBSPARTSCODERF = @FINDTBSPARTSCODE"  + Environment.NewLine;
                SqlParameter findTbsPartsCode = sqlCommand.Parameters.Add("@FINDTBSPARTSCODE", SqlDbType.Int);
                findTbsPartsCode.Value = SqlDataMediator.SqlSetInt32(partsPosCodeUWork.TbsPartsCode);
            }    

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PartsPosCodeUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PartsPosCodeUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private PartsPosCodeUWork CopyToPartsPosCodeUWorkFromReader(ref SqlDataReader myReader)
        {
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();

            this.CopyToPartsPosCodeUWorkFromReader(ref myReader, ref partsPosCodeUWork);

            return partsPosCodeUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → PartsPosCodeUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="partsPosCodeUWork">PartsPosCodeUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private void CopyToPartsPosCodeUWorkFromReader(ref SqlDataReader myReader, ref PartsPosCodeUWork partsPosCodeUWork)
        {
            if (myReader != null && partsPosCodeUWork != null)
            {
                # region クラスへ格納
                partsPosCodeUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // 作成日時
                partsPosCodeUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // 更新日時
                partsPosCodeUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));  // 企業コード
                partsPosCodeUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));  // GUID
                partsPosCodeUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));  // 更新従業員コード
                partsPosCodeUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));  // 更新アセンブリID1
                partsPosCodeUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));  // 更新アセンブリID2
                partsPosCodeUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));  // 論理削除区分
                partsPosCodeUWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));  // 拠点コード
                partsPosCodeUWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));  // 得意先コード
                partsPosCodeUWork.SearchPartsPosCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SEARCHPARTSPOSCODERF"));  // 検索部位コード
                partsPosCodeUWork.SearchPartsPosName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SEARCHPARTSPOSNAMERF"));  // 検索部位コード名称
                partsPosCodeUWork.PosDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSDISPORDERRF"));  // 検索部位表示順位
                partsPosCodeUWork.TbsPartsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCODERF"));  // 翼部品コード
                partsPosCodeUWork.TbsPartsCdDerivedNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TBSPARTSCDDERIVEDNORF"));  // 翼部品コード枝番
                partsPosCodeUWork.OfferDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("OFFERDATERF"));  // 提供日付
                partsPosCodeUWork.OfferDataDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATADIVRF"));  // 提供データ区分
                # endregion
            }
        }
        # endregion
    }
}

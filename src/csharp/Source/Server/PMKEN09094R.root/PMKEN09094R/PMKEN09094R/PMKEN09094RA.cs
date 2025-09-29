//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   部品代替マスタDBリモートオブジェクト
//                  :   PMKEN09094R.DLL
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
    /// 部品代替マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品代替マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 22008　長内 数馬</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PartsSubstUDB : RemoteWithAppLockDB, IPartsSubstUDB
    {
        /// <summary>
        /// 部品代替マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public PartsSubstUDB() : base("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork", "PARTSSUBSTURF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の部品代替マスタ情報を取得します。
        /// </summary>
        /// <param name="partsSubstUObj">PartsSubstUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する部品代替マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref object partsSubstUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PartsSubstUWork partsSubstUWork = partsSubstUObj as PartsSubstUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref partsSubstUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一の部品代替マスタ情報を取得します。
        /// </summary>
        /// <param name="partsSubstUWork">PartsSubstUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する部品代替マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref PartsSubstUWork partsSubstUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref partsSubstUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の部品代替マスタ情報を取得します。
        /// </summary>
        /// <param name="partsSubstUWork">PartsSubstUWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する部品代替マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int ReadProc(ref PartsSubstUWork partsSubstUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   PRT.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,PRT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,PRT.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCGOODSNORF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCGOODSNONONEHPRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTGOODSNONONEHPRF" + Environment.NewLine;
                sqlText += "  ,PRT.APPLYSTADATERF" + Environment.NewLine;
                sqlText += "  ,PRT.APPLYENDDATERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS CHGSRCGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS CHGDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS CHGSRCMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS CHGDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM PARTSSUBSTURF AS PRT" + Environment.NewLine;

                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCGOODSNORF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCMAKERCDRF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTGOODSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCMAKERCDRF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;

                sqlText += " WHERE PRT.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND PRT.CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD" + Environment.NewLine;
                sqlText += "  AND PRT.CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);


                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPartsSubstUWorkFromReader(ref myReader, ref partsSubstUWork);
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
        /// 部品代替マスタ情報を物理削除します
        /// </summary>
        /// <param name="partsSubstUList">物理削除する部品代替マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する部品代替マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Delete(object partsSubstUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = partsSubstUList as ArrayList;

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
        /// 部品代替マスタ情報を物理削除します
        /// </summary>
        /// <param name="partsSubstUList">部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList に格納されている部品代替マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Delete(ArrayList partsSubstUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(partsSubstUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部品代替マスタ情報を物理削除します
        /// </summary>
        /// <param name="partsSubstUList">部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList に格納されている部品代替マスタ情報を物理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int DeleteProc(ArrayList partsSubstUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (partsSubstUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsSubstUList.Count; i++)
                    {
                        PartsSubstUWork partsSubstUWork = partsSubstUList[i] as PartsSubstUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                        SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                        findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                        findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != partsSubstUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                            findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                            findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);

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
        /// 部品代替マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="partsSubstUList">検索結果</param>
        /// <param name="partsSubstUObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する、全ての部品代替マスタ情報を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref object partsSubstUList, object partsSubstUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList partsSubstUArray = partsSubstUList as ArrayList;
                
                if (partsSubstUArray == null)
                {
                    partsSubstUArray = new ArrayList();
                }
                
                PartsSubstUWork partsSubstUWork = partsSubstUObj as PartsSubstUWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref partsSubstUArray, partsSubstUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// 部品代替マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="partsSubstUList">部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="partsSubstUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する、全ての部品代替マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref ArrayList partsSubstUList, PartsSubstUWork partsSubstUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref partsSubstUList, partsSubstUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部品代替マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="partsSubstUList">部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="partsSubstUWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 部品代替マスタのキー値が一致する、全ての部品代替マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int SearchProc(ref ArrayList partsSubstUList, PartsSubstUWork partsSubstUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   PRT.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,PRT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,PRT.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCGOODSNORF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCGOODSNONONEHPRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTGOODSNONONEHPRF" + Environment.NewLine;
                sqlText += "  ,PRT.APPLYSTADATERF" + Environment.NewLine;
                sqlText += "  ,PRT.APPLYENDDATERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS CHGSRCGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS CHGDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS CHGSRCMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS CHGDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM PARTSSUBSTURF AS PRT" + Environment.NewLine;

                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCGOODSNORF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCMAKERCDRF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTGOODSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCMAKERCDRF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, partsSubstUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    partsSubstUList.Add(this.CopyToPartsSubstUWorkFromReader(ref myReader));
                }

                if (partsSubstUList.Count > 0)
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
        /// 部品代替マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="partsSubstUList">追加・更新する部品代替マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList に格納されている部品代替マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Write(ref object partsSubstUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = partsSubstUList as ArrayList;

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
        /// 部品代替マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="partsSubstUList">追加・更新する部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList に格納されている部品代替マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int Write(ref ArrayList partsSubstUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref partsSubstUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部品代替マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="partsSubstUList">追加・更新する部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList に格納されている部品代替マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int WriteProc(ref ArrayList partsSubstUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (partsSubstUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsSubstUList.Count; i++)
                    {
                        PartsSubstUWork partsSubstUWork = partsSubstUList[i] as PartsSubstUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                        SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                        findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                        findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != partsSubstUWork.UpdateDateTime)
                            {
                                if (partsSubstUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE PARTSSUBSTURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , CHGSRCMAKERCDRF=@CHGSRCMAKERCD , CHGSRCGOODSNORF=@CHGSRCGOODSNO , CHGSRCGOODSNONONEHPRF=@CHGSRCGOODSNONONEHP , CHGDESTMAKERCDRF=@CHGDESTMAKERCD , CHGDESTGOODSNORF=@CHGDESTGOODSNO , CHGDESTGOODSNONONEHPRF=@CHGDESTGOODSNONONEHP , APPLYSTADATERF=@APPLYSTADATE , APPLYENDDATERF=@APPLYENDDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                            findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                            findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsSubstUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (partsSubstUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO PARTSSUBSTURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CHGSRCMAKERCDRF, CHGSRCGOODSNORF, CHGSRCGOODSNONONEHPRF, CHGDESTMAKERCDRF, CHGDESTGOODSNORF, CHGDESTGOODSNONONEHPRF, APPLYSTADATERF, APPLYENDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CHGSRCMAKERCD, @CHGSRCGOODSNO, @CHGSRCGOODSNONONEHP, @CHGDESTMAKERCD, @CHGDESTGOODSNO, @CHGDESTGOODSNONONEHP, @APPLYSTADATE, @APPLYENDDATE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsSubstUWork;
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
                        SqlParameter paraChgSrcMakerCd = sqlCommand.Parameters.Add("@CHGSRCMAKERCD", SqlDbType.Int);
                        SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@CHGSRCGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraChgSrcGoodsNoNoneHp = sqlCommand.Parameters.Add("@CHGSRCGOODSNONONEHP", SqlDbType.NVarChar);
                        SqlParameter paraChgDestMakerCd = sqlCommand.Parameters.Add("@CHGDESTMAKERCD", SqlDbType.Int);
                        SqlParameter paraChgDestGoodsNo = sqlCommand.Parameters.Add("@CHGDESTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraChgDestGoodsNoNoneHp = sqlCommand.Parameters.Add("@CHGDESTGOODSNONONEHP", SqlDbType.NVarChar);
                        SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);


                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsSubstUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsSubstUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(partsSubstUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.LogicalDeleteCode);
                        paraChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                        paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);
                        paraChgSrcGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNoNoneHp);
                        paraChgDestMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgDestMakerCd);
                        paraChgDestGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgDestGoodsNo);
                        paraChgDestGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgDestGoodsNoNoneHp);
                        paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(partsSubstUWork.ApplyStaDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(partsSubstUWork.ApplyEndDate);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsSubstUWork);
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

            partsSubstUList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 部品代替マスタ情報を論理削除します。
        /// </summary>
        /// <param name="partsSubstUList">論理削除する部品代替マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork に格納されている部品代替マスタ情報を論理削除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int LogicalDelete(ref object partsSubstUList)
        {
            return this.LogicalDelete(ref partsSubstUList, 0);
        }

        /// <summary>
        /// 部品代替マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="partsSubstUList">論理削除を解除する部品代替マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork に格納されている部品代替マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int RevivalLogicalDelete(ref object partsSubstUList)
        {
            return this.LogicalDelete(ref partsSubstUList, 1);
        }

        /// <summary>
        /// 部品代替マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="partsSubstUList">論理削除を操作する部品代替マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork に格納されている部品代替マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int LogicalDelete(ref object partsSubstUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = partsSubstUList as ArrayList;

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
        /// 部品代替マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="partsSubstUList">論理削除を操作する部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork に格納されている部品代替マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        public int LogicalDelete(ref ArrayList partsSubstUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref partsSubstUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 部品代替マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="partsSubstUList">論理削除を操作する部品代替マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork に格納されている部品代替マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private int LogicalDeleteProc(ref ArrayList partsSubstUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (partsSubstUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsSubstUList.Count; i++)
                    {
                        PartsSubstUWork partsSubstUWork = partsSubstUList[i] as PartsSubstUWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                        SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);


                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                        findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                        findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != partsSubstUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                            findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                            findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsSubstUWork;
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
                            else if (logicalDelCd == 0) partsSubstUWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else partsSubstUWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                partsSubstUWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsSubstUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsSubstUWork);
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

            partsSubstUList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="partsSubstUWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PartsSubstUWork partsSubstUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // 企業コード
            retstring += "  PRT.ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND PRT.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND PRT.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //変換元メーカー
            if (partsSubstUWork.ChgSrcMakerCd != 0)
            {
                retstring += "AND PRT.CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD ";
                SqlParameter paraChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                paraChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
            }

            //変換元商品番号
            if (partsSubstUWork.ChgSrcGoodsNo != "")
            {
                retstring += "AND PRT.CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO ";
                SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);
                paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → PartsSubstUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PartsSubstUWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private PartsSubstUWork CopyToPartsSubstUWorkFromReader(ref SqlDataReader myReader)
        {
            PartsSubstUWork partsSubstUWork = new PartsSubstUWork();

            this.CopyToPartsSubstUWorkFromReader(ref myReader, ref partsSubstUWork);

            return partsSubstUWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → PartsSubstUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="partsSubstUWork">PartsSubstUWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008　長内 数馬</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private void CopyToPartsSubstUWorkFromReader(ref SqlDataReader myReader, ref PartsSubstUWork partsSubstUWork)
        {
            if (myReader != null && partsSubstUWork != null)
            {
                # region クラスへ格納
                partsSubstUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                partsSubstUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                partsSubstUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                partsSubstUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                partsSubstUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                partsSubstUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                partsSubstUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                partsSubstUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                partsSubstUWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                partsSubstUWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                partsSubstUWork.ChgSrcGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNONONEHPRF"));
                partsSubstUWork.ChgDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                partsSubstUWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                partsSubstUWork.ChgDestGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNONONEHPRF"));
                partsSubstUWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                partsSubstUWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
                partsSubstUWork.ChgSrcGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNAMERF"));
                partsSubstUWork.ChgDestGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNAMERF"));
                partsSubstUWork.ChgSrcMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCMAKERNAMERF"));
                partsSubstUWork.ChgDestMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTMAKERNAMERF"));
                # endregion
            }
        }
        # endregion
    }
}

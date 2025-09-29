//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   CustSlipNoSetDBリモートオブジェクト
//                  :   PMKHN09104R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   20081 疋田 勇人
// Date             :   2008.06.16
//----------------------------------------------------------------------
// Update Note      :   21112 久保田 誠
//                  :   2008.12.22  得意先伝票番号取得メソッドの追加
//----------------------------------------------------------------------
// Update Note      :   鄧潘ハン
//                  :   2010/12/22  ①得意先マスタ（伝票番号）の抽出区分が期末の場合の採番方法の不具合を修正  
//----------------------------------------------------------------------
// Update Note      :   2012/02/06 丁建雄</br>
// 管理番号         :   10707327-00 2012/03/28配信分</br>
//                      Redmine#28336 得意先伝票番号採番の不具合の対応</br>
//----------------------------------------------------------------------
// Update Note      :   2019/05/17 田建委</br>
// 管理番号         :   11575089-00 </br>
//                      Redmine#49749 締毎の場合に、得意先伝票番号採番の不具合の対応</br>
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// CustSlipNoSetDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : CustSlipNoSetの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 20081 疋田 勇人</br>
    /// <br>Date       : 2008.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CustSlipNoSetDB : RemoteWithAppLockDB, ICustSlipNoSetDB
    {
        /// <summary>
        /// CustSlipNoSetDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        public CustSlipNoSetDB()
            : base("PMKHN09106D", "Broadleaf.Application.Remoting.ParamData.CustSlipNoSetWork", "CustSlipNoSetRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一のCustSlipNoSet情報を取得します。
        /// </summary>
        /// <param name="custSlipNoSetObj">CustSlipNoSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致するCustSlipNoSet情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int Read(ref object custSlipNoSetObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetObj as CustSlipNoSetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref custSlipNoSetWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一のCustSlipNoSet情報を取得します。
        /// </summary>
        /// <param name="custSlipNoSetWork">CustSlipNoSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致するCustSlipNoSet情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int Read(ref CustSlipNoSetWork custSlipNoSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref custSlipNoSetWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一のCustSlipNoSet情報を取得します。
        /// </summary>
        /// <param name="custSlipNoSetWork">CustSlipNoSetWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致するCustSlipNoSet情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        private int ReadProc(ref CustSlipNoSetWork custSlipNoSetWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.PRESENTCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.STARTCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ENDCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " FROM CUSTSLIPNOSETRF CUSTSLIP" + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += " WHERE CUSTSLIP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "    AND CUSTSLIP.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "    AND CUSTSLIP.ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                // Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCustSlipNoSetWorkFromReader(ref myReader, ref custSlipNoSetWork);
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
        /// CustSlipNoSet情報を物理削除します
        /// </summary>
        /// <param name="custSlipNoSetList">物理削除するCustSlipNoSet情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致するCustSlipNoSet情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int Delete(object custSlipNoSetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = custSlipNoSetList as ArrayList;

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
        /// CustSlipNoSet情報を物理削除します
        /// </summary>
        /// <param name="custSlipNoSetList">CustSlipNoSet情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList に格納されているCustSlipNoSet情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int Delete(ArrayList custSlipNoSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(custSlipNoSetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// CustSlipNoSet情報を物理削除します
        /// </summary>
        /// <param name="custSlipNoSetList">CustSlipNoSet情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList に格納されているCustSlipNoSet情報を物理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        private int DeleteProc(ArrayList custSlipNoSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (custSlipNoSetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < custSlipNoSetList.Count; i++)
                    {
                        CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetList[i] as CustSlipNoSetWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != custSlipNoSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                            findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

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
        /// CustSlipNoSet情報のリストを取得します。
        /// </summary>
        /// <param name="custSlipNoSetList">検索結果</param>
        /// <param name="custSlipNoSetObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致する、全てのCustSlipNoSet情報を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int Search(ref object custSlipNoSetList, object custSlipNoSetObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList custSlipNoSetArray = custSlipNoSetList as ArrayList;

                if (custSlipNoSetArray == null)
                {
                    custSlipNoSetArray = new ArrayList();
                }

                CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetObj as CustSlipNoSetWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref custSlipNoSetArray, custSlipNoSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// CustSlipNoSet情報のリストを取得します。
        /// </summary>
        /// <param name="custSlipNoSetList">CustSlipNoSet情報を格納する ArrayList</param>
        /// <param name="custSlipNoSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致する、全てのCustSlipNoSet情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int Search(ref ArrayList custSlipNoSetList, CustSlipNoSetWork custSlipNoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref custSlipNoSetList, custSlipNoSetWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// CustSlipNoSet情報のリストを取得します。
        /// </summary>
        /// <param name="custSlipNoSetList">CustSlipNoSet情報を格納する ArrayList</param>
        /// <param name="custSlipNoSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetのキー値が一致する、全てのCustSlipNoSet情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        private int SearchProc(ref ArrayList custSlipNoSetList, CustSlipNoSetWork custSlipNoSetWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += "SELECT CUSTSLIP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ADDUPYEARMONTHRF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.PRESENTCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.STARTCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUSTSLIP.ENDCUSTSLIPNORF" + Environment.NewLine;
                sqlText += "    ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " FROM CUSTSLIPNOSETRF CUSTSLIP" + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTSLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "    AND CUST.CUSTOMERCODERF=CUSTSLIP.CUSTOMERCODERF" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, custSlipNoSetWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    custSlipNoSetList.Add(this.CopyToCustSlipNoSetWorkFromReader(ref myReader));
                }

                if (custSlipNoSetList.Count > 0)
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
        /// CustSlipNoSet情報を追加・更新します。
        /// </summary>
        /// <param name="custSlipNoSetList">追加・更新するCustSlipNoSet情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList に格納されているCustSlipNoSet情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int Write(ref object custSlipNoSetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = custSlipNoSetList as ArrayList;

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
        /// CustSlipNoSet情報を追加・更新します。
        /// </summary>
        /// <param name="custSlipNoSetList">追加・更新するCustSlipNoSet情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList に格納されているCustSlipNoSet情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int Write(ref ArrayList custSlipNoSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref custSlipNoSetList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// CustSlipNoSet情報を追加・更新します。
        /// </summary>
        /// <param name="custSlipNoSetList">追加・更新するCustSlipNoSet情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetList に格納されているCustSlipNoSet情報を追加・更新します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        private int WriteProc(ref ArrayList custSlipNoSetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (custSlipNoSetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < custSlipNoSetList.Count; i++)
                    {
                        CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetList[i] as CustSlipNoSetWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += "    ,PRESENTCUSTSLIPNORF" + Environment.NewLine;
                        sqlText += "    ,STARTCUSTSLIPNORF" + Environment.NewLine;
                        sqlText += "    ,ENDCUSTSLIPNORF" + Environment.NewLine;
                        sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != custSlipNoSetWork.UpdateDateTime)
                            {
                                if (custSlipNoSetWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += "UPDATE CUSTSLIPNOSETRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " , ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                            sqlText += " , PRESENTCUSTSLIPNORF=@PRESENTCUSTSLIPNO" + Environment.NewLine;
                            sqlText += " , STARTCUSTSLIPNORF=@STARTCUSTSLIPNO" + Environment.NewLine;
                            sqlText += " , ENDCUSTSLIPNORF=@ENDCUSTSLIPNO" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                            findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSlipNoSetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (custSlipNoSetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CUSTSLIPNOSETRF" + Environment.NewLine;
                            sqlText += " (CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "    ,ADDUPYEARMONTHRF" + Environment.NewLine;
                            sqlText += "    ,PRESENTCUSTSLIPNORF" + Environment.NewLine;
                            sqlText += "    ,STARTCUSTSLIPNORF" + Environment.NewLine;
                            sqlText += "    ,ENDCUSTSLIPNORF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    ,@ADDUPYEARMONTH" + Environment.NewLine;
                            sqlText += "    ,@PRESENTCUSTSLIPNO" + Environment.NewLine;
                            sqlText += "    ,@STARTCUSTSLIPNO" + Environment.NewLine;
                            sqlText += "    ,@ENDCUSTSLIPNO" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSlipNoSetWork;
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
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                        SqlParameter paraPresentCustSlipNo = sqlCommand.Parameters.Add("@PRESENTCUSTSLIPNO", SqlDbType.BigInt);
                        SqlParameter paraStartCustSlipNo = sqlCommand.Parameters.Add("@STARTCUSTSLIPNO", SqlDbType.BigInt);
                        SqlParameter paraEndCustSlipNo = sqlCommand.Parameters.Add("@ENDCUSTSLIPNO", SqlDbType.BigInt);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSlipNoSetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSlipNoSetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(custSlipNoSetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                        paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);
                        paraPresentCustSlipNo.Value = SqlDataMediator.SqlSetInt64(custSlipNoSetWork.PresentCustSlipNo);
                        paraStartCustSlipNo.Value = SqlDataMediator.SqlSetInt64(custSlipNoSetWork.StartCustSlipNo);
                        paraEndCustSlipNo.Value = SqlDataMediator.SqlSetInt64(custSlipNoSetWork.EndCustSlipNo);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custSlipNoSetWork);
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

            custSlipNoSetList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// CustSlipNoSet情報を論理削除します。
        /// </summary>
        /// <param name="custSlipNoSetList">論理削除するCustSlipNoSet情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork に格納されているCustSlipNoSet情報を論理削除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int LogicalDelete(ref object custSlipNoSetList)
        {
            return this.LogicalDelete(ref custSlipNoSetList, 0);
        }

        /// <summary>
        /// CustSlipNoSet情報の論理削除を解除します。
        /// </summary>
        /// <param name="custSlipNoSetList">論理削除を解除するCustSlipNoSet情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork に格納されているCustSlipNoSet情報の論理削除を解除します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int RevivalLogicalDelete(ref object custSlipNoSetList)
        {
            return this.LogicalDelete(ref custSlipNoSetList, 1);
        }

        /// <summary>
        /// CustSlipNoSet情報の論理削除を操作します。
        /// </summary>
        /// <param name="custSlipNoSetList">論理削除を操作するCustSlipNoSet情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork に格納されているCustSlipNoSet情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        private int LogicalDelete(ref object custSlipNoSetList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = custSlipNoSetList as ArrayList;

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
        /// CustSlipNoSet情報の論理削除を操作します。
        /// </summary>
        /// <param name="custSlipNoSetList">論理削除を操作するCustSlipNoSet情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork に格納されているCustSlipNoSet情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        public int LogicalDelete(ref ArrayList custSlipNoSetList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref custSlipNoSetList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// CustSlipNoSet情報の論理削除を操作します。
        /// </summary>
        /// <param name="custSlipNoSetList">論理削除を操作するCustSlipNoSet情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : CustSlipNoSetWork に格納されているCustSlipNoSet情報の論理削除を操作します。</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        private int LogicalDeleteProc(ref ArrayList custSlipNoSetList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (custSlipNoSetList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < custSlipNoSetList.Count; i++)
                    {
                        CustSlipNoSetWork custSlipNoSetWork = custSlipNoSetList[i] as CustSlipNoSetWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " FROM CUSTSLIPNOSETRF" + Environment.NewLine;
                        sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                        // Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != custSlipNoSetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  CUSTSLIPNOSETRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
                            findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);

                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)custSlipNoSetWork;
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
                            else if (logicalDelCd == 0) custSlipNoSetWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else custSlipNoSetWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                custSlipNoSetWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(custSlipNoSetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(custSlipNoSetWork);
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

            custSlipNoSetList = al;

            return status;
        }
        # endregion

        # region [Where文作成処理]
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="sqlCommand">SqlCommandオブジェクト</param>
        /// <param name="custSlipNoSetWork">検索条件格納クラス</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>Where条件文字列</returns>
        /// <br>Note       : Where句を作成して戻します</br>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, CustSlipNoSetWork custSlipNoSetWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // 企業コード
            retstring += "  CUSTSLIP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSlipNoSetWork.EnterpriseCode);

            // 論理削除区分
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND CUSTSLIP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND CUSTSLIP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            // 得意先コード
            if (custSlipNoSetWork.CustomerCode != 0)
            {
                retstring += "  AND CUSTSLIP.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.CustomerCode);
            }

            // 計上年月
            if (custSlipNoSetWork.AddUpYearMonth >= 0)
            {
                retstring += "  AND CUSTSLIP.ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter findAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                findAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(custSlipNoSetWork.AddUpYearMonth);
            }

            return retstring;
        }
        # endregion

        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CustSlipNoSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustSlipNoSetWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private CustSlipNoSetWork CopyToCustSlipNoSetWorkFromReader(ref SqlDataReader myReader)
        {
            CustSlipNoSetWork custSlipNoSetWork = new CustSlipNoSetWork();

            this.CopyToCustSlipNoSetWorkFromReader(ref myReader, ref custSlipNoSetWork);

            return custSlipNoSetWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CustSlipNoSetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="custSlipNoSetWork">CustSlipNoSetWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 20081 疋田 勇人</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        private void CopyToCustSlipNoSetWorkFromReader(ref SqlDataReader myReader, ref CustSlipNoSetWork custSlipNoSetWork)
        {
            if (myReader != null && custSlipNoSetWork != null)
            {
                # region クラスへ格納
                custSlipNoSetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                custSlipNoSetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                custSlipNoSetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                custSlipNoSetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                custSlipNoSetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                custSlipNoSetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                custSlipNoSetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                custSlipNoSetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                custSlipNoSetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                custSlipNoSetWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                custSlipNoSetWork.AddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                custSlipNoSetWork.PresentCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PRESENTCUSTSLIPNORF"));
                custSlipNoSetWork.StartCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STARTCUSTSLIPNORF"));
                custSlipNoSetWork.EndCustSlipNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ENDCUSTSLIPNORF"));
                # endregion
            }
        }
        # endregion

        # region [得意先伝票番号取得処理]

        /// <summary>
        /// 得意先伝票番号取得処理でのみ使用するデータクラス
        /// </summary>
        private class TmpCustSlipNoWork : CustSlipNoSetWork
        {
            public int TotalDay;           // 締日
            public int CustomerSlipNoDiv;  // 得意先伝票番号区分
        }

        private CompanyInfWork _CompanyInfWork = null;

        private CompanyInfWork GetCompanyInformation(string enterpriseCode)
        {
            if (this._CompanyInfWork == null)
            {
                CompanyInfDB companyInfDB = new CompanyInfDB();

                CompanyInfWork companyInfWork = new CompanyInfWork();

                companyInfWork.EnterpriseCode = enterpriseCode;
                companyInfWork.CompanyCode = 0;

                byte[] paraByte = XmlByteSerializer.Serialize(companyInfWork);

                int status = companyInfDB.Read(ref paraByte, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._CompanyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(paraByte, typeof(CompanyInfWork));
                }
            }

            return this._CompanyInfWork;
        }

        /// <summary>
        /// 得意先伝票番号を取得します
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <param name="customercode">得意先コード</param>
        /// <param name="salesdate">売上日付(計上日)</param>
        /// <param name="presentcustslipno">現在得意先伝票番号</param>
        /// <param name="connection">DB接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        public int GetCustomerSlipNo(string enterprisecode, int customercode, DateTime salesdate, out Int64 presentcustslipno, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            bool crtTran = false;  // true:トランザクションは自前で用意　false:トランザクションは呼出元が用意
            presentcustslipno = 0;

            try
            {
                # region [パラメータチェック]

                // 得意先コード
                if (customercode == 0)
                {
                    throw new Exception("得意先コードが未設定です.");
                }

                // 売上日付
                if (salesdate == DateTime.MinValue)
                {
                    throw new Exception("売上日付が未設定です.");
                }

                // DB接続情報
                if (connection == null)
                {
                    connection = this.CreateConnection(true);
                    transaction = this.CreateTransaction(ref connection);
                    crtTran = true;
                }

                # endregion

                status = this.GetCustomerSlipNoProc(enterprisecode, customercode, salesdate, out presentcustslipno, ref connection, ref transaction);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                # region [トランザクション(後)処理]
                if (crtTran)
                {
                    if (transaction != null && transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }

                        transaction.Dispose();
                        transaction = null;
                    }

                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
                # endregion
            }

            return status;
        }

        /// <summary>
        /// 得意先伝票番号を取得します
        /// </summary>
        /// <param name="enterprisecode">企業コード</param>
        /// <param name="customercode">得意先コード</param>
        /// <param name="salesdate">売上日付(計上日)</param>
        /// <param name="presentcustslipno">現在得意先伝票番号</param>
        /// <param name="connection">DB接続情報</param>
        /// <param name="transaction">トランザクション情報</param>
        /// <br>Update Note:   2010/12/22 鄧潘ハン</br>
        /// <br>               ①得意先マスタ（伝票番号）の抽出区分が期末の場合の採番方法の不具合を修正</br>
        /// <br>Update Note      :   2012/02/06 丁建雄</br>
        /// <br>                     Redmine#28336 得意先伝票番号採番の不具合の対応</br>
        /// <br>Update Note      :   2019/05/17 田建委</br>
        /// <br>                     Redmine#49749 締毎の場合に得意先伝票番号採番の不具合の対応</br>
        /// <br></br>
        /// <returns>STATUS</returns>
        private int GetCustomerSlipNoProc(string enterprisecode, int customercode, DateTime salesdate, out Int64 presentcustslipno, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
            SqlCommand command = null;
            SqlDataReader dtReader = null;

            const int DEF_PR_SLIPNO = 1;            // 現在得意先伝票番号(初期値)
            const int DEF_ST_SLIPNO = 1;            // 開始得意先伝票番号(初期値)
            const Int64 DEF_ED_SLIPNO = 999999999;  // 終了得意先伝票番号(初期値)

            presentcustslipno = DEF_PR_SLIPNO;

            try
            {
                # region [得意先データ読み込み]
                
                # region [SELECT文]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
                sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " ,SLIP.*" + Environment.NewLine;
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "  CUSTOMERRF AS CUST LEFT OUTER JOIN CUSTSLIPNOSETRF AS SLIP" + Environment.NewLine;
                sqlText += "  ON  CUST.ENTERPRISECODERF = SLIP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = SLIP.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CUST.LOGICALDELETECODERF = 0" + Environment.NewLine;
                
                // 得意先伝票番号区分に応じて、計上日付の絞込み条件を変更する
                sqlText += "  AND LEN(SLIP.ADDUPYEARMONTHRF) = CASE CUST.CUSTOMERSLIPNODIVRF" + Environment.NewLine;
                sqlText += "      WHEN 1 THEN 1" + Environment.NewLine;  // 1:連番 = 計上日付は 0 → 1桁
                sqlText += "      WHEN 2 THEN 6" + Environment.NewLine;  // 2:締毎 = 計上日付は YYYYMM → 6桁
                sqlText += "      WHEN 3 THEN 4" + Environment.NewLine;  // 3:期末 = 計上日付は YYYY → 4桁
                sqlText += "      ELSE 0 END" + Environment.NewLine;     // 上記外 = 0 即ちデータ無し
                
                sqlText += "ORDER BY" + Environment.NewLine;
                sqlText += "  SLIP.ADDUPYEARMONTHRF DESC" + Environment.NewLine;
                command = new SqlCommand(sqlText, connection, transaction);                
                # endregion                

                SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);      // 企業コード
                SqlParameter findCustomerCode = command.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);            // 得意先コード

                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterprisecode);
                findCustomerCode.Value = SqlDataMediator.SqlSetInt32(customercode);

# if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(command));
# endif

                dtReader = command.ExecuteReader();
                
                List<TmpCustSlipNoWork> ctsSlipNoList = new List<TmpCustSlipNoWork>();

                while (dtReader.Read())
                {
                    CustSlipNoSetWork cstSlpNoSetWrk = new TmpCustSlipNoWork();

                    this.CopyToCustSlipNoSetWorkFromReader(ref dtReader, ref cstSlpNoSetWrk);

                    (cstSlpNoSetWrk as TmpCustSlipNoWork).TotalDay = SqlDataMediator.SqlGetInt32(dtReader, dtReader.GetOrdinal("TOTALDAYRF"));                    // 締日
                    (cstSlpNoSetWrk as TmpCustSlipNoWork).CustomerSlipNoDiv = SqlDataMediator.SqlGetInt32(dtReader, dtReader.GetOrdinal("CUSTOMERSLIPNODIVRF"));  // 得意先伝票番号区分

                    ctsSlipNoList.Add((TmpCustSlipNoWork)cstSlpNoSetWrk);
                }

                dtReader.Close();
                dtReader.Dispose();

                # endregion

                if (ctsSlipNoList.Count > 0)
                {
                    int totalDay = ctsSlipNoList[0].TotalDay;              // 締日
                    int CstSlpNoDiv = ctsSlipNoList[0].CustomerSlipNoDiv;  // 得意先伝票番号区分

                    // 追加・更新用データ
                    TmpCustSlipNoWork wrtCstSlpNoWrk = new TmpCustSlipNoWork();

                    # region [初期値設定]
                    // ここで予め設定しておく事で、対象データが存在しない際の追加データ作成処理を省略
                    wrtCstSlpNoWrk.EnterpriseCode = enterprisecode;                                   // 企業コード
                    wrtCstSlpNoWrk.CustomerCode = customercode;                                       // 得意先コード
                    wrtCstSlpNoWrk.LogicalDeleteCode = (int)ConstantManagement.LogicalMode.GetData0;  // 論理削除区分
                    wrtCstSlpNoWrk.AddUpYearMonth = 0;                                                // 計上年月
                    wrtCstSlpNoWrk.PresentCustSlipNo = DEF_PR_SLIPNO;                                 // 現在得意先伝票番号
                    wrtCstSlpNoWrk.StartCustSlipNo = DEF_ST_SLIPNO;                                   // 開始得意先伝票番号
                    wrtCstSlpNoWrk.EndCustSlipNo = DEF_ED_SLIPNO;                                     // 終了得意先伝票番号
                    # endregion

                    // 得意先伝票番号区分による採番処理
                    switch (CstSlpNoDiv)
                    {
                        case 1:
                            {
                                # region [連番]

                                // 得意先マスタ(伝票番号)の企業コードがNULLで無い場合にデータ有りとする
                                if (!string.IsNullOrEmpty(ctsSlipNoList[0].EnterpriseCode))
                                {
                                    presentcustslipno = ctsSlipNoList[0].PresentCustSlipNo + 1;

                                    if (ctsSlipNoList[0].EndCustSlipNo < presentcustslipno)
                                    {
                                        presentcustslipno = ctsSlipNoList[0].StartCustSlipNo;
                                    }

                                    ctsSlipNoList[0].PresentCustSlipNo = presentcustslipno;
                                    
                                    wrtCstSlpNoWrk = ctsSlipNoList[0];
                                }

                                break;

                                # endregion
                            }
                        case 2:
                            {
                                # region [締毎]

                                // 売上日付から、締日を含む年月日を算出する(※締日が'28'以降の場合は月末として処理する)
                                int tmpY4 = salesdate.Year;
                                int tmpMM = salesdate.Month;
                                int tmpDD = (totalDay < 28) ? totalDay : DateTime.DaysInMonth(tmpY4, tmpMM);

                                int salesday = tmpY4 * 10000 + tmpMM * 100 + salesdate.Day;   // 数値型売上日付 // ADD BY 田建委  2019/05/17 For Redmine#49749
                                int tmpY4MMDD = tmpY4 * 10000 + tmpMM * 100 + tmpDD;   // 該当年月日
                                DateTime tmpDate = new DateTime(tmpY4, tmpMM, tmpDD);  // 日付型にしておく

                                int[] objY4MM = new int[2];  // [0]当月 [1]前月

                                // 売上日付が該当年月日以下で且つ締日が月末未満の場合は、該当月を１ヵ月戻す
                                // -------- UPD  BY 田建委  2019/05/17 For Redmine#49749 -------->>>>>
                                //if (salesdate <= tmpDate && tmpDD < 28)
                                if (salesday <= tmpY4MMDD && tmpDD < 28)
                                // -------- UPD  BY 田建委  2019/05/17 For Redmine#49749 --------<<<<<
                                {
                                    tmpDate = tmpDate.AddMonths(-1);
                                    objY4MM[0] = tmpDate.Year * 100 + tmpDate.Month;
                                }
                                else
                                {
                                    objY4MM[0] = tmpY4 * 100 + tmpMM;
                                }

                                // 更に１ヶ月前の該当月も算出しておく
                                DateTime prvDate = tmpDate.AddMonths(-1);
                                objY4MM[1] = prvDate.Year * 100 + prvDate.Month;

                                // 売上日を基準とした締対象年月を検索する
                                for (int i = 0; i < objY4MM.Length; i++)
                                {
                                    int idx = ctsSlipNoList.FindIndex(delegate(TmpCustSlipNoWork item) { return item.AddUpYearMonth == objY4MM[i]; });

                                    if (idx > -1)
                                    {
                                        if (i == 0)
                                        {
                                            // 当月で見つかった場合
                                            presentcustslipno = ctsSlipNoList[idx].PresentCustSlipNo + 1;

                                            if (ctsSlipNoList[idx].EndCustSlipNo < presentcustslipno)
                                            {
                                                presentcustslipno = ctsSlipNoList[idx].StartCustSlipNo;
                                            }

                                            ctsSlipNoList[idx].PresentCustSlipNo = presentcustslipno;

                                            wrtCstSlpNoWrk = ctsSlipNoList[idx];
                                            break;
                                        }
                                        else
                                        {
                                            // 前月で見つかった場合
                                            wrtCstSlpNoWrk.AddUpYearMonth = objY4MM[0];
                                            wrtCstSlpNoWrk.StartCustSlipNo = ctsSlipNoList[idx].StartCustSlipNo;
                                            wrtCstSlpNoWrk.EndCustSlipNo = ctsSlipNoList[idx].EndCustSlipNo;
                                            // --- ADD 丁建雄 2012/02/06 Redmine#28336 ------>>>>>
                                            presentcustslipno = ctsSlipNoList[idx].StartCustSlipNo;
                                            wrtCstSlpNoWrk.PresentCustSlipNo = presentcustslipno;
                                            // --- ADD 丁建雄 2012/02/06 Redmine#28336 ------<<<<<
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        // 当月も前月も無い場合は計上年月を初期値から変更する(他の項目は↑で設定済み)
                                        if (i == objY4MM.Length - 1)
                                        {
                                            wrtCstSlpNoWrk.AddUpYearMonth = objY4MM[0];  // 計上年月
                                            break;
                                        }
                                    }
                                }
                                
                                break;

                                # endregion
                            }
                        case 3:
                            {
                                # region [期末]

                                // 売上日より年度の取得を行う
                                CompanyInfWork cmpInf = this.GetCompanyInformation(enterprisecode);
                                FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(cmpInf);
                                int year;
                                DateTime adDate = DateTime.MinValue;
                                //dateGetAcs.GetYearMonth(salesdate, out adDate);// DEL 2010/12/22
                                dateGetAcs.GetYearMonth(salesdate, out adDate, out  year);// ADD 2010/12/22

                                int[] objY4 = new int[2];

                                //---DEL------------2010/12/22-------------------->>>>>
                                //objY4[0] = adDate.Year * 100;  // 当年

                                //adDate = adDate.AddYears(-1);
                                //objY4[1] = adDate.Year * 100;  // 前年
                                //---DEL------------2010/12/22--------------------<<<<<

                                objY4[0] = year;// ADD 2010/12/22 

                                objY4[1] = year - 1;// ADD 2010/12/22

                                for (int i = 0; i < objY4.Length; i++)
                                {
                                    int idx = ctsSlipNoList.FindIndex(delegate(TmpCustSlipNoWork item) { return item.AddUpYearMonth == objY4[i]; });

                                    if (idx > -1)
                                    {
                                        if (i == 0)
                                        {
                                            // 当年で見つかった場合
                                            presentcustslipno = ctsSlipNoList[idx].PresentCustSlipNo + 1;

                                            if (ctsSlipNoList[idx].EndCustSlipNo < presentcustslipno)
                                            {
                                                presentcustslipno = ctsSlipNoList[idx].StartCustSlipNo;
                                            }

                                            ctsSlipNoList[idx].PresentCustSlipNo = presentcustslipno;

                                            wrtCstSlpNoWrk = ctsSlipNoList[idx];
                                            break;
                                        }
                                        else
                                        {
                                            // 前年で見つかった場合
                                            wrtCstSlpNoWrk.AddUpYearMonth = objY4[0];
                                            wrtCstSlpNoWrk.StartCustSlipNo = ctsSlipNoList[idx].StartCustSlipNo;
                                            wrtCstSlpNoWrk.EndCustSlipNo = ctsSlipNoList[idx].EndCustSlipNo;
                                            // --- ADD 丁建雄 2012/02/06 Redmine#28336 ------>>>>>
                                            presentcustslipno = ctsSlipNoList[idx].StartCustSlipNo;
                                            wrtCstSlpNoWrk.PresentCustSlipNo = presentcustslipno;
                                            // --- ADD 丁建雄 2012/02/06 Redmine#28336 ------<<<<<
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        // 当年も前年も無い場合は計上年月を初期値から変更する(他の項目は↑で設定済み)
                                        if (i == objY4.Length - 1)
                                        {
                                            wrtCstSlpNoWrk.AddUpYearMonth = objY4[0];  // 計上年月
                                            break;
                                        }
                                    }
                                }

                                break;

                                # endregion
                            }
                        default:
                            {
                                // 使用しない・その他(例外)
                                wrtCstSlpNoWrk = null;
                                break;
                            }
                    }

                    if (wrtCstSlpNoWrk != null)
                    {
                        ArrayList custSlipNoSetList = new ArrayList();
                        custSlipNoSetList.Add(wrtCstSlpNoWrk);
                        
                        // 得意先マスタ(伝票番号)を更新する
                        status = this.WriteProc(ref custSlipNoSetList, ref connection, ref transaction);
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
                else
                {
                    // 得意先マスタにデータが無い場合となる
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, errmsg, ex.LineNumber);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                this.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (dtReader != null)
                {
                    if (!dtReader.IsClosed)
                    {
                        dtReader.Close();
                    }
                    dtReader.Dispose();
                }

                if (command != null)
                {
                    command.Cancel();
                    command.Dispose();
                }
            }

            return status;
        }

        # endregion

    }
}

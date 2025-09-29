//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先(掛率グループ)マスタDBリモートオブジェクト
//                  :   PMKHN09174R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   23012 畠中 啓次朗
// Date             :   2008.10.07
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// 管理番号  11770032-00 作成担当 : 30809 佐々木 亘
// 修 正 日  2021/03/25  修正内容 : 山形部品障害対応（先行配信）
//                                  ①オブジェクト参照エラー対応
//                                    ・負荷軽減のためREADUNCOMMITTED追加
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
    /// 得意先(掛率グループ)マスタDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先(掛率グループ)マスタの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.10.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CustRateGroupDB : RemoteWithAppLockDB, ICustRateGroupDB
    {
        /// <summary>
        /// 得意先(掛率グループ)マスタDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        public CustRateGroupDB(): base("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork", "CustRateGroupRF")
        {

        }

        # region [Read]
        /// <summary>
        /// 単一の得意先(掛率グループ)マスタ情報を取得します。
        /// </summary>
        /// <param name="custRateGroupObj">CustRateGroupWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する得意先(掛率グループ)マスタ情報を取得します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int Read(ref object custRateGroupObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CustRateGroupWork custRateGroupWork = custRateGroupObj as CustRateGroupWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref custRateGroupWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// 単一の得意先(掛率グループ)マスタ情報を取得します。
        /// </summary>
        /// <param name="custRateGroupWork">CustRateGroupWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する得意先(掛率グループ)マスタ情報を取得します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int Read(ref CustRateGroupWork custRateGroupWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref custRateGroupWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 単一の得意先(掛率グループ)マスタ情報を取得します。
        /// </summary>
        /// <param name="custRateGroupWork">CustRateGroupWorkオブジェクト</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する得意先(掛率グループ)マスタ情報を取得します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        private int ReadProc(ref CustRateGroupWork custRateGroupWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += " SELECT  CUSTGR.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.PURECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.CUSTRATEGRPCODERF" + Environment.NewLine;
                sqlText += "        ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " FROM CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                sqlText += "LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTGR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND CUST.CUSTOMERCODERF=CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CUSTGR.PURECODERF = @FINDPURECODE " + Environment.NewLine;
                sqlText += "  AND CUSTGR.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaPureCode = sqlCommand.Parameters.Add("@FINDPURECODE", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custRateGroupWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.CustomerCode);
                findParaPureCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.PureCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.GoodsMakerCd);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCustRateGroupWorkFromReader(ref myReader, ref custRateGroupWork);
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
        /// 得意先(掛率グループ)マスタ情報を物理削除します
        /// </summary>
        /// <param name="custRateGroupList">物理削除する得意先(掛率グループ)マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する得意先(掛率グループ)マスタ情報を物理削除します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int Delete(object custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //// パラメータのキャスト
                //ArrayList paraList = custRateGroupList as ArrayList;
                //パラメータのキャスト
                ArrayList paraList = CastToArrayListFromPara(custRateGroupList);
                if (paraList == null) return status;


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
        /// 得意先(掛率グループ)マスタ情報を物理削除します
        /// </summary>
        /// <param name="custRateGroupList">得意先(掛率グループ)マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupList に格納されている得意先(掛率グループ)マスタ情報を物理削除します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int Delete(ArrayList custRateGroupList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(custRateGroupList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報を物理削除します
        /// </summary>
        /// <param name="custRateGroupList">得意先(掛率グループ)マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupList に格納されている得意先(掛率グループ)マスタ情報を物理削除します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        private int DeleteProc(ArrayList custRateGroupList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (custRateGroupList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < custRateGroupList.Count; i++)
                    {
                        CustRateGroupWork custRateGroupWork = custRateGroupList[i] as CustRateGroupWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.PURECODERF = @FINDPURECODE " + Environment.NewLine;
                        sqlText += "  AND CUSTGR.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();

                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPureCode = sqlCommand.Parameters.Add("@FINDPURECODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custRateGroupWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.CustomerCode);
                        findParaPureCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.PureCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.GoodsMakerCd);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != custRateGroupWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE文]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  CUSTRATEGROUPRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND PURECODERF = @FINDPURECODE " + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custRateGroupWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.CustomerCode);
                            findParaPureCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.PureCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.GoodsMakerCd);

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
        /// 得意先(掛率グループ)マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="custRateGroupList">検索結果</param>
        /// <param name="custRateGroupObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する、全ての得意先(掛率グループ)マスタ情報を取得します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int Search(ref object custRateGroupList, object custRateGroupObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList custRateGroupArray = custRateGroupList as ArrayList;
                
                if (custRateGroupArray == null)
                {
                    custRateGroupArray = new ArrayList();
                }
                
                CustRateGroupWork custRateGroupWork = custRateGroupObj as CustRateGroupWork;

                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref custRateGroupArray, custRateGroupWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                custRateGroupList = custRateGroupArray;
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
        /// 得意先(掛率グループ)マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="custRateGroupList">得意先(掛率グループ)マスタ情報を格納する ArrayList</param>
        /// <param name="custRateGroupWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する、全ての得意先(掛率グループ)マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int Search(ref ArrayList custRateGroupList, CustRateGroupWork custRateGroupWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref custRateGroupList, custRateGroupWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="custRateGroupList">得意先(掛率グループ)マスタ情報を格納する ArrayList</param>
        /// <param name="custRateGroupWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 得意先(掛率グループ)マスタのキー値が一致する、全ての得意先(掛率グループ)マスタ情報が格納されている ArrayList を取得します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        /// <br>Update Note: 11770032-00 山形部品障害対応（先行対応） オブジェクト参照エラー対応（負荷軽減のためREADUNCOMMITTED追加）</br>
        /// <br>Programmer : 30809 佐々木 亘</br>
        /// <br>Date       : 2021/03/25</br>
        private int SearchProc(ref ArrayList custRateGroupList, CustRateGroupWork custRateGroupWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT文]
                sqlText += " SELECT  CUSTGR.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.PURECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.CUSTRATEGRPCODERF" + Environment.NewLine;
                sqlText += "        ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                //---UPD　30809 佐々木　亘　2021/03/25 11770032-00　オブジェクト参照エラー対応 ------>>>>>
                //sqlText += " FROM CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                //sqlText += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTGR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " FROM CUSTRATEGROUPRF AS CUSTGR WITH(READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED) ON CUST.ENTERPRISECODERF=CUSTGR.ENTERPRISECODERF " + Environment.NewLine;
                //---UPD　30809 佐々木　亘　2021/03/25 11770032-00　オブジェクト参照エラー対応 ------<<<<<
                sqlText += "    AND CUST.CUSTOMERCODERF=CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                # endregion

                #region WHERE句生成

                sqlText += "WHERE" + Environment.NewLine;

                // 企業コード
                sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(custRateGroupWork.EnterpriseCode);

                // 得意コード
                if (custRateGroupWork.CustomerCode == 0)
                {
                    sqlText += "  AND CUSTGR.CUSTOMERCODERF = CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                }
                else
                {
                    sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.CustomerCode);
                }

                // 論理削除区分
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND CUSTGR.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                         (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND CUSTGR.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlText += wkstring;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                #endregion
                sqlCommand.CommandText = sqlText;

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    custRateGroupList.Add(this.CopyToCustRateGroupWorkFromReader(ref myReader));
                }

                if (custRateGroupList.Count > 0)
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
        /// 得意先(掛率グループ)マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pustRateGroupList">追加・更新する得意先(掛率グループ)マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupList に格納されている得意先(掛率グループ)マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int Write(ref object pustRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pustRateGroupList as ArrayList;

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
        /// 得意先(掛率グループ)マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pustRateGroupList">追加・更新する得意先(掛率グループ)マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupList に格納されている得意先(掛率グループ)マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int Write(ref ArrayList pustRateGroupList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref pustRateGroupList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="pustRateGroupList">追加・更新する得意先(掛率グループ)マスタ情報を格納する ArrayList</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupList に格納されている得意先(掛率グループ)マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        private int WriteProc(ref ArrayList pustRateGroupList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pustRateGroupList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pustRateGroupList.Count; i++)
                    {
                        CustRateGroupWork pustRateGroupWork = pustRateGroupList[i] as CustRateGroupWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.PURECODERF = @FINDPURECODE " + Environment.NewLine;
                        sqlText += "  AND CUSTGR.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        //Prameterオブジェクトの作成
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPureCode = sqlCommand.Parameters.Add("@FINDPURECODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                        findParaPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != pustRateGroupWork.UpdateDateTime)
                            {
                                if (pustRateGroupWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText += " UPDATE " + Environment.NewLine;
                            sqlText += "   CUSTRATEGROUPRF " + Environment.NewLine;
                            sqlText += " SET " + Environment.NewLine;
                            sqlText += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " , PURECODERF=@PURECODE" + Environment.NewLine;
                            sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlText += " WHERE " + Environment.NewLine;
                            sqlText += "   ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "   AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "   AND PURECODERF = @FINDPURECODE " + Environment.NewLine;
                            sqlText += "   AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                            findParaPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pustRateGroupWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // 既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                            if (pustRateGroupWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT文]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CUSTRATEGROUPRF" + Environment.NewLine;
                            sqlText += " (" + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "    ,PURECODERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,CUSTRATEGRPCODERF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (" + Environment.NewLine;
                            sqlText += "     @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    ,@PURECODE" + Environment.NewLine;
                            sqlText += "    ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // 登録ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pustRateGroupWork;
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
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                        # endregion

                        # region Parameterオブジェクトへ値設定(更新用)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pustRateGroupWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pustRateGroupWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pustRateGroupWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustRateGrpCode);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pustRateGroupWork);
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

            pustRateGroupList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// 得意先(掛率グループ)マスタ情報を論理削除します。
        /// </summary>
        /// <param name="pustRateGroupList">論理削除する得意先(掛率グループ)マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork に格納されている得意先(掛率グループ)マスタ情報を論理削除します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int LogicalDelete(ref object pustRateGroupList)
        {
            return this.LogicalDelete(ref pustRateGroupList, 0);
        }

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="pustRateGroupList">論理削除を解除する得意先(掛率グループ)マスタ情報を含む CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork に格納されている得意先(掛率グループ)マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int RevivalLogicalDelete(ref object pustRateGroupList)
        {
            return this.LogicalDelete(ref pustRateGroupList, 1);
        }

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pustRateGroupList">論理削除を操作する得意先(掛率グループ)マスタ情報</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork に格納されている得意先(掛率グループ)マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        private int LogicalDelete(ref object pustRateGroupList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // パラメータのキャスト
                ArrayList paraList = pustRateGroupList as ArrayList;

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
        /// 得意先(掛率グループ)マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pustRateGroupList">論理削除を操作する得意先(掛率グループ)マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork に格納されている得意先(掛率グループ)マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        public int LogicalDelete(ref ArrayList pustRateGroupList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref pustRateGroupList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// 得意先(掛率グループ)マスタ情報の論理削除を操作します。
        /// </summary>
        /// <param name="pustRateGroupList">論理削除を操作する得意先(掛率グループ)マスタ情報を格納する ArrayList</param>
        /// <param name="procMode">0:論理削除 1:復活</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork に格納されている得意先(掛率グループ)マスタ情報の論理削除を操作します。</br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        private int LogicalDeleteProc(ref ArrayList pustRateGroupList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pustRateGroupList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pustRateGroupList.Count; i++)
                    {
                        CustRateGroupWork pustRateGroupWork = pustRateGroupList[i] as CustRateGroupWork;

                        # region [SELECT文]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CUSTGR.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.PURECODERF = @FINDPURECODE " + Environment.NewLine;
                        sqlText += "  AND CUSTGR.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameterオブジェクトの作成
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPureCode = sqlCommand.Parameters.Add("@FINDPURECODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameterオブジェクトへ値設定
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                        findParaPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            
                            // 既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// 更新日時

                            if (_updateDateTime != pustRateGroupWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }
                            
                            // 現在の論理削除区分を取得
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE文]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  CUSTRATEGROUPRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND PURECODERF = @FINDPURECODE " + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEYコマンドを再設定
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                            findParaPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);


                            // 更新ヘッダ情報を設定
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pustRateGroupWork;
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
                            else if (logicalDelCd == 0) pustRateGroupWork.LogicalDeleteCode = 1;  // 論理削除フラグをセット
                            else pustRateGroupWork.LogicalDeleteCode = 3;                         // 完全削除フラグをセット
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                pustRateGroupWork.LogicalDeleteCode = 0;                          // 論理削除フラグを解除
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pustRateGroupWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pustRateGroupWork);
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

            pustRateGroupList = al;

            return status;
        }
        # endregion

        #region [パラメータキャスト処理]
        /// <summary>
        /// パラメータキャスト処理
        /// </summary>
        /// <param name="paraobj">パラメータ</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 23012　畠中 啓次朗</br>
        /// <br>Date       : 2008.10.01</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CustRateGroupWork[] CustRateGroupWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayListの場合
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //パラメータクラスの場合
                    if (paraobj is CustRateGroupWork)
                    {
                        CustRateGroupWork wkCustRateGroupWork = paraobj as CustRateGroupWork;
                        if (wkCustRateGroupWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCustRateGroupWork);
                        }
                    }

                    //byte[]の場合
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CustRateGroupWorkArray = (CustRateGroupWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CustRateGroupWork[]));
                        }
                        catch (Exception) { }
                        if (CustRateGroupWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CustRateGroupWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CustRateGroupWork wkCustRateGroupWork = (CustRateGroupWork)XmlByteSerializer.Deserialize(byteArray, typeof(CustRateGroupWork));
                                if (wkCustRateGroupWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCustRateGroupWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //特に何もしない
                }

            return retal;
        }
        #endregion


        # region [クラス格納処理]
        /// <summary>
        /// クラス格納処理 Reader → CustRateGroupWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustRateGroupWork オブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private CustRateGroupWork CopyToCustRateGroupWorkFromReader(ref SqlDataReader myReader)
        {
            CustRateGroupWork pustRateGroupWork = new CustRateGroupWork();

            this.CopyToCustRateGroupWorkFromReader(ref myReader, ref pustRateGroupWork);

            return pustRateGroupWork;
        }

        /// <summary>
        /// クラス格納処理 Reader → CustRateGroupWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pustRateGroupWork">CustRateGroupWork オブジェクト</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private void CopyToCustRateGroupWorkFromReader(ref SqlDataReader myReader, ref CustRateGroupWork pustRateGroupWork)
        {
            if (myReader != null && pustRateGroupWork != null)
            {
                # region クラスへ格納
                pustRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                pustRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                pustRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                pustRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                pustRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                pustRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                pustRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                pustRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                pustRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                pustRateGroupWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                pustRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                pustRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                pustRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                # endregion
            }
        }
        # endregion
    }
}

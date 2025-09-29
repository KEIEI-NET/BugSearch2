//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データクリア処理
// プログラム概要   : データクリア処理DBリモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// データクリア処理DBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データクリア処理の実行処理を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.06.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class DataClearDB : RemoteDB, IDataClearDB
    {
        /// <summary>
        /// データクリア処理DBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        public DataClearDB()
            :
            base("PMKHN01006D", "Broadleaf.Application.Remoting.ParamData.DataClearWork", "")
        {
        }

        #region [Clear]
        /// <summary>
        /// データクリア処理を行う
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="dataClearList">データクリアリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        public int Clear(string enterpriseCode, Int32 delYM, Int32 delYMD, ref object dataClearList, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            errMsg = string.Empty;

            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return ClearProc(enterpriseCode, delYM, delYMD, ref dataClearList, ref sqlConnection, out errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.Clear");
                errMsg = ex.Message;
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

        #region [ClearProc]
        /// <summary>
        /// 指定された条件のデータクリア処理データを戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="dataClearList">データクリアリスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のデータクリア処理データを戻します(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearProc(string enterpriseCode, Int32 delYM, Int32 delYMD, ref object dataClearList, ref SqlConnection sqlConnection, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMsg = string.Empty;

            try
            {
                // 端数区分の取得
                Int32 fractionProcCd = GetFractionProcCd(enterpriseCode, ref sqlConnection);

                ArrayList list = dataClearList as ArrayList;
                for (int i = 0; i < list.Count; i++)
                {
                    int subStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    DataClearWork work = (DataClearWork)list[i];

                    // 選択された対象のみ
                    if (work.IsChecked)
                    {
                        // 処理コードにより、クリア処理を行う
                        switch (work.ClearCode)
                        {
                            case 0: // 処理コード＝0：無条件クリア
                                subStatus = ClearDataByCode0(enterpriseCode, work.TableId, ref sqlConnection);
                                break;
                            case 1: // 処理コード＝1：年月指定クリア１（年月）
                                subStatus = ClearDataByCode1(enterpriseCode, work.TableId, work.FileId, delYM, ref sqlConnection);
                                break;
                            case 2: // 処理コード＝2：年月指定クリア２（年月日）
                                subStatus = ClearDataByCode2(enterpriseCode, work.TableId, work.FileId, delYMD, ref sqlConnection);
                                break;
                            case 3: // 処理コード＝3：在庫履歴クリア
                                subStatus = ClearDataByCode3(enterpriseCode, work.TableId, delYM, delYMD, fractionProcCd, ref sqlConnection);
                                break;
                            case 4: // 処理コード＝4：番号管理設定クリア
                                subStatus = ClearDataByCode4(enterpriseCode, work.TableId, ref sqlConnection);
                                break;
                        }

                        // 処理結果の設定
                        if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            work.Result = "OK";
                        }
                        else
                        {
                            work.Result = "NG";
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearProc");
                errMsg = ex.Message;
            }

            return status;
        }
        #endregion

        #region 処理コード＝0：無条件クリア
        /// <summary>
        /// 処理コード＝0：無条件クリアの処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝0：無条件クリアの処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode0(string enterpriseCode, string tableId, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // トランザクション開始
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // クリア処理
                status = ClearDataByCode0Proc(enterpriseCode, tableId, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode0");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 処理コード＝0：無条件クリアの処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝0：無条件クリアの処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode0Proc(string enterpriseCode, string tableId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {               
                sql.Append("DELETE FROM ");
                sql.Append(tableId);
                sql.Append(" WHERE ENTERPRISECODERF = @FINDENTERPRISECODE");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // レコード削除時のTimeoutの設定
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode0Proc");
            }

            return status;
        }
        #endregion 処理コード＝0：無条件クリア

        #region 処理コード＝1：年月指定クリア１（年月）
        /// <summary>
        /// 処理コード＝1：年月指定クリア１（年月）の処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="fileId">フィールドID</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝1：年月指定クリア１（年月）の処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode1(string enterpriseCode, string tableId, string fileId, Int32 delYM, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // トランザクション開始
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // クリア処理
                status = ClearDataByCode1Proc(enterpriseCode, tableId, fileId, delYM, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode1");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 処理コード＝1：年月指定クリア１（年月）の処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="fileId">フィールドID</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝1：年月指定クリア１（年月）の処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode1Proc(string enterpriseCode, string tableId, string fileId, Int32 delYM, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("DELETE FROM ");
                sql.Append(tableId);
                sql.Append(" WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sql.Append(fileId);
                sql.Append(" >= @FINDADDUPYEARMONTH");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(delYM);

                // レコード削除時のTimeoutの設定
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode1Proc");
            }

            return status;
        }
        #endregion 処理コード＝1：年月指定クリア１（年月）

        #region 処理コード＝2：年月指定クリア２（年月日）
        /// <summary>
        /// 処理コード＝2：年月指定クリア２（年月日）の処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="fileId">フィールドID</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝2：年月指定クリア２（年月日）の処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode2(string enterpriseCode, string tableId, string fileId, Int32 delYMD, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // トランザクション開始
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // クリア処理
                status = ClearDataByCode2Proc(enterpriseCode, tableId, fileId, delYMD, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode2");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 処理コード＝2：年月指定クリア２（年月日）の処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="fileId">フィールドID</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝2：年月指定クリア２（年月日）の処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode2Proc(string enterpriseCode, string tableId, string fileId, Int32 delYMD, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("DELETE FROM ");
                sql.Append(tableId);
                sql.Append(" WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sql.Append(fileId);
                sql.Append(" >= @FINDADDUPDATE");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetInt32(delYMD);

                // レコード削除時のTimeoutの設定
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode2Proc");
            }

            return status;
        }
        #endregion 処理コード＝2：年月指定クリア２（年月日）

        #region 処理コード＝3：在庫履歴クリア
        /// <summary>
        /// 処理コード＝3：在庫履歴クリアの処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝3：在庫履歴クリアの処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode3(string enterpriseCode, string tableId, Int32 delYM, Int32 delYMD, Int32 fractionProcCd, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // クリア処理
                status = ClearDataByCode3Proc(enterpriseCode, tableId, delYM, delYMD, fractionProcCd, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode3");
            }

            return status;
        }

        /// <summary>
        /// 処理コード＝3：在庫履歴クリアの処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝3：在庫履歴クリアの処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode3Proc(string enterpriseCode, string tableId, Int32 delYM, Int32 delYMD, Int32 fractionProcCd, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sql = new StringBuilder();
            List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();
            SqlTransaction sqlTransaction = null;
            try
            {
                // トランザクション開始
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // 在庫履歴データのクリア削除処理
                status = ClearStockHistory(enterpriseCode, tableId, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    return status;
                }

                // 在庫マスタレコードの検索処理
                status = SearchData(enterpriseCode, delYM, delYMD, fractionProcCd, out stockHistoryWorkList, ref sqlConnection, ref sqlTransaction);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // トランザクション開始
                sqlTransaction = CreateTransaction(ref sqlConnection);
                // 在庫履歴データの新規処理
                status = WriteStockHistory(ref stockHistoryWorkList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode3Proc");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 在庫履歴データのクリア削除処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫履歴データのクリア削除処理</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearStockHistory(string enterpriseCode, string tableId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("DELETE FROM ");
                sql.Append(tableId);
                sql.Append(" WHERE ENTERPRISECODERF = @FINDENTERPRISECODE");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // レコード削除時のTimeoutの設定
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearStockHistory");
            }

            return status;
        }

        /// <summary>
        /// 在庫マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <param name="stockHistoryWorkList">在庫履歴データリスト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタの検索処理を行います</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int SearchData(string enterpriseCode, Int32 delYM, Int32 delYMD, Int32 fractionProcCd, out List<StockHistoryWork> stockHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            StringBuilder sql = new StringBuilder();
            stockHistoryWorkList = new List<StockHistoryWork>();
            List<GoodsSupplierDataWork> goodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();
            List<UnitPriceCalcParamWork> UnitPriceCalcParamWorkList = new List<UnitPriceCalcParamWork>();
            List<GoodsUnitDataWork> GoodsUnitDataWorkList = new List<GoodsUnitDataWork>();
            try
            {
                // 削除年月の前月
                DateTime addUpYearMonth = new DateTime(delYM / 100, delYM % 100, 1).AddMonths(-1);

                // 削除年月開始日の１ヶ月後
                DateTime priceApplyDate = new DateTime(delYMD / 10000, (delYMD % 10000) / 100, delYMD % 100).AddMonths(1);

                sql.Append("SELECT ");
                sql.Append("    A.WAREHOUSECODERF, ");
                sql.Append("    B.WAREHOUSENAMERF, ");
                sql.Append("    A.SECTIONCODERF, ");
                sql.Append("    A.GOODSNORF, ");
                sql.Append("    D.GOODSNAMERF, ");
                sql.Append("    A.GOODSMAKERCDRF, ");
                sql.Append("    C.MAKERNAMERF, ");
                sql.Append("    A.SHIPMENTPOSCNTRF, ");
                sql.Append("    A.SHIPMENTPOSCNTRF + A.SHIPMENTCNTRF - A.ARRIVALCNTRF PROPERTYSTOCKCNTRF, ");
                sql.Append("    D.BLGOODSCODERF, ");
                sql.Append("    E.BLGROUPCODERF, ");
                sql.Append("    F.GOODSMGROUPRF ");
                sql.Append("FROM ");
                sql.Append("    STOCKRF A ");
                sql.Append("    LEFT JOIN WAREHOUSERF B ");
                sql.Append("    ON A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sql.Append("    AND A.WAREHOUSECODERF = B.WAREHOUSECODERF ");
                sql.Append("    LEFT JOIN MAKERURF C ");
                sql.Append("    ON A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sql.Append("    AND A.GOODSMAKERCDRF = C.GOODSMAKERCDRF ");
                sql.Append("    LEFT JOIN GOODSURF D ");
                sql.Append("    ON A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sql.Append("    AND A.GOODSMAKERCDRF = D.GOODSMAKERCDRF ");
                sql.Append("    AND A.GOODSNORF = D.GOODSNORF ");
                sql.Append("    LEFT JOIN BLGOODSCDURF E ");
                sql.Append("    ON D.ENTERPRISECODERF = E.ENTERPRISECODERF ");
                sql.Append("    AND D.BLGOODSCODERF = E.BLGOODSCODERF ");
                sql.Append("    LEFT JOIN BLGROUPURF F ");
                sql.Append("    ON E.ENTERPRISECODERF = F.ENTERPRISECODERF ");
                sql.Append("    AND E.BLGROUPCODERF = F.BLGROUPCODERF ");
                sql.Append("WHERE ");
                sql.Append("    A.ENTERPRISECODERF = @FINDENTERPRISECODE ");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // 在庫履歴データリスト作成
                    StockHistoryWork stockHistoryWork = new StockHistoryWork();
                    stockHistoryWork.EnterpriseCode = enterpriseCode;
                    stockHistoryWork.AddUpYearMonth = addUpYearMonth;
                    stockHistoryWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockHistoryWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockHistoryWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockHistoryWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockHistoryWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockHistoryWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockHistoryWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockHistoryWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    stockHistoryWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    stockHistoryWork.PropertyStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PROPERTYSTOCKCNTRF"));
                    stockHistoryWorkList.Add(stockHistoryWork);

                    // 商品仕入取得パラメータリスト生成
                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                    goodsSupplierDataWork.EnterpriseCode = enterpriseCode;
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    goodsSupplierDataWorkList.Add(goodsSupplierDataWork);

                    // 単価算出パラメータリスト生成
                    UnitPriceCalcParamWork unitPriceCalcParamWork = new UnitPriceCalcParamWork();
                    unitPriceCalcParamWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    unitPriceCalcParamWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    unitPriceCalcParamWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    unitPriceCalcParamWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    unitPriceCalcParamWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    unitPriceCalcParamWork.PriceApplyDate = priceApplyDate;
                    UnitPriceCalcParamWorkList.Add(unitPriceCalcParamWork);

                    // 商品連結情報リスト生成
                    GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();
                    goodsUnitDataWork.EnterpriseCode = enterpriseCode;
                    goodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    GoodsUnitDataWorkList.Add(goodsUnitDataWork);
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }

                // 商品仕入先の取得
                // 品仕入先取得部品の呼び出し
                GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
                goodsSupplierGetter.GetGoodsMngInfo(ref goodsSupplierDataWorkList);

                // 単価算出パラメータの更新
                foreach (GoodsSupplierDataWork goodsSupplierDataWork in goodsSupplierDataWorkList)
                {
                    foreach (UnitPriceCalcParamWork unitPriceCalcParamWork in UnitPriceCalcParamWorkList)
                    {
                        if (goodsSupplierDataWork.GoodsMakerCd == unitPriceCalcParamWork.GoodsMakerCd
                            && goodsSupplierDataWork.GoodsNo == unitPriceCalcParamWork.GoodsNo
                            && goodsSupplierDataWork.BLGoodsCode == unitPriceCalcParamWork.BLGoodsCode)
                        {
                            unitPriceCalcParamWork.SupplierCd = goodsSupplierDataWork.SupplierCd;
                        }
                    }
                }

                // 仕入単価の取得
                // 単価算出モジュールの呼び出し
                UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
                List<UnitPriceCalcRetWork> unitPriceCalcRetWorkList = new List<UnitPriceCalcRetWork>();
                unitPriceCalculation.CalculateUnitCost(UnitPriceCalcParamWorkList, GoodsUnitDataWorkList, out unitPriceCalcRetWorkList);

                // 仕入単価のセット
                foreach (UnitPriceCalcRetWork unitPriceCalcRetWork in unitPriceCalcRetWorkList) 
                {
                    foreach (StockHistoryWork stockHistoryWork in stockHistoryWorkList)
                    {
                        if (stockHistoryWork.GoodsMakerCd == unitPriceCalcRetWork.GoodsMakerCd
                            && stockHistoryWork.GoodsNo == unitPriceCalcRetWork.GoodsNo)
                        {
                            // 仕入単価（税抜，浮動）
                            stockHistoryWork.StockUnitPriceFl = unitPriceCalcRetWork.UnitPriceTaxExcFl;
                        }
                    }
                }

                // 金額の設定
                double fractionUnit = 1.00d;
                Int64 resultMoney;
                foreach (StockHistoryWork stockHistoryWork in stockHistoryWorkList)
                {
                    // 在庫総数に対する金額
                    double stockMashinePrice = stockHistoryWork.StockUnitPriceFl * stockHistoryWork.StockTotal;
                    FractionCalculate.FracCalcMoney(stockMashinePrice, fractionUnit, fractionProcCd, out resultMoney);
                    stockHistoryWork.StockMashinePrice = resultMoney;
                    stockHistoryWork.AdjustPrice = resultMoney;

                    // 自社在庫数に対する金額
                    double propertyStockPrice = stockHistoryWork.StockUnitPriceFl * stockHistoryWork.PropertyStockCnt;
                    FractionCalculate.FracCalcMoney(propertyStockPrice, fractionUnit, fractionProcCd, out resultMoney);
                    stockHistoryWork.PropertyStockPrice = resultMoney;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearStockHistory");
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// 在庫履歴データを更新します
        /// </summary>
        /// <param name="stockHistoryWorkList">在庫履歴データList</param>
        /// <param name="sqlConnection">sqlコネクション</param>
        /// <param name="sqlTransaction">sqlトランザクション</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫履歴データを更新します</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private int WriteStockHistory(ref List<StockHistoryWork> stockHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StringBuilder sql = new StringBuilder();

            try
            {
                for (int i = 0; i < stockHistoryWorkList.Count; i++)
                {
                    StockHistoryWork stockHistoryWork = stockHistoryWorkList[i] as StockHistoryWork;

                    #region [Insert文作成]
                    sql = new StringBuilder();
                    sql.Append("INSERT INTO STOCKHISTORYRF").Append(Environment.NewLine);
                    sql.Append(" (").Append(Environment.NewLine);
                    sql.Append("     CREATEDATETIMERF").Append(Environment.NewLine);
                    sql.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sql.Append("    ,ENTERPRISECODERF").Append(Environment.NewLine);
                    sql.Append("    ,FILEHEADERGUIDRF").Append(Environment.NewLine);
                    sql.Append("    ,UPDEMPLOYEECODERF").Append(Environment.NewLine);
                    sql.Append("    ,UPDASSEMBLYID1RF").Append(Environment.NewLine);
                    sql.Append("    ,UPDASSEMBLYID2RF").Append(Environment.NewLine);
                    sql.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sql.Append("    ,ADDUPYEARMONTHRF").Append(Environment.NewLine);
                    sql.Append("    ,WAREHOUSECODERF").Append(Environment.NewLine);
                    sql.Append("    ,WAREHOUSENAMERF").Append(Environment.NewLine);
                    sql.Append("    ,SECTIONCODERF").Append(Environment.NewLine);
                    sql.Append("    ,GOODSNORF").Append(Environment.NewLine);
                    sql.Append("    ,GOODSNAMERF").Append(Environment.NewLine);
                    sql.Append("    ,GOODSMAKERCDRF").Append(Environment.NewLine);
                    sql.Append("    ,MAKERNAMERF").Append(Environment.NewLine);
                    sql.Append("    ,LMONTHSTOCKCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,LMONTHSTOCKPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,LMONTHPPTYSTOCKCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,LMONTHPPTYSTOCKPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,SALESTIMESRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESCOUNTRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESMONEYTAXEXCRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESRETGOODSTIMESRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESRETGOODSCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESRETGOODSPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,GROSSPROFITRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKTIMESRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKCOUNTRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKPRICETAXEXCRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKRETGOODSTIMESRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKRETGOODSCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKRETGOODSPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,MOVEARRIVALCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,MOVEARRIVALPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,MOVESHIPMENTCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,MOVESHIPMENTPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,ADJUSTCOUNTRF").Append(Environment.NewLine);
                    sql.Append("    ,ADJUSTPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,ARRIVALCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,ARRIVALPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,SHIPMENTCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,SHIPMENTPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,TOTALARRIVALCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,TOTALARRIVALPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,TOTALSHIPMENTCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,TOTALSHIPMENTPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKUNITPRICEFLRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKTOTALRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKMASHINEPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,PROPERTYSTOCKCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,PROPERTYSTOCKPRICERF").Append(Environment.NewLine);
                    sql.Append(" )").Append(Environment.NewLine);
                    sql.Append(" VALUES").Append(Environment.NewLine);
                    sql.Append(" (").Append(Environment.NewLine);
                    sql.Append("     @CREATEDATETIME").Append(Environment.NewLine);
                    sql.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                    sql.Append("    ,@ENTERPRISECODE").Append(Environment.NewLine);
                    sql.Append("    ,@FILEHEADERGUID").Append(Environment.NewLine);
                    sql.Append("    ,@UPDEMPLOYEECODE").Append(Environment.NewLine);
                    sql.Append("    ,@UPDASSEMBLYID1").Append(Environment.NewLine);
                    sql.Append("    ,@UPDASSEMBLYID2").Append(Environment.NewLine);
                    sql.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                    sql.Append("    ,@ADDUPYEARMONTH").Append(Environment.NewLine);
                    sql.Append("    ,@WAREHOUSECODE").Append(Environment.NewLine);
                    sql.Append("    ,@WAREHOUSENAME").Append(Environment.NewLine);
                    sql.Append("    ,@SECTIONCODE").Append(Environment.NewLine);
                    sql.Append("    ,@GOODSNO").Append(Environment.NewLine);
                    sql.Append("    ,@GOODSNAME").Append(Environment.NewLine);
                    sql.Append("    ,@GOODSMAKERCD").Append(Environment.NewLine);
                    sql.Append("    ,@MAKERNAME").Append(Environment.NewLine);
                    sql.Append("    ,@LMONTHSTOCKCNT").Append(Environment.NewLine);
                    sql.Append("    ,@LMONTHSTOCKPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@LMONTHPPTYSTOCKCNT").Append(Environment.NewLine);
                    sql.Append("    ,@LMONTHPPTYSTOCKPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@SALESTIMES").Append(Environment.NewLine);
                    sql.Append("    ,@SALESCOUNT").Append(Environment.NewLine);
                    sql.Append("    ,@SALESMONEYTAXEXC").Append(Environment.NewLine);
                    sql.Append("    ,@SALESRETGOODSTIMES").Append(Environment.NewLine);
                    sql.Append("    ,@SALESRETGOODSCNT").Append(Environment.NewLine);
                    sql.Append("    ,@SALESRETGOODSPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@GROSSPROFIT").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKTIMES").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKCOUNT").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKPRICETAXEXC").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKRETGOODSTIMES").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKRETGOODSCNT").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKRETGOODSPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@MOVEARRIVALCNT").Append(Environment.NewLine);
                    sql.Append("    ,@MOVEARRIVALPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@MOVESHIPMENTCNT").Append(Environment.NewLine);
                    sql.Append("    ,@MOVESHIPMENTPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@ADJUSTCOUNT").Append(Environment.NewLine);
                    sql.Append("    ,@ADJUSTPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@ARRIVALCNT").Append(Environment.NewLine);
                    sql.Append("    ,@ARRIVALPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@SHIPMENTCNT").Append(Environment.NewLine);
                    sql.Append("    ,@SHIPMENTPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@TOTALARRIVALCNT").Append(Environment.NewLine);
                    sql.Append("    ,@TOTALARRIVALPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@TOTALSHIPMENTCNT").Append(Environment.NewLine);
                    sql.Append("    ,@TOTALSHIPMENTPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKUNITPRICEFL").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKTOTAL").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKMASHINEPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@PROPERTYSTOCKCNT").Append(Environment.NewLine);
                    sql.Append("    ,@PROPERTYSTOCKPRICE").Append(Environment.NewLine);
                    sql.Append(" )").Append(Environment.NewLine);
                    #endregion  //[Insert文作成]

                    using (SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction))
                    {
                        //登録ヘッダ情報を設定
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockHistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameterオブジェクト作成
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraLMonthStockCnt = sqlCommand.Parameters.Add("@LMONTHSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraLMonthStockPrice = sqlCommand.Parameters.Add("@LMONTHSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraLMonthPptyStockCnt = sqlCommand.Parameters.Add("@LMONTHPPTYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraLMonthPptyStockPrice = sqlCommand.Parameters.Add("@LMONTHPPTYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraSalesTimes = sqlCommand.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                        SqlParameter paraSalesCount = sqlCommand.Parameters.Add("@SALESCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesMoneyTaxExc = sqlCommand.Parameters.Add("@SALESMONEYTAXEXC", SqlDbType.BigInt);
                        SqlParameter paraSalesRetGoodsTimes = sqlCommand.Parameters.Add("@SALESRETGOODSTIMES", SqlDbType.Int);
                        SqlParameter paraSalesRetGoodsCnt = sqlCommand.Parameters.Add("@SALESRETGOODSCNT", SqlDbType.Float);
                        SqlParameter paraSalesRetGoodsPrice = sqlCommand.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                        SqlParameter paraGrossProfit = sqlCommand.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);
                        SqlParameter paraStockTimes = sqlCommand.Parameters.Add("@STOCKTIMES", SqlDbType.Int);
                        SqlParameter paraStockCount = sqlCommand.Parameters.Add("@STOCKCOUNT", SqlDbType.Float);
                        SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                        SqlParameter paraStockRetGoodsTimes = sqlCommand.Parameters.Add("@STOCKRETGOODSTIMES", SqlDbType.Int);
                        SqlParameter paraStockRetGoodsCnt = sqlCommand.Parameters.Add("@STOCKRETGOODSCNT", SqlDbType.Float);
                        SqlParameter paraStockRetGoodsPrice = sqlCommand.Parameters.Add("@STOCKRETGOODSPRICE", SqlDbType.BigInt);
                        SqlParameter paraMoveArrivalCnt = sqlCommand.Parameters.Add("@MOVEARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraMoveArrivalPrice = sqlCommand.Parameters.Add("@MOVEARRIVALPRICE", SqlDbType.BigInt);
                        SqlParameter paraMoveShipmentCnt = sqlCommand.Parameters.Add("@MOVESHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraMoveShipmentPrice = sqlCommand.Parameters.Add("@MOVESHIPMENTPRICE", SqlDbType.BigInt);
                        SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                        SqlParameter paraAdjustPrice = sqlCommand.Parameters.Add("@ADJUSTPRICE", SqlDbType.BigInt);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraArrivalPrice = sqlCommand.Parameters.Add("@ARRIVALPRICE", SqlDbType.BigInt);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraShipmentPrice = sqlCommand.Parameters.Add("@SHIPMENTPRICE", SqlDbType.BigInt);
                        SqlParameter paraTotalArrivalCnt = sqlCommand.Parameters.Add("@TOTALARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraTotalArrivalPrice = sqlCommand.Parameters.Add("@TOTALARRIVALPRICE", SqlDbType.BigInt);
                        SqlParameter paraTotalShipmentCnt = sqlCommand.Parameters.Add("@TOTALSHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraTotalShipmentPrice = sqlCommand.Parameters.Add("@TOTALSHIPMENTPRICE", SqlDbType.BigInt);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraPropertyStockCnt = sqlCommand.Parameters.Add("@PROPERTYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraPropertyStockPrice = sqlCommand.Parameters.Add("@PROPERTYSTOCKPRICE", SqlDbType.BigInt);
                        #endregion

                        #region Parameterオブジェクト設定
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockHistoryWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockHistoryWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockHistoryWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.LogicalDeleteCode);
                        paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(stockHistoryWork.AddUpYearMonth);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.WarehouseName);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.SectionCode);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockHistoryWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.GoodsName);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.MakerName);
                        paraLMonthStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.LMonthStockCnt);
                        paraLMonthStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.LMonthStockPrice);
                        paraLMonthPptyStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.LMonthPptyStockCnt);
                        paraLMonthPptyStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.LMonthPptyStockPrice);
                        paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SalesTimes);
                        paraSalesCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.SalesCount);
                        paraSalesMoneyTaxExc.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.SalesMoneyTaxExc);
                        paraSalesRetGoodsTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SalesRetGoodsTimes);
                        paraSalesRetGoodsCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.SalesRetGoodsCnt);
                        paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.SalesRetGoodsPrice);
                        paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.GrossProfit);
                        paraStockTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.StockTimes);
                        paraStockCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockCount);
                        paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockPriceTaxExc);
                        paraStockRetGoodsTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.StockRetGoodsTimes);
                        paraStockRetGoodsCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockRetGoodsCnt);
                        paraStockRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockRetGoodsPrice);
                        paraMoveArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.MoveArrivalCnt);
                        paraMoveArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.MoveArrivalPrice);
                        paraMoveShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.MoveShipmentCnt);
                        paraMoveShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.MoveShipmentPrice);
                        paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.AdjustCount);
                        paraAdjustPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.AdjustPrice);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.ArrivalCnt);
                        paraArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.ArrivalPrice);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.ShipmentCnt);
                        paraShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.ShipmentPrice);
                        paraTotalArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.TotalArrivalCnt);
                        paraTotalArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.TotalArrivalPrice);
                        paraTotalShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.TotalShipmentCnt);
                        paraTotalShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.TotalShipmentPrice);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockUnitPriceFl);
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockTotal);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockMashinePrice);
                        paraPropertyStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.PropertyStockCnt);
                        paraPropertyStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.PropertyStockPrice);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DataClearDB.WriteStockHistory");
            }

            return status;
        }
        #endregion 処理コード＝3：在庫履歴クリア

        #region 処理コード＝4：番号管理設定クリア
        /// <summary>
        /// 処理コード＝4：番号管理設定クリアの処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝4：番号管理設定クリアの処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode4(string enterpriseCode, string tableId, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // トランザクション開始
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // クリア処理
                status = ClearDataByCode4Proc(enterpriseCode, tableId, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode4");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// 処理コード＝4：番号管理設定クリアの処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tableId">テーブルID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝4：番号管理設定クリアの処理(外部からのSqlConnectionを使用)</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode4Proc(string enterpriseCode, string tableId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("UPDATE ");
                sql.Append(tableId);
                sql.Append(" SET NOPRESENTVALRF = 0,").Append(Environment.NewLine);
                sql.Append(" UPDATEDATETIMERF = @UPDATEDATETIME,").Append(Environment.NewLine);
                sql.Append(" UPDEMPLOYEECODERF = @UPDEMPLOYEECODE,").Append(Environment.NewLine);
                sql.Append(" UPDASSEMBLYID1RF = @UPDASSEMBLYID1,").Append(Environment.NewLine);
                sql.Append(" UPDASSEMBLYID2RF = @UPDASSEMBLYID2,").Append(Environment.NewLine);
                sql.Append(" LOGICALDELETECODERF = @LOGICALDELETECODE").Append(Environment.NewLine);
                sql.Append(" WHERE ENTERPRISECODERF = @ENTERPRISECODE");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //登録ヘッダ情報を設定
                StockHistoryWork stockHistoryWork = new StockHistoryWork();
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)stockHistoryWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                //Prameterオブジェクトの作成
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);

                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockHistoryWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.LogicalDeleteCode);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode4Proc");
            }

            return status;
        }
        #endregion 処理コード＝4：番号管理設定クリア

        #region 処理コード＝9：価格改正履歴データクリア（提供データ削除処理用）
        /// <summary>
        /// 処理コード＝9：価格改正履歴データクリア（提供データ削除処理用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝9：価格改正履歴データクリアの処理（提供データ削除処理用）</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        public int ClearDataByCode9(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // クリア処理
                status = ClearDataByCode9Proc(enterpriseCode, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // コミット
                    sqlTransaction.Commit();
                }
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode9");
                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 処理コード＝9：価格改正履歴データクリアの処理（提供データ削除処理用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝9：価格改正履歴データクリアの処理（提供データ削除処理用）</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode9Proc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("DELETE FROM PRIUPDHISRF ");
                sql.Append("WHERE ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sql.Append("AND OFFERVERSIONRF IS NOT NULL ");
                sql.Append("AND LEN(OFFERVERSIONRF) > 0 ");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // レコード削除時のTimeoutの設定
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode9Proc");
            }

            return status;
        }
        #endregion 処理コード＝9：価格改正履歴データクリア（提供データ削除処理用）

        #region 端数処理区分の取得処理
        /// <summary>
        /// 端数処理区分の取得処理(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>端数処理区分</returns>
        /// <br>Note       : 端数処理区分の取得処理（拠点コード＝"00"のレコードを取得する）</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        private Int32 GetFractionProcCd(string enterpriseCode, ref SqlConnection sqlConnection)
        {
            Int32 fractionProcess = 0;
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
            StockMngTtlStWork paraStockMngTtlStWork = new StockMngTtlStWork();
            paraStockMngTtlStWork.EnterpriseCode = enterpriseCode;
            paraStockMngTtlStWork.SectionCode = "00";
            Object objStockMngTtlStWorkList = new object();
            Object objParaStockMngTtlStWork = paraStockMngTtlStWork as object;

            // 検索処理
            stockMngTtlStDB.SearchStockMngTtlStProc(out objStockMngTtlStWorkList, objParaStockMngTtlStWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
            ArrayList stockMngTtlStWorkList = objStockMngTtlStWorkList as ArrayList;
            if (stockMngTtlStWorkList.Count > 0)
            {
                fractionProcess = ((StockMngTtlStWork)stockMngTtlStWorkList[0]).FractionProcCd;
            }

            return fractionProcess;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion  //コネクション生成処理

        #region [トランザクション作成処理]
        /// <summary>
        /// トランザクション作成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            // トランザクション開始
#if DEBUG
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            return sqlTransaction;
        }
        #endregion //トランザクション作成処理
    }

}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタコンバート
// プログラム概要   : 在庫管理全体設定の現在庫表示区分より、出荷可能数を更新する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/08/26  修正内容 : 連番No.1016 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫マスタコンバートツールREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタコンバートツールREADの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/08/26</br>
    /// </remarks>
    [Serializable]
    public class StockConvertDB : RemoteDB, IStockConvertDB
    {
        #region ■ 在庫マスタコンバート処理 ■
        /// <summary>
        /// 在庫マスタコンバートツールの処理
        /// </summary>
        /// <param name="stockConvertWorkObj">在庫マスタコンバートクラスワーク</param>
        /// <param name="stockCount">在庫マスタ　処理件数</param>
        /// <param name="stockAcPayHistCount">在庫受払履歴データ　処理件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタコンバート処理を行うクラスです。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        public int ConvertShipmentPosCnt(object stockConvertWorkObj, out int stockCount, out int stockAcPayHistCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;


            StockConvertWork stockConvertWork = (StockConvertWork)stockConvertWorkObj;

            stockCount = 0;
            stockAcPayHistCount = 0;
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                // コネクション生成
                sqlConnection = this.CreateSqlConnection(true);
                // SqlTransaction生成処理
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // 在庫マスタコンバートツールの画面検索処理
                status = ConvertShipmentPosCntProc(stockConvertWork, out stockCount, out stockAcPayHistCount, ref sqlConnection, ref sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    stockCount = 0;
                    stockAcPayHistCount = 0;
                }
            }
            catch (SqlException sqlex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(sqlex, "StockConvertDB.ConvertShipmentPosCnt", sqlex.Number);
            }
            catch (Exception ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "StockConvertDB.ConvertShipmentPosCnt Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }
        #endregion

        #region ■ 在庫マスタコンバート処理Proc ■
        /// <summary>
        /// 在庫マスタコンバート処理Proc
        /// </summary>
        /// <param name="stockConvertWork">在庫マスタコンバートクラスワーク</param>
        /// <param name="stockCount">在庫マスタ　処理件数</param>
        /// <param name="stockAcPayHistCount">在庫受払履歴データ　処理件数</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタコンバート処理Procを行うクラスです。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private int ConvertShipmentPosCntProc(StockConvertWork stockConvertWork, out int stockCount, out int stockAcPayHistCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            stockCount = 0;
            stockAcPayHistCount = 0;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            try
            {
                StringBuilder sb = new StringBuilder();
                // Selectコマンドの生成
                sb.Append(" SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF");
                sb.Append(" FROM STOCKRF ");
                sb.Append(" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPODRCOUNTRF != @FINDACPODRCOUNT ");

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcpOdrCount = sqlCommand.Parameters.Add("@FINDACPODRCOUNT", SqlDbType.Float);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = stockConvertWork.EnterpriseCode;
                findParaAcpOdrCount.Value = 0;

                sqlCommand.CommandText = sb.ToString();
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                ArrayList resultList = new ArrayList();
                while (myReader.Read())
                {
                    StockWork stWork = new StockWork();
                    stWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));

                    resultList.Add(stWork);
                }

                if (myReader.IsClosed == false)
                {
                    myReader.Close();
                }

                foreach (StockWork stWork in resultList)
                {
                    // 在庫マスタ更新処理
                    status = this.UpdateStock(stockConvertWork, stWork, ref stockCount, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 在庫受払履歴データ更新処理
                        status = this.UpdateStockAcPayHist(stockConvertWork, stWork, ref stockAcPayHistCount, ref sqlConnection, ref sqlTransaction);
                    }

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "StockConvertDB.ConvertShipmentPosCntProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockConvertDB.ConvertShipmentPosCntProc" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }
        #endregion

        /// <summary>
        /// 在庫マスタ更新処理
        /// </summary>
        /// <param name="stockConvertWork">在庫マスタコンバートクラスワーク</param>
        /// <param name="stWork"> 在庫マスタワーク</param>
        /// <param name="stockCount">在庫マスタ　処理件数</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫マスタ更新を行うクラスです。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private int UpdateStock(StockConvertWork stockConvertWork, StockWork stWork, ref int stockCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            try
            {
                //Updateコマンドの生成
                if (stockConvertWork.PreStckCntDspDiv == 0)
                {
                    // 現在庫表示区分は「0:受注分含む」
                    // 出荷可能数(ShipmentPosCntRF)＝仕入在庫数＋入荷数－出荷数－受注数－移動中数
                    sqlCommand = new SqlCommand("UPDATE STOCKRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SHIPMENTPOSCNTRF=(SUPPLIERSTOCKRF + ARRIVALCNTRF - SHIPMENTCNTRF - ACPODRCOUNTRF - MOVINGSUPLISTOCKRF) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO", sqlConnection, sqlTransaction);
                }
                else
                {
                    // 現在庫表示区分は「1:受注分含まない」
                    // 出荷可能数(ShipmentPosCntRF)＝仕入在庫数＋入荷数－出荷数－移動中数
                    sqlCommand = new SqlCommand("UPDATE STOCKRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SHIPMENTPOSCNTRF=(SUPPLIERSTOCKRF + ARRIVALCNTRF - SHIPMENTCNTRF - MOVINGSUPLISTOCKRF) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO", sqlConnection, sqlTransaction);
                }

                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)stWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);

                //Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stWork.LogicalDeleteCode);

                //Parameterオブジェクトの作成(検索用)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定(検索用)
                findParaEnterpriseCode.Value = stWork.EnterpriseCode;
                findParaWarehouseCode.Value = stWork.WarehouseCode;
                findParaGoodsMakerCd.Value = stWork.GoodsMakerCd;
                findParaGoodsNo.Value = stWork.GoodsNo;

                int count = sqlCommand.ExecuteNonQuery();
                stockCount = stockCount + count;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockConvertDB.UpdateStock" + status);
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

        /// <summary>
        /// 在庫受払履歴データ更新処理
        /// </summary>
        /// <param name="stockConvertWork">在庫マスタコンバートクラスワーク</param>
        /// <param name="stWork"> 在庫マスタワーク</param>
        /// <param name="stockAcPayHistCount">在庫受払履歴データ　処理件数</param>
        /// <param name="sqlConnection">SQLコネクション</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 在庫受払履歴データ更新を行うクラスです。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private int UpdateStockAcPayHist(StockConvertWork stockConvertWork, StockWork stWork, ref int stockAcPayHistCount, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand sqlCommand = null;
            try
            {
                //Updateコマンドの生成
                if (stockConvertWork.PreStckCntDspDiv == 0)
                {
                    // 現在庫表示区分は「0:受注分含む」
                    // 出荷可能数(ShipmentPosCntRF)＝仕入在庫数＋入荷数－出荷数－受注数－移動中数
                    sqlCommand = new SqlCommand("UPDATE STOCKACPAYHISTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SHIPMENTPOSCNTRF=(SUPPLIERSTOCKRF + NONADDUPARRGDSCNTRF - NONADDUPSHIPMCNTRF - ACPODRCOUNTRF - MOVINGSUPLISTOCKRF) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND ACPODRCOUNTRF <> 0", sqlConnection, sqlTransaction);
                }
                else
                {
                    // 現在庫表示区分は「1:受注分含まない」
                    // 出荷可能数(ShipmentPosCntRF)＝仕入在庫数＋入荷数－出荷数－移動中数
                    sqlCommand = new SqlCommand("UPDATE STOCKACPAYHISTRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , SHIPMENTPOSCNTRF=(SUPPLIERSTOCKRF + NONADDUPARRGDSCNTRF - NONADDUPSHIPMCNTRF - MOVINGSUPLISTOCKRF) WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND ACPODRCOUNTRF <> 0", sqlConnection, sqlTransaction);
                }

                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                //更新ヘッダ情報を設定
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)stWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);

                //Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stWork.UpdateDateTime);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stWork.LogicalDeleteCode);

                //Parameterオブジェクトの作成(検索用)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定(検索用)
                findParaEnterpriseCode.Value = stWork.EnterpriseCode;
                findParaGoodsMakerCd.Value = stWork.GoodsMakerCd;
                findParaGoodsNo.Value = stWork.GoodsNo;
                findParaWarehouseCode.Value = stWork.WarehouseCode;

                int count = sqlCommand.ExecuteNonQuery();
                stockAcPayHistCount = stockAcPayHistCount + count;

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "StockConvertDB.UpdateStockAcPayHist" + status);
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


        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/08/26</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            SqlTransaction sqlTransaction = null;
            if (sqlConnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlConnection.State & ConnectionState.Open) == 0)
                {
                    sqlConnection.Open();
                }

                // トランザクションの生成(開始)
#if DEBUG
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            }

            return sqlTransaction;
        }
        #endregion
    }
}

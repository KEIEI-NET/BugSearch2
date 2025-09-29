//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタ
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2010/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10806793-00  作成担当 : 田建委
// 修 正 日  2012/12/13  修正内容 : 2013/03/13配信分  Redmine#33835
//                                  出荷回数を追加する対応
//----------------------------------------------------------------------------//
// 管理番号 11070266-00  作成担当 : 松本
// 修 正 日 2015/01/28   修正内容 : PMSCM同期化対応の変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using System.Collections.Generic;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫マスタ処理READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2010/08/11</br>
    /// <br>Update Note: 2012/12/13 田建委</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#33835 出荷回数を追加する対応</br>
    /// </remarks>
    [Serializable]
    public class StockMstDB : RemoteDB, IStockMstDB
    {

        # region [Constructor]
        /// <summary>
        /// 在庫マスタ処理READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタ処理READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// </remarks>
        public StockMstDB()
        {
        }
        #endregion

        # region [在庫マスタ検索処理]
        /// <summary>
        /// 在庫マスタ検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">ﾒｰｶｰ</param>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <br>Note       : 在庫マスタ検索処理</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <returns>STATUS</returns>
        public int SearchStockInfo(string enterpriseCode, string goodsNo, Int32 goodsMakerCd, out ArrayList stockList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMessage = string.Empty;
            stockList = new ArrayList();

            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();

                //write実行
                status = SearchStockInfoProc(enterpriseCode, goodsNo, goodsMakerCd, ref sqlConnection, out stockList, out retMessage);

            }
            catch (SqlException ex)
            {
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "StockMstDB.SearchStockInfo(Connection付) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// 在庫マスタ検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCd">ﾒｰｶｰ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <br>Note       : 在庫マスタ検索処理</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <returns>STATUS</returns>
        private int SearchStockInfoProc(string enterpriseCode, string goodsNo, Int32 goodsMakerCd, ref SqlConnection sqlConnection, out ArrayList stockList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            retMessage = string.Empty;
            stockList = new ArrayList();

            try
            {
                //Selectコマンドの生成
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO", sqlConnection);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(goodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo);

                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    StockWork _stockWork = new StockWork();
                    _stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    _stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    _stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    _stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    _stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    _stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    _stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    _stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    _stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    _stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    _stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    _stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    _stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    _stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    _stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    _stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                    _stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    _stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    _stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    _stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    _stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    _stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    _stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    _stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                    _stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    _stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    _stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                    _stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                    _stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    _stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    _stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    _stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    _stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    _stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    _stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    _stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    _stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    _stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    _stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    _stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    _stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
                    stockList.Add(_stockWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                retMessage = ex.ToString();
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        //----- ADD 2012/12/13 田建委 Redmine#33835 ------------------------------->>>>>
        #region [出荷回数検索処理]
        /// <summary>
        /// 指定された条件の出荷回数を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objStockHistoryDspSearchResultWork">検索結果</param>
        /// <param name="objStockHistoryDspSearchParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 出荷回数検索処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        public int SearchStockHisDsp(out object objStockHistoryDspSearchResultWork, object objStockHistoryDspSearchParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            objStockHistoryDspSearchResultWork = null;
            try
            {
                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockHisDsp(out objStockHistoryDspSearchResultWork, objStockHistoryDspSearchParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMstDB.SearchStockHisDsp");
                objStockHistoryDspSearchResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 指定された条件の出荷回数を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="objStockHistoryDspSearchResultWork">検索結果</param>
        /// <param name="objStockHistoryDspSearchParamWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 出荷回数検索処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private int SearchStockHisDsp(out object objStockHistoryDspSearchResultWork, object objStockHistoryDspSearchParamWork, ref SqlConnection sqlConnection)
        {
            StockHistoryDspSearchParamWork paramWork = null;

            ArrayList paramWorkList = objStockHistoryDspSearchParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objStockHistoryDspSearchParamWork as StockHistoryDspSearchParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as StockHistoryDspSearchParamWork;
            }

            ArrayList stockHistoryDspSearchResultWork = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // 出荷回数を取得(在庫履歴データ)
            status = SearchStockHisDspProc(out stockHistoryDspSearchResultWork, paramWork, ref sqlConnection);

            if (stockHistoryDspSearchResultWork.Count > 0) status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            objStockHistoryDspSearchResultWork = stockHistoryDspSearchResultWork;
            return status;

        }

        #region [SearchStockHisDspProc]
        /// <summary>
        /// 指定された条件の出荷回数を戻します(外部からのSqlConnectionを使用)
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWorkList">検索結果</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 出荷回数検索処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private int SearchStockHisDspProc(out ArrayList stockHistoryDspSearchResultWorkList, StockHistoryDspSearchParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            StringBuilder sqlText = new StringBuilder();

            try
            {
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                #region [SELECT]
                sqlText.Append("SELECT ").Append(Environment.NewLine);
                sqlText.Append("	STOCKHIS.ENTERPRISECODERF AS ENTERPRISECODE ").Append(Environment.NewLine);
                sqlText.Append("	,STOCKHIS.ADDUPYEARMONTHRF AS ADDUPYEARMONTH ").Append(Environment.NewLine);
                sqlText.Append("	,STOCKHIS.WAREHOUSECODERF AS WAREHOUSECODE ").Append(Environment.NewLine);
                sqlText.Append("	,STOCKHIS.GOODSNORF AS GOODSNO ").Append(Environment.NewLine);
                sqlText.Append("	,STOCKHIS.GOODSMAKERCDRF AS GOODSMAKERCD ").Append(Environment.NewLine);
                sqlText.Append("	,STOCKHIS.SALESTIMESRF AS SALESTIMES ").Append(Environment.NewLine);
                sqlText.Append("FROM ").Append(Environment.NewLine);
                sqlText.Append("	STOCKHISTORYRF AS STOCKHIS WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
                sqlText.Append("WHERE ").Append(Environment.NewLine);
                sqlText.Append("	STOCKHIS.ENTERPRISECODERF = @ENTERPRISECODE ").Append(Environment.NewLine);
                sqlText.Append("	AND STOCKHIS.LOGICALDELETECODERF = @LOGICALDELETECODE ").Append(Environment.NewLine);
                sqlText.Append("	AND STOCKHIS.WAREHOUSECODERF = @WAREHOUSECODE ").Append(Environment.NewLine);
                sqlText.Append("	AND STOCKHIS.GOODSMAKERCDRF = @GOODSMAKERCD ").Append(Environment.NewLine);
                sqlText.Append("    AND STOCKHIS.GOODSNORF = @GOODSNO ").Append(Environment.NewLine);
                sqlText.Append("	AND STOCKHIS.ADDUPYEARMONTHRF >= @STADDUPYEARMONTH ").Append(Environment.NewLine);
                sqlText.Append("	AND STOCKHIS.ADDUPYEARMONTHRF <= @EDADDUPYEARMONTH ").Append(Environment.NewLine);
                sqlText.Append("ORDER BY ").Append(Environment.NewLine);
                sqlText.Append("	ADDUPYEARMONTH ASC").Append(Environment.NewLine);
                #endregion

                sqlCommand.CommandText = sqlText.ToString();
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.StAddUpYearMonth);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.EdAddUpYearMonth);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);

                //タイムアウト時間の設定（秒）
                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToStockHisDspWorkFromReader(ref myReader, paramWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            stockHistoryDspSearchResultWorkList = al;
            return status;
        }
        #endregion  //SearchStockHisDspProc

        /// <summary>
        /// クラス格納処理 Reader → StockHistoryDspSearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">検索パラメータ</param>
        /// <returns>StockHistoryDspSearchResultWork オブジェクト</returns>
        /// <remarks>
        /// <br>Note       : 出荷回数検索処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2012/12/13</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// </remarks>
        private StockHistoryDspSearchResultWork CopyToStockHisDspWorkFromReader(ref SqlDataReader myReader, StockHistoryDspSearchParamWork paramWork)
        {
            StockHistoryDspSearchResultWork stockHistoryDspSearchResultWork = new StockHistoryDspSearchResultWork();

            if (myReader != null)
            {
                # region クラスへ格納
                stockHistoryDspSearchResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODE"));
                stockHistoryDspSearchResultWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTH"));
                stockHistoryDspSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
                stockHistoryDspSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNO"));
                stockHistoryDspSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD"));
                stockHistoryDspSearchResultWork.SalesTimes += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES"));
                stockHistoryDspSearchResultWork.SearchDiv = 1;
                # endregion
            }

            return stockHistoryDspSearchResultWork;
        }
        #endregion // 出荷回数
        //----- ADD 2012/12/13 田建委 Redmine#33835 -------------------------------<<<<<

        #region [Write]
        /// <summary>
        /// 在庫マスタ情報を登録、更新します
        /// </summary>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報を登録、更新します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        public int Write(ArrayList stockList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //パラメータのキャスト
                if (stockList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                StockWork stockWork = null;

                if (stockList != null && stockList.Count > 0)
                {
                    stockWork = (StockWork)stockList[0];
                }
                    //write実行
                status = WriteStockProc(ref stockWork, ref sqlConnection, ref sqlTransaction, out retMessage);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }

            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMstDB.Write(ArrayList stockList, out string retMessage)");
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
        /// 在庫マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWork">stockWorkオブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報を登録、更新します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        private int WriteStockProc(ref StockWork stockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;

            try
            {
                //Selectコマンドの生成
                sqlStr = "SELECT UPDATEDATETIMERF FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";
                sqlCommand = new SqlCommand(sqlStr, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != stockWork.UpdateDateTime)
                    {
                        //新規登録で該当データ有りの場合には重複
                        if (stockWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                        //既存データで更新日時違いの場合には排他
                        else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    sqlStr = "UPDATE STOCKRF SET UPDATEDATETIMERF=@UPDATEDATETIME , SECTIONCODERF=@SECTIONCODE , WAREHOUSECODERF=@WAREHOUSECODE , GOODSMAKERCDRF=@GOODSMAKERCD , GOODSNORF=@GOODSNO , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL , SUPPLIERSTOCKRF=@SUPPLIERSTOCK , ACPODRCOUNTRF=@ACPODRCOUNT , SALESORDERCOUNTRF=@SALESORDERCOUNT , STOCKDIVRF=@STOCKDIV , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT , LASTSTOCKDATERF=@LASTSTOCKDATE , LASTSALESDATERF=@LASTSALESDATE , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT , SALESORDERUNITRF=@SALESORDERUNIT , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1 , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2 , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1 , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2 , STOCKNOTE1RF=@STOCKNOTE1 , STOCKNOTE2RF=@STOCKNOTE2 , SHIPMENTCNTRF=@SHIPMENTCNT , ARRIVALCNTRF=@ARRIVALCNT , STOCKCREATEDATERF=@STOCKCREATEDATE , UPDATEDATERF=@UPDATEDATE WHERE ENTERPRISECODERF=@UFINDENTERPRISECODE AND WAREHOUSECODERF=@UFINDWAREHOUSECODE AND GOODSMAKERCDRF=@UFINDGOODSMAKERCD AND GOODSNORF=@UFINDGOODSNO";

                    sqlCommand.CommandText = sqlStr;

                    findParaEnterpriseCode = sqlCommand.Parameters.Add("@UFINDENTERPRISECODE", SqlDbType.NChar);
                    findParaWarehouseCode = sqlCommand.Parameters.Add("@UFINDWAREHOUSECODE", SqlDbType.NChar);
                    findParaGoodsMakerCd = sqlCommand.Parameters.Add("@UFINDGOODSMAKERCD", SqlDbType.Int);
                    findParaGoodsNo = sqlCommand.Parameters.Add("@UFINDGOODSNO", SqlDbType.NVarChar);

                    //Parameterオブジェクトへ値設定(検索用)
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    if (stockWork.UpdateDateTime > DateTime.MinValue)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    sqlStr = "INSERT INTO STOCKRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @STOCKUNITPRICEFL, @SUPPLIERSTOCK, @ACPODRCOUNT, @MONTHORDERCOUNT, @SALESORDERCOUNT, @STOCKDIV, @MOVINGSUPLISTOCK, @SHIPMENTPOSCNT, @STOCKTOTALPRICE, @LASTSTOCKDATE, @LASTSALESDATE, @LASTINVENTORYUPDATE, @MINIMUMSTOCKCNT, @MAXIMUMSTOCKCNT, @NMLSALODRCOUNT, @SALESORDERUNIT, @STOCKSUPPLIERCODE, @GOODSNONONEHYPHEN, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @PARTSMANAGEMENTDIVIDE1, @PARTSMANAGEMENTDIVIDE2, @STOCKNOTE1, @STOCKNOTE2, @SHIPMENTCNT, @ARRIVALCNT, @STOCKCREATEDATE, @UPDATEDATE)";
                    sqlCommand.CommandText = sqlStr;

                    //登録ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetInsertHeader(ref flhd, obj);
                }
                if (myReader.IsClosed == false) myReader.Close();

                #region Parameterオブジェクトの作成(更新用)
                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
                SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
                SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
                SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
                SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
                SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
                SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);
                #endregion

                #region Parameterオブジェクトへ値設定(更新用)
                //Parameterオブジェクトへ値設定(更新用)
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockWork.SectionCode);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockWork.StockUnitPriceFl);
                paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockWork.SupplierStock);
                paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.AcpOdrCount);
                paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.MonthOrderCount);
                paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockWork.SalesOrderCount);
                paraStockDiv.Value = SqlDataMediator.SqlSetInt32(stockWork.StockDiv);
                paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockWork.MovingSupliStock);
                paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentPosCnt);
                paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(stockWork.StockTotalPrice);
                paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastStockDate);
                paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastSalesDate);
                paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.LastInventoryUpdate);
                paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MinimumStockCnt);
                paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.MaximumStockCnt);
                paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(stockWork.NmlSalOdrCount);
                paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(stockWork.SalesOrderUnit);
                paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(stockWork.StockSupplierCode);
                paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNoNoneHyphen);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseShelfNo);
                paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo1);
                paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(stockWork.DuplicationShelfNo2);
                paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide1);
                paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(stockWork.PartsManagementDivide2);
                paraStockNote1.Value = SqlDataMediator.SqlSetString(stockWork.StockNote1);
                paraStockNote2.Value = SqlDataMediator.SqlSetString(stockWork.StockNote2);
                paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ShipmentCnt);
                paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockWork.ArrivalCnt);
                paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.StockCreateDate);
                paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockWork.UpdateDate);
                #endregion

                sqlCommand.ExecuteNonQuery();
                //----- ADD START 松本 2015/01/28 ----->>>>>>
                sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                //----- ADD END 松本 2015/01/28 -----<<<<<<	
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
                retMessage = ex.ToString();
            }
            catch (Exception e)
            {
                //基底クラスに例外を渡して処理してもらう
                retMessage = e.ToString();
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region 0:論理削除 1:復活
        /// <summary>
        /// 在庫マスタ情報を論理削除します
        /// </summary>
        /// <param name="stockList">在庫リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報を論理削除します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        public int LogicalDelete(ref ArrayList stockList)
        {
            return LogicalDeleteStockInfo(ref stockList, 0);
        }

        /// <summary>
        /// 論理削除在庫マスタ情報を復活します
        /// </summary>
        /// <param name="stockList">在庫リスト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除在庫マスタ情報を復活します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        public int RevivalLogicalDelete(ref ArrayList stockList)
        {
            return LogicalDeleteStockInfo(ref stockList, 1);
        }

        /// <summary>
        /// 在庫マスタ情報の論理削除を操作します
        /// </summary>
        /// <param name="stockList">在庫リスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報の論理削除を操作します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        private int LogicalDeleteStockInfo(ref ArrayList stockList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {

                if (stockList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                StockWork stockWork = null;

                if (stockList != null && stockList.Count > 0)
                {
                    stockWork = (StockWork)stockList[0];
                }

                status = LogicalDeleteStockInfoProc(ref stockWork, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "StockMstDB.LogicalDeleteStockInfo :" + procModestr);

                // ロールバック
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// 在庫マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWork">在庫リスト</param>
        /// <param name="procMode">関数区分 0:論理削除 1:復活</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報の論理削除を操作します(外部からのSqlConnection + SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        /// <br></br>
        private int LogicalDeleteStockInfoProc(ref StockWork stockWork, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //Selectコマンドの生成
                string sqlTxt = "SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";
                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != stockWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }
                    //現在の論理削除区分を取得
                    logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                    sqlTxt = "";
                    sqlTxt += "UPDATE STOCKRF" + Environment.NewLine;
                    sqlTxt += "SET" + Environment.NewLine;
                    sqlTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                    sqlTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                    sqlTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                    sqlTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                    sqlTxt += " , SUPPLIERSTOCKRF=0" + Environment.NewLine; // ADD 2010/09/06
                    sqlTxt += " , ACPODRCOUNTRF=0" + Environment.NewLine; // ADD 2010/09/06
                    sqlTxt += " , SALESORDERCOUNTRF=0" + Environment.NewLine; // ADD 2010/09/06
                    sqlTxt += " , MOVINGSUPLISTOCKRF=0" + Environment.NewLine; // ADD 2010/09/06
                    sqlTxt += " , SHIPMENTCNTRF=0" + Environment.NewLine; // ADD 2010/09/06
                    sqlTxt += " , ARRIVALCNTRF=0" + Environment.NewLine; // ADD 2010/09/06
                    sqlTxt += " , SHIPMENTPOSCNTRF=0" + Environment.NewLine; // ADD 2010/09/06
                    sqlTxt += "WHERE" + Environment.NewLine;
                    sqlTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;
                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);

                    //更新ヘッダ情報を設定
                    object obj = (object)this;
                    IFileHeader flhd = (IFileHeader)stockWork;
                    FileHeader fileHeader = new FileHeader(obj);
                    fileHeader.SetUpdateHeader(ref flhd, obj);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                }
                if (myReader.IsClosed == false) myReader.Close();

                //論理削除モードの場合
                if (procMode == 0)
                {
                    if (logicalDelCd == 0) stockWork.LogicalDeleteCode = 1;//論理削除フラグをセット
                }
                else
                {
                    if (logicalDelCd == 1) stockWork.LogicalDeleteCode = 0;//論理削除フラグを解除
                }

                //Parameterオブジェクトの作成(更新用)
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定(更新用)
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockWork.LogicalDeleteCode);

                sqlCommand.ExecuteNonQuery();
                //----- ADD START 松本 2015/01/28 ----->>>>>>
                sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                //----- ADD END 松本 2015/01/28 -----<<<<<<	
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// 在庫マスタ情報を物理削除します
        /// </summary>
        /// <param name="stockList">在庫マスタ情報オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報を物理削除します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        public int Delete(ArrayList stockList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                if (stockList == null) return status;

                //コネクション生成
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // トランザクション開始
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                StockWork stockWork = null;

                if (stockList != null && stockList.Count > 0)
                {
                    stockWork = (StockWork)stockList[0];
                }

                status = DeleteStockProc(stockWork, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // コミット
                    sqlTransaction.Commit();
                else
                {
                    // ロールバック
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMstDB.Delete");
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
        /// 在庫マスタ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)
        /// </summary>
        /// <param name="stockWork">在庫マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタ情報を物理削除します(外部からのSqlConnection,SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
        private int DeleteStockProc(StockWork stockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                string sqlTxt = "";
                sqlTxt += "SELECT" + Environment.NewLine;
                sqlTxt += "   STOCKS.UPDATEDATETIMERF" + Environment.NewLine;
                sqlTxt += "  ,STOCKS.ENTERPRISECODERF" + Environment.NewLine;
                sqlTxt += "  ,STOCKS.LOGICALDELETECODERF" + Environment.NewLine;
                sqlTxt += "FROM STOCKRF AS STOCKS" + Environment.NewLine;
                sqlTxt += "WHERE " + Environment.NewLine;
                sqlTxt += "      STOCKS.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlTxt += "  AND STOCKS.GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                sqlTxt += "  AND STOCKS.WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                sqlTxt += "  AND STOCKS.GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlTxt, sqlConnection, sqlTransaction);

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);


                myReader = sqlCommand.ExecuteReader();
                if (myReader.Read())
                {
                    //既存GUIDデータがある場合で更新日時が異なる場合は排他エラーで戻す
                    DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//更新日時
                    if (_updateDateTime != stockWork.UpdateDateTime)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();
                        return status;
                    }

                    sqlTxt = "";
                    sqlTxt += "DELETE" + Environment.NewLine;
                    sqlTxt += "FROM STOCKRF" + Environment.NewLine;
                    sqlTxt += "WHERE" + Environment.NewLine;
                    sqlTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSMAKERCDRF=@FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlTxt += "  AND WAREHOUSECODERF=@FINDWAREHOUSECODE" + Environment.NewLine;
                    sqlTxt += "  AND GOODSNORF=@FINDGOODSNO" + Environment.NewLine;

                    sqlCommand.CommandText = sqlTxt;

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(stockWork.GoodsNo);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(stockWork.WarehouseCode);
                }
                else
                {
                    //既存GUIDデータが無い場合で更新日時が更新対象データに入っている場合はすでに削除されている意味で排他を戻す
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                    sqlCommand.Cancel();
                    if (myReader.IsClosed == false) myReader.Close();
                    return status;
                }
                if (myReader.IsClosed == false) myReader.Close();

                sqlCommand.ExecuteNonQuery();
                //----- ADD START 松本 2015/01/28 ----->>>>>>
                sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
                sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
                //----- ADD END 松本 2015/01/28 -----<<<<<<	
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/11</br>
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
        #endregion
    }
}

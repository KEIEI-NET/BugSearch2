//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 張莉莉
// 修 正 日  2009/06/12  修正内容 : public MethodでSQL文字が駄目対応について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/07/26  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/08/20  修正内容 : myReaderからDクラスへ項目転記を行っている個所はメソッド化する
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/08/25  修正内容 : #23798 条件送信で更新ボタン押下で処理が終了しない
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/02  修正内容 : ①#24364 在庫マスタの仕入先指定について 
//                                  ②#24358 在庫抽出条件で「グループコード」
//                                    を指定すると送信できない
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響 
// 修 正 日  2011/09/06  修正内容 : #24252 データを受信する時、
//                                  在庫マスタの数量の更新について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/09/16  修正内容 : #25186 在庫マスタ項目制御依頼
//----------------------------------------------------------------------------//
// 管理番号 11070266-00  作成担当 : 松本
// 修 正 日 2015/01/28   修正内容 : PMSCM同期化対応の変更
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

using Broadleaf.Library.Data;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫マスタREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APStockDB : RemoteDB
    {
        private const string MST_STOCK = "在庫マスタ";

        // 重複棚番１
        private const string MST_ID_DUPLICATIONSHELFNO1RF = "DuplicationShelfNo1RF";
        // 重複棚番２
        private const string MST_ID_DUPLICATIONSHELFNO2RF = "DuplicationShelfNo2RF";
        // 最高在庫数
        private const string MST_ID_MAXIMUMSTOCKCNTRF = "MaximumStockCntRF";
        // 最低在庫数
        private const string MST_ID_MINIMUMSTOCKCNTRF = "MinimumStockCntRF";
        // 管理区分１
        private const string MST_ID_PARTSMANAGEMENTDIVIDE1RF = "PartsManagementDivide1RF";
        // 管理区分２
        private const string MST_ID_PARTSMANAGEMENTDIVIDE2RF = "PartsManagementDivide2RF";
        // 発注残
        private const string MST_ID_SALESORDERCOUNTRF = "SalesOrderCountRF";
        // 発注ロット
        private const string MST_ID_SALESORDERUNITRF = "SalesOrderUnitRF";
        // 管理拠点
        private const string MST_ID_SECTIONCODERF = "SectionCodeRF";
        // 在庫区分
        private const string MST_ID_STOCKDIVRF = "StockDivRF";
        // 在庫備考１
        private const string MST_ID_STOCKNOTE1RF = "StockNote1RF";
        // 在庫備考2
        private const string MST_ID_STOCKNOTE2RF = "StockNote2RF";
        // 発注先
        private const string MST_ID_STOCKSUPPLIERCODERF = "StockSupplierCodeRF";
        // 在庫評価単価
        private const string MST_ID_STOCKUNITPRICEFLRF = "StockUnitPriceFlRF";
        // 仕入在庫数
        private const string MST_ID_SUPPLIERSTOCKRF = "SupplierStockRF";
        // 棚番
        private const string MST_ID_WAREHOUSESHELFNORF = "WarehouseShelfNoRF";
        // 受注数
        private const string MST_ID_ACPODRCOUNTRF = "AcpOdrCountRF";
        // 移動中仕入在庫数
        private const string MST_ID_MOVINGSUPLISTOCKRF = "MovingSupliStockRF";
        // 出荷可能数
        private const string MST_ID_SHIPMENTPOSCNTRF = "ShipmentPosCntRF";
        // 出荷数（未計上）
        private const string MST_ID_SHIPMENTCNTRF = "ShipmentCntRF";
        // 入荷数（未計上）
        private const string MST_ID_ARRIVALCNTRF = "ArrivalCntRF";

        // 重複棚番１
        private Int32 DuplicationShelfNo1Int = 0;
        // 重複棚番２
        private Int32 DuplicationShelfNo2Int = 0;
        // 最高在庫数
        private Int32 MaximumStockCntInt = 0;
        // 最低在庫数
        private Int32 MinimumStockCntInt = 0;
        // 管理区分１
        private Int32 PartsManagementDivide1Int = 0;
        // 管理区分２
        private Int32 PartsManagementDivide2Int = 0;
        // 発注残
        private Int32 SalesOrderCountInt = 0;
        // 発注ロット
        private Int32 SalesOrderUnitInt = 0;
        // 管理拠点
        private Int32 SectionCodeInt = 0;
        // 在庫区分
        private Int32 StockDivInt = 0;
        // 在庫備考１
        private Int32 StockNote1Int = 0;
        // 在庫備考2
        private Int32 StockNote2Int = 0;
        // 発注先
        private Int32 StockSupplierCodeInt = 0;
        // 在庫評価単価
        private Int32 StockUnitPriceFlInt = 0;
        // 仕入在庫数
        private Int32 SupplierStockInt = 0;
        // 棚番
        private Int32 WarehouseShelfNoInt = 0;
        // 受注数
        private Int32 AcpOdrCountInt = 0;
        // 移動中仕入在庫数
        private Int32 MovingSupliStockInt = 0;
        // 出荷可能数
        private Int32 ShipmentPosCntInt = 0;
        // 出荷数（未計上）
        private Int32 ShipmentCntInt = 0;
        // 入荷数（未計上）
        private Int32 ArrivalCntInt = 0;

        #region [Private]
        private int _indexCreateDateTime;
        private int _indexUpdateDateTime;
        private int _indexEnterpriseCode;
        private int _indexFileHeaderGuid;
        private int _indexUpdEmployeeCode;
        private int _indexUpdAssemblyId1;
        private int _indexUpdAssemblyId2;
        private int _indexLogicalDeleteCode;
        private int _indexSectionCode;
        private int _indexWarehouseCode;
        private int _indexGoodsMakerCd;
        private int _indexGoodsNo;
        private int _indexStockUnitPriceFl;
        private int _indexSupplierStock;
        private int _indexAcpOdrCount;
        private int _indexMonthOrderCount;
        private int _indexSalesOrderCount;
        private int _indexStockDiv;
        private int _indexMovingSupliStock;
        private int _indexShipmentPosCnt;
        private int _indexStockTotalPrice;
        private int _indexLastStockDate;
        private int _indexLastSalesDate;
        private int _indexLastInventoryUpdate;
        private int _indexMinimumStockCnt;
        private int _indexMaximumStockCnt;
        private int _indexNmlSalOdrCount;
        private int _indexSalesOrderUnit;
        private int _indexStockSupplierCode;
        private int _indexGoodsNoNoneHyphen;
        private int _indexWarehouseShelfNo;
        private int _indexDuplicationShelfNo1;
        private int _indexDuplicationShelfNo2;
        private int _indexPartsManagementDivide1;
        private int _indexPartsManagementDivide2;
        private int _indexStockNote1;
        private int _indexStockNote2;
        private int _indexShipmentCnt;
        private int _indexArrivalCnt;
        private int _indexStockCreateDate;
        private int _indexUpdateDate;
        #endregion

        /// <summary>
        /// 在庫マスタREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APStockDB()
            : base("PMKYO06191D", "Broadleaf.Application.Remoting.ParamData.APStockWork", "STOCKRF")
        {

        }

        #region [Read]
        /// <summary>
        /// 在庫マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockArrList">在庫マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public int SearchStock(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockArrList, out string retMessage)
        {
            return SearchStockProc(enterpriseCodes, beginningDate, endingDate, sqlConnection, sqlTransaction, out stockArrList, out retMessage);
        }
        /// <summary>
        /// 在庫マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockArrList">在庫マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        private int SearchStockProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockArrList = new ArrayList();
            APStockWork stockWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                //在庫マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockWork = new APStockWork();

                    stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                    stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                    stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                    stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                    stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    stockArrList.Add(stockWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APStockDB.SearchStock Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// 在庫マスタの計数検索処理
        /// </summary>
        /// <param name="stockWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタデータ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        public int SearchStockCount(APStockWork stockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            return SearchStockCountProc(stockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 在庫マスタの計数検索処理
        /// </summary>
        /// <param name="stockWork">検索オブジェクト</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタデータ計数を全て戻します</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.04</br>
        private int SearchStockCountProc(APStockWork stockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockWork.EnterpriseCode);
                findParaWarehouseCode.Value = stockWork.WarehouseCode;
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockWork.GoodsMakerCd);
                findParaGoodsNo.Value = stockWork.GoodsNo;

                // 拠点情報設定マスタデータ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APStockDB.SearchStockCount Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }
            return status;
        }

        #endregion

        # region [Delete]
        /// <summary>
        ///  在庫マスタデータ削除
        /// </summary>
        /// <param name="apStockWork">在庫マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br>
        public void Delete(APStockWork apStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            DeleteProc(apStockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        ///  在庫マスタデータ削除
        /// </summary>
        /// <param name="apStockWork">在庫マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタデータを削除する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void DeleteProc(APStockWork apStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM STOCKRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND WAREHOUSECODERF=@FINDWAREHOUSECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO";
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
            SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
            SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = apStockWork.EnterpriseCode;
            findParaWarehouseCode.Value = apStockWork.WarehouseCode;
            findParaGoodsMakerCd.Value = apStockWork.GoodsMakerCd;
            findParaGoodsNo.Value = apStockWork.GoodsNo;


            // 在庫マスタデータを削除する
            sqlCommand.ExecuteNonQuery();
            //----- ADD START 松本 2015/01/28 ----->>>>>>
            sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
            sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
            //----- ADD END 松本 2015/01/28 -----<<<<<<	
        }
        #endregion

        # region [Insert]
        /// <summary>
        /// 在庫マスタ登録
        /// </summary>
        /// <param name="apStockWork">在庫マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Insert(APStockWork apStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(apStockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 在庫マスタ登録
        /// </summary>
        /// <param name="apStockWork">在庫マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタデータを登録する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void InsertProc(APStockWork apStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "INSERT INTO STOCKRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @STOCKUNITPRICEFL, @SUPPLIERSTOCK, @ACPODRCOUNT, @MONTHORDERCOUNT, @SALESORDERCOUNT, @STOCKDIV, @MOVINGSUPLISTOCK, @SHIPMENTPOSCNT, @STOCKTOTALPRICE, @LASTSTOCKDATE, @LASTSALESDATE, @LASTINVENTORYUPDATE, @MINIMUMSTOCKCNT, @MAXIMUMSTOCKCNT, @NMLSALODRCOUNT, @SALESORDERUNIT, @STOCKSUPPLIERCODE, @GOODSNONONEHYPHEN, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @PARTSMANAGEMENTDIVIDE1, @PARTSMANAGEMENTDIVIDE2, @STOCKNOTE1, @STOCKNOTE2, @SHIPMENTCNT, @ARRIVALCNT, @STOCKCREATEDATE, @UPDATEDATE)";

            //Prameterオブジェクトの作成
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

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apStockWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apStockWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apStockWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apStockWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apStockWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apStockWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apStockWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apStockWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(apStockWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = apStockWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(apStockWork.SectionCode);
            }
            if (string.IsNullOrEmpty(apStockWork.WarehouseCode.Trim()))
            {
                paraWarehouseCode.Value = apStockWork.WarehouseCode;
            }
            else
            {
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(apStockWork.WarehouseCode);
            }
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apStockWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apStockWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apStockWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apStockWork.GoodsNo);
            }
            paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(apStockWork.StockUnitPriceFl);
            paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(apStockWork.SupplierStock);
            paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.AcpOdrCount);
            paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.MonthOrderCount);
            paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.SalesOrderCount);
            paraStockDiv.Value = SqlDataMediator.SqlSetInt32(apStockWork.StockDiv);
            paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(apStockWork.MovingSupliStock);
            paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentPosCnt);
            paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(apStockWork.StockTotalPrice);
            paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastStockDate);
            paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastSalesDate);
            paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastInventoryUpdate);
            paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.MinimumStockCnt);
            paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.MaximumStockCnt);
            paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.NmlSalOdrCount);
            paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(apStockWork.SalesOrderUnit);
            paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(apStockWork.StockSupplierCode);
            paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(apStockWork.GoodsNoNoneHyphen);
            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(apStockWork.WarehouseShelfNo);
            paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(apStockWork.DuplicationShelfNo1);
            paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(apStockWork.DuplicationShelfNo2);
            paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(apStockWork.PartsManagementDivide1);
            paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(apStockWork.PartsManagementDivide2);
            paraStockNote1.Value = SqlDataMediator.SqlSetString(apStockWork.StockNote1);
            paraStockNote2.Value = SqlDataMediator.SqlSetString(apStockWork.StockNote2);
            paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentCnt);
            paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ArrivalCnt);
            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.StockCreateDate);
            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.UpdateDate);


            // 在庫マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
            //----- ADD START 松本 2015/01/28 ----->>>>>>
            sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
            sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
            //----- ADD END 松本 2015/01/28 -----<<<<<<	
        }

        /// <summary>
        /// 在庫マスタ登録
        /// </summary>
        /// <param name="masterDtlDivList">マスタ詳細区分</param>
        /// <param name="apStockWork">在庫マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタデータを登録する</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.06</br> 
        public void Insert(ArrayList masterDtlDivList, APStockWork apStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            InsertProc(masterDtlDivList, apStockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 在庫マスタ登録
        /// </summary>        
        /// <param name="masterDtlDivList">マスタ詳細区分</param>
        /// <param name="apStockWork">在庫マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタデータを登録する</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.09.06</br> 
        private void InsertProc(ArrayList masterDtlDivList, APStockWork apStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in masterDtlDivList)
            {
                // 仕入在庫数
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SUPPLIERSTOCKRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    SupplierStockInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
            }

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);           

            // INSERTコマンドの生成
            sqlCommand.CommandText = "INSERT INTO STOCKRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, SECTIONCODERF, WAREHOUSECODERF, GOODSMAKERCDRF, GOODSNORF, STOCKUNITPRICEFLRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, MONTHORDERCOUNTRF, SALESORDERCOUNTRF, STOCKDIVRF, MOVINGSUPLISTOCKRF, SHIPMENTPOSCNTRF, STOCKTOTALPRICERF, LASTSTOCKDATERF, LASTSALESDATERF, LASTINVENTORYUPDATERF, MINIMUMSTOCKCNTRF, MAXIMUMSTOCKCNTRF, NMLSALODRCOUNTRF, SALESORDERUNITRF, STOCKSUPPLIERCODERF, GOODSNONONEHYPHENRF, WAREHOUSESHELFNORF, DUPLICATIONSHELFNO1RF, DUPLICATIONSHELFNO2RF, PARTSMANAGEMENTDIVIDE1RF, PARTSMANAGEMENTDIVIDE2RF, STOCKNOTE1RF, STOCKNOTE2RF, SHIPMENTCNTRF, ARRIVALCNTRF, STOCKCREATEDATERF, UPDATEDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @SECTIONCODE, @WAREHOUSECODE, @GOODSMAKERCD, @GOODSNO, @STOCKUNITPRICEFL, @SUPPLIERSTOCK, @ACPODRCOUNT, @MONTHORDERCOUNT, @SALESORDERCOUNT, @STOCKDIV, @MOVINGSUPLISTOCK, @SHIPMENTPOSCNT, @STOCKTOTALPRICE, @LASTSTOCKDATE, @LASTSALESDATE, @LASTINVENTORYUPDATE, @MINIMUMSTOCKCNT, @MAXIMUMSTOCKCNT, @NMLSALODRCOUNT, @SALESORDERUNIT, @STOCKSUPPLIERCODE, @GOODSNONONEHYPHEN, @WAREHOUSESHELFNO, @DUPLICATIONSHELFNO1, @DUPLICATIONSHELFNO2, @PARTSMANAGEMENTDIVIDE1, @PARTSMANAGEMENTDIVIDE2, @STOCKNOTE1, @STOCKNOTE2, @SHIPMENTCNT, @ARRIVALCNT, @STOCKCREATEDATE, @UPDATEDATE)";

            //Prameterオブジェクトの作成
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

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apStockWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apStockWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apStockWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apStockWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apStockWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apStockWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apStockWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apStockWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(apStockWork.SectionCode.Trim()))
            {
                paraSectionCode.Value = apStockWork.SectionCode;
            }
            else
            {
                paraSectionCode.Value = SqlDataMediator.SqlSetString(apStockWork.SectionCode);
            }
            if (string.IsNullOrEmpty(apStockWork.WarehouseCode.Trim()))
            {
                paraWarehouseCode.Value = apStockWork.WarehouseCode;
            }
            else
            {
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(apStockWork.WarehouseCode);
            }
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apStockWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apStockWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apStockWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apStockWork.GoodsNo);
            }
            paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(apStockWork.StockUnitPriceFl);
            if (SupplierStockInt == 0)
            {
                paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(apStockWork.SupplierStock);

				//-----ADD 2011/09/16 by fengwx for #25186----->>>>>
				// 受注数
				paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.AcpOdrCount);
				// 出荷数（未計上）
				paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentCnt);
				// 入荷数（未計上）
				paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ArrivalCnt);
				// 移動中仕入在庫数
				paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(apStockWork.MovingSupliStock);
				// 出荷可能数
				paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentPosCnt);
				//-----ADD 2011/09/16 by fengwx for #25186-----<<<<<
            }
            else
            {
                paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(0);

				//-----ADD 2011/09/16 by fengwx for #25186----->>>>>
				// 受注数
				paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(0);
				// 出荷数（未計上）
				paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(0);
				// 入荷数（未計上）
				paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(0);
				// 移動中仕入在庫数
				paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(0);
				// 出荷可能数
				paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(0);
				//-----ADD 2011/09/16 by fengwx for #25186-----<<<<<
            }
			//paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.AcpOdrCount);  // DEL 2011/09/16 by fengwx for #25186
            paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.MonthOrderCount);
            paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.SalesOrderCount);
            paraStockDiv.Value = SqlDataMediator.SqlSetInt32(apStockWork.StockDiv);
			//paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(apStockWork.MovingSupliStock); // DEL 2011/09/16 by fengwx for #25186
			//paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentPosCnt); // DEL 2011/09/16 by fengwx for #25186
            paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(apStockWork.StockTotalPrice);
            paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastStockDate);
            paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastSalesDate);
            paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastInventoryUpdate);
            paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.MinimumStockCnt);
            paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.MaximumStockCnt);
            paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.NmlSalOdrCount);
            paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(apStockWork.SalesOrderUnit);
            paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(apStockWork.StockSupplierCode);
            paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(apStockWork.GoodsNoNoneHyphen);
            paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(apStockWork.WarehouseShelfNo);
            paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(apStockWork.DuplicationShelfNo1);
            paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(apStockWork.DuplicationShelfNo2);
            paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(apStockWork.PartsManagementDivide1);
            paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(apStockWork.PartsManagementDivide2);
            paraStockNote1.Value = SqlDataMediator.SqlSetString(apStockWork.StockNote1);
            paraStockNote2.Value = SqlDataMediator.SqlSetString(apStockWork.StockNote2);
			//paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentCnt); // DEL 2011/09/16 by fengwx for #25186
			//paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ArrivalCnt); // DEL 2011/09/16 by fengwx for #25186
            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.StockCreateDate);
            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.UpdateDate);


            // 在庫マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
            //----- ADD START 松本 2015/01/28 ----->>>>>>
            sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
            sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
            //----- ADD END 松本 2015/01/28 -----<<<<<<	
        }
        
        #endregion

        # region [Update]
        /// <summary>
        /// 在庫マスタ更新
        /// </summary>
        /// <param name="masterDtlDivList">マスタ詳細区分</param>
        /// <param name="apStockWork">在庫マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタデータを更新する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        public void Update(ArrayList masterDtlDivList, APStockWork apStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            UpdateProc(masterDtlDivList, apStockWork, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
        }
        /// <summary>
        /// 在庫マスタ更新
        /// </summary>
        /// <param name="masterDtlDivList">マスタ詳細区分</param>
        /// <param name="apStockWork">在庫マスタデータ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        /// <br>Note       : 在庫マスタデータを更新する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.04.28</br> 
        private void UpdateProc(ArrayList masterDtlDivList, APStockWork apStockWork, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            foreach (SecMngSndRcvDtlWork secMngSndRcvDtlWork in masterDtlDivList)
            {
                // 重複棚番１
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_DUPLICATIONSHELFNO1RF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    DuplicationShelfNo1Int = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 重複棚番２
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_DUPLICATIONSHELFNO2RF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    DuplicationShelfNo2Int = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 最高在庫数
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_MAXIMUMSTOCKCNTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    MaximumStockCntInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 最低在庫数
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_MINIMUMSTOCKCNTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    MinimumStockCntInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 管理区分１
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_PARTSMANAGEMENTDIVIDE1RF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    PartsManagementDivide1Int = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 管理区分２
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_PARTSMANAGEMENTDIVIDE2RF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    PartsManagementDivide2Int = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 発注残
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SALESORDERCOUNTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    SalesOrderCountInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 発注ロット
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SALESORDERUNITRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    SalesOrderUnitInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 管理拠点
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SECTIONCODERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    SectionCodeInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 在庫区分
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_STOCKDIVRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    StockDivInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 在庫備考１
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_STOCKNOTE1RF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    StockNote1Int = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 在庫備考2
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_STOCKNOTE2RF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    StockNote2Int = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 発注先
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_STOCKSUPPLIERCODERF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    StockSupplierCodeInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 在庫評価単価
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_STOCKUNITPRICEFLRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    StockUnitPriceFlInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 仕入在庫数
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SUPPLIERSTOCKRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    SupplierStockInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 棚番
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_WAREHOUSESHELFNORF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    WarehouseShelfNoInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 受注数
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_ACPODRCOUNTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    AcpOdrCountInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 移動中仕入在庫数
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_MOVINGSUPLISTOCKRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    MovingSupliStockInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 出荷可能数
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SHIPMENTPOSCNTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    ShipmentPosCntInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 出荷数（未計上）
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_SHIPMENTCNTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    ShipmentCntInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
                // 入荷数（未計上）
                if (MST_STOCK.Equals(secMngSndRcvDtlWork.FileNm) && MST_ID_ARRIVALCNTRF.Equals(secMngSndRcvDtlWork.ItemId))
                {
                    ArrivalCntInt = secMngSndRcvDtlWork.DataUpdateDiv;
                }
            }

            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            string sqlText = string.Empty;

            // Deleteコマンドの生成
            sqlText = "UPDATE STOCKRF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE  ";
            // 管理拠点
            if (SectionCodeInt == 0)
            {
                sqlText = sqlText + " , SECTIONCODERF=@SECTIONCODE ";
            }
            sqlText = sqlText + " , WAREHOUSECODERF=@WAREHOUSECODE ";
            sqlText = sqlText + " , GOODSMAKERCDRF=@GOODSMAKERCD  ";
            sqlText = sqlText + " , GOODSNORF=@GOODSNO  ";
            // 在庫評価単価
            if (StockUnitPriceFlInt == 0)
            {
                sqlText = sqlText + " , STOCKUNITPRICEFLRF=@STOCKUNITPRICEFL ";
            }
            // 仕入在庫数
            if (SupplierStockInt == 0)
            {
                sqlText = sqlText + " , SUPPLIERSTOCKRF=@SUPPLIERSTOCK  ";
                //-----ADD 2011/09/16 by fengwx for #25186----->>>>>
                // 受注数
                sqlText = sqlText + " , ACPODRCOUNTRF=@ACPODRCOUNT  ";
                // 出荷数（未計上）
                sqlText = sqlText + " , SHIPMENTCNTRF=@SHIPMENTCNT   ";
                // 入荷数（未計上）
                sqlText = sqlText + " , ARRIVALCNTRF=@ARRIVALCNT   ";
				// 移動中仕入在庫数
				sqlText = sqlText + " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK  ";
				// 出荷可能数
				sqlText = sqlText + " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT  ";
                //-----ADD 2011/09/16 by fengwx for #25186-----<<<<<
            }
            //-----DEL 2011/09/16 by fengwx for #25186----->>>>>
            //// 受注数
            //if (AcpOdrCountInt == 0)
            //{
            //    sqlText = sqlText + " , ACPODRCOUNTRF=@ACPODRCOUNT  ";
            //}
            //-----DEL 2011/09/16 by fengwx for #25186-----<<<<<

            sqlText = sqlText + " , MONTHORDERCOUNTRF=@MONTHORDERCOUNT ";
            // 発注残
            if (SalesOrderCountInt == 0)
            {
                sqlText = sqlText + " , SALESORDERCOUNTRF=@SALESORDERCOUNT  ";
            }
            // 在庫区分
            if (StockDivInt == 0)
            {
                sqlText = sqlText + " , STOCKDIVRF=@STOCKDIV ";
            }
			//-----DEL 2011/09/16 by fengwx for #25186----->>>>>
			//// 移動中仕入在庫数
			//if (MovingSupliStockInt == 0)
			//{
			//    sqlText = sqlText + " , MOVINGSUPLISTOCKRF=@MOVINGSUPLISTOCK  ";
			//}
			//-----DEL 2011/09/16 by fengwx for #25186-----<<<<<
			//// 出荷可能数
			//if (ShipmentPosCntInt == 0)
			//{
			//    sqlText = sqlText + " , SHIPMENTPOSCNTRF=@SHIPMENTPOSCNT  ";
			//}
			//-----DEL 2011/09/16 by fengwx for #25186-----<<<<<

            sqlText = sqlText + " , STOCKTOTALPRICERF=@STOCKTOTALPRICE   ";
            sqlText = sqlText + " , LASTSTOCKDATERF=@LASTSTOCKDATE  ";
            sqlText = sqlText + " , LASTSALESDATERF=@LASTSALESDATE  ";
            sqlText = sqlText + " , LASTINVENTORYUPDATERF=@LASTINVENTORYUPDATE  ";
            // 最低在庫数
            if (MinimumStockCntInt == 0)
            {
                sqlText = sqlText + " , MINIMUMSTOCKCNTRF=@MINIMUMSTOCKCNT  ";
            }
            // 最高在庫数
            if (MaximumStockCntInt == 0)
            {
                sqlText = sqlText + " , MAXIMUMSTOCKCNTRF=@MAXIMUMSTOCKCNT  ";
            }

            sqlText = sqlText + " , NMLSALODRCOUNTRF=@NMLSALODRCOUNT  ";
            // 発注ロット
            if (SalesOrderUnitInt == 0)
            {
                sqlText = sqlText + " , SALESORDERUNITRF=@SALESORDERUNIT  ";
            }
            // 発注先
            if (StockSupplierCodeInt == 0)
            {
                sqlText = sqlText + " , STOCKSUPPLIERCODERF=@STOCKSUPPLIERCODE  ";
            }

            sqlText = sqlText + " , GOODSNONONEHYPHENRF=@GOODSNONONEHYPHEN  ";
            // 棚番
            if (WarehouseShelfNoInt == 0)
            {
                sqlText = sqlText + " , WAREHOUSESHELFNORF=@WAREHOUSESHELFNO   ";
            }
            // 重複棚番１
            if (DuplicationShelfNo1Int == 0)
            {
                sqlText = sqlText + " , DUPLICATIONSHELFNO1RF=@DUPLICATIONSHELFNO1   ";
            }
            // 重複棚番２
            if (DuplicationShelfNo2Int == 0)
            {
                sqlText = sqlText + " , DUPLICATIONSHELFNO2RF=@DUPLICATIONSHELFNO2   ";
            }
            // 管理区分１
            if (PartsManagementDivide1Int == 0)
            {
                sqlText = sqlText + " , PARTSMANAGEMENTDIVIDE1RF=@PARTSMANAGEMENTDIVIDE1  ";
            }
            // 管理区分２
            if (PartsManagementDivide2Int == 0)
            {
                sqlText = sqlText + " , PARTSMANAGEMENTDIVIDE2RF=@PARTSMANAGEMENTDIVIDE2  ";
            }
            // 在庫備考１
            if (StockNote1Int == 0)
            {
                sqlText = sqlText + " , STOCKNOTE1RF=@STOCKNOTE1   ";
            }
            // 在庫備考2
            if (StockNote2Int == 0)
            {
                sqlText = sqlText + " , STOCKNOTE2RF=@STOCKNOTE2   ";
            }
            //-----DEL 2011/09/16 by fengwx for #25186----->>>>>
            //// 出荷数（未計上）
            //if (ShipmentCntInt == 0)
            //{
            //    sqlText = sqlText + " , SHIPMENTCNTRF=@SHIPMENTCNT   ";
            //}
            //// 入荷数（未計上）
            //if (ArrivalCntInt == 0)
            //{
            //    sqlText = sqlText + " , ARRIVALCNTRF=@ARRIVALCNT   ";
            //}
            //-----DEL 2011/09/16 by fengwx for #25186-----<<<<<
            sqlText = sqlText + " , STOCKCREATEDATERF=@STOCKCREATEDATE   ";
            sqlText = sqlText + " , UPDATEDATERF=@UPDATEDATE    ";
            sqlText = sqlText + " WHERE ENTERPRISECODERF=@ENTERPRISECODE AND WAREHOUSECODERF=@WAREHOUSECODE AND GOODSMAKERCDRF=@GOODSMAKERCD AND GOODSNORF=@GOODSNO   ";

            sqlCommand.CommandText = sqlText;

            //Prameterオブジェクトの作成
            SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
            SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
            SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
            SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
            // 管理拠点
            if (SectionCodeInt == 0)
            {
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                if (string.IsNullOrEmpty(apStockWork.SectionCode.Trim()))
                {
                    paraSectionCode.Value = apStockWork.SectionCode;
                }
                else
                {
                    paraSectionCode.Value = SqlDataMediator.SqlSetString(apStockWork.SectionCode);
                }
            }

            SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
            SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
            SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
            // 在庫評価単価
            if (StockUnitPriceFlInt == 0)
            {
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(apStockWork.StockUnitPriceFl);
            }
            // 仕入在庫数
            if (SupplierStockInt == 0)
            {
                SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(apStockWork.SupplierStock);
                //-----ADD 2011/09/16 by fengwx for #25186----->>>>>
                // 受注数
                SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.AcpOdrCount);
                // 出荷数（未計上）
                SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentCnt);
                // 入荷数（未計上）
                SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ArrivalCnt);
				// 移動中仕入在庫数
				SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
				paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(apStockWork.MovingSupliStock);
				// 出荷可能数
				SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
				paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentPosCnt);
                //-----ADD 2011/09/16 by fengwx for #25186-----<<<<<
            }
            //-----DEL 2011/09/16 by fengwx for #25186----->>>>>
            //// 受注数
            //if (AcpOdrCountInt == 0)
            //{
            //    SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
            //    paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.AcpOdrCount);
            //}
            //-----DEL 2011/09/16 by fengwx for #25186-----<<<<<

            SqlParameter paraMonthOrderCount = sqlCommand.Parameters.Add("@MONTHORDERCOUNT", SqlDbType.Float);
            // 発注残
            if (SalesOrderCountInt == 0)
            {
                SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.SalesOrderCount);
            }
            // 在庫区分
            if (StockDivInt == 0)
            {
                SqlParameter paraStockDiv = sqlCommand.Parameters.Add("@STOCKDIV", SqlDbType.Int);
                paraStockDiv.Value = SqlDataMediator.SqlSetInt32(apStockWork.StockDiv);
            }
			//-----DEL 2011/09/16 by fengwx for #25186----->>>>>
			//// 移動中仕入在庫数
			//if (MovingSupliStockInt == 0)
			//{
			//    SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
			//    paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(apStockWork.MovingSupliStock);
			//}
			//-----DEL 2011/09/16 by fengwx for #25186-----<<<<<
			//// 出荷可能数
			//if (ShipmentPosCntInt == 0)
			//{
			//    SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
			//    paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentPosCnt);
			//}
			//-----DEL 2011/09/16 by fengwx for #25186-----<<<<<

            SqlParameter paraStockTotalPrice = sqlCommand.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
            SqlParameter paraLastStockDate = sqlCommand.Parameters.Add("@LASTSTOCKDATE", SqlDbType.Int);
            SqlParameter paraLastSalesDate = sqlCommand.Parameters.Add("@LASTSALESDATE", SqlDbType.Int);
            SqlParameter paraLastInventoryUpdate = sqlCommand.Parameters.Add("@LASTINVENTORYUPDATE", SqlDbType.Int);
            // 最低在庫数
            if (MinimumStockCntInt == 0)
            {
                SqlParameter paraMinimumStockCnt = sqlCommand.Parameters.Add("@MINIMUMSTOCKCNT", SqlDbType.Float);
                paraMinimumStockCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.MinimumStockCnt);
            }
            // 最高在庫数
            if (MaximumStockCntInt == 0)
            {
                SqlParameter paraMaximumStockCnt = sqlCommand.Parameters.Add("@MAXIMUMSTOCKCNT", SqlDbType.Float);
                paraMaximumStockCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.MaximumStockCnt);
            }

            SqlParameter paraNmlSalOdrCount = sqlCommand.Parameters.Add("@NMLSALODRCOUNT", SqlDbType.Float);
            // 発注ロット
            if (SalesOrderUnitInt == 0)
            {
                SqlParameter paraSalesOrderUnit = sqlCommand.Parameters.Add("@SALESORDERUNIT", SqlDbType.Int);
                paraSalesOrderUnit.Value = SqlDataMediator.SqlSetInt32(apStockWork.SalesOrderUnit);
            }
            // 発注先
            if (StockSupplierCodeInt == 0)
            {
                SqlParameter paraStockSupplierCode = sqlCommand.Parameters.Add("@STOCKSUPPLIERCODE", SqlDbType.Int);
                paraStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(apStockWork.StockSupplierCode);
            }

            SqlParameter paraGoodsNoNoneHyphen = sqlCommand.Parameters.Add("@GOODSNONONEHYPHEN", SqlDbType.NVarChar);
            // 棚番
            if (WarehouseShelfNoInt == 0)
            {
                SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(apStockWork.WarehouseShelfNo);
            }
            // 重複棚番１
            if (DuplicationShelfNo1Int == 0)
            {
                SqlParameter paraDuplicationShelfNo1 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO1", SqlDbType.NVarChar);
                paraDuplicationShelfNo1.Value = SqlDataMediator.SqlSetString(apStockWork.DuplicationShelfNo1);
            }
            // 重複棚番２
            if (DuplicationShelfNo2Int == 0)
            {
                SqlParameter paraDuplicationShelfNo2 = sqlCommand.Parameters.Add("@DUPLICATIONSHELFNO2", SqlDbType.NVarChar);
                paraDuplicationShelfNo2.Value = SqlDataMediator.SqlSetString(apStockWork.DuplicationShelfNo2);
            }
            // 管理区分１
            if (PartsManagementDivide1Int == 0)
            {
                SqlParameter paraPartsManagementDivide1 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE1", SqlDbType.NChar);
                paraPartsManagementDivide1.Value = SqlDataMediator.SqlSetString(apStockWork.PartsManagementDivide1);
            }
            // 管理区分２
            if (PartsManagementDivide2Int == 0)
            {
                SqlParameter paraPartsManagementDivide2 = sqlCommand.Parameters.Add("@PARTSMANAGEMENTDIVIDE2", SqlDbType.NChar);
                paraPartsManagementDivide2.Value = SqlDataMediator.SqlSetString(apStockWork.PartsManagementDivide2);
            }
            // 在庫備考１
            if (StockNote1Int == 0)
            {
                SqlParameter paraStockNote1 = sqlCommand.Parameters.Add("@STOCKNOTE1", SqlDbType.NVarChar);
                paraStockNote1.Value = SqlDataMediator.SqlSetString(apStockWork.StockNote1);
            }
            // 在庫備考2
            if (StockNote2Int == 0)
            {
                SqlParameter paraStockNote2 = sqlCommand.Parameters.Add("@STOCKNOTE2", SqlDbType.NVarChar);
                paraStockNote2.Value = SqlDataMediator.SqlSetString(apStockWork.StockNote2);
            }
            //-----DEL 2011/09/16 by fengwx for #25186----->>>>>
            //// 出荷数（未計上）
            //if (ShipmentCntInt == 0)
            //{
            //    SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
            //    paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ShipmentCnt);
            //}
            //// 入荷数（未計上）
            //if (ArrivalCntInt == 0)
            //{
            //    SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
            //    paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(apStockWork.ArrivalCnt);
            //}
            //-----DEL 2011/09/16 by fengwx for #25186-----<<<<<

            SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
            SqlParameter paraUpdateDate = sqlCommand.Parameters.Add("@UPDATEDATE", SqlDbType.Int);

            //Parameterオブジェクトへ値設定
            paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apStockWork.CreateDateTime);
            paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(apStockWork.UpdateDateTime);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(apStockWork.EnterpriseCode);
            paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(apStockWork.FileHeaderGuid);
            paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(apStockWork.UpdEmployeeCode);
            paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(apStockWork.UpdAssemblyId1);
            paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(apStockWork.UpdAssemblyId2);
            paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(apStockWork.LogicalDeleteCode);
            if (string.IsNullOrEmpty(apStockWork.WarehouseCode.Trim()))
            {
                paraWarehouseCode.Value = apStockWork.WarehouseCode;
            }
            else
            {
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(apStockWork.WarehouseCode);
            }
            paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(apStockWork.GoodsMakerCd);
            if (string.IsNullOrEmpty(apStockWork.GoodsNo.Trim()))
            {
                paraGoodsNo.Value = apStockWork.GoodsNo;
            }
            else
            {
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(apStockWork.GoodsNo);
            }
            paraMonthOrderCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.MonthOrderCount);
            paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(apStockWork.StockTotalPrice);
            paraLastStockDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastStockDate);
            paraLastSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastSalesDate);
            paraLastInventoryUpdate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.LastInventoryUpdate);
            paraNmlSalOdrCount.Value = SqlDataMediator.SqlSetDouble(apStockWork.NmlSalOdrCount);
            paraGoodsNoNoneHyphen.Value = SqlDataMediator.SqlSetString(apStockWork.GoodsNoNoneHyphen);
            paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.StockCreateDate);
            paraUpdateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(apStockWork.UpdateDate);


            // 在庫マスタデータを登録する
            sqlCommand.ExecuteNonQuery();
            //----- ADD START 松本 2015/01/28 ----->>>>>>
            sqlConnection.Disposed -= new EventHandler(SynchExecuteMngDB.SyncNotify);
            sqlConnection.Disposed += new EventHandler(SynchExecuteMngDB.SyncNotify);
            //----- ADD END 松本 2015/01/28 -----<<<<<<	
        }

        #endregion

        #region 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）
        #region [Read]
        /// <summary>
        /// 在庫マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockArrList">在庫マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.07.26</br>
        public int SearchStock(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockArrList, out string retMessage)
        {
            return SearchStockProc(enterpriseCodes, paramList, sqlConnection,
                            sqlTransaction, out stockArrList, out retMessage);
        }
        /// <summary>
        /// 在庫マスタの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockArrList">在庫マスタデータオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫マスタデータREADLISTを全て戻します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011.07.26</br>
        private int SearchStockProc(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockArrList = new ArrayList();
            //APStockWork stockWork = null;//DEL 2011/08/20 途中納品チェック
            retMessage = string.Empty;
             //string sqlStr = string.Empty;//DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
            StringBuilder sqlStr = new StringBuilder();//ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            APStockProcParamWork param = paramList as APStockProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                #region DEL SQL
                //DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない--------------------------------------------------->>>>>
                //sqlStr = "SELECT STOCKRF.CREATEDATETIMERF, STOCKRF.UPDATEDATETIMERF, STOCKRF.ENTERPRISECODERF, STOCKRF.FILEHEADERGUIDRF, STOCKRF.UPDEMPLOYEECODERF, STOCKRF.UPDASSEMBLYID1RF, STOCKRF.UPDASSEMBLYID2RF, STOCKRF.LOGICALDELETECODERF, STOCKRF.SECTIONCODERF, STOCKRF.WAREHOUSECODERF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF, STOCKRF.STOCKUNITPRICEFLRF, STOCKRF.SUPPLIERSTOCKRF, STOCKRF.ACPODRCOUNTRF, STOCKRF.MONTHORDERCOUNTRF, STOCKRF.SALESORDERCOUNTRF, STOCKRF.STOCKDIVRF, STOCKRF.MOVINGSUPLISTOCKRF, STOCKRF.SHIPMENTPOSCNTRF, STOCKRF.STOCKTOTALPRICERF, STOCKRF.LASTSTOCKDATERF, STOCKRF.LASTSALESDATERF, STOCKRF.LASTINVENTORYUPDATERF, STOCKRF.MINIMUMSTOCKCNTRF, STOCKRF.MAXIMUMSTOCKCNTRF, STOCKRF.NMLSALODRCOUNTRF, STOCKRF.SALESORDERUNITRF, STOCKRF.STOCKSUPPLIERCODERF, STOCKRF.GOODSNONONEHYPHENRF, STOCKRF.WAREHOUSESHELFNORF, STOCKRF.DUPLICATIONSHELFNO1RF, STOCKRF.DUPLICATIONSHELFNO2RF, STOCKRF.PARTSMANAGEMENTDIVIDE1RF, STOCKRF.PARTSMANAGEMENTDIVIDE2RF, STOCKRF.STOCKNOTE1RF, STOCKRF.STOCKNOTE2RF, STOCKRF.SHIPMENTCNTRF, STOCKRF.ARRIVALCNTRF, STOCKRF.STOCKCREATEDATERF, STOCKRF.UPDATEDATERF ";
                //sqlStr += " FROM STOCKRF LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF LEFT JOIN BLGOODSCDURF ON GOODSMNGRF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF AND GOODSMNGRF.BLGOODSCODERF= BLGOODSCDURF.BLGOODSCODERF ";
                //sqlStr += " WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr += " AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    //-----DEL 2011.08.20途中納品チェックエラー----->>>>>
                //    //sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    //sqlStr += " AND BLGOODSCDURF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    //-----DEL 2011.08.20途中納品チェックエラー-----<<<<<
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr += " AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    //-----DEL 2011.08.20途中納品チェックエラー----->>>>>
                //    //sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    //sqlStr += " AND BLGOODSCDURF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    //-----DEL 2011.08.20途中納品チェックエラー-----<<<<<
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF";
                //    SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                //    warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF";
                //    SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                //    warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF";
                //    SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                //    warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF";
                //    SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                //    warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
                //}

                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}

                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF";
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr += " AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr += " AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (param.BLGloupCodeBeginRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF";
                //    SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                //    bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
                //}

                //if (param.BLGloupCodeEndRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF";
                //    SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                //    bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF";
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr += " AND STOCKRF.GOODSNORF <= @GOODSNOENDRF";
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}

                ////Order By Key
                //sqlStr += " ORDER BY STOCKRF.UPDATEDATETIMERF DESC";
                //DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない---------------------------------------------------<<<<<
                #endregion
                //ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない--------------------------------------------------->>>>>
                //sqlStr.Append("SELECT STOCKRF.CREATEDATETIMERF, STOCKRF.UPDATEDATETIMERF, STOCKRF.ENTERPRISECODERF, STOCKRF.FILEHEADERGUIDRF, STOCKRF.UPDEMPLOYEECODERF, STOCKRF.UPDASSEMBLYID1RF, STOCKRF.UPDASSEMBLYID2RF, STOCKRF.LOGICALDELETECODERF, STOCKRF.SECTIONCODERF, STOCKRF.WAREHOUSECODERF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF, STOCKRF.STOCKUNITPRICEFLRF, STOCKRF.SUPPLIERSTOCKRF, STOCKRF.ACPODRCOUNTRF, STOCKRF.MONTHORDERCOUNTRF, STOCKRF.SALESORDERCOUNTRF, STOCKRF.STOCKDIVRF, STOCKRF.MOVINGSUPLISTOCKRF, STOCKRF.SHIPMENTPOSCNTRF, STOCKRF.STOCKTOTALPRICERF, STOCKRF.LASTSTOCKDATERF, STOCKRF.LASTSALESDATERF, STOCKRF.LASTINVENTORYUPDATERF, STOCKRF.MINIMUMSTOCKCNTRF, STOCKRF.MAXIMUMSTOCKCNTRF, STOCKRF.NMLSALODRCOUNTRF, STOCKRF.SALESORDERUNITRF, STOCKRF.STOCKSUPPLIERCODERF, STOCKRF.GOODSNONONEHYPHENRF, STOCKRF.WAREHOUSESHELFNORF, STOCKRF.DUPLICATIONSHELFNO1RF, STOCKRF.DUPLICATIONSHELFNO2RF, STOCKRF.PARTSMANAGEMENTDIVIDE1RF, STOCKRF.PARTSMANAGEMENTDIVIDE2RF, STOCKRF.STOCKNOTE1RF, STOCKRF.STOCKNOTE2RF, STOCKRF.SHIPMENTCNTRF, STOCKRF.ARRIVALCNTRF, STOCKRF.STOCKCREATEDATERF, STOCKRF.UPDATEDATERF ");//DEL 2011/09/02 #24364
                sqlStr.Append("SELECT DISTINCT STOCKRF.ENTERPRISECODERF+','+STOCKRF.WAREHOUSECODERF+','+STR(STOCKRF.GOODSMAKERCDRF)+','+STOCKRF.GOODSNORF AS STOCKPK, STOCKRF.CREATEDATETIMERF, STOCKRF.UPDATEDATETIMERF, STOCKRF.ENTERPRISECODERF, STOCKRF.FILEHEADERGUIDRF, STOCKRF.UPDEMPLOYEECODERF, STOCKRF.UPDASSEMBLYID1RF, STOCKRF.UPDASSEMBLYID2RF, STOCKRF.LOGICALDELETECODERF, STOCKRF.SECTIONCODERF, STOCKRF.WAREHOUSECODERF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF, STOCKRF.STOCKUNITPRICEFLRF, STOCKRF.SUPPLIERSTOCKRF, STOCKRF.ACPODRCOUNTRF, STOCKRF.MONTHORDERCOUNTRF, STOCKRF.SALESORDERCOUNTRF, STOCKRF.STOCKDIVRF, STOCKRF.MOVINGSUPLISTOCKRF, STOCKRF.SHIPMENTPOSCNTRF, STOCKRF.STOCKTOTALPRICERF, STOCKRF.LASTSTOCKDATERF, STOCKRF.LASTSALESDATERF, STOCKRF.LASTINVENTORYUPDATERF, STOCKRF.MINIMUMSTOCKCNTRF, STOCKRF.MAXIMUMSTOCKCNTRF, STOCKRF.NMLSALODRCOUNTRF, STOCKRF.SALESORDERUNITRF, STOCKRF.STOCKSUPPLIERCODERF, STOCKRF.GOODSNONONEHYPHENRF, STOCKRF.WAREHOUSESHELFNORF, STOCKRF.DUPLICATIONSHELFNO1RF, STOCKRF.DUPLICATIONSHELFNO2RF, STOCKRF.PARTSMANAGEMENTDIVIDE1RF, STOCKRF.PARTSMANAGEMENTDIVIDE2RF, STOCKRF.STOCKNOTE1RF, STOCKRF.STOCKNOTE2RF, STOCKRF.SHIPMENTCNTRF, STOCKRF.ARRIVALCNTRF, STOCKRF.STOCKCREATEDATERF, STOCKRF.UPDATEDATERF ");//ADD 2011/09/02 #24364
                sqlStr.Append(MakeQueryCondition(enterpriseCodes, param, ref sqlCommand)); //ADD 2011.09.06 #24364
                #region DEL 2011.09.06 #24364
                //sqlStr.Append(" FROM STOCKRF ");
                ////if (param.SupplierCdBeginRF != 0 || param.BLGloupCodeBeginRF != 0)//DEL 2011/09/02 #24364
                //if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)//ADD 2011/09/02 #24364
                //{
                //    //sqlStr.Append("LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF ");//DEL 2011/09/02 #24364
                //    sqlStr.Append(" LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND (STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF OR GOODSMNGRF.SECTIONCODERF=@FINDSECTIONCODE) AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND (STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF OR GOODSMNGRF.GOODSNORF = '' OR GOODSMNGRF.GOODSNORF IS NULL) ");//ADD 2011/09/02 #24364
                //}
                //if (param.BLGloupCodeBeginRF != 0 || param.BLGloupCodeEndRF != 0)
                //{
                //    //sqlStr.Append("LEFT JOIN BLGOODSCDURF ON GOODSMNGRF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF AND GOODSMNGRF.BLGOODSCODERF= BLGOODSCDURF.BLGOODSCODERF ");//DEL 2011/09/02 ②#24358
                //    sqlStr.Append(" LEFT JOIN GOODSURF ON STOCKRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND STOCKRF.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF AND STOCKRF.GOODSNORF=GOODSURF.GOODSNORF");//ADD 2011/09/02 ②#24358
                //    sqlStr.Append(" LEFT JOIN BLGOODSCDURF ON BLGOODSCDURF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND BLGOODSCDURF.BLGOODSCODERF= GOODSURF.BLGOODSCODERF ");//ADD 2011/09/02 ②#24358
                //}
                //sqlStr.Append(" WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF");
                //    SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                //    warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF");
                //    SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                //    warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF");
                //    SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                //    warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF");
                //    SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                //    warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
                //}
                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr.Append(" AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr.Append(" AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}
                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF");
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.GOODSNORF <= @GOODSNOENDRF");
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}

                ////if (param.SupplierCdBeginRF != 0 || param.BLGloupCodeBeginRF != 0)//DEL 2011/09/02 ②#24358
                //if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)//ADD 2011/09/02 ②#24358
                //{
                //    if (param.SupplierCdBeginRF != 0)
                //    {
                //        sqlStr.Append(" AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                //        SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //        supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //    }

                //    if (param.SupplierCdEndRF != 0)
                //    {
                //        sqlStr.Append(" AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                //        SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //        supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //    }
                //}

                //if (param.BLGloupCodeBeginRF != 0)
                //{
                //    sqlStr.Append(" AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF");
                //    SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                //    bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
                //}

                //if (param.BLGloupCodeEndRF != 0)
                //{
                //    sqlStr.Append(" AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF");
                //    SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                //    bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
                //}

                ////Order By Key
                //sqlStr.Append(" ORDER BY STOCKRF.UPDATEDATETIMERF DESC, STOCKRF.WAREHOUSECODERF, STOCKRF.GOODSMAKERCDRF, STOCKRF.GOODSNORF");
                ////ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない---------------------------------------------------<<<<<

                ////Prameterオブジェクトの作成
                //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);//ADD 2011/09/02 #24364

                ////Parameterオブジェクトへ値設定
                //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                //findParaSectionCode.Value = SqlDataMediator.SqlSetString("00");//ADD 2011/09/02 #24364
                #endregion DEL 2011.09.06 #24364
                //在庫マスタデータ用SQL
                //sqlCommand.CommandText = sqlStr;//DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
                sqlCommand.CommandText = sqlStr.ToString();//ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
                // 読み込み
                myReader = sqlCommand.ExecuteReader();
                //ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない---->>>>>
                if (myReader.HasRows)
                {
                    SetStockIndex(myReader);
                }
                //ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない-----<<<<<
                while (myReader.Read())
                {
                    #region DEL
                    //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
                    //stockWork = new APStockWork();

                    //stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    //stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    //stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    //stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    //stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    //stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    //stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    //stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    //stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    //stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    //stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    //stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    //stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    //stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    //stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    //stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
                    //stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    //stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
                    //stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    //stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    //stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                    //stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
                    //stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    //stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
                    //stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    //stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    //stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
                    //stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
                    //stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    //stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
                    //stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    //stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
                    //stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
                    //stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    //stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    //stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
                    //stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
                    //stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    //stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    //stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    //stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));

                    //stockArrList.Add(stockWork);
                    //-----DEL 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<
                    #endregion DEL
                    stockArrList.Add(CopyFromMyReaderToAPStockWork(myReader));//ADD 2011/08/20 途中納品チェック
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APStockDB.SearchStock Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        //-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)----->>>>>
        /// <summary>
        /// 在庫マスタデータを取得
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>在庫マスタデータ</returns>
        /// <br>Note       : 在庫マスタデータを戻します</br>
        /// <br>Programmer : 馮文雄</br>
        /// <br>Date       : 2011/08/20</br>
        private APStockWork CopyFromMyReaderToAPStockWork(SqlDataReader myReader)
        {
            APStockWork stockWork = new APStockWork();
            #region DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
            //stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            //stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            //stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            //stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            //stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            //stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            //stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            //stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            //stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            //stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            //stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            //stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            //stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
            //stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
            //stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
            //stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHORDERCOUNTRF"));
            //stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
            //stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKDIVRF"));
            //stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
            //stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
            //stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
            //stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATERF"));
            //stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
            //stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTINVENTORYUPDATERF"));
            //stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
            //stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
            //stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NMLSALODRCOUNTRF"));
            //stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERUNITRF"));
            //stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
            //stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNONONEHYPHENRF"));
            //stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            //stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO1RF"));
            //stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DUPLICATIONSHELFNO2RF"));
            //stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
            //stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
            //stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE1RF"));
            //stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKNOTE2RF"));
            //stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            //stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
            //stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
            //stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("UPDATEDATERF"));
            #endregion

            //ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない --------------------------->>>>>
            stockWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexCreateDateTime);
            stockWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, _indexUpdateDateTime);
            stockWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, _indexEnterpriseCode);
            stockWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, _indexFileHeaderGuid);
            stockWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, _indexUpdEmployeeCode);
            stockWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, _indexUpdAssemblyId1);
            stockWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, _indexUpdAssemblyId2);
            stockWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, _indexLogicalDeleteCode);
            stockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, _indexSectionCode);
            stockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, _indexWarehouseCode);
            stockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, _indexGoodsMakerCd);
            stockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, _indexGoodsNo);
            stockWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, _indexStockUnitPriceFl);
            stockWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, _indexSupplierStock);
            stockWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, _indexAcpOdrCount);
            stockWork.MonthOrderCount = SqlDataMediator.SqlGetDouble(myReader, _indexMonthOrderCount);
            stockWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, _indexSalesOrderCount);
            stockWork.StockDiv = SqlDataMediator.SqlGetInt32(myReader, _indexStockDiv);
            stockWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, _indexMovingSupliStock);
            stockWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, _indexShipmentPosCnt);
            stockWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, _indexStockTotalPrice);
            stockWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexLastStockDate);
            stockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexLastSalesDate);
            stockWork.LastInventoryUpdate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexLastInventoryUpdate);
            stockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, _indexMinimumStockCnt);
            stockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, _indexMaximumStockCnt);
            stockWork.NmlSalOdrCount = SqlDataMediator.SqlGetDouble(myReader, _indexNmlSalOdrCount);
            stockWork.SalesOrderUnit = SqlDataMediator.SqlGetInt32(myReader, _indexSalesOrderUnit);
            stockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, _indexStockSupplierCode);
            stockWork.GoodsNoNoneHyphen = SqlDataMediator.SqlGetString(myReader, _indexGoodsNoNoneHyphen);
            stockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, _indexWarehouseShelfNo);
            stockWork.DuplicationShelfNo1 = SqlDataMediator.SqlGetString(myReader, _indexDuplicationShelfNo1);
            stockWork.DuplicationShelfNo2 = SqlDataMediator.SqlGetString(myReader, _indexDuplicationShelfNo2);
            stockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, _indexPartsManagementDivide1);
            stockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, _indexPartsManagementDivide2);
            stockWork.StockNote1 = SqlDataMediator.SqlGetString(myReader, _indexStockNote1);
            stockWork.StockNote2 = SqlDataMediator.SqlGetString(myReader, _indexStockNote2);
            stockWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, _indexShipmentCnt);
            stockWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, _indexArrivalCnt);
            stockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexStockCreateDate);
            stockWork.UpdateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, _indexUpdateDate);
            //ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない ---------------------------<<<<<

            return stockWork;
        }
        //-----ADD 2011/08/20 途中納品チェック(myReaderからDクラスへ項目転記を行っている個所はメソッド化する)-----<<<<<

        /// <summary>
        /// カラムインデックス格納処理
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <remarks>
        /// <br>Note       : カラムインデックス格納処理を行う</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011/08/25</br>
        /// </remarks>
        private void SetStockIndex(SqlDataReader myReader)
        {
            _indexCreateDateTime = myReader.GetOrdinal("CREATEDATETIMERF");
            _indexUpdateDateTime = myReader.GetOrdinal("UPDATEDATETIMERF");
            _indexEnterpriseCode = myReader.GetOrdinal("ENTERPRISECODERF");
            _indexFileHeaderGuid = myReader.GetOrdinal("FILEHEADERGUIDRF");
            _indexUpdEmployeeCode = myReader.GetOrdinal("UPDEMPLOYEECODERF");
            _indexUpdAssemblyId1 = myReader.GetOrdinal("UPDASSEMBLYID1RF");
            _indexUpdAssemblyId2 = myReader.GetOrdinal("UPDASSEMBLYID2RF");
            _indexLogicalDeleteCode = myReader.GetOrdinal("LOGICALDELETECODERF");
            _indexSectionCode = myReader.GetOrdinal("SECTIONCODERF");
            _indexWarehouseCode = myReader.GetOrdinal("WAREHOUSECODERF");
            _indexGoodsMakerCd = myReader.GetOrdinal("GOODSMAKERCDRF");
            _indexGoodsNo = myReader.GetOrdinal("GOODSNORF");
            _indexStockUnitPriceFl = myReader.GetOrdinal("STOCKUNITPRICEFLRF");
            _indexSupplierStock = myReader.GetOrdinal("SUPPLIERSTOCKRF");
            _indexAcpOdrCount = myReader.GetOrdinal("ACPODRCOUNTRF");
            _indexMonthOrderCount = myReader.GetOrdinal("MONTHORDERCOUNTRF");
            _indexSalesOrderCount = myReader.GetOrdinal("SALESORDERCOUNTRF");
            _indexStockDiv = myReader.GetOrdinal("STOCKDIVRF");
            _indexMovingSupliStock = myReader.GetOrdinal("MOVINGSUPLISTOCKRF");
            _indexShipmentPosCnt = myReader.GetOrdinal("SHIPMENTPOSCNTRF");
            _indexStockTotalPrice = myReader.GetOrdinal("STOCKTOTALPRICERF");
            _indexLastStockDate = myReader.GetOrdinal("LASTSTOCKDATERF");
            _indexLastSalesDate = myReader.GetOrdinal("LASTSALESDATERF");
            _indexLastInventoryUpdate = myReader.GetOrdinal("LASTINVENTORYUPDATERF");
            _indexMinimumStockCnt = myReader.GetOrdinal("MINIMUMSTOCKCNTRF");
            _indexMaximumStockCnt = myReader.GetOrdinal("MAXIMUMSTOCKCNTRF");
            _indexNmlSalOdrCount = myReader.GetOrdinal("NMLSALODRCOUNTRF");
            _indexSalesOrderUnit = myReader.GetOrdinal("SALESORDERUNITRF");
            _indexStockSupplierCode = myReader.GetOrdinal("STOCKSUPPLIERCODERF");
            _indexGoodsNoNoneHyphen = myReader.GetOrdinal("GOODSNONONEHYPHENRF");
            _indexWarehouseShelfNo = myReader.GetOrdinal("WAREHOUSESHELFNORF");
            _indexDuplicationShelfNo1 = myReader.GetOrdinal("DUPLICATIONSHELFNO1RF");
            _indexDuplicationShelfNo2 = myReader.GetOrdinal("DUPLICATIONSHELFNO2RF");
            _indexPartsManagementDivide1 = myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF");
            _indexPartsManagementDivide2 = myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF");
            _indexStockNote1 = myReader.GetOrdinal("STOCKNOTE1RF");
            _indexStockNote2 = myReader.GetOrdinal("STOCKNOTE2RF");
            _indexShipmentCnt = myReader.GetOrdinal("SHIPMENTCNTRF");
            _indexArrivalCnt = myReader.GetOrdinal("ARRIVALCNTRF");
            _indexStockCreateDate = myReader.GetOrdinal("STOCKCREATEDATERF");
            _indexUpdateDate = myReader.GetOrdinal("UPDATEDATERF");
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="paramList">検索条件</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="count">検索結果件数</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 検索結果件数を戻します</br>
        /// <br>Programmer : 孫東響</br>
        /// <br>Date       : 2011/07/26</br>
        public int SearchStockCount(string enterpriseCodes, object paramList, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out int count, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            count = 0; //ADD 2011.09.06 #24364
            retMessage = string.Empty;
            //string sqlStr = string.Empty;//DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
            StringBuilder sqlStr = new StringBuilder();//ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            APStockProcParamWork param = paramList as APStockProcParamWork;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                #region DEL SQL
                //DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない--------------------------------------------------->>>>>
                //sqlStr = "SELECT COUNT(STOCKRF.ENTERPRISECODERF)";
                //sqlStr += " FROM STOCKRF LEFT JOIN GOODSMNGRF ON STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF LEFT JOIN BLGOODSCDURF ON GOODSMNGRF.BLGOODSCODERFRF= BLGOODSCDURF.BLGOODSCODERFRF ";
                //sqlStr += " WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ";
                //sqlStr += " AND GOODSMNGRF.ENTERPRISECODERF=@FINDENTERPRISECODE ";
                //sqlStr += " AND BLGOODSCDURF.ENTERPRISECODERF=@FINDENTERPRISECODE ";

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr += " AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    sqlStr += " AND BLGOODSCDURF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF";
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr += " AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    sqlStr += " AND GOODSMNGRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    sqlStr += " AND BLGOODSCDURF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF";
                //    SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                //    warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF";
                //    SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                //    warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF";
                //    SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                //    warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
                //{
                //    sqlStr += " AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF";
                //    SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                //    warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
                //}

                //if (param.SupplierCdBeginRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF";
                //    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //}

                //if (param.SupplierCdEndRF != 0)
                //{
                //    sqlStr += " AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF";
                //    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //}

                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr += " AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF";
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr += " AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF";
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}

                //if (param.BLGloupCodeBeginRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF";
                //    SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                //    bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
                //}

                //if (param.BLGloupCodeEndRF != 0)
                //{
                //    sqlStr += " AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF";
                //    SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                //    bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr += " AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF";
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr += " AND STOCKRF.GOODSNORF <= @GOODSNOENDRF";
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}
                //DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない---------------------------------------------------<<<<<
                #endregion
                //ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない--------------------------------------------------->>>>>
                //sqlStr.Append("SELECT COUNT(STOCKRF.ENTERPRISECODERF) ");//DEL 2011/09/02 #24364
                sqlStr.Append("SELECT COUNT(DISTINCT STOCKRF.ENTERPRISECODERF+','+STOCKRF.WAREHOUSECODERF+','+STR(STOCKRF.GOODSMAKERCDRF)+','+STOCKRF.GOODSNORF )");//ADD 2011/09/02 #24364
                sqlStr.Append(MakeQueryCondition(enterpriseCodes, param, ref sqlCommand)); //ADD 2011.09.06 #24364
                #region DEL 2011.09.06 #24364
                //sqlStr.Append(" FROM STOCKRF ");
                ////if (param.SupplierCdBeginRF != 0 || param.BLGloupCodeBeginRF != 0)//DEL 2011/09/02 #24364
                //if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)//ADD 2011/09/02 #24364
                //{
                //    //sqlStr.Append("LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF ");//DEL 2011/09/02 #24364
                //    sqlStr.Append(" LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND (STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF OR GOODSMNGRF.SECTIONCODERF=@FINDSECTIONCODE) AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND (STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF OR GOODSMNGRF.GOODSNORF = '' OR GOODSMNGRF.GOODSNORF IS NULL) ");//ADD 2011/09/02 #24364
                //}
                //if (param.BLGloupCodeBeginRF != 0 || param.BLGloupCodeEndRF != 0)
                //{
                //    //sqlStr.Append("LEFT JOIN BLGOODSCDURF ON GOODSMNGRF.ENTERPRISECODERF=BLGOODSCDURF.ENTERPRISECODERF AND GOODSMNGRF.BLGOODSCODERF= BLGOODSCDURF.BLGOODSCODERF ");//DEL 2011/09/02 ②#24358
                //    sqlStr.Append(" LEFT JOIN GOODSURF ON STOCKRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND STOCKRF.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF AND STOCKRF.GOODSNORF=GOODSURF.GOODSNORF");//ADD 2011/09/02 ②#24358
                //    sqlStr.Append(" LEFT JOIN BLGOODSCDURF ON BLGOODSCDURF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND BLGOODSCDURF.BLGOODSCODERF= GOODSURF.BLGOODSCODERF ");//ADD 2011/09/02 ②#24358
                //}
                //sqlStr.Append(" WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");

                //if (param.UpdateDateTimeBegin != 0)
                //{
                //    sqlStr.Append(" AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                //    SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
                //}
                //if (param.UpdateDateTimeEnd != 0)
                //{
                //    sqlStr.Append(" AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                //    SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                //    findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
                //}
                //if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF");
                //    SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                //    warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF");
                //    SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                //    warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF");
                //    SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                //    warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF");
                //    SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                //    warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
                //}
                //if (param.GoodsMakerCdBeginRF != 0)
                //{
                //    sqlStr.Append(" AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                //    SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                //    goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
                //}

                //if (param.GoodsMakerCdEndRF != 0)
                //{
                //    sqlStr.Append(" AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                //    SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                //    goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
                //}
                //if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF");
                //    SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                //    goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
                //}

                //if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
                //{
                //    sqlStr.Append(" AND STOCKRF.GOODSNORF <= @GOODSNOENDRF");
                //    SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                //    goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
                //}

                ////if (param.SupplierCdBeginRF != 0 || param.BLGloupCodeBeginRF != 0)//DEL 2011/09/02 ②#24358
                //if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)//ADD 2011/09/02 ②#24358
                //{
                //    if (param.SupplierCdBeginRF != 0)
                //    {
                //        sqlStr.Append(" AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                //        SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                //        supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                //    }

                //    if (param.SupplierCdEndRF != 0)
                //    {
                //        sqlStr.Append(" AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                //        SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                //        supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                //    }
                //}

                //if (param.BLGloupCodeBeginRF != 0)
                //{
                //    sqlStr.Append(" AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF");
                //    SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                //    bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
                //}

                //if (param.BLGloupCodeEndRF != 0)
                //{
                //    sqlStr.Append(" AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF");
                //    SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                //    bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
                //}
                ////ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない---------------------------------------------------<<<<<

                ////Prameterオブジェクトの作成
                //SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                //SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);//ADD 2011/09/02 #24364

                ////Parameterオブジェクトへ値設定
                //findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                //findParaSectionCode.Value = SqlDataMediator.SqlSetString("00");//ADD 2011/09/02 #24364
                #endregion DEL 2011.09.06 #24364
                //在庫マスタデータ用SQL
                //sqlCommand.CommandText = sqlStr;//DEL 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
                sqlCommand.CommandText = sqlStr.ToString();//ADD 2011/08/25 #23798条件送信で更新ボタン押下で処理が終了しない
                // 読み込み
                count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APStockDB.SearchStock Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

        /// <summary>
        /// 検索条件SQL作成
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="param">検索条件</param>
        /// <param name="sqlCommand">SqlCommand</param>
        /// <returns>検索条件SQL</returns>
        private string MakeQueryCondition(string enterpriseCodes, APStockProcParamWork param, ref SqlCommand sqlCommand)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" FROM STOCKRF ");
            if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)
            {
                sb.Append(" LEFT JOIN GOODSMNGRF ON STOCKRF.ENTERPRISECODERF=GOODSMNGRF.ENTERPRISECODERF AND (STOCKRF.SECTIONCODERF=GOODSMNGRF.SECTIONCODERF OR GOODSMNGRF.SECTIONCODERF=@FINDSECTIONCODE) AND STOCKRF.GOODSMAKERCDRF=GOODSMNGRF.GOODSMAKERCDRF  AND (STOCKRF.GOODSNORF=GOODSMNGRF.GOODSNORF OR GOODSMNGRF.GOODSNORF = '' OR GOODSMNGRF.GOODSNORF IS NULL) ");//ADD 2011/09/02 #24364
            }
            if (param.BLGloupCodeBeginRF != 0 || param.BLGloupCodeEndRF != 0)
            {
                sb.Append(" LEFT JOIN GOODSURF ON STOCKRF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND STOCKRF.GOODSMAKERCDRF=GOODSURF.GOODSMAKERCDRF AND STOCKRF.GOODSNORF=GOODSURF.GOODSNORF");//ADD 2011/09/02 ②#24358
                sb.Append(" LEFT JOIN BLGOODSCDURF ON BLGOODSCDURF.ENTERPRISECODERF=GOODSURF.ENTERPRISECODERF AND BLGOODSCDURF.BLGOODSCODERF= GOODSURF.BLGOODSCODERF ");//ADD 2011/09/02 ②#24358
            }
            sb.Append(" WHERE STOCKRF.ENTERPRISECODERF=@FINDENTERPRISECODE ");

            if (param.UpdateDateTimeBegin != 0)
            {
                sb.Append(" AND STOCKRF.UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF");
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeBegin);
            }
            if (param.UpdateDateTimeEnd != 0)
            {
                sb.Append(" AND STOCKRF.UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF");
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(param.UpdateDateTimeEnd);
            }
            if (!string.IsNullOrEmpty(param.WarehouseCodeBeginRF))
            {
                sb.Append(" AND STOCKRF.WAREHOUSECODERF >= @WAREHOUSECODEBEGINRF");
                SqlParameter warehouseCodeBeginRF = sqlCommand.Parameters.Add("@WAREHOUSECODEBEGINRF", SqlDbType.NChar);
                warehouseCodeBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeBeginRF);
            }

            if (!string.IsNullOrEmpty(param.WarehouseCodeEndRF))
            {
                sb.Append(" AND STOCKRF.WAREHOUSECODERF <= @WAREHOUSECODEENDRF");
                SqlParameter warehouseCodeEndRF = sqlCommand.Parameters.Add("@WAREHOUSECODEENDRF", SqlDbType.NChar);
                warehouseCodeEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseCodeEndRF);
            }

            if (!string.IsNullOrEmpty(param.WarehouseShelfNoBeginRF))
            {
                sb.Append(" AND STOCKRF.WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOBEGINRF");
                SqlParameter warehouseShelfNoBeginRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOBEGINRF", SqlDbType.NVarChar);
                warehouseShelfNoBeginRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoBeginRF);
            }

            if (!string.IsNullOrEmpty(param.WarehouseShelfNoEndRF))
            {
                sb.Append(" AND STOCKRF.WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOENDRF");
                SqlParameter warehouseShelfNoEndRF = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOENDRF", SqlDbType.NVarChar);
                warehouseShelfNoEndRF.Value = SqlDataMediator.SqlSetString(param.WarehouseShelfNoEndRF);
            }
            if (param.GoodsMakerCdBeginRF != 0)
            {
                sb.Append(" AND STOCKRF.GOODSMAKERCDRF >= @GOODSMAKERCDBEGINRF");
                SqlParameter goodsMakerCdBeginRF = sqlCommand.Parameters.Add("@GOODSMAKERCDBEGINRF", SqlDbType.Int);
                goodsMakerCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdBeginRF);
            }

            if (param.GoodsMakerCdEndRF != 0)
            {
                sb.Append(" AND STOCKRF.GOODSMAKERCDRF <= @GOODSMAKERCDENDRF");
                SqlParameter goodsMakerCdEndRF = sqlCommand.Parameters.Add("@GOODSMAKERCDENDRF", SqlDbType.Int);
                goodsMakerCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.GoodsMakerCdEndRF);
            }
            if (!string.IsNullOrEmpty(param.GoodsNoBeginRF))
            {
                sb.Append(" AND STOCKRF.GOODSNORF >= @GOODSNOBEGINRF");
                SqlParameter goodsNoBeginRF = sqlCommand.Parameters.Add("@GOODSNOBEGINRF", SqlDbType.NVarChar);
                goodsNoBeginRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoBeginRF);
            }

            if (!string.IsNullOrEmpty(param.GoodsNoEndRF))
            {
                sb.Append(" AND STOCKRF.GOODSNORF <= @GOODSNOENDRF");
                SqlParameter goodsNoEndRF = sqlCommand.Parameters.Add("@GOODSNOENDRF", SqlDbType.NVarChar);
                goodsNoEndRF.Value = SqlDataMediator.SqlSetString(param.GoodsNoEndRF);
            }

            if (param.SupplierCdBeginRF != 0 || param.SupplierCdEndRF != 0)
            {
                if (param.SupplierCdBeginRF != 0)
                {
                    sb.Append(" AND GOODSMNGRF.SUPPLIERCDRF >= @SUPPLIERCDBEGINRF");
                    SqlParameter supplierCdBeginRF = sqlCommand.Parameters.Add("@SUPPLIERCDBEGINRF", SqlDbType.Int);
                    supplierCdBeginRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdBeginRF);
                }

                if (param.SupplierCdEndRF != 0)
                {
                    sb.Append(" AND GOODSMNGRF.SUPPLIERCDRF <= @SUPPLIERCDENDRF");
                    SqlParameter supplierCdEndRF = sqlCommand.Parameters.Add("@SUPPLIERCDENDRF", SqlDbType.Int);
                    supplierCdEndRF.Value = SqlDataMediator.SqlSetInt32(param.SupplierCdEndRF);
                }
            }

            if (param.BLGloupCodeBeginRF != 0)
            {
                sb.Append(" AND BLGOODSCDURF.BLGROUPCODERF >= @BLGLOUPCODEBEGINRF");
                SqlParameter bLGloupCodeBeginRF = sqlCommand.Parameters.Add("@BLGLOUPCODEBEGINRF", SqlDbType.Int);
                bLGloupCodeBeginRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeBeginRF);
            }

            if (param.BLGloupCodeEndRF != 0)
            {
                sb.Append(" AND BLGOODSCDURF.BLGROUPCODERF <= @BLGLOUPCODEENDRF");
                SqlParameter bLGloupCodeEndRF = sqlCommand.Parameters.Add("@BLGLOUPCODEENDRF", SqlDbType.Int);
                bLGloupCodeEndRF.Value = SqlDataMediator.SqlSetInt32(param.BLGloupCodeEndRF);
            }

            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);

            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
            findParaSectionCode.Value = SqlDataMediator.SqlSetString("00");

            return sb.ToString();
        }

        #endregion
        #endregion 2011/07/26 孫東響 SCM対応-拠点管理（10704767-00）

    }
}


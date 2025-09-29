//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/28  修正内容 : SCM対応‐拠点管理（10704767-00）
//                                : 在庫受払履歴データの削除
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫受払履歴データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.04.28</br>
    /// </remarks>
    public class APStockAcPayHistDB : RemoteDB
    {
        /// <summary>
        /// 在庫受払履歴データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.28</br>
        /// </remarks>
        public APStockAcPayHistDB()
        {
        }

        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）---------->>>>>>>
        /*　
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫受払履歴データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockAcPayHistArrList">在庫受払履歴データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データREADLISTを全て戻します</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.06.11</br>
        /// 
        public int SearchStockAcPayHist(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAcPayHistArrList, out string retMessage)
        {
            return SearchStockAcPayHistProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockAcPayHistArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫受払履歴データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockAcPayHistArrList">在庫受払履歴データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 在庫受払履歴データREADLISTを全て戻します</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.04.28</br>
        /// 
        private int SearchStockAcPayHistProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockAcPayHistArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockAcPayHistArrList = new ArrayList();
            APStockAcPayHistWork stockAcPayHistWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, IOGOODSDAYRF, ADDUPADATERF, ACPAYSLIPCDRF, ACPAYSLIPNUMRF, ACPAYSLIPROWNORF, ACPAYHISTDATETIMERF, ACPAYTRANSCDRF, INPUTSECTIONCDRF, INPUTSECTIONGUIDNMRF, INPUTAGENCDRF, INPUTAGENNMRF, MOVESTATUSRF, CUSTSLIPNORF, SLIPDTLNUMRF, ACPAYNOTERF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, SECTIONCODERF, SECTIONGUIDENMRF, WAREHOUSECODERF, WAREHOUSENAMERF, SHELFNORF, BFSECTIONCODERF, BFSECTIONGUIDENMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, BFSHELFNORF, AFSECTIONCODERF, AFSECTIONGUIDENMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, AFSHELFNORF, CUSTOMERCODERF, CUSTOMERSNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, ARRIVALCNTRF, SHIPMENTCNTRF, OPENPRICEDIVRF, LISTPRICETAXEXCFLRF, STOCKUNITPRICEFLRF, STOCKPRICERF, SALESUNPRCTAXEXCFLRF, SALESMONEYRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, SALESORDERCOUNTRF, MOVINGSUPLISTOCKRF, NONADDUPSHIPMCNTRF, NONADDUPARRGDSCNTRF, SHIPMENTPOSCNTRF, PRESENTSTOCKCNTRF FROM STOCKACPAYHISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 在庫受払履歴データ用SQL
                sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockAcPayHistWork = new APStockAcPayHistWork();
                    stockAcPayHistWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockAcPayHistWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockAcPayHistWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockAcPayHistWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockAcPayHistWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockAcPayHistWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockAcPayHistWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockAcPayHistWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockAcPayHistWork.IoGoodsDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("IOGOODSDAYRF"));
                    stockAcPayHistWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                    stockAcPayHistWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
                    stockAcPayHistWork.AcPaySlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYSLIPNUMRF"));
                    stockAcPayHistWork.AcPaySlipRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPROWNORF"));
                    stockAcPayHistWork.AcPayHistDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPAYHISTDATETIMERF"));
                    stockAcPayHistWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
                    stockAcPayHistWork.InputSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONCDRF"));
                    stockAcPayHistWork.InputSectionGuidNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTSECTIONGUIDNMRF"));
                    stockAcPayHistWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                    stockAcPayHistWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                    stockAcPayHistWork.MoveStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MOVESTATUSRF"));
                    stockAcPayHistWork.CustSlipNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
                    stockAcPayHistWork.SlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPDTLNUMRF"));
                    stockAcPayHistWork.AcPayNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYNOTERF"));
                    stockAcPayHistWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockAcPayHistWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockAcPayHistWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockAcPayHistWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockAcPayHistWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockAcPayHistWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockAcPayHistWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockAcPayHistWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    stockAcPayHistWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockAcPayHistWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockAcPayHistWork.ShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SHELFNORF"));
                    stockAcPayHistWork.BfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONCODERF"));
                    stockAcPayHistWork.BfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDENMRF"));
                    stockAcPayHistWork.BfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                    stockAcPayHistWork.BfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                    stockAcPayHistWork.BfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
                    stockAcPayHistWork.AfSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONCODERF"));
                    stockAcPayHistWork.AfSectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDENMRF"));
                    stockAcPayHistWork.AfEnterWarehCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                    stockAcPayHistWork.AfEnterWarehName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                    stockAcPayHistWork.AfShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
                    stockAcPayHistWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                    stockAcPayHistWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                    stockAcPayHistWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockAcPayHistWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockAcPayHistWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                    stockAcPayHistWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    stockAcPayHistWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    stockAcPayHistWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockAcPayHistWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockAcPayHistWork.StockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICERF"));
                    stockAcPayHistWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                    stockAcPayHistWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYRF"));
                    stockAcPayHistWork.SupplierStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERSTOCKRF"));
                    stockAcPayHistWork.AcpOdrCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPODRCOUNTRF"));
                    stockAcPayHistWork.SalesOrderCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESORDERCOUNTRF"));
                    stockAcPayHistWork.MovingSupliStock = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVINGSUPLISTOCKRF"));
                    stockAcPayHistWork.NonAddUpShipmCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPSHIPMCNTRF"));
                    stockAcPayHistWork.NonAddUpArrGdsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NONADDUPARRGDSCNTRF"));
                    stockAcPayHistWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    stockAcPayHistWork.PresentStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PRESENTSTOCKCNTRF"));

                    stockAcPayHistArrList.Add(stockAcPayHistWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "APStockAcPayHistDB.SearchStockAcPayHist Exception=" + ex.Message);
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
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫受払履歴データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAcPayHistList">在庫受払履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateStockAcPayHist(string enterPriseCode, ArrayList stockAcPayHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockAcPayHistProc(enterPriseCode, stockAcPayHistList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫受払履歴データ更新
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAcPayHistList">在庫受払履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateStockAcPayHistProc(string enterPriseCode, ArrayList stockAcPayHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteStockAcPayHist(enterPriseCode, stockAcPayHistList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertStockAcPayHist(enterPriseCode, stockAcPayHistList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫受払履歴データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAcPayHistList">在庫受払履歴</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteStockAcPayHist(string enterPriseCode, ArrayList stockAcPayHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockAcPayHistProc(enterPriseCode, stockAcPayHistList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫受払履歴データ削除
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAcPayHistList">在庫受払履歴</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteStockAcPayHistProc(string enterPriseCode, ArrayList stockAcPayHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAcPayHistWork stockAcPayHistWork in stockAcPayHistList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "DELETE FROM STOCKACPAYHISTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ACPAYSLIPCDRF=@FINDACPAYSLIPCD AND ACPAYSLIPNUMRF=@FINDACPAYSLIPNUM AND ACPAYSLIPROWNORF=@FINDACPAYSLIPROWNO AND ACPAYHISTDATETIMERF=@FINDACPAYHISTDATETIME AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND WAREHOUSECODERF=@FINDWAREHOUSECODE";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaAcPaySlipCd = sqlCommand.Parameters.Add("@FINDACPAYSLIPCD", SqlDbType.Int);
                SqlParameter findParaAcPaySlipNum = sqlCommand.Parameters.Add("@FINDACPAYSLIPNUM", SqlDbType.NVarChar);
                SqlParameter findParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNO", SqlDbType.Int);
                SqlParameter findParaAcPayHistDateTime = sqlCommand.Parameters.Add("@FINDACPAYHISTDATETIME", SqlDbType.BigInt);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaAcPaySlipCd.Value = stockAcPayHistWork.AcPaySlipCd;
                findParaAcPaySlipNum.Value = stockAcPayHistWork.AcPaySlipNum;
                findParaAcPaySlipRowNo.Value = stockAcPayHistWork.AcPaySlipRowNo;
                findParaAcPayHistDateTime.Value = stockAcPayHistWork.AcPayHistDateTime;
                findParaGoodsMakerCd.Value = stockAcPayHistWork.GoodsMakerCd;
                findParaGoodsNo.Value = stockAcPayHistWork.GoodsNo;
                findParaWarehouseCode.Value = stockAcPayHistWork.WarehouseCode;

                sqlCommand.CommandText = sqlText;

                // 実行
                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 在庫受払履歴データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAcPayHistList">在庫受払履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertStockAcPayHist(string enterPriseCode, ArrayList stockAcPayHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockAcPayHistProc(enterPriseCode, stockAcPayHistList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 在庫受払履歴データ新規
        /// </summary>
        /// <param name="enterPriseCode">拠点コード</param>
        /// <param name="stockAcPayHistList">在庫受払履歴データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertStockAcPayHistProc(string enterPriseCode, ArrayList stockAcPayHistList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockAcPayHistWork stockAcPayHistWork in stockAcPayHistList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKACPAYHISTRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, IOGOODSDAYRF, ADDUPADATERF, ACPAYSLIPCDRF, ACPAYSLIPNUMRF, ACPAYSLIPROWNORF, ACPAYHISTDATETIMERF, ACPAYTRANSCDRF, INPUTSECTIONCDRF, INPUTSECTIONGUIDNMRF, INPUTAGENCDRF, INPUTAGENNMRF, MOVESTATUSRF, CUSTSLIPNORF, SLIPDTLNUMRF, ACPAYNOTERF, GOODSMAKERCDRF, MAKERNAMERF, GOODSNORF, GOODSNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, SECTIONCODERF, SECTIONGUIDENMRF, WAREHOUSECODERF, WAREHOUSENAMERF, SHELFNORF, BFSECTIONCODERF, BFSECTIONGUIDENMRF, BFENTERWAREHCODERF, BFENTERWAREHNAMERF, BFSHELFNORF, AFSECTIONCODERF, AFSECTIONGUIDENMRF, AFENTERWAREHCODERF, AFENTERWAREHNAMERF, AFSHELFNORF, CUSTOMERCODERF, CUSTOMERSNMRF, SUPPLIERCDRF, SUPPLIERSNMRF, ARRIVALCNTRF, SHIPMENTCNTRF, OPENPRICEDIVRF, LISTPRICETAXEXCFLRF, STOCKUNITPRICEFLRF, STOCKPRICERF, SALESUNPRCTAXEXCFLRF, SALESMONEYRF, SUPPLIERSTOCKRF, ACPODRCOUNTRF, SALESORDERCOUNTRF, MOVINGSUPLISTOCKRF, NONADDUPSHIPMCNTRF, NONADDUPARRGDSCNTRF, SHIPMENTPOSCNTRF, PRESENTSTOCKCNTRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @IOGOODSDAY, @ADDUPADATE, @ACPAYSLIPCD, @ACPAYSLIPNUM, @ACPAYSLIPROWNO, @ACPAYHISTDATETIME, @ACPAYTRANSCD, @INPUTSECTIONCD, @INPUTSECTIONGUIDNM, @INPUTAGENCD, @INPUTAGENNM, @MOVESTATUS, @CUSTSLIPNO, @SLIPDTLNUM, @ACPAYNOTE, @GOODSMAKERCD, @MAKERNAME, @GOODSNO, @GOODSNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @SECTIONCODE, @SECTIONGUIDENM, @WAREHOUSECODE, @WAREHOUSENAME, @SHELFNO, @BFSECTIONCODE, @BFSECTIONGUIDENM, @BFENTERWAREHCODE, @BFENTERWAREHNAME, @BFSHELFNO, @AFSECTIONCODE, @AFSECTIONGUIDENM, @AFENTERWAREHCODE, @AFENTERWAREHNAME, @AFSHELFNO, @CUSTOMERCODE, @CUSTOMERSNM, @SUPPLIERCD, @SUPPLIERSNM, @ARRIVALCNT, @SHIPMENTCNT, @OPENPRICEDIV, @LISTPRICETAXEXCFL, @STOCKUNITPRICEFL, @STOCKPRICE, @SALESUNPRCTAXEXCFL, @SALESMONEY, @SUPPLIERSTOCK, @ACPODRCOUNT, @SALESORDERCOUNT, @MOVINGSUPLISTOCK, @NONADDUPSHIPMCNT, @NONADDUPARRGDSCNT, @SHIPMENTPOSCNT, @PRESENTSTOCKCNT)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraIoGoodsDay = sqlCommand.Parameters.Add("@IOGOODSDAY", SqlDbType.Int);
                SqlParameter paraAddUpADate = sqlCommand.Parameters.Add("@ADDUPADATE", SqlDbType.Int);
                SqlParameter paraAcPaySlipCd = sqlCommand.Parameters.Add("@ACPAYSLIPCD", SqlDbType.Int);
                SqlParameter paraAcPaySlipNum = sqlCommand.Parameters.Add("@ACPAYSLIPNUM", SqlDbType.NVarChar);
                SqlParameter paraAcPaySlipRowNo = sqlCommand.Parameters.Add("@ACPAYSLIPROWNO", SqlDbType.Int);
                SqlParameter paraAcPayHistDateTime = sqlCommand.Parameters.Add("@ACPAYHISTDATETIME", SqlDbType.BigInt);
                SqlParameter paraAcPayTransCd = sqlCommand.Parameters.Add("@ACPAYTRANSCD", SqlDbType.Int);
                SqlParameter paraInputSectionCd = sqlCommand.Parameters.Add("@INPUTSECTIONCD", SqlDbType.NChar);
                SqlParameter paraInputSectionGuidNm = sqlCommand.Parameters.Add("@INPUTSECTIONGUIDNM", SqlDbType.NVarChar);
                SqlParameter paraInputAgenCd = sqlCommand.Parameters.Add("@INPUTAGENCD", SqlDbType.NVarChar);
                SqlParameter paraInputAgenNm = sqlCommand.Parameters.Add("@INPUTAGENNM", SqlDbType.NVarChar);
                SqlParameter paraMoveStatus = sqlCommand.Parameters.Add("@MOVESTATUS", SqlDbType.Int);
                SqlParameter paraCustSlipNo = sqlCommand.Parameters.Add("@CUSTSLIPNO", SqlDbType.NVarChar);
                SqlParameter paraSlipDtlNum = sqlCommand.Parameters.Add("@SLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter paraAcPayNote = sqlCommand.Parameters.Add("@ACPAYNOTE", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraSectionGuideNm = sqlCommand.Parameters.Add("@SECTIONGUIDENM", SqlDbType.NVarChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                SqlParameter paraShelfNo = sqlCommand.Parameters.Add("@SHELFNO", SqlDbType.NVarChar);
                SqlParameter paraBfSectionCode = sqlCommand.Parameters.Add("@BFSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraBfSectionGuideNm = sqlCommand.Parameters.Add("@BFSECTIONGUIDENM", SqlDbType.NChar);
                SqlParameter paraBfEnterWarehCode = sqlCommand.Parameters.Add("@BFENTERWAREHCODE", SqlDbType.NChar);
                SqlParameter paraBfEnterWarehName = sqlCommand.Parameters.Add("@BFENTERWAREHNAME", SqlDbType.NVarChar);
                SqlParameter paraBfShelfNo = sqlCommand.Parameters.Add("@BFSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraAfSectionCode = sqlCommand.Parameters.Add("@AFSECTIONCODE", SqlDbType.NChar);
                SqlParameter paraAfSectionGuideNm = sqlCommand.Parameters.Add("@AFSECTIONGUIDENM", SqlDbType.NChar);
                SqlParameter paraAfEnterWarehCode = sqlCommand.Parameters.Add("@AFENTERWAREHCODE", SqlDbType.NChar);
                SqlParameter paraAfEnterWarehName = sqlCommand.Parameters.Add("@AFENTERWAREHNAME", SqlDbType.NVarChar);
                SqlParameter paraAfShelfNo = sqlCommand.Parameters.Add("@AFSHELFNO", SqlDbType.NVarChar);
                SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraCustomerSnm = sqlCommand.Parameters.Add("@CUSTOMERSNM", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraStockPrice = sqlCommand.Parameters.Add("@STOCKPRICE", SqlDbType.BigInt);
                SqlParameter paraSalesUnPrcTaxExcFl = sqlCommand.Parameters.Add("@SALESUNPRCTAXEXCFL", SqlDbType.Float);
                SqlParameter paraSalesMoney = sqlCommand.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                SqlParameter paraSupplierStock = sqlCommand.Parameters.Add("@SUPPLIERSTOCK", SqlDbType.Float);
                SqlParameter paraAcpOdrCount = sqlCommand.Parameters.Add("@ACPODRCOUNT", SqlDbType.Float);
                SqlParameter paraSalesOrderCount = sqlCommand.Parameters.Add("@SALESORDERCOUNT", SqlDbType.Float);
                SqlParameter paraMovingSupliStock = sqlCommand.Parameters.Add("@MOVINGSUPLISTOCK", SqlDbType.Float);
                SqlParameter paraNonAddUpShipmCnt = sqlCommand.Parameters.Add("@NONADDUPSHIPMCNT", SqlDbType.Float);
                SqlParameter paraNonAddUpArrGdsCnt = sqlCommand.Parameters.Add("@NONADDUPARRGDSCNT", SqlDbType.Float);
                SqlParameter paraShipmentPosCnt = sqlCommand.Parameters.Add("@SHIPMENTPOSCNT", SqlDbType.Float);
                SqlParameter paraPresentStockCnt = sqlCommand.Parameters.Add("@PRESENTSTOCKCNT", SqlDbType.Float);


                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAcPayHistWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockAcPayHistWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockAcPayHistWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.LogicalDeleteCode);
                paraIoGoodsDay.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.IoGoodsDay);
                paraAddUpADate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockAcPayHistWork.AddUpADate);
                paraAcPaySlipCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.AcPaySlipCd);
                paraAcPaySlipNum.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AcPaySlipNum);
                paraAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.AcPaySlipRowNo);
                paraAcPayHistDateTime.Value = SqlDataMediator.SqlSetInt64(stockAcPayHistWork.AcPayHistDateTime);
                paraAcPayTransCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.AcPayTransCd);
                paraInputSectionCd.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.InputSectionCd);
                paraInputSectionGuidNm.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.InputSectionGuidNm);
                paraInputAgenCd.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.InputAgenCd);
                paraInputAgenNm.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.InputAgenNm);
                paraMoveStatus.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.MoveStatus);
                paraCustSlipNo.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.CustSlipNo);
                paraSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockAcPayHistWork.SlipDtlNum);
                paraAcPayNote.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AcPayNote);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.MakerName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.GoodsName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.BLGoodsFullName);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.SectionCode);
                paraSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.SectionGuideNm);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.WarehouseName);
                paraShelfNo.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.ShelfNo);
                paraBfSectionCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.BfSectionCode);
                paraBfSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.BfSectionGuideNm);
                paraBfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.BfEnterWarehCode);
                paraBfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.BfEnterWarehName);
                paraBfShelfNo.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.BfShelfNo);
                paraAfSectionCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AfSectionCode);
                paraAfSectionGuideNm.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AfSectionGuideNm);
                paraAfEnterWarehCode.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AfEnterWarehCode);
                paraAfEnterWarehName.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AfEnterWarehName);
                paraAfShelfNo.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.AfShelfNo);
                paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.CustomerCode);
                paraCustomerSnm.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.CustomerSnm);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.SupplierCd);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockAcPayHistWork.SupplierSnm);
                paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.ArrivalCnt);
                paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.ShipmentCnt);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockAcPayHistWork.OpenPriceDiv);
                paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.ListPriceTaxExcFl);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.StockUnitPriceFl);
                paraStockPrice.Value = SqlDataMediator.SqlSetInt64(stockAcPayHistWork.StockPrice);
                paraSalesUnPrcTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.SalesUnPrcTaxExcFl);
                paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(stockAcPayHistWork.SalesMoney);
                paraSupplierStock.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.SupplierStock);
                paraAcpOdrCount.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.AcpOdrCount);
                paraSalesOrderCount.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.SalesOrderCount);
                paraMovingSupliStock.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.MovingSupliStock);
                paraNonAddUpShipmCnt.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.NonAddUpShipmCnt);
                paraNonAddUpArrGdsCnt.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.NonAddUpArrGdsCnt);
                paraShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.ShipmentPosCnt);
                paraPresentStockCnt.Value = SqlDataMediator.SqlSetDouble(stockAcPayHistWork.PresentStockCnt);


                sqlCommand.CommandText = sqlText;

                sqlCommand.ExecuteNonQuery();
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

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

            return status;
        }

// DEL 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----------<<<<<<<
*/
        #endregion [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
    }
}
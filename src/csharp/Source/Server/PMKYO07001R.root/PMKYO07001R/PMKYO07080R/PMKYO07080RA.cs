//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 修 正 日  2009/06/11  修正内容 : Rクラスのpublic MethodでSQL文字が駄目
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/28  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/08  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/15  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
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
    /// 仕入明細データREADDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : データ送信処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    public class APStockDetailDB : RemoteDB
    {
        /// <summary>
        /// 仕入明細データREADDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : DBサーバーコネクション情報を取得します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public APStockDetailDB()
        {
        }
        #region [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]
// DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
/*

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入明細データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockDetailArrList">仕入明細データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入明細データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        public int SearchStockDetail(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockDetailArrList, out string retMessage)
        {
            return SearchStockDetailProc(enterpriseCodes, beginningDate, endingDate, sqlConnection,
             sqlTransaction, out  stockDetailArrList, out  retMessage);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入明細データの検索処理
        /// </summary>
        /// <param name="enterpriseCodes">企業コード</param>
        /// <param name="beginningDate">開始日付</param>
        /// <param name="endingDate">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="stockDetailArrList">仕入明細データオブジェクト</param>
        /// <param name="retMessage">戻るメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入明細データREADLISTを全て戻します</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// 
        private int SearchStockDetailProc(string enterpriseCodes, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
            SqlTransaction sqlTransaction, out ArrayList stockDetailArrList, out string retMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockDetailArrList = new ArrayList();
            APStockDetailWork stockDetailWork = null;
            retMessage = string.Empty;
            string sqlStr = string.Empty;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, SECTIONCODERF, SUBSECTIONCODERF, COMMONSEQNORF, STOCKSLIPDTLNUMRF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPTANODRSTATUSSYNCRF, SALESSLIPDTLNUMSYNCRF, STOCKSLIPCDDTLRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, CMPLTMAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, STOCKORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, SUPPRATEGRPCODERF, LISTPRICETAXEXCFLRF, LISTPRICETAXINCFLRF, STOCKRATERF, RATESECTSTCKUNPRCRF, RATEDIVSTCKUNPRCRF, UNPRCCALCCDSTCKUNPRCRF, PRICECDSTCKUNPRCRF, STDUNPRCSTCKUNPRCRF, FRACPROCUNITSTCUNPRCRF, FRACPROCSTCKUNPRCRF, STOCKUNITPRICEFLRF, STOCKUNITTAXPRICEFLRF, STOCKUNITCHNGDIVRF, BFSTOCKUNITPRICEFLRF, BFLISTPRICERF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, STOCKCOUNTRF, ORDERCNTRF, ORDERADJUSTCNTRF, ORDERREMAINCNTRF, REMAINCNTUPDDATERF, STOCKPRICETAXEXCRF, STOCKPRICETAXINCRF, STOCKGOODSCDRF, STOCKPRICECONSTAXRF, TAXATIONCODERF, STOCKDTISLIPNOTE1RF, SALESCUSTOMERCODERF, SALESCUSTOMERSNMRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, SUPPLIERCDRF, SUPPLIERSNMRF, ADDRESSEECODERF, ADDRESSEENAMERF, DIRECTSENDINGCDRF, ORDERNUMBERRF, WAYTOORDERRF, DELIGDSCMPLTDUEDATERF, EXPECTDELIVERYDATERF, ORDERDATACREATEDIVRF, ORDERDATACREATEDATERF, ORDERFORMISSUEDDIVRF FROM STOCKDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
                SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCodes);
                findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
                findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

                // 仕入明細データ用SQL
				sqlCommand.CommandText = sqlStr;
                // 読み込み
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockDetailWork = new APStockDetailWork();

                    stockDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    stockDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    stockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    stockDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    stockDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    stockDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    stockDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    stockDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    stockDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                    stockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                    stockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                    stockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                    stockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                    stockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                    stockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                    stockDetailWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
                    stockDetailWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
                    stockDetailWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
                    stockDetailWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
                    stockDetailWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                    stockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                    stockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                    stockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                    stockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                    stockDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                    stockDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                    stockDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
                    stockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                    stockDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    stockDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                    stockDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    stockDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                    stockDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    stockDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                    stockDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    stockDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                    stockDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    stockDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                    stockDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    stockDetailWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                    stockDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                    stockDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                    stockDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                    stockDetailWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
                    stockDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                    stockDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                    stockDetailWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                    stockDetailWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
                    stockDetailWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
                    stockDetailWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
                    stockDetailWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
                    stockDetailWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
                    stockDetailWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
                    stockDetailWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
                    stockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    stockDetailWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
                    stockDetailWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
                    stockDetailWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                    stockDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                    stockDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
                    stockDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
                    stockDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
                    stockDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
                    stockDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
                    stockDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
                    stockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                    stockDetailWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));
                    stockDetailWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));
                    stockDetailWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));
                    stockDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
                    stockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                    stockDetailWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
                    stockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                    stockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                    stockDetailWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                    stockDetailWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
                    stockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
                    stockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
                    stockDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                    stockDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                    stockDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                    stockDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                    stockDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                    stockDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                    stockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    stockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    stockDetailWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                    stockDetailWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                    stockDetailWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
                    stockDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                    stockDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
                    stockDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
                    stockDetailWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTDELIVERYDATERF"));
                    stockDetailWork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERDATACREATEDIVRF"));
                    stockDetailWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));
                    stockDetailWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERFORMISSUEDDIVRF"));


                    stockDetailArrList.Add(stockDetailWork);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
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
*/
        // DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/28 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入明細データ更新
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="stockDetailList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int UpdateStockDetail(string enterPriseCode, ArrayList stockDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return UpdateStockDetailProc(enterPriseCode, stockDetailList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入明細データ更新
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="stockDetailList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int UpdateStockDetailProc(string enterPriseCode, ArrayList stockDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 全てデータを削除する
            status = DeleteStockDetail(enterPriseCode, stockDetailList, ref sqlConnection, ref sqlTransaction);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 登録処理
                status = InsertStockDetail(enterPriseCode, stockDetailList, ref sqlConnection, ref sqlTransaction);
            }

            return status;
        }
        // ADD 2009/06/11 --->>>
        // Rクラスのpublic MethodでSQL文字が駄目
        /// <summary>
        /// 仕入明細データ削除
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="stockDetailList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int DeleteStockDetail(string enterPriseCode, ArrayList stockDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteStockDetailProc(enterPriseCode, stockDetailList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入明細データ削除
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="stockDetailList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int DeleteStockDetailProc(string enterPriseCode, ArrayList stockDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockDetailWork stockDetailWork in stockDetailList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                // modified by zhubj for 仕様変更 start on 20090429
                //sqlText = "DELETE FROM STOCKDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND STOCKSLIPDTLNUMRF=@FINDSTOCKSLIPDTLNUM";
                sqlText = "DELETE FROM STOCKDETAILRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SUPPLIERFORMALRF=@FINDSUPPLIERFORMAL AND SUPPLIERSLIPNORF=@FINDSUPPLIERSLIPNO";
                // modified by zhubj for 仕様変更 end on 20090429
								
                //Prameterオブジェクトの作成
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierFormal = sqlCommand.Parameters.Add("@FINDSUPPLIERFORMAL", SqlDbType.Int);
                // modified by zhubj for 仕様変更 start on 20090429
                //SqlParameter findParaStockSlipDtlNum = sqlCommand.Parameters.Add("@FINDSTOCKSLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter findParaSupplierSlipNo = sqlCommand.Parameters.Add("@FINDSUPPLIERSLIPNO", SqlDbType.Int);
                // modified by zhubj for 仕様変更 end on 20090429
                //Parameterオブジェクトへ値設定
                findParaEnterpriseCode.Value = enterPriseCode;
                findParaSupplierFormal.Value = stockDetailWork.SupplierFormal;
                // modified by zhubj for 仕様変更 start on 20090429
                //findParaStockSlipDtlNum.Value = stockDetailWork.StockSlipDtlNum;
                findParaSupplierSlipNo.Value = stockDetailWork.SupplierSlipNo;
                // modified by zhubj for 仕様変更 end on 20090429
				
                sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
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
        /// 仕入明細データ新規
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="stockDetailList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        public int InsertStockDetail(string enterPriseCode, ArrayList stockDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return InsertStockDetailProc(enterPriseCode, stockDetailList, ref  sqlConnection, ref  sqlTransaction);
        }
        // ADD 2009/06/11 ---<<<
        /// <summary>
        /// 仕入明細データ新規
        /// </summary>
        /// <param name="enterPriseCode">企業コード</param>
        /// <param name="stockDetailList">仕入明細データ</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <returns></returns>
        private int InsertStockDetailProc(string enterPriseCode, ArrayList stockDetailList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            foreach (APStockDetailWork stockDetailWork in stockDetailList)
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                sqlText = "INSERT INTO STOCKDETAILRF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, SECTIONCODERF, SUBSECTIONCODERF, COMMONSEQNORF, STOCKSLIPDTLNUMRF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPTANODRSTATUSSYNCRF, SALESSLIPDTLNUMSYNCRF, STOCKSLIPCDDTLRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, CMPLTMAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, STOCKORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, SUPPRATEGRPCODERF, LISTPRICETAXEXCFLRF, LISTPRICETAXINCFLRF, STOCKRATERF, RATESECTSTCKUNPRCRF, RATEDIVSTCKUNPRCRF, UNPRCCALCCDSTCKUNPRCRF, PRICECDSTCKUNPRCRF, STDUNPRCSTCKUNPRCRF, FRACPROCUNITSTCUNPRCRF, FRACPROCSTCKUNPRCRF, STOCKUNITPRICEFLRF, STOCKUNITTAXPRICEFLRF, STOCKUNITCHNGDIVRF, BFSTOCKUNITPRICEFLRF, BFLISTPRICERF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, STOCKCOUNTRF, ORDERCNTRF, ORDERADJUSTCNTRF, ORDERREMAINCNTRF, REMAINCNTUPDDATERF, STOCKPRICETAXEXCRF, STOCKPRICETAXINCRF, STOCKGOODSCDRF, STOCKPRICECONSTAXRF, TAXATIONCODERF, STOCKDTISLIPNOTE1RF, SALESCUSTOMERCODERF, SALESCUSTOMERSNMRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, SUPPLIERCDRF, SUPPLIERSNMRF, ADDRESSEECODERF, ADDRESSEENAMERF, DIRECTSENDINGCDRF, ORDERNUMBERRF, WAYTOORDERRF, DELIGDSCMPLTDUEDATERF, EXPECTDELIVERYDATERF, ORDERDATACREATEDIVRF, ORDERDATACREATEDATERF, ORDERFORMISSUEDDIVRF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @ACCEPTANORDERNO, @SUPPLIERFORMAL, @SUPPLIERSLIPNO, @STOCKROWNO, @SECTIONCODE, @SUBSECTIONCODE, @COMMONSEQNO, @STOCKSLIPDTLNUM, @SUPPLIERFORMALSRC, @STOCKSLIPDTLNUMSRC, @ACPTANODRSTATUSSYNC, @SALESSLIPDTLNUMSYNC, @STOCKSLIPCDDTL, @STOCKINPUTCODE, @STOCKINPUTNAME, @STOCKAGENTCODE, @STOCKAGENTNAME, @GOODSKINDCODE, @GOODSMAKERCD, @MAKERNAME, @MAKERKANANAME, @CMPLTMAKERKANANAME, @GOODSNO, @GOODSNAME, @GOODSNAMEKANA, @GOODSLGROUP, @GOODSLGROUPNAME, @GOODSMGROUP, @GOODSMGROUPNAME, @BLGROUPCODE, @BLGROUPNAME, @BLGOODSCODE, @BLGOODSFULLNAME, @ENTERPRISEGANRECODE, @ENTERPRISEGANRENAME, @WAREHOUSECODE, @WAREHOUSENAME, @WAREHOUSESHELFNO, @STOCKORDERDIVCD, @OPENPRICEDIV, @GOODSRATERANK, @CUSTRATEGRPCODE, @SUPPRATEGRPCODE, @LISTPRICETAXEXCFL, @LISTPRICETAXINCFL, @STOCKRATE, @RATESECTSTCKUNPRC, @RATEDIVSTCKUNPRC, @UNPRCCALCCDSTCKUNPRC, @PRICECDSTCKUNPRC, @STDUNPRCSTCKUNPRC, @FRACPROCUNITSTCUNPRC, @FRACPROCSTCKUNPRC, @STOCKUNITPRICEFL, @STOCKUNITTAXPRICEFL, @STOCKUNITCHNGDIV, @BFSTOCKUNITPRICEFL, @BFLISTPRICE, @RATEBLGOODSCODE, @RATEBLGOODSNAME, @RATEGOODSRATEGRPCD, @RATEGOODSRATEGRPNM, @RATEBLGROUPCODE, @RATEBLGROUPNAME, @STOCKCOUNT, @ORDERCNT, @ORDERADJUSTCNT, @ORDERREMAINCNT, @REMAINCNTUPDDATE, @STOCKPRICETAXEXC, @STOCKPRICETAXINC, @STOCKGOODSCD, @STOCKPRICECONSTAX, @TAXATIONCODE, @STOCKDTISLIPNOTE1, @SALESCUSTOMERCODE, @SALESCUSTOMERSNM, @SLIPMEMO1, @SLIPMEMO2, @SLIPMEMO3, @INSIDEMEMO1, @INSIDEMEMO2, @INSIDEMEMO3, @SUPPLIERCD, @SUPPLIERSNM, @ADDRESSEECODE, @ADDRESSEENAME, @DIRECTSENDINGCD, @ORDERNUMBER, @WAYTOORDER, @DELIGDSCMPLTDUEDATE, @EXPECTDELIVERYDATE, @ORDERDATACREATEDIV, @ORDERDATACREATEDATE, @ORDERFORMISSUEDDIV)";

                //Prameterオブジェクトの作成
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraAcceptAnOrderNo = sqlCommand.Parameters.Add("@ACCEPTANORDERNO", SqlDbType.Int);
                SqlParameter paraSupplierFormal = sqlCommand.Parameters.Add("@SUPPLIERFORMAL", SqlDbType.Int);
                SqlParameter paraSupplierSlipNo = sqlCommand.Parameters.Add("@SUPPLIERSLIPNO", SqlDbType.Int);
                SqlParameter paraStockRowNo = sqlCommand.Parameters.Add("@STOCKROWNO", SqlDbType.Int);
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                SqlParameter paraCommonSeqNo = sqlCommand.Parameters.Add("@COMMONSEQNO", SqlDbType.BigInt);
                SqlParameter paraStockSlipDtlNum = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUM", SqlDbType.BigInt);
                SqlParameter paraSupplierFormalSrc = sqlCommand.Parameters.Add("@SUPPLIERFORMALSRC", SqlDbType.Int);
                SqlParameter paraStockSlipDtlNumSrc = sqlCommand.Parameters.Add("@STOCKSLIPDTLNUMSRC", SqlDbType.BigInt);
                SqlParameter paraAcptAnOdrStatusSync = sqlCommand.Parameters.Add("@ACPTANODRSTATUSSYNC", SqlDbType.Int);
                SqlParameter paraSalesSlipDtlNumSync = sqlCommand.Parameters.Add("@SALESSLIPDTLNUMSYNC", SqlDbType.BigInt);
                SqlParameter paraStockSlipCdDtl = sqlCommand.Parameters.Add("@STOCKSLIPCDDTL", SqlDbType.Int);
                SqlParameter paraStockInputCode = sqlCommand.Parameters.Add("@STOCKINPUTCODE", SqlDbType.NChar);
                SqlParameter paraStockInputName = sqlCommand.Parameters.Add("@STOCKINPUTNAME", SqlDbType.NVarChar);
                SqlParameter paraStockAgentCode = sqlCommand.Parameters.Add("@STOCKAGENTCODE", SqlDbType.NChar);
                SqlParameter paraStockAgentName = sqlCommand.Parameters.Add("@STOCKAGENTNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsKindCode = sqlCommand.Parameters.Add("@GOODSKINDCODE", SqlDbType.Int);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                SqlParameter paraMakerKanaName = sqlCommand.Parameters.Add("@MAKERKANANAME", SqlDbType.NVarChar);
                SqlParameter paraCmpltMakerKanaName = sqlCommand.Parameters.Add("@CMPLTMAKERKANANAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsNameKana = sqlCommand.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                SqlParameter paraGoodsLGroup = sqlCommand.Parameters.Add("@GOODSLGROUP", SqlDbType.Int);
                SqlParameter paraGoodsLGroupName = sqlCommand.Parameters.Add("@GOODSLGROUPNAME", SqlDbType.NVarChar);
                SqlParameter paraGoodsMGroup = sqlCommand.Parameters.Add("@GOODSMGROUP", SqlDbType.Int);
                SqlParameter paraGoodsMGroupName = sqlCommand.Parameters.Add("@GOODSMGROUPNAME", SqlDbType.NVarChar);
                SqlParameter paraBLGroupCode = sqlCommand.Parameters.Add("@BLGROUPCODE", SqlDbType.Int);
                SqlParameter paraBLGroupName = sqlCommand.Parameters.Add("@BLGROUPNAME", SqlDbType.NVarChar);
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                SqlParameter paraBLGoodsFullName = sqlCommand.Parameters.Add("@BLGOODSFULLNAME", SqlDbType.NVarChar);
                SqlParameter paraEnterpriseGanreCode = sqlCommand.Parameters.Add("@ENTERPRISEGANRECODE", SqlDbType.Int);
                SqlParameter paraEnterpriseGanreName = sqlCommand.Parameters.Add("@ENTERPRISEGANRENAME", SqlDbType.NVarChar);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                SqlParameter paraWarehouseShelfNo = sqlCommand.Parameters.Add("@WAREHOUSESHELFNO", SqlDbType.NVarChar);
                SqlParameter paraStockOrderDivCd = sqlCommand.Parameters.Add("@STOCKORDERDIVCD", SqlDbType.Int);
                SqlParameter paraOpenPriceDiv = sqlCommand.Parameters.Add("@OPENPRICEDIV", SqlDbType.Int);
                SqlParameter paraGoodsRateRank = sqlCommand.Parameters.Add("@GOODSRATERANK", SqlDbType.NChar);
                SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                SqlParameter paraSuppRateGrpCode = sqlCommand.Parameters.Add("@SUPPRATEGRPCODE", SqlDbType.Int);
                SqlParameter paraListPriceTaxExcFl = sqlCommand.Parameters.Add("@LISTPRICETAXEXCFL", SqlDbType.Float);
                SqlParameter paraListPriceTaxIncFl = sqlCommand.Parameters.Add("@LISTPRICETAXINCFL", SqlDbType.Float);
                SqlParameter paraStockRate = sqlCommand.Parameters.Add("@STOCKRATE", SqlDbType.Float);
                SqlParameter paraRateSectStckUnPrc = sqlCommand.Parameters.Add("@RATESECTSTCKUNPRC", SqlDbType.NChar);
                SqlParameter paraRateDivStckUnPrc = sqlCommand.Parameters.Add("@RATEDIVSTCKUNPRC", SqlDbType.NChar);
                SqlParameter paraUnPrcCalcCdStckUnPrc = sqlCommand.Parameters.Add("@UNPRCCALCCDSTCKUNPRC", SqlDbType.Int);
                SqlParameter paraPriceCdStckUnPrc = sqlCommand.Parameters.Add("@PRICECDSTCKUNPRC", SqlDbType.Int);
                SqlParameter paraStdUnPrcStckUnPrc = sqlCommand.Parameters.Add("@STDUNPRCSTCKUNPRC", SqlDbType.Float);
                SqlParameter paraFracProcUnitStcUnPrc = sqlCommand.Parameters.Add("@FRACPROCUNITSTCUNPRC", SqlDbType.Float);
                SqlParameter paraFracProcStckUnPrc = sqlCommand.Parameters.Add("@FRACPROCSTCKUNPRC", SqlDbType.Int);
                SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraStockUnitTaxPriceFl = sqlCommand.Parameters.Add("@STOCKUNITTAXPRICEFL", SqlDbType.Float);
                SqlParameter paraStockUnitChngDiv = sqlCommand.Parameters.Add("@STOCKUNITCHNGDIV", SqlDbType.Int);
                SqlParameter paraBfStockUnitPriceFl = sqlCommand.Parameters.Add("@BFSTOCKUNITPRICEFL", SqlDbType.Float);
                SqlParameter paraBfListPrice = sqlCommand.Parameters.Add("@BFLISTPRICE", SqlDbType.Float);
                SqlParameter paraRateBLGoodsCode = sqlCommand.Parameters.Add("@RATEBLGOODSCODE", SqlDbType.Int);
                SqlParameter paraRateBLGoodsName = sqlCommand.Parameters.Add("@RATEBLGOODSNAME", SqlDbType.NVarChar);
                SqlParameter paraRateGoodsRateGrpCd = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPCD", SqlDbType.Int);
                SqlParameter paraRateGoodsRateGrpNm = sqlCommand.Parameters.Add("@RATEGOODSRATEGRPNM", SqlDbType.NVarChar);
                SqlParameter paraRateBLGroupCode = sqlCommand.Parameters.Add("@RATEBLGROUPCODE", SqlDbType.Int);
                SqlParameter paraRateBLGroupName = sqlCommand.Parameters.Add("@RATEBLGROUPNAME", SqlDbType.NVarChar);
                SqlParameter paraStockCount = sqlCommand.Parameters.Add("@STOCKCOUNT", SqlDbType.Float);
                SqlParameter paraOrderCnt = sqlCommand.Parameters.Add("@ORDERCNT", SqlDbType.Float);
                SqlParameter paraOrderAdjustCnt = sqlCommand.Parameters.Add("@ORDERADJUSTCNT", SqlDbType.Float);
                SqlParameter paraOrderRemainCnt = sqlCommand.Parameters.Add("@ORDERREMAINCNT", SqlDbType.Float);
                SqlParameter paraRemainCntUpdDate = sqlCommand.Parameters.Add("@REMAINCNTUPDDATE", SqlDbType.Int);
                SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                SqlParameter paraStockPriceTaxInc = sqlCommand.Parameters.Add("@STOCKPRICETAXINC", SqlDbType.BigInt);
                SqlParameter paraStockGoodsCd = sqlCommand.Parameters.Add("@STOCKGOODSCD", SqlDbType.Int);
                SqlParameter paraStockPriceConsTax = sqlCommand.Parameters.Add("@STOCKPRICECONSTAX", SqlDbType.BigInt);
                SqlParameter paraTaxationCode = sqlCommand.Parameters.Add("@TAXATIONCODE", SqlDbType.Int);
                SqlParameter paraStockDtiSlipNote1 = sqlCommand.Parameters.Add("@STOCKDTISLIPNOTE1", SqlDbType.NVarChar);
                SqlParameter paraSalesCustomerCode = sqlCommand.Parameters.Add("@SALESCUSTOMERCODE", SqlDbType.Int);
                SqlParameter paraSalesCustomerSnm = sqlCommand.Parameters.Add("@SALESCUSTOMERSNM", SqlDbType.NVarChar);
                SqlParameter paraSlipMemo1 = sqlCommand.Parameters.Add("@SLIPMEMO1", SqlDbType.NVarChar);
                SqlParameter paraSlipMemo2 = sqlCommand.Parameters.Add("@SLIPMEMO2", SqlDbType.NVarChar);
                SqlParameter paraSlipMemo3 = sqlCommand.Parameters.Add("@SLIPMEMO3", SqlDbType.NVarChar);
                SqlParameter paraInsideMemo1 = sqlCommand.Parameters.Add("@INSIDEMEMO1", SqlDbType.NVarChar);
                SqlParameter paraInsideMemo2 = sqlCommand.Parameters.Add("@INSIDEMEMO2", SqlDbType.NVarChar);
                SqlParameter paraInsideMemo3 = sqlCommand.Parameters.Add("@INSIDEMEMO3", SqlDbType.NVarChar);
                SqlParameter paraSupplierCd = sqlCommand.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                SqlParameter paraSupplierSnm = sqlCommand.Parameters.Add("@SUPPLIERSNM", SqlDbType.NVarChar);
                SqlParameter paraAddresseeCode = sqlCommand.Parameters.Add("@ADDRESSEECODE", SqlDbType.Int);
                SqlParameter paraAddresseeName = sqlCommand.Parameters.Add("@ADDRESSEENAME", SqlDbType.NVarChar);
                SqlParameter paraDirectSendingCd = sqlCommand.Parameters.Add("@DIRECTSENDINGCD", SqlDbType.Int);
                SqlParameter paraOrderNumber = sqlCommand.Parameters.Add("@ORDERNUMBER", SqlDbType.NVarChar);
                SqlParameter paraWayToOrder = sqlCommand.Parameters.Add("@WAYTOORDER", SqlDbType.Int);
                SqlParameter paraDeliGdsCmpltDueDate = sqlCommand.Parameters.Add("@DELIGDSCMPLTDUEDATE", SqlDbType.Int);
                SqlParameter paraExpectDeliveryDate = sqlCommand.Parameters.Add("@EXPECTDELIVERYDATE", SqlDbType.Int);
                SqlParameter paraOrderDataCreateDiv = sqlCommand.Parameters.Add("@ORDERDATACREATEDIV", SqlDbType.Int);
                SqlParameter paraOrderDataCreateDate = sqlCommand.Parameters.Add("@ORDERDATACREATEDATE", SqlDbType.Int);
                SqlParameter paraOrderFormIssuedDiv = sqlCommand.Parameters.Add("@ORDERFORMISSUEDDIV", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.CreateDateTime);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockDetailWork.UpdateDateTime);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterPriseCode);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockDetailWork.FileHeaderGuid);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockDetailWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.LogicalDeleteCode);
                paraAcceptAnOrderNo.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.AcceptAnOrderNo);
                paraSupplierFormal.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormal);
                paraSupplierSlipNo.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierSlipNo);
                paraStockRowNo.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockRowNo);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.SectionCode);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SubSectionCode);
                paraCommonSeqNo.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.CommonSeqNo);
                paraStockSlipDtlNum.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNum);
                paraSupplierFormalSrc.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierFormalSrc);
                paraStockSlipDtlNumSrc.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockSlipDtlNumSrc);
                paraAcptAnOdrStatusSync.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.AcptAnOdrStatusSync);
                paraSalesSlipDtlNumSync.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.SalesSlipDtlNumSync);
                paraStockSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockSlipCdDtl);
                paraStockInputCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockInputCode);
                paraStockInputName.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockInputName);
                paraStockAgentCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockAgentCode);
                paraStockAgentName.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockAgentName);
                paraGoodsKindCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.GoodsKindCode);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.GoodsMakerCd);
                paraMakerName.Value = SqlDataMediator.SqlSetString(stockDetailWork.MakerName);
                paraMakerKanaName.Value = SqlDataMediator.SqlSetString(stockDetailWork.MakerKanaName);
                paraCmpltMakerKanaName.Value = SqlDataMediator.SqlSetString(stockDetailWork.CmpltMakerKanaName);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsNo);
                paraGoodsName.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsName);
                paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsNameKana);
                paraGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.GoodsLGroup);
                paraGoodsLGroupName.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsLGroupName);
                paraGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.GoodsMGroup);
                paraGoodsMGroupName.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsMGroupName);
                paraBLGroupCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.BLGroupCode);
                paraBLGroupName.Value = SqlDataMediator.SqlSetString(stockDetailWork.BLGroupName);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.BLGoodsCode);
                paraBLGoodsFullName.Value = SqlDataMediator.SqlSetString(stockDetailWork.BLGoodsFullName);
                paraEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.EnterpriseGanreCode);
                paraEnterpriseGanreName.Value = SqlDataMediator.SqlSetString(stockDetailWork.EnterpriseGanreName);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockDetailWork.WarehouseCode);
                paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockDetailWork.WarehouseName);
                paraWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(stockDetailWork.WarehouseShelfNo);
                paraStockOrderDivCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockOrderDivCd);
                paraOpenPriceDiv.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.OpenPriceDiv);
                paraGoodsRateRank.Value = SqlDataMediator.SqlSetString(stockDetailWork.GoodsRateRank);
                paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.CustRateGrpCode);
                paraSuppRateGrpCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SuppRateGrpCode);
                paraListPriceTaxExcFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.ListPriceTaxExcFl);
                paraListPriceTaxIncFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.ListPriceTaxIncFl);
                paraStockRate.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StockRate);
                paraRateSectStckUnPrc.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateSectStckUnPrc);
                paraRateDivStckUnPrc.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateDivStckUnPrc);
                paraUnPrcCalcCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.UnPrcCalcCdStckUnPrc);
                paraPriceCdStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.PriceCdStckUnPrc);
                paraStdUnPrcStckUnPrc.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StdUnPrcStckUnPrc);
                paraFracProcUnitStcUnPrc.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.FracProcUnitStcUnPrc);
                paraFracProcStckUnPrc.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.FracProcStckUnPrc);
                paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StockUnitPriceFl);
                paraStockUnitTaxPriceFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StockUnitTaxPriceFl);
                paraStockUnitChngDiv.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockUnitChngDiv);
                paraBfStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.BfStockUnitPriceFl);
                paraBfListPrice.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.BfListPrice);
                paraRateBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.RateBLGoodsCode);
                paraRateBLGoodsName.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateBLGoodsName);
                paraRateGoodsRateGrpCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.RateGoodsRateGrpCd);
                paraRateGoodsRateGrpNm.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateGoodsRateGrpNm);
                paraRateBLGroupCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.RateBLGroupCode);
                paraRateBLGroupName.Value = SqlDataMediator.SqlSetString(stockDetailWork.RateBLGroupName);
                paraStockCount.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.StockCount);
                paraOrderCnt.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.OrderCnt);
                paraOrderAdjustCnt.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.OrderAdjustCnt);
                paraOrderRemainCnt.Value = SqlDataMediator.SqlSetDouble(stockDetailWork.OrderRemainCnt);
                paraRemainCntUpdDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDetailWork.RemainCntUpdDate);
                paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockPriceTaxExc);
                paraStockPriceTaxInc.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockPriceTaxInc);
                paraStockGoodsCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.StockGoodsCd);
                paraStockPriceConsTax.Value = SqlDataMediator.SqlSetInt64(stockDetailWork.StockPriceConsTax);
                paraTaxationCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.TaxationCode);
                paraStockDtiSlipNote1.Value = SqlDataMediator.SqlSetString(stockDetailWork.StockDtiSlipNote1);
                paraSalesCustomerCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SalesCustomerCode);
                paraSalesCustomerSnm.Value = SqlDataMediator.SqlSetString(stockDetailWork.SalesCustomerSnm);
                paraSlipMemo1.Value = SqlDataMediator.SqlSetString(stockDetailWork.SlipMemo1);
                paraSlipMemo2.Value = SqlDataMediator.SqlSetString(stockDetailWork.SlipMemo2);
                paraSlipMemo3.Value = SqlDataMediator.SqlSetString(stockDetailWork.SlipMemo3);
                paraInsideMemo1.Value = SqlDataMediator.SqlSetString(stockDetailWork.InsideMemo1);
                paraInsideMemo2.Value = SqlDataMediator.SqlSetString(stockDetailWork.InsideMemo2);
                paraInsideMemo3.Value = SqlDataMediator.SqlSetString(stockDetailWork.InsideMemo3);
                paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.SupplierCd);
                paraSupplierSnm.Value = SqlDataMediator.SqlSetString(stockDetailWork.SupplierSnm);
                paraAddresseeCode.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.AddresseeCode);
                paraAddresseeName.Value = SqlDataMediator.SqlSetString(stockDetailWork.AddresseeName);
                paraDirectSendingCd.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.DirectSendingCd);
                paraOrderNumber.Value = SqlDataMediator.SqlSetString(stockDetailWork.OrderNumber);
                paraWayToOrder.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.WayToOrder);
                paraDeliGdsCmpltDueDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDetailWork.DeliGdsCmpltDueDate);
                paraExpectDeliveryDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDetailWork.ExpectDeliveryDate);
                paraOrderDataCreateDiv.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.OrderDataCreateDiv);
                paraOrderDataCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(stockDetailWork.OrderDataCreateDate);
                paraOrderFormIssuedDiv.Value = SqlDataMediator.SqlSetInt32(stockDetailWork.OrderFormIssuedDiv);

				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<

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

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// クラス格納処理 Reader → stockDetailWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>オブジェクト</returns>
		public APStockDetailWork CopyToStockDetailWorkFromReaderSCM(ref SqlDataReader myReader, string tableNm)
		{
			APStockDetailWork stockDetailWork = new APStockDetailWork();

			this.CopyToStockDetailWorkFromReaderSCM(ref myReader, ref stockDetailWork, tableNm);

			return stockDetailWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → stockDetailWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="stockDetailWork">stockDetailWork オブジェクト</param>
		/// <param name="tableNm">tableNm</param>
		/// <returns>void</returns>
		private void CopyToStockDetailWorkFromReaderSCM(ref SqlDataReader myReader, ref APStockDetailWork stockDetailWork, string tableNm)
		{
			if (myReader != null && stockDetailWork != null)
			{
				# region クラスへ格納
				stockDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "CREATEDATETIMERF"));
				stockDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal(tableNm + "UPDATEDATETIMERF"));
				stockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISECODERF"));
				stockDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal(tableNm + "FILEHEADERGUIDRF"));
				stockDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDEMPLOYEECODERF"));
				stockDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID1RF"));
				stockDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "UPDASSEMBLYID2RF"));
				stockDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "LOGICALDELETECODERF"));
				stockDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACCEPTANORDERNORF"));
				stockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALRF"));
				stockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSLIPNORF"));
				stockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKROWNORF"));
				stockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SECTIONCODERF"));
				stockDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUBSECTIONCODERF"));
				stockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "COMMONSEQNORF"));
				stockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPDTLNUMRF"));
				stockDetailWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERFORMALSRCRF"));
				stockDetailWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPDTLNUMSRCRF"));
				stockDetailWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ACPTANODRSTATUSSYNCRF"));
				stockDetailWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "SALESSLIPDTLNUMSYNCRF"));
				stockDetailWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKSLIPCDDTLRF"));
				stockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKINPUTCODERF"));
				stockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKINPUTNAMERF"));
				stockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTCODERF"));
				stockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKAGENTNAMERF"));
				stockDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSKINDCODERF"));
				stockDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSMAKERCDRF"));
				stockDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERNAMERF"));
				stockDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "MAKERKANANAMERF"));
				stockDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "CMPLTMAKERKANANAMERF"));
				stockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNORF"));
				stockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNAMERF"));
				stockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSNAMEKANARF"));
				stockDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSLGROUPRF"));
				stockDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSLGROUPNAMERF"));
				stockDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "GOODSMGROUPRF"));
				stockDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSMGROUPNAMERF"));
				stockDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BLGROUPCODERF"));
				stockDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BLGROUPNAMERF"));
				stockDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "BLGOODSCODERF"));
				stockDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "BLGOODSFULLNAMERF"));
				stockDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISEGANRECODERF"));
				stockDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ENTERPRISEGANRENAMERF"));
				stockDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSECODERF"));
				stockDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSENAMERF"));
				stockDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "WAREHOUSESHELFNORF"));
				stockDetailWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKORDERDIVCDRF"));
				stockDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "OPENPRICEDIVRF"));
				stockDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "GOODSRATERANKRF"));
				stockDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "CUSTRATEGRPCODERF"));
				stockDetailWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPRATEGRPCODERF"));
				stockDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICETAXEXCFLRF"));
				stockDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "LISTPRICETAXINCFLRF"));
				stockDetailWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STOCKRATERF"));
				stockDetailWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATESECTSTCKUNPRCRF"));
				stockDetailWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEDIVSTCKUNPRCRF"));
				stockDetailWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "UNPRCCALCCDSTCKUNPRCRF"));
				stockDetailWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "PRICECDSTCKUNPRCRF"));
				stockDetailWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STDUNPRCSTCKUNPRCRF"));
				stockDetailWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "FRACPROCUNITSTCUNPRCRF"));
				stockDetailWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "FRACPROCSTCKUNPRCRF"));
				stockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STOCKUNITPRICEFLRF"));
				stockDetailWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STOCKUNITTAXPRICEFLRF"));
				stockDetailWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKUNITCHNGDIVRF"));
				stockDetailWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFSTOCKUNITPRICEFLRF"));
				stockDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "BFLISTPRICERF"));
				stockDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEBLGOODSCODERF"));
				stockDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEBLGOODSNAMERF"));
				stockDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEGOODSRATEGRPCDRF"));
				stockDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEGOODSRATEGRPNMRF"));
				stockDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "RATEBLGROUPCODERF"));
				stockDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "RATEBLGROUPNAMERF"));
				stockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "STOCKCOUNTRF"));
				stockDetailWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "ORDERCNTRF"));
				stockDetailWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "ORDERADJUSTCNTRF"));
				stockDetailWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal(tableNm + "ORDERREMAINCNTRF"));
				stockDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "REMAINCNTUPDDATERF"));
				stockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICETAXEXCRF"));
				stockDetailWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICETAXINCRF"));
				stockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "STOCKGOODSCDRF"));
				stockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal(tableNm + "STOCKPRICECONSTAXRF"));
				stockDetailWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "TAXATIONCODERF"));
				stockDetailWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "STOCKDTISLIPNOTE1RF"));
				stockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SALESCUSTOMERCODERF"));
				stockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SALESCUSTOMERSNMRF"));
				stockDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO1RF"));
				stockDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO2RF"));
				stockDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SLIPMEMO3RF"));
				stockDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO1RF"));
				stockDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO2RF"));
				stockDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "INSIDEMEMO3RF"));
				stockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERCDRF"));
				stockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "SUPPLIERSNMRF"));
				stockDetailWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEECODERF"));
				stockDetailWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ADDRESSEENAMERF"));
				stockDetailWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "DIRECTSENDINGCDRF"));
				stockDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal(tableNm + "ORDERNUMBERRF"));
				stockDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "WAYTOORDERRF"));
				stockDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "DELIGDSCMPLTDUEDATERF"));
				stockDetailWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "EXPECTDELIVERYDATERF"));
				stockDetailWork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ORDERDATACREATEDIVRF"));
				stockDetailWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal(tableNm + "ORDERDATACREATEDATERF"));
				stockDetailWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal(tableNm + "ORDERFORMISSUEDDIVRF"));
				# endregion
			}
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

		#region [--- DEL 2011/09/15 張莉莉　SCM対応‐拠点管理（10704767-00）---]
		//// ADD 2011/09/08 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>

		//// ADD 2009/06/11 --->>>
		//// Rクラスのpublic MethodでSQL文字が駄目
		///// <summary>
		///// 仕入明細データの検索処理
		///// </summary>
		///// <param name="sectionCode">拠点コード</param>
		///// <param name="beginningDate">開始日付</param>
		///// <param name="endingDate">終了日付</param>
		///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
		///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		///// <param name="stockDetailArrList">仕入明細データオブジェクト</param>
		///// <param name="retMessage">戻るメッセージ</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : 仕入明細データREADLISTを全て戻します</br>
		///// <br>Programmer : 譚洪</br>
		///// <br>Date       : 2009.04.01</br>
		///// 
		//public int SearchStockDetail(string sectionCode, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
		//    SqlTransaction sqlTransaction, out ArrayList stockDetailArrList, out string retMessage)
		//{
		//    return SearchStockDetailProc(sectionCode, beginningDate, endingDate, sqlConnection,
		//     sqlTransaction, out  stockDetailArrList, out  retMessage);
		//}

		///// <summary>
		///// 仕入明細データの検索処理
		///// </summary>
		///// <param name="sectionCode">拠点コード</param>
		///// <param name="beginningDate">開始日付</param>
		///// <param name="endingDate">終了日付</param>
		///// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
		///// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
		///// <param name="stockDetailArrList">仕入明細データオブジェクト</param>
		///// <param name="retMessage">戻るメッセージ</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : 仕入明細データREADLISTを全て戻します</br>
		///// <br>Programmer : 譚洪</br>
		///// <br>Date       : 2009.04.01</br>
		///// 
		//private int SearchStockDetailProc(string sectionCode, Int64 beginningDate, Int64 endingDate, SqlConnection sqlConnection,
		//    SqlTransaction sqlTransaction, out ArrayList stockDetailArrList, out string retMessage)
		//{
		//    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//    stockDetailArrList = new ArrayList();
		//    APStockDetailWork stockDetailWork = null;
		//    retMessage = string.Empty;
		//    string sqlStr = string.Empty;
		//    SqlDataReader myReader = null;
		//    SqlCommand sqlCommand = null;

		//    try
		//    {
		//        sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

		//        sqlStr = "SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, ACCEPTANORDERNORF, SUPPLIERFORMALRF, SUPPLIERSLIPNORF, STOCKROWNORF, SECTIONCODERF, SUBSECTIONCODERF, COMMONSEQNORF, STOCKSLIPDTLNUMRF, SUPPLIERFORMALSRCRF, STOCKSLIPDTLNUMSRCRF, ACPTANODRSTATUSSYNCRF, SALESSLIPDTLNUMSYNCRF, STOCKSLIPCDDTLRF, STOCKINPUTCODERF, STOCKINPUTNAMERF, STOCKAGENTCODERF, STOCKAGENTNAMERF, GOODSKINDCODERF, GOODSMAKERCDRF, MAKERNAMERF, MAKERKANANAMERF, CMPLTMAKERKANANAMERF, GOODSNORF, GOODSNAMERF, GOODSNAMEKANARF, GOODSLGROUPRF, GOODSLGROUPNAMERF, GOODSMGROUPRF, GOODSMGROUPNAMERF, BLGROUPCODERF, BLGROUPNAMERF, BLGOODSCODERF, BLGOODSFULLNAMERF, ENTERPRISEGANRECODERF, ENTERPRISEGANRENAMERF, WAREHOUSECODERF, WAREHOUSENAMERF, WAREHOUSESHELFNORF, STOCKORDERDIVCDRF, OPENPRICEDIVRF, GOODSRATERANKRF, CUSTRATEGRPCODERF, SUPPRATEGRPCODERF, LISTPRICETAXEXCFLRF, LISTPRICETAXINCFLRF, STOCKRATERF, RATESECTSTCKUNPRCRF, RATEDIVSTCKUNPRCRF, UNPRCCALCCDSTCKUNPRCRF, PRICECDSTCKUNPRCRF, STDUNPRCSTCKUNPRCRF, FRACPROCUNITSTCUNPRCRF, FRACPROCSTCKUNPRCRF, STOCKUNITPRICEFLRF, STOCKUNITTAXPRICEFLRF, STOCKUNITCHNGDIVRF, BFSTOCKUNITPRICEFLRF, BFLISTPRICERF, RATEBLGOODSCODERF, RATEBLGOODSNAMERF, RATEGOODSRATEGRPCDRF, RATEGOODSRATEGRPNMRF, RATEBLGROUPCODERF, RATEBLGROUPNAMERF, STOCKCOUNTRF, ORDERCNTRF, ORDERADJUSTCNTRF, ORDERREMAINCNTRF, REMAINCNTUPDDATERF, STOCKPRICETAXEXCRF, STOCKPRICETAXINCRF, STOCKGOODSCDRF, STOCKPRICECONSTAXRF, TAXATIONCODERF, STOCKDTISLIPNOTE1RF, SALESCUSTOMERCODERF, SALESCUSTOMERSNMRF, SLIPMEMO1RF, SLIPMEMO2RF, SLIPMEMO3RF, INSIDEMEMO1RF, INSIDEMEMO2RF, INSIDEMEMO3RF, SUPPLIERCDRF, SUPPLIERSNMRF, ADDRESSEECODERF, ADDRESSEENAMERF, DIRECTSENDINGCDRF, ORDERNUMBERRF, WAYTOORDERRF, DELIGDSCMPLTDUEDATERF, EXPECTDELIVERYDATERF, ORDERDATACREATEDIVRF, ORDERDATACREATEDATERF, ORDERFORMISSUEDDIVRF FROM STOCKDETAILRF WHERE SUPPLIERFORMALRF=2 AND SUPPLIERSLIPNORF=0 AND SECTIONCODERF=@FINDSECTIONCODE AND UPDATEDATETIMERF > @UPDATEDATETIMEBEGRF AND UPDATEDATETIMERF <= @UPDATEDATETIMEENDRF";

		//        //Prameterオブジェクトの作成
		//        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
		//        SqlParameter findParaUpdateDateTimeBeg = sqlCommand.Parameters.Add("@UPDATEDATETIMEBEGRF", SqlDbType.BigInt);
		//        SqlParameter findParaUpdateDateTimeEnd = sqlCommand.Parameters.Add("@UPDATEDATETIMEENDRF", SqlDbType.BigInt);

		//        //Parameterオブジェクトへ値設定
		//        findParaSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode);
		//        findParaUpdateDateTimeBeg.Value = SqlDataMediator.SqlSetInt64(beginningDate);
		//        findParaUpdateDateTimeEnd.Value = SqlDataMediator.SqlSetInt64(endingDate);

		//        // 仕入明細データ用SQL
		//        sqlCommand.CommandText = sqlStr;
		//        // 読み込み
		//        myReader = sqlCommand.ExecuteReader();

		//        while (myReader.Read())
		//        {
		//            stockDetailWork = new APStockDetailWork();

		//            stockDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
		//            stockDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
		//            stockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
		//            stockDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
		//            stockDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
		//            stockDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
		//            stockDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
		//            stockDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
		//            stockDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
		//            stockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
		//            stockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
		//            stockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
		//            stockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
		//            stockDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
		//            stockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
		//            stockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
		//            stockDetailWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
		//            stockDetailWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
		//            stockDetailWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
		//            stockDetailWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
		//            stockDetailWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
		//            stockDetailWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
		//            stockDetailWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
		//            stockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
		//            stockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
		//            stockDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
		//            stockDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
		//            stockDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
		//            stockDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
		//            stockDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
		//            stockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
		//            stockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
		//            stockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
		//            stockDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
		//            stockDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
		//            stockDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
		//            stockDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
		//            stockDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
		//            stockDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
		//            stockDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
		//            stockDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
		//            stockDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
		//            stockDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
		//            stockDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
		//            stockDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
		//            stockDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
		//            stockDetailWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
		//            stockDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
		//            stockDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
		//            stockDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
		//            stockDetailWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
		//            stockDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
		//            stockDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
		//            stockDetailWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
		//            stockDetailWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
		//            stockDetailWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
		//            stockDetailWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
		//            stockDetailWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
		//            stockDetailWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
		//            stockDetailWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
		//            stockDetailWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
		//            stockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
		//            stockDetailWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
		//            stockDetailWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
		//            stockDetailWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
		//            stockDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
		//            stockDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
		//            stockDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
		//            stockDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
		//            stockDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
		//            stockDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
		//            stockDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
		//            stockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
		//            stockDetailWork.OrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERCNTRF"));
		//            stockDetailWork.OrderAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERADJUSTCNTRF"));
		//            stockDetailWork.OrderRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ORDERREMAINCNTRF"));
		//            stockDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));
		//            stockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
		//            stockDetailWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
		//            stockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
		//            stockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
		//            stockDetailWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
		//            stockDetailWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
		//            stockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
		//            stockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
		//            stockDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
		//            stockDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
		//            stockDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
		//            stockDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
		//            stockDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
		//            stockDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
		//            stockDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
		//            stockDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
		//            stockDetailWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
		//            stockDetailWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
		//            stockDetailWork.DirectSendingCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DIRECTSENDINGCDRF"));
		//            stockDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
		//            stockDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
		//            stockDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));
		//            stockDetailWork.ExpectDeliveryDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EXPECTDELIVERYDATERF"));
		//            stockDetailWork.OrderDataCreateDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERDATACREATEDIVRF"));
		//            stockDetailWork.OrderDataCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ORDERDATACREATEDATERF"));
		//            stockDetailWork.OrderFormIssuedDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ORDERFORMISSUEDDIVRF"));


		//            stockDetailArrList.Add(stockDetailWork);
		//        }

		//        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//    }
		//    catch (SqlException ex)
		//    {
		//        //基底クラスに例外を渡して処理してもらう
		//        base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.UpdateShipmentDir Exception=" + ex.Message);
		//        retMessage = ex.Message;
		//        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
		//    }
		//    finally
		//    {
		//        if (myReader != null)
		//            if (!myReader.IsClosed) myReader.Close();

		//        if (sqlCommand != null)
		//        {
		//            sqlCommand.Cancel();
		//            sqlCommand.Dispose();
		//        }
		//    }
		//    return status;
		//}

		//// ADD 2011/09/08 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
		#endregion [--- DEL 2011/09/15 張莉莉　SCM対応‐拠点管理（10704767-00）---]
    }
}
